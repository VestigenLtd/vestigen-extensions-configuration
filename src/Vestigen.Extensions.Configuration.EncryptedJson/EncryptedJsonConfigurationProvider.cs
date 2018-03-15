using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Vestigen.Extensions.Configuration.EncryptedJson
{
    /// <summary>
    /// Represents encrypted JSON file based <see cref="ConfigurationProvider"/>.
    /// </summary>
    public class EncryptedJsonConfigurationProvider : FileConfigurationProvider
    {
        private readonly EncryptedJsonConfigurationFileParser _parser;

        /// <summary>
        /// Creates a new instance of <see cref="EncryptedJsonConfigurationProvider"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cryptographer">The <see cref="IConfigurationCryptographer"/> to use for managing secure values.</param>
        public EncryptedJsonConfigurationProvider(EncryptedJsonConfigurationSource source, IConfigurationCryptographer cryptographer) : base(source)
        {
            var cryptographer1 = cryptographer ?? throw new ArgumentNullException(nameof(cryptographer));
            _parser = new EncryptedJsonConfigurationFileParser(cryptographer1);
        }

        public override void Load(Stream stream)
        {
            try
            {
                Data = _parser.ParseStream(stream);
            }
            catch (JsonReaderException e)
            {
                var errorLine = string.Empty;
                if (stream.CanSeek)
                {
                    stream.Seek(0, SeekOrigin.Begin);

                    using (var streamReader = new StreamReader(stream))
                    {
                        var fileContent = ReadLines(streamReader);
                        errorLine = RetrieveErrorContext(e, fileContent);
                    }
                }

                throw new FormatException($"Could not parse the JSON file. Error on line number '{e.LineNumber}': '{errorLine}'.", e);
            }
        }

        private static string RetrieveErrorContext(JsonReaderException e, IEnumerable<string> fileContent)
        {
            string errorLine = null;
            if (e.LineNumber >= 2)
            {
                var errorContext = fileContent.Skip(e.LineNumber - 2).Take(2).ToList();
                // Handle situations when the line number reported is out of bounds
                if (errorContext.Count() >= 2)
                {
                    errorLine = errorContext[0].Trim() + Environment.NewLine + errorContext[1].Trim();
                }
            }
            if (string.IsNullOrEmpty(errorLine))
            {
                var possibleLineContent = fileContent.Skip(e.LineNumber - 1).FirstOrDefault();
                errorLine = possibleLineContent ?? string.Empty;
            }
            return errorLine;
        }

        private static IEnumerable<string> ReadLines(StreamReader streamReader)
        {
            string line;
            do
            {
                line = streamReader.ReadLine();
                yield return line;
            } while (line != null);
        }
    }
}
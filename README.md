Configuration
=============

AppVeyor: Coming Soon

Travis:   Coming Soon

Configuration is a framework and set of abstractions for accessing key/value configuration values in an application using providers for multiple remote stores, such as Vault or Consul. Others such as Archaius, Zookeeper, and etcd are being considered for future development.

Overview
--------

This framework follows the same architectual model as the `Microsoft.Extensions.*` NuGet packages that are owned and maintained by the Microsoft ASP.NET team.

This particular framework is a **downstream** package for which there are upstream packages on which to build, and should be considered as an extension to those in the `Microsoft.Extensions.Configuration.*` namespace.

Packages
--------

The vision for this framework is to maintain framework compatibility for `netstandard1.4` and `netstandard2.0` as much as possible. This is only possible if the underlying libraries maintain support for these same framework versions and may/may not follow this vision. Any exceptions to this rule will be noted below in the package list. For more information on framework version targeting, please see [this document](https://docs.microsoft.com/en-us/dotnet/standard/net-standard).

The packages are published with unsigned assemblies.

The packages produced from this repository are as follows:

- Vestigen.Extensions.Configuration.Vault
- Vestigen.Extensions.Configuration.Consul


Samples
-------

See `samples/ConsoleApp` as an example of how to implement the package.

Each provider will have it's own implementation specific details for the given framework in which it encapsulates. Viewing the test suites can assist with bootstraping a particular implementation.


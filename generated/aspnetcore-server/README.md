# BlueIQ.Api.Server - ASP.NET Core 8.0 Server

This document describes the API for the BlueIQ API Gateway.
It serves as the single entry point for all client interactions with the BlueIQ microservices.
This specification is designed to be a reference for consumers and a template for similar gateway patterns.


## Upgrade NuGet Packages

NuGet packages get frequently updated.

To upgrade this solution to the latest version of all NuGet packages, use the dotnet-outdated tool.


Install dotnet-outdated tool:

```
dotnet tool install --global dotnet-outdated-tool
```

Upgrade only to new minor versions of packages

```
dotnet outdated --upgrade --version-lock Major
```

Upgrade to all new versions of packages (more likely to include breaking API changes)

```
dotnet outdated --upgrade
```


## Run

Linux/OS X:

```
sh build.sh
```

Windows:

```
build.bat
```
## Run in Docker

```
cd src/BlueIQ.Api.Server
docker build -t blueiq.api.server .
docker run -p 5000:8080 blueiq.api.server
```

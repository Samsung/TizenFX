# TizenFX

[![License](https://img.shields.io/badge/licence-Apache%202.0-brightgreen.svg?label=License&style=flat-square)](LICENSE)
[![Build](https://img.shields.io/github/actions/workflow/status/Samsung/TizenFX/build-branches.yml?query=branch%3Amaster?label=Build&style=flat-square)](https://github.com/Samsung/TizenFX/actions?query=workflow%3A%22Build+Branches%22+branch%3Amaster)

TizenFX API, which allows you to access platform-specific features not covered by the generic .NET and .NET MAUI features, such as system information and status, battery status, sensor date, and account and connectivity services.

## Branches

| Branch | API Level | Target Framework | API Reference | Platform          | myget.org | nuget.org  |
|--------|:---------:|------------------|---------------|-------------------|-----------|------------|
|master  | 11        | tizen11.0 | [Link](https://samsung.github.io/TizenFX/master/) | Tizen vNext | [![api11_myget](https://img.shields.io/tizen.myget/dotnet/vpre/Tizen.NET.API11.svg)](https://tizen.myget.org/feed/dotnet/package/nuget/Tizen.NET) |  |
|API10   | 10        | tizen10.0 | [Link](https://samsung.github.io/TizenFX/API10/) | Tizen 7.0 | [![api10_myget](https://img.shields.io/tizen.myget/dotnet/vpre/Tizen.NET.API10.svg)](https://tizen.myget.org/feed/dotnet/package/nuget/Tizen.NET) | [![api10_nuget](https://img.shields.io/nuget/v/Tizen.NET.API10.svg)](https://www.nuget.org/packages/Tizen.NET/) |
|API9    | 9         | tizen90   | [Link](https://samsung.github.io/TizenFX/API9/) | Tizen 6.5 | [![api9_myget](https://img.shields.io/tizen.myget/dotnet/vpre/Tizen.NET.API9.svg)](https://tizen.myget.org/feed/dotnet/package/nuget/Tizen.NET) | [![api9_nuget](https://img.shields.io/nuget/v/Tizen.NET.API9.svg)](https://www.nuget.org/packages/Tizen.NET/) |
|API8    | 8         | tizen80   | [Link](https://samsung.github.io/TizenFX/API8/) | Tizen 6.0 | [![api8_myget](https://img.shields.io/tizen.myget/dotnet/vpre/Tizen.NET.API8.svg)](https://tizen.myget.org/feed/dotnet/package/nuget/Tizen.NET) | [![api8_nuget](https://img.shields.io/nuget/v/Tizen.NET.API8.svg)](https://www.nuget.org/packages/Tizen.NET/) |
|API7    | 7         | tizen70   | [Link](https://samsung.github.io/TizenFX/API7/) | Tizen 5.5 M3 | [![api7_myget](https://img.shields.io/tizen.myget/dotnet/vpre/Tizen.NET.API7.svg)](https://tizen.myget.org/feed/dotnet/package/nuget/Tizen.NET) | [![api7_nuget](https://img.shields.io/nuget/v/Tizen.NET.API7.svg)](https://www.nuget.org/packages/Tizen.NET/) |
|API6    | 6         | tizen60   | [Link](https://samsung.github.io/TizenFX/API6/) | Tizen 5.5 M2 | [![api6_myget](https://img.shields.io/tizen.myget/dotnet/vpre/Tizen.NET.API6.svg)](https://tizen.myget.org/feed/dotnet/package/nuget/Tizen.NET) | [![api6_nuget](https://img.shields.io/nuget/v/Tizen.NET.API6.svg)](https://www.nuget.org/packages/Tizen.NET/) |
|API5    | 5         | tizen50   | [Link](https://samsung.github.io/TizenFX/API5/) | Tizen 5.0       | [![api5_myget](https://img.shields.io/tizen.myget/dotnet/vpre/Tizen.NET.API5.svg)](https://tizen.myget.org/feed/dotnet/package/nuget/Tizen.NET) | [![api5_nuget](https://img.shields.io/nuget/v/Tizen.NET.API5.svg)](https://www.nuget.org/packages/Tizen.NET/) |
|API4    | 4         | tizen40   | [Link](https://samsung.github.io/TizenFX/API4/) | Tizen 4.0         | [![api4_myget](https://img.shields.io/tizen.myget/dotnet/vpre/Tizen.NET.API4.svg)](https://tizen.myget.org/feed/dotnet/package/nuget/Tizen.NET) | [![api4_nuget](https://img.shields.io/nuget/v/Tizen.NET.API4.svg)](https://www.nuget.org/packages/Tizen.NET/) |

### master
The __master__ branch is the main development branch for the Tizen .NET __API Level 11__.

The following NuGet packages will be published to [Tizen MyGet Gallery](https://tizen.myget.org/gallery/dotnet) and [Github Packages Registry](https://github.com/orgs/Samsung/packages?tab=packages&q=Tizen.NET) every day if there are any changes. (Nightly Build)

> - MyGet Feed : ```https://tizen.myget.org/F/dotnet/api/v3/index.json```
> - GitHub Packages Feed : ```https://nuget.pkg.github.com/Samsung/index.json```
>   - GitHub Packages only supports authentication using a personal access token (classic). For more information, see [Working with the NuGet registry](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry) and [Managing your personal access tokens](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens)

* Tizen.NET 11.0.0.#####
* Tizen.NET.API11 11.0.0.#####
* Tizen.NET.Internals 11.0.0.#####

And, This branch is pushed to the [tizen branch](https://git.tizen.org/cgit/platform/core/csapi/tizenfx/?h=tizen) in the tizen gerrit and submitted for the Tizen vNext platform.

### API4 ~ API10 branches
The __API#__ branches are the release branch for Tizen .NET __API Level #__.

These release branches were __FROZEN__. No new public APIs can be added to these branches, only bug fixes and internal APIs can be added.

## Using `tizen` target framework
If you want to use the `tizen` target framework, you need to use `Tizen.NET.Sdk` package as the project sdk.
```xml
<Project Sdk="Tizen.NET.Sdk/1.1.9">
  <PropertyGroup>
    <TargetFramework>tizen11.0</TargetFramework>
  </PropertyGroup>
</Project>
```
For more information, please see [Using Tizen.NET.Sdk as SDK-style](https://developer.samsung.com/tizen/blog/en-us/2019/06/13/using-tizennetsdk-as-sdk-style).

### Minimum required versions of Tizen.NET.Sdk and Visual Studio
| API Level | Target Framework | Tizen.NET.Sdk | Visual Studio     |
|:---------:|------------------|---------------|-------------------|
| API11     | tizen11.0        | 1.1.10 (not yet) | 2022           |
| API10     | tizen10.0        | 1.1.9 (recommend) | 2019          |
| API9      | tizen90          | 1.1.7         | 2019              |
| API8      | tizen80          | 1.1.6         | 2019              |
| API7      | tizen70          | 1.0.9         | 2019              |
| API6      | tizen60          | 1.0.9         | 2019              |
| API5      | tizen50          | 1.0.1         | 2017              |
| API4      | tizen40          | 1.0.1         | 2017              |


## Quick Start
### Prerequisites
Install .NET Core SDK : https://www.microsoft.com/net/download/

### Getting the sources
```bash
git clone https://github.com/Samsung/TizenFX.git
cd TizenFX
```
### How to build
```bash
./build.sh full
./build.sh pack
```

## Tizen Project
TizenFX is a part of the [Tizen project](https://www.tizen.org).
You can download the latest binaries with TizenFX from the link below :

| Tizen Version     | Link |
|-------------------|------|
| Tizen 4.0         | http://download.tizen.org/snapshots/tizen/4.0-unified/latest/ |
| Tizen 5.0         | http://download.tizen.org/snapshots/tizen/5.0-unified/latest/ |
| Tizen 5.5         | http://download.tizen.org/snapshots/tizen/5.5-unified/latest/ |
| Tizen 6.0         | http://download.tizen.org/snapshots/tizen/6.0-unified/latest/ |
| Tizen 6.5         | http://download.tizen.org/snapshots/tizen/unified/latest/     |

# TizenFX

[![License](https://img.shields.io/badge/licence-Apache%202.0-brightgreen.svg?label=License&style=flat-square)](LICENSE)
[![Build](https://img.shields.io/github/actions/workflow/status/Samsung/TizenFX/build-branches.yml?query=branch%3Amain?label=Build&style=flat-square)](https://github.com/Samsung/TizenFX/actions?query=workflow%3A%22Build+Branches%22+branch%3Amain)

TizenFX API, which allows you to access platform-specific features not covered by the generic .NET and .NET MAUI features, such as system information and status, battery status, sensor date, and account and connectivity services.

## Branches

| Branch | API Level | Target Framework | API Reference | Platform          | Github Packages | nuget.org  |
|--------|:---------:|------------------|---------------|-------------------|-----------|------------|
|main    | 14        | net8.0-tizen11.0 | [Link](https://samsung.github.io/TizenFX/main/)  | Tizen 11.0 | [![api14_pkg](https://img.shields.io/github/v/tag/Samsung/TizenFX?include_prereleases&filter=v14.*&label=API14&logo=github)](https://github.com/Samsung/TizenFX/pkgs/nuget/Tizen.NET.API14) |  |
|API13   | 13        | net8.0-tizen10.0 | [Link](https://samsung.github.io/TizenFX/API13/) | Tizen 10.0 | [![api13_pkg](https://img.shields.io/github/v/tag/Samsung/TizenFX?include_prereleases&filter=v13.*&label=API13&logo=github)](https://github.com/Samsung/TizenFX/pkgs/nuget/Tizen.NET.API13) | [![api13_nuget](https://img.shields.io/nuget/v/Tizen.NET.API13.svg)](https://www.nuget.org/packages/Tizen.NET/) |
|API12   | 12        | net6.0-tizen9.0  | [Link](https://samsung.github.io/TizenFX/API12/) | Tizen 9.0  | [![api12_pkg](https://img.shields.io/github/v/tag/Samsung/TizenFX?include_prereleases&filter=v12.*&label=API12&logo=github)](https://github.com/Samsung/TizenFX/pkgs/nuget/Tizen.NET.API12) | [![api12_nuget](https://img.shields.io/nuget/v/Tizen.NET.API12.svg)](https://www.nuget.org/packages/Tizen.NET/) |
|API11   | 11        | net6.0-tizen8.0 | [Link](https://samsung.github.io/TizenFX/API11/) | Tizen 8.0 | [![api11_pkg](https://img.shields.io/github/v/tag/Samsung/TizenFX?include_prereleases&filter=v11.*&label=API11&logo=github)](https://github.com/Samsung/TizenFX/pkgs/nuget/Tizen.NET.API11) | [![api11_nuget](https://img.shields.io/nuget/v/Tizen.NET.API11.svg)](https://www.nuget.org/packages/Tizen.NET/) |
|API10   | 10        | tizen10.0 | [Link](https://samsung.github.io/TizenFX/API10/) | Tizen 7.0 | [![api10_pkg](https://img.shields.io/badge/API10-v10.0.0.17864-blue?logo=github)](https://github.com/Samsung/TizenFX/pkgs/nuget/Tizen.NET.API10) | [![api10_nuget](https://img.shields.io/nuget/v/Tizen.NET.API10.svg)](https://www.nuget.org/packages/Tizen.NET/) |
|API9    | 9         | tizen90   | [Link](https://samsung.github.io/TizenFX/API9/) | Tizen 6.5 | [![api9_pkg](https://img.shields.io/badge/API9-v9.0.0.16908-blue?logo=github)](https://github.com/Samsung/TizenFX/pkgs/nuget/Tizen.NET.API9) | [![api9_nuget](https://img.shields.io/nuget/v/Tizen.NET.API9.svg)](https://www.nuget.org/packages/Tizen.NET/) |
|API8    | 8         | tizen80   | [Link](https://samsung.github.io/TizenFX/API8/) | Tizen 6.0 | [![api8_pkg](https://img.shields.io/badge/API8-v8.0.0.15812-blue?logo=github)](https://github.com/Samsung/TizenFX/pkgs/nuget/Tizen.NET.API8) | [![api8_nuget](https://img.shields.io/nuget/v/Tizen.NET.API8.svg)](https://www.nuget.org/packages/Tizen.NET/) |
|API7    | 7         | tizen70   | [Link](https://samsung.github.io/TizenFX/API7/) | Tizen 5.5 M3 |  | [![api7_nuget](https://img.shields.io/nuget/v/Tizen.NET.API7.svg)](https://www.nuget.org/packages/Tizen.NET/) |
|API6    | 6         | tizen60   | [Link](https://samsung.github.io/TizenFX/API6/) | Tizen 5.5 M2 |  | [![api6_nuget](https://img.shields.io/nuget/v/Tizen.NET.API6.svg)](https://www.nuget.org/packages/Tizen.NET/) |
|API5    | 5         | tizen50   | [Link](https://samsung.github.io/TizenFX/API5/) | Tizen 5.0    |  | [![api5_nuget](https://img.shields.io/nuget/v/Tizen.NET.API5.svg)](https://www.nuget.org/packages/Tizen.NET/) |
|API4    | 4         | tizen40   | [Link](https://samsung.github.io/TizenFX/API4/) | Tizen 4.0    |  | [![api4_nuget](https://img.shields.io/nuget/v/Tizen.NET.API4.svg)](https://www.nuget.org/packages/Tizen.NET/) |

### main
The __main__ branch is the main development branch for the Tizen .NET __API Level 14__.

The following NuGet packages will be published to [Tizen MyGet Gallery](https://tizen.myget.org/gallery/dotnet) and [Github Packages Registry](https://github.com/orgs/Samsung/packages?tab=packages&q=Tizen.NET) every day if there are any changes. (Nightly Build)

> - MyGet Feed : ```https://tizen.myget.org/F/dotnet/api/v3/index.json```
> - GitHub Packages Feed : ```https://nuget.pkg.github.com/Samsung/index.json```
>   - GitHub Packages only supports authentication using a personal access token (classic). For more information, see [Working with the NuGet registry](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry) and [Managing your personal access tokens](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens)

* Tizen.NET 14.0.0.#####
* Tizen.NET.API14 14.0.0.#####
* Tizen.NET.Internals 14.0.0.#####

And, This branch is pushed to the [tizen branch](https://git.tizen.org/cgit/platform/core/csapi/tizenfx/?h=tizen) in the tizen gerrit and submitted for the next Tizen platform.

### API4 ~ API13 branches
The __API#__ branches are the release branch for Tizen .NET __API Level #__.

These release branches were __FROZEN__. No new public APIs can be added to these branches, only bug fixes and internal APIs can be added.

## Using `net6.0-tizen` target framework for API11 or API12
If you want to use the `net6.0-tizen` target framework, you need to [install Tizen workload](https://github.com/Samsung/Tizen.NET/wiki/Installing-Tizen-.NET-Workload).

## Using `tizen` target framework
If you want to use the `tizen` target framework, you need to use `Tizen.NET.Sdk` package as the project sdk.
```xml
<Project Sdk="Tizen.NET.Sdk/1.1.9">
  <PropertyGroup>
    <TargetFramework>tizen10.0</TargetFramework>
  </PropertyGroup>
</Project>
```
For more information, please see [Using Tizen.NET.Sdk as SDK-style](https://developer.samsung.com/tizen/blog/en-us/2019/06/13/using-tizennetsdk-as-sdk-style).

### Minimum required versions of Tizen.NET.Sdk and Visual Studio
| API Level | Target Framework | Tizen.NET.Sdk | Visual Studio     |
|:---------:|------------------|---------------|-------------------|
| API14     | net8.0-tizen11.0  | [Tizen .NET Workloads](https://github.com/samsung/Tizen.NET) | 2022       |
| API13     | net6.0-tizen10.0  | [Tizen .NET Workloads](https://github.com/samsung/Tizen.NET) | 2022       |
| API12     | net6.0-tizen9.0  | [Tizen .NET Workloads](https://github.com/samsung/Tizen.NET) | 2022       |
| API11     | net6.0-tizen8.0  | [Tizen .NET Workloads](https://github.com/samsung/Tizen.NET) | 2022       |
| API10     | tizen10.0        | 1.1.9         | 2019              |
| API9      | tizen90          | 1.1.7         | 2019              |
| API8      | tizen80          | 1.1.6         | 2019              |
| API7      | tizen70          | 1.0.9         | 2019              |
| API6      | tizen60          | 1.0.9         | 2019              |
| API5      | tizen50          | 1.0.1         | 2017              |
| API4      | tizen40          | 1.0.1         | 2017              |


## Quick Start
### Prerequisites
Install .NET SDK : https://www.microsoft.com/net/download/

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
| Tizen 4.0         | http://download.tizen.org/snapshots/TIZEN/Tizen-4.0/Tizen-4.0-Unified/latest/  |
| Tizen 5.0         | http://download.tizen.org/snapshots/TIZEN/Tizen-5.0/Tizen-5.0-Unified/latest/  |
| Tizen 5.5         | http://download.tizen.org/snapshots/TIZEN/Tizen-5.5/Tizen-5.5-Unified/latest/  |
| Tizen 6.0         | http://download.tizen.org/snapshots/TIZEN/Tizen-6.0/Tizen-6.0-Unified/latest/  |
| Tizen 6.5         | http://download.tizen.org/snapshots/TIZEN/Tizen-6.5/Tizen-6.5-Unified/latest/  |
| Tizen 7.0         | http://download.tizen.org/snapshots/TIZEN/Tizen-7.0/Tizen-7.0-Unified/latest/  |
| Tizen 8.0         | http://download.tizen.org/snapshots/TIZEN/Tizen-8.0/Tizen-8.0-Unified/latest/  |
| Tizen 9.0         | http://download.tizen.org/snapshots/TIZEN/Tizen-9.0/Tizen-9.0-Unified/latest/  |
| Tizen 10.0        | http://download.tizen.org/snapshots/TIZEN/Tizen-10.0/Tizen-10.0-Unified/latest |
| Tizen 11.0        | http://download.tizen.org/snapshots/TIZEN/Tizen/Tizen-Unified/latest           |

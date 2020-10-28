# TizenFX

[![License](https://img.shields.io/badge/licence-Apache%202.0-brightgreen.svg?style=flat)](LICENSE)
[![Build Status](https://travis-ci.org/Samsung/TizenFX.svg?branch=master)](https://travis-ci.org/Samsung/TizenFX)

TizenFX API, which allows you to access platform-specific features not covered by the generic .NET and Xamarin.Forms features, such as system information and status, battery status, sensor date, and account and connectivity services.

## Branches

| Branch | API Level | Target Framework | API Reference | Platform          | myget.org | nuget.org  |
|--------|:---------:|------------------|---------------|-------------------|-----------|------------|
|master  | 8         | tizen80 | [Link](https://samsung.github.io/TizenFX/master/) | Tizen vNext | [![api8_myget](https://img.shields.io/tizen.myget/dotnet/vpre/Tizen.NET.API8.svg)](https://tizen.myget.org/feed/dotnet/package/nuget/Tizen.NET) | |
|API7    | 7         | tizen70 | [Link](https://samsung.github.io/TizenFX/API7/) | Tizen 5.5 M3 | [![api7_myget](https://img.shields.io/tizen.myget/dotnet/vpre/Tizen.NET.API7.svg)](https://tizen.myget.org/feed/dotnet/package/nuget/Tizen.NET) | |
|API6    | 6         | tizen60 | [Link](https://samsung.github.io/TizenFX/API6/) | Tizen 5.5 M2 | [![api6_myget](https://img.shields.io/tizen.myget/dotnet/vpre/Tizen.NET.API6.svg)](https://tizen.myget.org/feed/dotnet/package/nuget/Tizen.NET) | [![api6_nuget](https://img.shields.io/nuget/v/Tizen.NET.API6.svg)](https://www.nuget.org/packages/Tizen.NET/) |
|API5    | 5         | tizen50 | [Link](https://samsung.github.io/TizenFX/API5/) | Tizen 5.0       | [![api5_myget](https://img.shields.io/tizen.myget/dotnet/vpre/Tizen.NET.API5.svg)](https://tizen.myget.org/feed/dotnet/package/nuget/Tizen.NET) | [![api5_nuget](https://img.shields.io/nuget/v/Tizen.NET.API5.svg)](https://www.nuget.org/packages/Tizen.NET/) |
|API4    | 4         | tizen40 | [Link](https://samsung.github.io/TizenFX/API4/) | Tizen 4.0         | [![api4_myget](https://img.shields.io/tizen.myget/dotnet/vpre/Tizen.NET.API4.svg)](https://tizen.myget.org/feed/dotnet/package/nuget/Tizen.NET) | [![api4_nuget](https://img.shields.io/nuget/v/Tizen.NET.API4.svg)](https://www.nuget.org/packages/Tizen.NET/) |

### master
The __master__ branch is the main development branch for the Tizen .NET __API Level 8__.

The following NuGet packages will be published to [Tizen MyGet Gallery](https://tizen.myget.org/gallery/dotnet) every day if there are any changes. (Nightly Build)
* Tizen.NET 8.0.0.#####
* Tizen.NET.API8 8.0.0.#####
* Tizen.NET.Internals 8.0.0.#####

And, This branch is pushed to the [tizen branch](https://git.tizen.org/cgit/platform/core/csapi/tizenfx/?h=tizen) in the tizen gerrit and submitted for the Tizen vNext (6.0) platform.

### API7
The __API7__ branch is reserved for Tizen 5.5 M3 release with the Tizen .NET __API Level 7__.

### API4,5,6 branches
The __API#__ branches are the release branch for Tizen .NET __API Level #__.

These release branches were __FROZEN__. No new public APIs can be added to these branches, only bug fixes and internal APIs can be added.

## Quick Start
### Prerequisites
Install .NET Core SDK 2.0+ : https://www.microsoft.com/net/download/

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
| Tizen vNext       | http://download.tizen.org/snapshots/tizen/unified/latest/     |


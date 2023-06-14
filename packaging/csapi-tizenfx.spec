# Auto-generated from csapi-tizenfx.spec.in by makespec.sh

%define TIZEN_NET_API_VERSION 11
%define TIZEN_NET_RPM_VERSION 11.0.0.999+nui22230
%define TIZEN_NET_NUGET_VERSION 11.0.0.99999

%define DOTNET_ASSEMBLY_PATH /usr/share/dotnet.tizen/framework
%define DOTNET_ASSEMBLY_DUMMY_PATH %{DOTNET_ASSEMBLY_PATH}/ref
%define DOTNET_ASSEMBLY_RES_PATH %{DOTNET_ASSEMBLY_PATH}/res
%define DOTNET_TOOLS_PATH /usr/share/dotnet.tizen/tools
%define DOTNET_PRELOAD_PATH /usr/share/dotnet.tizen/preload
%define DOTNET_NUGET_SOURCE /nuget

%define TIZEN_NET_RUNTIME_IDENTIFIERS 4.0.0:5.0.0:5.5.0:6.0.0:6.5.0:7.0.0
%define TIZEN_NET_TARGET_FRAMEWORK_MONIKERS tizen10.0:tizen90:tizen80:tizen70:tizen60:tizen50:tizen40

%define UPGRADE_SCRIPT_PATH /usr/share/upgrade/scripts

Name:       csapi-tizenfx
Summary:    Assemblies of Tizen .NET
Version:    %{TIZEN_NET_RPM_VERSION}
Release:    1
Group:      Development/Libraries
License:    Apache-2.0 and MIT
URL:        https://www.tizen.org
Source0:    %{name}-%{version}.tar.gz
Source1:    %{name}.manifest

BuildArch:   noarch
AutoReqProv: no

BuildRequires: dotnet-build-tools
BuildRequires: pkgconfig(dali2-csharp-binder)
Requires(post): /usr/bin/vconftool

# BuildRequires for StructValidator
%if %{defined enable_struct_test}
BuildRequires: coregl
BuildRequires: pkgconfig(elementary)
BuildRequires: pkgconfig(efl-extension)
BuildRequires: pkgconfig(capi-media-camera)
BuildRequires: pkgconfig(rua)
BuildRequires: pkgconfig(component-based-core-base)
BuildRequires: pkgconfig(notification)
BuildRequires: pkgconfig(capi-appfw-service-application)
BuildRequires: pkgconfig(capi-appfw-application)
BuildRequires: pkgconfig(capi-appfw-widget-application)
BuildRequires: pkgconfig(data-control)
BuildRequires: pkgconfig(capi-location-manager)
BuildRequires: pkgconfig(capi-media-vision)
BuildRequires: pkgconfig(capi-network-bluetooth)
BuildRequires: pkgconfig(capi-network-wifi-direct)
BuildRequires: pkgconfig(key-manager)
BuildRequires: pkgconfig(capi-system-sensor)
BuildRequires: pkgconfig(capi-system-runtime-info)
BuildRequires: pkgconfig(capi-ui-inputmethod)
BuildRequires: pkgconfig(stt-engine)
BuildRequires: pkgconfig(tts-engine)
BuildRequires: pkgconfig(chromium-efl)
BuildRequires: pkgconfig(libsessiond)
%if "%{profile}" == "tv"
BuildRequires: pkgconfig(trustzone-nwd)
%else
BuildRequires: pkgconfig(capi-appfw-watch-application)
BuildRequires: pkgconfig(capi-telephony)
BuildRequires: pkgconfig(tef-libteec)
%endif
%endif

%description
%{summary}

%package nuget
Summary:   NuGet package for %{name}
Group:     Development/Libraries
AutoReqProv: no

%description nuget
NuGet package for %{name}

%package tools
Summary:   Tools for TizenFX
Group:     Development/Libraries
AutoReqProv: no

%description tools
Tools for TizenFX

%package dummy
Summary:   not used package
Group:     Development/Libraries
AutoReqProv: no

%description dummy
not used package

%package full
Summary:   All Tizen .NET assemblies
Group:     Development/Libraries
Requires:  %{name} = %{version}-%{release}
AutoReqProv: no

%description full
All Tizen .NET assemblies

%package debug
Summary:   All .pdb files of Tizen .NET
Group:     Development/Libraries
AutoReqProv: no

%description debug
All .pdb files of Tizen .NET

%package mobile
Summary:   Tizen .NET assemblies for Mobile profile
Group:     Development/Libraries
Requires:  %{name} = %{version}-%{release}
AutoReqProv: no

%description mobile
Tizen .NET assemblies for Mobile profile

%package tv
Summary:   Tizen .NET assemblies for TV profile
Group:     Development/Libraries
Requires:  %{name} = %{version}-%{release}
AutoReqProv: no

%description tv
Tizen .NET assemblies for TV profile

%package wearable
Summary:   Tizen .NET assemblies for Wearable profile
Group:     Development/Libraries
Requires:  %{name} = %{version}-%{release}
AutoReqProv: no

%description wearable
Tizen .NET assemblies for Wearable profile

%prep
%setup -q
cp %{SOURCE1} .

%build

# configure for ASAN
%{?asan:export ASAN_OPTIONS=use_sigaltstack=false:allow_user_segv_handler=true:handle_sigfpe=false:`cat /ASAN_OPTIONS`}

# prepare for build
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true
%define build_cmd ./tools/scripts/retry.sh ./tools/scripts/timeout.sh -t 600 ./build.sh

# build full assemblies
%if %{defined profile}
%{build_cmd} --full /p:BuildProfile=%{profile}
%else
%{build_cmd} --full
%endif

# pack nuget package
%{build_cmd} --pack %{TIZEN_NET_NUGET_VERSION}

# check validation of struct size
%if %{defined enable_struct_test}
dotnet validate-struct Artifacts/bin/public || echo "
    #######################################################
    ##################### W A R N I N G ###################
    #######################################################
    # The sturct size mismatches MUST BE FIXED.           #
    # It will make building errors later                  #
    #######################################################
"
%endif


%install
mkdir -p %{buildroot}%{DOTNET_ASSEMBLY_PATH}
mkdir -p %{buildroot}%{DOTNET_ASSEMBLY_DUMMY_PATH}
mkdir -p %{buildroot}%{DOTNET_ASSEMBLY_RES_PATH}
mkdir -p %{buildroot}%{DOTNET_NUGET_SOURCE}
mkdir -p %{buildroot}%{DOTNET_TOOLS_PATH}
mkdir -p %{buildroot}%{DOTNET_PRELOAD_PATH}

# Install Runtime Assemblies
install -p -m 644 Artifacts/bin/public/*.dll %{buildroot}%{DOTNET_ASSEMBLY_PATH}
install -p -m 644 Artifacts/bin/internal/*.dll %{buildroot}%{DOTNET_ASSEMBLY_PATH}

# Install Debug Symbols
install -p -m 644 Artifacts/bin/public/*.pdb %{buildroot}%{DOTNET_ASSEMBLY_PATH}
install -p -m 644 Artifacts/bin/internal/*.pdb %{buildroot}%{DOTNET_ASSEMBLY_PATH}

# Install Resource files
[ -d Artifacts/bin/public/res ] \
  && cp -fr Artifacts/bin/public/res/* %{buildroot}%{DOTNET_ASSEMBLY_RES_PATH}
[ -d Artifacts/bin/internal/res ] \
  && cp -fr Artifacts/bin/internal/res/* %{buildroot}%{DOTNET_ASSEMBLY_RES_PATH}

# Install Dummy Assemblies
install -p -m 644 Artifacts/bin/dummy/*.dll %{buildroot}%{DOTNET_ASSEMBLY_DUMMY_PATH}

# Install Preload
install -p -m 644 Artifacts/preload/*.preload %{buildroot}%{DOTNET_PRELOAD_PATH}

# Install NuGet Packages
install -p -m 644 Artifacts/*.nupkg %{buildroot}%{DOTNET_NUGET_SOURCE}
install -p -m 644 packaging/depends/*.nupkg %{buildroot}%{DOTNET_NUGET_SOURCE}

# Install Tools
install -p -m 644 tools/bin/* %{buildroot}%{DOTNET_TOOLS_PATH}


# Install Upgrade Script
mkdir -p %{buildroot}%{UPGRADE_SCRIPT_PATH}
install -p -m 755 packaging/500.tizenfx_upgrade.sh %{buildroot}%{UPGRADE_SCRIPT_PATH}

%post
/usr/bin/vconftool set -t int db/dotnet/tizen_api_version %{TIZEN_NET_API_VERSION} -f
/usr/bin/vconftool set -t string db/dotnet/tizen_api_path %{DOTNET_ASSEMBLY_PATH} -f
/usr/bin/vconftool set -t string db/dotnet/tizen_rid_version %{TIZEN_NET_RUNTIME_IDENTIFIERS} -f
/usr/bin/vconftool set -t string db/dotnet/tizen_tfm_support %{TIZEN_NET_TARGET_FRAMEWORK_MONIKERS} -f

%files
%license LICENSE
%license LICENSE.MIT
%attr(0755,root,root) %{UPGRADE_SCRIPT_PATH}/500.tizenfx_upgrade.sh

%files nuget
%{DOTNET_NUGET_SOURCE}/*.nupkg

%files tools
%manifest %{name}.manifest
%{DOTNET_TOOLS_PATH}/*

%files dummy

%files full
%manifest %{name}.manifest
%defattr(644,root,root,755)
%{DOTNET_ASSEMBLY_PATH}/*.dll
%{DOTNET_ASSEMBLY_DUMMY_PATH}/*.dll
%{DOTNET_ASSEMBLY_RES_PATH}/*
%{DOTNET_PRELOAD_PATH}/*

%files debug
%manifest %{name}.manifest
%attr(644,root,root) %{DOTNET_ASSEMBLY_PATH}/*.pdb

%files mobile -f Artifacts/mobile.filelist
%manifest %{name}.manifest

%files tv -f Artifacts/tv.filelist
%manifest %{name}.manifest

%files wearable -f Artifacts/wearable.filelist
%manifest %{name}.manifest

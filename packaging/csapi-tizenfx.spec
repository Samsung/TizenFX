# Auto-generated from csapi-tizenfx.spec.in by makespec.sh

%define TIZEN_NET_API_VERSION 5
%define TIZEN_NET_RPM_VERSION 5.0.0.14363+nui501
%define TIZEN_NET_NUGET_VERSION 5.0.0.14363
%define TIZEN_NET_INTERNAL_NUGET_VERSION 5.0.0.14363

%define DOTNET_ASSEMBLY_PATH /usr/share/dotnet.tizen/framework
%define DOTNET_ASSEMBLY_DUMMY_PATH %{DOTNET_ASSEMBLY_PATH}/ref
%define DOTNET_ASSEMBLY_RES_PATH %{DOTNET_ASSEMBLY_PATH}/res
%define DOTNET_NUGET_SOURCE /nuget

Name:       csapi-tizenfx
Summary:    Assemblies of Tizen .NET
Version:    %{TIZEN_NET_RPM_VERSION}
Release:    1
Group:      Development/Libraries
License:    Apache-2.0
URL:        https://www.tizen.org
Source0:    %{name}-%{version}.tar.gz
Source1:    %{name}.manifest

BuildArch:   noarch
ExcludeArch: aarch64
AutoReqProv: no

BuildRequires: dotnet-build-tools
Requires(post): /usr/bin/vconftool

%description
%{summary}

%package nuget
Summary:   NuGet package for %{name}
Group:     Development/Libraries
AutoReqProv: no

%description nuget
NuGet package for %{name}

%package dummy
Summary:   Dummy assemblies of Tizen .NET
Group:     Development/Libraries
AutoReqProv: no

%description dummy
Dummy assemblies of Tizen .NET

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

%package common
Summary:   Tizen .NET assemblies for Common profile
Group:     Development/Libraries
Requires:  %{name} = %{version}-%{release}
Requires:  csapi-tizenfx-dummy = %{version}-%{release}
AutoReqProv: no

%description common
Tizen .NET assemblies for Common profile

%package mobile
Summary:   Tizen .NET assemblies for Mobile profile
Group:     Development/Libraries
Requires:  %{name} = %{version}-%{release}
Requires:  csapi-tizenfx-dummy = %{version}-%{release}
AutoReqProv: no

%description mobile
Tizen .NET assemblies for Mobile profile

%package mobile-emul
Summary:   Tizen .NET assemblies for Emulator of Mobile profile
Group:     Development/Libraries
Requires:  %{name} = %{version}-%{release}
Requires:  csapi-tizenfx-dummy = %{version}-%{release}
AutoReqProv: no

%description mobile-emul
Tizen .NET assemblies for Emulator of Mobile profile

%package tv
Summary:   Tizen .NET assemblies for TV profile
Group:     Development/Libraries
Requires:  %{name} = %{version}-%{release}
Requires:  csapi-tizenfx-dummy = %{version}-%{release}
AutoReqProv: no

%description tv
Tizen .NET assemblies for TV profile

%package ivi
Summary:   Tizen .NET assemblies for IVI profile
Group:     Development/Libraries
Requires:  %{name} = %{version}-%{release}
Requires:  csapi-tizenfx-dummy = %{version}-%{release}
AutoReqProv: no

%description ivi
Tizen .NET assemblies for IVI profile

%package wearable
Summary:   Tizen .NET assemblies for Wearable profile
Group:     Development/Libraries
Requires:  %{name} = %{version}-%{release}
Requires:  csapi-tizenfx-dummy = %{version}-%{release}
AutoReqProv: no

%description wearable
Tizen .NET assemblies for Wearable profile

%prep
%setup -q
cp %{SOURCE1} .

%build
%{?asan:export ASAN_OPTIONS=use_sigaltstack=false:allow_user_segv_handler=true:handle_sigfpe=false:`cat /ASAN_OPTIONS`}

%define _tizenfx_bin_path Artifacts

GetFileList() {
  PROFILE=$1
  cat pkg/PlatformFileList.txt | grep -E "#$PROFILE[[:space:]]|#$PROFILE$" | cut -d# -f1 | sed "s#^#%{DOTNET_ASSEMBLY_PATH}/#"
}

GetFileList common > common.filelist
GetFileList mobile > mobile.filelist
GetFileList mobile-emul > mobile-emul.filelist
GetFileList tv > tv.filelist
GetFileList ivi > ivi.filelist
GetFileList wearable > wearable.filelist

rm -fr %{_tizenfx_bin_path}
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true
./build.sh --full
./build.sh --dummy
./build.sh --pack %{TIZEN_NET_NUGET_VERSION} %{TIZEN_NET_INTERNAL_NUGET_VERSION}

%install
mkdir -p %{buildroot}%{DOTNET_ASSEMBLY_PATH}
mkdir -p %{buildroot}%{DOTNET_ASSEMBLY_DUMMY_PATH}
mkdir -p %{buildroot}%{DOTNET_ASSEMBLY_RES_PATH}
mkdir -p %{buildroot}%{DOTNET_NUGET_SOURCE}

# Install Runtime Assemblies
install -p -m 644 %{_tizenfx_bin_path}/bin/public/*.dll %{buildroot}%{DOTNET_ASSEMBLY_PATH}
install -p -m 644 %{_tizenfx_bin_path}/bin/internal/*.dll %{buildroot}%{DOTNET_ASSEMBLY_PATH}

# Install Debug Symbols
install -p -m 644 %{_tizenfx_bin_path}/bin/public/*.pdb %{buildroot}%{DOTNET_ASSEMBLY_PATH}
install -p -m 644 %{_tizenfx_bin_path}/bin/internal/*.pdb %{buildroot}%{DOTNET_ASSEMBLY_PATH}

# Install Resource files
[ -d %{_tizenfx_bin_path}/bin/public/res ] \
  && install -p -m 644 %{_tizenfx_bin_path}/bin/public/res/* %{buildroot}%{DOTNET_ASSEMBLY_RES_PATH}
[ -d %{_tizenfx_bin_path}/bin/internal/res ] \
  && install -p -m 644 %{_tizenfx_bin_path}/bin/internal/res/* %{buildroot}%{DOTNET_ASSEMBLY_RES_PATH}

# Install Dummy Assemblies
install -p -m 644 %{_tizenfx_bin_path}/bin/dummy/*.dll %{buildroot}%{DOTNET_ASSEMBLY_DUMMY_PATH}

# Install NuGet Packages
install -p -m 644 %{_tizenfx_bin_path}/*.nupkg %{buildroot}%{DOTNET_NUGET_SOURCE}

%post
/usr/bin/vconftool set -t int db/dotnet/tizen_api_version %{TIZEN_NET_API_VERSION} -f


%files
%license LICENSE

%files nuget
%{DOTNET_NUGET_SOURCE}/*.nupkg

%files dummy
%attr(644,root,root) %{DOTNET_ASSEMBLY_DUMMY_PATH}/*.dll

%files full
%manifest %{name}.manifest
%attr(644,root,root) %{DOTNET_ASSEMBLY_PATH}/*.dll
%attr(644,root,root) %{DOTNET_ASSEMBLY_RES_PATH}/*

%files debug
%attr(644,root,root) %{DOTNET_ASSEMBLY_PATH}/*.pdb

%files common -f common.filelist
%manifest %{name}.manifest

%files mobile -f mobile.filelist
%manifest %{name}.manifest

%files mobile-emul -f mobile-emul.filelist
%manifest %{name}.manifest

%files tv -f tv.filelist
%manifest %{name}.manifest

%files ivi -f ivi.filelist
%manifest %{name}.manifest

%files wearable -f wearable.filelist
%manifest %{name}.manifest

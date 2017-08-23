# !! IMPORTANT !!
# This packaging spec file is for developer testing only.
# For Tizen release, the spec file in the tizen branch should be used.

%define DOTNET_ASSEMBLY_PATH /usr/share/dotnet.tizen/framework
%define DOTNET_ASSEMBLY_DUMMY_PATH %{DOTNET_ASSEMBLY_PATH}/ref
%define DOTNET_ASSEMBLY_RES_PATH %{DOTNET_ASSEMBLY_PATH}/res
%define DOTNET_NUGET_SOURCE /nuget

%define _tizenfx_bin_path Artifacts

Name:       csapi-tizenfx
Summary:    Assemblies of Tizen .NET
Version:    99.99.99
Release:    1
Group:      Development/Libraries
License:    Apache-2.0
URL:        https://www.tizen.org
Source0:    %{name}-%{version}.tar.gz
Source1:    %{name}.manifest

BuildRequires: dotnet-build-tools

BuildArch: noarch
AutoReqProv: no

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
Requires:  csapi-tizenfx-dummy
AutoReqProv: no

%description common
Tizen .NET assemblies for Common profile

%package mobile
Summary:   Tizen .NET assemblies for Mobile profile
Group:     Development/Libraries
Requires:  csapi-tizenfx-dummy
AutoReqProv: no

%description mobile
Tizen .NET assemblies for Mobile profile

%package mobile-emul
Summary:   Tizen .NET assemblies for Emulator of Mobile profile
Group:     Development/Libraries
Requires:  csapi-tizenfx-dummy
AutoReqProv: no

%description mobile-emul
Tizen .NET assemblies for Emulator of Mobile profile

%package tv
Summary:   Tizen .NET assemblies for TV profile
Group:     Development/Libraries
Requires:  csapi-tizenfx-dummy
AutoReqProv: no

%description tv
Tizen .NET assemblies for TV profile

%package ivi
Summary:   Tizen .NET assemblies for IVI profile
Group:     Development/Libraries
Requires:  csapi-tizenfx-dummy
AutoReqProv: no

%description ivi
Tizen .NET assemblies for IVI profile

%package wearable
Summary:   Tizen .NET assemblies for Wearable profile
Group:     Development/Libraries
Requires:  csapi-tizenfx-dummy
AutoReqProv: no

%description wearable
Tizen .NET assemblies for Wearable profile

%prep
%setup -q
cp %{SOURCE1} .

%build

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

rm -fr %{_tizenfx_bin_path}/bin
rm -f %{_tizenfx_bin_path}/*.nupkg
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true
./build.sh --full
./build.sh --dummy
./build.sh --pack

%install
mkdir -p %{buildroot}%{DOTNET_ASSEMBLY_PATH}
mkdir -p %{buildroot}%{DOTNET_ASSEMBLY_DUMMY_PATH}
mkdir -p %{buildroot}%{DOTNET_ASSEMBLY_RES_PATH}
mkdir -p %{buildroot}%{DOTNET_NUGET_SOURCE}

install -p -m 644 %{_tizenfx_bin_path}/bin/*.dll %{buildroot}%{DOTNET_ASSEMBLY_PATH}
install -p -m 644 %{_tizenfx_bin_path}/bin/*.pdb %{buildroot}%{DOTNET_ASSEMBLY_PATH}
install -p -m 644 %{_tizenfx_bin_path}/bin/res/* %{buildroot}%{DOTNET_ASSEMBLY_RES_PATH}
install -p -m 644 %{_tizenfx_bin_path}/bin_dummy/*.dll %{buildroot}%{DOTNET_ASSEMBLY_DUMMY_PATH}
install -p -m 644 %{_tizenfx_bin_path}/*.nupkg %{buildroot}%{DOTNET_NUGET_SOURCE}

%files nuget
%{DOTNET_NUGET_SOURCE}/*.nupkg

%files dummy
%attr(644,root,root) %{DOTNET_ASSEMBLY_DUMMY_PATH}/*.dll

%files full
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{DOTNET_ASSEMBLY_PATH}/*.dll
%attr(644,root,root) %{DOTNET_ASSEMBLY_RES_PATH}/*

%files debug
%attr(644,root,root) %{DOTNET_ASSEMBLY_PATH}/*.pdb

%files common -f common.filelist
%manifest %{name}.manifest
%license LICENSE

%files mobile -f mobile.filelist
%manifest %{name}.manifest
%license LICENSE

%files mobile-emul -f mobile-emul.filelist
%manifest %{name}.manifest
%license LICENSE

%files tv -f tv.filelist
%manifest %{name}.manifest
%license LICENSE

%files ivi -f ivi.filelist
%manifest %{name}.manifest
%license LICENSE

%files wearable -f wearable.filelist
%manifest %{name}.manifest
%license LICENSE

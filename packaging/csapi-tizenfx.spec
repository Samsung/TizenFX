# Auto-generated from csapi-tizenfx.spec.in by makespec.sh

%define TIZEN_NET_API_VERSION 7
%define TIZEN_NET_RPM_VERSION 7.0.0.15010+nui550
%define TIZEN_NET_NUGET_VERSION 7.0.0.15010

%define DOTNET_ASSEMBLY_PATH /usr/share/dotnet.tizen/framework
%define DOTNET_ASSEMBLY_DUMMY_PATH %{DOTNET_ASSEMBLY_PATH}/ref
%define DOTNET_ASSEMBLY_RES_PATH %{DOTNET_ASSEMBLY_PATH}/res
%define DOTNET_TOOLS_PATH /usr/share/dotnet.tizen/tools
%define DOTNET_NUGET_SOURCE /nuget

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

%package common
Summary:   Tizen .NET assemblies for Common profile
Group:     Development/Libraries
Requires:  %{name} = %{version}-%{release}
AutoReqProv: no

%description common
Tizen .NET assemblies for Common profile

%package mobile
Summary:   Tizen .NET assemblies for Mobile profile
Group:     Development/Libraries
Requires:  %{name} = %{version}-%{release}
AutoReqProv: no

%description mobile
Tizen .NET assemblies for Mobile profile

%package mobile-emul
Summary:   Tizen .NET assemblies for Emulator of Mobile profile
Group:     Development/Libraries
Requires:  %{name} = %{version}-%{release}
AutoReqProv: no

%description mobile-emul
Tizen .NET assemblies for Emulator of Mobile profile

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
%{?asan:export ASAN_OPTIONS=use_sigaltstack=false:allow_user_segv_handler=true:handle_sigfpe=false:`cat /ASAN_OPTIONS`}

%define _tizenfx_bin_path Artifacts

rm -fr %{_tizenfx_bin_path}
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true

%define build_cmd ./tools/scripts/retry.sh ./tools/scripts/timeout.sh -t 600 ./build.sh
%{build_cmd} --full
%{build_cmd} --pack %{TIZEN_NET_NUGET_VERSION}

GetFileList() {
  PROFILE=$1
  cat packaging/PlatformFileList.txt | grep -E "#$PROFILE[[:space:]]|#$PROFILE$" | cut -d# -f1 | sed "s#^#%{DOTNET_ASSEMBLY_PATH}/#"
  for f in $(cat packaging/PlatformFileList.txt | grep -v -E "#$PROFILE[[:space:]]|#$PROFILE$" | cut -d# -f1); do
    if [ -f %{_tizenfx_bin_path}/bin/dummy/$f ]; then
      echo "%{DOTNET_ASSEMBLY_PATH}/ref/$f"
    fi
  done
}

GetFileList common > common.filelist
GetFileList mobile > mobile.filelist
GetFileList mobile-emul > mobile-emul.filelist
GetFileList tv > tv.filelist
GetFileList wearable > wearable.filelist

%install
mkdir -p %{buildroot}%{DOTNET_ASSEMBLY_PATH}
mkdir -p %{buildroot}%{DOTNET_ASSEMBLY_DUMMY_PATH}
mkdir -p %{buildroot}%{DOTNET_ASSEMBLY_RES_PATH}
mkdir -p %{buildroot}%{DOTNET_NUGET_SOURCE}
mkdir -p %{buildroot}%{DOTNET_TOOLS_PATH}

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
install -p -m 644 packaging/*.nupkg %{buildroot}%{DOTNET_NUGET_SOURCE}

# Install Tools
install -p -m 644 tools/bin/* %{buildroot}%{DOTNET_TOOLS_PATH}

%post
/usr/bin/vconftool set -t int db/dotnet/tizen_api_version %{TIZEN_NET_API_VERSION} -f
/usr/bin/vconftool set -t string db/dotnet/tizen_api_path %{DOTNET_ASSEMBLY_PATH} -f

%files
%license LICENSE
%license LICENSE.MIT

%files nuget
%{DOTNET_NUGET_SOURCE}/*.nupkg

%files tools
%manifest %{name}.manifest
%{DOTNET_TOOLS_PATH}/*

%files dummy

%files full
%manifest %{name}.manifest
%attr(644,root,root) %{DOTNET_ASSEMBLY_PATH}/*.dll
%attr(644,root,root) %{DOTNET_ASSEMBLY_DUMMY_PATH}/*.dll
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

%files wearable -f wearable.filelist
%manifest %{name}.manifest

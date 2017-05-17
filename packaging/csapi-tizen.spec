Name:       csapi-tizen
Summary:    Base components for Tizen .NET
Version:    1.0.5
Release:    1
Group:      Development/Libraries
License:    Apache-2.0
URL:        https://www.tizen.org
Source0:    %{name}-%{version}.tar.gz
Source1:    %{name}.manifest

AutoReqProv: no
ExcludeArch: aarch64

BuildRequires: dotnet-build-tools
BuildRequires: csapi-log-nuget
Requires: csapi-log

%define Assemblies Tizen

%description
%{summary}

%package nuget
Summary:   NuGet package for %{name}
Group:     Development/Libraries
AutoReqProv: no
Requires:  csapi-log-nuget

%description nuget
NuGet package for %{name}

%prep
%setup -q
cp %{SOURCE1} .

%build
for ASM in %{Assemblies}; do
%dotnet_build $ASM
%dotnet_pack $ASM/$ASM.nuspec %{version}
done

%install
for ASM in %{Assemblies}; do
%dotnet_install $ASM
done

%files
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{dotnet_assembly_files}

%files nuget
/nuget/Tizen.%{version}.nupkg


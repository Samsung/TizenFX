Name:       csapi-tapi
Summary:    Tizen TAPI API for C#
Version:    1.0.1
Release:    1
Group:      Development/Libraries
License:    Apache-2.0
URL:        https://www.tizen.org
Source0:    %{name}-%{version}.tar.gz
Source1:    %{name}.manifest

AutoReqProv: no
ExcludeArch: aarch64

BuildRequires: dotnet-build-tools

# C# API Requires
BuildRequires: csapi-tizen-nuget

%define Assemblies Tizen.Tapi

%description
%{summary}

%package nuget-private
Summary: Tapi Private Nuget
Group: Development/Libraries

%description nuget-private
Tapi Private Nuget for internal uses

%prep
%setup -q
cp %{SOURCE1} .

%build
for ASM in %{Assemblies}; do
%dotnet_build $ASM
%dotnet_pack $ASM
done

%install
for ASM in %{Assemblies}; do
%dotnet_install $ASM
done

%files
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{dotnet_assembly_files}

%files nuget-private
/nuget/Tizen.Tapi.%{version}.nupkg


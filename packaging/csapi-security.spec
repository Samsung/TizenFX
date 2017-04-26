%define Assemblies Tizen.Security Tizen.Security.SecureRepository
%define version_security          1.0.7
%define version_secure_repository 1.0.8

Name:       csapi-security
Summary:    Tizen Security API for C#
Version:    1.0.8
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
BuildRequires: csapi-application-common-nuget
BuildRequires: csapi-application-package-manager-nuget

%description
%{summary}

%dotnet_import_sub_packages

%prep
%setup -q
cp %{SOURCE1} .

%build
for ASM in %{Assemblies}; do
%dotnet_build $ASM
[ "$ASM" = "Tizen.Security" ] &&
	%dotnet_pack $ASM/$ASM.nuspec %{version_security}
[ "$ASM" = "Tizen.Security.SecureRepository" ] &&
	%dotnet_pack $ASM/$ASM.nuspec %{version_secure_repository}
done

%install
for ASM in %{Assemblies}; do
%dotnet_install $ASM
done

%files
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{dotnet_assembly_files}

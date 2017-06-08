Name:       csapi-log
Summary:    Tizen Log API for C#
Version:    1.0.0
Release:    1
Group:      Development/Libraries
License:    Apache-2.0
URL:        https://www.tizen.org
Source0:    %{name}-%{version}.tar.gz
Source1:    %{name}.manifest

AutoReqProv: no
ExcludeArch: aarch64

BuildRequires: dotnet-build-tools

%define Assemblies Tizen.Log

%description
%{summary}

%dotnet_import_sub_packages

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
%license LICENSE.APACHE2.0
%attr(644,root,root) %{dotnet_assembly_files}

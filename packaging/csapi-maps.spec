Name:       csapi-maps
Summary:    Tizen Map Service API for C#
Version:    1.0.15
Release:    1
Group:      Development/Libraries
License:    Apache-2.0 and SAMSUNG
URL:        https://www.tizen.org
Source0:    %{name}-%{version}.tar.gz
Source1:    %{name}.manifest

AutoReqProv: no
ExcludeArch: aarch64

BuildRequires: dotnet-build-tools

# NuGet for Dependencies
BuildRequires: csapi-tizen-nuget
BuildRequires: elm-sharp-nuget

%define Assemblies Tizen.Maps

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
mkdir -p %{buildroot}%{dotnet_assembly_path}/res
for ASM in %{Assemblies}; do
%dotnet_install $ASM
install -p -m 644 $ASM/res/*.png %{buildroot}%{dotnet_assembly_path}/res
done

%files
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{dotnet_assembly_files}
%attr(644,root,root) %{dotnet_assembly_path}/res/*.png

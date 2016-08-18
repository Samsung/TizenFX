%{!?dotnet_assembly_path: %define dotnet_assembly_path %{_datadir}/assembly}

%if 0%{?tizen_build_devel_mode}
%define BUILDCONF Debug
%else
%define BUILDCONF Release
%endif

Name:       csapi-security
Summary:    Tizen Security API for C#
Version:    1.0.0
Release:    1
Group:      Development/Libraries
License:    Apache-2.0
URL:        https://www.tizen.org
Source0:    %{name}-%{version}.tar.gz
Source1:    %{name}.manifest

# Mono
BuildRequires: mono-compiler
BuildRequires: mono-devel

# C# API default dependencies
BuildRequires: csapi-tizen
BuildRequires: pkgconfig(glib-2.0)

# privilege-info
BuildRequires: csapi-application
BuildRequires: pkgconfig(privilege-info)

# key-manager
BuildRequires: pkgconfig(key-manager)

%description
Tizen Security API for C#

%prep
%setup -q

cp %{SOURCE1} .

%define Assemblies Tizen.Security Tizen.Security.SecureRepository

%build
for ASM in %{Assemblies}; do
xbuild $ASM/$ASM.csproj \
    /p:Configuration=%{BUILDCONF} \
    /p:ReferencePath=%{dotnet_assembly_path}
done

%install
# Assemblies
mkdir -p %{buildroot}%{dotnet_assembly_path}
for ASM in %{Assemblies}; do
    install -p -m 644 $ASM/bin/%{BUILDCONF}/$ASM.dll %{buildroot}%{dotnet_assembly_path}
done

# License
mkdir -p %{buildroot}%{_datadir}/license
cp LICENSE %{buildroot}%{_datadir}/license/%{name}

%files
%manifest %{name}.manifest
%attr(644,root,root) %{dotnet_assembly_path}/Tizen.Security.dll
%attr(644,root,root) %{dotnet_assembly_path}/Tizen.Security.SecureRepository.dll
%attr(644,root,root) %{_datadir}/license/%{name}

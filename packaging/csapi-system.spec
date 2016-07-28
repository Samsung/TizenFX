%{!?dotnet_assembly_path: %define dotnet_assembly_path %{_datadir}/assembly}
%{!?dotnet_core_path: %define dotnet_core_path %{_datadir}/tizen.net/ref}

%if 0%{?tizen_build_devel_mode}
%define BUILDCONF Debug
%else
%define BUILDCONF Release
%endif

Name:       csapi-system
Summary:    Tizen System API for C#
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

# .NETCore
%if 0%{?_with_corefx}
AutoReqProv: no
BuildRequires: corefx-managed-32b-ref
%endif

# C# API Requires
BuildRequires: csapi-tizen
BuildRequires: csapi-uifw

%description
Tizen System API for C#

%prep
%setup -q
cp %{SOURCE1} .

%define Assemblies Tizen.System

%build
for ASM in %{Assemblies}; do
xbuild $ASM/$ASM.csproj \
%if 0%{?_with_corefx}
        /p:NoStdLib=True \
        /p:TargetFrameworkVersion=v5.0 \
        /p:AddAdditionalExplicitAssemblyReferences=False \
        /p:CoreFxPath=%{dotnet_core_path} \
%endif
        /p:Configuration=%{BUILDCONF} \
        /p:ReferencePath=%{dotnet_assembly_path}
done

%install
mkdir -p %{buildroot}%{dotnet_assembly_path}
for ASM in %{Assemblies}; do
install -p -m 644 $ASM/bin/%{BUILDCONF}/$ASM.dll %{buildroot}%{dotnet_assembly_path}
done

%files
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{dotnet_assembly_path}/*.dll

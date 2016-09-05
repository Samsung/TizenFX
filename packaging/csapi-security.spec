%{!?dotnet_assembly_path: %define dotnet_assembly_path /opt/usr/share/dotnet.tizen/framework}
%{!?dotnet_core_path: %define dotnet_core_path %{_datadir}/tizen.net/ref}

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

# .NETCore
%if 0%{?_with_corefx}
AutoReqProv: no
BuildRequires: corefx-managed-32b-ref
%endif

BuildRequires: dotnet-build-tools

# C# API Requires
BuildRequires: csapi-tizen-devel
BuildRequires: csapi-application-devel

%description
Tizen Security API for C#

%prep
%setup -q
cp %{SOURCE1} .

%define Assemblies Tizen.Security Tizen.Security.SecureRepository

%build
# Build for Net45
for ASM in %{Assemblies}; do
if [ -e $ASM/$ASM.Net45.csproj ]; then
  xbuild $ASM/$ASM.Net45.csproj \
         /p:Configuration=%{BUILDCONF} \
         /p:DotnetAssemblyPath=%{dotnet_assembly_path}/devel/net45 \
         /p:OutputPath=bin/net45
fi

# Build for Dotnet
%if 0%{?_with_corefx}
if [ -e $ASM/$ASM.csproj ]; then
  xbuild $ASM/$ASM.csproj \
         /p:Configuration=%{BUILDCONF} \
         /p:DotnetAssemblyPath=%{dotnet_assembly_path}/devel/netstandard1.6 \
         /p:CoreFxPath=%{dotnet_core_path} \
         /p:OutputPath=bin/netstandard1.6
fi
%endif

# Make NuGet package
dotnet-gbs pack $ASM/$ASM.nuspec --PackageVersion=%{version} --PackageFiles=$ASM/bin

done

%install
mkdir -p %{buildroot}%{dotnet_assembly_path}/devel
for ASM in %{Assemblies}; do
  cp -fr $ASM/bin/* %{buildroot}%{dotnet_assembly_path}/devel
%if 0%{?_with_corefx}
  install -p -m 644 $ASM/bin/netstandard1.6/$ASM.dll %{buildroot}%{dotnet_assembly_path}
%else
  install -p -m 644 $ASM/bin/net45/$ASM.dll %{buildroot}%{dotnet_assembly_path}
%endif
done

mkdir -p %{buildroot}/nuget
install -p -m 644 *.nupkg %{buildroot}/nuget

%files
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{dotnet_assembly_path}/*.dll

%package devel
Summary:   Development package for %{name}
Group:     Development/Libraries
Requires:  %{name} = %{version}-%{release}
AutoReqProv: no

%description devel
Development package for %{name}

%files devel
%{dotnet_assembly_path}/devel/*

%package nuget
Summary:   NuGet package for %{name}
Group:     Development/Libraries
Requires:  %{name} = %{version}-%{release}

%description nuget
NuGet package for %{name}

%files nuget
/nuget/*.nupkg

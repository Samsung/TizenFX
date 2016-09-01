%{!?dotnet_assembly_path: %define dotnet_assembly_path /opt/usr/share/dotnet.tizen/framework}
%{!?dotnet_core_path: %define dotnet_core_path %{_datadir}/tizen.net/ref}

%if 0%{?tizen_build_devel_mode}
%define BUILDCONF Debug
%else
%define BUILDCONF Release
%endif

Name:       elm-sharp
Summary:    C# Binding for Elementary
Version:    1.0.0
Release:    1
Group:      Development/Libraries
License:    Apache-2.0
URL:        https://www.tizen.org
Source0:    %{name}-%{version}.tar.gz
Source1:    %{name}.manifest

# .NETCore
%if 0%{?_with_corefx}
AutoReqProv: no
BuildRequires: corefx-managed-32b-ref
%endif

BuildRequires: dotnet-build-tools

%description
C# Binding for Elementary

%prep
%setup -q
cp %{SOURCE1} .

%define Assemblies ElmSharp

%build
dotnet-gbs build %{Assemblies} \
%if 0%{?_with_corefx}
        --CoreFxPath=%{dotnet_core_path} \
%endif
        --Configuration=%{BUILDCONF} \
        --DotnetAssemblyPath=%{dotnet_assembly_path}

dotnet-gbs pack %{Assemblies} --PackageVersion=%{version}

%install
mkdir -p %{buildroot}%{dotnet_assembly_path}
dotnet-gbs install %{Assemblies} \
        --Configuration=%{BUILDCONF} \
        --InstallPath=%{buildroot}%{dotnet_assembly_path}

mkdir -p %{buildroot}/nuget
install -p -m 644 .nuget/*.nupkg %{buildroot}/nuget

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

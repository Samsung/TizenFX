%{!?dotnet_assembly_path: %define dotnet_assembly_path /opt/usr/share/dotnet.tizen/framework}

%if 0%{?tizen_build_devel_mode}
%define BUILDCONF Debug
%else
%define BUILDCONF Release
%endif

Name:       csapi-security
Summary:    Tizen Security API for C#
Version:    1.0.2
Release:    1
Group:      Development/Libraries
License:    Apache-2.0
URL:        https://www.tizen.org
Source0:    %{name}-%{version}.tar.gz
Source1:    %{name}.manifest

AutoReqProv: no

BuildRequires: mono-compiler
BuildRequires: mono-devel

BuildRequires: dotnet-build-tools

# C# API Requires
BuildRequires: csapi-tizen-nuget
BuildRequires: csapi-application-nuget

%description
Tizen Security API for C#

%prep
%setup -q
cp %{SOURCE1} .

%define Assemblies Tizen.Security Tizen.Security.SecureRepository

%build
for ASM in %{Assemblies}; do
# NuGet Restore
find $ASM/*.project.json -exec nuget restore {} \;
# Build
find $ASM/*.csproj -exec xbuild {} /p:Configuration=%{BUILDCONF} \;
# NuGet Pack
nuget pack $ASM/$ASM.nuspec -Version %{version} -Properties Configuration=%{BUILDCONF}
done

%install
# Runtime Binary
mkdir -p %{buildroot}%{dotnet_assembly_path}
for ASM in %{Assemblies}; do
%if 0%{?_with_corefx}
  install -p -m 644 $ASM/bin/%{BUILDCONF}/$ASM.dll %{buildroot}%{dotnet_assembly_path}
%else
  install -p -m 644 $ASM/bin/%{BUILDCONF}/Net45/$ASM.dll %{buildroot}%{dotnet_assembly_path}
%endif
done
# NuGet
mkdir -p %{buildroot}/nuget
install -p -m 644 *.nupkg %{buildroot}/nuget

%files
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{dotnet_assembly_path}/*.dll

%package nuget
Summary:   NuGet package for %{name}
Group:     Development/Libraries

%description nuget
NuGet package for %{name}

%files nuget
/nuget/*.nupkg

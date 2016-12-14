%{!?dotnet_assembly_path: %define dotnet_assembly_path /opt/usr/share/dotnet.tizen/framework}

%if 0%{?tizen_build_devel_mode}
%define BUILDCONF Debug
%else
%define BUILDCONF Release
%endif

%define DEV_VERSION beta-002

Name:       elm-sharp
Summary:    C# Binding for Elementary
Version:    1.1.0
Release:    1
Group:      Development/Libraries
License:    Apache-2.0
URL:        https://www.tizen.org
Source0:    %{name}-%{version}.tar.gz
Source1:    %{name}.manifest

AutoReqProv: no
ExcludeArch: aarch64 %ix86

BuildRequires: mono-compiler
BuildRequires: mono-devel

BuildRequires: dotnet-build-tools
BuildRequires: edje-tools

%description
C# Binding for Elementary

%prep
%setup -q
cp %{SOURCE1} .

%define Assemblies ElmSharp

%build
for ASM in %{Assemblies}; do
# NuGet Restore
find $ASM/*.project.json -exec nuget restore {} \;
# Build
find $ASM/*.csproj -exec xbuild {} /p:Configuration=%{BUILDCONF} \;
# NuGet Pack
nuget pack $ASM/$ASM.nuspec -Version %{version}%{?DEV_VERSION:-%{DEV_VERSION}} -Properties Configuration=%{BUILDCONF}
done

edje_cc -id ElmSharp/theme/%{profile}/HD/images/ \
        -id ElmSharp/theme/%{profile}/HD/images/User_Input_Elements \
        ElmSharp/theme/%{profile}/elm-sharp-theme-%{profile}.edc ElmSharp/theme/elm-sharp-theme.edj

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
# Theme
mkdir %{buildroot}%{_datadir}/edje/elm-sharp -p
install -m 644 ElmSharp/theme/elm-sharp-theme.edj %{buildroot}%{_datadir}/edje/elm-sharp/

%files
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{dotnet_assembly_path}/*.dll
%attr(644,root,root) %{_datadir}/edje/elm-sharp/*.edj

%package nuget
Summary:   NuGet package for %{name}
Group:     Development/Libraries

%description nuget
NuGet package for %{name}

%files nuget
/nuget/*.nupkg

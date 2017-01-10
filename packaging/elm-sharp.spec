%define DEV_VERSION beta-006

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
ExcludeArch: aarch64

BuildRequires: dotnet-build-tools
BuildRequires: edje-tools

%define Assemblies ElmSharp

%description
%{summary}

%dotnet_import_sub_packages

%prep
%setup -q
cp %{SOURCE1} .

%build
for ASM in %{Assemblies}; do
%dotnet_build $ASM
%dotnet_pack $ASM/$ASM.nuspec %{version}%{?DEV_VERSION:-%{DEV_VERSION}}
done

edje_cc -id ElmSharp/theme/%{profile}/HD/images/ \
        -id ElmSharp/theme/%{profile}/HD/images/Assist_Views \
        -id ElmSharp/theme/%{profile}/HD/images/User_Input_Elements \
        -id ElmSharp/theme/%{profile}/HD/images/Navigation_elements \
        ElmSharp/theme/%{profile}/elm-sharp-theme-%{profile}.edc ElmSharp/theme/elm-sharp-theme.edj

%install
for ASM in %{Assemblies}; do
%dotnet_install $ASM
done

mkdir %{buildroot}%{_datadir}/edje/elm-sharp -p
install -m 644 ElmSharp/theme/elm-sharp-theme.edj %{buildroot}%{_datadir}/edje/elm-sharp/

%files
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{dotnet_assembly_files}
%attr(644,root,root) %{_datadir}/edje/elm-sharp/*.edj

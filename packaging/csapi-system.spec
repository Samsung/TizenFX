%define BUILDCONF Debug

Name:       csapi-system
Summary:    Tizen System API for C#
Version:    1.0.0
Release:    1
Group:      Development/Libraries
License:    Apache-2.0
URL:        https://www.tizen.org
Source0:    %{name}-%{version}.tar.gz
Source1:    %{name}.manifest
Source2:    %{name}.pc.in

# TODO: replace mono-compiler, mono-devel to mcs, mono-shlib-cop
BuildRequires: mono-compiler
BuildRequires: mono-devel

# P/Invoke Dependencies
BuildRequires: pkgconfig(csapi-tizen)
BuildRequires: pkgconfig(capi-system-device)
BuildRequires: pkgconfig(capi-system-runtime-info)
BuildRequires: pkgconfig(capi-system-info)
BuildRequires: pkgconfig(storage)

# P/Invoke Runtime Dependencies
# TODO: It should be removed after fix tizen-rpm-config
# DLL Dependencies
Requires: capi-system-device
Requires: capi-system-runtime-info
Requires: capi-system-info
Requires: storage
#BuildRequires: ...

%description
Tizen System API for C#

%package devel
Summary:    Development package for %{name}
Group:      Development/Libraries
Requires:   %{name} = %{version}-%{release}

%description devel
Development package for %{name}

%prep
%setup -q

cp %{SOURCE1} .

%build
xbuild Tizen.System/Tizen.System.csproj /p:Configuration=%{BUILDCONF}

%install
gacutil -i Tizen.System/bin/%{BUILDCONF}/*.dll -root "%{buildroot}%{_libdir}" -package tizen

# generate pkgconfig
mkdir -p %{buildroot}%{_libdir}/pkgconfig
sed -e "s#@name@#%{name}#g" \
    -e "s#@version@#%{version}#g" \
    -e "s#@libs@#%{pc_libs}#g" \
    %{SOURCE2} > %{buildroot}%{_libdir}/pkgconfig/%{name}.pc


%files
%{_libdir}/mono

%files devel
%{_libdir}/pkgconfig/%{name}.pc

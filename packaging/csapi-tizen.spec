%define dllpath %{_libdir}/mono/tizen

Name:       csapi-tizen
Summary:    Tizen API for C#
Version:    1.0.0
Release:    1
Group:      Development/Libraries
License:    Apache-2.0
URL:        https://www.tizen.org
Source0:    %{name}-%{version}.tar.gz
Source1:    %{name}.manifest
Source2:    %{name}.pc.in

BuildRequires: mono-compiler
BuildRequires: mono-devel
BuildRequires: pkgconfig(dlog)
BuildRequires: pkgconfig(capi-base-common)

# Add p/invoke runtime dependencies should be added manually
Requires: libdlog
Requires: capi-base-common

Requires(post): mono-core
Requires(postun): mono-core

%description
Tizen API for C#

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
make

%install
# copy dll
mkdir -p %{buildroot}%{dllpath}
install -p -m 644 Tizen.dll %{buildroot}%{dllpath}
install -p -m 644 Tizen.Internals.dll %{buildroot}%{dllpath}

# generate pkgconfig
mkdir -p %{buildroot}%{_libdir}/pkgconfig
sed -e "s#@version@#%{version}#g" \
    -e "s#@dllpath@#%{dllpath}#g" \
    %{SOURCE2} > %{buildroot}%{_libdir}/pkgconfig/%{name}.pc

%post
gacutil -i %{dllpath}/Tizen.dll
gacutil -i %{dllpath}/Tizen.Internals.dll

%files
%{dllpath}/Tizen.dll
%{dllpath}/Tizen.Internals.dll

%files devel
%{_libdir}/pkgconfig/%{name}.pc

%define BUILDCONF Debug

%define dllpath %{_libdir}/mono/tizen
%define dllname Tizen.System.dll

Name:       csapi-system.sensor
Summary:    Tizen Sensor API for C#
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
#BuildRequires: mcs
#BuildRequires: mono-shlib-cop
BuildRequires: pkgconfig(csapi-tizen)
BuildRequires: pkgconfig(glib-2.0)

# TODO: replace mono-core to gacutil.
#       mono-core should provide the symbol 'gacutil'
Requires(post): mono-core
Requires(postun): mono-core

# P/Invoke Dependencies
BuildRequires: pkgconfig(capi-system-sensor)

# P/Invoke Runtime Dependencies
# TODO: It should be removed after fix tizen-rpm-config
Requires: capi-system-sensor
# DLL Dependencies
#BuildRequires: ...

%description
Tizen Sensor API for C#

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
# build dll
xbuild Tizen.System.Sensor/Tizen.System.Sensor.csproj /p:Configuration=%{BUILDCONF}

# check p/invoke
if [ -x %{dllname} ]; then
  RET=`mono-shlib-cop %{dllname}`; \
  CNT=`echo $RET | grep -E "^error:" | wc -l`; \
  if [ $CNT -gt 0 ]; then exit 1; fi
fi

%install
# copy dll
gacutil -i Tizen.System.Sensor/bin/%{BUILDCONF}/*.dll -root "%{buildroot}%{_libdir}" -package tizen

# generate pkgconfig
%define pc_libs %{_libdir}/mono/tizen/Tizen.System.Sensor.dll
mkdir -p %{buildroot}%{_libdir}/pkgconfig
sed -e "s#@name@#%{name}#g" \
    -e "s#@version@#%{version}#g" \
    -e "s#@libs@#%{pc_libs}#g" \
    %{SOURCE2} > %{buildroot}%{_libdir}/pkgconfig/%{name}.pc

%files
%manifest %{name}.manifest
%{_libdir}/mono/

%files devel
%{_libdir}/pkgconfig/%{name}.pc

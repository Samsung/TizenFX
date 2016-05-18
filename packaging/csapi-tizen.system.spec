%define dllpath %{_libdir}/mono/tizen
%define dllname Tizen.System.dll

Name:       csapi-tizen.system
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
# TODO: replace mono-core to gacutil.
#       mono-core should provide the symbol 'gacutil'
Requires(post): mono-core
Requires(postun): mono-core

# P/Invoke Dependencies
BuildRequires: pkgconfig(capi-system-device)

# P/Invoke Runtime Dependencies
# TODO: It should be removed after fix tizen-rpm-config
Requires: capi-system-device
# DLL Dependencies
BuildRequires: pkgconfig(csapi-tizen)
#BuildRequires: ...

%description
Tizen System Device API for C#

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
mcs -target:library -out:%{dllname} -keyfile:Tizen.System/Tizen.System.snk -pkg:csapi-tizen \
  Tizen.System/Properties/AssemblyInfo.cs \
  Tizen.System/Device/DeviceEventArgs.cs \
  Tizen.System/Device/DeviceExceptionFactory.cs \
  Tizen.System/Device/Battery.cs \
  Tizen.System/Device/Display.cs \
  Tizen.System/Device/Haptic.cs \
  Tizen.System/Device/IR.cs \
  Tizen.System/Device/Led.cs \
  Tizen.System/Device/Power.cs \
  Tizen.System/Interop/Interop.Device.cs

# check p/invoke
if [ -x %{dllname} ]; then
  RET=`mono-shlib-cop %{dllname}`; \
  CNT=`echo $RET | grep -E "^error:" | wc -l`; \
  if [ $CNT -gt 0 ]; then exit 1; fi
fi

%install
# copy dll
mkdir -p %{buildroot}%{dllpath}
install -p -m 644 %{dllname} %{buildroot}%{dllpath}

# generate pkgconfig
mkdir -p %{buildroot}%{_libdir}/pkgconfig
sed -e "s#@version@#%{version}#g" \
    -e "s#@dllpath@#%{dllpath}#g" \
    -e "s#@dllname@#%{dllname}#g" \
    %{SOURCE2} > %{buildroot}%{_libdir}/pkgconfig/%{name}.pc

%post
gacutil -i %{dllpath}/%{dllname}

%files
%{dllpath}/%{dllname}

%files devel
%{_libdir}/pkgconfig/%{name}.pc

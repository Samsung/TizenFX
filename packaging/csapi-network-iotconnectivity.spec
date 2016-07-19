%define BUILDCONF Debug

Name:       csapi-network-iotconnectivity
Summary:    Tizen IoT Connectivity API for C#
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
BuildRequires: pkgconfig(glib-2.0)
BuildRequires: pkgconfig(iotcon)
BuildRequires: pkgconfig(csapi-tizen)

%description
Tizen IoTConnectivity API for C#

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
xbuild Tizen.Network.IoTConnectivity/Tizen.Network.IoTConnectivity.csproj /p:Configuration=%{BUILDCONF}

%install
gacutil -i Tizen.Network.IoTConnectivity/bin/%{BUILDCONF}/Tizen.Network.IoTConnectivity.dll -root "%{buildroot}%{_libdir}" -package tizen

# generate pkgconfig
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

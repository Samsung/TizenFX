%define dllpath %{_libdir}/mono/tizen
%define dllname Tizen.Applications.dll

Name:       csapi-application
Summary:    Tizen Application API for C#
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
BuildRequires: pkgconfig(csapi-tizen)
BuildRequires: pkgconfig(glib-2.0)
BuildRequires: pkgconfig(capi-appfw-application)
BuildRequires: pkgconfig(appcore-agent)
BuildRequires: pkgconfig(capi-appfw-app-manager)
BuildRequires: pkgconfig(message-port)

Requires: capi-appfw-application
Requires: capi-message-port
Requires: appcore-agent


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
install -p -m 644 %{dllname} %{buildroot}%{dllpath}

# generate pkgconfig
mkdir -p %{buildroot}%{_libdir}/pkgconfig
sed -e "s#@version@#%{version}#g" \
    -e "s#@dllpath@#%{dllpath}#g" \
    -e "s#@dllname@#%{dllname}#g" \
    %{SOURCE2} > %{buildroot}%{_libdir}/pkgconfig/%{name}.pc

%post
gacutil -i %{dllpath}/%{dllname}

find %{_libdir}/mono/gac -name Tizen*  -exec chsmack -a "_" {} \;

%files
%manifest %{name}.manifest
%{dllpath}/%{dllname}

%files devel
%{_libdir}/pkgconfig/%{name}.pc

%define BUILDCONF Debug

Name:       csapi-download
Summary:    Tizen Downlaod API for C#
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
BuildRequires: pkgconfig(capi-appfw-application)
BuildRequires: pkgconfig(capi-web-url-download)
BuildRequires: pkgconfig(csapi-tizen)
BuildRequires: pkgconfig(csapi-application)

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
xbuild Tizen.Content.Download/Tizen.Content.Download.csproj /p:Configuration=%{BUILDCONF}

%install
gacutil -i Tizen.Content.Download/bin/%{BUILDCONF}/Tizen.Content.Download.dll -root "%{buildroot}%{_libdir}" -package tizen

# generate pkgconfig
mkdir -p %{buildroot}%{_libdir}/pkgconfig
sed -e "s#@name@#%{name}#g" \
    -e "s#@version@#%{version}#g" \
    -e "s#@libs@#%{pc_libs}#g" \
    %{SOURCE2} > %{buildroot}%{_libdir}/pkgconfig/%{name}.pc

%files
%{_libdir}/mono/

%files devel
%{_libdir}/pkgconfig/%{name}.pc

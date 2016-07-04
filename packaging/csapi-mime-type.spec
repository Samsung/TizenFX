%define BUILDCONF Debug

Name:       csapi-mime-type
Summary:    Tizen MimeType API for C#
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
BuildRequires: pkgconfig(capi-content-mime-type)
BuildRequires: pkgconfig(csapi-tizen)

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
# build dll
xbuild Tizen.Content.MimeType/Tizen.Content.MimeType.csproj /p:Configuration=%{BUILDCONF}

%install
gacutil -i Tizen.Content.MimeType/bin/%{BUILDCONF}/Tizen.Content.MimeType.dll -root "%{buildroot}%{_libdir}" -package tizen

# generate pkgconfig
mkdir -p %{buildroot}%{_libdir}/pkgconfig
sed -e "s#@version@#%{version}#g" \
    -e "s#@dllpath@#%{dllpath}#g" \
    -e "s#@dllname@#%{dllname}#g" \
    %{SOURCE2} > %{buildroot}%{_libdir}/pkgconfig/%{name}.pc

%files
%manifest %{name}.manifest
%{_libdir}/mono/

%files devel
%{_libdir}/pkgconfig/%{name}.pc

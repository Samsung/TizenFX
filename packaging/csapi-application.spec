Name:       csapi-application
Summary:    Tizen Application API for C#
Version:    1.2.1
Release:    1
Group:      Development/Libraries
License:    Apache-2.0
URL:        https://www.tizen.org
Source0:    %{name}-%{version}.tar.gz
Source1:    %{name}.manifest

AutoReqProv: no
ExcludeArch: aarch64

BuildRequires: dotnet-build-tools

# C# API Requires
BuildRequires: csapi-tizen-nuget

%define Assemblies Tizen.Applications.Common Tizen.Applications.MessagePort Tizen.Applications.Service Tizen.Applications.PackageManager Tizen.Applications.Notification Tizen.Applications.Preference Tizen.Applications.Alarm Tizen.Applications.UI Tizen.Applications

%description
%{summary}

%package -n %{name}-nuget
Summary:  An Application library in Tizen C# API
Group:  Development/Libraries

%description -n %{name}-nuget
An Application library in Tizen C# API package.

%package -n csapi-application-common
Summary:  An Application Common library in Tizen C# API
Group:  Development/Libraries
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-common
An Application Common library in Tizen C# API package.

%package -n csapi-application-common-nuget
Summary:  An Application Common library in Tizen C# API
Group:  Development/Libraries

%description -n csapi-application-common-nuget
An Application Common library in Tizen C# API package.

%package -n csapi-application-message-port
Summary:  An Application IPC library in Tizen C# API
Group:  Development/Libraries
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-message-port
An Application IPC library in Tizen C# API package.

%package -n csapi-application-message-port-nuget
Summary:  An Application IPC library in Tizen C# API
Group:  Development/Libraries

%description -n csapi-application-message-port-nuget
An Application IPC library in Tizen C# API package.

%package -n csapi-application-package-manager
Summary:  A package library in Tizen C# API
Group:  Development/Libraries
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-package-manager
A package library in Tizen C# API package.

%package -n csapi-application-package-manager-nuget
Summary:  A package library in Tizen C# API
Group:  Development/Libraries

%description -n csapi-application-package-manager-nuget
A package library in Tizen C# API package.

%package -n csapi-application-notification
Summary:  A notification library in Tizen C# API
Group:  Development/Libraries
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-notification
A notification library in Tizen C# API package.

%package -n csapi-application-notification-nuget
Summary:  A notification library in Tizen C# API
Group:  Development/Libraries

%description -n csapi-application-notification-nuget
A notification library in Tizen C# API package.

%package -n csapi-application-preference
Summary:  A preference library in Tizen C# API
Group:  Development/Libraries
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-preference
A preference library in Tizen C# API package.

%package -n csapi-application-preference-nuget
Summary:  A preference library in Tizen C# API
Group:  Development/Libraries

%description -n csapi-application-preference-nuget
A preference library in Tizen C# API package.

%package -n csapi-application-alarm
Summary:  An alarm library in Tizen C# API
Group:  Development/Libraries
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-alarm
An alarm library in Tizen C# API package.

%package -n csapi-application-alarm-nuget
Summary:  An alarm library in Tizen C# API
Group:  Development/Libraries

%description -n csapi-application-alarm-nuget
An alarm library in Tizen C# API package.

%package -n csapi-application-service
Summary:  A service application library in Tizen C# API
Group:  Development/Libraries
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-service
A service application library in Tizen C# API package.

%package -n csapi-application-service-nuget
Summary:  A service application library in Tizen C# API
Group:  Development/Libraries

%description -n csapi-application-service-nuget
A service application library in Tizen C# API package.

%package -n csapi-application-ui
Summary:  An ui application library in Tizen C# API
Group:  Development/Libraries
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-ui
An ui application library in Tizen C# API package.

%package -n csapi-application-ui-nuget
Summary:  An ui application library in Tizen C# API
Group:  Development/Libraries

%description -n csapi-application-ui-nuget
An ui application library in Tizen C# API package.

%prep
%setup -q
cp %{SOURCE1} .

%build
SOURCES="/nuget;$(readlink -f .nuget)"

for ASM in %{Assemblies}; do
%dotnet_restore $ASM "-Source $SOURCES"
done

%dotnet_build Tizen.Applications.sln

for ASM in %{Assemblies}; do
%dotnet_pack $ASM/$ASM.nuspec %{version}
done

%install
for ASM in %{Assemblies}; do
%dotnet_install $ASM
done

%files -n csapi-application-common
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.Common.dll

%files -n csapi-application-common-nuget
/nuget/Tizen.Applications.Common.%{version}.nupkg

%files -n csapi-application-message-port
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.MessagePort.dll

%files -n csapi-application-message-port-nuget
/nuget/Tizen.Applications.MessagePort.%{version}.nupkg

%files -n csapi-application-package-manager
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.PackageManager.dll

%files -n csapi-application-package-manager-nuget
/nuget/Tizen.Applications.PackageManager.%{version}.nupkg

%files -n csapi-application-notification
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.Notification.dll

%files -n csapi-application-notification-nuget
/nuget/Tizen.Applications.Notification.%{version}.nupkg

%files -n csapi-application-preference
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.Preference.dll

%files -n csapi-application-preference-nuget
/nuget/Tizen.Applications.Preference.%{version}.nupkg

%files -n csapi-application-alarm
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.Alarm.dll

%files -n csapi-application-alarm-nuget
/nuget/Tizen.Applications.Alarm.%{version}.nupkg

%files -n csapi-application-service
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.Service.dll

%files -n csapi-application-service-nuget
/nuget/Tizen.Applications.Service.%{version}.nupkg

%files -n csapi-application-ui
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.UI.dll

%files -n csapi-application-ui-nuget
/nuget/Tizen.Applications.UI.%{version}.nupkg

%files
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.dll

%files -n %{name}-nuget
/nuget/Tizen.Applications.%{version}.nupkg


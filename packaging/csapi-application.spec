Name:       csapi-application
Summary:    Tizen Application API for C#
Version:    1.5.8
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

%define Assemblies Tizen.Applications.Common Tizen.Applications.MessagePort Tizen.Applications.Service Tizen.Applications.PackageManager Tizen.Applications.Notification Tizen.Applications.NotificationEventListener Tizen.Applications.Preference Tizen.Applications.Alarm Tizen.Applications.UI Tizen.Applications.ToastMessage

%description
%{summary}

%define ApplicationCommon 1.5.8
%define MessagePort 1.5.8
%define PackageManager 1.5.8
%define Notification 1.5.8
%define NotificationEventListener 1.5.8
%define Alarm 1.5.8
%define Preference 1.5.8
%define ApplicationService 1.5.8
%define ApplicationUI 1.5.8
%define ToastMessage 1.5.8

%package -n csapi-application-common
Summary:  An Application Common library in Tizen C# API
Version:  %{ApplicationCommon}
Group:  Development/Libraries
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-common
An Application Common library in Tizen C# API package.

%package -n csapi-application-common-nuget
Summary:  An Application Common library in Tizen C# API
Version:  %{ApplicationCommon}
Group:  Development/Libraries

%description -n csapi-application-common-nuget
An Application Common library in Tizen C# API package.

%package -n csapi-application-message-port
Summary:  An Application IPC library in Tizen C# API
Version:  %{MessagePort}
Group:  Development/Libraries
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-message-port
An Application IPC library in Tizen C# API package.

%package -n csapi-application-message-port-nuget
Summary:  An Application IPC library in Tizen C# API
Version:  %{MessagePort}
Group:  Development/Libraries

%description -n csapi-application-message-port-nuget
An Application IPC library in Tizen C# API package.

%package -n csapi-application-package-manager
Summary:  A package library in Tizen C# API
Group:  Development/Libraries
Version:  %{PackageManager}
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-package-manager
A package library in Tizen C# API package.

%package -n csapi-application-package-manager-nuget
Summary:  A package library in Tizen C# API
Version:  %{PackageManager}
Group:  Development/Libraries

%description -n csapi-application-package-manager-nuget
A package library in Tizen C# API package.

%package -n csapi-application-notification
Summary:  A notification library in Tizen C# API
Version:  %{Notification}
Group:  Development/Libraries
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-notification
A notification library in Tizen C# API package.

%package -n csapi-application-notification-nuget
Summary:  A notification library in Tizen C# API
Version:  %{Notification}
Group:  Development/Libraries

%description -n csapi-application-notification-nuget
A notification library in Tizen C# API package.

%package -n csapi-application-toastmessage
Summary:  A toastmessage library in Tizen C# API
Version:  %{ToastMessage}
Group:  Development/Libraries
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-toastmessage
A toastmessage library in Tizen C# API package.

%package -n csapi-application-toastmessage-nuget
Summary:  A toastmessage library in Tizen C# API
Version:  %{ToastMessage}
Group:  Development/Libraries

%description -n csapi-application-toastmessage-nuget
A toastmessage library in Tizen C# API package.

%package -n csapi-application-notificationeventlistener
Summary:  A notificationeventlistener library in Tizen C# API
Version:  %{NotificationEventListener}
Group:  Development/Libraries
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-notificationeventlistener
A notificationeventlistener library in Tizen C# API package.

%package -n csapi-application-notificationeventlistener-nuget
Summary:  A notificationeventlistener library in Tizen C# API
Version:  %{NotificationEventListener}
Group:  Development/Libraries

%description -n csapi-application-notificationeventlistener-nuget
A notificationeventlistener library in Tizen C# API package.

%package -n csapi-application-preference
Summary:  A preference library in Tizen C# API
Version:  %{Preference}
Group:  Development/Libraries
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-preference
A preference library in Tizen C# API package.

%package -n csapi-application-preference-nuget
Summary:  A preference library in Tizen C# API
Version:  %{Preference}
Group:  Development/Libraries

%description -n csapi-application-preference-nuget
A preference library in Tizen C# API package.

%package -n csapi-application-alarm
Summary:  An alarm library in Tizen C# API
Version:  %{Alarm}
Group:  Development/Libraries
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-alarm
An alarm library in Tizen C# API package.

%package -n csapi-application-alarm-nuget
Summary:  An alarm library in Tizen C# API
Version:  %{Alarm}
Group:  Development/Libraries

%description -n csapi-application-alarm-nuget
An alarm library in Tizen C# API package.

%package -n csapi-application-service
Summary:  A service application library in Tizen C# API
Version:  %{ApplicationService}
Group:  Development/Libraries
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-service
A service application library in Tizen C# API package.

%package -n csapi-application-service-nuget
Summary:  A service application library in Tizen C# API
Version:  %{ApplicationService}
Group:  Development/Libraries

%description -n csapi-application-service-nuget
A service application library in Tizen C# API package.

%package -n csapi-application-ui
Summary:  An ui application library in Tizen C# API
Version:  %{ApplicationUI}
Group:  Development/Libraries
AutoReqProv: no
ExcludeArch: aarch64

%description -n csapi-application-ui
An ui application library in Tizen C# API package.

%package -n csapi-application-ui-nuget
Summary:  An ui application library in Tizen C# API
Version:  %{ApplicationUI}
Group:  Development/Libraries

%description -n csapi-application-ui-nuget
An ui application library in Tizen C# API package.

%prep
%setup -q
cp %{SOURCE1} .

%build

%dotnet_build Tizen.Applications.sln

for ASM in %{Assemblies}; do
%dotnet_pack $ASM
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
/nuget/Tizen.Applications.Common.%{ApplicationCommon}.nupkg

%files -n csapi-application-message-port
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.MessagePort.dll

%files -n csapi-application-message-port-nuget
/nuget/Tizen.Applications.MessagePort.%{MessagePort}.nupkg

%files -n csapi-application-package-manager
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.PackageManager.dll

%files -n csapi-application-package-manager-nuget
/nuget/Tizen.Applications.PackageManager.%{PackageManager}.nupkg

%files -n csapi-application-notification
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.Notification.dll

%files -n csapi-application-notification-nuget
/nuget/Tizen.Applications.Notification.%{Notification}.nupkg

%files -n csapi-application-notificationeventlistener
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.NotificationEventListener.dll

%files -n csapi-application-notificationeventlistener-nuget
/nuget/Tizen.Applications.NotificationEventListener.%{NotificationEventListener}.nupkg

%files -n csapi-application-toastmessage
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.ToastMessage.dll

%files -n csapi-application-toastmessage-nuget
/nuget/Tizen.Applications.ToastMessage.%{ToastMessage}.nupkg

%files -n csapi-application-preference
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.Preference.dll

%files -n csapi-application-preference-nuget
/nuget/Tizen.Applications.Preference.%{Preference}.nupkg

%files -n csapi-application-alarm
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.Alarm.dll

%files -n csapi-application-alarm-nuget
/nuget/Tizen.Applications.Alarm.%{Alarm}.nupkg

%files -n csapi-application-service
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.Service.dll

%files -n csapi-application-service-nuget
/nuget/Tizen.Applications.Service.%{ApplicationService}.nupkg

%files -n csapi-application-ui
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{_dotnet_assembly_path}/Tizen.Applications.UI.dll

%files -n csapi-application-ui-nuget
/nuget/Tizen.Applications.UI.%{ApplicationUI}.nupkg


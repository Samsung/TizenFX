Name:       csapi-multimedia
Summary:    Tizen Multimedia API for C#
Version:    1.1.2
Release:    0
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
BuildRequires: csapi-application-common-nuget
BuildRequires: elm-sharp-nuget
BuildRequires: csapi-information-nuget

%define Assemblies \
	Tizen.Multimedia 1.2.0 \
	Tizen.Multimedia.AudioIO 1.0.0 \
	Tizen.Multimedia.Camera 1.0.0 \
	Tizen.Multimedia.MediaCodec 1.0.0 \
	Tizen.Multimedia.MediaPlayer 1.0.0 \
	Tizen.Multimedia.Metadata 1.0.0 \
	Tizen.Multimedia.Radio 1.0.1 \
	Tizen.Multimedia.Recorder 1.0.0 \
	Tizen.Multimedia.StreamRecorder 1.0.0 \
	Tizen.Multimedia.Remoting 1.0.0 \
	Tizen.Multimedia.Util 1.0.1 \
	Tizen.Multimedia.Vision 1.0.0

%description
%{summary}

%dotnet_import_sub_packages

%prep
%setup -q
cp %{SOURCE1} .

%build
%dotnet_build Tizen.Multimedia.sln

AssemArray=(%Assemblies)

for((i=0; i<${#AssemArray[*]};i+=2))
do
	AsmName=${AssemArray[$i]}
	AsmVer=${AssemArray[$i+1]}
	%dotnet_pack $AsmName/$AsmName.nuspec $AsmVer
done

%install
AssemArray=(%Assemblies)

for((i=0; i<${#AssemArray[*]};i+=2))
do
	AsmName=${AssemArray[$i]}
	%dotnet_install $AsmName
done

%files
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{dotnet_assembly_files}

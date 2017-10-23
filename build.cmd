@if not defined _echo @echo off
setlocal

if /I [%1] == [] goto Usage
if /I [%1] == [build] goto ModuleBuild
if /I [%1] == [full] goto FullBuild
if /I [%1] == [dummy] goto DummyBuild
if /I [%1] == [pack] goto Pack
if /I [%1] == [clean] goto Clean

goto :EOF

:Usage
echo Usage: %0 [command] [args]
echo Commands:
echo   build [module]     Build a specific module
echo   full               Build all modules in src/ directory
echo   dummy              Generate dummy assemblies of all modules
echo   pack [version]     Make a NuGet package with build artifacts
echo   clean              Clean all artifacts
echo.
goto :EOF

:ModuleBuild
if /I [%2] == [] (
  echo No module specified.
  exit /b !ERRORLEVEL!
)
call dotnet msbuild %~dp0build\build.proj /t:build /p:Project=%2
goto :EOF

:FullBuild
call dotnet msbuild %~dp0build\build.proj /t:build
goto :EOF

:DummyBuild
call dotnet build %~dp0build\build.dummy.csproj
goto :EOF

:Pack
set NUGET_VERSION_OPT=
if /I not [%2] == [] set NUGET_VERSION_OPT=-Version %2
set OUTDIR=%~dp0Artifacts
set NUGET_CMD=%~dp0tools\NuGet.exe
%NUGET_CMD% pack %~dp0pkg\Tizen.NET.Private.nuspec -Symbols -NoPackageAnalysis %NUGET_VERSION_OPT% -BasePath %~dp0 -OutputDirectory %OUTDIR%
%NUGET_CMD% pack %~dp0pkg\Tizen.NET.nuspec -Symbols -NoPackageAnalysis %NUGET_VERSION_OPT% -BasePath %~dp0 -OutputDirectory %OUTDIR%
goto :EOF

:Clean
call dotnet msbuild %~dp0build\build.proj /t:clean
goto :EOF

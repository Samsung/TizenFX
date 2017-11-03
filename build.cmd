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
call dotnet msbuild %~dp0build\build.proj /nologo /t:restore /p:Project=%2
call dotnet msbuild %~dp0build\build.proj /nologo /t:build /p:Project=%2
goto :EOF

:FullBuild
call dotnet msbuild %~dp0build\build.proj /nologo /t:clean
call dotnet msbuild %~dp0build\build.proj /nologo /t:restore
call dotnet msbuild %~dp0build\build.proj /nologo /t:build
goto :EOF

:DummyBuild
call dotnet build %~dp0build\build.dummy.csproj
goto :EOF

:Pack
set VERSION=%2
set VERSION_INTERNAL=%3
call :GetUnixTime TIMESTAMP
if /I [%VERSION%] == [] set VERSION=4.0.1-local-%TIMESTAMP%
if /I [%VERSION_INTERNAL%] == [] set VERSION_INTERNAL=%VERSION%
set OUTDIR=%~dp0Artifacts
set NUGET_CMD=%~dp0tools\NuGet.exe
%NUGET_CMD% pack %~dp0pkg\Tizen.NET.nuspec -NoPackageAnalysis -Version %VERSION% -BasePath %~dp0 -OutputDirectory %OUTDIR%
%NUGET_CMD% pack %~dp0pkg\Tizen.NET.Internals.nuspec -NoPackageAnalysis -Version %VERSION_INTERNAL% -BasePath %~dp0 -OutputDirectory %OUTDIR%
goto :EOF

:Clean
call dotnet msbuild %~dp0build\build.proj /nologo /t:clean
goto :EOF

:GetUnixTime
setlocal enableextensions
for /f %%x in ('wmic path win32_utctime get /format:list ^| findstr "="') do (
    set %%x)
set /a z=(14-100%Month%%%100)/12, y=10000%Year%%%10000-z
set /a ut=y*365+y/4-y/100+y/400+(153*(100%Month%%%100+12*z-3)+2)/5+Day-719469
set /a ut=ut*86400+100%Hour%%%100*3600+100%Minute%%%100*60+100%Second%%%100
endlocal & set "%1=%ut%" & goto :EOF

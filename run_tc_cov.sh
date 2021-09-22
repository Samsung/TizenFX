#!/bin/bash

cd test/Tizen.NUI.Tests/Tizen.NUI.Devel.Tests
dotnet clean
dotnet build
cd ../../../
./coverage_ubuntu.sh -i Tizen.NUI
./coverage_ubuntu.sh -c Tizen.NUI

cd test/Tizen.NUI.Tests/Tizen.NUI.Devel.Tests
chmod +x bin/Debug/netcoreapp3.1/Tizen.NUI.Devel.Tests.dll
bin/Debug/netcoreapp3.1/Tizen.NUI.Devel.Tests.dll
cd ../../../

#dotnet run



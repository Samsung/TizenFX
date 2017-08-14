#!/bin/bash

SCRIPT_FILE=$(readlink -f $0)
SCRIPT_DIR=$(dirname $SCRIPT_FILE)

# Properties
OUTDIR=$SCRIPT_DIR/Artifacts

# clean
rm -fr $OUTDIR
dotnet clean $SCRIPT_DIR/pkg/Tizen.NET.Private.sln

# build
dotnet build $SCRIPT_DIR/pkg/Tizen.NET.Private.sln --configuration=Release --output=$OUTDIR/bin

# pack
nuget pack pkg/Tizen.NET.Private.nuspec -Symbols -NoPackageAnalysis -BasePath $OUTDIR -OutputDirectory $OUTDIR
nuget pack pkg/Tizen.NET.nuspec -Symbols -NoPackageAnalysis -BasePath $OUTDIR -OutputDirectory $OUTDIR

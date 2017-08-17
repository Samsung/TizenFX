#!/bin/bash

SCRIPT_FILE=$(readlink -f $0)
SCRIPT_DIR=$(dirname $SCRIPT_FILE)

# Properties
OUTDIR=$SCRIPT_DIR/Artifacts



usage() {
  echo "Usage: $0 [options] [args]"
  echo "    Options:"
  echo "        -h, --help            Show this usages message"
  echo "        -b, --build [module]  Build a module"
  echo "        -f, --full            Build all modules in src/ directory. The module should be added in pkg/Tizen.NET.Private.sln"
  echo "        -d, --dummy           Build dummy modules"
  echo "        -c, --clean           Clean all artifacts"
}

cmd_clean() {
  rm -fr $OUTDIR
  LIST=$(find $SCRIPT_DIR -type d -a -name bin -o -name obj)
  for d in $LIST; do
    rm -fr $d
  done
}

cmd_build() {
  if [ -z "$1" ]; then
    echo "No module specified."
    exit 1
  fi
  dotnet build $SCRIPT_DIR/src/$1 --configuration=Release --output=$OUTDIR/bin
}

cmd_full_build() {
  dotnet build $SCRIPT_DIR/pkg/Tizen.NET.Private.sln --configuration=Release --output=$OUTDIR/bin
  nuget pack $SCRIPT_DIR/pkg/Tizen.NET.Private.nuspec -Symbols -NoPackageAnalysis -BasePath $OUTDIR -OutputDirectory $OUTDIR
  nuget pack $SCRIPT_DIR/pkg/Tizen.NET.nuspec -Symbols -NoPackageAnalysis -BasePath $OUTDIR -OutputDirectory $OUTDIR
}

cmd_dummy_build() {
  dotnet build $SCRIPT_DIR/pkg/Tizen.NET.Dummy.csproj --configuration=Release
}

OPTS=`getopt -o hcbfd --long help,clean,build,full,dummy -n 'build' -- "$@"`
if [ $? != 0 ] ; then echo "Failed parsing options." >&2 ; usage; exit 1 ; fi
eval set -- "$OPTS"

FLAG_HELP=false
FLAG_FULL=false
FLAG_BUILD=false
FLAG_CLEAN=false
FLAG_DUMMY=false

while true; do
  case "$1" in
    -h|--help) FLAG_HELP=true; shift ;;
    -b|--build) FLAG_BUILD=true; shift ;;
    -f|--full) FLAG_FULL=true; shift ;;
    -d|--dummy) FLAG_DUMMY=true; shift ;;
    -c|--clean) FLAG_CLEAN=true; shift ;;
    --) shift; break ;;
    *) break ;;
  esac
done

if $FLAG_HELP; then usage; exit 1; fi
if $FLAG_CLEAN; then cmd_clean; exit 1; fi
if $FLAG_FULL; then cmd_full_build; exit 1; fi
if $FLAG_BUILD; then cmd_build $@; exit 1; fi
if $FLAG_DUMMY; then cmd_dummy_build; exit 1; fi

usage;
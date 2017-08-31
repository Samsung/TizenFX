#!/bin/bash

SCRIPT_FILE=$(readlink -f $0)
SCRIPT_DIR=$(dirname $SCRIPT_FILE)

# Properties
OUTDIR=$SCRIPT_DIR/Artifacts
NUGET_CMD="mono $SCRIPT_DIR/tools/NuGet.exe"

usage() {
  echo "Usage: $0 [options] [args]"
  echo "    Options:"
  echo "        -h, --help            Show this usages message"
  echo "        -b, --build [module]  Build a module"
  echo "        -f, --full            Build all modules in src/ directory. (pkg/Tizen.NET.Private.sln)"
  echo "        -d, --dummy           Build dummy modules"
  echo "        -p, --pack            Make nuget packages"
  echo "        -c, --clean           Clean all artifacts"
}

dotnet_build() {
  if [ -d /nuget ]; then
    NUGET_SOURCE_OPT="--source /nuget"
  fi
  PROJ=$1; shift
  dotnet restore $PROJ $NUGET_SOURCE_OPT
  dotnet build $PROJ --no-restore --configuration=Release $@
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
  dotnet_build $SCRIPT_DIR/src/$1 --output=$OUTDIR/bin
}

cmd_full_build() {
  dotnet_build $SCRIPT_DIR/pkg/Tizen.NET.Private.sln --output=$OUTDIR/bin
}

cmd_pack() {
  VERSION_FILE=$OUTDIR/Version.txt
  if [ -f $VERSION_FILE ]; then
    NUGET_VERSION_PREFIX=$(cat $VERSION_FILE | grep Prefix | cut -d: -f2 | sed 's/\r$//')
    NUGET_VERSION_SUFFIX=$(cat $VERSION_FILE | grep Suffix | cut -d: -f2 | sed 's/\r$//')
	  NUGET_VERSION_OPT="-Version $NUGET_VERSION_PREFIX-$NUGET_VERSION_SUFFIX"
  fi
  $NUGET_CMD pack $SCRIPT_DIR/pkg/Tizen.NET.Private.nuspec -Symbols -NoPackageAnalysis $NUGET_VERSION_OPT -BasePath $SCRIPT_DIR -OutputDirectory $OUTDIR
  $NUGET_CMD pack $SCRIPT_DIR/pkg/Tizen.NET.nuspec -Symbols -NoPackageAnalysis $NUGET_VERSION_OPT -BasePath $SCRIPT_DIR -OutputDirectory $OUTDIR
}

cmd_dummy_build() {
  dotnet_build $SCRIPT_DIR/pkg/Tizen.NET.Dummy.csproj
}

OPTS=`getopt -o hcbfpd --long help,clean,build,full,pack,dummy -n 'build' -- "$@"`
if [ $? != 0 ] ; then echo "Failed parsing options." >&2 ; usage; exit 1 ; fi
eval set -- "$OPTS"

FLAG_HELP=false
FLAG_FULL=false
FLAG_BUILD=false
FLAG_CLEAN=false
FLAG_DUMMY=false
FLAG_PACK=false

while true; do
  case "$1" in
    -h|--help) FLAG_HELP=true; shift ;;
    -b|--build) FLAG_BUILD=true; shift ;;
    -f|--full) FLAG_FULL=true; shift ;;
    -d|--dummy) FLAG_DUMMY=true; shift ;;
    -p|--pack) FLAG_PACK=true; shift ;;
    -c|--clean) FLAG_CLEAN=true; shift ;;
    --) shift; break ;;
    *) break ;;
  esac
done

if $FLAG_HELP; then usage; exit 0; fi
if $FLAG_CLEAN; then cmd_clean; exit 0; fi
if $FLAG_FULL; then cmd_full_build; exit 0; fi
if $FLAG_BUILD; then cmd_build $@; exit 0; fi
if $FLAG_PACK; then cmd_pack $@; exit 0; fi
if $FLAG_DUMMY; then cmd_dummy_build; exit 0; fi

usage;

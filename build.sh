#!/bin/bash

SCRIPT_FILE=$(readlink -f $0)
SCRIPT_DIR=$(dirname $SCRIPT_FILE)

OUTDIR=$SCRIPT_DIR/Artifacts

RUN_BUILD="dotnet msbuild $SCRIPT_DIR/build/build.proj /nologo"

VERSION_PREFIX=6.0.0

usage() {
  echo "Usage: $0 [command] [args]"
  echo "Commands:"
  echo "    build [module]     Build a specific module"
  echo "    full               Build all modules in src/ directory"
  echo "    dummy              Generate dummy assemblies of all modules"
  echo "    pack [version]     Make a NuGet package with build artifacts"
  echo "    clean              Clean all artifacts"
}

cmd_build() {
  if [ -z "$1" ]; then
    echo "No module specified."
    exit 1
  fi
  if [ -d /nuget ]; then
    NUGET_SOURCE_OPT="/p:RestoreSources=/nuget"
  fi
  PROJECT=$1; shift
  $RUN_BUILD /t:restore /p:Project=$PROJECT $NUGET_SOURCE_OPT $@
  $RUN_BUILD /t:build /p:Project=$PROJECT $@
}

cmd_full_build() {
  if [ -d /nuget ]; then
    NUGET_SOURCE_OPT="/p:RestoreSources=/nuget"
  fi
  $RUN_BUILD /t:clean
  $RUN_BUILD /t:restore $NUGET_SOURCE_OPT $@
  $RUN_BUILD /t:build $@
}

cmd_dummy_build() {
  $RUN_BUILD /t:dummy
}

cmd_pack() {
  VERSION=$1
  if [ -z "$VERSION" ]; then
    VERSION=$VERSION_PREFIX.$((10000+$(git rev-list --count HEAD)))
  fi

  $RUN_BUILD /t:pack /p:Version=$VERSION
}

cmd_clean() {
  $RUN_BUILD /t:clean
}

cmd=$1; shift;
case "$cmd" in
  build|--build|-b) cmd_build $@ ;;
  full |--full |-f) cmd_full_build $@ ;;
  dummy|--dummy|-d) cmd_dummy_build $@ ;;
  pack |--pack |-p) cmd_pack $@ ;;
  clean|--clean|-c) cmd_clean $@ ;;
  *) usage ;;
esac

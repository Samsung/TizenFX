#!/bin/bash -e

SCRIPT_FILE=$(readlink -f $0)
SCRIPT_DIR=$(dirname $SCRIPT_FILE)

OUTDIR=$SCRIPT_DIR/Artifacts

RUN_BUILD="dotnet msbuild $SCRIPT_DIR/build/build.proj /nologo"

VERSION_PREFIX=8.0.0

usage() {
  echo "Usage: $0 [command] [args]"
  echo "Commands:"
  echo "    build [module]     Build a specific module"
  echo "    full               Build all modules in src/ directory"
  echo "    dummy              Generate dummy assemblies of all modules"
  echo "    pack [version]     Make a NuGet package with build artifacts"
  echo "    install [target]   Install assemblies to the target device"
  echo "    clean              Clean all artifacts"
}

clean() {
  $RUN_BUILD /t:clean
  rm -f msbuild.log
}

build() {
  if [ -d /nuget ]; then
    NUGET_SOURCE_OPT="/p:RestoreSources=/nuget"
  fi
  $RUN_BUILD /t:restore $NUGET_SOURCE_OPT $@
  $RUN_BUILD /t:build /fl $@
}

cmd_build() {
  if [ -z "$1" ]; then
    echo "No module specified."
    exit 1
  fi
  PROJECT=$1; shift
  build /p:Project=$PROJECT $@
}

cmd_full_build() {
  clean
  build $@
  cmd_dummy_build $@
}

cmd_design_build() {
  build /p:BuildDesignAssembly=True $@
  if [ -d "$OUTDIR"/bin/design ]; then
    cp -f "$OUTDIR"/bin/design/*.Design.dll "$SCRIPT_DIR"/pkg/Tizen.NET.API*/design/
  fi
}

cmd_dummy_build() {
  $RUN_BUILD /t:dummy $@
}

cmd_pack() {
  VERSION=$1
  if [ -z "$VERSION" ]; then
    pushd $SCRIPT_DIR > /dev/null
    VERSION=$VERSION_PREFIX.$((10000+$(git rev-list --count HEAD)))
    popd > /dev/null
  fi

  $RUN_BUILD /t:pack /p:Version=$VERSION
}

cmd_install() {
  DEVICE_ID=$1

  RUNTIME_ASSEMBLIES="$OUTDIR/bin/public/*.dll $OUTDIR/bin/internal/*.dll"
  TARGET_ASSEMBLY_PATH="/usr/share/dotnet.tizen/framework"

  device_cnt=$(sdb devices | grep -v "List" | wc -l)
  if [ $device_cnt -eq 0 ]; then
    echo "No connected devices"
    exit 1
  fi

  if [ $device_cnt -gt 1 ] && [ -z "$DEVICE_ID" ]; then
    echo "Multiple devices are connected. Specify the device. (ex: ./build.sh install [device-id])"
    sdb devices
    exit 1
  fi

  SDB_OPTIONS=""
  if [ -n "$DEVICE_ID" ]; then
    SDB_OPTIONS="-s $DEVICE_ID"
  fi

  sdb $SDB_OPTIONS root on
  sdb $SDB_OPTIONS shell mount -o remount,rw /
  sdb $SDB_OPTIONS push $RUNTIME_ASSEMBLIES $TARGET_ASSEMBLY_PATH

  nifile_cnt=$(sdb $SDB_OPTIONS shell find $TARGET_ASSEMBLY_PATH -name '*.ni.dll' | wc -l)
  if [ $nifile_cnt -gt 0 ]; then
    sdb $SDB_OPTIONS shell "rm -f $TARGET_ASSEMBLY_PATH/*.ni.dll"
    sdb $SDB_OPTIONS shell nitool --system
    sdb $SDB_OPTIONS shell nitool --regen-all-app
  fi

  sdb $SDB_OPTIONS shell chsmack -a '_' $TARGET_ASSEMBLY_PATH/*
}

cmd_clean() {
  $RUN_BUILD /t:clean
}

cmd=$1; shift;
case "$cmd" in
  build|--build|-b) cmd_build $@ ;;
  full |--full |-f) cmd_full_build $@ ;;
  dummy|--dummy|-d) cmd_dummy_build $@ ;;
  design|--design)  cmd_design_build $@ ;;
  pack |--pack |-p) cmd_pack $@ ;;
  install |--install |-i) cmd_install $@ ;;
  clean|--clean|-c) cmd_clean $@ ;;
  *) usage ;;
esac

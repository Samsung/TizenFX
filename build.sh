#!/bin/bash -e

SCRIPT_DIR=$(dirname $(readlink -f $0))

CONFIGURATION=Release
SLN_NAME=_Build
SLN_FILE=$SCRIPT_DIR/$SLN_NAME.sln
OUTDIR=$SCRIPT_DIR/Artifacts

PROFILES=(mobile tv wearable)
TARGET_ASSEMBLY_DIR=/usr/share/dotnet.tizen/framework
TARGET_PRELOAD_DIR=/usr/share/dotnet.tizen/preload

source $SCRIPT_DIR/packaging/version.txt
VERSION_PREFIX=$(expr $NUGET_VERSION : '\([0-9]\+\.[0-9]\+\.[0-9]\+\)')

usage() {
  echo "Usage: $0 [command] [args]"
  echo "Commands:"
  echo "    build [module]     Build a specific module"
  echo "    full               Build all modules in src/ directory"
  echo "    design             Build NUI Design module"
  echo "    xamlbuild          Build NUI XamlBuild module"
  echo "    dummy              Generate dummy assemblies of all modules"
  echo "    pack [version]     Make a NuGet package with build artifacts"
  echo "    install [target]   Install assemblies to the target device"
  echo "    clean              Clean all artifacts"
}

prepare_solution() {
  target=$1; [ -z "$target" ] && target="full"

  dotnet new sln -n $SLN_NAME -o $SCRIPT_DIR --force
  if [ "$target" == "public" -o "$target" == "full" ]; then
    dotnet sln $SLN_FILE add $SCRIPT_DIR/src/*/*.csproj
  fi
  if [ "$target" == "internal" -o "$target" == "full" ]; then
    dotnet sln $SLN_FILE add $SCRIPT_DIR/internals/src/*/*.csproj
  fi
  if [ "$target" == "design" ]; then
    dotnet sln $SLN_FILE add $SCRIPT_DIR/src/*/*.Design.csproj
  else
    dotnet sln $SLN_FILE remove $SCRIPT_DIR/src/*/*.Design.csproj
  fi
  if [ "$target" == "xamlbuild" ]; then
    dotnet sln $SLN_FILE add $SCRIPT_DIR/src/*/*.XamlBuild.csproj
  else
    dotnet sln $SLN_FILE remove $SCRIPT_DIR/src/*/*.XamlBuild.csproj
  fi
}

cleanup_solution() {
  rm -f $SLN_FILE
}

remove_intermediates() {
  find $1 -type d \
    \( -name obj -o -name bin \) -print0 | xargs -0 -I {} rm -fr "{}"
}

clean() {
  remove_intermediates $SCRIPT_DIR/build/
  remove_intermediates $SCRIPT_DIR/src/
  remove_intermediates $SCRIPT_DIR/internals/src/
  rm -fr $OUTDIR
  rm -f msbuild.log
  cleanup_solution
}

restore() {
  if [ -d /nuget ]; then
    dotnet restore -s /nuget $@
  else
    dotnet restore $@
  fi
}

build() {
  dotnet build --no-restore -c $CONFIGURATION /fl $@
}

copy_artifacts() {
  mkdir -p $2
  for proj in $(ls -d1 $1/*/); do
    if [ -d $proj/bin/$CONFIGURATION ]; then
      cp -fr $proj/bin/$CONFIGURATION/*/* $2
    fi
  done
}

build_artifacts() {
  copy_artifacts $SCRIPT_DIR/src $OUTDIR/bin/public
  copy_artifacts $SCRIPT_DIR/internals/src $OUTDIR/bin/internal

  # move preload
  mkdir -p $OUTDIR/preload
  mv $OUTDIR/bin/public/*.preload $OUTDIR/preload 2>/dev/null || :
  mv $OUTDIR/bin/internal/*.preload $OUTDIR/preload 2>/dev/null || :

  # merge filelist
  for profile in ${PROFILES[@]}; do
    list=$(cat $OUTDIR/bin/public/*.$profile.filelist \
               $OUTDIR/bin/internal/*.$profile.filelist \
               | sort | uniq)
    rm -f $OUTDIR/$profile.filelist
    for item in $list; do
      if [[ "$item" == *.preload ]]; then
        echo $TARGET_PRELOAD_DIR/$item >> $OUTDIR/$profile.filelist
      else
        echo $TARGET_ASSEMBLY_DIR/$item >> $OUTDIR/$profile.filelist
      fi
    done
  done
}

cmd_module_build() {
  if [ -z "$1" ]; then
    echo "No module specified."
    exit 1
  fi
  module=$1; shift;
  sources=(src internals/src)
  for src in $sources; do
    project=$SCRIPT_DIR/$src/$module/$module.csproj
    echo $project
    if [ -f "$project" ]; then
      restore $project
      build $project $@
    fi
  done
}

cmd_full_build() {
  clean
  prepare_solution full
  restore $SLN_FILE $@
  build $SLN_FILE $@
  cleanup_solution
  build_artifacts
  cmd_dummy_build
}

cmd_design_build() {
  prepare_solution design
  restore $SLN_FILE
  build $SLN_FILE $@
  projects=$(dirname $(ls -1 $SCRIPT_DIR/src/*/*.Design.csproj))
  for proj in $projects; do
    if [ -d $proj/bin/$CONFIGURATION ]; then
      cp -f $proj/bin/$CONFIGURATION/*/*.Design.dll $SCRIPT_DIR/pkg/Tizen.NET.API*/design/
    fi
  done
  cleanup_solution
}

cmd_xamlbuild_build() {
  prepare_solution xamlbuild
  restore $SLN_FILE
  build $SLN_FILE $@
  projects=$(dirname $(ls -1 $SCRIPT_DIR/src/*/*.XamlBuild.csproj))
  for proj in $projects; do
    if [ -d $proj/bin/$CONFIGURATION ]; then
      cp -f $proj/bin/$CONFIGURATION/*/*.XamlBuild.dll $SCRIPT_DIR/pkg/Tizen.NET.API*/xamlbuild/
    fi
  done
  cleanup_solution
}

cmd_dummy_build() {
  if [ ! -d $OUTDIR/bin/public/ref  ]; then
    echo "No assemblies to read. Build TizenFX first."
    exit 1
  fi
  mkdir -p $OUTDIR/bin/dummy
  CACHE=`pwd`
  cd $OUTDIR/bin/dummy
  dotnet $SCRIPT_DIR/tools/bin/APITool.dll \
         dummy $OUTDIR/bin/public/ref $OUTDIR/bin/dummy
  cd $CACHE
}

cmd_pack() {
  VERSION=$1
  if [ -z "$VERSION" ]; then
    pushd $SCRIPT_DIR > /dev/null
    VERSION=$VERSION_PREFIX.$((10000+$(git rev-list --count HEAD)))
    popd > /dev/null
  fi

  restore $SCRIPT_DIR/build/pack.csproj
  nuspecs=$(find $SCRIPT_DIR/pkg/ -name "*.nuspec")
  for nuspec in $nuspecs; do
    dotnet pack --no-restore --no-build --nologo -o $OUTDIR \
           $SCRIPT_DIR/build/pack.csproj \
           /p:Version=$VERSION \
           /p:NuspecFile=$(readlink -f $nuspec)
  done
}

cmd_install() {
  DEVICE_ID=$1

  RUNTIME_ASSEMBLIES="$OUTDIR/bin/public/*.dll $OUTDIR/bin/internal/*.dll"

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
  sdb $SDB_OPTIONS push $RUNTIME_ASSEMBLIES $TARGET_ASSEMBLY_DIR

  nifile_cnt=$(sdb $SDB_OPTIONS shell find $TARGET_ASSEMBLY_DIR -name '*.ni.dll' | wc -l)
  if [ $nifile_cnt -gt 0 ]; then
    sdb $SDB_OPTIONS shell "rm -f $TARGET_ASSEMBLY_DIR/*.ni.dll"
    sdb $SDB_OPTIONS shell dotnettool --ni-system
    sdb $SDB_OPTIONS shell dotnettool --ni-regen-all-app
  fi

  sdb $SDB_OPTIONS shell chsmack -a '_' $TARGET_ASSEMBLY_DIR/*
}

cmd=$1; [ $# -gt 0 ] && shift;
case "$cmd" in
  build|--build|-b) cmd_module_build $@ ;;
  full |--full |-f) cmd_full_build $@ ;;
  design|--design)  cmd_design_build $@ ;;
  xamlbuild|--xamlbuild)  cmd_xamlbuild_build $@ ;;
  dummy|--dummy|-d) cmd_dummy_build $@ ;;
  pack |--pack |-p) cmd_pack $@ ;;
  install |--install |-i) cmd_install $@ ;;
  clean|--clean|-c) clean ;;
  *) usage ;;
esac

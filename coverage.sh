#!/bin/bash -e

SCRIPT_DIR=$(dirname $(readlink -f $0))
ROOTDIR=$SCRIPT_DIR

BUILD_CONF=Debug
SLN_NAME=_TizenFX_Cov
SLN_FILE=$ROOTDIR/$SLN_NAME.sln

COV_TOOL_PATH=$ROOTDIR/tools/coverage
COV_REPORT_PATH=$ROOTDIR/Artifacts/coverage
MINICOVER_PATH=$COV_TOOL_PATH/coverage/minicover_linux
TARGET_ASSEMBLY_PATH=/usr/share/dotnet.tizen/framework
TARGET_COV_PATH=/home/owner/share/cov


usage() {
  echo "Usage: $0 [command] [module]"
  echo "Commands:"
  echo "    instrument|--instrument|-i : Instrument assemblies to record code coverage."
  echo "    replace |--replace |-c     : Replace runtime assemblies with intrumented."
  echo "    report|--report|-r         : Generate report files."
}

check_module() {
  if [ -z "$1" ]; then
    echo "No module specified." 1>&2
    exit 1
  fi

  local PROJECT_DIR=$ROOTDIR/src/$1

  if [ ! -f $PROJECT_DIR/$1.csproj ]; then
    echo "No such found $1 module." 1>&2
    exit 1
  fi

  echo $PROJECT_DIR
}

update_coverage_tools() {
  echo "## Update Coverage Tools ##"
  if [ -d $COV_TOOL_PATH ]; then
    pushd $COV_TOOL_PATH > /dev/null
    git fetch origin
    git reset --hard origin/master
    popd > /dev/null
  else
    git clone https://github.sec.samsung.net/RS8-DotNetTctTools/CSharpCoverageTool $COV_TOOL_PATH
  fi  
}

public_modules() {
  find $ROOTDIR/src -maxdepth 1 \
      -type d ! -name "*.Design" \
      -not -path $ROOTDIR/src | sort | sed "s:$ROOTDIR/src/::"
}

build() {
  PROJECT_DIR=$(check_module $1)
  dotnet build -c $BUILD_CONF $PROJECT_DIR/$1.csproj
}

instrument() {
  PROJECT_DIR=$(check_module $1)
  dotnet $MINICOVER_PATH/dotnet-minicover.dll instrument \
      --workdir $ROOTDIR \
      --sources "/src/$1/**/*.cs" \
      --assemblies "/src/$1/bin/$BUILD_CONF/*/$1.dll" \
      --hits-file $1
}

prepare_replace() {
  sdb root on
  sdb shell mount -o remount,rw /
  sdb shell "rm -f $TARGET_ASSEMBLY_PATH/*.ni.dll"
  sdb shell "rm -fr $TARGET_COV_PATH"
  sdb shell "mkdir -p $TARGET_COV_PATH" 
  sdb push $MINICOVER_PATH/MiniCover.HitServices.dll $TARGET_ASSEMBLY_PATH
  sdb shell chsmack -a '_' $TARGET_ASSEMBLY_PATH/MiniCover.HitServices.dll
}

replace() {
  PROJECT_DIR=$(check_module $1)
  sdb push $PROJECT_DIR/bin/$BUILD_CONF/*/$1.dll $TARGET_ASSEMBLY_PATH
  sdb shell chsmack -a '_' $TARGET_ASSEMBLY_PATH/$1.dll
}

prepare_report() {
  rm -fr $COV_REPORT_PATH  
  mkdir -p $COV_REPORT_PATH
  sdb pull $TARGET_COV_PATH
}

report() {
  set +e
  PROJECT_DIR=$(check_module $1)
  dotnet $MINICOVER_PATH/dotnet-minicover.dll xmlreport \
      --threshold 85 --output $1.xml
  dotnet $COV_TOOL_PATH/coverage/ReportGenerator_4.8.0/netcoreapp2.0/ReportGenerator.dll \
      -reporttypes:lcov -reports:$1.xml -targetdir:$COV_REPORT_PATH/$1
  java -jar $COV_TOOL_PATH/coverage/jgenhtml-1.5.jar \
      $COV_REPORT_PATH/$1/lcov.info -o $COV_REPORT_PATH/$1 --no-branch-coverage

  rm -f $1.xml
  rm -f $1*.hits
}

cmd_instrument() {
  build $1
  instrument $1
}

cmd_replace() {
  prepare_replace
  replace $1
}

cmd_report() {
  prepare_report
  report $1
}

update_coverage_tools

cmd=$1; [ $# -gt 0 ] && shift;
case "$cmd" in
  instrument|--instrument|-i) cmd_instrument $@ ;;
  replace |--replace |-c) cmd_replace $@ ;;
  report|--report| -r)  cmd_report $@ ;;
  *) usage ;;
esac

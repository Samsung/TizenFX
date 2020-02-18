#!/bin/bash

SCRIPT_FILE=$(readlink -f $0)
SCRIPT_DIR=$(dirname $SCRIPT_FILE)

VERSION_FILE=$SCRIPT_DIR/version.txt
RPMSPEC=$SCRIPT_DIR/csapi-tizenfx.spec
RPMSPEC_IN=$RPMSPEC.in

source $VERSION_FILE

while getopts ":r:n:" opt; do
  case $opt in
    r) RPM_VERSION=$OPTARG ;;
    n) NUGET_VERSION=$OPTARG ;;
    :) echo "Option -$OPTARG requires an argument."; exit 1 ;;
  esac
done

RPM_VERSION=$RPM_VERSION+$RPM_VERSION_SUFFIX

# Update RPM Spec
echo "# Auto-generated from $(basename $RPMSPEC_IN) by makespec.sh" | cat - $RPMSPEC_IN > $RPMSPEC
sed -i -e "s/@api_version@/$API_VERSION/g" $RPMSPEC
sed -i -e "s/@rpm_version@/$RPM_VERSION/g" $RPMSPEC
sed -i -e "s/@nuget_version@/$NUGET_VERSION/g" $RPMSPEC

# Update RID
cd ${SCRIPT_DIR}/..
RUNTIME_JSON_FILE=$PWD/pkg/Tizen.NET/runtime.json

if [ $(dpkg-query -W -f='${Status}' jq 2>/dev/null | grep -c "ok installed") -eq 0 ];
    then
        echo ""
        echo "[!] JSON processor(jq) package should install"
        echo "[!] Starting install JSON processor(jq) ... "
        sudo apt-get install jq
fi

PARSING_DATA=$(cat $RUNTIME_JSON_FILE | jq '.runtimes | keys' | grep 'tizen\.' | grep -Ev 'armel|x86')
RID_VERSION=$(echo $PARSING_DATA | sed -e "s/\"tizen\.//g" | sed -e "s/\"\, /:/g" | sed -e "s/\"\,//g")

sed -i -e "s/@rid_version@/$RID_VERSION/g" $RPMSPEC

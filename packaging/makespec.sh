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
python $SCRIPT_DIR/makerid.py

# Update TFM
python $SCRIPT_DIR/maketfm.py

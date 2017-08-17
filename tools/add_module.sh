#!/bin/bash

SCRIPT_FILE=$(readlink -f $0)
SCRIPT_DIR=$(dirname $SCRIPT_FILE)
ROOT_DIR=$(readlink -f $SCRIPT_DIR/..)

MODULE_NAME=$1; shift

if [ -z "$MODULE_NAME" ]; then
  echo "No module name specified."
  exit 1
fi

if [ -d "$ROOT_DIR/src/$MODULE_NAME" ]; then
  echo "The module '$MODULE_NAME' already exists."
fi

mkdir -p $ROOT_DIR/src/$MODULE_NAME
cp -f $SCRIPT_DIR/module.csproj.template $ROOT_DIR/src/$MODULE_NAME/$MODULE_NAME.csproj
cd $ROOT_DIR/src/$MODULE_NAME
dotnet new sln
dotnet sln add $MODULE_NAME.csproj

echo "New module [$ROOT_DIR/src/$MODULE_NAME] has been created."
#!/bin/bash

SCRIPT_FILE=$(readlink -f $0)
SCRIPT_DIR=$(dirname $SCRIPT_FILE)

SOURCE_DIR=$SCRIPT_DIR/src
BINARY_DIR=$SCRIPT_DIR/bin

CONF=Release

# Cleanup
rm -fr $BINARY_DIR/*
find $SOURCE_DIR -type d -name "bin" -prune -exec rm -r "{}" \;
find $SOURCE_DIR -type d -name "obj" -prune -exec rm -r "{}" \;

# Build and publish
dotnet publish -c $CONF Tools.sln

# Install
APPS="GenDummy ABIChecker"

for x in $APPS; do
  mkdir -p $BINARY_DIR/$x
  cp -fr $SOURCE_DIR/$x/bin/$CONF/*/publish/* $BINARY_DIR/$x
done

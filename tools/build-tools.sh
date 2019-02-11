#!/bin/bash

SCRIPT_FILE=$(readlink -f $0)
SCRIPT_DIR=$(dirname $SCRIPT_FILE)

SOURCE_DIR=$SCRIPT_DIR/src
BINARY_DIR=$SCRIPT_DIR/bin

CONF=Release

# Cleanup
rm -fr $BINARY_DIR
find $SOURCE_DIR -type d -name "bin" -prune -exec rm -r "{}" \;
find $SOURCE_DIR -type d -name "obj" -prune -exec rm -r "{}" \;

# Build and publish
for p in $(ls -1 src/**/*.csproj); do
  fn=$(basename -- $p)
  dotnet publish -c $CONF $p -o $BINARY_DIR/${fn%.*}
done 

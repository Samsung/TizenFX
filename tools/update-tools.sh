#!/bin/bash

SCRIPT_FILE=$(readlink -f $0)
SCRIPT_DIR=$(dirname $SCRIPT_FILE)

GITDIR="$SCRIPT_DIR"/.APITool
BINDIR="$SCRIPT_DIR"/bin

rm -fr $GITDIR
git clone https://github.com/TizenAPI/APITool $GITDIR

dotnet publish $GITDIR -o $BINDIR

rm -fr $GITDIR

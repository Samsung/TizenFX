#!/bin/bash

SCRIPT_FILE=$(readlink -f $0)
export SCRIPT_DIR=$(dirname $SCRIPT_FILE)

git submodule init
git submodule update
git submodule foreach 'git archive --format=tar.gz HEAD -o $SCRIPT_DIR/externals.$name.tar.gz'

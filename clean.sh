#!/bin/bash

SCRIPT_FILE=$(readlink -f $0)
SCRIPT_DIR=$(dirname $SCRIPT_FILE)

LIST=$(find $SCRIPT_DIR -type d -and -name bin -or -name obj)

for d in $LIST; do
	rm -fr $d
done


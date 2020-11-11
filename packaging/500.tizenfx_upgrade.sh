#!/bin/bash
# RW Update Script for 4.0 -> 5.5

/usr/bin/vconftool set -f -t int db/dotnet/tizen_api_version 6
/usr/bin/vconftool set -f -t string db/dotnet/tizen_rid_version "4.0.0:5.0.0:5.5.0"

#!/bin/bash
# RW Update Script for 4.0/5.5 -> 6.0

/usr/bin/vconftool set -f -t int db/dotnet/tizen_api_version 8
/usr/bin/vconftool set -f -t string db/dotnet/tizen_rid_version "4.0.0:5.0.0:5.5.0:6.0.0"
/usr/bin/vconftool set -f -t string db/dotnet/tizen_tfm_support "tizen80:tizen70:tizen60:tizen50:tizen40:netstandard2.0"

#!/bin/bash
# RW Update Script for Tizen 6.5

PATH=/bin:/usr/bin

vconftool set -f -t int db/dotnet/tizen_api_version 9
vconftool set -f -t string db/dotnet/tizen_rid_version "4.0.0:5.0.0:5.5.0:6.0.0:6.5.0"
vconftool set -f -t string db/dotnet/tizen_tfm_support "tizen90:tizen80:tizen70:tizen60:tizen50:tizen40:netstandard2.0"

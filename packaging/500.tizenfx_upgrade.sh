#!/bin/bash
# RW Update Script for Tizen 6.5

PATH=/bin:/usr/bin

vconftool set -f -t int db/dotnet/tizen_api_version 13

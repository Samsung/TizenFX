#!/bin/bash
# RW Update Script for Tizen 6.5

PATH=/bin:/usr/bin

/usr/bin/buxton2ctl -i -d create-int32 "system"  "db/dotnet/tizen_api_version" "13" "http://tizen.org/privilege/internal/default/public" "http://tizen.org/privilege/internal/default/platform"
/usr/bin/buxton2ctl -i -d create-string "system"  "db/dotnet/tizen_rid_version" "10.0.0:9.0.0:8.0.0:7.0.0:6.5.0:6.0.0:5.5.0:5.0.0:4.0.0" "http://tizen.org/privilege/internal/default/public" "http://tizen.org/privilege/internal/default/platform"
/usr/bin/buxton2ctl -i -d create-string "system"  "db/dotnet/tizen_tfm_support" "net8.0-tizen10.0:net6.0-tizen9.0:net6.0-tizen8.0:net6.0-tizen:net6.0:tizen10.0:tizen90:tizen80:tizen70:tizen60:tizen50:tizen40" "http://tizen.org/privilege/internal/default/public" "http://tizen.org/privilege/internal/default/platform"

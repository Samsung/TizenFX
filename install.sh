sdb root on
sdb shell mount -o remount,rw /
sdb push ./Artifacts/bin/public/$1.dll /usr/share/dotnet.tizen/framework/
sdb shell chsmack -a "_" /usr/share/dotnet.tizen/framework/$1.dll

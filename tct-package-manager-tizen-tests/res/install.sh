
pkgcmd -t tpk -i -p PMTestApp.tpk -q
pkgcmd -t tpk -i -p org.test.tizen.applications.tpk -q

rm PackageInfo.txt
for line in $(pkgcmd -l  | sed -n 's/.*\[\([^]]*\)\].*\[\([^]]*\)\].*\[\([^]]*\)\].*\[\([^]]*\)\].*/\2/p'); do
	pkginfo --pkg $line >> PackageInfo.txt;
	pkgmgr_tool $line >> PackageInfo.txt 2>&1;
	echo "*** END of package info"  >> PackageInfo.txt
done

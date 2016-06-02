# install & run TC application

pkgcmd -u -n org.tizentest.pmtestappforinstallation
# uninstall PMWgtAppForInstallation

pkgcmd -i -t tpk -q -p /home/owner/PMTpkAppForUnnstallation.tpk
pkgcmd -i -t wgt -q -p /home/owner/PMWgtAppForUninstallation.wgt
pkgcmd -i -t tpk -q -p /home/owner/PMTpkAppToMoveExternal.tpk
pkgcmd -i -t tpk -q -p /home/owner/PMTpkAppToMoveInternal.tpk
pkgcmd -m -t tpk -T 1 -n org.tizentest.pmtpkapptomoveinternal

app_launcher -t org.test.tizen.applications
app_launcher -s org.test.tizen.applications

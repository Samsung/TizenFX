sdb root on
sdb push ../org.test.tizen.applications.tpk *.wgt install.sh run.sh /home/owner
ARCH="armv7l"
#ARCH=`uname -m`
#echo $ARCH
if [[ $ARCH =~ "86" ]] ; then
	echo "Using emul packages"
	sdb push emul/*.tpk /home/owner
else
	echo "Using target packages"
	sdb push arm/*.tpk /home/owner
fi

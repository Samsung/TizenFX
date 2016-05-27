# Naming conventions

1) "TC application" refers to "org.test.tizen.notification".
2) "sample applications" refers to those whose name contains string "Sample".

# purpose of those scripts

1) "push.sh" - this script is made for pushing the TC application, the sample applications and "install.sh", "run.sh" scripts to Tizen device. Run it in Ubuntu.

2) "install.sh" - this script is made for installing the sample applications in Tizen device. This script will be pushed to "/home/owner" directory of Tizen device. Manually run it.

3) "run.sh" - this script is made for launching & relaunching TC application for Application API. This script will be pushed to "/home/owner" directory of Tizen device. Manually run it.

# how to install your sample applications using those script

1) Put your sample applications in the directory of the scripts.

2) Add your sample application's name to "install.sh" script as below:
    pkgcmd -u -n <your AppId>
    pkgcmd -t tpk -i -p <your AppId>.tpk -q
    app_launcher -l | grep <your AppId>

3) Add your sample application's name to "run.sh" script as below:
    app_launcher -k <your AppId>

# the end
-- nothing here---

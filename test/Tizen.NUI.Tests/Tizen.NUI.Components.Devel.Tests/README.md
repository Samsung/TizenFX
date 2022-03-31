This (Tizen.NUI.Components.Devel.Tests) is an auto TCT project for the internal API of Tizen.NUI.Components.Tests.

You can use it like below.

1. download or do "git clone" the csharp-tct project from review.tizen.org : https://review.tizen.org/gerrit/#/admin/projects/test/tct/csharp/api

2. copy this Tizen.NUI.Components.Devel.Tests project into the below of "api/tct-suite-vs/" folder
  ex) $ cp -rf Tizen.NUI.Components.Devel.Tests ~/SomePath/api/tct-suite-vs/

3. package Tizen.NUI.Components.Devel.Tests tpk into csharp-tct. execute the following command in "api/tool/script" folder
  ex) $ sudo python pack.py auto NUI.Components.Devel

4. execute csharp-tct and you can see the Tizen.NUI.Components.Devel.Tests item shown
  ex) $ sudo tct-mgr  

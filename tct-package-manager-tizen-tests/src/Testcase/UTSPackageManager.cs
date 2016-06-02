// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFramework;
using Tizen.Applications;

namespace TizenTests.Applications
{
    [TestFixture]
    [Description("Tizen.Applications.PackageManager test class")]
    public class UTSPackageManager
    {
        internal static Dictionary<Package, PackageData> Testdata;

        static string tpkPkgForInstallation = "/home/owner/PMTpkAppForInstallation.tpk";
        static string tpkPkgIdForInstallation = "org.tizentest.pmtestappforinstallation";
        static string tpkPkgIdForUninstallation = "org.tizentest.pmtestappforuninstallation";

        static string wgtPkgForInstallation = "/home/owner/PMWgtAppForInstallation.wgt";
        static string wgtPkgIdForInstallation = "PMWgtAppForInstallation";
        static string wgtPkgIdForUninstallation = "PMWgtAppForUninstallation";

        static string pkgIdToMoveExternal = "org.tizentest.pmtpkapptomoveexternal";
        static string pkgIdToMoveInternal = "org.tizentest.pmtpkapptomoveinternal";

        static bool bWaitFlag;
        static bool bInstallComplete;
        static bool bUninstallComplete;

        static EventHandler<PackageManagerEventArgs> installProgressCallback;
        static EventHandler<PackageManagerEventArgs> uninstallProgressCallback;

        static UTSPackageManager()
        {
            Testdata = new Dictionary<Package, PackageData>();
            Dictionary<string, string> packageData = new Dictionary<string, string>();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(@"/home/owner/PackageInfo.txt"))
            {
                string pkgId = "";
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line.StartsWith("Get Pkg Info Called"))
                    {
                        pkgId = line.Split(']')[0].Split('[')[1].Trim();
                        packageData = new Dictionary<string, string>();
                        packageData["id"] = pkgId;
                    }
                    else if (line.StartsWith("*** END of package info"))
                    {
                        var pkg = PackageManager.GetPackage(pkgId);
                        if (pkg != null)
                        {
                            Testdata[pkg] = new PackageData(packageData);
                        }
                    }
                    else if (line.Contains(":"))
                    {
                        var keyValue = line.Split(':');
                        packageData[keyValue[0].Trim()] = keyValue[1].Trim();
                    }
                    else if (line.StartsWith("storage \t="))
                    {
                        packageData["storage"] = line.Split('=')[1].Trim();
                    }
                }
            }

            foreach (var pkgid in PackageManager.GetPackages().Where(p => p.Label == wgtPkgIdForUninstallation).Select(p => p.Id))
            {
                wgtPkgIdForUninstallation = pkgid;
                DEBUG("Got package ID for WGT app for uninstallation: " + wgtPkgIdForUninstallation);
                break;
            }
        }

        static void DEBUG(string msg)
        {
            LogUtils.write(LogUtils.DEBUG, LogUtils.TAG, msg);
        }

        [SetUp]
        public static void Init()
        {
        }

        [TearDown]
        public static void Destroy()
        {
        }

        [Test]
        [Category("P1")]
        [Description("Check if GetPackageIdByApplicationId returns correct value")]
        [Property("Specification", "Tizen.Applications.PackageManager.GetPackageIdByApplicationId M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void GetPackageIdByApplicationId_RETURN_VALUE()
        {
            // TEST CODE
            foreach (KeyValuePair<Package, PackageData> item in Testdata)
            {
                var package = item.Key;
                var pkgId = PackageManager.GetPackageIdByApplicationId(item.Value.MainAppId);
                Assert.True(package.Id == pkgId, string.Format("Wrong Package ID, Expected: {0}, Actual: {1}", package.Id, pkgId));
            }
        }

        [Test]
        [Category("P1")]
        [Description("Check if GetPackage returns correct value")]
        [Property("Specification", "Tizen.Applications.PackageManager.GetPackage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void GetPackage_RETURN_VALUE()
        {
            // TEST CODE
            foreach (KeyValuePair<Package, PackageData> item in Testdata)
            {
                var package = item.Key;
                var pkg = PackageManager.GetPackage(item.Value.Id);
                Assert.IsInstanceOf<Package>(pkg);
                Assert.True(package.Id == pkg.Id, string.Format("Wrong Package ID, Expected: {0}, Actual: {1}", package.Id, pkg.Id));
                Assert.True(package.Label == pkg.Label, string.Format("Wrong Package Label, Expected: {0}, Actual: {1}", package.Label, pkg.Label));
            }
        }

        [Test]
        [Category("P1")]
        [Description("Check if GetPackages returns correct value")]
        [Property("Specification", "Tizen.Applications.PackageManager.GetPackages M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void GetPackages_RETURN_VALUE()
        {
            // TEST CODE
            var pkgList = PackageManager.GetPackages();
            Assert.IsInstanceOf<IEnumerable<Package>>(pkgList);
            Assert.IsNotNull(pkgList, "Package list should not be null");
            Assert.IsNotEmpty(pkgList, "Package list should not be empty.");
        }

        [Test]
        [Category("P1")]
        [Description("Checks if GetSizeInformationAsync returns correct value")]
        [Property("Specification", "Tizen.Applications.PackageManager.GetTotalSizeInformationAsync M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static async Task GetTotalSizeInformationAsync_RETURN_VALUE()
        {
            /* TEST CODE */
            // calling PackageManager.GetTotalSizeInformationAsync() directly hangs in TCT
            var sizeInfo = await Task.Run(() => PackageManager.GetTotalSizeInformationAsync());
            Assert.IsInstanceOf<PackageSizeInformation>(sizeInfo);
            Assert.True(sizeInfo.AppSize > 0, "Wrong total size info, AppSize should be greater than 0");
        }

        [Test]
        [Category("P1")]
        [Description("Check if we get call back for tpk installation")]
        [Property("Specification", "Tizen.Applications.PackageManager.Install M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static async Task Install_ENUM_TPK()
        {
            // PRECONDITION
            // 1. tpkPkgForInstallation should be installed
            //
            try
            {
                var pkg = PackageManager.GetPackage(tpkPkgForInstallation);
                Assert.True(false, string.Format(" Package [{0}] is already installed", pkg.Id));
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            // TEST CODE
            installProgressCallback = (s, e) =>
            {
                if (e.PackageId == tpkPkgIdForInstallation && e.Progress == 100)
                {
                    bInstallComplete = true;
                    bWaitFlag = true;
                }
            };

            bWaitFlag = false;
            bInstallComplete = false;
            PackageManager.InstallProgressChanged += installProgressCallback;

            var result = PackageManager.Install(tpkPkgForInstallation);
            await WaitForEvent(10);
            PackageManager.InstallProgressChanged -= installProgressCallback;

            Assert.IsTrue(result, string.Format("Failed to install Package [{0}]", tpkPkgForInstallation));
            Assert.IsTrue(bInstallComplete, string.Format("Failed to get event callback for Package [{0}] installation", tpkPkgForInstallation));

        }

        [Test]
        [Category("P1")]
        [Description("Check if we get call back for wgt installation")]
        [Property("Specification", "Tizen.Applications.PackageManager.Install M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static async Task Install_ENUM_WGT()
        {
            // PRECONDITION
            // 1. wgtPkgForInstallation should be installed
            //
            foreach (var pkgid in PackageManager.GetPackages().Where(p => p.Label.EndsWith(wgtPkgIdForInstallation)).Select(p => p.Id))
            {
                Assert.True(false, string.Format(" Package [{0}] is already installed", pkgid));
            }

            // TEST CODE
            installProgressCallback = (s, e) =>
            {
                // how to get package id for widget app
                if (/* e.PackageId == wgtPkgIdForInstallation && */ e.Progress == 100)
                {
                    bInstallComplete = true;
                    bWaitFlag = true;
                }
            };

            bWaitFlag = false;
            bInstallComplete = false;
            PackageManager.InstallProgressChanged += installProgressCallback;

            var result = PackageManager.Install(wgtPkgForInstallation);
            await WaitForEvent(10);
            PackageManager.InstallProgressChanged -= installProgressCallback;

            Assert.IsTrue(result, string.Format("Failed to install Package [{0}]", wgtPkgForInstallation));
            Assert.IsTrue(bInstallComplete, string.Format("Failed to get event callback for Package [{0}] installation", wgtPkgForInstallation));
        }

        [Test]
        [Category("P1")]
        [Description("Check if we get call back for tpk uninstallation")]
        [Property("Specification", "Tizen.Applications.PackageManager.Uninstall M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static async Task Uninstall_ENUM_TPK()
        {
            // PRECONDITION
            // 1. tpkPkgForUninstallation should be installed and is removable
            //

            var pkg = PackageManager.GetPackage(tpkPkgIdForUninstallation);
            Assert.IsNotNull(pkg, string.Format("Package [{0}] is not installed", tpkPkgIdForUninstallation));
            Assert.IsTrue(pkg.IsRemovable == true, string.Format("Package [{0}] is not removable", tpkPkgIdForUninstallation));

            // TEST CODE
            uninstallProgressCallback = (s, e) =>
            {
                if (e.PackageId == tpkPkgIdForUninstallation && e.Progress == 100)
                {
                    bUninstallComplete = true;
                    bWaitFlag = true;
                }
            };

            bWaitFlag = false;
            bUninstallComplete = false;
            PackageManager.UninstallProgressChanged += uninstallProgressCallback;

            var result = PackageManager.Uninstall(tpkPkgIdForUninstallation, PackageType.TPK);
            await WaitForEvent(10);
            PackageManager.UninstallProgressChanged -= uninstallProgressCallback;

            Assert.IsTrue(result, string.Format("Failed to unstall Package [{0}]", tpkPkgIdForUninstallation));
            Assert.IsTrue(bUninstallComplete, string.Format("Failed to get event callback for Package [{0}] uninstallation", tpkPkgIdForUninstallation));
        }

        [Test]
        [Category("P1")]
        [Description("Check if we get call back for wgt uninstallation")]
        [Property("Specification", "Tizen.Applications.PackageManager.Uninstall M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static async Task Uninstall_ENUM_WGT()
        {
            // PRECONDITION
            // 1. wgtPkgForUninstallation should be installed and is removable
            //

            var pkg = PackageManager.GetPackage(wgtPkgIdForUninstallation);
            Assert.IsNotNull(pkg, string.Format("Package [{0}] is not installed", wgtPkgIdForUninstallation));
            Assert.IsTrue(pkg.IsRemovable == true, string.Format("Package [{0}] is not removable", wgtPkgIdForUninstallation));

            // TEST CODE
            uninstallProgressCallback = (s, e) =>
            {
                if (e.PackageId == wgtPkgIdForUninstallation && e.Progress == 100)
                {
                    bUninstallComplete = true;
                    bWaitFlag = true;
                }
            };

            bWaitFlag = false;
            bUninstallComplete = false;
            PackageManager.UninstallProgressChanged += uninstallProgressCallback;

            var result = PackageManager.Uninstall(wgtPkgIdForUninstallation, PackageType.WGT);
            await WaitForEvent(10);
            PackageManager.UninstallProgressChanged -= uninstallProgressCallback;

            Assert.IsTrue(result, string.Format("Failed to unstall Package [{0}]", wgtPkgIdForUninstallation));
            Assert.IsTrue(bUninstallComplete, string.Format("Failed to get event callback for Package [{0}] uninstallation", wgtPkgIdForUninstallation));
        }

        [Test]
        [Category("P1")]
        [Description("Check if move to internal memory is successful")]
        [Property("Specification", "Tizen.Applications.PackageManager.Move M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MAE")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void Move_ENUM_INTERNAL()
        {
            // PRECONDITION
            // 1. pkgToMoveInternal should be installed on external memory
            //

            var pkg = PackageManager.GetPackage(pkgIdToMoveInternal);
            Assert.IsNotNull(pkg, string.Format("Test Package [{0}] is not installed", pkgIdToMoveInternal));
            Assert.IsTrue(pkg.InstalledStorageType == StorageType.External, string.Format("Package [{0}] is not installed in external memory", pkgIdToMoveInternal));

            // TEST CODE
            var result = PackageManager.Move(pkgIdToMoveInternal, PackageType.TPK, StorageType.Internal);
            Assert.IsTrue(result, string.Format("Failed to move Package [{0}] to internal memory", pkgIdToMoveInternal));

            pkg = PackageManager.GetPackage(pkgIdToMoveInternal);
            Assert.IsNotNull(pkg, string.Format("Test Package [{0}] is not installed", pkgIdToMoveInternal));
            Assert.IsTrue(pkg.InstalledStorageType == StorageType.Internal, string.Format("Package [{0}] is not moved to internal memory", pkgIdToMoveInternal));
        }

        [Test]
        [Category("P1")]
        [Description("Check if move to external memory is successful")]
        [Property("Specification", "Tizen.Applications.PackageManager.Move M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MAE")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void Move_ENUM_EXTERNAL()
        {
            // PRECONDITION
            // 1. pkgToMoveExternal should be installed on internal memory
            //

            var pkg = PackageManager.GetPackage(pkgIdToMoveExternal);
            Assert.IsNotNull(pkg, string.Format("Test Package [{0}] is not installed", pkgIdToMoveExternal));
            Assert.IsTrue(pkg.InstalledStorageType == StorageType.Internal, string.Format("Package [{0}] is not installed in internal memory", pkgIdToMoveExternal));

            // TEST CODE
            var result = PackageManager.Move(pkgIdToMoveExternal, PackageType.TPK, StorageType.External);
            Assert.IsTrue(result, string.Format("Failed to move Package [{0}] to external memory", pkgIdToMoveExternal));

            pkg = PackageManager.GetPackage(pkgIdToMoveExternal);
            Assert.IsNotNull(pkg, string.Format("Test Package [{0}] is not installed", pkgIdToMoveExternal));
            Assert.IsTrue(pkg.InstalledStorageType == StorageType.External, string.Format("Package [{0}] is not moved to external memory", pkgIdToMoveExternal));
        }

        public static async Task WaitForEvent(int timeInSeconds)
        {
            int count = 0;
            while (true)
            {
                await Task.Delay(1000);
                DEBUG("Waiting for event for sec: " + count + ", flag is: " + bWaitFlag);
                if (bWaitFlag) break;
                if (++count == timeInSeconds) break;
            }
        }

        internal class PackageData
        {
            public string Id { get; set; }
            public string MainAppId { get; set; }
            public string Label { get; set; }
            public string IconPath { get; set; }
            public string Version { get; set; }
            public PackageType Type { get; set; }
            public StorageType InstalledStorageType { get; set; }
            public string RootPath { get; set; }
            //public string TizenExpansionPackageName { get; set; }
            public bool IsSystemPackage { get; set; }
            public bool IsRemovable { get; set; }
            public bool IsPreloaded { get; set; }
            //public bool IsAccessible { get; }

            public PackageData(Dictionary<string, string> packageData)
            {
                Id = packageData["id"];
                MainAppId = packageData["mainappid"];
                Label = packageData["Label"];
                IconPath = packageData["Icon"];
                Version = packageData["Version"];
                PackageType _type;
                if (Enum.TryParse(packageData["Type"], true, out _type)) Type = _type;
                InstalledStorageType = packageData["storage"] == "[0]" ? StorageType.Internal : StorageType.External;
                RootPath = packageData["root_path"];
                //TizenExpansionPackageName = "";
                IsSystemPackage = packageData["system"] == "1";
                IsRemovable = packageData["Removable"] == "1";
                IsPreloaded = packageData["Preload"] == "1";
                //IsAccessible = packageData["Readonly"] == "0";
            }
        }
    }
}

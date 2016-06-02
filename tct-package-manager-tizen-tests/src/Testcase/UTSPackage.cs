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
    [Description("Tizen.Applications.Package test class")]
    public class UTSPackage
    {
        internal static Dictionary<Package, UTSPackageManager.PackageData> Testdata;
        static Package tpkPackage = null;

        static UTSPackage()
        {
            tpkPackage = PackageManager.GetPackage(TpkPackageData.ID);
        }

        [SetUp]
        public static void Init()
        {
            Testdata = UTSPackageManager.Testdata;
        }

        [TearDown]
        public static void Destroy()
        {
        }

        [Test]
        [Category("P1")]
        [Description("Checks if ClearCacheDir clear cache data")]
        [Property("Specification", "Tizen.Applications.Package.ClearCacheDir M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static async Task ClearCacheDir_RETURN_VALUE()
        {
            // PRECONDITION
            Assert.IsNotNull(tpkPackage, "Precondition failed: testPackage should not be null");

            // TEST CODE
            tpkPackage.ClearCacheDirectory();

            var sizeInfo = await tpkPackage.GetSizeInformationAsync();
            Assert.IsInstanceOf<PackageSizeInformation>(sizeInfo);
            Assert.IsTrue(0 == sizeInfo.CacheSize, "Cache size should be 0 after ClearCacheDir()");
        }

        [Test]
        [Category("P0")]
        [Description("Checks return type of GetApplications()")]
        [Property("Specification", "Tizen.Applications.Package.GetApplications M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void GetApplications_RETURN_VALUE()
        {
            // PRECONDITION
            Assert.IsNotNull(tpkPackage, "Precondition failed: testPackage should not be null");

            // TEST CODE
            var appList = tpkPackage.GetApplications();
            Assert.IsInstanceOf<IEnumerable<ApplicationInfo>>(appList);
        }

        [Test]
        [Category("P1")]
        [Description("Checks value returns from GetApplications(AppType.All)")]
        [Property("Specification", "Tizen.Applications.Package.GetApplications M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void GetApplications()
        {
            // PRECONDITION
            Assert.IsNotNull(tpkPackage, "Precondition failed: testPackage should not be null");

            // TEST CODE
            var appList = tpkPackage.GetApplications();
            Assert.IsNotNull(appList, "Application list should not be null");
            Assert.IsNotEmpty(appList, "Application list should not be empty.");
        }

        [Test]
        [Category("P1")]
        [Description("Checks value returns from GetApplications(AppType.Ui)")]
        [Property("Specification", "Tizen.Applications.Package.GetApplications M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MAE")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void GetApplications_ENUM_UI()
        {
            // PRECONDITION
            Assert.IsNotNull(tpkPackage, "Precondition failed: testPackage should not be null");

            // TEST CODE
            var appList = tpkPackage.GetApplications(ApplicationType.Ui);
            Assert.IsNotNull(appList, "Application list should not be null");
            Assert.IsNotEmpty(appList, "The list of package app should be not empty.");
        }

        [Test]
        [Category("P1")]
        [Description("Checks value returns from GetApplications(AppType.Service)")]
        [Property("Specification", "Tizen.Applications.Package.GetApplications M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MAE")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void GetApplications_ENUM_SERVICE()
        {
            // PRECONDITION
            Assert.IsNotNull(tpkPackage, "Precondition failed: testPackage should not be null");

            // TEST CODE
            var appList = tpkPackage.GetApplications(ApplicationType.Service);
            Assert.IsNotNull(appList, "Application list should not be null");
            Assert.IsNotEmpty(appList, "The list of package app should be not empty.");
        }

        [Test]
        [Category("P1")]
        [Description("Checks if GetSizeInformationAsync returns correct value")]
        [Property("Specification", "Tizen.Applications.Package.GetSizeInformationAsync M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static async Task GetSizeInformationAsync_RETURN_VALUE()
        {
            // PRECONDITION
            Assert.IsNotNull(tpkPackage, "Precondition failed: testPackage should not be null");

            // TEST CODE
            // calling PackageManager.GetTotalSizeInformationAsync() directly hangs in TCT
            var sizeInfo = await Task.Run(() => tpkPackage.GetSizeInformationAsync());
            Assert.IsInstanceOf<PackageSizeInformation>(sizeInfo);
            Assert.IsTrue(TpkPackageData.DataSize == sizeInfo.DataSize, string.Format("Wrong DataSize, Expected: {0}, Actual: {1}", TpkPackageData.DataSize, sizeInfo.DataSize));
            Assert.IsTrue(TpkPackageData.CacheSize == sizeInfo.CacheSize, string.Format("Wrong CacheSize, Expected: {0}, Actual: {1}", TpkPackageData.CacheSize, sizeInfo.CacheSize));
            Assert.IsTrue(TpkPackageData.AppSize == sizeInfo.AppSize, string.Format("Wrong AppSize, Expected: {0}, Actual: {1}", TpkPackageData.AppSize, sizeInfo.AppSize));
            Assert.IsTrue(TpkPackageData.ExternalDataSize == sizeInfo.ExternalDataSize, string.Format("Wrong ExternalDataSize, Expected: {0}, Actual: {1}", TpkPackageData.ExternalDataSize, sizeInfo.ExternalDataSize));
            Assert.IsTrue(TpkPackageData.ExternalCacheSize == sizeInfo.ExternalCacheSize, string.Format("Wrong ExternalCacheSize, Expected: {0}, Actual: {1}", TpkPackageData.ExternalCacheSize, sizeInfo.ExternalCacheSize));
            Assert.IsTrue(TpkPackageData.ExternalAppSize == sizeInfo.ExternalAppSize, string.Format("Wrong ExternalAppSize, Expected: {0}, Actual: {1}", TpkPackageData.ExternalAppSize, sizeInfo.ExternalAppSize));
        }

        [Test]
        [Category("P1")]
        [Description("Checks if Id property return correct value")]
        [Property("Specification", "Tizen.Applications.Package.Id A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void Id_READ_ONLY()
        {
            // TEST CODE
            foreach(KeyValuePair<Package, UTSPackageManager.PackageData> item in Testdata)
            {
                var package = item.Key;
                var packageInfo = item.Value;
                Assert.IsTrue(packageInfo.Id == package.Id, string.Format("Wrong Package ID, Expected: {0}, Actual: {1}", packageInfo.Id, package.Id));
            }
        }

        [Test]
        [Category("P1")]
        [Description("Checks if Label property return correct value")]
        [Property("Specification", "Tizen.Applications.Package.Label A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void Label_READ_ONLY()
        {
            // TEST CODE
            foreach (KeyValuePair<Package, UTSPackageManager.PackageData> item in Testdata)
            {
                var package = item.Key;
                var packageInfo = item.Value;
                Assert.IsTrue(packageInfo.Label == package.Label, string.Format("Wrong Package Label, Expected: {0}, Actual: {1}", packageInfo.Label, package.Label));
            }
        }

        [Test]
        [Category("P1")]
        [Description("Checks if IconPath property return correct value")]
        [Property("Specification", "Tizen.Applications.Package.IconPath A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void IconPath_READ_ONLY()
        {
            // TEST CODE
            foreach (KeyValuePair<Package, UTSPackageManager.PackageData> item in Testdata)
            {
                var package = item.Key;
                var packageInfo = item.Value;
                Assert.IsTrue(packageInfo.IconPath == package.IconPath, string.Format("Wrong Package IconPath, Expected: {0}, Actual: {1}", packageInfo.IconPath, package.IconPath));
            }
        }

        [Test]
        [Category("P1")]
        [Description("Checks if Version property return correct value")]
        [Property("Specification", "Tizen.Applications.Package.Version A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void Version_READ_ONLY()
        {
            // TEST CODE
            foreach (KeyValuePair<Package, UTSPackageManager.PackageData> item in Testdata)
            {
                var package = item.Key;
                var packageInfo = item.Value;
                Assert.IsTrue(packageInfo.Version == package.Version, string.Format("Wrong Package Version, Expected: {0}, Actual: {1}", packageInfo.Version, package.Version));
            }
        }

        [Test]
        [Category("P1")]
        [Description("Checks if Type property return correct value for tpk pacakge")]
        [Property("Specification", "Tizen.Applications.Package.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRE")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void Type_GET_ENUM_TPK()
        {
            // TEST CODE
            foreach (KeyValuePair<Package, UTSPackageManager.PackageData> item in Testdata.Where(p => p.Value.Type == PackageType.TPK))
            {
                var package = item.Key;
                var packageInfo = item.Value;
                Assert.IsTrue(packageInfo.Type == package.PackageType, string.Format("Wrong Package Type, Expected: {0}, Actual: {1}", packageInfo.Type, package.PackageType));
            }
        }

        [Test]
        [Category("P1")]
        [Description("Checks if Type property return correct value for wgt pacakge")]
        [Property("Specification", "Tizen.Applications.Package.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRE")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void Type_GET_ENUM_WGT()
        {
            // TEST CODE
            foreach (KeyValuePair<Package, UTSPackageManager.PackageData> item in Testdata.Where(p => p.Value.Type == PackageType.WGT))
            {
                var package = item.Key;
                var packageInfo = item.Value;
                Assert.IsTrue(packageInfo.Type == package.PackageType, string.Format("Wrong Package Type, Expected: {0}, Actual: {1}", packageInfo.Type, package.PackageType));
            }
        }

        [Test]
        [Category("P1")]
        [Description("Checks if InstalledStorageType property return correct value for internal package")]
        [Property("Specification", "Tizen.Applications.Package.InstalledStorageType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRE")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void InstalledStorageType_GET_ENUM_INTERNAL()
        {
            // TEST CODE
            foreach (KeyValuePair<Package, UTSPackageManager.PackageData> item in Testdata.Where(p => p.Value.InstalledStorageType == StorageType.Internal))
            {
                var package = item.Key;
                var packageInfo = item.Value;
                Assert.IsTrue(packageInfo.InstalledStorageType == package.InstalledStorageType, string.Format("Wrong Package InstalledStorageType, Expected: {0}, Actual: {1}", packageInfo.InstalledStorageType, package.InstalledStorageType));
            }
        }

        [Test]
        [Category("P1")]
        [Description("Checks if InstalledStorageType property return correct value for external package")]
        [Property("Specification", "Tizen.Applications.Package.InstalledStorageType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRE")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void InstalledStorageType_GET_ENUM_EXTERNAL()
        {
            // TEST CODE
            foreach (KeyValuePair<Package, UTSPackageManager.PackageData> item in Testdata.Where(p => p.Value.InstalledStorageType == StorageType.External))
            {
                var package = item.Key;
                var packageInfo = item.Value;
                Assert.IsTrue(packageInfo.InstalledStorageType == package.InstalledStorageType, string.Format("Wrong Package InstalledStorageType, Expected: {0}, Actual: {1}", packageInfo.InstalledStorageType, package.InstalledStorageType));
            }
        }

        [Test]
        [Category("P1")]
        [Description("Checks if RootPath property return correct value")]
        [Property("Specification", "Tizen.Applications.Package.RootPath A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void RootPath_READ_ONLY()
        {
            // TEST CODE
            foreach (KeyValuePair<Package, UTSPackageManager.PackageData> item in Testdata)
            {
                var package = item.Key;
                var packageInfo = item.Value;
                Assert.IsTrue(packageInfo.RootPath == package.RootPath, string.Format("Wrong Package RootPath, Expected: {0}, Actual: {1}", packageInfo.RootPath, package.RootPath));
            }
        }

        [Test]
        [Category("P1")]
        [Description("Checks if TizenExpansionPackageName property return correct value")]
        [Property("Specification", "Tizen.Applications.Package.TizenExpansionPackageName A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void TizenExpansionPackageName_READ_ONLY()
        {
            // PRECONDITION
            Assert.IsNotNull(tpkPackage, "Precondition failed: testPackage should not be null");

            // TEST CODE
            var expansionPackageName = tpkPackage.TizenExpansionPackageName;
            Assert.IsTrue(TpkPackageData.ExpansionPackageName == expansionPackageName, string.Format("Wrong Package TizenExpansionPackageName, Expected: ({0}), Actual: ({1})", TpkPackageData.ExpansionPackageName, expansionPackageName));
        }

        [Test]
        [Category("P1")]
        [Description("Checks if IsSystemPackage property return correct value")]
        [Property("Specification", "Tizen.Applications.Package.IsSystemPackage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void IsSystemPackage_READ_ONLY()
        {
            // TEST CODE
            foreach (KeyValuePair<Package, UTSPackageManager.PackageData> item in Testdata)
            {
                var package = item.Key;
                var packageInfo = item.Value;
                Assert.IsTrue(packageInfo.IsSystemPackage == package.IsSystemPackage, string.Format("Wrong Package IsSystemPackage, Expected: {0}, Actual: {1}", packageInfo.IsSystemPackage, package.IsSystemPackage));
            }
        }

        [Test]
        [Category("P1")]
        [Description("Checks if IsRemovable property return correct value")]
        [Property("Specification", "Tizen.Applications.Package.IsRemovable A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void IsRemovable_READ_ONLY()
        {
            // TEST CODE
            foreach (KeyValuePair<Package, UTSPackageManager.PackageData> item in Testdata)
            {
                var package = item.Key;
                var packageInfo = item.Value;
                Assert.IsTrue(packageInfo.IsRemovable == package.IsRemovable, string.Format("Wrong Package IsRemovable, Expected: {0}, Actual: {1}", packageInfo.IsRemovable, package.IsRemovable));
            }
        }

        [Test]
        [Category("P1")]
        [Description("Checks if IsPreloaded property return correct value")]
        [Property("Specification", "Tizen.Applications.Package.IsPreloaded A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void IsPreloaded_READ_ONLY()
        {
            // TEST CODE
            foreach (KeyValuePair<Package, UTSPackageManager.PackageData> item in Testdata)
            {
                var package = item.Key;
                var packageInfo = item.Value;
                Assert.IsTrue(packageInfo.IsPreloaded == package.IsPreloaded, string.Format("Wrong Package IsRemovable, Expected: {0}, Actual: {1}", packageInfo.IsPreloaded, package.IsPreloaded));
            }
        }

        [Test]
        [Category("P1")]
        [Description("Checks if IsAccessible property return correct value")]
        [Property("Specification", "Tizen.Applications.Package.IsAccessible A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void IsAccessible_READ_ONLY()
        {
            // PRECONDITION
            Assert.IsNotNull(tpkPackage, "Precondition failed: testPackage should not be null");

            // TEST CODE
            var isAccessible = tpkPackage.IsAccessible;
            Assert.IsTrue(TpkPackageData.IsAccessible == isAccessible, string.Format("Wrong Package IsAccessible, Expected: {0}, Actual: {1}", TpkPackageData.IsAccessible, isAccessible));
        }

        [Test]
        [Category("P1")]
        [Description("Checks if Certificates property return correct value")]
        [Property("Specification", "Tizen.Applications.Package.Certificates A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void Certificates_READ_ONLY()
        {
            // PRECONDITION
            Assert.IsNotNull(tpkPackage, "Precondition failed: testPackage should not be null");

            // TEST CODE
            var certificates = tpkPackage.Certificates;
            Assert.IsNotNull(certificates, "Certificate list should not be null");
            Assert.IsNotEmpty(certificates, "Certificate should be not empty.");
        }

        [Test]
        [Category("P1")]
        [Description("Checks if Privileges property return correct value")]
        [Property("Specification", "Tizen.Applications.Package.Privileges A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Dinesh Dwivedi, dinesh.d@samsung.com")]
        public static void Privileges_READ_ONLY()
        {
            // PRECONDITION
            Assert.IsNotNull(tpkPackage, "Precondition failed: testPackage should not be null");

            // TEST CODE
            var privileges = tpkPackage.Privileges;
            Assert.IsNotNull(privileges, "Certificate list should not be null");
            Assert.IsNotEmpty(privileges, "Certificate should be not empty.");
            foreach (var privilege in privileges)
            {
                Assert.IsTrue(TpkPackageData.privileges.Contains(privilege), "Wrong privilege in Privilege List");
            }
        }

        internal static class TpkPackageData
        {
            internal static string AppID = "org.test.PMTestApp";
            internal static string ID = "org.test.PMTestApp";
            internal static string Label = "PMTestApp";
            internal static string IconPath = "/home/owner/apps_rw/org.test.PMTestApp/shared/res/pmuiapp.png";
            internal static string Version = "1.0.0";
            internal static PackageType Type = PackageType.TPK;
            internal static StorageType StorageType = StorageType.Internal;
            internal static string RootPath = "/home/owner/apps_rw/org.test.PMTestApp";
            internal static string ExpansionPackageName = "";
            internal static bool IsAccessible = true;

            internal static List<string> privileges = new List<string>
            {
                "http://tizen.org/privilege/internal/default/public",
            };

            internal static long DataSize = 0;
            internal static long CacheSize = 0;
            internal static long AppSize = 192512;
            internal static long ExternalDataSize = 0;
            internal static long ExternalCacheSize = 0;
            internal static long ExternalAppSize = 0;
        }
    }
}

using NUnit.Framework;
using System;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/ViewExtensions")]
    internal class PublicViewExtensionsTest
    {
        private const string tag = "NUITEST";

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Extensions LoadFromXaml")]
        [Property("SPEC", "Tizen.NUI.Extensions.LoadFromXaml M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "string,Type")]
        public void ExtensionsLoadFromXaml1()
        {
            tlog.Debug(tag, $"ExtensionsLoadFromXaml START");
            try
            {
                Tizen.NUI.Xaml.Extensions.LoadFromXaml<string>("mystring", typeof(string));
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ExtensionsLoadFromXaml END (OK)");
            Assert.Pass("ExtensionsLoadFromXaml");
        }

        [Test]
        [Category("P1")]
        [Description("Extensions LoadFromXaml")]
        [Property("SPEC", "Tizen.NUI.Extensions.LoadFromXaml M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "string,string")]
        public void ExtensionsLoadFromXaml2()
        {
            tlog.Debug(tag, $"ExtensionsLoadFromXaml START");
            try
            {
                Tizen.NUI.Xaml.Extensions.LoadFromXaml<string>("mystring", "/home/owner/apps_rw/Tizen.NUI.Devel.Tests/tizen-manifest.xml");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ExtensionsLoadFromXaml END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Extensions LoadObject")]
        [Property("SPEC", "Tizen.NUI.Extensions.LoadObject M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ExtensionsLoadObject()
        {
            tlog.Debug(tag, $"ExtensionsLoadObject START");
            try
            {
                Tizen.NUI.Xaml.Extensions.LoadObject<string>("mypath");

            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ExtensionsLoadObject END (OK)");
            Assert.Pass("ExtensionsLoadObject");
        }

        [Test]
        [Category("P1")]
        [Description("Extensions LoadFromXamlFile")]
        [Property("SPEC", "Tizen.NUI.Extensions.LoadFromXamlFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ExtensionsLoadFromXamlFile()
        {
            tlog.Debug(tag, $"ExtensionsLoadFromXamlFile START");
            try
            {
                Tizen.NUI.Xaml.Extensions.LoadFromXamlFile<string>("myview", "/home/owner/apps_rw/Tizen.NUI.Devel.Tests/tizen-manifest.xml");

            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ExtensionsLoadFromXamlFile END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }
    }
}
using NUnit.Framework;
using System;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/ViewExtensions")]
    public class PublicViewExtensionsTest
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
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ExtensionsLoadFromXaml END");
        }
    }
}
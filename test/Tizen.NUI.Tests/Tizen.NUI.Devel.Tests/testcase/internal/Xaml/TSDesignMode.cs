using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/DesignMode")]
    internal class PublicDesignModeTest
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
        [Description("DesignMode IsDesignModeEnabled")]
        [Property("SPEC", "Tizen.NUI.DesignMode.IsDesignModeEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void DesignModeIsDesignModeEnabled()
        {
            tlog.Debug(tag, $"DesignModeIsDesignModeEnabled START");

            try
            {
                bool b1 = DesignMode.IsDesignModeEnabled;
                DesignMode.IsDesignModeEnabled = b1;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"DesignModeIsDesignModeEnabled END (OK)");
            Assert.Pass("DesignModeIsDesignModeEnabled");
        }
    }
}
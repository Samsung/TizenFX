using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/DesignMode")]
    public class InternalDesignModeTest
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
                var mode = DesignMode.IsDesignModeEnabled;
                DesignMode.IsDesignModeEnabled = mode;
                Assert.AreEqual(mode, DesignMode.IsDesignModeEnabled, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"DesignModeIsDesignModeEnabled END");
        }
    }
}
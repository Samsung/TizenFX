using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/DebugFileLogging")]
    public class TSDebugFileLogging
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
        [Description("DebugFileLogging constructor.")]
        [Property("SPEC", "Tizen.NUI.DebugFileLogging.DebugFileLogging C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DebugFileLoggingConstructor()
        {
            tlog.Debug(tag, $"DebugFileLoggingConstructor START");

            var testingTarget = DebugFileLogging.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object DebugFileLogging.");
            Assert.IsInstanceOf<DebugFileLogging>(testingTarget, "Should return DebugFileLogging instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"DebugFileLoggingConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DebugFileLogging WriteLog.")]
        [Property("SPEC", "Tizen.NUI.DebugFileLogging.WriteLog M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DebugFileLoggingWriteLog()
        {
            tlog.Debug(tag, $"DebugFileLoggingWriteLog START");

            var testingTarget = DebugFileLogging.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object DebugFileLogging.");
            Assert.IsInstanceOf<DebugFileLogging>(testingTarget, "Should return DebugFileLogging instance.");

            try
            {
                testingTarget.WriteLog("Chinese speaking!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"DebugFileLoggingWriteLog END (OK)");
        }
    }
}
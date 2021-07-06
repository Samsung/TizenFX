using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/LowBatterySignalType")]
    public class InternalLowBatterySignalTypeTest
    {
        private const string tag = "NUITEST";

		private delegate bool dummyCallback(IntPtr signal);
        private bool OnDummyCallback(IntPtr data)
        {
            return false;
        }

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
        [Description("LowBatterySignalType constructor.")]
        [Property("SPEC", "Tizen.NUI.LowBatterySignalType.LowBatterySignalType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LowBatterySignalTypeConstructor()
        {
            tlog.Debug(tag, $"LowBatterySignalTypeConstructor START");

            using (View view = new View())
            {
                var testingTarget = new LowBatterySignalType(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<LowBatterySignalType>(testingTarget, "Should be an Instance of LowBatterySignalType!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"LowBatterySignalTypeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LowBatterySignalType Empty.")]
        [Property("SPEC", "Tizen.NUI.LowBatterySignalType.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LowBatterySignalTypeEmpty()
        {
            tlog.Debug(tag, $"LowBatterySignalTypeEmpty START");

            var testingTarget = new LowBatterySignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<LowBatterySignalType>(testingTarget, "Should be an Instance of LowBatterySignalType!");

            try
            {
                testingTarget.Empty();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"LowBatterySignalTypeEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LowBatterySignalType GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.LowBatterySignalType.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LowBatterySignalTypeGetConnectionCount()
        {
            tlog.Debug(tag, $"LowBatterySignalTypeGetConnectionCount START");

            var testingTarget = new LowBatterySignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<LowBatterySignalType>(testingTarget, "Should be an Instance of LowBatterySignalType!");

            try
            {
                testingTarget.GetConnectionCount();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"LowBatterySignalTypeGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LowBatterySignalType Connect.")]
        [Property("SPEC", "Tizen.NUI.LowBatterySignalType.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LowBatterySignalTypeConnect()
        {
            tlog.Debug(tag, $"LowBatterySignalTypeConnect START");

            var testingTarget = new LowBatterySignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<LowBatterySignalType>(testingTarget, "Should be an Instance of LowBatterySignalType!");

            try
            {
                dummyCallback callback = OnDummyCallback;
                testingTarget.Connect(callback);
                testingTarget.Disconnect(callback);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"LowBatterySignalTypeConnect END (OK)");
        }
    }
}

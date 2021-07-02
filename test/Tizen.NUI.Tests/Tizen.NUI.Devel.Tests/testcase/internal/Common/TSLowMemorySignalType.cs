using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/LowMemorySignalType")]
    public class InternalLowMemorySignalTypeTest
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
        [Description("LowMemorySignalType constructor.")]
        [Property("SPEC", "Tizen.NUI.LowMemorySignalType.LowMemorySignalType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LowMemorySignalTypeConstructor()
        {
            tlog.Debug(tag, $"LowMemorySignalTypeConstructor START");

            using (View view = new View())
            {
                var testingTarget = new LowMemorySignalType(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<LowMemorySignalType>(testingTarget, "Should be an Instance of LowMemorySignalType!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"LowMemorySignalTypeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LowMemorySignalType Empty.")]
        [Property("SPEC", "Tizen.NUI.LowMemorySignalType.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LowMemorySignalTypeEmpty()
        {
            tlog.Debug(tag, $"LowMemorySignalTypeEmpty START");

            var testingTarget = new LowMemorySignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<LowMemorySignalType>(testingTarget, "Should be an Instance of LowMemorySignalType!");

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

            tlog.Debug(tag, $"LowMemorySignalTypeEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LowMemorySignalType GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.LowMemorySignalType.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LowMemorySignalTypeGetConnectionCount()
        {
            tlog.Debug(tag, $"LowMemorySignalTypeGetConnectionCount START");

            var testingTarget = new LowMemorySignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<LowMemorySignalType>(testingTarget, "Should be an Instance of LowMemorySignalType!");

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

            tlog.Debug(tag, $"LowMemorySignalTypeGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LowMemorySignalType Connect.")]
        [Property("SPEC", "Tizen.NUI.LowMemorySignalType.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LowMemorySignalTypeConnect()
        {
            tlog.Debug(tag, $"LowMemorySignalTypeConnect START");

            var testingTarget = new LowMemorySignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<LowMemorySignalType>(testingTarget, "Should be an Instance of LowMemorySignalType!");

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

            tlog.Debug(tag, $"LowMemorySignalTypeConnect END (OK)");
        }
    }
}

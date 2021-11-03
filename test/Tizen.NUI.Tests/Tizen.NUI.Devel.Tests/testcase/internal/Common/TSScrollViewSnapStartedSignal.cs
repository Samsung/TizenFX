using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ScrollViewSnapStartedSignal")]
    public class InternalScrollViewSnapStartedSignalTest
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
        [Description("ScrollViewSnapStartedSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewSnapStartedSignal.ScrollViewSnapStartedSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSnapStartedSignalConstructor()
        {
            tlog.Debug(tag, $"ScrollViewSnapStartedSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ScrollViewSnapStartedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ScrollViewSnapStartedSignal>(testingTarget, "Should be an ScrollViewSnapStartedSignal of WheelSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ScrollViewSnapStartedSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollViewSnapStartedSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewSnapStartedSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSnapStartedSignalEmpty()
        {
            tlog.Debug(tag, $"ScrollViewSnapStartedSignalEmpty START");

            var testingTarget = new ScrollViewSnapStartedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ScrollViewSnapStartedSignal>(testingTarget, "Should be an Instance of ScrollViewSnapStartedSignal!");

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

            tlog.Debug(tag, $"ScrollViewSnapStartedSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollViewSnapStartedSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewSnapStartedSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSnapStartedSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"ScrollViewSnapStartedSignalGetConnectionCount START");

            var testingTarget = new ScrollViewSnapStartedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ScrollViewSnapStartedSignal>(testingTarget, "Should be an Instance of ScrollViewSnapStartedSignal!");

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

            tlog.Debug(tag, $"ScrollViewSnapStartedSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollViewSnapStartedSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewSnapStartedSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSnapStartedSignalConnect()
        {
            tlog.Debug(tag, $"ScrollViewSnapStartedSignalConnect START");

            var testingTarget = new ScrollViewSnapStartedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ScrollViewSnapStartedSignal>(testingTarget, "Should be an Instance of ScrollViewSnapStartedSignal!");

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

            tlog.Debug(tag, $"ScrollViewSnapStartedSignalConnect END (OK)");
        }
    }
}

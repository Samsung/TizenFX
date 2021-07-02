using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/VisualEventSignal")]
    public class InternalVisualEventSignalTest
    {
        private const string tag = "NUITEST";

        private delegate bool dummyCallback(IntPtr visualEventSignal);
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
        [Description("VisualEventSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.VisualEventSignal.VisualEventSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualEventSignalConstructor()
        {
            tlog.Debug(tag, $"VisualEventSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new VisualEventSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<VisualEventSignal>(testingTarget, "Should be an Instance of VisualEventSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VisualEventSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualEventSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.VisualEventSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualEventSignalEmpty()
        {
            tlog.Debug(tag, $"VisualEventSignalEmpty START");

            using (View view = new View())
            {
                var testingTarget = new VisualEventSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<VisualEventSignal>(testingTarget, "Should be an Instance of VisualEventSignal!");

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
            }

            tlog.Debug(tag, $"VisualEventSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualEventSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.VisualEventSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualEventSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"VisualEventSignalGetConnectionCount START");

            using (View view = new View())
            {
                var testingTarget = new VisualEventSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<VisualEventSignal>(testingTarget, "Should be an Instance of VisualEventSignal!");

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
            }

            tlog.Debug(tag, $"VisualEventSignalGetConnectionCount END (OK)");
        }
    }
}

using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ViewVisibilityChangedSignal")]
    public class InternalViewVisibilityChangedSignalTest
    {
        private const string tag = "NUITEST";

        private delegate bool dummyCallback(IntPtr viewVisibilityChangedSignal);
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
        [Description("ViewVisibilityChangedSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.ViewVisibilityChangedSignal.ViewSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewVisibilityChangedSignalConstructor()
        {
            tlog.Debug(tag, $"ViewVisibilityChangedSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ViewVisibilityChangedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ViewVisibilityChangedSignal>(testingTarget, "Should be an Instance of ViewVisibilityChangedSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ViewVisibilityChangedSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewVisibilityChangedSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.ViewVisibilityChangedSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewVisibilityChangedSignalEmpty()
        {
            tlog.Debug(tag, $"ViewVisibilityChangedSignalEmpty START");

            var testingTarget = new ViewVisibilityChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ViewVisibilityChangedSignal>(testingTarget, "Should be an Instance of ViewVisibilityChangedSignal!");

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

            tlog.Debug(tag, $"ViewVisibilityChangedSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewVisibilityChangedSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.ViewVisibilityChangedSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewVisibilityChangedSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"ViewVisibilityChangedSignalGetConnectionCount START");

            var testingTarget = new ViewVisibilityChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ViewVisibilityChangedSignal>(testingTarget, "Should be an Instance of ViewVisibilityChangedSignal!");

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

            tlog.Debug(tag, $"ViewVisibilityChangedSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewVisibilityChangedSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.ViewVisibilityChangedSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewVisibilityChangedSignalConnect()
        {
            tlog.Debug(tag, $"ViewVisibilityChangedSignalConnect START");

            var testingTarget = new ViewVisibilityChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ViewVisibilityChangedSignal>(testingTarget, "Should be an Instance of ViewVisibilityChangedSignal!");

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

            tlog.Debug(tag, $"ViewVisibilityChangedSignalConnect END (OK)");
        }
    }
}

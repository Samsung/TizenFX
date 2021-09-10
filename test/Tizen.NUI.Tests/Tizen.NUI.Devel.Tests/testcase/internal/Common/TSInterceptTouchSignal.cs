using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/InterceptTouchSignal")]
    public class InternalInterceptTouchSignalTest
    {
        private const string tag = "NUITEST";

		private delegate bool dummyCallback(IntPtr signal);
        private bool OnDummyCallback(IntPtr data)
        {
            return false;
        }

        private bool OnInterceptTouchEvent(object source, View.TouchEventArgs e)
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
        [Description("InterceptTouchSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.InterceptTouchSignal.InterceptTouchSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InterceptTouchSignalConstructor()
        {
            tlog.Debug(tag, $"InterceptTouchSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new InterceptTouchSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<InterceptTouchSignal>(testingTarget, "Should be an Instance of InterceptTouchSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"InterceptTouchSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("InterceptTouchSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.InterceptTouchSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InterceptTouchSignalEmpty()
        {
            tlog.Debug(tag, $"InterceptTouchSignalEmpty START");

            using (View view = new View())
            {
                var testingTarget = new InterceptTouchSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<InterceptTouchSignal>(testingTarget, "Should be an Instance of InterceptTouchSignal!");

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

            tlog.Debug(tag, $"InterceptTouchSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("InterceptTouchSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.InterceptTouchSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InterceptTouchSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"InterceptTouchSignalGetConnectionCount START");

            using (View view = new View())
            {
                var testingTarget = new InterceptTouchSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<InterceptTouchSignal>(testingTarget, "Should be an Instance of InterceptTouchSignal!");

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

            tlog.Debug(tag, $"InterceptTouchSignalGetConnectionCount END (OK)");
        }
    }
}

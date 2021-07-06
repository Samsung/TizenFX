using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ViewLayoutDirectionChangedSignal")]
    public class InternalViewLayoutDirectionChangedSignalTest
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
        [Description("ViewLayoutDirectionChangedSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.ViewLayoutDirectionChangedSignal.ViewLayoutDirectionChangedSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewLayoutDirectionChangedSignalConstructor()
        {
            tlog.Debug(tag, $"ViewLayoutDirectionChangedSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ViewLayoutDirectionChangedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ViewLayoutDirectionChangedSignal>(testingTarget, "Should be an Instance of ViewLayoutDirectionChangedSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ViewLayoutDirectionChangedSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewLayoutDirectionChangedSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.ViewLayoutDirectionChangedSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewLayoutDirectionChangedSignalEmpty()
        {
            tlog.Debug(tag, $"ViewLayoutDirectionChangedSignalEmpty START");

            var testingTarget = new ViewLayoutDirectionChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ViewLayoutDirectionChangedSignal>(testingTarget, "Should be an Instance of ViewLayoutDirectionChangedSignal!");

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

            tlog.Debug(tag, $"ViewLayoutDirectionChangedSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewLayoutDirectionChangedSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.ViewLayoutDirectionChangedSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewLayoutDirectionChangedSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"ViewLayoutDirectionChangedSignalGetConnectionCount START");

            var testingTarget = new ViewLayoutDirectionChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ViewLayoutDirectionChangedSignal>(testingTarget, "Should be an Instance of ViewLayoutDirectionChangedSignal!");

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

            tlog.Debug(tag, $"ViewLayoutDirectionChangedSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewLayoutDirectionChangedSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.ViewLayoutDirectionChangedSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewLayoutDirectionChangedSignalConnect()
        {
            tlog.Debug(tag, $"ViewLayoutDirectionChangedSignalConnect START");

            var testingTarget = new ViewLayoutDirectionChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ViewLayoutDirectionChangedSignal>(testingTarget, "Should be an Instance of ViewLayoutDirectionChangedSignal!");

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

            tlog.Debug(tag, $"ViewLayoutDirectionChangedSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewLayoutDirectionChangedSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.ViewLayoutDirectionChangedSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ViewLayoutDirectionChangedSignalEmit()
        {
            tlog.Debug(tag, $"ViewLayoutDirectionChangedSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new ViewLayoutDirectionChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ViewLayoutDirectionChangedSignal>(testingTarget, "Should be an Instance of ViewLayoutDirectionChangedSignal!");

            try
            {
                using (View view = new View())
                {
                    testingTarget.Emit(view);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"ViewLayoutDirectionChangedSignalEmit END (OK)");
        }
    }
}

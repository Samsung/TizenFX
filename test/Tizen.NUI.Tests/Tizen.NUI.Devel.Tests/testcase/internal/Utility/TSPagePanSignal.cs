using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/PagePanSignal")]
    public class InternalPagePanSignalTest
    {
        private const string tag = "NUITEST";

        private delegate bool dummyCallback(IntPtr pagePanSignal);
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
        [Description("PagePanSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.PagePanSignal.PagePanSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PagePanSignalConstructor()
        {
            tlog.Debug(tag, $"PagePanSignalConstructor START");

            using (View view = new View())
            {
                view.Size = new Size(20, 40);
                view.BackgroundColor = Color.Cyan;

                var testingTarget = new PagePanSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PagePanSignal>(testingTarget, "Should be an Instance of PagePanSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PagePanSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PagePanSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.PagePanSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PagePanSignaEmpty()
        {
            tlog.Debug(tag, $"PagePanSignaEmpty START");

            using (View view = new View())
            {
                view.Size = new Size(20, 40);
                view.BackgroundColor = Color.Cyan;

                var testingTarget = new PagePanSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PagePanSignal>(testingTarget, "Should be an Instance of PagePanSignal!");

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

            tlog.Debug(tag, $"PagePanSignaEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PagePanSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.PagePanSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PagePanSignaGetConnectionCount()
        {
            tlog.Debug(tag, $"PagePanSignaGetConnectionCount START");

            using (View view = new View())
            {
                view.Size = new Size(20, 40);
                view.BackgroundColor = Color.Cyan;

                var testingTarget = new PagePanSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PagePanSignal>(testingTarget, "Should be an Instance of PagePanSignal!");

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

            tlog.Debug(tag, $"PagePanSignaGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PagePanSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.PagePanSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PagePanSignaConnect()
        {
            tlog.Debug(tag, $"PagePanSignaConnect START");

            var testingTarget = new PagePanSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PagePanSignal>(testingTarget, "Should be an Instance of PagePanSignal!");

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

            tlog.Debug(tag, $"PagePanSignaConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PagePanSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.PagePanSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PagePanSignalEmit()
        {
            tlog.Debug(tag, $"PagePanSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (View view = new View())
            {
                var testingTarget = new PagePanSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PagePanSignal>(testingTarget, "Should be an Instance of PagePanSignal!");

                try
                {
                    testingTarget.Emit(new PageTurnView(view.SwigCPtr.Handle, false));
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PagePanSignalEmit END (OK)");
        }
    }
}

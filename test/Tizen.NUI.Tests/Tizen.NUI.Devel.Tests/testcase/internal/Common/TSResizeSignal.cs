using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ResizeSignal")]
    public class InternalResizeSignalTest
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
        [Description("ResizeSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.ResizeSignal.ResizeSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ResizeSignalConstructor()
        {
            tlog.Debug(tag, $"ResizeSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ResizeSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ResizeSignal>(testingTarget, "Should be an Instance of ResizeSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ResizeSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ResizeSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.ResizeSignalConstructor.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ResizeSignalEmpty()
        {
            tlog.Debug(tag, $"ResizeSignalEmpty START");

            var testingTarget = new ResizeSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ResizeSignal>(testingTarget, "Should be an Instance of ResizeSignal!");

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

            tlog.Debug(tag, $"ResizeSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ResizeSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.ResizeSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ResizeSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"ResizeSignalGetConnectionCount START");

            var testingTarget = new ResizeSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ResizeSignal>(testingTarget, "Should be an Instance of ResizeSignal!");

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

            tlog.Debug(tag, $"ResizeSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ResizeSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.ResizeSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ResizeSignalConnect()
        {
            tlog.Debug(tag, $"ResizeSignalConnect START");

            var testingTarget = new ResizeSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ResizeSignal>(testingTarget, "Should be an Instance of ResizeSignal!");

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

            tlog.Debug(tag, $"ResizeSignalConnect END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("ResizeSignal Emit.")]
        //[Property("SPEC", "Tizen.NUI.ResizeSignal.Emit M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void ResizeSignalEmit()
        //{
        //    tlog.Debug(tag, $"ResizeSignalEmit START");
        //    var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
        //    var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

        //    tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

        //    using (View view = new View())
        //    {
        //        view.Size2D = new Size2D(50, 60);
        //        var testingTarget = new ResizeSignal(view.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "Should be not null!");
        //        Assert.IsInstanceOf<ResizeSignal>(testingTarget, "Should be an Instance of ResizeSignal!");

        //        try
        //        {
        //            using (Size2D size = new Size2D(20, 30))
        //            {
        //                testingTarget.Emit(size);
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"ResizeSignalEmit END (OK)");
        //}
    }
}

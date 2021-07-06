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

        //[Test]
        //[Category("P1")]
        //[Description("InterceptTouchSignal Empty.")]
        //[Property("SPEC", "Tizen.NUI.InterceptTouchSignal.Empty M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void InterceptTouchSignalEmpty()
        //{
        //    tlog.Debug(tag, $"InterceptTouchSignalEmpty START");

        //    var testingTarget = new InterceptTouchSignal();
        //    Assert.IsNotNull(testingTarget, "Should be not null!");
        //    Assert.IsInstanceOf<InterceptTouchSignal>(testingTarget, "Should be an Instance of InterceptTouchSignal!");

        //    try
        //    {
        //        testingTarget.Empty();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    testingTarget.Dispose();

        //    tlog.Debug(tag, $"InterceptTouchSignalEmpty END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("InterceptTouchSignal GetConnectionCount.")]
        //[Property("SPEC", "Tizen.NUI.InterceptTouchSignal.GetConnectionCount M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void InterceptTouchSignalGetConnectionCount()
        //{
        //    tlog.Debug(tag, $"InterceptTouchSignalGetConnectionCount START");

        //    var testingTarget = new InterceptTouchSignal();
        //    Assert.IsNotNull(testingTarget, "Should be not null!");
        //    Assert.IsInstanceOf<InterceptTouchSignal>(testingTarget, "Should be an Instance of InterceptTouchSignal!");

        //    try
        //    {
        //        testingTarget.GetConnectionCount();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    testingTarget.Dispose();

        //    tlog.Debug(tag, $"InterceptTouchSignalGetConnectionCount END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("InterceptTouchSignal Connect.")]
        //[Property("SPEC", "Tizen.NUI.InterceptTouchSignal.Connect M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void InterceptTouchSignalConnect()
        //{
        //    tlog.Debug(tag, $"InterceptTouchSignalConnect START");

        //    var testingTarget = new InterceptTouchSignal();
        //    Assert.IsNotNull(testingTarget, "Should be not null!");
        //    Assert.IsInstanceOf<InterceptTouchSignal>(testingTarget, "Should be an Instance of InterceptTouchSignal!");

        //    try
        //    {
        //        dummyCallback callback = OnDummyCallback;
        //        testingTarget.Connect(callback);
        //        testingTarget.Disconnect(callback);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    testingTarget.Dispose();

        //    tlog.Debug(tag, $"InterceptTouchSignalConnect END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("InterceptTouchSignal Emit.")]
        //[Property("SPEC", "Tizen.NUI.InterceptTouchSignal.Emit M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //[Obsolete]
        //public void InterceptTouchSignalEmit()
        //{
        //    tlog.Debug(tag, $"InterceptTouchSignalEmit START");
        //    var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
        //    var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

        //    tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

        //    var testingTarget = new InterceptTouchSignal();
        //    Assert.IsNotNull(testingTarget, "Should be not null!");
        //    Assert.IsInstanceOf<InterceptTouchSignal>(testingTarget, "Should be an Instance of InterceptTouchSignal!");

        //    try
        //    {
        //        using (Touch touch = new Touch())
        //        {
        //            testingTarget.Emit(touch);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    testingTarget.Dispose();

        //    tlog.Debug(tag, $"InterceptTouchSignalEmit END (OK)");
        //}
    }
}

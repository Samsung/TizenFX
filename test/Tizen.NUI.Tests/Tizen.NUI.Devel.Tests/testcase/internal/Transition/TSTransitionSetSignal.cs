using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Transition/TransitionSetSignal")]
    public class InternalTransitionSetSignalTest
    {
        private const string tag = "NUITEST";
        private global::System.IntPtr OnIntPtrCallback;
        private delegate bool dummyCallback(IntPtr transitionSet);
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
        [Description("TransitionSetSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.TransitionSetSignal.TransitionSetSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetSignalConstructor()
        {
            tlog.Debug(tag, $"TransitionSetSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new TransitionSetFinishedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TransitionSetFinishedSignal>(testingTarget, "Should be an Instance of TransitionSetFinishedSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TransitionSetSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionSetSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.TransitionSetSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetSignalEmpty()
        {
            tlog.Debug(tag, $"TransitionSetSignalEmpty START");

            using (View view = new View())
            {
                var testingTarget = new TransitionSetFinishedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TransitionSetFinishedSignal>(testingTarget, "Should be an Instance of TransitionSetFinishedSignal!");

                try
                {
                    tlog.Debug(tag, "Empty : " + testingTarget.Empty());
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TransitionSetSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionSetSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.TransitionSetSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"TransitionSetSignalGetConnectionCount START");

            using (View view = new View())
            {
                var testingTarget = new TransitionSetFinishedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TransitionSetFinishedSignal>(testingTarget, "Should be an Instance of TransitionSetFinishedSignal!");

                try
                {
                    tlog.Debug(tag, "ConnectionCount : " + testingTarget.GetConnectionCount());
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TransitionSetSignalGetConnectionCount END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("TransitionSetSignal Connect.")]
        //[Property("SPEC", "Tizen.NUI.TransitionSetSignal.Connect M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void TransitionSetSignalConnect()
        //{
        //    tlog.Debug(tag, $"TransitionSetSignalConnect START");

        //    using (View view = new View())
        //    {
        //        var testingTarget = new TransitionSetFinishedSignal(view.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "Should be not null!");
        //        Assert.IsInstanceOf<TransitionSetFinishedSignal>(testingTarget, "Should be an Instance of TransitionSetFinishedSignal!");

        //        try
        //        {
        //            dummyCallback callback = OnDummyCallback;
        //            testingTarget.Connect(callback);
        //            testingTarget.Disconnect(callback);
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"TransitionSetSignalConnect END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("TransitionSetSignal Connect. With IntPtr")]
        //[Property("SPEC", "Tizen.NUI.TransitionSetSignal.Connect M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void TransitionSetSignalConnectWithIntPtr()
        //{
        //    tlog.Debug(tag, $"TransitionSetSignalConnectWithIntPtr START");

        //    using (View view = new View())
        //    {
        //        var testingTarget = new TransitionSetFinishedSignal(view.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "Should be not null!");
        //        Assert.IsInstanceOf<TransitionSetFinishedSignal>(testingTarget, "Should be an Instance of TransitionSetFinishedSignal!");

        //        try
        //        {
        //            testingTarget.Connect(view.SwigCPtr.Handle);
        //            testingTarget.Disconnect(view.SwigCPtr.Handle);
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"TransitionSetSignalConnectWithIntPtr END (OK)");
        //}
    }
}

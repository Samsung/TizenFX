using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/VoidSignal")]
    public class InternalVoidSignalTest
    {
        private const string tag = "NUITEST";

        private delegate bool dummyCallback(IntPtr voidSignal);
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
        [Description("VoidSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.VoidSignal.VoidSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VoidSignalConstructor()
        {
            tlog.Debug(tag, $"VoidSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new VoidSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<VoidSignal>(testingTarget, "Should be an Instance of VoidSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VoidSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VoidSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.VoidSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VoidSignalEmpty()
        {
            tlog.Debug(tag, $"VoidSignalEmpty START");

            var testingTarget = new VoidSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<VoidSignal>(testingTarget, "Should be an Instance of VoidSignal!");

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

            tlog.Debug(tag, $"VoidSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VoidSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.VoidSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VoidSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"VoidSignalGetConnectionCount START");

            var testingTarget = new VoidSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<VoidSignal>(testingTarget, "Should be an Instance of VoidSignal!");

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

            tlog.Debug(tag, $"VoidSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VoidSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.VoidSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VoidSignalConnect()
        {
            tlog.Debug(tag, $"VoidSignalConnect START");

            var testingTarget = new VoidSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<VoidSignal>(testingTarget, "Should be an Instance of VoidSignal!");

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

            tlog.Debug(tag, $"VoidSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VoidSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.VoidSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VoidSignalEmit()
        {
            tlog.Debug(tag, $"VoidSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (View view = new View())
            {
                var testingTarget = new VoidSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<VoidSignal>(testingTarget, "Should be an Instance of VoidSignal!");

                try
                {
                    testingTarget.Emit();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VoidSignalEmit END (OK)");
        }
    }
}

using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/KeyEventSignal")]
    public class InternalKeyEventSignalTest
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
        [Description("KeyEventSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.KeyEventSignal.KeyEventSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyEventSignalConstructor()
        {
            tlog.Debug(tag, $"KeyEventSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new KeyEventSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<KeyEventSignal>(testingTarget, "Should be an Instance of KeyEventSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"KeyEventSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyEventSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.KeyEventSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyEventSignalEmpty()
        {
            tlog.Debug(tag, $"KeyEventSignalEmpty START");

            var testingTarget = new KeyEventSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyEventSignal>(testingTarget, "Should be an Instance of KeyEventSignal!");

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

            tlog.Debug(tag, $"KeyEventSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyEventSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.KeyEventSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyEventSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"KeyEventSignalGetConnectionCount START");

            var testingTarget = new KeyEventSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyEventSignal>(testingTarget, "Should be an Instance of KeyEventSignal!");

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

            tlog.Debug(tag, $"KeyEventSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyEventSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.KeyEventSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyEventSignalConnect()
        {
            tlog.Debug(tag, $"KeyEventSignalConnect START");

            var testingTarget = new KeyEventSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyEventSignal>(testingTarget, "Should be an Instance of KeyEventSignal!");

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

            tlog.Debug(tag, $"KeyEventSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyEventSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.KeyEventSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void KeyEventSignalEmit()
        {
            tlog.Debug(tag, $"KeyEventSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new KeyEventSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyEventSignal>(testingTarget, "Should be an Instance of KeyEventSignal!");

            try
            {
                using (Key key = new Key())
                {
                    testingTarget.Emit(key);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"KeyEventSignalEmit END (OK)");
        }
    }
}

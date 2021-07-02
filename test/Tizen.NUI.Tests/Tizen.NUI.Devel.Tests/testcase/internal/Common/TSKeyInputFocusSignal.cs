using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/KeyInputFocusSignal")]
    public class InternalKeyInputFocusSignalTest
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
        [Description("KeyInputFocusSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.KeyInputFocusSignal.KeyInputFocusSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyInputFocusSignalConstructor()
        {
            tlog.Debug(tag, $"KeyInputFocusSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new KeyInputFocusSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<KeyInputFocusSignal>(testingTarget, "Should be an Instance of KeyInputFocusSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"KeyInputFocusSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyInputFocusSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.KeyInputFocusSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyInputFocusSignalEmpty()
        {
            tlog.Debug(tag, $"KeyInputFocusSignalEmpty START");

            var testingTarget = new KeyInputFocusSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyInputFocusSignal>(testingTarget, "Should be an Instance of KeyInputFocusSignal!");

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

            tlog.Debug(tag, $"KeyInputFocusSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyInputFocusSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.KeyInputFocusSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyInputFocusSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"KeyInputFocusSignalGetConnectionCount START");

            var testingTarget = new KeyInputFocusSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyInputFocusSignal>(testingTarget, "Should be an Instance of KeyInputFocusSignal!");

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

            tlog.Debug(tag, $"KeyInputFocusSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyInputFocusSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.KeyInputFocusSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyInputFocusSignalConnect()
        {
            tlog.Debug(tag, $"KeyInputFocusSignalConnect START");

            var testingTarget = new KeyInputFocusSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyInputFocusSignal>(testingTarget, "Should be an Instance of KeyInputFocusSignal!");

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

            tlog.Debug(tag, $"KeyInputFocusSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyInputFocusSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.KeyInputFocusSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void KeyInputFocusSignalEmit()
        {
            tlog.Debug(tag, $"KeyInputFocusSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new KeyInputFocusSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyInputFocusSignal>(testingTarget, "Should be an Instance of KeyInputFocusSignal!");

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

            tlog.Debug(tag, $"KeyInputFocusSignalEmit END (OK)");
        }
    }
}

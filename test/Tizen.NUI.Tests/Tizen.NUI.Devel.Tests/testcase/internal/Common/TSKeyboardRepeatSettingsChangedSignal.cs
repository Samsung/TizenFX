using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/KeyboardRepeatSettingsChangedSignal")]
    public class InternalKeyboardRepeatSettingsChangedSignalTest
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
        [Description("KeyboardRepeatSettingsChangedSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.KeyboardRepeatSettingsChangedSignal.KeyboardRepeatSettingsChangedSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyboardRepeatSettingsChangedSignalConstructor()
        {
            tlog.Debug(tag, $"KeyboardRepeatSettingsChangedSignalConstructor START");

            var testingTarget = new KeyboardRepeatSettingsChangedSignal(Window.Instance);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyboardRepeatSettingsChangedSignal>(testingTarget, "Should be an Instance of KeyboardRepeatSettingsChangedSignal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"KeyboardRepeatSettingsChangedSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyboardRepeatSettingsChangedSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.KeyboardRepeatSettingsChangedSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyboardRepeatSettingsChangedSignalEmpty()
        {
            tlog.Debug(tag, $"KeyboardRepeatSettingsChangedSignalEmpty START");

            var testingTarget = new KeyboardRepeatSettingsChangedSignal(Window.Instance);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyboardRepeatSettingsChangedSignal>(testingTarget, "Should be an Instance of KeyboardRepeatSettingsChangedSignal!");

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
            tlog.Debug(tag, $"KeyboardRepeatSettingsChangedSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyboardRepeatSettingsChangedSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.KeyboardRepeatSettingsChangedSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyboardRepeatSettingsChangedSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"KeyboardRepeatSettingsChangedSignalGetConnectionCount START");

            var testingTarget = new KeyboardRepeatSettingsChangedSignal(Window.Instance);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyboardRepeatSettingsChangedSignal>(testingTarget, "Should be an Instance of KeyboardRepeatSettingsChangedSignal!");

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
            tlog.Debug(tag, $"KeyboardRepeatSettingsChangedSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyboardRepeatSettingsChangedSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.KeyboardRepeatSettingsChangedSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyboardRepeatSettingsChangedSignalConnect()
        {
            tlog.Debug(tag, $"KeyboardRepeatSettingsChangedSignalConnect START");

            var testingTarget = new KeyboardRepeatSettingsChangedSignal(Window.Instance);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyboardRepeatSettingsChangedSignal>(testingTarget, "Should be an Instance of KeyboardRepeatSettingsChangedSignal!");

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
            tlog.Debug(tag, $"KeyboardRepeatSettingsChangedSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyboardRepeatSettingsChangedSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.KeyboardRepeatSettingsChangedSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void KeyboardRepeatSettingsChangedSignalEmit()
        {
            tlog.Debug(tag, $"KeyboardRepeatSettingsChangedSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new KeyboardRepeatSettingsChangedSignal(Window.Instance);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyboardRepeatSettingsChangedSignal>(testingTarget, "Should be an Instance of KeyboardRepeatSettingsChangedSignal!");

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
            tlog.Debug(tag, $"KeyboardRepeatSettingsChangedSignalEmit END (OK)");
        }
    }
}

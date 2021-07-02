using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/KeyboardResizedSignalType")]
    public class InternalKeyboardResizedSignalTypeTest
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
        [Description("KeyboardResizedSignalType constructor.")]
        [Property("SPEC", "Tizen.NUI.KeyboardResizedSignalType.KeyboardResizedSignalType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyboardResizedSignalTypeConstructor()
        {
            tlog.Debug(tag, $"KeyboardResizedSignalTypeConstructor START");

            using (View view = new View())
            {
                var testingTarget = new KeyboardResizedSignalType(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<KeyboardResizedSignalType>(testingTarget, "Should be an Instance of KeyboardResizedSignalType!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"KeyboardResizedSignalTypeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyboardResizedSignalType Empty.")]
        [Property("SPEC", "Tizen.NUI.KeyboardResizedSignalType.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyboardResizedSignalTypeEmpty()
        {
            tlog.Debug(tag, $"KeyboardResizedSignalTypeEmpty START");

            var testingTarget = new KeyboardResizedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyboardResizedSignalType>(testingTarget, "Should be an Instance of KeyboardResizedSignalType!");

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

            tlog.Debug(tag, $"KeyboardResizedSignalTypeEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyboardResizedSignalType GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.KeyboardResizedSignalType.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyboardResizedSignalTypeGetConnectionCount()
        {
            tlog.Debug(tag, $"KeyboardResizedSignalTypeGetConnectionCount START");

            var testingTarget = new KeyboardResizedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyboardResizedSignalType>(testingTarget, "Should be an Instance of KeyboardResizedSignalType!");

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

            tlog.Debug(tag, $"KeyboardResizedSignalTypeGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyboardResizedSignalType Connect.")]
        [Property("SPEC", "Tizen.NUI.KeyboardResizedSignalType.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyboardResizedSignalTypeConnect()
        {
            tlog.Debug(tag, $"KeyboardResizedSignalTypeConnect START");

            var testingTarget = new KeyboardResizedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyboardResizedSignalType>(testingTarget, "Should be an Instance of KeyboardResizedSignalType!");

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

            tlog.Debug(tag, $"KeyboardResizedSignalTypeConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyboardResizedSignalType Emit.")]
        [Property("SPEC", "Tizen.NUI.KeyboardResizedSignalType.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void KeyboardResizedSignalTypeEmit()
        {
            tlog.Debug(tag, $"KeyboardResizedSignalTypeEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new KeyboardResizedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyboardResizedSignalType>(testingTarget, "Should be an Instance of KeyboardResizedSignalType!");

            try
            {
                testingTarget.Emit(1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"KeyboardResizedSignalTypeEmit END (OK)");
        }
    }
}

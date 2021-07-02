using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/KeyboardEventSignalType")]
    public class InternalKeyboardEventSignalTypeTest
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
        [Description("KeyboardEventSignalType constructor.")]
        [Property("SPEC", "Tizen.NUI.KeyboardEventSignalType.KeyboardEventSignalType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyboardEventSignalTypeConstructor()
        {
            tlog.Debug(tag, $"KeyboardEventSignalTypeConstructor START");

            using (View view = new View())
            {
                var testingTarget = new KeyboardEventSignalType(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<KeyboardEventSignalType>(testingTarget, "Should be an Instance of KeyboardEventSignalType!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"KeyboardEventSignalTypeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyboardEventSignalType Empty.")]
        [Property("SPEC", "Tizen.NUI.KeyboardEventSignalType.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyboardEventSignalTypeEmpty()
        {
            tlog.Debug(tag, $"KeyboardEventSignalTypeEmpty START");

            var testingTarget = new KeyboardEventSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyboardEventSignalType>(testingTarget, "Should be an Instance of KeyboardEventSignalType!");

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

            tlog.Debug(tag, $"KeyboardEventSignalTypeEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyboardEventSignalType GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.KeyboardEventSignalType.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyboardEventSignalTypeGetConnectionCount()
        {
            tlog.Debug(tag, $"KeyboardEventSignalTypeGetConnectionCount START");

            var testingTarget = new KeyboardEventSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyboardEventSignalType>(testingTarget, "Should be an Instance of KeyboardEventSignalType!");

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

            tlog.Debug(tag, $"KeyboardEventSignalTypeGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyboardEventSignalType Connect.")]
        [Property("SPEC", "Tizen.NUI.KeyboardEventSignalType.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyboardEventSignalTypeConnect()
        {
            tlog.Debug(tag, $"KeyboardEventSignalTypeConnect START");

            var testingTarget = new KeyboardEventSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyboardEventSignalType>(testingTarget, "Should be an Instance of KeyboardEventSignalType!");

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

            tlog.Debug(tag, $"KeyboardEventSignalTypeConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyboardEventSignalType Emit.")]
        [Property("SPEC", "Tizen.NUI.KeyboardEventSignalType.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void KeyboardEventSignalTypeEmit()
        {
            tlog.Debug(tag, $"KeyboardEventSignalTypeEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new KeyboardEventSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyboardEventSignalType>(testingTarget, "Should be an Instance of KeyboardEventSignalType!");

            try
            {
                using (InputMethodContext context = new InputMethodContext())
                {
                    using (InputMethodContext.EventData data = new InputMethodContext.EventData())
                    {
                        testingTarget.Emit(context, data);
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"KeyboardEventSignalTypeEmit END (OK)");
        }
    }
}

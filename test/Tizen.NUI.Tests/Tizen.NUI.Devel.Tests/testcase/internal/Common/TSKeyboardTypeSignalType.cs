using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/KeyboardTypeSignalType")]
    public class KeyboardTypeSignalTypeTests
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
        [Description("KeyboardTypeSignalType constructor.")]
        [Property("SPEC", "Tizen.NUI.KeyboardTypeSignalType.KeyboardTypeSignalType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyboardTypeSignalTypeConstructor()
        {
            tlog.Debug(tag, $"KeyboardTypeSignalTypeConstructor START");

            using (View view = new View())
            {
                var testingTarget = new KeyboardTypeSignalType(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<KeyboardTypeSignalType>(testingTarget, "Should be an Instance of KeyboardTypeSignalType!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"KeyboardTypeSignalTypeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyboardTypeSignalType Empty.")]
        [Property("SPEC", "Tizen.NUI.KeyboardTypeSignalType.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyboardTypeSignalTypeEmpty()
        {
            tlog.Debug(tag, $"KeyboardTypeSignalTypeEmpty START");

            var testingTarget = new KeyboardTypeSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyboardTypeSignalType>(testingTarget, "Should be an Instance of KeyboardTypeSignalType!");

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

            tlog.Debug(tag, $"KeyboardTypeSignalTypeEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyboardTypeSignalType GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.KeyboardTypeSignalType.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyboardTypeSignalTypeGetConnectionCount()
        {
            tlog.Debug(tag, $"KeyboardTypeSignalTypeGetConnectionCount START");

            var testingTarget = new KeyboardTypeSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyboardTypeSignalType>(testingTarget, "Should be an Instance of KeyboardTypeSignalType!");

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

            tlog.Debug(tag, $"KeyboardTypeSignalTypeGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyboardTypeSignalType Connect.")]
        [Property("SPEC", "Tizen.NUI.KeyboardTypeSignalType.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyboardTypeSignalTypeConnect()
        {
            tlog.Debug(tag, $"KeyboardTypeSignalTypeConnect START");

            var testingTarget = new KeyboardTypeSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyboardTypeSignalType>(testingTarget, "Should be an Instance of KeyboardTypeSignalType!");

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

            tlog.Debug(tag, $"KeyboardTypeSignalTypeConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyboardTypeSignalType Emit.")]
        [Property("SPEC", "Tizen.NUI.KeyboardTypeSignalType.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void KeyboardTypeSignalTypeEmit()
        {
            tlog.Debug(tag, $"KeyboardTypeSignalTypeEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new KeyboardTypeSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyboardTypeSignalType>(testingTarget, "Should be an Instance of KeyboardTypeSignalType!");

            try
            {
                testingTarget.Emit(new InputMethodContext.KeyboardType());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"KeyboardTypeSignalTypeEmit END (OK)");
        }
    }
}

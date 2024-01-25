using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/TextFieldSignal")]
    public class InternalTextFieldSignalTest
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
        [Description("TextFieldSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.TextFieldSignal.TextFieldSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldSignalConstructor()
        {
            tlog.Debug(tag, $"TextFieldSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new TextFieldSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TextFieldSignal>(testingTarget, "Should be an Instance of TextFieldSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TextFieldSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextFieldSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.TextFieldSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldSignalEmpty()
        {
            tlog.Debug(tag, $"TextFieldSignalEmpty START");

            var testingTarget = new TextFieldSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TextFieldSignal>(testingTarget, "Should be an Instance of TextFieldSignal!");

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

            tlog.Debug(tag, $"TextFieldSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextFieldSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.TextFieldSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"TextFieldSignalGetConnectionCount START");

            var testingTarget = new TextFieldSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TextFieldSignal>(testingTarget, "Should be an Instance of TextFieldSignal!");

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

            tlog.Debug(tag, $"TextFieldSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextFieldSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.TextFieldSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldSignalConnect()
        {
            tlog.Debug(tag, $"TextFieldSignalConnect START");

            var testingTarget = new TextFieldSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TextFieldSignal>(testingTarget, "Should be an Instance of TextFieldSignal!");

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

            tlog.Debug(tag, $"TextFieldSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextFieldSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.TextFieldSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldSignalEmit()
        {
            tlog.Debug(tag, $"TextFieldSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (TextField field = new TextField())
            {
                var testingTarget = new TextFieldSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TextFieldSignal>(testingTarget, "Should be an Instance of TextFieldSignal!");

                try
                {
                    testingTarget.Emit(field);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TouchDataSignalEmit END (OK)");
        }
    }
}

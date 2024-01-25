using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/TextLabelSignal")]
    public class InternalTextLabelSignalTest
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
        [Description("TextLabelSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.TextLabelSignal.TextLabelSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextLabelSignalConstructor()
        {
            tlog.Debug(tag, $"TextLabelSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new TextLabelSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TextLabelSignal>(testingTarget, "Should be an Instance of TextLabelSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TextLabelSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextLabelSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.TextLabelSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextLabelSignalEmpty()
        {
            tlog.Debug(tag, $"TextLabelSignalEmpty START");

            var testingTarget = new TextLabelSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TextLabelSignal>(testingTarget, "Should be an Instance of TextLabelSignal!");

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

            tlog.Debug(tag, $"TextLabelSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextLabelSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.TextLabelSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextLabelSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"TextLabelSignalGetConnectionCount START");

            var testingTarget = new TextLabelSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TextLabelSignal>(testingTarget, "Should be an Instance of TextLabelSignal!");

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

            tlog.Debug(tag, $"TextLabelSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextLabelSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.TextLabelSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextLabelSignalConnect()
        {
            tlog.Debug(tag, $"TextLabelSignalConnect START");

            var testingTarget = new TextLabelSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TextLabelSignal>(testingTarget, "Should be an Instance of TextLabelSignal!");

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

            tlog.Debug(tag, $"TextLabelSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextLabelSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.TextLabelSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextLabelSignalEmit()
        {
            tlog.Debug(tag, $"TextLabelSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (TextLabel label = new TextLabel())
            {
                var testingTarget = new TextLabelSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TextLabelSignal>(testingTarget, "Should be an Instance of TextLabelSignal!");

                try
                {
                    testingTarget.Emit(label);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TextLabelSignalEmit END (OK)");
        }
    }
}

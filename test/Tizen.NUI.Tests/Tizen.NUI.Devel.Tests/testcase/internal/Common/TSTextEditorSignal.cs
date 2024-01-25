using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/TextEditorSignal")]
    public class InternalTextEditorSignalTest
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
        [Description("TextEditorSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.TextEditorSignal.TextEditorSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextEditorSignalConstructor()
        {
            tlog.Debug(tag, $"TextEditorSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new TextEditorSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TextEditorSignal>(testingTarget, "Should be an Instance of TextEditorSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TextEditorSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEditorSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.TextEditorSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextEditorSignalEmpty()
        {
            tlog.Debug(tag, $"TextEditorSignalEmpty START");

            var testingTarget = new TextEditorSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TextEditorSignal>(testingTarget, "Should be an Instance of TextEditorSignal!");

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

            tlog.Debug(tag, $"TextEditorSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEditorSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.TextEditorSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextEditorSignalConnectionCount()
        {
            tlog.Debug(tag, $"TextEditorSignalGetConnectionCount START");

            var testingTarget = new TextEditorSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TextEditorSignal>(testingTarget, "Should be an Instance of TextEditorSignal!");

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

            tlog.Debug(tag, $"TextEditorSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEditorSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.TextEditorSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextEditorSignalConnect()
        {
            tlog.Debug(tag, $"TextEditorSignalConnect START");

            var testingTarget = new TextEditorSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TextEditorSignal>(testingTarget, "Should be an Instance of TextEditorSignal!");

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

            tlog.Debug(tag, $"TextEditorSignalConnect END (OK)");
        }
    }
}

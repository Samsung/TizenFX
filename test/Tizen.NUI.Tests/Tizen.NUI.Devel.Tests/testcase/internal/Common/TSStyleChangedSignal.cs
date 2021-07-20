using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/StyleChangedSignal")]
    public class InternalStyleChangedSignalTest
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
        [Description("StyleChangedSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.StyleChangedSignal.StyleChangedSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StyleChangedSignalConstructor()
        {
            tlog.Debug(tag, $"StyleChangedSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new StyleChangedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<StyleChangedSignal>(testingTarget, "Should be an Instance of StyleChangedSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"StyleChangedSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StyleChangedSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.StyleChangedSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StyleChangedSignalEmpty()
        {
            tlog.Debug(tag, $"StyleChangedSignalEmpty START");

            var testingTarget = new StyleChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StyleChangedSignal>(testingTarget, "Should be an Instance of StyleChangedSignal!");

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

            tlog.Debug(tag, $"StyleChangedSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StyleChangedSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.StyleChangedSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StyleChangedSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"StyleChangedSignalGetConnectionCount START");

            var testingTarget = new StyleChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StyleChangedSignal>(testingTarget, "Should be an Instance of StyleChangedSignal!");

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

            tlog.Debug(tag, $"StyleChangedSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StyleChangedSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.StyleChangedSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StyleChangedSignalConnect()
        {
            tlog.Debug(tag, $"StyleChangedSignal START");

            var testingTarget = new StyleChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StyleChangedSignal>(testingTarget, "Should be an Instance of StyleChangedSignal!");

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

            tlog.Debug(tag, $"StyleChangedSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StyleChangedSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.StyleChangedSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void StyleChangedSignalEmit()
        {
            tlog.Debug(tag, $"StyleChangedSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new StyleChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StyleChangedSignal>(testingTarget, "Should be an Instance of StyleChangedSignal!");

            try
            {
                testingTarget.Emit(StyleManager.Get(), StyleChangeType.DefaultFontChange);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"StyleChangedSignalEmit END (OK)");
        }
    }
}

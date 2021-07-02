using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/GLWindowResizedSignal")]
    public class InternalGLWindowResizedSignalTest
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
        [Description("GLWindowResizedSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.GLWindowResizedSignal.GLWindowResizedSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GLWindowResizedSignalConstructor()
        {
            tlog.Debug(tag, $"GLWindowResizedSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new GLWindowResizedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<GLWindowResizedSignal>(testingTarget, "Should be an Instance of GLWindowResizedSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"GLWindowResizedSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindowResizedSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.GLWindowResizedSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GLWindowResizedSignalEmpty()
        {
            tlog.Debug(tag, $"GLWindowResizedSignalEmpty START");

            var testingTarget = new GLWindowResizedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<GLWindowResizedSignal>(testingTarget, "Should be an Instance of GLWindowResizedSignal!");

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

            tlog.Debug(tag, $"GLWindowResizedSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindowResizedSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.GLWindowResizedSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GLWindowResizedSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"GLWindowResizedSignalGetConnectionCount START");

            var testingTarget = new GLWindowResizedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<GLWindowResizedSignal>(testingTarget, "Should be an Instance of GLWindowResizedSignal!");

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

            tlog.Debug(tag, $"GLWindowResizedSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindowResizedSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.GLWindowResizedSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GLWindowResizedSignalConnect()
        {
            tlog.Debug(tag, $"GLWindowResizedSignalConnect START");

            var testingTarget = new GLWindowResizedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<GLWindowResizedSignal>(testingTarget, "Should be an Instance of GLWindowResizedSignal!");

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

            tlog.Debug(tag, $"GLWindowResizedSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindowResizedSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.GLWindowResizedSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void GLWindowResizedSignalEmit()
        {
            tlog.Debug(tag, $"GLWindowResizedSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new GLWindowResizedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<GLWindowResizedSignal>(testingTarget, "Should be an Instance of GLWindowResizedSignal!");

            try
            {
                using (Size2D size = new Size2D(20, 30))
                {
                    testingTarget.Emit(size);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"GLWindowResizedSignalEmit END (OK)");
        }
    }
}

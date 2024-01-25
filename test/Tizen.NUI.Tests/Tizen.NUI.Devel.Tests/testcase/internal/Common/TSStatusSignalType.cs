using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/StatusSignalType")]
    public class InternalStatusSignalTypeTest
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
        [Description("StatusSignalType constructor.")]
        [Property("SPEC", "Tizen.NUI.StatusSignalType.StatusSignalType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StatusSignalTypeConstructor()
        {
            tlog.Debug(tag, $"StatusSignalTypeConstructor START");

            using (View view = new View())
            {
                var testingTarget = new StatusSignalType(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<StatusSignalType>(testingTarget, "Should be an Instance of StatusSignalType!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"StatusSignalTypeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StatusSignalType Empty.")]
        [Property("SPEC", "Tizen.NUI.StatusSignalType.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StatusSignalTypeEmpty()
        {
            tlog.Debug(tag, $"StatusSignalTypeEmpty START");

            var testingTarget = new StatusSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StatusSignalType>(testingTarget, "Should be an Instance of StatusSignalType!");

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

            tlog.Debug(tag, $"StatusSignalTypeEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StatusSignalType GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.StatusSignalType.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StatusSignalTypeGetConnectionCount()
        {
            tlog.Debug(tag, $"StatusSignalTypeGetConnectionCount START");

            var testingTarget = new StatusSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StatusSignalType>(testingTarget, "Should be an Instance of StatusSignalType!");

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

            tlog.Debug(tag, $"StatusSignalTypeGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StatusSignalType Connect.")]
        [Property("SPEC", "Tizen.NUI.StatusSignalType.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StatusSignalTypeConnect()
        {
            tlog.Debug(tag, $"StatusSignalTypeConnect START");

            var testingTarget = new StatusSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StatusSignalType>(testingTarget, "Should be an Instance of StatusSignalType!");

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

            tlog.Debug(tag, $"StatusSignalTypeConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StatusSignalType Emit.")]
        [Property("SPEC", "Tizen.NUI.StatusSignalType.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StatusSignalTypeEmit()
        {
            tlog.Debug(tag, $"StatusSignalTypeEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new StatusSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StatusSignalType>(testingTarget, "Should be an Instance of StatusSignalType!");

            try
            {
                testingTarget.Emit(true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"StatusSignalTypeEmit END (OK)");
        }
    }
}

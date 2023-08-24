using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ActivatedSignalType")]
    public class InternalActivatedSignalTypeTest
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
        [Description("ActivatedSignalType constructor.")]
        [Property("SPEC", "Tizen.NUI.ActivatedSignalType.ActivatedSignalType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ActivatedSignalTypeConstructor()
        {
            tlog.Debug(tag, $"ActivatedSignalTypeConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ActivatedSignalType(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ActivatedSignalType>(testingTarget, "Should be an Instance of ActivatedSignalType!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ActivatedSignalTypeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ActivatedSignalType Empty.")]
        [Property("SPEC", "Tizen.NUI.ActivatedSignalType.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ActivatedSignalTypeEmpty()
        {
            tlog.Debug(tag, $"ActivatedSignalTypeEmpty START");

            var testingTarget = new ActivatedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ActivatedSignalType>(testingTarget, "Should be an Instance of ActivatedSignalType!");

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

            tlog.Debug(tag, $"ActivatedSignalTypeEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ActivatedSignalType GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.ActivatedSignalType.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ActivatedSignalTypeGetConnectionCount()
        {
            tlog.Debug(tag, $"ActivatedSignalTypeGetConnectionCount START");

            var testingTarget = new ActivatedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ActivatedSignalType>(testingTarget, "Should be an Instance of ActivatedSignalType!");

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

            tlog.Debug(tag, $"ActivatedSignalTypeGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ActivatedSignalType Connect.")]
        [Property("SPEC", "Tizen.NUI.ActivatedSignalType.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ActivatedSignalTypeConnect()
        {
            tlog.Debug(tag, $"ActivatedSignalTypeConnect START");

            var testingTarget = new ActivatedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ActivatedSignalType>(testingTarget, "Should be an Instance of ActivatedSignalType!");

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

            tlog.Debug(tag, $"ActivatedSignalTypeConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ActivatedSignalType Emit.")]
        [Property("SPEC", "Tizen.NUI.ActivatedSignalType.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ActivatedSignalTypeEmit()
        {
            tlog.Debug(tag, $"ActivatedSignalTypeEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (InputMethodContext context = new InputMethodContext())
            {
                var testingTarget = new ActivatedSignalType();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ActivatedSignalType>(testingTarget, "Should be an Instance of ActivatedSignalType!");

                try
                {
                    testingTarget.Emit(context);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ActivatedSignalTypeEmit END (OK)");
        }
    }
}

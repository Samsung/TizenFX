using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ContentReceivedSignalType")]
    public class InternalContentReceivedSignalTypeTest
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
        [Description("ContentReceivedSignalType constructor.")]
        [Property("SPEC", "Tizen.NUI.ContentReceivedSignalType.ContentReceivedSignalType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ContentReceivedSignalTypeConstructor()
        {
            tlog.Debug(tag, $"ContentReceivedSignalTypeConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ContentReceivedSignalType(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ContentReceivedSignalType>(testingTarget, "Should be an Instance of ContentReceivedSignalType!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ContentReceivedSignalTypeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ContentReceivedSignalType Empty.")]
        [Property("SPEC", "Tizen.NUI.ContentReceivedSignalType.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ContentReceivedSignalTypeEmpty()
        {
            tlog.Debug(tag, $"ContentReceivedSignalTypeEmpty START");

            var testingTarget = new ContentReceivedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ContentReceivedSignalType>(testingTarget, "Should be an Instance of ContentReceivedSignalType!");

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

            tlog.Debug(tag, $"ContentReceivedSignalTypeEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ContentReceivedSignalType GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.ContentReceivedSignalType.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ContentReceivedSignalTypeGetConnectionCount()
        {
            tlog.Debug(tag, $"ContentReceivedSignalTypeGetConnectionCount START");

            var testingTarget = new ContentReceivedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ContentReceivedSignalType>(testingTarget, "Should be an Instance of ContentReceivedSignalType!");

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

            tlog.Debug(tag, $"ContentReceivedSignalTypeGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ContentReceivedSignalType Connect.")]
        [Property("SPEC", "Tizen.NUI.ContentReceivedSignalType.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ContentReceivedSignalTypeConnect()
        {
            tlog.Debug(tag, $"ContentReceivedSignalTypeConnect START");

            var testingTarget = new ContentReceivedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ContentReceivedSignalType>(testingTarget, "Should be an Instance of ContentReceivedSignalType!");

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

            tlog.Debug(tag, $"ContentReceivedSignalTypeConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ContentReceivedSignalType Emit.")]
        [Property("SPEC", "Tizen.NUI.ContentReceivedSignalType.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ContentReceivedSignalTypeEmit()
        {
            tlog.Debug(tag, $"ContentReceivedSignalTypeEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new ContentReceivedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ContentReceivedSignalType>(testingTarget, "Should be an Instance of ContentReceivedSignalType!");

            try
            {
                testingTarget.Emit("func1", "func2", "func3");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"ContentReceivedSignalTypeEmit END (OK)");
        }
    }
}

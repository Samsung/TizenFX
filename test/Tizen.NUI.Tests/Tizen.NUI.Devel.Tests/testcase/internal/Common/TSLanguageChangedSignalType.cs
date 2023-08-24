using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/LanguageChangedSignalType")]
    public class InternalLanguageChangedSignalTypeTest
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
        [Description("LanguageChangedSignalType constructor.")]
        [Property("SPEC", "Tizen.NUI.LanguageChangedSignalType.LanguageChangedSignalType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LanguageChangedSignalTypeConstructor()
        {
            tlog.Debug(tag, $"LanguageChangedSignalTypeConstructor START");

            using (View view = new View())
            {
                var testingTarget = new LanguageChangedSignalType(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<LanguageChangedSignalType>(testingTarget, "Should be an Instance of LanguageChangedSignalType!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"LanguageChangedSignalTypeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LanguageChangedSignalType Empty.")]
        [Property("SPEC", "Tizen.NUI.LanguageChangedSignalType.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LanguageChangedSignalTypeEmpty()
        {
            tlog.Debug(tag, $"LanguageChangedSignalTypeEmpty START");

            var testingTarget = new LanguageChangedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<LanguageChangedSignalType>(testingTarget, "Should be an Instance of LanguageChangedSignalType!");

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

            tlog.Debug(tag, $"LanguageChangedSignalTypeEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LanguageChangedSignalType GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.LanguageChangedSignalType.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LanguageChangedSignalTypeGetConnectionCount()
        {
            tlog.Debug(tag, $"LanguageChangedSignalTypeGetConnectionCount START");

            var testingTarget = new LanguageChangedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<LanguageChangedSignalType>(testingTarget, "Should be an Instance of LanguageChangedSignalType!");

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

            tlog.Debug(tag, $"LanguageChangedSignalTypeGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LanguageChangedSignalType Connect.")]
        [Property("SPEC", "Tizen.NUI.LanguageChangedSignalType.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LanguageChangedSignalTypeConnect()
        {
            tlog.Debug(tag, $"LanguageChangedSignalTypeConnect START");

            var testingTarget = new LanguageChangedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<LanguageChangedSignalType>(testingTarget, "Should be an Instance of LanguageChangedSignalType!");

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

            tlog.Debug(tag, $"LanguageChangedSignalTypeConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LanguageChangedSignalType Emit.")]
        [Property("SPEC", "Tizen.NUI.LanguageChangedSignalType.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LanguageChangedSignalTypeEmit()
        {
            tlog.Debug(tag, $"LanguageChangedSignalTypeEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new LanguageChangedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<LanguageChangedSignalType>(testingTarget, "Should be an Instance of LanguageChangedSignalType!");

            try
            {
                testingTarget.Emit(1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"LanguageChangedSignalTypeEmit END (OK)");
        }
    }
}

using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/PreFocusChangeSignal")]
    public class InternalPreFocusChangeSignalTest
    {
        private const string tag = "NUITEST";

        private IntPtr OnDummyCallback(IntPtr current, IntPtr proposed, View.FocusDirection direction)
        {
            return proposed;
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
        [Description("PreFocusChangeSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.PreFocusChangeSignal.PreFocusChangeSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PreFocusChangeSignalConstructor()
        {
            tlog.Debug(tag, $"PreFocusChangeSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new PreFocusChangeSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PreFocusChangeSignal>(testingTarget, "Should be an Instance of PreFocusChangeSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PreFocusChangeSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PreFocusChangeSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.PreFocusChangeSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PreFocusChangeSignalEmpty()
        {
            tlog.Debug(tag, $"PreFocusChangeSignalEmpty START");

            var testingTarget = new PreFocusChangeSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PreFocusChangeSignal>(testingTarget, "Should be an Instance of PreFocusChangeSignal!");

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

            tlog.Debug(tag, $"PreFocusChangeSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PreFocusChangeSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.PreFocusChangeSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PreFocusChangeSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"PreFocusChangeSignalGetConnectionCount START");

            var testingTarget = new PreFocusChangeSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PreFocusChangeSignal>(testingTarget, "Should be an Instance of PreFocusChangeSignal!");

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

            tlog.Debug(tag, $"PreFocusChangeSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PreFocusChangeSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.PreFocusChangeSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PreFocusChangeSignalConnect()
        {
            tlog.Debug(tag, $"PreFocusChangeSignalConnect START");

            var testingTarget = new PreFocusChangeSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PreFocusChangeSignal>(testingTarget, "Should be an Instance of PreFocusChangeSignal!");

            try
            {
                Tizen.NUI.FocusManager.PreFocusChangeEventCallback func = OnDummyCallback;
                testingTarget.Connect(func);
                testingTarget.Disconnect(func);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"PreFocusChangeSignalConnect END (OK)");
        }
    }
}

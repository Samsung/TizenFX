using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ObjectCreatedSignal")]
    public class InternalObjectCreatedSignalTest
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
        [Description("ObjectCreatedSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.ObjectCreatedSignal.ObjectCreatedSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectCreatedSignalConstructor()
        {
            tlog.Debug(tag, $"ObjectCreatedSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ObjectCreatedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ObjectCreatedSignal>(testingTarget, "Should be an Instance of ObjectCreatedSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ObjectCreatedSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObjectCreatedSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.ObjectCreatedSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectCreatedSignalEmpty()
        {
            tlog.Debug(tag, $"ObjectCreatedSignalEmpty START");

            var testingTarget = new ObjectCreatedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ObjectCreatedSignal>(testingTarget, "Should be an Instance of ObjectCreatedSignal!");

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

            tlog.Debug(tag, $"ObjectCreatedSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObjectCreatedSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.ObjectCreatedSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectCreatedSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"ObjectCreatedSignalGetConnectionCount START");

            var testingTarget = new ObjectCreatedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ObjectCreatedSignal>(testingTarget, "Should be an Instance of ObjectCreatedSignal!");

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

            tlog.Debug(tag, $"ObjectCreatedSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObjectCreatedSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.ObjectCreatedSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectCreatedSignalConnect()
        {
            tlog.Debug(tag, $"ObjectCreatedSignalConnect START");

            var testingTarget = new ObjectCreatedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ObjectCreatedSignal>(testingTarget, "Should be an Instance of ObjectCreatedSignal!");

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

            tlog.Debug(tag, $"ObjectCreatedSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObjectCreatedSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.ObjectCreatedSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectCreatedSignalEmit()
        {
            tlog.Debug(tag, $"ObjectCreatedSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (View view = new View())
            {
                var testingTarget = new ObjectCreatedSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ObjectCreatedSignal>(testingTarget, "Should be an Instance of ObjectCreatedSignal!");

                try
                {
                    using (RefObject obj = new RefObject(view.SwigCPtr.Handle, false))
                    {
                        testingTarget.Emit(view);
                    }
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ObjectCreatedSignalEmit END (OK)");
        }
    }
}

using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ObjectDestroyedSignal")]
    public class InternalObjectDestroyedSignalTest
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
        [Description("ObjectDestroyedSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.ObjectDestroyedSignal.ObjectDestroyedSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectDestroyedSignalConstructor()
        {
            tlog.Debug(tag, $"ObjectDestroyedSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ObjectDestroyedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ObjectDestroyedSignal>(testingTarget, "Should be an Instance of ObjectDestroyedSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ObjectDestroyedSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObjectDestroyedSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.ObjectDestroyedSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectDestroyedSignalEmpty()
        {
            tlog.Debug(tag, $"ObjectDestroyedSignalEmpty START");

            var testingTarget = new ObjectDestroyedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ObjectDestroyedSignal>(testingTarget, "Should be an Instance of ObjectDestroyedSignal!");

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

            tlog.Debug(tag, $"ObjectDestroyedSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObjectDestroyedSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.ObjectDestroyedSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectDestroyedSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"ObjectDestroyedSignalGetConnectionCount START");

            var testingTarget = new ObjectDestroyedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ObjectDestroyedSignal>(testingTarget, "Should be an Instance of ObjectDestroyedSignal!");

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

            tlog.Debug(tag, $"ObjectDestroyedSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObjectDestroyedSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.ObjectDestroyedSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectDestroyedSignalConnect()
        {
            tlog.Debug(tag, $"ObjectDestroyedSignalConnect START");

            var testingTarget = new ObjectDestroyedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ObjectDestroyedSignal>(testingTarget, "Should be an Instance of ObjectDestroyedSignal!");

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

            tlog.Debug(tag, $"ObjectDestroyedSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObjectDestroyedSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.ObjectDestroyedSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectDestroyedSignalEmit()
        {
            tlog.Debug(tag, $"ObjectDestroyedSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (View view = new View())
            {
                var testingTarget = new ObjectDestroyedSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ObjectDestroyedSignal>(testingTarget, "Should be an Instance of ObjectDestroyedSignal!");

                try
                {
                    using (RefObject obj = new RefObject(view.SwigCPtr.Handle, false))
                    {
                        testingTarget.Emit(obj);
                    }
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ObjectDestroyedSignalEmit END (OK)");
        }
    }
}

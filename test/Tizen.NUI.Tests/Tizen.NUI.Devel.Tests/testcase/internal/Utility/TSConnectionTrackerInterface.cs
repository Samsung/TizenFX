using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/ConnectionTrackerInterface")]
    public class InternalConnectionTrackerInterfaceTest
    {
        private const string tag = "NUITEST";
        private delegate bool dummyCallback(IntPtr pageTurnSignal);
        private bool OnDummyCallback(IntPtr data)
        {
            return false;
        }

        internal class MyConnectionTrackerInterface : ConnectionTrackerInterface
        {
            public MyConnectionTrackerInterface(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
            { }
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
        [Description("ConnectionTrackerInterface constructor.")]
        [Property("SPEC", "Tizen.NUI.ConnectionTrackerInterface.ConnectionTrackerInterface C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ConnectionTrackerInterfaceConstructor()
        {
            tlog.Debug(tag, $"ConnectionTrackerInterfaceConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ConnectionTrackerInterface(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ConnectionTrackerInterface>(testingTarget, "Should be an Instance of ConnectionTrackerInterface!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ConnectionTrackerInterfaceConstructor END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("ConnectionTrackerInterface SignalConnected.")]
        //[Property("SPEC", "Tizen.NUI.ConnectionTrackerInterface.SignalConnected M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void ConnectionTrackerInterfaceSignalConnected()
        //{
        //    tlog.Debug(tag, $"ConnectionTrackerInterfaceSignalConnected START");

        //    using (View view = new View())
        //    {
        //        var testingTarget = new ConnectionTrackerInterface(view.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "Should be not null!");
        //        Assert.IsInstanceOf<ConnectionTrackerInterface>(testingTarget, "Should be an Instance of ConnectionTrackerInterface!");

        //        try
        //        {
        //            var slotObserver = new SlotObserver(testingTarget.SwigCPtr.Handle, false);
        //            var callback = new SWIGTYPE_p_CallbackBase(testingTarget.SwigCPtr.Handle);
        //            testingTarget.SignalConnected(slotObserver, callback);
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"ConnectionTrackerInterfaceSignalConnected END (OK)");
        //}
    }
}

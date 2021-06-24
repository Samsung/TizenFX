using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Application/WatchBoolSignal")]
    public class InternalWatchBoolSignalTest
    {
        private const string tag = "NUITEST";
        private delegate bool dummyCallback(IntPtr application);
        private bool OnDummyCallback(IntPtr data)
        {
            return false;
        }

        internal class MyWatchBoolSignal : WatchBoolSignal
        {
            public MyWatchBoolSignal(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
            { }

            public void OnReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
            {
                base.ReleaseSwigCPtr(swigCPtr);
            }
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
        [Description("WatchBoolSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.WatchBoolSignal.WatchBoolSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchBoolSignalConstructor()
        {
            tlog.Debug(tag, $"WatchBoolSignalConstructor START");

            using (ImageView imageView = new ImageView())
            {
                var testingTarget = new WatchBoolSignal(imageView.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchBoolSignal>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WatchBoolSignalConstructor END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("WatchApplication ReleaseSwigCPtr.")]
        //[Property("SPEC", "Tizen.NUI.WatchApplication.ReleaseSwigCPtr M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchApplicationReleaseSwigCPtr()
        //{
        //    tlog.Debug(tag, $"WatchBoolSignalReleaseSwigCPtr START");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new MyWatchBoolSignal(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchBoolSignal>(testingTarget, "should be an instance of testing target class!");

        //        try
        //        {
        //            testingTarget.OnReleaseSwigCPtr(imageView.SwigCPtr);
        //        }
        //        catch (Exception e)
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_delete_WatchBoolSignal' in shared library 'libdali2-csharp-binder.so' */
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchBoolSignalReleaseSwigCPtr END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchBoolSignal Empty.")]
        //[Property("SPEC", "Tizen.NUI.WatchBoolSignal.Empty M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchBoolSignalEmpty()
        //{
        //    tlog.Debug(tag, $"WatchBoolSignalEmpty START");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new WatchBoolSignal(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchBoolSignal>(testingTarget, "should be an instance of testing target class!");

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchBoolSignal_Empty' in shared library 'libdali2-csharp-binder.so' */
        //            var result = testingTarget.Empty();
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }
        //    tlog.Debug(tag, $"WatchBoolSignalEmpty END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchBoolSignal GetConnectionCount.")]
        //[Property("SPEC", "Tizen.NUI.WatchBoolSignal.GetConnectionCount M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchBoolSignalGetConnectionCount()
        //{
        //    tlog.Debug(tag, $"WatchBoolSignalGetConnectionCount START");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new WatchBoolSignal(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchBoolSignal>(testingTarget, "should be an instance of testing target class!");

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchBoolSignal_GetConnectionCount' in shared library 'libdali2-csharp-binder.so' */
        //            var result = testingTarget.GetConnectionCount();
        //            Assert.IsTrue(result == 0, "result should be 0");
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }
        //    tlog.Debug(tag, $"WatchBoolSignalGetConnectionCount END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchBoolSignal connection.")]
        //[Property("SPEC", "Tizen.NUI.WatchBoolSignal.Connect M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchBoolSignalConnection()
        //{
        //    tlog.Debug(tag, $"WatchBoolSignalConnection START");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new WatchBoolSignal(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchBoolSignal>(testingTarget, "should be an instance of testing target class!");

        //        dummyCallback callback = OnDummyCallback;

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchBoolSignal_Connect' in shared library 'libdali2-csharp-binder.so' */
        //            testingTarget.Connect(callback);
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }
        //    tlog.Debug(tag, $"WatchBoolSignalConnection END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchBoolSignal disconnection.")]
        //[Property("SPEC", "Tizen.NUI.WatchBoolSignal.Disconnect M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchBoolSignalDisconnection()
        //{
        //    tlog.Debug(tag, $"WatchBoolSignalDisconnection START");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new WatchBoolSignal(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchBoolSignal>(testingTarget, "should be an instance of testing target class!");

        //        dummyCallback callback = OnDummyCallback;

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchBoolSignal_Disconnect' in shared library 'libdali2-csharp-binder.so' */
        //            testingTarget.Connect(callback);
        //            testingTarget.Disconnect(callback); 
        //        }
        //        catch (Exception e)
        //        {   
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchBoolSignalDisconnection END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchBoolSignal Emit.")]
        //[Property("SPEC", "Tizen.NUI.WatchBoolSignal.Emit M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchBoolSignalEmit()
        //{
        //    tlog.Debug(tag, $"WatchBoolSignalEmit START");

        //    var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
        //    var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

        //    tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new WatchBoolSignal(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchBoolSignal>(testingTarget, "should be an instance of testing target class!");

        //        Widget widget = new Widget();
        //        var application = new WidgetApplication(widget.GetIntPtr(), false);

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchBoolSignal_Emit' in shared library 'libdali2-csharp-binder.so' */
        //            testingTarget.Emit(application, true);
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        widget.Dispose();
        //        widget = null;

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchBoolSignalEmit END (OK)");         
        //}
    }
}

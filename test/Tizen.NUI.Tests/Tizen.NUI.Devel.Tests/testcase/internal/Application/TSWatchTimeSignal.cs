using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Application/WatchTimeSignal")]
    public class InternalWatchTimeSignalTest
    {
        private const string tag = "NUITEST";
        private delegate bool dummyCallback(IntPtr application);
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
        [Description("WatchTimeSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.WatchTimeSignal.WatchTimeSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeSignalConstructor()
        {
            tlog.Debug(tag, $"WatchTimeSignalConstructor START");

            using (ImageView imageView = new ImageView())
            {
                var testingTarget = new WatchTimeSignal(imageView.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTimeSignal>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WatchTimeSignalConstructor END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("WatchTimeSignal Empty.")]
        //[Property("SPEC", "Tizen.NUI.WatchTimeSignal.Empty M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchTimeSignalEmpty()
        //{
        //    tlog.Debug(tag, $"WatchTimeSignalEmpty START");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new WatchTimeSignal(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchTimeSignal>(testingTarget, "should be an instance of testing target class!");

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchTimeSignal_Empty' in shared library 'libdali2-csharp-binder.so' */
        //            var result = testingTarget.Empty();
        //            Assert.IsTrue(result);
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchTimeSignalEmpty END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchTimeSignal GetConnectionCount.")]
        //[Property("SPEC", "Tizen.NUI.WatchTimeSignal.GetConnectionCount M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchTimeSignalGetConnectionCount()
        //{
        //    tlog.Debug(tag, $"WatchTimeSignalGetConnectionCount START");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new WatchTimeSignal(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchTimeSignal>(testingTarget, "should be an instance of testing target class!");

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchTimeSignal_GetConnectionCount' in shared library 'libdali2-csharp-binder.so' */
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

        //    tlog.Debug(tag, $"WatchTimeSignalGetConnectionCount END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchTimeSignal connection.")]
        //[Property("SPEC", "Tizen.NUI.WatchTimeSignal.Connect M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchTimeSignalConnection()
        //{
        //    tlog.Debug(tag, $"WatchTimeSignalConnection START");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new WatchTimeSignal(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchTimeSignal>(testingTarget, "should be an instance of testing target class!");

        //        dummyCallback callback = OnDummyCallback;

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchTimeSignal_Connect' in shared library 'libdali2-csharp-binder.so' */
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

        //    tlog.Debug(tag, $"WatchTimeSignalConnection END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchTimeSignal disconnection.")]
        //[Property("SPEC", "Tizen.NUI.WatchTimeSignal.Disconnection M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchTimeSignalDisconnection()
        //{
        //    tlog.Debug(tag, $"WatchTimeSignalDisconnection START");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new WatchTimeSignal(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchTimeSignal>(testingTarget, "should be an instance of testing target class!");

        //        dummyCallback callback = OnDummyCallback;
        //        testingTarget.Connect(callback);
        //        testingTarget.Disconnect(callback);
        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchTimeSignalDisconnection END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchTimeSignal Emit.")]
        //[Property("SPEC", "Tizen.NUI.WatchTimeSignal.Emit M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchTimeSignalEmit()
        //{
        //    tlog.Debug(tag, $"WatchTimeSignalEmit START");

        //    var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
        //    var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

        //    tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new WatchTimeSignal(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchTimeSignal>(testingTarget, "should be an instance of testing target class!");

        //        Widget widget = new Widget();
        //        WidgetApplication application = new WidgetApplication(widget.GetIntPtr(), false);
        //        WatchTime watchTime = new WatchTime(widget.GetIntPtr(), false);

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchTimeSignal_Emit' in shared library 'libdali2-csharp-binder.so' */
        //            testingTarget.Emit(application, watchTime);
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        application.Dispose();
        //        watchTime.Dispose();
        //        testingTarget.Dispose();

        //        widget.Dispose();
        //        widget = null;
        //    }

        //    tlog.Debug(tag, $"WatchTimeSignalEmit END (OK)");          
        //}
    }
}

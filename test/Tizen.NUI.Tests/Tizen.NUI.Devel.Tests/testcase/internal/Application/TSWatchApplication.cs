using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using static Tizen.NUI.WatchApplication;
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Application/WatchApplication")]
    public class InternalWatchApplicationTest
    {
        private const string tag = "NUITEST";
        private string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

        internal class MyWatchApplication : WatchApplication
        {
            public MyWatchApplication(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
            { }

            public void OnReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
            {
                base.ReleaseSwigCPtr(swigCPtr);
            }
        }

        private bool IsWearable()
        {
            string value;
            var result = Tizen.System.Information.TryGetValue("tizen.org/feature/profile", out value);
            if (result && value.Equals("wearable"))
            {
                return true;
            }

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
        [Description("WatchApplication constructor.")]
        [Property("SPEC", "Tizen.NUI.WatchApplication.WatchApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationConstructor()
        {
            tlog.Debug(tag, $"WatchApplicationConstructor START");

            using (ImageView imageView = new ImageView())
            {
                var testingTarget = new WatchApplication(imageView.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchApplication>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WatchApplicationConstructor END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("WatchApplication constructor. With WatchApplication.")]
        //[Property("SPEC", "Tizen.NUI.WatchApplication.WatchApplication C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchApplicationConstructorWithApplication()
        //{
        //    tlog.Debug(tag, $"WatchApplicationConstructorWithApplication START");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        WatchApplication watchApplication = new WatchApplication(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(watchApplication, "should be not null");
        //        Assert.IsInstanceOf<WatchApplication>(watchApplication, "should be an instance of testing target class!");

        //        try
        //        {
        //            new WatchApplication(watchApplication);
        //        }
        //        catch (Exception e)
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_new_WatchApplication__SWIG_1' in shared library 'libdali2-csharp-binder.so' */
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        watchApplication.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchApplicationConstructorWithApplication END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("WatchApplication getCPtr.")]
        [Property("SPEC", "Tizen.NUI.WatchApplication.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationgetCPtr()
        {
            tlog.Debug(tag, $"WatchApplicationgetCPtr START");

            using (ImageView imageView = new ImageView())
            {
                var testingTarget = new WatchApplication(imageView.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchApplication>(testingTarget, "should be an instance of testing target class!");

                try
                {
                    WatchApplication.getCPtr(testingTarget);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WatchApplicationgetCPtr END (OK)");
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
        //    tlog.Debug(tag, $"WatchApplicationReleaseSwigCPtr START");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new MyWatchApplication(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchApplication>(testingTarget, "should be an instance of testing target class!");

        //        try
        //        {
        //            testingTarget.OnReleaseSwigCPtr(imageView.SwigCPtr);
        //        }
        //        catch (Exception e)
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_delete_WatchApplication' in shared library 'libdali2-csharp-binder.so' */
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchApplicationReleaseSwigCPtr END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchApplication NewWatchApplication.")]
        //[Property("SPEC", "Tizen.NUI.WatchApplication.NewWatchApplication M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchApplicationNewWatchApplication()
        //{
        //    tlog.Debug(tag, $"WatchApplicationNewWatchApplication START");

        //    try
        //    {
        //        var testingTarget = WatchApplication.NewWatchApplication();
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchApplication>(testingTarget, "should be an instance of testing target class!");
        //    }
        //    catch (Exception e)
        //    {
        //        /** Unable to find an entry point named 'CSharp_Dali_WatchApplication_New__SWIG_0' in shared library 'libdali2-csharp-binder.so' */
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    tlog.Debug(tag, $"WatchApplicationNewWatchApplication END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchApplication NewWatchApplication. With strings")]
        //[Property("SPEC", "Tizen.NUI.WatchApplication.NewWatchApplication M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchApplicationNewWatchApplicationWithStrings()
        //{
        //    tlog.Debug(tag, $"WatchApplicationNewWatchApplicationWithStrings START");

        //    try
        //    {
        //        var dummy = new string[3];
        //        var testingTarget = WatchApplication.NewWatchApplication(dummy);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchApplication>(testingTarget, "should be an instance of testing target class!");

        //        testingTarget.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        /** Unable to find an entry point named 'CSharp_Dali_WatchApplication_New__SWIG_1' in shared library 'libdali2-csharp-binder.so' */
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    tlog.Debug(tag, $"WatchApplicationNewWatchApplicationWithStrings END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchApplication NewWatchApplication. With strings and style.")]
        //[Property("SPEC", "Tizen.NUI.WatchApplication.NewWatchApplication M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchApplicationNewWithStringsAndStylesheet()
        //{
        //    tlog.Debug(tag, $"WatchApplicationNewWithStringsAndStylesheet START");

        //    try
        //    {
        //        var args = new string[] { "Dali-demo" };
        //        var stylesheet = resource + "style/Test_Style_Manager.json";
        //        var testingTarget = WatchApplication.NewWatchApplication(args, stylesheet);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchApplication>(testingTarget, "should be an instance of testing target class!");

        //        testingTarget.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        /** Unable to find an entry point named 'CSharp_Dali_WatchApplication_New__SWIG_2' in shared library 'libdali2-csharp-binder.so' */
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    tlog.Debug(tag, $"WatchApplicationNewWithStringsAndStylesheet END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("WatchApplication.TimeTickEventArgs. Application.")]
        [Property("SPEC", "Tizen.NUI.WatchApplication.TimeTickEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationTimeTickEventArgsApplication()
        {
            tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsApplication START");

            var testingTarget = new TimeTickEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TimeTickEventArgs>(testingTarget, "should be an instance of testing target class!");

            Widget widget = new Widget();
            var application = new WidgetApplication(widget.GetIntPtr(), false);
            testingTarget.Application = application;
            Assert.IsNotNull(testingTarget.Application, "should be not null.");

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsApplication END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WatchApplication.TimeTickEventArgs. WatchTime.")]
        [Property("SPEC", "Tizen.NUI.WatchApplication.TimeTickEventArgs.WatchTime A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationTimeTickEventArgsWatchTime()
        {
            tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsWatchTime START");

            var testingTarget = new TimeTickEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TimeTickEventArgs>(testingTarget, "should be an instance of testing target class!");

            Widget widget = new Widget();
            using (WatchTime time = new WatchTime(widget.GetIntPtr(), false))
            {
                testingTarget.WatchTime = time;
                Assert.IsNotNull(testingTarget.WatchTime);
            }

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsWatchTime END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("WatchApplication.TimeTick.")]
        //[Property("SPEC", "Tizen.NUI.WatchApplication.TimeTick A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchApplicationTimeTick()
        //{
        //    tlog.Debug(tag, $"WatchApplicationTimeTick START");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new WatchApplication(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchApplication>(testingTarget, "should be an instance of testing target class!");

        //        /** Unable to find an entry point named 'CSharp_Dali_WatchApplication_TimeTickSignal' in shared library 'libdali2-csharp-binder.so' */
        //        testingTarget.TimeTick += MyOnTimeTick;
        //        testingTarget.TimeTick -= MyOnTimeTick;

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchApplicationTimeTick END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchApplication.TimeTickSignal.")]
        //[Property("SPEC", "Tizen.NUI.WatchApplication.TimeTickSignal A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchApplicationTimeTickSignal()
        //{
        //    tlog.Debug(tag, $"WatchApplicationTimeTickSignal START");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new WatchApplication(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchApplication>(testingTarget, "should be an instance of testing target class!");

        //        try
        //        {
        //            testingTarget.TimeTickSignal();
        //        }
        //        catch (Exception e)
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchApplication_TimeTickSignal' in shared library 'libdali2-csharp-binder.so' */
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }
        //    }

        //    tlog.Debug(tag, $"WatchApplicationTimeTickSignal END (OK)");
        //}

        private void MyOnTimeTick(object sender, TimeTickEventArgs e) { }

        [Test]
        [Category("P1")]
        [Description("WatchApplication.AmbientTickEventArgs. Application.")]
        [Property("SPEC", "Tizen.NUI.WatchApplication.TimeTickEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationAmbientTickEventArgsApplication()
        {
            tlog.Debug(tag, $"WatchApplicationAmbientTickEventArgsApplication START");

            var testingTarget = new AmbientTickEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AmbientTickEventArgs>(testingTarget, "should be an instance of AmbientTickEventArgs class!");

            Widget widget = new Widget();
            var application = new WidgetApplication(widget.GetIntPtr(), false);
            testingTarget.Application = application;
            Assert.IsNotNull(testingTarget.Application, "should be not null.");

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"WatchApplicationAmbientTickEventArgsApplication END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WatchApplication.AmbientTickEventArgs.WatchTime")]
        [Property("SPEC", "Tizen.NUI.WatchApplication.AmbientTickEventArgs.WatchTime A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationAmbientTickArgsWatchTime()
        {
            tlog.Debug(tag, $"WatchApplicationAmbientTickArgsWatchTime START");

            var testingTarget = new AmbientTickEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AmbientTickEventArgs>(testingTarget, "should be an instance of testing target class!");

            Widget widget = new Widget();
            using (WatchTime time = new WatchTime(widget.GetIntPtr(), false))
            {
                testingTarget.WatchTime = time;
                Assert.IsNotNull(testingTarget.WatchTime);
            }

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"WatchApplicationAmbientTickArgsWatchTime END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("WatchApplication.AmbientTick.")]
        //[Property("SPEC", "Tizen.NUI.WatchApplication.AmbientTick A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchApplicationAmbientTick()
        //{
        //    tlog.Debug(tag, $"WatchApplicationAmbientTick START");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new WatchApplication(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchApplication>(testingTarget, "should be an instance of testing target class!");

        //        /** Unable to find an entry point named 'CSharp_Dali_WatchApplication_AmbientTickSignal' in shared library 'libdali2-csharp-binder.so' */
        //        testingTarget.AmbientTick += MyOnAmbientTick;
        //        testingTarget.AmbientTick -= MyOnAmbientTick;

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchApplicationAmbientTick END (OK)");
        //}

        //private void MyOnAmbientTick(object sender, AmbientTickEventArgs e) { }

        //[Test]
        //[Category("P1")]
        //[Description("WatchApplication.AmbientTickSignal.")]
        //[Property("SPEC", "Tizen.NUI.WatchApplication.AmbientTickSignal A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchApplicationAmbientTickSignal()
        //{
        //    tlog.Debug(tag, $"WatchApplicationAmbientTickSignal START");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new WatchApplication(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchApplication>(testingTarget, "should be an instance of testing target class!");

        //        try
        //        {
        //            testingTarget.AmbientTickSignal();
        //        }
        //        catch (Exception e)
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchApplication_AmbientTickSignal' in shared library 'libdali2-csharp-binder.so' */
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }
        //    }

        //    tlog.Debug(tag, $"WatchApplicationAmbientTickSignal END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("WatchApplication.AmbientChangedEventArgs. Application.")]
        [Property("SPEC", "Tizen.NUI.WatchApplication.TimeTickEventArgs.WatchTime A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationAmbientChangedEventArgsApplication()
        {
            tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsApplication START");

            var testingTarget = new AmbientChangedEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AmbientChangedEventArgs>(testingTarget, "should be an instance of AmbientChangedEventArgs class!");

            Widget widget = new Widget();
            var application = new WidgetApplication(widget.GetIntPtr(), false);
            testingTarget.Application = application;
            Assert.IsNotNull(testingTarget.Application, "should be not null.");

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsApplication END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WatchApplication.AmbientChangedEventArgs. Changed.")]
        [Property("SPEC", "Tizen.NUI.WatchApplication.AmbientChangedEventArgs.Changed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationAmbientChangedEventArgsChangedSet()
        {
            tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsChangedSet START");

            var testingTarget = new AmbientChangedEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AmbientChangedEventArgs>(testingTarget, "should be an instance of AmbientChangedEventArgs class!");

            testingTarget.Changed = true;
            Assert.AreEqual(true, testingTarget.Changed, "Retrieved result should be equal to true. ");

            testingTarget.Changed = false;
            Assert.AreEqual(false, testingTarget.Changed, "Retrieved result should be equal to true. ");

            tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsChangedSet END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("WatchApplication.AmbientChanged.")]
        //[Property("SPEC", "Tizen.NUI.WatchApplication.AmbientChanged A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchApplicationAmbientChanged()
        //{
        //    tlog.Debug(tag, $"WatchApplicationAmbientChanged START");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new WatchApplication(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchApplication>(testingTarget, "should be an instance of testing target class!");

        //        /** Unable to find an entry point named 'CSharp_Dali_WatchApplication_AmbientChangedSignal' in shared library 'libdali2-csharp-binder.so' */
        //        testingTarget.AmbientChanged += MyOnAmbientChanged;
        //        testingTarget.AmbientChanged -= MyOnAmbientChanged;

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchApplicationAmbientChanged END (OK)");
        //}

        //private void MyOnAmbientChanged(object sender, AmbientChangedEventArgs e) { }

        //[Test]
        //[Category("P1")]
        //[Description("WatchApplication.AmbientChangedSignal.")]
        //[Property("SPEC", "Tizen.NUI.WatchApplication.AmbientChangedSignal A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchApplicationAmbientChangedSignal()
        //{
        //    tlog.Debug(tag, $"WatchApplicationAmbientChangedSignal START");

        //    using (ImageView imageView = new ImageView())
        //    {
        //        var testingTarget = new WatchApplication(imageView.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchApplication>(testingTarget, "should be an instance of testing target class!");

        //        try
        //        {
        //            testingTarget.AmbientChangedSignal();
        //        }
        //        catch (Exception e)
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchApplication_AmbientChangedSignal' in shared library 'libdali2-csharp-binder.so' */
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }
        //    }

        //    tlog.Debug(tag, $"WatchApplicationAmbientChangedSignal END (OK)");
        //}
    }
}

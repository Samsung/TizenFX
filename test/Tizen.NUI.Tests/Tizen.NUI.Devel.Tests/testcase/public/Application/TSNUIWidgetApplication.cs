using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using Tizen.Applications;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    public class MyWidget : Widget
    {
        protected override void OnCreate(string contentInfo, Window window)
        {
            window.BackgroundColor = Color.White;
            TextLabel textLabel = new TextLabel("Widget Works");

            window.GetDefaultLayer().Add(textLabel);
            base.OnCreate(contentInfo, window);
        }
    }

    [TestFixture]
    [Description("public/Application/NUIWidgetApplication")]
    public class PublicNUIWidgetApplicationTest
    {
        private const string tag = "NUITEST";

        internal class MyNUIWidgetApplication : NUIWidgetApplication
        {
            public MyNUIWidgetApplication(global::System.Type widgetType) : base(widgetType)
            { }

            public void MyOnCreate() { base.OnCreate(); }

            public void MyOnPreCreate() { base.OnPreCreate(); }

            public void MyOnTerminate() { base.OnTerminate(); }

            public void MyExit() { base.Exit(); }

            public void MyOnLocaleChanged(LocaleChangedEventArgs e) { base.OnLocaleChanged(e); }

            public void MyOnLowBattery(LowBatteryEventArgs e) { base.OnLowBattery(e); }

            public void MyOnLowMemory(LowMemoryEventArgs e) { base.OnLowMemory(e); }

            public void MyOnRegionFormatChanged(RegionFormatChangedEventArgs e) { base.OnRegionFormatChanged(e); }
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
        [Description("NUIWidgetApplication  AddWidgetType System.Type.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.AddWidgetType System.Type M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetApplicationAddWidgetTypeWithSystemType()
        {
            tlog.Debug(tag, $"NUIWidgetApplicationAddWidgetTypeWithSystemType START");

            NUIWidgetApplication widgetApplication = new NUIWidgetApplication(typeof(MyWidget));
            Assert.IsNotNull(widgetApplication, "NUIWidgetApplication can't create successfully.");
            Assert.IsInstanceOf<NUIWidgetApplication>(widgetApplication, "Should be an instance of NUIWidgetApplication type.");
            
            try
            {
                widgetApplication.AddWidgetType(typeof(MyWidget));
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            widgetApplication.Dispose();
            tlog.Debug(tag, $"NUIWidgetApplicationAddWidgetTypeWithSystemType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetApplication  AddWidgetType Dictionary<>.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.AddWidgetType Dictionary<> M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetApplicationAddWidgetTypeWithDictionary()
        {
            tlog.Debug(tag, $"NUIWidgetApplicationAddWidgetTypeWithDictionary START");

            NUIWidgetApplication widgetApplication = new NUIWidgetApplication(typeof(MyWidget));
            Assert.IsNotNull(widgetApplication, "NUIWidgetApplication can't create successfully.");
            Assert.IsInstanceOf<NUIWidgetApplication>(widgetApplication, "Should be an instance of NUIWidgetApplication type.");
            
            try
            {
                Dictionary<Type, string> widgetSet = new Dictionary<Type, string>();
                widgetSet.Add(typeof(MyWidget), "Tizen.NUI.Tests");

                widgetApplication.AddWidgetType(widgetSet);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            widgetApplication.Dispose();
            tlog.Debug(tag, $"NUIWidgetApplicationAddWidgetTypeWithDictionary END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetApplication  ApplicationHandle.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.ApplicationHandle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetApplicationApplicationHandle()
        {
            tlog.Debug(tag, $"NUIWidgetApplicationApplicationHandle START");

            NUIWidgetApplication widgetApplication = new NUIWidgetApplication(typeof(MyWidget));
            Assert.IsNotNull(widgetApplication, "NUIWidgetApplication can't create successfully.");
            Assert.IsInstanceOf<NUIWidgetApplication>(widgetApplication, "Should be an instance of NUIWidgetApplication type.");

            try
            {
                var temp = widgetApplication.ApplicationHandle;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            widgetApplication.Dispose();
            tlog.Debug(tag, $"NUIWidgetApplicationApplicationHandle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetApplication constructor.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.NUIWidgetApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetApplicationConstructor()
        {
            tlog.Debug(tag, $"NUIWidgetApplicationConstructor START");

            var testingTarget = new MyNUIWidgetApplication(typeof(MyWidget));
            Assert.IsNotNull(testingTarget, "MyNUIWidgetApplication can't create successfully.");
            Assert.IsInstanceOf<MyNUIWidgetApplication>(testingTarget, "Should be an instance of MyNUIWidgetApplication type.");

            try
            {
                testingTarget.MyOnCreate();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetApplicationConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetApplication OnPreCreate.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.OnPreCreate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetApplicationOnPreCreate()
        {
            tlog.Debug(tag, $"NUIWidgetApplicationOnPreCreate START");

            var testingTarget = new MyNUIWidgetApplication(typeof(MyWidget));
            Assert.IsNotNull(testingTarget, "MyNUIWidgetApplication can't create successfully.");
            Assert.IsInstanceOf<MyNUIWidgetApplication>(testingTarget, "Should be an instance of MyNUIWidgetApplication type.");

            try
            {
                testingTarget.MyOnPreCreate();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetApplicationOnPreCreate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetApplication OnTerminate.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.OnTerminate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetApplicationOnTerminate()
        {
            tlog.Debug(tag, $"NUIWidgetApplicationOnTerminate START");

            var testingTarget = new MyNUIWidgetApplication(typeof(MyWidget));
            Assert.IsNotNull(testingTarget, "MyNUIWidgetApplication can't create successfully.");
            Assert.IsInstanceOf<MyNUIWidgetApplication>(testingTarget, "Should be an instance of MyNUIWidgetApplication type.");

            try
            {
                testingTarget.MyOnTerminate();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetApplicationOnTerminate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetApplication OnLocaleChanged.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.OnLocaleChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetApplicationOnLocaleChanged()
        {
            tlog.Debug(tag, $"NUIWidgetApplicationOnLocaleChanged START");

            var testingTarget = new MyNUIWidgetApplication(typeof(MyWidget));
            Assert.IsNotNull(testingTarget, "MyNUIWidgetApplication can't create successfully.");
            Assert.IsInstanceOf<MyNUIWidgetApplication>(testingTarget, "Should be an instance of MyNUIWidgetApplication type.");

            try
            {
                testingTarget.MyOnLocaleChanged(new LocaleChangedEventArgs("Shanghai"));
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetApplicationOnLocaleChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetApplication OnLowBattery.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.OnLowBattery M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetApplicationOnLowBattery()
        {
            tlog.Debug(tag, $"NUIWidgetApplicationOnLowBattery START");

            var testingTarget = new MyNUIWidgetApplication(typeof(MyWidget));
            Assert.IsNotNull(testingTarget, "MyNUIWidgetApplication can't create successfully.");
            Assert.IsInstanceOf<MyNUIWidgetApplication>(testingTarget, "Should be an instance of MyNUIWidgetApplication type.");

            try
            {
                LowBatteryStatus status = LowBatteryStatus.None;
                testingTarget.MyOnLowBattery(new LowBatteryEventArgs(status));
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetApplicationOnLowBattery END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetApplication OnLowMemory.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.OnLowMemory M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetApplicationOnLowMemory()
        {
            tlog.Debug(tag, $"NUIWidgetApplicationOnLowMemory START");

            var testingTarget = new MyNUIWidgetApplication(typeof(MyWidget));
            Assert.IsNotNull(testingTarget, "MyNUIWidgetApplication can't create successfully.");
            Assert.IsInstanceOf<MyNUIWidgetApplication>(testingTarget, "Should be an instance of MyNUIWidgetApplication type.");

            try
            {
                LowMemoryStatus status = LowMemoryStatus.None;
                testingTarget.MyOnLowMemory(new LowMemoryEventArgs(status));
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetApplicationOnLowMemory END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetApplication OnRegionFormatChanged.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.OnRegionFormatChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetApplicationOnRegionFormatChanged()
        {
            tlog.Debug(tag, $"NUIWidgetApplicationOnRegionFormatChanged START");

            var testingTarget = new MyNUIWidgetApplication(typeof(MyWidget));
            Assert.IsNotNull(testingTarget, "MyNUIWidgetApplication can't create successfully.");
            Assert.IsInstanceOf<MyNUIWidgetApplication>(testingTarget, "Should be an instance of MyNUIWidgetApplication type.");

            try
            {
                testingTarget.MyOnRegionFormatChanged(new RegionFormatChangedEventArgs("Shanghai"));
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetApplicationOnRegionFormatChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetApplication Exit.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.Exit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetApplicationExit()
        {
            tlog.Debug(tag, $"NUIWidgetApplicationExit START");

            var testingTarget = new MyNUIWidgetApplication(typeof(MyWidget));
            Assert.IsNotNull(testingTarget, "MyNUIWidgetApplication can't create successfully.");
            Assert.IsInstanceOf<MyNUIWidgetApplication>(testingTarget, "Should be an instance of MyNUIWidgetApplication type.");

            try
            {
                testingTarget.MyExit();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetApplicationExit END (OK)");
        }
    }
}

using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Application/NUIWidgetApplication")]

    internal class MyWidget : Widget
    {
        protected override void OnCreate(string contentInfo, Window window)
        {
            window.BackgroundColor = Color.White;
            TextLabel textLabel = new TextLabel("Widget Works");

            window.GetDefaultLayer().Add(textLabel);
            base.OnCreate(contentInfo, window);
        }
    }

    internal class MyNUIWidgetApplication : NUIWidgetApplication
    {
        public MyNUIWidgetApplication(global::System.Type widgetType) : base(widgetType)
        { }

        public void MyOnCreate()
        {
            base.OnCreate();
        }

        public void MyOnTerminate()
        {
            base.OnTerminate();
        }

        public void MyOnLocaleChanged(Applications.LocaleChangedEventArgs e)
        {
            base.OnLocaleChanged(e);
        }

        public void MyOnLowBattery(Applications.LowBatteryEventArgs e)
        {
            base.OnLowBattery(e);
        }

        public void MyOnLowMemory(Applications.LowMemoryEventArgs e)
        {
            base.OnLowMemory(e);
        }

        public void MyOnRegionFormatChanged(Applications.RegionFormatChangedEventArgs e)
        {
            base.OnRegionFormatChanged(e);
        }
    }

    public class PublicNUIWidgetApplicationTest
    {
        private const string tag = "NUITEST";

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

        //[Test]
        //[Category("P1")]
        //[Description("NUIWidgetApplication constructor.")]
        //[Property("SPEC", "Tizen.NUI.NUIWidgetApplication.NUIWidgetApplication C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void NUIWidgetApplicationConstructor()
        //{
        //    tlog.Debug(tag, $"NUIWidgetApplicationConstructor START");

        //    var testingTarget = new NUIWidgetApplication(typeof(MyWidget));
        //    Assert.IsNotNull(testingTarget, "should be not null.");
        //    Assert.IsInstanceOf<NUIWidgetApplication>(testingTarget, "Should be an instance of NUIWidgetApplication type.");

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"NUIWidgetApplicationConstructor END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("NUIWidgetApplication constructor. With stylesheet.")]
        //[Property("SPEC", "Tizen.NUI.NUIWidgetApplication.NUIWidgetApplication C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@partner.samsung.com")]
        //public void NUIWidgetApplicationConstructorWithStylesheet()
        //{
        //    tlog.Debug(tag, $"NUIWidgetApplicationConstructorWithStylesheet START");

        //    var testingTarget = new NUIWidgetApplication(typeof(MyWidget), "stylesheet");
        //    Assert.IsNotNull(testingTarget, "should be not null.");
        //    Assert.IsInstanceOf<NUIWidgetApplication>(testingTarget, "Should be an instance of NUIWidgetApplication type.");

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"NUIWidgetApplicationConstructorWithStylesheet END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("NUIWidgetApplication constructor. With multi class.")]
        //[Property("SPEC", "Tizen.NUI.NUIWidgetApplication.NUIWidgetApplication C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void NUIWidgetApplicationConstructorWithMultiClass()
        //{
        //    tlog.Debug(tag, $"NUIWidgetApplicationConstructorWithMultiClass START");

        //    Dictionary<Type, string> widgetSet = new Dictionary<Type, string>();
        //    widgetSet.Add(typeof(MyWidget), "Tizen.NUI.Tests");

        //    var testingTarget = new NUIWidgetApplication(widgetSet);
        //    Assert.IsNotNull(testingTarget, "should be not null.");
        //    Assert.IsInstanceOf<NUIWidgetApplication>(testingTarget, "Should be an instance of NUIWidgetApplication type.");

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"NUIWidgetApplicationConstructorWithMultiClass END (OK)");
        //}

        //[Test]
        //[Category("P2")]
        //[Description("NUIWidgetApplication constructor. With invalid value.")]
        //[Property("SPEC", "Tizen.NUI.NUIWidgetApplication.NUIWidgetApplication C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void NUIWidgetApplicationConstructorWithNullValue()
        //{
        //    tlog.Debug(tag, $"NUIWidgetApplicationConstructorWithNullValue START");

        //    try
        //    {
        //        Dictionary<Type, string> widgetSet = null;
        //        var testingTarget = new NUIWidgetApplication(widgetSet);
        //    }
        //    catch (InvalidOperationException e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        tlog.Debug(tag, $"NUIWidgetApplicationConstructorWithNullValue END (OK)");
        //        Assert.Pass("Create a NUIWidgetApplication with invalid Dictionary");
        //    }
        //}

        //[Test]
        //[Category("P1")]
        //[Description("NUIWidgetApplication Dispose.")]
        //[Property("SPEC", "Tizen.NUI.NUIWidgetApplication.Dispose M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@partner.samsung.com")]
        //public void NUIWidgetApplicationDispose()
        //{
        //    tlog.Debug(tag, $"NUIWidgetApplicationDispose START");

        //    try
        //    {
        //        var testingTarget = new NUIWidgetApplication(typeof(MyWidget));
        //        Assert.IsNotNull(testingTarget, "should be not null.");
        //        Assert.IsInstanceOf<NUIWidgetApplication>(testingTarget, "Should be an instance of NUIWidgetApplication type.");

        //        testingTarget.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Error(tag, "Caught Exception" + e.ToString());
        //        LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    tlog.Debug(tag, $"NUIWidgetApplicationDispose END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("NUIWidgetApplication AddWidgetType.")]
        //[Property("SPEC", "Tizen.NUI.NUIWidgetApplication.AddWidgetType M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@partner.samsung.com")]
        //public void NUIWidgetApplicationAddWidgetType()
        //{
        //    tlog.Debug(tag, $"NUIWidgetApplicationAddWidgetType START");

        //    var testingTarget = new NUIWidgetApplication(typeof(MyWidget));
        //    Assert.IsNotNull(testingTarget, "should be not null.");
        //    Assert.IsInstanceOf<NUIWidgetApplication>(testingTarget, "Should be an instance of NUIWidgetApplication type.");
            
        //    try
        //    {
        //        testingTarget.AddWidgetType(typeof(MyWidget));
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Error(tag, "Caught Exception" + e.ToString());
        //        LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"NUIWidgetApplicationAddWidgetType END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("NUIWidgetApplication AddWidgetType. With Dictionary.")]
        //[Property("SPEC", "Tizen.NUI.NUIWidgetApplication.AddWidgetType M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@partner.samsung.com")]
        //public void NUIWidgetApplicationAddWidgetTypeWithDictionary()
        //{
        //    tlog.Debug(tag, $"NUIWidgetApplicationAddWidgetTypeWithDictionary START");

        //    var testingTarget = new NUIWidgetApplication(typeof(MyWidget));
        //    Assert.IsNotNull(testingTarget, "should be not null.");
        //    Assert.IsInstanceOf<NUIWidgetApplication>(testingTarget, "Should be an instance of NUIWidgetApplication type.");

        //    try
        //    {
        //        Dictionary<global::System.Type, string> widgetTypes = new Dictionary<Type, string>();
        //        widgetTypes.Add(typeof(MyWidget), "MyWidget");
        //        testingTarget.AddWidgetType(widgetTypes);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Error(tag, "Caught Exception" + e.ToString());
        //        LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"NUIWidgetApplicationAddWidgetTypeWithDictionary END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("NUIWidgetApplication ApplicationHandle.")]
        //[Property("SPEC", "Tizen.NUI.NUIWidgetApplication.ApplicationHandle M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@partner.samsung.com")]
        //public void NUIWidgetApplicationApplicationHandle()
        //{
        //    tlog.Debug(tag, $"NUIWidgetApplicationApplicationHandle START");

        //    var testingTarget = new NUIWidgetApplication(typeof(MyWidget));
        //    Assert.IsNotNull(testingTarget, "should be not null.");
        //    Assert.IsInstanceOf<NUIWidgetApplication>(testingTarget, "Should be an instance of NUIWidgetApplication type.");

        //    try
        //    {
        //        var result =  testingTarget.ApplicationHandle;
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Error(tag, "Caught Exception" + e.ToString());
        //        LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"NUIWidgetApplicationApplicationHandle END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("NUIWidgetApplication OnCreate.")]
        //[Property("SPEC", "Tizen.NUI.NUIWidgetApplication.OnCreate M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@partner.samsung.com")]
        //public void NUIWidgetApplicationOnCreate()
        //{
        //    tlog.Debug(tag, $"NUIWidgetApplicationOnCreate START");

        //    var testingTarget = new MyNUIWidgetApplication(typeof(MyWidget));
        //    Assert.IsNotNull(testingTarget, "should be not null.");
        //    Assert.IsInstanceOf<NUIWidgetApplication>(testingTarget, "Should be an instance of NUIWidgetApplication type.");

        //    try
        //    {
        //        testingTarget.MyOnCreate();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Error(tag, "Caught Exception" + e.ToString());
        //        LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"NUIWidgetApplicationOnCreate END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("NUIWidgetApplication OnLocaleChanged.")]
        //[Property("SPEC", "Tizen.NUI.NUIWidgetApplication.OnLocaleChanged M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@partner.samsung.com")]
        //public void NUIWidgetApplicationOnLocaleChanged()
        //{
        //    tlog.Debug(tag, $"NUIWidgetApplicationOnLocaleChanged START");

        //    var testingTarget = new MyNUIWidgetApplication(typeof(MyWidget));
        //    Assert.IsNotNull(testingTarget, "should be not null.");
        //    Assert.IsInstanceOf<NUIWidgetApplication>(testingTarget, "Should be an instance of NUIWidgetApplication type.");

        //    try
        //    {
        //        testingTarget.MyOnLocaleChanged(new Applications.LocaleChangedEventArgs("BeiJing"));
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Error(tag, "Caught Exception" + e.ToString());
        //        LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"NUIWidgetApplicationOnLocaleChanged END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("NUIWidgetApplication OnLowBattery.")]
        //[Property("SPEC", "Tizen.NUI.NUIWidgetApplication.OnLowBattery M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@partner.samsung.com")]
        //public void NUIWidgetApplicationOnLowBattery()
        //{
        //    tlog.Debug(tag, $"NUIWidgetApplicationOnLowBattery START");

        //    var testingTarget = new MyNUIWidgetApplication(typeof(MyWidget));
        //    Assert.IsNotNull(testingTarget, "should be not null.");
        //    Assert.IsInstanceOf<NUIWidgetApplication>(testingTarget, "Should be an instance of NUIWidgetApplication type.");

        //    try
        //    {
        //        testingTarget.MyOnLowBattery(new Applications.LowBatteryEventArgs(Applications.LowBatteryStatus.PowerOff));
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Error(tag, "Caught Exception" + e.ToString());
        //        LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"NUIWidgetApplicationOnLowBattery END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("NUIWidgetApplication OnLowMemory.")]
        //[Property("SPEC", "Tizen.NUI.NUIWidgetApplication.OnLowMemory M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@partner.samsung.com")]
        //public void NUIWidgetApplicationOnLowMemory()
        //{
        //    tlog.Debug(tag, $"NUIWidgetApplicationOnLowMemory START");

        //    var testingTarget = new MyNUIWidgetApplication(typeof(MyWidget));
        //    Assert.IsNotNull(testingTarget, "should be not null.");
        //    Assert.IsInstanceOf<NUIWidgetApplication>(testingTarget, "Should be an instance of NUIWidgetApplication type.");

        //    try
        //    {
        //        testingTarget.MyOnLowMemory(new Applications.LowMemoryEventArgs(Applications.LowMemoryStatus.Normal));
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Error(tag, "Caught Exception" + e.ToString());
        //        LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"NUIWidgetApplicationOnLowMemory END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("NUIWidgetApplication OnTerminate.")]
        //[Property("SPEC", "Tizen.NUI.NUIWidgetApplication.OnTerminate M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@partner.samsung.com")]
        //public void NUIWidgetApplicationOnTerminate()
        //{
        //    tlog.Debug(tag, $"NUIWidgetApplicationOnTerminate START");

        //    var testingTarget = new MyNUIWidgetApplication(typeof(MyWidget));
        //    Assert.IsNotNull(testingTarget, "should be not null.");
        //    Assert.IsInstanceOf<NUIWidgetApplication>(testingTarget, "Should be an instance of NUIWidgetApplication type.");

        //    try
        //    {
        //        testingTarget.MyOnTerminate();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Error(tag, "Caught Exception" + e.ToString());
        //        LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"NUIWidgetApplicationOnTerminate END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("NUIWidgetApplication OnRegionFormatChanged.")]
        //[Property("SPEC", "Tizen.NUI.NUIWidgetApplication.OnRegionFormatChanged M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@partner.samsung.com")]
        //public void NUIWidgetApplicationOnRegionFormatChanged()
        //{
        //    tlog.Debug(tag, $"NUIWidgetApplicationOnRegionFormatChanged START");

        //    var testingTarget = new MyNUIWidgetApplication(typeof(MyWidget));
        //    Assert.IsNotNull(testingTarget, "should be not null.");
        //    Assert.IsInstanceOf<NUIWidgetApplication>(testingTarget, "Should be an instance of NUIWidgetApplication type.");

        //    try
        //    {
        //        testingTarget.MyOnRegionFormatChanged(new Applications.RegionFormatChangedEventArgs("China"));
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Error(tag, "Caught Exception" + e.ToString());
        //        LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"NUIWidgetApplicationOnRegionFormatChanged END (OK)");
        //}
    }
}

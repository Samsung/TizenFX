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

            var testingTarget = new NUIWidgetApplication(typeof(MyWidget));
            Assert.IsNotNull(testingTarget, "should be not null.");
            Assert.IsInstanceOf<NUIWidgetApplication>(testingTarget, "Should be an instance of NUIWidgetApplication type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetApplicationConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetApplication constructor. With stylesheet.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.NUIWidgetApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@partner.samsung.com")]
        public void NUIWidgetApplicationConstructorWithStylesheet()
        {
            tlog.Debug(tag, $"NUIWidgetApplicationConstructorWithStylesheet START");

            var testingTarget = new NUIWidgetApplication(typeof(MyWidget), "stylesheet");
            Assert.IsNotNull(testingTarget, "should be not null.");
            Assert.IsInstanceOf<NUIWidgetApplication>(testingTarget, "Should be an instance of NUIWidgetApplication type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetApplicationConstructorWithStylesheet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetApplication constructor. With multi class.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.NUIWidgetApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetApplicationConstructorWithMultiClass()
        {
            tlog.Debug(tag, $"NUIWidgetApplicationConstructorWithMultiClass START");

            Dictionary<Type, string> widgetSet = new Dictionary<Type, string>();
            widgetSet.Add(typeof(MyWidget), "Tizen.NUI.Tests");

            var testingTarget = new NUIWidgetApplication(widgetSet);
            Assert.IsNotNull(testingTarget, "should be not null.");
            Assert.IsInstanceOf<NUIWidgetApplication>(testingTarget, "Should be an instance of NUIWidgetApplication type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetApplicationConstructorWithMultiClass END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("NUIWidgetApplication constructor. With invalid value.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.NUIWidgetApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetApplicationConstructorWithNullValue()
        {
            tlog.Debug(tag, $"NUIWidgetApplicationConstructorWithNullValue START");

            try
            {
                Dictionary<Type, string> widgetSet = null;
                var testingTarget = new NUIWidgetApplication(widgetSet);
            }
            catch (InvalidOperationException e)
            {
                Assert.Pass("Create a NUIWidgetApplication with invalid Dictionary");
            }

            tlog.Debug(tag, $"NUIWidgetApplicationConstructorWithNullValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetApplication Dispose.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@partner.samsung.com")]
        public void NUIWidgetApplicationDispose()
        {
            tlog.Debug(tag, $"NUIWidgetApplicationDispose START");

            try
            {
                var testingTarget = new NUIWidgetApplication(typeof(MyWidget));
                Assert.IsNotNull(testingTarget, "should be not null.");
                Assert.IsInstanceOf<NUIWidgetApplication>(testingTarget, "Should be an instance of NUIWidgetApplication type.");

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"NUIWidgetApplicationDispose END (OK)");
        }
    }
}

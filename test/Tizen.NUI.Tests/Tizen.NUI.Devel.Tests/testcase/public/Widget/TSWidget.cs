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
    [Description("public/Widget/Widget")]
    public class PublicWidgetTest
    {
        private const string tag = "NUITEST";
        private Widget widget = null;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            
            widget = new Widget();
            tlog.Debug(tag, "widget.Id : " + widget.Id);
        }

        [TearDown]
        public void Destroy()
        {
            widget.Dispose();
			widget = null;
			
            tlog.Info(tag, "Destroy() is called!");
        }

        internal class MyWidget : Widget
        {
            public MyWidget() : base()
            { }

            public void MyOnCreate(string contentInfo, Window window)
            {
                window.BackgroundColor = Color.White;
                TextLabel textLabel = new TextLabel("Widget Works");

                window.GetDefaultLayer().Add(textLabel);
                base.OnCreate(contentInfo, window);
            }

            public void MyOnTerminate(string contentInfo, Widget.TerminationType type)
            {
                base.OnTerminate(contentInfo, type);
            }

            public void MyOnPause()
            {
                base.OnPause();
            }

            public void MyOnResume()
            {
                base.OnResume();
            }

            public void MyOnResize(Window window)
            {
                base.OnResize(window);
            }

            public void MyOnUpdate(string contentInfo, int force)
            {
                base.OnUpdate(contentInfo, force);
            }
        }

        [Test]
        [Category("P1")]
        [Description("Widget Constructor. With IntPtr.")]
        [Property("SPEC", "Tizen.NUI.Widget.Widget C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetConstructorWithIntPtr()
        {
            tlog.Debug(tag, $"WidgetConstructorWithIntPtr START");

            var testingTarget = new Widget(widget.GetIntPtr(), true);
            Assert.IsNotNull(testingTarget, "Can't create success object Widget");
            Assert.IsInstanceOf<Widget>(testingTarget, "Should be an instance of Widget type.");

            tlog.Debug(tag, $"WidgetConstructorWithIntPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Widget SetContentInfo.")]
        [Property("SPEC", "Tizen.NUI.Widget.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetSetContentInfo()
        {
            tlog.Debug(tag, $"WidgetSetContentInfo START");

            try
            {
                widget.SetContentInfo("PublicWidgetTest");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetSetContentInfo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Widget getCPtr.")]
        [Property("SPEC", "Tizen.NUI.Widget.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetGetCPtr()
        {
            tlog.Debug(tag, $"WidgetGetCPtr START");

            var testingTarget = new Widget(widget.GetIntPtr(), true);
            Assert.IsNotNull(testingTarget, "Can't create success object Widget");
            Assert.IsInstanceOf<Widget>(testingTarget, "Should be an instance of Widget type.");

            var result = Widget.getCPtr(testingTarget);
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"WidgetGetCPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Widget Assign.")]
        [Property("SPEC", "Tizen.NUI.Widget.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetAssign()
        {
            tlog.Debug(tag, $"WidgetAssign START");

            var result = widget.Assign(Activator.CreateInstance(typeof(Widget)) as Widget);
            Assert.IsNotNull(result, "Can't create success object Widget");
            Assert.IsInstanceOf<Widget>(result, "Should be an instance of Widget type.");

            tlog.Debug(tag, $"WidgetAssign END (OK)");
        }
    }
}

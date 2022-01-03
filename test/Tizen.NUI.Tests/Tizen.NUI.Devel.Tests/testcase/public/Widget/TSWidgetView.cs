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
    [Description("public/Widget/WidgetView")]
    public class PublicWidgetViewTest
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
        [Description("WidgetView WidgetAddedSignal.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.WidgetAddedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewWidgetAddedSignal()
        {
            tlog.Debug(tag, $"WidgetViewWidgetAddedSignal START");

            var view = new View()
            {
                Size = new Size(100, 200),
                Color = new Tizen.NUI.Color("#C3CAD5FF"),
            };

            var widgetView = new WidgetView(view.SwigCPtr.Handle, false);
            Assert.IsNotNull(widgetView, "Can't create success object WidgetView");
            Assert.IsInstanceOf<WidgetView>(widgetView, "Should be an instance of WidgetView type.");

            tlog.Debug(tag, " widgetView.ID : " + widgetView.ID);
            tlog.Debug(tag, "widgetView.InstanceID : " + widgetView.InstanceID);
            tlog.Debug(tag, "widgetView.ContentInfo : " + widgetView.ContentInfo);
            tlog.Debug(tag, "widgetView.Title : " + widgetView.Title);
            tlog.Debug(tag, "widgetView.UpdatePeriod : " + widgetView.UpdatePeriod);

            widgetView.Preview = true;
            tlog.Debug(tag, "widgetView.Preview : " + widgetView.Preview);

            widgetView.Preview = false;
            tlog.Debug(tag, "widgetView.Preview : " + widgetView.Preview);

            widgetView.LoadingText = true;
            tlog.Debug(tag, "widgetView.LoadingText : " + widgetView.LoadingText);

            widgetView.LoadingText = false;
            tlog.Debug(tag, "widgetView.LoadingText : " + widgetView.LoadingText);

            widgetView.WidgetStateFaulted = true;
            tlog.Debug(tag, "widgetView.WidgetStateFaulted : " + widgetView.WidgetStateFaulted);

            widgetView.PermanentDelete = false;
            tlog.Debug(tag, "widgetView.PermanentDelete : " + widgetView.PermanentDelete);

            using (PropertyMap retryText = new PropertyMap())
            {
                retryText.Add("stateText", new PropertyValue("RetryTextTest"));
                widgetView.RetryText = retryText;
                tlog.Debug(tag, "widget view retryText: " + widgetView.RetryText);

                using (PropertyMap effect = new PropertyMap())
                {
                    retryText.Add("shader", new PropertyValue("ShaderText"));
                    widgetView.Effect = effect;
                    tlog.Debug(tag, "widget view effect: " + widgetView.Effect);
                }
            }

            try
            {
                WidgetView.GetWidgetViewFromPtr(widgetView.SwigCPtr.Handle);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            try
            {
                widgetView.Assign(widgetView);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            var args = new WidgetView.WidgetViewEventArgs();
            tlog.Debug(tag, "Default args.WidgetView is : " + args.WidgetView);

            args.WidgetView = widgetView;
            tlog.Debug(tag, "args.WidgetView is : " + args.WidgetView);

            try
            {
                widgetView.WidgetAddedSignal();
                widgetView.WidgetContentUpdatedSignal();
                widgetView.WidgetUpdatePeriodChangedSignal();
                widgetView.WidgetCreationAbortedSignal();
                widgetView.WidgetFaultedSignal();
                widgetView.WidgetDeletedSignal();

                try
                {
                    widgetView.ActivateFaultedWidget();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            view.Dispose();
            view = null;

            widgetView = null;
            tlog.Debug(tag, $"WidgetViewWidgetAddedSignal END (OK)");
        }
    }
}

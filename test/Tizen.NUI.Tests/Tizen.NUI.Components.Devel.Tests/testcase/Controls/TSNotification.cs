using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/Notification")]
    public class NotificationTest
    {
        private const string tag = "NUITEST";
        bool isSurfacelessContextSupported = false;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            Tizen.System.Information.TryGetValue("http://tizen.org/feature/opengles.surfaceless_context", out isSurfacelessContextSupported);
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Notification SetLevel.")]
        [Property("SPEC", "Tizen.NUI.Components.Notification.SetLevel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NotificationSetLevel()
        {
            tlog.Debug(tag, $"NotificationSetLevel START");

            if (isSurfacelessContextSupported == false)
            {
                Tizen.Log.Error("NUITEST", "Test skipped! This Device is not support to opengles.surfaceless_context");
                Assert.Pass("Test skipped! This Device is not support to opengles.surfaceless_context");
                return;
            }

            View view = new View();

            var noti = new Notification(view);
            Assert.IsNotNull(noti, "Can't create success object Notification");
            Assert.IsInstanceOf<Notification>(noti, "Should be an instance of Notification type");

            try
            {
                uint duration = 3000;
                noti.Post(duration);
                try
                {
                    noti.SetLevel(NotificationLevel.High);
                    noti.SetPositionSize(new Rectangle(0, 0, 81, 81));
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception" + e.ToString());
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"NotificationSetLevel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Notification SetDismissOnTouch.")]
        [Property("SPEC", "Tizen.NUI.Components.Notification.SetDismissOnTouch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NotificationSetDismissOnTouch()
        {
            tlog.Debug(tag, $"NotificationSetDismissOnTouch START");

            if (isSurfacelessContextSupported == false)
            {
                Tizen.Log.Error("NUITEST", "Test skipped! This Device is not support to opengles.surfaceless_context");
                Assert.Pass("Test skipped! This Device is not support to opengles.surfaceless_context");
                return;
            }

            View view = new View();
            
            var noti = new Notification(view);
            Assert.IsNotNull(noti, "Can't create success object Notification");
            Assert.IsInstanceOf<Notification>(noti, "Should be an instance of Notification type");
         
            var result = noti.SetDismissOnTouch(true);
            tlog.Debug(tag, "SetDismissOnTouch : " + result);

            tlog.Debug(tag, $"NotificationSetDismissOnTouch END (OK)");
        }
    }
}

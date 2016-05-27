using System;
using TestFramework;
using Tizen.Applications;
using Tizen.Applications.Notifications;
using Tizen.UI;

namespace TizenTest.Applications.Notifications
{
    [TestFixture]
    [Description("Notification Api Test")]
    public class TSNotification
    {
        [SetUp]
        public static void Init() {
        }

        [TearDown]
        public static void Destroy() {
        }

        [Test]
        [Category("P1")]
        [Description("Test : Notification's Properties")]
        [Property("SPEC", " Tizen.Applications.Notification A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void Notification_PROPERTIES_SET_GET() {
            /* TEST CODE */
            string title = "title";
            string content = "content";
            string iconPath = "icon";
            string indicatorPath = "indicator";
            string backgroundPath = "background";
            string thumbnailPath = "zzz";
            string subIcon = "subicon";
            string tag = "tag";
            NotificationArea area = NotificationArea.Ticker | NotificationArea.Indicator;
            NotificationType type = NotificationType.Event;
            LedBlinkPeriod period = new LedBlinkPeriod(100, 100);
            bool soundEnabled = true;
            string soundPath = "xxx";
            bool vibrationEnabled = true;
            bool ledEnabled = true;
            Color ledColor = new Color(100, 100, 100, 255);
            bool volatileDisplay = true;
            DateTime date = DateTime.Now;
            string defaultTitle = string.Empty;
            string defaultContent = string.Empty;
            string defaultIconPath = string.Empty;
            string defaultIndicatorPath = string.Empty;
            string defaultBackgroundPath = string.Empty;
            string defaultThumbnailPath = string.Empty;
            string defaultSubIcon = string.Empty;
            string defaultTag = string.Empty;
            NotificationArea defaultArea = NotificationArea.Ticker | NotificationArea.Indicator | NotificationArea.NotificationTray;
            LedBlinkPeriod defaultPeriod = new LedBlinkPeriod(0, 0);
            bool defaultSoundEnabled = false;
            string defaultSoundPath = string.Empty;
            bool defaultVibrationEnabled = false;
            bool defaultLedEnabled = false;
            Color defaultLedColor = new Color(0, 0, 0, 0);
            bool defaultVolatileDisplay = false;
            DateTime defaultDate = new DateTime(1970, 1, 1, 9, 0, 0);

            EventNotification noti = new EventNotification();
            Assert.IsNotNull(noti, "Event Notification should not be null after init");

            Assert.AreEqual(defaultTitle, noti.Title, "Default title should match value from getter");
            noti.Title = title;
            Assert.AreEqual(title, noti.Title, "Set title should match value from getter");

            Assert.AreEqual(defaultContent, noti.Content, "Default content should match value from getter");
            noti.Content = content;
            Assert.AreEqual(content, noti.Content, "Set content should match value from getter");

            Assert.AreEqual(defaultIconPath, noti.IconPath, "Default icon path should match value from getter");
            noti.IconPath = iconPath;
            Assert.AreEqual(iconPath, noti.IconPath, "Set icon path should match value from getter");

            Assert.AreEqual(defaultIndicatorPath, noti.IndicatorIconPath, "Default indicator icon path should match value from getter");
            noti.IndicatorIconPath = indicatorPath;
            Assert.AreEqual(indicatorPath, noti.IndicatorIconPath, "Set indicator icon path should match value from getter");

            Assert.AreEqual(defaultBackgroundPath, noti.BackgroundImagePath, "Default background should match value from getter");
            noti.BackgroundImagePath = backgroundPath;
            Assert.AreEqual(backgroundPath, noti.BackgroundImagePath, "Set background should match value from getter");

            Assert.AreEqual(defaultSubIcon, noti.SubIconPath, "Default sub icon should match value from getter");
            noti.SubIconPath = subIcon;
            Assert.AreEqual(subIcon, noti.SubIconPath, "Set sub icon should match value from getter");

            Assert.AreEqual(defaultThumbnailPath, noti.ThumbnailPath, "Default sub icon should match value from getter");
            noti.ThumbnailPath = thumbnailPath;
            Assert.AreEqual(thumbnailPath, noti.ThumbnailPath, "Set sub icon should match value from getter");

            Assert.AreEqual(defaultTag, noti.Tag, "Default tag should match value from getter");
            noti.Tag = tag;
            Assert.AreEqual(tag, noti.Tag, "Set tag should match value from getter");

            Assert.AreEqual((int)type, (int)noti.NotificationType);

            Assert.True(noti.LedBlinkPeriod.OnTime == defaultPeriod.OnTime && noti.LedBlinkPeriod.OffTime == defaultPeriod.OffTime, "Default led blink period shoudl match value from getter");
            noti.LedBlinkPeriod = period;
            Assert.True(noti.LedBlinkPeriod.OnTime == period.OnTime && noti.LedBlinkPeriod.OffTime == period.OffTime, "Set led blink period shoudl match value from getter");

            Assert.True(noti.SoundEnabled == defaultSoundEnabled, "Default Sound enabled should match value from getter");
            noti.SoundEnabled = soundEnabled;
            Assert.True(noti.SoundEnabled == soundEnabled, "Set Sound enabled should match value from getter");

            Assert.AreEqual(defaultSoundPath, noti.SoundPath, "Default soundpath should match value from getter");
            noti.SoundPath =  soundPath;
            Assert.AreEqual(soundPath, noti.SoundPath, "Set soundpath should match value from getter");

            Assert.True(noti.VibrationEnabled == defaultVibrationEnabled, "Default Vibration enabled should match value from getter");
            noti.VibrationEnabled = vibrationEnabled;
            Assert.True(noti.VibrationEnabled == vibrationEnabled, "Set Vibration enabled should match value from getter");

            Assert.True(noti.LedEnabled == defaultLedEnabled, "Default led enabled should match value from getter");
            noti.LedEnabled = ledEnabled;
            Assert.True(noti.LedEnabled == ledEnabled, "Set led enabled should match value from getter");

            Assert.AreEqual(defaultLedColor.ToString(), noti.LedColor.ToString(), "Default led color should match value from getter");
            noti.LedColor =  ledColor;
            Assert.AreEqual(ledColor.ToString(), noti.LedColor.ToString(), "Set led color should match value from getter");

            Assert.True(defaultVolatileDisplay == noti.VolatileDisplayEnabled, "Default Volatile display should match value from getter");
            noti.VolatileDisplayEnabled = volatileDisplay;
            Assert.True(volatileDisplay == noti.VolatileDisplayEnabled, "Set Volatile display should match value from getter");

            Assert.True((int)defaultArea == (int)noti.NotificationArea, "Default notification area should match value from getter");
            noti.NotificationArea = area;
            Assert.True((int)area == (int)noti.NotificationArea, "Set notification area should match value from getter");

            Assert.True(defaultDate.ToString() == noti.InsertTime.ToString(), "Default insert time should match value from getter");

            try
            {
                NotificationManager.Post(noti);
            }
            catch(Exception)
            {
                Assert.True(false, "NotificationManager.Post should not throw an exception");
            }

            Assert.True(noti.InsertTime.Year == date.Year && noti.InsertTime.Month == date.Month && noti.InsertTime.Day == date.Day && noti.InsertTime.Hour == date.Hour, "Insert date should match date of now");
        }

        [Test]
        [Category("P1")]
        [Description("Set a Launch App Control for a Notification.")]
        [Property("SPEC", "Tizen.Applications.Notification.SetLaunchAppControl M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void SetLaunchAppControl_RETURN_VALUE() {
            /* TEST CODE */
            string appId = "xxx";

            EventNotification noti = new EventNotification();
            Assert.IsNotNull(noti, "Event Notification should not be null after init");

            AppControl app = new AppControl();
            app.ApplicationId = appId;
            try
            {
                noti.SetLaunchAppControl(app);
            }
            catch(Exception)
            {
                Assert.True(false, "SetLaunchAppControl should not throw an exception");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Get an already set launch app control.")]
        [Property("SPEC", "Tizen.Applications.Notification.LaunchAppControl M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void GetLaunchAppControl_RETURN_VALUE() {
            /* TEST CODE */
            string appId = "xxx";

            EventNotification noti = new EventNotification();
            Assert.IsNotNull(noti, "Event Notification should not be null after init");

            AppControl app = new AppControl();
            app.ApplicationId = appId;

            try
            {
                noti.SetLaunchAppControl(app);
            }
            catch(Exception)
            {
                Assert.True(false, "SetLaunchAppControl should not throw an exception");
            }

            try
            {
                Assert.AreEqual(appId, noti.GetLaunchAppControl().ApplicationId, "Returned objects from GetLaunchAppControl should match objects set");
            }
            catch(Exception)
            {
                Assert.True(false, "GetAction should not throw an exception");
            }
        }

        [Test]
        [Category("P2")]
        [Description("Check Set launch control for null argument.")]
        [Property("SPEC", "Tizen.Applications.Notification.SetLaunchAppControl M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void SetLaunchAppControl_CHECK_FOR_NULL_INPUT() {
            /* TEST CODE */
            EventNotification noti = new EventNotification();
            Assert.IsNotNull(noti, "Event Notification should not be null after init");

            try
            {
                noti.SetLaunchAppControl(null);
                Assert.True(false, "SetLaunchAppControl should throw an exception");
            }
            catch(Exception)
            {
                Assert.Pass();
            }
        }
    }
}

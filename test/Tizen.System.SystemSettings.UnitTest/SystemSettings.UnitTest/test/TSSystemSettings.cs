using System.Threading;
using System.Threading.Tasks;
using System;
using Tizen.System;

// /opt/usr/data/settings/Ringtones/ringtone_sdk.mp3
namespace SystemSettingsUnitTest
{

    public static class SystemSettingsTestInput
    {


        private const int nStringDataSize = 100;

        enum eProfileValue
        {
            PROFILE_MOBILE = 0,
            PROFILE_WEARABLE,           //1
            PROFILE_TV,                 //2
            PROFILE_COMMON,             //3
            PROFILE_MAX,

        };
        static string[,] string_data = new string[5, 100];

        public static void InitStringValue()
        {
            string[,] init_data = new string[,] {
                  { //mobile
                   "/opt/usr/data/settings/Ringtones/ringtone_sdk.mp3",
                   "/opt/usr/data/settings/Wallpapers/home_003.png",
                   "/opt/usr/data/settings/Wallpapers/home_003.png",
                },
                { //wearable
                        "/opt/usr/data/settings/Ringtones/Ringtone.ogg",
                   "/opt/usr/data/settings/Wallpaper/BG_preview_02.png",
                   "/opt/usr/data/settings/Wallpaper/BG_preview_02.png",
                },
                { //tv
                        "/opt/usr/data/settings/Ringtones/ringtone_sdk.mp3",
                   "/opt/usr/data/settings/Wallpapers/home_003.png",
                   "/opt/usr/data/settings/Wallpapers/home_003.png",
                },
                { //common
                        "/opt/usr/data/settings/Ringtones/ringtone_sdk.mp3",
                   "/opt/usr/data/settings/Wallpapers/home_003.png",
                   "/opt/usr/data/settings/Wallpapers/home_003.png",
                },
            };

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    string_data[i, j] = init_data[i, j];
                }
            }

            string_data[(int)eProfileValue.PROFILE_MOBILE, (int)Tizen.System.SystemSettingsKeys.SoundNotification] = "/opt/usr/data/settings/Alerts/General notification_sdk.wav";
            string_data[(int)eProfileValue.PROFILE_WEARABLE, (int)Tizen.System.SystemSettingsKeys.SoundNotification] = "/opt/usr/data/settings/Alerts/Notification.ogg";
            string_data[(int)eProfileValue.PROFILE_TV, (int)Tizen.System.SystemSettingsKeys.SoundNotification] = "/opt/usr/data/settings/Alerts/General notification_sdk.wav";
            string_data[(int)eProfileValue.PROFILE_COMMON, (int)Tizen.System.SystemSettingsKeys.SoundNotification] = "/opt/usr/data/settings/Alerts/General notification_sdk.wav";

            string_data[(int)eProfileValue.PROFILE_MOBILE, (int)Tizen.System.SystemSettingsKeys.EmailAlertRingtone] = "/opt/usr/data/settings/Alerts/General notification_sdk.wav";
            string_data[(int)eProfileValue.PROFILE_WEARABLE, (int)Tizen.System.SystemSettingsKeys.EmailAlertRingtone] = "/opt/usr/data/settings/Alerts/Notification.ogg";
            string_data[(int)eProfileValue.PROFILE_TV, (int)Tizen.System.SystemSettingsKeys.EmailAlertRingtone] = "/opt/usr/data/settings/Alerts/General notification_sdk.wav";
            string_data[(int)eProfileValue.PROFILE_COMMON, (int)Tizen.System.SystemSettingsKeys.EmailAlertRingtone] = "/opt/usr/data/settings/Alerts/General notification_sdk.wav";

        }
        static bool isStarted = false;

        public static string GetStringValue(int enum_val)
        {

            if (!isStarted)
            {
                InitStringValue();
                isStarted = true;
            }
            string strProfile;
            eProfileValue profile_val = eProfileValue.PROFILE_MOBILE;
            Information.TryGetValue<string>("tizen.org/feature/profile", out strProfile);
            if (string.Compare(strProfile, "mobile") == 0)
            {
                profile_val = eProfileValue.PROFILE_MOBILE;
            }
            else if (string.Compare(strProfile, "wearable") == 0)
            {
                profile_val = eProfileValue.PROFILE_WEARABLE;
            }
            else if (string.Compare(strProfile, "tv") == 0)
            {
                profile_val = eProfileValue.PROFILE_TV;
            }
            else if (string.Compare(strProfile, "common") == 0)
            {
                profile_val = eProfileValue.PROFILE_COMMON;
            }
            return string_data[(int)profile_val, enum_val];
        }

    }

    //[TestFixture]
    //[Description("Tizen.System.SystemSettings Tests")]
    public static class SystemSettingsTests
    {
        //[SetUp]
        public static void Init()
        {
            //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Preconditions for each TEST");
        }

        //[TearDown]
        public static void Destroy()
        {
            //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Postconditions for each TEST");
        }





        // IncomingCallRingtone
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:IncomingCallRingtone is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.IncomingCallRingtone A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void IncomingCallRingtone_READ_WRITE()
        {
            try {
                LogUtils.StartTest();
                /* TEST CODE */
                Assert.IsInstanceOf<string>(Tizen.System.SystemSettings.IncomingCallRingtone, "IncomingCallRingtone_READ_WRITE: IncomingCallRingtone not an instance of string");
                string preValue = Tizen.System.SystemSettings.IncomingCallRingtone;
                var setValue = SystemSettingsTestInput.GetStringValue((int)Tizen.System.SystemSettingsKeys.IncomingCallRingtone);

                Tizen.System.SystemSettings.IncomingCallRingtone = setValue;
                var getValue = Tizen.System.SystemSettings.IncomingCallRingtone;
                Assert.IsTrue(setValue.CompareTo(getValue) == 0, "IncomingCallRingtone_READ_WRITE: Set value and get value of the property should be same.");
                Tizen.System.SystemSettings.IncomingCallRingtone = preValue;
                LogUtils.WriteOK();
            } catch (NotSupportedException) {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.incoming_call", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.incoming_call)");
                LogUtils.NotSupport();
            }
        }

        private static bool s_incomingCallRingtoneCallbackCalled = false;
        private static readonly string s_incomingCallRingtoneValue = SystemSettingsTestInput.GetStringValue((int) Tizen.System.SystemSettingsKeys.IncomingCallRingtone);
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:IncomingCallRingtoneChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.IncomingCallRingtoneChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task IncomingCallRingtoneChanged_CHECK_EVENT()
        {
            try {
                LogUtils.StartTest();
                /* TEST CODE */
                Tizen.System.SystemSettings.IncomingCallRingtoneChanged += OnIncomingCallRingtoneChanged;
                string preValue = Tizen.System.SystemSettings.IncomingCallRingtone;
                Tizen.System.SystemSettings.IncomingCallRingtone = s_incomingCallRingtoneValue;
                await Task.Delay(2000);
                Assert.IsTrue(s_incomingCallRingtoneCallbackCalled, "IncomingCallRingtoneChanged_CHECK_EVENT: EventHandler added. Not getting called");
                s_incomingCallRingtoneCallbackCalled = false;
                Tizen.System.SystemSettings.IncomingCallRingtoneChanged -= OnIncomingCallRingtoneChanged;
                Tizen.System.SystemSettings.IncomingCallRingtone = s_incomingCallRingtoneValue;
                await Task.Delay(2000);
                Assert.IsFalse(s_incomingCallRingtoneCallbackCalled, "IncomingCallRingtoneChanged_CHECK_EVENT: EventHandler removed. Still getting called");
                Tizen.System.SystemSettings.IncomingCallRingtone = preValue;
                LogUtils.WriteOK();
            } catch (NotSupportedException) {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.incoming_call", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.incoming_call)");
                LogUtils.NotSupport();
            }
        }
        private static void OnIncomingCallRingtoneChanged(object sender, Tizen.System.IncomingCallRingtoneChangedEventArgs e)
        {
            s_incomingCallRingtoneCallbackCalled = true;
            Assert.IsInstanceOf<string>(e.Value, "OnIncomingCallRingtoneChanged: IncomingCallRingtone not an instance of string");
            Assert.IsTrue(s_incomingCallRingtoneValue.CompareTo(e.Value) == 0, "OnIncomingCallRingtoneChanged: The callback should receive the latest value for the property.");
        }

        // WallpaperHomeScreen
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:WallpaperHomeScreen is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.WallpaperHomeScreen A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void WallpaperHomeScreen_READ_WRITE()
        {
            try {
                LogUtils.StartTest();
                /* TEST CODE */
                Assert.IsInstanceOf<string>(Tizen.System.SystemSettings.WallpaperHomeScreen, "WallpaperHomeScreen_READ_WRITE: WallpaperHomeScreen not an instance of string");
                string preValue = Tizen.System.SystemSettings.WallpaperHomeScreen;
                var setValue = SystemSettingsTestInput.GetStringValue((int)Tizen.System.SystemSettingsKeys.WallpaperHomeScreen);

                Tizen.System.SystemSettings.WallpaperHomeScreen = setValue;
                var getValue = Tizen.System.SystemSettings.WallpaperHomeScreen;
                Assert.IsTrue(setValue.CompareTo(getValue) == 0, "WallpaperHomeScreen_READ_WRITE: Set value and get value of the property should be same.");

                string strProfile;
                Information.TryGetValue<string>("tizen.org/feature/profile", out strProfile);
                if (string.Compare(strProfile, "mobile") == 0)
                    Tizen.System.SystemSettings.WallpaperHomeScreen = preValue;

                LogUtils.WriteOK();
            } catch (NotSupportedException) {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.home_screen", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.home_screen)");
                LogUtils.NotSupport();
            }
        }
        
        private static bool s_wallpaperHomeScreenCallbackCalled = false;
        private static readonly string s_wallpaperHomeScreenValue = SystemSettingsTestInput.GetStringValue((int)Tizen.System.SystemSettingsKeys.WallpaperHomeScreen);
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:WallpaperHomeScreenChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.WallpaperHomeScreenChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task WallpaperHomeScreenChanged_CHECK_EVENT()
        {
            try {
                LogUtils.StartTest();
                /* TEST CODE */
                Tizen.System.SystemSettings.WallpaperHomeScreenChanged += OnWallpaperHomeScreenChanged;
                string preValue = Tizen.System.SystemSettings.WallpaperHomeScreen;
                Tizen.System.SystemSettings.WallpaperHomeScreen = s_wallpaperHomeScreenValue;
                await Task.Delay(2000);
                Assert.IsTrue(s_wallpaperHomeScreenCallbackCalled, "WallpaperHomeScreenChanged_CHECK_EVENT: EventHandler added. Not getting called");
                s_wallpaperHomeScreenCallbackCalled = false;
                Tizen.System.SystemSettings.WallpaperHomeScreenChanged -= OnWallpaperHomeScreenChanged;
                Tizen.System.SystemSettings.WallpaperHomeScreen = s_wallpaperHomeScreenValue;
                await Task.Delay(2000);
                Assert.IsFalse(s_wallpaperHomeScreenCallbackCalled, "WallpaperHomeScreenChanged_CHECK_EVENT: EventHandler removed. Still getting called");

                string strProfile;
                Information.TryGetValue<string>("tizen.org/feature/profile", out strProfile);
                if (string.Compare(strProfile, "mobile") == 0)
                    Tizen.System.SystemSettings.WallpaperHomeScreen = preValue;
                LogUtils.WriteOK();
            } catch (NotSupportedException) {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.home_screen", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.home_screen)");
                LogUtils.NotSupport();
            }
        }
        private static void OnWallpaperHomeScreenChanged(object sender, Tizen.System.WallpaperHomeScreenChangedEventArgs e)
        {
            s_wallpaperHomeScreenCallbackCalled = true;
            Assert.IsInstanceOf<string>(e.Value, "OnWallpaperHomeScreenChanged: WallpaperHomeScreen not an instance of string");
            Assert.IsTrue(s_wallpaperHomeScreenValue.CompareTo(e.Value) == 0, "OnWallpaperHomeScreenChanged: The callback should receive the latest value for the property.");
        }

        //WallpaperLockScreen
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:WallpaperLockScreen is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.WallpaperLockScreen A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void WallpaperLockScreen_READ_WRITE()
        {
            try {
                LogUtils.StartTest();
                /* TEST CODE */
                Assert.IsInstanceOf<string>(Tizen.System.SystemSettings.WallpaperLockScreen, "WallpaperLockScreen_READ_WRITE: WallpaperLockScreen not an instance of string");
                string preValue = Tizen.System.SystemSettings.WallpaperLockScreen;
                var setValue = SystemSettingsTestInput.GetStringValue((int)Tizen.System.SystemSettingsKeys.WallpaperLockScreen);
                Tizen.System.SystemSettings.WallpaperLockScreen = setValue;
                var getValue = Tizen.System.SystemSettings.WallpaperLockScreen;
                Assert.IsTrue(setValue.CompareTo(getValue) == 0, "WallpaperLockScreen_READ_WRITE: Set value and get value of the property should be same.");

                string strProfile;
                Information.TryGetValue<string>("tizen.org/feature/profile", out strProfile);
                if (string.Compare(strProfile, "mobile") == 0)
                    Tizen.System.SystemSettings.WallpaperLockScreen = preValue;


                LogUtils.WriteOK();
            } catch (NotSupportedException) {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.lock_screen", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.lock_screen)");
                LogUtils.NotSupport();
            }
        }

        private static bool s_wallpaperLockScreenCallbackCalled = false;
        private static readonly string s_wallpaperLockScreenValue = SystemSettingsTestInput.GetStringValue((int)Tizen.System.SystemSettingsKeys.WallpaperLockScreen);
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:WallpaperLockScreenChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.WallpaperLockScreenChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task WallpaperLockScreenChanged_CHECK_EVENT()
        {
            try {
                LogUtils.StartTest();
                /* TEST CODE */
                Tizen.System.SystemSettings.WallpaperLockScreenChanged += OnWallpaperLockScreenChanged;
                string preValue = Tizen.System.SystemSettings.WallpaperLockScreen;
                Tizen.System.SystemSettings.WallpaperLockScreen = s_wallpaperLockScreenValue;
                await Task.Delay(2000);
                Assert.IsTrue(s_wallpaperLockScreenCallbackCalled, "WallpaperLockScreenChanged_CHECK_EVENT: EventHandler added. Not getting called");
                s_wallpaperLockScreenCallbackCalled = false;
                Tizen.System.SystemSettings.WallpaperLockScreenChanged -= OnWallpaperLockScreenChanged;
                Tizen.System.SystemSettings.WallpaperLockScreen = s_wallpaperLockScreenValue;
                await Task.Delay(2000);
                Assert.IsFalse(s_wallpaperLockScreenCallbackCalled, "WallpaperLockScreenChanged_CHECK_EVENT: EventHandler removed. Still getting called");

                string strProfile;
                Information.TryGetValue<string>("tizen.org/feature/profile", out strProfile);
                if (string.Compare(strProfile, "mobile") == 0)
                    Tizen.System.SystemSettings.WallpaperLockScreen = preValue;

                LogUtils.WriteOK();
            } catch (NotSupportedException) {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.lock_screen", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.lock_screen)");
                LogUtils.NotSupport();
            }
        }
        private static void OnWallpaperLockScreenChanged(object sender, Tizen.System.WallpaperLockScreenChangedEventArgs e)
        {
            s_wallpaperLockScreenCallbackCalled = true;
            Assert.IsInstanceOf<string>(e.Value, "OnWallpaperLockScreenChanged: WallpaperLockScreen not an instance of string");
            Assert.IsTrue(s_wallpaperLockScreenValue.CompareTo(e.Value) == 0, "OnWallpaperLockScreenChanged: The callback should receive the latest value for the property.");
        }

        // FontSize
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:FontSize is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.FontSize A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRE")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void FontSize_READ_WRITE_ALL()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsInstanceOf<Tizen.System.SystemSettingsFontSize>(Tizen.System.SystemSettings.FontSize, "FontSize_READ_WRITE_ALL: FontSize not an instance of SystemSettingsFontSize");
            Thread.Sleep(3000);
            SystemSettingsFontSize preValue = Tizen.System.SystemSettings.FontSize;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Small;
            var getValue = Tizen.System.SystemSettings.FontSize;
            Assert.IsTrue(getValue == Tizen.System.SystemSettingsFontSize.Small, "FontSize_READ_WRITE_ALL: Set value and get value of the property should be same.");

            Thread.Sleep(3000);
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Normal;
            getValue = Tizen.System.SystemSettings.FontSize;
            Assert.IsTrue(getValue == Tizen.System.SystemSettingsFontSize.Normal, "FontSize_READ_WRITE_ALL: Set value and get value of the property should be same.");

            Thread.Sleep(3000);
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Large;
            getValue = Tizen.System.SystemSettings.FontSize;
            Assert.IsTrue(getValue == Tizen.System.SystemSettingsFontSize.Large, "FontSize_READ_WRITE_ALL: Set value and get value of the property should be same.");

            Thread.Sleep(3000);
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Huge;
            getValue = Tizen.System.SystemSettings.FontSize;
            Assert.IsTrue(getValue == Tizen.System.SystemSettingsFontSize.Huge, "FontSize_READ_WRITE_ALL: Set value and get value of the property should be same.");

            Thread.Sleep(3000);
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Giant;
            getValue = Tizen.System.SystemSettings.FontSize;
            Assert.IsTrue(getValue == Tizen.System.SystemSettingsFontSize.Giant, "FontSize_READ_WRITE_ALL: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.FontSize = preValue;
            LogUtils.WriteOK();
        }

        private static bool s_fontSizeSmallCallbackCalled = false;
        private static SystemSettingsFontSize preFontValue;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:FontSizeChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.FontSizeChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task FontSizeChanged_CHECK_EVENT_SMALL()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.FontSizeChanged += OnFontSizeChangedSmall;
            //SystemSettingsFontSize preValue = Tizen.System.SystemSettings.FontSize;
            preFontValue = Tizen.System.SystemSettings.FontSize;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Small;
            await Task.Delay(2000);
            Tizen.System.SystemSettings.FontSizeChanged -= OnFontSizeChangedSmall;
            Assert.IsTrue(s_fontSizeSmallCallbackCalled, "FontSizeChanged_CHECK_EVENT_SMALL: EventHandler added. Not getting called");
            s_fontSizeSmallCallbackCalled = false;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Small;
            await Task.Delay(2000);
            Assert.IsFalse(s_fontSizeSmallCallbackCalled, "FontSizeChanged_CHECK_EVENT_SMALL: EventHandler removed. Still getting called");
            //Tizen.System.SystemSettings.FontSize = preValue;
            LogUtils.WriteOK();
        }
        private static void OnFontSizeChangedSmall(object sender, Tizen.System.FontSizeChangedEventArgs e)
        {
            s_fontSizeSmallCallbackCalled = true;
            Assert.IsInstanceOf<Tizen.System.SystemSettingsFontSize>(e.Value, "OnFontSizeChangedSmall: FontSize not an instance of SystemSettingsFontSize");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsFontSize.Small, "OnFontSizeChangedSmall: The callback should receive the latest value for the property.");
        }

        private static bool s_fontSizeNormalCallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:FontSizeChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.FontSizeChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task FontSizeChanged_CHECK_EVENT_NORMAL()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.FontSizeChanged += OnFontSizeChangedNormal;
            await Task.Delay(2000);
            //SystemSettingsFontSize preValue = Tizen.System.SystemSettings.FontSize;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Normal;
            await Task.Delay(2000);
            Tizen.System.SystemSettings.FontSizeChanged -= OnFontSizeChangedNormal;
            await Task.Delay(2000);
            Assert.IsTrue(s_fontSizeNormalCallbackCalled, "FontSizeChanged_CHECK_EVENT_NORMAL: EventHandler added. Not getting called");
            s_fontSizeNormalCallbackCalled = false;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Normal;
            await Task.Delay(2000);
            Assert.IsFalse(s_fontSizeNormalCallbackCalled, "FontSizeChanged_CHECK_EVENT_NORMAL: EventHandler removed. Still getting called");
            //Tizen.System.SystemSettings.FontSize = preValue;
            LogUtils.WriteOK();
        }
        private static void OnFontSizeChangedNormal(object sender, Tizen.System.FontSizeChangedEventArgs e)
        {
            s_fontSizeNormalCallbackCalled = true;
         //   string format = string.Format("Current Tizen.System.SystemSettings.FontSize : {0} , actual value {1}", Tizen.System.SystemSettings.FontSize, e.Value);
         //   Tizen.Log.Debug("CS-SYSTEM-SETTINGS", format);

            Assert.IsInstanceOf<Tizen.System.SystemSettingsFontSize>(e.Value, "OnFontSizeChangedNormal: FontSize not an instance of SystemSettingsFontSize");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsFontSize.Normal, "OnFontSizeChangedNormal: The callback should receive the latest value for the property.");
        }

        private static bool s_fontSizeLargeCallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:FontSizeChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.FontSizeChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task FontSizeChanged_CHECK_EVENT_LARGE()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.FontSizeChanged += OnFontSizeChangedLarge;
            await Task.Delay(2000);
            //SystemSettingsFontSize preValue = Tizen.System.SystemSettings.FontSize;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Large;
            await Task.Delay(2000);
            Tizen.System.SystemSettings.FontSizeChanged -= OnFontSizeChangedLarge;
            await Task.Delay(2000);
            Assert.IsTrue(s_fontSizeLargeCallbackCalled, "FontSizeChanged_CHECK_EVENT_LARGE: EventHandler added. Not getting called");
            s_fontSizeLargeCallbackCalled = false;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Large;
            await Task.Delay(2000);
            Assert.IsFalse(s_fontSizeLargeCallbackCalled, "FontSizeChanged_CHECK_EVENT_LARGE: EventHandler removed. Still getting called");
            //Tizen.System.SystemSettings.FontSize = preValue;
            LogUtils.WriteOK();
        }
        private static void OnFontSizeChangedLarge(object sender, Tizen.System.FontSizeChangedEventArgs e)
        {
            s_fontSizeLargeCallbackCalled = true;
           //string format = string.Format("Current Tizen.System.SystemSettings.FontSize : {0} , actual value {1}", Tizen.System.SystemSettings.FontSize, e.Value);
           //Tizen.Log.Debug("CS-SYSTEM-SETTINGS", format);

            Assert.IsInstanceOf<Tizen.System.SystemSettingsFontSize>(e.Value, "OnFontSizeChangedLarge: FontSizeChanged not an instance of SystemSettingsFontSize");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsFontSize.Large, "OnFontSizeChangedLarge: The callback should receive the latest value for the property.");
        }

        private static bool s_fontSizeHugeCallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:FontSizeChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.FontSizeChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task FontSizeChanged_CHECK_EVENT_HUGE()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.FontSizeChanged += OnFontSizeChangedHuge;
            await Task.Delay(2000);
            //SystemSettingsFontSize preValue = Tizen.System.SystemSettings.FontSize;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Huge;
            await Task.Delay(2000);
            Tizen.System.SystemSettings.FontSizeChanged -= OnFontSizeChangedHuge;
            await Task.Delay(2000);
            Assert.IsTrue(s_fontSizeHugeCallbackCalled, "FontSizeChanged_CHECK_EVENT_HUGE: EventHandler added. Not getting called");
            s_fontSizeHugeCallbackCalled = false;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Huge;
            await Task.Delay(2000);
            Assert.IsFalse(s_fontSizeHugeCallbackCalled, "FontSizeChanged_CHECK_EVENT_HUGE: EventHandler removed. Still getting called");
            //Tizen.System.SystemSettings.FontSize = preValue;
            LogUtils.WriteOK();
        }
        private static void OnFontSizeChangedHuge(object sender, Tizen.System.FontSizeChangedEventArgs e)
        {
            s_fontSizeHugeCallbackCalled = true;
            //string format = string.Format("Current Tizen.System.SystemSettings.FontSize : {0} , actual value {1}", Tizen.System.SystemSettings.FontSize, e.Value);
            //Tizen.Log.Debug("CS-SYSTEM-SETTINSG", format);

            Assert.IsInstanceOf<Tizen.System.SystemSettingsFontSize>(e.Value, "OnFontSizeChangedHuge: FontSize not an instance of SystemSettingsFontSize");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsFontSize.Huge, "OnFontSizeChangedHuge: The callback should receive the latest value for the property.");
        }

        private static bool s_fontSizeGiantCallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:FontSizeChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.FontSizeChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task FontSizeChanged_CHECK_EVENT_GIANT()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.FontSizeChanged += OnFontSizeChangedGiant;
            await Task.Delay(2000);
            //SystemSettingsFontSize preValue = Tizen.System.SystemSettings.FontSize;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Giant;
            await Task.Delay(2000);
            Tizen.System.SystemSettings.FontSizeChanged -= OnFontSizeChangedGiant;
            await Task.Delay(2000);
            Assert.IsTrue(s_fontSizeGiantCallbackCalled, "FontSizeChanged_CHECK_EVENT_GIANT: EventHandler added. Not getting called");
            s_fontSizeGiantCallbackCalled = false;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Giant;
            await Task.Delay(2000);
            Assert.IsFalse(s_fontSizeGiantCallbackCalled, "FontSizeChanged_CHECK_EVENT_GIANT: EventHandler removed. Still getting called");
            //Tizen.System.SystemSettings.FontSize = preValue;
            Tizen.System.SystemSettings.FontSize = preFontValue;
            LogUtils.WriteOK();
        }
        private static void OnFontSizeChangedGiant(object sender, Tizen.System.FontSizeChangedEventArgs e)
        {
            s_fontSizeGiantCallbackCalled = true;
            //string format = string.Format("Current Tizen.System.SystemSettings.FontSize : {0} , actual value {1}", Tizen.System.SystemSettings.FontSize, e.Value);
            //Tizen.Log.Debug("CS-SYSTEM-SETTINGS", format);

            Assert.IsInstanceOf<Tizen.System.SystemSettingsFontSize>(e.Value, "OnFontSizeChangedGiant: FontSize not an instance of SystemSettingsFontSize");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsFontSize.Giant, "OnFontSizeChangedGiant: The callback should receive the latest value for the property.");
        }

        // FontType
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:FontType is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.FontType A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void FontType_READ_WRITE()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsInstanceOf<string>(Tizen.System.SystemSettings.FontType, "FontType_READ_WRITE: FontType not an instance of string");
            string setValue = "BreezeSans";
            string preValue = Tizen.System.SystemSettings.FontType;

            Thread.Sleep(3000);
            Tizen.System.SystemSettings.FontType = setValue;
            var getValue = Tizen.System.SystemSettings.FontType;
            Assert.IsTrue(getValue.CompareTo(setValue) == 0, "FontType_READ_WRITE: Set value and get value of the property should be same.");
            Thread.Sleep(1000);

            LogUtils.WriteOK();
        }

        private static bool s_fontTypeCallbackCalled = false;
        private static readonly string s_fontTypeValue = "BreezeSans";
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:FontTypeChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.FontTypeChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task FontTypeChanged_CHECK_EVENT()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.FontTypeChanged += OnFontTypeChanged;
            string preValue = Tizen.System.SystemSettings.FontType;
            Tizen.System.SystemSettings.FontType = s_fontTypeValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_fontTypeCallbackCalled, "FontTypeChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_fontTypeCallbackCalled = false;
            Tizen.System.SystemSettings.FontTypeChanged -= OnFontTypeChanged;
            Tizen.System.SystemSettings.FontType = s_fontTypeValue;
            await Task.Delay(2000);
            Assert.IsFalse(s_fontTypeCallbackCalled, "FontTypeChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.FontType = preValue;
            LogUtils.WriteOK();
        }
        private static void OnFontTypeChanged(object sender, Tizen.System.FontTypeChangedEventArgs e)
        {
            s_fontTypeCallbackCalled = true;
            Assert.IsInstanceOf<string>(e.Value, "OnFontTypeChanged: FontType not an instance of string");
            Assert.IsTrue(s_fontTypeValue.CompareTo(e.Value) == 0, "OnFontTypeChanged: The callback should receive the latest value for the property.");
        }

        // MotionActivation
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:MotionActivationEnabled is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.MotionActivationEnabled A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void MotionActivationEnabled_READ_WRITE()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            bool preValue = Tizen.System.SystemSettings.MotionActivationEnabled;
            Assert.IsInstanceOf<bool>(Tizen.System.SystemSettings.MotionActivationEnabled, "MotionActivationEnabled_READ_WRITE: MotionActivationEnabled not an instance of bool");
            Tizen.System.SystemSettings.MotionActivationEnabled = true;
            Assert.IsTrue(Tizen.System.SystemSettings.MotionActivationEnabled, "MotionActivation_READ_WRITE: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.MotionActivationEnabled = false;
            Assert.IsFalse(Tizen.System.SystemSettings.MotionActivationEnabled, "MotionActivation_READ_WRITE: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.MotionActivationEnabled = preValue;
            LogUtils.WriteOK();
        }

        private static bool s_motionActivationCallbackCalled = false;
        private static bool s_motionActivationValue = !Tizen.System.SystemSettings.MotionActivationEnabled;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:MotionActivationSettingChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.MotionActivationSettingChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task MotionActivationSettingChanged_CHECK_EVENT()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.MotionActivationSettingChanged += OnMotionActivationChanged;
            bool preValue = Tizen.System.SystemSettings.MotionActivationEnabled;
            Tizen.System.SystemSettings.MotionActivationEnabled = s_motionActivationValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_motionActivationCallbackCalled, "MotionActivationSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_motionActivationCallbackCalled = false;
            s_motionActivationValue = !s_motionActivationValue;
            Tizen.System.SystemSettings.MotionActivationEnabled = s_motionActivationValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_motionActivationCallbackCalled, "MotionActivationSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_motionActivationCallbackCalled = false;

            Tizen.System.SystemSettings.MotionActivationSettingChanged -= OnMotionActivationChanged;
            Tizen.System.SystemSettings.MotionActivationEnabled = s_motionActivationValue;
            await Task.Delay(2000);
            Assert.IsFalse(s_motionActivationCallbackCalled, "MotionActivationSettingChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.MotionActivationEnabled = preValue;
            LogUtils.WriteOK();
        }
        private static void OnMotionActivationChanged(object sender, Tizen.System.MotionActivationSettingChangedEventArgs e)
        {
            s_motionActivationCallbackCalled = true;
            Assert.IsInstanceOf<bool>(e.Value, "OnMotionActivationChanged: MotionActivationEnabled not an instance of bool");
            Assert.IsTrue(e.Value == s_motionActivationValue, "OnMotionActivationChanged: The callback should receive the latest value for the property.");
        }

        // EmailAlertRingtone
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:EmailAlertRingtone is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.EmailAlertRingtone A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void EmailAlertRingtone_READ_WRITE()
        {
            try {
                LogUtils.StartTest();
                /* TEST CODE */
                Assert.IsInstanceOf<string>(Tizen.System.SystemSettings.EmailAlertRingtone, "EmailAlertRingtone_READ_WRITE: EmailAlertRingtone not an instance of string");
                var setValue = SystemSettingsTestInput.GetStringValue((int)Tizen.System.SystemSettingsKeys.EmailAlertRingtone);
                string preValue = Tizen.System.SystemSettings.EmailAlertRingtone;
                Tizen.System.SystemSettings.EmailAlertRingtone = setValue;
                var getValue = Tizen.System.SystemSettings.EmailAlertRingtone;
                Assert.IsTrue(setValue.CompareTo(getValue) == 0, "EmailAlertRingtone_READ_WRITE: Set value and get value of the property should be same.");
                Tizen.System.SystemSettings.EmailAlertRingtone = preValue;
                LogUtils.WriteOK();
            } catch (NotSupportedException) {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.notification_email", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.notification_email)");
                LogUtils.NotSupport();

            }
        }

        private static bool s_emailAlertRingtoneCallbackCalled = false;
        private static readonly string s_emailAlertRingtoneValue = SystemSettingsTestInput.GetStringValue((int)Tizen.System.SystemSettingsKeys.EmailAlertRingtone);
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:EmailAlertRingtoneChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.EmailAlertRingtoneChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task EmailAlertRingtoneChanged_CHECK_EVENT()
        {
            try {
                LogUtils.StartTest();
                /* TEST CODE */
                Tizen.System.SystemSettings.EmailAlertRingtoneChanged += OnEmailAlertRingtoneChanged;
                string preValue = Tizen.System.SystemSettings.EmailAlertRingtone;
                Tizen.System.SystemSettings.EmailAlertRingtone = s_emailAlertRingtoneValue;
                await Task.Delay(2000);
                Assert.IsTrue(s_emailAlertRingtoneCallbackCalled, "EmailAlertRingtoneChanged_CHECK_EVENT: EventHandler added. Not getting called");
                s_emailAlertRingtoneCallbackCalled = false;
                Tizen.System.SystemSettings.EmailAlertRingtoneChanged -= OnEmailAlertRingtoneChanged;
                Tizen.System.SystemSettings.EmailAlertRingtone = s_emailAlertRingtoneValue;
                await Task.Delay(2000);
                Assert.IsFalse(s_emailAlertRingtoneCallbackCalled, "EmailAlertRingtoneChanged_CHECK_EVENT: EventHandler removed. Still getting called");
                Tizen.System.SystemSettings.EmailAlertRingtone = preValue;
                LogUtils.WriteOK();
            } catch (NotSupportedException) {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.notification_email", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.notification_email)");
                LogUtils.NotSupport();
            }
        }
        private static void OnEmailAlertRingtoneChanged(object sender, Tizen.System.EmailAlertRingtoneChangedEventArgs e)
        {
            s_emailAlertRingtoneCallbackCalled = true;
            Assert.IsInstanceOf<string>(e.Value, "OnEmailAlertRingtoneChanged: EmailAlertRingtone not an instance of string");
            Assert.IsTrue(s_emailAlertRingtoneValue.CompareTo(e.Value) == 0, "OnEmailAlertRingtoneChanged: The callback should receive the latest value for the property.");
        }

        // Data3GNetworkEnabled
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:Data3GNetworkEnabled is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.Data3GNetworkEnabled A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void Data3GNetworkEnabled_READ_WRITE()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            bool preValue = Tizen.System.SystemSettings.Data3GNetworkEnabled;
            Assert.IsInstanceOf<bool>(Tizen.System.SystemSettings.Data3GNetworkEnabled, "Data3GNetworkEnabled_READ_WRITE: Data3GNetworkEnabled not an instance of bool");
            Tizen.System.SystemSettings.Data3GNetworkEnabled = true;
            Assert.IsTrue(Tizen.System.SystemSettings.Data3GNetworkEnabled, "Data3GNetworkEnabled_READ_WRITE: Set value and get value of the property should be same");
            Tizen.System.SystemSettings.Data3GNetworkEnabled = false;
            Assert.IsFalse(Tizen.System.SystemSettings.Data3GNetworkEnabled, "Data3GNetworkEnabled_READ_WRITE: Set value and get value of the property should be same");
            Tizen.System.SystemSettings.Data3GNetworkEnabled = preValue;
            LogUtils.WriteOK();
        }

        private static bool s_data3GNetworkCallbackCalled = false;
        private static bool s_data3GNetworkSettingValue = !Tizen.System.SystemSettings.Data3GNetworkEnabled;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:Data3GNetworkSettingChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.Data3GNetworkSettingChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Data3GNetworkSettingChanged_CHECK_EVENT()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.Data3GNetworkSettingChanged += OnData3GNetworkSettingChanged;
            bool preValue = Tizen.System.SystemSettings.Data3GNetworkEnabled;
            Tizen.System.SystemSettings.Data3GNetworkEnabled = s_data3GNetworkSettingValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_data3GNetworkCallbackCalled, "Data3GNetworkSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");

            s_data3GNetworkSettingValue = !s_data3GNetworkSettingValue;
            s_data3GNetworkCallbackCalled = false;
            Tizen.System.SystemSettings.Data3GNetworkEnabled = s_data3GNetworkSettingValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_data3GNetworkCallbackCalled, "Data3GNetworkSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_data3GNetworkCallbackCalled = false;

            Tizen.System.SystemSettings.Data3GNetworkSettingChanged -= OnData3GNetworkSettingChanged;
            Tizen.System.SystemSettings.Data3GNetworkEnabled = s_data3GNetworkSettingValue;
            await Task.Delay(2000);
            Assert.IsFalse(s_data3GNetworkCallbackCalled, "Data3GNetworkSettingChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.Data3GNetworkEnabled = preValue;
            LogUtils.WriteOK();
        }
        private static void OnData3GNetworkSettingChanged(object sender, Tizen.System.Data3GNetworkSettingChangedEventArgs e)
        {
            s_data3GNetworkCallbackCalled = true;
            Assert.IsInstanceOf<bool>(e.Value, "OnData3GNetworkSettingChanged: Data3GNetworkEnabled not an instance of bool");
            Assert.IsTrue(e.Value == s_data3GNetworkSettingValue, "OnData3GNetworkSettingChanged: The callback should receive the latest value for the property.");
        }

        // LockscreenApp
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:LockscreenApp is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.LockscreenApp A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void LockscreenApp_READ_WRITE()
        {
            try {
                LogUtils.StartTest();
                /* TEST CODE */
                Assert.IsInstanceOf<string>(Tizen.System.SystemSettings.LockScreenApp, "LockscreenApp_READ_WRITE: LockscreenApp not an instance of string");
                var setValue = "org.tizen.lockscreen";
                string preValue = Tizen.System.SystemSettings.LockScreenApp;
                Tizen.System.SystemSettings.LockScreenApp = setValue;
                var getValue = Tizen.System.SystemSettings.LockScreenApp;
                Assert.IsTrue(setValue.CompareTo(getValue) == 0, "LockscreenApp_READ_WRITE: Set value and get value of the property should be same.");
                Tizen.System.SystemSettings.LockScreenApp = preValue;
                LogUtils.WriteOK();
            } catch (NotSupportedException) {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.lock_screen", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.lock_screen)");
                LogUtils.NotSupport();
            }
        }

        private static bool s_lockScreenAppCallbackCalled = false;
        private static readonly string s_lockscreenAppValue = "org.tizen.lockscreen";
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:LockscreenAppChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.LockscreenAppChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task LockscreenAppChanged_CHECK_EVENT()
        {
            try {
                LogUtils.StartTest();
                /* TEST CODE */
                Tizen.System.SystemSettings.LockScreenAppChanged += OnLockscreenAppChanged;
                string preValue = Tizen.System.SystemSettings.LockScreenApp;
                Tizen.System.SystemSettings.LockScreenApp = s_lockscreenAppValue;
                await Task.Delay(2000);
                Assert.IsTrue(s_lockScreenAppCallbackCalled, "LockscreenAppChanged_CHECK_EVENT: EventHandler added. Not getting called");
                s_lockScreenAppCallbackCalled = false;
                Tizen.System.SystemSettings.LockScreenAppChanged -= OnLockscreenAppChanged;
                Tizen.System.SystemSettings.LockScreenApp = s_lockscreenAppValue;
                await Task.Delay(2000);
                Assert.IsFalse(s_lockScreenAppCallbackCalled, "LockscreenAppChanged_CHECK_EVENT: EventHandler removed. Still getting called");
                Tizen.System.SystemSettings.LockScreenApp = preValue;
                LogUtils.WriteOK();
            } catch (NotSupportedException) {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.lock_screen", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.lock_screen)");
                LogUtils.NotSupport();
            }
        }
        private static void OnLockscreenAppChanged(object sender, Tizen.System.LockScreenAppChangedEventArgs e)
        {
            s_lockScreenAppCallbackCalled = true;
            Assert.IsInstanceOf<string>(e.Value, "OnLockscreenAppChanged: LockscreenApp not an instance of string");
            Assert.IsTrue(s_lockscreenAppValue.CompareTo(e.Value) == 0, "OnLockscreenAppChanged: The callback should receive the latest value for the property.");
        }

        // DefaultFontType
        //[Test]
        //[Category("P1")]
        //[Description("Test if get for SystemSettings:DefaultFontType is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.DefaultFontType A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void DefaultFontType_READ_ONLY()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsNotNull(Tizen.System.SystemSettings.DefaultFontType, "DefaultFontType_READ_ONLY: DefaultFontType is null");
            Assert.IsInstanceOf<string>(Tizen.System.SystemSettings.DefaultFontType, "DefaultFontType_READ_ONLY: DefaultFontType not an instance of string");
            LogUtils.WriteOK();
        }

        // LocaleCountry
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:LocaleCountry is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.LocaleCountry A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void LocaleCountry_READ_WRITE()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsInstanceOf<string>(Tizen.System.SystemSettings.LocaleCountry, "LocaleCountry_READ_WRITE: LocaleCountry not an instance of string");
            var setValue = "en_US";
            string preValue = Tizen.System.SystemSettings.LocaleCountry;
            Tizen.System.SystemSettings.LocaleCountry = setValue;
            var getValue = Tizen.System.SystemSettings.LocaleCountry;
            Assert.IsTrue(setValue.CompareTo(getValue) == 0, "LocaleCountry_READ_WRITE: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.LocaleCountry = preValue;
            LogUtils.WriteOK();
        }

        private static bool s_localeCountryCallbackCalled = false;
        private static readonly string s_localeCountryValue = "en_US";
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:LocaleCountryChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.LocaleCountryChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task LocaleCountryChanged_CHECK_EVENT()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.LocaleCountryChanged += OnLocaleCountryChanged;
            string preValue = Tizen.System.SystemSettings.LocaleCountry;
            Tizen.System.SystemSettings.LocaleCountry = s_localeCountryValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_localeCountryCallbackCalled, "LocaleCountryChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_localeCountryCallbackCalled = false;
            Tizen.System.SystemSettings.LocaleCountryChanged -= OnLocaleCountryChanged;
            Tizen.System.SystemSettings.LocaleCountry = s_localeCountryValue;
            await Task.Delay(2000);
            Assert.IsFalse(s_localeCountryCallbackCalled, "LocaleCountryChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.LocaleCountry = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLocaleCountryChanged(object sender, Tizen.System.LocaleCountryChangedEventArgs e)
        {
            s_localeCountryCallbackCalled = true;
            Assert.IsInstanceOf<string>(e.Value, "OnLocaleCountryChanged: LocaleCountry not an instance of string");
            Assert.IsTrue(s_localeCountryValue.CompareTo(e.Value) == 0, "OnLocaleCountryChanged: The callback should receive the latest value for the property.");
        }

        // LocaleLanguage
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:LocaleLanguage is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.LocaleLanguage A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void LocaleLanguage_READ_WRITE()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsInstanceOf<string>(Tizen.System.SystemSettings.LocaleLanguage, "LocaleLanguage_READ_WRITE: LocaleLanguage not an instance of string");
            var setValue = "en_US";
            string preValue = Tizen.System.SystemSettings.LocaleLanguage;
            Tizen.System.SystemSettings.LocaleLanguage = setValue;
            var getValue = Tizen.System.SystemSettings.LocaleLanguage;
            Assert.IsTrue(setValue.CompareTo(getValue) == 0, "LocaleLanguage_READ_WRITE: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.LocaleLanguage = preValue;
            LogUtils.WriteOK();
        }

        private static bool s_localeLanguageCallbackCalled = false;
        private static readonly string s_localeLanguageValue = "en_US";
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:LocaleLanguageChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.LocaleLanguageChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task LocaleLanguageChanged_CHECK_EVENT()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.LocaleLanguageChanged += OnLocaleLanguageChanged;
            string preValue = Tizen.System.SystemSettings.LocaleLanguage;
            Tizen.System.SystemSettings.LocaleLanguage = s_localeLanguageValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_localeLanguageCallbackCalled, "LocaleLanguageChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_localeLanguageCallbackCalled = false;
            Tizen.System.SystemSettings.LocaleLanguageChanged -= OnLocaleLanguageChanged;
            Tizen.System.SystemSettings.LocaleLanguage = s_localeLanguageValue;
            await Task.Delay(2000);
            Assert.IsFalse(s_localeLanguageCallbackCalled, "LocaleLanguageChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.LocaleLanguage = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLocaleLanguageChanged(object sender, Tizen.System.LocaleLanguageChangedEventArgs e)
        {
            s_localeLanguageCallbackCalled = true;
            Assert.IsInstanceOf<string>(e.Value, "OnLocaleLanguageChanged: LocaleLanguage not an instance of string");
            Assert.IsTrue(s_localeLanguageValue.CompareTo(e.Value) == 0, "OnLocaleLanguageChanged: The callback should receive the latest value for the property.");
        }

        // LocaleTimeformat24Hour
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:LocaleTimeFormat24HourEnabled is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void LocaleTimeFormat24HourEnabled_READ_WRITE()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            bool preValue = Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled;
            Assert.IsInstanceOf<bool>(Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled, "LocaleTimeFormat24HourEnabled_READ_WRITE: LocaleTimeFormat24HourEnabled not an instance of bool");
            Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled = true;
            Assert.IsTrue(Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled, "LocaleTimeformat24Hour_READ_WRITE: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled = false;
            Assert.IsFalse(Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled, "LocaleTimeformat24Hour_READ_WRITE: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled = preValue;
            LogUtils.WriteOK();
        }

        private static bool s_timeFormatCallbackCalled = false;
        private static bool s_localeTimeformat24HourValue = !Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:LocaleTimeFormat24HourSettingChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.LocaleTimeFormat24HourSettingChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task LocaleTimeFormat24HourSettingChanged_CHECK_EVENT()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.LocaleTimeFormat24HourSettingChanged += OnLocaleTimeformat24HourChanged;
            bool preValue = Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled;
            Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled = s_localeTimeformat24HourValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_timeFormatCallbackCalled, "LocaleTimeFormat24HourSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_timeFormatCallbackCalled = false;

            s_localeTimeformat24HourValue = !s_localeTimeformat24HourValue;
            Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled = s_localeTimeformat24HourValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_timeFormatCallbackCalled, "LocaleTimeFormat24HourSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_timeFormatCallbackCalled = false;

            Tizen.System.SystemSettings.LocaleTimeFormat24HourSettingChanged -= OnLocaleTimeformat24HourChanged;
            Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled = s_localeTimeformat24HourValue;
            await Task.Delay(2000);
            Assert.IsFalse(s_timeFormatCallbackCalled, "LocaleTimeFormat24HourSettingChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled = preValue;
            LogUtils.WriteOK();
        }

        private static void OnLocaleTimeformat24HourChanged(object sender, Tizen.System.LocaleTimeFormat24HourSettingChangedEventArgs e)
        {
            s_timeFormatCallbackCalled = true;
            Assert.IsInstanceOf<bool>(e.Value, "OnLocaleTimeformat24HourChanged: LocaleTimeFormat24HourEnabled not an instance of bool");
            Assert.IsTrue(e.Value == s_localeTimeformat24HourValue, "OnLocaleTimeformat24HourChanged: The callback should receive the latest value for the property.");
        }

        // LocaleTimezone
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:LocaleTimeZone is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.LocaleTimeZone A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void LocaleTimeZone_READ_WRITE()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsInstanceOf<string>(Tizen.System.SystemSettings.LocaleTimeZone, "LocaleTimeZone_READ_WRITE: LocaleTimeZone not an instance of string");
            //var setValue = "Pacific/Tahiti";
            var setValue = "Asia/Seoul";
            string preValue = Tizen.System.SystemSettings.LocaleTimeZone;
            Tizen.System.SystemSettings.LocaleTimeZone = setValue;
            var getValue = Tizen.System.SystemSettings.LocaleTimeZone;
            Assert.IsTrue(setValue.CompareTo(getValue) == 0, "LocaleTimezone_READ_WRITE: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.LocaleTimeZone = preValue;
            LogUtils.WriteOK();
        }

        private static bool s_localeTimeZoneCallbackCalled = false;
        private static readonly string s_localeTimeZoneValue = "Asia/Seoul";
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:LocaleTimeZoneChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.LocaleTimeZoneChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task LocaleTimeZoneChanged_CHECK_EVENT()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.LocaleTimeZoneChanged += OnLocaleTimeZoneChanged;
            string preValue = Tizen.System.SystemSettings.LocaleTimeZone;
            Tizen.System.SystemSettings.LocaleTimeZone = s_localeTimeZoneValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_localeTimeZoneCallbackCalled, "LocaleTimeZoneChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_localeTimeZoneCallbackCalled = false;

            Tizen.System.SystemSettings.LocaleTimeZoneChanged -= OnLocaleTimeZoneChanged;
            Tizen.System.SystemSettings.LocaleTimeZone = s_localeTimeZoneValue;
            await Task.Delay(2000);
            Assert.IsFalse(s_localeTimeZoneCallbackCalled, "LocaleTimeZoneChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.LocaleTimeZone = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLocaleTimeZoneChanged(object sender, Tizen.System.LocaleTimeZoneChangedEventArgs e)
        {
            s_localeTimeZoneCallbackCalled = true;
            Assert.IsInstanceOf<string>(e.Value, "OnLocaleTimeZoneChanged: LocaleTimeZone not an instance of string");
            Assert.IsTrue(s_localeTimeZoneValue.CompareTo(e.Value) == 0, "OnLocaleTimezoneChanged: The callback should receive the latest value for the property.");
        }

        // SoundLock
        //[Test]
        //[Category("P1")]
        //[Description("Test if get for SystemSettings:SoundLockEnabled is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.SoundLockEnabled A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void SoundLockEnabled_READ_ONLY()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsInstanceOf<bool>(Tizen.System.SystemSettings.SoundLockEnabled, "SoundLockEnabled_READ_ONLY: SoundLockEnabled not an instance of bool");
            LogUtils.WriteOK();
        }

        // SoundSilentMode
        //[Test]
        //[Category("P1")]
        //[Description("Test if get for SystemSettings:SoundSilentModeEnabled is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.SoundSilentModeEnabled A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void SoundSilentModeEnabled_READ_ONLY()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsInstanceOf<bool>(Tizen.System.SystemSettings.SoundSilentModeEnabled, "SoundSilentModeEnabled_READ_ONLY: SoundSilentModeEnabled not an instance of bool");
            LogUtils.WriteOK();
        }

        // SoundTouch
        //[Test]
        //[Category("P1")]
        //[Description("Test if get for SystemSettings:SoundTouchEnabled is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.SoundTouchEnabled A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void SoundTouchEnabled_READ_ONLY()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsInstanceOf<bool>(Tizen.System.SystemSettings.SoundTouchEnabled, "SoundTouchEnabled_READ_ONLY: SoundTouchEnabled not an instance of bool");
            LogUtils.WriteOK();
        }

        // DisplayScreenRotationAuto
        //[Test]
        //[Category("P1")]
        //[Description("Test if get for SystemSettings:DisplayScreenRotationAutoEnabled is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.DisplayScreenRotationAutoEnabled A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void DisplayScreenRotationAutoEnabled_READ_ONLY()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsInstanceOf<bool>(Tizen.System.SystemSettings.DisplayScreenRotationAutoEnabled, "DisplayScreenRotationAutoEnabled_READ_ONLY: DisplayScreenRotationAutoEnabled not an instance of bool");
            LogUtils.WriteOK();
        }

        // DeviceName
        //[Test]
        //[Category("P1")]
        //[Description("Test if get for SystemSettings:DeviceName is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.DeviceName A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void DeviceName_READ_ONLY()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsNotNull(Tizen.System.SystemSettings.DeviceName, "DeviceName_READ_ONLY: DeviceName is null");
            Assert.IsInstanceOf<string>(Tizen.System.SystemSettings.DeviceName, "DeviceName_READ_ONLY: DeviceName not an instance of string");
            Assert.IsFalse(Tizen.System.SystemSettings.DeviceName.CompareTo("") == 0, "DeviceName_READ_ONLY: Device name is empty");
            LogUtils.WriteOK();
        }

        // MotionEnabled
        //[Test]
        //[Category("P1")]
        //[Description("Test if get for SystemSettings:MotionEnabled is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.MotionEnabled A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void MotionEnabled_READ_ONLY()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsInstanceOf<bool>(Tizen.System.SystemSettings.MotionEnabled, "MotionEnabled_READ_ONLY: MotionEnabled not an instance of bool");
            LogUtils.WriteOK();
        }

        // NetworkWifiNotification
        //[Test]
        //[Category("P1")]
        //[Description("Test if get for SystemSettings:NetworkWifiNotificationEnabled is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.NetworkWifiNotificationEnabled A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void NetworkWifiNotificationEnabled_READ_ONLY()
        {
            /* TEST CODE */
            try
            {
                LogUtils.StartTest();
                Assert.IsInstanceOf<bool>(Tizen.System.SystemSettings.NetworkWifiNotificationEnabled, "NetworkWifiNotificationEnabled_READ_ONLY: NetworkWifiNotificationEnabled not an instance of bool");
                LogUtils.WriteOK();
            } catch (NotSupportedException) {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/network.wifi", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.wifi)");
                LogUtils.NotSupport();
            }
        }

        // NetworkFlightMode
        //[Test]
        //[Category("P1")]
        //[Description("Test if get for SystemSettings:NetworkFlightModeEnabled is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.NetworkFlightModeEnabled A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void NetworkFlightModeEnabled_READ_ONLY()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsInstanceOf<bool>(Tizen.System.SystemSettings.NetworkFlightModeEnabled, "NetworkFlightModeEnabled_READ_ONLY: NetworkFlightModeEnabled not an instance of bool");
            LogUtils.WriteOK();
        }

        // ScreenBacklightTime
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:ScreenBacklightTime is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.ScreenBacklightTime A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void ScreenBacklightTime_READ_WRITE_ALL()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsInstanceOf<int>(Tizen.System.SystemSettings.ScreenBacklightTime, "ScreenBacklightTime_READ_WRITE_ALL: ScreenBacklightTime not an instance of int");
            var setValue = 15;
            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = setValue;
            var getValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Assert.IsTrue(setValue == getValue, "ScreenBacklightTime_READ_WRITE_ALL: Set value and get value of the property should be same.");

            setValue = 30;
            Tizen.System.SystemSettings.ScreenBacklightTime = setValue;
            getValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Assert.IsTrue(setValue == getValue, "ScreenBacklightTime_READ_WRITE_ALL: Set value and get value of the property should be same.");

            setValue = 60;
            Tizen.System.SystemSettings.ScreenBacklightTime = setValue;
            getValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Assert.IsTrue(setValue == getValue, "ScreenBacklightTime_READ_WRITE_ALL: Set value and get value of the property should be same.");

            setValue = 120;
            Tizen.System.SystemSettings.ScreenBacklightTime = setValue;
            getValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Assert.IsTrue(setValue == getValue, "ScreenBacklightTime_READ_WRITE_ALL: Set value and get value of the property should be same.");

            setValue = 300;
            Tizen.System.SystemSettings.ScreenBacklightTime = setValue;
            getValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Assert.IsTrue(setValue == getValue, "ScreenBacklightTime_READ_WRITE_ALL: Set value and get value of the property should be same.");

            setValue = 600;
            Tizen.System.SystemSettings.ScreenBacklightTime = setValue;
            getValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Assert.IsTrue(setValue == getValue, "ScreenBacklightTime_READ_WRITE_ALL: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();
        }
        private static bool s_screenBacklightTime15CallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:ScreenBacklightTimeChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.ScreenBacklightTimeChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task ScreenBacklightTimeChanged_CHECK_EVENT_15()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime15Changed;
            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 15;
            await Task.Delay(2000);
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime15Changed;
            Assert.IsTrue(s_screenBacklightTime15CallbackCalled, "ScreenBacklightTimeChanged_CHECK_EVENT_15: EventHandler added. Not getting called");
            s_screenBacklightTime15CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();
        }
        private static void OnScreenBacklightTime15Changed(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_screenBacklightTime15CallbackCalled = true;
            Assert.IsInstanceOf<int>(e.Value, "OnScreenBacklightTime15Changed: ScreenBacklightTime not an instance of int");
            Assert.IsTrue(e.Value == 15, "OnScreenBacklightTime15Changed: The callback should receive the latest value for the property.");
        }

        private static bool s_screenBacklightTime30CallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:ScreenBacklightTimeChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.ScreenBacklightTimeChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task ScreenBacklightTimeChanged_CHECK_EVENT_30()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime30Changed;
            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 30;
            await Task.Delay(2000);
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime30Changed;
            Assert.IsTrue(s_screenBacklightTime30CallbackCalled, "ScreenBacklightTimeChanged_CHECK_EVENT_30: EventHandler added. Not getting called");
            s_screenBacklightTime30CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();
        }
        private static void OnScreenBacklightTime30Changed(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_screenBacklightTime30CallbackCalled = true;
            Assert.IsInstanceOf<int>(e.Value, "OnScreenBacklightTime30Changed: ScreenBacklightTime not an instance of int");
            Assert.IsTrue(e.Value == 30, "OnScreenBacklightTime30Changed: The callback should receive the latest value for the property.");
        }

        private static bool s_screenBacklightTime60CallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:ScreenBacklightTimeChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.ScreenBacklightTimeChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task ScreenBacklightTimeChanged_CHECK_EVENT_60()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime60Changed;
            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 60;
            await Task.Delay(2000);
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime60Changed;
            Assert.IsTrue(s_screenBacklightTime60CallbackCalled, "ScreenBacklightTimeChanged_CHECK_EVENT_60: EventHandler added. Not getting called");
            s_screenBacklightTime60CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();
        }
        private static void OnScreenBacklightTime60Changed(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_screenBacklightTime60CallbackCalled = true;
            Assert.IsInstanceOf<int>(e.Value, "OnScreenBacklightTime60Changed: ScreenBacklightTime not an instance of int");
            Assert.IsTrue(e.Value == 60, "OnScreenBacklightTime60Changed: The callback should receive the latest value for the property.");
        }

        private static bool s_screenBacklightTime120CallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:ScreenBacklightTimeChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.ScreenBacklightTimeChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task ScreenBacklightTimeChanged_CHECK_EVENT_120()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime120Changed;
            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 120;
            await Task.Delay(2000);
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime120Changed;
            Assert.IsTrue(s_screenBacklightTime120CallbackCalled, "ScreenBacklightTimeChanged_CHECK_EVENT_120: EventHandler added. Not getting called");
            s_screenBacklightTime120CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();
        }
        private static void OnScreenBacklightTime120Changed(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_screenBacklightTime120CallbackCalled = true;
            Assert.IsInstanceOf<int>(e.Value, "OnScreenBacklightTime120Changed: ScreenBacklightTime not an instance of int");
            Assert.IsTrue(e.Value == 120, "OnScreenBacklightTime120Changed: The callback should receive the latest value for the property.");
        }

        private static bool s_screenBacklightTime300CallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:ScreenBacklightTimeChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.ScreenBacklightTimeChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task ScreenBacklightTimeChanged_CHECK_EVENT_300()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime300Changed;
            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 300;
            await Task.Delay(2000);
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime300Changed;
            Assert.IsTrue(s_screenBacklightTime300CallbackCalled, "ScreenBacklightTimeChanged_CHECK_EVENT_300: EventHandler added. Not getting called");
            s_screenBacklightTime300CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();
        }
        private static void OnScreenBacklightTime300Changed(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_screenBacklightTime300CallbackCalled = true;
            Assert.IsInstanceOf<int>(e.Value, "OnScreenBacklightTime300Changed: ScreenBacklightTime not an instance of int");
            Assert.IsTrue(e.Value == 300, "OnScreenBacklightTime300Changed: The callback should receive the latest value for the property.");
        }

        private static bool s_screenBacklightTime600CallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:ScreenBacklightTimeChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.ScreenBacklightTimeChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task ScreenBacklightTimeChanged_CHECK_EVENT_600()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime600Changed;
            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 600;
            await Task.Delay(2000);
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime600Changed;
            Assert.IsTrue(s_screenBacklightTime600CallbackCalled, "ScreenBacklightTimeChanged_CHECK_EVENT_600: EventHandler added. Not getting called");
            s_screenBacklightTime600CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();
        }
        private static void OnScreenBacklightTime600Changed(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_screenBacklightTime600CallbackCalled = true;
            Assert.IsInstanceOf<int>(e.Value, "OnScreenBacklightTime600Changed: ScreenBacklightTime not an instance of int");
            Assert.IsTrue(e.Value == 600, "OnScreenBacklightTime600Changed; The callback should receive the latest value for the property.");
        }

        // SoundNotification
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:SoundNotification is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.SoundNotification A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void SoundNotification_READ_WRITE()
        {
            try {
                LogUtils.StartTest();
                /* TEST CODE */
                Assert.IsInstanceOf<string>(Tizen.System.SystemSettings.SoundNotification, "SoundNotification_READ_WRITE: SoundNotification not an instance of string");
                var setValue = SystemSettingsTestInput.GetStringValue((int)Tizen.System.SystemSettingsKeys.SoundNotification);
                string preValue = Tizen.System.SystemSettings.SoundNotification;
                Tizen.System.SystemSettings.SoundNotification = setValue;
                var getValue = Tizen.System.SystemSettings.SoundNotification;
                Assert.IsTrue(setValue.CompareTo(getValue) == 0, "SoundNotification_READ_WRITE: Set value and get value of the property should be same.");
                Tizen.System.SystemSettings.SoundNotification = preValue;
                LogUtils.WriteOK();
            } catch (NotSupportedException) {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.incoming_call", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.incoming_call)");
                LogUtils.NotSupport();
            }
        }

        private static bool s_soundNotificationCallbackCalled = false;
        private static readonly string s_soundNotificationValue = SystemSettingsTestInput.GetStringValue((int)Tizen.System.SystemSettingsKeys.SoundNotification);
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:SoundNotificationChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.SoundNotificationChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task SoundNotificationChanged_CHECK_EVENT()
        {
            try {
                LogUtils.StartTest();
                /* TEST CODE */
                Tizen.System.SystemSettings.SoundNotificationChanged += OnSoundNotificationChanged;
                string preValue = Tizen.System.SystemSettings.SoundNotification;
                Tizen.System.SystemSettings.SoundNotification = s_soundNotificationValue;
                await Task.Delay(2000);
                Assert.IsTrue(s_soundNotificationCallbackCalled, "SoundNotificationChanged_CHECK_EVENT: EventHandler added. Not getting called");

                s_soundNotificationCallbackCalled = false;
                Tizen.System.SystemSettings.SoundNotificationChanged -= OnSoundNotificationChanged;
                Tizen.System.SystemSettings.SoundNotification = s_soundNotificationValue;
                await Task.Delay(2000);
                Assert.IsFalse(s_soundNotificationCallbackCalled, "SoundNotificationChanged_CHECK_EVENT: EventHandler removed. Still getting called");
                Tizen.System.SystemSettings.SoundNotification = preValue;
                LogUtils.WriteOK();
            } catch (NotSupportedException) {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.incoming_call", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.incoming_call)");
                LogUtils.NotSupport();
            }
        }
        private static void OnSoundNotificationChanged(object sender, Tizen.System.SoundNotificationChangedEventArgs e)
        {
            s_soundNotificationCallbackCalled = true;
            Assert.IsInstanceOf<string>(e.Value, "OnSoundNotificationChanged: SoundNotification not an instance of string");
            Assert.IsTrue(s_soundNotificationValue.CompareTo(e.Value) == 0, "OnSoundNotificationChanged: The callback should receive the latest value for the property.");
        }

        // SoundNotificationRepetitionPeriod
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:SoundNotificationRepetitionPeriod is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.SoundNotificationRepetitionPeriod A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void SoundNotificationRepetitionPeriod_READ_WRITE()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsInstanceOf<int>(Tizen.System.SystemSettings.SoundNotificationRepetitionPeriod, "SoundNotificationRepetitionPeriod_READ_WRITE: SoundNotificationRepetitionPeriod not an instance of int");
            var setValue = 300;
            int preValue = Tizen.System.SystemSettings.SoundNotificationRepetitionPeriod;
            Tizen.System.SystemSettings.SoundNotificationRepetitionPeriod = setValue;
            var getValue = Tizen.System.SystemSettings.SoundNotificationRepetitionPeriod;
            Assert.IsTrue(setValue.CompareTo(getValue) == 0, "SoundNotificationRepetitionPeriod_READ_WRITE: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.SoundNotificationRepetitionPeriod = preValue;
            LogUtils.WriteOK();
        }

        private static bool s_soundNotificationRepetitionPeriodCallbackCalled = false;
        private static readonly int s_soundNotificationRepetitionPeriodValue = 300;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:SoundNotificationRepetitionPeriodChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.SoundNotificationRepetitionPeriodChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task SoundNotificationRepetitionPeriodChanged_CHECK_EVENT()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.SoundNotificationRepetitionPeriodChanged += OnSoundNotificationRepetitionPeriodChanged;
            int preValue = Tizen.System.SystemSettings.SoundNotificationRepetitionPeriod;
            Tizen.System.SystemSettings.SoundNotificationRepetitionPeriod = s_soundNotificationRepetitionPeriodValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_soundNotificationRepetitionPeriodCallbackCalled, "SoundNotificationRepetitionPeriodChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_soundNotificationRepetitionPeriodCallbackCalled = false;

            Tizen.System.SystemSettings.SoundNotificationRepetitionPeriodChanged -= OnSoundNotificationRepetitionPeriodChanged;
            Tizen.System.SystemSettings.SoundNotificationRepetitionPeriod = s_soundNotificationRepetitionPeriodValue;
            await Task.Delay(2000);
            Assert.IsFalse(s_soundNotificationRepetitionPeriodCallbackCalled, "SoundNotificationRepetitionPeriodChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.SoundNotificationRepetitionPeriod = preValue;
            LogUtils.WriteOK();
        }
        private static void OnSoundNotificationRepetitionPeriodChanged(object sender, Tizen.System.SoundNotificationRepetitionPeriodChangedEventArgs e)
        {
            s_soundNotificationRepetitionPeriodCallbackCalled = true;
            Assert.IsInstanceOf<int>(e.Value, "OnSoundNotificationRepetitionPeriodChanged: SoundNotificationRepetitionPeriod not an instance of int");
            Assert.IsTrue(s_soundNotificationRepetitionPeriodValue.CompareTo(e.Value) == 0, "OnSoundNotificationRepetitionPeriodChanged: The callback should receive the latest value for the property.");
        }

        // LockState
        // //[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:LockState is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.LockState A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRE")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void LockState_READ_WRITE_ALL()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsInstanceOf<Tizen.System.SystemSettingsIdleLockState>(Tizen.System.SystemSettings.LockState, "LockState_READ_WRITE_ALL: LockState not an instance of SystemSettingsIdleLockState");
            SystemSettingsIdleLockState preValue = Tizen.System.SystemSettings.LockState;
            var setValue = Tizen.System.SystemSettingsIdleLockState.Unlock;
            Tizen.System.SystemSettings.LockState = setValue;
            var getValue = Tizen.System.SystemSettings.LockState;
            Assert.IsTrue(setValue == getValue, "LockState_READ_WRITE_ALL: Set value and get value of the property should be same.");

            setValue = Tizen.System.SystemSettingsIdleLockState.Lock;
            Tizen.System.SystemSettings.LockState = setValue;
            getValue = Tizen.System.SystemSettings.LockState;
            Assert.IsTrue(setValue == getValue, "LockState_READ_WRITE_ALL: Set value and get value of the property should be same.");

            setValue = Tizen.System.SystemSettingsIdleLockState.LaunchingLock;
            Tizen.System.SystemSettings.LockState = setValue;
            getValue = Tizen.System.SystemSettings.LockState;
            Assert.IsTrue(setValue == getValue, "LockState_READ_WRITE_ALL: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.LockState = preValue;
            LogUtils.WriteOK();
        }

        private static bool s_lockStateLockCallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:LockStateChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.LockStateChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task LockStateChanged_CHECK_EVENT_LOCK()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.LockStateChanged += OnLockStateChangedLock;
            SystemSettingsIdleLockState preValue = Tizen.System.SystemSettings.LockState;
            Tizen.System.SystemSettings.LockState = Tizen.System.SystemSettingsIdleLockState.Lock;
            await Task.Delay(2000);
            Assert.IsTrue(s_lockStateLockCallbackCalled, "LockStateChanged_CHECK_EVENT_LOCK: EventHandler added. Not getting called");
            Tizen.System.SystemSettings.LockStateChanged -= OnLockStateChangedLock;
            s_lockStateLockCallbackCalled = false;
            Tizen.System.SystemSettings.LockState = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLockStateChangedLock(object sender, Tizen.System.LockStateChangedEventArgs e)
        {
            s_lockStateLockCallbackCalled = true;
            Assert.IsInstanceOf<Tizen.System.SystemSettingsIdleLockState>(e.Value, "OnLockStateChangedLock: LockState not an instance of SystemSettingsIdleLockState");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsIdleLockState.Lock, "OnLockStateChangedLock: The callback should receive the latest value for the property.");
        }

        private static bool s_lockStateUnlockCallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:LockStateChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.LockStateChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task LockStateChanged_CHECK_EVENT_UNLOCK()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.LockStateChanged += OnLockStateChangedUnlock;
            SystemSettingsIdleLockState preValue = Tizen.System.SystemSettings.LockState;
            Tizen.System.SystemSettings.LockState = Tizen.System.SystemSettingsIdleLockState.Unlock;
            await Task.Delay(2000);
            Tizen.System.SystemSettings.LockStateChanged -= OnLockStateChangedUnlock;
            Assert.IsTrue(s_lockStateUnlockCallbackCalled, "LockStateChanged_CHECK_EVENT_UNLOCK: EventHandler added. Not getting called");
            s_lockStateLockCallbackCalled = false;
            Tizen.System.SystemSettings.LockState = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLockStateChangedUnlock(object sender, Tizen.System.LockStateChangedEventArgs e)
        {
            s_lockStateUnlockCallbackCalled = true;
            Assert.IsInstanceOf<Tizen.System.SystemSettingsIdleLockState>(e.Value, "OnLockStateChangedUnlock: LockState not an instance of SystemSettingsIdleLockState");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsIdleLockState.Unlock, "OnLockStateChangedUnlock: The callback should receive the latest value for the property.");
        }

        private static bool s_lockStateLaunchingLockCallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:LockStateChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.LockStateChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task LockStateChanged_CHECK_EVENT_LAUNCHING_LOCK()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.LockStateChanged += OnLockStateChangedLaunchingLock;
            SystemSettingsIdleLockState preValue = Tizen.System.SystemSettings.LockState;
            Tizen.System.SystemSettings.LockState = Tizen.System.SystemSettingsIdleLockState.LaunchingLock;
            await Task.Delay(2000);
            Tizen.System.SystemSettings.LockStateChanged -= OnLockStateChangedLaunchingLock;
            Assert.IsTrue(s_lockStateLaunchingLockCallbackCalled, "LockStateChanged_CHECK_EVENT_LAUNCHING_LOCK: EventHandler added. Not getting called");
            s_lockStateLockCallbackCalled = false;
            Tizen.System.SystemSettings.LockState = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLockStateChangedLaunchingLock(object sender, Tizen.System.LockStateChangedEventArgs e)
        {
            s_lockStateLaunchingLockCallbackCalled = true;
            Assert.IsInstanceOf<Tizen.System.SystemSettingsIdleLockState>(e.Value, "OnLockStateChangedLaunchingLock: LockState not an instance of SystemSettingsIdleLockState");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsIdleLockState.LaunchingLock, "OnLockStateChangedLaunchingLock: The callback should receive the latest value for the property.");
        }

        // Time
        //[Test]
        //[Category("P1")]
        //[Description("Test if get for SystemSettings:Time is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.Time A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void Time_READ_ONLY()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsInstanceOf<int>(Tizen.System.SystemSettings.Time, "Time_READ_ONLY: Time not an instance of int");
            var readValue = Tizen.System.SystemSettings.Time;
            Assert.NotNull(readValue, "Should be readable");
            LogUtils.WriteOK();
        }

        // UsbDebuggingEnabled
        ////[Test]
        //[Category("P1")]
        //[Description("Test if get for SystemSettings:UsbDebuggingEnabled is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.UsbDebuggingEnabled A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void UsbDebuggingEnabled_READ_WRITE()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            bool setValue = true;
            bool preValue = Tizen.System.SystemSettings.UsbDebuggingEnabled;
            Tizen.System.SystemSettings.UsbDebuggingEnabled = setValue;
            Assert.IsTrue(Tizen.System.SystemSettings.UsbDebuggingEnabled, "UsbDebuggingEnabled_READ_WRITE: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.UsbDebuggingEnabled = preValue;
            LogUtils.WriteOK();
        }

        public static async void TestAllAsync()
        {

            LogUtils.initWriteResult();
            IncomingCallRingtone_READ_WRITE();
            await IncomingCallRingtoneChanged_CHECK_EVENT();
            WallpaperHomeScreen_READ_WRITE();
            await WallpaperHomeScreenChanged_CHECK_EVENT();
            WallpaperLockScreen_READ_WRITE();
            await WallpaperLockScreenChanged_CHECK_EVENT();
            FontSize_READ_WRITE_ALL();
            await FontSizeChanged_CHECK_EVENT_SMALL();
            await FontSizeChanged_CHECK_EVENT_NORMAL();
            await FontSizeChanged_CHECK_EVENT_LARGE();
            await FontSizeChanged_CHECK_EVENT_HUGE();
            await FontSizeChanged_CHECK_EVENT_GIANT();
            FontType_READ_WRITE();
            await FontTypeChanged_CHECK_EVENT();
            MotionActivationEnabled_READ_WRITE();
            await MotionActivationSettingChanged_CHECK_EVENT();
            EmailAlertRingtone_READ_WRITE();
            await EmailAlertRingtoneChanged_CHECK_EVENT();
            Data3GNetworkEnabled_READ_WRITE();
            await Data3GNetworkSettingChanged_CHECK_EVENT();
            LockscreenApp_READ_WRITE();
            await LockscreenAppChanged_CHECK_EVENT();
            DefaultFontType_READ_ONLY();
            LocaleCountry_READ_WRITE();
            await LocaleCountryChanged_CHECK_EVENT();
            LocaleLanguage_READ_WRITE();
            await LocaleLanguageChanged_CHECK_EVENT();
            LocaleTimeFormat24HourEnabled_READ_WRITE();
            await LocaleTimeFormat24HourSettingChanged_CHECK_EVENT();
            LocaleTimeZone_READ_WRITE();
            await LocaleTimeZoneChanged_CHECK_EVENT();
            SoundLockEnabled_READ_ONLY();
            SoundSilentModeEnabled_READ_ONLY();
            SoundTouchEnabled_READ_ONLY();
            DisplayScreenRotationAutoEnabled_READ_ONLY();
            DeviceName_READ_ONLY();
            MotionEnabled_READ_ONLY();
            NetworkWifiNotificationEnabled_READ_ONLY();
            NetworkFlightModeEnabled_READ_ONLY();

            SoundNotification_READ_WRITE();
            await SoundNotificationChanged_CHECK_EVENT();
            SoundNotificationRepetitionPeriod_READ_WRITE();
            await SoundNotificationRepetitionPeriodChanged_CHECK_EVENT();
            LockState_READ_WRITE_ALL();
            await LockStateChanged_CHECK_EVENT_LOCK();
            await LockStateChanged_CHECK_EVENT_UNLOCK();
            await LockStateChanged_CHECK_EVENT_LAUNCHING_LOCK();
            Time_READ_ONLY();
            UsbDebuggingEnabled_READ_WRITE();

            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "Data3GNetworkSettingChangedEventArgsTests");
            await Data3GNetworkSettingChangedEventArgsTests.Value_PROPERTY_READ_ONLY();

            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "EmailAlertRingtoneChangedEventArgsTests");
            await EmailAlertRingtoneChangedEventArgsTests.Value_PROPERTY_READ_ONLY();

            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "FontSizeChangedEventArgsTests");
            await FontSizeChangedEventArgsTests.Value_ENUM_GIANT();
            await FontSizeChangedEventArgsTests.Value_ENUM_HUGE();
            await FontSizeChangedEventArgsTests.Value_ENUM_LARGE();
            await FontSizeChangedEventArgsTests.Value_ENUM_NORMAL();
            await FontSizeChangedEventArgsTests.Value_ENUM_SMALL();

            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "FontTypeChangedEventArgsTests");
            await FontTypeChangedEventArgsTests.Value_PROPERTY_READ_ONLY();

            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "IncomingCallRingtoneChangedEventArgsTests");
            await IncomingCallRingtoneChangedEventArgsTests.Value_PROPERTY_READ_ONLY();

            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "LocaleCountryChangedEventArgsTests");
            await LocaleCountryChangedEventArgsTests.Value_PROPERTY_READ_ONLY();

            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "LocaleLanguageChangedEventArgsTests");
            await LocaleLanguageChangedEventArgsTests.Value_PROPERTY_READ_ONLY();

            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "LocaleTimeFormat24HourSettingChangedEventArgsTests");
            await LocaleTimeFormat24HourSettingChangedEventArgsTests.Value_PROPERTY_READ_ONLY();

            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "LocaleTimeZoneChangedEventArgsTests");
            await LocaleTimeZoneChangedEventArgsTests.Value_PROPERTY_READ_ONLY();

            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "LockStateChangedEventArgsTests");
            await LockStateChangedEventArgsTests.Value_ENUM_LAUNCHING_LOCK();
            await LockStateChangedEventArgsTests.Value_ENUM_LOCK();
            await LockStateChangedEventArgsTests.Value_ENUM_UNLOCK();

            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "MotionActivationSettingChangedEventArgsTests");
            await MotionActivationSettingChangedEventArgsTests.Value_PROPERTY_READ_ONLY();

            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "SoundNotificationChangedEventArgsTests");
            await SoundNotificationChangedEventArgsTests.Value_PROPERTY_READ_ONLY();

            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "SoundNotificationRepetitionPeriodChangedEventArgsTests");
            await SoundNotificationRepetitionPeriodChangedEventArgsTests.Value_PROPERTY_READ_ONLY();

            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "WallpaperHomeScreenChangedEventArgsTests");
            await WallpaperHomeScreenChangedEventArgsTests.Value_PROPERTY_READ_ONLY();

            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "WallpaperLockScreenChangedEventArgsTests");
            await WallpaperLockScreenChangedEventArgsTests.Value_PROPERTY_READ_ONLY();


            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "BlackLightTime Test");
            ScreenBacklightTime_READ_WRITE_ALL();
            await ScreenBacklightTimeChanged_CHECK_EVENT_15();
            await ScreenBacklightTimeChanged_CHECK_EVENT_30();
            await ScreenBacklightTimeChanged_CHECK_EVENT_60();
            await ScreenBacklightTimeChanged_CHECK_EVENT_120();
            await ScreenBacklightTimeChanged_CHECK_EVENT_300();
            await ScreenBacklightTimeChanged_CHECK_EVENT_600();


            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "ScreenBacklightTimeChangedEventArgsTests");
            await ScreenBacklightTimeChangedEventArgsTests.Value_PROPERTY_READ_ONLY_120();
            await ScreenBacklightTimeChangedEventArgsTests.Value_PROPERTY_READ_ONLY_15();
            await ScreenBacklightTimeChangedEventArgsTests.Value_PROPERTY_READ_ONLY_30();
            await ScreenBacklightTimeChangedEventArgsTests.Value_PROPERTY_READ_ONLY_300();
            await ScreenBacklightTimeChangedEventArgsTests.Value_PROPERTY_READ_ONLY_60();
            await ScreenBacklightTimeChangedEventArgsTests.Value_PROPERTY_READ_ONLY_600();

            LogUtils.WriteResult();
            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", "All of Unit test for Tizen.System.SystemSettings have completed!");
        }
    }
}



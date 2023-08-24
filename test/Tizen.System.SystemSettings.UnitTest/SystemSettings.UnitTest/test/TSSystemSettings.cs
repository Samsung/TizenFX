using System;
using System.Threading;
using System.Threading.Tasks;
using Tizen.NUI.Components;
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
            try
            {
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
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.incoming_call", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.incoming_call)");
                LogUtils.NotSupport();
            }
        }

        private static bool s_incomingCallRingtoneCallbackCalled = false;
        private static TaskCompletionSource<bool> s_tcsIncomingCallRingtone;
        private static readonly string s_incomingCallRingtoneValue = SystemSettingsTestInput.GetStringValue((int)Tizen.System.SystemSettingsKeys.IncomingCallRingtone);
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:IncomingCallRingtoneChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.IncomingCallRingtoneChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task IncomingCallRingtoneChanged_CHECK_EVENT()
        {
            try
            {
                s_tcsIncomingCallRingtone = new TaskCompletionSource<bool>();
                LogUtils.StartTest();
                /* TEST CODE */
                Tizen.System.SystemSettings.IncomingCallRingtoneChanged += OnIncomingCallRingtoneChanged;
                string preValue = Tizen.System.SystemSettings.IncomingCallRingtone;
                Tizen.System.SystemSettings.IncomingCallRingtone = s_incomingCallRingtoneValue;
                await s_tcsIncomingCallRingtone.Task;
                Assert.IsTrue(s_incomingCallRingtoneCallbackCalled, "IncomingCallRingtoneChanged_CHECK_EVENT: EventHandler added. Not getting called");
                s_incomingCallRingtoneCallbackCalled = false;
                Tizen.System.SystemSettings.IncomingCallRingtoneChanged -= OnIncomingCallRingtoneChanged;
                Tizen.System.SystemSettings.IncomingCallRingtone = s_incomingCallRingtoneValue;
                await Task.Delay(100);
                Assert.IsFalse(s_incomingCallRingtoneCallbackCalled, "IncomingCallRingtoneChanged_CHECK_EVENT: EventHandler removed. Still getting called");
                Tizen.System.SystemSettings.IncomingCallRingtone = preValue;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.incoming_call", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.incoming_call)");
                LogUtils.NotSupport();
            }
        }
        private static void OnIncomingCallRingtoneChanged(object sender, Tizen.System.IncomingCallRingtoneChangedEventArgs e)
        {
            s_tcsIncomingCallRingtone.SetResult(true);
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
            try
            {
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
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.home_screen", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.home_screen)");
                LogUtils.NotSupport();
            }
        }

        private static bool s_wallpaperHomeScreenCallbackCalled = false;
        private static TaskCompletionSource<bool> s_tcsWallpaperHomeScreen;
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
            try
            {
                LogUtils.StartTest();
                s_tcsWallpaperHomeScreen = new TaskCompletionSource<bool>();
                /* TEST CODE */
                Tizen.System.SystemSettings.WallpaperHomeScreenChanged += OnWallpaperHomeScreenChanged;
                string preValue = Tizen.System.SystemSettings.WallpaperHomeScreen;
                Tizen.System.SystemSettings.WallpaperHomeScreen = s_wallpaperHomeScreenValue;
                await s_tcsWallpaperHomeScreen.Task;
                Assert.IsTrue(s_wallpaperHomeScreenCallbackCalled, "WallpaperHomeScreenChanged_CHECK_EVENT: EventHandler added. Not getting called");
                s_wallpaperHomeScreenCallbackCalled = false;
                Tizen.System.SystemSettings.WallpaperHomeScreenChanged -= OnWallpaperHomeScreenChanged;
                Tizen.System.SystemSettings.WallpaperHomeScreen = s_wallpaperHomeScreenValue;
                await Task.Delay(100);
                Assert.IsFalse(s_wallpaperHomeScreenCallbackCalled, "WallpaperHomeScreenChanged_CHECK_EVENT: EventHandler removed. Still getting called");

                string strProfile;
                Information.TryGetValue<string>("tizen.org/feature/profile", out strProfile);
                if (string.Compare(strProfile, "mobile") == 0)
                    Tizen.System.SystemSettings.WallpaperHomeScreen = preValue;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.home_screen", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.home_screen)");
                LogUtils.NotSupport();
            }
        }
        private static void OnWallpaperHomeScreenChanged(object sender, Tizen.System.WallpaperHomeScreenChangedEventArgs e)
        {
            s_tcsWallpaperHomeScreen.SetResult(true);
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
            try
            {
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
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.lock_screen", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.lock_screen)");
                LogUtils.NotSupport();
            }
        }

        private static bool s_wallpaperLockScreenCallbackCalled = false;
        private static TaskCompletionSource<bool> s_tcsWallpaperLockScreen;
        private static readonly string s_wallpaperLockScreenValue = SystemSettingsTestInput.GetStringValue((int)Tizen.System.SystemSettingsKeys.WallpaperLockScreen);
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:WallpaperLockScreenChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.WallpaperLockScreenChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task WallpaperLockScreenChanged_CHECK_EVENT()
        {
            try
            {
                LogUtils.StartTest();
                s_tcsWallpaperLockScreen = new TaskCompletionSource<bool>();
                /* TEST CODE */
                Tizen.System.SystemSettings.WallpaperLockScreenChanged += OnWallpaperLockScreenChanged;
                string preValue = Tizen.System.SystemSettings.WallpaperLockScreen;
                Tizen.System.SystemSettings.WallpaperLockScreen = s_wallpaperLockScreenValue;
                await s_tcsWallpaperLockScreen.Task;
                Assert.IsTrue(s_wallpaperLockScreenCallbackCalled, "WallpaperLockScreenChanged_CHECK_EVENT: EventHandler added. Not getting called");
                s_wallpaperLockScreenCallbackCalled = false;
                Tizen.System.SystemSettings.WallpaperLockScreenChanged -= OnWallpaperLockScreenChanged;
                Tizen.System.SystemSettings.WallpaperLockScreen = s_wallpaperLockScreenValue;
                await Task.Delay(100);
                Assert.IsFalse(s_wallpaperLockScreenCallbackCalled, "WallpaperLockScreenChanged_CHECK_EVENT: EventHandler removed. Still getting called");

                string strProfile;
                Information.TryGetValue<string>("tizen.org/feature/profile", out strProfile);
                if (string.Compare(strProfile, "mobile") == 0)
                    Tizen.System.SystemSettings.WallpaperLockScreen = preValue;

                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.lock_screen", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.lock_screen)");
                LogUtils.NotSupport();
            }
        }
        private static void OnWallpaperLockScreenChanged(object sender, Tizen.System.WallpaperLockScreenChangedEventArgs e)
        {
            s_tcsWallpaperLockScreen.SetResult(true);
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
        private static TaskCompletionSource<bool> s_tcsFontSizeSmall;
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
            s_tcsFontSizeSmall = new TaskCompletionSource<bool>();
            /* TEST CODE */
            Tizen.System.SystemSettings.FontSizeChanged += OnFontSizeChangedSmall;
            //SystemSettingsFontSize preValue = Tizen.System.SystemSettings.FontSize;
            preFontValue = Tizen.System.SystemSettings.FontSize;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Small;
            await s_tcsFontSizeSmall.Task;
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
            s_tcsFontSizeSmall.SetResult(true);
            s_fontSizeSmallCallbackCalled = true;
            Assert.IsInstanceOf<Tizen.System.SystemSettingsFontSize>(e.Value, "OnFontSizeChangedSmall: FontSize not an instance of SystemSettingsFontSize");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsFontSize.Small, "OnFontSizeChangedSmall: The callback should receive the latest value for the property.");
        }

        private static bool s_fontSizeNormalCallbackCalled = false;
        private static TaskCompletionSource<bool> s_tcsFontSizeNormal;
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
            s_tcsFontSizeNormal = new TaskCompletionSource<bool>();
            /* TEST CODE */
            Tizen.System.SystemSettings.FontSizeChanged += OnFontSizeChangedNormal;
            //SystemSettingsFontSize preValue = Tizen.System.SystemSettings.FontSize;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Normal;
            await s_tcsFontSizeNormal.Task;
            Tizen.System.SystemSettings.FontSizeChanged -= OnFontSizeChangedNormal;
            await Task.Delay(100);
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
            s_tcsFontSizeNormal.SetResult(true);
            //   string format = string.Format("Current Tizen.System.SystemSettings.FontSize : {0} , actual value {1}", Tizen.System.SystemSettings.FontSize, e.Value);
            //   Tizen.Log.Debug("CS-SYSTEM-SETTINGS", format);

            Assert.IsInstanceOf<Tizen.System.SystemSettingsFontSize>(e.Value, "OnFontSizeChangedNormal: FontSize not an instance of SystemSettingsFontSize");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsFontSize.Normal, "OnFontSizeChangedNormal: The callback should receive the latest value for the property.");
        }

        private static bool s_fontSizeLargeCallbackCalled = false;
        private static TaskCompletionSource<bool> s_tcsFontSizeLarge;
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
            s_tcsFontSizeLarge = new TaskCompletionSource<bool>();
            /* TEST CODE */
            Tizen.System.SystemSettings.FontSizeChanged += OnFontSizeChangedLarge;
            //SystemSettingsFontSize preValue = Tizen.System.SystemSettings.FontSize;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Large;
            await s_tcsFontSizeLarge.Task;
            Tizen.System.SystemSettings.FontSizeChanged -= OnFontSizeChangedLarge;
            await Task.Delay(100);
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
            s_tcsFontSizeLarge.SetResult(true);
            s_fontSizeLargeCallbackCalled = true;
            //string format = string.Format("Current Tizen.System.SystemSettings.FontSize : {0} , actual value {1}", Tizen.System.SystemSettings.FontSize, e.Value);
            //Tizen.Log.Debug("CS-SYSTEM-SETTINGS", format);

            Assert.IsInstanceOf<Tizen.System.SystemSettingsFontSize>(e.Value, "OnFontSizeChangedLarge: FontSizeChanged not an instance of SystemSettingsFontSize");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsFontSize.Large, "OnFontSizeChangedLarge: The callback should receive the latest value for the property.");
        }

        private static TaskCompletionSource<bool> s_tcsFontSizeHuge;
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
            s_tcsFontSizeHuge = new TaskCompletionSource<bool>();
            /* TEST CODE */
            Tizen.System.SystemSettings.FontSizeChanged += OnFontSizeChangedHuge;
            //SystemSettingsFontSize preValue = Tizen.System.SystemSettings.FontSize;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Huge;
            await s_tcsFontSizeHuge.Task;
            Tizen.System.SystemSettings.FontSizeChanged -= OnFontSizeChangedHuge;
            await Task.Delay(100);
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
            s_tcsFontSizeHuge.SetResult(true);
            s_fontSizeHugeCallbackCalled = true;
            //string format = string.Format("Current Tizen.System.SystemSettings.FontSize : {0} , actual value {1}", Tizen.System.SystemSettings.FontSize, e.Value);
            //Tizen.Log.Debug("CS-SYSTEM-SETTINSG", format);

            Assert.IsInstanceOf<Tizen.System.SystemSettingsFontSize>(e.Value, "OnFontSizeChangedHuge: FontSize not an instance of SystemSettingsFontSize");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsFontSize.Huge, "OnFontSizeChangedHuge: The callback should receive the latest value for the property.");
        }

        private static TaskCompletionSource<bool> s_tcsFontSizeGiant;
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
            s_tcsFontSizeGiant = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.FontSizeChanged += OnFontSizeChangedGiant;
            //SystemSettingsFontSize preValue = Tizen.System.SystemSettings.FontSize;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Giant;
            await s_tcsFontSizeGiant.Task;
            Tizen.System.SystemSettings.FontSizeChanged -= OnFontSizeChangedGiant;
            await Task.Delay(100);
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
            s_tcsFontSizeGiant.SetResult(true);
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
        public static async Task FontType_READ_WRITE()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            Assert.IsInstanceOf<string>(Tizen.System.SystemSettings.FontType, "FontType_READ_WRITE: FontType not an instance of string");
            //string setValue = "BreezeSans";
//            string setValue = "SamsungOneUI";
            string setValue = Tizen.System.SystemSettings.DefaultFontType;
            string preValue = Tizen.System.SystemSettings.FontType;
            Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>>>>>>>>> Default Font set : " + setValue);
            Tizen.System.SystemSettings.FontType = setValue;
            var getValue = Tizen.System.SystemSettings.FontType;
            Assert.IsTrue(getValue.CompareTo(setValue) == 0, "FontType_READ_WRITE: Set value and get value of the property should be same.");
            await Task.Delay(2000);

            LogUtils.WriteOK();
        }

        private static bool s_fontTypeCallbackCalled = false;
        private static readonly string s_fontTypeValue = Tizen.System.SystemSettings.DefaultFontType;
        private static TaskCompletionSource<bool> s_tcsFontType;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:FontTypeChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.FontTypeChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task FontTypeChanged_CHECK_EVENT()
        {
            s_tcsFontType = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.FontTypeChanged += OnFontTypeChanged;
            string preValue = Tizen.System.SystemSettings.FontType;
            Tizen.System.SystemSettings.FontType = s_fontTypeValue;
            await s_tcsFontType.Task;
            Assert.IsTrue(s_fontTypeCallbackCalled, "FontTypeChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_fontTypeCallbackCalled = false;
            Tizen.System.SystemSettings.FontTypeChanged -= OnFontTypeChanged;
            Tizen.System.SystemSettings.FontType = s_fontTypeValue;
            await Task.Delay(100);
            Assert.IsFalse(s_fontTypeCallbackCalled, "FontTypeChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.FontType = preValue;
            LogUtils.WriteOK();
        }
        private static void OnFontTypeChanged(object sender, Tizen.System.FontTypeChangedEventArgs e)
        {
            s_tcsFontType.SetResult(true);
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
        private static TaskCompletionSource<bool> s_tcsMotionActivation;
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
            s_tcsMotionActivation = new TaskCompletionSource<bool>();
            /* TEST CODE */
            Tizen.System.SystemSettings.MotionActivationSettingChanged += OnMotionActivationChanged;
            bool preValue = Tizen.System.SystemSettings.MotionActivationEnabled;
            Tizen.System.SystemSettings.MotionActivationEnabled = s_motionActivationValue;
            await s_tcsMotionActivation.Task;

            Assert.IsTrue(s_motionActivationCallbackCalled, "MotionActivationSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_motionActivationCallbackCalled = false;
            s_motionActivationValue = !s_motionActivationValue;
            Tizen.System.SystemSettings.MotionActivationEnabled = s_motionActivationValue;
            await s_tcsMotionActivation.Task;
            Assert.IsTrue(s_motionActivationCallbackCalled, "MotionActivationSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_motionActivationCallbackCalled = false;

            Tizen.System.SystemSettings.MotionActivationSettingChanged -= OnMotionActivationChanged;
            Tizen.System.SystemSettings.MotionActivationEnabled = s_motionActivationValue;
            await Task.Delay(100);
            Assert.IsFalse(s_motionActivationCallbackCalled, "MotionActivationSettingChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.MotionActivationEnabled = preValue;
            LogUtils.WriteOK();
        }
        private static void OnMotionActivationChanged(object sender, Tizen.System.MotionActivationSettingChangedEventArgs e)
        {
            s_tcsMotionActivation.SetResult(true);
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
            try
            {
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
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.notification_email", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.notification_email)");
                LogUtils.NotSupport();

            }
        }

        private static TaskCompletionSource<bool> s_tcsEmailAlertRingtone;
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
            try
            {
				s_tcsEmailAlertRingtone = new TaskCompletionSource<bool>();
                LogUtils.StartTest();
                /* TEST CODE */
                Tizen.System.SystemSettings.EmailAlertRingtoneChanged += OnEmailAlertRingtoneChanged;
                string preValue = Tizen.System.SystemSettings.EmailAlertRingtone;
                Tizen.System.SystemSettings.EmailAlertRingtone = s_emailAlertRingtoneValue;
				await s_tcsEmailAlertRingtone.Task;
                Assert.IsTrue(s_emailAlertRingtoneCallbackCalled, "EmailAlertRingtoneChanged_CHECK_EVENT: EventHandler added. Not getting called");
                s_emailAlertRingtoneCallbackCalled = false;
                Tizen.System.SystemSettings.EmailAlertRingtoneChanged -= OnEmailAlertRingtoneChanged;
                Tizen.System.SystemSettings.EmailAlertRingtone = s_emailAlertRingtoneValue;
                await Task.Delay(100);
                Assert.IsFalse(s_emailAlertRingtoneCallbackCalled, "EmailAlertRingtoneChanged_CHECK_EVENT: EventHandler removed. Still getting called");
                Tizen.System.SystemSettings.EmailAlertRingtone = preValue;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.notification_email", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.notification_email)");
                LogUtils.NotSupport();
            }
        }
        private static void OnEmailAlertRingtoneChanged(object sender, Tizen.System.EmailAlertRingtoneChangedEventArgs e)
        {
            s_tcsEmailAlertRingtone.SetResult(true);
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

        private static TaskCompletionSource<bool> s_tcsData3GNetwork;
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
            s_tcsData3GNetwork = new TaskCompletionSource<bool>();
            /* TEST CODE */
            Tizen.System.SystemSettings.Data3GNetworkSettingChanged += OnData3GNetworkSettingChanged;
            bool preValue = Tizen.System.SystemSettings.Data3GNetworkEnabled;
            Tizen.System.SystemSettings.Data3GNetworkEnabled = s_data3GNetworkSettingValue;
            await s_tcsData3GNetwork.Task;
            Assert.IsTrue(s_data3GNetworkCallbackCalled, "Data3GNetworkSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");

            s_data3GNetworkSettingValue = !s_data3GNetworkSettingValue;
            s_data3GNetworkCallbackCalled = false;
            Tizen.System.SystemSettings.Data3GNetworkEnabled = s_data3GNetworkSettingValue;
            await s_tcsData3GNetwork.Task;
            Assert.IsTrue(s_data3GNetworkCallbackCalled, "Data3GNetworkSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_data3GNetworkCallbackCalled = false;

            Tizen.System.SystemSettings.Data3GNetworkSettingChanged -= OnData3GNetworkSettingChanged;
            Tizen.System.SystemSettings.Data3GNetworkEnabled = s_data3GNetworkSettingValue;
            await Task.Delay(100);
            Assert.IsFalse(s_data3GNetworkCallbackCalled, "Data3GNetworkSettingChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.Data3GNetworkEnabled = preValue;
            LogUtils.WriteOK();
        }
        private static void OnData3GNetworkSettingChanged(object sender, Tizen.System.Data3GNetworkSettingChangedEventArgs e)
        {
            s_tcsData3GNetwork.SetResult(true);
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
            try
            {
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
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.lock_screen", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.lock_screen)");
                LogUtils.NotSupport();
            }
        }

        private static TaskCompletionSource<bool> s_tcsLockScreenApp;
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
            try
            {
				s_tcsLockScreenApp = new TaskCompletionSource<bool>();
                LogUtils.StartTest();
                /* TEST CODE */
                Tizen.System.SystemSettings.LockScreenAppChanged += OnLockscreenAppChanged;
                string preValue = Tizen.System.SystemSettings.LockScreenApp;
                Tizen.System.SystemSettings.LockScreenApp = s_lockscreenAppValue;
				await s_tcsLockScreenApp.Task;
                Assert.IsTrue(s_lockScreenAppCallbackCalled, "LockscreenAppChanged_CHECK_EVENT: EventHandler added. Not getting called");
                s_lockScreenAppCallbackCalled = false;
                Tizen.System.SystemSettings.LockScreenAppChanged -= OnLockscreenAppChanged;
                Tizen.System.SystemSettings.LockScreenApp = s_lockscreenAppValue;
                await Task.Delay(100);
                Assert.IsFalse(s_lockScreenAppCallbackCalled, "LockscreenAppChanged_CHECK_EVENT: EventHandler removed. Still getting called");
                Tizen.System.SystemSettings.LockScreenApp = preValue;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.lock_screen", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.lock_screen)");
                LogUtils.NotSupport();
            }
        }
        private static void OnLockscreenAppChanged(object sender, Tizen.System.LockScreenAppChangedEventArgs e)
        {
            s_tcsLockScreenApp.SetResult(true);
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

        private static TaskCompletionSource<bool> s_tcsLocaleCountry;
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
            s_tcsLocaleCountry = new TaskCompletionSource<bool>();
            /* TEST CODE */
            Tizen.System.SystemSettings.LocaleCountryChanged += OnLocaleCountryChanged;
            string preValue = Tizen.System.SystemSettings.LocaleCountry;
            Tizen.System.SystemSettings.LocaleCountry = s_localeCountryValue;
            await s_tcsLocaleCountry.Task;
            Assert.IsTrue(s_localeCountryCallbackCalled, "LocaleCountryChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_localeCountryCallbackCalled = false;
            Tizen.System.SystemSettings.LocaleCountryChanged -= OnLocaleCountryChanged;
            Tizen.System.SystemSettings.LocaleCountry = s_localeCountryValue;
            await Task.Delay(100);
            Assert.IsFalse(s_localeCountryCallbackCalled, "LocaleCountryChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.LocaleCountry = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLocaleCountryChanged(object sender, Tizen.System.LocaleCountryChangedEventArgs e)
        {
            s_tcsLocaleCountry.SetResult(true);
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

        private static TaskCompletionSource<bool> s_tcsLocaleLanguage;
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
            s_tcsLocaleLanguage = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.LocaleLanguageChanged += OnLocaleLanguageChanged;
            string preValue = Tizen.System.SystemSettings.LocaleLanguage;
            Tizen.System.SystemSettings.LocaleLanguage = s_localeLanguageValue;
            await s_tcsLocaleLanguage.Task;
            Assert.IsTrue(s_localeLanguageCallbackCalled, "LocaleLanguageChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_localeLanguageCallbackCalled = false;
            Tizen.System.SystemSettings.LocaleLanguageChanged -= OnLocaleLanguageChanged;
            Tizen.System.SystemSettings.LocaleLanguage = s_localeLanguageValue;
            await Task.Delay(100);
            Assert.IsFalse(s_localeLanguageCallbackCalled, "LocaleLanguageChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.LocaleLanguage = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLocaleLanguageChanged(object sender, Tizen.System.LocaleLanguageChangedEventArgs e)
        {
            s_tcsLocaleLanguage.SetResult(true);
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

        private static TaskCompletionSource<bool> s_tcsTimeFormat;
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
            s_tcsTimeFormat = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.LocaleTimeFormat24HourSettingChanged += OnLocaleTimeformat24HourChanged;
            bool preValue = Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled;
            Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled = s_localeTimeformat24HourValue;
            await s_tcsTimeFormat.Task;
            Assert.IsTrue(s_timeFormatCallbackCalled, "LocaleTimeFormat24HourSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_timeFormatCallbackCalled = false;

            s_localeTimeformat24HourValue = !s_localeTimeformat24HourValue;
            Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled = s_localeTimeformat24HourValue;
            await s_tcsTimeFormat.Task;
            Assert.IsTrue(s_timeFormatCallbackCalled, "LocaleTimeFormat24HourSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_timeFormatCallbackCalled = false;

            Tizen.System.SystemSettings.LocaleTimeFormat24HourSettingChanged -= OnLocaleTimeformat24HourChanged;
            Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled = s_localeTimeformat24HourValue;
            await Task.Delay(100);
            Assert.IsFalse(s_timeFormatCallbackCalled, "LocaleTimeFormat24HourSettingChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled = preValue;
            LogUtils.WriteOK();
        }

        private static void OnLocaleTimeformat24HourChanged(object sender, Tizen.System.LocaleTimeFormat24HourSettingChangedEventArgs e)
        {
            s_tcsTimeFormat.SetResult(true);
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

        private static TaskCompletionSource<bool> s_tcsLocaleTimeZone;
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
            s_tcsLocaleTimeZone = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.LocaleTimeZoneChanged += OnLocaleTimeZoneChanged;
            string preValue = Tizen.System.SystemSettings.LocaleTimeZone;
            Tizen.System.SystemSettings.LocaleTimeZone = s_localeTimeZoneValue;
            await s_tcsLocaleTimeZone.Task;
            Assert.IsTrue(s_localeTimeZoneCallbackCalled, "LocaleTimeZoneChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_localeTimeZoneCallbackCalled = false;

            Tizen.System.SystemSettings.LocaleTimeZoneChanged -= OnLocaleTimeZoneChanged;
            Tizen.System.SystemSettings.LocaleTimeZone = s_localeTimeZoneValue;
            await Task.Delay(100);
            Assert.IsFalse(s_localeTimeZoneCallbackCalled, "LocaleTimeZoneChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.LocaleTimeZone = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLocaleTimeZoneChanged(object sender, Tizen.System.LocaleTimeZoneChangedEventArgs e)
        {
            s_tcsLocaleTimeZone.SetResult(true);
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
            }
            catch (NotSupportedException)
            {
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

        private static TaskCompletionSource<bool> s_tcsScreenBacklightTime15;
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
            s_tcsScreenBacklightTime15 = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime15Changed;
            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 15;
            await s_tcsScreenBacklightTime15.Task;
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime15Changed;
            Assert.IsTrue(s_screenBacklightTime15CallbackCalled, "ScreenBacklightTimeChanged_CHECK_EVENT_15: EventHandler added. Not getting called");
            s_screenBacklightTime15CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();
        }
        private static void OnScreenBacklightTime15Changed(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_tcsScreenBacklightTime15.SetResult(true);
            s_screenBacklightTime15CallbackCalled = true;
            Assert.IsInstanceOf<int>(e.Value, "OnScreenBacklightTime15Changed: ScreenBacklightTime not an instance of int");
            Assert.IsTrue(e.Value == 15, "OnScreenBacklightTime15Changed: The callback should receive the latest value for the property.");
        }

        private static TaskCompletionSource<bool> s_tcsScreenBacklightTime30;
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
            s_tcsScreenBacklightTime30 = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime30Changed;
            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 30;
            await s_tcsScreenBacklightTime30.Task;
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime30Changed;
            Assert.IsTrue(s_screenBacklightTime30CallbackCalled, "ScreenBacklightTimeChanged_CHECK_EVENT_30: EventHandler added. Not getting called");
            s_screenBacklightTime30CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();
        }
        private static void OnScreenBacklightTime30Changed(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_tcsScreenBacklightTime30.SetResult(true);
            s_screenBacklightTime30CallbackCalled = true;
            Assert.IsInstanceOf<int>(e.Value, "OnScreenBacklightTime30Changed: ScreenBacklightTime not an instance of int");
            Assert.IsTrue(e.Value == 30, "OnScreenBacklightTime30Changed: The callback should receive the latest value for the property.");
        }

        private static TaskCompletionSource<bool> s_tcsScreenBacklightTime60;
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
            s_tcsScreenBacklightTime60 = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime60Changed;
            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 60;
            await s_tcsScreenBacklightTime60.Task;
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime60Changed;
            Assert.IsTrue(s_screenBacklightTime60CallbackCalled, "ScreenBacklightTimeChanged_CHECK_EVENT_60: EventHandler added. Not getting called");
            s_screenBacklightTime60CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();
        }
        private static void OnScreenBacklightTime60Changed(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_tcsScreenBacklightTime60.SetResult(true);
            s_screenBacklightTime60CallbackCalled = true;
            Assert.IsInstanceOf<int>(e.Value, "OnScreenBacklightTime60Changed: ScreenBacklightTime not an instance of int");
            Assert.IsTrue(e.Value == 60, "OnScreenBacklightTime60Changed: The callback should receive the latest value for the property.");
        }

        private static TaskCompletionSource<bool> s_tcsScreenBacklightTime120;
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
            s_tcsScreenBacklightTime120 = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime120Changed;
            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 120;
            await s_tcsScreenBacklightTime120.Task;
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime120Changed;
            Assert.IsTrue(s_screenBacklightTime120CallbackCalled, "ScreenBacklightTimeChanged_CHECK_EVENT_120: EventHandler added. Not getting called");
            s_screenBacklightTime120CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();
        }
        private static void OnScreenBacklightTime120Changed(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_tcsScreenBacklightTime120.SetResult(true);
            s_screenBacklightTime120CallbackCalled = true;
            Assert.IsInstanceOf<int>(e.Value, "OnScreenBacklightTime120Changed: ScreenBacklightTime not an instance of int");
            Assert.IsTrue(e.Value == 120, "OnScreenBacklightTime120Changed: The callback should receive the latest value for the property.");
        }

        private static TaskCompletionSource<bool> s_tcsScreenBacklightTime300;
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
            s_tcsScreenBacklightTime300 = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime300Changed;
            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 300;
            await s_tcsScreenBacklightTime300.Task;
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime300Changed;
            Assert.IsTrue(s_screenBacklightTime300CallbackCalled, "ScreenBacklightTimeChanged_CHECK_EVENT_300: EventHandler added. Not getting called");
            s_screenBacklightTime300CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();
        }
        private static void OnScreenBacklightTime300Changed(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_tcsScreenBacklightTime300.SetResult(true);
            s_screenBacklightTime300CallbackCalled = true;
            Assert.IsInstanceOf<int>(e.Value, "OnScreenBacklightTime300Changed: ScreenBacklightTime not an instance of int");
            Assert.IsTrue(e.Value == 300, "OnScreenBacklightTime300Changed: The callback should receive the latest value for the property.");
        }

        private static TaskCompletionSource<bool> s_tcsScreenBacklightTime600;
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
            s_tcsScreenBacklightTime600 = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime600Changed;
            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 600;
            await s_tcsScreenBacklightTime600.Task;
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime600Changed;
            Assert.IsTrue(s_screenBacklightTime600CallbackCalled, "ScreenBacklightTimeChanged_CHECK_EVENT_600: EventHandler added. Not getting called");
            s_screenBacklightTime600CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();
        }
        private static void OnScreenBacklightTime600Changed(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_tcsScreenBacklightTime600.SetResult(true);
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
            try
            {
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
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.incoming_call", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.incoming_call)");
                LogUtils.NotSupport();
            }
        }

        private static TaskCompletionSource<bool> s_tcsSoundNotification;
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
            try
            {
				s_tcsSoundNotification = new TaskCompletionSource<bool>();
                LogUtils.StartTest();
                /* TEST CODE */
                Tizen.System.SystemSettings.SoundNotificationChanged += OnSoundNotificationChanged;
                string preValue = Tizen.System.SystemSettings.SoundNotification;
                Tizen.System.SystemSettings.SoundNotification = s_soundNotificationValue;
				await s_tcsSoundNotification.Task;
                Assert.IsTrue(s_soundNotificationCallbackCalled, "SoundNotificationChanged_CHECK_EVENT: EventHandler added. Not getting called");

                s_soundNotificationCallbackCalled = false;
                Tizen.System.SystemSettings.SoundNotificationChanged -= OnSoundNotificationChanged;
                Tizen.System.SystemSettings.SoundNotification = s_soundNotificationValue;
                await Task.Delay(100);
                Assert.IsFalse(s_soundNotificationCallbackCalled, "SoundNotificationChanged_CHECK_EVENT: EventHandler removed. Still getting called");
                Tizen.System.SystemSettings.SoundNotification = preValue;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.incoming_call", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.incoming_call)");
                LogUtils.NotSupport();
            }
        }
        private static void OnSoundNotificationChanged(object sender, Tizen.System.SoundNotificationChangedEventArgs e)
        {
            s_tcsSoundNotification.SetResult(true);
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

        private static TaskCompletionSource<bool> s_tcsSoundNotificationRepetitionPeriod;
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
            s_tcsSoundNotificationRepetitionPeriod = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.SoundNotificationRepetitionPeriodChanged += OnSoundNotificationRepetitionPeriodChanged;
            int preValue = Tizen.System.SystemSettings.SoundNotificationRepetitionPeriod;
            Tizen.System.SystemSettings.SoundNotificationRepetitionPeriod = s_soundNotificationRepetitionPeriodValue;
            await s_tcsSoundNotificationRepetitionPeriod.Task;
            Assert.IsTrue(s_soundNotificationRepetitionPeriodCallbackCalled, "SoundNotificationRepetitionPeriodChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_soundNotificationRepetitionPeriodCallbackCalled = false;

            Tizen.System.SystemSettings.SoundNotificationRepetitionPeriodChanged -= OnSoundNotificationRepetitionPeriodChanged;
            Tizen.System.SystemSettings.SoundNotificationRepetitionPeriod = s_soundNotificationRepetitionPeriodValue;
            await Task.Delay(100);
            Assert.IsFalse(s_soundNotificationRepetitionPeriodCallbackCalled, "SoundNotificationRepetitionPeriodChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.SoundNotificationRepetitionPeriod = preValue;
            LogUtils.WriteOK();
        }
        private static void OnSoundNotificationRepetitionPeriodChanged(object sender, Tizen.System.SoundNotificationRepetitionPeriodChangedEventArgs e)
        {
            s_tcsSoundNotificationRepetitionPeriod.SetResult(true);
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

        private static TaskCompletionSource<bool> s_tcsLockStateLock;
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
            s_tcsLockStateLock = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.LockStateChanged += OnLockStateChangedLock;
            SystemSettingsIdleLockState preValue = Tizen.System.SystemSettings.LockState;
            Tizen.System.SystemSettings.LockState = Tizen.System.SystemSettingsIdleLockState.Lock;
            await s_tcsLockStateLock.Task;
            Assert.IsTrue(s_lockStateLockCallbackCalled, "LockStateChanged_CHECK_EVENT_LOCK: EventHandler added. Not getting called");
            Tizen.System.SystemSettings.LockStateChanged -= OnLockStateChangedLock;
            s_lockStateLockCallbackCalled = false;
            Tizen.System.SystemSettings.LockState = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLockStateChangedLock(object sender, Tizen.System.LockStateChangedEventArgs e)
        {
            s_tcsLockStateLock.SetResult(true);
            s_lockStateLockCallbackCalled = true;
            Assert.IsInstanceOf<Tizen.System.SystemSettingsIdleLockState>(e.Value, "OnLockStateChangedLock: LockState not an instance of SystemSettingsIdleLockState");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsIdleLockState.Lock, "OnLockStateChangedLock: The callback should receive the latest value for the property.");
        }

        private static TaskCompletionSource<bool> s_tcsLockStateUnlock;
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
            s_tcsLockStateUnlock = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.LockStateChanged += OnLockStateChangedUnlock;
            SystemSettingsIdleLockState preValue = Tizen.System.SystemSettings.LockState;
            Tizen.System.SystemSettings.LockState = Tizen.System.SystemSettingsIdleLockState.Unlock;
            await s_tcsLockStateUnlock.Task;
            Tizen.System.SystemSettings.LockStateChanged -= OnLockStateChangedUnlock;
            Assert.IsTrue(s_lockStateUnlockCallbackCalled, "LockStateChanged_CHECK_EVENT_UNLOCK: EventHandler added. Not getting called");
            s_lockStateLockCallbackCalled = false;
            Tizen.System.SystemSettings.LockState = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLockStateChangedUnlock(object sender, Tizen.System.LockStateChangedEventArgs e)
        {
            s_tcsLockStateUnlock.SetResult(true);
            s_lockStateUnlockCallbackCalled = true;
            Assert.IsInstanceOf<Tizen.System.SystemSettingsIdleLockState>(e.Value, "OnLockStateChangedUnlock: LockState not an instance of SystemSettingsIdleLockState");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsIdleLockState.Unlock, "OnLockStateChangedUnlock: The callback should receive the latest value for the property.");
        }

        private static TaskCompletionSource<bool> s_tcsLockStateLaunchingLock;
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
            s_tcsLockStateLaunchingLock = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.LockStateChanged += OnLockStateChangedLaunchingLock;
            SystemSettingsIdleLockState preValue = Tizen.System.SystemSettings.LockState;
            Tizen.System.SystemSettings.LockState = Tizen.System.SystemSettingsIdleLockState.LaunchingLock;
            await s_tcsLockStateLaunchingLock.Task;
            Tizen.System.SystemSettings.LockStateChanged -= OnLockStateChangedLaunchingLock;
            Assert.IsTrue(s_lockStateLaunchingLockCallbackCalled, "LockStateChanged_CHECK_EVENT_LAUNCHING_LOCK: EventHandler added. Not getting called");
            s_lockStateLockCallbackCalled = false;
            Tizen.System.SystemSettings.LockState = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLockStateChangedLaunchingLock(object sender, Tizen.System.LockStateChangedEventArgs e)
        {
            s_tcsLockStateLaunchingLock.SetResult(true);
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



        // AdsId
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:AdsId is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.AdsId A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void AdsId_READ_WRITE()
        {
            try
            {
                LogUtils.StartTest();
                /* TEST CODE */
                Assert.IsInstanceOf<string>(Tizen.System.SystemSettings.AdsId, "AdsId_READ_WRITE: AdsId not an instance of string");
                string preValue = Tizen.System.SystemSettings.AdsId;
                var setValue = "00000215-0156-0133-0034-000000000102";

                Tizen.System.SystemSettings.AdsId = setValue;
                var getValue = Tizen.System.SystemSettings.AdsId;
                Assert.IsTrue(setValue.CompareTo(getValue) == 0, "AdsId_READ_WRITE: Set value and get value of the property should be same.");
                Tizen.System.SystemSettings.AdsId = preValue;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.incoming_call", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.incoming_call)");
                LogUtils.NotSupport();
            }
        }

        private static TaskCompletionSource<bool> s_tcsAdsId;
        private static bool s_adsIdCallbackCalled = false;
        private static readonly string s_adsIdValue = "00000215-0156-0133-0034-000000000102";
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:AdsIdChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.AdsIdChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task AdsIdChanged_CHECK_EVENT()
        {
            try
            {
				s_tcsAdsId = new TaskCompletionSource<bool>();
                LogUtils.StartTest();
                /* TEST CODE */
                Tizen.System.SystemSettings.AdsIdChanged += OnAdsIdChanged;
                string preValue = Tizen.System.SystemSettings.AdsId;
                Tizen.System.SystemSettings.AdsId = s_adsIdValue;
				await s_tcsAdsId.Task;
                Assert.IsTrue(s_adsIdCallbackCalled, "AdsIdChanged_CHECK_EVENT: EventHandler added. Not getting called");
                s_adsIdCallbackCalled = false;
                Tizen.System.SystemSettings.AdsIdChanged -= OnAdsIdChanged;
                Tizen.System.SystemSettings.AdsId = s_adsIdValue;
                await Task.Delay(100);
                Assert.IsFalse(s_adsIdCallbackCalled, "AdsIdChanged_CHECK_EVENT: EventHandler removed. Still getting called");
                Tizen.System.SystemSettings.AdsId = preValue;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.incoming_call", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.incoming_call)");
                LogUtils.NotSupport();
            }
        }
        private static void OnAdsIdChanged(object sender, Tizen.System.AdsIdChangedEventArgs e)
        {
            s_tcsAdsId.SetResult(true);
            s_adsIdCallbackCalled = true;
            Assert.IsInstanceOf<string>(e.Value, "OnAdsIdChanged: AdsId not an instance of string");
            Assert.IsTrue(s_adsIdValue.CompareTo(e.Value) == 0, "OnAdsIdChanged: The callback should receive the latest value for the property.");
        }

        // UltraDataSave
        //[Test]
        //[Category("P1")]
        //[Description("Test if get for SystemSettings:UltraDataSave is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.UltraDataSave A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void UltraDataSave_READ_ONLY()
        {
            try
            {
                LogUtils.StartTest();
                /* TEST CODE */
                Assert.IsInstanceOf<string>(Tizen.System.SystemSettings.UltraDataSave, "UltraDataSave_READ_ONLY: UltraDataSave not an instance of string");
                var readValue = Tizen.System.SystemSettings.UltraDataSave;
                Assert.NotNull(readValue, "Should be readable");
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/network.telephony", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/network.telephony)");
                LogUtils.NotSupport();
            }
        }

#if true
        // AccessibilityTts
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:AccessibilityTtsEnabled is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.AccessibilityTtsEnabled A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void AccessibilityTtsEnabled_READ_WRITE()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            bool preValue = Tizen.System.SystemSettings.AccessibilityTtsEnabled;
            Assert.IsInstanceOf<bool>(Tizen.System.SystemSettings.AccessibilityTtsEnabled, "AccessibilityTtsEnabled_READ_WRITE: AccessibilityTtsEnabled not an instance of bool");
            Tizen.System.SystemSettings.AccessibilityTtsEnabled = true;
            Assert.IsTrue(Tizen.System.SystemSettings.AccessibilityTtsEnabled, "AccessibilityTts_READ_WRITE: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.AccessibilityTtsEnabled = false;
            Assert.IsFalse(Tizen.System.SystemSettings.AccessibilityTtsEnabled, "AccessibilityTts_READ_WRITE: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.AccessibilityTtsEnabled = preValue;
            LogUtils.WriteOK();
        }

        private static TaskCompletionSource<bool> s_tcsAccessibilityTts;
        private static bool s_accessibilityTtsCallbackCalled = false;
        private static bool s_accessibilityTtsValue = !Tizen.System.SystemSettings.AccessibilityTtsEnabled;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:AccessibilityTtsSettingChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.AccessibilityTtsSettingChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task AccessibilityTtsSettingChanged_CHECK_EVENT()
        {
            s_tcsAccessibilityTts = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.AccessibilityTtsSettingChanged += OnAccessibilityTtsChanged;
            bool preValue = Tizen.System.SystemSettings.AccessibilityTtsEnabled;
            Tizen.System.SystemSettings.AccessibilityTtsEnabled = s_accessibilityTtsValue;
            await s_tcsAccessibilityTts.Task;
            Assert.IsTrue(s_accessibilityTtsCallbackCalled, "AccessibilityTtsSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_accessibilityTtsCallbackCalled = false;
            s_accessibilityTtsValue = !s_accessibilityTtsValue;
            Tizen.System.SystemSettings.AccessibilityTtsEnabled = s_accessibilityTtsValue;
            await s_tcsAccessibilityTts.Task;
            Assert.IsTrue(s_accessibilityTtsCallbackCalled, "AccessibilityTtsSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_accessibilityTtsCallbackCalled = false;

            Tizen.System.SystemSettings.AccessibilityTtsSettingChanged -= OnAccessibilityTtsChanged;
            Tizen.System.SystemSettings.AccessibilityTtsEnabled = s_accessibilityTtsValue;
            await Task.Delay(100);
            Assert.IsFalse(s_accessibilityTtsCallbackCalled, "AccessibilityTtsSettingChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.AccessibilityTtsEnabled = preValue;
            LogUtils.WriteOK();
        }
        private static void OnAccessibilityTtsChanged(object sender, Tizen.System.AccessibilityTtsSettingChangedEventArgs e)
        {
            s_tcsAccessibilityTts.SetResult(true);
            s_accessibilityTtsCallbackCalled = true;
            Assert.IsInstanceOf<bool>(e.Value, "OnAccessibilityTtsChanged: AccessibilityTtsEnabled not an instance of bool");
            Assert.IsTrue(e.Value == s_accessibilityTtsValue, "OnAccessibilityTtsChanged: The callback should receive the latest value for the property.");
        }
#endif
        // Vibration
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:Vibration is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.Vibration A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void Vibration_READ_WRITE()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            bool preValue = Tizen.System.SystemSettings.Vibration;
            Assert.IsInstanceOf<bool>(Tizen.System.SystemSettings.Vibration, "Vibration_READ_WRITE: Vibration not an instance of bool");
            Tizen.System.SystemSettings.Vibration = true;
            Assert.IsTrue(Tizen.System.SystemSettings.Vibration, "Vibration_READ_WRITE: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.Vibration = false;
            Assert.IsFalse(Tizen.System.SystemSettings.Vibration, "Vibration_READ_WRITE: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.Vibration = preValue;
            LogUtils.WriteOK();
        }

        private static TaskCompletionSource<bool> s_tcsVibration;
        private static bool s_vibrationCallbackCalled = false;
        private static bool s_vibrationValue = !Tizen.System.SystemSettings.Vibration;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:VibrationSettingChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.VibrationSettingChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task VibrationSettingChanged_CHECK_EVENT()
        {
            s_tcsVibration = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.VibrationChanged += OnVibrationChanged;
            bool preValue = Tizen.System.SystemSettings.Vibration;
            Tizen.System.SystemSettings.Vibration = s_vibrationValue;
            await s_tcsVibration.Task;
            Assert.IsTrue(s_vibrationCallbackCalled, "VibrationSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_vibrationCallbackCalled = false;
            s_vibrationValue = !s_vibrationValue;
            Tizen.System.SystemSettings.Vibration = s_vibrationValue;
            await s_tcsVibration.Task;
            Assert.IsTrue(s_vibrationCallbackCalled, "VibrationSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_vibrationCallbackCalled = false;

            Tizen.System.SystemSettings.VibrationChanged -= OnVibrationChanged;
            Tizen.System.SystemSettings.Vibration = s_vibrationValue;
            await Task.Delay(100);
            Assert.IsFalse(s_vibrationCallbackCalled, "VibrationSettingChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.Vibration = preValue;
            LogUtils.WriteOK();
        }
        private static void OnVibrationChanged(object sender, Tizen.System.VibrationChangedEventArgs e)
        {
            s_tcsVibration.SetResult(true);
            s_vibrationCallbackCalled = true;
            Assert.IsInstanceOf<bool>(e.Value, "OnVibrationChanged: Vibration not an instance of bool");
            Assert.IsTrue(e.Value == s_vibrationValue, "OnVibrationChanged: The callback should receive the latest value for the property.");
        }

        // AutomaticTimeUpdate
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:AutomaticTimeUpdate is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.AutomaticTimeUpdate A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void AutomaticTimeUpdate_READ_WRITE()
        {
            try
            {
                LogUtils.StartTest();
                /* TEST CODE */
                bool preValue = Tizen.System.SystemSettings.AutomaticTimeUpdate;
                Assert.IsInstanceOf<bool>(Tizen.System.SystemSettings.AutomaticTimeUpdate, "AutomaticTimeUpdate_READ_WRITE: AutomaticTimeUpdate not an instance of bool");
                Tizen.System.SystemSettings.AutomaticTimeUpdate = true;
                Assert.IsTrue(Tizen.System.SystemSettings.AutomaticTimeUpdate, "AutomaticTimeUpdate_READ_WRITE: Set value and get value of the property should be same.");
                Tizen.System.SystemSettings.AutomaticTimeUpdate = false;
                Assert.IsFalse(Tizen.System.SystemSettings.AutomaticTimeUpdate, "AutomaticTimeUpdate_READ_WRITE: Set value and get value of the property should be same.");
                Tizen.System.SystemSettings.AutomaticTimeUpdate = preValue;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/network.telephony", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/network.telephony)");
                LogUtils.NotSupport();
            }
        }

        private static TaskCompletionSource<bool> s_tcsAutomaticTimeUpdate;
        private static bool s_automaticTimeUpdateCallbackCalled = false;
        private static bool s_automaticTimeUpdateValue = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:AutomaticTimeUpdateSettingChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.AutomaticTimeUpdateSettingChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task AutomaticTimeUpdateSettingChanged_CHECK_EVENT()
        {
            try
            {
				s_tcsAutomaticTimeUpdate = new TaskCompletionSource<bool>();
                LogUtils.StartTest();
                /* TEST CODE */
                s_automaticTimeUpdateValue = !Tizen.System.SystemSettings.AutomaticTimeUpdate;
                Tizen.System.SystemSettings.AutomaticTimeUpdateChanged += OnAutomaticTimeUpdateChanged;
                bool preValue = Tizen.System.SystemSettings.AutomaticTimeUpdate;
                Tizen.System.SystemSettings.AutomaticTimeUpdate = s_automaticTimeUpdateValue;
				await s_tcsAutomaticTimeUpdate.Task;
                Assert.IsTrue(s_automaticTimeUpdateCallbackCalled, "AutomaticTimeUpdateSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
                s_automaticTimeUpdateCallbackCalled = false;
                s_automaticTimeUpdateValue = !s_automaticTimeUpdateValue;
                Tizen.System.SystemSettings.AutomaticTimeUpdate = s_automaticTimeUpdateValue;
                Assert.IsTrue(s_automaticTimeUpdateCallbackCalled, "AutomaticTimeUpdateSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
                s_automaticTimeUpdateCallbackCalled = false;

                Tizen.System.SystemSettings.AutomaticTimeUpdateChanged -= OnAutomaticTimeUpdateChanged;
                Tizen.System.SystemSettings.AutomaticTimeUpdate = s_automaticTimeUpdateValue;
                await Task.Delay(100);
                Assert.IsFalse(s_automaticTimeUpdateCallbackCalled, "AutomaticTimeUpdateSettingChanged_CHECK_EVENT: EventHandler removed. Still getting called");
                Tizen.System.SystemSettings.AutomaticTimeUpdate = preValue;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/network.telephony", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/network.telephony)");
                LogUtils.NotSupport();
            }
        }
        private static void OnAutomaticTimeUpdateChanged(object sender, Tizen.System.AutomaticTimeUpdateChangedEventArgs e)
        {
            s_tcsAutomaticTimeUpdate.SetResult(true);
            s_automaticTimeUpdateCallbackCalled = true;
            Assert.IsInstanceOf<bool>(e.Value, "OnAutomaticTimeUpdateChanged: AutomaticTimeUpdate not an instance of bool");
            Assert.IsTrue(e.Value == s_automaticTimeUpdateValue, "OnAutomaticTimeUpdateChanged: The callback should receive the latest value for the property.");
        }

        // DeveloperOptionState
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:DeveloperOptionState is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.DeveloperOptionState A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void DeveloperOptionState_READ_WRITE()
        {
            LogUtils.StartTest();
            /* TEST CODE */
            bool preValue = Tizen.System.SystemSettings.DeveloperOptionState;
            Assert.IsInstanceOf<bool>(Tizen.System.SystemSettings.DeveloperOptionState, "DeveloperOptionState_READ_WRITE: DeveloperOptionState not an instance of bool");
            Tizen.System.SystemSettings.DeveloperOptionState = true;
            Assert.IsTrue(Tizen.System.SystemSettings.DeveloperOptionState, "DeveloperOptionState_READ_WRITE: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.DeveloperOptionState = false;
            Assert.IsFalse(Tizen.System.SystemSettings.DeveloperOptionState, "DeveloperOptionState_READ_WRITE: Set value and get value of the property should be same.");
            Tizen.System.SystemSettings.DeveloperOptionState = preValue;
            LogUtils.WriteOK();
        }

        private static TaskCompletionSource<bool> s_tcsDeveloperOptionState;
        private static bool s_developerOptionStateCallbackCalled = false;
        private static bool s_developerOptionStateValue = !Tizen.System.SystemSettings.DeveloperOptionState;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:DeveloperOptionStateSettingChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.DeveloperOptionStateSettingChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task DeveloperOptionStateSettingChanged_CHECK_EVENT()
        {
            s_tcsDeveloperOptionState = new TaskCompletionSource<bool>();
            LogUtils.StartTest();
            /* TEST CODE */
            Tizen.System.SystemSettings.DeveloperOptionStateChanged += OnDeveloperOptionStateChanged;
            bool preValue = Tizen.System.SystemSettings.DeveloperOptionState;
            Tizen.System.SystemSettings.DeveloperOptionState = s_developerOptionStateValue;
            await s_tcsDeveloperOptionState.Task;
            Assert.IsTrue(s_developerOptionStateCallbackCalled, "DeveloperOptionStateSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_developerOptionStateCallbackCalled = false;
            s_developerOptionStateValue = !s_developerOptionStateValue;
            Tizen.System.SystemSettings.DeveloperOptionState = s_developerOptionStateValue;
            await s_tcsDeveloperOptionState.Task;
            Assert.IsTrue(s_developerOptionStateCallbackCalled, "DeveloperOptionStateSettingChanged_CHECK_EVENT: EventHandler added. Not getting called");
            s_developerOptionStateCallbackCalled = false;

            Tizen.System.SystemSettings.DeveloperOptionStateChanged -= OnDeveloperOptionStateChanged;
            Tizen.System.SystemSettings.DeveloperOptionState = s_developerOptionStateValue;
            await Task.Delay(100);
            Assert.IsFalse(s_developerOptionStateCallbackCalled, "DeveloperOptionStateSettingChanged_CHECK_EVENT: EventHandler removed. Still getting called");
            Tizen.System.SystemSettings.DeveloperOptionState = preValue;
            LogUtils.WriteOK();
        }
        private static void OnDeveloperOptionStateChanged(object sender, Tizen.System.DeveloperOptionStateChangedEventArgs e)
        {
            s_tcsDeveloperOptionState.SetResult(true);
            s_developerOptionStateCallbackCalled = true;
            Assert.IsInstanceOf<bool>(e.Value, "OnDeveloperOptionStateChanged: DeveloperOptionState not an instance of bool");
            Assert.IsTrue(e.Value == s_developerOptionStateValue, "OnDeveloperOptionStateChanged: The callback should receive the latest value for the property.");
        }

        // AccessibilityGrayscale
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:AccessibilityGrayscale is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.AccessibilityGrayscale A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void AccessibilityGrayscale_READ_WRITE()
        {
            try
            {
                LogUtils.StartTest();
                /* TEST CODE */
                Assert.IsInstanceOf<bool>(Tizen.System.SystemSettings.AccessibilityGrayscale, "AccessibilityGrayscale_READ_WRITE: AccessibilityGrayscale not an instance of string");
                bool preValue = Tizen.System.SystemSettings.AccessibilityGrayscale;
                var setValue = !preValue;

                Tizen.System.SystemSettings.AccessibilityGrayscale = setValue;
                var getValue = Tizen.System.SystemSettings.AccessibilityGrayscale;
                Assert.IsTrue(getValue == setValue, "AccessibilityGrayscale_READ_WRITE: Set value and get value of the property should be same.");
                Tizen.System.SystemSettings.AccessibilityGrayscale = preValue;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/accessibility.grayscale", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/accessibility.grayscale)");
                LogUtils.NotSupport();
            }
        }

        private static TaskCompletionSource<bool> s_tcsAccessibilityGrayscale;
        private static bool s_accessibilityGrayscaleCallbackCalled = false;
        private static bool s_accessibilityGrayscaleValue = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:AccessibilityGrayscaleChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.AccessibilityGrayscaleChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task AccessibilityGrayscaleChanged_CHECK_EVENT()
        {
            try
            {
				s_tcsAccessibilityGrayscale = new TaskCompletionSource<bool>();
                LogUtils.StartTest();
                /* TEST CODE */
                Tizen.System.SystemSettings.AccessibilityGrayscaleChanged += OnAccessibilityGrayscaleChanged;
                bool preValue = Tizen.System.SystemSettings.AccessibilityGrayscale;
                s_accessibilityGrayscaleValue = !preValue;
                Tizen.System.SystemSettings.AccessibilityGrayscale = s_accessibilityGrayscaleValue;
				await s_tcsAccessibilityGrayscale.Task;
                Assert.IsTrue(s_accessibilityGrayscaleCallbackCalled, "AccessibilityGrayscaleChanged_CHECK_EVENT: EventHandler added. Not getting called");
                s_accessibilityGrayscaleCallbackCalled = false;
                Tizen.System.SystemSettings.AccessibilityGrayscaleChanged -= OnAccessibilityGrayscaleChanged;
                Tizen.System.SystemSettings.AccessibilityGrayscale = !s_accessibilityGrayscaleValue;
                await Task.Delay(100);
                Assert.IsFalse(s_accessibilityGrayscaleCallbackCalled, "AccessibilityGrayscaleChanged_CHECK_EVENT: EventHandler removed. Still getting called");
                Tizen.System.SystemSettings.AccessibilityGrayscale = preValue;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/accessibility.grayscale", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/accessibility.grayscale)");
                LogUtils.NotSupport();
            }
        }
        private static void OnAccessibilityGrayscaleChanged(object sender, Tizen.System.AccessibilityGrayscaleChangedEventArgs e)
        {
            s_accessibilityGrayscaleCallbackCalled = true;
            Assert.IsInstanceOf<bool>(e.Value, "OnAccessibilityGrayscaleChanged: AccessibilityGrayscale not an instance of string");
            Assert.IsTrue(s_accessibilityGrayscaleValue == e.Value, "OnAccessibilityGrayscaleChanged: The callback should receive the latest value for the property.");
        }

        // AccessibilityNegativeColor
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:AccessibilityNegativeColor is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.AccessibilityNegativeColor A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void AccessibilityNegativeColor_READ_WRITE()
        {
            try
            {
                LogUtils.StartTest();
                /* TEST CODE */
                Assert.IsInstanceOf<bool>(Tizen.System.SystemSettings.AccessibilityNegativeColor, "AccessibilityNegativeColor_READ_WRITE: AccessibilityNegativeColor not an instance of string");
                bool preValue = Tizen.System.SystemSettings.AccessibilityNegativeColor;
                var setValue = !preValue;

                Tizen.System.SystemSettings.AccessibilityNegativeColor = setValue;
                var getValue = Tizen.System.SystemSettings.AccessibilityNegativeColor;
                Assert.IsTrue(getValue == setValue, "AccessibilityNegativeColor_READ_WRITE: Set value and get value of the property should be same.");
                Tizen.System.SystemSettings.AccessibilityNegativeColor = preValue;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/accessibility.negative", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/accessibility.negative)");
                LogUtils.NotSupport();
            }
        }

        private static TaskCompletionSource<bool> s_tcsAccessibilityNegativeColor;
        private static bool s_accessibilityNegativeColorCallbackCalled = false;
        private static bool s_accessibilityNegativeColorValue = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:AccessibilityNegativeColorChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.AccessibilityNegativeColorChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task AccessibilityNegativeColorChanged_CHECK_EVENT()
        {
            try
            {
				s_tcsAccessibilityNegativeColor = new TaskCompletionSource<bool>();
                LogUtils.StartTest();
                /* TEST CODE */
                Tizen.System.SystemSettings.AccessibilityNegativeColorChanged += OnAccessibilityNegativeColorChanged;
                bool preValue = Tizen.System.SystemSettings.AccessibilityNegativeColor;
                s_accessibilityNegativeColorValue = !preValue;
                Tizen.System.SystemSettings.AccessibilityNegativeColor = s_accessibilityNegativeColorValue;
				await s_tcsAccessibilityNegativeColor.Task;
                Assert.IsTrue(s_accessibilityNegativeColorCallbackCalled, "AccessibilityNegativeColorChanged_CHECK_EVENT: EventHandler added. Not getting called");
                s_accessibilityNegativeColorCallbackCalled = false;
                Tizen.System.SystemSettings.AccessibilityNegativeColorChanged -= OnAccessibilityNegativeColorChanged;
                Tizen.System.SystemSettings.AccessibilityNegativeColor = !s_accessibilityNegativeColorValue;
                await Task.Delay(100);
                Assert.IsFalse(s_accessibilityNegativeColorCallbackCalled, "AccessibilityNegativeColorChanged_CHECK_EVENT: EventHandler removed. Still getting called");
                Tizen.System.SystemSettings.AccessibilityNegativeColor = preValue;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/accessibility.negative", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/accessibility.negative)");
                LogUtils.NotSupport();
            }
        }
        private static void OnAccessibilityNegativeColorChanged(object sender, Tizen.System.AccessibilityNegativeColorChangedEventArgs e)
        {
            s_tcsAccessibilityNegativeColor.SetResult(true);
            s_accessibilityNegativeColorCallbackCalled = true;
            Assert.IsInstanceOf<bool>(e.Value, "OnAccessibilityNegativeColorChanged: AccessibilityNegativeColor not an instance of string");
            Assert.IsTrue(s_accessibilityNegativeColorValue == e.Value, "OnAccessibilityNegativeColorChanged: The callback should receive the latest value for the property.");
        }

        // RotaryEventEnabled
        ////[Test]
        //[Category("P1")]
        //[Description("Test if set/get for SystemSettings:RotaryEventEnabled is working properly")]
        //[Property("SPEC", "Tizen.System.SystemSettings.RotaryEventEnabled A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static void RotaryEventEnabled_READ_WRITE()
        {
            try
            {
                LogUtils.StartTest();
                /* TEST CODE */
                Assert.IsInstanceOf<bool>(Tizen.System.SystemSettings.RotaryEventEnabled, "RotaryEventEnabled_READ_WRITE: RotaryEventEnabled not an instance of string");
                bool preValue = Tizen.System.SystemSettings.RotaryEventEnabled;
                var setValue = !preValue;

                Tizen.System.SystemSettings.RotaryEventEnabled = setValue;
                var getValue = Tizen.System.SystemSettings.RotaryEventEnabled;
                Assert.IsTrue(getValue == setValue, "RotaryEventEnabled_READ_WRITE: Set value and get value of the property should be same.");
                Tizen.System.SystemSettings.RotaryEventEnabled = preValue;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/input.rotating_bezel", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/input.rotating_bezel)");
                LogUtils.NotSupport();
            }
        }

        private static TaskCompletionSource<bool> s_tcsRotaryEventEnabled;
        private static bool s_rotaryEventEnabledCallbackCalled = false;
        private static bool s_rotaryEventEnabledValue = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check if callback to SystemSettings:RotaryEventEnabledChanged event is called")]
        //[Property("SPEC", "Tizen.System.SystemSettings.RotaryEventEnabledChanged E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task RotaryEventEnabledChanged_CHECK_EVENT()
        {
            try
            {
                s_tcsRotaryEventEnabled = new TaskCompletionSource<bool>();
                LogUtils.StartTest();
                /* TEST CODE */
                Tizen.System.SystemSettings.RotaryEventEnabledChanged += OnRotaryEventEnabledChanged;
                bool preValue = Tizen.System.SystemSettings.RotaryEventEnabled;
                s_rotaryEventEnabledValue = !preValue;
                Tizen.System.SystemSettings.RotaryEventEnabled = s_rotaryEventEnabledValue;
                await s_tcsRotaryEventEnabled.Task;
                Assert.IsTrue(s_rotaryEventEnabledCallbackCalled, "RotaryEventEnabledChanged_CHECK_EVENT: EventHandler added. Not getting called");
                s_rotaryEventEnabledCallbackCalled = false;
                Tizen.System.SystemSettings.RotaryEventEnabledChanged -= OnRotaryEventEnabledChanged;
                Tizen.System.SystemSettings.RotaryEventEnabled = !s_rotaryEventEnabledValue;
                await Task.Delay(100);
                Assert.IsFalse(s_rotaryEventEnabledCallbackCalled, "RotaryEventEnabledChanged_CHECK_EVENT: EventHandler removed. Still getting called");
                Tizen.System.SystemSettings.RotaryEventEnabled = preValue;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/input.rotating_bezel", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/input.rotating_bezel)");
                LogUtils.NotSupport();
            }
        }
        private static void OnRotaryEventEnabledChanged(object sender, Tizen.System.RotaryEventEnabledChangedEventArgs e)
        {
            s_tcsRotaryEventEnabled.SetResult(true);
            s_rotaryEventEnabledCallbackCalled = true;
            Assert.IsInstanceOf<bool>(e.Value, "OnRotaryEventEnabledChanged: RotaryEventEnabled not an instance of string");
            Assert.IsTrue(s_rotaryEventEnabledValue == e.Value, "OnRotaryEventEnabledChanged: The callback should receive the latest value for the property.");
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
            await FontType_READ_WRITE();
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
            //UsbDebuggingEnabled_READ_WRITE();

            AdsId_READ_WRITE();
            await AdsIdChanged_CHECK_EVENT();
            UltraDataSave_READ_ONLY();

            AccessibilityTtsEnabled_READ_WRITE();
            await AccessibilityTtsSettingChanged_CHECK_EVENT();

            Vibration_READ_WRITE();
            await VibrationSettingChanged_CHECK_EVENT();
            AutomaticTimeUpdate_READ_WRITE();
            await AutomaticTimeUpdateSettingChanged_CHECK_EVENT();
            DeveloperOptionState_READ_WRITE();
            await DeveloperOptionStateSettingChanged_CHECK_EVENT();

            AccessibilityGrayscale_READ_WRITE();
            await AccessibilityGrayscaleChanged_CHECK_EVENT();
            AccessibilityNegativeColor_READ_WRITE();
            await AccessibilityNegativeColorChanged_CHECK_EVENT();


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



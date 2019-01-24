using System.Threading.Tasks;
using System;
using System.Threading;
using Tizen.System;

/*
string format = string.Format("Current Tizen.System.SystemSettings.FontSize : {0}", (int)Tizen.System.SystemSettings.FontSize);
Tizen.Log.Debug("CS-SYSTEM-SETTING", format);
*/

namespace SystemSettingsUnitTest
{
    //[TestFixture]
    //[Description("Tizen.System.FontSizeChangedEventArgs Tests")]
    public static class FontSizeChangedEventArgsTests
    {
        private static bool s_fontSizeSmallCallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check FontSizeChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.FontSizeChangedEventArgs.Value A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRE")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Value_ENUM_SMALL()
        {
            LogUtils.StartTest();
            /*
                * PRECONDITION
                * 1. Assign event handler
                */
            Tizen.System.SystemSettings.FontSizeChanged += OnFontSizeChangedSmallValue;

            SystemSettingsFontSize preValue = Tizen.System.SystemSettings.FontSize;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Small;
            await Task.Delay(2000);
            Assert.IsTrue(s_fontSizeSmallCallbackCalled, "Value_ENUM_SMALL: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            Tizen.System.SystemSettings.FontSizeChanged -= OnFontSizeChangedSmallValue;
            s_fontSizeSmallCallbackCalled = false;
            Tizen.System.SystemSettings.FontSize = preValue;
            LogUtils.WriteOK();
        }
        private static void OnFontSizeChangedSmallValue(object sender, Tizen.System.FontSizeChangedEventArgs e)
        {
            s_fontSizeSmallCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<Tizen.System.SystemSettingsFontSize>(e.Value, "OnFontSizeChangedSmallValue: FontSize not an instance of SystemSettingsFontSize");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsFontSize.Small, "OnFontSizeChangedSmallValue: The callback should receive the latest value for the property.");
        }

        private static bool s_fontSizeNormalCallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check FontSizeChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.FontSizeChangedEventArgs.Value A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRE")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Value_ENUM_NORMAL()
        {
            LogUtils.StartTest();
            /*
                * PRECONDITION
                * 1. Assign event handler
                */
            Tizen.System.SystemSettings.FontSizeChanged += OnFontSizeChangedNormalValue;

            SystemSettingsFontSize preValue = Tizen.System.SystemSettings.FontSize;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Normal;
            await Task.Delay(2000);
            Assert.IsTrue(s_fontSizeNormalCallbackCalled, "Value_ENUM_NORMAL: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            Tizen.System.SystemSettings.FontSizeChanged -= OnFontSizeChangedNormalValue;
            s_fontSizeNormalCallbackCalled = false;
            Tizen.System.SystemSettings.FontSize = preValue;
            LogUtils.WriteOK();
        }
        private static void OnFontSizeChangedNormalValue(object sender, Tizen.System.FontSizeChangedEventArgs e)
        {
            s_fontSizeNormalCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<Tizen.System.SystemSettingsFontSize>(e.Value, "OnFontSizeChangedNormalValue: FontSize not an instance of SystemSettingsFontSize");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsFontSize.Normal, "OnFontSizeChangedNormalValue: The callback should receive the latest value for the property.");
        }

        private static bool s_fontSizeLargeCallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check FontSizeChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.FontSizeChangedEventArgs.Value A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRE")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Value_ENUM_LARGE()
        {
            LogUtils.StartTest();
            /*
                * PRECONDITION
                * 1. Assign event handler
                */
            Tizen.System.SystemSettings.FontSizeChanged += OnFontSizeChangedLargeValue;

            SystemSettingsFontSize preValue = Tizen.System.SystemSettings.FontSize;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Large;
            await Task.Delay(2000);
            Assert.IsTrue(s_fontSizeLargeCallbackCalled, "Value_ENUM_LARGE: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            Tizen.System.SystemSettings.FontSizeChanged -= OnFontSizeChangedLargeValue;
            s_fontSizeLargeCallbackCalled = false;
            Tizen.System.SystemSettings.FontSize = preValue;
            LogUtils.WriteOK();
        }
        private static void OnFontSizeChangedLargeValue(object sender, Tizen.System.FontSizeChangedEventArgs e)
        {
            s_fontSizeLargeCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<Tizen.System.SystemSettingsFontSize>(e.Value, "OnFontSizeChangedLargeValue: FontSize not an instance of SystemSettingsFontSize");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsFontSize.Large, "OnFontSizeChangedLargeValue: The callback should receive the latest value for the property.");
        }

        private static bool s_fontSizeHugeCallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check FontSizeChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.FontSizeChangedEventArgs.Value A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRE")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Value_ENUM_HUGE()
        {
            LogUtils.StartTest();
            /*
                * PRECONDITION
                * 1. Assign event handler
                */
            Tizen.System.SystemSettings.FontSizeChanged += OnFontSizeChangedHugeValue;

            SystemSettingsFontSize preValue = Tizen.System.SystemSettings.FontSize;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Huge;
            await Task.Delay(2000);
            Assert.IsTrue(s_fontSizeHugeCallbackCalled, "Value_ENUM_HUGE: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            Tizen.System.SystemSettings.FontSizeChanged -= OnFontSizeChangedHugeValue;
            s_fontSizeHugeCallbackCalled = false;
            Tizen.System.SystemSettings.FontSize = preValue;
            LogUtils.WriteOK();
        }
        private static void OnFontSizeChangedHugeValue(object sender, Tizen.System.FontSizeChangedEventArgs e)
        {
            s_fontSizeHugeCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<Tizen.System.SystemSettingsFontSize>(e.Value, "OnFontSizeChangedHugeValue: FontSize not an instance of SystemSettingsFontSize");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsFontSize.Huge, "OnFontSizeChangedHugeValue: The callback should receive the latest value for the property.");
        }

        private static bool s_fontSizeGiantCallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check FontSizeChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.FontSizeChangedEventArgs.Value A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRE")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Value_ENUM_GIANT()
        {
            LogUtils.StartTest();
            /*
                * PRECONDITION
                * 1. Assign event handler
                */
            Tizen.System.SystemSettings.FontSizeChanged += OnFontSizeChangedGiantValue;

            SystemSettingsFontSize preValue = Tizen.System.SystemSettings.FontSize;
            Tizen.System.SystemSettings.FontSize = Tizen.System.SystemSettingsFontSize.Giant;
            await Task.Delay(2000);
            Assert.IsTrue(s_fontSizeGiantCallbackCalled, "Value_ENUM_GIANT: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            Tizen.System.SystemSettings.FontSizeChanged -= OnFontSizeChangedGiantValue;
            s_fontSizeGiantCallbackCalled = false;
            Tizen.System.SystemSettings.FontSize = preValue;
            LogUtils.WriteOK();
        }
        private static void OnFontSizeChangedGiantValue(object sender, Tizen.System.FontSizeChangedEventArgs e)
        {
            s_fontSizeGiantCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<Tizen.System.SystemSettingsFontSize>(e.Value, "OnFontSizeChangedGiantValue: FontSize nto an instance of SystemSettingsFontSize");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsFontSize.Giant, "OnFontSizeChangedGiantValue: The callback should receive the latest value for the property.");
        }

    }
}

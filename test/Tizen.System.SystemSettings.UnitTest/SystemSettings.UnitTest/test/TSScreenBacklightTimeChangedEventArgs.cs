using System.Threading.Tasks;
using System;
using System.Threading;
using Tizen.System;


namespace SystemSettingsUnitTest
{
    //[TestFixture]
    //[Description("Tizen.System.ScreenBacklightTimeChangedEventArgs Tests")]
    public static class ScreenBacklightTimeChangedEventArgsTests
    {
        private static bool s_screenBacklightTime15CallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check ScreenBacklightTimeChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.ScreenBacklightTimeChangedEventArgs.Value A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Value_PROPERTY_READ_ONLY_15()
        {
            LogUtils.StartTest();
            /*
                * PRECONDITION
                * 1. Assign event handler
                */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime15ChangedValue;

            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 15;
            await Task.Delay(2000);
            Assert.IsTrue(s_screenBacklightTime15CallbackCalled, "Value_PROPERTY_READ_ONLY_15: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime15ChangedValue;
            s_screenBacklightTime15CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();

        }
        private static void OnScreenBacklightTime15ChangedValue(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_screenBacklightTime15CallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<int>(e.Value, "OnScreenBacklightTime15ChangedValue: ScreenBacklightTime not an instance of int");
            Assert.IsTrue(e.Value == 15, "OnScreenBacklightTime15ChangedValue: The callback should receive the latest value for the property.");
        }

        private static bool s_screenBacklightTime30CallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check ScreenBacklightTimeChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.ScreenBacklightTimeChangedEventArgs.Value A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Value_PROPERTY_READ_ONLY_30()
        {
            LogUtils.StartTest();
            /*
                * PRECONDITION
                * 1. Assign event handler
                */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime30ChangedValue;

            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 30;
            await Task.Delay(2000);
            Assert.IsTrue(s_screenBacklightTime30CallbackCalled, "Value_PROPERTY_READ_ONLY_30: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime30ChangedValue;
            s_screenBacklightTime30CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();

        }
        private static void OnScreenBacklightTime30ChangedValue(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_screenBacklightTime30CallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<int>(e.Value, "OnScreenBacklightTime30ChangedValue: ScreenBacklightTime not an instance of int");
            Assert.IsTrue(e.Value == 30, "OnScreenBacklightTime30ChangedValue: The callback should receive the latest value for the property.");
        }

        private static bool s_screenBacklightTime60CallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check ScreenBacklightTimeChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.ScreenBacklightTimeChangedEventArgs.Value A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Value_PROPERTY_READ_ONLY_60()
        {
            LogUtils.StartTest();
            /*
                * PRECONDITION
                * 1. Assign event handler
                */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime60ChangedValue;

            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 60;
            await Task.Delay(2000);
            Assert.IsTrue(s_screenBacklightTime60CallbackCalled, "Value_PROPERTY_READ_ONLY_60: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime60ChangedValue;
            s_screenBacklightTime60CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();

        }
        private static void OnScreenBacklightTime60ChangedValue(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_screenBacklightTime60CallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<int>(e.Value, "OnScreenBacklightTime60ChangedValue: ScreenBacklightTime not an instance of int");
            Assert.IsTrue(e.Value == 60, "OnScreenBacklightTime60ChangedValue: The callback should receive the latest value for the property.");
        }

        private static bool s_screenBacklightTime120CallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check ScreenBacklightTimeChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.ScreenBacklightTimeChangedEventArgs.Value A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Value_PROPERTY_READ_ONLY_120()
        {
            LogUtils.StartTest();
            /*
                * PRECONDITION
                * 1. Assign event handler
                */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime120ChangedValue;

            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 120;
            await Task.Delay(2000);
            Assert.IsTrue(s_screenBacklightTime120CallbackCalled, "Value_PROPERTY_READ_ONLY_120: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime120ChangedValue;
            s_screenBacklightTime120CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();

        }

        private static void OnScreenBacklightTime120ChangedValue(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_screenBacklightTime120CallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<int>(e.Value, "OnScreenBacklightTime120ChangedValue: ScreenBacklightTime not an instance of int");
            Assert.IsTrue(e.Value == 120, "OnScreenBacklightTime120ChangedValue: The callback should receive the latest value for the property.");
        }

        private static bool s_screenBacklightTime300CallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check ScreenBacklightTimeChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.ScreenBacklightTimeChangedEventArgs.Value A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Value_PROPERTY_READ_ONLY_300()
        {
            LogUtils.StartTest();
            /*
                * PRECONDITION
                * 1. Assign event handler
                */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime300ChangedValue;

            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 300;
            await Task.Delay(2000);
            Assert.IsTrue(s_screenBacklightTime300CallbackCalled, "Value_PROPERTY_READ_ONLY_300: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime300ChangedValue;
            s_screenBacklightTime300CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();

        }
        private static void OnScreenBacklightTime300ChangedValue(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_screenBacklightTime300CallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<int>(e.Value, "OnScreenBacklightTime300ChangedValue: ScreenBacklightTime not an instance of int");
            Assert.IsTrue(e.Value == 300, "OnScreenBacklightTime300ChangedValue: The callback should receive the latest value for the property.");
        }

        private static bool s_screenBacklightTime600CallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check ScreenBacklightTimeChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.ScreenBacklightTimeChangedEventArgs.Value A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Value_PROPERTY_READ_ONLY_600()
        {
            LogUtils.StartTest();
            /*
                * PRECONDITION
                * 1. Assign event handler
                */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged += OnScreenBacklightTime600ChangedValue;

            int preValue = Tizen.System.SystemSettings.ScreenBacklightTime;
            Tizen.System.SystemSettings.ScreenBacklightTime = 600;
            await Task.Delay(2000);
            Assert.IsTrue(s_screenBacklightTime600CallbackCalled, "Value_PROPERTY_READ_ONLY_600: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            Tizen.System.SystemSettings.ScreenBacklightTimeChanged -= OnScreenBacklightTime600ChangedValue;
            s_screenBacklightTime600CallbackCalled = false;
            Tizen.System.SystemSettings.ScreenBacklightTime = preValue;
            LogUtils.WriteOK();

        }
        private static void OnScreenBacklightTime600ChangedValue(object sender, Tizen.System.ScreenBacklightTimeChangedEventArgs e)
        {
            s_screenBacklightTime600CallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<int>(e.Value, "OnScreenBacklightTime600ChangedValue: ScreenBacklightTime not an instance of int");
            Assert.IsTrue(e.Value == 600, "OnScreenBacklightTime600ChangedValue: The callback should receive the latest value for the property.");
        }
    }
}

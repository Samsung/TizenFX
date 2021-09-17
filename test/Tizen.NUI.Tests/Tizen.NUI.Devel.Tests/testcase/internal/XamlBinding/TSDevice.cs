using global::System;
using NUnit.Framework;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/XamlBinding/Device")]
    public class InternalDeviceTest
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
        [Description("Device SetIdiom")]
        [Property("SPEC", "Device SetIdiom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void DeviceSetIdiom()
        {
            tlog.Debug(tag, $"DeviceSetIdiom START");

            tlog.Debug(tag, "OS : " + Device.OS);
            tlog.Debug(tag, "Info : " + Device.Info);
            tlog.Debug(tag, "RuntimePlatform  : " + Device.RuntimePlatform);

            Device.SetIdiom(TargetIdiom.TV);
            tlog.Debug(tag, "Idiom : " + Device.Idiom);

            tlog.Debug(tag, $"DeviceSetIdiom END");
        }

        [Test]
        public void TestBeginInvokeOnMainThread()
        {
            bool calledFromMainThread = false;

            bool invoked = false;
            Device.BeginInvokeOnMainThread(() => invoked = true);

            Assert.True(invoked, "Action not invoked.");
            Assert.False(calledFromMainThread, "Action not invoked from main thread.");
        }

        [Test]
        public void InvokeOnMainThreadThrowsWhenNull()
        {
            try{
                Device.BeginInvokeOnMainThread(() => { });
            }
            catch(Exception e){
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }
        }
    }
}

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
    [Description("internal/FrameBroker/FrameBrokerBase")]
    public class InternalFrameBrokerBaseTest
    {
        private const string tag = "NUITEST";
        private const string MyAppId = "org.tizen.SampleServiceApp.Tizen";
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

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
        [Category("P2")]
        [Description("FrameBrokerBase SendLaunchRequest.")]
        [Property("SPEC", "Tizen.NUI.FrameBrokerBase.SendLaunchRequest M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameBrokerBaseSendLaunchRequestNullAppControl()
        {
            tlog.Debug(tag, $"FrameBrokerBaseSendLaunchRequestNullAppControl START");

            using (Window window = new Window(new Rectangle(0, 0, 100, 200), false))
            {
                var testingTarget = new DefaultFrameBroker(window);
                Assert.IsNotNull(testingTarget, "Can't create success object CustomView");
                Assert.IsInstanceOf<DefaultFrameBroker>(testingTarget, "Should be an instance of DefaultFrameBroker type.");

                try
                {
                    testingTarget.SendLaunchRequest(null, true);
                }
                catch (Exception e)
                {
                    testingTarget.Dispose();
                    tlog.Debug(tag, e.Message.ToString());
                    tlog.Debug(tag, $"FrameBrokerBaseSendLaunchRequestNullAppControl END (OK)");
                    Assert.Pass("Caught ArgumentException : Passed!");
                }
            }
        }
    }
}

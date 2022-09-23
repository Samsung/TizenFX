using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using Tizen.Applications;

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
        [Description("FrameBrokerBase SendLaunchRequest. With null.")]
        [Property("SPEC", "Tizen.NUI.FrameBrokerBase.SendLaunchRequest M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameBrokerBaseSendLaunchRequestWithNull()
        {
            tlog.Debug(tag, $"FrameBrokerBaseSendLaunchRequestWithNull START");

            var testingTarget = new DefaultFrameBroker(Window.Instance);
            Assert.IsNotNull(testingTarget, "Can't create success object CustomView");
            Assert.IsInstanceOf<DefaultFrameBroker>(testingTarget, "Should be an instance of DefaultFrameBroker type.");

            try
            {
                testingTarget.SendLaunchRequest(null);
            }
            catch (Exception e)
            {
                testingTarget.Dispose();
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"FrameBrokerBaseSendLaunchRequestWithNull END (OK)");
                Assert.Pass("Caught ArgumentException : Passed!");
            }
        }
    }
}

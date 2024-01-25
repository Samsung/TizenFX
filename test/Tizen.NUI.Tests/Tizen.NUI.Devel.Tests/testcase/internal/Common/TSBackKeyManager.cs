using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/BackKeyManager")]
    public class InternalBackKeyManagerTest
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
        [Description("BackKeyManager Instance.")]
        [Property("SPEC", "Tizen.NUI.BackKeyManager.Instance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BackKeyManagerInstance()
        {
            tlog.Debug(tag, $"BackKeyManagerInstance START");

            var testingTarget = BackKeyManager.Instance;
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<BackKeyManager>(testingTarget, "should be an instance of BackKeyManager class!");

            tlog.Debug(tag, $"BackKeyManagerInstance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BackKeyManager Subscriber.")]
        [Property("SPEC", "Tizen.NUI.BackKeyManager.Subscriber A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BackKeyManagerSubscriber()
        {
            tlog.Debug(tag, $"BackKeyManagerSubscriber START");

            var testingTarget = BackKeyManager.Instance;
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<BackKeyManager>(testingTarget, "should be an instance of BackKeyManager class!");

            var result = testingTarget.Subscriber;
            tlog.Debug(tag, "Subscriber : " + result);

            tlog.Debug(tag, $"BackKeyManagerSubscriber END (OK)");
        }
    }
}

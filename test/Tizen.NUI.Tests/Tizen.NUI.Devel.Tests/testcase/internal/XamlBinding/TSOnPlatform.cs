using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Reflection;
using System.Collections.Generic;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/XamlBinding/OnPlatform")]
    public class InternalOnPlatformTest
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
        [Description("OnPlatform constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.OnPlatform.OnPlatform C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void OnPlatformConstructor()
        {
            tlog.Debug(tag, $"OnPlatformConstructor START");

            var testingTarget = new OnPlatform<string>();
            Assert.IsNotNull(testingTarget, "Can't create success object OnPlatform.");
            Assert.IsInstanceOf<OnPlatform<string>>(testingTarget, "Should return OnPlatform instance.");

            testingTarget.Android = "Android";
            Assert.AreEqual("Android", testingTarget.Android, "Should be equal");
            testingTarget.iOS = "iOS";
            Assert.AreEqual("iOS", testingTarget.iOS, "Should be equal");
            testingTarget.WinPhone = "WinPhone";
            Assert.AreEqual("WinPhone", testingTarget.WinPhone, "Should be equal");
            testingTarget.Default = "Default";
            Assert.AreEqual("Default", testingTarget.Default, "Should be equal");

            Assert.IsNotNull(testingTarget.Platforms, "Should not be null.");

            
            tlog.Debug(tag, $"OnPlatformConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("OnPlatform constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.On.On C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void OnConstructor()
        {
            tlog.Debug(tag, $"OnPlatformConstructor START");

            var testingTarget = new On();
            Assert.IsNotNull(testingTarget, "Can't create success object On.");
            Assert.IsInstanceOf<On>(testingTarget, "Should return On instance.");

            testingTarget.Platform = new List<string>() { "Android" };
            Assert.AreEqual("Android", testingTarget.Platform[0], "Should be equal");
            testingTarget.Value = "iOS";
            Assert.AreEqual("iOS", testingTarget.Value, "Should be equal");

            tlog.Debug(tag, $"OnPlatformConstructor END");
        }
    }
}

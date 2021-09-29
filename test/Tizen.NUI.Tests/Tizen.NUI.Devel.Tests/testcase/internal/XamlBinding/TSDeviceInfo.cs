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
    [Description("internal/XamlBinding/DeviceInfo")]
    public class InternalDeviceInfoTest
    {
        private const string tag = "NUITEST";

        internal class MyDeviceInfo : DeviceInfo
        {
            public override Size PixelScreenSize => new Size(100,100);

            public override Size ScaledScreenSize => new Size(100, 100);

            public override double ScalingFactor => 1.0f;
        }

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
        [Description("DeviceInfo constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.DeviceInfo.DeviceInfo C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void DeviceInfoConstructor()
        {
            tlog.Debug(tag, $"DeviceInfoConstructor START");

            var testingTarget = new MyDeviceInfo();
            Assert.IsNotNull(testingTarget, "Can't create success object DeviceInfo.");
            Assert.IsInstanceOf<MyDeviceInfo>(testingTarget, "Should return DeviceInfo instance.");

            Assert.AreEqual(1.0, testingTarget.DisplayRound(1.0), "Should be equal");
            var ret = testingTarget.CurrentOrientation;
            testingTarget.CurrentOrientation = ret;
            Assert.AreEqual(ret, testingTarget.CurrentOrientation, "Should be equal");
            testingTarget.CurrentOrientation = DeviceOrientation.Other;
            Assert.AreEqual(DeviceOrientation.Other, testingTarget.CurrentOrientation, "Should be equal");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DeviceInfoConstructor END");
        }
    }
}

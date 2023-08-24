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
    [Description("internal/XamlBinding/OnIdiom")]
    public class InternalOnIdiomTest
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
        [Description("OnIdiom constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.OnIdiom.OnIdiom C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void OnIdiomConstructor()
        {
            tlog.Debug(tag, $"OnIdiomConstructor START");

            var testingTarget = new OnIdiom<TargetIdiom>();
            Assert.IsNotNull(testingTarget, "Can't create success object OnIdiom.");
            Device.SetIdiom(TargetIdiom.Phone);
            testingTarget.Phone = TargetIdiom.Phone;
            Assert.AreEqual(TargetIdiom.Phone, testingTarget.Phone, "Should be equal");

            Device.SetIdiom(TargetIdiom.Tablet);
            testingTarget.Tablet = TargetIdiom.Tablet;
            Assert.AreEqual(TargetIdiom.Tablet, testingTarget.Tablet, "Should be equal");

            Device.SetIdiom(TargetIdiom.Desktop);
            testingTarget.Desktop = TargetIdiom.Desktop;
            Assert.AreEqual(TargetIdiom.Desktop, testingTarget.Desktop, "Should be equal");

            Device.SetIdiom(TargetIdiom.TV);
            testingTarget.TV = TargetIdiom.TV;
            Assert.AreEqual(TargetIdiom.TV, testingTarget.TV, "Should be equal");

            Device.SetIdiom(TargetIdiom.Watch);
            testingTarget.Watch = TargetIdiom.Watch;
            Assert.AreEqual(TargetIdiom.Watch, testingTarget.Watch, "Should be equal");

            tlog.Debug(tag, $"OnIdiomConstructor END");
        }
    }
}

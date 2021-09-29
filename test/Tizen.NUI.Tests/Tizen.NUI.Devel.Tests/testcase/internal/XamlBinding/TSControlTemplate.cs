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
    [Description("internal/XamlBinding/ControlTemplate")]
    public class InternalControlTemplateTest
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
        [Description("ControlTemplate constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.ControlTemplate.ControlTemplate C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void ControlTemplateConstructor()
        {
            tlog.Debug(tag, $"ControlTemplateConstructor START");

            var testingTarget = new ControlTemplate();
            Assert.IsNotNull(testingTarget, "Can't create success object ControlTemplate.");
            Assert.IsInstanceOf<ControlTemplate>(testingTarget, "Should return ControlTemplate instance.");

            var testingTarget2 = new ControlTemplate(typeof(View));
            Assert.IsNotNull(testingTarget2, "Should not be null");
            Assert.IsInstanceOf<ControlTemplate>(testingTarget2, "Should return ControlTemplate instance.");

            tlog.Debug(tag, $"ControlTemplateConstructor END");
        }
    }
}

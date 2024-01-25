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
    [Description("internal/XamlBinding/ParameterAttribute")]
    public class InternalParameterAttributeTest
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
        [Description("ParameterAttribute constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.ParameterAttribute.ParameterAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void ParameterAttributeConstructor()
        {
            tlog.Debug(tag, $"ParameterAttributeConstructor START");

            var testingTarget = new ParameterAttribute("string");
            Assert.IsNotNull(testingTarget, "Can't create success object ParameterAttribute.");
            Assert.IsInstanceOf<ParameterAttribute>(testingTarget, "Should return ParameterAttribute instance.");

            Assert.AreEqual("string", testingTarget.Name, "Should be equal");

            tlog.Debug(tag, $"ParameterAttributeConstructor END");
        }
    }
}

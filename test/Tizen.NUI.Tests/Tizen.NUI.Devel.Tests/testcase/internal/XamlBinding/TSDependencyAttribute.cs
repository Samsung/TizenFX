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
    [Description("internal/XamlBinding/DependencyAttribute")]
    public class InternalDependencyAttributeTest
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
        [Description("DependencyAttribute constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.DependencyAttribute.DependencyAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void DependencyAttributeConstructor()
        {
            tlog.Debug(tag, $"DependencyAttributeConstructor START");

            var testingTarget = new DependencyAttribute(typeof(int));
            Assert.IsNotNull(testingTarget, "Can't create success object DependencyAttribute.");
            Assert.IsInstanceOf<DependencyAttribute>(testingTarget, "Should return DependencyAttribute instance.");

            Assert.IsNotNull(testingTarget.Implementor, "Should not be null");

            tlog.Debug(tag, $"DependencyAttributeConstructor END");
        }
    }
}

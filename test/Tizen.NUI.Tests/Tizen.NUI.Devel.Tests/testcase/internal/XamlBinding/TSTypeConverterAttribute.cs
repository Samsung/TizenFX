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
    [Description("internal/XamlBinding/TypeConverterAttribute")]
    public class InternalTypeConverterAttributeTest
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
        [Description("TypeConverterAttribute constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.TypeConverterAttribute.TypeConverterAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void TypeConverterAttributeConstructor()
        {
            tlog.Debug(tag, $"TypeConverterAttributeConstructor START");

            var testingTarget = new TypeConverterAttribute("string");
            Assert.IsNotNull(testingTarget, "Can't create success object TypeConverterAttribute.");
            Assert.IsInstanceOf<TypeConverterAttribute>(testingTarget, "Should return TypeConverterAttribute instance.");

            Assert.AreEqual("string", testingTarget.ConverterTypeName, "Should be equal");

            var testingTarget2 = new TypeConverterAttribute(typeof(string));
            Assert.IsNotNull(testingTarget2, "Can't create success object TypeConverterAttribute.");
            Assert.IsInstanceOf<TypeConverterAttribute>(testingTarget2, "Should return TypeConverterAttribute instance.");

            Assert.AreEqual(typeof(string).AssemblyQualifiedName, testingTarget2.ConverterTypeName, "Should be equal");

            Assert.AreEqual(typeof(string).AssemblyQualifiedName.GetHashCode(), testingTarget2.GetHashCode(), "Should be equal");

            tlog.Debug(tag, $"TypeConverterAttributeConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("TypeConverterAttribute Equals")]
        [Property("SPEC", "Tizen.NUI.Binding.TypeConverterAttribute.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void Equals()
        {
            tlog.Debug(tag, $"Equals START");

            var testingTarget = new TypeConverterAttribute("string");
            Assert.IsNotNull(testingTarget, "Can't create success object TypeConverterAttribute.");

            var testingTarget2 = new TypeConverterAttribute("int");
            Assert.False(testingTarget.Equals(testingTarget2), "Should be equal");
            Assert.False(testingTarget.Equals(null), "Should be equal");

            tlog.Debug(tag, $"Equals END");
        }
    }
}

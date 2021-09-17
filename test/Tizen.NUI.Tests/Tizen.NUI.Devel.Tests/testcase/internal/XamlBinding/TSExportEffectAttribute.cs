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
    [Description("internal/XamlBinding/ExportEffectAttribute")]
    public class InternalExportEffectAttributeTest
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
        [Description("ExportEffectAttribute constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.ExportEffectAttribute.ExportEffectAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void ExportEffectAttributeConstructor()
        {
            tlog.Debug(tag, $"ExportEffectAttributeConstructor START");

            var intt = typeof(int);
            var testingTarget = new ExportEffectAttribute(intt, "Unique");
            Assert.IsNotNull(testingTarget, "Can't create success object ExportEffectAttribute.");
            Assert.IsInstanceOf<ExportEffectAttribute>(testingTarget, "Should return ExportEffectAttribute instance.");

            Assert.AreEqual("Unique", testingTarget.Id, "Should be equal");
            Assert.AreEqual(intt, testingTarget.Type, "Should be equal");

            tlog.Debug(tag, $"ExportEffectAttributeConstructor END");
        }

        [Test]
        [Category("P2")]
        [Description("ExportEffectAttribute constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.ExportEffectAttribute.ExportEffectAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void ExportEffectAttributeConstructor2()
        {
            tlog.Debug(tag, $"ExportEffectAttributeConstructor2 START");
            var intt = typeof(int);
            Assert.Throws<ArgumentException>(() => new ExportEffectAttribute(intt, "Uni.que"));

            tlog.Debug(tag, $"ExportEffectAttributeConstructor2 END");
        }
    }
}

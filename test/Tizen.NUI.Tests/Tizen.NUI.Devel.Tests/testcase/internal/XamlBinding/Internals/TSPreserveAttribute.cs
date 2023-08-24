using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Reflection;
using System.Collections.Generic;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/XamlBinding/PreserveAttribute")]
    public class InternalPreserveAttributeTest
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
        [Description("PreserveAttribute constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.Internals.PreserveAttribute.PreserveAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void PreserveAttributeConstructor()
        {
            tlog.Debug(tag, $"PreserveAttributeConstructor START");
            var testingTarget = new PreserveAttribute();
            Assert.IsNotNull(testingTarget, "Can't create success object PreserveAttribute.");
            Assert.IsInstanceOf<PreserveAttribute>(testingTarget, "Should return PreserveAttribute instance.");

            var testingTarget2 = new PreserveAttribute(false, false);
            Assert.IsNotNull(testingTarget2, "Can't create success object PreserveAttribute.");
            Assert.IsInstanceOf<PreserveAttribute>(testingTarget2, "Should return PreserveAttribute instance.");

            tlog.Debug(tag, $"PreserveAttributeConstructor END");
        }
    }
}

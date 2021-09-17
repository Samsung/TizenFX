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
    [Description("internal/XamlBinding/NumericExtensions")]
    public class InternalNumericExtensionsTest
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
        [Description("NumericExtensions constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.Internals.NumericExtensions.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void Clamp()
        {
            tlog.Debug(tag, $"Clamp START");
            double d = 1.0;
            var testingTarget = NumericExtensions.Clamp(d, 0, 10);
            Assert.AreEqual(d, testingTarget, "Should be equal.");

            float f = 1.0f;
            var testingTarget2 = NumericExtensions.Clamp(f, 0, 10);
            Assert.AreEqual(f, testingTarget2, "Should be equal.");

            int i = 1;
            var testingTarget3 = NumericExtensions.Clamp(i, 0, 10);
            Assert.AreEqual(i, testingTarget3, "Should be equal.");

            tlog.Debug(tag, $"Clamp END");
        }
    }
}

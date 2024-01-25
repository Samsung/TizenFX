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
    [Description("internal/XamlBinding/ExtentsTypeConverter")]
    public class InternalExtentsTypeConverterTest
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
        [Description("ExtentsTypeConverter constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.ExtentsTypeConverter.ExtentsTypeConverter C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void ExtentsTypeConverterConstructor()
        {
            tlog.Debug(tag, $"ExtentsTypeConverterConstructor START");

            var testingTarget = new ExtentsTypeConverter();
            Assert.IsNotNull(testingTarget, "Can't create success object ExtentsTypeConverter.");

            
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("1,2,3,4"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("1"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertToString(new Extents(1,2,3,4)), "Should not be null");

            Assert.Throws<InvalidOperationException>(() => testingTarget.ConvertFromInvariantString(null));

            tlog.Debug(tag, $"ExtentsTypeConverterConstructor END");
        }

    }
}

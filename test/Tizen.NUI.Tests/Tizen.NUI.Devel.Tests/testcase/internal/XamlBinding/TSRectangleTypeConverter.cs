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
    [Description("internal/XamlBinding/RectangleTypeConverter")]
    public class InternalRectangleTypeConverterTest
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
        [Description("RectangleTypeConverter constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.RectangleTypeConverter.RectangleTypeConverter C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void RectangleTypeConverterConstructor()
        {
            tlog.Debug(tag, $"RectangleTypeConverterConstructor START");

            var testingTarget = new RectangleTypeConverter();
            Assert.IsNotNull(testingTarget, "Can't create success object RectangleTypeConverter.");

            
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("1,2,3,4"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertToString(new Rectangle(1,2,3,4)), "Should not be null");
            Assert.IsNull(testingTarget.ConvertToString(null), "Should be null");

            Assert.Throws<InvalidOperationException>(() => testingTarget.ConvertFromInvariantString(null));

            tlog.Debug(tag, $"RectangleTypeConverterConstructor END");
        }

    }
}

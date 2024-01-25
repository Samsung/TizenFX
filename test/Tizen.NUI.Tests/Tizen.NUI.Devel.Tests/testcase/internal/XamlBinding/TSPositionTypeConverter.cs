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
    [Description("internal/XamlBinding/PositionTypeConverter")]
    public class InternalPositionTypeConverterTest
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
        [Description("PositionTypeConverter constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.PositionTypeConverter.PositionTypeConverter C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void PositionTypeConverterConstructor()
        {
            tlog.Debug(tag, $"PositionTypeConverterConstructor START");

            var testingTarget = new PositionTypeConverter();
            Assert.IsNotNull(testingTarget, "Can't create success object PositionTypeConverter.");

            
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("Top"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("Bottom"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("Left"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("Right"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("Middle"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("TopLeft"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("TopCenter"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("TopRight"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("CenterLeft"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("Center"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("CenterRight"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("BottomLeft"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("BottomCenter"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("BottomRight"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("1,2,3"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("1,3"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertToString(new Position(1, 2, 3)), "Should not be null");
            Assert.IsNull(testingTarget.ConvertToString(null), "Should be null");

            Assert.Throws<InvalidOperationException>(() => testingTarget.ConvertFromInvariantString(null));

            tlog.Debug(tag, $"PositionTypeConverterConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("Position2DTypeConverter constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.Position2DTypeConverter.Position2DTypeConverter C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void Position2DTypeConverterConstructor()
        {
            tlog.Debug(tag, $"Position2DTypeConverterConstructor START");

            var testingTarget = new Position2DTypeConverter();
            Assert.IsNotNull(testingTarget, "Can't create success object Position2DTypeConverter.");


            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("1,3"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertToString(new Position2D(1, 2)), "Should not be null");
            Assert.IsNull(testingTarget.ConvertToString(null), "Should be null");

            Assert.Throws<InvalidOperationException>(() => testingTarget.ConvertFromInvariantString(null));

            tlog.Debug(tag, $"Position2DTypeConverterConstructor END");
        }
    }
}

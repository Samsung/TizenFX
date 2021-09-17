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
    [Description("internal/XamlBinding/FlowDirectionConverter")]
    public class InternalFlowDirectionConverterTest
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
        [Description("FlowDirectionConverter constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.FlowDirectionConverter.FlowDirectionConverter C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void FlowDirectionConverterConstructor()
        {
            tlog.Debug(tag, $"FlowDirectionConverterConstructor START");

            var testingTarget = new FlowDirectionConverter();
            Assert.IsNotNull(testingTarget, "Can't create success object FlowDirectionConverter.");

            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("MatchParent"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("ltr"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("rtl"), "Should not be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("inherit"), "Should not be null");

            Assert.Throws<InvalidOperationException>(() => testingTarget.ConvertFromInvariantString("null"));
            tlog.Debug(tag, $"FlowDirectionConverterConstructor END");
        }

    }
}

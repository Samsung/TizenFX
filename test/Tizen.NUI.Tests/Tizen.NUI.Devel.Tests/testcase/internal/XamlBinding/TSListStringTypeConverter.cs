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
    [Description("internal/XamlBinding/ListStringTypeConverter")]
    public class InternalListStringTypeConverterTest
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
        [Description("ListStringTypeConverter constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.ListStringTypeConverter.ListStringTypeConverter C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void ListStringTypeConverterConstructor()
        {
            tlog.Debug(tag, $"ListStringTypeConverterConstructor START");

            var testingTarget = new ListStringTypeConverter();
            Assert.IsNotNull(testingTarget, "Can't create success object ListStringTypeConverter.");

            Assert.IsNull(testingTarget.ConvertFromInvariantString(null), "Should be null");
            Assert.IsNotNull(testingTarget.ConvertFromInvariantString("A,B,C"), "Should not be null");

            tlog.Debug(tag, $"ListStringTypeConverterConstructor END");
        }

    }
}

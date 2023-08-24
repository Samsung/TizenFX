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
    [Description("internal/XamlBinding/TypeTypeConverter")]
    public class InternalTypeTypeConverterTest
    {
        private const string tag = "NUITEST";
        private string selfpath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Test_Theme.xaml";

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
        [Category("P2")]
        [Description("TypeTypeConverter ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.TypeTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void TypeTypeConverterConvertFromInvariantString()
        {
            tlog.Debug(tag, $"TypeTypeConverterConvertFromInvariantString START");

            var testingTarget = new TypeTypeConverter();
            Assert.IsNotNull(testingTarget, "Can't create success object TypeTypeConverter.");
            Assert.IsInstanceOf<TypeTypeConverter>(testingTarget, "Should return TypeTypeConverter instance.");

            Assert.Throws<NotImplementedException>(()=> testingTarget.ConvertFromInvariantString(null));

            tlog.Debug(tag, $"TypeTypeConverterConvertFromInvariantString END");
        }
    }
}

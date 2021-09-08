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
    [Description("internal/XamlBinding/UriTypeConverter")]
    public class InternalUriTypeConverterTest
    {
        private const string tag = "NUITEST";
        private string selfpath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Test_Theme.xaml";

        internal class UriTypeConverterImpl : Binding.UriTypeConverter
        {
            public UriTypeConverterImpl()
            { }
        }

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
        [Description("UriTypeConverter ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.UriTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void UriTypeConverterConvertFromInvariantString()
        {
            tlog.Debug(tag, $"UriTypeConverterConvertFromInvariantString START");

            var testingTarget = new UriTypeConverterImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object UriTypeConverter.");
            Assert.IsInstanceOf<Tizen.NUI.Binding.UriTypeConverter>(testingTarget, "Should return UriTypeConverter instance.");

            var result = testingTarget.ConvertFromInvariantString(selfpath);
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            tlog.Debug(tag, $"UriTypeConverterConvertFromInvariantString END");
        }

        [Test]
        [Category("P2")]
        [Description("UriTypeConverter ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.UriTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void UriTypeConverterConvertFromInvariantStringNullPath()
        {
            tlog.Debug(tag, $"UriTypeConverterConvertFromInvariantStringNullPath START");

            var testingTarget = new UriTypeConverterImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object UriTypeConverter.");
            Assert.IsInstanceOf<Tizen.NUI.Binding.UriTypeConverter>(testingTarget, "Should return UriTypeConverter instance.");

            var result = testingTarget.ConvertFromInvariantString(" ");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            tlog.Debug(tag, $"UriTypeConverterConvertFromInvariantStringNullPath END");
        }
    }
}

using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/PointSizeTypeConverter")]
    internal class PublicPointSizeTypeConverterTest
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
        [Description("PointSizeTypeConverter PointSizeTypeConverter")]
        [Property("SPEC", "Tizen.NUI.Binding.PointSizeTypeConverter.PointSizeTypeConverter C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void PointSizeTypeConverterConstructor()
        {
            tlog.Debug(tag, $"PointSizeTypeConverterConstructor START");

            PointSizeTypeConverter testingTarget = new PointSizeTypeConverter();
            Assert.IsNotNull(testingTarget, "null PointSizeTypeConverter");
            Assert.IsInstanceOf<PointSizeTypeConverter>(testingTarget, "Should return PointSizeTypeConverter instance.");

            tlog.Debug(tag, $"PointSizeTypeConverterConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("PointSizeTypeConverter ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.PointSizeTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void PointSizeTypeConverterConvertFromInvariantStringTest()
        {
            tlog.Debug(tag, $"PointSizeTypeConverterConvertFromInvariantStringTest START");
            
            var testingTarget = new PointSizeTypeConverter();
            Assert.IsNotNull(testingTarget, "null PointSizeTypeConverter");

            var ret = testingTarget.ConvertFromInvariantString("2, 2");
            Assert.IsNotNull(ret, "null Binding");

            try
            {
                testingTarget.ConvertFromInvariantString(null);
            }
            catch (InvalidOperationException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Pass("Caught InvalidOperationException : Passed!");
            }

            tlog.Debug(tag, $"PointSizeTypeConverterConvertFromInvariantStringTest END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PointSizeTypeConverter ConvertToString")]
        [Property("SPEC", "Tizen.NUI.Binding.PointSizeTypeConverter.ConvertToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void PointSizeTypeConverterConvertToStringTest()
        {
            tlog.Debug(tag, $"PointSizeTypeConverterConvertToStringTest START");

            var testingTarget = new PointSizeTypeConverter();
            Assert.IsNotNull(testingTarget, "null PointSizeTypeConverter");

            var ret = testingTarget.ConvertToString(20);
            Assert.AreEqual("20", ret, "Should be equal!");

            tlog.Debug(tag, $"PointSizeTypeConverterConvertToStringTest END");
        }
    }
}
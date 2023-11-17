using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/FloatGraphicsTypeConverter")]
    internal class PublicFloatGraphicsTypeConverterTest
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
        [Description("FloatGraphicsTypeConverter ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.FloatGraphicsTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertFromInvariantStringTest0()
        {
            tlog.Debug(tag, $"ConvertFromInvariantStringTest0 START");

            var testingTarget = new FloatGraphicsTypeConverter();
            Assert.IsNotNull(testingTarget, "null FloatGraphicsTypeConverter");
            
            var ret = testingTarget.ConvertFromInvariantString("1.0 | #AABBCCFF");
            Assert.IsNotNull(ret, "null ConvertFromInvariantString");
         
            tlog.Debug(tag, $"ConvertFromInvariantStringTest0 END");
        }
		
		[Test]
        [Category("P1")]
        [Description("FloatGraphicsTypeConverter ConvertToString")]
        [Property("SPEC", "Tizen.NUI.Binding.FloatGraphicsTypeConverter.ConvertToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void FloatGraphicsTypeConverterConvertToStringTest()
        {
            tlog.Debug(tag, $"FloatGraphicsTypeConverterConvertToStringTest START");

            var testingTarget = new FloatGraphicsTypeConverter();
            Assert.IsNotNull(testingTarget, "null FloatGraphicsTypeConverter");

			var ret1 = testingTarget.ConvertToString(110.0f);
            Assert.AreEqual("110", ret1, "Should be equal!");

            var ret2 = testingTarget.ConvertToString(null);
            Assert.AreEqual("", ret2, "Should be equal!");
            
            tlog.Debug(tag, $"FloatGraphicsTypeConverterConvertToStringTest END");
        }
	}
}
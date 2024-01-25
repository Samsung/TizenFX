using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/IntGraphicsTypeConverter")]
    internal class PublicIntGraphicsTypeConverterTest
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
        [Description("IntGraphicsTypeConverter ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.IntGraphicsTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertFromInvariantStringTest00()
        {
            tlog.Debug(tag, $"ConvertFromInvariantStringTest0 START");
            
            var testingTarget = new IntGraphicsTypeConverter();
            Assert.IsNotNull(testingTarget, "null IntGraphicsTypeConverter");

            var ret = testingTarget.ConvertFromInvariantString("1.0 | #AABBCCFF");
            Assert.IsNotNull(ret, "null ConvertFromInvariantString");

            try
            {
                testingTarget.ConvertFromInvariantString(null);
            }
            catch (InvalidOperationException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Pass("Caught InvalidOperationException : Passed!");
            }
			
            tlog.Debug(tag, $"ConvertFromInvariantStringTest00 END");	
        }
		
		[Test]
        [Category("P1")]
        [Description("IntGraphicsTypeConverter ConvertToString")]
        [Property("SPEC", "Tizen.NUI.Binding.IntGraphicsTypeConverter.ConvertToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void IntGraphicsTypeConverterConvertToStringTest()
        {
            tlog.Debug(tag, $"IntGraphicsTypeConverterConvertToStringTest START");

            var testingTarget = new IntGraphicsTypeConverter();
            Assert.IsNotNull(testingTarget, "null IntGraphicsTypeConverter");

            var ret1 = testingTarget.ConvertToString(null);
            Assert.AreEqual("", ret1, "Should be equal!");
            
			var ret2 = testingTarget.ConvertToString(300);
            Assert.AreEqual("300", ret2, "Should be equal!");
			
            tlog.Debug(tag, $"IntGraphicsTypeConverterConvertToStringTest END");
        }
	}
}
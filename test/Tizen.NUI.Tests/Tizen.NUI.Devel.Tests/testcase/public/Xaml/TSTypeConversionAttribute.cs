using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/TypeConversionAttribute")]
    public class PublicTypeConversionAttributeTest
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
        [Description("TypeConversionAttribute constructor")]
        [Property("SPEC", "Tizen.NUI.Xaml.TypeConversionAttribute.TypeConversionAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void TypeConversionAttributeConstructor()
        {
            tlog.Debug(tag, $"TypeConversionAttributeConstructor START");

#pragma warning disable Reflection // The code contains reflection
            var testingTarget = new TypeConversionAttribute(typeof(string));
#pragma warning restore Reflection // The code contains reflection
            Assert.IsNotNull(testingTarget, "null TypeConversionAttribute");
            Assert.IsInstanceOf<TypeConversionAttribute>(testingTarget, "Should return TypeConversionAttribute instance.");
            
            tlog.Debug(tag, $"TypeConversionAttributeConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("TypeConversionAttribute TargetType")]
        [Property("SPEC", "Tizen.NUI.Xaml.TypeConversionAttribute.TargetType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void TypeConversionAttributeTargetType()
        {
            tlog.Debug(tag, $"TypeConversionAttributeTargetType START");

            try
            {
#pragma warning disable Reflection // The code contains reflection
                Type type = typeof(string);
#pragma warning restore Reflection // The code contains reflection
                var testingTarget = new TypeConversionAttribute(type);
                Assert.AreEqual(type, testingTarget.TargetType, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TypeConversionAttributeTargetType END");
        }
    }
}
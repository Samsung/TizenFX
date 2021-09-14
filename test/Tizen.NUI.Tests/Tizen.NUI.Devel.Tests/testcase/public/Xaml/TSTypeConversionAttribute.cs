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
        private TypeConversionAttribute conversionAttr;
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            conversionAttr = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("TypeConversionAttribute TypeConversionAttribute")]
        [Property("SPEC", "Tizen.NUI.Xaml.TypeConversionAttribute.TypeConversionAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void TypeConversionAttributeConstructor()
        {
            tlog.Debug(tag, $"TypeConversionAttributeConstructor START");
            Type type = typeof(string);
            TypeConversionAttribute t2 = new TypeConversionAttribute(type);
            Assert.IsNotNull(t2, "null TypeConversionAttribute");
            Assert.IsInstanceOf<TypeConversionAttribute>(t2, "Should return TypeConversionAttribute instance.");
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

                Type type = typeof(string);
                TypeConversionAttribute t1 = new TypeConversionAttribute(type);
                Assert.AreEqual(type, t1.TargetType, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"TypeConversionAttributeTargetType END");
        }
    }
}
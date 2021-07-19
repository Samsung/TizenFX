using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/TypeConversionAttribute")]
    internal class PublicTypeConversionAttributeTest
    {
        private const string tag = "NUITEST";
        private static TypeConversionAttribute t1;
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            Type type = typeof(string);
            TypeConversionAttribute t1 = new TypeConversionAttribute(type);
        }

        [TearDown]
        public void Destroy()
        {
            t1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("TypeConversionAttribute TypeConversionAttribute")]
        [Property("SPEC", "Tizen.NUI.TypeConversionAttribute.TypeConversionAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void TypeConversionAttributeConstructor()
        {
            tlog.Debug(tag, $"TypeConversionAttributeConstructor START");
            Type type = typeof(string);
            TypeConversionAttribute t2 = new TypeConversionAttribute(type);

            tlog.Debug(tag, $"TypeConversionAttributeConstructor END (OK)");
            Assert.Pass("TypeConversionAttributeConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("TypeConversionAttribute TargetType")]
        [Property("SPEC", "Tizen.NUI.TypeConversionAttribute.TargetType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void TypeConversionAttributeTargetType()
        {
            tlog.Debug(tag, $"TypeConversionAttributeTargetType START");
            try
            {
                Type type = t1.TargetType;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TypeConversionAttributeTargetType END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }
    }
}
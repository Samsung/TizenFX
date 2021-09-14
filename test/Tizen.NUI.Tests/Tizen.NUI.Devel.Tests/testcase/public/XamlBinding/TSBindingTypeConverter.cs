using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/BindingTypeConverter")]
    internal class PublicBindingTypeConverterTest
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
        [Description("BindingTypeConverter BindingTypeConverter")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingTypeConverter.BindingTypeConverter C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void BindingTypeConverterConstructor()
        {
            tlog.Debug(tag, $"BindingTypeConverterConstructor START");
            Type type = typeof(string);
            BindingTypeConverter t2 = new BindingTypeConverter();
            Assert.IsNotNull(t2, "null BindingTypeConverter");
            Assert.IsInstanceOf<BindingTypeConverter>(t2, "Should return BindingTypeConverter instance.");
            tlog.Debug(tag, $"BindingTypeConverterConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("BindingTypeConverter  ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertFromInvariantStringTest()
        {
            tlog.Debug(tag, $"ConvertFromInvariantStringTest START");
            try
            {
                BindingTypeConverter t2 = new BindingTypeConverter();
                Assert.IsNotNull(t2, "null BindingTypeConverter");
                var b = t2.ConvertFromInvariantString("Binding");
                Assert.IsNotNull(b, "null Binding"); ;
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ConvertFromInvariantStringTest END (OK)");
        }
    }
}
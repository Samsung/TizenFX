using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/BindablePropertyConverter")]
    internal class PublicBindablePropertyConverterTest
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
        [Description("BindablePropertyConverter  ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.BindablePropertyConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertFromInvariantStringTest()
        {
            tlog.Debug(tag, $"ConvertFromInvariantStringTest START");
            try
            {
                BindablePropertyConverter t2 = new BindablePropertyConverter();
                Assert.IsNotNull(t2, "null BindablePropertyConverter");
                var b1 = t2.ConvertFromInvariantString("");
                Assert.IsNull(b1, "null Binding");
                var b2 = t2.ConvertFromInvariantString("A:B");
                Assert.IsNull(b2, "null Binding");
                var b3 = t2.ConvertFromInvariantString("A.B.C");
                Assert.IsNull(b3, "null Binding");
                var b4 = t2.ConvertFromInvariantString("A.B.C");
                Assert.IsNull(b4, "null Binding");
                var b5 = t2.ConvertFromInvariantString("GaussianBlurView.BlurStrength");
                Assert.IsNotNull(b5, "null Binding");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ConvertFromInvariantStringTest END");
        }

        [Test]
        [Category("P1")]
        [Description("BindablePropertyConverter  ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.BindablePropertyConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        public void ConvertFromInvariantStringTest2()
        {
            tlog.Debug(tag, $"ConvertFromInvariantStringTest2 START");

            BindablePropertyConverter t2 = new BindablePropertyConverter();
            Assert.Throws<XamlParseException>(() => t2.ConvertFromInvariantString("GaussianBlurView.BlurStrengthA"));

            tlog.Debug(tag, $"ConvertFromInvariantStringTest2 END");
        }
    }
}
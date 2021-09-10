using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/ColorTypeConverter")]
    internal class PublicColorTypeConverterTest
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
        [Description("ColorTypeConverter ColorTypeConverter")]
        [Property("SPEC", "Tizen.NUI.Binding.ColorTypeConverter.ColorTypeConverter C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void ColorTypeConverterConstructor()
        {
            tlog.Debug(tag, $"ColorTypeConverterConstructor START");
            Type type = typeof(string);
            ColorTypeConverter t2 = new ColorTypeConverter();
            Assert.IsNotNull(t2, "null ColorTypeConverter");
            Assert.IsInstanceOf<ColorTypeConverter>(t2, "Should return ColorTypeConverter instance.");
            tlog.Debug(tag, $"ColorTypeConverterConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("ColorTypeConverter  ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.ColorTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertFromInvariantStringTest1()
        {
            tlog.Debug(tag, $"ConvertFromInvariantStringTest1 START");
            try
            {
                ColorTypeConverter t2 = new ColorTypeConverter();
                Assert.IsNotNull(t2, "null ColorTypeConverter");
                var b = t2.ConvertFromInvariantString("Black");
                Assert.IsNotNull(b, "null Binding");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ConvertFromInvariantStringTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("ColorTypeConverter  ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.ColorTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertFromInvariantStringTest2()
        {
            tlog.Debug(tag, $"ConvertFromInvariantStringTest2 START");
            try
            {
                ColorTypeConverter t2 = new ColorTypeConverter();
                Assert.IsNotNull(t2, "null ColorTypeConverter");
                var b1 = t2.ConvertFromInvariantString("#FFF");
                Assert.IsNotNull(b1, "null Binding");
                var b2 = t2.ConvertFromInvariantString("#F");
                Assert.IsNotNull(b2, "null Binding");
                //var b3 = t2.ConvertFromInvariantString("FFF");
                //Assert.IsNotNull(b3, "null Binding");
                var b4 = t2.ConvertFromInvariantString("#FFF1");
                Assert.IsNotNull(b4, "null Binding");
                var b5 = t2.ConvertFromInvariantString("#F1F3F1");
                Assert.IsNotNull(b5, "null Binding");
                var b6 = t2.ConvertFromInvariantString("#F1F3F134");
                Assert.IsNotNull(b6, "null Binding");
                var b7 = t2.ConvertFromInvariantString("#ABG");
                Assert.IsNotNull(b7, "null Binding");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ConvertFromInvariantStringTest2 END");
        }

        [Test]
        [Category("P1")]
        [Description("ColorTypeConverter  ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.ColorTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertFromInvariantStringTest3()
        {
            tlog.Debug(tag, $"ConvertFromInvariantStringTest3 START");
            try
            {
                ColorTypeConverter t2 = new ColorTypeConverter();
                Assert.IsNotNull(t2, "null ColorTypeConverter");
                var b1 = t2.ConvertFromInvariantString("Color.Red");
                Assert.IsNotNull(b1, "null Binding");
                var b2 = t2.ConvertFromInvariantString("Color.White");
                Assert.IsNotNull(b2, "null Binding");
                var b3 = t2.ConvertFromInvariantString("Color.Green");
                Assert.IsNotNull(b3, "null Binding");
                var b4 = t2.ConvertFromInvariantString("Color.Blue");
                Assert.IsNotNull(b4, "null Binding");
                var b5 = t2.ConvertFromInvariantString("Color.Yellow");
                Assert.IsNotNull(b5, "null Binding");
                var b6 = t2.ConvertFromInvariantString("Color.Magenta");
                Assert.IsNotNull(b6, "null Binding");
                var b7 = t2.ConvertFromInvariantString("Color.Cyan");
                Assert.IsNotNull(b7, "null Binding");
                var b8 = t2.ConvertFromInvariantString("Color.Transparent");
                Assert.IsNotNull(b8, "null Binding");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ConvertFromInvariantStringTest3 END");
        }

        [Test]
        [Category("P1")]
        [Description("ColorTypeConverter  ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.ColorTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertFromInvariantStringTest4()
        {
            tlog.Debug(tag, $"ConvertFromInvariantStringTest4 START");
            try
            {
                ColorTypeConverter t2 = new ColorTypeConverter();
                Assert.IsNotNull(t2, "null ColorTypeConverter");
                var b = t2.ConvertFromInvariantString("0.5,1,1,0.8");
                Assert.IsNotNull(b, "null Binding");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ConvertFromInvariantStringTest4 END");
        }

        [Test]
        [Category("P2")]
        [Description("ColorTypeConverter  ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.ColorTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        public void ConvertFromInvariantStringTest5()
        {
            tlog.Debug(tag, $"ConvertFromInvariantStringTest5 START");

            ColorTypeConverter t2 = new ColorTypeConverter();
            Assert.Throws<InvalidOperationException>(() => t2.ConvertFromInvariantString("Color.Pink")); //Pink not exist
            
            tlog.Debug(tag, $"ConvertFromInvariantStringTest5 END");
        }

        [Test]
        [Category("P1")]
        [Description("ColorTypeConverter  ToHex")]
        [Property("SPEC", "Tizen.NUI.Binding.ColorTypeConverter.ConvertToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertToStringTest1()
        {
            tlog.Debug(tag, $"ConvertToStringTest1 START");

            ColorTypeConverter t2 = new ColorTypeConverter();
            Color red = Color.Red;
            string r = t2.ConvertToString(red);
            Assert.IsNotNull(r, "Should not be null");

            tlog.Debug(tag, $"ConvertToStringTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("ColorTypeConverter ConvertToString")]
        [Property("SPEC", "Tizen.NUI.Binding.ColorTypeConverter.ConvertToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertToStringTest2()
        {
            tlog.Debug(tag, $"ConvertToStringTest2 START");

            ColorTypeConverter t2 = new ColorTypeConverter();
            string r = t2.ConvertToString(null);
            Assert.AreEqual(string.Empty, r, "Should be equal");

            tlog.Debug(tag, $"ConvertToStringTest2 END");
        }
    }
}
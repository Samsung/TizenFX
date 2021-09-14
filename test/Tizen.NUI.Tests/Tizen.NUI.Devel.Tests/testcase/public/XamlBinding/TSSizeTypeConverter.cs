using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/SizeTypeConverter")]
    internal class PublicSizeTypeConverterTest
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
        [Description("SizeTypeConverter SizeTypeConverter")]
        [Property("SPEC", "Tizen.NUI.Binding.SizeTypeConverter.SizeTypeConverter C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void SizeTypeConverterConstructor()
        {
            tlog.Debug(tag, $"SizeTypeConverterConstructor START");
            Type type = typeof(string);
            SizeTypeConverter t2 = new SizeTypeConverter();
            Assert.IsNotNull(t2, "null SizeTypeConverter");
            Assert.IsInstanceOf<SizeTypeConverter>(t2, "Should return SizeTypeConverter instance.");
            tlog.Debug(tag, $"SizeTypeConverterConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("SizeTypeConverter  ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.SizeTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertFromInvariantStringTest()
        {
            tlog.Debug(tag, $"ConvertFromInvariantStringTest START");
            try
            {
                SizeTypeConverter t2 = new SizeTypeConverter();
                Assert.IsNotNull(t2, "null SizeTypeConverter");
                var b = t2.ConvertFromInvariantString("2,2");
                Assert.IsNotNull(b, "null Binding");
                var b2 = t2.ConvertFromInvariantString("2,2,2");
                Assert.IsNotNull(b2, "null Binding");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ConvertFromInvariantStringTest END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SizeTypeConverter  ConvertToString")]
        [Property("SPEC", "Tizen.NUI.Binding.SizeTypeConverter.ConvertToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertToStringTest2()
        {
            tlog.Debug(tag, $"ConvertToStringTest2 START");

            SizeTypeConverter t2 = new SizeTypeConverter();
            Assert.IsNotNull(t2, "null SizeTypeConverter");
            var ret1 = t2.ConvertToString(null);
            Assert.AreEqual(string.Empty, ret1, "null ImageShadow");
            var ret2 = t2.ConvertToString(new Size(2,2,2));
            Assert.IsNotNull(ret2, "null Size");

            tlog.Debug(tag, $"ConvertToStringTest2 END");
        }

        [Test]
        [Category("P2")]
        [Description("SizeTypeConverter  ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.SizeTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertFromInvariantStringTest3()
        {
            tlog.Debug(tag, $"ConvertFromInvariantStringTest3 START");

            SizeTypeConverter t2 = new SizeTypeConverter();
            Assert.IsNotNull(t2, "null SizeTypeConverter");
            Assert.Throws<InvalidOperationException>(() => t2.ConvertFromInvariantString(null));

            tlog.Debug(tag, $"ConvertFromInvariantStringTest3 END");
        }

        [Test]
        [Category("P1")]
        [Description("Size2DTypeConverter  ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.Size2DTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertFromInvariantStringTest2()
        {
            tlog.Debug(tag, $"ConvertFromInvariantStringTest2 START");
            try
            {
                Size2DTypeConverter t2 = new Size2DTypeConverter();
                Assert.IsNotNull(t2, "null Size2DTypeConverter");
                var b = t2.ConvertFromInvariantString("2,2");
                Assert.IsNotNull(b, "null Binding");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ConvertFromInvariantStringTest2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2DTypeConverter  ConvertToString")]
        [Property("SPEC", "Tizen.NUI.Binding.Size2DTypeConverter.ConvertToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertToStringTest3()
        {
            tlog.Debug(tag, $"ConvertToStringTest2 START");

            Size2DTypeConverter t2 = new Size2DTypeConverter();
            Assert.IsNotNull(t2, "null Size2DTypeConverter");
            var ret1 = t2.ConvertToString(null);
            Assert.AreEqual(string.Empty, ret1, "null ImageShadow");
            var ret2 = t2.ConvertToString(new Size2D(2, 2));
            Assert.IsNotNull(ret2, "null Size");

            tlog.Debug(tag, $"ConvertToStringTest3 END");
        }

        [Test]
        [Category("P2")]
        [Description("Size2DTypeConverter  ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.Size2DTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertFromInvariantStringTest4()
        {
            tlog.Debug(tag, $"ConvertFromInvariantStringTest4 START");

            Size2DTypeConverter t2 = new Size2DTypeConverter();
            Assert.IsNotNull(t2, "null Size2DTypeConverter");
            Assert.Throws<InvalidOperationException>(() => t2.ConvertFromInvariantString(null));

            tlog.Debug(tag, $"ConvertFromInvariantStringTest4 END");
        }
    }
}
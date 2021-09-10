using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/ShadowTypeConverter")]
    internal class PublicShadowTypeConverterTest
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
        [Description("ShadowTypeConverter ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.ShadowTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertFromInvariantStringTest1()
        {
            tlog.Debug(tag, $"ConvertFromInvariantStringTest1 START");
            ShadowTypeConverter t2 = new ShadowTypeConverter();
            Assert.IsNotNull(t2, "null ShadowTypeConverter");
            var ret1 = t2.ConvertFromInvariantString("1.0 | #AABBCCFF");
            Assert.IsNotNull(ret1, "null Shadow");
            var ret2 = t2.ConvertFromInvariantString("6.2 | #AABBCC | 5.0, 5.0");
            Assert.IsNotNull(ret2, "null Shadow");
            var ret3 = t2.ConvertFromInvariantString("8.0 | #AABBCC | 5.0, 5.0 | 7.0, 8.0");
            Assert.IsNotNull(ret3, "null Shadow");
            tlog.Debug(tag, $"ConvertFromInvariantStringTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("ShadowTypeConverter ConvertToString")]
        [Property("SPEC", "Tizen.NUI.Binding.ShadowTypeConverter.ConvertToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertToStringTest1()
        {
            tlog.Debug(tag, $"ConvertToStringTest1 START");

            ShadowTypeConverter t2 = new ShadowTypeConverter();
            Assert.IsNotNull(t2, "null ShadowTypeConverter");
            var ret1 = t2.ConvertToString(null);
            Assert.AreEqual(string.Empty, ret1, "null Shadow");
            var ret2 = t2.ConvertToString(new Shadow(8, Color.Red, new Vector2(5,5), new Vector2(1,1)));
            Assert.IsNotNull(ret2, "null Shadow");
            
            tlog.Debug(tag, $"ConvertToStringTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("ImageShadowTypeConverter  ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.ImageShadowTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertFromInvariantStringTest2()
        {
            tlog.Debug(tag, $"ConvertFromInvariantStringTest2 START");
            ImageShadowTypeConverter t2 = new ImageShadowTypeConverter();
            Assert.IsNotNull(t2, "null ImageShadowTypeConverter");
            var ret1 = t2.ConvertFromInvariantString("*Resource*/button_9patch.png");
            Assert.IsNotNull(ret1, "null ImageShadow");
            var ret2 = t2.ConvertFromInvariantString("*Resource*/button_9patch.png | 5.0, 5.0");
            Assert.IsNotNull(ret2, "null ImageShadow");
            var ret3 = t2.ConvertFromInvariantString("*Resource*/button_9patch.png | 5.0, 5.0 | 7.0, 8.0");
            Assert.IsNotNull(ret3, "null ImageShadow");
            tlog.Debug(tag, $"ConvertFromInvariantStringTest2 END");
        }

        [Test]
        [Category("P1")]
        [Description("ImageShadowTypeConverter  ConvertToString")]
        [Property("SPEC", "Tizen.NUI.Binding.ImageShadowTypeConverter.ConvertToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertToStringTest2()
        {
            tlog.Debug(tag, $"ConvertToStringTest2 START");

            ImageShadowTypeConverter t2 = new ImageShadowTypeConverter();
            Assert.IsNotNull(t2, "null ImageShadowTypeConverter");
            var ret1 = t2.ConvertToString(null);
            Assert.AreEqual(string.Empty, ret1, "null ImageShadow");
            var ret2 = t2.ConvertToString(new ImageShadow("*Resource*/button_9patch.png", new Vector2(5,5), new Vector2(7,8)));
            Assert.IsNotNull(ret2, "null ImageShadow");

            tlog.Debug(tag, $"ConvertToStringTest2 END");
        }
    }
}
using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/TypeConverter")]
    internal class PublicTypeConverterTest
    {
        private const string tag = "NUITEST";

        internal class MyTypeConverter : TypeConverter
        {
        }

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
        [Category("P2")]
        [Description("TypeConverter CanConvertFrom")]
        [Property("SPEC", "Tizen.NUI.Binding.TypeConverter.CanConvertFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void CanConvertFromTest1()
        {
            tlog.Debug(tag, $"CanConvertFromTest1 START");
            MyTypeConverter tc = new MyTypeConverter();
            Assert.IsNotNull(tc, "null TypeConverter");
            Assert.Throws<ArgumentNullException>(() => tc.CanConvertFrom(null));
            
            tlog.Debug(tag, $"CanConvertFromTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("TypeConverter ConvertFrom")]
        [Property("SPEC", "Tizen.NUI.Binding.TypeConverter.ConvertFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertFromTest1()
        {
            tlog.Debug(tag, $"ConvertFromTest1 START");

            MyTypeConverter tc = new MyTypeConverter();
            Assert.IsNotNull(tc, "null TypeConverter");
            var ret = tc.ConvertFrom(null);
            Assert.IsNull(ret, "Should be null");

            ret = tc.ConvertFrom(null, null);
            Assert.IsNull(ret, "Should be null");
            tlog.Debug(tag, $"ConvertFromTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("ImageTypeConverter  ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.TypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ConvertFromInvariantStringTestc()
        {
            tlog.Debug(tag, $"ConvertFromInvariantStringTestc START");
            MyTypeConverter tc = new MyTypeConverter();
            Assert.IsNotNull(tc, "null TypeConverter");
            var ret1 = tc.ConvertFromInvariantString(null);
            Assert.IsNull(ret1, "Should be null");

            ret1 = tc.ConvertToString(null);
            Assert.IsNull(ret1, "Should be null");
            
            tlog.Debug(tag, $"ConvertFromInvariantStringTestc END");
        }

    }
}
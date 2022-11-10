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
        public void TypeConverterCanConvertFrom()
        {
            tlog.Debug(tag, $"TypeConverterCanConvertFrom START");

            var testingTarget = new MyTypeConverter();
            Assert.IsNotNull(testingTarget, "null TypeConverter");

            Assert.Throws<ArgumentNullException>(() => testingTarget.CanConvertFrom(null));
            
            tlog.Debug(tag, $"TypeConverterCanConvertFrom END");
        }

        [Test]
        [Category("P1")]
        [Description("TypeConverter ConvertFrom")]
        [Property("SPEC", "Tizen.NUI.Binding.TypeConverter.ConvertFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Obsolete]
        public void TypeConverterConvertFrom()
        {
            tlog.Debug(tag, $"TypeConverterConvertFrom START");

            var testingTarget = new MyTypeConverter();
            Assert.IsNotNull(testingTarget, "null TypeConverter");

            var ret = testingTarget.ConvertFrom(null);
            Assert.IsNull(ret, "Should be null");

            ret = testingTarget.ConvertFrom(null, null);
            Assert.IsNull(ret, "Should be null");

            tlog.Debug(tag, $"TypeConverterConvertFrom END");
        }

        [Test]
        [Category("P1")]
        [Description("TypeConverter ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.TypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void TypeConverterConvertFromInvariantString()
        {
            tlog.Debug(tag, $"TypeConverterConvertFromInvariantString START");

            var testingTarget = new MyTypeConverter();
            Assert.IsNotNull(testingTarget, "null TypeConverter");

            var ret1 = testingTarget.ConvertFromInvariantString(null);
            Assert.IsNull(ret1, "Should be null");

            ret1 = testingTarget.ConvertToString(null);
            Assert.IsNull(ret1, "Should be null");
            
            tlog.Debug(tag, $"TypeConverterConvertFromInvariantString END");
        }
    }
}
using NUnit.Framework;
using System;
using System.Xml;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/StaticResourceExtension")]
    public class PublicStaticResourceExtensionTest
    {
        private const string tag = "NUITEST";
        private StaticResourceExtension staticRes;
		
		private class ServiceProviderImpl : IServiceProvider
        {
            private static readonly object service = new object();

            public object GetService(Type type)
            {
                return service;
            }
        }
		
		private class XmlLineInfoImplent : IXmlLineInfo
        {
            public int LineNumber => 16;

            public int LinePosition => 8;

            public bool HasLineInfo()
            {
                return true;
            }
        }
		
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            staticRes = new StaticResourceExtension();
        }

        [TearDown]
        public void Destroy()
        {
            staticRes = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("StaticResourceExtension Key")]
        [Property("SPEC", "Tizen.NUI.Xaml.StaticResourceExtension.Key A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void StaticResourceExtensionKey()
        {
            tlog.Debug(tag, $"StaticResourceExtensionKey START");
            try
            {
                string key = staticRes.Key;
                staticRes.Key = key;
                Assert.AreEqual(key, staticRes.Key, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            tlog.Debug(tag, $"StaticResourceExtensionKey END");
        }

        [Test]
        [Category("P2")]
        [Description("StaticResourceExtension Key")]
        [Property("SPEC", "Tizen.NUI.Xaml.StaticResourceExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ProvideValueTest()
        {
            tlog.Debug(tag, $"ProvideValueTest START");

            var sr = new StaticResourceExtension();
            Assert.Throws<ArgumentNullException>(() => sr.ProvideValue(null));

            tlog.Debug(tag, $"ProvideValueTest END");
        }

        [Test]
        [Category("P2")]
        [Description("StaticResourceExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.Xaml.StaticResourceExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ProvideValueTest2()
        {
            tlog.Debug(tag, $"ProvideValueTest2 START");

            var sr = new StaticResourceExtension();
            Assert.Throws<XamlParseException>(() => sr.ProvideValue(new ServiceProviderImpl()));

            tlog.Debug(tag, $"ProvideValueTest2 END");
        }

        [Test]
        [Category("P2")]
        [Description("StaticResourceExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.Xaml.StaticResourceExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ProvideValueTest3()
        {
            tlog.Debug(tag, $"ProvideValueTest3 START");

            var sr = new StaticResourceExtension();
            sr.Key = "Key";
            Assert.Throws<ArgumentException>(() => sr.ProvideValue(new ServiceProviderImpl()));

            tlog.Debug(tag, $"ProvideValueTest3 END");
        }
    }
}
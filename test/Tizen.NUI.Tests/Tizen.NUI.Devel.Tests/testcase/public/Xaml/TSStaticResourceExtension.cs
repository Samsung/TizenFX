using NUnit.Framework;
using System;
using System.Xml;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/StaticResourceExtension")]
    internal class PublicStaticResourceExtensionTest
    {
        private const string tag = "NUITEST";
        private static StaticResourceExtension resourceExtension;
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            resourceExtension = new StaticResourceExtension();
        }

        [TearDown]
        public void Destroy()
        {
            resourceExtension = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("StaticResourceExtension Key")]
        [Property("SPEC", "Tizen.NUI.StaticResourceExtension.Key A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StaticResourceExtensionKey()
        {
            tlog.Debug(tag, $"StaticResourceExtensionKey START");
            try
            {
                var result = resourceExtension.Key;
                tlog.Debug(tag, "Key : " + result);
                resourceExtension.Key = "size";
                tlog.Debug(tag, "Key : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            tlog.Debug(tag, $"StaticResourceExtensionKey END (OK)");
            Assert.Pass("StaticResourceExtensionKey");
        }

        private class ServiceProviderImplemente : IServiceProvider
        {
            private static readonly object service = new object();

            public object GetService(Type type)
            {
                return service;
            }
        }

        [Test]
        [Category("P1")]
        [Description("StaticResourceExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.StaticResourceExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void StaticResourceExtensionProvideValue()
        {
            tlog.Debug(tag, $"StaticResourceExtensionProvideValue START");

            try
            {
                ServiceProviderImplemente ss = new ServiceProviderImplemente();

                resourceExtension.Key = "myKey";
                resourceExtension.ProvideValue(ss);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"StaticResourceExtensionProvideValue END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("StaticResourceExtension ProvideValue. Null serviceProvider.")]
        [Property("SPEC", "Tizen.NUI.StaticResourceExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StaticResourceExtensionProvideValueWithNullServiceProvder()
        {
            tlog.Debug(tag, $"StaticResourceExtensionProvideValueWithNullServiceProvder START");
            try
            {
                resourceExtension.ProvideValue(null);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"StaticResourceExtensionProvideValueWithNullServiceProvder END (OK)");
                Assert.Pass("Caught ArgumentNullException : passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("StaticResourceExtension ProvideValue. Null Key.")]
        [Property("SPEC", "Tizen.NUI.StaticResourceExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StaticResourceExtensionProvideValueWithNullKey()
        {
            tlog.Debug(tag, $"StaticResourceExtensionProvideValueWithNullKey START");

            var serviceProvider = new ServiceProviderImplemente();
            Assert.IsNotNull(serviceProvider, "Can't create success object IServiceProvider");
            Assert.IsInstanceOf<IServiceProvider>(serviceProvider, "Should be an instance of IServiceProvider type.");

            resourceExtension.Key = null;

            try
            {
                resourceExtension.ProvideValue(serviceProvider);
            }
            catch (XamlParseException e)
            {
                tlog.Debug(tag, $"StaticResourceExtensionProvideValueWithNullKey END (OK)");
                Assert.Pass("Caught XamlParseException : passed!");
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

        [Test]
        [Category("P1")]
        [Description("StaticResourceExtension GetApplicationLevelResource")]
        [Property("SPEC", "Tizen.NUI.StaticResourceExtension.GetApplicationLevelResource M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void StaticResourceExtensionGetApplicationLevelResource()
        {
            tlog.Debug(tag, $"StaticResourceExtensionGetApplicationLevelResource START");

            try
            {
                XmlLineInfoImplent xx = new XmlLineInfoImplent();
                resourceExtension.GetApplicationLevelResource("mykey", xx);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, $"StaticResourceExtensionGetApplicationLevelResource END (OK)");
                Assert.Fail("Caught Exception : failed!");
            }
        }
    }
}
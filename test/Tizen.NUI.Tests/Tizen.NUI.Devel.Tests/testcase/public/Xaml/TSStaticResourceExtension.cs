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
        private static StaticResourceExtension s1;
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            s1 = new StaticResourceExtension();
        }

        [TearDown]
        public void Destroy()
        {
            s1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("StaticResourceExtension Key")]
        [Property("SPEC", "Tizen.NUI.StaticResourceExtension.Key A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void StaticResourceExtensionKey()
        {
            tlog.Debug(tag, $"StaticResourceExtensionKey START");
            try
            {
                string key = s1.Key;
                s1.Key = key;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"StaticResourceExtensionKey END (OK)");
            Assert.Pass("StaticResourceExtensionKey");
        }

        private class ServiceProviderImplementer : IServiceProvider
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
                ServiceProviderImplementer ss = new ServiceProviderImplementer();

                s1.Key = "myKey";
                s1.ProvideValue(ss);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"StaticResourceExtensionProvideValue END (OK)");
                Assert.Pass("Caught Exception : passed!");
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
                s1.GetApplicationLevelResource("mykey", xx);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"StaticResourceExtensionGetApplicationLevelResource END (OK)");
            Assert.Pass("StaticResourceExtensionGetApplicationLevelResource");
        }
    }
}
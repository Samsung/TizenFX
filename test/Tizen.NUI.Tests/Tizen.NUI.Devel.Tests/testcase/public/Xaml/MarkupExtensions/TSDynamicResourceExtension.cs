using NUnit.Framework;
using System;
using System.Xml;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/MarkupExtensions/DynamicResourceExtension")]
    public class PublicDynamicResourceExtensionTest
    {
        private const string tag = "NUITEST";
        private DynamicResourceExtension resExtension;

        internal class IServiceProviderImpl : IServiceProvider
        {
            public object GetService(Type serviceType) { return null; }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            resExtension = new DynamicResourceExtension();
        }

        [TearDown]
        public void Destroy()
        {
            resExtension = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("DynamicResourceExtension Key")]
        [Property("SPEC", "Tizen.NUI.Xaml.DynamicResourceExtension.Key A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void DynamicResourceExtensionKey()
        {
            tlog.Debug(tag, $"DynamicResourceExtensionKey START");

            try
            {
                string key = resExtension.Key;
                resExtension.Key = key;
                Assert.AreEqual(key, resExtension.Key, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"DynamicResourceExtensionKey END");
        }

        [Test]
        [Category("P1")]
        [Description("DynamicResourceExtension Key")]
        [Property("SPEC", "Tizen.NUI.Xaml.DynamicResourceExtension.Key M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void DynamicResourceExtensionProvideValue()
        {
            tlog.Debug(tag, $"DynamicResourceExtensionProvideValue START");

            try
            {
                resExtension.Key = "Key";
                resExtension.ProvideValue(new IServiceProviderImpl());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"DynamicResourceExtensionProvideValue END");
        }

        [Test]
        [Category("P2")]
        [Description("DynamicResourceExtension Key")]
        [Property("SPEC", "Tizen.NUI.Xaml.DynamicResourceExtension.Key M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void DynamicResourceExtensionProvideValue2()
        {
            tlog.Debug(tag, $"DynamicResourceExtensionProvideValue2 START");
            resExtension.Key = null;
            Assert.Throws<XamlParseException>(() => resExtension.ProvideValue(new IServiceProviderImpl()));
            tlog.Debug(tag, $"DynamicResourceExtensionProvideValue2 END");
        }
    }
}
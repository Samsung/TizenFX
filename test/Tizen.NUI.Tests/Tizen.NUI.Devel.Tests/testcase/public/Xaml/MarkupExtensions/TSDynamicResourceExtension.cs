using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/MarkupExtensions/DynamicResourceExtension")]
    public class PublicDynamicResourceExtensionTest
    {
        private const string tag = "NUITEST";
        private static DynamicResourceExtension d1;

        internal class IServiceProviderimplement : IServiceProvider
        {
            public object GetService(Type serviceType)
            {
                return null;
            }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            d1 = new DynamicResourceExtension();
        }

        [TearDown]
        public void Destroy()
        {
            d1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("DynamicResourceExtension Key")]
        [Property("SPEC", "Tizen.NUI.DynamicResourceExtension.Key A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void DynamicResourceExtensionKey()
        {
            tlog.Debug(tag, $"DynamicResourceExtensionKey START");

            try
            {
                string tmp = d1.Key;
                d1.Key = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"DynamicResourceExtensionKey END (OK)");
            Assert.Pass("DynamicResourceExtensionKey");
        }

        [Test]
        [Category("P1")]
        [Description("DynamicResourceExtension Key")]
        [Property("SPEC", "Tizen.NUI.DynamicResourceExtension.Key A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void DynamicResourceExtensionProvideValue()
        {
            tlog.Debug(tag, $"DynamicResourceExtensionProvideValue START");

            try
            {
                IServiceProviderimplement serviceProviderimplement = new IServiceProviderimplement();
                d1.Key = "myKey";
                d1.ProvideValue(serviceProviderimplement);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"DynamicResourceExtensionProvideValue END (OK)");
            Assert.Pass("DynamicResourceExtensionProvideValue");
        }
    }
}
using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/MarkupExtensions/ReferenceExtension")]
    public class PublicReferenceExtensionTest
    {
        private const string tag = "NUITEST";
        private static ReferenceExtension r1;

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
            r1 = new ReferenceExtension();
        }

        [TearDown]
        public void Destroy()
        {
            r1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("ReferenceExtension Name")]
        [Property("SPEC", "Tizen.NUI.ReferenceExtension.Name A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ReferenceExtensionName()
        {
            tlog.Debug(tag, $"ReferenceExtensionName START");

            try
            {
                string tmp = r1.Name;
                r1.Name = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ReferenceExtensionName END (OK)");
            Assert.Pass("ReferenceExtensionName");
        }

        [Test]
        [Category("P1")]
        [Description("ReferenceExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.ReferenceExtension.ProvideValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ReferenceExtensionProvideValue()
        {
            tlog.Debug(tag, $"ReferenceExtensionProvideValue START");

            try
            {
                IServiceProviderimplement serviceProviderimplement = new IServiceProviderimplement();
                r1.ProvideValue(serviceProviderimplement);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ReferenceExtensionProvideValue END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }
    }
}
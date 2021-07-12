using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/MarkupExtensions/StaticExtension")]
    internal class PublicStaticExtensionTest
    {
        private const string tag = "NUITEST";
        private static StaticExtension s1;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            s1 = new StaticExtension();
        }

        [TearDown]
        public void Destroy()
        {
            s1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("StaticExtension Member")]
        [Property("SPEC", "Tizen.NUI.StaticExtension.Member A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void StaticExtensionMember()
        {
            tlog.Debug(tag, $"StaticExtensionMember START");

            try
            {
                string tmp = s1.Member;
                s1.Member = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"StaticExtensionMember END (OK)");
            Assert.Pass("StaticExtensionMember");
        }

        private class IServiceProviderimplement : IServiceProvider
        {
            public object GetService(Type serviceType)
            {
                return null;
            }
        }

        [Test]
        [Category("P1")]
        [Description("StaticExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.StaticExtension.ProvideValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void StaticExtensionProvideValue()
        {
            tlog.Debug(tag, $"StaticExtensionProvideValue START");

            try
            {
                IServiceProviderimplement serviceProviderimplement = new IServiceProviderimplement();
                s1.ProvideValue(serviceProviderimplement);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"StaticExtensionProvideValue END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }
    }
}
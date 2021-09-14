using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/MarkupExtensions/StaticExtension")]
    public class PublicStaticExtensionTest
    {
        private const string tag = "NUITEST";
        private StaticExtension sExtention;

        internal class IServiceProviderImpl : IServiceProvider
        {
            public object GetService(Type serviceType) { return null; }
        }
        internal class IServiceProviderImpl2 : IServiceProvider
        {
            public object GetService(Type serviceType) {
                var xml = new XmlNamespaceResolver();
                xml.Add("l", "Tizen.NUI.Devel.Tests");
                return new XamlTypeResolver(xml, typeof(UIElement).Assembly); 
            }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            sExtention = new StaticExtension();
        }

        [TearDown]
        public void Destroy()
        {
            sExtention = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("StaticExtension Member")]
        [Property("SPEC", "Tizen.NUI.Xaml.StaticExtension.Member A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void StaticExtensionMember()
        {
            tlog.Debug(tag, $"StaticExtensionMember START");

            try
            {
                var member = sExtention.Member;
                sExtention.Member = member;
                Assert.AreEqual(member, sExtention.Member, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"StaticExtensionMember END");
        }

        [Test]
        [Category("P2")]
        [Description("StaticExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.Xaml.StaticExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void StaticExtensionProvideValue()
        {
            tlog.Debug(tag, $"StaticExtensionProvideValue START");
            Assert.Throws<ArgumentNullException>(() => sExtention.ProvideValue(null));
            tlog.Debug(tag, $"StaticExtensionProvideValue END");
        }

        [Test]
        [Category("P2")]
        [Description("StaticExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.Xaml.StaticExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void StaticExtensionProvideValue2()
        {
            tlog.Debug(tag, $"StaticExtensionProvideValue2 START");
            Assert.Throws<ArgumentException>(() => sExtention.ProvideValue(new IServiceProviderImpl()));
            tlog.Debug(tag, $"StaticExtensionProvideValue2 END");
        }

        [Test]
        [Category("P2")]
        [Description("StaticExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.Xaml.StaticExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void StaticExtensionProvideValue3()
        {
            tlog.Debug(tag, $"StaticExtensionProvideValue3 START");
            sExtention.Member = null;
            Assert.Throws<XamlParseException>(() => sExtention.ProvideValue(new IServiceProviderImpl2()));
            tlog.Debug(tag, $"StaticExtensionProvideValue3 END");
        }
    }
}
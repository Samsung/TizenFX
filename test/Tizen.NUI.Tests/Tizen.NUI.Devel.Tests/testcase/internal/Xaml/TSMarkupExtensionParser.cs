using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/MarkupExtensionParser")]
    public class InternalMarkupExtensionParserTest
    {
        private const string tag = "NUITEST";
        private MarkupExtensionParser extParser;

        internal class IServiceProviderImpl : IServiceProvider
        {
            public object GetService(Type serviceType) { return null; }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            extParser = new MarkupExtensionParser();
        }

        [TearDown]
        public void Destroy()
        {
            extParser = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("MarkupExtensionParser Parse")]
        [Property("SPEC", "Tizen.NUI.Xaml.MarkupExtensionParser.Parse M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void MarkupExtensionParserParse()
        {
            tlog.Debug(tag, $"MarkupExtensionParserParse START");

            try
            {
                string str = new string('a', 4);
                IServiceProviderImpl provider = new IServiceProviderImpl();
                Assert.IsNotNull(provider, "null IServiceProviderImplement");
                extParser.Parse("myMatch", ref str, provider);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MarkupExtensionParserParse END");
        }

        [Test]
        [Category("P1")]
        [Description("MarkupExtensionParser Parse")]
        [Property("SPEC", "Tizen.NUI.Xaml.MarkupExtensionParser.Parse M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void MarkupExtensionParserParse2()
        {
            tlog.Debug(tag, $"MarkupExtensionParserParse2 START");

            try
            {
                string str = "{Binding Red}";
                IServiceProviderImpl provider = new IServiceProviderImpl();
                Assert.IsNotNull(provider, "null IServiceProviderImplement");
                extParser.Parse("Binding", ref str, provider);
                string str2 = "{TemplateBinding Red}";
                extParser.Parse("TemplateBinding", ref str2, provider);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MarkupExtensionParserParse2 END");
        }

        [Test]
        [Category("P2")]
        [Description("MarkupExtensionParser Parse")]
        [Property("SPEC", "Tizen.NUI.Xaml.MarkupExtensionParser.Parse M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void MarkupExtensionParserParse3()
        {
            tlog.Debug(tag, $"MarkupExtensionParserParse3 START");

            try
            {
                string str = "{Binding Red}";
                IServiceProviderImpl provider = new IServiceProviderImpl();
                Assert.IsNotNull(provider, "null IServiceProviderImplement");
                string str3 = "}";
                extParser.Parse("StaticResource", ref str3, provider);
            }
            catch (XamlParseException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.True(true, $"Should caught Exception {e.Message.ToString()}");
            }

            tlog.Debug(tag, $"MarkupExtensionParserParse3 END");
        }
    }
}
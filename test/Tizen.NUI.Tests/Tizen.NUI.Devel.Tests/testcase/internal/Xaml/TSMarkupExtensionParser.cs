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
        [Property("SPEC", "Tizen.NUI.MarkupExtensionParser.Parse M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void MarkupExtensionParserParse()
        {
            tlog.Debug(tag, $"MarkupExtensionParserParse START");

            try
            {
                string str = new string('a', 4);
                IServiceProviderImpl provider = new IServiceProviderImpl();
                extParser.Parse("myMatch", ref str, provider);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MarkupExtensionParserParse END");
        }
    }
}
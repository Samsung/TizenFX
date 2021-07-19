using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/MarkupExtensionParser")]
    internal class PublicMarkupExtensionParserTest
    {
        private const string tag = "NUITEST";
        private static MarkupExtensionParser m1;
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            m1 = new MarkupExtensionParser();
        }

        [TearDown]
        public void Destroy()
        {
            m1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        private class IServiceProviderImplement : IServiceProvider
        {
            public object GetService(Type serviceType)
            {
                return null;
            }
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
                string s1 = new string('a', 4);
                IServiceProviderImplement serviceProviderImplement = new IServiceProviderImplement();
                m1.Parse("myMatch", ref s1, serviceProviderImplement);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"MarkupExtensionParserParse END (OK)");
            Assert.Pass("MarkupExtensionParserParse");
        }
    }
}
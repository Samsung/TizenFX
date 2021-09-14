using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/MarkupExpressionParser")]
    public class InternalMarkupExpressionParserTest
    {
        private const string tag = "NUITEST";
        private MarkupExpressionParserImpl expParser;

        internal class MarkupExpressionParserImpl : MarkupExpressionParser
        {
            protected override void SetPropertyValue(string prop, string strValue, object value, IServiceProvider serviceProvider) { }
            
            public void CallHandleProperty()
            {
                IServiceProviderImpl provider = new IServiceProviderImpl();

                string str = new string('a', 1);
                HandleProperty("length", provider, ref str, true);
            }

            public void CallGetNextPiece()
            {
                string str = new string('a', 4);
                GetNextPiece(ref str, out char next);
            }
        }

        public class IServiceProviderImpl : IServiceProvider
        {
            public object GetService(Type serviceType) { return null; }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            expParser = new MarkupExpressionParserImpl();
        }

        [TearDown]
        public void Destroy()
        {
            expParser = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("MarkupExpressionParser MatchMarkup")]
        [Property("SPEC", "Tizen.NUI.MarkupExpressionParser.MatchMarkup M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void MarkupExpressionParserMatchMarkup()
        {
            tlog.Debug(tag, $"MarkupExpressionParserMatchMarkup START");

            try
            {
                string str = new string('a', 1);
                MarkupExpressionParser.MatchMarkup(out str, "a+b", out int result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MarkupExpressionParserMatchMarkup END");
        }

        [Test]
        [Category("P1")]
        [Description("MarkupExpressionParser HandleProperty")]
        [Property("SPEC", "Tizen.NUI.MarkupExpressionParser.HandleProperty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void MarkupExpressionParserHandleProperty()
        {
            tlog.Debug(tag, $"MarkupExpressionParserHandleProperty START");

            try
            {
                expParser.CallHandleProperty();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MarkupExpressionParserHandleProperty END");
        }
    }
}
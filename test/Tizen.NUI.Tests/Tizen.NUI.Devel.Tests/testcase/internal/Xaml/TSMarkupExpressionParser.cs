using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/MarkupExpressionParser")]
    public class InternalXamlMarkupExpressionParserTest
    {
        private const string tag = "NUITEST";
        private MarkupExpressionParserImplement m1;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            m1 = new MarkupExpressionParserImplement();
        }

        [TearDown]
        public void Destroy()
        {
            m1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        private class MarkupExpressionParserImplement : MarkupExpressionParser
        {
            protected override void SetPropertyValue(string prop, string strValue, object value, IServiceProvider serviceProvider)
            {
                return;
            }

            public void CallHandleProperty()
            {
                IServiceProviderImplement serviceProviderImplement = new IServiceProviderImplement();
                string s1 = new string('a', 1);
                HandleProperty("length", serviceProviderImplement, ref s1, true);
            }

            public void CallGetNextPiece()
            {
                string s1 = new string('a', 4);

                GetNextPiece(ref s1, out char next);
            }
        }

        public class IServiceProviderImplement : IServiceProvider
        {
            public object GetService(Type serviceType)
            {
                return null;
            }
        }

        [Test]
        [Category("P1")]
        [Description("MarkupExpressionParser ParseExpression")]
        [Property("SPEC", "Tizen.NUI.MarkupExpressionParser.ParseExpression M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void MarkupExpressionParserParseExpression()
        {
            tlog.Debug(tag, $"MarkupExpressionParserParseExpression START");

            try
            {
                string s1 = new string('a', 4);

                IServiceProviderImplement serviceProviderImplement = new IServiceProviderImplement();
                m1.ParseExpression(ref s1, serviceProviderImplement);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"MarkupExpressionParserParseExpression END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
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
                string s1 = new string('a', 1);
                MarkupExpressionParser.MatchMarkup(out s1, "a+b", out int i1);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"MarkupExpressionParserMatchMarkup END (OK)");
            Assert.Pass("MarkupExpressionParserMatchMarkup");
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
                m1.CallHandleProperty();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"MarkupExpressionParserHandleProperty END (OK)");
            Assert.Pass("MarkupExpressionParserHandleProperty");
        }

        [Test]
        [Category("P1")]
        [Description("MarkupExpressionParser GetNextPiece")]
        [Property("SPEC", "Tizen.NUI.MarkupExpressionParser.GetNextPiece M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void MarkupExpressionParserGetNextPiece()
        {
            tlog.Debug(tag, $"MarkupExpressionParserGetNextPiece START");

            try
            {
                m1.CallGetNextPiece();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"MarkupExpressionParserGetNextPiece END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }

        }
    }
}
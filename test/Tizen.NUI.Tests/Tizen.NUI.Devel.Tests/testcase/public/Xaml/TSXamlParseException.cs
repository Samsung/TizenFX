using NUnit.Framework;
using System;
using System.Xml;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/XamlParseException ")]
    public class PublicXamlParseExceptionTest
    {
        private const string tag = "NUITEST";
        private XamlParseException xamlParse;

        internal class XmlLineInfoImpl : IXmlLineInfo
        {
            public int LineNumber => 0;
            public int LinePosition => 0;
            public bool HasLineInfo() => false;
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            xamlParse = new XamlParseException("myMessage");
        }

        [TearDown]
        public void Destroy()
        {
            xamlParse = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("XamlParseException XamlParseException")]
        [Property("SPEC", "Tizen.NUI.XamlParseException.XamlParseException C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void XamlParseExceptionConstructor()
        {
            tlog.Debug(tag, $"XamlParseExceptionConstructor START");

            var testingTarget = new XamlParseException();
            Assert.IsNotNull(testingTarget, "null XamlParseException");
            Assert.IsInstanceOf<XamlParseException>(testingTarget, "Should return XamlParseException instance.");
            
            testingTarget = null;
            tlog.Debug(tag, $"XamlParseExceptionConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlParseException XamlParseException")]
        [Property("SPEC", "Tizen.NUI.XamlParseException.XamlParseException C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void XamlParseExceptionConstructorWithMessage()
        {
            tlog.Debug(tag, $"XamlParseExceptionConstructorWithMessage START");

            var testingTarget = new XamlParseException("myMessage", new Exception());
            Assert.IsNotNull(testingTarget, "null XamlParseException");
            Assert.IsInstanceOf<XamlParseException>(testingTarget, "Should return XamlParseException instance.");

            testingTarget = null;
            tlog.Debug(tag, $"XamlParseExceptionConstructorWithMessage END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlParseException XmlInfo ")]
        [Property("SPEC", "Tizen.NUI.XamlParseException.XmlInfo A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlParseExceptionXmlInfo()
        {
            tlog.Debug(tag, $"XamlParseExceptionXmlInfo START");

            try
            {
                var result = (XmlLineInfoImpl)xamlParse.XmlInfo;
                tlog.Debug(tag, "XmlInfo : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlParseExceptionXmlInfo END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlParseException UnformattedMessage ")]
        [Property("SPEC", "Tizen.NUI.XamlParseException.UnformattedMessage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlParseExceptionUnformattedMessage()
        {
            tlog.Debug(tag, $"XamlParseExceptionUnformattedMessage START");

            try
            {
                var result = xamlParse.UnformattedMessage;
                tlog.Debug(tag, "UnformattedMessage : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlParseExceptionUnformattedMessage END");
        }
    }
}
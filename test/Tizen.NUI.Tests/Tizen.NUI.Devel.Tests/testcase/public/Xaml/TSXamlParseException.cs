using NUnit.Framework;
using System;
using System.Xml;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/XamlParseException ")]
    internal class PublicXamlParseExceptionTest
    {
        private const string tag = "NUITEST";
        private XamlParseException xamlParseException;
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            xamlParseException = new XamlParseException("Parse Exception!");
        }

        [TearDown]
        public void Destroy()
        {
            xamlParseException = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        internal class XmlLineInfoImplement : IXmlLineInfo
        {
            public int LineNumber => 0;

            public int LinePosition => 0;

            public bool HasLineInfo() => false;
        }

        [Test]
        [Category("P1")]
        [Description("XamlParseException XamlParseException")]
        [Property("SPEC", "Tizen.NUI.XamlParseException.XamlParseException C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void XamlParseExceptionConstructor()
        {
            tlog.Debug(tag, $"XamlParseExceptionConstructor START");

            var testingTarget = new XamlParseException();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<XamlParseException>(testingTarget, "should be an instance of XamlParseException class!");

            tlog.Debug(tag, $"XamlParseExceptionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("XamlParseException constructor. With message.")]
        [Property("SPEC", "Tizen.NUI.XamlParseException.XamlParseException C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void XamlParseExceptionConstructorWithMessage()
        {
            tlog.Debug(tag, $"XamlParseExceptionConstructorWithMessage START");

            var testingTarget = new XamlParseException("Xaml Parsed Failed!");
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<XamlParseException>(testingTarget, "should be an instance of XamlParseException class!");

            tlog.Debug(tag, $"XamlParseExceptionConstructorWithMessage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("XamlParseException constructor. With innerException.")]
        [Property("SPEC", "Tizen.NUI.XamlParseException.XamlParseException C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void XamlParseExceptionConstructorWithInnerException()
        {
            tlog.Debug(tag, $"XamlParseExceptionConstructorWithInnerException START");

            var testingTarget = new XamlParseException("myMessage", new Exception());
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<XamlParseException>(testingTarget, "should be an instance of XamlParseException class!");

            tlog.Debug(tag, $"XamlParseExceptionConstructorWithInnerException END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("XamlParseException constructor. With IXmlLineInfo.")]
        [Property("SPEC", "Tizen.NUI.XamlParseException.XamlParseException C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void XamlParseExceptionConstructorWithIXmlLineInfo()
        {
            tlog.Debug(tag, $"XamlParseExceptionConstructorWithIXmlLineInfo START");

            var testingTarget = new XamlParseException("Xaml Parsed Failed!", new XmlLineInfoImplement(), new Exception());
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<XamlParseException>(testingTarget, "should be an instance of XamlParseException class!");

            tlog.Debug(tag, $"XamlParseExceptionConstructorWithIXmlLineInfo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("XamlParseException XmlInfo ")]
        [Property("SPEC", "Tizen.NUI.XamlParseException.XmlInfo A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void XamlParseExceptionXmlInfo()
        {
            tlog.Debug(tag, $"XamlParseExceptionXmlInfo START");

            try
            {
                var result = xamlParseException.XmlInfo;
                tlog.Debug(tag, "XmlInfo :" + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlParseExceptionXmlInfo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("XamlParseException UnformattedMessage ")]
        [Property("SPEC", "Tizen.NUI.XamlParseException.UnformattedMessage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void XamlParseExceptionUnformattedMessage()
        {
            tlog.Debug(tag, $"XamlParseExceptionUnformattedMessage START");
            
            try
            {
                var result = xamlParseException.UnformattedMessage;
                tlog.Debug(tag, "UnformattedMessage :" + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlParseExceptionUnformattedMessage END (OK)");
        }
    }
}
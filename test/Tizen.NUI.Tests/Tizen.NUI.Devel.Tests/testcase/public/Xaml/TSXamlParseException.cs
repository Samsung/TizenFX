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
            xamlParseException = new XamlParseException("myMessage");
        }

        [TearDown]
        public void Destroy()
        {
            xamlParseException = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        private class XmlLineInfoImplent : IXmlLineInfo
        {
            public int LineNumber => throw new NotImplementedException();

            public int LinePosition => throw new NotImplementedException();

            public bool HasLineInfo()
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        [Category("P1")]
        [Description("XamlParseException XamlParseException")]
        [Property("SPEC", "Tizen.NUI.XamlParseException.XamlParseException C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void XamlParseExceptionConstructor1()
        {
            tlog.Debug(tag, $"XamlParseExceptionConstructor START");

            XamlParseException x1 = new XamlParseException("myMessage");

            x1 = null;

            tlog.Debug(tag, $"XamlParseExceptionConstructor END (OK)");
            Assert.Pass("XamlParseExceptionConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("XamlParseException XamlParseException")]
        [Property("SPEC", "Tizen.NUI.XamlParseException.XamlParseException C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void XamlParseExceptionConstructor2()
        {
            tlog.Debug(tag, $"XamlParseExceptionConstructor START");

            XamlParseException x2 = new XamlParseException();

            x2 = null;

            tlog.Debug(tag, $"XamlParseExceptionConstructor END (OK)");
            Assert.Pass("XamlParseExceptionConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("XamlParseException XamlParseException")]
        [Property("SPEC", "Tizen.NUI.XamlParseException.XamlParseException C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void XamlParseExceptionConstructor3()
        {
            tlog.Debug(tag, $"XamlParseExceptionConstructor START");

            Exception e1 = new Exception();
            XamlParseException x3 = new XamlParseException("myMessage", e1);

            x3 = null;
            tlog.Debug(tag, $"XamlParseExceptionConstructor END (OK)");
            Assert.Pass("XamlParseExceptionConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("XamlParseException XamlParseException")]
        [Property("SPEC", "Tizen.NUI.XamlParseException.XamlParseException C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void XamlParseExceptionConstructor4()
        {
            tlog.Debug(tag, $"XamlParseExceptionConstructor START");

            Exception e1 = new Exception();
            XmlLineInfoImplent xmlLineInfoImplent = new XmlLineInfoImplent();
            XamlParseException x4 = new XamlParseException("myMessage", xmlLineInfoImplent, e1);

            x4 = null;

            tlog.Debug(tag, $"XamlParseExceptionConstructor END (OK)");
            Assert.Pass("XamlParseExceptionConstructor");
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
                XmlLineInfoImplent xml1 = (XmlLineInfoImplent)xamlParseException.XmlInfo;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"XamlParseExceptionXmlInfo END (OK)");
            Assert.Pass("XamlParseExceptionXmlInfo");
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
                string s1 = xamlParseException.UnformattedMessage;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"XamlParseExceptionUnformattedMessage END (OK)");
            Assert.Pass("XamlParseExceptionUnformattedMessage");
        }
    }
}
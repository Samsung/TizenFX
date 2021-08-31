using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/XmlLineInfo ")]
    public class PublicXmlLineInfoTest
    {
        private const string tag = "NUITEST";
        private XmlLineInfo lineInfo;
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            lineInfo = new XmlLineInfo();
        }

        [TearDown]
        public void Destroy()
        {
            lineInfo = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("XmlLineInfo XmlLineInfo")]
        [Property("SPEC", "Tizen.NUI.XmlLineInfo.XmlLineInfo C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void XmlLineInfoConstructor()
        {
            tlog.Debug(tag, $"XmlLineInfoConstructor START");

            var testingTarget = new XmlLineInfo(10, 5);
            Assert.IsNotNull(testingTarget, "null XmlLineInfo");
            Assert.IsInstanceOf<XmlLineInfo>(testingTarget, "Should return XmlLineInfo instance.");

            tlog.Debug(tag, $"XmlLineInfoConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("XmlLineInfo HasLineInfo")]
        [Property("SPEC", "Tizen.NUI.XmlLineInfo.HasLineInfo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XmlLineInfoHasLineInfo()
        {
            tlog.Debug(tag, $"XmlLineInfoHasLineInfo START");

            try
            {
                var result = lineInfo.HasLineInfo();
                tlog.Debug(tag, "HasLineInfo : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XmlLineInfoHasLineInfo END");
        }

        [Test]
        [Category("P1")]
        [Description("XmlLineInfo LineNumber ")]
        [Property("SPEC", "Tizen.NUI.XmlLineInfo.LineNumber  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XmlLineInfoLineNumber()
        {
            tlog.Debug(tag, $"XmlLineInfoLineNumber START");

            try
            {
                var result = lineInfo.LineNumber;
                tlog.Debug(tag, "LineNumber : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XmlLineInfoLineNumber END");
        }

        [Test]
        [Category("P1")]
        [Description("XmlLineInfo LinePosition ")]
        [Property("SPEC", "Tizen.NUI.XmlLineInfo.LinePosition  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XmlLineInfoLinePosition()
        {
            tlog.Debug(tag, $"XmlLineInfoLinePosition START");

            try
            {
                var result = lineInfo.LinePosition;
                tlog.Debug(tag, "LinePosition : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XmlLineInfoLinePosition END");
        }
    }
}
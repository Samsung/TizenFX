using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/XmlLineInfo ")]
    internal class PublicXmlLineInfoTest
    {
        private const string tag = "NUITEST";
        private XmlLineInfo x1;
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            x1 = new XmlLineInfo();
        }

        [TearDown]
        public void Destroy()
        {
            x1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("XmlLineInfo XmlLineInfo")]
        [Property("SPEC", "Tizen.NUI.XmlLineInfo.XmlLineInfo C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void XmlLineInfoConstructor1()
        {
            tlog.Debug(tag, $"XmlLineInfoConstructor START");

            XmlLineInfo xmlLineInfo1 = new XmlLineInfo();

            tlog.Debug(tag, $"XmlLineInfoConstructor END (OK)");
            Assert.Pass("XmlLineInfoConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("XmlLineInfo XmlLineInfo")]
        [Property("SPEC", "Tizen.NUI.XmlLineInfo.XmlLineInfo C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void XmlLineInfoConstructor2()
        {
            tlog.Debug(tag, $"XmlLineInfoConstructor START");

            XmlLineInfo xmlLineInfo2 = new XmlLineInfo(10, 5);

            tlog.Debug(tag, $"XmlLineInfoConstructor END (OK)");
            Assert.Pass("XmlLineInfoConstructor");
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
                x1.HasLineInfo();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XmlLineInfoHasLineInfo END (OK)");
            Assert.Pass("XmlLineInfoHasLineInfo");
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
                int i = x1.LineNumber;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XmlLineInfoLineNumber END (OK)");
            Assert.Pass("XmlLineInfoLineNumber");
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
                int i = x1.LinePosition;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XmlLineInfoLinePosition END (OK)");
            Assert.Pass("XmlLineInfoLinePosition");
        }
    }
}
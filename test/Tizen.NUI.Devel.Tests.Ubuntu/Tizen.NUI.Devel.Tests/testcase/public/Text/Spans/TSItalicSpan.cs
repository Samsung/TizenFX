using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tizen.NUI.Text.Spans;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Text/Spans")]
    public class PublicItalicSpanTest
    {
        private const string tag = "NUITEST";

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is calles!");
        }

        [Test]
        [Category("P1")]
        [Description("Create an Italic span")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.ItalicSpan.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Sara Al-Jammal, s.al-jammal@partner.samsung.com")]
        public void ItalicSpanCreate()
        {
            tlog.Debug(tag, $"ItalicSpanCreate START");

            var testingTarget = ItalicSpan.Create();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ItalicSpan>(testingTarget, "Should return ItalicSpan instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"ItalicSpanCreate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItalicSpan Dispose.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.ItalicSpan.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Sara Al-Jammal, s.al-jammal@partner.samsung.com")]
        public void ItalicSpanDispose()
        {
            tlog.Debug(tag, $"ItalicSpanDispose START");

            var testingTarget = ItalicSpan.Create();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ItalicSpan>(testingTarget, "Should return ItalicSpan instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ItalicSpanDispose END (OK)");
        }

    }
}
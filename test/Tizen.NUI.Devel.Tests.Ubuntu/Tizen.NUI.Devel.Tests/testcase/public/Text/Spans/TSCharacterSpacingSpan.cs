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
    public class PublicCharacterSpacingSpanTest
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
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create CharacterSpacing span.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.CharacterSpacingSpan.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void CharacterSpacingSpanCreate()
        {
            tlog.Debug(tag, $"CharacterSpacingSpanCreate START");

            var testingTarget = CharacterSpacingSpan.Create(2.9f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<CharacterSpacingSpan>(testingTarget, "Should return CharacterSpacingSpan instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"CharacterSpacingSpanCreate END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("CharacterSpacing span value.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.CharacterSpacingSpan.CharacterSpacing A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void CharacterSpacingSpanValue()
        {
            tlog.Debug(tag, $"CharacterSpacingSpanValue START");

            float expectedCharacterSpacing = 0;

            var testingTarget = CharacterSpacingSpan.Create(expectedCharacterSpacing);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<CharacterSpacingSpan>(testingTarget, "Should return CharacterSpacingSpan instance.");

            try
            {
                var result = testingTarget.CharacterSpacing;
                Assert.AreEqual(result, expectedCharacterSpacing, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"CharacterSpacingSpanValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CharacterSpacingSpan HasCharacterSpacing.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.CharacterSpacingSpan.HasCharacterSpacing A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void CharacterSpacingSpanHasCharacterSpacing()
        {
            tlog.Debug(tag, $"CharacterSpacingSpanHasCharacterSpacing START");

            var expected = true;

            var testingTarget = CharacterSpacingSpan.Create(0.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<CharacterSpacingSpan>(testingTarget, "Should return CharacterSpacingSpan instance.");

            try
            {
                var result = testingTarget.HasCharacterSpacing;
                Assert.AreEqual(expected, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"CharacterSpacingSpanHasCharacterSpacing END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CharacterSpacingSpan Dispose.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.CharacterSpacingSpan.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void CharacterSpacingSpanDispose()
        {
            tlog.Debug(tag, $"CharacterSpacingSpanDispose START");

            var testingTarget = CharacterSpacingSpan.Create(3.5f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<CharacterSpacingSpan>(testingTarget, "Should return CharacterSpacingSpan instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"CharacterSpacingSpanDispose END (OK)");
        }
    }
}
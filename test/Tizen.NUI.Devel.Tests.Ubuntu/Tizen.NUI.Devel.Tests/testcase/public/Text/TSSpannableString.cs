using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tizen.NUI.Text.Spans;
using Tizen.NUI.Text;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Text")]
    public class PublicSpannableStringTest
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
        [Description("SpannableString Create.")]
        [Property("SPEC", "Tizen.NUI.Text.SpannableString.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannableStringCreate()
        {
            tlog.Debug(tag, $"SpannableStringCreate START");

            var testingTarget = SpannableString.Create("Hello World!");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SpannableString>(testingTarget, "Should return SpannableString instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"SpannableStringCreate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SpannableString Dispose.")]
        [Property("SPEC", "Tizen.NUI.Text.SpannableString.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannableStringDispose()
        {
            tlog.Debug(tag, $"SpannableStringDispose START");

            var testingTarget = SpannableString.Create("Hello World!");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SpannableString>(testingTarget, "Should return SpannableString instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"SpannableStringDispose END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("SpannableString Create.")]
        [Property("SPEC", "Tizen.NUI.Text.Spannable.AttachSpan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannableStringAttachSpan()
        {
            tlog.Debug(tag, $"SpannableStringAttachSpan START");

            var testingTarget = SpannableString.Create("Hello World!");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SpannableString>(testingTarget, "Should return SpannableString instance.");

            var flagIsAttached = testingTarget.AttachSpan(
                ForegroundColorSpan.Create(Color.Green),
                Range.Create(2,5)
            );

            Assert.AreEqual(true, flagIsAttached, "Should be true!");

            flagIsAttached = testingTarget.AttachSpan(
                ForegroundColorSpan.Create(Color.Blue),
                Range.Create(22,50)
            );

            Assert.AreEqual(false, flagIsAttached, "Should be true!");

            testingTarget.Dispose();

            tlog.Debug(tag, $"SpannableStringAttachSpan END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("SpannableString Create.")]
        [Property("SPEC", "Tizen.NUI.Text.Spannable.DetachSpan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannableStringDetachSpan()
        {
            tlog.Debug(tag, $"SpannableStringDetachSpan START");

            var testingTarget = SpannableString.Create("Hello World!");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SpannableString>(testingTarget, "Should return SpannableString instance.");


            ForegroundColorSpan span = ForegroundColorSpan.Create(Color.Green);

            var flagIsDetached = testingTarget.DetachSpan(span);
            Assert.AreEqual(false, flagIsDetached, "Should be true!");


            var flagIsAttached = testingTarget.AttachSpan(
                span,
                Range.Create(2,5)
            );

            Assert.AreEqual(true, flagIsAttached, "Should be true!");

            flagIsDetached = testingTarget.DetachSpan(span);
            Assert.AreEqual(true, flagIsDetached, "Should be true!");

            flagIsDetached = testingTarget.DetachSpan(span);
            Assert.AreEqual(false, flagIsDetached, "Should be true!");

            testingTarget.Dispose();

            tlog.Debug(tag, $"SpannableStringDetachSpan END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SpannableString GetNumberOfCharacters.")]
        [Property("SPEC", "Tizen.NUI.Text.CharacterSequence.GetNumberOfCharacters M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannableStringGetNumberOfCharacters()
        {
            tlog.Debug(tag, $"SpannableStringGetNumberOfCharacters START");

            uint expected = 26;

            var testingTarget = SpannableString.Create("Hello World! مرحبا بالعالم");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SpannableString>(testingTarget, "Should return SpannableString instance.");

            uint result = testingTarget.GetNumberOfCharacters();
            Assert.AreEqual(expected, result, "Should be true!");

            testingTarget.Dispose();

            tlog.Debug(tag, $"SpannableStringGetNumberOfCharacters END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SpannableString ToString.")]
        [Property("SPEC", "Tizen.NUI.Text.CharacterSequence.ToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannableStringToString()
        {
            tlog.Debug(tag, $"SpannableStringToString START");

            string expected = "Hello World! مرحبا بالعالم";

            var testingTarget = SpannableString.Create(expected);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SpannableString>(testingTarget, "Should return SpannableString instance.");

            var result = testingTarget.ToString();
            Assert.AreEqual(expected, result, "Should be true!");

            testingTarget.Dispose();

            tlog.Debug(tag, $"SpannableStringToString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SpannableString GetCharacters.")]
        [Property("SPEC", "Tizen.NUI.Text.CharacterSequence.GetCharacters M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannableStringGetCharacters()
        {
            tlog.Debug(tag, $"SpannableStringGetCharacters START");

             List<uint> expected = new List<uint>
             {
                72,
                101,
                108,
                108,
                111,
                1605,
                1585,
                1581,
                1576,
                1575
             };

            var testingTarget = SpannableString.Create("Helloمرحبا");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SpannableString>(testingTarget, "Should return SpannableString instance.");

            var result = testingTarget.GetCharacters();
            Assert.AreEqual(expected, result, "Should be true!");

            testingTarget.Dispose();

            tlog.Debug(tag, $"SpannableStringGetCharacters END (OK)");
        }

    }
}
using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Text.Spans;
using Tizen.NUI.Text;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Text")]
    public class PublicTextSpannableTest
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
        [Description("Check SetSpannedText method with TextLabel. Check whether SetSpannedText is successfully invoked or not.")]
        [Property("SPEC", "Tizen.NUI.Text.TextSpannable.SetSpannedText M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        [Property("COVPARAM", "TextLabel")]
        public void TextSpannableSetSpannedText_CALL_API_WITHOUT_EXCEPTION_WITH_TEXTLABEL()
        {
            tlog.Debug(tag, $"TextSpannableSetSpannedText_CALL_API_WITHOUT_EXCEPTION_WITH_TEXTLABEL START");


            var testingTarget = new TextLabel(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            var spannedText = SpannableString.Create("Hello World!");
            Assert.IsNotNull(spannedText, "null handle");
            Assert.IsInstanceOf<SpannableString>(spannedText, "Should return SpannableString instance.");

            spannedText.AttachSpan(
                ForegroundColorSpan.Create(Color.Green),
                Range.Create(2,5)
            );

            try
            {
                TextSpannable.SetSpannedText(testingTarget, spannedText);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception when call TextSpannable.SetSpannedText(textLabel, spannedText) , but got: %s", ex.Message);
            }

            spannedText.Dispose();
            testingTarget.Dispose();

            tlog.Debug(tag, $"TextSpannableSetSpannedText_CALL_API_WITHOUT_EXCEPTION_WITH_TEXTLABEL END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Check SetSpannedText method with TextField. Check whether SetSpannedText is successfully invoked or not.")]
        [Property("SPEC", "Tizen.NUI.Text.TextSpannable.SetSpannedText M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        [Property("COVPARAM", "TextField")]
        public void TextSpannableSetSpannedText_CALL_API_WITHOUT_EXCEPTION_WITH_TEXTFIELD()
        {
            tlog.Debug(tag, $"TextSpannableSetSpannedText_CALL_API_WITHOUT_EXCEPTION_WITH_TEXTFIELD START");


            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var spannedText = SpannableString.Create("Hello World!");
            Assert.IsNotNull(spannedText, "null handle");
            Assert.IsInstanceOf<SpannableString>(spannedText, "Should return SpannableString instance.");

            spannedText.AttachSpan(
                ForegroundColorSpan.Create(Color.Green),
                Range.Create(2,5)
            );

            try
            {
                TextSpannable.SetSpannedText(testingTarget, spannedText);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception when call TextSpannable.SetSpannedText(textField, spannedText) , but got: %s", ex.Message);
            }

            spannedText.Dispose();
            testingTarget.Dispose();

            tlog.Debug(tag, $"TextSpannableSetSpannedText_CALL_API_WITHOUT_EXCEPTION_WITH_TEXTFIELD END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Check SetSpannedText method with TextEditor. Check whether SetSpannedText is successfully invoked or not.")]
        [Property("SPEC", "Tizen.NUI.Text.TextSpannable.SetSpannedText M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        [Property("COVPARAM", "TextEditor")]
        public void TextSpannableSetSpannedText_CALL_API_WITHOUT_EXCEPTION_WITH_TEXTEDITOR()
        {
            tlog.Debug(tag, $"TextSpannableSetSpannedText_CALL_API_WITHOUT_EXCEPTION_WITH_TEXTEDITOR START");


            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            var spannedText = SpannableString.Create("Hello World!");
            Assert.IsNotNull(spannedText, "null handle");
            Assert.IsInstanceOf<SpannableString>(spannedText, "Should return SpannableString instance.");

            spannedText.AttachSpan(
                ForegroundColorSpan.Create(Color.Green),
                Range.Create(2,5)
            );

            try
            {
                TextSpannable.SetSpannedText(testingTarget, spannedText);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception when call TextSpannable.SetSpannedText(textEditor, spannedText) , but got: %s", ex.Message);
            }

            spannedText.Dispose();
            testingTarget.Dispose();

            tlog.Debug(tag, $"TextSpannableSetSpannedText_CALL_API_WITHOUT_EXCEPTION_WITH_TEXTEDITOR END (OK)");
        }


    }
}
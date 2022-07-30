using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tizen.NUI.Text.Spans;
using Tizen.NUI.Text;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Text")]
    public class PublicSpannableTest
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
        [Description("Spannable AttachSpan on TextLabel.")]
        [Property("SPEC", "Tizen.NUI.Text.Spannable.AttachSpan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannableAttachSpanTextLabel()
        {
            tlog.Debug(tag, $"SpannableAttachSpanTextLabel START");

            var testingTarget = new TextLabel(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            var span = ForegroundColorSpanBuilder.Initialize().WithForegroundColor(Color.Green).Build();
            Assert.IsNotNull(span, "null handle");
            Assert.IsInstanceOf<BaseSpan>(span, "Should return ForegroundColorSpan instance.");

            try
            {
                testingTarget.Text = "Hello World!";
                Spannable.AttachSpan(testingTarget,span,3,8);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SpannableAttachSpanTextLabel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Spannable AttachSpan on TextEditor.")]
        [Property("SPEC", "Tizen.NUI.Text.Spannable.AttachSpan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannableAttachSpanTextEditor()
        {
            tlog.Debug(tag, $"SpannableAttachSpanTextEditor START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            var span = ForegroundColorSpanBuilder.Initialize().WithForegroundColor(Color.Green).Build();
            Assert.IsNotNull(span, "null handle");
            Assert.IsInstanceOf<BaseSpan>(span, "Should return ForegroundColorSpan instance.");

            try
            {
                testingTarget.Text = "Hello World!";
                Spannable.AttachSpan(testingTarget,span,3,8);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SpannableAttachSpanTextEditor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Spannable AttachSpan on TextField.")]
        [Property("SPEC", "Tizen.NUI.Text.Spannable.AttachSpan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannableAttachSpanTextField()
        {
            tlog.Debug(tag, $"SpannableAttachSpanTextField START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var span = ForegroundColorSpanBuilder.Initialize().WithForegroundColor(Color.Green).Build();
            Assert.IsNotNull(span, "null handle");
            Assert.IsInstanceOf<BaseSpan>(span, "Should return ForegroundColorSpan instance.");

            try
            {
                testingTarget.Text = "Hello World!";
                Spannable.AttachSpan(testingTarget,span,3,8);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SpannableAttachSpanTextEditor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Spannable DetachSpan on TextLabel.")]
        [Property("SPEC", "Tizen.NUI.Text.Spannable.DetachSpan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannableDetachSpanTextLabel()
        {
            tlog.Debug(tag, $"SpannableDetachSpanTextLabel START");

            var testingTarget = new TextLabel(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            var span = ForegroundColorSpanBuilder.Initialize().WithForegroundColor(Color.Green).Build();
            Assert.IsNotNull(span, "null handle");
            Assert.IsInstanceOf<BaseSpan>(span, "Should return ForegroundColorSpan instance.");

            try
            {
                testingTarget.Text = "Hello World!";
                Spannable.DetachSpan(testingTarget,span);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SpannableDetachSpanTextLabel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Spannable DetachSpan on TextEditor.")]
        [Property("SPEC", "Tizen.NUI.Text.Spannable.DetachSpan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannableDetachSpanTextEditor()
        {
            tlog.Debug(tag, $"SpannableDetachSpanTextEditor START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            var span = ForegroundColorSpanBuilder.Initialize().WithForegroundColor(Color.Green).Build();
            Assert.IsNotNull(span, "null handle");
            Assert.IsInstanceOf<BaseSpan>(span, "Should return ForegroundColorSpan instance.");

            try
            {
                testingTarget.Text = "Hello World!";
                Spannable.DetachSpan(testingTarget,span);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SpannableDetachSpanTextEditor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Spannable DetachSpan on TextField.")]
        [Property("SPEC", "Tizen.NUI.Text.Spannable.DetachSpan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannableDetachSpanTextField()
        {
            tlog.Debug(tag, $"SpannableDetachSpanTextField START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var span = ForegroundColorSpanBuilder.Initialize().WithForegroundColor(Color.Green).Build();
            Assert.IsNotNull(span, "null handle");
            Assert.IsInstanceOf<BaseSpan>(span, "Should return ForegroundColorSpan instance.");

            try
            {
                testingTarget.Text = "Hello World!";
                Spannable.DetachSpan(testingTarget,span);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SpannableDetachSpanTextEditor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Spannable BuildSpannedText on TextLabel.")]
        [Property("SPEC", "Tizen.NUI.Text.Spannable.BuildSpannedText M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannableBuildSpannedTextTextLabel()
        {
            tlog.Debug(tag, $"SpannableBuildSpannedTextTextLabel START");

            var testingTarget = new TextLabel(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            try
            {
                testingTarget.Text = "Hello World!";
                Spannable.BuildSpannedText(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SpannableBuildSpannedTextTextLabel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Spannable BuildSpannedText on TextEditor.")]
        [Property("SPEC", "Tizen.NUI.Text.Spannable.BuildSpannedText M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannableBuildSpannedTextTextEditor()
        {
            tlog.Debug(tag, $"SpannableBuildSpannedTextTextEditor START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            try
            {
                testingTarget.Text = "Hello World!";
                Spannable.BuildSpannedText(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SpannableBuildSpannedTextTextEditor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Spannable BuildSpannedText on TextField.")]
        [Property("SPEC", "Tizen.NUI.Text.Spannable.BuildSpannedText M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannableBuildSpannedTextTextField()
        {
            tlog.Debug(tag, $"SpannableBuildSpannedTextTextField START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            try
            {
                testingTarget.Text = "Hello World!";
                Spannable.BuildSpannedText(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SpannableBuildSpannedTextTextEditor END (OK)");
        }



    }
}

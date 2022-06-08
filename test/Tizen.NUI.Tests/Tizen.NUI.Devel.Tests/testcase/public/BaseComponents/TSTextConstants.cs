using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/TextConstants")]
    public class PublicTextConstantsTest
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
        [Description("InputFilter Equals")]
        [Property("SPEC", "Tizen.NUI.Text.InputFilter.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void InputFilterEquals()
        {
            tlog.Debug(tag, $"InputFilterEquals START");

            var inputFilter = new Tizen.NUI.Text.InputFilter();
            Assert.IsNotNull(inputFilter, "Can't create success object inputFilter");
            Assert.IsInstanceOf<Tizen.NUI.Text.InputFilter>(inputFilter, "Should be an instance of inputFilter type.");

            var compare = new Tizen.NUI.Text.InputFilter();
            Assert.IsTrue(inputFilter == compare, "Should be true!");
            Assert.AreEqual(inputFilter.GetHashCode(), compare.GetHashCode(), "Should be true!");

            compare.Accepted = @"[\d]";
            Assert.IsTrue(inputFilter != compare, "Should be true!");

            tlog.Debug(tag, $"InputFilterEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Strikethrough Equals")]
        [Property("SPEC", "Tizen.NUI.Text.Strikethrough.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void StrikethroughEquals()
        {
            tlog.Debug(tag, $"StrikethroughEquals START");

            var strikethrough = new Tizen.NUI.Text.Strikethrough();
            Assert.IsNotNull(strikethrough, "Can't create success object strikethrough");
            Assert.IsInstanceOf<Tizen.NUI.Text.Strikethrough>(strikethrough, "Should be an instance of strikethrough type.");

            var compare = new Tizen.NUI.Text.Strikethrough();
            Assert.IsTrue(strikethrough == compare, "Should be true!");
            Assert.AreEqual(strikethrough.GetHashCode(), compare.GetHashCode(), "Should be true!");

            compare.Height = 2.0f;
            Assert.IsTrue(strikethrough != compare, "Should be true!");

            tlog.Debug(tag, $"StrikethroughEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontStyle Equals")]
        [Property("SPEC", "Tizen.NUI.Text.FontStyle.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void FontStyleEquals()
        {
            tlog.Debug(tag, $"FontStyleEquals START");

            var fontStyle = new Tizen.NUI.Text.FontStyle();
            Assert.IsNotNull(fontStyle, "Can't create success object strikethrough");
            Assert.IsInstanceOf<Tizen.NUI.Text.FontStyle>(fontStyle, "Should be an instance of fontStyle type.");

            var compare = new Tizen.NUI.Text.FontStyle();
            Assert.IsTrue(fontStyle == compare, "Should be true!");
            Assert.AreEqual(fontStyle.GetHashCode(), compare.GetHashCode(), "Should be true!");

            compare.Slant = FontSlantType.Italic;
            Assert.IsTrue(fontStyle != compare, "Should be true!");

            tlog.Debug(tag, $"FontStyleEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Underline Equals")]
        [Property("SPEC", "Tizen.NUI.Text.Underline.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void UnderlineEquals()
        {
            tlog.Debug(tag, $"UnderlineEquals START");

            var underline = new Tizen.NUI.Text.Underline();
            Assert.IsNotNull(underline, "Can't create success object strikethrough");
            Assert.IsInstanceOf<Tizen.NUI.Text.Underline>(underline, "Should be an instance of underline type.");

            var compare = new Tizen.NUI.Text.Underline();
            Assert.IsTrue(underline == compare, "Should be true!");
            Assert.AreEqual(underline.GetHashCode(), compare.GetHashCode(), "Should be true!");

            compare.Color = Color.Red;
            Assert.IsTrue(underline != compare, "Should be true!");

            tlog.Debug(tag, $"UnderlineEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Shadow Equals")]
        [Property("SPEC", "Tizen.NUI.Text.Shadow.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void ShadowEquals()
        {
            tlog.Debug(tag, $"ShadowEquals START");

            var shadow = new Tizen.NUI.Text.Shadow();
            Assert.IsNotNull(shadow, "Can't create success object strikethrough");
            Assert.IsInstanceOf<Tizen.NUI.Text.Shadow>(shadow, "Should be an instance of shadow type.");

            var compare = new Tizen.NUI.Text.Shadow();
            Assert.IsTrue(shadow == compare, "Should be true!");
            Assert.AreEqual(shadow.GetHashCode(), compare.GetHashCode(), "Should be true!");

            compare.BlurRadius = 5.0f;
            Assert.IsTrue(shadow != compare, "Should be true!");

            tlog.Debug(tag, $"ShadowEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Outline Equals")]
        [Property("SPEC", "Tizen.NUI.Text.Outline.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void OutlineEquals()
        {
            tlog.Debug(tag, $"OutlineEquals START");

            var outline = new Tizen.NUI.Text.Outline();
            Assert.IsNotNull(outline, "Can't create success object strikethrough");
            Assert.IsInstanceOf<Tizen.NUI.Text.Outline>(outline, "Should be an instance of outline type.");

            var compare = new Tizen.NUI.Text.Outline();
            Assert.IsTrue(outline == compare, "Should be true!");
            Assert.AreEqual(outline.GetHashCode(), compare.GetHashCode(), "Should be true!");

            compare.Width = 2.0f;
            Assert.IsTrue(outline != compare, "Should be true!");

            tlog.Debug(tag, $"OutlineEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextFit Equals")]
        [Property("SPEC", "Tizen.NUI.Text.TextFit.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextFitEquals()
        {
            tlog.Debug(tag, $"TextFitEquals START");

            var textFit = new Tizen.NUI.Text.TextFit();
            Assert.IsNotNull(textFit, "Can't create success object strikethrough");
            Assert.IsInstanceOf<Tizen.NUI.Text.TextFit>(textFit, "Should be an instance of textFit type.");

            var compare = new Tizen.NUI.Text.TextFit();
            Assert.IsTrue(textFit == compare, "Should be true!");
            Assert.AreEqual(textFit.GetHashCode(), compare.GetHashCode(), "Should be true!");

            compare.StepSize = 10.0f;
            Assert.IsTrue(textFit != compare, "Should be true!");

            tlog.Debug(tag, $"TextFitEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Placeholder Equals")]
        [Property("SPEC", "Tizen.NUI.Text.Placeholder.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void PlaceholderEquals()
        {
            tlog.Debug(tag, $"PlaceholderEquals START");

            var placeholder = new Tizen.NUI.Text.Placeholder();
            Assert.IsNotNull(placeholder, "Can't create success object strikethrough");
            Assert.IsInstanceOf<Tizen.NUI.Text.Placeholder>(placeholder, "Should be an instance of placeholder type.");

            var compare = new Tizen.NUI.Text.Placeholder();
            Assert.IsTrue(placeholder == compare, "Should be true!");
            Assert.AreEqual(placeholder.GetHashCode(), compare.GetHashCode(), "Should be true!");

            compare.Ellipsis = true;
             Assert.IsTrue(placeholder != compare, "Should be true!");

            tlog.Debug(tag, $"PlaceholderEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("HiddenInput Equals")]
        [Property("SPEC", "Tizen.NUI.Text.HiddenInput.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void HiddenInputEquals()
        {
            tlog.Debug(tag, $"HiddenInputEquals START");

            var hiddenInput = new Tizen.NUI.Text.HiddenInput();
            Assert.IsNotNull(hiddenInput, "Can't create success object strikethrough");
            Assert.IsInstanceOf<Tizen.NUI.Text.HiddenInput>(hiddenInput, "Should be an instance of hiddenInput type.");

            var compare = new Tizen.NUI.Text.HiddenInput();
            Assert.IsTrue(hiddenInput == compare, "Should be true!");
            Assert.AreEqual(hiddenInput.GetHashCode(), compare.GetHashCode(), "Should be true!");

            compare.ShowLastCharacterDuration = 10000;
            Assert.IsTrue(hiddenInput != compare, "Should be true!");

            tlog.Debug(tag, $"HiddenInputEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SelectionHandleImage Equals")]
        [Property("SPEC", "Tizen.NUI.Text.SelectionHandleImage.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void SelectionHandleImageEquals()
        {
            tlog.Debug(tag, $"SelectionHandleImageEquals START");

            var selectionHandleImage = new Tizen.NUI.Text.SelectionHandleImage();
            Assert.IsNotNull(selectionHandleImage, "Can't create success object strikethrough");
            Assert.IsInstanceOf<Tizen.NUI.Text.SelectionHandleImage>(selectionHandleImage, "Should be an instance of selectionHandleImage type.");

            var compare = new Tizen.NUI.Text.SelectionHandleImage();
            Assert.IsTrue(selectionHandleImage == compare, "Should be true!");
            Assert.AreEqual(selectionHandleImage.GetHashCode(), compare.GetHashCode(), "Should be true!");

            compare.LeftImageUrl = "left image url";
            Assert.IsTrue(selectionHandleImage != compare, "Should be true!");

            tlog.Debug(tag, $"SelectionHandleImageEquals END (OK)");
        }
    }
}

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
    [Description("public/BaseComponents/TextEditor")]
    public class PublicTextEditorTest
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

        //[Test]
        //[Category("P1")]
        //[Description("TextEditor constructor.")]
        //[Property("SPEC", "Tizen.NUI.TextEditor.TextEditor C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //[Obsolete]
        //public void TextEditorConstructor()
        //{
        //    tlog.Debug(tag, $"TextEditorConstructor START");

        //    TextEditorStyle style = new TextEditorStyle()
        //    {
        //        FontFamily = "BreezeSans",
        //        FontStyle = new PropertyMap().Add("weight", new PropertyValue("regular")),
        //    };

        //    var testingTarget = new TextEditor(style);
        //    Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
        //    Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"TextEditorConstructor END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("TextEditor constructor. With status of Shown.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.TextEditor C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextEditorConstructorWithStatusOfShown()
        {
            tlog.Debug(tag, $"TextEditorConstructorWithStatusOfShown START");

            var testingTarget = new TextEditor(false);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextEditorConstructorWithStatusOfShown END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("TextEditor TranslatableText.")]
        //[Property("SPEC", "Tizen.NUI.TextEditor.TranslatableText A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //[Obsolete]
        //public void TextEditorTranslatableText()
        //{
        //    tlog.Debug(tag, $"TextEditorTranslatableText START");

        //    var testingTarget = new TextEditor();
        //    Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
        //    Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

        //    testingTarget.TranslatableText = "textEditorTextSid";
        //    Assert.AreEqual("textEditorTextSid", testingTarget.TranslatableText, "Should be equal!");

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"TextEditorTranslatableText END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("TextEditor TranslatablePlaceholderText.")]
        //[Property("SPEC", "Tizen.NUI.TextEditor.TranslatablePlaceholderText A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //[Obsolete]
        //public void TextEditorTranslatablePlaceholderText()
        //{
        //    tlog.Debug(tag, $"TextEditorTranslatablePlaceholderText START");

        //    var testingTarget = new TextEditor();
        //    Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
        //    Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

        //    testingTarget.TranslatablePlaceholderText = "textEditorTextSid";
        //    Assert.AreEqual("textEditorTextSid", testingTarget.TranslatablePlaceholderText, "Should be equal!");

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"TextEditorTranslatablePlaceholderText END (OK)");
        //}
    }   
}

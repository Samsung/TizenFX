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
    [Description("public/BaseComponents/TextEditorEvent")]
    public class PublicTextEditorEventTest
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
        [Description("TextEditorEvent TextChanged.")]
        [Property("SPEC", "Tizen.NUI.TextEditorEvent.TextChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextEditorEventEvents()
        {
            tlog.Debug(tag, $"TextEditorEventEvents START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            testingTarget.TextChanged += OnTextChanged;
            testingTarget.TextChanged -= OnTextChanged;

            testingTarget.MaxLengthReached += OnMaxLengthReached;
            testingTarget.MaxLengthReached -= OnMaxLengthReached;

            testingTarget.AnchorClicked += OnAnchorClicked;
            testingTarget.AnchorClicked -= OnAnchorClicked;

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextEditorEventEvents END (OK)");
        }

        private void OnAnchorClicked(object sender, AnchorClickedEventArgs e)
        {
        }

        private void OnMaxLengthReached(object sender, TextEditor.MaxLengthReachedEventArgs e)
        {
        }

        private void OnTextChanged(object sender, TextEditor.TextChangedEventArgs e)
        {
        }
    }
}

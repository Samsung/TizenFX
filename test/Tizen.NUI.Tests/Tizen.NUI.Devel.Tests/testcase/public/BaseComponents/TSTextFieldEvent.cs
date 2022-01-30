using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/TextFieldEvent")]
    public class PublicTextFieldEventTest
    {
        private const string tag = "NUITEST";
        private bool textChangedFlag = false;
        private bool maxLengthFlag = false;
        private bool selectionStartedFlag = false;

        private void OnTextChanged(object sender, TextField.TextChangedEventArgs e) { }
        private void OnMaxLengthReached(object sender, TextField.MaxLengthReachedEventArgs e) { }
        private void OnSelectionChanged(object sender, EventArgs e) { }
        private void OnAnchorClicked(object sender, AnchorClickedEventArgs e) { }
        private void OnSelectionCleared(object sender, EventArgs e) { }
        private void OnInputFiltered(object sender, InputFilteredEventArgs e) { }

        private void OnSelectionStarted(object sender, EventArgs e) 
        { 
            selectionStartedFlag = true;
        }

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
        [Description("TextField MaxLengthReached.")]
        [Property("SPEC", "Tizen.NUI.TextField.MaxLengthReached A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldMaxLengthReached()
        {
            tlog.Debug(tag, $"TextFieldMaxLengthReached START");

            var testingTarget = new TextField()
            {
                Text = "textfield",
                MaxLength = 9,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            try
            {
                testingTarget.TextChanged += OnTextChanged;
                testingTarget.MaxLengthReached += OnMaxLengthReached;
                testingTarget.SelectionCleared += OnSelectionCleared;
                testingTarget.AnchorClicked += OnAnchorClicked;
                testingTarget.SelectionChanged += OnSelectionChanged;
                testingTarget.InputFiltered += OnInputFiltered;

                testingTarget.TextChanged -= OnTextChanged;
                testingTarget.MaxLengthReached -= OnMaxLengthReached;
                testingTarget.SelectionCleared -= OnSelectionCleared;
                testingTarget.AnchorClicked -= OnAnchorClicked;
                testingTarget.SelectionChanged -= OnSelectionChanged;
                testingTarget.InputFiltered -= OnInputFiltered;
            }
            catch (Exception e)
            {
                tlog.Info(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldMaxLengthReached END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextFieldEvent SelectionStarted.")]
        [Property("SPEC", "Tizen.NUI.TextField.SelectionStarted A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "a.ghujeh@samsung.com")]
        async public Task TextFieldSelectionStarted()
        {
            tlog.Debug(tag, $"SelectionStarted START");

            var testingTarget = new TextField()
            {
                Text = "textfield",
            };

            Window.Instance.GetDefaultLayer().Add(testingTarget);

            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            try
            {
                testingTarget.SelectionStarted += OnSelectionStarted;

                testingTarget.SelectWholeText();
                await Task.Delay(500);

                testingTarget.SelectionStarted -= OnSelectionStarted;
            }
            catch (Exception e)
            {
                tlog.Info(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();

            if(selectionStartedFlag == true)
                tlog.Debug(tag, $"SelectionStarted END (OK)");
            else
                Assert.Fail("SelectionStarted : Failed!");
        }
    }
}

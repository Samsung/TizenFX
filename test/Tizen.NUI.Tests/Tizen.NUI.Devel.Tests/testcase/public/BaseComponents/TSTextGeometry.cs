using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/TextGeometry")]
    public class PublicTextGeometryTest
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
        [Description("TextGeometry.GetTextSize")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextSizeWithTextEditor()
        {
            tlog.Debug(tag, $"TextGeometryGetTextSizeWithTextEditor START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            try
            {
                TextGeometry.GetTextSize(testingTarget, 2, 6);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextGeometryGetTextSizeWithTextEditor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextSize, with null TextEditor")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextSizeWithNullTextEditor()
        {
            tlog.Debug(tag, $"TextGeometryGetTextSizeWithNullTextEditor START");

            try
            {
                TextEditor temp = null;
                TextGeometry.GetTextSize(temp, 2, 6);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message);
                tlog.Debug(tag, $"TextGeometryGetTextSizeWithNullTextEditor END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextSize, with illegal start")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextSizeWithIllegalStart()
        {
            tlog.Debug(tag, $"TextGeometryGetTextSizeWithIllegalStart START");

            try
            {
                var testingTarget = new TextEditor(true);
                Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
                Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

                TextGeometry.GetTextSize(testingTarget, -1, 6);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message);
                tlog.Debug(tag, $"TextGeometryGetTextSizeWithIllegalStart END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextSize, with illegal end")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextSizeWithIllegalEnd()
        {
            tlog.Debug(tag, $"TextGeometryGetTextSizeWithIllegalEnd START");

            try
            {
                var testingTarget = new TextEditor(true);
                Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
                Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

                TextGeometry.GetTextSize(testingTarget, 1, -1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TextGeometryGetTextSizeWithIllegalEnd END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextSize, with TextField")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextSizeWithTextField()
        {
            tlog.Debug(tag, $"TextGeometryGetTextSizeWithTextField START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            try
            {
                TextGeometry.GetTextSize(testingTarget, 2, 6);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextGeometryGetTextSizeWithNormalRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextSize, with null TextField")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextSizeWithNullTextField()
        {
            tlog.Debug(tag, $"TextGeometryGetTextSizeWithNullTextField START");

            try
            {
                TextField temp = null;
                TextGeometry.GetTextSize(temp, 2, 6);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TextGeometryGetTextSizeWithNullTextField END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextSize, with TextField and illegal start")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextSizeWithTextFieldAndIllegalStart()
        {
            tlog.Debug(tag, $"TextGeometryGetTextSizeWithTextFieldAndIllegalStart START");

            try
            {
                var testingTarget = new TextField(true);
                Assert.IsNotNull(testingTarget, "Can't create success object TextField");
                Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

                TextGeometry.GetTextSize(testingTarget, -1, 6);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TextGeometryGetTextSizeWithTextFieldAndIllegalStart END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextSize, with TextField and illegal end")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextSizeWithTextFieldAndIllegalEnd()
        {
            tlog.Debug(tag, $"TextGeometryGetTextSizeWithTextFieldAndIllegalEnd START");

            try
            {
                var testingTarget = new TextField(true);
                Assert.IsNotNull(testingTarget, "Can't create success object TextField");
                Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

                TextGeometry.GetTextSize(testingTarget, 1, -1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TextGeometryGetTextSizeWithTextFieldAndIllegalEnd END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextSize.WithTextLabel")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextSizeWithTextLabe()
        {
            tlog.Debug(tag, $"TextGeometryGetTextSizeWithTextLabel START");

            TextLabel label = new TextLabel()
            {
                Text = "hypertext",
            };

            try
            {
                TextGeometry.GetTextSize(label, 2, 6);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            label.Dispose();
            tlog.Debug(tag, $"TextGeometryGetTextSizeWithTextLabel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextSize.With null TextLabel ")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextSizeWithNullTextLabel()
        {
            tlog.Debug(tag, $"TextGeometryGetTextSizeWithNullTextLabel START");

            try
            {
                TextLabel temp = null;
                TextGeometry.GetTextSize(temp, 2, 6);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TextGeometryGetTextSizeWithNullTextLabel END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextSize.With TextLabel and illegal start")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextSizeWithTextLabelAndIllegalStart()
        {
            tlog.Debug(tag, $"TextGeometryGetTextSizeWithTextLabelAndIllegalStart START");

            try
            {
                var testingTarget = new TextLabel(true);
                Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
                Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

                TextGeometry.GetTextSize(testingTarget, -1, 6);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Pass("Caught ArgumentOutOfRangeException: Passed!");
                tlog.Debug(tag, $"TextGeometryGetTextSizeWithTextLabelAndIllegalStart END (OK)");
            }
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextSize.With TextLabel and illegal end")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextSizeWithTextLabelAndIllegalEnd()
        {
            tlog.Debug(tag, $"TextGeometryGetTextSizeWithTextLabelAndIllegalEnd START");

            try
            {
                var testingTarget = new TextLabel(true);
                Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
                Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

                TextGeometry.GetTextSize(testingTarget, 1, -1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TextGeometryGetTextSizeWithTextLabelAndIllegalEnd END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException: Passed!");
            }

        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextPosition, with TextEditor")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextPositionWithTextEditor()
        {
            tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextEditor START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            try
            {
                TextGeometry.GetTextPosition(testingTarget, 2, 6);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextEditor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextPosition, with null TextEditor")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextPositionWithNullTextEditor()
        {
            tlog.Debug(tag, $"TextGeometryGetTextPositionWithNullTextEditor START");

            try
            {
                TextEditor temp = null;
                TextGeometry.GetTextPosition(temp, 2, 6);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TextGeometryGetTextPositionWithNullTextEditor END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextPosition.With TextEditor and illegal start")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextPositionWithTextEditorAndIllegalStart()
        {
            tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextEditorAndIllegalStart START");

            try
            {
                var testingTarget = new TextEditor(true);
                Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
                Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

                TextGeometry.GetTextPosition(testingTarget, -1, 6);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextEditorAndIllegalStart END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextPosition.With TextEditor and illegal end")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextPositionWithTextEditorAndIllegalEnd()
        {
            tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextEditorAndIllegalEnd START");

            try
            {
                var testingTarget = new TextEditor(true);
                Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
                Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

                TextGeometry.GetTextPosition(testingTarget, 1, -1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextEditorAndIllegalEnd END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException: Passed!");
            }

        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextPosition, with TextField")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextPositionWithTextField()
        {
            tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextField START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            try
            {
                TextGeometry.GetTextPosition(testingTarget, 2, 6);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextField END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextPosition, with null TextField")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextPositionWithNullTextField()
        {
            tlog.Debug(tag, $"TextGeometryGetTextPositionWithNullTextField START");

            try
            {
                TextField temp = null;
                TextGeometry.GetTextPosition(temp, 2, 6);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TextGeometryGetTextPositionWithNullTextField END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextPosition.WithTextField and illegal start")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextPositionWithTextFieldAndIllegalStart()
        {
            tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextFieldAndIllegalStart START");

            try
            {
                var testingTarget = new TextField(true);
                Assert.IsNotNull(testingTarget, "Can't create success object TextField");
                Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

                TextGeometry.GetTextPosition(testingTarget, -1, 6);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextFieldAndIllegalStart END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextPosition.With TextField and illegal end")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextPositionWithTextFieldAndIllegalEnd()
        {
            tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextFieldAndIllegalEnd START");

            try
            {
                var testingTarget = new TextField(true);
                Assert.IsNotNull(testingTarget, "Can't create success object TextField");
                Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

                TextGeometry.GetTextPosition(testingTarget, 1, -1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextFieldAndIllegalEnd END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException: Passed!");
            }

        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextPosition, with TextLabel")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextPositionWithTextLabe()
        {
            tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextLabel START");

            TextLabel label = new TextLabel()
            {
                Text = "hypertext",
            };

            try
            {
                TextGeometry.GetTextPosition(label, 2, 6);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            label.Dispose();
            tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextLabel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextPosition, with Null TextLabel")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextPositionWithNullTextLabel()
        {
            tlog.Debug(tag, $"TextGeometryGetTextPositionWithNullTextLabel START");

            try
            {
                TextLabel temp = null;
                TextGeometry.GetTextPosition(temp, 2, 6);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TextGeometryGetTextPositionWithNullTextLabel END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextPosition, with TextLabel and illegal start")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextPositionWithTextLabelAndIllegalStart()
        {
            tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextLabelAndIllegalStart START");

            try
            {
                var testingTarget = new TextLabel(true);
                Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
                Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

                TextGeometry.GetTextPosition(testingTarget, -1, 6);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextLabelAndIllegalStart END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry.GetTextPosition, with TextLabel and illegal end")]
        [Property("SPEC", "Tizen.NUI.TextGeometry.GetTextPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextGeometryGetTextPositionWithTextLabelAndIllegalEnd()
        {
            tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextLabelAndIllegalEnd START");

            try
            {
                var testingTarget = new TextLabel(true);
                Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
                Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

                TextGeometry.GetTextPosition(testingTarget, 1, -1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TextGeometryGetTextPositionWithTextLabelAndIllegalEnd END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException: Passed!");
            }
        }
    }
}

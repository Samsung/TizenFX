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
    [Description("public/BaseComponents/TextField")]
    public class PublicTextFieldTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        internal class MyTextField : TextField
        {
            public MyTextField(bool shown) : base(shown)
            {
            }

            public ViewStyle OnCreateViewStyle()
            {
                return base.CreateViewStyle();
            }

            public void OnDispose(DisposeTypes type)
            {
                base.Dispose(type);
            }
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
        [Description("TextField constructor.")]
        [Property("SPEC", "Tizen.NUI.TextField.TextField C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldConstructor()
        {
            tlog.Debug(tag, $"TextFieldConstructor START");

            var testingTarget = new TextField();
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField constructor. With Shown.")]
        [Property("SPEC", "Tizen.NUI.TextField.TextField C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldConstructorWithShown()
        {
            tlog.Debug(tag, $"TextFieldConstructorWithShown START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldConstructorWithShown END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField constructor. With ViewStyle.")]
        [Property("SPEC", "Tizen.NUI.TextField.TextField C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldConstructorWithViewStyle()
        {
            tlog.Debug(tag, $"TextFieldConstructorWithViewStyle START");

            using (MyTextField textField = new MyTextField(true))
            {
                using (ViewStyle style = textField.OnCreateViewStyle())
                {
                    var testingTarget = new TextField(textField.SwigCPtr.Handle, false, style, false);
                    Assert.IsNotNull(testingTarget, "Can't create success object TextField");
                    Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"TextFieldConstructorWithViewStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField constructor. Without ViewStyle.")]
        [Property("SPEC", "Tizen.NUI.TextField.TextField C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldConstructorWithoutViewStyle()
        {
            tlog.Debug(tag, $"TextFieldConstructorWithoutViewStyle START");

            using (TextField textField = new TextField(true))
            {
                var testingTarget = new TextField(textField.SwigCPtr.Handle, false, false);
                Assert.IsNotNull(testingTarget, "Can't create success object TextField");
                Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TextFieldConstructorWithoutViewStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField constructor. With TextField.")]
        [Property("SPEC", "Tizen.NUI.TextField.TextField C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldConstructorWithTextField()
        {
            tlog.Debug(tag, $"TextFieldConstructorWithTextField START");

            using (MyTextField textField = new MyTextField(true))
            {
                var testingTarget = new TextField(textField, false);
                Assert.IsNotNull(testingTarget, "Can't create success object TextField");
                Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TextFieldConstructorWithTextField END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField TranslatableText.")]
        [Property("SPEC", "Tizen.NUI.TextField.TranslatableText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldTranslatableText()
        {
            tlog.Debug(tag, $"TextFieldTranslatableText START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            if (NUIApplication.MultilingualResourceManager != null)
            {
                testingTarget.TranslatableText = "TextFieldTranslatableText";
                Assert.AreEqual("TextFieldTranslatableText", testingTarget.TranslatableText, "Should be equal!");

                testingTarget.Dispose();
                tlog.Debug(tag, $"TextFieldTranslatableText END (OK)");
            }
            else
            {
                try
                {
                    testingTarget.TranslatableText = "TextFieldTranslatableText";
                }
                catch (ArgumentNullException e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    tlog.Debug(tag, $"TextFieldTranslatableText END (OK)");
                    Assert.Pass("Caught ArgumentNullException: Passed!");
                }
            }
        }

        [Test]
        [Category("P1")]
        [Description("TextField TranslatablePlaceholderText.")]
        [Property("SPEC", "Tizen.NUI.TextField.TranslatablePlaceholderText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldTranslatablePlaceholderText()
        {
            tlog.Debug(tag, $"TextFieldTranslatablePlaceholderText START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            if (NUIApplication.MultilingualResourceManager != null)
            {
                testingTarget.TranslatablePlaceholderText = "TextFieldTranslatableText";
                Assert.AreEqual("TextFieldTranslatableText", testingTarget.TranslatablePlaceholderText, "Should be equal!");

                testingTarget.Dispose();
                tlog.Debug(tag, $"TextFieldTranslatablePlaceholderText END (OK)");
            }
            else
            {
                try
                {
                    testingTarget.TranslatablePlaceholderText = "TextFieldTranslatableText";
                }
                catch (ArgumentNullException e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    tlog.Debug(tag, $"TextFieldTranslatablePlaceholderText END (OK)");
                    Assert.Pass("Caught ArgumentNullException: Passed!");
                }
            }
        }

        [Test]
        [Category("P1")]
        [Description("TextField TranslatablePlaceholderTextFocused.")]
        [Property("SPEC", "Tizen.NUI.TextField.TranslatablePlaceholderTextFocused A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldTranslatablePlaceholderTextFocused()
        {
            tlog.Debug(tag, $"TextFieldTranslatablePlaceholderTextFocused START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            if (NUIApplication.MultilingualResourceManager != null)
            {
                testingTarget.TranslatablePlaceholderTextFocused = "TextFieldTranslatableText";
                Assert.AreEqual("TextFieldTranslatableText", testingTarget.TranslatablePlaceholderTextFocused, "Should be equal!");

                testingTarget.Dispose();
                tlog.Debug(tag, $"TextFieldTranslatablePlaceholderTextFocused END (OK)");
            }
            else
            {
                try
                {
                    testingTarget.TranslatablePlaceholderTextFocused = "TextFieldTranslatableText";
                }
                catch (ArgumentNullException e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    tlog.Debug(tag, $"TextFieldTranslatablePlaceholderTextFocused END (OK)");
                    Assert.Pass("Caught ArgumentNullException: Passed!");
                }
            }
        }

        [Test]
        [Category("P1")]
        [Description("TextField Text.")]
        [Property("SPEC", "Tizen.NUI.TextField.Text A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldText()
        {
            tlog.Debug(tag, $"TextFieldText START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.Text = "TextFieldText";
            Assert.AreEqual("TextFieldText", testingTarget.Text, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldText END (OK)");

        }

        [Test]
        [Category("P1")]
        [Description("TextField PlaceholderText.")]
        [Property("SPEC", "Tizen.NUI.TextField.PlaceholderText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldPlaceholderText()
        {
            tlog.Debug(tag, $"TextFieldPlaceholderText START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.PlaceholderText = "PlaceholderText";
            Assert.AreEqual("PlaceholderText", testingTarget.PlaceholderText, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldPlaceholderText END (OK)");

        }

        [Test]
        [Category("P1")]
        [Description("TextField PlaceholderTextFocused.")]
        [Property("SPEC", "Tizen.NUI.TextField.PlaceholderTextFocused A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldPlaceholderTextFocused()
        {
            tlog.Debug(tag, $"TextFieldPlaceholderTextFocused START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.PlaceholderTextFocused = "PlaceholderTextFocused";
            Assert.AreEqual("PlaceholderTextFocused", testingTarget.PlaceholderTextFocused, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldPlaceholderTextFocused END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField FontFamily.")]
        [Property("SPEC", "Tizen.NUI.TextField.FontFamily A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldFontFamily()
        {
            tlog.Debug(tag, $"TextFieldFontFamily START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.FontFamily = "BreezeSans";
            Assert.AreEqual("BreezeSans", testingTarget.FontFamily, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldFontFamily END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField FontStyle.")]
        [Property("SPEC", "Tizen.NUI.TextField.FontStyle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldFontStyle()
        {
            tlog.Debug(tag, $"TextFieldFontFamily START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            using (PropertyMap fontStyle = new PropertyMap())
            {
                fontStyle.Add("weight", new PropertyValue("bold"));
                fontStyle.Add("width", new PropertyValue("condensed"));
                fontStyle.Add("slant", new PropertyValue("italic"));

                testingTarget.FontStyle = fontStyle;
                Assert.IsNotNull(testingTarget.FontStyle, "Should not be null!");
            }
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldFontFamily END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField PointSize.")]
        [Property("SPEC", "Tizen.NUI.TextField.PointSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldPointSize()
        {
            tlog.Debug(tag, $"TextFieldPointSize START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.PointSize = 15.0f;
            Assert.AreEqual(15.0f, testingTarget.PointSize, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldPointSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField MaxLength.")]
        [Property("SPEC", "Tizen.NUI.TextField.MaxLength A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldMaxLength()
        {
            tlog.Debug(tag, $"TextFieldMaxLength START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.MaxLength = 1000;
            Assert.AreEqual(1000, testingTarget.MaxLength, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldMaxLength END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField ExceedPolicy.")]
        [Property("SPEC", "Tizen.NUI.TextField.ExceedPolicy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldExceedPolicy()
        {
            tlog.Debug(tag, $"TextFieldExceedPolicy START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.ExceedPolicy = 1000;
            Assert.AreEqual(1000, testingTarget.ExceedPolicy, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldExceedPolicy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField HorizontalAlignment.")]
        [Property("SPEC", "Tizen.NUI.TextField.HorizontalAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldHorizontalAlignment()
        {
            tlog.Debug(tag, $"TextFieldHorizontalAlignment START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.HorizontalAlignment = HorizontalAlignment.End;
            Assert.AreEqual(HorizontalAlignment.End, testingTarget.HorizontalAlignment, "Should be equal!");

            testingTarget.HorizontalAlignment = HorizontalAlignment.Begin;
            Assert.AreEqual(HorizontalAlignment.Begin, testingTarget.HorizontalAlignment, "Should be equal!");

            testingTarget.HorizontalAlignment = HorizontalAlignment.Center;
            Assert.AreEqual(HorizontalAlignment.Center, testingTarget.HorizontalAlignment, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldHorizontalAlignment END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField VerticalAlignment.")]
        [Property("SPEC", "Tizen.NUI.TextField.VerticalAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldVerticalAlignment()
        {
            tlog.Debug(tag, $"TextFieldVerticalAlignment START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.VerticalAlignment = VerticalAlignment.Bottom;
            Assert.AreEqual(VerticalAlignment.Bottom, testingTarget.VerticalAlignment, "Should be equal!");

            testingTarget.VerticalAlignment = VerticalAlignment.Top;
            Assert.AreEqual(VerticalAlignment.Top, testingTarget.VerticalAlignment, "Should be equal!");

            testingTarget.VerticalAlignment = VerticalAlignment.Center;
            Assert.AreEqual(VerticalAlignment.Center, testingTarget.VerticalAlignment, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldVerticalAlignment END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField TextColor.")]
        [Property("SPEC", "Tizen.NUI.TextField.TextColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldTextColor()
        {
            tlog.Debug(tag, $"TextFieldTextColor START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.TextColor = new Color(1.0f, 1.0f, 0.8f, 0.0f);
            Assert.AreEqual(1.0f, testingTarget.TextColor.R, "Should be equal!");
            Assert.AreEqual(1.0f, testingTarget.TextColor.G, "Should be equal!");
            Assert.AreEqual(0.8f, testingTarget.TextColor.B, "Should be equal!");
            Assert.AreEqual(0.0f, testingTarget.TextColor.A, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldTextColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField PlaceholderTextColor.")]
        [Property("SPEC", "Tizen.NUI.TextField.PlaceholderTextColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldPlaceholderTextColor()
        {
            tlog.Debug(tag, $"TextFieldPlaceholderTextColor START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.PlaceholderTextColor = new Vector4(1.0f, 1.0f, 0.8f, 0.0f);
            Assert.AreEqual(1.0f, testingTarget.PlaceholderTextColor.X, "Should be equal!");
            Assert.AreEqual(1.0f, testingTarget.PlaceholderTextColor.Y, "Should be equal!");
            Assert.AreEqual(0.8f, testingTarget.PlaceholderTextColor.Z, "Should be equal!");
            Assert.AreEqual(0.0f, testingTarget.PlaceholderTextColor.W, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldPlaceholderTextColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField ShadowOffset.")]
        [Property("SPEC", "Tizen.NUI.TextField.ShadowOffset A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldShadowOffset()
        {
            tlog.Debug(tag, $"TextFieldShadowOffset START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.ShadowOffset = new Vector2(1.0f, 0.8f);
            Assert.AreEqual(1.0f, testingTarget.ShadowOffset.X, "Should be equal!");
            Assert.AreEqual(0.8f, testingTarget.ShadowOffset.Y, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldShadowOffset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField ShadowColor.")]
        [Property("SPEC", "Tizen.NUI.TextField.ShadowColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldShadowColor()
        {
            tlog.Debug(tag, $"TextFieldShadowColor START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.ShadowColor = new Vector4(1.0f, 1.0f, 0.8f, 0.0f);
            Assert.AreEqual(1.0f, testingTarget.ShadowColor.X, "Should be equal!");
            Assert.AreEqual(1.0f, testingTarget.ShadowColor.Y, "Should be equal!");
            Assert.AreEqual(0.8f, testingTarget.ShadowColor.Z, "Should be equal!");
            Assert.AreEqual(0.0f, testingTarget.ShadowColor.W, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldShadowColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField PrimaryCursorColor.")]
        [Property("SPEC", "Tizen.NUI.TextField.PrimaryCursorColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldPrimaryCursorColor()
        {
            tlog.Debug(tag, $"TextFieldPrimaryCursorColor START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.PrimaryCursorColor = new Vector4(1.0f, 1.0f, 0.8f, 0.0f);
            Assert.AreEqual(1.0f, testingTarget.PrimaryCursorColor.X, "Should be equal!");
            Assert.AreEqual(1.0f, testingTarget.PrimaryCursorColor.Y, "Should be equal!");
            Assert.AreEqual(0.8f, testingTarget.PrimaryCursorColor.Z, "Should be equal!");
            Assert.AreEqual(0.0f, testingTarget.PrimaryCursorColor.W, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldPrimaryCursorColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField SecondaryCursorColor.")]
        [Property("SPEC", "Tizen.NUI.TextField.SecondaryCursorColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldSecondaryCursorColor()
        {
            tlog.Debug(tag, $"TextFieldSecondaryCursorColor START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.SecondaryCursorColor = new Vector4(1.0f, 0.5f, 0.0f, 0.8f);
            Assert.AreEqual(1.0f, testingTarget.SecondaryCursorColor.X, "Should be equal!");
            Assert.AreEqual(0.5f, testingTarget.SecondaryCursorColor.Y, "Should be equal!");
            Assert.AreEqual(0.0f, testingTarget.SecondaryCursorColor.Z, "Should be equal!");
            Assert.AreEqual(0.8f, testingTarget.SecondaryCursorColor.W, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldSecondaryCursorColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField EnableCursorBlink.")]
        [Property("SPEC", "Tizen.NUI.TextField.EnableCursorBlink A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldEnableCursorBlink()
        {
            tlog.Debug(tag, $"TextFieldEnableCursorBlink START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.EnableCursorBlink = true;
            Assert.AreEqual(true, testingTarget.EnableCursorBlink, "Should be equal!");

            testingTarget.EnableCursorBlink = false;
            Assert.AreEqual(false, testingTarget.EnableCursorBlink, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldEnableCursorBlink END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField CursorBlinkInterval.")]
        [Property("SPEC", "Tizen.NUI.TextField.CursorBlinkInterval A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldCursorBlinkInterval()
        {
            tlog.Debug(tag, $"TextFieldCursorBlinkInterval START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.CursorBlinkInterval = 0.3f;
            Assert.AreEqual(0.3f, testingTarget.CursorBlinkInterval, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldCursorBlinkInterval END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField CursorBlinkDuration.")]
        [Property("SPEC", "Tizen.NUI.TextField.CursorBlinkDuration A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldCursorBlinkDuration()
        {
            tlog.Debug(tag, $"TextFieldCursorBlinkDuration START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.CursorBlinkDuration = 300;
            Assert.AreEqual(300, testingTarget.CursorBlinkDuration, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldCursorBlinkDuration END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField CursorWidth.")]
        [Property("SPEC", "Tizen.NUI.TextField.CursorWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldCursorWidth()
        {
            tlog.Debug(tag, $"TextFieldCursorWidth START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.CursorWidth = 4;
            Assert.AreEqual(4, testingTarget.CursorWidth, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldCursorWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField GrabHandleImage.")]
        [Property("SPEC", "Tizen.NUI.TextField.GrabHandleImage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldGrabHandleImage()
        {
            tlog.Debug(tag, $"TextFieldGrabHandleImage START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.GrabHandleImage = url;
            Assert.AreEqual(url, testingTarget.GrabHandleImage, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldGrabHandleImage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField GrabHandlePressedImage.")]
        [Property("SPEC", "Tizen.NUI.TextField.GrabHandlePressedImage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldGrabHandlePressedImage()
        {
            tlog.Debug(tag, $"TextFieldGrabHandlePressedImage START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.GrabHandlePressedImage = url;
            Assert.AreEqual(url, testingTarget.GrabHandlePressedImage, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldGrabHandlePressedImage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField ScrollThreshold.")]
        [Property("SPEC", "Tizen.NUI.TextField.ScrollThreshold A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldScrollThreshold()
        {
            tlog.Debug(tag, $"TextFieldScrollThreshold START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.ScrollThreshold = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.ScrollThreshold, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldScrollThreshold END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField ScrollSpeed.")]
        [Property("SPEC", "Tizen.NUI.TextField.ScrollSpeed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldScrollSpeed()
        {
            tlog.Debug(tag, $"TextFieldScrollSpeed START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.ScrollSpeed = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.ScrollSpeed, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldScrollSpeed END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField SelectionHandleImageLeft.")]
        [Property("SPEC", "Tizen.NUI.TextField.SelectionHandleImageLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldSelectionHandleImageLeft()
        {
            tlog.Debug(tag, $"TextFieldSelectionHandleImageLeft START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            using (PropertyMap map = new PropertyMap())
            {
                map.Add("SelectionHandleImageLeft", new PropertyValue(5.0f));

                testingTarget.SelectionHandleImageLeft = map;

                var result = testingTarget.SelectionHandleImageLeft;
                Assert.IsNotNull(result, "Can't create success object PropertyMap");
                Assert.IsInstanceOf<PropertyMap>(result, "Should be an instance of PropertyMap type.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldSelectionHandleImageLeft END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField SelectionHandleImageRight.")]
        [Property("SPEC", "Tizen.NUI.TextField.SelectionHandleImageRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldSelectionHandleImageRight()
        {
            tlog.Debug(tag, $"TextFieldSelectionHandleImageRight START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            using (PropertyMap map = new PropertyMap())
            {
                map.Add("SelectionHandleImageLeft", new PropertyValue(5.0f));

                testingTarget.SelectionHandleImageRight = map;

                var result = testingTarget.SelectionHandleImageRight;
                Assert.IsNotNull(result, "Can't create success object PropertyMap");
                Assert.IsInstanceOf<PropertyMap>(result, "Should be an instance of PropertyMap type.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldSelectionHandleImageRight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField SelectionHandlePressedImageLeft.")]
        [Property("SPEC", "Tizen.NUI.TextField.SelectionHandlePressedImageLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldSelectionHandlePressedImageLeft()
        {
            tlog.Debug(tag, $"TextFieldSelectionHandlePressedImageLeft START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            using (PropertyMap map = new PropertyMap())
            {
                map.Add("SelectionHandleImageLeft", new PropertyValue(5.0f));

                testingTarget.SelectionHandlePressedImageLeft = map;

                var result = testingTarget.SelectionHandlePressedImageLeft;
                Assert.IsNotNull(result, "Can't create success object PropertyMap");
                Assert.IsInstanceOf<PropertyMap>(result, "Should be an instance of PropertyMap type.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldSelectionHandlePressedImageLeft END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField SelectionHandlePressedImageRight.")]
        [Property("SPEC", "Tizen.NUI.TextField.SelectionHandlePressedImageRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldSelectionHandlePressedImageRight()
        {
            tlog.Debug(tag, $"TextFieldSelectionHandlePressedImageRight START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            using (PropertyMap map = new PropertyMap())
            {
                map.Add("SelectionHandleImageLeft", new PropertyValue(5.0f));

                testingTarget.SelectionHandlePressedImageRight = map;

                var result = testingTarget.SelectionHandlePressedImageRight;
                Assert.IsNotNull(result, "Can't create success object PropertyMap");
                Assert.IsInstanceOf<PropertyMap>(result, "Should be an instance of PropertyMap type.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldSelectionHandlePressedImageRight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField SelectionHandleMarkerImageLeft.")]
        [Property("SPEC", "Tizen.NUI.TextField.SelectionHandleMarkerImageLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldSelectionHandleMarkerImageLeft()
        {
            tlog.Debug(tag, $"TextFieldSelectionHandleMarkerImageLeft START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            using (PropertyMap map = new PropertyMap())
            {
                map.Add("SelectionHandleImageLeft", new PropertyValue(5.0f));

                testingTarget.SelectionHandleMarkerImageLeft = map;

                var result = testingTarget.SelectionHandleMarkerImageLeft;
                Assert.IsNotNull(result, "Can't create success object PropertyMap");
                Assert.IsInstanceOf<PropertyMap>(result, "Should be an instance of PropertyMap type.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldSelectionHandleMarkerImageLeft END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField SelectionHandleMarkerImageRight.")]
        [Property("SPEC", "Tizen.NUI.TextField.SelectionHandleMarkerImageRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldSelectionHandleMarkerImageRight()
        {
            tlog.Debug(tag, $"TextFieldSelectionHandleMarkerImageRight START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            using (PropertyMap map = new PropertyMap())
            {
                map.Add("SelectionHandleImageLeft", new PropertyValue(5.0f));

                testingTarget.SelectionHandleMarkerImageRight = map;

                var result = testingTarget.SelectionHandleMarkerImageRight;
                Assert.IsNotNull(result, "Can't create success object PropertyMap");
                Assert.IsInstanceOf<PropertyMap>(result, "Should be an instance of PropertyMap type.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldSelectionHandleMarkerImageRight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField SelectionHighlightColor.")]
        [Property("SPEC", "Tizen.NUI.TextField.SelectionHighlightColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldSelectionHighlightColor()
        {
            tlog.Debug(tag, $"TextFieldSelectionHighlightColor START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.SelectionHighlightColor = new Vector4(0.3f, 0.5f, 0.8f, 0.0f);
            Assert.AreEqual(0.3f, testingTarget.SelectionHighlightColor.X, "Should be equal!");
            Assert.AreEqual(0.5f, testingTarget.SelectionHighlightColor.Y, "Should be equal!");
            Assert.AreEqual(0.8f, testingTarget.SelectionHighlightColor.Z, "Should be equal!");
            Assert.AreEqual(0.0f, testingTarget.SelectionHighlightColor.W, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldSelectionHighlightColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField DecorationBoundingBox.")]
        [Property("SPEC", "Tizen.NUI.TextField.DecorationBoundingBox A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldDecorationBoundingBox()
        {
            tlog.Debug(tag, $"TextFieldDecorationBoundingBox START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.DecorationBoundingBox = new Rectangle(3, 5, 8, 10);
            Assert.AreEqual(3, testingTarget.DecorationBoundingBox.X, "Should be equal!");
            Assert.AreEqual(5, testingTarget.DecorationBoundingBox.Y, "Should be equal!");
            Assert.AreEqual(8, testingTarget.DecorationBoundingBox.Width, "Should be equal!");
            Assert.AreEqual(10, testingTarget.DecorationBoundingBox.Height, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldDecorationBoundingBox END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField InputMethodSettings.")]
        [Property("SPEC", "Tizen.NUI.TextField.InputMethodSettings A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldInputMethodSettings()
        {
            tlog.Debug(tag, $"TextFieldInputMethodSettings START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            using (PropertyMap map = new PropertyMap())
            {
                map.Add("InputMethodSettings", new PropertyValue(5.0f));

                testingTarget.InputMethodSettings = map;

                var result = testingTarget.InputMethodSettings;
                Assert.IsNotNull(result, "Can't create success object PropertyMap");
                Assert.IsInstanceOf<PropertyMap>(result, "Should be an instance of PropertyMap type.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldInputMethodSettings END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField InputColor.")]
        [Property("SPEC", "Tizen.NUI.TextField.InputColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextFieldInputColor()
        {
            tlog.Debug(tag, $"TextFieldInputColor START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.InputColor = new Vector4(0.3f, 0.5f, 0.8f, 0.0f);
            Assert.AreEqual(0.3f, testingTarget.InputColor.X, "Should be equal!");
            Assert.AreEqual(0.5f, testingTarget.InputColor.Y, "Should be equal!");
            Assert.AreEqual(0.8f, testingTarget.InputColor.Z, "Should be equal!");
            Assert.AreEqual(0.0f, testingTarget.InputColor.W, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldInputColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField EnableMarkup.")]
        [Property("SPEC", "Tizen.NUI.TextField.EnableMarkup A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldEnableMarkup()
        {
            tlog.Debug(tag, $"TextFieldEnableMarkup START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.EnableMarkup = true;
            Assert.AreEqual(true, testingTarget.EnableMarkup, "Should be equal!");

            testingTarget.EnableMarkup = false;
            Assert.AreEqual(false, testingTarget.EnableMarkup, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldEnableMarkup END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField InputFontFamily.")]
        [Property("SPEC", "Tizen.NUI.TextField.InputFontFamily A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldInputFontFamily()
        {
            tlog.Debug(tag, $"TextFieldInputFontFamily START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.InputFontFamily = "BreezeSans";
            Assert.AreEqual("BreezeSans", testingTarget.InputFontFamily, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldInputFontFamily END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField InputFontStyle.")]
        [Property("SPEC", "Tizen.NUI.TextField.InputFontStyle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldInputFontStyle()
        {
            tlog.Debug(tag, $"TextFieldInputFontStyle START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            using (PropertyMap fontStyle = new PropertyMap())
            {
                fontStyle.Add("weight", new PropertyValue("bold"));
                fontStyle.Add("width", new PropertyValue("condensed"));
                fontStyle.Add("slant", new PropertyValue("italic"));

                testingTarget.InputFontStyle = fontStyle;
                Assert.IsNotNull(testingTarget.InputFontStyle, "Should not be null!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldInputFontStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField InputPointSize.")]
        [Property("SPEC", "Tizen.NUI.TextField.InputPointSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldInputPointSize()
        {
            tlog.Debug(tag, $"TextFieldInputPointSize START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.InputPointSize = 15.0f;
            Assert.AreEqual(15.0f, testingTarget.InputPointSize, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldInputPointSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField Underline.")]
        [Property("SPEC", "Tizen.NUI.TextField.Underline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldUnderline()
        {
            tlog.Debug(tag, $"TextFieldUnderline START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            using (PropertyMap map = new PropertyMap())
            {
                map.Add("Underline", new PropertyValue(5.0f));

                testingTarget.Underline = map;

                var result = testingTarget.Underline;
                Assert.IsNotNull(result, "Can't create success object PropertyMap");
                Assert.IsInstanceOf<PropertyMap>(result, "Should be an instance of PropertyMap type.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldUnderline END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField InputUnderline.")]
        [Property("SPEC", "Tizen.NUI.TextField.InputUnderline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldInputUnderline()
        {
            tlog.Debug(tag, $"TextFieldInputUnderline START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.InputUnderline = "40";
            Assert.AreEqual("40", testingTarget.InputUnderline, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldInputUnderline END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField Shadow.")]
        [Property("SPEC", "Tizen.NUI.TextField.Shadow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldShadow()
        {
            tlog.Debug(tag, $"TextFieldShadow START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            using (PropertyMap map = new PropertyMap())
            {
                map.Add("Shadow", new PropertyValue(5.0f));

                testingTarget.Underline = map;

                var result = testingTarget.Shadow;
                Assert.IsNotNull(result, "Can't create success object PropertyMap");
                Assert.IsInstanceOf<PropertyMap>(result, "Should be an instance of PropertyMap type.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldShadow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField InputShadow.")]
        [Property("SPEC", "Tizen.NUI.TextField.InputShadow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldInputShadow()
        {
            tlog.Debug(tag, $"TextFieldInputShadow START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.InputShadow = "40";
            Assert.AreEqual("40", testingTarget.InputShadow, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldInputShadow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField Emboss.")]
        [Property("SPEC", "Tizen.NUI.TextField.Emboss A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldEmboss()
        {
            tlog.Debug(tag, $"TextFieldEmboss START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.Emboss = "40";
            Assert.AreEqual("40", testingTarget.Emboss, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldEmboss END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField InputEmboss.")]
        [Property("SPEC", "Tizen.NUI.TextField.InputEmboss A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldInputEmboss()
        {
            tlog.Debug(tag, $"TextFieldInputEmboss START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.InputEmboss = "40";
            Assert.AreEqual("40", testingTarget.InputEmboss, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldInputEmboss END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField Outline.")]
        [Property("SPEC", "Tizen.NUI.TextField.Outline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldOutline()
        {
            tlog.Debug(tag, $"TextFieldOutline START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            using (PropertyMap map = new PropertyMap())
            {
                map.Add("Shadow", new PropertyValue(5.0f));

                testingTarget.Outline = map;

                var result = testingTarget.Outline;
                Assert.IsNotNull(result, "Can't create success object PropertyMap");
                Assert.IsInstanceOf<PropertyMap>(result, "Should be an instance of PropertyMap type.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldOutline END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField InputOutline.")]
        [Property("SPEC", "Tizen.NUI.TextField.InputOutline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldInputOutline()
        {
            tlog.Debug(tag, $"TextFieldInputOutline START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.InputOutline = "40";
            Assert.AreEqual("40", testingTarget.InputOutline, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldInputOutline END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField HiddenInputSettings.")]
        [Property("SPEC", "Tizen.NUI.TextField.HiddenInputSettings A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldHiddenInputSettings()
        {
            tlog.Debug(tag, $"TextFieldHiddenInputSettings START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            using (PropertyMap map = new PropertyMap())
            {
                map.Add("HiddenInputSettings", new PropertyValue(5.0f));

                testingTarget.HiddenInputSettings = map;

                var result = testingTarget.HiddenInputSettings;
                Assert.IsNotNull(result, "Can't create success object PropertyMap");
                Assert.IsInstanceOf<PropertyMap>(result, "Should be an instance of PropertyMap type.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldHiddenInputSettings END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField PixelSize.")]
        [Property("SPEC", "Tizen.NUI.TextField.PixelSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldPixelSize()
        {
            tlog.Debug(tag, $"TextFieldPixelSize START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.PixelSize = 0.3f;
            Assert.AreEqual(0.3f, testingTarget.PixelSize, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldPixelSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField EnableSelection.")]
        [Property("SPEC", "Tizen.NUI.TextField.EnableSelection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldEnableSelection()
        {
            tlog.Debug(tag, $"TextFieldEnableSelection START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.EnableSelection = true;
            Assert.AreEqual(true, testingTarget.EnableSelection, "Should be equal!");

            testingTarget.EnableSelection = false;
            Assert.AreEqual(false, testingTarget.EnableSelection, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldEnableSelection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField EnableGrabHandle.")]
        [Property("SPEC", "Tizen.NUI.TextField.EnableGrabHandle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldEnableGrabHandle()
        {
            tlog.Debug(tag, $"TextFieldEnableGrabHandle START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.EnableGrabHandle = true;
            Assert.AreEqual(true, testingTarget.EnableGrabHandle, "Should be equal!");

            testingTarget.EnableGrabHandle = false;
            Assert.AreEqual(false, testingTarget.EnableGrabHandle, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldEnableGrabHandle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField EnableGrabHandlePopup.")]
        [Property("SPEC", "Tizen.NUI.TextField.EnableGrabHandlePopup A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldEnableGrabHandlePopup()
        {
            tlog.Debug(tag, $"TextFieldEnableGrabHandlePopup START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.EnableGrabHandlePopup = true;
            Assert.AreEqual(true, testingTarget.EnableGrabHandlePopup, "Should be equal!");

            testingTarget.EnableGrabHandlePopup = false;
            Assert.AreEqual(false, testingTarget.EnableGrabHandlePopup, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldEnableGrabHandlePopup END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField GrabHandleColor.")]
        [Property("SPEC", "Tizen.NUI.TextField.GrabHandleColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldGrabHandleColor()
        {
            tlog.Debug(tag, $"TextFieldGrabHandleColor START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.GrabHandleColor = new Color(1.0f, 1.0f, 0.8f, 0.0f);
            Assert.AreEqual(1.0f, testingTarget.GrabHandleColor.R, "Should be equal!");
            Assert.AreEqual(1.0f, testingTarget.GrabHandleColor.G, "Should be equal!");
            Assert.AreEqual(0.8f, testingTarget.GrabHandleColor.B, "Should be equal!");
            Assert.AreEqual(0.0f, testingTarget.GrabHandleColor.A, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldGrabHandleColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField Placeholder.")]
        [Property("SPEC", "Tizen.NUI.TextField.Placeholder A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldPlaceholder()
        {
            tlog.Debug(tag, $"TextFieldPlaceholder START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            using (PropertyMap map = new PropertyMap())
            {
                map.Add("Placeholder", new PropertyValue(5.0f));

                testingTarget.Placeholder = map;

                var result = testingTarget.Placeholder;
                Assert.IsNotNull(result, "Can't create success object PropertyMap");
                Assert.IsInstanceOf<PropertyMap>(result, "Should be an instance of PropertyMap type.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldPlaceholder END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField Ellipsis.")]
        [Property("SPEC", "Tizen.NUI.TextField.Ellipsis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldEllipsis()
        {
            tlog.Debug(tag, $"TextFieldEllipsis START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.Ellipsis = true;
            Assert.AreEqual(true, testingTarget.Ellipsis, "Should be equal!");

            testingTarget.Ellipsis = false;
            Assert.AreEqual(false, testingTarget.Ellipsis, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldEllipsis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField EnableShiftSelection.")]
        [Property("SPEC", "Tizen.NUI.TextField.EnableShiftSelection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldEnableShiftSelection()
        {
            tlog.Debug(tag, $"TextFieldEnableShiftSelection START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.EnableShiftSelection = true;
            Assert.AreEqual(true, testingTarget.EnableShiftSelection, "Should be equal!");

            testingTarget.EnableShiftSelection = false;
            Assert.AreEqual(false, testingTarget.EnableShiftSelection, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldEnableShiftSelection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField MatchSystemLanguageDirection.")]
        [Property("SPEC", "Tizen.NUI.TextField.MatchSystemLanguageDirection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldMatchSystemLanguageDirection()
        {
            tlog.Debug(tag, $"TextFieldMatchSystemLanguageDirection START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.MatchSystemLanguageDirection = true;
            Assert.AreEqual(true, testingTarget.MatchSystemLanguageDirection, "Should be equal!");

            testingTarget.MatchSystemLanguageDirection = false;
            Assert.AreEqual(false, testingTarget.MatchSystemLanguageDirection, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldMatchSystemLanguageDirection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField FontSizeScale.")]
        [Property("SPEC", "Tizen.NUI.TextField.FontSizeScale A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldFontSizeScale()
        {
            tlog.Debug(tag, $"TextFieldFontSizeScale START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.FontSizeScale = 2.0f;
            Assert.AreEqual(2.0f, testingTarget.FontSizeScale, "Should be equal!");

            testingTarget.FontSizeScale = Tizen.NUI.FontSizeScale.UseSystemSetting;

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldFontSizeScale END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField SelectWholeText.")]
        [Property("SPEC", "Tizen.NUI.TextField.SelectWholeText M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldSelectWholeText()
        {
            tlog.Debug(tag, $"TextFieldSelectWholeText START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            try
            {
                testingTarget.SelectWholeText();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"TextFieldSelectWholeText END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField SelectNone.")]
        [Property("SPEC", "Tizen.NUI.TextField.SelectNone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldSelectNone()
        {
            tlog.Debug(tag, $"TextFieldSelectNone START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            try
            {
                testingTarget.SelectNone();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"TextFieldSelectNone END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField Dispose.")]
        [Property("SPEC", "Tizen.NUI.TextField.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextFieldDispose()
        {
            tlog.Debug(tag, $"TextFieldDispose START");

            var testingTarget = new MyTextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.OnDispose(DisposeTypes.Explicit);

            try
            {
                testingTarget.OnDispose(DisposeTypes.Explicit);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"TextFieldDispose END (OK)");
        }
    }
}

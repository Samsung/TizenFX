﻿using global::System;
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

        public bool CheckColor(Color colorSrc, Color colorDst)
        {
            if (colorSrc.R == colorDst.R && colorSrc.G == colorDst.G && colorSrc.B == colorDst.B && colorSrc.A == colorDst.A)
                return true;

            return false;
        }

        public bool CheckColor(Vector4 colorSrc, Vector4 colorDst)
        {
            if (colorSrc.X == colorDst.X && colorSrc.Y == colorDst.Y && colorSrc.Z == colorDst.Z && colorSrc.W == colorDst.W)
                return true;

            return false;
        }

        public bool CheckVector2(Vector2 vectorSrc, Vector2 vectorDst)
        {
            if (vectorSrc.X == vectorDst.X && vectorSrc.Y == vectorDst.Y)
                return true;

            return false;
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
            var color = new Color(1.0f, 1.0f, 0.8f, 0.0f);
            Assert.AreEqual(true, CheckColor(color, testingTarget.TextColor), "Should be true!");

            color.Dispose();
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
            var color = new Vector4(1.0f, 1.0f, 0.8f, 0.0f);
            Assert.AreEqual(true, CheckColor(color, testingTarget.PlaceholderTextColor), "Should be true!");

            color.Dispose();
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
            var color = new Vector4(1.0f, 1.0f, 0.8f, 0.0f);
            Assert.AreEqual(true, CheckColor(color, testingTarget.ShadowColor), "Should be true!");

            color.Dispose();
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
            var color = new Vector4(1.0f, 1.0f, 0.8f, 0.0f);
            Assert.AreEqual(true, CheckColor(color, testingTarget.PrimaryCursorColor), "Should be true!");

            color.Dispose();
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
            var color = new Vector4(1.0f, 0.5f, 0.0f, 0.8f);
            Assert.AreEqual(true, CheckColor(color, testingTarget.SecondaryCursorColor), "Should be true!");

            color.Dispose();
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
            var color = new Vector4(0.3f, 0.5f, 0.8f, 0.0f);
            Assert.AreEqual(true, CheckColor(color, testingTarget.SelectionHighlightColor), "Should be true!");

            color.Dispose();
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
            var color = new Vector4(0.3f, 0.5f, 0.8f, 0.0f);
            Assert.AreEqual(true, CheckColor(color, testingTarget.InputColor), "Should be true!");

            color.Dispose();
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
            var color = new Color(1.0f, 1.0f, 0.8f, 0.0f);
            Assert.AreEqual(true, CheckColor(color, testingTarget.GrabHandleColor), "Should be true!");

            color.Dispose();
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
            Assert.AreEqual(Tizen.NUI.FontSizeScale.UseSystemSetting, testingTarget.FontSizeScale, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldFontSizeScale END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField EnableFontSizeScale.")]
        [Property("SPEC", "Tizen.NUI.TextField.EnableFontSizeScale A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextFieldEnableFontSizeScale()
        {
            tlog.Debug(tag, $"TextFieldEnableFontSizeScale START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.EnableFontSizeScale = false;
            Assert.AreEqual(false, testingTarget.EnableFontSizeScale, "Should be equal!");

            testingTarget.EnableFontSizeScale = true;
            Assert.AreEqual(true, testingTarget.EnableFontSizeScale, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldEnableFontSizeScale END (OK)");
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

        [Test]
        [Category("P1")]
        [Description("TextField Strikethrough.")]
        [Property("SPEC", "Tizen.NUI.TextField.GetStrikethrough M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.sabah@samsung.com")]
        public void TextFieldStrikethrough()
        {
            tlog.Debug(tag, $"TextFieldStrikethrough START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var setStrikethrough = new Tizen.NUI.Text.Strikethrough()
            {
                Enable = true,
                Color = new Color("#3498DB"),
                Height = 2.0f
            };

            testingTarget.SetStrikethrough(setStrikethrough);

            var getStrikethrough = testingTarget.GetStrikethrough();
            Assert.AreEqual(getStrikethrough.Enable, setStrikethrough.Enable, "Should be equal!");
            Assert.AreEqual(true, CheckColor(getStrikethrough.Color, setStrikethrough.Color), "Should be true!");
            Assert.AreEqual(getStrikethrough.Height, setStrikethrough.Height, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldStrikethrough END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField CharacterSpacing.")]
        [Property("SPEC", "Tizen.NUI.TextField.CharacterSpacing A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "s.sabah@samsung.com")]
        public void TextFieldCharacterSpacing()
        {
            tlog.Debug(tag, $"TextFieldCharacterSpacing START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            float expandedValue = 1.5f;
            testingTarget.CharacterSpacing = expandedValue;
            Assert.AreEqual(expandedValue, testingTarget.CharacterSpacing, "Should be equal!");

            float condensedValue = -1.5f;
            testingTarget.CharacterSpacing = condensedValue;
            Assert.AreEqual(condensedValue, testingTarget.CharacterSpacing, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldCharacterSpacing END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField GetFontStyle.")]
        [Property("SPEC", "Tizen.NUI.TextField.GetFontStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextFieldGetFontStyle()
        {
            tlog.Debug(tag, $"TextFieldGetFontStyle START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var setFontStyle = new Tizen.NUI.Text.FontStyle()
            {
                Width = FontWidthType.Condensed,
                Weight = FontWeightType.Light,
                Slant = FontSlantType.Italic,
            };

            testingTarget.SetFontStyle(setFontStyle);

            var getFontStyle = testingTarget.GetFontStyle();
            Assert.AreEqual(getFontStyle.Width, setFontStyle.Width, "Should be equal!");
            Assert.AreEqual(getFontStyle.Weight, setFontStyle.Weight, "Should be equal!");
            Assert.AreEqual(getFontStyle.Slant, setFontStyle.Slant, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldGetFontStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField GetUnderline.")]
        [Property("SPEC", "Tizen.NUI.TextField.GetUnderline M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextFieldGetUnderline()
        {
            tlog.Debug(tag, $"TextFieldGetUnderline START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var setUnderline = new Tizen.NUI.Text.Underline()
            {
                Enable = true,
                Color = new Color("#3498DB"),
                Height = 2.0f,
                Type = UnderlineType.Dashed,
                DashWidth = 4.0f,
                DashGap = 6.0f,
            };

            testingTarget.SetUnderline(setUnderline);

            var getUnderline = testingTarget.GetUnderline();
            Assert.AreEqual(getUnderline.Enable, setUnderline.Enable, "Should be equal!");
            Assert.AreEqual(true, CheckColor(getUnderline.Color, setUnderline.Color), "Should be true!");
            Assert.AreEqual(getUnderline.Height, setUnderline.Height, "Should be equal!");
            Assert.AreEqual(getUnderline.Type, setUnderline.Type, "Should be equal!");
            Assert.AreEqual(getUnderline.DashWidth, setUnderline.DashWidth, "Should be equal!");
            Assert.AreEqual(getUnderline.DashGap, setUnderline.DashGap, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldGetUnderline END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField GetShadow.")]
        [Property("SPEC", "Tizen.NUI.TextField.GetShadow M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextFieldGetShadow()
        {
            tlog.Debug(tag, $"TextFieldGetShadow START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var setShadow = new Tizen.NUI.Text.Shadow()
            {
                BlurRadius = 5.0f,
                Color = Color.Red,
                Offset = new Vector2(3, 3),
            };

            testingTarget.SetShadow(setShadow);

            var getShadow = testingTarget.GetShadow();
            Assert.AreEqual(getShadow.BlurRadius, setShadow.BlurRadius, "Should be equal!");
            Assert.AreEqual(true, CheckColor(getShadow.Color, setShadow.Color), "Should be true!");
            Assert.AreEqual(true, CheckVector2(getShadow.Offset, setShadow.Offset), "Should be true!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldGetShadow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField GetOutline.")]
        [Property("SPEC", "Tizen.NUI.TextField.GetOutline M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextFieldGetOutline()
        {
            tlog.Debug(tag, $"TextFieldGetOutline START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var setOutline = new Tizen.NUI.Text.Outline()
            {
                Width = 2.0f,
                Color = Color.Red,
            };

            testingTarget.SetOutline(setOutline);

            var getOutline = testingTarget.GetOutline();
            Assert.AreEqual(getOutline.Width, setOutline.Width, "Should be equal!");
            Assert.AreEqual(true, CheckColor(getOutline.Color, setOutline.Color), "Should be true!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldGetOutline END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField GetSelectionHandleImage.")]
        [Property("SPEC", "Tizen.NUI.TextField.GetSelectionHandleImage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextFieldGetSelectionHandleImage()
        {
            tlog.Debug(tag, $"TextFieldGetSelectionHandleImage START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var setSelectionHandleImage = new Tizen.NUI.Text.SelectionHandleImage()
            {
                LeftImageUrl = "leftImage",
                RightImageUrl = "rightImage",
            };

            testingTarget.SetSelectionHandleImage(setSelectionHandleImage);

            var getSelectionHandleImage = testingTarget.GetSelectionHandleImage();
            Assert.AreEqual(getSelectionHandleImage.LeftImageUrl, setSelectionHandleImage.LeftImageUrl, "Should be equal!");
            Assert.AreEqual(getSelectionHandleImage.RightImageUrl, setSelectionHandleImage.RightImageUrl, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldGetSelectionHandleImage END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("TextField GetSelectionHandlePressedImage.")]
        [Property("SPEC", "Tizen.NUI.TextField.GetSelectionHandlePressedImage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextFieldGetSelectionHandlePressedImage()
        {
            tlog.Debug(tag, $"TextFieldGetSelectionHandlePressedImage START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var setSelectionHandleImage = new Tizen.NUI.Text.SelectionHandleImage()
            {
                LeftImageUrl = "leftImage",
                RightImageUrl = "rightImage",
            };

            testingTarget.SetSelectionHandlePressedImage(setSelectionHandleImage);

            var getSelectionHandleImage = testingTarget.GetSelectionHandlePressedImage();
            Assert.AreEqual(getSelectionHandleImage.LeftImageUrl, setSelectionHandleImage.LeftImageUrl, "Should be equal!");
            Assert.AreEqual(getSelectionHandleImage.RightImageUrl, setSelectionHandleImage.RightImageUrl, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldGetSelectionHandlePressedImage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField GetSelectionHandleMarkerImage.")]
        [Property("SPEC", "Tizen.NUI.TextField.GetSelectionHandleMarkerImage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextFieldGetSelectionHandleMarkerImage()
        {
            tlog.Debug(tag, $"TextFieldGetSelectionHandleMarkerImage START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var setSelectionHandleImage = new Tizen.NUI.Text.SelectionHandleImage()
            {
                LeftImageUrl = "leftImage",
                RightImageUrl = "rightImage",
            };

            testingTarget.SetSelectionHandleMarkerImage(setSelectionHandleImage);

            var getSelectionHandleImage = testingTarget.GetSelectionHandleMarkerImage();
            Assert.AreEqual(getSelectionHandleImage.LeftImageUrl, setSelectionHandleImage.LeftImageUrl, "Should be equal!");
            Assert.AreEqual(getSelectionHandleImage.RightImageUrl, setSelectionHandleImage.RightImageUrl, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldGetSelectionHandleMarkerImage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField GetHiddenInput.")]
        [Property("SPEC", "Tizen.NUI.TextField.GetHiddenInput M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextFieldGetHiddenInput()
        {
            tlog.Debug(tag, $"TextFieldGetHiddenInput START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var setHiddenInput = new Tizen.NUI.Text.HiddenInput()
            {
                Mode = HiddenInputModeType.ShowLastCharacter,
                SubstituteCharacter = '★',
                SubstituteCount = 0,
                ShowLastCharacterDuration = 1000,
            };

            testingTarget.SetHiddenInput(setHiddenInput);

            var getHiddenInput = testingTarget.GetHiddenInput();
            Assert.AreEqual(getHiddenInput.Mode, setHiddenInput.Mode, "Should be equal!");
            Assert.AreEqual(getHiddenInput.SubstituteCharacter, setHiddenInput.SubstituteCharacter, "Should be equal!");
            Assert.AreEqual(getHiddenInput.SubstituteCount, setHiddenInput.SubstituteCount, "Should be equal!");
            Assert.AreEqual(getHiddenInput.ShowLastCharacterDuration, setHiddenInput.ShowLastCharacterDuration, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldGetHiddenInput END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField GetInputFilter.")]
        [Property("SPEC", "Tizen.NUI.TextField.GetInputFilter M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextFieldGetInputFilter()
        {
            tlog.Debug(tag, $"TextFieldGetInputFilter START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var setInputFilter = new Tizen.NUI.Text.InputFilter()
            {
                Accepted = @"[\d]",
                Rejected = "[0-3]",
            };

            testingTarget.SetInputFilter(setInputFilter);

            var getInputFilter = testingTarget.GetInputFilter();
            Assert.AreEqual(getInputFilter.Accepted, setInputFilter.Accepted, "Should be equal!");
            Assert.AreEqual(getInputFilter.Rejected, setInputFilter.Rejected, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldGetInputFilter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField GetPlaceholder.")]
        [Property("SPEC", "Tizen.NUI.TextField.GetPlaceholder M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextFieldGetPlaceholder()
        {
            tlog.Debug(tag, $"TextFieldGetPlaceholder START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var setPlaceholder = new Tizen.NUI.Text.Placeholder()
            {
                Text = "placeholder text",
                TextFocused = "placeholder TextFocused",
                Color = Color.Red,
                FontFamily = "BreezeSans",
                FontStyle = new Tizen.NUI.Text.FontStyle()
                {
                    Width = FontWidthType.Expanded,
                    Weight = FontWeightType.ExtraLight,
                    Slant = FontSlantType.Italic,
                },
                PointSize = 15.0f,
                Ellipsis = true,
            };

            testingTarget.SetPlaceholder(setPlaceholder);

            var getPlaceholder = testingTarget.GetPlaceholder();
            Assert.AreEqual(getPlaceholder.Text, setPlaceholder.Text, "Should be equal!");
            Assert.AreEqual(getPlaceholder.TextFocused, setPlaceholder.TextFocused, "Should be equal!");
            Assert.AreEqual(true, CheckColor(getPlaceholder.Color, setPlaceholder.Color), "Should be true!");
            Assert.AreEqual(getPlaceholder.FontFamily, setPlaceholder.FontFamily, "Should be equal!");
            Assert.AreEqual(true, getPlaceholder.FontStyle == setPlaceholder.FontStyle, "Should be true!");
            Assert.AreEqual(getPlaceholder.PointSize, setPlaceholder.PointSize, "Should be equal!");
            Assert.AreEqual(getPlaceholder.Ellipsis, setPlaceholder.Ellipsis, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldGetPlaceholder END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField EnableEditing.")]
        [Property("SPEC", "Tizen.NUI.TextField.EnableEditing A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextFieldEnableEditing()
        {
            tlog.Debug(tag, $"TextFieldEnableEditing START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.EnableEditing = false;
            Assert.AreEqual(false, testingTarget.EnableEditing, "Should be equal!");

            testingTarget.EnableEditing = true;
            Assert.AreEqual(true, testingTarget.EnableEditing, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldEnableEditing END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextField PrimaryCursorPosition.")]
        [Property("SPEC", "Tizen.NUI.TextField.PrimaryCursorPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextFieldPrimaryCursorPosition()
        {
            tlog.Debug(tag, $"TextFieldPrimaryCursorPosition START");

            var testingTarget = new TextField(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            testingTarget.Text = "0123456789";
            testingTarget.PrimaryCursorPosition = 5;
            Assert.AreEqual(5, testingTarget.PrimaryCursorPosition, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextFieldPrimaryCursorPosition END (OK)");
        }
    }
}

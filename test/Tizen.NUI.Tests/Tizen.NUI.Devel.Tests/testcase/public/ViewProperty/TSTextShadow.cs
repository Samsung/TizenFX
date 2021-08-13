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
    [Description("public/ViewProperty/TextShadow.cs")]
    public class PublicTextShadowTest
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
        //[Description("TextShadow constructor.")]
        //[Property("SPEC", "Tizen.NUI.TextShadow.TextShadow C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void TextShadowConstructor()
        //{
        //    tlog.Debug(tag, $"TextShadowConstructor START");

        //    using (Vector2 vector = new Vector2(1.5f, 3.0f))
        //    {
        //        var testingTarget = new TextShadow(Color.Cyan, vector, 0.3f);
        //        Assert.IsNotNull(testingTarget, "Can't create success object TextShadow");
        //        Assert.IsInstanceOf<TextShadow>(testingTarget, "Should be an instance of TextShadow type.");

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"TextShadowConstructor END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("TextShadow constructor. With TextShadow.")]
        //[Property("SPEC", "Tizen.NUI.TextShadow.TextShadow C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void TextShadowConstructorWithTextShadow()
        //{
        //    tlog.Debug(tag, $"TextShadowConstructorWithTextShadow START");

        //    using (Vector2 vector = new Vector2(1.5f, 3.0f))
        //    {
        //        using (TextShadow shadow = new TextShadow(Color.Cyan, vector, 0.3f))
        //        {
        //            try
        //            {
        //                var testingTarget = new TextShadow(shadow);
        //                testingTarget.Dispose();
        //            }
        //            catch (Exception e)
        //            {
        //                tlog.Debug(tag, e.Message.ToString());
        //                Assert.Fail("Caught Exception: Failed!");
        //            }

        //        }
        //    }

        //    tlog.Debug(tag, $"TextShadowConstructorWithTextShadow END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("TextShadow constructor. With PropertyMap.")]
        [Property("SPEC", "Tizen.NUI.TextShadow.TextShadow C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextShadowConstructorWithPropertyMap()
        {
            tlog.Debug(tag, $"TextShadowConstructorWithPropertyMap START");

            TextLabel textLabel = new TextLabel()
            {
                Text = "TextShadowConstructor",
                Color = Color.Green,
                PointSize = 15.0f,
            };
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((global::System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.SHADOW).Get(temp);

            var testingTarget = new TextShadow(temp);
            Assert.IsNotNull(testingTarget, "Can't create success object TextShadow");
            Assert.IsInstanceOf<TextShadow>(testingTarget, "Should be an instance of TextShadow type.");

            textLabel.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TextShadowConstructorWithPropertyMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextShadow Clone.")]
        [Property("SPEC", "Tizen.NUI.TextShadow.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextShadowClone()
        {
            tlog.Debug(tag, $"TextShadowClone START");

            using (Vector2 vector = new Vector2(1.5f, 3.0f))
            {
                using (TextShadow textShadow = new TextShadow(Color.Cyan, vector, 0.3f))
                {
                    try
                    {
                        textShadow.Clone();
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception: Failed!");
                    }
                }
            }

            tlog.Debug(tag, $"TextShadowClone END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextShadow Clone. With TextShadow.")]
        [Property("SPEC", "Tizen.NUI.TextShadow.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextShadowCloneWithTextShadow()
        {
            tlog.Debug(tag, $"TextShadowCloneWithTextShadow START");

            TextLabel textLabel = new TextLabel()
            {
                Text = "TextShadowConstructor",
                Color = Color.Green,
                PointSize = 15.0f,
            };
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((global::System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.SHADOW).Get(temp);

            try
            {
                TextShadow.Clone(new TextShadow(temp));
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            textLabel.Dispose();
            tlog.Debug(tag, $"TextShadowCloneWithTextShadow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextShadow Clone. With null TextShadow.")]
        [Property("SPEC", "Tizen.NUI.TextShadow.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextShadowCloneWithNullTextShadow()
        {
            tlog.Debug(tag, $"TextShadowCloneWithNullTextShadow START");

            TextShadow textShadow = null;
            var testingTarget = TextShadow.Clone(textShadow);
            Assert.IsNull(testingTarget);

            tlog.Debug(tag, $"TextShadowCloneWithNullTextShadow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextShadow ToPropertyValue.")]
        [Property("SPEC", "Tizen.NUI.TextShadow.ToPropertyValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextShadowToPropertyValue()
        {
            tlog.Debug(tag, $"TextShadowToPropertyValue START");

            TextLabel textLabel = new TextLabel()
            {
                Text = "TextShadowConstructor",
                Color = Color.Green,
                PointSize = 15.0f,
            };
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((global::System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.SHADOW).Get(temp);

            using (TextShadow textShadow = new TextShadow(temp))
            {

                var testingTarget = TextShadow.ToPropertyValue(textShadow);
                Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue");
                Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should be an instance of PropertyValue type.");

                testingTarget.Dispose();
            }

            textLabel.Dispose();
            tlog.Debug(tag, $"TextShadowToPropertyValue END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("TextShadow ToPropertyValue. Instance is null.")]
        [Property("SPEC", "Tizen.NUI.TextShadow.ToPropertyValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextShadowToPropertyValueWithNullInstance()
        {
            tlog.Debug(tag, $"TextShadowToPropertyValueWithNullInstance START");

            var testingTarget = TextShadow.ToPropertyValue(null);
            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should be an instance of PropertyValue type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextShadowToPropertyValueWithNullInstance END (OK)");
        }
    }
}

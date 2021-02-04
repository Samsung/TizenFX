using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using global::System.Resources;

namespace Tizen.NUI.Devel.Tests
{
    [TestFixture]
    [Description("TSButton Example Tests")]
    public class ButtonTests
    {
        private const string TAG = "NUITEST";
        private string _image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test Button empty constructor. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.Components.Button.Button C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void Button_CHECK_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be an instance of Button!");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P2")]
        [Description("Check exception when constructing a Button with nonexistent style.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.Button C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTX")]
        [Property("COVPARAM", "string")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void Button_INIT_WITH_STRING_Exception()
        {
            /* TEST CODE */
            try
            {
                var button = new Button("defaultButtonX");
                Assert.Fail("Should throw the Exception: There is no style of defaultButtonX !");
            }
            catch (InvalidOperationException e)
            {
                Assert.Pass("InvalidOperationException: passed!");
            }
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test Button constructor using style. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.Components.Button.Button C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "ButtonStyle")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void Button_INIT_WITH_STYLE()
        {
            /* TEST CODE */
            var style = new ButtonStyle();
            Assert.IsNotNull(style, "Should be not null!");
            Assert.IsInstanceOf<ButtonStyle>(style, "Should be an instance of ButtonStyle!");

            var button = new Button(style);
            Assert.IsNotNull(button, "Should be not null!");
            Assert.IsInstanceOf<Button>(button, "Should be an instance of Button!");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test Style. Check whether Style is readable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.Style A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void Style_CHECK_GET_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be an instance of Button!");

            var style = button.Style;
            Assert.IsNotNull(style, "Should be not null");
            Assert.IsInstanceOf<ButtonStyle>(style, "Should be an instance of ButtonStyle!");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test IsSelectable. Check whether IsSelectable is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.IsSelectable A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void IsSelectable_SET_GET_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");
            button.IsSelectable = true;
            Assert.AreEqual(true, button.IsSelectable, "Should be equals to the set value");
            button.IsSelectable = false;
            Assert.AreEqual(false, button.IsSelectable, "Should be equals to the set value");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test Text. Check whether Text is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.Text A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void Text_SET_GET_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");
            button.Text = "Test Text";
            Assert.AreEqual("Test Text", button.Text, "Should be equals to the set value of Text");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test TranslatableText. Check whether TranslatableText is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.TranslatableText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void TranslatableText_SET_GET_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");
            if (NUIApplication.MultilingualResourceManager != null)
            {
                button.TranslatableText = "Test TranslatableText";
                Assert.AreEqual("Test TranslatableText", button.TranslatableText, "Should be equals to the set value of TranslatableText");
            }
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test PointSize. Check whether PointSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.PointSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void PointSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");
            button.PointSize = 10.0f;
            Assert.AreEqual(10.0f, button.PointSize, "Should be equals to the set value of PointSize");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test FontFamily. Check whether FontFamily is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.FontFamily A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void FontFamily_SET_GET_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");
            button.FontFamily = "SamsungOne 500";
            Assert.AreEqual("SamsungOne 500", button.FontFamily, "Should be equals to the set value of FontFamily");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test TextColor. Check whether TextColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.TextColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void TextColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");
            var color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            Assert.IsNotNull(color, "Should be not null");
            Assert.IsInstanceOf<Color>(color, "Should be equal!");
            button.TextColor = color;

            Assert.AreEqual(color.R, button.TextColor.R, "Should be equals to the color.R set");
            Assert.AreEqual(color.G, button.TextColor.G, "Should be equals to the color.G set");
            Assert.AreEqual(color.B, button.TextColor.B, "Should be equals to the color.B set");
            Assert.AreEqual(color.A, button.TextColor.A, "Should be equals to the color.A set");

        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test TextAlignment. Check whether TextAlignment is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.TextAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void TextAlignment_SET_GET_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");
            button.TextAlignment = HorizontalAlignment.Begin;
            Assert.AreEqual(HorizontalAlignment.Begin, button.TextAlignment, "Should be equals to the set value of TextAlignment");
            button.TextAlignment = HorizontalAlignment.Center;
            Assert.AreEqual(HorizontalAlignment.Center, button.TextAlignment, "Should be equals to the set value of TextAlignment");
            button.TextAlignment = HorizontalAlignment.End;
            Assert.AreEqual(HorizontalAlignment.End, button.TextAlignment, "Should be equals to the set value of TextAlignment");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test IconURL. Check whether IconURL is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.IconURL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void IconURL_SET_GET_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");
            button.IconURL = _image_path;
            Assert.AreEqual(_image_path, button.IconURL, "Should be equals to the set value of IconURL");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test TextSelector. Check whether TextSelector is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.TextSelector A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void TextSelector_SET_GET_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");
            var stringSelector = new StringSelector
            {
                Normal = "Normal",
                Selected = "Selected",
            };
            Assert.IsNotNull(stringSelector, "Should be not null");
            Assert.IsInstanceOf<StringSelector>(stringSelector, "Should be equal!");

            button.TextSelector = stringSelector;
            Assert.AreEqual(stringSelector.Normal, button.TextSelector.Normal, "Should be equals to the set value of TextSelector");
            Assert.AreEqual(stringSelector.Selected, button.TextSelector.Selected, "Should be equals to the set value of TextSelector");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P2")]
        [Description("Check exception when TextSelector receive a null value.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.TextSelector A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PEX")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void TextSelector_SET_GET_VALUE_Exception()
        {
            /* TEST CODE */
            try
            {
                var button = new Components.Button();
                Assert.IsNotNull(button, "Should be not null");
                Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");

                button.TextSelector = null;
                Assert.Fail("Should throw the NullReferenceException!");
            }
            catch (NullReferenceException e)
            {
                Assert.Pass("NullReferenceException: passed!");
            }
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test TranslatableTextSelector. Check whether TranslatableTextSelector is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.TranslatableTextSelector A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void TranslatableTextSelector_SET_GET_VALUE()
        {
            /* TEST CODE */
            ResourceManager testRm = new ResourceManager("Tizen.NUI.Devel.Tests.Properties.Resources", typeof(ButtonTests).Assembly);
            NUIApplication.MultilingualResourceManager = testRm;

            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");
            var stringSelector = new StringSelector
            {
                Normal = "Normal",
                Selected = "Selected",
            };
            Assert.IsNotNull(stringSelector, "Should be not null");
            Assert.IsInstanceOf<StringSelector>(stringSelector, "Should be equal!");

            button.TranslatableTextSelector = stringSelector;
            Assert.AreEqual(stringSelector.Normal, button.TranslatableTextSelector.Normal, "Should be equals to the set value of TranslatableTextSelector");
            Assert.AreEqual(stringSelector.Selected, button.TranslatableTextSelector.Selected, "Should be equals to the set value of TranslatableTextSelector");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P2")]
        [Description("Check exception when TranslatableTextSelector receive a null value.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.TranslatableTextSelector A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PEX")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void TranslatableTextSelector_SET_GET_VALUE_Exception()
        {
            /* TEST CODE */
            try
            {
                var button = new Components.Button();
                Assert.IsNotNull(button, "Should be not null");
                Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");

                button.TranslatableTextSelector = null;
                Assert.Fail("Should throw the NullReferenceException!");
            }
            catch (NullReferenceException e)
            {
                Assert.Pass("NullReferenceException: passed!");
            }
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test TextColorSelector. Check whether TextColorSelector is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.TextColorSelector A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void TextColorSelector_SET_GET_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");
            var colorSelector = new ColorSelector
            {
                Normal = new Color(0.0f, 0.0f, 1.0f, 1.0f),
                Selected = new Color(0.0f, 1.0f, 0.0f, 1.0f),
            };
            Assert.IsNotNull(colorSelector, "Should be not null");
            Assert.IsInstanceOf<ColorSelector>(colorSelector, "Should be equal!");

            button.TextColorSelector = colorSelector;
            Assert.AreEqual(colorSelector.Normal.R, button.TextColorSelector.Normal.R, "Should be equals to the set value of TextColorSelector Normal R");
            Assert.AreEqual(colorSelector.Normal.G, button.TextColorSelector.Normal.G, "Should be equals to the set value of TextColorSelector Normal G");
            Assert.AreEqual(colorSelector.Normal.B, button.TextColorSelector.Normal.B, "Should be equals to the set value of TextColorSelector Normal B");
            Assert.AreEqual(colorSelector.Normal.A, button.TextColorSelector.Normal.A, "Should be equals to the set value of TextColorSelector Normal A");

            Assert.AreEqual(colorSelector.Selected.R, button.TextColorSelector.Selected.R, "Should be equals to the set value of TextColorSelector Selected R");
            Assert.AreEqual(colorSelector.Selected.G, button.TextColorSelector.Selected.G, "Should be equals to the set value of TextColorSelector Selected G");
            Assert.AreEqual(colorSelector.Selected.B, button.TextColorSelector.Selected.B, "Should be equals to the set value of TextColorSelector Selected B");
            Assert.AreEqual(colorSelector.Selected.A, button.TextColorSelector.Selected.A, "Should be equals to the set value of TextColorSelector Selected A");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P2")]
        [Description("Check exception when TextColorSelector receive a null value.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.TextColorSelector A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PEX")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void TextColorSelector_SET_GET_VALUE_Exception()
        {
            /* TEST CODE */
            try
            {
                var button = new Components.Button();
                Assert.IsNotNull(button, "Should be not null");
                Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");

                button.TextColorSelector = null;
                Assert.Fail("Should throw the NullReferenceException!");
            }
            catch (NullReferenceException e)
            {
                Assert.Pass("NullReferenceException: passed!");
            }
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test PointSizeSelector. Check whether PointSizeSelector is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.PointSizeSelector A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void PointSizeSelector_SET_GET_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");
            var floatSelector = new FloatSelector
            {
                Normal = 10.0f,
                Selected = 12.0f,
            };
            Assert.IsNotNull(floatSelector, "Should be not null");
            Assert.IsInstanceOf<FloatSelector>(floatSelector, "Should be equal!");

            button.PointSizeSelector = floatSelector;
            Assert.AreEqual(floatSelector.Normal, button.PointSizeSelector.Normal, "Should be equals to the set value of PointSizeSelector Normal");
            Assert.AreEqual(floatSelector.Selected, button.PointSizeSelector.Selected, "Should be equals to the set value of PointSizeSelector Selected");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P2")]
        [Description("Check exception when PointSizeSelector receive a null value.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.PointSizeSelector A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PEX")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void PointSizeSelector_SET_GET_VALUE_Exception()
        {
            /* TEST CODE */
            try
            {
                var button = new Components.Button();
                Assert.IsNotNull(button, "Should be not null");
                Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");

                button.PointSizeSelector = null;
                Assert.Fail("Should throw the NullReferenceException!");
            }
            catch (NullReferenceException e)
            {
                Assert.Pass("NullReferenceException: passed!");
            }
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test IconURLSelector. Check whether IconURLSelector is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.IconURLSelector A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void IconURLSelector_SET_GET_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");
            var stringSelector = new StringSelector
            {
                Normal = _image_path,
                Selected = _image_path,
            };
            Assert.IsNotNull(stringSelector, "Should be not null");
            Assert.IsInstanceOf<StringSelector>(stringSelector, "Should be equal!");

            button.IconURLSelector = stringSelector;
            Assert.AreEqual(stringSelector.Normal, button.IconURLSelector.Normal, "Should be equals to the set value of IconURLSelector Normal");
            Assert.AreEqual(stringSelector.Selected, button.IconURLSelector.Selected, "Should be equals to the set value of IconURLSelector Selected");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P2")]
        [Description("Check exception when IconURLSelector receive a null value.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.IconURLSelector A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PEX")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void IconURLSelector_SET_GET_VALUE_Exception()
        {
            /* TEST CODE */
            try
            {
                var button = new Components.Button();
                Assert.IsNotNull(button, "Should be not null");
                Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");
                button.IconURLSelector = null;
                Assert.Fail("Should throw the NullReferenceException!");
            }
            catch (NullReferenceException e)
            {
                Assert.Pass("NullReferenceException: passed!");
            }
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test IsSelected. Check whether IsSelected is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.IsSelected A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void IsSelected_SET_GET_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");

            button.IsSelectable = true;
            button.IsSelected = true;
            Assert.AreEqual(true, button.IsSelected, "Retrieved IsSelected should be equal to set value");
            button.IsSelected = false;
            Assert.AreEqual(false, button.IsSelected, "Retrieved IsSelected should be equal to set value");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test IsEnabled. Check whether IsEnabled is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.IsEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void IsEnabled_SET_GET_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");

            button.IsEnabled = true;
            Assert.AreEqual(true, button.IsEnabled, "Retrieved IsEnabled should be equal to set value");
            button.IsEnabled = false;
            Assert.AreEqual(false, button.IsEnabled, "Retrieved IsEnabled should be equal to set value");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test IconPadding. Check whether IconPadding is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.IconPadding A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void IconPadding_SET_GET_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");

            button.IconPadding = new Extents(0, 0, 10, 10);
            Assert.AreEqual(0, button.IconPadding.Start, "Retrieved IconPadding.Start should be equal to set value");
            Assert.AreEqual(0, button.IconPadding.End, "Retrieved IconPadding.End should be equal to set value");
            Assert.AreEqual(10, button.IconPadding.Top, "Retrieved IconPadding.Top should be equal to set value");
            Assert.AreEqual(10, button.IconPadding.Bottom, "Retrieved IconPadding.Bottom should be equal to set value");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test TextPadding. Check whether TextPadding is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.TextPadding A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void TextPadding_SET_GET_VALUE()
        {
            /* TEST CODE */
            var button = new Components.Button();
            Assert.IsNotNull(button, "Should be not null");
            Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");

            button.TextPadding = new Extents(0, 0, 10, 10);
            Assert.AreEqual(0, button.TextPadding.Start, "Retrieved TextPadding.Start should be equal to set value");
            Assert.AreEqual(0, button.TextPadding.End, "Retrieved TextPadding.End should be equal to set value");
            Assert.AreEqual(10, button.TextPadding.Top, "Retrieved TextPadding.Top should be equal to set value");
            Assert.AreEqual(10, button.TextPadding.Bottom, "Retrieved TextPadding.Bottom should be equal to set value");
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test OnKey. Check return the right value or not")]
        [Property("SPEC", "Tizen.NUI.Components.Button.OnKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Ma Junqing, junqing.ma@samsung.com")]
        public void OnKey_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var button = new Components.Button();
                Assert.IsNotNull(button, "Should be not null");
                Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");

                bool flag = true;
                flag = button.OnKey(new Key());
                Assert.AreEqual(false, flag, "OnKey return check fail.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Button.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Button button = new Button();
                Assert.IsNotNull(button, "Should be not null");
                Assert.IsInstanceOf<Components.Button>(button, "Should be equal!");
                button.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test ApplyStyle. Check whether ApplyStyle works or not.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.ApplyStyle M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ApplyStyle_NO_RETURN_VALUE()
        {
            try
            {
                var button = new Button();
                var style = new ButtonStyle();
                button.ApplyStyle(style);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test CreateViewStyle. Check whether CreateViewStyle works or not.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.CreateViewStyle M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void CreateViewStyle_CHECK_RETURN_VALUE()
        {
            try
            {
                var button = new MyButton();
                ViewStyle style = button.CreateMyViewStyle();
                Assert.IsNotNull(style, "Should be not null");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test Button's icon part. Check whether null or not")]
        [Property("SPEC", "Tizen.NUI.Components.Button.Icon A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Zhou Lei, zhouleon.lei@samsung.com")]
        public void Icon_TEST()
        {
            /* TEST CODE */
            try
            {
                var button = new Button();
                Assert.IsNotNull(button, "Should be not null");
                Assert.IsInstanceOf<Components.Button>(button, "Should return Button instance");
                Assert.IsNotNull(button.Icon, "Should be not null");
                Assert.IsInstanceOf<ImageView>(button.Icon, "Should return ImageView instance");
                button.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test Button's overlay image part. Check whether null or not")]
        [Property("SPEC", "Tizen.NUI.Components.Button.OverlayImage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Zhou Lei, zhouleon.lei@samsung.com")]
        public void OverlayImage_TEST()
        {
            /* TEST CODE */
            try
            {
                var button = new Button();
                Assert.IsNotNull(button, "Should be not null");
                Assert.IsInstanceOf<Components.Button>(button, "Should return Button instance");
                Assert.IsNotNull(button.OverlayImage, "Should be not null");
                Assert.IsInstanceOf<ImageView>(button.OverlayImage, "Should return ImageView instance");
                button.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test Button's text part. Check whether null or not")]
        [Property("SPEC", "Tizen.NUI.Components.Button.TextLabel A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Zhou Lei, zhouleon.lei@samsung.com")]
        public void TextLabel_TEST()
        {
            /* TEST CODE */
            try
            {
                var button = new Button();
                Assert.IsNotNull(button, "Should be not null");
                Assert.IsInstanceOf<Components.Button>(button, "Should return Button instance");
                Assert.IsNotNull(button.TextLabel, "Should be not null");
                Assert.IsInstanceOf<TextLabel>(button.TextLabel, "Should return TextLabel instance");
                button.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Test Icon relative orientation in Button. Check whether IconRelativeOrientation is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.IconRelativeOrientation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Zhou Lei, zhouleon.lei@samsung.com")]
        public void IconRelativeOrientation_TEST()
        {
            /* TEST CODE */
            try
            {
                var button = new Button();
                Assert.IsNotNull(button, "Should be not null");
                Assert.IsInstanceOf<Components.Button>(button, "Should return Button instance");
                button.IconRelativeOrientation = Button.IconOrientation.Top;
                Assert.AreEqual(Button.IconOrientation.Top, button.IconRelativeOrientation, "Should be equals to the set value of IconRelativeOrientation");
                button.IconRelativeOrientation = Button.IconOrientation.Bottom;
                Assert.AreEqual(Button.IconOrientation.Bottom, button.IconRelativeOrientation, "Should be equals to the set value of IconRelativeOrientation");
                button.IconRelativeOrientation = Button.IconOrientation.Left;
                Assert.AreEqual(Button.IconOrientation.Left, button.IconRelativeOrientation, "Should be equals to the set value of IconRelativeOrientation");
                button.IconRelativeOrientation = Button.IconOrientation.Right;
                Assert.AreEqual(Button.IconOrientation.Right, button.IconRelativeOrientation, "Should be equals to the set value of IconRelativeOrientation");
                button.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        public class MyButton : Button
        {
            public MyButton() : base() { }

            public ViewStyle CreateMyViewStyle()
            {
                return base.CreateViewStyle();
            }
        }

        public class DefaultButtonStyle : StyleBase
        {
            protected override ViewStyle GetViewStyle()
            {
                return new ButtonStyle();
            }
        }
    }
}

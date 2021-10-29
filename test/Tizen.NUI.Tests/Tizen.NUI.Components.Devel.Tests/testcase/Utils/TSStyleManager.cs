using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using static Tizen.NUI.Components.StyleManager;
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Utils/StyleManager")]
    class TSStyleManager
    {
        private const string tag = "NUITEST";

        internal class FoodRadioButtonStyle : StyleBase
        {
            public ViewStyle MyGetViewStyle()
            {
                base.GetViewStyle();
                ButtonStyle style = new ButtonStyle
                {
                    Icon = new ImageViewStyle
                    {
                        Size = new Size(48, 48),
                        Position = new Position(0, 0),
                        ResourceUrl = new StringSelector
                        {
                            Normal = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png",
                            Selected = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "arrow.png",
                            Disabled = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "button_9patch.png",
                            DisabledSelected = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png",
                        },
                        Opacity = new FloatSelector
                        {
                            Normal = 1.0f,
                            Selected = 1.0f,
                            Disabled = 0.4f,
                            DisabledSelected = 0.4f
                        },
                    },
                };

                return style;
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
        [Description("StyleManager Theme.")]
        [Property("SPEC", "Tizen.NUI.Components.StyleManager.Theme A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void StyleManagerTheme()
        {
            tlog.Debug(tag, $"StyleManagerTheme START");

            var testingTarget = StyleManager.Instance;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StyleManager>(testingTarget, "Should return StyleManager instance.");

            tlog.Debug(tag, "Theme : " + testingTarget.Theme);

            Theme theme = new Theme()
            {
                Id = "theme",
                Version = "1.0",
            };
            testingTarget.Theme = theme.Id;

            tlog.Debug(tag, $"StyleManagerTheme END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StyleManager GetViewStyle.")]
        [Property("SPEC", "Tizen.NUI.Components.StyleManager.GetViewStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void StyleManagerGetViewStyle()
        {
            tlog.Debug(tag, $"StyleManagerGetViewStyle START");

            var testingTarget = StyleManager.Instance;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StyleManager>(testingTarget, "Should return StyleManager instance.");

            StyleManager.Instance.RegisterStyle("RadioButton", "Food", typeof(FoodRadioButtonStyle), true);

            var result = testingTarget.GetViewStyle("RadioButton");
            tlog.Debug(tag, "GetViewStyle : " + result);

            tlog.Debug(tag, $"StyleManagerGetViewStyle END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("StyleManager GetViewStyle.")]
        [Property("SPEC", "Tizen.NUI.Components.StyleManager.GetViewStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void StyleManagerGetViewStyleGetNullStyle()
        {
            tlog.Debug(tag, $"StyleManagerGetViewStyleGetNullStyle START");

            var testingTarget = StyleManager.Instance;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StyleManager>(testingTarget, "Should return StyleManager instance.");

            string style = null;
            var result = testingTarget.GetViewStyle(style);
            tlog.Debug(tag, "GetViewStyle : " + result);

            tlog.Debug(tag, $"StyleManagerGetViewStyleGetNullStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StyleManager RegisterComponentStyle.")]
        [Property("SPEC", "Tizen.NUI.Components.StyleManager.RegisterComponentStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void StyleManagerRegisterComponentStyle()
        {
            tlog.Debug(tag, $"StyleManagerRegisterComponentStyle START");

            var testingTarget = StyleManager.Instance;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StyleManager>(testingTarget, "Should return StyleManager instance.");

            StyleManager.Instance.RegisterComponentStyle("RadioButton", typeof(RadioButton), typeof(FoodRadioButtonStyle));

            var result = testingTarget.GetComponentStyle(typeof(RadioButton));
            tlog.Debug(tag, "GetComponentStyle : " + result);

            tlog.Debug(tag, $"StyleManagerRegisterComponentStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ThemeChangeEventArgs CurrentTheme.")]
        [Property("SPEC", "Tizen.NUI.Components.ThemeChangeEventArgs.CurrentTheme M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ThemeChangeEventArgsCurrentTheme()
        {
            tlog.Debug(tag, $"ThemeChangeEventArgsCurrentTheme START");

            var testingTarget = new ThemeChangeEventArgs();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ThemeChangeEventArgs>(testingTarget, "Should return ThemeChangeEventArgs instance.");

            testingTarget.CurrentTheme = "themeTest";
            tlog.Debug(tag, "CurrentTheme : " + testingTarget.CurrentTheme);

            tlog.Debug(tag, $"ThemeChangeEventArgsCurrentTheme END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("StyleManager RegisterStyle.")]
        [Property("SPEC", "Tizen.NUI.Components.StyleManager.RegisterStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void StyleManagerRegisterStyle()
        {
            tlog.Debug(tag, $"StyleManagerRegisterComponentStyle START");

            var testingTarget = StyleManager.Instance;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StyleManager>(testingTarget, "Should return StyleManager instance.");

            try
            {
                string style = null;
                StyleManager.Instance.RegisterStyle(style, "Food", typeof(FoodRadioButtonStyle));
            }
            catch (InvalidOperationException)
            {
                tlog.Debug(tag, $"StyleManagerRegisterComponentStyle END (OK)");
                Assert.Pass("Caught InvalidOperationException :  Passed!");
            } 
        }
    }
}

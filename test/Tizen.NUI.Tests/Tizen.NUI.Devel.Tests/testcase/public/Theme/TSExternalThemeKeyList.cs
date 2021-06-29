using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Theme/ExternalThemeKeyList")]
    internal class PublicExternalThemeKeyListTest
    {
        private const string tag = "NUITEST";
        private readonly object viewStyle;

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
        [Description("Create a ExternalThemeKeyList object.")]
        [Property("SPEC", "Tizen.NUI.ExternalThemeKeyList.ExternalThemeKeyList C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        public void ExternalThemeKeyListConstructor()
        {
            tlog.Debug(tag, $"ExternalThemeKeyListConstructor START");

            Type componentType = typeof(string);
            Type styleType = typeof(string);
            ExternalThemeKeyList a1 = new ExternalThemeKeyList(componentType, styleType);

            tlog.Debug(tag, $"ExternalThemeKeyListConstructor END (OK)");
            Assert.Pass("ExternalThemeKeyListConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("ExternalThemeKeyList add")]
        [Property("SPEC", "Tizen.NUI.ExternalThemeKeyList.add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ExternalThemeKeyListadd()
        {
            tlog.Debug(tag, $"ExternalThemeKeyListadd START");

            ExternalThemeKeyList keyList = new ExternalThemeKeyList(typeof(Button), typeof(ButtonStyle));

            keyList.Add<Size>("/Size", (ViewStyle style, Size value) => style.Size = value);
            tlog.Debug(tag, $"ExternalThemeKeyListadd END (OK)");
            Assert.Pass("ExternalThemeKeyListadd");
        }

        [Test]
        [Category("P1")]
        [Description("ExternalThemeKeyList AddSelector")]
        [Property("SPEC", "Tizen.NUI.ExternalThemeKeyList.AddSelector M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ExternalThemeKeyListAddSelector()
        {
            tlog.Debug(tag, $"ExternalThemeKeyListAddSelector START");

            ExternalThemeKeyList keyList = new ExternalThemeKeyList(typeof(Button), typeof(ButtonStyle));

            keyList.AddSelector<Color>("/Pickers/ItemTextLabel/TextColor", (ViewStyle style, Selector<Color> value) => ((TimePickerStyle)style).Pickers.ItemTextLabel.TextColor = value, ControlState.Selected);

            tlog.Debug(tag, $"ExternalThemeKeyListAddSelector END (OK)");
            Assert.Pass("ExternalThemeKeyListAddSelector");
        }

        [Test]
        [Category("P1")]
        [Description("ExternalThemeKeyList AddBackgroundSelector")]
        [Property("SPEC", "Tizen.NUI.ExternalThemeKeyList.AddBackgroundSelector M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ExternalThemeKeyListAddBackgroundSelector()
        {
            tlog.Debug(tag, $"ExternalThemeKeyListAddBackgroundSelector START");

            ExternalThemeKeyList keyList = new ExternalThemeKeyList(typeof(Button), typeof(ButtonStyle));

            keyList.AddBackgroundSelector("/Background", mySetBackgroundColor, mySetBackgroundImage);

            tlog.Debug(tag, $"ExternalThemeKeyListAddBackgroundSelector END (OK)");
            Assert.Pass("ExternalThemeKeyListAddBackgroundSelector");
        }

        private static void mySetBackgroundColor(ViewStyle style, Selector<Color> value)
        {
            style.BackgroundColor = value;
        }

        private static void mySetBackgroundImage(ViewStyle style, Selector<string> value)
        {
            style.BackgroundImage = value;
        }

        //[Test]
        //[Category("P1")]
        //[Description("ExternalThemeKeyList ApplyKeyActions")]
        //[Property("SPEC", "Tizen.NUI.ExternalThemeKeyList.ApplyKeyActions M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void ExternalThemeKeyListApplyKeyActions()
        //{
        //    tlog.Debug(tag, $"ExternalThemeKeyListApplyKeyActions START");

        //    ExternalThemeKeyList keyList = new ExternalThemeKeyList(typeof(Button), typeof(ButtonStyle));

        //    Tizen.Applications.ThemeManager.Theme theme();
        //    TizenExternalTheme externalTheme = new TizenExternalTheme();
        //    Theme theme = new Theme();
        //    keyList.ApplyKeyActions(externalTheme, theme);

        //    tlog.Debug(tag, $"ExternalThemeKeyListApplyKeyActions END (OK)");
        //    Assert.Pass("ExternalThemeKeyListApplyKeyActions");
        //}
    }
}


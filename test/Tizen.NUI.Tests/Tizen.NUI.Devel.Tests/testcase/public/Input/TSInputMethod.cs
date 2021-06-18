using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Input/InputMethod")]
    internal class PublicInputMethodTest
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
        [Description("Create a InputMethod object.")]
        [Property("SPEC", "Tizen.NUI.InputMethod.InputMethod C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodConstructor()
        {
            tlog.Debug(tag, $"InputMethodConstructor START");
            InputMethod a1 = new InputMethod();

            tlog.Debug(tag, $"InputMethodConstructor END (OK)");
            Assert.Pass("InputMethodConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethod PanelLayout")]
        [Property("SPEC", "Tizen.NUI.InputMethod.PanelLayout A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodPanelLayout()
        {
            tlog.Debug(tag, $"InputMethodPanelLayout START");
            InputMethod a1 = new InputMethod
            {
                PanelLayout = InputMethod.PanelLayoutType.Email
            };

            InputMethod.PanelLayoutType p1 = a1.PanelLayout;

            tlog.Debug(tag, $"InputMethodPanelLayout END (OK)");
            Assert.Pass("InputMethodPanelLayout");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethod ActionButton")]
        [Property("SPEC", "Tizen.NUI.InputMethod.ActionButton A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodActionButton()
        {
            tlog.Debug(tag, $"InputMethodActionButton START");
            InputMethod a1 = new InputMethod
            {
                ActionButton = InputMethod.ActionButtonTitleType.Done
            };

            InputMethod.ActionButtonTitleType p1 = a1.ActionButton;

            tlog.Debug(tag, $"InputMethodActionButton END (OK)");
            Assert.Pass("InputMethodActionButton");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethod AutoCapital")]
        [Property("SPEC", "Tizen.NUI.InputMethod.AutoCapital A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodAutoCapital()
        {
            tlog.Debug(tag, $"InputMethodAutoCapital START");
            InputMethod a1 = new InputMethod
            {
                AutoCapital = InputMethod.AutoCapitalType.Allcharacter
            };

            InputMethod.AutoCapitalType p1 = a1.AutoCapital;

            tlog.Debug(tag, $"InputMethodAutoCapital END (OK)");
            Assert.Pass("InputMethodAutoCapital");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethod Variation")]
        [Property("SPEC", "Tizen.NUI.InputMethod.Variation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodVariation()
        {
            tlog.Debug(tag, $"InputMethodVariation START");
            InputMethod a1 = new InputMethod
            {
                Variation = 1
            };

            int p1 = a1.Variation;

            tlog.Debug(tag, $"InputMethodVariation END (OK)");
            Assert.Pass("InputMethodVariation");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethod NormalVariation")]
        [Property("SPEC", "Tizen.NUI.InputMethod.NormalVariation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodNormalVariation()
        {
            tlog.Debug(tag, $"InputMethodNormalVariation START");
            InputMethod a1 = new InputMethod
            {
                NormalVariation = InputMethod.NormalLayoutType.Normal
            };

            InputMethod.NormalLayoutType p1 = a1.NormalVariation;

            tlog.Debug(tag, $"InputMethodNormalVariation END (OK)");
            Assert.Pass("InputMethodNormalVariation");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethod NumberOnlyVariation")]
        [Property("SPEC", "Tizen.NUI.InputMethod.NumberOnlyVariation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodNumberOnlyVariation()
        {
            tlog.Debug(tag, $"InputMethodNumberOnlyVariation START");
            InputMethod a1 = new InputMethod
            {
                NumberOnlyVariation = InputMethod.NumberOnlyLayoutType.Normal
            };

            InputMethod.NumberOnlyLayoutType p1 = a1.NumberOnlyVariation;

            tlog.Debug(tag, $"InputMethodNumberOnlyVariation END (OK)");
            Assert.Pass("InputMethodNumberOnlyVariation");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethod PasswordVariation")]
        [Property("SPEC", "Tizen.NUI.InputMethod.PasswordVariation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodPasswordVariation()
        {
            tlog.Debug(tag, $"InputMethodPasswordVariation START");
            InputMethod a1 = new InputMethod
            {
                PasswordVariation = InputMethod.PasswordLayoutType.Normal
            };

            InputMethod.PasswordLayoutType p1 = a1.PasswordVariation;

            tlog.Debug(tag, $"InputMethodPasswordVariation END (OK)");
            Assert.Pass("InputMethodPasswordVariation");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethod OutputMap")]
        [Property("SPEC", "Tizen.NUI.InputMethod.OutputMap A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodOutputMap()
        {
            tlog.Debug(tag, $"InputMethodOutputMap START");

            InputMethod a1 = new InputMethod
            {
                PanelLayout = InputMethod.PanelLayoutType.Normal,
                ActionButton = InputMethod.ActionButtonTitleType.Done,
                AutoCapital = InputMethod.AutoCapitalType.Allcharacter,
                Variation = 1
            };

            PropertyMap p1 = a1.OutputMap;

            tlog.Debug(tag, $"InputMethodOutputMap END (OK)");
            Assert.Pass("InputMethodOutputMap");
        }
    }

}
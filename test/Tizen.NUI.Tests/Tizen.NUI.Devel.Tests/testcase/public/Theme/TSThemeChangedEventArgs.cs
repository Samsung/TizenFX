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
    [Description("public/Theme/ThemeChangedEventArgs")]
    internal class PublicThemeChangedEventArgsTest
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
        [Description("Create a ThemeChangedEventArgs ThemeChangedEventArgs object.")]
        [Property("SPEC", "Tizen.NUI.ThemeChangedEventArgs.ThemeChangedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        public void ThemeChangedEventArgsConstructor()
        {
            tlog.Debug(tag, $"ThemeChangedEventArgsConstructor START");

            Theme theme = new Theme()
            {
                Id = "1"
            };

            try
            {
                var testingTarget = new ThemeChangedEventArgs(theme.Id, ThemeManager.PlatformThemeId, false);
                Assert.IsNotNull(testingTarget, "Can't create success object ThemeChangedEventArgs.");
                Assert.IsInstanceOf<ThemeChangedEventArgs>(testingTarget, "Should return ThemeChangedEventArgs instance.");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ThemeChangedEventArgsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Test ThemeChangedEventArgs ThemeId.")]
        [Property("SPEC", "Tizen.NUI.ThemeChangedEventArgs.ThemeId  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        public void ThemeChangedEventArgsThemeId()
        {
            tlog.Debug(tag, $"ThemeChangedEventArgsThemeId START");

            Theme theme = new Theme()
            {
                Id = "1"
            };
            var testingTarget = new ThemeChangedEventArgs(theme.Id, ThemeManager.PlatformThemeId, false);
            Assert.IsNotNull(testingTarget, "Can't create success object ThemeChangedEventArgs.");
            Assert.IsInstanceOf<ThemeChangedEventArgs>(testingTarget, "Should return ThemeChangedEventArgs instance.");

            try
            {
                var result = testingTarget.ThemeId;
                tlog.Debug(tag, "themeId :" + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ThemeChangedEventArgsThemeId END (OK)");
        }
    }
}


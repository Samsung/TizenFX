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
    [Description("public/Theme/ThemeManager")]
    internal class PublicThemeManagerTest
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
        [Description("Test ThemeManager CurrentTheme.")]
        [Property("SPEC", "Tizen.NUI.ThemeManager.CurrentTheme  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        public void ThemeManagerCurrentTheme()
        {
            tlog.Debug(tag, $"ThemeManagerCurrentTheme START");

            Theme a1 = ThemeManager.CurrentTheme;
            ThemeManager.CurrentTheme = a1;

            tlog.Debug(tag, $"ThemeManagerCurrentTheme END (OK)");
            Assert.Pass("ThemeManagerCurrentTheme");
        }

        [Test]
        [Category("P1")]
        [Description("Test ThemeManager ApplyTheme.")]
        [Property("SPEC", "Tizen.NUI.ThemeManager.ApplyTheme  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeManagerApplyTheme()
        {
            tlog.Debug(tag, $"ThemeManagerApplyTheme START");

            Theme a1 = new Theme();
            ThemeManager.ApplyTheme(a1);

            a1.Id = null;
            ThemeManager.ApplyTheme(a1);

            tlog.Debug(tag, $"ThemeManagerApplyTheme END (OK)");
            Assert.Pass("ThemeManagerApplyTheme");
        }

        [Test]
        [Category("P1")]
        [Description("Test ThemeManager GetStyle.")]
        [Property("SPEC", "Tizen.NUI.ThemeManager.GetStyle  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeManagerGetStyle()
        {
            tlog.Debug(tag, $"ThemeManagerGetStyle START");


            ThemeManager.GetStyle("styleName");

            Type viewType = typeof(string);
            ThemeManager.GetStyle(viewType);

            tlog.Debug(tag, $"ThemeManagerGetStyle END (OK)");
            Assert.Pass("ThemeManagerGetStyle");
        }

        [Test]
        [Category("P1")]
        [Description("Test ThemeManager ApplyFallbackTheme.")]
        [Property("SPEC", "Tizen.NUI.ThemeManager.ApplyFallbackTheme  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeManagerApplyFallbackTheme()
        {
            tlog.Debug(tag, $"ThemeManagerApplyFallbackTheme START");

            Theme a1 = new Theme();
            ThemeManager.ApplyFallbackTheme(a1);

            tlog.Debug(tag, $"ThemeManagerApplyFallbackTheme END (OK)");
            Assert.Pass("ThemeManagerApplyFallbackTheme");
        }
    }
}


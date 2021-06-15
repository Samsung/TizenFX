using NUnit.Framework;
using System;
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
        [Description("Test ThemeManager DefaultTheme.")]
        [Property("SPEC", "Tizen.NUI.ThemeManager.DefaultTheme  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        public void ThemeManagerDefaultTheme()
        {
            tlog.Debug(tag, $"ThemeManagerDefaultTheme START");

            Theme a1 = ThemeManager.DefaultTheme;
            ThemeManager.DefaultTheme = a1;

            tlog.Debug(tag, $"ThemeManagerDefaultTheme END (OK)");
            Assert.Pass("ThemeManagerDefaultTheme");
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
        [Description("Test ThemeManager ApplyBaseTheme.")]
        [Property("SPEC", "Tizen.NUI.ThemeManager.ApplyBaseTheme  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeManagerApplyBaseTheme()
        {
            tlog.Debug(tag, $"ThemeManagerApplyBaseTheme START");


            ThemeManager.ApplyBaseTheme("mythemeid");

            tlog.Debug(tag, $"ThemeManagerApplyBaseTheme END (OK)");
            Assert.Pass("ThemeManagerApplyBaseTheme");
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
        [Description("Test ThemeManager GetBuiltinTheme.")]
        [Property("SPEC", "Tizen.NUI.ThemeManager.GetBuiltinTheme  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeManagerGetBuiltinTheme()
        {
            tlog.Debug(tag, $"ThemeManagerGetBuiltinTheme START");


            ThemeManager.GetBuiltinTheme("myThemeID");

            tlog.Debug(tag, $"ThemeManagerGetBuiltinTheme END (OK)");
            Assert.Pass("ThemeManagerGetBuiltinTheme");
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

        [Test]
        [Category("P1")]
        [Description("Test ThemeManager ApplyExternalTheme.")]
        [Property("SPEC", "Tizen.NUI.ThemeManager.ApplyExternalTheme  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeManagerApplyExternalTheme()
        {
            tlog.Debug(tag, $"ThemeManagerApplyExternalTheme START");

            Dictionary<string, string> b1 = new Dictionary<string, string>
            {
                { "test1", "test2" }
            };


            DictionaryExternalTheme c1 = new DictionaryExternalTheme("myid", "myVersion", b1);

            ThemeManager.ApplyExternalTheme(c1);

            tlog.Debug(tag, $"ThemeManagerApplyExternalTheme END (OK)");
            Assert.Pass("ThemeManagerApplyExternalTheme");
        }

    }
}


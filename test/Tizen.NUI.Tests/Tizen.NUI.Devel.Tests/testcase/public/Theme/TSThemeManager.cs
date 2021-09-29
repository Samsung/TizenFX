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
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Test_Theme.xaml";

        internal class IThemeCreatorImpy : IThemeCreator
        {
            public Theme Create()
            {
                var path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Test_Theme.xaml";
                return new Theme(path);
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
        [Description("ThemeManager CurrentTheme.")]
        [Property("SPEC", "Tizen.NUI.ThemeManager.CurrentTheme  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        public void ThemeManagerCurrentTheme()
        {
            tlog.Debug(tag, $"ThemeManagerCurrentTheme START");

            Theme theme = new Theme(path);
            ThemeManager.CurrentTheme = theme;
            tlog.Debug(tag, "CurrentTheme : " + ThemeManager.CurrentTheme);

            tlog.Debug(tag, "ThemeId : " + ThemeManager.ThemeId);
            tlog.Debug(tag, "BaseTheme : " + ThemeManager.BaseTheme);

            tlog.Debug(tag, $"ThemeManagerCurrentTheme END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ThemeManager PlatformThemeEnabled.")]
        [Property("SPEC", "Tizen.NUI.ThemeManager.PlatformThemeEnabled  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        public void ThemeManagerplatformThemeEnabled()
        {
            tlog.Debug(tag, $"ThemeManagerplatformThemeEnabled START");

            ThemeManager.PlatformThemeEnabled = true;
            tlog.Error(tag, "PlatformThemeEnabled : " + ThemeManager.PlatformThemeEnabled);

            var result = ThemeManager.ApplyPlatformTheme("Tizen.NUI.Theme.Common");
            tlog.Error(tag, "ApplyPlatformTheme : " + result);
            tlog.Error(tag, "GetPlatformStyle : " + ThemeManager.GetPlatformStyle("style"));
            tlog.Error(tag, "GetPlatformStyle : " + ThemeManager.GetPlatformStyle(typeof(ViewStyle)));

            tlog.Debug(tag, $"ThemeManagerplatformThemeEnabled END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("Test ThemeManager ApplyTheme.")]
        //[Property("SPEC", "Tizen.NUI.ThemeManager.ApplyTheme  M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //public void ThemeManagerApplyTheme()
        //{
        //    tlog.Debug(tag, $"ThemeManagerApplyTheme START");

        //    var testingTarget = new Theme(path);
        //    Assert.IsNotNull(testingTarget, "should be not null");
        //    Assert.IsInstanceOf<Theme>(testingTarget, "should be an instance of testing target class!");

        //    try
        //    {
        //        ThemeManager.ApplyTheme(testingTarget);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    tlog.Debug(tag, $"ThemeManagerApplyTheme END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("Test ThemeManager ApplyTheme.")]
        //[Property("SPEC", "Tizen.NUI.ThemeManager.ApplyTheme  M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //public void ThemeManagerApplyThemeNullThemeId()
        //{
        //    tlog.Debug(tag, $"ThemeManagerApplyThemeNullThemeId START");

        //    var testingTarget = new Theme();
        //    Assert.IsNotNull(testingTarget, "should be not null");
        //    Assert.IsInstanceOf<Theme>(testingTarget, "should be an instance of testing target class!");

        //    try
        //    {
        //        ThemeManager.ApplyTheme(testingTarget);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    tlog.Debug(tag, $"ThemeManagerApplyThemeNullThemeId END (OK)");
        //}

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

            var testingTarget = new Theme(path);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Theme>(testingTarget, "should be an instance of testing target class!");

            ViewStyle style = new ViewStyle()
            {
                Color = Color.Cyan,
            };
            testingTarget.AddStyle("style", style);
            ThemeManager.CurrentTheme = testingTarget;

            tlog.Debug(tag, "GetStyle : " + ThemeManager.GetStyle("style"));
            tlog.Debug(tag, "GetStyle : " + ThemeManager.GetStyle(typeof(View)));
            tlog.Debug(tag, "GetUpdateStyleWithoutClone : " + ThemeManager.GetUpdateStyleWithoutClone("style"));
            tlog.Debug(tag, "GetUpdateStyleWithoutClone : " + ThemeManager.GetUpdateStyleWithoutClone(typeof(ViewStyle)));

            tlog.Debug(tag, $"ThemeManagerGetStyle END (OK)");
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

            var testingTarget = new Theme(path);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Theme>(testingTarget, "should be an instance of testing target class!");

            try
            {
                ThemeManager.ApplyFallbackTheme(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ThemeManagerApplyFallbackTheme END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Test ThemeManager AddPackageTheme.")]
        [Property("SPEC", "Tizen.NUI.ThemeManager.AddPackageTheme  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeManagerAddPackageTheme()
        {
            tlog.Debug(tag, $"ThemeManagerAddPackageTheme START");

            try
            {
                ThemeManager.AddPackageTheme(new IThemeCreatorImpy());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ThemeManagerAddPackageTheme END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ThemeManager ApplyExternalPlatformTheme.")]
        [Property("SPEC", "Tizen.NUI.ThemeManager.ApplyExternalPlatformTheme  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeManagerApplyExternalPlatformTheme()
        {
            tlog.Debug(tag, $"ThemeManagerApplyExternalPlatformTheme START");

            var theme = new Theme(path);
            ViewStyle style = new ViewStyle()
            {
                Color = Color.Cyan,
            };

            theme.AddStyle("style", style);

            try
            {
                ThemeManager.ApplyExternalPlatformTheme(theme.Id, theme.Version);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ThemeManagerApplyExternalPlatformTheme END (OK)");
        }
    }
}


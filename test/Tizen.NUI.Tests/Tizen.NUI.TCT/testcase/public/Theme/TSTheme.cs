using NUnit.Framework;
using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Theme/Theme")]
    internal class PublicThemeTest
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
        [Description("Create a Theme object.")]
        [Property("SPEC", "Tizen.NUI.Theme.Theme C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        public void ThemeConstructor()
        {
            tlog.Debug(tag, $"ThemeConstructor START");

            Theme a1 = new Theme("");
            Theme b1 = new Theme("/root/noexist.xml");
            Theme C1 = new Theme("/etc/info.ini");

            tlog.Debug(tag, $"ThemeConstructor END (OK)");
            Assert.Pass("ThemeConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("test Theme BasedOn.")]
        [Property("SPEC", "Tizen.NUI.Theme.BasedOn A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        public void ThemeBasedOn()
        {
            tlog.Debug(tag, $"ThemeBasedOn START");
            Theme a1 = new Theme();

            string b1 = a1.BasedOn;
            a1.BasedOn = b1;

            tlog.Debug(tag, $"ThemeBasedOn END (OK)");
            Assert.Pass("ThemeBasedOn");
        }

        [Test]
        [Category("P1")]
        [Description("test Theme IsResourcesCreated .")]
        [Property("SPEC", "Tizen.NUI.Theme.IsResourcesCreated  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        public void ThemeIsResourcesCreated()
        {
            tlog.Debug(tag, $"ThemeIsResourcesCreated START");
            Theme a1 = new Theme();

            bool b1 = a1.IsResourcesCreated;

            tlog.Debug(tag, $"ThemeIsResourcesCreated END (OK)");
            Assert.Pass("ThemeIsResourcesCreated");
        }

        [Test]
        [Category("P1")]
        [Description("test Theme Resources .")]
        [Property("SPEC", "Tizen.NUI.Theme.Resources  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        public void ThemeResources()
        {
            tlog.Debug(tag, $"ThemeResources START");
            Theme a1 = new Theme();

            ResourceDictionary b1 = a1.Resources;

            tlog.Debug(tag, $"ThemeResources END (OK)");
            Assert.Pass("ThemeResources");
        }

        //[Test]
        //[Category("P1")]
        //[Description("test Theme this .")]
        //[Property("SPEC", "Tizen.NUI.Theme.this A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("COVPARAM", "")]
        //public void Themethis()
        //{
        //    tlog.Debug(tag, $"Themethis START");
        //    Theme a1 = new Theme();

        //    ViewStyle b1 = a1.styleName;

        //    tlog.Debug(tag, $"Themethis END (OK)");
        //    Assert.Pass("Themethis");
        //}

        [Test]
        [Category("P1")]
        [Description("test Theme Clear .")]
        [Property("SPEC", "Tizen.NUI.Theme.Clear  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeClear()
        {
            tlog.Debug(tag, $"ThemeClear START");
            Theme a1 = new Theme();

            a1.Clear();

            tlog.Debug(tag, $"ThemeClear END (OK)");
            Assert.Pass("ThemeClear");
        }

        [Test]
        [Category("P1")]
        [Description("test Theme HasStyle .")]
        [Property("SPEC", "Tizen.NUI.Theme.HasStyle  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeHasStyle()
        {
            tlog.Debug(tag, $"ThemeHasStyle START");
            Theme a1 = new Theme();

            a1.HasStyle("red");

            tlog.Debug(tag, $"ThemeHasStyle END (OK)");
            Assert.Pass("ThemeHasStyle");
        }

        [Test]
        [Category("P1")]
        [Description("test Theme RemoveStyle .")]
        [Property("SPEC", "Tizen.NUI.Theme.RemoveStyle  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeRemoveStyle()
        {
            tlog.Debug(tag, $"ThemeRemoveStyle START");
            Theme a1 = new Theme();

            a1.RemoveStyle("red");

            tlog.Debug(tag, $"ThemeRemoveStyle END (OK)");
            Assert.Pass("ThemeRemoveStyle");
        }

        [Test]
        [Category("P1")]
        [Description("test Theme AddStyle .")]
        [Property("SPEC", "Tizen.NUI.Theme.AddStyle  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeAddStyle()
        {
            tlog.Debug(tag, $"ThemeAddStyle START");
            Theme a1 = new Theme();

            ViewStyle v1 = new ViewStyle();
            a1.AddStyle("red", v1);

            a1.AddStyle(null, v1);

            tlog.Debug(tag, $"ThemeAddStyle END (OK)");
            Assert.Pass("ThemeAddStyle");
        }

        [Test]
        [Category("P1")]
        [Description("test Theme Clone .")]
        [Property("SPEC", "Tizen.NUI.Theme.Clone  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeClone()
        {
            tlog.Debug(tag, $"ThemeClone START");
            Theme a1 = new Theme();

            a1.Clone();

            tlog.Debug(tag, $"ThemeAddStyle END (OK)");
            Assert.Pass("ThemeAddStyle");
        }

        [Test]
        [Category("P1")]
        [Description("test Theme Merge .")]
        [Property("SPEC", "Tizen.NUI.Theme.Merge  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeMerge()
        {
            tlog.Debug(tag, $"ThemeMerge START");
            Theme a1 = new Theme();

            a1.Merge("./opt/etc/skel/apps_rw/mobilebff/tizen-manifest.xml");
            Theme t1 = new Theme();
            a1.Merge(t1);

            Theme t2 = null;
            a1.Merge(t2);

            tlog.Debug(tag, $"ThemeMerge END (OK)");
            Assert.Pass("ThemeMerge");
        }

        [Test]
        [Category("P1")]
        [Description("test Theme MergeWithoutClone .")]
        [Property("SPEC", "Tizen.NUI.Theme.MergeWithoutClone  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeMergeWithoutClone()
        {
            tlog.Debug(tag, $"ThemeMergeWithoutClone START");
            Theme a1 = new Theme();
            Theme b1 = new Theme();

            Theme t2 = null;
            a1.Merge(t2);

            string tmp = a1.Id;
            a1.Id = null;

            a1.Merge(b1);

            a1.Id = tmp;
            tmp = a1.Version;
            a1.Version = null;
            a1.Merge(b1);

            tlog.Debug(tag, $"ThemeMergeWithoutClone END (OK)");
            Assert.Pass("ThemeMergeWithoutClone");
        }

        [Test]
        [Category("P1")]
        [Description("test Theme ApplyExternalTheme .")]
        [Property("SPEC", "Tizen.NUI.Theme.ApplyExternalTheme  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeApplyExternalTheme()
        {
            tlog.Debug(tag, $"ThemeApplyExternalTheme START");
            Theme a1 = new Theme();
            Theme b1 = new Theme();

            Dictionary<string, string> theme = new Dictionary<string, string>
            {
                { "aaa", "111" },
                { "bbb", "222" }
            };

            DictionaryExternalTheme c1 = new DictionaryExternalTheme("myid", "myversion", theme);

            Type componentType = typeof(string);
            Type styleType = typeof(string);
            ExternalThemeKeyList e1 = new ExternalThemeKeyList(componentType, styleType);

            HashSet<ExternalThemeKeyList> keyListSet = new HashSet<ExternalThemeKeyList>
            {
                e1
            };

            a1.ApplyExternalTheme(c1, keyListSet);
            a1.ApplyExternalTheme(c1, null);

            tlog.Debug(tag, $"ThemeApplyExternalTheme END (OK)");
            Assert.Pass("ThemeApplyExternalTheme");
        }

        [Test]
        [Category("P1")]
        [Description("test Theme HasSameIdAndVersion .")]
        [Property("SPEC", "Tizen.NUI.Theme.HasSameIdAndVersion  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeHasSameIdAndVersion()
        {
            tlog.Debug(tag, $"ThemeHasSameIdAndVersion START");
            Theme a1 = new Theme();
            a1.HasSameIdAndVersion(null);

            tlog.Debug(tag, $"ThemeHasSameIdAndVersion END (OK)");
            Assert.Pass("ThemeHasSameIdAndVersion");
        }
        [Test]
        [Category("P1")]
        [Description("test Theme OnThemeResourcesChanged .")]
        [Property("SPEC", "Tizen.NUI.Theme.OnThemeResourcesChanged  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeOnThemeResourcesChanged()
        {
            tlog.Debug(tag, $"ThemeOnThemeResourcesChanged START");
            Theme a1 = new Theme();

            a1.OnThemeResourcesChanged();

            tlog.Debug(tag, $"ThemeOnThemeResourcesChanged END (OK)");
            Assert.Pass("ThemeOnThemeResourcesChanged");
        }
    }
}


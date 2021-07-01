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
        [Category("P2")]
        [Description("Theme construcotr. xaml file path is null.")]
        [Property("SPEC", "Tizen.NUI.Theme.Theme C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        public void ThemeConstructorWithUnavailablePath()
        {
            tlog.Debug(tag, $"ThemeConstructorWithUnavailablePath START");

            try
            {
                Theme a1 = new Theme("");
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ThemeConstructorWithUnavailablePath END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
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
        [Description("Theme Merge .")]
        [Property("SPEC", "Tizen.NUI.Theme.Merge  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeMerge()
        {
            tlog.Debug(tag, $"ThemeMerge START");

            ViewStyle style = new ViewStyle()
            {
                Size = new Size2D(100, 30),
                Focusable = true
            };
            Theme a1 = new Theme();
            a1.Version = "0.1";
            a1.AddStyle("myStyle", style);

            ViewStyle style1 = new ViewStyle() 
            {
                Margin = new Extents(4, 2, 3, 7)
            };
            Theme t1 = new Theme();
            t1.Id = "t1";
            t1.Version = "1.0";
            t1.AddStyle("myStyle", style1);

            try
            {
                a1.Merge(t1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ThemeMerge END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Theme Merge. Parameter is null.")]
        [Property("SPEC", "Tizen.NUI.Theme.Merge  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeMergeWithNullParameter()
        {
            tlog.Debug(tag, $"ThemeMergeWithNullParameter START");
            Theme a1 = new Theme();
            Theme b1 = new Theme();

            Theme t2 = null;
            try
            {
                a1.Merge(t2);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ThemeMergeWithNullParameter END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
            

            string tmp = a1.Id;
            a1.Id = null;

            a1.Merge(b1);

            a1.Id = tmp;
            tmp = a1.Version;
            a1.Version = null;
            a1.Merge(b1);
        }

        [Test]
        [Category("P2")]
        [Description("Theme Merge. Id is null.")]
        [Property("SPEC", "Tizen.NUI.Theme.Merge  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeMergeWithNullId()
        {
            tlog.Debug(tag, $"ThemeMergeWithNullId START");
            Theme a1 = new Theme();
            Theme b1 = new Theme();

            a1.Id = null;
            a1.Merge(b1);
            Assert.AreEqual(a1.Id, b1.Id, "Should be equal!");

            tlog.Debug(tag, $"ThemeMergeWithNullId END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Theme Merge. Version is null.")]
        [Property("SPEC", "Tizen.NUI.Theme.Merge  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeMergeWithNullVersion()
        {
            tlog.Debug(tag, $"ThemeMergeWithNullVersion START");
            Theme a1 = new Theme();
            Theme b1 = new Theme();

            a1.Version = null;
            a1.Merge(b1);
            Assert.AreEqual(a1.Version, b1.Version, "Should be equal!");

            tlog.Debug(tag, $"ThemeMergeWithNullVersion END (OK)");
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
            a1.HasSameIdAndVersion("themeid", "1.0");

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


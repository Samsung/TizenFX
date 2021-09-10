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
        private Theme theme = null;
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Test_Theme.xaml";
        private string image = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private string IOException_file = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "1.xaml";
        private string ParseException_file = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Test_View.xaml";
        private IEnumerable<KeyValuePair<string, string>> changedResources = new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("Version", "2.0") };

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            theme = new Theme(path);
        }

        [TearDown]
        public void Destroy()
        {
            theme = null;
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
                var testingTarget = new Theme("");
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ThemeConstructorWithUnavailablePath END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("Theme construcotr. Could not parse.")]
        [Property("SPEC", "Tizen.NUI.Theme.Theme C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        public void ThemeConstructorWithFileCouldNotBeParsed()
        {
            tlog.Debug(tag, $"ThemeConstructorWithFileCouldNotBeParsed START");

            try
            {
                var testingTarget = new Theme(image);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ThemeConstructorWithFileCouldNotBeParsed END (OK)");
                Assert.Pass("Caught Exception : Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("Theme construcotr. IOException.")]
        [Property("SPEC", "Tizen.NUI.Theme.Theme C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        public void ThemeConstructorIOException()
        {
            tlog.Debug(tag, $"ThemeConstructorIOException START");

            try
            {
                var testingTarget = new Theme(IOException_file);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ThemeConstructorIOException END (OK)");
                Assert.Pass("Caught IOException : Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("Theme construcotr. XamlParseException.")]
        [Property("SPEC", "Tizen.NUI.Theme.Theme C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        public void ThemeConstructorXamlParseException()
        {
            tlog.Debug(tag, $"ThemeConstructorXamlParseException START");

            try
            {
                var testingTarget = new Theme(ParseException_file);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ThemeConstructorXamlParseException END (OK)");
                Assert.Pass("Caught XamlParseException : Passed!");
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

            var baseOn = "Tizen.NUI.Theme.Common";
            theme.BasedOn = baseOn;
            tlog.Debug(tag, "BaseOn : " + theme.BasedOn);

            tlog.Debug(tag, $"ThemeBasedOn END (OK)");
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

            var result = theme.IsResourcesCreated;
            tlog.Debug(tag, "IsResourcesCreated : " + result);

            tlog.Debug(tag, $"ThemeIsResourcesCreated END (OK)");
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

            var result = theme.Resources;
            tlog.Debug(tag, "Resources : " + result);

            theme.SetChangedResources(changedResources);

            // resources == value
            theme.Resources = result;
            tlog.Debug(tag, "Resouces : " + theme.Resources);

            // resources != null
            ResourceDictionary dic = new ResourceDictionary();
            theme.Resources = dic;
            tlog.Debug(tag, "Resouces : " + theme.Resources);

            tlog.Debug(tag, $"ThemeResources END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("test Theme this .")]
        [Property("SPEC", "Tizen.NUI.Theme.this  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        public void ThemeThis()
        {
            tlog.Debug(tag, $"ThemeThis START");

            ViewStyle style = new ViewStyle()
            {
                Color = Color.Cyan,
            };

            theme.AddStyle("style", style);

            tlog.Debug(tag, "Count : " + theme.Count);
            tlog.Debug(tag, "theme[\"style\"] : " + theme["style"]);

            ViewStyle newStyle = new ViewStyle()
            {
                Size = new Size(100, 50),
                Color = Color.Red
            };

            theme["Style"] = newStyle;
            tlog.Debug(tag, "theme[\"style\"] : " + theme["style"]);

            tlog.Debug(tag, $"ThemeThis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("test Theme this .")]
        [Property("SPEC", "Tizen.NUI.Theme.this  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        public void ThemeThisSetVauleIsNUll()
        {
            tlog.Debug(tag, $"ThemeThisSetVauleIsNUll START");

            ViewStyle style = new ViewStyle()
            {
                Color = Color.Cyan,
            };

            theme.AddStyle("style", style);

            tlog.Debug(tag, "Count : " + theme.Count);
            tlog.Debug(tag, "theme[\"style\"] : " + theme["style"]);

            ViewStyle newStyle = null;

            theme["Style"] = newStyle;
            tlog.Debug(tag, "theme[\"style\"] : " + theme["style"]);

            tlog.Debug(tag, $"ThemeThisSetVauleIsNUll END (OK)");
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
            
            try
            {
                theme.Clear();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            
            tlog.Debug(tag, $"ThemeClear END (OK)");
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

            ViewStyle style = new ViewStyle()
            {
                Color = Color.Cyan,
            };

            try
            {
                theme.AddStyle("style", style);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, "HasStyle : " + theme.HasStyle("style"));
            tlog.Debug(tag, "RemoveStyle : " + theme.RemoveStyle("style"));

            tlog.Debug(tag, $"ThemeAddStyle END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("test Theme AddStyle .")]
        [Property("SPEC", "Tizen.NUI.Theme.AddStyle  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeAddStyleNullStyleName()
        {
            tlog.Debug(tag, $"ThemeAddStyleNullStyleName START");

            ViewStyle style = new ViewStyle()
            {
                Color = Color.Cyan,
            };

            try
            {
                theme.AddStyle(null, style);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ThemeAddStyleNullStyleName END (OK)");
                Assert.Pass("Caught Exception : Passed!");
            }
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

            try
            {
                theme.Clone();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ThemeClone END (OK)");
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

            var testingTarget = new Theme();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Theme>(testingTarget, "should be an instance of testing target class!");

            ViewStyle style = new ViewStyle()
            {
                Size = new Size2D(100, 30),
                Focusable = true
            };
            testingTarget.Version = "0.1";
            testingTarget.AddStyle("myStyle", style);

            try
            {
                theme.Merge(testingTarget); // merge with Theme
                theme.Merge(path);  // merge with xaml file
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

            try
            {
                Theme newtheme = null;
                theme.Merge(newtheme);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ThemeMergeWithNullParameter END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("Theme Merge.")]
        [Property("SPEC", "Tizen.NUI.Theme.Merge  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ThemeMergeIdAndVersionIsNull()
        {
            tlog.Debug(tag, $"ThemeMergeIdAndVersionIsNull START");
            
            var testingTarget = new Theme();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Theme>(testingTarget, "should be an instance of testing target class!");
            
            testingTarget.Merge(theme);
            Assert.AreEqual(testingTarget.Id, theme.Id, "Should be equal!");
            Assert.AreEqual(testingTarget.Version, theme.Version, "Should be equal!");

            testingTarget = null;
            tlog.Debug(tag, $"ThemeMergeIdAndVersionIsNull END (OK)");
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

            var result = theme.HasSameIdAndVersion("Tizen.NUI.Theme.Wearable", "1.0");
            tlog.Debug(tag, "HasSameIdAndVersion : " + result);

            tlog.Debug(tag, $"ThemeHasSameIdAndVersion END (OK)");
        }
    }
}


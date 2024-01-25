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
    [Description("public/BaseComponents/ViewSelectorData")]
    public class PublicViewSelectorDataTest
    {
        private const string tag = "NUITEST";
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

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
        [Description("ViewSelectorData ClearBackground.")]
        [Property("SPEC", "Tizen.NUI.ViewSelectorData.ClearBackground M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSelectorDataClearBackground()
        {
            tlog.Debug(tag, $"ViewSelectorDataClearBackground START");

            var testingTarget = new ViewSelectorData();
            Assert.IsNotNull(testingTarget, "Can't create success object ViewSelectorData");
            Assert.IsInstanceOf<ViewSelectorData>(testingTarget, "Should be an instance of ViewSelectorData type.");

            View view = new View()
            {
                BackgroundColor = Color.Cyan,
                BackgroundImage = path,
            };

            try
            {
                testingTarget.ClearBackground(view);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ViewSelectorDataClearBackground END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewSelectorData ClearShadow.")]
        [Property("SPEC", "Tizen.NUI.ViewSelectorData.ClearShadow M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSelectorDataClearShadow()
        {
            tlog.Debug(tag, $"ViewSelectorDataClearShadow START");

            var testingTarget = new ViewSelectorData();
            Assert.IsNotNull(testingTarget, "Can't create success object ViewSelectorData");
            Assert.IsInstanceOf<ViewSelectorData>(testingTarget, "Should be an instance of ViewSelectorData type.");

            View view = new View()
            {
                ImageShadow = new ImageShadow(path, new Vector2(20, 30), new Vector2(30, 40)),
                BoxShadow = new Shadow(1.5f, Color.CadetBlue, null, null)
            };

            try
            {
                testingTarget.ClearShadow(view);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ViewSelectorDataClearShadow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewSelectorData Reset.")]
        [Property("SPEC", "Tizen.NUI.ViewSelectorData.Reset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSelectorReset()
        {
            tlog.Debug(tag, $"ViewSelectorReset START");

            var testingTarget = new ViewSelectorData();
            Assert.IsNotNull(testingTarget, "Can't create success object ViewSelectorData");
            Assert.IsInstanceOf<ViewSelectorData>(testingTarget, "Should be an instance of ViewSelectorData type.");

            View view = new View()
            {
                BackgroundColor = Color.Cyan,
                BackgroundImage = path,
                ImageShadow = new ImageShadow(path, new Vector2(20, 30), new Vector2(30, 40)),
                BoxShadow = new Shadow(1.5f, Color.CadetBlue, null, null),
                Opacity = 0.2f
            };

            try
            {
                testingTarget.Reset(view);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ViewSelectorReset END (OK)");
        }
    }
}

using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Style/DefaultGridItemStyle")]
    public class DefaultGridItemStyleTest
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
        [Description("DefaultGridItemStyle Constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItemStyle.DefaultGridItemStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultGridItemStyleConstructor()
        {
            tlog.Debug(tag, $"DefaultGridItemStyleConstructor START");

            DefaultGridItemStyle style = new DefaultGridItemStyle()
            {
                Label = new TextLabelStyle()
                {
                    EnableAutoScroll = true,
                    Ellipsis = true,
                },
                Image = new ImageViewStyle()
                {
                    BorderOnly = true,
                    ResourceUrl = new StringSelector
                    {
                        Normal = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png",
                        Selected = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "arrow.png",
                        Disabled = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "button_9patch.png",
                        DisabledSelected = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png",
                    },
                }
            };

            var testingTarget = new DefaultGridItemStyle(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<DefaultGridItemStyle>(testingTarget, "Should return DefaultGridItemStyle instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItemStyleConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultGridItemStyle CopyFrom.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItemStyle.CopyFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultGridItemStyleCopyFrom()
        {
            tlog.Debug(tag, $"DefaultGridItemStyleCopyFrom START");

            DefaultGridItemStyle style = new DefaultGridItemStyle()
            {
                Label = new TextLabelStyle()
                {
                    EnableAutoScroll = true,
                    Ellipsis = true,
                },
                Image = new ImageViewStyle()
                {
                    BorderOnly = true,
                    ResourceUrl = new StringSelector
                    {
                        Normal = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png",
                        Selected = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "arrow.png",
                        Disabled = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "button_9patch.png",
                        DisabledSelected = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png",
                    },
                }
            };

            var testingTarget = new DefaultGridItemStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<DefaultGridItemStyle>(testingTarget, "Should return DefaultGridItemStyle instance.");

            try
            {
                testingTarget.CopyFrom(style);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItemStyleCopyFrom END (OK)");
        }
    }
}

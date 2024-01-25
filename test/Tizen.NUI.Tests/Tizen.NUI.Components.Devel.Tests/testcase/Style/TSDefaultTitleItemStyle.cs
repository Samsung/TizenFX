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
    [Description("Style/DefaultTitleItemStyle")]
    class DefaultTitleItemStyleTest
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
        [Description("DefaultTitleItemStyle Constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultTitleItemStyle.DefaultTitleItemStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultTitleItemStyleConstructor()
        {
            tlog.Debug(tag, $"DefaultTitleItemStyleConstructor START");

            DefaultTitleItemStyle style = new DefaultTitleItemStyle()
            {
                Label = new TextLabelStyle()
                {
                    EnableAutoScroll = true,
                    Ellipsis = true,
                },
                Icon = new ViewStyle()
                {
                    Color = new ColorSelector
                    {
                        Normal = Color.Cyan,
                    },
                }
            };

            var testingTarget = new DefaultTitleItemStyle(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<DefaultTitleItemStyle>(testingTarget, "Should return DefaultTitleItemStyle instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultTitleItemStyleConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultTitleItemStyle CopyFrom.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultTitleItemStyle.CopyFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultTitleItemStyleCopyFrom()
        {
            tlog.Debug(tag, $"DefaultTitleItemStyleCopyFrom START");

            DefaultTitleItemStyle style = new DefaultTitleItemStyle()
            {
                Label = new TextLabelStyle()
                {
                    EnableAutoScroll = true,
                    Ellipsis = true,
                },
                Icon = new ViewStyle()
                {
                    Color = new ColorSelector
                    {
                        Normal = Color.Cyan,
                    },
                }
            };

            var testingTarget = new DefaultTitleItemStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<DefaultTitleItemStyle>(testingTarget, "Should return DefaultTitleItemStyle instance.");

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
            tlog.Debug(tag, $"DefaultTitleItemStyleCopyFrom END (OK)");
        }
    }
}

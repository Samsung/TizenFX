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
    [Description("Style/DefaultLinearItemStyle")]
    public class DefaultLinearItemStyleTest
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
        [Description("DefaultLinearItemStyle Constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultLinearItemStyle.DefaultLinearItemStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultLinearItemStyleConstructor()
        {
            tlog.Debug(tag, $"DefaultLinearItemStyleConstructor START");

            DefaultLinearItemStyle style = new DefaultLinearItemStyle()
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

            var testingTarget = new DefaultLinearItemStyle(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<DefaultLinearItemStyle>(testingTarget, "Should return DefaultLinearItemStyle instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultLinearItemStyleConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultLinearItemStyle CopyFrom.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultLinearItemStyle.CopyFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultLinearItemStyleCopyFrom()
        {
            tlog.Debug(tag, $"DefaultLinearItemStyleCopyFrom START");

            DefaultLinearItemStyle style = new DefaultLinearItemStyle()
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

            var testingTarget = new DefaultLinearItemStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<DefaultLinearItemStyle>(testingTarget, "Should return DefaultLinearItemStyle instance.");

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
            tlog.Debug(tag, $"DefaultLinearItemStyleCopyFrom END (OK)");
        }
    }
}

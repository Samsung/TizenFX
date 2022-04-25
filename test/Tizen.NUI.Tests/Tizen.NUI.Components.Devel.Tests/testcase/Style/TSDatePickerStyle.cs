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
    [Description("Style/DatePickerStyle")]
    public class DatePickerStyleTest
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
        [Description("DatePickerStyle Constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.DatePickerStyle.DatePickerStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DatePickerStyleConstructor()
        {
            tlog.Debug(tag, $"DatePickerStyleConstructor START");

            DatePickerStyle style = new DatePickerStyle()
            {
                CellPadding = new Size2D(100, 200),
                Pickers = new PickerStyle()
                {
                    ItemTextLabel = new TextLabelStyle()
                    {
                        EnableAutoScroll = true,
                        Ellipsis = true,
                    }
                }
            };

            var testingTarget = new DatePickerStyle(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<DatePickerStyle>(testingTarget, "Should return DatePickerStyle instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DatePickerStyleConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DatePickerStyle CopyFrom.")]
        [Property("SPEC", "Tizen.NUI.Components.DatePickerStyle.CopyFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DatePickerStyleCopyFrom()
        {
            tlog.Debug(tag, $"DatePickerStyleCopyFrom START");

            DatePickerStyle style = new DatePickerStyle()
            {
                CellPadding = new Size2D(100, 200),
                Pickers = new PickerStyle()
                {
                    ItemTextLabel = new TextLabelStyle()
                    {
                        EnableAutoScroll = true,
                        Ellipsis = true,
                    }
                }
            };

            var testingTarget = new DatePickerStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<DatePickerStyle>(testingTarget, "Should return DatePickerStyle instance.");

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
            tlog.Debug(tag, $"DatePickerStyleCopyFrom END (OK)");
        }
    }
}

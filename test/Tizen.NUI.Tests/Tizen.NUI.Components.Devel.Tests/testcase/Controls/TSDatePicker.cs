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
    [Description("Controls/DatePicker")]
    public class DatePickerTest
    {
        private const string tag = "NUITEST";

        internal class MyDatePicker : DatePicker
        {
            public MyDatePicker() : base()
            { }

            public void OnDispose(DisposeTypes types)
            {
                base.Dispose(types);
            }

            public override void OnInitialize()
            {
                base.OnInitialize();
            }

            public override void ApplyStyle(ViewStyle viewStyle)
            {
                base.ApplyStyle(viewStyle);
            }
        }

        internal class MyDatePickerStyle : DatePickerStyle
        {
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
        [Description("DatePicker constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.DatePicker.DatePicker C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DatePickerConstructor()
        {
            tlog.Debug(tag, $"DatePickerConstructor START");

            var testingTarget = new DatePicker()
            {
                Size = new Size(600, 339),
                Date = DateTime.Now,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<DatePicker>(testingTarget, "Should return DatePicker instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DatePickerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DatePicker constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.DatePicker.DatePicker C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DatePickerConstructorWithString()
        {
            tlog.Debug(tag, $"DatePickerConstructorWithString START");

            try
            {
                new DatePicker("Tizen.NUI.Components.DatePicker");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"DatePickerConstructorWithString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DatePicker constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.DatePicker.DatePicker M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DatePickerConstructorWithDatePickerStyle()
        {
            tlog.Debug(tag, $"DatePickerConstructorWithDatePickerStyle START");

            DatePickerStyle dpStyle = new DatePickerStyle()
            {
                Pickers = new PickerStyle()
                {
                    StartScrollOffset = new Size(10, 10),
                },
                CellPadding = new Size2D(20, 20),
            };

            var testingTarget = new DatePicker(dpStyle);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<DatePicker>(testingTarget, "Should return DatePicker instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DatePickerConstructorWithDatePickerStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DatePicker Date.")]
        [Property("SPEC", "Tizen.NUI.Components.DatePicker.Date A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DatePickerDate()
        {
            tlog.Debug(tag, $"DatePickerDate START");

            var testingTarget = new DatePicker();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<DatePicker>(testingTarget, "Should return DatePicker instance.");

            testingTarget.Date = DateTime.Now;
            tlog.Debug(tag, "Date : " + testingTarget.Date);

            testingTarget.Dispose();
            tlog.Debug(tag, $"DatePickerDate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DatePicker ApplyStyle.")]
        [Property("SPEC", "Tizen.NUI.Components.DatePicker.ApplyStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DatePickerApplyStyle()
        {
            tlog.Debug(tag, $"DatePickerApplyStyle START");

            var testingTarget = new DatePicker()
            {
                Size = new Size(600, 339),
                Date = DateTime.Now,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<DatePicker>(testingTarget, "Should return DatePicker instance.");

            try
            {
                ViewStyle style = new ViewStyle()
                {
                    Size = new Size(30, 200)
                };
                testingTarget.ApplyStyle(style);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"DatePickerApplyStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DatePicker GetNextFocusableView.")]
        [Property("SPEC", "Tizen.NUI.Components.DatePicker.GetNextFocusableView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DatePickerGetNextFocusableView()
        {
            tlog.Debug(tag, $"DatePickerGetNextFocusableView START");

            DatePickerStyle dpStyle = new DatePickerStyle()
            {
                Pickers = new PickerStyle()
                {
                    StartScrollOffset = new Size(10, 10),
                },
                CellPadding = new Size2D(20, 20),
            };

            var testingTarget = new DatePicker(dpStyle);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<DatePicker>(testingTarget, "Should return DatePicker instance.");

            try
            {
                testingTarget.GetNextFocusableView(null, View.FocusDirection.Down, true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"DatePickerGetNextFocusableView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DateChangedEventArgs constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.DateChangedEventArgs.DateChangedEventArgs  C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DateChangedEventArgsConstructor()
        {
            tlog.Debug(tag, $"DateChangedEventArgsConstructor START");

            var testingTarget = new DateChangedEventArgs(new DateTime(2100, 12, 31));
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<DateChangedEventArgs>(testingTarget, "Should return DateChangedEventArgs instance.");

            var result = testingTarget.Date;
            tlog.Debug(tag, "Date : " + result);

            tlog.Debug(tag, $"DateChangedEventArgsConstructor END (OK)");
        }
    }
}

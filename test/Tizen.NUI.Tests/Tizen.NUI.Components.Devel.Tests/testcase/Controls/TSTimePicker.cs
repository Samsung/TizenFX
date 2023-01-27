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
    [Description("Control/TimePicker")]
    public class TimePickerTest
    {
        private const string tag = "NUITEST";

        internal class MyTimePicker : TimePicker
        {
            public MyTimePicker() : base()
            { 
            }

            public override void OnInitialize()
            {
                base.OnInitialize();
            }

            public override void ApplyStyle(ViewStyle style)
            {
                base.ApplyStyle(style);
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
        [Description("TimePicker constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.TimePicker.TimePicker C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONST")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimePickerConstructor()
        {
            tlog.Debug(tag, $"TimePickerConstructor START");

            TimePickerStyle ts = new TimePickerStyle()
            {
                Pickers = new PickerStyle(),
            };

            var testingTarget = new TimePicker(ts);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TimePicker>(testingTarget, "Should return TimePicker instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TimePickerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TimePicker constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.TimePicker.TimePicker C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONST")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimePickerConstructorWithString()
        {
            tlog.Debug(tag, $"TimePickerConstructorWithString START");

            try
            {
                new TimePicker("Tizen.NUI.Components.TimePicker");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TimePickerConstructorWithString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TimePicker Time.")]
        [Property("SPEC", "Tizen.NUI.Components.TimePicker.Time A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimePickerTime()
        {
            tlog.Debug(tag, $"TimePickerTime START");

            var testingTarget = new TimePicker();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TimePicker>(testingTarget, "Should return TimePicker instance.");

            tlog.Debug(tag, "Time : " + testingTarget.Time);

            testingTarget.Time = DateTime.Now;
            tlog.Debug(tag, "Time : " + testingTarget.Time);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TimePickerTime END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TimePicker Is24HourView.")]
        [Property("SPEC", "Tizen.NUI.Components.TimePicker.Is24HourView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimePickerIs24HourView()
        {
            tlog.Debug(tag, $"TimePickerIs24HourView START");

            var testingTarget = new TimePicker();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TimePicker>(testingTarget, "Should return TimePicker instance.");

            testingTarget.Is24HourView = true;
            tlog.Debug(tag, "Is24HourView : " + testingTarget.Is24HourView);

            testingTarget.Is24HourView = false;
            tlog.Debug(tag, "Is24HourView : " + testingTarget.Is24HourView);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TimePickerIs24HourView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TimePicker ApplyStyle.")]
        [Property("SPEC", "Tizen.NUI.Components.TimePicker.ApplyStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimePickerApplyStyle()
        {
            tlog.Debug(tag, $"TimePickerApplyStyle START");

            var testingTarget = new TimePicker();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TimePicker>(testingTarget, "Should return TimePicker instance.");

            try
            {
                testingTarget.ApplyStyle(new ViewStyle() { Size = new Size(100, 200) });
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TimePickerApplyStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TimeChangedEventArgs constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.TimeChangedEventArgs.TimeChangedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimeChangedEventArgsConstructor()
        {
            tlog.Debug(tag, $"TimeChangedEventArgsConstructor START");

            var testingTarget = new TimeChangedEventArgs(DateTime.Now);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TimeChangedEventArgs>(testingTarget, "Should return TimeChangedEventArgs instance.");

            tlog.Debug(tag, "Time : " + testingTarget.Time);

            tlog.Debug(tag, $"TimeChangedEventArgsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TimePicker GetNextFocusableView.")]
        [Property("SPEC", "Tizen.NUI.Components.TimePicker.GetNextFocusableView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimePickerGetNextFocusableView()
        {
            tlog.Debug(tag, $"TimePickerGetNextFocusableView START");

            TimePickerStyle ts = new TimePickerStyle()
            {
                Pickers = new PickerStyle()
                {
                    StartScrollOffset = new Size(10, 10),
                },
                CellPadding = new Size2D(20, 20),
            };

            var testingTarget = new TimePicker(ts);

            try
            {
                testingTarget.GetNextFocusableView(null, View.FocusDirection.Down, true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TimePickerGetNextFocusableView END (OK)");
        }
    }
}

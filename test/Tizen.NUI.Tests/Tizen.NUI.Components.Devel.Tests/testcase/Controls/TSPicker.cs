using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/Picker")]
    public class PickerTest
    {
        private const string tag = "NUITEST";

        internal class MyPicker : Picker
        {
            public MyPicker() : base()
            { }

            public override void OnInitialize()
            {
                base.OnInitialize();
            }

            public override void ApplyStyle(ViewStyle viewStyle)
            {
                base.ApplyStyle(viewStyle);
            }
        }

        internal class MyPickerScroller : Picker.PickerScroller
        {
            public void MyDecelerating(float velocity, Animation animation)
            {
                base.Decelerating(velocity, animation);
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
        [Description("Picker constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.Picker.Picker C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PickerConstructor()
        {
            tlog.Debug(tag, $"PickerConstructor START");

            var testingTarget = new Picker();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Picker>(testingTarget, "Should return Picker instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PickerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Picker DisplayedValues.")]
        [Property("SPEC", "Tizen.NUI.Components.Picker.DisplayedValues A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PickerDisplayedValues()
        {
            tlog.Debug(tag, $"PickerDisplayedValues START");

            var testingTarget = new Picker();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Picker>(testingTarget, "Should return Picker instance.");

            string[] items = new string[3];
            items[0] = "str0";
            items[1] = "str1";
            items[2] = "str2";
            ReadOnlyCollection<string> rc = new ReadOnlyCollection<string>(items);
            testingTarget.DisplayedValues = rc;
            tlog.Debug(tag, "DisplayedValues : " + testingTarget.DisplayedValues);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PickerDisplayedValues END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Picker CurrentValue.")]
        [Property("SPEC", "Tizen.NUI.Components.Picker.CurrentValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PickerCurrentValue()
        {
            tlog.Debug(tag, $"PickerCurrentValue START");

            var testingTarget = new Picker();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Picker>(testingTarget, "Should return Picker instance.");

            testingTarget.CurrentValue = 12;
            tlog.Debug(tag, "CurrentValue : " + testingTarget.CurrentValue);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PickerCurrentValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Picker MinValue.")]
        [Property("SPEC", "Tizen.NUI.Components.Picker.MinValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PickerMinValue()
        {
            tlog.Debug(tag, $"PickerMinValue START");

            var testingTarget = new Picker();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Picker>(testingTarget, "Should return Picker instance.");

            testingTarget.MinValue = 10;
            tlog.Debug(tag, "MinValue : " + testingTarget.MinValue);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PickerCurrentValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Picker MaxValue.")]
        [Property("SPEC", "Tizen.NUI.Components.Picker.MaxValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PickerMaxValue()
        {
            tlog.Debug(tag, $"PickerMaxValue START");

            var testingTarget = new Picker();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Picker>(testingTarget, "Should return Picker instance.");

            testingTarget.MaxValue = 60;
            tlog.Debug(tag, "MaxValue : " + testingTarget.MaxValue);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PickerMaxValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Picker OnInitialize.")]
        [Property("SPEC", "Tizen.NUI.Components.Picker.OnInitialize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PickerOnInitialize()
        {
            tlog.Debug(tag, $"PickerOnInitialize START");

            var testingTarget = new MyPicker();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Picker>(testingTarget, "Should return Picker instance.");

            try
            {
                testingTarget.OnInitialize();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PickerOnInitialize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Picker ApplyStyle.")]
        [Property("SPEC", "Tizen.NUI.Components.Picker.ApplyStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PickerApplyStyle()
        {
            tlog.Debug(tag, $"PickerApplyStyle START");

            var testingTarget = new MyPicker();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Picker>(testingTarget, "Should return Picker instance.");

            try
            {
                ViewStyle style = new ViewStyle() 
                { 
                    Size = new Size(30, 80),
                };
                testingTarget.ApplyStyle(style);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PickerApplyStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ValueChangedEventArgs constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.ValueChangedEventArgs.ValueChangedEventArgs M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ValueChangedEventArgsConstructor()
        {
            tlog.Debug(tag, $"ValueChangedEventArgsConstructor START");

            var testingTarget = new ValueChangedEventArgs(10);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ValueChangedEventArgs>(testingTarget, "Should return ValueChangedEventArgs instance.");

            tlog.Debug(tag, "Value : " + testingTarget.Value);

            tlog.Debug(tag, $"ValueChangedEventArgsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Picker OnRelayout.")]
        [Property("SPEC", "Tizen.NUI.Components.Picker.OnRelayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task PickerOnRelayout()
        {
            tlog.Debug(tag, $"PickerOnRelayout START");

            var testingTarget = new MyPicker()
            {
                Size = new Size(100, 200),
                BackgroundColor = Color.Green,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Picker>(testingTarget, "Should return Picker instance.");

            NUIApplication.GetDefaultWindow().GetDefaultLayer().Add(testingTarget);

            testingTarget.Size = new Size(50, 100);
            testingTarget.BackgroundColor = Color.Blue;

            await Task.Delay(200);
            NUIApplication.GetDefaultWindow().GetDefaultLayer().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PickerOnRelayout END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PickerScroller Decelerating")]
        [Property("SPEC", "Tizen.NUI.Components.PickerScroller.Decelerating M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PickerScrollerDecelerating()
        {
            tlog.Debug(tag, $"PickerScrollerDecelerating START");

            var testingTarget = new MyPickerScroller();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Picker.PickerScroller>(testingTarget, "Should return PickerScroller instance.");

            try
            {
                using (Animation ani = new Animation(300))
                {
                    ani.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce);
                    testingTarget.MyDecelerating(0.3f, ani);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"PickerScrollerDecelerating END (OK)");
        }
    }
}

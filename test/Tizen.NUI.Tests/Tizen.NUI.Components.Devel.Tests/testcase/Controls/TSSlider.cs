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
    [Description("Controls/Slider")]
    public class SliderTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        [Obsolete]
        private EventHandler<Slider.ValueChangedArgs> OnValueChangedEvent()
        {
            return null;
        }

        [Obsolete]
        private EventHandler<Slider.SlidingFinishedArgs> OnSlidingFinishedEvent()
        {
            return null;
        }

        private EventHandler<SliderValueChangedEventArgs> OnValueChanged()
        {
            return null;
        }

        private EventHandler<SliderSlidingStartedEventArgs> OnSlidingStarted()
        {
            return null;
        }

        private EventHandler<SliderSlidingFinishedEventArgs> OnSlidingFinished()
        {
            return null;
        }

        [Obsolete]
        private EventHandler<Slider.StateChangedArgs> OnStateChangedEvent()
        {
            return null;
        }

        internal class MySlider : Slider
        {
            public MySlider() : base()
            { }

            public bool OnAccessibilityShouldReportZeroChildren()
            {
                return base.AccessibilityShouldReportZeroChildren();
            }

            public double OnAccessibilityGetMinimum()
            {
                return base.AccessibilityGetMinimum();
            }

            public double OnAccessibilityGetCurrent()
            {
                return base.AccessibilityGetCurrent();
            }

            public double OnAccessibilityGetMaximum()
            {
                return base.AccessibilityGetMaximum();
            }

            public bool OnAccessibilitySetCurrent(double value)
            {
                return base.AccessibilitySetCurrent(value);
            }

            public double OnAccessibilityGetMinimumIncrement()
            {
                return base.AccessibilityGetMinimumIncrement();
            }

            public void MyOnUpdate()
            {
                base.OnUpdate();
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
        [Description("Slider TrackThickness.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.TrackThickness A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SliderTrackThickness()
        {
            tlog.Debug(tag, $"SliderTrackThickness START");

            var testingTarget = new Slider()
            {
                Direction = Slider.DirectionType.Vertical,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            testingTarget.IsEnabled = true;
            tlog.Debug(tag, "IsEnabled : " + testingTarget.IsEnabled);

            testingTarget.TrackThickness = 30;
            tlog.Debug(tag, "TrackThickness : " + testingTarget.TrackThickness);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TrackThickness END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Slider WarningStartValue.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.WarningStartValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SliderWarningStartValue()
        {
            tlog.Debug(tag, $"SliderWarningStartValue START");

            var testingTarget = new Slider()
            {
                Direction = Slider.DirectionType.Vertical,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            testingTarget.IsEnabled = true;
            tlog.Debug(tag, "IsEnabled : " + testingTarget.IsEnabled);

            testingTarget.WarningStartValue = 30.0f;
            tlog.Debug(tag, "WarningStartValue : " + testingTarget.WarningStartValue);

            testingTarget.WarningTrackColor = Color.Cyan;
            tlog.Debug(tag, "WarningTrackColor :" + testingTarget.WarningTrackColor);

            testingTarget.WarningSlidedTrackColor = Color.Green;
            tlog.Debug(tag, "WarningSlidedTrackColor :" + testingTarget.WarningSlidedTrackColor);

            testingTarget.WarningThumbColor = Color.Red;
            tlog.Debug(tag, "WarningThumbColor : " + testingTarget.WarningThumbColor);

            Selector<string> url = new Selector<string>()
            { 
                All = image_path,
            };
            testingTarget.WarningThumbImageUrl = url;
            tlog.Debug(tag, "WarningThumbImageUrl : " + testingTarget.WarningThumbImageUrl);

            try
            {
                testingTarget.WarningThumbImageUrl = null;
            }
            catch (NullReferenceException)
            {
                testingTarget.Dispose();
                tlog.Debug(tag, $"SliderThumbImageUrl END (OK)");
                Assert.Pass("Caught NullReferenceException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Slider OnFocusGained.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.OnFocusGained M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SliderOnFocusGained()
        {
            tlog.Debug(tag, $"SliderOnFocusGained START");

            var testingTarget = new Slider()
            {
                Direction = Slider.DirectionType.Vertical,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            try
            {
                testingTarget.OnFocusGained();
                testingTarget.OnFocusLost();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SliderOnFocusGained END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Slider OnKey.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.OnKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SliderOnKey()
        {
            tlog.Debug(tag, $"SliderOnKey START");

            var testingTarget = new Slider()
            {
                Direction = Slider.DirectionType.Vertical,
                IsEnabled = true,
                IsDiscrete = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            testingTarget.MinValue = 0.0f;
            testingTarget.MaxValue = 100.0f;
            testingTarget.CurrentValue = 30.0f;

            Key dummy = null;
            var result = testingTarget.OnKey(dummy);
            Assert.AreEqual(false, result, "should be equal here!");

            using (Key key = new Key())
            {
                key.State = Key.StateType.Down;
                key.KeyPressedName = "Down";

                try
                {
                    testingTarget.OnKey(key);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                key.State = Key.StateType.Up;
                try
                {
                    testingTarget.OnKey(key);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SliderOnKey END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Slider OnKey.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.OnKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SliderOnKeyKeyPressedNameUp()
        {
            tlog.Debug(tag, $"SliderOnKeyKeyPressedNameUp START");

            var testingTarget = new Slider()
            {
                Direction = Slider.DirectionType.Vertical,
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            testingTarget.MinValue = 0.0f;
            testingTarget.MaxValue = 100.0f;
            testingTarget.CurrentValue = 30.0f;

            using (Key key = new Key())
            {
                key.State = Key.StateType.Down;
                key.KeyPressedName = "Up";

                try
                {
                    testingTarget.OnKey(key);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SliderOnKeyKeyPressedNameUp END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Slider ValueChangedEvent.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.ValueChangedEvent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SliderValueChangedEvent()
        {
            tlog.Debug(tag, $"SliderValueChangedEvent START");

            var testingTarget = new Slider()
            {
                Direction = Slider.DirectionType.Vertical,
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            testingTarget.ValueChangedEvent += OnValueChangedEvent();
            testingTarget.ValueChangedEvent -= OnValueChangedEvent();

            testingTarget.Dispose();
            tlog.Debug(tag, $"SliderValueChangedEvent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Slider SlidingFinishedEvent.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.SlidingFinishedEvent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SliderSlidingFinishedEvent()
        {
            tlog.Debug(tag, $"SliderSlidingFinishedEvent START");

            var testingTarget = new Slider()
            {
                Direction = Slider.DirectionType.Vertical,
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            testingTarget.SlidingFinishedEvent += OnSlidingFinishedEvent();
            testingTarget.SlidingFinishedEvent -= OnSlidingFinishedEvent();

            testingTarget.Dispose();
            tlog.Debug(tag, $"SliderValueChangedEvent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SliderSlidingStartedEventArgs CurrentValue.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.OnKey A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SliderSlidingStartedEventArgsCurrentValue()
        {
            tlog.Debug(tag, $"SliderSlidingStartedEventArgsCurrentValue START");

            var testingTarget = new SliderSlidingStartedEventArgs();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SliderSlidingStartedEventArgs>(testingTarget, "Should return SliderSlidingStartedEventArgs instance.");

            testingTarget.CurrentValue = 30.0f;
            tlog.Debug(tag, "CurrentValue : " + testingTarget.CurrentValue);

            tlog.Debug(tag, $"SliderSlidingStartedEventArgsCurrentValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Slider ValueChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.ValueChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SliderValueChanged()
        {
            tlog.Debug(tag, $"SliderValueChanged START");

            var testingTarget = new Slider()
            {
                Direction = Slider.DirectionType.Vertical,
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            testingTarget.ValueChanged += OnValueChanged();
            testingTarget.ValueChanged -= OnValueChanged();

            testingTarget.Dispose();
            tlog.Debug(tag, $"SliderValueChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Slider SlidingStarted.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.SlidingStarted A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SliderSlidingStarted()
        {
            tlog.Debug(tag, $"SliderSlidingStarted START");

            var testingTarget = new Slider()
            {
                Direction = Slider.DirectionType.Vertical,
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            testingTarget.SlidingStarted += OnSlidingStarted();
            testingTarget.SlidingStarted -= OnSlidingStarted();

            testingTarget.Dispose();
            tlog.Debug(tag, $"SliderSlidingStarted END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Slider SlidingFinished.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.SlidingFinished A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SliderSlidingFinished()
        {
            tlog.Debug(tag, $"SliderSlidingFinished START");

            var testingTarget = new Slider()
            {
                Direction = Slider.DirectionType.Vertical,
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            testingTarget.SlidingFinished += OnSlidingFinished();
            testingTarget.SlidingFinished -= OnSlidingFinished();

            testingTarget.Dispose();
            tlog.Debug(tag, $"SliderSlidingFinished END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Slider StateChangedEvent.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.StateChangedEvent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SliderStateChangedEvent()
        {
            tlog.Debug(tag, $"SliderStateChangedEvent START");

            var testingTarget = new Slider()
            {
                Direction = Slider.DirectionType.Vertical,
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            testingTarget.StateChangedEvent += OnStateChangedEvent();
            testingTarget.StateChangedEvent -= OnStateChangedEvent();

            testingTarget.Dispose();
            tlog.Debug(tag, $"SliderStateChangedEvent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Slider ThumbImageUrl.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.ThumbImageUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SliderThumbImageUrl()
        {
            tlog.Debug(tag, $"SliderThumbImageUrl START");

            var testingTarget = new Slider()
            {
                Direction = Slider.DirectionType.Vertical,
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            tlog.Debug(tag, "ThumbImageUrl : " + testingTarget.ThumbImageUrl);

            testingTarget.ThumbImageUrl = image_path;
            tlog.Debug(tag, "ThumbImageUrl : " + testingTarget.ThumbImageUrl);

            try
            {
                testingTarget.ThumbImageUrl = null;
            }
            catch (NullReferenceException)
            {
                testingTarget.Dispose();
                tlog.Debug(tag, $"SliderThumbImageUrl END (OK)");
                Assert.Pass("Caught NullReferenceException : Passed!");
            }   
        }

        [Test]
        [Category("P1")]
        [Description("Slider ThumbColor.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.ThumbColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SliderThumbColor()
        {
            tlog.Debug(tag, $"SliderThumbColor START");

            var testingTarget = new Slider()
            {
                Direction = Slider.DirectionType.Vertical,
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            testingTarget.ThumbImageUrl = image_path;
            testingTarget.ThumbColor = Color.Black;
            tlog.Debug(tag, "ThumbColor : " + testingTarget.ThumbColor);

            testingTarget.Dispose();
            tlog.Debug(tag, $"SliderThumbColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Slider AccessibilityShouldReportZeroChildren.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.AccessibilityShouldReportZeroChildren M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SliderAccessibilityShouldReportZeroChildren()
        {
            tlog.Debug(tag, $"SliderAccessibilityShouldReportZeroChildren START");

            var testingTarget = new MySlider()
            {
                Direction = Slider.DirectionType.Vertical,
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            var result = testingTarget.OnAccessibilityShouldReportZeroChildren();
            tlog.Debug(tag, "AccessibilityShouldReportZeroChildren : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"SliderAccessibilityShouldReportZeroChildren END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Slider AccessibilityGetMinimum.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.AccessibilityGetMinimum M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SliderAccessibilityGetMinimum()
        {
            tlog.Debug(tag, $"SliderAccessibilityGetMinimum START");

            var testingTarget = new MySlider()
            {
                Direction = Slider.DirectionType.Vertical,
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            testingTarget.MinValue = 0.0f;
            testingTarget.MaxValue = 100.0f;
            testingTarget.CurrentValue = 30.0f;

            var result = testingTarget.OnAccessibilityGetMinimum();
            tlog.Debug(tag, "AccessibilityGetMinimum : " + result);

            result = testingTarget.OnAccessibilityGetMaximum();
            tlog.Debug(tag, "AccessibilityGetMaximum : " + result);

            result = testingTarget.OnAccessibilityGetCurrent();
            tlog.Debug(tag, "AccessibilityGetCurrent : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"SliderAccessibilityGetMinimum END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Slider AccessibilitySetCurrent.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.AccessibilitySetCurrent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SliderAccessibilitySetCurrent()
        {
            tlog.Debug(tag, $"SliderAccessibilitySetCurrent START");

            var testingTarget = new MySlider()
            {
                Direction = Slider.DirectionType.Vertical,
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            testingTarget.MinValue = 0.0f;
            testingTarget.MaxValue = 100.0f;

            var result = testingTarget.OnAccessibilitySetCurrent(30.0f);
            tlog.Debug(tag, "AccessibilitySetCurrent : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"SliderAccessibilitySetCurrent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Slider AccessibilityGetMinimumIncrement.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.AccessibilityGetMinimumIncrement M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SliderAccessibilityGetMinimumIncrement()
        {
            tlog.Debug(tag, $"SliderAccessibilityGetMinimumIncrement START");

            var testingTarget = new MySlider()
            {
                Direction = Slider.DirectionType.Vertical,
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            testingTarget.MinValue = 0.0f;
            testingTarget.MaxValue = 100.0f;

            var result = testingTarget.OnAccessibilityGetMinimumIncrement();
            tlog.Debug(tag, "AccessibilityGetMinimumIncrement : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"SliderAccessibilityGetMinimumIncrement END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Slider OnUpdate.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.OnUpdate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SliderOnUpdate()
        {
            tlog.Debug(tag, $"SliderOnUpdate START");

            var testingTarget = new MySlider()
            {
                Direction = Slider.DirectionType.Vertical,
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            testingTarget.MinValue = 0.0f;
            testingTarget.MaxValue = 100.0f;
            testingTarget.BgTrackColor = Color.Cyan;
            testingTarget.LowIndicatorImageURL = image_path;
            testingTarget.LowIndicatorSize = new Size(8, 8);
            testingTarget.HighIndicatorImageURL = image_path;
            testingTarget.HighIndicatorSize = new Size(10, 10);

            SliderStyle style1 = new SliderStyle()
            { 
                IndicatorType = Slider.IndicatorType.Image,
            };
            testingTarget.ApplyStyle(style1);

            try
            {
                testingTarget.MyOnUpdate();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            SliderStyle style2 = new SliderStyle()
            {
                IndicatorType = Slider.IndicatorType.Text,
            };
            testingTarget.ApplyStyle(style2);

            try
            {
                testingTarget.MyOnUpdate();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SliderOnUpdate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Slider OnUpdate.")]
        [Property("SPEC", "Tizen.NUI.Components.Slider.OnUpdate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SliderOnUpdateDirectionIsHorizontal()
        {
            tlog.Debug(tag, $"SliderOnUpdateDirectionIsHorizontal START");

            var testingTarget = new MySlider()
            {
                Size = new Size(100, 5),
                Direction = Slider.DirectionType.Horizontal,
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Slider>(testingTarget, "Should return Slider instance.");

            testingTarget.MinValue = 0.0f;
            testingTarget.MaxValue = 100.0f;
            testingTarget.BgTrackColor = Color.Cyan; 
            testingTarget.LowIndicatorImageURL = image_path;
            testingTarget.LowIndicatorSize = new Size(8, 8);
            testingTarget.HighIndicatorImageURL = image_path;
            testingTarget.HighIndicatorSize = new Size(10, 10);

            SliderStyle style1 = new SliderStyle()
            {
                IndicatorType = Slider.IndicatorType.Image,
            };
            testingTarget.ApplyStyle(style1);

            try
            {
                testingTarget.MyOnUpdate();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            SliderStyle style2 = new SliderStyle()
            {
                IndicatorType = Slider.IndicatorType.Text,
            };
            testingTarget.ApplyStyle(style2);

            try
            {
                testingTarget.MyOnUpdate();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SliderOnUpdateDirectionIsHorizontal END (OK)");
        }
    }
}

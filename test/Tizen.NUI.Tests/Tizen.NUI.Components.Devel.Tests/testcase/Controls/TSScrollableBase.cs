using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components.Devel.Tests
{
    using static Tizen.NUI.Components.ScrollOutOfBoundEventArgs;
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/ScrollableBase")]
    public class ScrollableBaseTest
    {
        private const string tag = "NUITEST";

        internal class MyScrollableBase : ScrollableBase
        {
            public MyScrollableBase() : base()
            { }

            public void MyAccessibilityIsScrollable()
            {
                base.AccessibilityIsScrollable();
            }

            public void OnGetNextFocusableView(View currentFocusedView, View.FocusDirection direction, bool loopEnabled)
            {
                base.GetNextFocusableView(currentFocusedView, direction, loopEnabled);
            }

            public void MyDecelerating(float velocity, Animation animation)
            {
                base.Decelerating(velocity, animation);
            }

            public bool MyAccessibilityScrollToChild(View child)
            {
                return base.AccessibilityScrollToChild(child);
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
        [Description("ScrollableBase constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollableBase.ScrollableBase C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollableBaseConstructor()
        {
            tlog.Debug(tag, $"ScrollableBaseConstructor START");

            var testingTarget = new ScrollableBase();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollableBase>(testingTarget, "Should return ScrollableBase instance.");

            tlog.Debug(tag, "ScrollPosition : " + testingTarget.ScrollPosition);

            testingTarget.ScrollingEventThreshold = 0.3f;
            tlog.Debug(tag, "ScrollingEventThreshold : " + testingTarget.ScrollingEventThreshold);

            testingTarget.NoticeAnimationEndBeforePosition = 0.5f;
            tlog.Debug(tag, "NoticeAnimationEndBeforePosition : " + testingTarget.NoticeAnimationEndBeforePosition);

            testingTarget.Padding = new Extents(2, 2, 2, 2);
            tlog.Debug(tag, "Padding : " + testingTarget.Padding);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollableBaseConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollEventArgs ScrollPosition")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollEventArgs.ScrollPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollEventArgsScrollPosition()
        {
            tlog.Debug(tag, $"ScrollEventArgsScrollPosition START");

            using (Position position = new Position(10, 20))
            {
                var testingTarget = new ScrollEventArgs(position);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<ScrollEventArgs>(testingTarget, "Should return ScrollEventArgs instance.");

                tlog.Debug(tag, "ScrollPosition : " + testingTarget.ScrollPosition);
            }

            tlog.Debug(tag, $"ScrollEventArgsScrollPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollOutOfBoundEventArgs constructor")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollableBase.ScrollOutOfBoundEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollOutOfBoundEventArgsConstructor()
        {
            tlog.Debug(tag, $"ScrollOutOfBoundEventArgsConstructor START");

            var testingTarget = new ScrollOutOfBoundEventArgs(ScrollOutOfBoundEventArgs.Direction.Up, 0.3f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollOutOfBoundEventArgs>(testingTarget, "Should return ScrollOutOfBoundEventArgs instance.");

            tlog.Debug(tag, "PanDirection : " + testingTarget.PanDirection);
            tlog.Debug(tag, "Displacement : " + testingTarget.Displacement);

            tlog.Debug(tag, $"ScrollOutOfBoundEventArgsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollableBase ScrollEnabled")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollableBase.ScrollEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollableBaseScrollEnabled()
        {
            tlog.Debug(tag, $"ScrollableBaseScrollEnabled START");

            var testingTarget = new ScrollableBase();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollableBase>(testingTarget, "Should return ScrollableBase instance.");

            testingTarget.ScrollEnabled = true;
            tlog.Debug(tag, "ScrollEnabled : " + testingTarget.ScrollEnabled);

            testingTarget.ScrollEnabled = false;
            tlog.Debug(tag, "ScrollEnabled : " + testingTarget.ScrollEnabled);

            testingTarget.ScrollEnabled = true;
            tlog.Debug(tag, "ScrollEnabled : " + testingTarget.ScrollEnabled);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollableBaseScrollEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollableBase Scrollbar")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollableBase.Scrollbar A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollableBaseScrollbar()
        {
            tlog.Debug(tag, $"ScrollableBaseScrollbar START");

            var testingTarget = new ScrollableBase();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollableBase>(testingTarget, "Should return ScrollableBase instance.");

            testingTarget.ScrollEnabled = true;
            tlog.Debug(tag, "ScrollEnabled : " + testingTarget.ScrollEnabled);

            testingTarget.HideScrollbar = false;

            Scrollbar bar = new Scrollbar()
            {
                Size = new Size(50, 2),
            };
            testingTarget.Scrollbar = bar;

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollableBaseScrollbar END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollableBase ScrollableBaseAccessibilityIsScrollable")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollableBase.ScrollableBaseAccessibilityIsScrollable M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollableBaseAccessibilityIsScrollable()
        {
            tlog.Debug(tag, $"ScrollableBaseAccessibilityIsScrollable START");

            var testingTarget = new MyScrollableBase();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollableBase>(testingTarget, "Should return ScrollableBase instance.");

            try
            {
                testingTarget.MyAccessibilityIsScrollable();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollableBaseAccessibilityIsScrollable END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollableBase GetNextFocusableView")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollableBase.GetNextFocusableView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollableBaseGetNextFocusableView()
        {
            tlog.Debug(tag, $"ScrollableBaseGetNextFocusableView START");

            var testingTarget = new MyScrollableBase();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollableBase>(testingTarget, "Should return ScrollableBase instance.");

            View view1 = new View()
            {
                Size = new Size(100, 200),
                Position = new Position(0, 0),
                BackgroundColor = Color.Cyan
            };

            View view2 = new View()
            {
                Size = new Size(100, 200),
                Position = new Position(150, 0),
                BackgroundColor = Color.Green
            };

            View view3 = new View()
            {
                Size = new Size(100, 200),
                Position = new Position(300, 200),
                BackgroundColor = Color.Green
            };

            FocusManager.Instance.SetCurrentFocusView(view1);

            try
            {
                testingTarget.OnGetNextFocusableView(view1, View.FocusDirection.Right, true);
                testingTarget.OnGetNextFocusableView(view2, View.FocusDirection.Right, true);
                testingTarget.OnGetNextFocusableView(view3, View.FocusDirection.Left, true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            FocusManager.Instance.ClearFocus();

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollableBaseGetNextFocusableView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollableBase ScrollTo")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollableBase.ScrollTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollableBaseScrollTo()
        {
            tlog.Debug(tag, $"ScrollableBaseScrollTo START");

            var testingTarget = new ScrollableBase()
            {
                Size = new Size(100, 2),
                BackgroundColor = Color.Cyan,
                ScrollingDirection = ScrollableBase.Direction.Horizontal,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollableBase>(testingTarget, "Should return ScrollableBase instance.");

            try
            {
                testingTarget.ScrollTo(0.3f, true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollableBaseScrollTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollableBase Decelerating")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollableBase.Decelerating M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollableBaseDecelerating()
        {
            tlog.Debug(tag, $"ScrollableBaseDecelerating START");

            var testingTarget = new MyScrollableBase()
            {
                Size = new Size(100, 2),
                BackgroundColor = Color.Cyan,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollableBase>(testingTarget, "Should return ScrollableBase instance.");

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

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollableBaseDecelerating END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollableBase DecelerationThreshold")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollableBase.DecelerationThreshold A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollableBaseDecelerationThreshold()
        {
            tlog.Debug(tag, $"ScrollableBaseDecelerationThreshold START");

            var testingTarget = new MyScrollableBase()
            {
                Size = new Size(100, 2),
                BackgroundColor = Color.Cyan,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollableBase>(testingTarget, "Should return ScrollableBase instance.");

            testingTarget.DecelerationThreshold = 0.8f;
            tlog.Debug(tag, "DecelerationThreshold : " + testingTarget.DecelerationThreshold);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollableBaseDecelerationThreshold END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollableBase ScrollAlphaFunction")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollableBase.ScrollAlphaFunction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollableBaseScrollAlphaFunction()
        {
            tlog.Debug(tag, $"ScrollableBaseScrollAlphaFunction START");

            var testingTarget = new MyScrollableBase()
            {
                Size = new Size(100, 2),
                BackgroundColor = Color.Cyan,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollableBase>(testingTarget, "Should return ScrollableBase instance.");

            testingTarget.ScrollAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseIn);
            tlog.Debug(tag, "ScrollAlphaFunction : " + testingTarget.ScrollAlphaFunction);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollableBaseScrollAlphaFunction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollableBase AccessibilityScrollToChild")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollableBase.AccessibilityScrollToChild M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollableBaseAccessibilityScrollToChild()
        {
            tlog.Debug(tag, $"ScrollableBaseAccessibilityScrollToChild START");

            var testingTarget = new MyScrollableBase()
            {
                Size = new Size(2000, 200),
                BackgroundColor = Color.Cyan,
                ScrollingDirection = ScrollableBase.Direction.Horizontal,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollableBase>(testingTarget, "Should return ScrollableBase instance.");

            testingTarget.ScrollAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseIn);
            tlog.Debug(tag, "ScrollAlphaFunction : " + testingTarget.ScrollAlphaFunction);

            View[] views = new View[10];
            for (int i = 0; i < 10; i++)
            {
                views[i] = new View();
                views[i].Size = new Size(200, 200);
                testingTarget.Add(views[i]);
            }

            var result = testingTarget.MyAccessibilityScrollToChild(views[9]);
            tlog.Debug(tag, "AccessibilityScrollToChild : " + result);

            try
            {
                testingTarget.RemoveAllChildren(true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollableBaseAccessibilityScrollToChild END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollableBase EnableOverShootingEffect")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollableBase.EnableOverShootingEffect A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollableBaseEnableOverShootingEffect()
        {
            tlog.Debug(tag, $"ScrollableBaseEnableOverShootingEffect START");

            var testingTarget = new MyScrollableBase()
            {
                Size = new Size(2000, 200),
                BackgroundColor = Color.Cyan,
                ScrollingDirection = ScrollableBase.Direction.Horizontal,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollableBase>(testingTarget, "Should return ScrollableBase instance.");

            testingTarget.EnableOverShootingEffect = true;
            tlog.Debug(tag, "EnableOverShootingEffect : " + testingTarget.EnableOverShootingEffect);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollableBaseEnableOverShootingEffect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollableBase BaseRemove")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollableBase.BaseRemove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollableBaseBaseRemove()
        {
            tlog.Debug(tag, $"ScrollableBaseBaseRemove START");

            var testingTarget = new MyScrollableBase()
            {
                Size = new Size(2000, 200),
                BackgroundColor = Color.Cyan,
                ScrollingDirection = ScrollableBase.Direction.Horizontal,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollableBase>(testingTarget, "Should return ScrollableBase instance.");

            using (View view = new View() { Size = new Size(100, 200), })
            {
                testingTarget.Add(view);

                try
                {
                    testingTarget.BaseRemove(view);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception :  Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollableBaseBaseRemove END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollableBase StepScrollDisance")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollableBase.StepScrollDisance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "sh10233.lee@samsung.com")]
        public void ScrollableBaseStepScrollDistance()
        {
            tlog.Debug(tag, $"ScrollableBaseStepScrollDistance START");

            var testingTarget = new ScrollableBase();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollableBase>(testingTarget, "Should return ScrollableBase instance.");

            testingTarget.StepScrollDistance = 200f;
            tlog.Debug(tag, "StepScrollDistance : " + testingTarget.StepScrollDistance);

            testingTarget.StepScrollDistance = 0f;
            tlog.Debug(tag, "StepScrollDistance : " + testingTarget.StepScrollDistance);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollableBaseStepScrollDistance END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("ScrollableBase FadeScrollbar")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollableBase.FadeScrollbar A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "sh10233.lee@samsung.com")]
        public void ScrollableBaseFadeScrollbar()
        {
            tlog.Debug(tag, $"ScrollableBaseFadeScrollbar START");

            var testingTarget = new ScrollableBase();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollableBase>(testingTarget, "Should return ScrollableBase instance.");

            testingTarget.FadeScrollbar = false;
            Assert.AreEqual(false, testingTarget.FadeScrollbar, "Should be equal.");

            testingTarget.FadeScrollbar = true;
            Assert.AreEqual(true, testingTarget.FadeScrollbar, "Should be equal.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollableBaseFadeScrollbar END (OK)");
        }
    }
}

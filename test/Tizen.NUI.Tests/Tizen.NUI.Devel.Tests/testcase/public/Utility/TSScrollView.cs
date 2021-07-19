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
    [Description("public/Utility/ScrollView")]
    class PublicScrollViewTest
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
        [Description("ScrollView WrapEnabled.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.WrapEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewWrapEnabled()
        {
            tlog.Debug(tag, $"ScrollViewWrapEnabled START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            Assert.AreEqual(false, testingTarget.WrapEnabled);

            testingTarget.WrapEnabled = true;
            Assert.AreEqual(true, testingTarget.WrapEnabled);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewWrapEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView PanningEnabled.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.PanningEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewPanningEnabled()
        {
            tlog.Debug(tag, $"ScrollViewPanningEnabled START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            testingTarget.PanningEnabled = true;
            Assert.AreEqual(true, testingTarget.PanningEnabled);

            testingTarget.PanningEnabled = false;
            Assert.AreEqual(false, testingTarget.PanningEnabled);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewPanningEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView AxisAutoLockEnabled.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.AxisAutoLockEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewAxisAutoLockEnabled()
        {
            tlog.Debug(tag, $"ScrollViewAxisAutoLockEnabled START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            Assert.AreEqual(false, testingTarget.AxisAutoLockEnabled);

            testingTarget.AxisAutoLockEnabled = true;
            Assert.AreEqual(true, testingTarget.AxisAutoLockEnabled);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewAxisAutoLockEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView WheelScrollDistanceStep.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.WheelScrollDistanceStep A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewWheelScrollDistanceStep()
        {
            tlog.Debug(tag, $"ScrollViewWheelScrollDistanceStep START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            Assert.IsNotNull(testingTarget.WheelScrollDistanceStep.X);
            Assert.IsNotNull(testingTarget.WheelScrollDistanceStep.Y);

            using (Vector2 vector = new Vector2(100, 80))
            {
                testingTarget.WheelScrollDistanceStep = vector;
                Assert.AreEqual(100, testingTarget.WheelScrollDistanceStep.X);
                Assert.AreEqual( 80, testingTarget.WheelScrollDistanceStep.Y);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewWheelScrollDistanceStep END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView ScrollPosition.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewScrollPosition()
        {
            tlog.Debug(tag, $"ScrollViewScrollPosition START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            Assert.AreEqual(0, testingTarget.ScrollPosition.X);
            Assert.AreEqual(0, testingTarget.ScrollPosition.Y);

            using (Vector2 vector = new Vector2(80, 100))
            {
                testingTarget.ScrollPosition = vector;
                Assert.AreEqual(80, testingTarget.ScrollPosition.X);
                Assert.AreEqual(100, testingTarget.ScrollPosition.Y);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewScrollPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView ScrollPrePosition.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollPrePosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewScrollPrePosition()
        {
            tlog.Debug(tag, $"ScrollViewScrollPrePosition START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            Assert.AreEqual(0, testingTarget.ScrollPrePosition.X);
            Assert.AreEqual(0, testingTarget.ScrollPrePosition.Y);

            using (Vector2 vector = new Vector2(80, 100))
            {
                testingTarget.ScrollPrePosition = vector;
                Assert.AreEqual(80, testingTarget.ScrollPrePosition.X);
                Assert.AreEqual(100, testingTarget.ScrollPrePosition.Y);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewScrollPrePosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView ScrollPrePositionMax.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollPrePositionMax A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewScrollPrePositionMax()
        {
            tlog.Debug(tag, $"ScrollViewScrollPrePositionMax START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            Assert.AreEqual(0, testingTarget.ScrollPrePositionMax.X);
            Assert.AreEqual(0, testingTarget.ScrollPrePositionMax.Y);

            using (Vector2 vector = new Vector2(80, 100))
            {
                testingTarget.ScrollPrePositionMax = vector;
                Assert.AreEqual(80, testingTarget.ScrollPrePositionMax.X);
                Assert.AreEqual(100, testingTarget.ScrollPrePositionMax.Y);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewScrollPrePositionMax END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView OvershootX.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.OvershootX A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewOvershootX()
        {
            tlog.Debug(tag, $"ScrollViewOvershootX START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            Assert.AreEqual(0, testingTarget.OvershootX);

            testingTarget.OvershootX = 1.5f;
            Assert.AreEqual(1.5f, testingTarget.OvershootX);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewOvershootX END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView OvershootY.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.OvershootY A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewOvershootY()
        {
            tlog.Debug(tag, $"ScrollViewOvershootY START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            Assert.AreEqual(0, testingTarget.OvershootY);

            testingTarget.OvershootY = 1.5f;
            Assert.AreEqual(1.5f, testingTarget.OvershootY);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewOvershootY END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView ScrollFinal.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollFinal A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewScrollFinal()
        {
            tlog.Debug(tag, $"ScrollViewScrollFinal START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            Assert.AreEqual(0, testingTarget.ScrollFinal.X);
            Assert.AreEqual(0, testingTarget.ScrollFinal.Y);

            using (Vector2 vector = new Vector2(80, 100))
            {
                testingTarget.ScrollFinal = vector;
                Assert.AreEqual(80, testingTarget.ScrollFinal.X);
                Assert.AreEqual(100, testingTarget.ScrollFinal.Y);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewScrollFinal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView Wrap.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Wrap A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewWrap()
        {
            tlog.Debug(tag, $"ScrollViewWrap START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            Assert.AreEqual(false, testingTarget.Wrap);

            testingTarget.Wrap = true;
            Assert.AreEqual(true, testingTarget.Wrap);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewWrap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView Panning.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Panning A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewPanning()
        {
            tlog.Debug(tag, $"ScrollViewPanning START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            Assert.AreEqual(false, testingTarget.Panning);

            testingTarget.Panning = true;
            Assert.AreEqual(true, testingTarget.Panning);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewPanning END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView Scrolling.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Scrolling A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewScrolling()
        {
            tlog.Debug(tag, $"ScrollViewScrolling START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            Assert.AreEqual(false, testingTarget.Scrolling);

            testingTarget.Scrolling = true;
            Assert.AreEqual(true, testingTarget.Scrolling);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewScrolling END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView ScrollDomainSize.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollDomainSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewScrollDomainSize()
        {
            tlog.Debug(tag, $"ScrollViewScrollDomainSize START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            Assert.AreEqual(0, testingTarget.ScrollDomainSize.X);
            Assert.AreEqual(0, testingTarget.ScrollDomainSize.Y);

            using (Vector2 vector = new Vector2(80, 100))
            {
                testingTarget.ScrollDomainSize = vector;
                Assert.AreEqual(80, testingTarget.ScrollDomainSize.X);
                Assert.AreEqual(100, testingTarget.ScrollDomainSize.Y);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewScrollDomainSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView ScrollDomainOffset.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollDomainOffset A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewScrollDomainOffset()
        {
            tlog.Debug(tag, $"ScrollViewScrollDomainOffset START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            Assert.AreEqual(0, testingTarget.ScrollDomainOffset.X);
            Assert.AreEqual(0, testingTarget.ScrollDomainOffset.Y);

            using (Vector2 vector = new Vector2(80, 100))
            {
                testingTarget.ScrollDomainOffset = vector;
                Assert.AreEqual(80, testingTarget.ScrollDomainOffset.X);
                Assert.AreEqual(100, testingTarget.ScrollDomainOffset.Y);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewScrollDomainOffset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView ScrollPositionDelta.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollPositionDelta A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewScrollPositionDelta()
        {
            tlog.Debug(tag, $"ScrollViewScrollPositionDelta START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            Assert.AreEqual(0, testingTarget.ScrollPositionDelta.X);
            Assert.AreEqual(0, testingTarget.ScrollPositionDelta.Y);

            using (Vector2 vector = new Vector2(80, 100))
            {
                testingTarget.ScrollPositionDelta = vector;
                Assert.AreEqual(80, testingTarget.ScrollPositionDelta.X);
                Assert.AreEqual(100, testingTarget.ScrollPositionDelta.Y);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewScrollPositionDelta END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView StartPagePosition.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.StartPagePosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewStartPagePosition()
        {
            tlog.Debug(tag, $"ScrollViewStartPagePosition START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            Assert.AreEqual(0, testingTarget.StartPagePosition.X);
            Assert.AreEqual(0, testingTarget.StartPagePosition.Y);
            Assert.AreEqual(0, testingTarget.StartPagePosition.Z);

            using (Vector3 vector = new Vector3(50, 80, 100))
            {
                testingTarget.StartPagePosition = vector;
                Assert.AreEqual(50, testingTarget.StartPagePosition.X);
                Assert.AreEqual(80, testingTarget.StartPagePosition.Y);
                Assert.AreEqual(100, testingTarget.StartPagePosition.Z);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewStartPagePosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView ScrollMode.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewScrollMode()
        {
            tlog.Debug(tag, $"ScrollViewScrollMode START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            using (PropertyMap map = new PropertyMap())
            {
                using (PropertyValue value = new PropertyValue("horizontal"))
                {
                    map.Add("direction", value);
                    testingTarget.ScrollMode = map;

                    Assert.IsNotNull(testingTarget.ScrollMode);
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewScrollMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView GetScrollSnapAlphaFunction.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetScrollSnapAlphaFunction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewGetScrollSnapAlphaFunction()
        {
            tlog.Debug(tag, $"ScrollViewGetScrollSnapAlphaFunction START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            var result = testingTarget.GetScrollSnapAlphaFunction();
            Assert.IsNotNull(result, "Can't create success object AlphaFunction");
            Assert.IsInstanceOf<AlphaFunction>(result, "Should be an instance of AlphaFunction type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewGetScrollSnapAlphaFunction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetScrollSnapAlphaFunction.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetScrollSnapAlphaFunction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetScrollSnapAlphaFunction()
        {
            tlog.Debug(tag, $"ScrollViewSetScrollSnapAlphaFunction START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            using (AlphaFunction alpha = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInSine))
            {
                testingTarget.SetScrollSnapAlphaFunction(alpha);
                Assert.IsNotNull(testingTarget.GetScrollSnapAlphaFunction());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetScrollSnapAlphaFunction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView GetScrollFlickAlphaFunction.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetScrollFlickAlphaFunction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewGetScrollFlickAlphaFunction()
        {
            tlog.Debug(tag, $"ScrollViewGetScrollFlickAlphaFunction START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            var result = testingTarget.GetScrollFlickAlphaFunction();
            Assert.IsNotNull(result, "Can't create success object AlphaFunction");
            Assert.IsInstanceOf<AlphaFunction>(result, "Should be an instance of AlphaFunction type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewGetScrollFlickAlphaFunction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetScrollFlickAlphaFunction.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetScrollFlickAlphaFunction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetScrollFlickAlphaFunction()
        {
            tlog.Debug(tag, $"ScrollViewSetScrollFlickAlphaFunction START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            using (AlphaFunction alpha = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutBack))
            {
                testingTarget.SetScrollFlickAlphaFunction(alpha);
                Assert.IsNotNull(testingTarget.GetScrollFlickAlphaFunction());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetScrollFlickAlphaFunction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView GetScrollSnapDuration.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetScrollSnapDuration M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewGetScrollSnapDuration()
        {
            tlog.Debug(tag, $"ScrollViewGetScrollSnapDuration START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            var result = testingTarget.GetScrollSnapDuration();
            Assert.IsNotNull(result, "Can't create success object AlphaFunction");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewGetScrollSnapDuration END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetScrollSnapDuration.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetScrollSnapDuration M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetScrollSnapDuration()
        {
            tlog.Debug(tag, $"ScrollViewSetScrollSnapDuration START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            testingTarget.SetScrollSnapDuration(1.5f);
            Assert.AreEqual(1.5f, testingTarget.GetScrollSnapDuration(), "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetScrollSnapDuration END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView GetScrollFlickDuration.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetScrollFlickDuration M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewGetScrollFlickDuration()
        {
            tlog.Debug(tag, $"ScrollViewGetScrollFlickDuration START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            var result = testingTarget.GetScrollFlickDuration();
            Assert.IsNotNull(result, "Can't create success object AlphaFunction");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewGetScrollFlickDuration END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetScrollFlickDuration.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetScrollFlickDuration M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetScrollFlickDuration()
        {
            tlog.Debug(tag, $"ScrollViewSetScrollFlickDuration START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            testingTarget.SetScrollFlickDuration(1.5f);
            Assert.AreEqual(1.5f, testingTarget.GetScrollFlickDuration(), "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetScrollFlickDuration END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetScrollSensitive.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetScrollSensitive M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetScrollSensitive()
        {
            tlog.Debug(tag, $"ScrollViewSetScrollSensitive START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                testingTarget.SetScrollSensitive(true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetScrollSensitive END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetMaxOvershoot.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetMaxOvershoot M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetMaxOvershoot()
        {
            tlog.Debug(tag, $"ScrollViewSetMaxOvershoot START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                testingTarget.SetMaxOvershoot(0.2f, 0.4f);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetMaxOvershoot END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetSnapOvershootAlphaFunction.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetSnapOvershootAlphaFunction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetSnapOvershootAlphaFunction()
        {
            tlog.Debug(tag, $"ScrollViewSetSnapOvershootAlphaFunction START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                using (AlphaFunction alpha = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutBack))
                {
                    testingTarget.SetSnapOvershootAlphaFunction(alpha);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetSnapOvershootAlphaFunction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetSnapOvershootDuration.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetSnapOvershootDuration M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetSnapOvershootDuration()
        {
            tlog.Debug(tag, $"ScrollViewSetSnapOvershootDuration START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                testingTarget.SetSnapOvershootDuration(0.8f);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetSnapOvershootDuration END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetViewAutoSnap.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetViewAutoSnap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetViewAutoSnap()
        {
            tlog.Debug(tag, $"ScrollViewSetViewAutoSnap START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                testingTarget.SetViewAutoSnap(true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetViewAutoSnap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetWrapMode.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetWrapMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetWrapMode()
        {
            tlog.Debug(tag, $"ScrollViewSetWrapMode START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                testingTarget.SetWrapMode(true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetWrapMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView GetScrollUpdateDistance.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetScrollUpdateDistance M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewGetScrollUpdateDistance()
        {
            tlog.Debug(tag, $"ScrollViewGetScrollUpdateDistance START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                var result = testingTarget.GetScrollUpdateDistance();
                Assert.IsNotNull(result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewGetScrollUpdateDistance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetScrollUpdateDistance.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetScrollUpdateDistance M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetScrollUpdateDistance()
        {
            tlog.Debug(tag, $"ScrollViewSetScrollUpdateDistance START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                testingTarget.SetScrollUpdateDistance(50);
                Assert.AreEqual(50, testingTarget.GetScrollUpdateDistance(), "Should be equal!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetScrollUpdateDistance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetAxisAutoLock.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetAxisAutoLock M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetAxisAutoLock()
        {
            tlog.Debug(tag, $"ScrollViewSetAxisAutoLock START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                testingTarget.SetAxisAutoLock(true);
                Assert.AreEqual(true, testingTarget.GetAxisAutoLock(), "Should be equal!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetAxisAutoLock END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetAxisAutoLockGradient.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetAxisAutoLockGradient M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetAxisAutoLockGradient()
        {
            tlog.Debug(tag, $"ScrollViewSetAxisAutoLockGradient START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                testingTarget.SetAxisAutoLockGradient(0.6f);
                Assert.AreEqual(0.6f, testingTarget.GetAxisAutoLockGradient(), "Should be equal!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetAxisAutoLockGradient END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetFrictionCoefficient.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetFrictionCoefficient M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetFrictionCoefficient()
        {
            tlog.Debug(tag, $"ScrollViewSetFrictionCoefficient START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                testingTarget.SetFrictionCoefficient(0.6f);
                Assert.AreEqual(0.6f, testingTarget.GetFrictionCoefficient(), "Should be equal!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetFrictionCoefficient END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetFlickSpeedCoefficient.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetFlickSpeedCoefficient M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetFlickSpeedCoefficient()
        {
            tlog.Debug(tag, $"ScrollViewSetFlickSpeedCoefficient START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                testingTarget.SetFlickSpeedCoefficient(0.6f);
                Assert.AreEqual(0.6f, testingTarget.GetFlickSpeedCoefficient(), "Should be equal!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetFlickSpeedCoefficient END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetMinimumDistanceForFlick.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetMinimumDistanceForFlick M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetMinimumDistanceForFlick()
        {
            tlog.Debug(tag, $"ScrollViewSetMinimumDistanceForFlick START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                using (Vector2 vector = new Vector2(0.3f, 0.5f))
                {
                    testingTarget.SetMinimumDistanceForFlick(vector);
                    Assert.IsNotNull(testingTarget.GetMinimumDistanceForFlick().X);
                    Assert.IsNotNull(testingTarget.GetMinimumDistanceForFlick().Y);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetMinimumDistanceForFlick END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetMinimumSpeedForFlick.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetMinimumSpeedForFlick M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetMinimumSpeedForFlick()
        {
            tlog.Debug(tag, $"ScrollViewSetMinimumSpeedForFlick START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                testingTarget.SetMinimumSpeedForFlick(0.6f);
                Assert.AreEqual(0.6f, testingTarget.GetMinimumSpeedForFlick(), "Should be equal!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetMinimumSpeedForFlick END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetMaxFlickSpeed.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetMaxFlickSpeed M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetMaxFlickSpeed()
        {
            tlog.Debug(tag, $"ScrollViewSetMaxFlickSpeed START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                testingTarget.SetMaxFlickSpeed(2.0f);
                Assert.AreEqual(2.0f, testingTarget.GetMaxFlickSpeed(), "Should be equal!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetMaxFlickSpeed END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView GetCurrentScrollPosition.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetCurrentScrollPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewGetCurrentScrollPosition()
        {
            tlog.Debug(tag, $"ScrollViewGetCurrentScrollPosition START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                var result =  testingTarget.GetCurrentScrollPosition();
                Assert.IsNotNull(result.X);
                Assert.IsNotNull(result.Y);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewGetCurrentScrollPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView GetCurrentPage.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetCurrentPage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewGetCurrentPage()
        {
            tlog.Debug(tag, $"ScrollViewGetCurrentPage START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                var result = testingTarget.GetCurrentPage();
                Assert.IsNotNull(result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewGetCurrentPage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView ScrollTo.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewScrollTo()
        {
            tlog.Debug(tag, $"ScrollViewScrollTo START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                using (Vector2 vector = new Vector2(0.3f, 0.5f))
                {
                    testingTarget.ScrollTo(vector);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewScrollTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView ScrollTo. With duration.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewScrollToSpecifyDuration()
        {
            tlog.Debug(tag, $"ScrollViewScrollToSpecifyDuration START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                using (Vector2 vector = new Vector2(0.3f, 0.5f))
                {
                    testingTarget.ScrollTo(vector, 300);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewScrollToSpecifyDuration END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView ScrollToSnapPoint.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollToSnapPoint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewScrollToSnapPoint()
        {
            tlog.Debug(tag, $"ScrollViewScrollToSnapPoint START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            try
            {
                var result = testingTarget.ScrollToSnapPoint();
                Assert.IsNotNull(result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewScrollToSnapPoint END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView ApplyEffect.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ApplyEffect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewApplyEffect()
        {
            tlog.Debug(tag, $"ScrollViewApplyEffect START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            using (Path path = new Path())
            {
                using (Vector2 stageSize = Window.Instance.WindowSize)
                {
                    using (Vector3 TABLE_RELATIVE_SIZE = new Vector3(0.95f, 0.9f, 0.8f))
                    {
                        ScrollViewPagePathEffect effect = new ScrollViewPagePathEffect(path,
                                                             new Vector3(-1.0f, 0.0f, 0.0f),
                                                             ScrollView.Property.ScrollFinalX,
                                                             new Vector3(stageSize.X * TABLE_RELATIVE_SIZE.X, stageSize.Y * TABLE_RELATIVE_SIZE.Y, 0.0f),
                                                             3);
                        try
                        {
                            testingTarget.ApplyEffect(effect);
                        }
                        catch (Exception e)
                        {
                            tlog.Debug(tag, e.Message.ToString());
                            Assert.Fail("Caught Exception: Failed!");
                        }
                    }
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewApplyEffect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView RemoveEffect.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.RemoveEffect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewRemoveEffect()
        {
            tlog.Debug(tag, $"ScrollViewRemoveEffect START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            using (Path path = new Path())
            {
                using (Vector2 stageSize = Window.Instance.WindowSize)
                {
                    using (Vector3 TABLE_RELATIVE_SIZE = new Vector3(0.95f, 0.9f, 0.8f))
                    {
                        ScrollViewPagePathEffect effect = new ScrollViewPagePathEffect(path,
                                                             new Vector3(-1.0f, 0.0f, 0.0f),
                                                             ScrollView.Property.ScrollFinalX,
                                                             new Vector3(stageSize.X * TABLE_RELATIVE_SIZE.X, stageSize.Y * TABLE_RELATIVE_SIZE.Y, 0.0f),
                                                             3);
                        testingTarget.ApplyEffect(effect);

                        try
                        {
                            testingTarget.RemoveEffect(effect);
                        }
                        catch (Exception e)
                        {
                            tlog.Debug(tag, e.Message.ToString());
                            Assert.Fail("Caught Exception: Failed!");
                        }
                    }
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewRemoveEffect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView BindView.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.BindView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewBindView()
        {
            tlog.Debug(tag, $"ScrollViewBindView START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            using (View view = new View())
            {
                view.Size = new Size(80, 120);

                try
                {
                    testingTarget.BindView(view);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewBindView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView UnbindView.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.UnbindView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewUnbindView()
        {
            tlog.Debug(tag, $"ScrollViewUnbindView START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            using (View view = new View())
            {
                view.Size = new Size(80, 120);
                testingTarget.BindView(view);

                try
                {
                    testingTarget.UnbindView(view);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewUnbindView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetScrollingDirection.  With threshold.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetScrollingDirection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetScrollingDirectionWithThreshold()
        {
            tlog.Debug(tag, $"ScrollViewSetScrollingDirectionWithThreshold START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            using (Radian direction = new Radian(2.0f))
            {
                using (Radian threshold = new Radian(4.5f))
                {
                    try
                    {
                        testingTarget.SetScrollingDirection(direction, threshold);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception: Failed!");
                    }
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetScrollingDirectionWithThreshold END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetScrollingDirection.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetScrollingDirection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetScrollingDirection()
        {
            tlog.Debug(tag, $"ScrollViewSetScrollingDirection START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            using (Radian direction = new Radian(2.0f))
            {
                    try
                    {
                        testingTarget.SetScrollingDirection(direction);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception: Failed!");
                    }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetScrollingDirection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView RemoveScrollingDirection.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetScrollingDirection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewRemoveScrollingDirection()
        {
            tlog.Debug(tag, $"ScrollViewRemoveScrollingDirection START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            using (Radian direction = new Radian(2.0f))
            {
                testingTarget.SetScrollingDirection(direction);

                try
                {
                    testingTarget.RemoveScrollingDirection(direction);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewRemoveScrollingDirection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollView SetRulerX.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetRulerX M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewSetRulerX()
        {
            tlog.Debug(tag, $"ScrollViewSetRulerX START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            using (TableView page = new TableView(3, 2))
            {
                testingTarget.Add(page);

                try
                {
                    testingTarget.SetRulerX(new RulerPtr(new FixedRuler(1024.0f)));
                    testingTarget.SetRulerY(new RulerPtr(new DefaultRuler()));
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewSetRulerX END (OK)");
        }
    }
}

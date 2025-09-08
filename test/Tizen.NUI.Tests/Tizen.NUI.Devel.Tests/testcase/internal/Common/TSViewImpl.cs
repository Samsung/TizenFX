using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ViewImpl")]
    public class InternalViewImplTest
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
        [Description("ViewImpl New.")]
        [Property("SPEC", "Tizen.NUI.ViewImpl.New M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewImplNew()
        {
            tlog.Debug(tag, $"ViewImplNew START");

            var testingTarget = ViewImpl.New();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<View>(testingTarget, "Should return View instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewImplNew END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewImpl SetStyleName.")]
        [Property("SPEC", "Tizen.NUI.ViewImpl.SetStyleName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewImplSetStyleName()
        {
            tlog.Debug(tag, $"ViewImplSetStyleName START");

            using (ViewWrapperImpl impl = new ViewWrapperImpl(CustomViewBehaviour.ViewBehaviourDefault))
            {
                var testingTarget = new ViewWrapper("CustomView", impl);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<ViewWrapper>(testingTarget, "should be an instance of testing target class!");

                testingTarget.viewWrapperImpl.SetStyleName("style");
                var result = testingTarget.viewWrapperImpl.GetStyleName();
                tlog.Debug(tag, "StyleName : " + result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ViewImplSetStyleName END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewImpl SetBackgroundColor.")]
        [Property("SPEC", "Tizen.NUI.ViewImpl.SetBackgroundColor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewImplSetBackgroundColor()
        {
            tlog.Debug(tag, $"ViewImplSetBackgroundColor START");

            using (ViewWrapperImpl impl = new ViewWrapperImpl(CustomViewBehaviour.ViewBehaviourDefault))
            {
                var testingTarget = new ViewWrapper("CustomView", impl);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<ViewWrapper>(testingTarget, "should be an instance of testing target class!");

                using (Vector4 color = new Vector4(0.3f, 0.5f, 0.9f, 1.0f))
                {
                    testingTarget.viewWrapperImpl.SetBackgroundColor(color);
                    //tlog.Debug(tag, "BackgroundColor : " + wrapper.viewWrapperImpl.GetBackgroundColor());
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ViewImplSetBackgroundColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewImpl SetBackground.")]
        [Property("SPEC", "Tizen.NUI.ViewImpl.SetBackground M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewImplSetBackground()
        {
            tlog.Debug(tag, $"ViewImplSetBackground START");

            using (ViewWrapperImpl impl = new ViewWrapperImpl(CustomViewBehaviour.ViewBehaviourDefault))
            {
                var testingTarget = new ViewWrapper("CustomView", impl);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<ViewWrapper>(testingTarget, "should be an instance of testing target class!");

                using (ColorVisual colorVisual = new ColorVisual())
                {
                    colorVisual.Color = Color.Cyan;

                    try
                    {
                        testingTarget.viewWrapperImpl.SetBackground(colorVisual.OutputVisualMap);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception : Failed!");
                    }
                }

                testingTarget.viewWrapperImpl.ClearBackground();

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ViewImplSetBackground END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewImpl EnableGestureDetection.")]
        [Property("SPEC", "Tizen.NUI.ViewImpl.EnableGestureDetection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewImplEnableGestureDetection()
        {
            tlog.Debug(tag, $"ViewImplEnableGestureDetection START");

            using (ViewWrapperImpl impl = new ViewWrapperImpl(CustomViewBehaviour.ViewBehaviourDefault))
            {
                var testingTarget = new ViewWrapper("CustomView", impl);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<ViewWrapper>(testingTarget, "should be an instance of testing target class!");

                try
                {
                    testingTarget.viewWrapperImpl.EnableGestureDetection(Gesture.GestureType.LongPress);
                    testingTarget.viewWrapperImpl.DisableGestureDetection(Gesture.GestureType.LongPress);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ViewImplEnableGestureDetection (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewImpl GetPinchGestureDetector.")]
        [Property("SPEC", "Tizen.NUI.ViewImpl.GetPinchGestureDetector M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewImplGetGestureDetector()
        {
            tlog.Debug(tag, $"ViewImplGetGestureDetector START");

            using (ViewWrapperImpl impl = new ViewWrapperImpl(CustomViewBehaviour.ViewBehaviourDefault))
            {
                var testingTarget = new ViewWrapper("CustomView", impl);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<ViewWrapper>(testingTarget, "should be an instance of testing target class!");

                var pinchGesture = testingTarget.viewWrapperImpl.GetPinchGestureDetector();
                Assert.IsInstanceOf<PinchGestureDetector>(pinchGesture, "should be an instance of testing target class!");

                var panGesture = testingTarget.viewWrapperImpl.GetPanGestureDetector();
                Assert.IsInstanceOf<PanGestureDetector>(panGesture, "should be an instance of testing target class!");

                var tapGesture = testingTarget.viewWrapperImpl.GetTapGestureDetector();
                Assert.IsInstanceOf<TapGestureDetector>(tapGesture, "should be an instance of testing target class!");

                var pressGesture = testingTarget.viewWrapperImpl.GetLongPressGestureDetector();
                Assert.IsInstanceOf<LongPressGestureDetector>(pressGesture, "should be an instance of testing target class!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ViewImplGetGestureDetector (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewImpl SetKeyInputFocus.")]
        [Property("SPEC", "Tizen.NUI.ViewImpl.SetKeyInputFocus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewImplSetKeyInputFocus()
        {
            tlog.Debug(tag, $"ViewImplSetKeyInputFocus START");

            using (ViewWrapperImpl impl = new ViewWrapperImpl(CustomViewBehaviour.ViewBehaviourDefault))
            {
                var testingTarget = new ViewWrapper("CustomView", impl);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<ViewWrapper>(testingTarget, "should be an instance of testing target class!");

                testingTarget.viewWrapperImpl.SetKeyInputFocus();
                var result = testingTarget.viewWrapperImpl.HasKeyInputFocus();
                tlog.Debug(tag, "HasKeyInputFocus : " + result);
                testingTarget.viewWrapperImpl.ClearKeyInputFocus();

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ViewImplSetKeyInputFocus (OK)");
        }
        
        [Test]
        [Category("P1")]
        [Description("ViewImpl OnInitialize.")]
        [Property("SPEC", "Tizen.NUI.ViewImpl.OnInitialize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewImplOnInitialize()
        {
            tlog.Debug(tag, $"ViewImplOnInitialize START");

            using (ViewWrapperImpl impl = new ViewWrapperImpl(CustomViewBehaviour.ViewBehaviourDefault))
            {
                var testingTarget = new ViewWrapper("CustomView", impl);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<ViewWrapper>(testingTarget, "should be an instance of testing target class!");

                testingTarget.viewWrapperImpl.OnInitialize();

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ViewImplOnInitialize (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewImpl OnAccessibilityActivated.")]
        [Property("SPEC", "Tizen.NUI.ViewImpl.OnAccessibilityActivated M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewImplOnAccessibilityActivated()
        {
            tlog.Debug(tag, $"ViewImplOnAccessibilityActivated START");

            var testingTarget = NDalic.GetImplementation(new View());
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ViewImpl>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.OnAccessibilityActivated();
            Assert.IsTrue(!result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewImplOnAccessibilityActivated (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewImpl OnKeyboardEnter.")]
        [Property("SPEC", "Tizen.NUI.ViewImpl.OnKeyboardEnter M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewImplOnKeyboardEnter()
        {
            tlog.Debug(tag, $"ViewImplOnKeyboardEnter START");

            var testingTarget = NDalic.GetImplementation(new View());
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ViewImpl>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.OnKeyboardEnter();
            Assert.IsTrue(!result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewImplOnKeyboardEnter (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewImpl OnKeyInputFocusGained.")]
        [Property("SPEC", "Tizen.NUI.ViewImpl.OnKeyInputFocusGained M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewImplOnKeyInputFocusGained()
        {
            tlog.Debug(tag, $"ViewImplOnKeyInputFocusGained START");

            using (ViewWrapperImpl impl = new ViewWrapperImpl(CustomViewBehaviour.ViewBehaviourDefault))
            {
                var testingTarget = new ViewWrapper("CustomView", impl);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<ViewWrapper>(testingTarget, "should be an instance of testing target class!");

                testingTarget.viewWrapperImpl.OnKeyInputFocusGained();

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ViewImplOnKeyInputFocusGained (OK)");
        }
        
        [Test]
        [Category("P1")]
        [Description("ViewImpl OnKeyInputFocusLost.")]
        [Property("SPEC", "Tizen.NUI.ViewImpl.OnKeyInputFocusLost M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewImplOnKeyInputFocusLost()
        {
            tlog.Debug(tag, $"ViewImplOnKeyInputFocusLost START");

            using (ViewWrapperImpl impl = new ViewWrapperImpl(CustomViewBehaviour.ViewBehaviourDefault))
            {
                var testingTarget = new ViewWrapper("CustomView", impl);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<ViewWrapper>(testingTarget, "should be an instance of testing target class!");

                testingTarget.viewWrapperImpl.OnKeyInputFocusLost();

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ViewImplOnKeyInputFocusLost (OK)");
        }
    }
}

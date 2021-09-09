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
        [Description("ViewImpl getCPtr.")]
        [Property("SPEC", "Tizen.NUI.ViewImpl.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewImplGetCPtr()
        {
            tlog.Debug(tag, $"ViewImplGetCPtr START");

            using (ViewWrapperImpl impl = new ViewWrapperImpl(CustomViewBehaviour.ViewBehaviourDefault))
            {
                var testingTarget = new ViewWrapper("CustomView", impl);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<ViewWrapper>(testingTarget, "should be an instance of testing target class!");

                var result = ViewWrapperImpl.getCPtr(testingTarget.viewWrapperImpl);
                tlog.Debug(tag, "getCptr : " + result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ViewImplGetCPtr END (OK)");
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
        [Description("ViewImpl KeyEventSignal.")]
        [Property("SPEC", "Tizen.NUI.ViewImpl.KeyEventSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewImplSignal()
        {
            tlog.Debug(tag, $"ViewImplSignal START");

            using (ViewWrapperImpl impl = new ViewWrapperImpl(CustomViewBehaviour.ViewBehaviourDefault))
            {
                var testingTarget = new ViewWrapper("CustomView", impl);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<ViewWrapper>(testingTarget, "should be an instance of testing target class!");

                var signal = testingTarget.viewWrapperImpl.KeyEventSignal();
                Assert.IsInstanceOf<ControlKeySignal>(signal, "Should return ControlKeySignal instance.");

                var focusGained = testingTarget.viewWrapperImpl.KeyInputFocusGainedSignal();
                Assert.IsInstanceOf<KeyInputFocusSignal>(focusGained, "Should return ControlKeySignal instance.");

                var focusLost = testingTarget.viewWrapperImpl.KeyInputFocusLostSignal();
                Assert.IsInstanceOf<KeyInputFocusSignal>(focusLost, "Should return ControlKeySignal instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ViewImplSignal (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("ViewImpl EmitKeyEventSignal.")]
        //[Property("SPEC", "Tizen.NUI.ViewImpl.EmitKeyEventSignal M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void ViewImplEmitKeyEventSignal()
        //{
        //    tlog.Debug(tag, $"ViewImplEmitKeyEventSignal START");

        //    using (ViewWrapperImpl impl = new ViewWrapperImpl(CustomViewBehaviour.ViewBehaviourDefault))
        //    {
        //        var testingTarget = new ViewWrapper("CustomView", impl);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<ViewWrapper>(testingTarget, "should be an instance of testing target class!");

        //        using (Key key = new Key())
        //        {
        //            var result = testingTarget.viewWrapperImpl.EmitKeyEventSignal(key);
        //            tlog.Debug(tag, "EmitKeyEventSignal : " + result);
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"ViewImplEmitKeyEventSignal (OK)");
        //}
    }
}

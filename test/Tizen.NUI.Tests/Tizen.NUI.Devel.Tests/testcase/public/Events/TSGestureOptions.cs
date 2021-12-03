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
    [Description("public/Events/GestureOptions")]
    public class PublicGestureOptionsTest
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
        [Description("GestureOptions Instance.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.Instance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsInstance()
        {
            tlog.Debug(tag, $"GestureOptionsInstance START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            tlog.Debug(tag, $"GestureOptionsInstance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPanGesturePredictionMode.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPanGesturePredictionMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPanGesturePredictionMode()
        {
            tlog.Debug(tag, $"GestureOptionsSetPanGesturePredictionMode START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPanGesturePredictionMode(0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPanGesturePredictionMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPanGesturePredictionAmount.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPanGesturePredictionAmount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPanGesturePredictionAmount()
        {
            tlog.Debug(tag, $"GestureOptionsSetPanGesturePredictionAmount START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPanGesturePredictionMode(1);
                testingTarget.SetPanGesturePredictionAmount(300);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPanGesturePredictionAmount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPanGestureMaximumPredictionAmount.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPanGestureMaximumPredictionAmount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPanGestureMaximumPredictionAmount()
        {
            tlog.Debug(tag, $"GestureOptionsSetPanGestureMaximumPredictionAmount START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPanGestureMaximumPredictionAmount(1000);
                testingTarget.SetPanGestureMinimumPredictionAmount(0);
                testingTarget.SetPanGesturePredictionAmountAdjustment(500);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPanGestureMaximumPredictionAmount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPanGestureSmoothingMode.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPanGestureSmoothingMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPanGestureSmoothingMode()
        {
            tlog.Debug(tag, $"GestureOptionsSetPanGestureSmoothingMode START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPanGestureSmoothingMode(0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPanGestureSmoothingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPanGestureSmoothingAmount.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPanGestureSmoothingAmount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPanGestureSmoothingAmount()
        {
            tlog.Debug(tag, $"GestureOptionsSetPanGestureSmoothingAmount START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPanGestureSmoothingAmount(1.0f);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPanGestureSmoothingAmount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPanGestureUseActualTimes.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPanGestureUseActualTimes M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPanGestureUseActualTimes()
        {
            tlog.Debug(tag, $"GestureOptionsSetPanGestureUseActualTimes START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPanGestureUseActualTimes(true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPanGestureUseActualTimes END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPanGestureInterpolationTimeRange.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPanGestureInterpolationTimeRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPanGestureInterpolationTimeRange()
        {
            tlog.Debug(tag, $"GestureOptionsSetPanGestureInterpolationTimeRange START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPanGestureInterpolationTimeRange(5000);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPanGestureInterpolationTimeRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPanGestureScalarOnlyPredictionEnabled.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPanGestureScalarOnlyPredictionEnabled M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPanGestureScalarOnlyPredictionEnabled()
        {
            tlog.Debug(tag, $"GestureOptionsSetPanGestureScalarOnlyPredictionEnabled START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPanGestureScalarOnlyPredictionEnabled(true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPanGestureScalarOnlyPredictionEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPanGestureTwoPointPredictionEnabled.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPanGestureTwoPointPredictionEnabled M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPanGestureTwoPointPredictionEnabled()
        {
            tlog.Debug(tag, $"GestureOptionsSetPanGestureTwoPointPredictionEnabled START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPanGestureTwoPointPredictionEnabled(true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPanGestureTwoPointPredictionEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPanGestureTwoPointInterpolatePastTime.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPanGestureTwoPointInterpolatePastTime M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPanGestureTwoPointInterpolatePastTime()
        {
            tlog.Debug(tag, $"GestureOptionsSetPanGestureTwoPointInterpolatePastTime START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPanGestureTwoPointInterpolatePastTime(100);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPanGestureTwoPointInterpolatePastTimed END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPanGestureTwoPointVelocityBias.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPanGestureTwoPointVelocityBias M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPanGestureTwoPointVelocityBias()
        {
            tlog.Debug(tag, $"GestureOptionsSetPanGestureTwoPointVelocityBias START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPanGestureTwoPointVelocityBias(0.8f);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPanGestureTwoPointVelocityBias END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPanGestureTwoPointAccelerationBias.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPanGestureTwoPointAccelerationBias M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPanGestureTwoPointAccelerationBias()
        {
            tlog.Debug(tag, $"GestureOptionsSetPanGestureTwoPointAccelerationBias START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPanGestureTwoPointAccelerationBias(0.8f);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPanGestureTwoPointAccelerationBias END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPanGestureMultitapSmoothingRange.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPanGestureMultitapSmoothingRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPanGestureMultitapSmoothingRange()
        {
            tlog.Debug(tag, $"GestureOptionsSetPanGestureMultitapSmoothingRange START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPanGestureMultitapSmoothingRange(1000);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPanGestureMultitapSmoothingRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPanGestureMinimumDistance.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPanGestureMinimumDistance M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPanGestureMinimumDistance()
        {
            tlog.Debug(tag, $"GestureOptionsSetPanGestureMinimumDistance START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPanGestureMinimumDistance(1000);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPanGestureMinimumDistance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPanGestureMinimumPanEvents.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPanGestureMinimumPanEvents M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPanGestureMinimumPanEvents()
        {
            tlog.Debug(tag, $"GestureOptionsSetPanGestureMinimumPanEvents START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPanGestureMinimumPanEvents(2);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPanGestureMinimumPanEvents END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPinchGestureMinimumDistance.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPinchGestureMinimumDistance M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPinchGestureMinimumDistance()
        {
            tlog.Debug(tag, $"GestureOptionsSetPinchGestureMinimumDistance START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPinchGestureMinimumDistance(1000);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPinchGestureMinimumDistance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPinchGestureMinimumTouchEvents.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPinchGestureMinimumTouchEvents M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPinchGestureMinimumTouchEvents()
        {
            tlog.Debug(tag, $"GestureOptionsSetPanGestureMinimumPanEvents START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPinchGestureMinimumTouchEvents(2);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPinchGestureMinimumTouchEvents END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetPinchGestureMinimumTouchEventsAfterStart.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetPinchGestureMinimumTouchEventsAfterStart M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetPinchGestureMinimumTouchEventsAfterStart()
        {
            tlog.Debug(tag, $"GestureOptionsSetPinchGestureMinimumTouchEventsAfterStart START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetPinchGestureMinimumTouchEventsAfterStart(2);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetPinchGestureMinimumTouchEventsAfterStart END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetRotationGestureMinimumTouchEvents.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetRotationGestureMinimumTouchEvents M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetRotationGestureMinimumTouchEvents()
        {
            tlog.Debug(tag, $"GestureOptionsSetPinchGestureMinimumTouchEventsAfterStart START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetRotationGestureMinimumTouchEvents(2);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetRotationGestureMinimumTouchEvents END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetRotationGestureMinimumTouchEventsAfterStart.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetRotationGestureMinimumTouchEventsAfterStart M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetRotationGestureMinimumTouchEventsAfterStart()
        {
            tlog.Debug(tag, $"GestureOptionsSetRotationGestureMinimumTouchEventsAfterStart START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetRotationGestureMinimumTouchEventsAfterStart(2);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetRotationGestureMinimumTouchEventsAfterStart END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetLongPressMinimumHoldingTime.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetLongPressMinimumHoldingTime M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetLongPressMinimumHoldingTime()
        {
            tlog.Debug(tag, $"GestureOptionsSetRotationGestureMinimumTouchEventsAfterStart START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetLongPressMinimumHoldingTime(2000);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetLongPressMinimumHoldingTime END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureOptions SetDoubleTapTimeout.")]
        [Property("SPEC", "Tizen.NUI.GestureOptions.SetDoubleTapTimeout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureOptionsSetDoubleTapTimeout()
        {
            tlog.Debug(tag, $"GestureOptionsSetRotationGestureMinimumTouchEventsAfterStart START");

            var testingTarget = GestureOptions.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<GestureOptions>(testingTarget, "Should be an instance of GestureOptions type.");

            try
            {
                testingTarget.SetDoubleTapTimeout(1000);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GestureOptionsSetDoubleTapTimeout END (OK)");
        }
    }
}

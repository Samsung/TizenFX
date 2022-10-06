using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;
	
    [TestFixture]
    [Description("public/Events/PanGestureDetector")]
    class PublicPanGestureDetectorTest
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
        [Description("Create a PanGestureDetector object. Check whether PanGestureDetector is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.PanGestureDetector C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorConstructor()
        {
            tlog.Debug(tag, $"PanGestureDetectorConstructor START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Create a PanGestureDetector object. Check whether PanGestureDetector is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.PanGestureDetector C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorConstructorWithPanGestureDetector()
        {
            tlog.Debug(tag, $"PanGestureDetectorConstructorWithPanGestureDetector START");

            using (PanGestureDetector detector = new PanGestureDetector())
            {
                var testingTarget = new PanGestureDetector(detector);
                Assert.IsNotNull(testingTarget, "Can't create success object Hover");
                Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PanGestureDetectorConstructorWithPanGestureDetector END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector DirectionLeft.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.DirectionLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorDirectionLeft()
        {
            tlog.Debug(tag, $"PanGestureDetectorDirectionLeft START");
            
            var testingTarget = PanGestureDetector.DirectionLeft;
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should be an instance of Radian type.");

            tlog.Debug(tag, $"PanGestureDetectorDirectionLeft END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector DirectionRight.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.DirectionRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorDirectionRight()
        {
            tlog.Debug(tag, $"PanGestureDetectorDirectionRight START");

            var testingTarget = PanGestureDetector.DirectionRight;
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should be an instance of Radian type.");

            tlog.Debug(tag, $"PanGestureDetectorDirectionRight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector DirectionUp.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.DirectionUp A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorDirectionUp()
        {
            tlog.Debug(tag, $"PanGestureDetectorDirectionUp START");

            var testingTarget = PanGestureDetector.DirectionUp;
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should be an instance of Radian type.");

            tlog.Debug(tag, $"PanGestureDetectorDirectionUp END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector DirectionDown.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.DirectionDown A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorDirectionDown()
        {
            tlog.Debug(tag, $"PanGestureDetectorDirectionDown START");

            var testingTarget = PanGestureDetector.DirectionDown;
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should be an instance of Radian type.");

            tlog.Debug(tag, $"PanGestureDetectorDirectionDown END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector DirectionHorizontal.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.DirectionHorizontal A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorDirectionHorizontal()
        {
            tlog.Debug(tag, $"PanGestureDetectorDirectionHorizontal START");

            var testingTarget = PanGestureDetector.DirectionHorizontal;
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should be an instance of Radian type.");

            tlog.Debug(tag, $"PanGestureDetectorDirectionHorizontal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector DirectionVertical.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.DirectionVertical A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorDirectionVertical()
        {
            tlog.Debug(tag, $"PanGestureDetectorDirectionVertical START");

            var testingTarget = PanGestureDetector.DirectionVertical;
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should be an instance of Radian type.");

            tlog.Debug(tag, $"PanGestureDetectorDirectionVertical END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector DefaultThreshold.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.DefaultThreshold A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorDefaultThreshold()
        {
            tlog.Debug(tag, $"PanGestureDetectorDefaultThreshold START");

            var testingTarget = PanGestureDetector.DefaultThreshold;
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should be an instance of Radian type.");

            tlog.Debug(tag, $"PanGestureDetectorDefaultThreshold END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector ScreenPosition.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.ScreenPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorScreenPosition()
        {
            tlog.Debug(tag, $"PanGestureDetectorScreenPosition START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

            var result = testingTarget.ScreenPosition;
            Assert.IsInstanceOf<Vector2>(result, "Should be an instance of Vector2 type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorScreenPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector ScreenDisplacement.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.ScreenDisplacement A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorScreenDisplacement()
        {
            tlog.Debug(tag, $"PanGestureDetectorScreenDisplacement START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

            var result = testingTarget.ScreenDisplacement;
            Assert.IsInstanceOf<Vector2>(result, "Should be an instance of Vector2 type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorScreenDisplacement END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector ScreenVelocity.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.ScreenVelocity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorScreenVelocity()
        {
            tlog.Debug(tag, $"PanGestureDetectorScreenVelocity START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

            var result = testingTarget.ScreenVelocity;
            Assert.IsInstanceOf<Vector2>(result, "Should be an instance of Vector2 type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorScreenVelocity END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector LocalPosition.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.LocalPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorLocalPosition()
        {
            tlog.Debug(tag, $"PanGestureDetectorLocalPosition START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

            var result = testingTarget.LocalPosition;
            Assert.IsInstanceOf<Vector2>(result, "Should be an instance of Vector2 type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorLocalPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector LocalDisplacement.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.LocalDisplacement A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorLocalDisplacement()
        {
            tlog.Debug(tag, $"PanGestureDetectorLocalDisplacement START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

            var result = testingTarget.LocalDisplacement;
            Assert.IsInstanceOf<Vector2>(result, "Should be an instance of Vector2 type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorLocalDisplacement END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector LocalVelocity.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.LocalVelocity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorLocalVelocity()
        {
            tlog.Debug(tag, $"PanGestureDetectorLocalVelocity START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

            var result = testingTarget.LocalVelocity;
            Assert.IsInstanceOf<Vector2>(result, "Should be an instance of Vector2 type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorLocalVelocity END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector Panning.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.Panning A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorPanning()
        {
            tlog.Debug(tag, $"PanGestureDetectorPanning START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

            var result = testingTarget.Panning;
            tlog.Debug(tag, "Panning : " + result);
            
            tlog.Debug(tag, $"PanGestureDetectorPanning END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector SetMinimumTouchesRequired.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.SetMinimumTouchesRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorSetMinimumTouchesRequired()
        {
            tlog.Debug(tag, $"PanGestureDetectorSetMinimumTouchesRequired START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

            try
            {
                testingTarget.SetMinimumTouchesRequired(2);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorSetMinimumTouchesRequired END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector SetMaximumTouchesRequired.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.SetMaximumTouchesRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorSetMaximumTouchesRequired()
        {
            tlog.Debug(tag, $"PanGestureDetectorSetMaximumTouchesRequired START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

            try
            {
                testingTarget.SetMaximumTouchesRequired(4);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorSetMaximumTouchesRequired END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector SetMaximumMotionEventAge.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.SetMaximumMotionEventAge M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorSetMaximumMotionEventAge()
        {
            tlog.Debug(tag, $"PanGestureDetectorSetMaximumMotionEventAge START");
            
            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should return PanGestureDetector instance.");

            try
			{
                testingTarget.SetMaximumMotionEventAge(4);
            }
			catch(Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorSetMaximumMotionEventAge END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector GetMinimumTouchesRequired.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.GetMinimumTouchesRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorGetMinimumTouchesRequired()
        {
            tlog.Debug(tag, $"PanGestureDetectorGetMinimumTouchesRequired START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should return PanGestureDetector instance.");

            try
            {
                testingTarget.SetMinimumTouchesRequired(4);
                testingTarget.GetMinimumTouchesRequired();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorGetMinimumTouchesRequired END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector GetMaximumTouchesRequired.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.GetMaximumTouchesRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorGetMaximumTouchesRequired()
        {
            tlog.Debug(tag, $"PanGestureDetectorGetMaximumTouchesRequired START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should return PanGestureDetector instance.");

            try
            {
                testingTarget.SetMaximumTouchesRequired(4);
                testingTarget.GetMaximumTouchesRequired();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorGetMaximumTouchesRequired END (OK)");
        }
        
        [Test]
        [Category("P1")]
        [Description("PanGestureDetector GetMaximumMotionEventAge.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.GetMaximumMotionEventAge M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorGetMaximumMotionEventAge()
        {
            tlog.Debug(tag, $"PanGestureDetectorGetMaximumMotionEventAge START");
            
            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should return PanGestureDetector instance.");

            try
			{
                testingTarget.SetMaximumMotionEventAge(16);
                testingTarget.GetMaximumMotionEventAge();
            }
			catch(Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorGetMaximumMotionEventAge END (OK)");
        }		

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector AddAngle.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.AddAngle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorAddAngle()
        {
            tlog.Debug(tag, $"PanGestureDetectorAddAngle START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should return PanGestureDetector instance.");

            using (Radian angle = new Radian(4))
            {
                try
                {
                    testingTarget.AddAngle(angle);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught exception : Failed!");
                }

                using (Radian threshold = new Radian(15))
                {
                    try
                    {
                        testingTarget.AddAngle(angle, threshold);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught exception : Failed!");
                    }
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorAddAngle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector AddDirection.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.AddDirection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorAddDirection()
        {
            tlog.Debug(tag, $"PanGestureDetectorAddDirection START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should return PanGestureDetector instance.");

            using (Radian angle = new Radian(4))
            {
                try
                {
                    testingTarget.AddDirection(angle);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught exception : Failed!");
                }

                using (Radian threshold = new Radian(15))
                {
                    try
                    {
                        testingTarget.AddDirection(angle, threshold);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught exception : Failed!");
                    }
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorAddDirection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector GetAngleCount.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.GetAngleCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorGetAngleCount()
        {
            tlog.Debug(tag, $"PanGestureDetectorGetAngleCount START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should return PanGestureDetector instance.");

            using (Radian angle = new Radian(4))
            {
                testingTarget.AddAngle(angle);
                var result = testingTarget.GetAngleCount();
                tlog.Debug(tag, "GetAngleCount :" + result);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorGetAngleCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector GetAngle.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.GetAngle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorGetAngle()
        {
            tlog.Debug(tag, $"PanGestureDetectorGetAngle START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should return PanGestureDetector instance.");

            using (Radian angle = new Radian(4))
            {
                testingTarget.AddAngle(angle);

                try
                {
                    testingTarget.GetAngle(1);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }
            
            tlog.Debug(tag, $"PanGestureDetectorGetAngle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector ClearAngles.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.ClearAngles M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorClearAngles()
        {
            tlog.Debug(tag, $"PanGestureDetectorClearAngles START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should return PanGestureDetector instance.");

            using (Radian angle = new Radian(4))
            {
                testingTarget.AddAngle(angle);

                try
                {
                    testingTarget.ClearAngles();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorClearAngles END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector RemoveAngle.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.RemoveAngle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorRemoveAngle()
        {
            tlog.Debug(tag, $"PanGestureDetectorRemoveAngle START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should return PanGestureDetector instance.");

            using (Radian angle = new Radian(4))
            {
                testingTarget.AddAngle(angle);

                try
                {
                    testingTarget.RemoveAngle(angle);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorRemoveAngle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector RemoveDirection.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.RemoveDirection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorRemoveDirection()
        {
            tlog.Debug(tag, $"PanGestureDetectorRemoveDirection START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should return PanGestureDetector instance.");

            using (Radian angle = new Radian(4))
            {
                testingTarget.AddDirection(angle);

                try
                {
                    testingTarget.RemoveDirection(angle);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }   
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorRemoveDirection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector SetPanGestureProperties.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.SetPanGestureProperties M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorSetPanGestureProperties()
        {
            tlog.Debug(tag, $"PanGestureDetectorSetPanGestureProperties START");

            using (PanGesture pan = new PanGesture())
            {
                try
                {
                    PanGestureDetector.SetPanGestureProperties(pan);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }
            
            tlog.Debug(tag, $"PanGestureDetectorSetPanGestureProperties END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetector GetPanGestureDetectorFromPtr.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.GetPanGestureDetectorFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorGetPanGestureDetectorFromPtr()
        {
            tlog.Debug(tag, $"PanGestureDetectorGetPanGestureDetectorFromPtr START");

            using (PanGestureDetector detector = new PanGestureDetector())
            {
                var testingTarget = PanGestureDetector.GetPanGestureDetectorFromPtr(detector.SwigCPtr.Handle);
                Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
                Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should return PanGestureDetector instance.");

                testingTarget.Dispose();
            }
           		
            tlog.Debug(tag, $"PanGestureDetectorGetPanGestureDetectorFromPtr END (OK)");
        }

		[Test]
        [Category("P1")]
        [Description("PanGestureDetector DownCast.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorDownCast()
        {
            tlog.Debug(tag, $"PanGestureDetectorDownCast START");

            using (PanGestureDetector detector = new PanGestureDetector())
            {
                var testingTarget = PanGestureDetector.DownCast(detector);
                Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PanGestureDetectorDownCast END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("PanGestureDetector Assign")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorAssign()
        {
            tlog.Debug(tag, $"PanGestureDetectorAssign START");

            using (PanGestureDetector detector = new PanGestureDetector())
            {
                var testingTarget = detector.Assign(detector);
                Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PanGestureDetectorAssign END (OK)");		
        }		

		[Test]
        [Category("P1")]
        [Description("PanGestureDetector Detected.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.Detected A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorDetected()
        {
            tlog.Debug(tag, $"PanGestureDetectorDetected START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should return PanGestureDetector instance.");

            testingTarget.Detected += OnDetected;
            testingTarget.Detected -= OnDetected;

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorDetected END (OK)");
        }		
		
		private void OnDetected(object obj, PanGestureDetector.DetectedEventArgs e)
		{
            View view = e.View;
            e.View = view;

            PanGesture gesture = e.PanGesture;
            e.PanGesture = gesture;

            tlog.Debug(tag, "Handled : " + e.Handled);
        }

        [Test]
        [Category("P1")]
        [Description("DetectedEventArgs View.")]
        [Property("SPEC", "Tizen.NUI.DetectedEventArgs.View A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectedEventArgsView()
        {
            tlog.Debug(tag, $"PanGestureDetectedEventArgsView START");

            var testingTarget = new Tizen.NUI.PanGestureDetector.DetectedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
            Assert.IsInstanceOf<Tizen.NUI.PanGestureDetector.DetectedEventArgs>(testingTarget, "Should return DetectedEventArgs instance.");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                testingTarget.View = view;
                Assert.AreEqual(100, testingTarget.View.Size.Width, "Should be equal!");
            }

            testingTarget.PanGesture = new PanGesture(Gesture.StateType.Possible);
            Assert.AreEqual(Gesture.StateType.Possible, testingTarget.PanGesture.State, "Should be equal!");

            tlog.Debug(tag, "Handled : " + testingTarget.Handled);

            tlog.Debug(tag, $"PanGestureDetectedEventArgsView END (OK)");
        }
    }
}

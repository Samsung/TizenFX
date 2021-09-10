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
            Assert.Pass("PanGestureDetectorConstructor");
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
            Assert.Pass("PanGestureDetectorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Test DirectionLeft property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.DirectionLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorDirectionLeft()
        {
            tlog.Debug(tag, $"PanGestureDetectorDirectionLeft START");
            
            var testingTarget = PanGestureDetector.DirectionLeft;
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should be an instance of Radian type.");

            tlog.Debug(tag, $"PanGestureDetectorDirectionLeft END (OK)");
            Assert.Pass("PanGestureDetectorDirectionLeft");
        }

        [Test]
        [Category("P1")]
        [Description("Test DirectionRight property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.DirectionRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorDirectionRight()
        {
            tlog.Debug(tag, $"PanGestureDetectorDirectionRight START");

            var testingTarget = PanGestureDetector.DirectionRight;
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should be an instance of Radian type.");

            tlog.Debug(tag, $"PanGestureDetectorDirectionRight END (OK)");
            Assert.Pass("PanGestureDetectorDirectionLeft");
        }

        [Test]
        [Category("P1")]
        [Description("Test DirectionUp property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.DirectionUp A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorDirectionUp()
        {
            tlog.Debug(tag, $"PanGestureDetectorDirectionUp START");

            var testingTarget = PanGestureDetector.DirectionUp;
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should be an instance of Radian type.");

            tlog.Debug(tag, $"PanGestureDetectorDirectionUp END (OK)");
            Assert.Pass("PanGestureDetectorDirectionUp");
        }

        [Test]
        [Category("P1")]
        [Description("Test DirectionDown property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.DirectionDown A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorDirectionDown()
        {
            tlog.Debug(tag, $"PanGestureDetectorDirectionDown START");

            var testingTarget = PanGestureDetector.DirectionDown;
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should be an instance of Radian type.");

            tlog.Debug(tag, $"PanGestureDetectorDirectionDown END (OK)");
            Assert.Pass("PanGestureDetectorDirectionDown");
        }

        [Test]
        [Category("P1")]
        [Description("Test DirectionHorizontal property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.DirectionHorizontal A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorDirectionHorizontal()
        {
            tlog.Debug(tag, $"PanGestureDetectorDirectionHorizontal START");

            var testingTarget = PanGestureDetector.DirectionHorizontal;
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should be an instance of Radian type.");

            tlog.Debug(tag, $"PanGestureDetectorDirectionHorizontal END (OK)");
            Assert.Pass("PanGestureDetectorDirectionHorizontal");
        }

        [Test]
        [Category("P1")]
        [Description("Test DirectionVertical property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.DirectionVertical A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorDirectionVertical()
        {
            tlog.Debug(tag, $"PanGestureDetectorDirectionVertical START");

            var testingTarget = PanGestureDetector.DirectionVertical;
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should be an instance of Radian type.");

            tlog.Debug(tag, $"PanGestureDetectorDirectionVertical END (OK)");
            Assert.Pass("PanGestureDetectorDirectionVertical");
        }

        [Test]
        [Category("P1")]
        [Description("Test DefaultThreshold property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.DefaultThreshold A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorDefaultThreshold()
        {
            tlog.Debug(tag, $"PanGestureDetectorDefaultThreshold START");

            var testingTarget = PanGestureDetector.DefaultThreshold;
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should be an instance of Radian type.");

            tlog.Debug(tag, $"PanGestureDetectorDefaultThreshold END (OK)");
            Assert.Pass("PanGestureDetectorDefaultThreshold");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScreenPosition property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.ScreenPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorScreenPosition()
        {
            tlog.Debug(tag, $"PanGestureDetectorScreenPosition START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

            tlog.Debug(tag, "ScreenPosition : " + testingTarget.ScreenPosition);

            tlog.Debug(tag, $"PanGestureDetectorScreenPosition END (OK)");
            Assert.Pass("PanGestureDetectorScreenPosition");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScreenDisplacement property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.ScreenDisplacement A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorScreenDisplacement()
        {
            tlog.Debug(tag, $"PanGestureDetectorScreenDisplacement START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

            tlog.Debug(tag, "ScreenDisplacement : " + testingTarget.ScreenDisplacement);
            
            tlog.Debug(tag, $"PanGestureDetectorScreenDisplacement END (OK)");
            Assert.Pass("PanGestureDetectorScreenDisplacement");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScreenVelocity property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.ScreenVelocity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorScreenVelocity()
        {
            tlog.Debug(tag, $"PanGestureDetectorScreenVelocity START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

            tlog.Debug(tag, "ScreenVelocity : " + testingTarget.ScreenVelocity);

            tlog.Debug(tag, $"PanGestureDetectorScreenVelocity END (OK)");
            Assert.Pass("PanGestureDetectorScreenVelocity");
        }

        [Test]
        [Category("P1")]
        [Description("Test LocalPosition property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.LocalPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorLocalPosition()
        {
            tlog.Debug(tag, $"PanGestureDetectorLocalPosition START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

            tlog.Debug(tag, "LocalPosition : " + testingTarget.LocalPosition);

            tlog.Debug(tag, $"PanGestureDetectorLocalPosition END (OK)");
            Assert.Pass("PanGestureDetectorLocalPosition");
        }

        [Test]
        [Category("P1")]
        [Description("Test LocalDisplacement property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.LocalDisplacement A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorLocalDisplacement()
        {
            tlog.Debug(tag, $"PanGestureDetectorLocalDisplacement START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

            tlog.Debug(tag, "LocalDisplacement : " + testingTarget.LocalDisplacement);

            tlog.Debug(tag, $"PanGestureDetectorLocalDisplacement END (OK)");
            Assert.Pass("PanGestureDetectorLocalDisplacement");
        }

        [Test]
        [Category("P1")]
        [Description("Test LocalVelocity property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.LocalVelocity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorLocalVelocity()
        {
            tlog.Debug(tag, $"PanGestureDetectorLocalVelocity START");

            var testingTarget = new PanGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGestureDetector>(testingTarget, "Should be an instance of PanGestureDetector type.");

            tlog.Debug(tag, "LocalVelocity : " + testingTarget.LocalVelocity);

            tlog.Debug(tag, $"PanGestureDetectorLocalVelocity END (OK)");
            Assert.Pass("PanGestureDetectorLocalVelocity");
        }

        [Test]
        [Category("P1")]
        [Description("Test Panning property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.Panning A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorPanning()
        {
            tlog.Debug(tag, $"PanGestureDetectorPanning START");
            PanGestureDetector a1 = new PanGestureDetector();
            bool b1 = a1.Panning;
            
            tlog.Debug(tag, $"PanGestureDetectorPanning END (OK)");
            Assert.Pass("PanGestureDetectorPanning");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetMinimumTouchesRequired property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.SetMinimumTouchesRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorSetMinimumTouchesRequired()
        {
            tlog.Debug(tag, $"PanGestureDetectorSetMinimumTouchesRequired START");
            PanGestureDetector a1 = new PanGestureDetector();

            a1.SetMinimumTouchesRequired(2);
            
            tlog.Debug(tag, $"PanGestureDetectorSetMinimumTouchesRequired END (OK)");
            Assert.Pass("PanGestureDetectorSetMinimumTouchesRequired");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetMaximumTouchesRequired property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.SetMaximumTouchesRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorSetMaximumTouchesRequired()
        {
            tlog.Debug(tag, $"PanGestureDetectorSetMaximumTouchesRequired START");
            PanGestureDetector a1 = new PanGestureDetector();
            a1.SetMaximumTouchesRequired(4);
            
            tlog.Debug(tag, $"PanGestureDetectorSetMaximumTouchesRequired END (OK)");
            Assert.Pass("PanGestureDetectorSetMaximumTouchesRequired");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetMinimumTouchesRequired property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.GetMinimumTouchesRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorGetMinimumTouchesRequired()
        {
            tlog.Debug(tag, $"PanGestureDetectorGetMinimumTouchesRequired START");
            PanGestureDetector a1 = new PanGestureDetector();
            a1.SetMinimumTouchesRequired(4);

            a1.GetMinimumTouchesRequired();
            
            tlog.Debug(tag, $"PanGestureDetectorGetMinimumTouchesRequired END (OK)");
            Assert.Pass("PanGestureDetectorSetMaximumTouchesRequired");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetMaximumTouchesRequired property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.GetMaximumTouchesRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorGetMaximumTouchesRequired()
        {
            tlog.Debug(tag, $"PanGestureDetectorGetMaximumTouchesRequired START");
            PanGestureDetector a1 = new PanGestureDetector();
            a1.SetMaximumTouchesRequired(4);

            a1.GetMaximumTouchesRequired();
            
            tlog.Debug(tag, $"PanGestureDetectorGetMaximumTouchesRequired END (OK)");
            Assert.Pass("PanGestureDetectorSetMaximumTouchesRequired");
        }

        [Test]
        [Category("P1")]
        [Description("Test AddAngle property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.AddAngle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorAddAngle()
        {
            tlog.Debug(tag, $"PanGestureDetectorAddAngle START");
            PanGestureDetector a1 = new PanGestureDetector();
            Radian angle = new Radian(4);
            Radian threshold = new Radian(15);
            a1.AddAngle(angle);
            a1.AddAngle(angle, threshold);
            tlog.Debug(tag, $"PanGestureDetectorAddAngle END (OK)");
            Assert.Pass("PanGestureDetectorAddAngle");
        }

        [Test]
        [Category("P1")]
        [Description("Test AddDirection property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.AddDirection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorAddDirection()
        {
            tlog.Debug(tag, $"PanGestureDetectorAddDirection START");
            PanGestureDetector a1 = new PanGestureDetector();

            Radian angle = new Radian(4);
            Radian threshold = new Radian(15);
            a1.AddDirection(angle);

            a1.AddDirection(angle, threshold);

            
            tlog.Debug(tag, $"PanGestureDetectorAddDirection END (OK)");
            Assert.Pass("PanGestureDetectorAddDirection");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetAngleCount property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.GetAngleCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorGetAngleCount()
        {
            tlog.Debug(tag, $"PanGestureDetectorGetAngleCount START");
            PanGestureDetector a1 = new PanGestureDetector();

            Radian angle = new Radian(4);
            a1.AddAngle(angle);

            a1.GetAngleCount();
            
            tlog.Debug(tag, $"PanGestureDetectorGetAngleCount END (OK)");
            Assert.Pass("PanGestureDetectorAddDirection");
        }

        [Test]
        [Category("P1")]
        [Description("Test ClearAngles property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.ClearAngles M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorClearAngles()
        {
            tlog.Debug(tag, $"PanGestureDetectorClearAngles START");
            PanGestureDetector a1 = new PanGestureDetector();

            Radian angle = new Radian(4);
            a1.AddAngle(angle);

            a1.ClearAngles();
            
            tlog.Debug(tag, $"PanGestureDetectorClearAngles END (OK)");
            Assert.Pass("PanGestureDetectorClearAngles");
        }

        [Test]
        [Category("P1")]
        [Description("Test RemoveAngle property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.RemoveAngle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorRemoveAngle()
        {
            tlog.Debug(tag, $"PanGestureDetectorRemoveAngle START");
            PanGestureDetector a1 = new PanGestureDetector();

            Radian angle = new Radian(4);
            a1.AddAngle(angle);

            a1.RemoveAngle(angle);
            
            tlog.Debug(tag, $"PanGestureDetectorRemoveAngle END (OK)");
            Assert.Pass("PanGestureDetectorClearAngles");
        }


        [Test]
        [Category("P1")]
        [Description("Test RemoveDirection property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.RemoveDirection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorRemoveDirection()
        {
            tlog.Debug(tag, $"PanGestureDetectorRemoveDirection START");
            PanGestureDetector a1 = new PanGestureDetector();

            Radian angle = new Radian(4);
            a1.AddDirection(angle);

            a1.RemoveDirection(angle);
            
            tlog.Debug(tag, $"PanGestureDetectorRemoveDirection END (OK)");
            Assert.Pass("PanGestureDetectorClearAngles");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetPanGestureProperties property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.SetPanGestureProperties M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorSetPanGestureProperties()
        {
            tlog.Debug(tag, $"PanGestureDetectorSetPanGestureProperties START");
            PanGesture pan = new PanGesture();

            PanGestureDetector.SetPanGestureProperties(pan);
            
            tlog.Debug(tag, $"PanGestureDetectorSetPanGestureProperties END (OK)");
            Assert.Pass("PanGestureDetectorClearAngles");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetPanGestureDetectorFromPtr property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.GetPanGestureDetectorFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorGetPanGestureDetectorFromPtr()
        {
            tlog.Debug(tag, $"PanGestureDetectorGetPanGestureDetectorFromPtr START");
            PanGestureDetector a1 = new PanGestureDetector();
			           
            PanGestureDetector.GetPanGestureDetectorFromPtr(PanGestureDetector.getCPtr(a1).Handle);
            a1.Dispose();
					
            tlog.Debug(tag, $"PanGestureDetectorGetPanGestureDetectorFromPtr END (OK)");
            Assert.Pass("PanGestureDetectorGetPanGestureDetectorFromPtr");
        }
		
		[Test]
        [Category("P1")]
        [Description("Test Detected property.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetector.Detected A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectorDetected()
        {
            tlog.Debug(tag, $"PanGestureDetectorDetected START");
            PanGestureDetector a1 = new PanGestureDetector();
			
            a1.Detected += OnDetected;
            a1.Detected -= OnDetected;

            a1.Dispose();
            tlog.Debug(tag, $"PanGestureDetectorDetected END (OK)");
            Assert.Pass("PanGestureDetectorDetected");
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
        public void LongPressGestureDetectedEventArgsView()
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

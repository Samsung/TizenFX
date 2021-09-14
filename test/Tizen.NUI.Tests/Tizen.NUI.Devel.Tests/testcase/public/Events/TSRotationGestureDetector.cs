using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Events/RotationGestureDetector")]
    class PublicRotationGestureDetectorTest
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
        [Description("RotationGestureDetector constructor")]
        [Property("SPEC", "Tizen.NUI.RotationGestureDetector.RotationGestureDetector C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureDetectorConstructor()
        {
            tlog.Debug(tag, $"RotationGestureDetectorConstructor START");
            RotationGestureDetector a1 = new RotationGestureDetector();

            a1.Dispose();
            tlog.Debug(tag, $"RotationGestureDetectorConstructor END (OK)");
            Assert.Pass("RotationGestureDetectorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("RotationGestureDetector constructor")]
        [Property("SPEC", "Tizen.NUI.RotationGestureDetector.RotationGestureDetector C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureDetectorConstructorWithRotationGestureDetector()
        {
            tlog.Debug(tag, $"RotationGestureDetectorConstructorWithRotationGestureDetector START");

            using (RotationGestureDetector detector = new RotationGestureDetector())
            {
                var testingTarget = new RotationGestureDetector(detector);
                Assert.IsNotNull(testingTarget, "Can't create success object Hover");
                Assert.IsInstanceOf<RotationGestureDetector>(testingTarget, "Should be an instance of RotationGestureDetector type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RotationGestureDetectorConstructorWithRotationGestureDetector END (OK)");
            Assert.Pass("RotationGestureDetectorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("RotationGestureDetector GetRotationGestureDetectorFromPtr")]
        [Property("SPEC", "Tizen.NUI.RotationGestureDetector.GetRotationGestureDetectorFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureDetectorGetRotationGestureDetectorFromPtr()
        {
            tlog.Debug(tag, $"RotationGestureDetectorGetRotationGestureDetectorFromPtr START");
            RotationGestureDetector a1 = new RotationGestureDetector();
			
            RotationGestureDetector a2 = RotationGestureDetector.GetRotationGestureDetectorFromPtr(RotationGestureDetector.getCPtr(a1).Handle);
            a1.Dispose();
						
            tlog.Debug(tag, $"RotationGestureDetectorGetRotationGestureDetectorFromPtr END (OK)");
            Assert.Pass("RotationGestureDetectorGetRotationGestureDetectorFromPtr");
        }

        [Test]
        [Category("P1")]
        [Description("RotationGestureDetector DownCast")]
        [Property("SPEC", "Tizen.NUI.RotationGestureDetector.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureDetectorDownCast()
        {
            tlog.Debug(tag, $"RotationGestureDetectorDownCast START");

            using (RotationGestureDetector detector = new RotationGestureDetector())
            {
                var testingTarget = RotationGestureDetector.DownCast(detector);
                Assert.IsNotNull(testingTarget, "Can't create success object RotationGestureDetector");
                Assert.IsInstanceOf<RotationGestureDetector>(testingTarget, "Should be an instance of RotationGestureDetector type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RotationGestureDetectorDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RotationGestureDetector getCPtr")]
        [Property("SPEC", "Tizen.NUI.RotationGestureDetector.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureDetectorgetCPtr()
        {
            tlog.Debug(tag, $"RotationGestureDetectorgetCPtr START");
            RotationGestureDetector a1 = new RotationGestureDetector();
            global::System.Runtime.InteropServices.HandleRef b1 = RotationGestureDetector.getCPtr(a1);

            a1.Dispose();
            
            tlog.Debug(tag, $"RotationGestureDetectorgetCPtr END (OK)");
            Assert.Pass("RotationGestureDetectorgetCPtr");
        }

		[Test]
        [Category("P1")]
        [Description("RotationGestureDetector Assign")]
        [Property("SPEC", "Tizen.NUI.RotationGestureDetector.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureDetectorAssign()
        {
            tlog.Debug(tag, $"RotationGestureDetectorAssign START");

            using (RotationGestureDetector detector = new RotationGestureDetector())
            {
                var testingTarget = detector.Assign(detector);
                Assert.IsInstanceOf<RotationGestureDetector>(testingTarget, "Should be an instance of RotationGestureDetector type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RotationGestureDetectorAssign END (OK)");
        }
		
        [Test]
        [Category("P1")]
        [Description("RotationGestureDetector DetectedSignal")]
        [Property("SPEC", "Tizen.NUI.RotationGestureDetector.DetectedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureDetectorDetectedSignal()
        {
            tlog.Debug(tag, $"RotationGestureDetectorDetectedSignal START");
            RotationGestureDetector a1 = new RotationGestureDetector();

            RotationGestureDetectedSignal b1 = a1.DetectedSignal();

            a1.Dispose();
            
            tlog.Debug(tag, $"RotationGestureDetectorDetectedSignal END (OK)");
            Assert.Pass("RotationGestureDetectorDetectedSignal");
        }
		
		[Test]
        [Category("P1")]
        [Description("Test Detected property.")]
        [Property("SPEC", "Tizen.NUI.RotationGestureDetector.Detected A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureDetectorDetected()
        {
            tlog.Debug(tag, $"RotationGestureDetectorDetected START");
            RotationGestureDetector a1 = new RotationGestureDetector();
			
            a1.Detected += OnDetected;
            a1.Detected -= OnDetected;
            
            a1.Dispose();
            tlog.Debug(tag, $"RotationGestureDetectorDetected END (OK)");
        }		
		
		private void OnDetected(object obj, RotationGestureDetector.DetectedEventArgs e)
		{ }

        [Test]
        [Category("P1")]
        [Description("DetectedEventArgs View.")]
        [Property("SPEC", "Tizen.NUI.DetectedEventArgs.View A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureDetectedEventArgsView()
        {
            tlog.Debug(tag, $"RotationGestureDetectedEventArgsView START");

            var testingTarget = new Tizen.NUI.RotationGestureDetector.DetectedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
            Assert.IsInstanceOf<Tizen.NUI.RotationGestureDetector.DetectedEventArgs>(testingTarget, "Should return DetectedEventArgs instance.");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                testingTarget.View = view;
                Assert.AreEqual(100, testingTarget.View.Size.Width, "Should be equal!");
            }

            testingTarget.RotationGesture = new RotationGesture(Gesture.StateType.Possible);
            Assert.AreEqual(Gesture.StateType.Possible, testingTarget.RotationGesture.State, "Should be equal!");

            tlog.Debug(tag, "Handled : " + testingTarget.Handled);

            tlog.Debug(tag, $"RotationGestureDetectedEventArgsView END (OK)");
        }
    }
}
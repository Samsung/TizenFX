using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Events/PinchGestureDetector")]
    class PublicPinchGestureDetectorTest
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
        [Description("PinchGestureDetector constructor")]
        [Property("SPEC", "Tizen.NUI.PinchGestureDetector.PinchGestureDetector C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureDetectorConstructor()
        {
            tlog.Debug(tag, $"PinchGestureDetectorConstructor START");
            PinchGestureDetector a1 = new PinchGestureDetector();

            a1.Dispose();
            tlog.Debug(tag, $"PinchGestureDetectorConstructor END (OK)");
            Assert.Pass("PinchGestureDetectorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("PinchGestureDetector constructor")]
        [Property("SPEC", "Tizen.NUI.PinchGestureDetector.PinchGestureDetector C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureDetectorConstructorWithPinchGestureDetector()
        {
            tlog.Debug(tag, $"PinchGestureDetectorConstructor START");

            using (PinchGestureDetector detector = new PinchGestureDetector())
            {
                var testingTarget = new PinchGestureDetector(detector);
                Assert.IsNotNull(testingTarget, "Can't create success object Hover");
                Assert.IsInstanceOf<PinchGestureDetector>(testingTarget, "Should be an instance of PinchGestureDetector type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PinchGestureDetectorConstructor END (OK)");
            Assert.Pass("PinchGestureDetectorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("PinchGestureDetector GetPinchGestureDetectorFromPtr")]
        [Property("SPEC", "Tizen.NUI.PinchGestureDetector.GetPinchGestureDetectorFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureDetectorGetPinchGestureDetectorFromPtr()
        {
            tlog.Debug(tag, $"PinchGestureDetectorGetPinchGestureDetectorFromPtr START");
            PinchGestureDetector a1 = new PinchGestureDetector();

            PinchGestureDetector a2 = PinchGestureDetector.GetPinchGestureDetectorFromPtr(PinchGestureDetector.getCPtr(a1).Handle);
			
            a1.Dispose();
            
            tlog.Debug(tag, $"PinchGestureDetectorGetPinchGestureDetectorFromPtr END (OK)");
            Assert.Pass("PinchGestureDetectorGetPinchGestureDetectorFromPtr");
        }

        [Test]
        [Category("P1")]
        [Description("PinchGestureDetector DownCast")]
        [Property("SPEC", "Tizen.NUI.PinchGestureDetector.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureDetectorDownCast()
        {
            tlog.Debug(tag, $"PinchGestureDetectorDownCast START");

            using (PinchGestureDetector detector = new PinchGestureDetector())
            {
                var testingTarget = PinchGestureDetector.DownCast(detector);
                Assert.IsInstanceOf<PinchGestureDetector>(testingTarget, "Should be an instance of PinchGestureDetector type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PinchGestureDetectorDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PinchGestureDetector getCPtr")]
        [Property("SPEC", "Tizen.NUI.PinchGestureDetector.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureDetectorgetCPtr()
        {
            tlog.Debug(tag, $"PinchGestureDetectorgetCPtr START");
            PinchGestureDetector a1 = new PinchGestureDetector();

            global::System.Runtime.InteropServices.HandleRef b1 = PinchGestureDetector.getCPtr(a1);

            a1.Dispose();
            
            tlog.Debug(tag, $"PinchGestureDetectorgetCPtr END (OK)");
            Assert.Pass("PinchGestureDetectorgetCPtr");
        }

		[Test]
        [Category("P1")]
        [Description("PinchGestureDetector Assign")]
        [Property("SPEC", "Tizen.NUI.PinchGestureDetector.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureDetectorAssign()
        {
            tlog.Debug(tag, $"PinchGestureDetectorAssign START");

            using (PinchGestureDetector detector = new PinchGestureDetector())
            {
                var testingTarget = detector.Assign(detector);
                Assert.IsInstanceOf<PinchGestureDetector>(testingTarget, "Should be an instance of PinchGestureDetector type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PinchGestureDetectorAssign END (OK)");		
        }
		
        [Test]
        [Category("P1")]
        [Description("PinchGestureDetector DetectedSignal")]
        [Property("SPEC", "Tizen.NUI.PinchGestureDetector.DetectedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureDetectorDetectedSignal()
        {
            tlog.Debug(tag, $"PinchGestureDetectorDetectedSignal START");
            PinchGestureDetector a1 = new PinchGestureDetector();

            PinchGestureDetectedSignal b1 = a1.DetectedSignal();
			
            a1.Dispose();
            
            tlog.Debug(tag, $"PinchGestureDetectorDetectedSignal END (OK)");
            Assert.Pass("PinchGestureDetectorDetectedSignal");
        }

		[Test]
        [Category("P1")]
        [Description("Test Detected property.")]
        [Property("SPEC", "Tizen.NUI.PinchGestureDetector.Detected A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureDetectorDetected()
        {
            tlog.Debug(tag, $"PinchGestureDetectorDetected START");
            PinchGestureDetector a1 = new PinchGestureDetector();
			
            a1.Detected += OnDetected;
            a1.Detected -= OnDetected;
			
            a1.Dispose();
            tlog.Debug(tag, $"PinchGestureDetectorDetected END (OK)");
            Assert.Pass("PinchGestureDetectorDetected");
        }
		
		private void OnDetected(object obj, PinchGestureDetector.DetectedEventArgs e)
		{ }

        [Test]
        [Category("P1")]
        [Description("Test DetectedEventArgs View.")]
        [Property("SPEC", "Tizen.NUI.DetectedEventArgs.View A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureDetectedEventArgsView()
        {
            tlog.Debug(tag, $"PinchGestureDetectedEventArgsView START");

            var testingTarget = new Tizen.NUI.PinchGestureDetector.DetectedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
            Assert.IsInstanceOf<Tizen.NUI.PinchGestureDetector.DetectedEventArgs>(testingTarget, "Should return DetectedEventArgs instance.");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                testingTarget.View = view;
                Assert.AreEqual(100, testingTarget.View.Size.Width, "Should be equal!");
            }

            testingTarget.PinchGesture = new PinchGesture(Gesture.StateType.Possible);
            Assert.AreEqual(Gesture.StateType.Possible, testingTarget.PinchGesture.State, "Should be equal!");

            tlog.Debug(tag, $"PinchGestureDetectedEventArgsView END (OK)");
        }
    }
}
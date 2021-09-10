using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Events/TapGestureDetector")]
    class PublicTapGestureDetectorTest
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
        [Description("TapGestureDetector constructor")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetector.TapGestureDetector C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectorConstructor()
        {
            tlog.Debug(tag, $"TapGestureDetectorConstructor START");
            
            var testingTarget = new TapGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<TapGestureDetector>(testingTarget, "Should be an instance of TapGestureDetector type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TapGestureDetectorConstructor END (OK)");
            Assert.Pass("TapGestureDetectorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("TapGestureDetector constructor")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetector.TapGestureDetector C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectorConstructorWithTapsRequired()
        {
            tlog.Debug(tag, $"TapGestureDetectorConstructorWithTapsRequired START");

            var testingTarget = new TapGestureDetector(4);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<TapGestureDetector>(testingTarget, "Should be an instance of TapGestureDetector type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TapGestureDetectorConstructorWithTapsRequired END (OK)");
            Assert.Pass("TapGestureDetectorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("TapGestureDetector constructor")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetector.TapGestureDetector C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectorConstructorWithTapGestureDetector()
        {
            tlog.Debug(tag, $"TapGestureDetectorConstructorWithTapGestureDetector START");

            using (TapGestureDetector detector = new TapGestureDetector(4))
            {
                var testingTarget = new TapGestureDetector(detector);
                Assert.IsNotNull(testingTarget, "Can't create success object Hover");
                Assert.IsInstanceOf<TapGestureDetector>(testingTarget, "Should be an instance of TapGestureDetector type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TapGestureDetectorConstructorWithTapGestureDetector END (OK)");
            Assert.Pass("TapGestureDetectorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("TapGestureDetector Assign")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetector.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectorAssign()
        {
            tlog.Debug(tag, $"TapGestureDetectorAssign START");

            using (TapGestureDetector detector = new TapGestureDetector(4))
            {
                var testingTarget = detector.Assign(detector);
                Assert.IsNotNull(testingTarget, "Can't create success object Hover");
                Assert.IsInstanceOf<TapGestureDetector>(testingTarget, "Should be an instance of TapGestureDetector type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TapGestureDetectorAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TapGestureDetector SetMinimumTapsRequired")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetector.SetMinimumTapsRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectorSetMinimumTapsRequired()
        {
            tlog.Debug(tag, $"TapGestureDetectorSetMinimumTapsRequired START");
            TapGestureDetector a1 = new TapGestureDetector();
            a1.SetMinimumTapsRequired(2);
            a1.Dispose();
            
            tlog.Debug(tag, $"TapGestureDetectorSetMinimumTapsRequired END (OK)");
            Assert.Pass("TapGestureDetectorSetMinimumTapsRequired");
        }

        [Test]
        [Category("P1")]
        [Description("TapGestureDetector SetMaximumTapsRequired")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetector.SetMaximumTapsRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectorSetMaximumTapsRequired()
        {
            tlog.Debug(tag, $"TapGestureDetectorSetMaximumTapsRequired START");
            TapGestureDetector a1 = new TapGestureDetector();
            a1.SetMaximumTapsRequired(9);
            a1.Dispose();
            
            tlog.Debug(tag, $"TapGestureDetectorSetMaximumTapsRequired END (OK)");
            Assert.Pass("TapGestureDetectorSetMaximumTapsRequired");
        }

        [Test]
        [Category("P1")]
        [Description("TapGestureDetector GetMinimumTapsRequired")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetector.GetMinimumTapsRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectorGetMinimumTapsRequired()
        {
            tlog.Debug(tag, $"TapGestureDetectorGetMinimumTapsRequired START");
            TapGestureDetector a1 = new TapGestureDetector();
            a1.SetMinimumTapsRequired(2);

            a1.GetMinimumTapsRequired();
            a1.Dispose();
            
            tlog.Debug(tag, $"TapGestureDetectorGetMinimumTapsRequired END (OK)");
            Assert.Pass("TapGestureDetectorGetMinimumTapsRequired");
        }

        [Test]
        [Category("P1")]
        [Description("TapGestureDetector GetMaximumTapsRequired")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetector.GetMaximumTapsRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectorGetMaximumTapsRequired()
        {
            tlog.Debug(tag, $"TapGestureDetectorGetMaximumTapsRequired START");
            TapGestureDetector a1 = new TapGestureDetector();
            a1.SetMaximumTapsRequired(9);

            a1.GetMaximumTapsRequired();
            a1.Dispose();
            
            tlog.Debug(tag, $"TapGestureDetectorGetMaximumTapsRequired END (OK)");
            Assert.Pass("TapGestureDetectorGetMaximumTapsRequired");
        }

        [Test]
        [Category("P1")]
        [Description("TapGestureDetector DownCast")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetector.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectorDownCast()
        {
            tlog.Debug(tag, $"TapGestureDetectorDownCast START");
            BaseHandle handle = new BaseHandle();

            TapGestureDetector a1 = TapGestureDetector.DownCast(handle);
            
            tlog.Debug(tag, $"TapGestureDetectorDownCast END (OK)");
            Assert.Pass("TapGestureDetectorDownCast");
        }

        [Test]
        [Category("P1")]
        [Description("TapGestureDetector getCPtr")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetector.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectorgetCPtr()
        {
            tlog.Debug(tag, $"TapGestureDetectorgetCPtr START");
            TapGestureDetector a1 = new TapGestureDetector();
            global::System.Runtime.InteropServices.HandleRef p1 = TapGestureDetector.getCPtr(a1);
            
            tlog.Debug(tag, $"TapGestureDetectorgetCPtr END (OK)");
            Assert.Pass("TapGestureDetectorgetCPtr");
        }

        [Test]
        [Category("P1")]
        [Description("TapGestureDetector GetTapGestureDetectorFromPtr")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetector.GetTapGestureDetectorFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectorGetTapGestureDetectorFromPtr()
        {
            tlog.Debug(tag, $"TapGestureDetectorGetTapGestureDetectorFromPtr START");
            TapGestureDetector a1 = new TapGestureDetector();
			
            TapGestureDetector a2 = TapGestureDetector.GetTapGestureDetectorFromPtr(TapGestureDetector.getCPtr(a1).Handle);

            a1.Dispose();
            
            tlog.Debug(tag, $"TapGestureDetectorGetTapGestureDetectorFromPtr END (OK)");
            Assert.Pass("TapGestureDetectorGetTapGestureDetectorFromPtr");
        }

        [Test]
        [Category("P1")]
        [Description("TapGestureDetector DetectedSignal")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetector.DetectedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectorDetectedSignal()
        {
            tlog.Debug(tag, $"TapGestureDetectorDetectedSignal START");
            TapGestureDetector a1 = new TapGestureDetector();
            TapGestureDetectedSignal b1 = a1.DetectedSignal();
         
            tlog.Debug(tag, $"TapGestureDetectorDetectedSignal END (OK)");
            Assert.Pass("TapGestureDetectorDetectedSignal");
        }
		
		[Test]
        [Category("P1")]
        [Description("Test Detected property.")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetector.Detected A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectorDetected()
        {
            tlog.Debug(tag, $"TapGestureDetectorDetected START");
            TapGestureDetector a1 = new TapGestureDetector();
			
            a1.Detected += OnDetected;
            a1.Detected -= OnDetected;
			
            a1.Dispose();
            tlog.Debug(tag, $"TapGestureDetectorDetected END (OK)");
            Assert.Pass("TapGestureDetectorDetected");
        }		
		
		private void OnDetected(object obj, TapGestureDetector.DetectedEventArgs e)
		{ }

        [Test]
        [Category("P1")]
        [Description("Test DetectedEventArgs View.")]
        [Property("SPEC", "Tizen.NUI.DetectedEventArgs.View A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectedEventArgsView()
        {
            tlog.Debug(tag, $"TapGestureDetectedEventArgsView START");

            var testingTarget = new Tizen.NUI.TapGestureDetector.DetectedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
            Assert.IsInstanceOf<Tizen.NUI.TapGestureDetector.DetectedEventArgs>(testingTarget, "Should return DetectedEventArgs instance.");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                testingTarget.View = view;
                Assert.AreEqual(100, testingTarget.View.Size.Width, "Should be equal!");
            }

            testingTarget.TapGesture = new TapGesture();
            tlog.Debug(tag, "TapGesture : " + testingTarget.TapGesture);

            tlog.Debug(tag, $"TapGestureDetectedEventArgsView END (OK)");
        }
    }
}
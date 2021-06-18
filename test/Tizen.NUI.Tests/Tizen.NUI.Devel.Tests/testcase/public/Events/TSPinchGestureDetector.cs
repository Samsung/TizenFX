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
            PinchGestureDetector a2 = new PinchGestureDetector(a1);

            a2.Dispose();
            a1.Dispose();

            
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
            BaseHandle handle = new BaseHandle();

            PinchGestureDetector a1 = PinchGestureDetector.DownCast(handle);

            a1.Dispose();
            
            tlog.Debug(tag, $"PinchGestureDetectorDownCast END (OK)");
            Assert.Pass("PinchGestureDetectorDownCast");
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
            PinchGestureDetector a1 = new PinchGestureDetector();

            PinchGestureDetector b1 = a1;
			
            a1.Dispose();
            b1.Dispose();
            
            tlog.Debug(tag, $"PinchGestureDetectorAssign END (OK)");
            Assert.Pass("PinchGestureDetectorAssign");			
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
			
            PinchGestureDetector.DetectedEventArgs e = new PinchGestureDetector.DetectedEventArgs();
            object o = new object();
			
            OnDetected(o, e);
			
            a1.Dispose();
			
            tlog.Debug(tag, $"PinchGestureDetectorDetected END (OK)");
            Assert.Pass("PinchGestureDetectorDetected");
        }
		
		private void OnDetected(object obj, PinchGestureDetector.DetectedEventArgs e)
		{
            View v1 = e.View;
            e.View = v1;
			
            PinchGesture p1 = e.PinchGesture;
            e.PinchGesture = p1;
		}	
    }
}
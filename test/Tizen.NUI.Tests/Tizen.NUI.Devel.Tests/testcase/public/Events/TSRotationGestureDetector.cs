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
            RotationGestureDetector a2 = new RotationGestureDetector(a1);

            a2.Dispose();
            a1.Dispose();
            
            tlog.Debug(tag, $"RotationGestureDetectorConstructor END (OK)");
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
            BaseHandle handle = new BaseHandle();

            RotationGestureDetector a1 = RotationGestureDetector.DownCast(handle);

            a1.Dispose();
            
            tlog.Debug(tag, $"RotationGestureDetectorDownCast END (OK)");
            Assert.Pass("RotationGestureDetectorDownCast");
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
            RotationGestureDetector a1 = new RotationGestureDetector();

            RotationGestureDetector b1 = a1;

            b1.Dispose();
            a1.Dispose();
            
            tlog.Debug(tag, $"RotationGestureDetectorAssign END (OK)");
            Assert.Pass("RotationGestureDetectorAssign");
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
			
            RotationGestureDetector.DetectedEventArgs e = new RotationGestureDetector.DetectedEventArgs();
            object o = new object();
			
            OnDetected(o, e);
			
            a1.Dispose();
			
            tlog.Debug(tag, $"RotationGestureDetectorDetected END (OK)");
            Assert.Pass("RotationGestureDetectorDetected");
        }		
		
		private void OnDetected(object obj, RotationGestureDetector.DetectedEventArgs e)
		{
            View v1 = e.View;
            e.View = v1;
			
            RotationGesture p1 = e.RotationGesture;
            e.RotationGesture = p1;
		}		
    }

}
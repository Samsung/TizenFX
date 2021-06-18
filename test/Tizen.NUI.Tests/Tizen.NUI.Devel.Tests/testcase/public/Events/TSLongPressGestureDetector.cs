using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Events/LongPressGestureDetector")]
    internal class PublicLongPressGestureDetectorTest
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
        [Description("Create a LongPressGestureDetector object. Check whether LongPressGestureDetector is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.LongPressGestureDetector C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorConstructor()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorConstructor START");
            LongPressGestureDetector a1 = new LongPressGestureDetector();
            LongPressGestureDetector a2 = new LongPressGestureDetector(7);
            LongPressGestureDetector a3 = new LongPressGestureDetector(3, 7);
            LongPressGestureDetector a4 = new LongPressGestureDetector(a3);

            a1.Dispose();
            a2.Dispose();
            a3.Dispose();
            a4.Dispose();
            tlog.Debug(tag, $"LongPressGestureDetectorConstructor END (OK)");
            Assert.Pass("LongPressGestureDetectorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetector SetTouchesRequired")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.SetTouchesRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorSetTouchesRequired()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorSetTouchesRequired START");
            LongPressGestureDetector a1 = new LongPressGestureDetector(7);

            a1.SetTouchesRequired(3);
            a1.SetTouchesRequired(1, 5);

            a1.Dispose();
			
            tlog.Debug(tag, $"LongPressGestureDetectorSetTouchesRequired END (OK)");
            Assert.Pass("SetTouchesRequired");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetector GetMinimumTouchesRequired")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.GetMinimumTouchesRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorGetMinimumTouchesRequired()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorGetMinimumTouchesRequired START");
            LongPressGestureDetector a1 = new LongPressGestureDetector(3, 7);
            uint b1 = a1.GetMinimumTouchesRequired();

            a1.Dispose();
			
            tlog.Debug(tag, $"LongPressGestureDetectorGetMinimumTouchesRequired END (OK)");
            Assert.Pass("GetMinimumTouchesRequired");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetector GetMaximumTouchesRequired")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.GetMaximumTouchesRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorGetMaximumTouchesRequired()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorGetMaximumTouchesRequired START");
            LongPressGestureDetector a1 = new LongPressGestureDetector(3, 7);
            uint b1 = a1.GetMaximumTouchesRequired();

            a1.Dispose();
			
            tlog.Debug(tag, $"LongPressGestureDetectorGetMaximumTouchesRequired END (OK)");
            Assert.Pass("GetMaximumTouchesRequired");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetector GetLongPressGestureDetectorFromPtr")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.GetLongPressGestureDetectorFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorGetLongPressGestureDetectorFromPtr()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorGetLongPressGestureDetectorFromPtr START");
            LongPressGestureDetector a1 = new LongPressGestureDetector();
            LongPressGestureDetector a2 = LongPressGestureDetector.GetLongPressGestureDetectorFromPtr(LongPressGestureDetector.getCPtr(a1).Handle);

            a1.Dispose();
			
            tlog.Debug(tag, $"LongPressGestureDetectorGetLongPressGestureDetectorFromPtr END (OK)");
            Assert.Pass("GetLongPressGestureDetectorFromPtr");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetector DownCast")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorDownCast()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorDownCast START");
            BaseHandle handle = new BaseHandle();
            LongPressGestureDetector a1 = LongPressGestureDetector.DownCast(handle);
			
            tlog.Debug(tag, $"LongPressGestureDetectorDownCast END (OK)");
            Assert.Pass("LongPressGestureDetectorDownCast");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetector DetectedSignal")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.DetectedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorDetectedSignal()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorDetectedSignal START");
            LongPressGestureDetector a1 = new LongPressGestureDetector();
            LongPressGestureDetectedSignal b1 = a1.DetectedSignal();

            a1.Dispose();
			
            tlog.Debug(tag, $"LongPressGestureDetectorDetectedSignal END (OK)");
            Assert.Pass("LongPressGestureDetectorDetectedSignal");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetector getCPtr")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorgetCPtr()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorgetCPtr START");
            LongPressGestureDetector a1 = new LongPressGestureDetector();
            global::System.Runtime.InteropServices.HandleRef c1 = LongPressGestureDetector.getCPtr(a1);

            a1.Dispose();
				
			
            tlog.Debug(tag, $"LongPressGestureDetectorgetCPtr END (OK)");
            Assert.Pass("LongPressGestureDetectorgetCPtr");
        }
		
        [Test]
        [Category("P1")]
        [Description("Test Detected property.")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.Detected A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorDetected()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorDetected START");
            LongPressGestureDetector a1 = new LongPressGestureDetector();
			
            a1.Detected += OnDetected;
            a1.Detected -= OnDetected;
			
            LongPressGestureDetector.DetectedEventArgs e = new LongPressGestureDetector.DetectedEventArgs();
            object o = new object();
			
            OnDetected(o, e);
			
            a1.Dispose();
			
            tlog.Debug(tag, $"LongPressGestureDetectorDetected END (OK)");
            Assert.Pass("LongPressGestureDetectorDetected");
        }		
		
        private void OnDetected(object obj, LongPressGestureDetector.DetectedEventArgs e)
        {
            View v1 = e.View;
            e.View = v1;
			
            LongPressGesture p1 = e.LongPressGesture;
            e.LongPressGesture = p1;
        }
	}
}

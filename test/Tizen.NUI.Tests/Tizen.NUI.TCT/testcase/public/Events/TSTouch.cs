using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Events/Touch")]
    class PublicTouchTest
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
        [Description("Touch constructor")]
        [Property("SPEC", "Tizen.NUI.Touch.Touch C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchConstructor()
        {
            tlog.Debug(tag, $"TouchConstructor START");
            
            Touch a1 = new Touch();
            Touch a2 = new Touch(a1);
            
            a2.Dispose();
            a1.Dispose();
            
            tlog.Debug(tag, $"TouchConstructor END (OK)");
            Assert.Pass("TouchConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetTime")]
        [Property("SPEC", "Tizen.NUI.Touch.GetTime M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetTime()
        {
            tlog.Debug(tag, $"TouchGetTime START");
            Touch a1 = new Touch();
            a1.GetTime();

            a1.Dispose();
            
            tlog.Debug(tag, $"TouchGetTime END (OK)");
            Assert.Pass("TouchGetTime");
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetPointCount")]
        [Property("SPEC", "Tizen.NUI.Touch.GetPointCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetPointCount()
        {
            tlog.Debug(tag, $"TouchGetPointCount START");
            Touch a1 = new Touch();
            a1.GetPointCount();

            a1.Dispose();
            
            tlog.Debug(tag, $"TouchGetPointCount END (OK)");
            Assert.Pass("TouchGetPointCount");
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetDeviceId")]
        [Property("SPEC", "Tizen.NUI.Touch.GetDeviceId M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetDeviceId()
        {
            tlog.Debug(tag, $"TouchGetDeviceId START");
            Touch a1 = new Touch();
            a1.GetDeviceId(1);

            a1.Dispose();
            
            tlog.Debug(tag, $"TouchGetDeviceId END (OK)");
            Assert.Pass("TouchGetDeviceId");
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetState")]
        [Property("SPEC", "Tizen.NUI.Touch.GetState M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetState()
        {
            tlog.Debug(tag, $"TouchGetState START");
            Touch a1 = new Touch();
            PointStateType b1 = a1.GetState(1);

            a1.Dispose();
            
            tlog.Debug(tag, $"TouchGetState END (OK)");
            Assert.Pass("TouchGetDeviceId");
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetHitView")]
        [Property("SPEC", "Tizen.NUI.Touch.GetHitView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetHitView()
        {
            tlog.Debug(tag, $"TouchGetHitView START");
            Touch a1 = new Touch();
            View b1 = a1.GetHitView(2);

            a1.Dispose();
            
            tlog.Debug(tag, $"TouchGetHitView END (OK)");
            Assert.Pass("TouchGetHitView");
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetLocalPosition")]
        [Property("SPEC", "Tizen.NUI.Touch.GetLocalPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetLocalPosition()
        {
            tlog.Debug(tag, $"TouchGetLocalPosition START");
            Touch a1 = new Touch();
            Vector2 b1 = a1.GetLocalPosition(2);

            a1.Dispose();
            
            tlog.Debug(tag, $"TouchGetLocalPosition END (OK)");
            Assert.Pass("TouchGetLocalPosition");
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetScreenPosition")]
        [Property("SPEC", "Tizen.NUI.Touch.GetScreenPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetScreenPosition()
        {
            tlog.Debug(tag, $"TouchGetScreenPosition START");
            Touch a1 = new Touch();
            Vector2 b1 = a1.GetScreenPosition(2);

            a1.Dispose();
            
            tlog.Debug(tag, $"TouchGetScreenPosition END (OK)");
            Assert.Pass("TouchGetScreenPosition");
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetRadius")]
        [Property("SPEC", "Tizen.NUI.Touch.GetRadius M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetRadius()
        {
            tlog.Debug(tag, $"TouchGetRadius START");
            Touch a1 = new Touch();
            float f1 = a1.GetRadius(2);

            a1.Dispose();
            
            tlog.Debug(tag, $"TouchGetRadius END (OK)");
            Assert.Pass("TouchGetRadius");
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetEllipseRadius")]
        [Property("SPEC", "Tizen.NUI.Touch.GetEllipseRadius M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetEllipseRadius()
        {
            tlog.Debug(tag, $"TouchGetEllipseRadius START");
            Touch a1 = new Touch();
            Vector2 b1 = a1.GetEllipseRadius(2);

            a1.Dispose();
            
            tlog.Debug(tag, $"TouchGetEllipseRadius END (OK)");
            Assert.Pass("TouchGetEllipseRadius");
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetPressure")]
        [Property("SPEC", "Tizen.NUI.Touch.GetPressure M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetPressure()
        {
            tlog.Debug(tag, $"TouchGetPressure START");
            Touch a1 = new Touch();
            float f1 = a1.GetPressure(2);

            a1.Dispose();
            
            tlog.Debug(tag, $"TouchGetPressure END (OK)");
            Assert.Pass("TouchGetPressure");
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetMouseButton")]
        [Property("SPEC", "Tizen.NUI.Touch.GetMouseButton M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetMouseButton()
        {
            tlog.Debug(tag, $"TouchGetMouseButton START");
            Touch a1 = new Touch();
            MouseButton b1 = a1.GetMouseButton(2);

            a1.Dispose();
            
            tlog.Debug(tag, $"TouchGetMouseButton END (OK)");
            Assert.Pass("TouchGetMouseButton");
        }

        [Test]
        [Category("P1")]
        [Description("Touch getCPtr")]
        [Property("SPEC", "Tizen.NUI.Touch.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchgetCPtr()
        {
            tlog.Debug(tag, $"TouchgetCPtr START");
            Touch a1 = new Touch();
            global::System.Runtime.InteropServices.HandleRef b1 = Touch.getCPtr(a1);

            a1.Dispose();
            
            tlog.Debug(tag, $"TouchgetCPtr END (OK)");
            Assert.Pass("TouchgetCPtr");
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetTouchFromPtr")]
        [Property("SPEC", "Tizen.NUI.Touch.GetTouchFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetTouchFromPtr()
        {
            tlog.Debug(tag, $"TouchGetTouchFromPtr START");
            Touch a1 = new Touch();
            Touch a2 = Touch.GetTouchFromPtr(Touch.getCPtr(a1).Handle);

            a1.Dispose();
            
            tlog.Debug(tag, $"TouchGetTouchFromPtr END (OK)");
            Assert.Pass("TouchGetTouchFromPtr");
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetAngle")]
        [Property("SPEC", "Tizen.NUI.Touch.GetAngle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetAngle()
        {
            tlog.Debug(tag, $"TouchGetAngle START");
            Touch a1 = new Touch();
            Degree b1 = a1.GetAngle(2);

            a1.Dispose();
            
            tlog.Debug(tag, $"TouchGetAngle END (OK)");
            Assert.Pass("TouchGetAngle");
        }
    }

}
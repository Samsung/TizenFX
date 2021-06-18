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
    [Description("public/BaseComponents/CameraView")]
    class PublicCameraViewTest
    {
        private const string tag = "NUITEST";

        internal class MyCameraView : CameraView
        {
            public MyCameraView(global::System.IntPtr handle, DisplayType type = DisplayType.Window) : base(handle, type)
            { }

            public void OnDispose(DisposeTypes type)
            {
                base.Dispose(type);
            }
        }

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
        [Description("CameraView constructor.")]
        [Property("SPEC", "Tizen.NUI.CameraView.CameraView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraViewConstructor()
        {
            tlog.Debug(tag, $"CameraViewConstructor START");

            var testingTarget = new CameraView(new ImageView().SwigCPtr.Handle, CameraView.DisplayType.Image);
            Assert.IsNotNull(testingTarget, "Can't create success object CameraView");
            Assert.IsInstanceOf<CameraView>(testingTarget, "Should be an instance of CameraView type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraViewConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CameraView constructor. With CameraView Instance.")]
        [Property("SPEC", "Tizen.NUI.CameraView.CameraView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraViewConstructorWithCameraViewInstance()
        {
            tlog.Debug(tag, $"CameraViewConstructorWithCameraViewInstance START");

            using (CameraView cameraView = new CameraView(new ImageView().SwigCPtr.Handle, CameraView.DisplayType.Image))
            {
                var testingTarget = new CameraView(cameraView);
                Assert.IsNotNull(testingTarget, "Can't create success object CameraView");
                Assert.IsInstanceOf<CameraView>(testingTarget, "Should be an instance of CameraView type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CameraViewConstructorWithCameraViewInstance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CameraView Dispose.")]
        [Property("SPEC", "Tizen.NUI.CameraView.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraViewDispose()
        {
            tlog.Debug(tag, $"CameraViewDispose START");

            var testingTarget = new MyCameraView(new ImageView().SwigCPtr.Handle, CameraView.DisplayType.Image);
            Assert.IsNotNull(testingTarget, "Can't create success object CameraView");
            Assert.IsInstanceOf<CameraView>(testingTarget, "Should be an instance of CameraView type.");

            testingTarget.OnDispose(DisposeTypes.Explicit);

            try
            {
                testingTarget.OnDispose(DisposeTypes.Explicit);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"CameraViewDispose END (OK)");
        }
    }
}

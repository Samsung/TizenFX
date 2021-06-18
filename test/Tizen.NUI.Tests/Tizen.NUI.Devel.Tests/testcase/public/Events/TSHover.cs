using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;
	
    [TestFixture]
    [Description("public/Events/Hover")]
    internal class PublicHoverTest
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
        [Description("Create a Hover object. Check whether Hover is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Hover.Hover C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverConstructor()
        {
            tlog.Debug(tag, $"HoverConstructor START");
            var hover1 = new Hover();
            Assert.IsNotNull(hover1, "Can't create success object Hover");
            Assert.IsInstanceOf<Hover>(hover1, "Should be an instance of Hover type.");

            var hover2 = new Hover(2);

            var hover3 = new Hover(hover2);			
            
            var hover4 = new Hover(Hover.getCPtr(hover3).Handle, true);	
			
            //hover4.Dispose();
            hover3.Dispose();
            hover2.Dispose();
            hover1.Dispose();
            tlog.Debug(tag, $"HoverConstructor END (OK)");
            Assert.Pass("HoverConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Test Time property. Check whether Time returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.Hover.Time A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverTime()
        {
            tlog.Debug(tag, $"HoverTime START");
            /* TEST CODE */
            Hover hover = new Hover();
            Assert.AreEqual(0u, hover.Time, "Should be equals to the origin value of Time");
            hover.Dispose();
            tlog.Debug(tag, $"HoverTime END (OK)");
            Assert.Pass("HoverTime");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetDeviceId.Check whether GetDeviceId returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetDeviceId M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverGetDeviceId()
        {
            tlog.Debug(tag, $"HoverGetDeviceId START");
            /* TEST CODE */
            Hover hover = new Hover();
            Assert.AreEqual(-1, hover.GetDeviceId(0), "Should be equals to the origin value of DeviceId");
            hover.Dispose();
            tlog.Debug(tag, $"HoverGetDeviceId END (OK)");
            Assert.Pass("HoverGetDeviceId");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetState.Check whether GetState returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetState M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@partner.samsung.com")]
        public void HoverGetState()
        {
            tlog.Debug(tag, $"HoverGetState START");
            /* TEST CODE */
            Hover hover = new Hover();
            Assert.AreEqual(PointStateType.Finished, hover.GetState(0), "Should be equals to the origin value of state");
            hover.Dispose();
            tlog.Debug(tag, $"HoverGetState END (OK)");
            Assert.Pass("HoverGetState");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetHitView.Check whether GetHitView returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetHitView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverGetHitView()
        {
            tlog.Debug(tag, $"HoverGetHitView START");
            /* TEST CODE */
            Hover hover = new Hover();

            Assert.IsNotInstanceOf<View>(hover.GetHitView(0), "non-existent point returns an empty handle");
            hover.Dispose();
            tlog.Debug(tag, $"HoverGetHitView END (OK)");
            Assert.Pass("HoverGetHitView");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetLocalPosition.Check whether GetLocalPosition returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetLocalPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverGetLocalPosition()
        {
            tlog.Debug(tag, $"HoverGetLocalPosition START");
            /* TEST CODE */
            Hover hover = new Hover();
            Assert.AreEqual(0.0f, hover.GetLocalPosition(0).X, "Should be equals to the origin value of LocalPosition.X");
            Assert.AreEqual(0.0f, hover.GetLocalPosition(0).Y, "Should be equals to the origin value of LocalPosition.Y");
            hover.Dispose();
            tlog.Debug(tag, $"HoverGetLocalPosition END (OK)");
            Assert.Pass("HoverGetLocalPosition");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetScreenPosition.Check whether GetScreenPosition returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetScreenPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverGetScreenPosition()
        {
            tlog.Debug(tag, $"HoverGetScreenPosition START");
            /* TEST CODE */
            Hover hover = new Hover();
            Assert.AreEqual(0.0f, hover.GetScreenPosition(0).X, "Should be equals to the origin value of ScreenPosition.X");
            Assert.AreEqual(0.0f, hover.GetScreenPosition(0).Y, "Should be equals to the origin value of ScreenPosition.Y");
            hover.Dispose();
            tlog.Debug(tag, $"HoverGetScreenPosition END (OK)");
            Assert.Pass("HoverGetScreenPosition");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetPointCount.Check whether GetPointCount returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetPointCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverGetPointCount()
        {
            tlog.Debug(tag, $"HoverGetPointCount START");
            /* TEST CODE */
            Hover hover = new Hover();
            Assert.AreEqual(0, hover.GetPointCount(), "Should be equals to the origin value of pointCount");
            tlog.Debug(tag, $"HoverGetPointCount END (OK)");
            Assert.Pass("HoverGetPointCount");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetCPtr.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverGetCPtr()
        {
            tlog.Debug(tag, $"HoverGetCPtr START");
            Hover hover = new Hover();
            Hover.getCPtr(hover);
            Assert.Pass("HoverGetCPtr");
            tlog.Debug(tag, $"HoverGetCPtr END (OK)");
            Assert.Pass("HoverGetCPtr");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetHoverFromPtr.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetHoverFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverGetHoverFromPtr()
        {
            tlog.Debug(tag, $"HoverGetHoverFromPtr START");
            var hover2 = new Hover(2);
            
            Hover hover = Hover.GetHoverFromPtr(Hover.getCPtr(hover2).Handle);
            Assert.Pass("HoverGetHoverFromPtr");
			
            hover2.Dispose();
            hover.Dispose();
            tlog.Debug(tag, $"HoverGetHoverFromPtr END (OK)");
            Assert.Pass("HoverGetHoverFromPtr");
        }
    }
}

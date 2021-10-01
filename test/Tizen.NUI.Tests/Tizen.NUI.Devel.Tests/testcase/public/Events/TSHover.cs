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
        [Description("Create a Hover object.")]
        [Property("SPEC", "Tizen.NUI.Hover.Hover C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverConstructor()
        {
            tlog.Debug(tag, $"HoverConstructor START");

            var testingTarget = new Hover();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Hover>(testingTarget, "Should be an instance of Hover type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"HoverConstructor END (OK)");
            Assert.Pass("HoverConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Create a Hover object.")]
        [Property("SPEC", "Tizen.NUI.Hover.Hover C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverConstructorWithTime()
        {
            tlog.Debug(tag, $"HoverConstructorWithTime START");

            var testingTarget = new Hover(300);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Hover>(testingTarget, "Should be an instance of Hover type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"HoverConstructorWithTime END (OK)");
            Assert.Pass("HoverConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Create a Hover object.")]
        [Property("SPEC", "Tizen.NUI.Hover.Hover C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverConstructorWithHover()
        {
            tlog.Debug(tag, $"HoverConstructorWithHover START");

            using (Hover hover = new Hover(300))
            {
                var testingTarget = new Hover(hover);
                Assert.IsNotNull(testingTarget, "Can't create success object Hover");
                Assert.IsInstanceOf<Hover>(testingTarget, "Should be an instance of Hover type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"HoverConstructorWithHover END (OK)");
            Assert.Pass("HoverConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Test Time property.")]
        [Property("SPEC", "Tizen.NUI.Hover.Time A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverTime()
        {
            tlog.Debug(tag, $"HoverTime START");

            var testingTarget = new Hover();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Hover>(testingTarget, "Should be an instance of Hover type.");

            tlog.Debug(tag, "time : " + testingTarget.Time);
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"HoverTime END (OK)");
            Assert.Pass("HoverTime");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetDeviceId.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetDeviceId M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverGetDeviceId()
        {
            tlog.Debug(tag, $"HoverGetDeviceId START");

            var testingTarget = new Hover();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Hover>(testingTarget, "Should be an instance of Hover type.");

            tlog.Debug(tag, "DeviceId : " + testingTarget.GetDeviceId(0));
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"HoverGetDeviceId END (OK)");
            Assert.Pass("HoverGetDeviceId");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetState.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetState M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@partner.samsung.com")]
        public void HoverGetState()
        {
            tlog.Debug(tag, $"HoverGetState START");

            var testingTarget = new Hover();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Hover>(testingTarget, "Should be an instance of Hover type.");

            tlog.Debug(tag, "State : " + testingTarget.GetState(0));
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"HoverGetState END (OK)");
            Assert.Pass("HoverGetState");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetHitView.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetHitView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverGetHitView()
        {
            tlog.Debug(tag, $"HoverGetHitView START");

            var testingTarget = new Hover();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Hover>(testingTarget, "Should be an instance of Hover type.");

            tlog.Debug(tag, "HitView : " + testingTarget.GetHitView(0));
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"HoverGetHitView END (OK)");
            Assert.Pass("HoverGetHitView");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetLocalPosition.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetLocalPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverGetLocalPosition()
        {
            tlog.Debug(tag, $"HoverGetLocalPosition START");

            var testingTarget = new Hover();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Hover>(testingTarget, "Should be an instance of Hover type.");

            Assert.AreEqual(0.0f, testingTarget.GetLocalPosition(0).X, "Should be equals to the origin value of LocalPosition.X");
            Assert.AreEqual(0.0f, testingTarget.GetLocalPosition(0).Y, "Should be equals to the origin value of LocalPosition.Y");
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"HoverGetLocalPosition END (OK)");
            Assert.Pass("HoverGetLocalPosition");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetScreenPosition.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetScreenPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverGetScreenPosition()
        {
            tlog.Debug(tag, $"HoverGetScreenPosition START");

            var testingTarget = new Hover();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Hover>(testingTarget, "Should be an instance of Hover type.");

            Assert.AreEqual(0.0f, testingTarget.GetScreenPosition(0).X, "Should be equals to the origin value of ScreenPosition.X");
            Assert.AreEqual(0.0f, testingTarget.GetScreenPosition(0).Y, "Should be equals to the origin value of ScreenPosition.Y");
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"HoverGetScreenPosition END (OK)");
            Assert.Pass("HoverGetScreenPosition");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetPointCount.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetPointCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverGetPointCount()
        {
            tlog.Debug(tag, $"HoverGetPointCount START");

            var testingTarget = new Hover();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<Hover>(testingTarget, "Should be an instance of Hover type.");

            tlog.Debug(tag, "PointCount : " + testingTarget.GetPointCount());
            
            tlog.Debug(tag, $"HoverGetPointCount END (OK)");
            Assert.Pass("HoverGetPointCount");
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

            using (Hover hover = new Hover(300))
            {
                var testingTarget = Hover.GetHoverFromPtr(hover.SwigCPtr.Handle);
                Assert.IsNotNull(testingTarget, "Can't create success object Hover");
                Assert.IsInstanceOf<Hover>(testingTarget, "Should be an instance of Hover type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"HoverGetHoverFromPtr END (OK)");
            Assert.Pass("HoverGetHoverFromPtr");
        }
    }
}

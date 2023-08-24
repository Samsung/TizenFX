using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;
	
    [TestFixture]
    [Description("public/Events/GestureDetector")]
    class PublicGestureDetectorTest
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
        [Description("GestureDetector constructor")]
        [Property("SPEC", "Tizen.NUI.GestureDetector.GestureDetector C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureDetectorConstructor()
        {
            tlog.Debug(tag, $"GestureDetectorConstructor START");
			
            var testingTarget = new GestureDetector();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<GestureDetector>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GestureDetectorConstructor END (OK)");
            Assert.Pass("GestureDetectorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("GestureDetector Attach")]
        [Property("SPEC", "Tizen.NUI.GestureDetector.Attach M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureDetectorAttach()
        {
            tlog.Debug(tag, $"GestureDetectorAttach START");

            var testingTarget = new LongPressGestureDetector();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<LongPressGestureDetector>(testingTarget, "should be an instance of testing target class!");

            using (View view = new View())
            {
                Window.Instance.GetDefaultLayer().Add(view);
                testingTarget.Attach(view);
                testingTarget.Detach(view);
                Window.Instance.GetDefaultLayer().Remove(view);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"GestureDetectorAttach END (OK)");
            Assert.Pass("GestureDetectorAttach");
        }

        [Test]
        [Category("P1")]
        [Description("GestureDetector DetachAll")]
        [Property("SPEC", "Tizen.NUI.GestureDetector.DetachAll M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureDetectorDetachAll()
        {
            tlog.Debug(tag, $"GestureDetectorDetachAll START");

            var testingTarget = new LongPressGestureDetector();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<LongPressGestureDetector>(testingTarget, "should be an instance of testing target class!");

            using (View view = new View())
            {
                testingTarget.Attach(view);
                testingTarget.DetachAll();
            }

            testingTarget.Dispose();            
            tlog.Debug(tag, $"GestureDetectorDetachAll END (OK)");
            Assert.Pass("GestureDetectorDetachAll");
        }

        [Test]
        [Category("P1")]
        [Description("GestureDetector GetAttachedViewCount")]
        [Property("SPEC", "Tizen.NUI.GestureDetector.GetAttachedViewCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureDetectorGetAttachedViewCount()
        {
            tlog.Debug(tag, $"GestureDetectorGetAttachedViewCount START");

            var testingTarget = new LongPressGestureDetector();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<LongPressGestureDetector>(testingTarget, "should be an instance of testing target class!");

            using (View view = new View())
            {
                testingTarget.Attach(view);
                tlog.Debug(tag, "AttachedViewCount : " + testingTarget.GetAttachedViewCount());

                testingTarget.Detach(view);
            }

            testingTarget.Dispose();            
            tlog.Debug(tag, $"GestureDetectorGetAttachedViewCount END (OK)");
            Assert.Pass("GestureDetectorGetAttachedViewCount");
        }

        [Test]
        [Category("P1")]
        [Description("GestureDetector GetAttachedView")]
        [Property("SPEC", "Tizen.NUI.GestureDetector.GetAttachedView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureDetectorGetAttachedView()
        {
            tlog.Debug(tag, $"GestureDetectorGetAttachedView START");

            var testingTarget = new LongPressGestureDetector();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<LongPressGestureDetector>(testingTarget, "should be an instance of testing target class!");

            using (View view = new View())
            {
                testingTarget.Attach(view);
                testingTarget.GetAttachedView(0);
                testingTarget.Detach(view);
            }

            testingTarget.Dispose();            
            tlog.Debug(tag, $"GestureDetectorGetAttachedView END (OK)");
            Assert.Pass("GestureDetectorGetAttachedView");
        }

        [Test]
        [Category("P1")]
        [Description("GestureDetector DownCast")]
        [Property("SPEC", "Tizen.NUI.GestureDetector.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureDetectorDownCast()
        {
            tlog.Debug(tag, $"GestureDetectorDownCast START");

            using (GestureDetector detector = new GestureDetector())
            {
                var testingTarget = GestureDetector.DownCast(detector);
                Assert.IsInstanceOf<GestureDetector>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
            }
            
            tlog.Debug(tag, $"GestureDetectorDownCast END (OK)");
            Assert.Pass("GestureDetectorDownCast");
        }
    }
}

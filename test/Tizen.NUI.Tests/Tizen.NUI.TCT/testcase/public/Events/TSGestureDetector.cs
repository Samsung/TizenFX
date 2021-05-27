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
			
            GestureDetector ret = new GestureDetector();
            Assert.IsNotNull(ret, "should be not null");
            Assert.IsInstanceOf<GestureDetector>(ret, "should be an instance of testing target class!");

            GestureDetector newOne = new GestureDetector(ret);
            Assert.IsNotNull(newOne, "should be not null");
            Assert.IsInstanceOf<GestureDetector>(newOne, "should be an instance of testing target class!");

           
            GestureDetector newTwo = new GestureDetector(GestureDetector.getCPtr(ret).Handle, true);
            Assert.IsNotNull(newTwo, "should be not null");
            Assert.IsInstanceOf<GestureDetector>(newTwo, "should be an instance of testing target class!");

            ret.Dispose();
            newOne.Dispose();
            newTwo.Dispose();
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
			
            GestureDetector ret = new GestureDetector();
            Assert.IsNotNull(ret, "should be not null");
            Assert.IsInstanceOf<GestureDetector>(ret, "should be an instance of testing target class!");

            View view = new View();
            ret.Attach(view);

            ret.Detach(view);
            ret.Dispose();
            
            tlog.Debug(tag, $"GestureDetectorAttach END (OK)");
            Assert.Pass("GestureDetectorAttach");
        }

        [Test]
        [Category("P1")]
        [Description("GestureDetector Detach")]
        [Property("SPEC", "Tizen.NUI.GestureDetector.Detach M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureDetectorDetach()
        {
            tlog.Debug(tag, $"GestureDetectorDetach START");
            GestureDetector ret = new GestureDetector();
            Assert.IsNotNull(ret, "should be not null");
            Assert.IsInstanceOf<GestureDetector>(ret, "should be an instance of testing target class!");

            View view = new View();
            ret.Attach(view);

            ret.Detach(view);
            ret.Dispose();
            
            tlog.Debug(tag, $"GestureDetectorDetach END (OK)");
            Assert.Pass("GestureDetectorDetach");
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
            GestureDetector ret = new GestureDetector();
            Assert.IsNotNull(ret, "should be not null");
            Assert.IsInstanceOf<GestureDetector>(ret, "should be an instance of testing target class!");

            View view = new View();
            ret.Attach(view);

            ret.DetachAll();
            ret.Dispose();
            
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
            GestureDetector ret = new GestureDetector();
            Assert.IsNotNull(ret, "should be not null");
            Assert.IsInstanceOf<GestureDetector>(ret, "should be an instance of testing target class!");

            View view = new View();
            ret.Attach(view);

            ret.GetAttachedViewCount();

            ret.Detach(view);
            ret.Dispose();
            
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
            GestureDetector ret = new GestureDetector();
            Assert.IsNotNull(ret, "should be not null");
            Assert.IsInstanceOf<GestureDetector>(ret, "should be an instance of testing target class!");

            View view = new View();
            ret.Attach(view);

            ret.GetAttachedView(0);

            ret.Detach(view);
            ret.Dispose();
            
            tlog.Debug(tag, $"GestureDetectorGetAttachedView END (OK)");
            Assert.Pass("GestureDetectorGetAttachedView");
        }

        [Test]
        [Category("P1")]
        [Description("GestureDetector Assign")]
        [Property("SPEC", "Tizen.NUI.GestureDetector.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureDetectorAssign()
        {
            tlog.Debug(tag, $"GestureDetectorAssign START");
            GestureDetector ret = new GestureDetector();
            GestureDetector newOne = new GestureDetector();
            
            newOne = ret;
            
            ret.Dispose();
            newOne.Dispose();
            
            
            tlog.Debug(tag, $"GestureDetectorAssign END (OK)");
            Assert.Pass("GestureDetectorAssign");
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
            BaseHandle handle = new BaseHandle();
            GestureDetector ret = GestureDetector.DownCast(handle);

            Assert.IsNotNull(ret, "should be not null");
            Assert.IsInstanceOf<GestureDetector>(ret, "should be an instance of testing target class!");
            tlog.Debug(tag, $"GestureDetectorDownCast END (OK)");
            Assert.Pass("GestureDetectorDownCast");
        }

        [Test]
        [Category("P1")]
        [Description("GestureDetector getCPtr")]
        [Property("SPEC", "Tizen.NUI.GestureDetector.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureDetectorgetCPtr()
        {
            tlog.Debug(tag, $"GestureDetectorgetCPtr START");
            GestureDetector ret = new GestureDetector();
            Assert.IsNotNull(ret, "should be not null");
            Assert.IsInstanceOf<GestureDetector>(ret, "should be an instance of testing target class!");

            global::System.Runtime.InteropServices.HandleRef ptr = GestureDetector.getCPtr(ret);

            GestureDetector newOne = null;
            ptr = GestureDetector.getCPtr(newOne);

            ret.Dispose();
            
            tlog.Debug(tag, $"GestureDetectorgetCPtr END (OK)");
            Assert.Pass("GestureDetectorgetCPtr");
        }
    }
}

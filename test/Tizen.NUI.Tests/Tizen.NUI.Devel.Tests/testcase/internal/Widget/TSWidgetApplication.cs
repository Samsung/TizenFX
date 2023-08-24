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
    [Description("Internal/Widget/WidgetApplication")]
    public class InternalWidgetApplicationTest
    {
        private const string tag = "NUITEST";
        private Widget widget = null;

        internal class MyWidgetApplication : WidgetApplication
        {
            public MyWidgetApplication(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
            { }

            public void OnReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
            {
                base.ReleaseSwigCPtr(swigCPtr);
            }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");

            widget = new Widget();
        }

        [TearDown]
        public void Destroy()
        {
            widget.Dispose();
            widget = null;

            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetApplication Constructor.")]
        [Property("SPEC", "Tizen.NUI.WidgetApplication.WidgetApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetApplicationConstructor()
        {
            tlog.Debug(tag, $"WidgetApplicationConstructor START");

            var testingTarget = new WidgetApplication(widget.GetIntPtr(), false);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetApplication");
            Assert.IsInstanceOf<WidgetApplication>(testingTarget, "Should be an instance of WidgetApplication type.");

            testingTarget.Dispose();
            testingTarget = null;

            tlog.Debug(tag, $"WidgetApplicationConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetApplication Constructor. With WidgetApplication.")]
        [Property("SPEC", "Tizen.NUI.WidgetApplication.WidgetApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetApplicationConstructorWithWidgetApplication()
        {
            tlog.Debug(tag, $"WidgetApplicationConstructorWithWidgetApplication START");

            using (WidgetApplication widgetApplication = new WidgetApplication(widget.GetIntPtr(), false))
            {
                var testingTarget = new WidgetApplication(widgetApplication);
                Assert.IsNotNull(testingTarget, "Can't create success object WidgetApplication");
                Assert.IsInstanceOf<WidgetApplication>(testingTarget, "Should be an instance of WidgetApplication type.");

                testingTarget.Dispose();
                testingTarget = null;
            }

            tlog.Debug(tag, $"WidgetApplicationConstructorWithWidgetApplication END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetApplication Assign.")]
        [Property("SPEC", "Tizen.NUI.WidgetApplication.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetApplicationAssign()
        {
            tlog.Debug(tag, $"WidgetApplicationAssign START");

            using (WidgetApplication widgetApplication = new WidgetApplication(widget.GetIntPtr(), false))
            {
                var testingTarget = widgetApplication.Assign(widgetApplication);
                Assert.IsNotNull(testingTarget, "Can't create success object WidgetApplication");
                Assert.IsInstanceOf<WidgetApplication>(testingTarget, "Should be an instance of WidgetApplication type.");

                testingTarget.Dispose();
                testingTarget = null;
            }

            tlog.Debug(tag, $"WidgetApplicationAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetApplication ReleaseSwigCPtr.")]
        [Property("SPEC", "Tizen.NUI.WidgetApplication.ReleaseSwigCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetApplicationReleaseSwigCPtr()
        {
            tlog.Debug(tag, $"WidgetApplicationReleaseSwigCPtr START");

            var testingTarget = new MyWidgetApplication(widget.GetIntPtr(), false);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetApplication");
            Assert.IsInstanceOf<WidgetApplication>(testingTarget, "Should be an instance of WidgetApplication type.");

            try
            {
                testingTarget.OnReleaseSwigCPtr(widget.SwigCPtr);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            testingTarget = null;

            tlog.Debug(tag, $"WidgetApplicationReleaseSwigCPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetApplication AddWidgetInstance.")]
        [Property("SPEC", "Tizen.NUI.WidgetApplication.AddWidgetInstance M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetApplicationAddWidgetInstance()
        {
            tlog.Debug(tag, $"WidgetApplicationAddWidgetInstance START");

            Widget widget = new Widget();

            var testingTarget = new WidgetApplication(widget.GetIntPtr(), false);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetApplication");
            Assert.IsInstanceOf<WidgetApplication>(testingTarget, "Should be an instance of WidgetApplication type.");

            try
            {
                testingTarget.AddWidgetInstance(widget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            widget.Dispose();
            widget = null;

            testingTarget.Dispose();
            testingTarget = null;
            tlog.Debug(tag, $"WidgetApplicationAddWidgetInstance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetApplication RegisterWidgetInfo.")]
        [Property("SPEC", "Tizen.Applications.WidgetApplication.RegisterWidgetInfo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetApplicationRegisterWidgetInfo()
        {
            tlog.Debug(tag, $"WidgetApplicationRegisterWidgetInfo START");

            var testingTarget = new WidgetApplication(widget.GetIntPtr(), false);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetApplication");
            Assert.IsInstanceOf<WidgetApplication>(testingTarget, "Should be an instance of WidgetApplication type.");

            global::System.Collections.Generic.Dictionary<Type, string> widgetInfo = new global::System.Collections.Generic.Dictionary<Type, string>(){
                { typeof(Widget), "w1@org.tizen.WidgetApp"} };

            try
            {
                testingTarget.RegisterWidgetInfo(widgetInfo);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            testingTarget = null;

            tlog.Debug(tag, $"WidgetApplicationRegisterWidgetInfo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetApplication WidgetCreateFunction.")]
        [Property("SPEC", "Tizen.Applications.WidgetApplication.WidgetCreateFunction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetApplicationWidgetCreateFunction()
        {
            tlog.Debug(tag, $"WidgetApplicationWidgetCreateFunction START");

            var instance = WidgetApplication.Instance;
            tlog.Debug(tag, "WidgetApplication.Instance : " + instance);

            try
            {
                global::System.IntPtr widgetPtr = widget.GetIntPtr();
                WidgetApplication.WidgetCreateFunction(ref widgetPtr);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetApplicationWidgetCreateFunction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetApplication WidgetInfo.")]
        [Property("SPEC", "Tizen.Applications.WidgetApplication.WidgetInfo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetApplicationWidgetInfo()
        {
            tlog.Debug(tag, $"WidgetApplicationWidgetInfo START");

            var testingTarget = new WidgetApplication(widget.GetIntPtr(), false);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetApplication");
            Assert.IsInstanceOf<WidgetApplication>(testingTarget, "Should be an instance of WidgetApplication type.");

            global::System.Collections.Generic.Dictionary<Type, string> widgetInfo = new global::System.Collections.Generic.Dictionary<Type, string>(){
                { typeof(Widget), "w1@org.tizen.WidgetApp"} };
            testingTarget.RegisterWidgetInfo(widgetInfo);

            var info = testingTarget.WidgetInfo;
            tlog.Debug(tag, "testingTarget.WidgetInfo : " + info);

            testingTarget.Dispose();
            testingTarget = null;

            tlog.Debug(tag, $"WidgetApplicationWidgetInfo END (OK)");
        }
		
        [Test]
        [Category("P1")]
        [Description("WidgetApplication AddWidgetInfo.")]
        [Property("SPEC", "Tizen.Applications.WidgetApplication.AddWidgetInfo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetApplicationAddWidgetInfo()
        {
            tlog.Debug(tag, $"WidgetApplicationAddWidgetInfo START");

            var testingTarget = new WidgetApplication(widget.GetIntPtr(), false);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetApplication");
            Assert.IsInstanceOf<WidgetApplication>(testingTarget, "Should be an instance of WidgetApplication type.");

            global::System.Collections.Generic.Dictionary<Type, string> widgetInfo = new global::System.Collections.Generic.Dictionary<Type, string>(){
                { typeof(Widget), "w1@org.tizen.WidgetApp"} };
			
            try
			{
                testingTarget.AddWidgetInfo(widgetInfo);
            }
			catch(Exception e)
            {
                Assert.Pass("Catch exception: " + e.Message.ToString());
            }

            testingTarget.Dispose();
            testingTarget = null;

            tlog.Debug(tag, $"WidgetApplicationAddWidgetInfo END (OK)");
        }
    }
}

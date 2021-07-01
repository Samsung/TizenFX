using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Window/GLWindowVisibilityChangedEvent")]
    internal class PublicGLWindowVisibilityChangedEventTest
    {
        private const string tag = "NUITEST";

        private delegate bool dummyCallback(IntPtr glWindow);
        private bool OnDummyCallback(IntPtr data)
        {
            return false;
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
        [Description("Create a GLWindowVisibilityChangedEvent object.")]
        [Property("SPEC", "Tizen.NUI.GLWindowVisibilityChangedEvent.GLWindowVisibilityChangedEvent C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        public void GLWindowVisibilityChangedEventConstructor()
        {
            tlog.Debug(tag, $"GLWindowVisibilityChangedEventConstructor START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            GLWindowVisibilityChangedEvent b1 = new GLWindowVisibilityChangedEvent(a1.SwigCPtr.Handle, false);

            b1.Dispose();
            a1.Destroy();
            tlog.Debug(tag, $"GLWindowVisibilityChangedEventConstructor END (OK)");
            Assert.Pass("GLWindowVisibilityChangedEventConstructor");
        }

        //[Test]
        //[Category("P1")]
        //[Description("GLWindowVisibilityChangedEvent Empty")]
        //[Property("SPEC", "Tizen.NUI.GLWindowVisibilityChangedEvent.Empty M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void GLWindowVisibilityChangedEventEmpty()
        //{
        //    tlog.Debug(tag, $"GLWindowVisibilityChangedEventEmpty START");

        //    using (GLWindow glWindow = new GLWindow())
        //    {
        //        var testingTarget = new GLWindowVisibilityChangedEvent(glWindow.SwigCPtr.Handle, false);

        //        try
        //        {
        //            var result = testingTarget.Empty();
        //            tlog.Debug(tag, "result : " + result);
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception : Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"GLWindowVisibilityChangedEventEmpty END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("GLWindowVisibilityChangedEvent GetConnectionCount")]
        [Property("SPEC", "Tizen.NUI.GLWindowVisibilityChangedEvent.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowVisibilityChangedEventGetConnectionCount()
        {
            tlog.Debug(tag, $"GLWindowVisibilityChangedEventGetConnectionCount START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            GLWindowVisibilityChangedEvent b1 = new GLWindowVisibilityChangedEvent(a1.SwigCPtr.Handle, false);
            b1.GetConnectionCount();

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowVisibilityChangedEventGetConnectionCount END (OK)");
            Assert.Pass("GLWindowVisibilityChangedEventGetConnectionCount");
        }

        //[Test]
        //[Category("P1")]
        //[Description("GLWindowVisibilityChangedEvent Connect")]
        //[Property("SPEC", "Tizen.NUI.GLWindowVisibilityChangedEvent.Connect M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void GLWindowVisibilityChangedEventConnect()
        //{
        //    tlog.Debug(tag, $"GLWindowVisibilityChangedEventConnect START");

        //    using (GLWindow glWindow = new GLWindow())
        //    {
        //        var testingTarget = new GLWindowVisibilityChangedEvent(glWindow.SwigCPtr.Handle, false);

        //        try
        //        {
        //            dummyCallback callback = OnDummyCallback;
        //            testingTarget.Connect(callback);
        //            testingTarget.Disconnect(callback);
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception : Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"GLWindowVisibilityChangedEventConnect END (OK)");
        //    Assert.Pass("GLWindowVisibilityChangedEventConnect");
        //}

        [Test]
        [Category("P1")]
        [Description("GLWindowVisibilityChangedEvent Emit")]
        [Property("SPEC", "Tizen.NUI.GLWindowVisibilityChangedEvent.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowVisibilityChangedEventEmit()
        {
            tlog.Debug(tag, $"GLWindowVisibilityChangedEventEmit START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            GLWindowVisibilityChangedEvent b1 = new GLWindowVisibilityChangedEvent(a1.SwigCPtr.Handle, false);
            b1.Emit(a1, true);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowVisibilityChangedEventEmit END (OK)");
            Assert.Pass("GLWindowVisibilityChangedEventEmit");
        }
    }
}


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
            Rectangle rec = new Rectangle(20, 20, 100, 100);
            GLWindow glwin = new GLWindow(name, rec, true);

            var testingTarget = new GLWindowVisibilityChangedEvent(glwin.SwigCPtr.Handle, false);
            Assert.IsNotNull(testingTarget, "Can't create success object GLWindowVisibilityChangedEvent");
            Assert.IsInstanceOf<GLWindowVisibilityChangedEvent>(testingTarget, "Should be an instance of GLWindowVisibilityChangedEvent type.");

            rec.Dispose();
            glwin.Destroy();
            testingTarget.Dispose();
            tlog.Debug(tag, $"GLWindowVisibilityChangedEventConstructor END (OK)");
        }

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
            Rectangle rec = new Rectangle(20, 20, 100, 100);
            GLWindow glwin = new GLWindow(name, rec, true);

            var testingTarget = new GLWindowVisibilityChangedEvent(glwin.SwigCPtr.Handle, false);
            Assert.IsNotNull(testingTarget, "Can't create success object GLWindowVisibilityChangedEvent");
            Assert.IsInstanceOf<GLWindowVisibilityChangedEvent>(testingTarget, "Should be an instance of GLWindowVisibilityChangedEvent type.");

            var result = testingTarget.GetConnectionCount();
            tlog.Debug(tag, "ConnectionCount : " + result);

            rec.Dispose();
            glwin.Destroy();
            testingTarget.Dispose();
            tlog.Debug(tag, $"GLWindowVisibilityChangedEventGetConnectionCount END (OK)");
        }

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
            Rectangle rec = new Rectangle(20, 20, 100, 100);
            GLWindow glwin = new GLWindow(name, rec, true);

            var testingTarget = new GLWindowVisibilityChangedEvent(glwin.SwigCPtr.Handle, false);
            Assert.IsNotNull(testingTarget, "Can't create success object GLWindowVisibilityChangedEvent");
            Assert.IsInstanceOf<GLWindowVisibilityChangedEvent>(testingTarget, "Should be an instance of GLWindowVisibilityChangedEvent type.");

            try
            {
                testingTarget.Emit(glwin, true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            rec.Dispose();
            glwin.Destroy();
            testingTarget.Dispose();
            tlog.Debug(tag, $"GLWindowVisibilityChangedEventEmit END (OK)");
        }
    }
}


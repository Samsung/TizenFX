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

            using (Rectangle rec = new Rectangle(20, 20, 100, 100))
            {
                var glwin = new GLWindow("myGLWindow", rec, true);

                var testingTarget = new GLWindowVisibilityChangedEvent(glwin.SwigCPtr.Handle, true);
                Assert.IsNotNull(testingTarget, "Can't create success object GLWindowVisibilityChangedEvent");
                Assert.IsInstanceOf<GLWindowVisibilityChangedEvent>(testingTarget, "Should be an instance of GLWindowVisibilityChangedEvent type.");

                tlog.Debug(tag, "ConnectionCount : " + testingTarget.GetConnectionCount());

                try
                {
                    testingTarget.Emit(glwin, true);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"GLWindowVisibilityChangedEventConstructor END (OK)");
        }
    }
}


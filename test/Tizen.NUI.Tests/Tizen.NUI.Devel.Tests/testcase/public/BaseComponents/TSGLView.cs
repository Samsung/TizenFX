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
    [Description("public/BaseComponents/GLView ")]
    public class PublicGLViewTest
    {
        private const string tag = "NUITEST";

	    public void ViewResize(int w, int h) { }
		
		public void GLInitialize() {}
		
	    public int GLRenderFrame() { return 5;}
		
		public void GLTerminate() {}
		
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
        [Description("GLView  constructor.")]
        [Property("SPEC", "Tizen.NUI.GLView .GLView  C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GLViewConstructor()
        {
            tlog.Debug(tag, $"GLViewConstructor START");

            try
            {
                var testingTarget = new GLView(GLView.ColorFormat.RGBA8888);
                Assert.IsNotNull(testingTarget, "Can't create success object GLView ");
                Assert.IsInstanceOf<GLView>(testingTarget, "Should be an instance of GLView  type.");

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"GLViewConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLView RenderingMode")]
        [Property("SPEC", "Tizen.NUI.GLView.RenderingMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GLViewRenderingMode()
        {
            tlog.Debug(tag, $"GLViewRenderingMode START");

            try
            {
                var testingTarget = new GLView(GLView.ColorFormat.RGBA8888);
                Assert.IsNotNull(testingTarget, "Can't create success object GLView");
                Assert.IsInstanceOf<GLView>(testingTarget, "Should be an instance of GLView type.");

                testingTarget.RenderingMode = GLRenderingMode.OnDemand;
                var result = testingTarget.RenderingMode;
                Assert.AreEqual(GLRenderingMode.OnDemand, result, "Should be equal!");

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"GLViewRenderingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLView RenderOnce")]
        [Property("SPEC", "Tizen.NUI.GLView.RenderOnce M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GLViewRenderOnce()
        {
            tlog.Debug(tag, $"GLViewRenderOnce START");

            var testingTarget = new GLView(GLView.ColorFormat.RGBA8888);
            Assert.IsNotNull(testingTarget, "Can't create success object GLView");
            Assert.IsInstanceOf<GLView>(testingTarget, "Should be an instance of GLView type.");

            try
            {
                testingTarget.RenderOnce();
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"GLViewRenderOnce END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLView SetResizeCallback")]
        [Property("SPEC", "Tizen.NUI.GLView.SetResizeCallback M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GLViewSetResizeCallback()
        {
            tlog.Debug(tag, $"GLViewSetResizeCallback START");

            var testingTarget = new GLView(GLView.ColorFormat.RGBA8888);
            Assert.IsNotNull(testingTarget, "Can't create success object GLView");
            Assert.IsInstanceOf<GLView>(testingTarget, "Should be an instance of GLView type.");

            try
            {
                testingTarget.SetResizeCallback(ViewResize);
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"GLViewSetResizeCallback END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLView RegisterGLCallbacks")]
        [Property("SPEC", "Tizen.NUI.GLView.RegisterGLCallbacks M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GLViewRegisterGLCallbacks()
        {
            tlog.Debug(tag, $"GLViewRegisterGLCallbacks START");

            var testingTarget = new GLView(GLView.ColorFormat.RGBA8888);
            Assert.IsNotNull(testingTarget, "Can't create success object GLView");
            Assert.IsInstanceOf<GLView>(testingTarget, "Should be an instance of GLView type.");

            try
            {
                testingTarget.RegisterGLCallbacks(GLInitialize, GLRenderFrame, GLTerminate);
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"GLViewRegisterGLCallbacks END (OK)");
        }
    }
}
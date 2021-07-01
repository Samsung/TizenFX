using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Window/GLWindow.cs")]
    internal class PublicGLWindowTest
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
        [Description("GLWindow constructor.")]
        [Property("SPEC", "Tizen.NUI.GLWindow.GLWindow C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        public void GLWindowConstructor()
        {
            tlog.Debug(tag, $"GLWindowConstructor START");

            var testingTarget = new GLWindow();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<GLWindow>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Destroy();
            tlog.Debug(tag, $"GLWindowConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow constructor. With name.")]
        [Property("SPEC", "Tizen.NUI.GLWindow.GLWindow C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        public void GLWindowConstructorWithName()
        {
            tlog.Debug(tag, $"GLWindowConstructorWithName START");

            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowConstructorWithName END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow constructor. With GLWindow.")]
        [Property("SPEC", "Tizen.NUI.GLWindow.GLWindow C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        public void GLWindowConstructorWithGLWindow()
        {
            tlog.Debug(tag, $"GLWindowConstructorWithGLWindow START");

            using (GLWindow glwindow = new GLWindow())
            {
                var testingTarget = new GLWindow(glwindow.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<GLWindow>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Destroy();
            }

            tlog.Debug(tag, $"GLWindowConstructorWithGLWindow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow WindowSize")]
        [Property("SPEC", "Tizen.NUI.GLWindow.WindowSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void GLWindowWindowSize()
        {
            tlog.Debug(tag, $"GLWindowWindowSize START");

            var testingTarget = new GLWindow();
            Assert.IsNotNull(testingTarget, "Can't create success object GLWindow");
            Assert.IsInstanceOf<GLWindow>(testingTarget, "Should be an instance of GLWindow type.");

            testingTarget.WindowSize = new Size2D(50, 30);
            Assert.AreEqual(50, testingTarget.WindowSize.Width, "Should be equal!");
            Assert.AreEqual(30, testingTarget.WindowSize.Height, "Should be equal!");

            testingTarget.Destroy();
            tlog.Debug(tag, $"GLWindowWindowSize END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("GLWindow SetEglConfig")]
        //[Property("SPEC", "Tizen.NUI.GLWindow.SetEglConfig M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void GLWindowSetEglConfig()
        //{
        //    tlog.Debug(tag, $"GLWindowSetEglConfig START");

        //    var testingTarget = new GLWindow();
        //    Assert.IsNotNull(testingTarget, "Can't create success object GLWindow");
        //    Assert.IsInstanceOf<GLWindow>(testingTarget, "Should be an instance of GLWindow type.");

        //    try
        //    {
        //        testingTarget.SetEglConfig(true, true, 10, GLESVersion.Version20);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    testingTarget.Destroy();
        //    tlog.Debug(tag, $"GLWindowSetEglConfig END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("GLWindow Show")]
        [Property("SPEC", "Tizen.NUI.GLWindow.Show M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowShow()
        {
            tlog.Debug(tag, $"GLWindowShow START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.Show();
            a1.Destroy();
            tlog.Debug(tag, $"GLWindowShow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow Hide")]
        [Property("SPEC", "Tizen.NUI.GLWindow.Hide M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowHide()
        {
            tlog.Debug(tag, $"GLWindowHide START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.Hide();

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowHide END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("GLWindow Raise")]
        [Property("SPEC", "Tizen.NUI.GLWindow.Raise M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowRaise()
        {
            tlog.Debug(tag, $"GLWindowRaise START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.Raise();

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowRaise END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow Lower")]
        [Property("SPEC", "Tizen.NUI.GLWindow.Lower M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowLower()
        {
            tlog.Debug(tag, $"GLWindowLower START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.Lower();

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowLower END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow Activate")]
        [Property("SPEC", "Tizen.NUI.GLWindow.Activate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowActivate()
        {
            tlog.Debug(tag, $"GLWindowActivate START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.Activate();

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowActivate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow WindowPositionSize")]
        [Property("SPEC", "Tizen.NUI.GLWindow.WindowPositionSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void GLWindowWindowPositionSize()
        {
            tlog.Debug(tag, $"GLWindowWindowPositionSize START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.WindowPositionSize = new Rectangle(30, 40, 50, 60);
            Assert.AreEqual(30, a1.WindowPositionSize.X, "Should be equal!");
            Assert.AreEqual(40, a1.WindowPositionSize.Y, "Should be equal!");
            Assert.AreEqual(50, a1.WindowPositionSize.Width, "Should be equal!");
            Assert.AreEqual(60, a1.WindowPositionSize.Height, "Should be equal!");

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowWindowPositionSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow GetSupportedAuxiliaryHintCount")]
        [Property("SPEC", "Tizen.NUI.GLWindow.GetSupportedAuxiliaryHintCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowGetSupportedAuxiliaryHintCount()
        {
            tlog.Debug(tag, $"GLWindowGetSupportedAuxiliaryHintCount START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            var result =  a1.GetSupportedAuxiliaryHintCount();
            tlog.Debug(tag, "SupportedAuxiliaryHintCount : " + result);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowGetSupportedAuxiliaryHintCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow GetSupportedAuxiliaryHint")]
        [Property("SPEC", "Tizen.NUI.GLWindow.GetSupportedAuxiliaryHint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowGetSupportedAuxiliaryHint()
        {
            tlog.Debug(tag, $"GLWindowGetSupportedAuxiliaryHint START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            var result = a1.GetSupportedAuxiliaryHint(1);
            tlog.Debug(tag, "GetSupportedAuxiliaryHint : " + result);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowGetSupportedAuxiliaryHint END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow AddAuxiliaryHint")]
        [Property("SPEC", "Tizen.NUI.GLWindow.AddAuxiliaryHint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowAddAuxiliaryHint()
        {
            tlog.Debug(tag, $"GLWindowAddAuxiliaryHint START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.AddAuxiliaryHint("myHint", "myValue");

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowAddAuxiliaryHint END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow RemoveAuxiliaryHint")]
        [Property("SPEC", "Tizen.NUI.GLWindow.RemoveAuxiliaryHint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowRemoveAuxiliaryHint()
        {
            tlog.Debug(tag, $"GLWindowRemoveAuxiliaryHint START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            uint pos = a1.AddAuxiliaryHint("myHint", "myValue");
            a1.RemoveAuxiliaryHint(pos);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowRemoveAuxiliaryHint END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow SetAuxiliaryHintValue")]
        [Property("SPEC", "Tizen.NUI.GLWindow.SetAuxiliaryHintValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowSetAuxiliaryHintValue()
        {
            tlog.Debug(tag, $"GLWindowSetAuxiliaryHintValue START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            uint pos = a1.AddAuxiliaryHint("myHint", "myValue");
            a1.SetAuxiliaryHintValue(pos, "myValue");

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowSetAuxiliaryHintValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow GetAuxiliaryHintValue")]
        [Property("SPEC", "Tizen.NUI.GLWindow.GetAuxiliaryHintValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowGetAuxiliaryHintValue()
        {
            tlog.Debug(tag, $"GLWindowGetAuxiliaryHintValue START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            uint pos = a1.AddAuxiliaryHint("myHint", "myValue");
            a1.GetAuxiliaryHintValue(pos);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowGetAuxiliaryHintValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow GetAuxiliaryHintId")]
        [Property("SPEC", "Tizen.NUI.GLWindow.GetAuxiliaryHintId M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowGetAuxiliaryHintId()
        {
            tlog.Debug(tag, $"GLWindowGetAuxiliaryHintId START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            uint pos = a1.AddAuxiliaryHint("myHint", "myValue");
            a1.GetAuxiliaryHintId("myHint");

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowGetAuxiliaryHintId END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow SetInputRegion")]
        [Property("SPEC", "Tizen.NUI.GLWindow.SetInputRegion M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowSetInputRegion()
        {
            tlog.Debug(tag, $"GLWindowSetInputRegion START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.SetInputRegion(rectangle);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowGetAuxiliaryHintId END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow SetOpaqueState")]
        [Property("SPEC", "Tizen.NUI.GLWindow.SetOpaqueState M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowSetOpaqueState()
        {
            tlog.Debug(tag, $"GLWindowSetOpaqueState START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.SetOpaqueState(true);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowSetOpaqueState END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow IsOpaqueState")]
        [Property("SPEC", "Tizen.NUI.GLWindow.IsOpaqueState M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowIsOpaqueState()
        {
            tlog.Debug(tag, $"GLWindowIsOpaqueState START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            var result = a1.IsOpaqueState();
            tlog.Debug(tag, "IsOpaqueState : " + result);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowIsOpaqueState END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow SetPreferredOrientation")]
        [Property("SPEC", "Tizen.NUI.GLWindow.SetPreferredOrientation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowSetPreferredOrientation()
        {
            tlog.Debug(tag, $"GLWindowSetPreferredOrientation START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            GLWindow.GLWindowOrientation o1 = new GLWindow.GLWindowOrientation();
            a1.SetPreferredOrientation(o1);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowSetPreferredOrientation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow GetCurrentOrientation")]
        [Property("SPEC", "Tizen.NUI.GLWindow.GetCurrentOrientation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowGetCurrentOrientation()
        {
            tlog.Debug(tag, $"GLWindowGetCurrentOrientation START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            var result =  a1.GetCurrentOrientation();
            tlog.Debug(tag, "CurrentOrientation : " + result);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowGetCurrentOrientation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow SetAvailableOrientations")]
        [Property("SPEC", "Tizen.NUI.GLWindow.SetAvailableOrientations M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowSetAvailableOrientations()
        {
            tlog.Debug(tag, $"GLWindowSetAvailableOrientations START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            GLWindow.GLWindowOrientation o1 = new GLWindow.GLWindowOrientation();
            List<GLWindow.GLWindowOrientation> l1 = new List<GLWindow.GLWindowOrientation>
            {
                o1
            };

            a1.SetAvailableOrientations(l1);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowSetAvailableOrientations END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow RenderOnce")]
        [Property("SPEC", "Tizen.NUI.GLWindow.RenderOnce M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowRenderOnce()
        {
            tlog.Debug(tag, $"GLWindowRenderOnce START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.RenderOnce();

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowRenderOnce END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow RegisterGlCallback")]
        [Property("SPEC", "Tizen.NUI.GLWindow.RegisterGlCallback M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowRegisterGlCallback()
        {
            tlog.Debug(tag, $"GLWindowRegisterGlCallback START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.RegisterGlCallback(GLInit, GLRenderFrame, GLTerminate);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowRegisterGlCallback END (OK)");
        }

        public void GLInit() { }
        public int GLRenderFrame() { return 0; }
        public void GLTerminate() { }
    }
}


using NUnit.Framework;
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
        [Description("Create a GLWindow object.")]
        [Property("SPEC", "Tizen.NUI.GLWindow.GLWindow C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        public void GLWindowConstructor()
        {
            tlog.Debug(tag, $"GLWindowConstructor START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            GLWindow a2 = new GLWindow();
            GLWindow a3 = new GLWindow(GLWindow.getCPtr(a1).Handle, true);

            a1.Destroy();
            a2.Destroy();
            a3.Destroy();
            tlog.Debug(tag, $"GLWindowConstructor END (OK)");
            Assert.Pass("GLWindowConstructor");
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
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            Size2D b1 = a1.WindowSize;
            a1.WindowSize = b1;
            a1.WindowSize = null;

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowWindowSize END (OK)");
            Assert.Pass("GLWindowWindowSize");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow SetEglConfig")]
        [Property("SPEC", "Tizen.NUI.GLWindow.SetEglConfig M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowSetEglConfig()
        {
            tlog.Debug(tag, $"GLWindowSetEglConfig START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            GLWindow.GLESVersion b1 = new GLWindow.GLESVersion();
            a1.SetEglConfig(true, true, 10, b1);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowSetEglConfig END (OK)");
            Assert.Pass("GLWindowSetEglConfig");
        }

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
            Assert.Pass("GLWindowShow");
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

            tlog.Debug(tag, $"GLWindowHide END (OK)");
            Assert.Pass("GLWindowHide");
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

            tlog.Debug(tag, $"GLWindowRaise END (OK)");
            Assert.Pass("GLWindowRaise");
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

            tlog.Debug(tag, $"GLWindowLower END (OK)");
            Assert.Pass("GLWindowLower");
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

            tlog.Debug(tag, $"GLWindowActivate END (OK)");
            Assert.Pass("GLWindowActivate");
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

            Rectangle b1 = a1.WindowPositionSize;
            a1.WindowPositionSize = b1;

            tlog.Debug(tag, $"GLWindowWindowPositionSize END (OK)");
            Assert.Pass("GLWindowWindowPositionSize");
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

            a1.GetSupportedAuxiliaryHintCount();

            tlog.Debug(tag, $"GLWindowGetSupportedAuxiliaryHintCount END (OK)");
            Assert.Pass("GLWindowGetSupportedAuxiliaryHintCount");
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

            a1.GetSupportedAuxiliaryHint(1);

            tlog.Debug(tag, $"GLWindowGetSupportedAuxiliaryHint END (OK)");
            Assert.Pass("GLWindowGetSupportedAuxiliaryHint");
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

            tlog.Debug(tag, $"GLWindowAddAuxiliaryHint END (OK)");
            Assert.Pass("GLWindowAddAuxiliaryHint");
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

            tlog.Debug(tag, $"GLWindowRemoveAuxiliaryHint END (OK)");
            Assert.Pass("GLWindowRemoveAuxiliaryHint");
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


            tlog.Debug(tag, $"GLWindowSetAuxiliaryHintValue END (OK)");
            Assert.Pass("GLWindowSetAuxiliaryHintValue");
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


            tlog.Debug(tag, $"GLWindowGetAuxiliaryHintValue END (OK)");
            Assert.Pass("GLWindowGetAuxiliaryHintValue");
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

            tlog.Debug(tag, $"GLWindowGetAuxiliaryHintId END (OK)");
            Assert.Pass("GLWindowGetAuxiliaryHintId");
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
            tlog.Debug(tag, $"GLWindowGetAuxiliaryHintId END (OK)");
            Assert.Pass("GLWindowGetAuxiliaryHintId");
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
            tlog.Debug(tag, $"GLWindowSetOpaqueState END (OK)");
            Assert.Pass("GLWindowSetOpaqueState");
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

            a1.IsOpaqueState();
            tlog.Debug(tag, $"GLWindowIsOpaqueState END (OK)");
            Assert.Pass("GLWindowIsOpaqueState");
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
            tlog.Debug(tag, $"GLWindowSetPreferredOrientation END (OK)");
            Assert.Pass("GLWindowSetPreferredOrientation");
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


            a1.GetCurrentOrientation();
            tlog.Debug(tag, $"GLWindowGetCurrentOrientation END (OK)");
            Assert.Pass("GLWindowGetCurrentOrientation");
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

            tlog.Debug(tag, $"GLWindowSetAvailableOrientations END (OK)");
            Assert.Pass("GLWindowSetAvailableOrientations");
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
            tlog.Debug(tag, $"GLWindowRenderOnce END (OK)");
            Assert.Pass("GLWindowRenderOnce");
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


            a1.RegisterGlCallback(b1, c1, d1);
            tlog.Debug(tag, $"GLWindowRegisterGlCallback END (OK)");
            Assert.Pass("GLWindowRegisterGlCallback");
        }

        public void b1() { }
        public int c1() { return 0; }
        public void d1() { }

        [Test]
        [Category("P1")]
        [Description("GLWindow Destroy")]
        [Property("SPEC", "Tizen.NUI.GLWindow.Destroy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowDestroy()
        {
            tlog.Debug(tag, $"GLWindowDestroy START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowDestroy END (OK)");
            Assert.Pass("GLWindowDestroy");
        }
    }
}


using NUnit.Framework;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Window/GLWindowEvent")]
    internal class PublicGLWindowEventTest
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
        [Description("GLWindow FocusChanged")]
        [Property("SPEC", "Tizen.NUI.GLWindow.FocusChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void GLWindowFocusChanged()
        {
            tlog.Debug(tag, $"GLWindowFocusChanged START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.FocusChanged += A1_FocusChanged;
            a1.FocusChanged -= A1_FocusChanged;

            GLWindow.FocusChangedEventArgs e1 = new GLWindow.FocusChangedEventArgs();
            A1_FocusChanged(null, e1);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowFocusChanged END (OK)");
            Assert.Pass("GLWindowFocusChanged");
        }

        private void A1_FocusChanged(object sender, GLWindow.FocusChangedEventArgs e)
        {
            bool c1 = e.FocusGained;
            e.FocusGained = c1;

            return;
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow TouchEvent")]
        [Property("SPEC", "Tizen.NUI.GLWindow.TouchEvent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void GLWindowTouchEvent()
        {
            tlog.Debug(tag, $"GLWindowTouchEvent START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.TouchEvent += A1_TouchEvent;
            a1.TouchEvent -= A1_TouchEvent;

            GLWindow.TouchEventArgs e1 = new GLWindow.TouchEventArgs();
            A1_TouchEvent(null, e1);
            a1.Destroy();
            tlog.Debug(tag, $"GLWindowTouchEvent END (OK)");
            Assert.Pass("GLWindowTouchEvent");
        }

        private void A1_TouchEvent(object sender, GLWindow.TouchEventArgs e)
        {
            Touch t1 = e.Touch;
            e.Touch = t1;

            return;
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow KeyEvent")]
        [Property("SPEC", "Tizen.NUI.GLWindow.KeyEvent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void GLWindowKeyEvent()
        {
            tlog.Debug(tag, $"GLWindowKeyEvent START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.KeyEvent += A1_KeyEvent;
            a1.KeyEvent -= A1_KeyEvent;

            GLWindow.KeyEventArgs e1 = new GLWindow.KeyEventArgs();
            A1_KeyEvent(null, e1);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowKeyEvent END (OK)");
            Assert.Pass("GLWindowKeyEvent");
        }

        private void A1_KeyEvent(object sender, GLWindow.KeyEventArgs e)
        {
            Key k1 = e.Key;
            e.Key = k1;
            return;
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow Resized")]
        [Property("SPEC", "Tizen.NUI.GLWindow.Resized A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void GLWindowResized()
        {
            tlog.Debug(tag, $"GLWindowResized START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.Resized += A1_Resized;
            a1.Resized -= A1_Resized;

            GLWindow.ResizedEventArgs e1 = new GLWindow.ResizedEventArgs();
            A1_Resized(null, e1);
            a1.Destroy();
            tlog.Debug(tag, $"GLWindowResized END (OK)");
            Assert.Pass("GLWindowResized");
        }

        private void A1_Resized(object sender, GLWindow.ResizedEventArgs e)
        {
            Size2D s1 = e.WindowSize;
            e.WindowSize = s1;
            return;
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow FocusChangedSignal")]
        [Property("SPEC", "Tizen.NUI.GLWindow.FocusChangedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowFocusChangedSignal()
        {
            tlog.Debug(tag, $"GLWindowFocusChangedSignal START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.FocusChangedSignal();

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowFocusChangedSignal END (OK)");
            Assert.Pass("GLWindowFocusChangedSignal");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow KeyEventSignal")]
        [Property("SPEC", "Tizen.NUI.GLWindow.KeyEventSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowKeyEventSignal()
        {
            tlog.Debug(tag, $"GLWindowKeyEventSignal START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.KeyEventSignal();

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowKeyEventSignal END (OK)");
            Assert.Pass("GLWindowKeyEventSignal");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow TouchSignal")]
        [Property("SPEC", "Tizen.NUI.GLWindow.TouchSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowTouchSignal()
        {
            tlog.Debug(tag, $"GLWindowTouchSignal START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.TouchSignal();

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowTouchSignal END (OK)");
            Assert.Pass("GLWindowTouchSignal");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow GLWindowResizedSignal")]
        [Property("SPEC", "Tizen.NUI.GLWindow.GLWindowResizedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowGLWindowResizedSignal()
        {
            tlog.Debug(tag, $"GLWindowGLWindowResizedSignal START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.GLWindowResizedSignal();

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowGLWindowResizedSignal END (OK)");
            Assert.Pass("GLWindowGLWindowResizedSignal");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow GLWindowDisconnectNativeSignals")]
        [Property("SPEC", "Tizen.NUI.GLWindow.DisconnectNativeSignals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowDisconnectNativeSignals()
        {
            tlog.Debug(tag, $"GLWindowDisconnectNativeSignals START");

            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.DisconnectNativeSignals();

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowDisconnectNativeSignals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow.VisibilityChangedEventArgs Visibility")]
        [Property("SPEC", "Tizen.NUI.GLWindow.VisibilityChangedEventArgs.Visibility A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void GLWindowVisibilityChangedEventArgsVisibility()
        {
            tlog.Debug(tag, $"GLWindowVisibilityChangedEventArgsVisibility START");

            var testingTarget = new GLWindow.VisibilityChangedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object VisibilityChangedEventArgs");
            Assert.IsInstanceOf<GLWindow.VisibilityChangedEventArgs>(testingTarget, "Should be an instance of VisibilityChangedEventArgs type.");

            testingTarget.Visibility = true;
            tlog.Debug(tag, "Visibility : " + testingTarget.Visibility);

            tlog.Debug(tag, $"GLWindowVisibilityChangedEventArgsVisibility END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GLWindow GLWindowVisibiltyChangedSignalEmit")]
        [Property("SPEC", "Tizen.NUI.GLWindow.VisibiltyChangedSignalEmit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GLWindowVisibiltyChangedSignalEmit()
        {
            tlog.Debug(tag, $"GLWindowVisibiltyChangedSignalEmit START");
            string name = "myGLWindow";
            Rectangle rectangle = new Rectangle(20, 20, 100, 100);
            GLWindow a1 = new GLWindow(name, rectangle, true);

            a1.VisibiltyChangedSignalEmit(true);

            a1.Destroy();
            tlog.Debug(tag, $"GLWindowVisibiltyChangedSignalEmit END (OK)");
            Assert.Pass("GLWindowVisibiltyChangedSignalEmit");
        }
    }
}


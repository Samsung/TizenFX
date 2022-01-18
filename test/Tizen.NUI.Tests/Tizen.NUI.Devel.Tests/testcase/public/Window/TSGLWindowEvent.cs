using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Window/GLWindowEvent")]
    internal class PublicGLWindowEventTest
    {
        private const string tag = "NUITEST";
        private Rectangle rec = null;
        private GLWindow glwin = null;

        private void OnFocusChanged(object sender, GLWindow.FocusChangedEventArgs e) { }
        private void OnTouchEvent(object sender, GLWindow.TouchEventArgs e) { }
        private void OnKeyEvent(object sender, GLWindow.KeyEventArgs e) { }
        private void OnResized(object sender, GLWindow.ResizedEventArgs e) { }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");

            string name = "myGLWindow";
            rec = new Rectangle(20, 20, 100, 100);
            glwin = new GLWindow(name, rec, true);
        }

        [TearDown]
        public void Destroy()
        {
            rec.Dispose();
            rec = null;

            glwin.Destroy();
            glwin = null;

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

            glwin.Resized += OnResized;
            glwin.KeyEvent += OnKeyEvent;
            glwin.TouchEvent += OnTouchEvent;
            glwin.FocusChanged += OnFocusChanged;

            glwin.Resized -= OnResized;
            glwin.KeyEvent -= OnKeyEvent;
            glwin.TouchEvent -= OnTouchEvent;
            glwin.FocusChanged -= OnFocusChanged;

            tlog.Debug(tag, $"GLWindowFocusChanged END (OK)");
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

            try
            {
                glwin.DisconnectNativeSignals();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

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

            try
            {
                glwin.VisibiltyChangedSignalEmit(true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GLWindowVisibiltyChangedSignalEmit END (OK)");
        }
    }
}


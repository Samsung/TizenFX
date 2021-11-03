using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Window/WindowEvent")]
    public class PublicWindowEventTest
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
        [Description("WindowEvent.TransitionEffectEventArgs State.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.TransitionEffectEventArgs.State A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventTransitionEffectEventArgs()
        {
            tlog.Debug(tag, $"WindowEventTransitionEffectEventArgs START");

            var testingTarget = new Window.TransitionEffectEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object Window");
            Assert.IsInstanceOf<Window.TransitionEffectEventArgs>(testingTarget, "Should be an instance of Window.TransitionEffectEventArgs type.");

            testingTarget.State = Window.EffectState.Start;
            tlog.Debug(tag, "State : " + testingTarget.State);

            testingTarget.Type = Window.EffectType.Show;
            tlog.Debug(tag, "Type : " + testingTarget.Type);

            tlog.Debug(tag, $"WindowEventTransitionEffectEventArgs END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowEvent.VisibilityChangedEventArgs Visibility.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.VisibilityChangedEventArgs.Visibility A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventVisibilityChangedEventArgsVisibility()
        {
            tlog.Debug(tag, $"WindowEventVisibilityChangedEventArgsVisibility START");

            var testingTarget = new Window.VisibilityChangedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object Window");
            Assert.IsInstanceOf<Window.VisibilityChangedEventArgs>(testingTarget, "Should be an instance of Window.VisibilityChangedEventArgs type.");

            testingTarget.Visibility = true;
            tlog.Debug(tag, "Visibility : " + testingTarget.Visibility);

            tlog.Debug(tag, $"WindowEventVisibilityChangedEventArgsVisibility END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowEvent VisibiltyChangedSignalEmit.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.VisibiltyChangedSignalEmit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventVisibiltyChangedSignalEmit()
        {
            tlog.Debug(tag, $"WindowEventVisibiltyChangedSignalEmit START");

            using (Rectangle rec = new Rectangle(0, 0, 2, 2))
            {
                var testingTarget = new Window(rec);
                Assert.IsNotNull(testingTarget, "Can't create success object Window");
                Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

                try
                {
                    testingTarget.VisibiltyChangedSignalEmit(true);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WindowEventVisibiltyChangedSignalEmit END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowEvent FocusChanged.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.FocusChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventFocusChanged()
        {
            tlog.Debug(tag, $"WindowEventFocusChanged START");

            var testingTarget = Window.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object Window");
            Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

            testingTarget.FocusChanged += OnFocusChanged;
            testingTarget.FocusChanged -= OnFocusChanged;

            tlog.Debug(tag, $"WindowEventFocusChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowEvent TouchEvent.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.TouchEvent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventTouchEvent()
        {
            tlog.Debug(tag, $"WindowEventTouchEvent START");

            using (Rectangle rec = new Rectangle(0, 0, 2, 2))
            {
                var testingTarget = new Window(rec);
                Assert.IsNotNull(testingTarget, "Can't create success object Window");
                Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

                testingTarget.TouchEvent += OnWindowTouch;
                testingTarget.TouchEvent -= OnWindowTouch;

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WindowEventTouchEvent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowEvent KeyEvent.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.KeyEvent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventKeyEvent()
        {
            tlog.Debug(tag, $"WindowEventKeyEvent START");

            using (Rectangle rec = new Rectangle(0, 0, 2, 2))
            {
                var testingTarget = new Window(rec);
                Assert.IsNotNull(testingTarget, "Can't create success object Window");
                Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

                testingTarget.KeyEvent += OnStageKey;
                testingTarget.KeyEvent -= OnStageKey;

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WindowEventKeyEvent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowEvent Resized.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.Resized A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventResized()
        {
            tlog.Debug(tag, $"WindowEventResized START");

            using (Rectangle rec = new Rectangle(0, 0, 2, 2))
            {
                var testingTarget = new Window(rec);
                Assert.IsNotNull(testingTarget, "Can't create success object Window");
                Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

                testingTarget.Resized += OnResized;
                testingTarget.Resized -= OnResized;

                testingTarget.Dispose();
            }
            
            tlog.Debug(tag, $"WindowEventResized END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowEvent WindowFocusChanged.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.WindowFocusChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventWindowFocusChanged()
        {
            tlog.Debug(tag, $"WindowEventWindowFocusChanged START");

            using (Rectangle rec = new Rectangle(0, 0, 2, 2))
            {
                var testingTarget = new Window(rec);
                Assert.IsNotNull(testingTarget, "Can't create success object Window");
                Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

                testingTarget.WindowFocusChanged += OnWindowFocusedChanged2;
                testingTarget.WindowFocusChanged -= OnWindowFocusedChanged2;

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WindowEventWindowFocusChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowEvent TransitionEffect.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.TransitionEffect A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventTransitionEffect()
        {
            tlog.Debug(tag, $"WindowEventTransitionEffect START");

            using (Rectangle rec = new Rectangle(0, 0, 2, 2))
            {
                var testingTarget = new Window(rec);
                Assert.IsNotNull(testingTarget, "Can't create success object Window");
                Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

                testingTarget.TransitionEffect += OnTransitionEffect;
                testingTarget.TransitionEffect -= OnTransitionEffect;

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WindowEventTransitionEffect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowEvent EventProcessingFinished.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.EventProcessingFinished A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventEventProcessingFinished()
        {
            tlog.Debug(tag, $"WindowEventEventProcessingFinished START");

            var testingTarget = Window.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object Window");
            Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

            testingTarget.EventProcessingFinished += OnEventProcessingFinished;
            testingTarget.EventProcessingFinished -= OnEventProcessingFinished;

            tlog.Debug(tag, $"WindowEventEventProcessingFinished END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowEvent ContextLost.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.ContextLost A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventContextLost()
        {
            tlog.Debug(tag, $"WindowEventContextLost START");

            var testingTarget = Window.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object Window");
            Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

            testingTarget.ContextLost += OnContextLost;
            testingTarget.ContextLost -= OnContextLost;

            tlog.Debug(tag, $"WindowEventContextLost END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowEvent ContextRegained.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.ContextRegained A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventContextRegained()
        {
            tlog.Debug(tag, $"WindowEventContextRegained START");

            var testingTarget = Window.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object Window");
            Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

            testingTarget.ContextRegained += OnContextRegained;
            testingTarget.ContextRegained -= OnContextRegained;

            tlog.Debug(tag, $"WindowEventContextRegained END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowEvent SceneCreated.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.SceneCreated A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventSceneCreated()
        {
            tlog.Debug(tag, $"WindowEventSceneCreated START");

            var testingTarget = Window.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object Window");
            Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

            testingTarget.SceneCreated += OnSceneCreated;
            testingTarget.SceneCreated -= OnSceneCreated;

            tlog.Debug(tag, $"WindowEventSceneCreated END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowEvent KeyboardRepeatSettingsChanged.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.KeyboardRepeatSettingsChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventKeyboardRepeatSettingsChanged()
        {
            tlog.Debug(tag, $"WindowEventKeyboardRepeatSettingsChanged START");

            using (Rectangle rec = new Rectangle(0, 0, 2, 2))
            {
                var testingTarget = new Window(rec);
                Assert.IsNotNull(testingTarget, "Can't create success object Window");
                Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

                testingTarget.KeyboardRepeatSettingsChanged += OnKeyboardRepeatSettingsChanged;
                testingTarget.KeyboardRepeatSettingsChanged -= OnKeyboardRepeatSettingsChanged;

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WindowEventKeyboardRepeatSettingsChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowEvent WheelEvent.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.WheelEvent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventWheelEvent()
        {
            tlog.Debug(tag, $"WindowEventWheelEvent START");

            using (Rectangle rec = new Rectangle(0, 0, 2, 2))
            {
                var testingTarget = new Window(rec);
                Assert.IsNotNull(testingTarget, "Can't create success object Window");
                Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

                testingTarget.WheelEvent += OnStageWheel;
                testingTarget.WheelEvent -= OnStageWheel;

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WindowEventWheelEvent END (OK)");
        }

        private void OnFocusChanged(object sender, Window.FocusChangedEventArgs e) { }
        private void OnWindowTouch(object sender, Window.TouchEventArgs e) { }
        private void OnStageWheel(object sender, Window.WheelEventArgs e) { }
        private void OnStageKey(object sender, Window.KeyEventArgs e) { }
        private void OnResized(object sender, Window.ResizedEventArgs e) { }
        private void OnTransitionEffect(object sender, Window.TransitionEffectEventArgs e) { }
        private void OnWindowFocusedChanged2(object sender, Window.FocusChangedEventArgs e) { }
        private void OnKeyboardRepeatSettingsChanged(object sender, EventArgs e) { }
        private void OnEventProcessingFinished(object sender, EventArgs e) { }
        private void OnContextLost(object sender, EventArgs e) { }
        private void OnContextRegained(object sender, EventArgs e) { }
        private void OnSceneCreated(object sender, EventArgs e) { }
    }
}

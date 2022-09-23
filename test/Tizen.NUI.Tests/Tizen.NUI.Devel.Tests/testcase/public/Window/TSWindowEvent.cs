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
        private bool IsFocusChanged = false;
        private bool IsResized = false;

        private bool OnWindowInterceptTouchEvent(object source, Window.TouchEventArgs e)
        {
            return true;
        }
		
		private bool OnStageInterceptKeyEvent(object source, Window.KeyEventArgs e)
        {
            return true;
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

            Assert.IsFalse(IsFocusChanged);

            testingTarget.FocusChanged += OnFocusChanged;

            View current = new View()
            {
                Size = new Size(100, 200),
                Position = new Position(0, 0)
            };
            testingTarget.GetDefaultLayer().Add(current);
            FocusManager.Instance.SetCurrentFocusView(current);

            View next = new View()
            {
                Size = new Size(100, 200),
                Position = new Position(200, 0)
            };
            testingTarget.GetDefaultLayer().Add(next);
            FocusManager.Instance.MoveFocus(View.FocusDirection.Right);

            tlog.Debug(tag, "FocusChanged : " + IsFocusChanged);
            testingTarget.FocusChanged -= OnFocusChanged;

            testingTarget.Dispose();
            tlog.Debug(tag, $"WindowEventFocusChanged END (OK)");
        }

   //     [Test]
   //     [Category("P1")]
   //     [Description("WindowEvent InterceptKeyEvent.")]
   //     [Property("SPEC", "Tizen.NUI.WindowEvent.InterceptKeyEvent A")]
   //     [Property("SPEC_URL", "-")]
   //     [Property("CRITERIA", "PRW")]
   //     [Property("AUTHOR", "guowei.wang@samsung.com")]
   //     public void WindowEventInterceptKeyEvent()
   //     {
   //         tlog.Debug(tag, $"WindowEventInterceptKeyEvent START");

   //         var testingTarget = Window.Instance;
   //         Assert.IsNotNull(testingTarget, "Can't create success object Window");
   //         Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

   //         testingTarget.InterceptKeyEvent += OnStageInterceptKeyEvent;
   //         testingTarget.InterceptKeyEvent -= OnStageInterceptKeyEvent;

   //         tlog.Debug(tag, $"WindowEventInterceptKeyEvent END (OK)");
   //     }
       
   //     [Test]
   //     [Category("P1")]
   //     [Description("WindowEvent InterceptKeyEventSignal.")]
   //     [Property("SPEC", "Tizen.NUI.WindowEvent.InterceptKeyEventSignal A")]
   //     [Property("SPEC_URL", "-")]
   //     [Property("CRITERIA", "PRW")]
   //     [Property("AUTHOR", "guowei.wang@samsung.com")]
   //     public void WindowEventInterceptKeyEventSignal()
   //     {
   //         tlog.Debug(tag, $"WindowEventInterceptKeyEventSignal START");

   //         var testingTarget = Window.Instance;
   //         Assert.IsNotNull(testingTarget, "Can't create success object Window");
   //         Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");
            
			//try
			//{
   //              testingTarget.InterceptKeyEventSignal();
   //         }
   //         catch (Exception e)
   //         {
   //             tlog.Debug(tag, e.Message.ToString());
   //             Assert.Fail("Caught ArgumentNullException : Failed!");
   //         } 

   //         testingTarget.Dispose();
   //         tlog.Debug(tag, $"ViewEventInterceptKeyEventSignal END (OK)");
   //     }

        [Test]
        [Category("P1")]
        [Description("WindowEvent DisconnectNativeSignals.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.DisconnectNativeSignals A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventDisconnectNativeSignals()
        {
            tlog.Debug(tag, $"WindowEventDisconnectNativeSignals START");

            var testingTarget = Window.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object Window");
            Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");
            
			try
			{
                testingTarget.DisconnectNativeSignals();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught ArgumentNullException : Failed!");
            }
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewEventDisconnectNativeSignals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowEvent.FocusChangedEventArgs FocusGained.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.FocusChangedEventArgs .FocusGained A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventFocusChangedEventArgsFocusGained()
        {
            tlog.Debug(tag, $"WindowEventFocusChangedEventArgsFocusGained START");

            var testingTarget = new Window.FocusChangedEventArgs ();
            Assert.IsNotNull(testingTarget, "Can't create success object Window");
            Assert.IsInstanceOf<Window.FocusChangedEventArgs >(testingTarget, "Should be an instance of Window.FocusChangedEventArgs  type.");

            testingTarget.FocusGained = true;
            tlog.Debug(tag, "FocusGained : " + testingTarget.FocusGained);

            tlog.Debug(tag, $"WindowEventFocusChangedEventArgsFocusGained  END (OK)");
        }
  
        [Test]
        [Category("P1")]
        [Description("WindowEvent.WindowFocusChangedEventArgs FocusGained.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.WindowFocusChangedEventArgs  .FocusGained A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void WindowEventWindowFocusChangedEventArgsFocusGained()
        {
            tlog.Debug(tag, $"WindowEventWindowFocusChangedEventArgsFocusGained START");

            var testingTarget = new Window.WindowFocusChangedEventArgs ();
            Assert.IsNotNull(testingTarget, "Can't create success object Window");
            Assert.IsInstanceOf<Window.WindowFocusChangedEventArgs >(testingTarget, "Should be an instance of Window.WindowFocusChangedEventArgs   type.");

            testingTarget.FocusGained = true;
            tlog.Debug(tag, "FocusGained : " + testingTarget.FocusGained);

            tlog.Debug(tag, $"WindowEventWindowFocusChangedEventArgsFocusGained  END (OK)");
        }
  
        [Test]
        [Category("P1")]
        [Description("WindowEvent.AccessibilityHighlightEventArgs AccessibilityHighlight.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.AccessibilityHighlightEventArgs  .AccessibilityHighlight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventAccessibilityHighlightEventArgsAccessibilityHighlight()
        {
            tlog.Debug(tag, $"WindowEventAccessibilityHighlightEventArgsFocusGained START");

            var testingTarget = new Window.AccessibilityHighlightEventArgs ();
            Assert.IsNotNull(testingTarget, "Can't create success object Window");
            Assert.IsInstanceOf<Window.AccessibilityHighlightEventArgs >(testingTarget, "Should be an instance of Window.AccessibilityHighlightEventArgs   type.");

            testingTarget.AccessibilityHighlight = true;
            tlog.Debug(tag, "AccessibilityHighlight : " + testingTarget.AccessibilityHighlight);

            tlog.Debug(tag, $"WindowEventAccessibilityHighlightEventArgsAccessibilityHighlight  END (OK)");
        }

		[Test]
        [Category("P1")]
        [Description("WindowEvent.KeyEventArgs Key.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.KeyEventArgs.Key A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventKeyEventArgsKey()
        {
            tlog.Debug(tag, $"WindowEventKeyEventArgsKey START");

            var testingTarget = new Window.KeyEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object Window");
            Assert.IsInstanceOf<Window.KeyEventArgs >(testingTarget, "Should be an instance of Window.KeyEventArgs  type.");

            using (Key key = new Key())
            {
                key.KeyCode = 911;
                key.KeyString = "myKey";
                testingTarget.Key = key;

                Assert.AreEqual(911, testingTarget.Key.KeyCode, "Should be equal!");
            }

            tlog.Debug(tag, $"WindowEventKeyEventArgsKey  END (OK)");
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

            using (Rectangle rec = new Rectangle(0, 0, 100, 200))
            {
                Assert.IsFalse(IsResized) ;

                var testingTarget = new Window(rec);
                Assert.IsNotNull(testingTarget, "Can't create success object Window");
                Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

                testingTarget.Resized += OnResized;
                testingTarget.WindowSize = new Size2D(200, 400);
                
                tlog.Debug(tag, "Resized : " + IsResized);
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
        [Obsolete]
        public void WindowEventWindowFocusChanged()
        {
            tlog.Debug(tag, $"WindowEventWindowFocusChanged START");

            using (Rectangle rec = new Rectangle(0, 0, 2, 2))
            {
                var testingTarget = new Window(rec);
                Assert.IsNotNull(testingTarget, "Can't create success object Window");
                Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

                testingTarget.WindowFocusChanged += OnWindowFocusedChanged;
                testingTarget.WindowFocusChanged -= OnWindowFocusedChanged;

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
		
        [Test]
        [Category("P1")]
        [Description("WindowEvent VisibilityChanged.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.VisibilityChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventVisibilityChanged()
        {
            tlog.Debug(tag, $"WindowEventVisibilityChanged START");

            using (Rectangle rec = new Rectangle(0, 0, 2, 2))
            {
                var testingTarget = new Window(rec);
                Assert.IsNotNull(testingTarget, "Can't create success object Window");
                Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

                testingTarget.VisibilityChanged += OnVisibilityChanged;
                testingTarget.VisibilityChanged -= OnVisibilityChanged;

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WindowEventVisibilityChanged END (OK)");	
        }

        [Test]
        [Category("P1")]
        [Description("WindowEvent AuxiliaryMessage.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.AuxiliaryMessage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventAuxiliaryMessage()
        {
            tlog.Debug(tag, $"WindowEventAuxiliaryMessage START");

            using (Rectangle rec = new Rectangle(0, 0, 2, 2))
            {
                var testingTarget = new Window(rec);
                Assert.IsNotNull(testingTarget, "Can't create success object Window");
                Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

                testingTarget.AuxiliaryMessage += OnAuxiliaryMessage;
                testingTarget.AuxiliaryMessage -= OnAuxiliaryMessage;

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WindowEventVisibilityChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowEvent AccessibilityHighlight.")]
        [Property("SPEC", "Tizen.NUI.WindowEvent.AccessibilityHighlight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowEventAccessibilityHighlight()
        {
            tlog.Debug(tag, $"WindowEventAccessibilityHighlight START");

            using (Rectangle rec = new Rectangle(0, 0, 2, 2))
            {
                var testingTarget = new Window(rec);
                Assert.IsNotNull(testingTarget, "Can't create success object Window");
                Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

                testingTarget.AccessibilityHighlight += OnAccessibilityHighlight;
                testingTarget.AccessibilityHighlight -= OnAccessibilityHighlight;

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WindowEventAccessibilityHighlight END (OK)");
        }

        private void OnFocusChanged(object sender, Window.FocusChangedEventArgs e) { IsFocusChanged = true; }
        private void OnWindowTouch(object sender, Window.TouchEventArgs e) { }
        private void OnStageWheel(object sender, Window.WheelEventArgs e) { }
        private void OnStageKey(object sender, Window.KeyEventArgs e) { }
        private void OnResized(object sender, Window.ResizedEventArgs e) { IsResized = true; }
        private void OnTransitionEffect(object sender, Window.TransitionEffectEventArgs e) { }
        private void OnWindowFocusedChanged(object sender, Window.FocusChangedEventArgs e) { }
        private void OnKeyboardRepeatSettingsChanged(object sender, EventArgs e) { }
        private void OnEventProcessingFinished(object sender, EventArgs e) { }
        private void OnContextLost(object sender, EventArgs e) { }
        private void OnContextRegained(object sender, EventArgs e) { }
        private void OnSceneCreated(object sender, EventArgs e) { }
		private void OnVisibilityChanged(object sender, Window.VisibilityChangedEventArgs e) { }
		private void OnAuxiliaryMessage(object sender, EventArgs e) { }
		private void OnAccessibilityHighlight(object sender, Window.AccessibilityHighlightEventArgs e) { }
    }
}

using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;


namespace Tizen.NUI.Samples
{
    public class TouchGestureSample : IExample
    {
        class CustomBorder : DefaultBorder
        {
            private bool isOverlayMode = false;
            private View borderView;
            public CustomBorder() : base()
            {
                OverlayMode = true;
                BorderLineThickness = 0;
            }

            public override void OnOverlayMode(bool enabled)
            {
                Tizen.Log.Error("gab_test", $"OnOverlayMode {enabled}\n");
                base.OnOverlayMode(enabled);
                isOverlayMode = enabled;
                FocusManager.Instance.SetCurrentFocusView(borderView);
            }

            public override void OnCreated(View borderView)
            {
                base.OnCreated(borderView);
                this.borderView = borderView;
                borderView.Focusable = true;
                // BorderWindow.InterceptTouchEvent += (s, e) =>
                // {
                //     Tizen.Log.Error("gab_test", $"BorderWindow.InterceptTouchEvent\n");
                //     OverlayBorderShow();
                //     return false;
                // };

                // borderView.TouchEvent += (s, e) =>
                // {
                //     Tizen.Log.Error("gab_test", $"borderView.TouchEvent\n");
                //     OverlayBorderShow();
                //     return false;
                // };

                BorderWindow.KeyEvent += (s, e) =>
                {
                    Tizen.Log.Error("gab_test", $"borderView.KeyEvent {e.Key.KeyPressedName}\n");
                    if(isOverlayMode == true)
                    {
                        Tizen.Log.Error("gab_test", $"OverlayBorderShow return true\n");
                        OverlayBorderShow();
                        // return true;
                    }
                    else
                    {
                        Tizen.Log.Error("gab_test", $"return false\n");
                        // return false;
                    }
                };
            }
        }

        private View root;
        private Window subWindowOne; 
        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            root = new View{
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = Color.Green,
            };

            var view = new TextField()
            {
                Text = "Text",
                Size2D = new Size2D(200, 200),
                BackgroundColor = Color.White,
                GrabTouchAfterLeave = true,
            };

            var view1 = new View()
            {
                Position = new Position(200,200),
                Size2D = new Size2D(200, 200),
                BackgroundColor = Color.Red,
                GrabTouchAfterLeave = true,
                Focusable = true,
                FocusableInTouch = true,
            };
            view1.KeyEvent += (s, e) =>
            {
                if (e.Key.State == Key.StateType.Up)
                {
                    Tizen.Log.Error("gab_test", $"view1.KeyEvent {e.Key.KeyPressedName}\n");

                }
                return false;
            };
            root.Add(view1);


            view.TouchEvent += (s, e) =>
            {
                Tizen.Log.Error("gab_test", $"TouchEvent {e.Touch.GetState(0)}\n");
                return false;
            };
            root.Add(view);

            CustomBorder customBorder = new CustomBorder();
            window.EnableBorder(customBorder);
            window.KeyEvent += (s, e) =>
            {
                if (e.Key.State == Key.StateType.Up)
                {
                    Tizen.Log.Error("gab_test", $"window.KeyEvent {e.Key.KeyPressedName}\n");

                }
                if (e.Key.State == Key.StateType.Up && e.Key.KeyPressedName == "XF86Back" )
                {
                    root.BackgroundColor = Color.Red;
                }
                else if (e.Key.State == Key.StateType.Up && e.Key.KeyPressedName == "XF86Menu" )
                {
                    root.BackgroundColor = Color.Yellow;
                }
            };


            window.InterceptKeyEvent += (s, e) =>
            {
                if (e.Key.State == Key.StateType.Up)
                {
                    Tizen.Log.Error("gab_test", $"window.InterceptKeyEvent {e.Key.KeyPressedName}\n");

                }
                if (e.Key.State == Key.StateType.Up && e.Key.KeyPressedName == "XF86Back" )
                {
                    root.BackgroundColor = Color.Red;
                }
                else if (e.Key.State == Key.StateType.Up && e.Key.KeyPressedName == "XF86Menu" )
                {
                    root.BackgroundColor = Color.Yellow;
                }
                return false;
            };
            window.Add(root);
        }

        public void Deactivate()
        {
        }
    }
}

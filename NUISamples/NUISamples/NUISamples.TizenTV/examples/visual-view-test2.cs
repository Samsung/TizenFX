using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;

namespace VisualViewTest2
{
    public class VisualSample : NUIApplication
    {
        const int num = 2;
        VisualView[] view;

        TextLabel guide;
        ImageVisual imageMap;
        ImageVisual imageMap2;

        ImageVisual highlightImageMap;
        ImageVisual dimImageMap;

        TextVisual textMap1;
        TextVisual textMap2;

        Window _window;

        int imgIndex;

        readonly string resourcePath = "/home/owner/apps_rw/NUISamples.TizenTV/res/images/";

        protected override void OnCreate()
        {
            base.OnCreate();

            view = new VisualView[2];

            for (int i = 0; i < num; i++)
            {
                view[i] = new VisualView();
                view[i].Size2D = new Size2D(600, 600);
                view[i].BackgroundColor = Color.Blue;
                view[i].Position = new Position(400 + i * 800, 600, 0);
                view[i].Focusable = true;
                view[i].Name = "MyView" + i;
                Window.Instance.Add(view[i]);
                view[i].FocusGained += VisualSample_FocusGained;
                view[i].FocusLost += VisualSample_FocusLost;
                view[i].KeyEvent += VisualSample_KeyEvent;
            }

            view[0].RightFocusableView = view[1];
            view[1].LeftFocusableView = view[0];

            imageMap = new ImageVisual();
            imageMap.URL = resourcePath + "gallery-" + imgIndex++ + ".jpg";
            imageMap.AnchorPoint = Visual.AlignType.TopBegin;
            imageMap.Origin = Visual.AlignType.TopBegin;
            imageMap.Position = new Vector2(0, 0);
            imageMap.PositionPolicy = VisualTransformPolicyType.Absolute;
            imageMap.Size = new Size2D(500, 500);
            imageMap.SizePolicy = VisualTransformPolicyType.Absolute;
            imageMap.DepthIndex = 0;
            view[0].AddVisual("bgVisual", imageMap);


            highlightImageMap = new ImageVisual();
            highlightImageMap.URL = resourcePath + "star-highlight.png";
            highlightImageMap.AnchorPoint = Visual.AlignType.TopBegin;
            highlightImageMap.Origin = Visual.AlignType.TopBegin;
            highlightImageMap.Size = new Vector2(40, 40);
            highlightImageMap.SizePolicy = VisualTransformPolicyType.Absolute;
            highlightImageMap.Position = new Vector2(10, 10);
            highlightImageMap.PositionPolicy = VisualTransformPolicyType.Absolute;
            highlightImageMap.DepthIndex = 1;
            view[0].AddVisual("iconVisual", highlightImageMap);


            textMap1 = new TextVisual();
            textMap1.Text = "Hello";
            textMap1.AnchorPoint = Visual.AlignType.TopBegin;
            textMap1.Origin = Visual.AlignType.TopBegin;
            textMap1.PointSize = 20;
            textMap1.Position = new Vector2(60, 210);
            textMap1.PositionPolicy = VisualTransformPolicyType.Absolute;
            textMap1.Size = new Vector2(600, 200);
            textMap1.SizePolicy = VisualTransformPolicyType.Absolute;
            textMap1.TextColor = Color.Red;
            textMap1.DepthIndex = 5;
            view[0].AddVisual("textVisual", textMap1);



            imageMap2 = new ImageVisual();
            imageMap2.URL = resourcePath + "gallery-" + imgIndex + ".jpg";
            imageMap2.AnchorPoint = Visual.AlignType.TopBegin;
            imageMap2.Origin = Visual.AlignType.TopBegin;
            imageMap2.Position = new Vector2(0, 0);
            imageMap2.PositionPolicy = VisualTransformPolicyType.Absolute;
            imageMap2.Size = new Vector2(500, 500);
            imageMap2.SizePolicy = VisualTransformPolicyType.Absolute;
            imageMap2.DepthIndex = 0;
            view[1].AddVisual("bgVisual", imageMap2);

            dimImageMap = new ImageVisual();
            dimImageMap.URL = resourcePath + "star-dim.png";
            dimImageMap.Size = new Vector2(40, 40);
            dimImageMap.SizePolicy = VisualTransformPolicyType.Absolute;
            dimImageMap.AnchorPoint = Visual.AlignType.TopBegin;
            dimImageMap.Origin = Visual.AlignType.TopBegin;
            dimImageMap.Position = new Vector2(10, 10);
            dimImageMap.PositionPolicy = VisualTransformPolicyType.Absolute;
            dimImageMap.DepthIndex = 1;
            view[1].AddVisual("iconVisual", dimImageMap);

            textMap2 = new TextVisual();
            textMap2.Text = "I'm";
            textMap2.PointSize = 20;
            textMap2.AnchorPoint = Visual.AlignType.TopBegin;
            textMap2.Origin = Visual.AlignType.TopBegin;
            textMap2.Position = new Vector2(60, 210);
            textMap2.PositionPolicy = VisualTransformPolicyType.Absolute;
            textMap2.Size = new Vector2(600, 200);
            textMap2.SizePolicy = VisualTransformPolicyType.Absolute;
            textMap2.TextColor = Color.Black;
            textMap2.DepthIndex = 5;
            view[1].AddVisual("textVisual", textMap2);


            guide = new TextLabel();
            guide.PivotPoint = PivotPoint.TopLeft;
            guide.Size2D = new Size2D(800, 200);
            guide.Padding = new Vector4(50, 50, 50, 50);
            guide.MultiLine = true;
            guide.BackgroundColor = Color.Magenta;
            guide.PointSize = 10;
            guide.TextColor = Color.Black;
            guide.Text = "Left/Right - Move focus\n" +
                "Up/Down - Change Text\n" +
                "Enter - Change BG image\n";
            Window.Instance.Add(guide);

            Window.Instance.KeyEvent += Instance_Key;
            FocusManager.Instance.SetCurrentFocusView(view[0]);
            Window.Instance.TouchEvent += Instance_Touch;
            _window = Window.Instance;
            _window.FocusChanged += _window_WindowFocusChanged;

        }

        private void _window_WindowFocusChanged(object sender, Window.FocusChangedEventArgs e)
        {
            Tizen.Log.Fatal("NUI", "window focus changed!() focus gained=" + e.FocusGained);
        }

        private void Instance_Touch(object sender, Window.TouchEventArgs e)
        {
            FocusManager.Instance.SetCurrentFocusView(view[0]);
        }

        private bool VisualSample_KeyEvent(object source, View.KeyEventArgs e)
        {
            Tizen.Log.Fatal("NUI", "View_KeyEvent" + e.Key.State.ToString() + ", Pressed-" + e.Key.KeyPressedName);

            if (e.Key.State == Key.StateType.Down)
            {
                if (source.Equals(view[0]))
                {
                    if (e.Key.KeyPressedName == "Up")
                    {
                        textMap1.PointSize = 14;
                        textMap1.TextColor = Color.Red;
                        textMap1.Text = "Hello NY!";
                        //this.VersionCheckTest();
                        /*
                           DALI_KEY_VOLUME_UP      = 200,      ///< Volume up key @SINCE_1_0.0
                           DALI_KEY_VOLUME_DOWN    = 201,       ///< Volume down key @SINCE_1_0.0
                        */
                        try
                        {
                            Tizen.Log.Fatal("NUI", "GrabKeyTopmost (200==vol up) ret=" + _window.GrabKeyTopmost(200));
                        }
                        catch (Exception except)
                        {
                            Tizen.Log.Fatal("NUI", "Exception!!! GrabKeyTopmost (200==vol up) msg=" + except.Message);
                        }

                    }
                    else if (e.Key.KeyPressedName == "Down")
                    {
                        textMap1.PointSize = 17;
                        textMap1.TextColor = Color.Blue;
                        textMap1.Text = "Goodbye NY.";

                        Tizen.Log.Fatal("NUI", "UngrabKeyTopmost (200==vol up) ret=" + _window.UngrabKeyTopmost(200));

                    }
                    else if (e.Key.KeyPressedName == "Return")
                    {
                        imgIndex = (imgIndex + 1) % 6;
                        imageMap.URL = resourcePath + "gallery-" + imgIndex + ".jpg";
                        //Tizen.Log.Fatal("NUI", "get native ecore wayland hander=" + _window.GetNativeWindowHandler());
                    }

                }
                else
                {
                    if (e.Key.KeyPressedName == "Up")
                    {
                        textMap2.PointSize = 14;
                        textMap2.TextColor = Color.Red;
                        textMap2.Text = "I'm happy!";
                        Tizen.Log.Fatal("NUI", "grab key (201==vol down) ret=" + _window.GrabKey(201, Window.KeyGrabMode.Topmost));
                    }

                    if (e.Key.KeyPressedName == "Down")
                    {
                        textMap2.PointSize = 17;
                        textMap2.TextColor = Color.Blue;
                        textMap2.Text = "I'm unhappy";
                        Tizen.Log.Fatal("NUI", "ungrab key (201==vol down) ret=" + _window.UngrabKey(201));
                    }
                    else if (e.Key.KeyPressedName == "Return")
                    {
                        imgIndex = (imgIndex + 1) % 6;
                        imageMap2.URL = resourcePath + "gallery-" + imgIndex + ".jpg";
                        //Tizen.Log.Fatal("NUI", "get native ecore wayland hander=" + _window.GetNativeWindowHandler());
                    }
                }
            }
            return false;
        }

        private void Instance_Key(object sender, Window.KeyEventArgs e)
        {
            View currentFocusView = FocusManager.Instance.GetCurrentFocusView();

            Tizen.Log.Fatal("NUI", "Window_KeyEvent" + e.Key.State.ToString() + ", Pressed-" + e.Key.KeyPressedName);
            //Tizen.Log.Fatal("NUI", " CurrentFocusView : " + currentFocusView.HasBody() + currentFocusView?.Name);
        }

        private void VisualSample_FocusLost(object sender, EventArgs e)
        {
            VisualView view = sender as VisualView;
            view.BackgroundColor = Color.Green;
            view.Scale = new Vector3(1.0f, 1.0f, 1.0f);

            view.AddVisual("iconVisual", dimImageMap);

            if (view.Name == "MyView1")
            {
                imageMap2.MixColor = new Color(1, 0, 0, 0.5f);
                imageMap2.Opacity = 0.5f;
            }
            else if (view.Name == "MyView0")
            {
                imageMap.MixColor = new Color(1, 0, 0, 0.5f);
                imageMap.Opacity = 0.5f;
            }

            Tizen.Log.Fatal("NUI", "FocusLost-" + view.Name);
        }

        private void VisualSample_FocusGained(object sender, EventArgs e)
        {
            VisualView view = sender as VisualView;
            view.BackgroundColor = Color.Yellow;
            view.Scale = new Vector3(1.2f, 1.2f, 1.0f);

            view.AddVisual("iconVisual", highlightImageMap);

            if (view.Name == "MyView1")
            {
                imageMap2.MixColor = new Color(1, 1, 1, 1);
                imageMap2.Opacity = 1.0f;
            }
            else if (view.Name == "MyView0")
            {
                imageMap.MixColor = new Color(1, 1, 1, 1);
                imageMap.Opacity = 1.0f;
            }

            Tizen.Log.Fatal("NUI", "FocusGained-" + view.Name);
        }

        static void _Main(string[] args)
        {
            VisualSample sample = new VisualSample();
            sample.Run(args);
        }
    }
}
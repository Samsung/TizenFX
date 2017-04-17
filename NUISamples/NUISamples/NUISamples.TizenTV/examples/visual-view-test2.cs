using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;

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

        int imgIndex;

        readonly string resourcePath = "/home/owner/apps_rw/NUISamples.TizenTV/res/images/";

        protected override void OnCreate()
        {
            base.OnCreate();

            view = new VisualView[2];

            for (int i = 0; i < num; i++)
            {
                view[i] = new VisualView();
                view[i].Size = new Size(600, 600, 0);
                view[i].BackgroundColor = Color.Blue;
                view[i].Position = new Position(400 + i * 800, 600, 0);
                view[i].Focusable = true;
                view[i].Name = "MyView" + i;
                Stage.Instance.GetDefaultLayer().Add(view[i]);
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
            imageMap.PositionPolicy = new Vector2(1, 1);
            imageMap.Size = new Vector2(500, 500);
            imageMap.SizePolicy = new Vector2(1, 1);
            imageMap.DepthIndex = 0;
            view[0].AddVisual("bgVisual", imageMap);


            highlightImageMap = new ImageVisual();
            highlightImageMap.URL = resourcePath + "star-highlight.png";
            highlightImageMap.AnchorPoint = Visual.AlignType.TopBegin;
            highlightImageMap.Origin = Visual.AlignType.TopBegin;
            highlightImageMap.Size = new Vector2(40, 40);
            highlightImageMap.SizePolicy = new Vector2(1, 1);
            highlightImageMap.Position = new Vector2(10, 10);
            highlightImageMap.PositionPolicy = new Vector2(1, 1);
            highlightImageMap.DepthIndex = 1;
            view[0].AddVisual("iconVisual", highlightImageMap);


            textMap1 = new TextVisual();
            textMap1.Text = "Hello";
            textMap1.AnchorPoint = Visual.AlignType.TopBegin;
            textMap1.Origin = Visual.AlignType.TopBegin;
            textMap1.PointSize = 20;
            textMap1.Position = new Vector2(60, 210);
            textMap1.PositionPolicy = new Vector2(1, 1);
            textMap1.Size = new Vector2(600, 200);
            textMap1.SizePolicy = new Vector2(1, 1);
            textMap1.TextColor = Color.Red;
            textMap1.DepthIndex = 5;
            view[0].AddVisual("textVisual", textMap1);



            imageMap2 = new ImageVisual();
            imageMap2.URL = resourcePath + "gallery-" + imgIndex + ".jpg";
            imageMap2.AnchorPoint = Visual.AlignType.TopBegin;
            imageMap2.Origin = Visual.AlignType.TopBegin;
            imageMap2.Position = new Vector2(0, 0);
            imageMap2.PositionPolicy = new Vector2(1, 1);
            imageMap2.Size = new Vector2(500, 500);
            imageMap2.SizePolicy = new Vector2(1, 1);
            imageMap2.DepthIndex = 0;
            view[1].AddVisual("bgVisual", imageMap2);

            dimImageMap = new ImageVisual();
            dimImageMap.URL = resourcePath + "star-dim.png";
            dimImageMap.Size = new Vector2(40, 40);
            dimImageMap.SizePolicy = new Vector2(1, 1);
            dimImageMap.AnchorPoint = Visual.AlignType.TopBegin;
            dimImageMap.Origin = Visual.AlignType.TopBegin;
            dimImageMap.Position = new Vector2(10, 10);
            dimImageMap.PositionPolicy = new Vector2(1, 1);
            dimImageMap.DepthIndex = 1;
            view[1].AddVisual("iconVisual", dimImageMap);

            textMap2 = new TextVisual();
            textMap2.Text = "I'm";
            textMap2.PointSize = 20;
            textMap2.AnchorPoint = Visual.AlignType.TopBegin;
            textMap2.Origin = Visual.AlignType.TopBegin;
            textMap2.Position = new Vector2(60, 210);
            textMap2.PositionPolicy = new Vector2(1, 1);
            textMap2.Size = new Vector2(600, 200);
            textMap2.SizePolicy = new Vector2(1, 1);
            textMap2.TextColor = Color.Black;
            textMap2.DepthIndex = 5;
            view[1].AddVisual("textVisual", textMap2);


            guide = new TextLabel();
            guide.AnchorPoint = AnchorPoint.TopLeft;
            guide.Size2D = new Size2D(800, 200);
            guide.Padding = new Vector4(50, 50, 50, 50);
            guide.MultiLine = true;
            guide.BackgroundColor = Color.Magenta;
            guide.PointSize = 10;
            guide.TextColor = Color.Black;
            guide.Text = "Left/Right - Move focus\n" +
                "Up/Down - Change Text\n" +
                "Enter - Change BG image\n";
            Stage.Instance.GetDefaultLayer().Add(guide);

            Stage.Instance.Key += Instance_Key;
            FocusManager.Instance.SetCurrentFocusView(view[0]);
            Stage.Instance.Touch += Instance_Touch;
        }


        private void Instance_Touch(object sender, Stage.TouchEventArgs e)
        {
            FocusManager.Instance.SetCurrentFocusView(view[0]);
        }

        private bool VisualSample_KeyEvent(object source, View.KeyEventArgs e)
        {
            Tizen.Log.Debug("NUI", "View_KeyEvent" + e.Key.State.ToString() + ", Pressed-" + e.Key.KeyPressedName);

            if (e.Key.State == Key.StateType.Down)
            {
                if (source.Equals(view[0]))
                {
                    if (e.Key.KeyPressedName == "Up")
                    {
                        textMap1.PointSize = 14;
                        textMap1.TextColor = Color.Red;
                        textMap1.Text = "Hello NY!";
                    }
                    else if (e.Key.KeyPressedName == "Down")
                    {
                        textMap1.PointSize = 17;
                        textMap1.TextColor = Color.Blue;
                        textMap1.Text = "Goodbye NY.";
                    }
                    else if (e.Key.KeyPressedName == "Return")
                    {
                        imgIndex = (imgIndex + 1) % 6;
                        imageMap.URL = resourcePath + "gallery-" + imgIndex + ".jpg";
                    }

                }
                else
                {
                    if (e.Key.KeyPressedName == "Up")
                    {
                        textMap2.PointSize = 14;
                        textMap2.TextColor = Color.Red;
                        textMap2.Text = "I'm happy!";
                    }

                    if (e.Key.KeyPressedName == "Down")
                    {
                        textMap2.PointSize = 17;
                        textMap2.TextColor = Color.Blue;
                        textMap2.Text = "I'm unhappy";
                    }
                    else if (e.Key.KeyPressedName == "Return")
                    {
                        imgIndex = (imgIndex + 1) % 6;
                        imageMap2.URL = resourcePath + "gallery-" + imgIndex + ".jpg";
                    }
                }
            }
            return false;
        }

        private void Instance_Key(object sender, Stage.KeyEventArgs e)
        {
            View currentFocusView = FocusManager.Instance.GetCurrentFocusView();

            Tizen.Log.Debug("NUI", "Stage_KeyEvent" + e.Key.State.ToString() + ", Pressed-" + e.Key.KeyPressedName);
            //Tizen.Log.Debug("NUI", " CurrentFocusView : " + currentFocusView.HasBody() + currentFocusView?.Name);
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

            Tizen.Log.Debug("NUI", "FocusLost-" + view.Name);
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

            Tizen.Log.Debug("NUI", "FocusGained-" + view.Name);
        }

        static void _Main(string[] args)
        {
            VisualSample sample = new VisualSample();
            sample.Run(args);
        }
    }
}
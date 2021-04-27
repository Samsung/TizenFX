using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    using tlog = Tizen.Log;
    public class AnimatedImageViewTest : IExample
    {
        View root;
        Box box, box2;
        string resPath;
        const string tag = "NUITEST";

        internal static int GetRatio(int percent, float value)
        {
            return (int)(value * (percent / 100.0f));
        }

        public class Box : View
        {
            public TextLabel title;
            public AnimatedImageView image;
            public TextLabel status;
            public Button but1;
            public Button but2;
            public Button but3;

            public Box(Size2D boxSize, string boxTitle, string imageUrl)
            {
                this.Size2D = boxSize;
                this.Margin = new Extents(0, 0, 20, 20);
                this.BackgroundColor = Color.Magenta;

                title = new TextLabel(boxTitle);
                title.Size2D = new Size2D(boxSize.Width, GetRatio(20, boxSize.Height));
                title.Position2D = new Position2D(0, 0);
                title.MultiLine = true;
                title.BackgroundColor = Color.Blue;
                title.TextColor = Color.Yellow;
                this.Add(title);

                image = new AnimatedImageView();
                image.Size2D = new Size2D(boxSize.Width, GetRatio(50, boxSize.Height));
                image.Position2D = new Position2D(0, title.Size2D.Height);
                image.ResourceUrl = imageUrl;
                image.Play();
                this.Add(image);

                status = new TextLabel("Initialized");
                status.Size2D = new Size2D(boxSize.Width, GetRatio(20, boxSize.Height));
                status.Position2D = new Position2D(0, image.Position2D.Y + image.Size2D.Height);
                status.MultiLine = true;
                status.BackgroundColor = Color.White;
                status.PointSize = 20;
                this.Add(status);

                ButtonStyle aStyle = new ButtonStyle
                {
                    IsSelectable = true,
                    BackgroundImage = new Selector<string>
                    {
                        Normal = CommonResource.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_toggle_btn_normal_24c447.png",
                        Selected = CommonResource.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_point_btn_normal_24c447.png",
                    },
                    BackgroundImageBorder = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) },

                    ImageShadow = new ImageShadow(CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png", new Rectangle(5, 5, 5, 5)),

                    Overlay = new ImageViewStyle
                    {
                        ResourceUrl = new Selector<string> { Pressed = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png", Other = "" },
                        Border = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) },
                    },

                    Text = new TextLabelStyle
                    {
                        PointSize = new Selector<float?> { All = 20 },
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,

                        TextColor = new Selector<Color>
                        {
                            Normal = new Color(0.141f, 0.769f, 0.278f, 1),
                            Selected = new Color(1, 1, 1, 1),
                        },
                    }
                };
                but1 = new Button(aStyle);
                but1.Size2D = new Size2D(GetRatio(32, boxSize.Width), GetRatio(10, boxSize.Height));
                but1.PositionUsesPivotPoint = true;
                but1.ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft;
                but1.PivotPoint = Tizen.NUI.ParentOrigin.BottomLeft;
                but1.Style.Text.Text = new Selector<string>
                {
                    Normal = "Button1 Normal",
                    Selected = "Button1 Selected",
                    Disabled = "Button2 Disabled",
                };
                this.Add(but1);

                but2 = new Button(aStyle);
                but2.Size2D = new Size2D(GetRatio(32, boxSize.Width), GetRatio(10, boxSize.Height));
                but2.PositionUsesPivotPoint = true;
                but2.ParentOrigin = Tizen.NUI.ParentOrigin.BottomCenter;
                but2.PivotPoint = Tizen.NUI.ParentOrigin.BottomCenter;
                but2.Style.Text.Text = new Selector<string>
                {
                    Normal = "Button2 Normal",
                    Selected = "Button2 Selected",
                    Disabled = "Button2 Disabled",
                };
                this.Add(but2);

                but3 = new Button(aStyle);
                but3.Size2D = new Size2D(GetRatio(32, boxSize.Width), GetRatio(10, boxSize.Height));
                but3.PositionUsesPivotPoint = true;
                but3.ParentOrigin = Tizen.NUI.ParentOrigin.BottomRight;
                but3.PivotPoint = Tizen.NUI.ParentOrigin.BottomRight;
                but3.Style.Text.Text = new Selector<string>
                {
                    Normal = "Button3 Normal",
                    Selected = "Button3 Selected",
                    Disabled = "Button2 Disabled",
                };
                this.Add(but3);
            }

        }
        public void Activate()
        {
            resPath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            root = new View();
            root.BackgroundColor = Color.Green;
            root.Size2D = new Size2D(NUIApplication.GetDefaultWindow().Size.Width, NUIApplication.GetDefaultWindow().Size.Height);
            var layer = new LinearLayout();
            layer.LinearAlignment = LinearLayout.Alignment.CenterHorizontal;
            layer.LinearOrientation = LinearLayout.Orientation.Vertical;
            root.Layout = layer;
            NUIApplication.GetDefaultWindow().GetDefaultLayer().Add(root);

            box = new Box(new Size2D(root.Size2D.Width, GetRatio(40, root.Size2D.Height)), "AGIF Test", resPath + "images/AGIF/dali-logo-anim.gif");
            root.Add(box);

            box.image.SetValues();
            box.but1.Clicked += But1_Clicked;
            box.but1.Style.Text.Text = new Selector<string>
            {
                Normal = "Pause !",
                Selected = "Play !"
            };
            box.but2.Clicked += But2_Clicked;
            box.but2.Style.Text.Text = new Selector<string>
            {
                Normal = "Stop !",
                Selected = "Play !"
            };
            box.status.Text = "playing now";
            box.but3.IsEnabled = false;

            box2 = new Box(new Size2D(root.Size2D.Width, GetRatio(40, root.Size2D.Height)), "Image array Test", "");
            root.Add(box2);

            for (int i = 1; i <= 8; i++)
            {
                box2.image.URLs.Add(resPath + "images/AGIF/dog-anim-00" + i + ".png");
            }
            box2.image.Play();

            box2.but1.Clicked += But1_Clicked1;
            box2.but1.Style.Text.Text = new Selector<string>
            {
                Normal = "Pause !",
                Selected = "Play by reseting frame dalay and loop count!",
            };
            box2.but1.Style.Text.PointSize = new Selector<float?>
            {
                Normal = 20,
                Selected = 15,
            };
            box2.but1.Style.Text.MultiLine = true;


            box2.but2.Clicked += But2_Clicked1;
            box2.but2.IsSelectable = false;
            box2.but2.Style.Text.Text = new Selector<string>
            {
                Normal = "Increase frame delay",
                Pressed = "Up 100ms",
            };

            box2.but3.Clicked += But3_Clicked;
            box2.but3.IsSelectable = false;
            box2.but3.Style.Text.Text = new Selector<string>
            {
                Normal = "Increase loop count",
                Pressed = "Up 1 count",
            };
            box2.status.Text = $"playing now,  frame delay: {box2.image.FrameDelay}ms,  loop count: {box2.image.LoopCount}";

        }

        private void But3_Clicked(object sender, ClickedEventArgs e)
        {
            tlog.Fatal(tag, $"But3_Clicked()!");
            var src = sender as Button;
            if (src != null)
            {
                box2.image.LoopCount += 1;
                box2.image.Play();
                box2.status.Text = $"playing now,  frame delay: {box2.image.FrameDelay}ms,  loop count: {box2.image.LoopCount}";
            }
        }

        private void But2_Clicked1(object sender, ClickedEventArgs e)
        {
            tlog.Fatal(tag, $"But2_Clicked1()!");
            var src = sender as Button;
            if (src != null)
            {
                box2.image.FrameDelay += 100;
                box2.image.Play();
                box2.status.Text = $"playing now,  frame delay: {box2.image.FrameDelay}ms,  loop count: {box2.image.LoopCount}";
            }
        }
        private void But1_Clicked1(object sender, ClickedEventArgs e)
        {
            tlog.Fatal(tag, $"But1_Clicked1()!");
            var src = sender as Button;
            if (src != null)
            {
                tlog.Fatal(tag, $"is selected: {src.IsSelected}");
                if (src.IsSelected)
                {
                    box2.image.Pause();
                    box2.status.Text = $"paused,  frame delay: {box2.image.FrameDelay}ms,  loop count: {box2.image.LoopCount}";
                }
                else
                {
                    box2.image.FrameDelay = 0;
                    box2.image.LoopCount = -1;
                    box2.image.Play();
                    box2.status.Text = $"playing now,  frame delay: {box2.image.FrameDelay}ms,  loop count: {box2.image.LoopCount}";
                }
            }
        }

        private void But2_Clicked(object sender, ClickedEventArgs e)
        {
            tlog.Fatal(tag, $"But2_Clicked()!");
            var src = sender as Button;
            if (src != null)
            {
                if (src.IsSelected)
                {
                    box.image.Stop();
                    box.status.Text = "stopped";
                }
                else
                {
                    box.image.Play();
                    box.status.Text = "playing now";
                }
            }
        }

        private void But1_Clicked(object sender, ClickedEventArgs e)
        {
            tlog.Fatal(tag, $"But1_Clicked()!");
            var src = sender as Button;
            if (src != null)
            {
                tlog.Fatal(tag, $"is selected: {src.IsSelected}");
                if (src.IsSelected)
                {
                    box.image.Pause();
                    box.status.Text = "paused";
                }
                else
                {
                    box.image.Play();
                    box.status.Text = "playing now";
                }
            }
        }

        public void Deactivate()
        {
        }
    }
}

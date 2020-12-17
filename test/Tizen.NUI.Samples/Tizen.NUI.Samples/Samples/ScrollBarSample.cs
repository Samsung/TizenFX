using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class ScrollbarSample : IExample
    {
        private TextLabel text_nullstyle, text_style;
        private Button[] button = new Button[4];
        private ScrollBar[] scrollBar = new ScrollBar[3];
        private View root;
        private View top_parent, bottom_parent, null_style_parent, style_parent;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            root = new View()
            {
                Size = new Size(1920, 1080),
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
            };
            root.Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical };
            window.Add(root);

            // TextLabel of Null style construction and Style construction
            CreateTopView();

            // Buttons for moving thumbnail
            CreateBottomView();
        }
        private void CreateTopView()
        {
            top_parent = new View() { Size = new Size(1920, 540) };
            top_parent.Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Horizontal };
            root.Add(top_parent);
            CreateNullStylePart();
            CreateStylePart();
        }

        private void CreateNullStylePart()
        {
            null_style_parent = new View() { Size = new Size(960, 540) };
            null_style_parent.Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical, LinearAlignment = LinearLayout.Alignment.Center, CellPadding = new Size2D(0, 50) };
            top_parent.Add(null_style_parent);

            // Add Textlabel of "Null style construction"
            text_nullstyle = new TextLabel();
            text_nullstyle.Size = new Size(400, 70);
            text_nullstyle.PointSize = 20;
            text_nullstyle.HorizontalAlignment = HorizontalAlignment.Center;
            text_nullstyle.VerticalAlignment = VerticalAlignment.Center;
            text_nullstyle.BackgroundColor = Color.Magenta;
            text_nullstyle.Text = "Null style construction";
            text_nullstyle.Focusable = true;
            null_style_parent.Add(text_nullstyle);

            // Add ScrollBar of Null style construction
            scrollBar[0] = new ScrollBar();
            scrollBar[0].Size = new Size(400, 4);
            scrollBar[0].TrackColor = Color.Green;
            scrollBar[0].MaxValue = (int)scrollBar[0].SizeWidth / 10;
            scrollBar[0].MinValue = 0;
            scrollBar[0].ThumbSize = new Size(30, 4);
            scrollBar[0].CurrentValue = 0; //set after thumbsize
            scrollBar[0].ThumbColor = Color.Black;
            null_style_parent.Add(scrollBar[0]);

            scrollBar[1] = new ScrollBar();
            scrollBar[1].Size = new Size(400, 4);
            scrollBar[1].TrackColor = Color.Green;
            scrollBar[1].MaxValue = (int)scrollBar[1].SizeWidth / 10;
            scrollBar[1].MinValue = 0;
            scrollBar[1].ThumbSize = new Size(30, 4);
            scrollBar[1].CurrentValue = 0;//set after thumbsize
            scrollBar[1].ThumbColor = Color.Yellow;
            scrollBar[1].TrackImageURL = CommonResource.GetTVResourcePath() + "component/c_progressbar/c_progressbar_white_buffering.png";
            null_style_parent.Add(scrollBar[1]);
        }
        
        private void CreateStylePart()
        {
            style_parent = new View() { Size = new Size(960, 540) };
            style_parent.Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical, LinearAlignment = LinearLayout.Alignment.CenterVertical, CellPadding = new Size2D(0, 50) };
            top_parent.Add(style_parent);

            // Add Textlabel of "Style construction"
            text_style = new TextLabel();
            text_style.Size = new Size(400, 70);
            text_style.PointSize = 20;
            text_style.HorizontalAlignment = HorizontalAlignment.Center;
            text_style.VerticalAlignment = VerticalAlignment.Center;
            text_style.BackgroundColor = Color.Magenta;
            text_style.Text = "Style construction";
            text_style.Focusable = true;
            style_parent.Add(text_style);

            // Add ScrollBar of Style construction
            ScrollBarStyle st = new ScrollBarStyle
            {
                Track = new ImageViewStyle
                {
                    BackgroundColor = new Selector<Color>
                    {
                        All = new Color(0.43f, 0.43f, 0.43f, 0.1f),
                    }
                },
                Thumb = new ImageViewStyle
                {
                    BackgroundColor = new Selector<Color>
                    {
                        All = new Color(1.0f, 0.0f, 0.0f, 0.2f),
                    }
                },
            };
            scrollBar[2] = new ScrollBar(st);
            scrollBar[2].Size = new Size(400, 4);
            scrollBar[2].MaxValue = (int)scrollBar[2].SizeWidth / 10;
            scrollBar[2].MinValue = 0;
            scrollBar[2].ThumbSize = new Size(30, 4);
            scrollBar[2].CurrentValue = 0;//set after thumbsize
            style_parent.Add(scrollBar[2]);
        }

        private void CreateBottomView()
        {
            bottom_parent = new View() { Size = new Size(1920, 540) };
            bottom_parent.Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Horizontal, LinearAlignment = LinearLayout.Alignment.Center, CellPadding = new Size2D(50, 50) };
            root.Add(bottom_parent);

            // Create buttons
            CreateButtons();
        }

        void CreateButtons()
        {
            for (int i = 0; i < 4; i++)
            {
                button[i] = new Button();
                button[i].BackgroundColor = Color.Green;
                button[i].Size = new Size(80, 50);
                button[i].Focusable = true;
                bottom_parent.Add(button[i]);
            }

            button[0].Text = "+";
            button[0].Clicked += Scroll1Add;

            button[1].Text = "-";
            button[1].Clicked += Scroll1Minus;

            button[2].Text = "+ / - 4";
            button[2].Clicked += Scroll1_2move;

            button[3].Text = "change direction";
            button[3].Clicked += Scroll1_2Changed;
            button[3].Size = new Size(180, 50);

            // Set focus to Add Button
            FocusManager.Instance.SetCurrentFocusView(button[0]);
        }

        private void Scroll1Add(object sender, global::System.EventArgs e)
        {
            scrollBar[0].CurrentValue++;
            scrollBar[2].CurrentValue++;
        }
        private void Scroll1Minus(object sender, global::System.EventArgs e)
        {
            scrollBar[0].CurrentValue--;
            scrollBar[2].CurrentValue--;
        }

        private void Scroll1_2Changed(object sender, global::System.EventArgs e)
        {
            if (scrollBar[1].LayoutDirection == ViewLayoutDirectionType.LTR)
            {
                scrollBar[1].LayoutDirection = ViewLayoutDirectionType.RTL;
            }
            else
            {
                scrollBar[1].LayoutDirection = ViewLayoutDirectionType.LTR;
            }
        }

        private void Scroll1_2move(object sender, global::System.EventArgs e)
        {
            if (scrollBar[1].CurrentValue < scrollBar[1].MaxValue / 2)
            {
                scrollBar[1].SetCurrentValue(scrollBar[1].MaxValue - 2);
            }
            else
            {
                scrollBar[1].SetCurrentValue(2);
            }
        }

        public void Deactivate()
        {
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                if (text_nullstyle != null)
                {
                    text_nullstyle.Dispose();
                    text_nullstyle = null;
                }

                if (text_style != null)
                {
                    text_style.Dispose();
                    text_style = null;
                }

                for (int i = 0; i < 4; i++)
                {
                    if (button[i] != null)
                    {
                        button[i].Dispose();
                        button[i] = null;
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    if (scrollBar[i] != null)
                    {
                        scrollBar[i].Dispose();
                        scrollBar[i] = null;
                    }
                }

                if (top_parent != null)
                {
                    top_parent.Dispose();
                    top_parent = null;
                }

                if (bottom_parent != null)
                {
                    bottom_parent.Dispose();
                    bottom_parent = null;
                }

                if (null_style_parent != null)
                {
                    null_style_parent.Dispose();
                    null_style_parent = null;
                }

                if (style_parent != null)
                {
                    style_parent.Dispose();
                    style_parent = null;
                }

                root.Dispose();
                root = null;
            }
        }
    }
}

using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class SliderSample : IExample
    {
        private const float MIN_VALUE = 0;
        private const float MAX_VALUE = 100;

        private View root;
        private View top_parent, bottom_parent, ver_slider_parent, hori_slider_parent;
        private TextLabel[] createText = new TextLabel[2];
        private TextLabel[] inforText = new TextLabel[2];
        private Slider[] slider_null_style = new Slider[4];
        private Slider[] slider_style = new Slider[4];

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

            // Textlabel of Null style construction/Style construction and infoText
            CreateTopView();

            // Various kinds of Slider
            CreateBottomView();
        }

        private void InitSliders()
        {
            // Null style construction
            slider_null_style[0] = CreateByProperty(800, 50, 20, Slider.DirectionType.Horizontal);
            slider_null_style[1] = CreateByProperty(800, 50, 30, Slider.DirectionType.Horizontal);
            slider_null_style[1].LowIndicatorTextContent = "SubText";
            slider_null_style[1].LowIndicatorSize = new Size(100, 40);
            slider_null_style[2] = CreateByProperty(50, 400, 20, Slider.DirectionType.Vertical);
            slider_null_style[3] = CreateByProperty(50, 400, 30, Slider.DirectionType.Vertical);
            slider_null_style[3].LowIndicatorTextContent = "SubText";
            slider_null_style[3].LowIndicatorSize = new Size(100, 40);

            // Style construction
            SliderStyle st = new SliderStyle
            {
                TrackThickness = 4,
                Track = new ImageViewStyle
                {
                    BackgroundColor = new Selector<Color>
                    {
                        All = new Color(0, 0, 0, 0.1f),
                    }
                },

                Progress = new ImageViewStyle
                {
                    BackgroundColor = new Selector<Color>
                    {
                        All = new Color(0.05f, 0.63f, 0.9f, 1),
                    }
                },

                Thumb = new ImageViewStyle
                {
                    Size = new Size(60, 60),
                    ResourceUrl = new Selector<string>
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_slide_handler_normal.png",
                        Pressed = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_slide_handler_press.png",
                    },
                    BackgroundImage = new Selector<string>
                    {
                        Normal = "",
                        Pressed = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_slide_handler_effect.png",
                    }
                }
            };
            slider_style[0] = CreateByStyle(st, 800, 50, 20, Slider.DirectionType.Horizontal);
            slider_style[1] = CreateByStyle(st, 800, 50, 30, Slider.DirectionType.Horizontal);
            slider_style[1].LowIndicatorTextContent = "SubText";
            slider_style[1].LowIndicatorSize = new Size(100, 40);
            slider_style[2] = CreateByStyle(st, 50, 400, 20, Slider.DirectionType.Vertical);
            slider_style[3] = CreateByStyle(st, 50, 400, 30, Slider.DirectionType.Vertical);
            slider_style[3].LowIndicatorTextContent = "SubText";
            slider_style[3].LowIndicatorSize = new Size(100, 40);
        }

        private void CreateTopView()
        {
            top_parent = new View() { Size = new Size(1920, 240) };
            top_parent.Layout = new GridLayout() { Rows = 2, GridOrientation = GridLayout.Orientation.Horizontal };
            root.Add(top_parent);

            for (int i = 0; i < 2; i++)
            {
                createText[i] = new TextLabel();
                createText[i].PointSize = 20;
                createText[i].TextColor = Color.Black;
                createText[i].Size = new Size(600, 100);
                createText[i].Margin = new Extents(200, 100, 40, 0);
                createText[i].BackgroundColor = Color.Magenta;
                createText[i].HorizontalAlignment = HorizontalAlignment.Center;
                createText[i].VerticalAlignment = VerticalAlignment.Center;
                top_parent.Add(createText[i]);

                inforText[i] = new TextLabel();
                inforText[i].PointSize = 20;
                inforText[i].TextColor = Color.Blue;
                inforText[i].Text = "currentValue = ";
                inforText[i].BackgroundColor = new Color(0, 0, 0, 0.1f);
                inforText[i].HorizontalAlignment = HorizontalAlignment.Center;
                inforText[i].VerticalAlignment = VerticalAlignment.Center;
                top_parent.Add(inforText[i]);
            }

            // TextLabel of "Null style construction"
            createText[0].Text = "Null style constructions";

            // TextLabel of "Style construction"
            createText[1].Text = "Style construction";
        }

        private void CreateBottomView()
        {
            bottom_parent = new View() { Size = new Size(1920, 840) };
            bottom_parent.Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical, CellPadding = new Size2D(0, 0) };
            root.Add(bottom_parent);

            // Init Sliders
            InitSliders();

            // Add Horizontal Slider
            hori_slider_parent = new View() { Size = new Size(1920, 160) };
            hori_slider_parent.Layout = new GridLayout() { Rows = 2, GridOrientation = GridLayout.Orientation.Horizontal };
            bottom_parent.Add(hori_slider_parent);
            slider_null_style[0].Margin = new Extents(100, 0, 30, 0);
            hori_slider_parent.Add(slider_null_style[0]);
            hori_slider_parent.Add(slider_null_style[1]);
            hori_slider_parent.Add(slider_style[0]);
            hori_slider_parent.Add(slider_style[1]);

            // Add vertical Slider
            ver_slider_parent = new View() { Size = new Size(1920, 680) };
            ver_slider_parent.Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Horizontal, LinearAlignment = LinearLayout.Alignment.CenterVertical, CellPadding = new Size2D(200, 0) };
            bottom_parent.Add(ver_slider_parent);
            slider_null_style[2].Margin = new Extents(350, 0, 0, 0);
            slider_style[2].Margin = new Extents(400, 0, 0, 0);
            ver_slider_parent.Add(slider_null_style[2]);
            ver_slider_parent.Add(slider_null_style[3]);
            ver_slider_parent.Add(slider_style[2]);
            ver_slider_parent.Add(slider_style[3]);
        }

        public void Deactivate()
        {
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                for (int i = 0; i < 2; i++)
                {
                    if (createText[i] != null)
                    {
                        createText[i].Dispose();
                        createText[i] = null;
                    }

                    if (inforText[i] != null)
                    {
                        inforText[i].Dispose();
                        inforText[i] = null;
                    }
                }

                for (int j = 0; j < 4; j++)
                {
                    if (slider_null_style[j] != null)
                    {
                        slider_null_style[j].Dispose();
                        slider_null_style[j] = null;
                    }

                    if (slider_style[j] != null)
                    {
                        slider_style[j].Dispose();
                        slider_style[j] = null;
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

                if (ver_slider_parent != null)
                {
                    ver_slider_parent.Dispose();
                    ver_slider_parent = null;
                }

                if (hori_slider_parent != null)
                {
                    hori_slider_parent.Dispose();
                    hori_slider_parent = null;
                }
                root.Dispose();
                root = null;
            }
        }

        private Slider CreateByProperty(int w, int h, int curValue, Slider.DirectionType dir)
        {
            // Setting the property of selector is not supported now, so add these in style first.
            SliderStyle st = new SliderStyle
            {
                Thumb = new ImageViewStyle()
                {
                    ResourceUrl = new Selector<string>
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_slide_handler_normal.png",
                        Pressed = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_slide_handler_press.png",
                    },
                    BackgroundImage = new Selector<string>
                    {
                        Normal = "",
                        Pressed = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_slide_handler_effect.png",
                    }
                }
            };
            Slider source = new Slider(st);
            source.TrackThickness = 4;
            source.ThumbSize = new Size(60, 60);
            source.BgTrackColor = new Color(0, 0, 0, 0.1f);
            source.SlidedTrackColor = new Color(0.05f, 0.63f, 0.9f, 1);
            source.Direction = dir;
            source.Focusable = true;
            source.MinValue = MIN_VALUE;
            source.MaxValue = MAX_VALUE;
            source.StateChangedEvent += OnStateChanged;
            source.ValueChanged += OnValueChanged;
            source.SlidingStarted += OnSlidingStarted;
            source.SlidingFinished += OnSlidingFinished;
            source.Size = new Size(w, h);
            source.CurrentValue = curValue;
            return source;
        }

        private Slider CreateByStyle(SliderStyle st, int w, int h, int curValue, Slider.DirectionType dir)
        {
            // input style in construction
            Slider source = new Slider(st);
            source.Direction = dir;
            root.Add(source);
            source.Focusable = true;
            source.MinValue = MIN_VALUE;
            source.MaxValue = MAX_VALUE;
            source.StateChangedEvent += OnStateChanged;
            source.ValueChanged += OnValueChanged;
            source.SlidingStarted += OnSlidingStarted;
            source.SlidingFinished += OnSlidingFinished;
            source.Size = new Size(w, h);
            source.CurrentValue = curValue;
            return source;
        }

        private void OnValueChanged(object sender, SliderValueChangedEventArgs args)
        {
            Slider source = sender as Slider;
            if (source != null)
            {
                if (source == slider_style[0] || source == slider_style[1] || source == slider_style[2] || source == slider_style[3])
                {
                    inforText[1].Text = "currentValue = " + args.CurrentValue;
                }
                else
                {
                    inforText[0].Text = "currentValue = " + args.CurrentValue;
                }
            }
        }

        private void OnSlidingStarted(object sender, SliderSlidingStartedEventArgs args)
        {
            Slider source = sender as Slider;
            if (source != null)
            {
                if (source == slider_style[0] || source == slider_style[1] || source == slider_style[2] || source == slider_style[3])
                {
                    inforText[1].Text = "Started currentValue = " + args.CurrentValue;
                }
                else
                {
                    inforText[0].Text = "Started currentValue = " + args.CurrentValue;
                }
            }
        }

        private void OnSlidingFinished(object sender, SliderSlidingFinishedEventArgs args)
        {
            Slider source = sender as Slider;
            if (source != null)
            {
                if (source == slider_style[0] || source == slider_style[1] || source == slider_style[2] || source == slider_style[3])
                {
                    inforText[1].Text = "Finished currentValue = " + args.CurrentValue;
                }
                else
                {
                    inforText[0].Text = "Finished currentValue = " + args.CurrentValue;
                }
            }
        }

        private void OnStateChanged(object sender, Slider.StateChangedArgs args)
        {
            if (sender is Tizen.NUI.Components.Slider)
            {
                Tizen.NUI.Components.Slider slider = sender as Tizen.NUI.Components.Slider;
                if (slider != null)
                {
                    // Do something
                }
            }
        }
    }
}

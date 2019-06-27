using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace Tizen.NUI.CommonUI.Samples
{
    public class SliderSample : IExample
    {
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;

        private View root;
        private TextLabel[] createText = new TextLabel[2];
        private Slider[] slider = new Slider[4];
        private Slider[] slider2 = new Slider[4];
        private TextLabel[] inforText = new TextLabel[2];

        public void Activate()
        {
            Window window = Window.Instance;

            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
            };
            window.Add(root);
            CreateInforText();

            ///////////////////////////////////////////////Create by Property//////////////////////////////////////////////////////////
            createText[0] = new TextLabel();
            createText[0].Text = "Create Slider just by properties";
            createText[0].Size2D = new Size2D(450, 100);
            createText[0].Position2D = new Position2D(200, 100);
            createText[0].MultiLine = true;
            root.Add(createText[0]);

            slider[0] = CreateByProperty(40, 300, 800, 50, 20, Slider.DirectionType.Horizontal);
            slider[1] = CreateByProperty(300, 450, 50, 400, 20, Slider.DirectionType.Vertical);

            slider[2] = CreateByProperty(40, 400, 800, 50, 30, Slider.DirectionType.Horizontal);
            slider[2].LowIndicatorTextContent = "SubText";
            slider[2].LowIndicatorSize = new Size2D(100, 40);

            slider[3] = CreateByProperty(600, 450, 50, 400, 30, Slider.DirectionType.Vertical);
            slider[3].LowIndicatorTextContent = "SubText";
            slider[3].LowIndicatorSize = new Size2D(100, 40);

            /////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            createText[1] = new TextLabel();
            createText[1].Text = "Create Slider just by Attributes";
            createText[1].Size2D = new Size2D(450, 100);
            createText[1].Position2D = new Position2D(1000, 100);
            createText[1].MultiLine = true;
            root.Add(createText[1]);

            SliderAttributes attributes = new SliderAttributes
            {
                TrackThickness = 4,
                BackgroundTrackAttributes = new ImageAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0, 0, 0, 0.1f),
                    }
                },

                SlidedTrackAttributes = new ImageAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0.05f, 0.63f, 0.9f, 1),
                    }
                },

                ThumbAttributes = new ImageAttributes
                {
                    ResourceUrl = new StringSelector
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_slide_handler_normal.png",
                        Pressed = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_slide_handler_press.png",
                    }
                },

                ThumbBackgroundAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(60, 60),
                    ResourceUrl = new StringSelector
                    {
                        Normal = "",
                        Pressed = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_slide_handler_effect.png",
                    }
                }
            };

            slider2[0] = CreateByAttributes(attributes, 890, 300, 800, 50, 20, Slider.DirectionType.Horizontal);
            slider2[1] = CreateByAttributes(attributes, 1150, 450, 50, 400, 20, Slider.DirectionType.Vertical);

            slider2[2] = CreateByAttributes(attributes, 890, 400, 800, 50, 30, Slider.DirectionType.Horizontal);
            slider2[2].LowIndicatorTextContent = "SubText";
            slider2[2].LowIndicatorSize = new Size2D(100, 40);

            slider2[3] = CreateByAttributes(attributes, 1450, 450, 50, 400, 30, Slider.DirectionType.Vertical);
            slider2[3].LowIndicatorTextContent = "SubText";
            slider2[3].LowIndicatorSize = new Size2D(100, 40);
        }

        public void Deactivate()
        {
            if (root != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (slider[i] != null)
                    {
                        root.Remove(slider[i]);
                        slider[i].Dispose();
                        slider[i] = null;
                    }
                    if (slider2[i] != null)
                    {
                        root.Remove(slider2[i]);
                        slider2[i].Dispose();
                        slider2[i] = null;
                    }
                }

                for (int i = 0; i < 2; i++)
                {
                    if (createText[i] != null)
                    {
                        root.Remove(createText[i]);
                        createText[i].Dispose();
                        createText[i] = null;
                    }

                    if (inforText[i] != null)
                    {
                        root.Remove(inforText[i]);
                        inforText[i].Dispose();
                        inforText[i] = null;
                    }
                }
                   
                Window.Instance.Remove(root);
                root.Dispose();
                root = null;
            }
        }

        private void CreateInforText()
        {
            for (int i = 0; i < 2; i++)
            {
                inforText[i] = new TextLabel();
                inforText[i].Size2D = new Size2D(450, 60);
                inforText[i].Position2D = new Position2D(200 + 800 * i, 200);
                inforText[i].PointSize = 20;
                inforText[i].TextColor = Color.Blue;
                inforText[i].Text = "currentValue = ";
                inforText[i].BackgroundColor = new Color(0, 0, 0, 0.1f);
                inforText[i].HorizontalAlignment = HorizontalAlignment.Center;
                inforText[i].VerticalAlignment = VerticalAlignment.Center;
                root.Add(inforText[i]);
            }
        }

        private Slider CreateByProperty(int posX, int posY, int w, int h, int curValue, Slider.DirectionType dir)
        {           
            Slider source = new Slider();
            source.TrackThickness = 4;
            source.BgTrackColor = new Color(0, 0, 0, 0.1f);
            source.SlidedTrackColor = new Color(0.05f, 0.63f, 0.9f, 1);
            source.ThumbImageURLSelector = new StringSelector
            {
                Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_slide_handler_normal.png",
                Pressed = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_slide_handler_press.png",
            };
            source.ThumbSize = new Size2D(60, 60);
            source.ThumbImageBackgroundURLSelector = new StringSelector
            {
                Normal = "",
                Pressed = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_slide_handler_effect.png",
            };
            source.Direction = dir;
            root.Add(source);
            source.Focusable = true;
            source.MinValue = MIN_VALUE;
            source.MaxValue = MAX_VALUE;
            source.StateChangedEvent += OnStateChanged;
            source.ValueChangedEvent += OnValueChanged;

            source.Position2D = new Position2D(posX, posY);
            source.Size2D = new Size2D(w, h);
            source.CurrentValue = curValue;
            return source;
        }

        private Slider CreateByAttributes(SliderAttributes attrs, int posX, int posY, int w, int h, int curValue, Slider.DirectionType dir)
        {
            Slider source = new Slider(attrs);
            source.Direction = dir;
            root.Add(source);
            source.Focusable = true;
            source.MinValue = MIN_VALUE;
            source.MaxValue = MAX_VALUE;
            source.StateChangedEvent += OnStateChanged;
            source.ValueChangedEvent += OnValueChanged;

            source.Position2D = new Position2D(posX, posY);
            source.Size2D = new Size2D(w, h);
            source.CurrentValue = curValue;
            return source;
        }

        private void OnValueChanged(object sender, Slider.ValueChangedArgs args)
        {
            Slider source = sender as Slider;
            if (source != null)
            {
                if (source == slider2[0] || source == slider2[1] || source == slider2[2] || source == slider2[3])
                {
                    inforText[1].Text = "currentValue = " + args.CurrentValue;
                }
                else
                {
                    inforText[0].Text = "currentValue = " + args.CurrentValue;
                }
            }
        }

        private void OnStateChanged(object sender, Slider.StateChangedArgs args)
        {
            if (sender is Tizen.NUI.CommonUI.Slider)
            {
                Tizen.NUI.CommonUI.Slider slider = sender as Tizen.NUI.CommonUI.Slider;
                if (slider != null)
                {
                    // Do something
                }
            }
        }
    }
}

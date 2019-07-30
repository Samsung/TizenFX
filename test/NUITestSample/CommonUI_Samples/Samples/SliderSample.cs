using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;
using System;
using Tizen.NUI;

namespace NuiCommonUiSamples
{
    public class Slider : IExample
    {
        private SampleLayout root;
        private TextLabel inforText;
        private Tizen.NUI.CommonUI.Slider[] slider_da;
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;
        private const int SR_COUNT = 2;
        private const int DA_COUNT = 4;

        private static readonly string[] styleName = new string[2] {
            "DefaultSlider",
            "TextSlider" };

        public void Activate()
        {
            Window.Instance.BackgroundColor = Color.White;
            root = new SampleLayout();
            root.HeaderText = "Slider";
            CreateInforText();
            CreateDA();
        }

        private void CreateInforText()
        {
            inforText = new TextLabel();
            inforText.Size2D = new Size2D(1040, 60);
            inforText.Position2D = new Position2D(20, 10);
            inforText.PointSize = 20;
            inforText.TextColor = Color.Blue;
            inforText.BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1.0f);
            inforText.HorizontalAlignment = HorizontalAlignment.Begin;
            inforText.VerticalAlignment = VerticalAlignment.Center;
            root.Add(inforText);
        }

        private void CreateDA()
        {
            if (slider_da == null)
            {
                slider_da = new Tizen.NUI.CommonUI.Slider[DA_COUNT];
            }

            slider_da[0] = CreateDA(styleName[0], 40, 100, 1000, 50, 20, Tizen.NUI.CommonUI.Slider.DirectionType.Horizontal);
            slider_da[1] = CreateDA(styleName[0], 300, 250, 50, 400, 20, Tizen.NUI.CommonUI.Slider.DirectionType.Vertical);

            slider_da[2] = CreateDA(styleName[1], 40, 200, 1000, 50, 30, Tizen.NUI.CommonUI.Slider.DirectionType.Horizontal);
            slider_da[2].LowIndicatorTextContent = "SubText";
            slider_da[2].LowIndicatorSize = new Size2D(200, 80);

            slider_da[3] = CreateDA(styleName[1], 600, 250, 50, 400, 30, Tizen.NUI.CommonUI.Slider.DirectionType.Vertical);
            slider_da[3].LowIndicatorTextContent = "SubText";
            slider_da[3].LowIndicatorSize = new Size2D(200, 80);

        }

        private Tizen.NUI.CommonUI.Slider CreateDA(string style, int posX, int posY, int w, int h, int curValue, Tizen.NUI.CommonUI.Slider.DirectionType dir)
        {
            Tizen.NUI.CommonUI.Slider source = new Tizen.NUI.CommonUI.Slider(style);
            source.Name = style;
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

        public void Deactivate()
        {
            Window window = Window.Instance;

            if (inforText != null)
            {
                root.Remove(inforText);
                inforText.Dispose();
                inforText = null;
            }

            DestroyDA();
            root.Dispose();
        }

        private void DestroyDA()
        {
            if (slider_da != null)
            {
                for (int i = 0; i < DA_COUNT; ++i)
                {
                    if (slider_da[i] != null)
                    {
                        slider_da[i].StateChangedEvent -= OnStateChanged;
                        slider_da[i].ValueChangedEvent -= OnValueChanged;
                        root.Remove(slider_da[i]);
                        slider_da[i].Dispose();
                        slider_da[i] = null;
                    }
                }
                slider_da = null;
            }
        }

        private void OnValueChanged(object sender, Tizen.NUI.CommonUI.Slider.ValueChangedArgs args)
        {
            Console.WriteLine("args.CurrentValue = " + args.CurrentValue);
            if (sender is Tizen.NUI.CommonUI.Slider)
            {
                Tizen.NUI.CommonUI.Slider slider = sender as Tizen.NUI.CommonUI.Slider;
                if (slider != null)
                {
                    inforText.Text = "name = " + slider.Name + ", currentValue = " + args.CurrentValue;
                }
            }
            else if (sender is Tizen.NUI.CommonUI.Slider)
            {
                Tizen.NUI.CommonUI.Slider slider = sender as Tizen.NUI.CommonUI.Slider;
                if (slider != null)
                {
                    inforText.Text = "name = " + slider.Name + ", currentValue = " + args.CurrentValue;
                }
            }
        }

        private void OnStateChanged(object sender, Tizen.NUI.CommonUI.Slider.StateChangedArgs args)
        {
            Console.WriteLine("args.CurrentState = " + args.CurrentState);
            if (sender is Tizen.NUI.CommonUI.Slider)
            {
                Tizen.NUI.CommonUI.Slider slider = sender as Tizen.NUI.CommonUI.Slider;
                if (slider != null)
                {
                    //if (args.CurrentState == States.Normal)
                    //{
                    //    slider_sr[0].ThumbImageURL = "*DemoRes*/images/FH3/9. Controller/controller_btn_slide_handler_normal.png";
                    //}
                    //else if (args.CurrentState == States.Focused || args.CurrentState == States.Pressed)
                    //{
                    //    slider_sr[0].ThumbImageURL = "*DemoRes*/images/FH3/9. Controller/controller_btn_slide_handler_press.png";
                    //}
                }
            }
        }
    }
}

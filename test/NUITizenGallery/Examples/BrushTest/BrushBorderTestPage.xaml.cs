/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI;

namespace NUITizenGallery
{
    public partial class BrushBorderTestPage : ContentPage
    {
        private VisualView FrameView;
        private TextVisual FrameText;
        private BorderVisual FrameBorder;
        private GradientVisual LinearGradient;
        private GradientVisual RadialGradient;

        private readonly string TextId = "_textVisual";
        private readonly string BorderId = "_borderVisual";
        private readonly string LinearGradientId = "_linearGradientVisual";
        private readonly string RadialGradientId = "_radialGradientVisual";


        public BrushBorderTestPage()
        {
            InitializeComponent();

            ButtonSolid.Clicked += OnClickedSolid;
            ButtonGradientLinear.Clicked += OnClickedLinear;
            ButtonGradientRadial.Clicked += OnClickedRadial;

            FrameView = new VisualView()
            {
                Size = new Size(500, 100),
                BackgroundColor = Tizen.NUI.Color.White,
                BoxShadow = new Shadow(10.0f, new Color(0.2f, 0.2f, 0.2f, 1.0f), new Vector2(5,5))
            };

            FrameText = new TextVisual();
            FrameText.Text = "Frame With Shadow";
            FrameText.TextColor = Tizen.NUI.Color.Black;
            FrameText.PointSize = 10;
            FrameText.HorizontalAlignment = HorizontalAlignment.Center;

            PropertyArray stopColor = new PropertyArray();
            stopColor.Add(new PropertyValue(new Vector4(255.0f, 0.0f, 0.0f, 255.0f) / 255.0f));
            stopColor.Add(new PropertyValue(new Vector4(0.0f, 255.0f, 0.0f, 255.0f) / 255.0f));

            LinearGradient = new GradientVisual();
            LinearGradient.StopColor = stopColor;
            LinearGradient.StartPosition = new Vector2(0.0f, 0.0f);
            LinearGradient.EndPosition = new Vector2(0.3f, 0.3f);
            LinearGradient.Origin = Visual.AlignType.TopBegin;

            RadialGradient = new GradientVisual();
            RadialGradient.Center = new Vector2(0.0f, 0.0f);
            RadialGradient.Radius = 0.5f;
            RadialGradient.StopColor = stopColor;
            RadialGradient.Origin = Visual.AlignType.TopBegin;

            FrameBorder = new BorderVisual();
            FrameBorder.BorderSize = 2.0f;
            FrameBorder.Color = Tizen.NUI.Color.Blue;
            FrameBorder.RelativeSize = new RelativeVector2(1.0f, 1.0f);

            FrameView.AddVisual(BorderId, FrameBorder);
            FrameView.AddVisual(TextId, FrameText);

            ContentView.Add(FrameView);
        }

        public void OnClickedSolid(object sender, ClickedEventArgs args)
        {
            ViewTest1.BackgroundColor = Color.Red;

            FrameView.RemoveAll();
            FrameView.BackgroundColor = Color.Red;
            FrameView.AddVisual(BorderId, FrameBorder);
            FrameView.AddVisual(TextId, FrameText);
        }

        public void OnClickedLinear(object sender, ClickedEventArgs args)
        {
            ViewTest1.Background = LinearGradient.OutputVisualMap;
            FrameView.RemoveAll();

            FrameView.AddVisual(LinearGradientId, LinearGradient);
            FrameView.AddVisual(BorderId, FrameBorder);
            FrameView.AddVisual(TextId, FrameText);
        }

        public void OnClickedRadial(object sender, ClickedEventArgs args)
        {
            ViewTest1.Background = RadialGradient.OutputVisualMap;
            FrameView.RemoveAll();

            FrameView.AddVisual(RadialGradientId, RadialGradient);
            FrameView.AddVisual(BorderId, FrameBorder);
            FrameView.AddVisual(TextId, FrameText);
        }
    }
}

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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class FrameTest1Page : View
    {
        VisualView FrameView;
        TextVisual FrameText;
        public FrameTest1Page()
        {
            FrameView = new VisualView()
            {
                Size = new Size(500, 100),
                BackgroundColor = Tizen.NUI.Color.White,
                BoxShadow = new Shadow(10.0f, new Color(0.2f, 0.2f, 0.2f, 1.0f), new Vector2(5, 5)),
            };

            FrameText = new TextVisual();
            FrameText.Text = "Frame With Shadow";
            FrameText.TextColor = Tizen.NUI.Color.Black;
            FrameText.PointSize = 10;
            FrameText.HorizontalAlignment = HorizontalAlignment.Center;

            BorderVisual borderVisual = new BorderVisual();
            borderVisual.BorderSize = 2.0f;
            borderVisual.Color = Tizen.NUI.Color.Blue;
            borderVisual.RelativeSize = new RelativeVector2(1.0f, 1.0f);

            FrameView.AddVisual("_borderVisual", borderVisual);
            FrameView.AddVisual("_textVisual", FrameText);

            InitializeComponent();
            Add(FrameView);

            ShadowOnBackground.Clicked += OnShadowOnButtonClicked;
            ShadowOffBackground.Clicked += OnShadowOffButtonClicked;
        }

        public void OnShadowOffButtonClicked(object sender, ClickedEventArgs args)
        {
            FrameView.BoxShadow = null;
            FrameText.Text = "Frame with no shadow";
        }

        public void OnShadowOnButtonClicked(object sender, ClickedEventArgs args)
        {
            FrameView.BoxShadow = new Shadow(10.0f, new Color(0.2f, 0.2f, 0.2f, 1.0f), new Vector2(5, 5));
            FrameText.Text = "Frame with shadow";
        }
    }
}

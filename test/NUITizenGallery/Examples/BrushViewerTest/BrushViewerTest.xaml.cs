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
    public partial class BrushViewerTestPage : View
    {
        public BrushViewerTestPage()
        {
            InitializeComponent();

            LinearLayout pageLayout = new LinearLayout();
            pageLayout.LinearOrientation = LinearLayout.Orientation.Vertical;
            pageLayout.CellPadding = new Size2D(10, 10);
            pageLayout.Padding = new Extents(10, 10, 10, 10);
            this.Layout = pageLayout;

            ButtonSolid.Clicked += OnClickedSolid;
            ButtonGradientLinear.Clicked += OnClickedLinear;
            ButtonGradientRadial.Clicked += OnClickedRadial;
        }

        public void OnClickedSolid(object sender, ClickedEventArgs args)
        {
            BrushViewer.RemoveVisual("radialGradient");
            BrushViewer.RemoveVisual("linearGradient");
            BrushViewer.BackgroundColor = new Color(1f, 0f, 0f, 1f);
        }

        public void OnClickedLinear(object sender, ClickedEventArgs args)
        {
            ///Create new visual view and gradient visual instances
            GradientVisual gradientVisualMap1 = new GradientVisual();

            PropertyArray stopColor = new PropertyArray();
            stopColor.Add(new PropertyValue(new Vector4(255.0f, 0.0f, 0.0f, 255.0f) / 255.0f));
            stopColor.Add(new PropertyValue(new Vector4(0.0f, 255.0f, 0.0f, 255.0f) / 255.0f));

            gradientVisualMap1.StartPosition = new Vector2(0.0f, 0.0f);
            gradientVisualMap1.EndPosition = new Vector2(0.3f, 0.3f);
            gradientVisualMap1.StopColor = stopColor;
            gradientVisualMap1.Origin = Visual.AlignType.TopBegin;

            BrushViewer.RemoveVisual("radialGradient");
            BrushViewer.AddVisual("linearGradient", gradientVisualMap1);
        }

        public void OnClickedRadial(object sender, ClickedEventArgs args)
        {
            GradientVisual gradientVisualMap1 = new GradientVisual();

            PropertyArray stopColor = new PropertyArray();
            stopColor.Add(new PropertyValue(new Vector4(255.0f, 0.0f, 0.0f, 255.0f) / 255.0f));
            stopColor.Add(new PropertyValue(new Vector4(0.0f, 255.0f, 0.0f, 255.0f) / 255.0f));

            gradientVisualMap1.Center = new Vector2(0.0f, 0.0f);
            gradientVisualMap1.Radius = 0.5f;
            gradientVisualMap1.StopColor = stopColor;
            gradientVisualMap1.Origin = Visual.AlignType.TopBegin;

            BrushViewer.RemoveVisual("linearGradient");
            BrushViewer.AddVisual("radialGradient", gradientVisualMap1);
        }
    }
}

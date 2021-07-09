﻿/*
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
    public partial class BrushComponentsTestPage : View
    {
        public BrushComponentsTestPage()
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
            ViewTest1.BackgroundColor = Color.Red;
            ViewTest2.BackgroundColor = Color.Red;
            ViewTest3.BackgroundColor = Color.Red;
        }

        public void OnClickedLinear(object sender, ClickedEventArgs args) 
        {
            PropertyArray stopColor = new PropertyArray();
            stopColor.Add(new PropertyValue(new Vector4(255.0f, 0.0f, 0.0f, 255.0f) / 255.0f));
            stopColor.Add(new PropertyValue(new Vector4(0.0f, 255.0f, 0.0f, 255.0f) / 255.0f));

            GradientVisual linearGradient = new GradientVisual();
            linearGradient.StopColor = stopColor;
            linearGradient.StartPosition = new Vector2(0.0f, 0.0f);
            linearGradient.EndPosition = new Vector2(0.3f, 0.3f);
            linearGradient.Origin = Visual.AlignType.TopBegin;

            ViewTest1.Background = linearGradient.OutputVisualMap;
            ViewTest2.Background = linearGradient.OutputVisualMap;
            ViewTest3.Background = linearGradient.OutputVisualMap;
        }

        public void OnClickedRadial(object sender, ClickedEventArgs args) 
        {
            PropertyArray stopColor = new PropertyArray();
            stopColor.Add(new PropertyValue(new Vector4(255.0f, 0.0f, 0.0f, 255.0f) / 255.0f));
            stopColor.Add(new PropertyValue(new Vector4(0.0f, 255.0f, 0.0f, 255.0f) / 255.0f));

            GradientVisual radialGradient = new GradientVisual();
            radialGradient.Center = new Vector2(0.0f, 0.0f);
            radialGradient.Radius = 0.5f;
            radialGradient.StopColor = stopColor;
            radialGradient.Origin = Visual.AlignType.TopBegin;

            ViewTest1.Background = radialGradient.OutputVisualMap;
            ViewTest2.Background = radialGradient.OutputVisualMap;
            ViewTest3.Background = radialGradient.OutputVisualMap;
        }
    }
}

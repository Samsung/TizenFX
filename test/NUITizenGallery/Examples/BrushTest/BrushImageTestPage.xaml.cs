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
using System;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Components.Extension;

namespace NUITizenGallery
{
    public partial class BrushImageTestPage : ContentPage
    {
        private GradientVisual LinearGradient;
        private GradientVisual RadialGradient;
        private readonly string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/";

        public BrushImageTestPage()
        {
            InitializeComponent();

            ButtonSolid.Clicked += OnClickedSolid;
            ButtonGradientLinear.Clicked += OnClickedLinear;
            ButtonGradientRadial.Clicked += OnClickedRadial;

            Image1.SetImage(ResourcePath + "tizen.png");
            Image2.SetImage(ResourcePath + "xamarin_logo.png");

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
        }

        public void OnClickedSolid(object sender, ClickedEventArgs args)
        {
            Image1.BackgroundColor = Color.Red;
            Image2.BackgroundColor = Color.Red;
        }

        public void OnClickedLinear(object sender, ClickedEventArgs args)
        {
            Image1.Background = LinearGradient.OutputVisualMap;
            Image2.Background = LinearGradient.OutputVisualMap;
        }

        public void OnClickedRadial(object sender, ClickedEventArgs args)
        {
            Image1.Background = RadialGradient.OutputVisualMap;
            Image2.Background = RadialGradient.OutputVisualMap;
        }
    }
}

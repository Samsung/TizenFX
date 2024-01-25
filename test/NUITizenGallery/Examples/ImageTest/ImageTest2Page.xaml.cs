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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class ImageTest2Page : ContentPage
    {
        private bool colorChanged = false;
        public ImageTest2Page()
        {

            InitializeComponent();

            image1Btn.Clicked += (o, e) =>
            {
                imageView.FittingMode = FittingModeType.ShrinkToFit;
                imageView.WidthResizePolicy = Tizen.NUI.ResizePolicyType.UseNaturalSize;
                imageView.HeightResizePolicy = Tizen.NUI.ResizePolicyType.UseNaturalSize;
            };

            image2Btn.Clicked += (o, e) =>
            {
                imageView.FittingMode = FittingModeType.ScaleToFill;
                imageView.HeightResizePolicy = Tizen.NUI.ResizePolicyType.FillToParent;
                imageView.HeightResizePolicy = Tizen.NUI.ResizePolicyType.FillToParent;
            };

            image3Btn.Clicked += (o, e) =>
            {
                imageView.FittingMode = FittingModeType.Fill;
                imageView.HeightResizePolicy = Tizen.NUI.ResizePolicyType.FillToParent;
                imageView.WidthResizePolicy = Tizen.NUI.ResizePolicyType.FillToParent;
            };

            image4Btn.Clicked += (o, e) =>
            {
                if (colorChanged)
                {
                    imgView.BackgroundColor = Tizen.NUI.Color.Transparent;
                }
                else
                {
                    imgView.BackgroundColor = Tizen.NUI.Color.Red;
                }
                colorChanged = !colorChanged;
            };
        }
    }
}

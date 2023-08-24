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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class ImageTest1Page : ContentPage
    {
        private readonly string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/";
        public ImageTest1Page()
        {
            InitializeComponent();

            image1Btn.Clicked += (o, e) =>
            {
                imageView.SetImage(ResourcePath + "NUITizenGallery.png");
            };

            image2Btn.Clicked += (o, e) =>
            {
                imageView.SetImage(ResourcePath + "b.jpg");
            };

            image3Btn.Clicked += (o, e) =>
            {
                imageView.SetImage(ResourcePath + "tizen.png");
            };

            image4Btn.Clicked += (o, e) =>
            {
                imageView.SetImage(ResourcePath + "4000x2802.jpg");
            };

            image5Btn.Clicked += (o, e) =>
            {
                imageView.SetImage(ResourcePath + "8000x10454.jpg");
            };

            image6Btn.Clicked += (o, e) =>
            {
                imageView.SetImage("http://pe.tedcdn.com/images/ted/2e306b9655267cee35e45688ace775590b820510_615x461.jpg");
            };

            image7Btn.Clicked += (o, e) =>
            {
                imageView.SetImage(ResourcePath + "picture.png");
            };

            sliderA.ValueChanged += OnValueChanged;
            sliderR.ValueChanged += OnValueChanged;
            sliderG.ValueChanged += OnValueChanged;
            sliderB.ValueChanged += OnValueChanged;
        }

        private void OnValueChanged(object sender, SliderValueChangedEventArgs e)
        {
            float r, g, b, a;
            a = sliderA.CurrentValue / 255;
            r = sliderR.CurrentValue / 255;
            g = sliderG.CurrentValue / 255;
            b = sliderB.CurrentValue / 255;
            /* Remind : Color is inofficial Property.
             * Use Opacity for Alpha blending. */
            imageView.Color = new Tizen.NUI.Color(r, g, b, a);
        }
    }
}

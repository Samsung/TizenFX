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
    public partial class AnimationTest3Page : ContentPage
    {
        private Animation animation;

        public AnimationTest3Page()
        {
            InitializeComponent();

            animation = new Animation(2000);
            animation.AnimateTo(imageView, "Opacity", 0.0f, 0, 1000);
            animation.AnimateTo(imageView, "Opacity", 1.0f, 1000, 2000);
            animation.AnimateTo(imageView, "PositionY", 400.0f, 0, 2000);
            animation.AnimateTo(imageView, "ScaleX", 2.0f, 0, 1000);
            animation.AnimateTo(imageView, "ScaleY", 2.0f, 0, 1000);
            animation.AnimateTo(imageView, "ScaleX", 1.0f, 1000, 2000);
            animation.AnimateTo(imageView, "ScaleY", 1.0f, 1000, 2000);
            animation.AnimateTo(imageView, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.Z), 0, 1000);
            animation.AnimateTo(imageView, "Orientation", new Rotation(new Radian(new Degree(360.0f)), PositionAxis.Z), 1000, 2000);
            image1Btn.Clicked += (o, e) =>
            {
                imageView.PositionY = 0.0f;
                imageView.Orientation = new Rotation(new Radian(new Degree(0.0f)), PositionAxis.Z);
                animation.Play();
                desc1.Text = "True";
            };

            image2Btn.Clicked += (o, e) =>
            {
                animation.Stop();
                desc1.Text = "False";
            };
        }
    }
}
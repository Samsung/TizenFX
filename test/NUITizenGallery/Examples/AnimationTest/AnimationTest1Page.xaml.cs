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
    public partial class AnimationTest1Page : ContentPage
    {
        private Animation animation;

        public AnimationTest1Page()
        {
            InitializeComponent();

            animation = new Animation(2000);

            animation.AnimateTo(imageView, "ScaleX", 0.6f, 0, 1000);
            animation.AnimateTo(imageView, "ScaleY", 0.6f, 0, 1000);
            animation.AnimateTo(imageView, "ScaleX", 3.0f, 1000, 2000);
            animation.AnimateTo(imageView, "ScaleY", 3.0f, 1000, 2000);

            image1Btn.Clicked += (o, e) =>
            {
                imageView.Scale = new Vector3(1.0f, 1.0f, 1.0f);
                animation.Play();
                desc1.Text = "True";
            };

            image2Btn.Clicked += (o, e) =>
            {
                animation.Stop();
                desc1.Text = "False";
            };

            animation.Finished += (o, e) =>
            {
                desc1.Text = "False";
            };
        }
    }
}
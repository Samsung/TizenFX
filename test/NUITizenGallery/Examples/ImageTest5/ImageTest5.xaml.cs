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
    public partial class ImageTest5Page : View
    {

        private float imgWidth = 0;
        private float imgHeight = 0;

        private void updateLabel()
        {
            imgHeight = imageView.Size2D.Height;
            imgWidth = imageView.Size2D.Width;
            desc1.Text = "Mode : AscpectFit / Width : " + (imgWidth > 0 ? imgWidth.ToString() : "-") + ", Height: " + (imgHeight > 0 ? imgHeight.ToString() : "-");
        }

        public ImageTest5Page()
        {
            InitializeComponent();
            updateLabel();

            image1Btn.Clicked += (o, e) =>
            {
                imageView.Size2D = new Size2D(imageView.Size2D.Width + 100, imageView.Size2D.Height + 100);
                updateLabel();
            };
            image2Btn.Clicked += (o, e) =>
            {
                imageView.Size2D = new Size2D(imageView.Size2D.Width - 100, imageView.Size2D.Height - 100);
                updateLabel();
            };
            image3Btn.Clicked += (o, e) =>
            {
                imageView.Size2D = new Size2D(imageView.Size2D.Width, imageView.Size2D.Height + 100);
                updateLabel();
            };
            image4Btn.Clicked += (o, e) =>
            {
                imageView.Size2D = new Size2D(imageView.Size2D.Width, imageView.Size2D.Height - 100);
                updateLabel();
            };
            image5Btn.Clicked += (o, e) =>
            {
                updateLabel();
            };
        }
    }
}
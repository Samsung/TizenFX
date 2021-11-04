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
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents.VectorGraphics;

namespace NUITizenGallery
{
    public partial class VectorGraphicsCanvasViewTest3Page : ContentPage
    {
        public VectorGraphicsCanvasViewTest3Page()
        {
            InitializeComponent();

            Shape clipper1 = new Shape()
            {
                FillColor = Color.Red
            };
            clipper1.AddCircle(200, 150, 100, 100);

            Shape shape1 = new Shape()
            {
                FillColor = Color.Red,
                Opacity=0.5f
            };
            shape1.AddRect(50, 0, 200, 200, 10, 10);

            shape1.ClipPath(clipper1);
            canvasView.AddDrawable(shape1);


            Shape mask1 = new Shape()
            {
                FillColor = Color.Red,
                Opacity=0.5f
            };
            mask1.AddCircle(200, 350, 100, 100);

            Shape shape2 = new Shape()
            {
                FillColor = Color.Green,
                Opacity=0.5f
            };
            shape2.AddRect(50, 200, 200, 200, 10, 10);

            shape2.Mask(mask1, MaskType.Alpha);
            canvasView.AddDrawable(shape2);

            Shape mask2 = new Shape()
            {
                FillColor = Color.Red,
                Opacity=0.5f
            };
            mask2.AddCircle(200, 600, 100, 100);

            Shape shape3 = new Shape()
            {
                FillColor = Color.Blue,
                Opacity=0.5f
            };
            shape3.AddRect(50, 450, 200, 200, 10, 10);

            shape3.Mask(mask2, MaskType.AlphaInverse);
            canvasView.AddDrawable(shape3);
        }
    }
}
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
using Tizen.NUI.BaseComponents.VectorGraphics;

namespace NUITizenGallery
{
    public partial class VectorGraphicsCanvasViewTest1Page : ContentPage
    {
        public VectorGraphicsCanvasViewTest1Page()
        {
            InitializeComponent();

            Shape shape1 = new Shape()
            {
                FillColor = Color.Green,
                StrokeColor = new Color(0.5f, 0.0f, 0.0f, 0.5f),
                StrokeWidth = 10.0f
            };
            shape1.Translate(240.0f, 150.0f);
            shape1.Scale(1.2f);
            shape1.Rotate(30.0f);
            shape1.AddRect(-50.0f, -50.0f, 100.0f, 100.0f, 20.0f, 20.0f);

            canvasView.AddDrawable(shape1);

            Shape shape2 = new Shape()
            {
                FillColor = Color.Red,
                StrokeColor = Color.Blue,
                StrokeWidth = 20.0f,
                Opacity = 0.5f
            };
            shape2.Translate(240.0f, 350.0f);
            shape2.AddCircle(0.0f, 0.0f, 50.0f, 50.0f);

            canvasView.AddDrawable(shape2);

            Shape shape3 = new Shape()
            {
                FillColor = Color.Green,
                StrokeColor = Color.Cyan,
                StrokeWidth = 20.0f,
            };
            shape3.Translate(240.0f, 550.0f);
            shape3.Scale(0.5f);
            shape3.AddMoveTo(-1.0f, -165.0f);
            shape3.AddLineTo(53.0f, -56.0f);
            shape3.AddLineTo(174.0f, -39.0f);
            shape3.AddLineTo(87.0f, 45.0f);
            shape3.AddLineTo(107.0f, 166.0f);
            shape3.AddLineTo(-1.0f, 110.0f);
            shape3.AddLineTo(-103.0f, 166.0f);
            shape3.AddLineTo(-88.0f, 46.0f);
            shape3.AddLineTo(-174.0f, -38.0f);
            shape3.AddLineTo(-54.0f, -56.0f);
            shape3.Close();

            canvasView.AddDrawable(shape3);
        }
    }
}
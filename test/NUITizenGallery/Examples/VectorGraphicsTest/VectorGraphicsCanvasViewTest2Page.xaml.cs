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
    public partial class VectorGraphicsCanvasViewTest2Page : ContentPage
    {
        public VectorGraphicsCanvasViewTest2Page()
        {
            InitializeComponent();

            Shape canvasView1BackGround = new Shape()
            {
                FillColor = Color.Green
            };
            canvasView1BackGround.AddRect(0, 0, canvasView.Size.Width, canvasView.Size.Height, 0 ,0);
            canvasView.AddDrawable(canvasView1BackGround);


            LinearGradient shape1FillLinearGradient = new LinearGradient()
            {
                ColorStops = new List<ColorStop>()
                {
                    new ColorStop(0.0f, Color.Red),
                    new ColorStop(0.5f, Color.Green),
                    new ColorStop(1.0f, Color.Blue)
                }.AsReadOnly()
            };
            shape1FillLinearGradient.SetBounds(new Position2D(-50, -50), new Position2D(50, 50));

            LinearGradient shape1StrokeLinearGradient = new LinearGradient()
            {
                ColorStops = new List<ColorStop>()
                {
                    new ColorStop(0.0f, Color.Magenta),
                    new ColorStop(1.0f, Color.Cyan)
                }.AsReadOnly()
            };
            shape1StrokeLinearGradient.SetBounds(new Position2D(0, -50), new Position2D(50, 50));

            Shape shape1 = new Shape()
            {
                StrokeWidth = 30.0f,
                FillGradient = shape1FillLinearGradient,
                StrokeGradient = shape1StrokeLinearGradient,
            };

            shape1.Translate(150.0f, 150.0f);
            shape1.Scale(0.8f);
            shape1.AddMoveTo(-1.0f, -165.0f);
            shape1.AddLineTo(53.0f, -56.0f);
            shape1.AddLineTo(174.0f, -39.0f);
            shape1.AddLineTo(87.0f, 45.0f);
            shape1.AddLineTo(107.0f, 166.0f);
            shape1.AddLineTo(-1.0f, 110.0f);
            shape1.AddLineTo(-103.0f, 166.0f);
            shape1.AddLineTo(-88.0f, 46.0f);
            shape1.AddLineTo(-174.0f, -38.0f);
            shape1.AddLineTo(-54.0f, -56.0f);
            shape1.Close();

            canvasView.AddDrawable(shape1);


            Shape canvasView2BackGround = new Shape()
            {
                FillColor = Color.Blue,
                Opacity=0.5f
            };
            canvasView2BackGround.AddRect(0, 0, canvasView.Size.Width, canvasView.Size.Height, 0 ,0);
            canvasView2.AddDrawable(canvasView2BackGround);

            RadialGradient shape2FillRadialGradient = new RadialGradient()
            {
                ColorStops = new List<ColorStop>()
                {
                    new ColorStop(0.0f, Color.Red),
                    new ColorStop(0.5f, Color.Green),
                    new ColorStop(1.0f, Color.Blue)
                }.AsReadOnly(),
                Spread = SpreadType.Reflect
                
            };
            shape2FillRadialGradient.SetBounds(new Position2D(0, 0), 50);

            RadialGradient shape2StrokeRadialGradient = new RadialGradient()
            {
                ColorStops = new List<ColorStop>()
                {
                    new ColorStop(0.0f, Color.Magenta),
                    new ColorStop(1.0f, Color.Cyan)
                }.AsReadOnly(),
                Spread = SpreadType.Repeat
            };
            shape2StrokeRadialGradient.SetBounds(new Position2D(0, 0), 20);

            Shape shape2 = new Shape()
            {
                StrokeWidth = 40.0f,
                FillGradient = shape2FillRadialGradient,
                StrokeGradient = shape2StrokeRadialGradient,
            };
            shape2.Translate(150.0f, 150.0f);
            shape2.AddCircle(0, 0, 120.0f, 120.0f);
            shape2.Close();

            canvasView2.AddDrawable(shape2);
        }
    }
}
using System.Drawing;
using System.Threading;
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
    public partial class VectorGraphicsCanvasViewTest4Page : ContentPage
    {
        public const float StrokeWidthGap = 5.0f;
        public const int HeightGap = 80;
        public const int NumberOfShapes = 8;

        Shape[] mShape = new Shape[NumberOfShapes];
        

        public VectorGraphicsCanvasViewTest4Page()
        {
            InitializeComponent();

            for(int i = 0; i < NumberOfShapes; i++)
            {
                mShape[i] = new Shape()
                {
                    StrokeColor = Tizen.NUI.Color.Red,
                    StrokeWidth = 5.0f + (i * StrokeWidthGap)
                };
                mShape[i].AddMoveTo(50, 20 + i * HeightGap);
                mShape[i].AddLineTo(380, 20 + i * HeightGap);
                mShape[i].AddLineTo(450, 80 + i * HeightGap);

                canvasView.AddDrawable(mShape[i]);
            }

            mShape[0].StrokeColor = Tizen.NUI.Color.Blue;
            mShape[1].StrokeColor = Tizen.NUI.Color.Yellow;
            mShape[2].StrokeColor = Tizen.NUI.Color.Green;
            mShape[3].StrokeColor = Tizen.NUI.Color.Cyan;
            mShape[4].StrokeColor = new Tizen.NUI.Color(0.8f, 0.5f, 0.2f, 0.7f);

            mShape[3].StrokeCap = StrokeCapType.Square;
            mShape[4].StrokeCap = StrokeCapType.Round;
            mShape[5].StrokeCap = StrokeCapType.Butt;

            mShape[3].StrokeJoin = StrokeJoinType.Bevel;
            mShape[4].StrokeJoin = StrokeJoinType.Round;
            mShape[5].StrokeJoin = StrokeJoinType.Miter;

            mShape[6].Opacity = 0.5f;

            mShape[0].StrokeDash = new List<float>() { 15.0f, 20.0f, 20.0f, 10.0f }.AsReadOnly();
            mShape[1].StrokeDash = new List<float>() { 5.0f, 15.0f, 20.0f }.AsReadOnly();
            mShape[2].StrokeDash = new List<float>() { 15.0f, 40.0f }.AsReadOnly();
            mShape[7].StrokeDash = new List<float>() { 15.0f, 70.0f }.AsReadOnly();
        }
    }
}
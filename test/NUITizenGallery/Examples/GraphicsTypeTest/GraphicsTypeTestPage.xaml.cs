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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class GraphicsTypeTestPage : ContentPage
    {
        public GraphicsTypeTestPage()
        {
            InitializeComponent();

            var Manager = GraphicsTypeManager.Instance;

            InfoText.Text = $"Dpi={Manager.Dpi} ScaledDpi={Manager.ScaledDpi} ScalingFactor={Manager.ScalingFactor}";

            PixelRect.Position = new Position(100f, 200f);
            PixelRect.Size = new Size(300f, 100f);
            PixelText.Position2D = new Position2D(100, 310);
            PixelText.WidthSpecification = 300;
            PixelText.HeightSpecification = 90;
            PixelText.Text = "Pixel size 20";
            PixelText.PixelSize = 20f;
            PointText.Position2D = new Position2D(100, 410);
            PointText.WidthSpecification = 300;
            PointText.HeightSpecification = 90;
            PointText.Text = "Point size 20";
            PointText.PointSize = 20f;

            DpRect.Position = new Position(100f, 200f).DpToPx();
            DpRect.Size = new Size(300f, 100f).DpToPx();
            DpPixelText.Position2D = new Position2D(100, 310).DpToPx();
            DpPixelText.WidthSpecification = 300.DpToPx();
            DpPixelText.HeightSpecification = 90.DpToPx();
            DpPixelText.Text = $"Dp Pixel Size {20f.DpToPx()}";
            DpPixelText.PixelSize = 20f.DpToPx();
            DpPointText.Position2D = new Position2D(100, 410).DpToPx();
            DpPointText.WidthSpecification = 300.DpToPx();
            DpPointText.HeightSpecification = 90.DpToPx();
            DpPointText.Text = $"Dp Point Size {20f.DpToPt()}";

            SpRect.Position = new Position(100f, 200f).SpToPx();
            SpRect.Size = new Size(300f, 100f).SpToPx();
            SpPixelText.Position2D = new Position2D(100, 310).SpToPx();
            SpPixelText.WidthSpecification = 300.SpToPx();
            SpPixelText.HeightSpecification = 90.SpToPx();
            SpPixelText.Text = $"Sp Pixel Size {20f.SpToPx()}";
            SpPointText.Position2D = new Position2D(100, 410).SpToPx();
            SpPointText.WidthSpecification = 300.SpToPx();
            SpPointText.HeightSpecification = 90.SpToPx();
            SpPointText.Text = $"Sp Point Size {20f.SpToPt()}";
            SpPointText.PointSize = 20f.SpToPt();
        }
    }
}

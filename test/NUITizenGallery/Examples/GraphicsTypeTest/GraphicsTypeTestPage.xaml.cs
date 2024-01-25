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
            PixelText.HeightSpecification = 100;
            PixelText.Text = "Pixel size 100";
            PixelText.PointSize = 20f;

            DpRect.Position = new Position(100f, 200f).DpToPx();
            DpRect.Size = new Size(300f, 100f).DpToPx();
            DpText.Position2D = new Position2D(100, 310).DpToPx();
            DpText.WidthSpecification = 300.DpToPx();
            DpText.HeightSpecification = 100.DpToPx();
            DpText.Text = $"Dp size {100f.DpToPx()}";
            DpText.PointSize = 20f.DpToPt();

            SpRect.Position = new Position(100f, 200f).SpToPx();
            SpRect.Size = new Size(300f, 100f).SpToPx();
            SpText.Position2D = new Position2D(100, 310).SpToPx();
            SpText.WidthSpecification = 300.SpToPx();
            SpText.HeightSpecification = 100.SpToPx();
            SpText.Text = $"Sp size {100f.SpToPx()}";
            SpText.PointSize = 20f.SpToPt();
        }
    }
}

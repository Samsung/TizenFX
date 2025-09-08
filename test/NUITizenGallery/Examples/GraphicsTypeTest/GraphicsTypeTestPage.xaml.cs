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
            DpText.WidthSpecification = 300.Dp();
            DpText.HeightSpecification = 100.Dp();
            DpText.Text = $"Dp size {100f.Dp()}";
            DpText.PointSize = 20f.DpToPt();

            SdpRect.Position = new Position(100f, 200f).SdpToPx();
            SdpRect.Size = new Size(300f, 100f).SdpToPx();
            SdpText.Position2D = new Position2D(100, 310).SdpToPx();
            SdpText.WidthSpecification = 300.Sdp();
            SdpText.HeightSpecification = 100.Sdp();
            SdpText.Text = $"Sp size {100f.Sdp()}";
            SdpText.PointSize = 20f.SdpToPt();
        }
    }
}

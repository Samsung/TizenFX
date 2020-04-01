/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// Describes Round Button in OneUI_Watch2.X
    /// </summary>
    internal class RoundButtonStyle : ButtonStyle
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RoundButtonStyle() : base()
        {
            Size = new Size(200, 200);
            CornerRadius = 100;
            BackgroundColor = new Color(0.3f, 0.3f, 0.3f, 0.5f);
            PositionUsesPivotPoint = true;
            IconRelativeOrientation = Button.IconOrientation.Top;
            Text = new TextLabelStyle
            {
                FontFamily = "SamsungOne 700",
                PixelSize = 18,
                TextColor = new Selector<Color>
                {
                    Normal = new Color(1, 1, 1, 0.70f),
                    Pressed = new Color(1, 1, 1, 0.60f),
                    Disabled = new Color(1, 1, 1, 0.40f),
                },
            };
            TextPadding = new Extents(0, 0, 0, 40);
            Icon = new ImageViewStyle
            {
                WidthResizePolicy = ResizePolicyType.SizeRelativeToParent,
                HeightResizePolicy = ResizePolicyType.SizeRelativeToParent,
                SizeModeFactor = new Vector3(0.35f, 0.35f, 0.35f),
                Opacity = new Selector<float?>
                {
                    Normal = 0.7f,
                    Pressed = 0.5f
                }
            };
            IconPadding = new Extents(0, 0, 65, 0);
        }
    }
}

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
    /// Describes Basic Button in OneUI_Watch2.X
    /// </summary>
    internal class BasicButtonStyle : ButtonStyle
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BasicButtonStyle() : base()
        {
            Size = new Size(210, 72);
            CornerRadius = 36;
            BackgroundColor = new Selector<Color>
            {
                Normal = new Color(0, 42f/255f, 77f/255f, 0.85f),
                Pressed = new Color(0, 70f/255f, 128f/255f, 0.85f),
                Disabled = new Color(61f/255f, 61f/255f, 61f/255f, 0.85f),
            };
            Text = new TextLabelStyle
            {
                FontFamily = "SamsungOne 700",
                PixelSize = 28,
                TextColor = new Selector<Color>
                {
                    Normal = new Color(56f/255f, 164f/255f, 252f/255f, 1),
                    Pressed = new Color(56f/255f, 164f/255f, 252f/255f, 1),
                    Disabled = new Color(1, 1, 1, 0.35f),
                },
                Padding = new Extents(20, 20, 0, 0),
            };
        }
    }
}

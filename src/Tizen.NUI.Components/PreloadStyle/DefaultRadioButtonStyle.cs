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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The default RadioButton style
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DefaultRadioButtonStyle : StyleBase
    {
        /// <summary>
        /// Return default RadioButton style
        /// </summary>
        internal protected override ViewStyle GetAttributes()
        {
            ButtonStyle style = new ButtonStyle
            {
                Size = new Size(30, 30),
                Icon = new ImageViewStyle
                {
                    WidthResizePolicy = ResizePolicyType.DimensionDependency,
                    HeightResizePolicy = ResizePolicyType.SizeRelativeToParent,
                    SizeModeFactor = new Vector3(1, 1, 1),
                    Opacity = new Selector<float?>
                    {
                        Normal = 1.0f,
                        Selected = 1.0f,
                        Disabled = 0.4f,
                        DisabledSelected = 0.4f
                    },
                    BackgroundImage = new Selector<string>
                    {
                        Normal = DefaultStyle.GetResourcePath("nui_component_default_radiobutton_n.png"),
                        Pressed = DefaultStyle.GetResourcePath("nui_component_default_radiobutton_p.png"),
                        Selected = DefaultStyle.GetResourcePath("nui_component_default_radiobutton_s.png"),
                        Disabled = DefaultStyle.GetResourcePath("nui_component_default_radiobutton_n.png"),
                        DisabledSelected = DefaultStyle.GetResourcePath("nui_component_default_radiobutton_s.png"),
                    }
                },
                Text = new TextLabelStyle
                {
                    PointSize = new Selector<float?> { All = DefaultStyle.PointSizeNormal },
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextColor = new Selector<Color>
                    {
                        Normal = new Color(0.22f, 0.22f, 0.22f, 1),
                        Pressed = new Color(0.11f, 0.11f, 0.11f, 1),
                        Disabled = new Color(0.66f, 0.66f, 0.66f, 1)
                    }
                }
            };
            return style;
        }
    }
}

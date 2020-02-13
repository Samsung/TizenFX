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
    /// The default DropDown style
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DefaultDropDownStyle : StyleBase
    {
        /// <summary>
        /// Return default DropDown style
        /// </summary>
        internal protected override ViewStyle GetAttributes()
        {
            DropDownStyle style = new DropDownStyle
            {
                Position = new Position(50, 50),
                // WidthResizePolicy = ResizePolicyType.FitToChildren,
                // HeightResizePolicy = ResizePolicyType.FitToChildren,
                // HeaderText = new TextLabelStyle
                // {
                //     Text = new Selector<string> { All = "TitleArea" },
                //     PointSize = new Selector<float?> { All = 28 },
                //     TextColor = new Selector<Color> { All = new Color(0, 0, 0, 1) },
                //     FontFamily = "SamsungOneUI 500C",
                // },
                // BackgroundColor = new Selector<Color> { All = new Color(1, 1, 1, 1) },

                Button = new ButtonStyle
                {
                    ParentOrigin = ParentOrigin.TopLeft,
                    PivotPoint = PivotPoint.TopLeft,
                    BackgroundImage = new Selector<string>
                    {
                        Normal = DefaultStyle.GetResourcePath("nui_component_default_checkbox_bg_n.png"),
                        Pressed = DefaultStyle.GetResourcePath("nui_component_default_checkbox_bg_p.png")
                    },
                    BackgroundImageBorder = (Rectangle)6,
                    Text = new TextLabelStyle
                    {
                        Text = "Select an item",
                        PointSize = DefaultStyle.PointSizeNormal,
                        TextColor = Color.Black,
                    },
                    Icon = new ImageViewStyle
                    {
                        Size = new Size(28, 28),
                        ResourceUrl = DefaultStyle.GetResourcePath("nui_component_default_dropdown_button_icon.png"),
                    },
                    IconRelativeOrientation = Button.IconOrientation.Right,
                    IconPadding = 6,
                },
                ListBackgroundImage = new ImageViewStyle
                {
                    ResourceUrl = DefaultStyle.GetResourcePath("nui_component_default_dropdown_list_bg.png"),
                    Border = (Rectangle)6,
                    Size = new Size(280, 360),
                },
                SpaceBetweenButtonTextAndIcon = 10,
                ListPadding = 5,
            };
            return style;
        }
    }

    /// <summary>
    /// The default DropDownItem style
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DefaultDropDownItemStyle : StyleBase
    {
        /// <summary>
        /// Return default DropDownItem style
        /// </summary>
        internal protected override ViewStyle GetAttributes()
        {
            DropDownItemStyle style = new DropDownItemStyle
            {
                Size = new Size(360, 50),
                BackgroundColor = new Selector<Color>
                {
                    Pressed = new Color(0.05f, 0.63f, 0.9f, 1),
                    Selected = new Color(0.8f, 0.8f, 0.8f, 1),
                    Normal = new Color(1, 1, 1, 1),
                },
                Text = new TextLabelStyle
                {
                    PointSize = DefaultStyle.PointSizeNormal,
                    Position = new Position(28, 0),
                    Text = "List item",
                },
            };
            return style;
        }
    }
}

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
    /// Interface that includes styles for all components for a default theme
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class DefaultTheme : Theme
    {
        internal static Theme Instance { get; } = new DefaultTheme();

        protected DefaultTheme() : base()
        {
        }

        protected override ButtonStyle GetButtonStyle()
        {
            return new ButtonStyle
            {
                Size = new Size(100, 45),
                BackgroundColor = new Selector<Color>
                {
                    Normal = new Color(0.88f, 0.88f, 0.88f, 1),
                    Pressed = new Color(0.77f, 0.77f, 0.77f, 1),
                    Disabled = new Color(0.88f, 0.88f, 0.88f, 1)
                },
                Text = new TextLabelStyle
                {
                    PointSize = new Selector<float?> { All = StyleManager.PointSizeNormal },
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextColor = new Selector<Color>
                    {
                        Normal = new Color(0.22f, 0.22f, 0.22f, 1),
                        Pressed = new Color(0.11f, 0.11f, 0.11f, 1),
                        Disabled = new Color(0.66f, 0.66f, 0.66f, 1)
                    },
                    Text = "Button",
                }
            };
        }

        protected override ButtonStyle GetCheckBoxStyle()
        {
            return new ButtonStyle
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
                        Normal = StyleManager.GetFrameworkResourcePath("nui_component_default_checkbox_bg_n.png"),
                        Pressed = StyleManager.GetFrameworkResourcePath("nui_component_default_checkbox_bg_p.png"),
                        Selected = StyleManager.GetFrameworkResourcePath("nui_component_default_checkbox_bg_p.png"),
                        Disabled = StyleManager.GetFrameworkResourcePath("nui_component_default_checkbox_bg_n.png"),
                        DisabledSelected = StyleManager.GetFrameworkResourcePath("nui_component_default_checkbox_bg_p.png"),
                    },
                    ResourceUrl = new Selector<string>
                    {
                        Normal = "",
                        Pressed = "",
                        Selected = StyleManager.GetFrameworkResourcePath("nui_component_default_checkbox_s.png"),
                        Disabled = "",
                        DisabledSelected = StyleManager.GetFrameworkResourcePath("nui_component_default_checkbox_s.png"),
                    }
                },
                Text = new TextLabelStyle
                {
                    PointSize = new Selector<float?> { All = StyleManager.PointSizeNormal },
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
        }

        protected override DropDownStyle GetDropDownStyle()
        {
            return new DropDownStyle
            {
                Position = new Position(50, 50),
                Button = new ButtonStyle
                {
                    ParentOrigin = ParentOrigin.TopLeft,
                    PivotPoint = PivotPoint.TopLeft,
                    BackgroundImage = new Selector<string>
                    {
                        Normal = StyleManager.GetFrameworkResourcePath("nui_component_default_checkbox_bg_n.png"),
                        Pressed = StyleManager.GetFrameworkResourcePath("nui_component_default_checkbox_bg_p.png")
                    },
                    BackgroundImageBorder = (Rectangle)6,
                    Text = new TextLabelStyle
                    {
                        Text = "Select an item",
                        PointSize = StyleManager.PointSizeNormal,
                        TextColor = Color.Black,
                    },
                    Icon = new ImageViewStyle
                    {
                        Size = new Size(28, 28),
                        ResourceUrl = StyleManager.GetFrameworkResourcePath("nui_component_default_dropdown_button_icon.png"),
                    },
                    IconRelativeOrientation = Button.IconOrientation.Right,
                    IconPadding = 6,
                },
                ListBackgroundImage = new ImageViewStyle
                {
                    ResourceUrl = StyleManager.GetFrameworkResourcePath("nui_component_default_dropdown_list_bg.png"),
                    Border = (Rectangle)6,
                    Size = new Size(280, 360),
                },
                SpaceBetweenButtonTextAndIcon = 10,
                ListPadding = 5,
            };
        }

        protected override DropDownItemStyle GetDropDownItemStyle()
        {
            return new DropDownItemStyle
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
                    PointSize = StyleManager.PointSizeNormal,
                    Position = new Position(28, 0),
                    Text = "List item",
                },
            };
        }

        protected override PopupStyle GetPopupStyle()
        {
            return new PopupStyle
            {
                Size = new Size(500, 280),
                BackgroundColor = new Color(0.9f, 0.9f, 0.9f, 1),
                ImageShadow = new ImageShadow
                {
                    Url = StyleManager.GetFrameworkResourcePath("nui_component_default_popup_shadow.png"),
                    Border = new Rectangle(24, 24, 24, 24),
                    Offset = new Vector2(-24, -24),
                    Extents = new Vector2(48, 48),
                },
                Title = new TextLabelStyle
                {
                    PointSize = 16,
                    TextColor = Color.Black,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Padding = 20,
                    Text = "Title",
                },
                Buttons = new ButtonStyle
                {
                    Size = new Size(0, 80),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                    BackgroundColor = new Selector<Color>
                    {
                        Normal = new Color(1, 1, 1, 1),
                        Pressed = new Color(1, 1, 1, 0.5f),
                    },
                    Overlay = new ImageViewStyle
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                        PivotPoint = Tizen.NUI.PivotPoint.Center,
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                        BackgroundColor = new Selector<Color>
                        {
                            Normal = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                            Pressed = new Color(0.0f, 0.0f, 0.0f, 0.1f),
                            Selected = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                        }
                    },
                    Text = new TextLabelStyle
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                        PivotPoint = Tizen.NUI.PivotPoint.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        TextColor = new Color(0.05f, 0.63f, 0.9f, 1)
                    },
                },
            };
        }

        protected override ProgressStyle GetProgressStyle()
        {
            return new ProgressStyle
            {
                Size = new Size(200, 5),
                Track = new ImageViewStyle
                {
                    BackgroundColor = new Color(0, 0, 0, 0.1f),
                },
                Buffer = new ImageViewStyle
                {
                    BackgroundColor = new Color(0.05f, 0.63f, 0.9f, 0.3f)
                },
                Progress = new ImageViewStyle
                {
                    BackgroundColor = new Color(0.05f, 0.63f, 0.9f, 1)
                },
            };
        }

        protected override ButtonStyle GetRadioButtonStyle()
        {
            return new ButtonStyle
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
                        Normal = StyleManager.GetFrameworkResourcePath("nui_component_default_radiobutton_n.png"),
                        Pressed = StyleManager.GetFrameworkResourcePath("nui_component_default_radiobutton_p.png"),
                        Selected = StyleManager.GetFrameworkResourcePath("nui_component_default_radiobutton_s.png"),
                        Disabled = StyleManager.GetFrameworkResourcePath("nui_component_default_radiobutton_n.png"),
                        DisabledSelected = StyleManager.GetFrameworkResourcePath("nui_component_default_radiobutton_s.png"),
                    }
                },
                Text = new TextLabelStyle
                {
                    PointSize = new Selector<float?> { All = StyleManager.PointSizeNormal },
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
        }

        protected override SliderStyle GetSliderStyle()
        {
            return new SliderStyle
            {
                Size = new Size(200, 50),
                TrackThickness = 5,
                Track = new ImageViewStyle
                {
                    BackgroundColor = new Color(0, 0, 0, 0.1f),
                },

                Progress = new ImageViewStyle
                {
                    BackgroundColor = new Color(0.05f, 0.63f, 0.9f, 1),
                },

                Thumb = new ImageViewStyle
                {
                    Size = new Size(50, 50),
                    ResourceUrl = StyleManager.GetFrameworkResourcePath("nui_component_default_slider_thumb_n.png"),
                    BackgroundImage = new Selector<string>
                    {
                        Normal = "",
                        Pressed = StyleManager.GetFrameworkResourcePath("nui_component_default_slider_thumb_bg_p.png"),
                    }
                },

            };
        }

        protected override SwitchStyle GetSwitchStyle()
        {
            return new SwitchStyle
            {
                Size = new Size(96, 60),
                Track = new ImageViewStyle
                {
                    Size = new Size(96, 60),
                    ResourceUrl = new Selector<string>
                    {
                        Normal = StyleManager.GetFrameworkResourcePath("nui_component_default_switch_track_n.png"),
                        Selected = StyleManager.GetFrameworkResourcePath("nui_component_default_switch_track_s.png"),
                        Disabled = StyleManager.GetFrameworkResourcePath("nui_component_default_switch_track_d.png"),
                        DisabledSelected = StyleManager.GetFrameworkResourcePath("nui_component_default_switch_track_ds.png"),
                    },
                    Border = new Rectangle(30, 30, 30, 30),
                },
                Thumb = new ImageViewStyle
                {
                    Size = new Size(60, 60),
                    ResourceUrl = new Selector<string>
                    {
                        Normal = StyleManager.GetFrameworkResourcePath("nui_component_default_switch_thumb_n.png"),
                        Selected = StyleManager.GetFrameworkResourcePath("nui_component_default_switch_thumb_n.png"),
                        Disabled = StyleManager.GetFrameworkResourcePath("nui_component_default_switch_thumb_d.png"),
                        DisabledSelected = StyleManager.GetFrameworkResourcePath("nui_component_default_switch_thumb_d.png"),
                    },
                },
                Text = new TextLabelStyle
                {
                    PointSize = new Selector<float?> { All = StyleManager.PointSizeNormal },
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
                },
            };
        }

        protected override TabStyle GetTabStyle()
        {
            return new TabStyle
            {
                BackgroundColor = Color.Yellow,
                Size = new Size(480, 80),
                UnderLine = new ViewStyle
                {
                    Size = new Size(0, 6),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                    BackgroundColor = new Color(0.05f, 0.63f, 0.9f, 1),
                },
                Text = new TextLabelStyle
                {
                    PointSize = StyleManager.PointSizeTitle,
                    TextColor = new Selector<Color>
                    {
                        Normal = Color.Black,
                        Selected = new Color(0.05f, 0.63f, 0.9f, 1),
                    },
                },
            };
        }

        protected override ToastStyle GetToastStyle()
        {
            return new ToastStyle
            {
                WidthResizePolicy = ResizePolicyType.FitToChildren,
                HeightResizePolicy = ResizePolicyType.FitToChildren,
                BackgroundColor = new Color(0, 0, 0, 0.8f),
                Text = new TextLabelStyle()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                    HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextColor = Color.White,
                    Padding = new Extents(12, 12, 8, 8),
                }
            };
        }

        protected override LoadingStyle GetLoadingStyle()
        {
            return new LoadingStyle
            {
                LoadingSize = new Size(100, 100)
            };
        }

        protected override PaginationStyle GetPaginationStyle()
        {
            return new PaginationStyle
            {
                IndicatorImageURL = new Selector<string>()
                {
                    Normal = StyleManager.GetFrameworkResourcePath("nui_component_default_pagination_normal_dot.png"),
                    Selected = StyleManager.GetFrameworkResourcePath("nui_component_default_pagination_focus_dot.png"),
                },
            };
        }
    }
}

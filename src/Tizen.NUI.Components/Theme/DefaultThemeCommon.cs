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
#if !PROFILE_WEARABLE

using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    // It is a C# version of res/Tizen.NUI.Components_Tizen.NUI.Theme.Common.xaml
    internal partial class DefaultThemeCreator : IThemeCreator
    {
        [SuppressMessage("Microsoft.Reliability", "CA2000: Dispose objects before losing scope", Justification = "The responsibility to dispose the object is transferred to the theme object.")]
        public Theme Create()
        {
            var theme = new Theme()
            {
                Id = Tizen.NUI.DefaultThemeCreator.DefaultId,
                Version = Tizen.NUI.DefaultThemeCreator.DefaultVersion
            };

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Button", new ButtonStyle()
            {
                Size = new Size(339, 96),
                CornerRadiusPolicy = VisualTransformPolicyType.Relative,
                CornerRadius = 0.2916f,
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color(0.039f, 0.055f, 0.29f, 1),
                    Focused = new Color(0, 0.2f, 0.545f, 1),
                    Pressed = new Color(0.106f, 0.412f, 0.792f, 1),
                    Disabled = new Color(0.765f, 0.792f, 0.824f, 1),
                },
                Text = new TextLabelStyle()
                {
                    PixelSize = 32,
                    TextColor = Color.White,
                }
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.CheckBox", new ButtonStyle()
            {
                Size = new Size(30, 30),
                Icon = new ImageViewStyle()
                {
                    Opacity = new Selector<float?>()
                    {
                        Normal = 1.0f,
                        Disabled = 0.4f,
                        Selected = 1.0f,
                    },
                    BackgroundImage = new Selector<string>()
                    {
                        Pressed = FrameworkInformation.ResourcePath + "nui_component_default_checkbox_bg_p.png",
                        Selected = FrameworkInformation.ResourcePath + "nui_component_default_checkbox_bg_p.png",
                        Other = FrameworkInformation.ResourcePath + "nui_component_default_checkbox_bg_n.png",
                    },
                    ResourceUrl = new Selector<string>()
                    {
                        Pressed = "",
                        Selected = FrameworkInformation.ResourcePath + "nui_component_default_checkbox_s.png",
                        Other = "",
                    },
                },
                Text = new TextLabelStyle()
                {
                    PointSize = 12,
                    TextColor = new Selector<Color>()
                    {
                        Normal = new Color(0.22f, 0.22f, 0.22f, 1),
                        Pressed = new Color(0.11f, 0.11f, 0.11f, 1),
                        Disabled = new Color(0.66f, 0.66f, 0.66f, 1),
                    }
                }
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Popup", new PopupStyle()
            {
                Size = new Size(500, 280),
                BackgroundColor = new Color(0.9f, 0.9f, 0.9f, 1),
                ImageShadow = new ImageShadow()
                {
                    Url = FrameworkInformation.ResourcePath + "nui_component_default_popup_shadow.png",
                    Border = new Rectangle(24, 24, 24, 24),
                    Extents = new Vector2(48, 48)
                },
                Title = new TextLabelStyle()
                {
                    PointSize = 16,
                    Padding = new Extents(20, 20, 20, 20),
                },
                Buttons = new ButtonStyle()
                {
                    Size = new Size(0, 80),
                    BackgroundColor = new Selector<Color>()
                    {
                        Normal = new Color(1, 1, 1, 1),
                        Pressed = new Color(1, 1, 1, 0.5f),
                    },
                    Overlay = new ImageViewStyle()
                    {
                        BackgroundColor = new Selector<Color>()
                        {
                            Normal = new Color(1, 1, 1, 1),
                            Pressed = new Color(0, 0, 0, 0.1f),
                            Other = new Color(1, 1, 1, 1),
                        },
                    },
                    Text = new TextLabelStyle()
                    {
                        TextColor = new Color(0.05f, 0.63f, 0.9f, 1),
                    }
                }
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Progress", new ProgressStyle()
            {
                Size = new Size(200, 5),
                Track = new ImageViewStyle()
                {
                    BackgroundColor = new Color(0, 0, 0, 0.1f),
                },
                Buffer = new ImageViewStyle()
                {
                    BackgroundColor = new Color(0.05f, 0.63f, 0.9f, 0.3f),
                },
                Progress = new ImageViewStyle()
                {
                    BackgroundColor = new Color(0.05f, 0.63f, 0.9f, 1),
                },
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.RadioButton", new ButtonStyle()
            {
                Size = new Size(30, 30),
                Icon = new ImageViewStyle()
                {
                    Opacity = new Selector<float?>()
                    {
                        Normal = 1.0f,
                        Disabled = 0.4f,
                        Selected = 1.0f,
                    },
                    BackgroundImage = new Selector<string>()
                    {
                        Pressed = FrameworkInformation.ResourcePath + "nui_component_default_radiobutton_p.png",
                        Selected = FrameworkInformation.ResourcePath + "nui_component_default_radiobutton_s.png",
                        Other = FrameworkInformation.ResourcePath + "nui_component_default_radiobutton_n.png",
                    }
                },
                Text = new TextLabelStyle()
                {
                    PointSize = 12,
                    TextColor = new Selector<Color>()
                    {
                        Normal = new Color(0.22f, 0.22f, 0.22f, 1),
                        Pressed = new Color(0.11f, 0.11f, 0.11f, 1),
                        Disabled = new Color(0.66f, 0.66f, 0.66f, 1),
                    }
                }
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Slider", new SliderStyle()
            {
                Size = new Size(200, 50),
                TrackThickness = 5,
                Track = new ImageViewStyle()
                {
                    BackgroundColor = new Color(0, 0, 0, 0.1f),
                },
                Progress = new ImageViewStyle()
                {
                    BackgroundColor = new Color(0.5f, 0.63f, 0.9f, 1),
                },
                Thumb = new ImageViewStyle()
                {
                    Size = new Size(50, 50),
                    ResourceUrl = FrameworkInformation.ResourcePath + "nui_component_default_slider_thumb_n.png",
                    BackgroundImage = new Selector<string>()
                    {
                        Normal = FrameworkInformation.ResourcePath + "nui_component_default_slider_thumb_bg_p.png",
                        Pressed = FrameworkInformation.ResourcePath + "nui_component_default_slider_thumb_bg_p.png",
                    }
                },
                ValueIndicatorImage = new ImageViewStyle()
                {
                    Size = new Size(83, 54),
                    ResourceUrl = FrameworkInformation.ResourcePath + "nui_component_default_slider_value_indicator.png",
                },
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Switch", new SwitchStyle()
            {
                Size = new Size(96, 60),
                Track = new ImageViewStyle()
                {
                    Size = new Size(96, 60),
                    ResourceUrl = new Selector<string>()
                    {
                        Normal = FrameworkInformation.ResourcePath + "nui_component_default_switch_track_n.png",
                        Selected = FrameworkInformation.ResourcePath + "nui_component_default_switch_track_s.png",
                        Disabled = FrameworkInformation.ResourcePath + "nui_component_default_switch_track_d.png",
                        DisabledSelected = FrameworkInformation.ResourcePath + "nui_component_default_switch_track_ds.png",
                    }
                },
                Thumb = new ImageViewStyle()
                {
                    Size = new Size(60, 60),
                    ResourceUrl = new Selector<string>()
                    {
                        Normal = FrameworkInformation.ResourcePath + "nui_component_default_switch_thumb_n.png",
                        Disabled = FrameworkInformation.ResourcePath + "nui_component_default_switch_thumb_d.png",
                        Selected = FrameworkInformation.ResourcePath + "nui_component_default_switch_thumb_n.png",
                    }
                },
                Text = new TextLabelStyle()
                {
                    PointSize = 12,
                    TextColor = new Selector<Color>()
                    {
                        Normal = new Color(0.22f, 0.22f, 0.22f, 1),
                        Pressed = new Color(0.11f, 0.11f, 0.11f, 1),
                        Disabled = new Color(0.66f, 0.66f, 0.66f, 1),
                    }
                }
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Loading", new LoadingStyle()
            {
                LoadingSize = new Size(100, 100),
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Pagination", new PaginationStyle()
            {
                IndicatorImageUrl = new Selector<string>()
                {
                    Normal = FrameworkInformation.ResourcePath + "nui_component_default_pagination_normal_dot.png",
                    Selected = FrameworkInformation.ResourcePath + "nui_component_default_pagination_focus_dot.png",
                }
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Scrollbar", new ScrollbarStyle()
            {
                TrackThickness = 6,
                ThumbThickness = 6,
                TrackColor = new Color(1, 1, 1, 0.15f),
                ThumbColor = new Color(0.6f, 0.6f, 0.6f, 1.0f),
                TrackPadding = 4
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.RecyclerViewItem", new RecyclerViewItemStyle()
            {
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color(1, 1, 1, 1),
                    Pressed = new Color(0.85f, 0.85f, 0.85f, 1),
                    Disabled = new Color(0.70f, 0.70f, 0.70f, 1),
                    Selected = new Color(0.701f, 0.898f, 0.937f, 1),
                },
            });
            
            theme.AddStyleWithoutClone("Tizen.NUI.Components.DefaultLinearItem", new DefaultLinearItemStyle()
            {
                SizeHeight = 130,
                Padding = new Extents(20, 20, 5, 5),
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color(1, 1, 1, 1),
                    Pressed = new Color(0.85f, 0.85f, 0.85f, 1),
                    Disabled = new Color(0.70f, 0.70f, 0.70f, 1),
                    Selected = new Color(0.701f, 0.898f, 0.937f, 1),
                },
                Label = new TextLabelStyle()
                {
                    PointSize = 10,
                    Ellipsis = true,
                },
                SubLabel = new TextLabelStyle()
                {
                    PointSize = 6,
                    Ellipsis = true,
                },
                Icon = new ViewStyle()
                {
                    Margin = new Extents(0, 20, 0, 0)
                },
                Extra = new ViewStyle()
                {
                    Margin = new Extents(20, 0, 0, 0)
                },
                Seperator = new ViewStyle()
                {
                    Margin = new Extents(5, 5, 0, 0),
                    BackgroundColor = new Color(0.78f, 0.78f, 0.78f, 1),
                },
            });
            theme.AddStyleWithoutClone("Tizen.NUI.Components.DefaultGridItem", new DefaultGridItemStyle()
            {
                Padding = new Extents(5, 5, 5, 5),
                Caption = new TextLabelStyle()
                {
                    PointSize = 9,
                    Ellipsis = true,
                },
                Badge = new ViewStyle()
                {
                    Margin = new Extents(5, 5, 5, 5),
                },
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.DefaultTitleItem", new DefaultTitleItemStyle()
            {
                SizeHeight = 90,
                Padding = new Extents(10, 10, 5, 5),
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color(0.78f, 0.78f, 0.78f, 1),
                },
                Label = new TextLabelStyle()
                {
                    PointSize = 10,
                    Ellipsis = true,
                },
                Icon = new ViewStyle()
                {
                    Margin = new Extents(10, 0, 0, 0)
                },
                Seperator = new ViewStyle()
                {
                    Margin = new Extents(0, 0, 0, 0),
                    BackgroundColor = new Color(0.85f, 0.85f, 0.85f, 1),
                },
            });

            return theme;
        }
    }
}

#endif

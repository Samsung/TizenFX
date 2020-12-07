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
#if !PROFILE_WEARABLE

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    // It is a C# version of res/Tizen.NUI.Components_Tizen.NUI.Theme.Common.xaml
    internal class DefaultThemeCreator : IThemeCreator
    {
        public Theme Create()
        {
            var theme = new Theme() { Id = "Tizen.NUI.Theme.Common" };

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Button", new ButtonStyle()
            {
                Size = new Size(100, 45),
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color(0.88f, 0.88f, 0.88f, 1),
                    Pressed = new Color(0.77f, 0.77f, 0.77f, 1),
                    Disabled = new Color(0.88f, 0.88f, 0.88f, 1),
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
                    BackgroundColor = new Color(0.05f, 0.63f, 0.9f, 1),
                },
                Thumb = new ImageViewStyle()
                {
                    Size = new Size(50, 50),
                    ResourceUrl = FrameworkInformation.ResourcePath + "nui_component_default_slider_thumb_n.png",
                    BackgroundImage = new Selector<string>()
                    {
                        Normal = "",
                        Pressed = FrameworkInformation.ResourcePath + "nui_component_default_slider_thumb_bg_p.png",
                    }
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

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Tab", new TabStyle()
            {
                Size = new Size(480, 80),
                BackgroundColor = Color.Yellow,
                UnderLine = new ViewStyle()
                {
                    Size = new Size(0, 6),
                    BackgroundColor = new Color(0.05f, 0.63f, 0.9f, 1),
                },
                Text = new TextLabelStyle()
                {
                    PointSize = 16,
                    TextColor = new Selector<Color>()
                    {
                        Normal = Color.Black,
                        Selected = new Color(0.05f, 0.63f, 0.9f, 1),
                    }
                }
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Toast", new ToastStyle()
            {
                Size = new Size(480, 80),
                BackgroundColor = new Color(0, 0, 0, 0.8f),
                Text = new TextLabelStyle()
                {
                    Padding = new Extents(12, 12, 8, 8)
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
                ThumbColor = new Color(0.6f, 0.6f, 0.6f, 1),
                TrackPadding = 4
            });

            return theme;
        }
    }
}

#endif

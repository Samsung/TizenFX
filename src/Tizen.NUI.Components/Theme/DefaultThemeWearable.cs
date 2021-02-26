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

#if PROFILE_WEARABLE

using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components.Extension;

namespace Tizen.NUI.Components
{
    // It is a C# version of res/Tizen.NUI.Components_Tizen.NUI.Theme.Wearable.xaml
    internal partial class DefaultThemeCreator : IThemeCreator
    {
        public Theme Create()
        {
            var theme = new Theme()
            {
                Id = Tizen.NUI.DefaultThemeCreator.DefaultId,
                Version = Tizen.NUI.DefaultThemeCreator.DefaultVersion
            };

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

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Button", new ButtonStyle()
            {
                Size = new Size(210, 72),
                CornerRadius = 36,
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color(0, 0.1647f, 0.3019f, 0.85f),
                    Pressed = new Color(0, 0.2475f, 0.5019f, 0.85f),
                    Disabled = new Color(0.2392f, 0.2392f, 0.2392f, 0.85f),
                },
                Opacity = new Selector<float?>()
                {
                    Other = 1.0f,
                    Disabled = 0.3f,
                },
                Text = new TextLabelStyle()
                {
                    FontFamily = "SamsungOne 700",
                    PixelSize = 28,
                    Padding = new Extents(20, 20, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextColor = new Selector<Color>()
                    {
                        Normal = new Color(0.2196f, 0.6131f, 0.9882f, 1),
                        Disabled = new Color(1, 1, 1, 0.35f),
                    }
                }
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.CheckBox", new LottieButtonStyle()
            {
                LottieUrl = FrameworkInformation.ResourcePath + "nui_wearable_checkbox_icon.png",
                PlayRange = new Selector<LottieFrameInfo>()
                {
                    Selected = new LottieFrameInfo(19, 36),
                    Normal = new LottieFrameInfo(0, 18)
                },
                Opacity = new Selector<float?>()
                {
                    Other = 1.0f,
                    Pressed = 0.6f,
                    Disabled = 0.3f,
                },
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.RadioButton", new LottieButtonStyle()
            {
                LottieUrl = FrameworkInformation.ResourcePath + "nui_wearable_radiobutton_icon.png",
                PlayRange = new Selector<LottieFrameInfo>()
                {
                    Selected = new LottieFrameInfo(0, 12),
                    Normal = new LottieFrameInfo(13, 25)
                },
                Opacity = new Selector<float?>()
                {
                    Other = 1.0f,
                    Pressed = 0.6f,
                    Disabled = 0.3f,
                },
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Switch", new LottieSwitchStyle()
            {
                LottieUrl = FrameworkInformation.ResourcePath + "nui_wearable_switch_icon.png",
                PlayRange = new Selector<LottieFrameInfo>()
                {
                    Selected = new LottieFrameInfo(0, 18),
                    Normal = new LottieFrameInfo(19, 36)
                },
                Opacity = new Selector<float?>()
                {
                    Other = 1.0f,
                    Pressed = 0.6f,
                    Disabled = 0.3f,
                },
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Loading", new LoadingStyle()
            {
                LoadingSize = new Size(360, 360),
            });

            return theme;
        }
    }
}

#endif

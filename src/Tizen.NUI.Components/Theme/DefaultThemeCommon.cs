/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
        /// <summary>
        /// The base theme description.
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2000: Dispose objects before losing scope", Justification = "The responsibility to dispose the object is transferred to the theme object.")]
        public Theme Create()
        {
            var theme = new Theme()
            {
                Id = Tizen.NUI.DefaultThemeCreator.DefaultId,
                Version = Tizen.NUI.DefaultThemeCreator.DefaultVersion
            };

            // Button base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Button", new ButtonStyle()
            {
                Padding = new Extents(32, 32, 8, 8),
                ItemSpacing = new Size2D(8, 8),
                CornerRadius = 12.0f,
                ItemHorizontalAlignment = HorizontalAlignment.Center,
                ItemVerticalAlignment = VerticalAlignment.Center,
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color(1.0f, 0.384f, 0.0f, 1),
                    Pressed = new Color(0.85f, 0.325f, 0.0f, 1),
                    Focused = new Color(1.0f, 0.827f, 0.624f, 1),
                    Selected = new Color(0.624f, 0.239f, 0.0f, 1),
                    Disabled = new Color(0.792f, 0.792f, 0.792f, 1),
                },
                Text = new TextLabelStyle()
                {
                    TextColor = new Color("#FDFDFD"),
                    PixelSize = 24,
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                }
            });

            // Outlined Button style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Button.Outlined", new ButtonStyle()
            {
                Padding = new Extents(32, 32, 8, 8),
                ItemSpacing = new Size2D(8, 8),
                CornerRadius = 12.0f,
                BorderlineWidth = 2.0f,
                BorderlineColorSelector = new Selector<Color>()
                {
                    Normal = new Color("#FF6200"),
                    Pressed = new Color("#FFA166"),
                    Focused = new Color("#FF7119"),
                    Selected = new Color("#FF8133"),
                    Disabled = new Color("#CACACA"),
                },
                ItemHorizontalAlignment = HorizontalAlignment.Center,
                ItemVerticalAlignment = VerticalAlignment.Center,
                BackgroundColor = Color.Transparent,
                Text = new TextLabelStyle()
                {
                    TextColor = new Selector<Color>()
                    {
                        Normal = new Color("#FF6200"),
                        Pressed = new Color("#FFA166"),
                        Focused = new Color("#FF7119"),
                        Selected = new Color("#FF8133"),
                        Disabled = new Color("#CACACA"),
                    },
                    PixelSize = 24,
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                }
            });

            // TextOnly Button style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Button.TextOnly", new ButtonStyle()
            {
                Padding = new Extents(32, 32, 8, 8),
                ItemHorizontalAlignment = HorizontalAlignment.Center,
                ItemVerticalAlignment = VerticalAlignment.Center,
                BackgroundColor = Color.Transparent,
                Text = new TextLabelStyle()
                {
                    TextColor = new Selector<Color>()
                    {
                        Normal = new Color("#FF6200"),
                        Pressed = new Color("#FFA166"),
                        Focused = new Color("#FF7119"),
                        Selected = new Color("#FF8133"),
                        Disabled = new Color("#CACACA"),
                    },
                    PixelSize = 24,
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                }
            });

            // CheckBox base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.CheckBox", new ButtonStyle()
            {
                Padding = new Extents(8, 8, 8, 8),
                ItemSpacing = new Size2D(16, 16),
                ItemHorizontalAlignment = HorizontalAlignment.Center,
                ItemVerticalAlignment = VerticalAlignment.Center,
                Icon = new ImageViewStyle()
                {
                    Size = new Size(32, 32),
                    ResourceUrl = new Selector<string>()
                    {
                        Normal = FrameworkInformation.ResourcePath + "IoT_check_off.png",
                        Pressed = FrameworkInformation.ResourcePath + "IoT_check_off_p.png",
                        Disabled = FrameworkInformation.ResourcePath + "IoT_check_off_d.png",
                        Focused = FrameworkInformation.ResourcePath + "IoT_check_off_f.png",
                        Selected = FrameworkInformation.ResourcePath + "IoT_check_on.png",
                        SelectedPressed = FrameworkInformation.ResourcePath + "IoT_check_on_p.png",
                        SelectedFocused = FrameworkInformation.ResourcePath + "IoT_check_on_f.png",
                        DisabledSelected = FrameworkInformation.ResourcePath + "IoT_check_on_d.png",
                    },
                },
                Text = new TextLabelStyle()
                {
                    TextColor = new Color("#090E21"),
                    PixelSize = 24,
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                }
            });

            // Popup base style
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
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                },
                Buttons = new ButtonStyle()
                {
                    SizeHeight = 80,
                    CornerRadius = 0,
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
                            Other = new Color(1, 1, 1, 0.1f),
                        },
                    },
                    Text = new TextLabelStyle()
                    {
                        TextColor = new Color(0.05f, 0.63f, 0.9f, 1),
                        FontSizeScale = FontSizeScale.UseSystemSetting,
                    }
                }
            });

            // Progress base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Progress", new ProgressStyle()
            {
                Size = new Size(508, 16),
                Track = new ImageViewStyle()
                {
                    CornerRadius = 8.0f,
                    BackgroundColor = new Selector<Color>()
                    {
                        Normal = new Color(0.82f, 0.31f, 0.0f, 0.1f),
                        Disabled = new Color(0.82f, 0.31f, 0.0f, 0.1f),
                    },
                },
                Buffer = new ImageViewStyle()
                {
                    CornerRadius = 8.0f,
                    BackgroundColor = new Color(0.82f, 0.31f, 0.0f, 0.1f),
                },
                Progress = new ImageViewStyle()
                {
                    CornerRadius = 8.0f,
                    BackgroundColor = new Color("#D25000"),
                },
                IndeterminateImageUrl = FrameworkInformation.ResourcePath + "IoT_progress_indeterminate.png",
            });

            // RadioButton base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.RadioButton", new ButtonStyle()
            {
                Padding = new Extents(8, 8, 8, 8),
                ItemSpacing = new Size2D(16, 16),
                ItemHorizontalAlignment = HorizontalAlignment.Center,
                ItemVerticalAlignment = VerticalAlignment.Center,
                Icon = new ImageViewStyle()
                {
                    Size = new Size(32, 32),
                    ResourceUrl = new Selector<string>()
                    {
                        Normal = FrameworkInformation.ResourcePath + "IoT_radiobutton_off.png",
                        Pressed = FrameworkInformation.ResourcePath + "IoT_radiobutton_off_p.png",
                        Disabled = FrameworkInformation.ResourcePath + "IoT_radiobutton_off_d.png",
                        Focused = FrameworkInformation.ResourcePath + "IoT_radiobutton_off_f.png",
                        Selected = FrameworkInformation.ResourcePath + "IoT_radiobutton_on.png",
                        SelectedPressed = FrameworkInformation.ResourcePath + "IoT_radiobutton_on_p.png",
                        SelectedFocused = FrameworkInformation.ResourcePath + "IoT_radiobutton_on_f.png",
                        DisabledSelected = FrameworkInformation.ResourcePath + "IoT_radiobutton_on_d.png",
                    },
                },
                Text = new TextLabelStyle()
                {
                    TextColor = new Color("#090E21"),
                    PixelSize = 24,
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                }
            });

            // Slider base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Slider", new SliderStyle()
            {
                Size = new Size(850, 50),
                TrackThickness = 8,
                Track = new ImageViewStyle()
                {
                    Size = new Size(800, 8),
                    CornerRadius = 4.0f,
                    BackgroundColor = new Selector<Color>()
                    {
                        Normal = new Color(1.0f, 0.37f, 0.0f, 0.1f),
                        Disabled = new Color(1.0f, 0.37f, 0.0f, 0.1f),
                    },
                },
                Progress = new ImageViewStyle()
                {
                    Size = new Size(800, 8),
                    CornerRadius = 4.0f,
                    BackgroundColor = new Selector<Color>()
                    {
                        Normal = new Color("#FF6200"),
                        Disabled = new Color("#CACACA"),
                    },
                },
                Thumb = new ImageViewStyle()
                {
                    WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                    HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                    ResourceUrl = new Selector<string>()
                    {
                        Normal = FrameworkInformation.ResourcePath + "IoT_slider_handler_normal.png",
                        Pressed = FrameworkInformation.ResourcePath + "IoT_slider_handler_pressed.png",
                        Focused = FrameworkInformation.ResourcePath + "IoT_slider_handler_pressed.png",
                        Disabled = FrameworkInformation.ResourcePath + "IoT_slider_handler_disabled.png",
                    },
                },
                ValueIndicatorImage = new ImageViewStyle()
                {
                    SizeHeight = 40,
                    WidthResizePolicy = ResizePolicyType.FitToChildren,
                    Margin = new Extents(8, 8, 0, 0),
                    BorderlineWidth = 1.0f,
                    BorderlineColor = new Color("#FF6200"),
                    BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.0f),
                    CornerRadius = 12.0f,
                },
                ValueIndicatorText = new TextLabelStyle()
                {
                    SizeHeight = 24,
                    WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                    PixelSize = 16,
                    TextColor = new Color("#FF6200"),
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                }
            });

            // Switch base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Switch", new SwitchStyle()
            {
                ItemSpacing = new Size2D(16, 16),
                ItemHorizontalAlignment = HorizontalAlignment.Begin,
                ItemVerticalAlignment = VerticalAlignment.Center,
                Track = new ImageViewStyle()
                {
                    Size = new Size(84, 44),
                    ResourceUrl = new Selector<string>()
                    {
                        Normal = FrameworkInformation.ResourcePath + "IoT_switch_track_off.png",
                        Pressed = FrameworkInformation.ResourcePath + "IoT_switch_track_off_p.png",
                        Disabled = FrameworkInformation.ResourcePath + "IoT_switch_track_off_d.png",
                        Focused = FrameworkInformation.ResourcePath + "IoT_switch_track_off_f.png",
                        Selected = FrameworkInformation.ResourcePath + "IoT_switch_track_on.png",
                        SelectedPressed = FrameworkInformation.ResourcePath + "IoT_switch_track_on_p.png",
                        SelectedFocused = FrameworkInformation.ResourcePath + "IoT_switch_track_on_f.png",
                        DisabledSelected = FrameworkInformation.ResourcePath + "IoT_switch_track_on_d.png",
                    },
                },
                Thumb = new ImageViewStyle()
                {
                    Size = new Size(44, 44),
                    ResourceUrl = new Selector<string>()
                    {
                        Normal = FrameworkInformation.ResourcePath + "IoT_switch_thumb.png",
                        Disabled = FrameworkInformation.ResourcePath + "IoT_switch_thumb_d.png",
                        Selected = FrameworkInformation.ResourcePath + "IoT_switch_thumb_s.png",
                        SelectedPressed = FrameworkInformation.ResourcePath + "IoT_switch_thumb_sp.png",
                        SelectedFocused = FrameworkInformation.ResourcePath + "IoT_switch_thumb_sf.png",
                    }
                },
                Text = new TextLabelStyle()
                {
                    TextColor = new Color("#090E21"),
                    PixelSize = 24,
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                }
            });

            // Loading base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Loading", new LoadingStyle()
            {
                LoadingSize = new Size(200, 200),
            });

            // Pagination base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Pagination", new PaginationStyle()
            {
                Size = new Size(450, 24),
                IndicatorImageUrl = new Selector<string>()
                {
                    Normal = FrameworkInformation.ResourcePath + "nui_component_default_pagination_normal_dot.png",
                    Selected = FrameworkInformation.ResourcePath + "nui_component_default_pagination_focus_dot.png",
                },
                IndicatorSize = new Size(64, 8),
                IndicatorSpacing = 16,
            });

            // Scrollbar base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Scrollbar", new ScrollbarStyle()
            {
                TrackThickness = 8,
                ThumbThickness = 8,
                TrackColor = new Color(0f, 0f, 0f, 0f),
                ThumbColor = new Color("#FFFEFE"),
                TrackPadding = 4,
                //7.0 UX no require image resource.
                Thumb = new ImageViewStyle()
                {
                    CornerRadius = 4.0f,
                    BoxShadow = new Shadow(8.0f, new Color(0.0f, 0.0f, 0.0f, 0.16f), new Vector2(0.0f, 2.0f)),
                }
                //ThumbVerticalImageUrl = FrameworkInformation.ResourcePath + "nui_component_default_scroll_vbar.#.png",
                //ThumbHorizontalImageUrl = FrameworkInformation.ResourcePath + "nui_component_default_scroll_hbar.#.png",
            });

            // LinearLayouter base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.LinearLayouter", new ViewStyle()
            {
                Padding = new Extents(0, 0, 0, 0)
            });

            // GridLayouter base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.GridLayouter", new ViewStyle()
            {
                Padding = new Extents(0, 0, 0, 0),
            });

            // ItemsLayouter base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.ItemsLayouter", new ViewStyle()
            {
                Padding = new Extents(0, 0, 0, 0),
            });

            // RecyclerViewItem base style
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

            // DefaultLinearItem base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.DefaultLinearItem", new DefaultLinearItemStyle()
            {
                SizeHeight = 64,
                Padding = new Extents(16, 16, 0, 0),
                Margin = new Extents(0, 0, 0, 0),
                Label = new TextLabelStyle()
                {
                    PixelSize = 24,
                    Ellipsis = true,
                    FontFamily = "SamsungOneUI600",
                    TextColor = new Selector<Color>()
                    {
                        Normal = new Color("#090E21"),
                        Pressed = new Color("#FF6200"),
                        Disabled = new Color("#CACACA"),
                        Selected = new Color("#FF6200"),
                    },
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                    ThemeChangeSensitive = false
                },
                SubLabel = new TextLabelStyle()
                {
                    PixelSize = 20,
                    Ellipsis = true,
                    FontFamily = "SamsungOneUI400",
                    TextColor = new Selector<Color>()
                    {
                        Normal = new Color("#090E21"),
                        Pressed = new Color("#FF6200"),
                        Disabled = new Color("#CACACA"),
                        Selected = new Color("#FF6200"),
                    },
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                    ThemeChangeSensitive = false
                },
                Icon = new ViewStyle()
                {
                    Margin = new Extents(0, 16, 0, 0)
                },
                Extra = new ViewStyle()
                {
                    Margin = new Extents(16, 0, 0, 0)
                },
            });

            // DefaultGridItem base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.DefaultGridItem", new DefaultGridItemStyle()
            {
                ClippingMode = ClippingModeType.ClipChildren,
                Padding = new Extents(0, 0, 0, 0),
                Margin = new Extents(5, 5, 5, 5),
                CornerRadius = 12.0f,
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color("#FAFAFA"),
                    Pressed = new Color(1f, 0.38f, 0, 0.2f),
                    Disabled = new Color("#FAFAFA"),
                    Selected = new Color(1f, 0.38f, 0, 0.2f),
                },
                Image = new ImageViewStyle()
                {
                    //FIXME: Clip mode is not working on CornerRadius.
                    CornerRadius = 12.0f,
                    ClippingMode = ClippingModeType.ClipChildren,
                },
                Label = new TextLabelStyle()
                {
                    SizeHeight = 24,
                    PixelSize = 16,
                    FontFamily = "SamsungOneUI400",
                    LineWrapMode = LineWrapMode.Character,
                    TextColor = new Selector<Color>()
                    {
                        Normal = new Color("#090E21"),
                        Pressed = new Color("#FF6200"),
                        Disabled = new Color("#CACACA"),
                        Selected = new Color("#FF6200"),
                    },
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                    ThemeChangeSensitive = false
                },
                Badge = new ViewStyle()
                {
                    Margin = new Extents(0, 0, 0, 0),
                },
                BoxShadow = new Shadow(12.0f, new Color(0.0f, 0.0f, 0.0f, 0.16f), new Vector2(0.0f, 4.0f)),
            });

            // DefaultTitleItem base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.DefaultTitleItem", new DefaultTitleItemStyle()
            {
                SizeHeight = 48,
                Padding = new Extents(20, 20, 0, 0),
                Margin = new Extents(0, 0, 0, 0),
                BackgroundColor = Color.Transparent,
                Label = new TextLabelStyle()
                {
                    PixelSize = 24,
                    Ellipsis = true,
                    FontFamily = "SamsungOneUI400",
                    TextColor = new Color("#090E217F"),
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                    ThemeChangeSensitive = false
                },
                Icon = new ViewStyle()
                {
                    Margin = new Extents(24, 0, 0, 0)
                },
                Seperator = new ViewStyle()
                {
                    Margin = new Extents(0, 0, 0, 0),
                    BackgroundColor = new Color(0, 0, 0, 0),
                },
            });

            // ContentPage base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.ContentPage", new ViewStyle()
            {
                BackgroundColor = new Color("#FAFAFA"),
                CornerRadius = new Vector4(24.0f, 24.0f, 24.0f ,24.0f),
                CornerRadiusPolicy = VisualTransformPolicyType.Absolute,
                BoxShadow = new Shadow(8.0f, new Color(0.0f, 0.0f, 0.0f, 0.16f), new Vector2(0.0f, 2.0f)),
            });

            // AppBar base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.AppBar", new AppBarStyle()
            {
                Size = new Size(-1, 64),
                BackgroundColor = Color.Transparent,
                BackButton = new ButtonStyle()
                {
                    Size = new Size(48, 48),
                    CornerRadius = 0,
                    BackgroundColor = Color.Transparent,
                    Icon = new ImageViewStyle()
                    {
                        Size = new Size(48, 48),
                        ResourceUrl = FrameworkInformation.ResourcePath + "nui_component_default_back_button.png",
                        Color = new Selector<Color>()
                        {
                            Normal = new Color("#17234D"),
                            Focused = new Color("#17234D"),
                            Pressed = new Color("#FF6200"),
                            Disabled = new Color("#CACACA"),
                        },
                    },
                    ThemeChangeSensitive = false
                },
                TitleTextLabel = new TextLabelStyle()
                {
                    PixelSize = 24,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextColor = new Selector<Color>()
                    {
                        Normal = new Color("#17234D"),
                    },
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                    ThemeChangeSensitive = false
                },
                ActionView = new ViewStyle()
                {
                    Size = new Size(48, 64),
                    CornerRadius = 0,
                    BackgroundColor = Color.Transparent,
                },
                ActionButton = new ButtonStyle()
                {
                    Size = new Size(-2, 64),
                    CornerRadius = 0,
                    BackgroundColor = Color.Transparent,
                    Text = new TextLabelStyle()
                    {
                        PixelSize = 24,
                        TextColor = new Selector<Color>()
                        {
                            Normal = new Color("#FF6200"),
                            Focused = new Color("#FF6200"),
                            Pressed = new Color("#D95300"),
                            Disabled = new Color("#CACACA"),
                        },
                        FontSizeScale = FontSizeScale.UseSystemSetting,
                    },
                    Icon = new ImageViewStyle()
                    {
                        Size = new Size(48, 48),
                        Color = new Selector<Color>()
                        {
                            Normal = new Color("#17234D"),
                            Focused = new Color("#17234D"),
                            Pressed = new Color("#FF6200"),
                            Disabled = new Color("#CACACA"),
                        },
                    },
                    ThemeChangeSensitive = false,
                },
                Padding = new Extents(16, 16, 0, 0),
                NavigationPadding = new Extents(0, 8, 0, 0),
                ActionPadding = new Extents(16, 0, 0, 0),
                ActionCellPadding = new Size2D(16, 0),
            });

            // Picker base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Picker", new PickerStyle()
            {
                SizeHeight = 220.0f,
                MinimumSize = new Size(80, -1),
                ItemTextLabel = new TextLabelStyle()
                {
                    PixelSize = 24,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    SizeHeight = 44,
                    TextColor = new Selector<Color>()
                    {
                        Normal = new Color(0.035f, 0.055f, 0.123f, 1.0f),
                    },
                    BackgroundColor = new Color("#FAFAFA"),
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                },
                StartScrollOffset = new Size(0, 0),
            });

            // TabBar base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.TabBar", new ViewStyle()
            {
                Size = new Size(-1, -2),
                Margin = new Extents(16, 16, 0, 0),
                Padding = new Extents(14, 14, 0, 0),
                CornerRadius = new Vector4(12.0f, 12.0f, 12.0f, 12.0f),
                CornerRadiusPolicy = VisualTransformPolicyType.Absolute,
                BoxShadow = new Shadow(8.0f, new Color(0.0f, 0.0f, 0.0f, 0.16f), new Vector2(0.0f, 2.0f)),
                BackgroundColor = new Color("#FAFAFA"),
            });

            // TabButton base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.TabButton", new TabButtonStyle()
            {
                Size = new Size(-1, 72),
                SizeWithIcon = new Size(-1, 116),
                SizeWithIconOnly = new Size(-1, 64),
                MinimumSize = new Size(80, 64),
                Padding = new Extents(24, 24, 16, 16),
                ItemSpacing = new Size2D(10, 10),
                CornerRadius = 0,
                IconSizeWithIconOnly = new Size(32, 32),
                TextSizeWithIcon = 16.0f,
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color("#FAFAFA"),
                    Selected = new Color("#FFE0CC"),
                    Pressed = new Color("#FFCAA8"),
                    Focused = new Color("#FAFAFA"),
                    Disabled = new Color("#FAFAFA"),
                },
                Text = new TextLabelStyle()
                {
                    PixelSize = 24,
                    Size = new Size(-2, -2),
                    TextColor = new Selector<Color>()
                    {
                        Normal = new Color("#090E21"),
                        Selected = new Color("#FF6200"),
                        Pressed = new Color("#FF6200"),
                        Focused = new Color("#FF6200"),
                        Disabled = new Color("#CACACA"),
                    },
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                    ThemeChangeSensitive = false,
                },
                Icon = new ImageViewStyle()
                {
                    Size = new Size(48, 48),
                    Color = new Selector<Color>()
                    {
                        Normal = new Color("#090E21"),
                        Selected = new Color("#FF6200"),
                        Pressed = new Color("#FF6200"),
                        Focused = new Color("#FF6200"),
                        Disabled = new Color("#CACACA"),
                    },
                },
            });

            // NotificationToast base style
            theme.AddStyleWithoutClone("NotificationToast", new TextLabelStyle()
            {
                BackgroundColor = new Color("#FAFAFA"),
                CornerRadius = 12.0f,
                BoxShadow = new Shadow(8.0f, new Color(0.0f, 0.0f, 0.0f, 0.16f), new Vector2(0.0f, 2.0f)),
                TextColor = new Color("#090E21"),
                PixelSize = 24,
                WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                PositionUsesPivotPoint = true,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Extents(16, 16, 16, 16),
                PositionY = 120,
                FontSizeScale = FontSizeScale.UseSystemSetting,
            });

            // AlertDialog base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.AlertDialog", new AlertDialogStyle()
            {
                Size = new Size(-2, -2),
                Padding = new Extents(32, 32, 32, 32),
                ItemSpacing = new Size2D(0, 32),
                BackgroundColor = new Color("#FAFAFA"),
                CornerRadius = 12.0f,
                BoxShadow = new Shadow(8.0f, new Color(0.0f, 0.0f, 0.0f, 0.16f), new Vector2(0.0f, 2.0f)),
                TitleTextLabel = new TextLabelStyle()
                {
                    Size = new Size(626, -2),
                    PixelSize = 24,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextColor = new Color("#090E21"),
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                    ThemeChangeSensitive = false,
                },
                MessageTextLabel = new TextLabelStyle()
                {
                    Size = new Size(626, -2),
                    PixelSize = 24,
                    MultiLine = true,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextColor = new Color("#090E21"),
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                    ThemeChangeSensitive = false,
                },
                ActionContent = new ViewStyle()
                {
                    Size = new Size(626, -2),
                },
            });

            // TimePicker base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.TimePicker", new TimePickerStyle()
            {
                CellPadding = new Size(12, 220),

                Pickers = new PickerStyle()
                {
                    Size = new Size(80, 220),
                    ItemTextLabel = new TextLabelStyle()
                    {
                        PixelSize = 24,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        SizeHeight = 44,
                        TextColor = new Selector<Color>()
                        {
                            Normal = new Color(0.035f, 0.055f, 0.123f, 1.0f),
                        },
                        BackgroundColor = new Color("#FAFAFA"),
                        FontSizeScale = FontSizeScale.UseSystemSetting,
                        ThemeChangeSensitive = false
                    },
                    StartScrollOffset = new Size2D(0, 0),
                }
            });

            // DatePicker base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.DatePicker", new DatePickerStyle()
            {
                CellPadding = new Size(12, 220),

                Pickers = new PickerStyle()
                {
                    Size = new Size(80, 220),
                    ItemTextLabel = new TextLabelStyle()
                    {
                        PixelSize = 24,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        SizeHeight = 44,
                        TextColor = new Selector<Color>()
                        {
                            Normal = new Color(0.035f, 0.055f, 0.123f, 1.0f),
                        },
                        BackgroundColor = new Color("#FAFAFA"),
                        FontSizeScale = FontSizeScale.UseSystemSetting,
                        ThemeChangeSensitive = false
                    },
                    StartScrollOffset = new Size2D(0, 0),
                }
            });

            // Menu base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Menu", new MenuStyle()
            {
                BackgroundColor = Color.Transparent,
                Content = new ViewStyle()
                {
                    BackgroundColor = new Color("#FFFEFE"),
                    CornerRadius = 24.0f,
                    BoxShadow = new Shadow(8.0f, new Color(0.0f, 0.0f, 0.0f, 0.16f), new Vector2(0.0f, 2.0f)),
                    // FIXME: ScrollableBase with LinearLayout's Padding.Start is applied both Start and End.
                    //        ScrollableBase with LinearLayout's Padding.Top is applied both Top and Bottom.
                    Padding = new Extents(32, 0, 16, 0),
                },
            });

            // MenuItem base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.MenuItem", new ButtonStyle()
            {
                Size = new Size(324, -2),
                MinimumSize = new Size2D(0, 64),
                BackgroundColor = new Color("#FFFEFE"),
                CornerRadius = 0,
                // FIXME: ClippingModeType.ClipChildren cannot support anti-aliasing
                //        So not to show left bottom corner of MenuItem, MenuItem.Padding.Start is 0 and Menu.Content.Padding.Start is 32.
                //        (instead of MenuItem.Padding.Start 16 and Menu.Content.Padding.Start is 16)
                Padding = new Extents(0, 0, 24, 24),
                Text = new TextLabelStyle()
                {
                    PixelSize = 24,
                    MultiLine = true,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextColor = new Selector<Color>()
                    {
                        Normal = new Color("#090E21"),
                        Focused = new Color("#FF6200"),
                        Pressed = new Color("#FF6200"),
                        Disabled = new Color("#CACACA"),
                        Selected = new Color("#FF6200"),
                    },
                    FontSizeScale = FontSizeScale.UseSystemSetting,
                    ThemeChangeSensitive = false
                },
                Icon = new ImageViewStyle()
                {
                    Color = new Selector<Color>()
                    {
                        Normal = new Color("#090E21"),
                        Focused = new Color("#FF6200"),
                        Pressed = new Color("#FF6200"),
                        Disabled = new Color("#CACACA"),
                        Selected = new Color("#FF6200"),
                    },
                },
            });

            // AlertDialog base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.DialogPage.Scrim", new ViewStyle()
            {
                BackgroundColor = new Color("#090E21"),
                Opacity = 0.5f,
            });

            return theme;
        }
    }
}

#endif // !PROFILE_WEARABLE

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
                Size = new Size(339, 96),
                CornerRadius = 28.0f,
                ItemHorizontalAlignment = HorizontalAlignment.Center,
                ItemVerticalAlignment = VerticalAlignment.Center,
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color(0.039f, 0.055f, 0.29f, 1),
                    Pressed = new Color(0.106f, 0.412f, 0.792f, 1),
                    Focused = new Color(0, 0.2f, 0.545f, 1),
                    Disabled = new Color(0.765f, 0.792f, 0.824f, 1),
                },
                Text = new TextLabelStyle()
                {
                    TextColor = Color.White,
                    PixelSize = 32,
                }
            });

            // CheckBox base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.CheckBox", new ButtonStyle()
            {
                ItemSpacing = new Size2D(32, 32),
                ItemHorizontalAlignment = HorizontalAlignment.Begin,
                ItemVerticalAlignment = VerticalAlignment.Center,
                Icon = new ImageViewStyle()
                {
                    Size = new Size(36, 36),
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
                    TextColor = new Color("#001447"),
                    PixelSize = 32,
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
                },
                Buttons = new ButtonStyle()
                {
                    Size = new Size(0, 80),
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
                    }
                }
            });

            // Progress base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Progress", new ProgressStyle()
            {
                Size = new Size(200, 25),
                Track = new ImageViewStyle()
                {
                    BorderlineWidth = 0.5f,
                    BorderlineColor = new Color(0.92f, 0.93f, 0.94f, 1.0f),
                    BackgroundColor = new Selector<Color>()
                    {
                        Normal = new Color(1.0f, 1.0f, 1.0f, 0.5f),
                        Disabled = new Color(0.73f, 0.76f, 0.79f, 1),
                    },
                },
                Buffer = new ImageViewStyle()
                {
                    BackgroundColor = new Color(0.05f, 0.63f, 0.9f, 0.3f),
                },
                Progress = new ImageViewStyle()
                {
                    BackgroundColor = new Color(0.03f, 0.05f, 0.29f, 1),
                },
                IndeterminateImageUrl = FrameworkInformation.ResourcePath + "nui_component_default_progress_indeterminate.png",
            });

            // RadioButton base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.RadioButton", new ButtonStyle()
            {
                ItemSpacing = new Size2D(32, 32),
                ItemHorizontalAlignment = HorizontalAlignment.Begin,
                ItemVerticalAlignment = VerticalAlignment.Center,
                Icon = new ImageViewStyle()
                {
                    Size = new Size(36, 36),
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
                    TextColor = new Color("#001447"),
                    PixelSize = 32,
                }
            });

            // Slider base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Slider", new SliderStyle()
            {
                Size = new Size(200, 50),
                TrackThickness = 8,
                Track = new ImageViewStyle()
                {
                    Size = new Size(100, 8),
                    BorderlineWidth = 0.5f,
                    BorderlineColor = new Color(0.84f, 0.85f, 0.87f, 1.0f),
                    BackgroundColor = new Selector<Color>()
                    {
                        Normal = new Color(1.0f, 1.0f, 1.0f, 0.2f),
                        Disabled = new Color(0.76f, 0.79f, 0.82f, 1),
                    },
                },
                Progress = new ImageViewStyle()
                {
                    Size = new Size(100, 8),
                    BackgroundColor = new Selector<Color>()
                    {
                        Normal = new Color(0.03f, 0.05f, 0.3f, 1),
                        Disabled = new Color(0.76f, 0.79f, 0.82f, 1),
                    },
                },
                Thumb = new ImageViewStyle()
                {
                    Size = new Size(36, 36),
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
                    Size = new Size(49, 24),
                    BackgroundColor = new Color(0.0f, 0.04f, 0.16f, 1.0f),
                },
            });

            // Switch base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Switch", new SwitchStyle()
            {
                ItemSpacing = new Size2D(32, 32),
                ItemHorizontalAlignment = HorizontalAlignment.Begin,
                ItemVerticalAlignment = VerticalAlignment.Center,
                Track = new ImageViewStyle()
                {
                    Size = new Size(80, 40),
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
                    Size = new Size(40, 40),
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
                    TextColor = new Color("#001447"),
                    PixelSize = 32,
                }
            });

            // Loading base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Loading", new LoadingStyle()
            {
                LoadingSize = new Size(100, 100),
            });

            // Pagination base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Pagination", new PaginationStyle()
            {
                IndicatorImageUrl = new Selector<string>()
                {
                    Normal = FrameworkInformation.ResourcePath + "nui_component_default_pagination_normal_dot.png",
                    Selected = FrameworkInformation.ResourcePath + "nui_component_default_pagination_focus_dot.png",
                },
                IndicatorSize = new Size(10, 10),
            });

            // Scrollbar base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Scrollbar", new ScrollbarStyle()
            {
                TrackThickness = 12,
                ThumbThickness = 12,
                TrackColor = new Color(0f, 0f, 0f, 0f),
                ThumbColor = new Color("#0A0E4A"),
                TrackPadding = 4,
                ThumbVerticalImageUrl = FrameworkInformation.ResourcePath + "nui_component_default_scroll_vbar.#.png",
                ThumbHorizontalImageUrl = FrameworkInformation.ResourcePath + "nui_component_default_scroll_hbar.#.png",
            });

            // LinearLayouter base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.LinearLayouter", new ViewStyle()
            {
                Padding = new Extents(64, 64, 0, 0)
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
                SizeHeight = 108,
                Padding = new Extents(64, 64, 18, 17),
                Margin = new Extents(0, 0, 0, 0),
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color(1, 1, 1, 1),
                    Pressed = new Color(0.85f, 0.85f, 0.85f, 1),
                    Disabled = new Color(0.70f, 0.70f, 0.70f, 1),
                    Selected = new Color(0.85f, 0.85f, 0.85f, 1),
                },
                Label = new TextLabelStyle()
                {
                    PixelSize = 32,
                    Ellipsis = true,
                    FontFamily = "BreezeSans", //FXIME Font Weight is Light
                    TextColor = new Color("#001447"),
                    ThemeChangeSensitive = false
                },
                SubLabel = new TextLabelStyle()
                {
                    PixelSize = 28,
                    Ellipsis = true,
                    FontFamily = "BreezeSans",
                    TextColor = new Color("#001447"),
                    ThemeChangeSensitive = false
                },
                Icon = new ViewStyle()
                {
                    Margin = new Extents(0, 32, 0, 0)
                },
                Extra = new ViewStyle()
                {
                    Margin = new Extents(32, 0, 0, 0)
                },
                Seperator = new ViewStyle()
                {
                    SizeHeight = 1,
                    Margin = new Extents(64, 64, 0, 0),
                    BackgroundColor = new Color("#C3CAD2"),
                },
            });

            // DefaultGridItem base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.DefaultGridItem", new DefaultGridItemStyle()
            {
                Padding = new Extents(0, 0, 0, 0),
                Margin = new Extents(5, 5, 5, 5),
                Label = new TextLabelStyle()
                {
                    SizeHeight = 60,
                    PixelSize = 24,
                    LineWrapMode = LineWrapMode.Character,
                    ThemeChangeSensitive = false
                },
                Badge = new ViewStyle()
                {
                    Margin = new Extents(5, 5, 5, 5),
                },
            });

            // DefaultTitleItem base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.DefaultTitleItem", new DefaultTitleItemStyle()
            {
                SizeHeight = 60,
                Padding = new Extents(64, 64, 12, 12),
                Margin = new Extents(0, 0, 0, 0),
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color("#EEEEF1"),
                },
                Label = new TextLabelStyle()
                {
                    PixelSize = 28,
                    Ellipsis = true,
                    TextColor = new Color("#001447"),
                    ThemeChangeSensitive = false
                },
                Icon = new ViewStyle()
                {
                    Margin = new Extents(40, 0, 0, 0)
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
                Size = new Size(160, 339),
                ItemTextLabel = new TextLabelStyle()
                {
                    //FIXME: Should be check PointSize. given size from UX is too large.
                    PixelSize = 32,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Size = new Size(0,72),
                    TextColor = new Selector<Color>()
                    {
                        Normal = new Color("#000C2B"),
                    },
                    BackgroundColor = Color.White,
                },
                Divider = new ViewStyle()
                {
                    SizeHeight = 2.0f,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    Position = new Position(0, 132),
                    BackgroundColor = new Color("#0A0E4A"),
                },
                StartScrollOffset = new Size(0, 12),
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
                Size = new Size(-1, 116),
                SizeWithTextOnly = new Size(-1, 72),
                SizeWithIconOnly = new Size(-1, 64),
                MinimumSize = new Size(100, -1),
                Padding = new Extents(24, 24, 18, 16),
                PaddingWithTextOnly = new Extents(24, 24, 20, 20),
                PaddingWithIconOnly = new Extents(24, 24, 16, 16),
                ItemSpacing = new Size2D(0, 10),
                CornerRadius = 0,
                IconSizeWithIconOnly = new Size(32, 32),
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color("#FAFAFA"),
                    Selected = new Color("#FFE0CC"),
                    Pressed = new Color("#FFE0CC"),
                    Disabled = new Color("#FAFAFA"),
                },
                Text = new TextLabelStyle()
                {
                    PixelSize = 28,
                    Size = new Size(-2, -2),
                    TextColor = new Selector<Color>()
                    {
                        Normal = new Color("#090E21"),
                        Selected = new Color("#FF6200"),
                        Pressed = new Color("#FF6200"),
                        Disabled = new Color("#CACACA"),
                    },
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
                        Disabled = new Color("#CACACA"),
                    },
                },
            });

            // NotificationToast base style
            theme.AddStyleWithoutClone("NotificationToast", new TextLabelStyle()
            {
                BackgroundColor = new Color("#F2F7FF"),
                CornerRadius = 20.0f,
                BoxShadow = new Shadow(5.0f, new Color("#00000066"), new Vector2(2.0f, 2.0f)),
                TextColor = new Color("#000C2B"),
                PixelSize = 32,
                WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                PositionUsesPivotPoint = true,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Extents(40, 40, 24, 24),
                PositionY = 120,
            });

            // AlertDialog base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.AlertDialog", new AlertDialogStyle()
            {
                Size = new Size(-2, -2),
                Padding = new Extents(80, 80, 0, 0),
                BackgroundColor = Color.White,
                CornerRadius = 28.0f,
                BoxShadow = new Shadow(2.0f, new Color("#00000029"), new Vector2(2.0f, 2.0f)),
                TitleTextLabel = new TextLabelStyle()
                {
                    Size = new Size(720, -2),
                    Margin = new Extents(0, 0, 40, 40),
                    PixelSize = 40,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextColor = new Color("#000C2B"),
                    ThemeChangeSensitive = false,
                },
                MessageTextLabel = new TextLabelStyle()
                {
                    Size = new Size(720, -2),
                    Margin = new Extents(0, 0, 0, 64),
                    PixelSize = 32,
                    MultiLine = true,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextColor = new Color("#000C2B"),
                    ThemeChangeSensitive = false,
                },
                ActionContent = new ViewStyle()
                {
                    Size = new Size(720, -2),
                },
            });

            // TimePicker base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.TimePicker", new TimePickerStyle()
            {
                CellPadding = new Size(50, 339),

                Pickers = new PickerStyle()
                {
                    Size = new Size(160, 339),
                    ItemTextLabel = new TextLabelStyle()
                    {
                        //FIXME: Should be check PointSize. given size from UX is too large.
                        PixelSize = 32,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Size = new Size(0,72),
                        TextColor = new Color("#000C2B"),
                        BackgroundColor = Color.White,
                        ThemeChangeSensitive = false
                    },
                    Divider = new ViewStyle()
                    {
                        SizeHeight = 2.0f,
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        Position = new Position(0, 132),
                        BackgroundColor = new Color("#0A0E4A"),
                    },
                    StartScrollOffset = new Size2D(0, 12),
                }
            });

            // DatePicker base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.DatePicker", new DatePickerStyle()
            {
                CellPadding = new Size(50, 339),

                Pickers = new PickerStyle()
                {
                    Size = new Size(160, 339),
                    ItemTextLabel = new TextLabelStyle()
                    {
                        //FIXME: Should be check PointSize. given size from UX is too large.
                        PixelSize = 32,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Size = new Size(0,72),
                        TextColor = new Color("#000C2B"),
                        BackgroundColor = Color.White,
                        ThemeChangeSensitive = false
                    },
                    Divider = new ViewStyle()
                    {
                        SizeHeight = 2.0f,
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        Position = new Position(0, 132),
                        BackgroundColor = new Color("#0A0E4A"),
                    },
                    StartScrollOffset = new Size2D(0, 12),
                }
            });

            // Menu base style
            theme.AddStyleWithoutClone("Tizen.NUI.Components.Menu", new MenuStyle()
            {
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
                    ThemeChangeSensitive = false
                },
                Icon = new ImageViewStyle()
                {
                    Size = new Size(32, 32),
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

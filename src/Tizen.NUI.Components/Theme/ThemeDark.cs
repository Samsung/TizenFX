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
#if false

using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
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
                ItemAlignment = LinearLayout.Alignment.Center,
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color(0.039f, 0.055f, 0.29f, 1),
                    Pressed = new Color(0.106f, 0.412f, 0.792f, 1),
                    Focused = new Color(0, 0.2f, 0.545f, 1),
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
                ItemSpacing = new Size2D(32, 32),
                ItemAlignment = LinearLayout.Alignment.Begin,
                Icon = new ImageViewStyle()
                {
                    Size = new Size(36, 36),
                    ResourceUrl = new Selector<string>()
                    {
                        Normal = FrameworkInformation.ResourcePath + "IoT_check_off.svg",
                        Pressed = FrameworkInformation.ResourcePath + "IoT_check_off_p.svg",
                        Disabled = FrameworkInformation.ResourcePath + "IoT_check_off_d.svg",
                        Focused = FrameworkInformation.ResourcePath + "IoT_check_off_f.svg",
                        Selected = FrameworkInformation.ResourcePath + "IoT_check_on.svg",
                        SelectedPressed = FrameworkInformation.ResourcePath + "IoT_check_on_p.svg",
                        SelectedFocused = FrameworkInformation.ResourcePath + "IoT_check_on_f.svg",
                        DisabledSelected = FrameworkInformation.ResourcePath + "IoT_check_on_d.svg",
                    },
                },
                Text = new TextLabelStyle()
                {
                    PixelSize = 32,
                    TextColor = new Color("#001447")
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
                            Other = new Color(1, 1, 1, 0.1f),
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
                Size = new Size(200, 25),
                Track = new ImageViewStyle()
                {
                    ResourceUrl = FrameworkInformation.ResourcePath + "IoT_progressindicator_empty.png",
                    BackgroundColor = new Color(0, 0, 0, 0.1f),
                },
                Buffer = new ImageViewStyle()
                {
                    BackgroundColor = new Color(0.05f, 0.63f, 0.9f, 0.3f),
                },
                Progress = new ImageViewStyle()
                {
                    ResourceUrl = new Selector<string>()
                    {
                        Normal = FrameworkInformation.ResourcePath + "IoT_progressindicator_progress_dark.png",
                        Disabled = FrameworkInformation.ResourcePath + "IoT_progressindicator_progressdisabled.png",
                    },
                    BackgroundColor = new Color(0.05f, 0.63f, 0.9f, 1),
                },
                IndeterminateImageUrl = FrameworkInformation.ResourcePath + "nui_component_default_progress_indeterminate.png",
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.RadioButton", new ButtonStyle()
            {
                ItemSpacing = new Size2D(32, 32),
                ItemAlignment = LinearLayout.Alignment.Begin,
                Icon = new ImageViewStyle()
                {
                    Size = new Size(36, 36),
                    ResourceUrl = new Selector<string>()
                    {
                        Normal = FrameworkInformation.ResourcePath + "IoT_radiobutton_off.svg",
                        Pressed = FrameworkInformation.ResourcePath + "IoT_radiobutton_off_p.svg",
                        Disabled = FrameworkInformation.ResourcePath + "IoT_radiobutton_off_d.svg",
                        Focused = FrameworkInformation.ResourcePath + "IoT_radiobutton_off_f.svg",
                        Selected = FrameworkInformation.ResourcePath + "IoT_radiobutton_on.svg",
                        SelectedPressed = FrameworkInformation.ResourcePath + "IoT_radiobutton_on_p.svg",
                        SelectedFocused = FrameworkInformation.ResourcePath + "IoT_radiobutton_on_f.svg",
                        DisabledSelected = FrameworkInformation.ResourcePath + "IoT_radiobutton_on_d.svg",
                    },
                },
                Text = new TextLabelStyle()
                {
                    PixelSize = 32,
                    TextColor = new Color("#001447")
                }
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Slider", new SliderStyle()
            {
                Size = new Size(200, 50),
                TrackThickness = 8,
                Track = new ImageViewStyle()
                {
                    Size = new Size(100, 8),
                    ResourceUrl = new Selector<string>()
                    {
                        Normal = FrameworkInformation.ResourcePath + "IoT_slider_status_empty_track.png",
                        Disabled = FrameworkInformation.ResourcePath + "IoT_slider_status_track_disabled.png",
                    },
                    BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.1f),
                },
                Progress = new ImageViewStyle()
                {
                    Size = new Size(100, 8),
                    ResourceUrl = FrameworkInformation.ResourcePath + "IoT_slider_status_trackW.png",
                    BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 1),
                },
                Thumb = new ImageViewStyle()
                {
                    Size = new Size(36, 36),
                    ResourceUrl = FrameworkInformation.ResourcePath + "IoT_slider_handler_normalW.png",
                },
                ValueIndicatorImage = new ImageViewStyle()
                {
                    Size = new Size(49, 24),
                    BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                },
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Switch", new SwitchStyle()
            {
                ItemSpacing = new Size2D(32, 32),
                ItemAlignment = LinearLayout.Alignment.Begin,
                Track = new ImageViewStyle()
                {
                    Size = new Size(80, 40),
                    ResourceUrl = new Selector<string>()
                    {
                        Normal = FrameworkInformation.ResourcePath + "IoT_switch_track_off.svg",
                        Pressed = FrameworkInformation.ResourcePath + "IoT_switch_track_off_p.svg",
                        Disabled = FrameworkInformation.ResourcePath + "IoT_switch_track_off_d.svg",
                        Focused = FrameworkInformation.ResourcePath + "IoT_switch_track_off_f.svg",
                        Selected = FrameworkInformation.ResourcePath + "IoT_switch_track_on.svg",
                        SelectedPressed = FrameworkInformation.ResourcePath + "IoT_switch_track_on_p.svg",
                        SelectedFocused = FrameworkInformation.ResourcePath + "IoT_switch_track_on_f.svg",
                        DisabledSelected = FrameworkInformation.ResourcePath + "IoT_switch_track_on_d.svg",
                    },
                },
                Thumb = new ImageViewStyle()
                {
                    Size = new Size(40, 40),
                    ResourceUrl = new Selector<string>()
                    {
                        Normal = FrameworkInformation.ResourcePath + "IoT_switch_thumb.svg",
                        Disabled = FrameworkInformation.ResourcePath + "IoT_switch_thumb_d.svg",
                        Selected = FrameworkInformation.ResourcePath + "IoT_switch_thumb_s.svg",
                        SelectedPressed = FrameworkInformation.ResourcePath + "IoT_switch_thumb_sp.svg",
                        SelectedFocused = FrameworkInformation.ResourcePath + "IoT_switch_thumb_sf.svg",
                    }
                },
                Text = new TextLabelStyle()
                {
                    PixelSize = 32,
                    TextColor = new Color("#001447")
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
                },
                IndicatorSize = new Size(10, 10),
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Scrollbar", new ScrollbarStyle()
            {
                TrackThickness = 12,
                ThumbThickness = 12,
                TrackColor = new Color(0f, 0f, 0f, 0f),
                ThumbColor = new Color("#0A0E4AFF"),
                TrackPadding = 4,
                ThumbVerticalImageUrl = FrameworkInformation.ResourcePath + "nui_component_default_scroll_vbar.#.png",
                ThumbHorizontalImageUrl = FrameworkInformation.ResourcePath + "nui_component_default_scroll_hbar.#.png",
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.LinearLayouter", new ViewStyle()
            {
                Padding = new Extents(64, 64, 0, 0)
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.GridLayouter", new ViewStyle()
            {
                Padding = new Extents(0, 0, 0, 0),
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.ItemsLayouter", new ViewStyle()
            {
                Padding = new Extents(0, 0, 0, 0),
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
                    TextColor = new Color("#001447FF"),
                },
                SubLabel = new TextLabelStyle()
                {
                    PixelSize = 28,
                    Ellipsis = true,
                    FontFamily = "BreezeSans",
                    TextColor = new Color("#001447FF"),
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
                    BackgroundColor = new Color("#C3CAD2FF"),
                },
            });
            theme.AddStyleWithoutClone("Tizen.NUI.Components.DefaultGridItem", new DefaultGridItemStyle()
            {
                Padding = new Extents(0, 0, 0, 0),
                Margin = new Extents(5, 5, 5, 5),
                Caption = new TextLabelStyle()
                {
                    SizeHeight = 60,
                    PixelSize = 24,
                    LineWrapMode = LineWrapMode.Character,
                },
                Badge = new ViewStyle()
                {
                    Margin = new Extents(5, 5, 5, 5),
                },
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.DefaultTitleItem", new DefaultTitleItemStyle()
            {
                SizeHeight = 60,
                Padding = new Extents(64, 64, 12, 12),
                Margin = new Extents(0, 0, 0, 0),
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color("#EEEEF1FF"),
                },
                Label = new TextLabelStyle()
                {
                    PixelSize = 28,
                    Ellipsis = true,
                    TextColor = new Color("#001447FF"),
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

            theme.AddStyleWithoutClone("Tizen.NUI.Components.AppBar", new AppBarStyle()
            {
                Size = new Size(-1, 120),
                BackgroundColor = new Color("#EEEFF1FF"),
                BackButton = new ButtonStyle()
                {
                    Size = new Size(48, 48),
                    CornerRadius = 0,
                    BackgroundColor = new Color(0, 0, 0, 0),
                    Icon = new ImageViewStyle()
                    {
                        Size = new Size(48, 48),
                        ResourceUrl = FrameworkInformation.ResourcePath + "nui_component_default_back_button.png",
                        Color = new Selector<Color>()
                        {
                            Normal = new Color("#0A0E4AFF"),
                            Focused = new Color("#00338BFF"),
                            Pressed = new Color("#1B69CAFF"),
                            Disabled = new Color("#C3CAD2FF"),
                        },
                    },
                },
                TitleTextLabel = new TextLabelStyle()
                {
                    PixelSize = 40,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextColor = new Selector<Color>()
                    {
                        Normal = new Color("#000C2BFF"),
                    }
                },
                ActionView = new ViewStyle()
                {
                    Size = new Size(-1, 48),
                    CornerRadius = 0,
                    BackgroundColor = new Color(0, 0, 0, 0),
                },
                ActionButton = new ButtonStyle()
                {
                    Size = new Size(-1, 48),
                    CornerRadius = 0,
                    BackgroundColor = new Color(0, 0, 0, 0),
                    Text = new TextLabelStyle()
                    {
                        PixelSize = 26,
                        TextColor = new Selector<Color>()
                        {
                            Normal = new Color("#0A0E4AFF"),
                            Focused = new Color("#00338BFF"),
                            Pressed = new Color("#1B69CAFF"),
                            Disabled = new Color("#C3CAD2FF"),
                        },
                    },
                    Icon = new ImageViewStyle()
                    {
                        Size = new Size(-1, 48),
                        Color = new Selector<Color>()
                        {
                            Normal = new Color("#0A0E4AFF"),
                            Focused = new Color("#00338BFF"),
                            Pressed = new Color("#1B69CAFF"),
                            Disabled = new Color("#C3CAD2FF"),
                        },
                    },
                },
                Padding = new Extents(64, 64, 0, 0),
                NavigationPadding = new Extents(0, 24, 0, 0),
                ActionPadding = new Extents(40, 0, 0, 0),
                ActionCellPadding = new Size2D(40, 0),
            });

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
                        Normal = new Color("#000C2BFF"),
                    },
                    BackgroundColor = Color.White,
                },
                Divider = new ViewStyle()
                {
                    SizeHeight = 2.0f,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    Position = new Position(0, 132),
                    BackgroundColor = new Color("#0A0E4AFF"),
                },
                StartScrollOffset = new Size(0, 12),
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.TabButton", new TabButtonStyle()
            {
                Size = new Size(-1, 84),
                CornerRadius = 0,
                BackgroundColor = Color.White,
                Text = new TextLabelStyle()
                {
                    PixelSize = 28,
                    Size = new Size(-2, -2),
                    TextColor = new Selector<Color>()
                    {
                        Normal = new Color("#000C2BFF"),
                        Selected = new Color("#000C2BFF"),
                        Pressed = new Color("#1473E6FF"),
                        Disabled = new Color("#C3CAD2FF"),
                    },
                },
                Icon = new ImageViewStyle()
                {
                    Size = new Size(48, 48),
                    Color = new Selector<Color>()
                    {
                        Normal = new Color("#000C2BFF"),
                        Selected = new Color("#000C2BFF"),
                        Pressed = new Color("#1473E6FF"),
                        Disabled = new Color("#C3CAD2FF"),
                    },
                },
                TopLine = new ViewStyle()
                {
                    Size = new Size(-1, 1),
                    BackgroundColor = new Selector<Color>()
                    {
                        Normal = new Color("#000C2BFF"),
                        Selected = new Color("#000C2BFF"),
                        Pressed = new Color("#1473E6FF"),
                        Disabled = new Color("#C3CAD2FF"),
                    },
                },
                BottomLine = new ViewStyle()
                {
                    Size = new Size(-1, 8),
                    Position = new Position(0, 76), // 84 - 8
                    BackgroundColor = new Selector<Color>()
                    {
                        Normal = Color.Transparent,
                        Selected = new Color("#000C2BFF"),
                        Pressed = new Color("#1473E6FF"),
                        Disabled = Color.Transparent,
                    },
                },
            });

            theme.AddStyleWithoutClone("NotificationToast", new TextLabelStyle()
            {
                BackgroundImage = FrameworkInformation.ResourcePath + "IoT_Toast_1.png",
                BackgroundImageBorder = new Rectangle(28, 28, 28, 28),
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
                        TextColor = new Selector<Color>()
                        {
                            Normal = new Color("#000C2BFF"),
                        },
                        BackgroundColor = Color.White,
                    },
                    Divider = new ViewStyle()
                    {
                        SizeHeight = 2.0f,
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        Position = new Position(0, 132),
                        BackgroundColor = new Color("#0A0E4AFF"),
                    },
                    StartScrollOffset = new Size2D(0, 12),
                }
            });

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
                        TextColor = new Selector<Color>()
                        {
                            Normal = new Color("#000C2BFF"),
                        },
                        BackgroundColor = Color.White,
                    },
                    Divider = new ViewStyle()
                    {
                        SizeHeight = 2.0f,
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        Position = new Position(0, 132),
                        BackgroundColor = new Color("#0A0E4AFF"),
                    },
                    StartScrollOffset = new Size2D(0, 12),
                }
            });

            return theme;
        }
    }
}

#endif

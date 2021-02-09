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
#if PROFILE_MOBILE

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    // It is a C# version of res/Tizen.NUI.Components_Tizen.NUI.Theme.Common.xaml
    internal class DefaultThemeCreator : IThemeCreator
    {
        public ResourceDictionary CreateThemeResource() => new ResourceDictionary()
        {
            ["ButtonBackgroundColorNormal"] = new Color(0.88f, 0.88f, 0.88f, 1),
            ["ButtonBackgroundColorPressed"] = new Color(0.77f, 0.77f, 0.77f, 1),
            ["ButtonBackgroundColorDisabled"] = new Color(0.88f, 0.88f, 0.88f, 1),
            ["ButtonTextColorNormal"] = new Color(0.22f, 0.22f, 0.22f, 1),
            ["ButtonTextColorPressed"] = new Color(0.11f, 0.11f, 0.11f, 1),
            ["ButtonTextColorDisabled"] = new Color(0.66f, 0.66f, 0.66f, 1),
            ["CheckBoxIconBackgroundImagePressed"] = FrameworkInformation.ResourcePath + "nui_component_default_checkbox_bg_p.png",
            ["CheckBoxIconBackgroundImageSelected"] = FrameworkInformation.ResourcePath + "nui_component_default_checkbox_bg_p.png",
            ["CheckBoxIconBackgroundImageOther"] = FrameworkInformation.ResourcePath + "nui_component_default_checkbox_bg_n.png",
            ["CheckBoxIconImageResourceUrlPressed"] = "",
            ["CheckBoxIconImageResourceUrlSelected"] = FrameworkInformation.ResourcePath + "nui_component_default_checkbox_s.png",
            ["CheckBoxIconImageResourceUrlOther"] = "",
            ["CheckBoxTextColorNormal"] = new Color(0.22f, 0.22f, 0.22f, 1),
            ["CheckBoxTextColorPressed"] = new Color(0.11f, 0.11f, 0.11f, 1),
            ["CheckBoxTextColorDisabled"] = new Color(0.66f, 0.66f, 0.66f, 1),
            ["DropDownBackgroundImagePressed"] = FrameworkInformation.ResourcePath + "nui_component_default_checkbox_bg_p.png",
            ["DropDownBackgroundImageOther"] = FrameworkInformation.ResourcePath + "nui_component_default_checkbox_bg_n.png",
            ["DropDownIconImageResourceUrl"] = FrameworkInformation.ResourcePath + "nui_component_default_dropdown_button_icon.png",
            ["DropDownListBackgroundImageResourceUrl"] = FrameworkInformation.ResourcePath + "nui_component_default_dropdown_list_bg.png",
            ["DropDownDataItemBackgroundColorPressed"] = new Color(0.05f, 0.63f, 0.9f, 1),
            ["DropDownDataItemBackgroundColorSelected"] = new Color(0.8f, 0.8f, 0.8f, 1),
            ["DropDownDataItemBackgroundColorNormal"] = new Color(1, 1, 1, 1),
            ["PopupBackgroundColor"] = new Color(0.9f, 0.9f, 0.9f, 1),
            ["PopupImageShadowUrl"] = FrameworkInformation.ResourcePath + "nui_component_default_popup_shadow.png",
            ["PopupButtonBackgroundColorNormal"] = new Color(1, 1, 1, 1),
            ["PopupButtonBackgroundColorPressed"] = new Color(1, 1, 1, 0.5f),
            ["PopupButtonOverlayBackgroundColorNormal"] = new Color(1, 1, 1, 1),
            ["PopupButtonOverlayBackgroundColorPressed"] = new Color(0, 0, 0, 0.1f),
            ["PopupButtonOverlayBackgroundColorSelected"] = new Color(1, 1, 1, 1),
            ["PopupButtonTextColor"] = new Color(0.05f, 0.63f, 0.9f, 1),
            ["ProgressTrackBackgroundColor"] = new Color(0, 0, 0, 0.1f),
            ["ProgressBufferBackgroundColor"] = new Color(0.05f, 0.63f, 0.9f, 0.3f),
            ["ProgressProgressBackgroundColor"] = new Color(0.05f, 0.63f, 0.9f, 1),
            ["RadioButtonIconBackgroundImagePressed"] = FrameworkInformation.ResourcePath + "nui_component_default_radiobutton_p.png",
            ["RadioButtonIconBackgroundImageSelected"] = FrameworkInformation.ResourcePath + "nui_component_default_radiobutton_s.png",
            ["RadioButtonIconBackgroundImageOther"] = FrameworkInformation.ResourcePath + "nui_component_default_radiobutton_n.png",
            ["RadioButtonTextColorNormal"] = new Color(0.22f, 0.22f, 0.22f, 1),
            ["RadioButtonTextColorPressed"] = new Color(0.11f, 0.11f, 0.11f, 1),
            ["RadioButtonTextColorDisabled"] = new Color(0.66f, 0.66f, 0.66f, 1),
            ["SliderTrackColor"] = new Color(0, 0, 0, 0.1f),
            ["SliderProgressColor"] = new Color(0.5f, 0.63f, 0.9f, 1),
            ["SliderThumbImageResourceUrl"] = FrameworkInformation.ResourcePath + "nui_component_default_slider_thumb_n.png",
            ["SliderThumbBackgroundImageNormal"] = FrameworkInformation.ResourcePath + "nui_component_default_slider_thumb_bg_p.png",
            ["SliderThumbBackgroundImagePressed"] = FrameworkInformation.ResourcePath + "nui_component_default_slider_thumb_bg_p.png",
            ["SliderValueIndicatorImage"] = FrameworkInformation.ResourcePath + "nui_component_default_slider_value_indicator.png",
            ["SwitchTrackImageResourceUrlNormal"] = FrameworkInformation.ResourcePath + "nui_component_default_switch_track_n.png",
            ["SwitchTrackImageResourceUrlSelected"] = FrameworkInformation.ResourcePath + "nui_component_default_switch_track_s.png",
            ["SwitchTrackImageResourceUrlDisabled"] = FrameworkInformation.ResourcePath + "nui_component_default_switch_track_d.png",
            ["SwitchTrackImageResourceUrlDisabledSelected"] = FrameworkInformation.ResourcePath + "nui_component_default_switch_track_ds.png",
            ["SwitchThumbImageResourceUrlNormal"] = FrameworkInformation.ResourcePath + "nui_component_default_switch_thumb_n.png",
            ["SwitchThumbImageResourceUrlDisabled"] = FrameworkInformation.ResourcePath + "nui_component_default_switch_thumb_d.png",
            ["SwitchThumbImageResourceUrlSelected"] = FrameworkInformation.ResourcePath + "nui_component_default_switch_thumb_n.png",
            ["SwitchTextColorNormal"] = new Color(0.22f, 0.22f, 0.22f, 1),
            ["SwitchTextColorPressed"] = new Color(0.11f, 0.11f, 0.11f, 1),
            ["SwitchTextColorDisabled"] = new Color(0.66f, 0.66f, 0.66f, 1),
            ["TabBackgroundColor"] = Color.Yellow,
            ["TabUnderLineBackgroundColor"] = new Color(0.05f, 0.63f, 0.9f, 1.0f),
            ["TabTextColorNormal"] = Color.Black,
            ["TabTextColorSelected"] = new Color(0.05f, 0.63f, 0.9f, 1),
            ["ToastBackgroundColor"] = new Color(0, 0, 0, 0.8f),
            ["PaginationIndicatorImageUrlNormal"] = FrameworkInformation.ResourcePath + "nui_component_default_pagination_normal_dot.png",
            ["PaginationIndicatorImageUrlSelected"] = FrameworkInformation.ResourcePath + "nui_component_default_pagination_focus_dot.png",
            ["ScrollbarTrackColor"] = new Color(1, 1, 1, 0.15f),
            ["ScrollbarThumbColor"] = new Color(0.6f, 0.6f, 0.6f, 1.0f),
            ["RecyclerViewItemBackgroundColorNormal"] = new Color(1, 1, 1, 1),
            ["RecyclerViewItemBackgroundColorPressed"] = new Color(0.85f, 0.85f, 0.85f, 1),
            ["RecyclerViewItemBackgroundColorDisabled"] = new Color(0.70f, 0.70f, 0.70f, 1),
            ["RecyclerViewItemBackgroundColorSelected"] = new Color(0.701f, 0.898f, 0.937f, 1),
            ["TitleBackgroundColorNormal"] = new Color(0.78f, 0.78f, 0.78f, 1),
        };

        public Theme Create() => Create(null);

        [SuppressMessage("Microsoft.Reliability", "CA2000: Dispose objects before losing scope", Justification = "The responsibility to dispose the object is transferred to the theme object.")]
        public Theme Create(IEnumerable<KeyValuePair<string, string>> changedResources)
        {
            var theme = new Theme() { Id = "Tizen.NUI.Theme.Common" };

            theme.SetChangedResources(changedResources);
            theme.Resources = CreateThemeResource();
            theme.OnThemeResourcesChanged();

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Button", new ButtonStyle()
            {
                Size = new Size(100, 45),
                BackgroundColor = new Selector<Color>()
                {
                    Normal = (Color)theme.Resources["ButtonBackgroundColorNormal"],
                    Pressed = (Color)theme.Resources["ButtonBackgroundColorPressed"],
                    Disabled = (Color)theme.Resources["ButtonBackgroundColorDisabled"],
                },
                Text = new TextLabelStyle()
                {
                    PointSize = 12,
                    TextColor = new Selector<Color>()
                    {
                        Normal = (Color)theme.Resources["ButtonTextColorNormal"],
                        Pressed = (Color)theme.Resources["ButtonTextColorPressed"],
                        Disabled = (Color)theme.Resources["ButtonTextColorDisabled"],
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
                        Pressed = (string)theme.Resources["CheckBoxIconBackgroundImagePressed"],
                        Selected = (string)theme.Resources["CheckBoxIconBackgroundImageSelected"],
                        Other = (string)theme.Resources["CheckBoxIconBackgroundImageOther"],
                    },
                    ResourceUrl = new Selector<string>()
                    {
                        Pressed = (string)theme.Resources["CheckBoxIconImageResourceUrlPressed"],
                        Selected = (string)theme.Resources["CheckBoxIconImageResourceUrlSelected"],
                        Other = (string)theme.Resources["CheckBoxIconImageResourceUrlOther"],
                    },
                },
                Text = new TextLabelStyle()
                {
                    PointSize = 12,
                    TextColor = new Selector<Color>()
                    {
                        Normal = (Color)theme.Resources["CheckBoxTextColorNormal"],
                        Pressed = (Color)theme.Resources["CheckBoxTextColorPressed"],
                        Disabled = (Color)theme.Resources["CheckBoxTextColorDisabled"],
                    }
                }
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Popup", new PopupStyle()
            {
                Size = new Size(500, 280),
                BackgroundColor = (Color)theme.Resources["PopupBackgroundColor"],
                ImageShadow = new ImageShadow()
                {
                    Url = (string)theme.Resources["PopupImageShadowUrl"],
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
                        Normal = (Color)theme.Resources["PopupButtonBackgroundColorNormal"],
                        Pressed = (Color)theme.Resources["PopupButtonBackgroundColorPressed"],
                    },
                    Overlay = new ImageViewStyle()
                    {
                        BackgroundColor = new Selector<Color>()
                        {
                            Normal = (Color)theme.Resources["PopupButtonOverlayBackgroundColorNormal"],
                            Pressed = (Color)theme.Resources["PopupButtonOverlayBackgroundColorPressed"],
                            Other = (Color)theme.Resources["PopupButtonOverlayBackgroundColorSelected"],
                        },
                    },
                    Text = new TextLabelStyle()
                    {
                        TextColor = (Color)theme.Resources["PopupButtonTextColor"],
                    }
                }
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Progress", new ProgressStyle()
            {
                Size = new Size(200, 5),
                Track = new ImageViewStyle()
                {
                    BackgroundColor = (Color)theme.Resources["ProgressTrackBackgroundColor"],
                },
                Buffer = new ImageViewStyle()
                {
                    BackgroundColor = (Color)theme.Resources["ProgressBufferBackgroundColor"],
                },
                Progress = new ImageViewStyle()
                {
                    BackgroundColor = (Color)theme.Resources["ProgressProgressBackgroundColor"],
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
                        Pressed = (string)theme.Resources["RadioButtonIconBackgroundImagePressed"],
                        Selected = (string)theme.Resources["RadioButtonIconBackgroundImageSelected"],
                        Other = (string)theme.Resources["RadioButtonIconBackgroundImageOther"],
                    }
                },
                Text = new TextLabelStyle()
                {
                    PointSize = 12,
                    TextColor = new Selector<Color>()
                    {
                        Normal = (Color)theme.Resources["RadioButtonTextColorNormal"],
                        Pressed = (Color)theme.Resources["RadioButtonTextColorPressed"],
                        Disabled = (Color)theme.Resources["RadioButtonTextColorDisabled"],
                    }
                }
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Slider", new SliderStyle()
            {
                Size = new Size(200, 50),
                TrackThickness = 5,
                Track = new ImageViewStyle()
                {
                    BackgroundColor = (Color)theme.Resources["SliderTrackColor"],
                },
                Progress = new ImageViewStyle()
                {
                    BackgroundColor = (Color)theme.Resources["SliderProgressColor"],
                },
                Thumb = new ImageViewStyle()
                {
                    Size = new Size(50, 50),
                    ResourceUrl = (string)theme.Resources["SliderThumbImageResourceUrl"],
                    BackgroundImage = new Selector<string>()
                    {
                        Normal = (string)theme.Resources["SliderThumbBackgroundImageNormal"],
                        Pressed = (string)theme.Resources["SliderThumbBackgroundImagePressed"],
                    }
                },
                ValueIndicatorImage = new ImageViewStyle()
                {
                    Size = new Size(83, 54),
                    ResourceUrl = (string)theme.Resources["SliderValueIndicatorImage"],
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
                        Normal = (string)theme.Resources["SwitchTrackImageResourceUrlNormal"],
                        Selected = (string)theme.Resources["SwitchTrackImageResourceUrlSelected"],
                        Disabled = (string)theme.Resources["SwitchTrackImageResourceUrlDisabled"],
                        DisabledSelected = (string)theme.Resources["SwitchTrackImageResourceUrlDisabledSelected"],
                    }
                },
                Thumb = new ImageViewStyle()
                {
                    Size = new Size(60, 60),
                    ResourceUrl = new Selector<string>()
                    {
                        Normal = (string)theme.Resources["SwitchThumbImageResourceUrlNormal"],
                        Disabled = (string)theme.Resources["SwitchThumbImageResourceUrlDisabled"],
                        Selected = (string)theme.Resources["SwitchThumbImageResourceUrlSelected"],
                    }
                },
                Text = new TextLabelStyle()
                {
                    PointSize = 12,
                    TextColor = new Selector<Color>()
                    {
                        Normal = (Color)theme.Resources["SwitchTextColorNormal"],
                        Pressed = (Color)theme.Resources["SwitchTextColorPressed"],
                        Disabled = (Color)theme.Resources["SwitchTextColorDisabled"],
                    }
                }
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Tab", new TabStyle()
            {
                Size = new Size(480, 80),
                BackgroundColor = (Color)theme.Resources["TabBackgroundColor"],
                UnderLine = new ViewStyle()
                {
                    Size = new Size(0, 6),
                    BackgroundColor = (Color)theme.Resources["TabUnderLineBackgroundColor"],
                },
                Text = new TextLabelStyle()
                {
                    PointSize = 16,
                    TextColor = new Selector<Color>()
                    {
                        Normal = (Color)theme.Resources["TabTextColorNormal"],
                        Selected = (Color)theme.Resources["TabTextColorSelected"],
                    }
                }
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Toast", new ToastStyle()
            {
                Size = new Size(480, 80),
                BackgroundColor = (Color)theme.Resources["ToastBackgroundColor"],
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
                    Normal = (string)theme.Resources["PaginationIndicatorImageUrlNormal"],
                    Selected = (string)theme.Resources["PaginationIndicatorImageUrlSelected"],
                }
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Components.Scrollbar", new ScrollbarStyle()
            {
                TrackThickness = 6,
                ThumbThickness = 6,
                TrackColor = (Color)theme.Resources["ScrollbarTrackColor"],
                ThumbColor = (Color)theme.Resources["ScrollbarThumbColor"],
                TrackPadding = 4
            });

                        theme.AddStyleWithoutClone("Tizen.NUI.Components.RecyclerViewItem", new RecyclerViewItemStyle()
            {
                BackgroundColor = new Selector<Color>()
                {
                    Normal = (Color)theme.Resources["RecyclerViewItemBackgroundColorNormal"],
                    Pressed = (Color)theme.Resources["RecyclerViewItemBackgroundColorPressed"],
                    Disabled = (Color)theme.Resources["RecyclerViewItemBackgroundColorDisabled"],
                    Selected = (Color)theme.Resources["RecyclerViewItemBackgroundColorSelected"],
                },
            });
            
            theme.AddStyleWithoutClone("Tizen.NUI.Components.DefaultLinearItem", new DefaultLinearItemStyle()
            {
                SizeHeight = 160,
                Padding = new Extents(10, 10, 20, 20),
                BackgroundColor = new Selector<Color>()
                {
                    Normal = (Color)theme.Resources["RecyclerViewItemBackgroundColorNormal"],
                    Pressed = (Color)theme.Resources["RecyclerViewItemBackgroundColorPressed"],
                    Disabled = (Color)theme.Resources["RecyclerViewItemBackgroundColorDisabled"],
                    Selected = (Color)theme.Resources["RecyclerViewItemBackgroundColorSelected"],
                },
                Label = new TextLabelStyle()
                {
                    PointSize = 20,
                    Ellipsis = true,
                },
                SubLabel = new TextLabelStyle()
                {
                    PointSize = 12,
                    Ellipsis = true,
                },
                Icon = new ViewStyle()
                {
                    Margin = new Extents(0, 10, 0, 0)
                },
                Extra = new ViewStyle()
                {
                    Margin = new Extents(10, 0, 0, 0)
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
                SizeHeight = 50,
                Padding = new Extents(10, 10, 5, 5),
                BackgroundColor = new Selector<Color>()
                {
                    Normal = (Color)theme.Resources["TitleBackgroundColorNormal"],
                },
                Label = new TextLabelStyle()
                {
                    PointSize = 15,
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

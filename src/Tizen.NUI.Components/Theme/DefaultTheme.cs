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

using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    internal partial class DefaultThemeCreator
    {
        private HashSet<ExternalThemeKeyList> actionSet;

        private DefaultThemeCreator() { }

        public static IThemeCreator Instance { get; set; } = new DefaultThemeCreator();

        public HashSet<ExternalThemeKeyList> GetExternalThemeKeyListSet()
        {
            if (actionSet != null)
            {
                return actionSet;
            }

            actionSet = new HashSet<ExternalThemeKeyList>()
            {
                // Button
                (new ExternalThemeKeyList(typeof(Button), typeof(ButtonStyle)))
                    .AddBackgroundSelector("/Background", SetBackgroundColor, SetBackgroundImage)
                    .Add<Rectangle>("/BackgroundImageBorder", SetBackgroundBorder)
                    .AddSelector<Color>("/Text/TextColor", SetButtonTextColor)
                    .AddSelector<float?>("/Text/PixelSize", SetButtonTextPixelSize),

                // CheckBox
                (new ExternalThemeKeyList(typeof(CheckBox), typeof(ButtonStyle)))
                    .AddSelector<string>("/Icon/ResourceUrl", SetButtonIconResourceUrl, ControlState.Selected, ControlState.DisabledSelected)
                    .Add<Rectangle>("/Icon/Border", SetButtonIconBorder)
                    .AddSelector<Color>("/Text/TextColor", SetButtonTextColor, ControlState.Selected, ControlState.DisabledSelected)
                    .AddSelector<float?>("/Text/PixelSize", SetButtonTextPixelSize, ControlState.Selected, ControlState.DisabledSelected),

                // RadioButton
                (new ExternalThemeKeyList(typeof(RadioButton), typeof(ButtonStyle)))
                    .AddSelector<string>("/Icon/ResourceUrl", SetButtonIconResourceUrl, ControlState.Selected, ControlState.DisabledSelected)
                    .Add<Rectangle>("/Icon/Border", SetButtonIconBorder)
                    .AddSelector<Color>("/Text/TextColor", SetButtonTextColor, ControlState.Selected, ControlState.DisabledSelected)
                    .AddSelector<float?>("/Text/PixelSize", SetButtonTextPixelSize, ControlState.Selected, ControlState.DisabledSelected),

                // Switch
                (new ExternalThemeKeyList(typeof(Switch), typeof(SwitchStyle)))
                    .AddSelector<string>("/Track/ResourceUrl", (ViewStyle style, Selector<string> value) => ((SwitchStyle)style).Track.ResourceUrl = value, ControlState.Selected, ControlState.DisabledSelected)
                    .AddSelector<string>("/Thumb/ResourceUrl", (ViewStyle style, Selector<string> value) => ((SwitchStyle)style).Thumb.ResourceUrl = value, ControlState.Selected, ControlState.DisabledSelected)
                    .Add<Rectangle>("/Track/Border", (ViewStyle style, Rectangle value) => ((SwitchStyle)style).Track.Border = value)
                    .Add<Rectangle>("/Thumb/Border", (ViewStyle style, Rectangle value) => ((SwitchStyle)style).Thumb.Border = value)
                    .AddSelector<Color>("/Text/TextColor", SetButtonTextColor, ControlState.Selected, ControlState.DisabledSelected)
                    .AddSelector<float?>("/Text/PixelSize", SetButtonTextPixelSize, ControlState.Selected, ControlState.DisabledSelected),

                // Progress
                (new ExternalThemeKeyList(typeof(Progress), typeof(ProgressStyle)))
                    .AddSelector("/Track/Background", (ViewStyle style, Selector<Color> value) => ((ProgressStyle)style).Track.BackgroundColor = value)
                    .AddSelector("/Buffer/Background", (ViewStyle style, Selector<Color> value) => ((ProgressStyle)style).Buffer.BackgroundColor = value)
                    .AddSelector("/Progress/Background", (ViewStyle style, Selector<Color> value) => ((ProgressStyle)style).Progress.BackgroundColor = value)
                    .AddSelector("/Track/ResourceUrl", (ViewStyle style, Selector<string> value) => ((ProgressStyle)style).Track.ResourceUrl = value)
                    .AddSelector("/Buffer/ResourceUrl", (ViewStyle style, Selector<string> value) => ((ProgressStyle)style).Buffer.ResourceUrl = value)
                    .AddSelector("/Progress/ResourceUrl", (ViewStyle style, Selector<string> value) => ((ProgressStyle)style).Progress.ResourceUrl = value),

                // Slider
                (new ExternalThemeKeyList(typeof(Slider), typeof(SliderStyle)))
                    .AddSelector("/Track/Background", (ViewStyle style, Selector<Color> value) => ((SliderStyle)style).Track.BackgroundColor = value)
                    .AddSelector("/Progress/Background", (ViewStyle style, Selector<Color> value) => ((SliderStyle)style).Progress.BackgroundColor = value)
                    .AddSelector("/Thumb/Background", (ViewStyle style, Selector<Color> value) => ((SliderStyle)style).Thumb.BackgroundColor = value)
                    .AddSelector("/Thumb/ResourceUrl", (ViewStyle style, Selector<string> value) => ((SliderStyle)style).Thumb.ResourceUrl = value)
                    .AddSelector("/ValueIndicatorImage/ResourceUrl", (ViewStyle style, Selector<string> value) => ((SliderStyle)style).ValueIndicatorImage.ResourceUrl = value),
                
                // Pagination
                (new ExternalThemeKeyList(typeof(Pagination), typeof(PaginationStyle)))
                    .AddSelector("/IndicatorImageUrl", (ViewStyle style, Selector<string> value) => ((PaginationStyle)style).IndicatorImageUrl = value),
                
                // Scrollbar
                (new ExternalThemeKeyList(typeof(Scrollbar), typeof(ScrollbarStyle)))
                    .Add("/TrackColor", (ViewStyle style, Color value) => ((ScrollbarStyle)style).TrackColor = value)
                    .Add("/ThumbColor", (ViewStyle style, Color value) => ((ScrollbarStyle)style).ThumbColor = value),
                
                // RecyclerViewItem
                (new ExternalThemeKeyList(typeof(RecyclerViewItem), typeof(RecyclerViewItemStyle)))
                    .AddBackgroundSelector("/Background", SetBackgroundColor, SetBackgroundImage, ControlState.Selected)
                    .Add<Rectangle>("/BackgroundImageBorder", SetBackgroundBorder),
                
                // DefaultTitleItem
                (new ExternalThemeKeyList(typeof(DefaultTitleItem), typeof(DefaultTitleItemStyle)))
                    .AddBackgroundSelector("/Background", SetBackgroundColor, SetBackgroundImage)
                    .Add<Rectangle>("/BackgroundImageBorder", SetBackgroundBorder),

                // AppBar
                (new ExternalThemeKeyList(typeof(AppBar), typeof(AppBarStyle))),

                // Picker
                (new ExternalThemeKeyList(typeof(Picker), typeof(PickerStyle)))
                    .AddSelector("/ItemTextLabel/Background", (ViewStyle style, Selector<Color> value) => ((PickerStyle)style).ItemTextLabel.BackgroundColor = value)
                    .AddSelector("/ItemTextLabel/TextColor", (ViewStyle style, Selector<Color> value) => ((PickerStyle)style).ItemTextLabel.TextColor = value)
                    .AddSelector("/ItemTextLabel/PixelSize", (ViewStyle style, Selector<float?> value) => ((PickerStyle)style).ItemTextLabel.PixelSize = value)
                    .AddSelector("/Divider/Background", (ViewStyle style, Selector<Color> value) => ((PickerStyle)style).Divider.BackgroundColor = value),
            };

            return actionSet;
        }

        public static void Preload()
        {
            ThemeManager.AddPackageTheme(Instance);
            Instance.GetExternalThemeKeyListSet();
        }

        private static void SetBackgroundColor(ViewStyle style, Selector<Color> value) => style.BackgroundColor = value;

        private static void SetBackgroundImage(ViewStyle style, Selector<string> value) => style.BackgroundImage = value;

        private static void SetBackgroundBorder(ViewStyle style, Rectangle value) => style.BackgroundImageBorder = value;

        private static void SetButtonTextColor(ViewStyle style, Selector<Color> value) => ((ButtonStyle)style).Text.TextColor = value;

        private static void SetButtonTextPixelSize(ViewStyle style, Selector<float?> value) => ((ButtonStyle)style).Text.PixelSize = value;

        private static void SetButtonIconResourceUrl(ViewStyle style, Selector<string> value) => ((ButtonStyle)style).Icon.ResourceUrl = value;

        private static void SetButtonIconBorder(ViewStyle style, Rectangle value) => ((ButtonStyle)style).Icon.Border = value;

        private static void SetButtonIconBackgroundColor(ViewStyle style, Selector<Color> value) => ((ButtonStyle)style).Icon.BackgroundColor = value;

        private static void SetButtonIconBackgroundImageUrl(ViewStyle style, Selector<string> value) => ((ButtonStyle)style).Icon.BackgroundImage = value;

        private static void SetButtonIconBackgroundBorder(ViewStyle style, Rectangle value) => ((ButtonStyle)style).Icon.BackgroundImageBorder = value;
    }
}


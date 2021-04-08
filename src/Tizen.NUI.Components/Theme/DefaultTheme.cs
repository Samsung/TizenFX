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
                    .AddSelector("/Progress/ResourceUrl", (ViewStyle style, Selector<string> value) => ((ProgressStyle)style).Progress.ResourceUrl = value)
                    .Add<string>("/IndeterminateImageUrl", (ViewStyle style, string value) => ((ProgressStyle)style).IndeterminateImageUrl = value),

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
                    .Add<Size>("/Size", (ViewStyle style, Size value) => ((ViewStyle)style).Size = value)
                    .AddSelector<float?>("/ItemTextLabel/PixelSize", (ViewStyle style, Selector<float?> value) => ((PickerStyle)style).ItemTextLabel.PixelSize = value, ControlState.Selected)
                    .Add<Size>("/ItemTextLabel/Size", (ViewStyle style, Size value) => ((PickerStyle)style).ItemTextLabel.Size = value)
                    .AddSelector<Color>("/ItemTextLabel/TextColor", (ViewStyle style, Selector<Color> value) => ((PickerStyle)style).ItemTextLabel.TextColor = value, ControlState.Selected)
                    .AddSelector("/ItemTextLabel/BackgroundColor", (ViewStyle style, Selector<Color> value) => ((PickerStyle)style).ItemTextLabel.BackgroundColor = value, ControlState.Selected)
                    .Add<float?>("/Divider/SizeHeight", (ViewStyle style, float? value) => ((PickerStyle)style).Divider.SizeHeight = value)
                    .Add<Position>("/Divider/Position", (ViewStyle style, Position value) => ((PickerStyle)style).Divider.Position = value)
                    .AddSelector("/Divider/BackgroundColor", (ViewStyle style, Selector<Color> value) => ((PickerStyle)style).Divider.BackgroundColor = value, ControlState.Selected)
                    .Add<Size>("/StartScrollOffset", (ViewStyle style, Size value) => ((PickerStyle)style).StartScrollOffset = value),

                // TabButton
                (new ExternalThemeKeyList(typeof(TabButton), typeof(TabButtonStyle)))
                    .Add<Size>("/Size", (ViewStyle style, Size value) => ((ViewStyle)style).Size = value)
                    .Add<float?>("/CornerRadius", (ViewStyle style, float? value) => ((ViewStyle)style).CornerRadius = value)
                    .AddSelector<Color>("/BackgroundColor", (ViewStyle style, Selector<Color> value) => ((ViewStyle)style).BackgroundColor = value, ControlState.Selected)
                    .AddSelector<float?>("/Text/PixelSize", SetButtonTextPixelSize, ControlState.Selected)
                    .Add<Size>("/Text/Size", (ViewStyle style, Size value) => ((ButtonStyle)style).Text.Size = value)
                    .AddSelector<Color>("/Text/TextColor", SetButtonTextColor, ControlState.Selected)
                    .Add<Size>("/Icon/Size", (ViewStyle style, Size value) => ((ButtonStyle)style).Icon.Size = value)
                    .AddSelector<Color>("/Icon/Color", (ViewStyle style, Selector<Color> value) => ((ButtonStyle)style).Icon.Color = value, ControlState.Selected)
                    .Add<Size>("/TopLine/Size", (ViewStyle style, Size value) => ((TabButtonStyle)style).TopLine.Size = value)
                    .AddSelector<Color>("/TopLine/BackgroundColor", (ViewStyle style, Selector<Color> value) => ((TabButtonStyle)style).TopLine.BackgroundColor = value, ControlState.Selected)
                    .Add<Size>("/BottomLine/Size", (ViewStyle style, Size value) => ((TabButtonStyle)style).BottomLine.Size = value)
                    .Add<Position>("/BottomLine/Position", (ViewStyle style, Position value) => ((TabButtonStyle)style).BottomLine.Position = value)
                    .AddSelector<Color>("/BottomLine/BackgroundColor", (ViewStyle style, Selector<Color> value) => ((TabButtonStyle)style).BottomLine.BackgroundColor = value, ControlState.Selected),

                // AlertDialog
                (new ExternalThemeKeyList(typeof(AlertDialog), typeof(AlertDialogStyle)))
                    .Add<Size>("/Size", (ViewStyle style, Size value) => ((ViewStyle)style).Size = value)
                    .Add<Extents>("/Padding", (ViewStyle style, Extents value) => ((ViewStyle)style).Padding = value)
                    .Add<string>("/BackgroundImage", (ViewStyle style, string value) => ((ViewStyle)style).BackgroundImage = value)
                    .Add<Size>("/TitleTextLabel/Size", (ViewStyle style, Size value) => ((AlertDialogStyle)style).TitleTextLabel.Size = value)
                    .Add<Extents>("/TitleTextLabel/Margin", (ViewStyle style, Extents value) => ((AlertDialogStyle)style).TitleTextLabel.Margin = value)
                    .Add<float?>("/TitleTextLabel/PixelSize", (ViewStyle style, float? value) => ((AlertDialogStyle)style).TitleTextLabel.PixelSize = value)
                    .Add<HorizontalAlignment?>("/TitleTextLabel/HorizontalAlignment", (ViewStyle style, HorizontalAlignment? value) => ((AlertDialogStyle)style).TitleTextLabel.HorizontalAlignment = value)
                    .Add<VerticalAlignment?>("/TitleTextLabel/VerticalAlignment", (ViewStyle style, VerticalAlignment? value) => ((AlertDialogStyle)style).TitleTextLabel.VerticalAlignment = value)
                    .AddSelector<Color>("/TitleTextLabel/TextColor", (ViewStyle style, Selector<Color> value) => ((AlertDialogStyle)style).TitleTextLabel.TextColor = value)
                    .Add<Size>("/MessageTextLabel/Size", (ViewStyle style, Size value) => ((AlertDialogStyle)style).MessageTextLabel.Size = value)
                    .Add<Extents>("/MessageTextLabel/Margin", (ViewStyle style, Extents value) => ((AlertDialogStyle)style).MessageTextLabel.Margin = value)
                    .Add<float?>("/MessageTextLabel/PixelSize", (ViewStyle style, float? value) => ((AlertDialogStyle)style).MessageTextLabel.PixelSize = value)
                    .Add<bool?>("/MessageTextLabel/MultiLine", (ViewStyle style, bool? value) => ((AlertDialogStyle)style).MessageTextLabel.MultiLine = value)
                    .Add<HorizontalAlignment?>("/MessageTextLabel/HorizontalAlignment", (ViewStyle style, HorizontalAlignment? value) => ((AlertDialogStyle)style).MessageTextLabel.HorizontalAlignment = value)
                    .Add<VerticalAlignment?>("/MessageTextLabel/VerticalAlignment", (ViewStyle style, VerticalAlignment? value) => ((AlertDialogStyle)style).MessageTextLabel.VerticalAlignment = value)
                    .AddSelector<Color>("/MessageTextLabel/TextColor", (ViewStyle style, Selector<Color> value) => ((AlertDialogStyle)style).MessageTextLabel.TextColor = value)
                    .Add<Size>("/ActionContent/Size", (ViewStyle style, Size value) => ((AlertDialogStyle)style).ActionContent.Size = value),
                
                // TimePicker
                (new ExternalThemeKeyList(typeof(TimePicker), typeof(TimePickerStyle)))
                    .Add<Size>("/CellPadding", (ViewStyle style, Size value) => ((TimePickerStyle)style).Size = value)
                    .Add<Size>("/Pickers/Size", (ViewStyle style, Size value) => ((TimePickerStyle)style).Pickers.Size = value)
                    .AddSelector<float?>("/Pickers/ItemTextLabel/PixelSize", (ViewStyle style, Selector<float?> value) => ((TimePickerStyle)style).Pickers.ItemTextLabel.PixelSize = value, ControlState.Selected)
                    .Add<Size>("/Pickers/ItemTextLabel/Size", (ViewStyle style, Size value) => ((TimePickerStyle)style).Pickers.ItemTextLabel.Size = value)
                    .AddSelector<Color>("/Pickers/ItemTextLabel/TextColor", (ViewStyle style, Selector<Color> value) => ((TimePickerStyle)style).Pickers.ItemTextLabel.TextColor = value, ControlState.Selected)
                    .AddSelector("/Pickers/ItemTextLabel/BackgroundColor", (ViewStyle style, Selector<Color> value) => ((TimePickerStyle)style).Pickers.ItemTextLabel.BackgroundColor = value, ControlState.Selected)
                    .Add<float?>("/Pickers/Divider/SizeHeight", (ViewStyle style, float? value) => ((TimePickerStyle)style).Pickers.Divider.SizeHeight = value)
                    .Add<Position>("/Pickers/Divider/Position", (ViewStyle style, Position value) => ((TimePickerStyle)style).Pickers.Divider.Position = value)
                    .AddSelector("/Pickers/Divider/BackgroundColor", (ViewStyle style, Selector<Color> value) => ((TimePickerStyle)style).Pickers.Divider.BackgroundColor = value, ControlState.Selected)
                    .Add<Size>("/Pickers/StartScrollOffset", (ViewStyle style, Size value) => ((TimePickerStyle)style).Pickers.StartScrollOffset = value),

                // DatePicker
                (new ExternalThemeKeyList(typeof(DatePicker), typeof(DatePickerStyle)))
                    .Add<Size>("/CellPadding", (ViewStyle style, Size value) => ((DatePickerStyle)style).Size = value)
                    .Add<Size>("/Pickers/Size", (ViewStyle style, Size value) => ((DatePickerStyle)style).Pickers.Size = value)
                    .AddSelector<float?>("/Pickers/ItemTextLabel/PixelSize", (ViewStyle style, Selector<float?> value) => ((DatePickerStyle)style).Pickers.ItemTextLabel.PixelSize = value, ControlState.Selected)
                    .Add<Size>("/Pickers/ItemTextLabel/Size", (ViewStyle style, Size value) => ((DatePickerStyle)style).Pickers.ItemTextLabel.Size = value)
                    .AddSelector<Color>("/Pickers/ItemTextLabel/TextColor", (ViewStyle style, Selector<Color> value) => ((DatePickerStyle)style).Pickers.ItemTextLabel.TextColor = value, ControlState.Selected)
                    .AddSelector("/Pickers/ItemTextLabel/BackgroundColor", (ViewStyle style, Selector<Color> value) => ((DatePickerStyle)style).Pickers.ItemTextLabel.BackgroundColor = value, ControlState.Selected)
                    .Add<float?>("/Pickers/Divider/SizeHeight", (ViewStyle style, float? value) => ((DatePickerStyle)style).Pickers.Divider.SizeHeight = value)
                    .Add<Position>("/Pickers/Divider/Position", (ViewStyle style, Position value) => ((DatePickerStyle)style).Pickers.Divider.Position = value)
                    .AddSelector("/Pickers/Divider/BackgroundColor", (ViewStyle style, Selector<Color> value) => ((DatePickerStyle)style).Pickers.Divider.BackgroundColor = value, ControlState.Selected)
                    .Add<Size>("/Pickers/StartScrollOffset", (ViewStyle style, Size value) => ((DatePickerStyle)style).Pickers.StartScrollOffset = value),

                // AlertDialog
                (new ExternalThemeKeyList(typeof(AlertDialog), typeof(AlertDialogStyle)))
                    .Add<Size>("/Size", (ViewStyle style, Size value) => ((ViewStyle)style).Size = value)
                    .Add<Extents>("/Padding", (ViewStyle style, Extents value) => ((ViewStyle)style).Padding = value)
                    .Add<string>("/BackgroundImage", (ViewStyle style, string value) => ((ViewStyle)style).BackgroundImage = value)
                    .Add<Size>("/TitleTextLabel/Size", (ViewStyle style, Size value) => ((AlertDialogStyle)style).TitleTextLabel.Size = value)
                    .Add<Extents>("/TitleTextLabel/Margin", (ViewStyle style, Extents value) => ((AlertDialogStyle)style).TitleTextLabel.Margin = value)
                    .Add<float?>("/TitleTextLabel/PixelSize", (ViewStyle style, float? value) => ((AlertDialogStyle)style).TitleTextLabel.PixelSize = value)
                    .Add<HorizontalAlignment?>("/TitleTextLabel/HorizontalAlignment", (ViewStyle style, HorizontalAlignment? value) => ((AlertDialogStyle)style).TitleTextLabel.HorizontalAlignment = value)
                    .Add<VerticalAlignment?>("/TitleTextLabel/VerticalAlignment", (ViewStyle style, VerticalAlignment? value) => ((AlertDialogStyle)style).TitleTextLabel.VerticalAlignment = value)
                    .AddSelector<Color>("/TitleTextLabel/TextColor", (ViewStyle style, Selector<Color> value) => ((AlertDialogStyle)style).TitleTextLabel.TextColor = value)
                    .Add<Size>("/MessageTextLabel/Size", (ViewStyle style, Size value) => ((AlertDialogStyle)style).MessageTextLabel.Size = value)
                    .Add<Extents>("/MessageTextLabel/Margin", (ViewStyle style, Extents value) => ((AlertDialogStyle)style).MessageTextLabel.Margin = value)
                    .Add<float?>("/MessageTextLabel/PixelSize", (ViewStyle style, float? value) => ((AlertDialogStyle)style).MessageTextLabel.PixelSize = value)
                    .Add<bool?>("/MessageTextLabel/MultiLine", (ViewStyle style, bool? value) => ((AlertDialogStyle)style).MessageTextLabel.MultiLine = value)
                    .Add<HorizontalAlignment?>("/MessageTextLabel/HorizontalAlignment", (ViewStyle style, HorizontalAlignment? value) => ((AlertDialogStyle)style).MessageTextLabel.HorizontalAlignment = value)
                    .Add<VerticalAlignment?>("/MessageTextLabel/VerticalAlignment", (ViewStyle style, VerticalAlignment? value) => ((AlertDialogStyle)style).MessageTextLabel.VerticalAlignment = value)
                    .AddSelector<Color>("/MessageTextLabel/TextColor", (ViewStyle style, Selector<Color> value) => ((AlertDialogStyle)style).MessageTextLabel.TextColor = value)
                    .Add<Size>("/ActionContent/Size", (ViewStyle style, Size value) => ((AlertDialogStyle)style).ActionContent.Size = value),
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


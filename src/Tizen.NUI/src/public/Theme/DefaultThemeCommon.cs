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

using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal partial class DefaultThemeCreator
    {
        /// <summary>
        /// The base theme description.
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2000: Dispose objects before losing scope", Justification = "The responsibility to dispose the object is transferred to the theme object.")]
        public Theme Create()
        {
            Theme theme = new Theme()
            {
                Id = DefaultId,
                Version = DefaultVersion,
            };

            // TextLabel style.
            theme.AddStyleWithoutClone("Tizen.NUI.BaseComponents.TextLabel", new TextLabelStyle()
            {
                FontFamily = "BreezeSans",
                PixelSize = 24,
                TextColor = new Color(0.04f, 0.05f, 0.13f, 1),
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("regular")),
                AutoScrollLoopCount = 2,
                AutoScrollGap = 50.0f,
                AutoScrollSpeed = 80,
                FontSizeScale = Tizen.NUI.FontSizeScale.UseSystemSetting,
                AnchorColor = Color.MediumBlue,
                AnchorClickedColor = Color.DarkMagenta,
            });

            // TextField style.
            theme.AddStyleWithoutClone("Tizen.NUI.BaseComponents.TextField", new TextFieldStyle()
            {
                FontFamily = "BreezeSans",
                PixelSize = 24,
                TextColor = new Color(0.04f, 0.05f, 0.13f, 1),
                PlaceholderTextColor = new Vector4(0.79f, 0.79f, 0.79f, 1),
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("regular")),
                PrimaryCursorColor = new Vector4(0.04f, 0.05f, 0.13f, 1),
                SecondaryCursorColor = new Vector4(0.04f, 0.05f, 0.13f, 1),
                CursorWidth = 2,
                FontSizeScale = Tizen.NUI.FontSizeScale.UseSystemSetting,
                SelectionHighlightColor = new Vector4(1.00f, 0.38f, 0.00f, 0.30f),
                GrabHandleColor = new Color(1.00f, 1.00f, 1.00f, 1),
                GrabHandleImage = FrameworkInformation.ResourcePath + "IoT_handler_center_downW.png",
                SelectionHandleImageLeft = new PropertyMap().Add("filename", new PropertyValue(FrameworkInformation.ResourcePath + "IoT_handler_downleftW.png")),
                SelectionHandleImageRight = new PropertyMap().Add("filename", new PropertyValue(FrameworkInformation.ResourcePath + "IoT_handler_downrightW.png")),
                SelectionPopupStyle = new PropertyMap()
                .Add(SelectionPopupStyleProperty.MaxSize, new PropertyValue(new Vector2(1200.0f, 40.0f)))
                .Add(SelectionPopupStyleProperty.DividerSize, new PropertyValue(new Vector2(0.0f, 0.0f)))
                .Add(SelectionPopupStyleProperty.DividerPadding, new PropertyValue(new Vector4(0.0f, 0.0f, 0.0f, 0.0f)))
                .Add(SelectionPopupStyleProperty.Background, new PropertyValue(new PropertyMap().Add(ImageVisualProperty.URL, new PropertyValue(FrameworkInformation.ResourcePath + "IoT-selection-popup-background.9.png"))))
                .Add(SelectionPopupStyleProperty.BackgroundBorder, new PropertyValue(new PropertyMap().Add(ImageVisualProperty.URL, new PropertyValue(FrameworkInformation.ResourcePath + "IoT-selection-popup-border.9.png"))))
                .Add(SelectionPopupStyleProperty.PressedColor, new PropertyValue(new Vector4(1.0f, 0.39f, 0.0f, 0.16f)))
                .Add(SelectionPopupStyleProperty.PressedCornerRadius, new PropertyValue(12.0f))
                .Add(SelectionPopupStyleProperty.FadeInDuration, new PropertyValue(0.25f))
                .Add(SelectionPopupStyleProperty.FadeOutDuration, new PropertyValue(0.25f))
                .Add(SelectionPopupStyleProperty.EnableScrollBar, new PropertyValue(false))
                .Add(SelectionPopupStyleProperty.LabelMinimumSize, new PropertyValue(new Vector2(0, 40.0f)))
                .Add(SelectionPopupStyleProperty.LabelPadding, new PropertyValue(new Vector4(-4.0f, -4.0f, 0.0f, 0.0f)))
                .Add(SelectionPopupStyleProperty.LabelTextVisual, new PropertyValue(new PropertyMap()
                    .Add(TextVisualProperty.PointSize, new PropertyValue(6.0f))
                    .Add(TextVisualProperty.TextColor, new PropertyValue(new Vector4(1.00f, 0.38f, 0.00f, 1)))
                    .Add(TextVisualProperty.FontFamily, new PropertyValue("TizenSans"))
                    .Add(TextVisualProperty.FontStyle, new PropertyValue(new PropertyMap().Add("weight", new PropertyValue("regular")))))),
            });

            // TextEditor style.
            theme.AddStyleWithoutClone("Tizen.NUI.BaseComponents.TextEditor", new TextEditorStyle()
            {
                FontFamily = "BreezeSans",
                PixelSize = 24,
                TextColor = new Color(0.04f, 0.05f, 0.13f, 1),
                PlaceholderTextColor = new Color(0.79f, 0.79f, 0.79f, 1),
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("regular")),
                PrimaryCursorColor = new Vector4(0.04f, 0.05f, 0.13f, 1),
                SecondaryCursorColor = new Vector4(0.04f, 0.05f, 0.13f, 1),
                CursorWidth = 2,
                EnableScrollBar = true,
                ScrollBarShowDuration = 0.8f,
                ScrollBarFadeDuration = 0.5f,
                FontSizeScale = Tizen.NUI.FontSizeScale.UseSystemSetting,
                SelectionHighlightColor = new Vector4(1.00f, 0.38f, 0.00f, 0.30f),
                GrabHandleColor = new Color(1.00f, 1.00f, 1.00f, 1),
                GrabHandleImage = FrameworkInformation.ResourcePath + "IoT_handler_center_downW.png",
                SelectionHandleImageLeft = new PropertyMap().Add("filename", new PropertyValue(FrameworkInformation.ResourcePath + "IoT_handler_downleftW.png")),
                SelectionHandleImageRight = new PropertyMap().Add("filename", new PropertyValue(FrameworkInformation.ResourcePath + "IoT_handler_downrightW.png")),
                SelectionPopupStyle = new PropertyMap()
                .Add(SelectionPopupStyleProperty.MaxSize, new PropertyValue(new Vector2(1200.0f, 40.0f)))
                .Add(SelectionPopupStyleProperty.DividerSize, new PropertyValue(new Vector2(0.0f, 0.0f)))
                .Add(SelectionPopupStyleProperty.DividerPadding, new PropertyValue(new Vector4(0.0f, 0.0f, 0.0f, 0.0f)))
                .Add(SelectionPopupStyleProperty.Background, new PropertyValue(new PropertyMap().Add(ImageVisualProperty.URL, new PropertyValue(FrameworkInformation.ResourcePath + "IoT-selection-popup-background.9.png"))))
                .Add(SelectionPopupStyleProperty.BackgroundBorder, new PropertyValue(new PropertyMap().Add(ImageVisualProperty.URL, new PropertyValue(FrameworkInformation.ResourcePath + "IoT-selection-popup-border.9.png"))))
                .Add(SelectionPopupStyleProperty.PressedColor, new PropertyValue(new Vector4(1.0f, 0.39f, 0.0f, 0.16f)))
                .Add(SelectionPopupStyleProperty.PressedCornerRadius, new PropertyValue(12.0f))
                .Add(SelectionPopupStyleProperty.FadeInDuration, new PropertyValue(0.25f))
                .Add(SelectionPopupStyleProperty.FadeOutDuration, new PropertyValue(0.25f))
                .Add(SelectionPopupStyleProperty.EnableScrollBar, new PropertyValue(false))
                .Add(SelectionPopupStyleProperty.LabelMinimumSize, new PropertyValue(new Vector2(0, 40.0f)))
                .Add(SelectionPopupStyleProperty.LabelPadding, new PropertyValue(new Vector4(-4.0f, -4.0f, 0.0f, 0.0f)))
                .Add(SelectionPopupStyleProperty.LabelTextVisual, new PropertyValue(new PropertyMap()
                    .Add(TextVisualProperty.PointSize, new PropertyValue(6.0f))
                    .Add(TextVisualProperty.TextColor, new PropertyValue(new Vector4(1.00f, 0.38f, 0.00f, 1)))
                    .Add(TextVisualProperty.FontFamily, new PropertyValue("TizenSans"))
                    .Add(TextVisualProperty.FontStyle, new PropertyValue(new PropertyMap().Add("weight", new PropertyValue("regular")))))),
            });

            return theme;
        }
    }
}


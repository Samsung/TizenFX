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
        private DefaultThemeCreator() { }

        public static IThemeCreator Instance { get; set; } = new DefaultThemeCreator();

        public static void Preload()
        {
            ThemeManager.AddPackageTheme(Instance);
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


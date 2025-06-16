/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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

using System;
using System.ComponentModel;

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.MarkdownRenderer
{
    /// <summary>
    /// Renders a heading element as a styled paragraph with configurable heading levels.
    /// Applies heading-specific styles and sizing based on the markdown heading level.
    /// </summary>
    internal class UIHeading : UIParagraph
    {
        private readonly HeadingStyle heading;
        private int level;

        public int Level
        {
            get => level;
            set
            {
                if (level == value) return;

                level = value;
                switch (level)
                {
                    case 1: PixelSize = heading.FontSizeLevel1; break;
                    case 2: PixelSize = heading.FontSizeLevel2; break;
                    case 3: PixelSize = heading.FontSizeLevel3; break;
                    case 4: PixelSize = heading.FontSizeLevel4; break;
                    case 5: PixelSize = heading.FontSizeLevel5; break;
                    default: PixelSize = heading.FontSizeLevel1; break;
                }
            }
        }

        public UIHeading(string text, int level, HeadingStyle headingStyle, CommonStyle commonStyle, ParagraphStyle paragraphStyle, string hash, bool asyncRendering) : base(text, paragraphStyle, hash, asyncRendering)
        {
            heading = headingStyle;

            Level = level;
            FontFamily = heading.FontFamily;
            Margin = new Extents(0, 0, (ushort)commonStyle.Margin, (ushort)commonStyle.Margin);
        }
    }
}

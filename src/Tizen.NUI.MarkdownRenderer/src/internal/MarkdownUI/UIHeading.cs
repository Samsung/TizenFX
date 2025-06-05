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
    internal class UIHeading : UIParagraph
    {
        HeadingStyle style;

        public UIHeading(string text, int level, HeadingStyle headingStyle, CommonStyle commonStyle, ParagraphStyle paragraphStyle) : base(text, paragraphStyle)
        {
            style = headingStyle;

            FontFamily = style.FontFamily;
            Margin = new Extents(0, 0, (ushort)commonStyle.Margin, (ushort)commonStyle.Margin);
            SetFontSize(level);
        }

        private void SetFontSize(int level)
        {
            switch(level)
            {
                case 1:
                    PixelSize = style.FontSizeLevel1;
                    break;
                case 2:
                    PixelSize = style.FontSizeLevel2;
                    break;
                case 3:
                    PixelSize = style.FontSizeLevel3;
                    break;
                case 4:
                    PixelSize = style.FontSizeLevel4;
                    break;
                case 5:
                    PixelSize = style.FontSizeLevel5;
                    break;
                default:
                    PixelSize = style.FontSizeLevel1;
                    break;
            }
        }
    }
}

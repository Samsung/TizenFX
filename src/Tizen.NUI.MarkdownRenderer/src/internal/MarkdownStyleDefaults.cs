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

namespace Tizen.NUI.MarkdownRenderer
{
    internal static class StyleDefaults
    {
        // Common
        public const int CommonIndent = 40;
        public const int CommonPadding = 10;
        public const int CommonMargin = 10;

        // Paragraph
        public const string ParagraphFontColor = "#000000FF";
        public const float ParagraphFontSize = 20.0f;
        public const string ParagraphFontFamily = "SamsungOneUI_400";
        public const float ParagraphLineHeight = 32.0f;

        // Heading
        public const float HeadingFontSizeLevel1 = 28.0f;
        public const float HeadingFontSizeLevel2 = 24.0f;
        public const float HeadingFontSizeLevel3 = 20.0f;
        public const float HeadingFontSizeLevel4 = 16.0f;
        public const float HeadingFontSizeLevel5 = 12.0f;
        public const string HeadingFontFamily = "SamsungOneUI_700";

        // ThematicBreakStyle
        public const string ThematicBreakColor = "#DFDFDFFF";
        public const int ThematicBreakThickness = 1;
        public const int ThematicBreakMargin = 10;

        // QuoteStyle
        public const string QuoteFontColor = "#2F2F2FFF";
        public const string QuoteBarColor = "#DFDFDFFF";
        public const int QuoteBarWidth = 6;
        public const int QuoteBarMargin = 10;
        public const int QuotePadding = 10;

        // TableStyle
        public const string TableBackgroundColor = "#00000000";
        public const string TableBorderColor = "#000000FF";
        public const int TableBorderThickness = 1;
        public const int TablePadding = 10;
        public const int TableItemPadding = 5;

        // CodeStyle
        public const string CodeFontFamily = "SamsungOneUI_300"; // FIXME: Tizen devices do not have mono space font.
        public const string CodeFontColor = "#121212FF";
        public const string CodeBackgroundColor = "#CCCCCC33";
        public const float CodeFontSize = 20.0f;
        public const string CodeTitleFontFamily = "SamsungOneUI_300"; // FIXME: Tizen devices do not have mono space font.
        public const string CodeTitleFontColor = "#454545FF";
        public const string CodeTitleBackgroundColor = "#CCCCCC55";
        public const float CodeTitleFontSize = 16.0f;
        public const int CodePadding = 10;
    }
}
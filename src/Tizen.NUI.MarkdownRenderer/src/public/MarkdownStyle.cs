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
    /// <summary>
    /// MarkdownStyle.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MarkdownStyle
    {
        /// <summary>
        /// MarkdownStyle.
        /// </summary>
        public MarkdownStyle() { }

        /// <summary>
        /// CommonStyle.
        /// </summary>
        public CommonStyle Common { get; } = new CommonStyle();

        /// <summary>
        /// ParagraphStyle.
        /// </summary>
        public ParagraphStyle Paragraph { get; } = new ParagraphStyle();

        /// <summary>
        /// HeadingStyle.
        /// </summary>
        public HeadingStyle Heading { get; } = new HeadingStyle();

        /// <summary>
        /// ThematicBreakStyle.
        /// </summary>
        public ThematicBreakStyle ThematicBreak { get; } = new ThematicBreakStyle();

        /// <summary>
        /// QuoteStyle.
        /// </summary>
        public QuoteStyle Quote { get; } = new QuoteStyle();

        /// <summary>
        /// TableStyle.
        /// </summary>
        public TableStyle Table { get; } = new TableStyle();

        /// <summary>
        /// CodeStyle.
        /// </summary>
        public CodeStyle Code { get; } = new CodeStyle();
    }

    /// <summary>
    /// CommonStyle.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CommonStyle
    {
        /// Indent is added in pixels to the left of a Container Block (Quote, List).
        public int Indent { get; set; } = StyleDefaults.CommonIndent;

        /// Padding.
        public int Padding { get; set; } = StyleDefaults.CommonPadding;

        /// Margin is added in pixels to the top and bottom of Block (Heading, List, Table, Code, Quote, ThematicBreak).
        public int Margin { get; set; } = StyleDefaults.CommonMargin;
    }

    /// <summary>
    /// ParagraphStyle.
    /// </summary>
    /// <remark>
    /// Most text follows ParagraphStyle, except Heading and Code.
    /// </remark>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ParagraphStyle
    {
        /// FontColor.
        public string FontColor { get; set; } = StyleDefaults.ParagraphFontColor;

        /// FontSize.
        public float FontSize { get; set; } = StyleDefaults.ParagraphFontSize;

        /// FontFamily.
        public string FontFamily { get; set; } = StyleDefaults.ParagraphFontFamily;

        /// The minimum height of a line in pixels.
        public float LineHeight { get; set; } = StyleDefaults.ParagraphLineHeight;
    }

    /// <summary>
    /// HeadingStyle.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class HeadingStyle
    {
        /// Font size of heading level 1.
        public float FontSizeLevel1 { get; set; } = StyleDefaults.HeadingFontSizeLevel1;

        /// Font size of heading level 2.
        public float FontSizeLevel2 { get; set; } = StyleDefaults.HeadingFontSizeLevel2;

        /// Font size of heading level 3.
        public float FontSizeLevel3 { get; set; } = StyleDefaults.HeadingFontSizeLevel3;

        /// Font size of heading level 4.
        public float FontSizeLevel4 { get; set; } = StyleDefaults.HeadingFontSizeLevel4;

        /// Font size of heading level 5.
        public float FontSizeLevel5 { get; set; } = StyleDefaults.HeadingFontSizeLevel5;

        /// FontFamily.
        public string FontFamily { get; set; } = StyleDefaults.HeadingFontFamily;
    }

    /// <summary>
    /// ThematicBreakStyle.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ThematicBreakStyle
    {
        /// Color.
        public string Color { get; set; } = StyleDefaults.ThematicBreakColor;

        /// Thickness.
        public int Thickness { get; set; } = StyleDefaults.ThematicBreakThickness;

        /// Margin is added in pixels to the top and bottom of Block.
        public int Margin { get; set; } = StyleDefaults.ThematicBreakMargin;
    }

    /// <summary>
    /// QuoteStyle.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class QuoteStyle
    {
        /// BackgroundColor.
        public string BackgroundColor { get; set; } = StyleDefaults.QuoteBackgroundColor;

        /// Padding.
        public int Padding { get; set; } = StyleDefaults.QuotePadding;
    }

    /// <summary>
    /// TableStyle.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TableStyle
    {
        /// BackgroundColor.
        public string BackgroundColor { get; set; } = StyleDefaults.TableBackgroundColor;

        /// BorderColor.
        public string BorderColor { get; set; } = StyleDefaults.TableBorderColor;

        /// BorderThickness.
        public int BorderThickness { get; set; } = StyleDefaults.TableBorderThickness;

        /// Padding.
        public int Padding { get; set; } = StyleDefaults.TablePadding;

        /// ItemPadding.
        public int ItemPadding { get; set; } = StyleDefaults.TableItemPadding;
    }

    /// <summary>
    /// CodeStyle.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CodeStyle
    {
        /// TitleFontFamily.
        public string TitleFontFamily { get; set; } = StyleDefaults.CodeTitleFontFamily;

        /// TitleFontColor.
        public string TitleFontColor { get; set; } = StyleDefaults.CodeTitleFontColor;

        /// TitleBackgroundColor.
        public string TitleBackgroundColor { get; set; } = StyleDefaults.CodeTitleBackgroundColor;

        /// TitleFontSize.
        public float TitleFontSize { get; set; } = StyleDefaults.CodeTitleFontSize;

        /// FontFamily.
        public string FontFamily { get; set; } = StyleDefaults.CodeFontFamily;

        /// FontColor.
        public string FontColor { get; set; } = StyleDefaults.CodeFontColor;

        /// BackgroundColor.
        public string BackgroundColor { get; set; } = StyleDefaults.CodeBackgroundColor;

        /// FontSize.
        public float FontSize { get; set; } = StyleDefaults.CodeFontSize;

        /// Padding.
        public int Padding { get; set; } = StyleDefaults.CodePadding;
    }
}
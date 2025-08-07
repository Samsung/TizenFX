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
    /// Represents a visual element for rendering a paragraph of text in a Markdown UI.
    /// </summary>
    internal class UIParagraph : UIText
    {
        public string ContentHash { get; set; } = string.Empty;

        public UIParagraph(string text, ParagraphStyle paragraphStyle, string hash = "", bool asyncRendering = false) : base()
        {
            ContentHash = hash; 
            Text = text;
            FontFamily = paragraphStyle.FontFamily;
            PixelSize = paragraphStyle.FontSize;
            TextColor = new Color(paragraphStyle.FontColor);
            MinLineSize = Math.Max(paragraphStyle.LineHeight, paragraphStyle.FontSize * 1.4f);
            MultiLine = true;
            EnableMarkup = true;
            Ellipsis = false;
            VerticalLineAlignment = VerticalLineAlignment.Center;
            RenderMode = asyncRendering ? TextRenderMode.AsyncManual : TextRenderMode.Sync;
        }
    }
}

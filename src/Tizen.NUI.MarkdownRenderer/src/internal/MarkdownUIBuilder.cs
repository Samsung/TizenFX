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
using System.Text;

using Tizen.NUI.BaseComponents;

using Markdig;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using Markdig.Extensions.Tables;

namespace Tizen.NUI.MarkdownRenderer
{
    /// <summary>
    /// Builds a UI tree from a Markdown block AST and manages view re-use through caching.
    /// Designed for efficient incremental updates and streaming rendering.
    /// </summary>
    internal class MarkdownUIBuilder
    {
        private MarkdownStyle style;
        private MarkdownUICacheManager cacheManager = new MarkdownUICacheManager();

        /// <summary>
        /// Initializes a new builder instance with the specified style.
        /// </summary>
        /// <param name="markdownStyle">Style settings for rendering markdown UI.</param>
        public MarkdownUIBuilder(MarkdownStyle markdownStyle)
        {
            style = markdownStyle;
        }

        /// <summary>
        /// Disposes and removes any views in the cache that were not visited
        /// in the latest Build() traversal.
        /// Should be called after each build pass.
        /// </summary>
        public void RemoveUnusedUI()
        {
            cacheManager.RemoveUnusedViews();
        }

        /// <summary>
        /// Clears the cached UI views and resets the builder's internal state.
        /// </summary>
        public void Clear()
        {
            cacheManager.Clear();
        }

        /// <summary>
        /// Recursively traverses the Markdown block AST, constructing and reusing
        /// UI views for each block. Uses a cache to minimize unnecessary view creation.
        /// </summary>
        /// <param name="block">The current Markdown block node being processed.</param>
        /// <param name="parent">The parent UI View to attach created/reused views to.</param>
        /// <param name="path">A unique path string (e.g., "root/0/2") for key generation and cache lookup.</param>
        public void Build(Block block, View parent, string path)
        {
            string key = cacheManager.CreateKey(block, path);
            cacheManager.MarkVisited(key);

            var view = cacheManager.Get(key);
            if (view is null)
            {
                string text = string.Empty;
                if (block is LeafBlock leafBlock)
                    text = GetInlineText(leafBlock.Inline);

                view = block is ContainerBlock ? CreateContainer(block) : CreateLeaf(block, text);
                parent.Add(view);

                cacheManager.Add(key, view);
            }
            // else: do nothing!

            if (block is ContainerBlock containerBlock)
            {
                int index = 0;
                foreach (var subBlock in containerBlock)
                    Build(subBlock, view, $"{path}/{index++}");
            }
        }

        /// <summary>
        /// Recursively converts a Markdig inline node tree into a markup string for rich UI rendering.
        /// Applies markdown styling (bold, italic, strikethrough, code, link, linebreak, etc)
        /// by emitting markup tags suitable for NUI TextLabel.
        /// </summary>
        /// <param name="inline">Root Markdig ContainerInline node to convert.</param>
        /// <returns>
        /// A string containing markup representing the fully styled inline content,
        /// with emphasis, code, links, and other markdown features as tags.
        /// </returns>
        private string GetInlineText(ContainerInline inline)
        {
            if (inline == null) return string.Empty;
            var sb = new StringBuilder();
            foreach (var child in inline)
            {
                switch (child)
                {
                    case LiteralInline literal:
                        var slice = literal.Content;
                        AppendEscaped(sb, slice.Text, slice.Start, slice.Length);
                        break;

                    case EmphasisInline emphasis:
                        var content = GetInlineText(emphasis);
                        if(emphasis.DelimiterChar == '~')
                            sb.Append(emphasis.DelimiterCount == 2 ? $"<s>{content}</s>" : $"{content}");
                        else // '*', '**', '__'
                            sb.Append(emphasis.DelimiterCount == 2 ? $"<b>{content}</b>" : $"<i>{content}</i>");
                        break;

                    case CodeInline code:
                        sb.Append($"<font family='{style.Code.FontFamily}'>");
                        AppendEscaped(sb, code.Content, 0, code.Content.Length);
                        sb.Append("</font>");
                        break;

                    case LineBreakInline:
                        sb.AppendLine();
                        break;

                    case LinkInline link:
                        var label = GetInlineText(link);
                        sb.Append($"<b>{label}</b> [\U0001f517 ");
                        AppendEscaped(sb, link.Url, 0, link.Url.Length);
                        sb.Append("]");
                        break;

                    default: // fallback
                        if (child is ContainerInline container)
                            sb.Append(GetInlineText(container));
                        break;
                }
            }
            return sb.ToString();
        }

        private void AppendEscaped(StringBuilder sb, string text, int start, int length)
        {
            for (int i = start; i < start + length; i++)
            {
                char c = text[i];
                switch (c)
                {
                    case '&': sb.Append("&amp;"); break;
                    case '<': sb.Append("&lt;"); break;
                    case '>': sb.Append("&gt;"); break;
                    default: sb.Append(c); break;
                }
            }
        }

        private View CreateLeaf(Block block, string text)
        {
            if (block is HeadingBlock heading)
            {
                return new UIHeading(text, heading.Level, style.Heading, style.Common, style.Paragraph);
            }
            else if (block is ParagraphBlock)
            {
                if (block.Parent is ListItemBlock)
                    return new UIListItemParagraph(text, style.Paragraph);

                else if (block.Parent is QuoteBlock)
                    return new UIQuoteParagraph(text, style.Quote, style.Paragraph);

                else
                    return new UIParagraph(text, style.Paragraph);
            }
            else if (block is ThematicBreakBlock)
            {
                return new UIThematicBreak(style.ThematicBreak, style.Common);
            }
            else if (block is FencedCodeBlock fenced)
            {
                string language = fenced.Info;
                string code = fenced.Lines.ToString();
                return new UICode(language, code, style.Code, style.Common);
            }
            else
            {
                return new UIParagraph(text, style.Paragraph); // fallback
            }
        }

        private View CreateContainer(Block block)
        {
            if (block is MarkdownDocument)
            {
                return new UIContainer(style.Common);
            }
            else if (block is QuoteBlock)
            {
                return new UIQuote(block.Parent is MarkdownDocument, style.Quote, style.Common, style.Paragraph);
            }
            else if (block is ListBlock)
            {
                return new UIList(style.Common);
            }
            else if (block is ListItemBlock)
            {
                return new UIListItem(style.Common);
            }
            else if (block is Table)
            {
                return new UITable(style.Table, style.Common);
            }
            else if (block is TableRow tableRow)
            {
                return new UITableRow(tableRow.IsHeader, style.Table);
            }
            else if (block is TableCell)
            {
                return new UITableCell(style.Table);
            }
            else
            {
                return new UIContainer(style.Common);
            }
        }
    }
}
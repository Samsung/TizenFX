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
        /// The UI elements are rendered asynchronously on a background thread whenever possible.
        /// Currently only UIText can be async rendered.
        /// </summary>
        public bool AsyncRendering { get; set; } = false;

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
        /// <param name="childIndex">Index of the current child block (or -1 for root)</param>
        public void Build(Block block, View parent, StringBuilder path, int childIndex = -1)
        {
            int pathLength = path.Length;
            if (childIndex >= 0)
                path.Append('/').Append(childIndex);

            string key = cacheManager.CreateKey(block, path.ToString());
            cacheManager.MarkVisited(key);

            var view = cacheManager.Get(key);
            if (view is null)
            {
                if (block is ContainerBlock)
                {
                    view = CreateContainer(block);
                }
                else
                {
                    string text = (block is LeafBlock leafBlock) ? GetInlineText(leafBlock.Inline) : string.Empty;
                    view = CreateLeaf(block, text);
                }
                parent.Add(view);
                cacheManager.Add(key, view);
            }
            else if (IsUpdatable(block) && block is LeafBlock leafBlock)
            {
                string text = GetInlineText(leafBlock.Inline);
                UpdateLeaf(view, block, text);
            }

            // else do nothing!

            if (block is ContainerBlock containerBlock)
            {
                int index = 0;
                foreach (var subBlock in containerBlock)
                    Build(subBlock, view, path, index++);
            }

            path.Length = pathLength;
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
                        if (emphasis.DelimiterChar == '~')
                        {
                            if (emphasis.DelimiterCount == 2)
                                sb.Append("<s height='").Append(style.Paragraph.StrikethroughThickness).Append("'>").Append(content).Append("</s>");
                            else
                                sb.Append(content);
                        }
                        else // '*', '**', '__'
                        {
                            if (emphasis.DelimiterCount == 2)
                                sb.Append("<b>").Append(content).Append("</b>");
                            else
                                sb.Append("<i>").Append(content).Append("</i>");
                        }
                        break;

                    case CodeInline code:
                        sb.Append("<font family='").Append(style.Code.FontFamily).Append("'>");
                        AppendEscaped(sb, code.Content, 0, code.Content.Length);
                        sb.Append("</font>");
                        break;

                    case LineBreakInline:
                        sb.Append('\n');
                        break;

                    case LinkInline link:
                        var label = GetInlineText(link);
                        sb.Append("<b>").Append(label).Append("</b> [\U0001f517 ");
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

        private int GetIndent(Block block)
        {
            int indent = 0;
            if (block.Parent is ListItemBlock listItem)
            {
                if (listItem.Parent is ListBlock listBlock && listBlock.IsOrdered)
                {
                    indent = UIList.GetNumberSize(style.Paragraph);
                }
                else
                {
                    int bulletSize = UIList.GetBulletSize(style.Paragraph);
                    ushort bulletMargin = UIList.GetBulletMargin(bulletSize, style.Paragraph);
                    indent = bulletSize + (int)(bulletMargin * 2);
                }
            }
            return indent;
        }

        private bool IsUpdatable(Block block)
        {
            return block is HeadingBlock || block is ParagraphBlock || block is FencedCodeBlock;
        }

        private void UpdateLeaf(View view, Block block, string text)
        {
            switch (block)
            {
                case HeadingBlock heading when view is UIHeading uiHeading:
                {
                    var hash = cacheManager.ComputeHash(text);
                    if (uiHeading.ContentHash != hash)
                    {
                        uiHeading.Text = text;
                        uiHeading.Level = heading.Level;
                        uiHeading.ContentHash = hash;
                    }
                    break;
                }
                case ParagraphBlock when view is UIParagraph uiParagraph:
                {
                    var hash = cacheManager.ComputeHash(text);
                    if (uiParagraph.ContentHash != hash)
                    {
                        uiParagraph.Text = text;
                        uiParagraph.ContentHash = hash;
                    }
                    break;
                }
                case ParagraphBlock when view is UIListItemParagraph uiListItemParagraph && block.Parent is ListItemBlock listItem:
                {
                    var hash = cacheManager.ComputeHash(text);
                    if (uiListItemParagraph.ContentHash != hash)
                    {
                        uiListItemParagraph.Text = text;
                        uiListItemParagraph.ContentHash = hash;
                    }
                    break;
                }
                case ParagraphBlock when view is UIQuoteParagraph uiQuoteParagraph:
                {
                    var hash = cacheManager.ComputeHash(text);
                    if (uiQuoteParagraph.ContentHash != hash)
                    {
                        uiQuoteParagraph.Text = text;
                        uiQuoteParagraph.ContentHash = hash;
                    }
                    break;
                }
                case FencedCodeBlock fenced when view is UICode uiCode:
                {
                    string code = fenced.Lines.ToString();
                    string language = fenced.Info;
                    string hash = cacheManager.ComputeHash(language + code);
                    if (uiCode.ContentHash != hash)
                    {
                        uiCode.Language = language;
                        uiCode.Code = code;
                        uiCode.ContentHash = hash;
                    }
                    break;
                }
                default:
                    Tizen.Log.Error("NUI", $"Unknown type:{block.GetType().Name}\n");
                    break;
            }
        }

        private View CreateLeaf(Block block, string text)
        {
            switch (block)
            {
                case HeadingBlock heading:
                {
                    string hash = cacheManager.ComputeHash(text);
                    return new UIHeading(text, heading.Level, style.Heading, style.Common, style.Paragraph, hash, AsyncRendering);
                }
                case ParagraphBlock when block.Parent is ListItemBlock listItem:
                {
                    string hash = cacheManager.ComputeHash(text);
                    if (listItem.Parent is ListBlock listBlock && listBlock.IsOrdered)
                    {
                        int index = listBlock.IndexOf(listItem);
                        int start = int.TryParse(listBlock.OrderedStart?.ToString(), out var s) ? s : 1;
                        int number = start + index;
                        return new UIListItemParagraph(text, number, style.Paragraph, hash, AsyncRendering);
                    }
                    else
                    {
                        return new UIListItemParagraph(text, style.Paragraph, hash, AsyncRendering);
                    }
                }
                case ParagraphBlock when block.Parent is QuoteBlock:
                {
                    string hash = cacheManager.ComputeHash(text);
                    return new UIQuoteParagraph(text, style.Quote, style.Paragraph, hash, AsyncRendering);
                }
                case ParagraphBlock:
                {
                    string hash = cacheManager.ComputeHash(text);
                    return new UIParagraph(text, style.Paragraph, hash, AsyncRendering);
                }
                case ThematicBreakBlock:
                {
                    return new UIThematicBreak(style.ThematicBreak, style.Common);
                }
                case FencedCodeBlock fenced:
                {
                    string language = fenced.Info;
                    string code = fenced.Lines.ToString();
                    string hash = cacheManager.ComputeHash(language + code);
                    return new UICode(language, code, GetIndent(block), style.Code, style.Common, hash, AsyncRendering);
                }
                default:
                {
                    string hash = cacheManager.ComputeHash(text);
                    return new UIParagraph(text, style.Paragraph, hash, AsyncRendering); // fallback
                }
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
                return new UIQuote(block.Parent is MarkdownDocument, GetIndent(block), style.Quote, style.Common, style.Paragraph);
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

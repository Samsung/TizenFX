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
using System.Globalization;

using Markdig;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

namespace Tizen.NUI.MarkdownRenderer
{
    /// <summary>
    /// Provides a Markdown parser configured with custom pipeline options,
    /// enabling table support and enhanced emphasis handling for Tizen NUI markdown rendering.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class MarkdownParser
    {
        private static readonly MarkdownPipeline _pipeline = new MarkdownPipelineBuilder().UsePipeTables().UseEmphasisExtras().Build();

        /// <summary>
        /// Converts the given markdown text to plain text.
        /// </summary>
        /// <param name="markdown">Markdown input string.</param>
        /// <returns>Plain text.</returns>
        public static string MarkdownToPlainText(string markdown)
        {
            var document = Markdown.Parse(markdown, _pipeline);

            var sb = new StringBuilder();
            BuildPlainText(document, sb);
            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// Parses the given markdown string into a Markdig MarkdownDocument AST,
        /// using the configured pipeline.
        /// </summary>
        /// <param name="markdown">The markdown text to parse.</param>
        /// <returns>The parsed <see cref="MarkdownDocument"/> object.</returns>
        internal static MarkdownDocument Parse(string markdown)
        {
            var document = Markdown.Parse(markdown, _pipeline);
            return document;
        }

        /// <summary>
        /// Recursively traverses block-level nodes and appends plain text.
        /// </summary>
        private static void BuildPlainText(Block block, StringBuilder sb)
        {
            switch (block)
            {
                case FencedCodeBlock fenced:
                    string language = fenced.Info;
                    string code = fenced.Lines.ToString();
                    sb.Append(language).Append("\n").Append(code).Append("\n");
                    break;

                case LeafBlock leaf:
                    if (leaf.Inline != null)
                    {
                        if (block is ParagraphBlock && block.Parent is ListItemBlock listItem)
                        {
                            if (listItem.Parent is ListBlock listBlock && listBlock.IsOrdered)
                            {
                                int index = listBlock.IndexOf(listItem);
                                int start = int.TryParse(listBlock.OrderedStart?.ToString(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var s) ? s : 1;
                                int number = start + index;
                                sb.Append(number).Append(". ").Append(GetInlinePlainText(leaf.Inline));
                            }
                            else
                            {
                                sb.Append(GetInlinePlainText(leaf.Inline));
                            }
                        }
                        else
                        {
                            sb.Append(GetInlinePlainText(leaf.Inline));
                        }
                    }
                    sb.Append('\n');
                    break;

                case ContainerBlock container:
                    foreach (var child in container)
                        BuildPlainText(child, sb);
                    break;

                default:
                    sb.Append('\n'); // fallback
                    break;
            }
        }

        /// <summary>
        /// Recursively extracts plain text from an inline container.
        /// </summary>
        private static string GetInlinePlainText(ContainerInline inline)
        {
            if (inline == null) return string.Empty;
            var sb = new StringBuilder();
            foreach (var child in inline)
            {
                switch (child)
                {
                    case LiteralInline literal:
                        var slice = literal.Content;
                        sb.Append(slice.Text.Substring(slice.Start, slice.Length));
                        break;

                    case EmphasisInline emphasis:
                        sb.Append(GetInlinePlainText(emphasis));
                        break;

                    case CodeInline code:
                        sb.Append(code.Content);
                        break;

                    case LineBreakInline:
                        sb.Append('\n');
                        break;

                    case LinkInline link:
                        var label = GetInlinePlainText(link);
                        sb.Append(label).Append(" [").Append(link.Url).Append("]");
                        break;

                    case ContainerInline container:
                        sb.Append(GetInlinePlainText(container));
                        break;
                }
            }
            return sb.ToString();
        }
    }
}

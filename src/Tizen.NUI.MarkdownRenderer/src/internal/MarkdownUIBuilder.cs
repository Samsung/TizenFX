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
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Text;

using Markdig;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using Markdig.Extensions.Tables;

namespace Tizen.NUI.MarkdownRenderer
{
    /// <summary>
    /// Indent for log.
    /// </summary>
    internal class Indent
    {
        // level 0 ~ 6
        private static readonly string[] indent = new[] {"", "  ", "    ", "      ", "        ", "         "};
        public static string Get(int level)
        {
            return level >= 0 && level < indent.Length ? indent[level] : indent[^1];
        }
    }

    /// <summary>
    /// MarkdownUIBuilder.
    /// </summary>
    internal class MarkdownUIBuilder
    {
        private MarkdownStyle style;
        private List<View> uiBlocks;

        public MarkdownUIBuilder(MarkdownStyle markdownStyle)
        {
            style = markdownStyle;

            Initialize();
        }

        public void Clear()
        {
            for (int i = 0 ; i < uiBlocks.Count ; i ++)
            {
                uiBlocks[i].Dispose();
            }
            uiBlocks.Clear();
        }

        public void Build(Block block, View parent, int indent)
        {
            if (block is LeafBlock leafBlock)
            {
                Tizen.Log.Info("NUI", $"{Indent.Get(indent)}[{indent}][{block.GetType().Name}] : LeafBlock\n");

                var text = leafBlock.Inline is null ? String.Empty : GetInlineText(leafBlock.Inline);
                AddBlockToUI(block, parent, text, indent);
            }
            else if (block is ContainerBlock containerBlock)
            {
                Tizen.Log.Info("NUI", $"{Indent.Get(indent)}[{indent}][{block.GetType().Name}] : ContainerBlock\n");

                var container = NewContainer(block);
                parent.Add(container);

                foreach (var subBlock in containerBlock)
                {
                    Build(subBlock, container, indent + 1);
                }
            }
            else
            {
                // Something wrong.
                Tizen.Log.Info("NUI", $"{Indent.Get(indent)}[{indent}][{block.GetType().Name}] : UnknownBlock\n");
            }
        }

        private void Initialize()
        {
            uiBlocks = new List<View>();
        }

        private string GetInlineText(ContainerInline inline)
        {
            var result = new StringBuilder();
            foreach (var child in inline)
            {
                switch (child)
                {
                    case LiteralInline literal:
                        result.Append(literal.Content.Text.Substring(literal.Content.Start, literal.Content.Length));
                        break;

                    case EmphasisInline emphasis:
                        var content = GetInlineText(emphasis);
                        if(emphasis.DelimiterChar == '~')
                        {
                            result.Append(emphasis.DelimiterCount == 2 ? $"<s>{content}</s>" : $"{content}");
                        }
                        else
                        {
                            // '*', '**'
                            result.Append(emphasis.DelimiterCount == 2 ? $"<b>{content}</b>" : $"<i>{content}</i>");
                        }
                        break;

                    case CodeInline code:
                        result.Append($"<font family='{style.Code.FontFamily}'>{code.Content}</font>");
                        break;

                    case LineBreakInline:
                        result.AppendLine();
                        break;

                    case LinkInline link:
                        var label = GetInlineText(link);
                        result.Append($"<a href='{link.Url}'>{label}</a>");
                        break;

                    default: // fallback
                        if (child is ContainerInline container)
                            result.Append(GetInlineText(container));
                        break;
                }
            }
            return result.ToString();
        }

        private void AddBlockToUI(Block block, View parent, string text, int indent)
        {
            if (block is HeadingBlock heading)
            {
                Tizen.Log.Info("NUI", $"{Indent.Get(indent)}└[{indent}][HeadingBlock][{heading.Level}] Text:{text}\n");
                parent.Add(NewHeading(text, heading.Level));
            }
            else if (block is ParagraphBlock)
            {
                Tizen.Log.Info("NUI", $"{Indent.Get(indent)}└[{indent}][ParagraphBlock] Text:{text}\n");
                parent.Add(NewParagraph(text));
            }
            else if (block is ThematicBreakBlock)
            {
                Tizen.Log.Info("NUI", $"{Indent.Get(indent)}└[{indent}][ThematicBreakBlock] Text:{text}\n");
                parent.Add(NewThematicBreak());
            }
            else if (block is FencedCodeBlock fenced)
            {
                Tizen.Log.Info("NUI", $"{Indent.Get(indent)}└[{indent}][FencedCodeBlock] Text:{text}\n");
                string language = fenced.Info;
                string code = fenced.Lines.ToString();
                parent.Add(NewCode(language, code));
            }
            else
            {
                Tizen.Log.Info("NUI", $"{Indent.Get(indent)}└[{indent}][UnknownBlock:{block.GetType().Name}] Text:{text}\n");
                parent.Add(NewParagraph(text));
            }
        }

        private View NewContainer(Block block)
        {
            if (block is MarkdownDocument)
            {
                return NewBase();
            }
            if (block is QuoteBlock)
            {
                return NewQuote();
            }
            else if (block is ListBlock)
            {
                return NewList();
            }
            else if (block is ListItemBlock)
            {
                return NewListItem();
            }
            else if (block is Table)
            {
                return NewTable();
            }
            else if (block is TableRow)
            {
                return NewTableRow();
            }
            else if (block is TableCell)
            {
                return NewTableItem();
            }
            else
            {
                return NewBase();
            }
        }

        private View NewCode(string language, string text)
        {
            var code = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Transparent,
                Margin = new Extents(0, 0, (ushort)style.Common.Margin, (ushort)style.Common.Margin),
            };

            var title = new TextLabel
            {
                Text = language,
                FontFamily = style.Code.TitleFontFamily,
                PixelSize = style.Code.TitleFontSize,
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                TextColor = new Color(style.Code.TitleFontColor),
                BackgroundColor = new Color(style.Code.TitleBackgroundColor),
                Padding = new Extents((ushort)style.Code.Padding),
            };
            code.Add(title);

            var label = new TextLabel
            {
                Text = text,
                FontFamily = style.Code.FontFamily,
                PixelSize = style.Code.FontSize,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                TextColor = new Color(style.Code.FontColor),
                BackgroundColor = new Color(style.Code.BackgroundColor),
                Padding = new Extents((ushort)style.Code.Padding),
            };
            code.Add(label);

            uiBlocks.Add(code);
            uiBlocks.Add(title);
            uiBlocks.Add(label);

            return code;
        }

        private View NewBase()
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Transparent,
                Padding = new Extents((ushort)style.Common.Padding),
            };
            uiBlocks.Add(view);
            return view;
        }

        private View NewTable()
        {
            var table = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Transparent,
                Margin = new Extents(0, 0, (ushort)style.Common.Margin, (ushort)style.Common.Margin),
            };
            uiBlocks.Add(table);
            return table;
        }

        private View NewTableRow()
        {
            var item = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Transparent,
                BorderlineWidth = style.Table.BorderThickness,
                BorderlineColor = new Color(style.Table.BorderColor),
            };
            uiBlocks.Add(item);
            return item;
        }

        private View NewTableItem()
        {
            var item = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Transparent,
                Padding = new Extents((ushort)style.Table.Padding),
            };
            uiBlocks.Add(item);
            return item;
        }

        private View NewList()
        {
            var list = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Transparent,
                Margin = new Extents(0, 0, (ushort)style.Common.Margin, (ushort)style.Common.Margin),
            };
            uiBlocks.Add(list);
            return list;
        }

        private View NewListItem()
        {
            var item = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Transparent,
                Margin = new Extents((ushort)style.Common.Indent, 0, 0, 0),
            };
            uiBlocks.Add(item);
            return item;
        }

        private TextLabel NewHeading(string text, int level)
        {
            var heading = new TextLabel
            {
                Text = text,
                FontFamily = style.Heading.FontFamily,
                TextColor = new Color(style.Paragraph.FontColor),
                MultiLine = true,
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Transparent,
                Margin = new Extents(0, 0, (ushort)style.Common.Margin, (ushort)style.Common.Margin),
            };

            switch(level)
            {
                case 1:
                    heading.PixelSize = style.Heading.FontSizeLevel1;
                    break;
                case 2:
                    heading.PixelSize = style.Heading.FontSizeLevel2;
                    break;
                case 3:
                    heading.PixelSize = style.Heading.FontSizeLevel3;
                    break;
                case 4:
                    heading.PixelSize = style.Heading.FontSizeLevel4;
                    break;
                case 5:
                    heading.PixelSize = style.Heading.FontSizeLevel5;
                    break;
                default:
                    heading.PixelSize = style.Heading.FontSizeLevel1;
                    break;
            }
            uiBlocks.Add(heading);
            return heading;
        }

        private View NewQuote()
        {
            var view = new View
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = new Color(style.Quote.BackgroundColor),
                Padding = new Extents((ushort)style.Quote.Padding),
                Margin = new Extents((ushort)style.Common.Indent, 0, (ushort)style.Common.Margin, (ushort)style.Common.Margin),
            };
            uiBlocks.Add(view);
            return view;
        }

        private View NewThematicBreak()
        {
            var view = new View
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = style.ThematicBreak.Thickness,
                BackgroundColor = new Color(style.ThematicBreak.Color),
                Margin = new Extents(0, 0, (ushort)style.Common.Margin, (ushort)style.Common.Margin),
            };
            uiBlocks.Add(view);
            return view;
        }

        private TextLabel NewParagraph(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                FontFamily = style.Paragraph.FontFamily,
                PixelSize = style.Paragraph.FontSize,
                TextColor = new Color(style.Paragraph.FontColor),
                MinLineSize = style.Paragraph.LineHeight,
                MultiLine = true,
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                VerticalLineAlignment = VerticalLineAlignment.Center,
                BackgroundColor = Color.Transparent,
                AnchorColor = new Color(style.Link.Color),
                AnchorClickedColor = new Color(style.Link.VisitedColor),
            };
            uiBlocks.Add(label);
            return label;
        }
    }
}
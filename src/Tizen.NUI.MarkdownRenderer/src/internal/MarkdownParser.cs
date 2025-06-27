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

using Markdig;
using Markdig.Syntax;

namespace Tizen.NUI.MarkdownRenderer
{
    /// <summary>
    /// Provides a Markdown parser configured with custom pipeline options,
    /// enabling table support and enhanced emphasis handling for Tizen NUI markdown rendering.
    /// </summary>
    internal class MarkdownParser
    {
        private static readonly MarkdownPipeline pipeline = new MarkdownPipelineBuilder().UsePipeTables().UseEmphasisExtras().Build();

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownParser"/> class
        /// with a pipeline that supports pipe tables and emphasis extras.
        /// </summary>
        public MarkdownParser()
        {
        }

        /// <summary>
        /// Parses the given markdown string into a Markdig MarkdownDocument AST,
        /// using the configured pipeline.
        /// </summary>
        /// <param name="markdown">The markdown text to parse.</param>
        /// <returns>The parsed <see cref="MarkdownDocument"/> object.</returns>
        public MarkdownDocument Parse(string markdown)
        {
            var document = Markdown.Parse(markdown, pipeline);
            return document;
        }
    }
}

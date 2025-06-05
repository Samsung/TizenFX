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
    /// Provides a reusable NUI View for rendering Markdown text as UI components.
    /// Supports incremental UI updates, streaming input, and rich markdown features.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MarkdownRenderer : View
    {
        private MarkdownParser parser;
        private MarkdownUIBuilder builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownRenderer"/> class.
        /// </summary>
        public MarkdownRenderer() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Gets the style settings applied to the rendered Markdown UI.
        /// </summary>
        public MarkdownStyle Style { get; } = new MarkdownStyle();

        /// <summary>
        /// Parses and renders the specified markdown string, updating the UI.
        /// Automatically reuses or disposes of views for efficient updates.
        /// </summary>
        /// <param name="markdown">The markdown text to render.</param>
        public void Render(string markdown)
        {
            var document = parser.Parse(markdown);

            builder.Build(document, this, "root");
            builder.RemoveUnusedUI();
        }

        /// <summary>
        /// Disposes all rendered views and clears the internal UI builder state.
        /// </summary>
        public void Clear()
        {
            builder.Clear();
        }

        /// <summary>
        /// Initializes layout, parser, and UI builder components for rendering.
        /// </summary>
        private void Initialize()
        {
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Begin,
            };
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;
            BackgroundColor = Color.Transparent;

            parser = new MarkdownParser();
            builder = new MarkdownUIBuilder(Style);
        }
    }
}
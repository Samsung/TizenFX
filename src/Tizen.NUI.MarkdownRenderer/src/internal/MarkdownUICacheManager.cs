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
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using Markdig.Syntax;
using Markdig.Syntax.Inlines;

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.MarkdownRenderer
{
    /// <summary>
    /// Manages view caching for incremental UI updates in Markdown rendering.
    /// Generates unique cache keys per block and provides
    /// cache lifecycle management (add, lookup, visit, purge, clear).
    /// </summary>
    internal class MarkdownUICacheManager
    {
        private Dictionary<string, View> cache = new();
        private HashSet<string> visited = new();

        /// <summary>
        /// Adds or updates a cached view for the given key.
        /// </summary>
        /// <param name="key">Unique cache key (generated from block + path)</param>
        /// <param name="view">View instance to cache</param>
        public void Add(string key, View view)
        {
            cache[key] = view;
        }

        /// <summary>
        /// Looks up a cached view for the given key, or null if not present.
        /// </summary>
        /// <param name="key">Unique cache key</param>
        /// <returns>Cached view, or null if not found</returns>
        public View Get(string key)
        {
            cache.TryGetValue(key, out var view);
            return view;
        }

        /// <summary>
        /// Marks the given cache key as "visited" in the current build pass.
        /// </summary>
        /// <param name="key">Cache key for the visited block</param>
        public void MarkVisited(string key)
        {
            visited.Add(key);
        }

        /// <summary>
        /// Disposes and removes any cached views that were not visited in the latest build pass.
        /// Clears the "visited" set afterwards.
        /// </summary>
        public void RemoveUnusedViews()
        {
            foreach (var key in cache.Keys.ToList())
            {
                if (!visited.Contains(key))
                {
                    var view = cache[key];
                    view?.DisposeRecursively();
                    cache.Remove(key);
                }
            }
            visited.Clear();
        }

        /// <summary>
        /// Disposes all cached views and clears the cache and visited sets.
        /// </summary>
        public void Clear()
        {
            foreach (var view in cache.Values)
                view.Dispose();

            cache.Clear();
            visited.Clear();
        }

        /// <summary>
        /// Generates a unique cache key for a given block and logical path.
        /// Uses block type, tree path, and block text content hash for stability.
        /// </summary>
        /// <param name="block">Markdown block</param>
        /// <param name="path">Logical path in the block tree (e.g. "root/0/1")</param>
        /// <returns>Unique string key for caching</returns>
        public string CreateKey(Block block, string path)
        {
            string type = block.GetType().Name;
            string hash = "";

            if (block is FencedCodeBlock fenced)
            {
                string language = fenced.Info;
                string code = fenced.Lines.ToString();
                hash = ComputeHash(language + code);
            }
            else if (block is LeafBlock leaf)
            {
                hash = ComputeHash(GetInlineText(leaf.Inline));
            }

            return $"{path}-{type}-{hash}";
        }

        /// <summary>
        /// Generates a stable hash string from text (SHA1, hex-encoded).
        /// </summary>
        /// <param name="text">Input text to hash</param>
        /// <returns>SHA1 hex string</returns>
        private string ComputeHash(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            using var sha1 = SHA1.Create();
            var bytes = Encoding.UTF8.GetBytes(text);
            var hash = sha1.ComputeHash(bytes);
            return Convert.ToHexString(hash);
        }

        /// <summary>
        /// Extracts plain text from a Markdig inline tree (for hash/key generation).
        /// Ignores styling/markup but preserves code, link (as text:url), and line breaks.
        /// </summary>
        /// <param name="inline">Root inline node</param>
        /// <returns>Flattened plain text</returns>
        private string GetInlineText(ContainerInline inline)
        {
            if (inline == null) return string.Empty;
            var sb = new StringBuilder();
            foreach (var child in inline)
            {
                switch (child)
                {
                    case LiteralInline literal:
                        sb.Append(literal.Content.Text, literal.Content.Start, literal.Content.Length);
                        break;

                    case EmphasisInline emphasis:
                        sb.Append(GetInlineText(emphasis));
                        break;

                    case CodeInline code:
                        sb.Append(code.Content);
                        break;

                    case LineBreakInline:
                        sb.AppendLine();
                        break;

                    case LinkInline link:
                        sb.Append($"{GetInlineText(link)}:{link.Url}");
                        break;

                    default: // fallback
                        if (child is ContainerInline container)
                            sb.Append(GetInlineText(container));
                        break;
                }
            }
            return sb.ToString();
        }
    }
}

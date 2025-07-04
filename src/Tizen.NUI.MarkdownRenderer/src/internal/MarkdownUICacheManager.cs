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
                view?.DisposeRecursively();

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
            return $"{path}-{block.GetType().Name}";
        }

        /// <summary>
        /// Computes a non-cryptographic 32-bit FNV-1a hash for the given string.
        /// Fast and simple, ideal for cache keys or non-security purposes.
        /// Reference: http://isthe.com/chongo/tech/comp/fnv/
        /// </summary>
        /// <param name="text">Input string to hash. Null or empty returns an empty string.</param>
        /// <returns>8-digit hex string representing the FNV-1a 32-bit hash of the input.</returns>
        public string ComputeHash(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            unchecked
            {
                const uint fnvPrime = 0x01000193;
                uint hash = 0x811C9DC5;
                foreach (char c in text)
                {
                    hash ^= c;
                    hash *= fnvPrime;
                }
                return hash.ToString("X8");
            }
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
                        sb.Append(GetInlineText(link)).Append(':').Append(link.Url);
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

/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
#if DEBUG

using System.Collections.Generic;

namespace Tizen.NUI
{
    /// <summary>
    /// This is a helper class to test external theme applying.
    /// </summary>
    internal class DictionaryExternalTheme : IExternalTheme
    {
        private readonly Dictionary<string, string> theme;

        public DictionaryExternalTheme(string id, string version, Dictionary<string, string> theme)
        {
            Id = id;
            Version = version;
            this.theme = theme;
        }

        public string Id { get; }

        public string Version { get; }

        public string GetValue(string key)
        {
            theme.TryGetValue(key, out string extracted);

            return extracted;
        }
    }
}
#endif

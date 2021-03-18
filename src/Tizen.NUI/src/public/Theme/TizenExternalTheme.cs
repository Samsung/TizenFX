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

using System;
using System.Diagnostics.CodeAnalysis;

namespace Tizen.NUI
{
    /// <summary>
    /// This is a wrapper to express tizen-theme-manager's theme.
    /// </summary>
    internal class TizenExternalTheme : IExternalTheme
    {
        private const string prefix = "/theme/";
        private readonly Tizen.Applications.ThemeManager.Theme theme;

        internal TizenExternalTheme(Tizen.Applications.ThemeManager.Theme theme)
        {
            this.theme = theme;
        }

        public string Id
        {
            get => theme.Id;
        }

        public string Version
        {
            get => theme.Version;
        }

        [SuppressMessage("Microsoft.Design", "CA1031: Do not catch general exception types", Justification = "This method is to handle external resources that may throw an exception but ignorable. This method should not interrupt the main stream.")]
        public string GetValue(string key)
        {
            string themeKey = prefix + key;
            string extracted = null;

            try
            {
                if (theme.HasKey(themeKey))
                {
                    extracted = theme.GetString(themeKey);
                }
            }
            catch (Exception e)
            {
                Tizen.Log.Error("NUI", $"{e.GetType().Name} occurred while getting value from {theme.GetType().FullName}: {e.Message}");
            }

            return extracted;
        }
    }
}

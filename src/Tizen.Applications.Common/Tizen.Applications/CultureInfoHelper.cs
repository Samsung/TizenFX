/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using Tizen;

namespace Tizen.Applications
{
    internal static class CultureInfoHelper
    {
        private const string LogTag = "Tizen.Applications";
        private static bool _initialized = false;
        private static readonly Dictionary<string, string> _cultureNames = new Dictionary<string, string>();
        private static readonly object _lock = new object();
        private const string _pathCultureInfoXml = "/usr/share/dotnet.tizen/framework/i18n/CultureInfo.xml";
        private static readonly CultureInfo _cultureInfo = new CultureInfo("en-US");

        public static void Initialize()
        {
            if (File.Exists(_pathCultureInfoXml))
            {
                try
                {
                    ParseCultureInfoXml();
                }
                catch
                {
                    Log.Warn(LogTag, "Failed to parse CultureInfo.xml");
                }
            }

            _initialized = true;
        }

        private static void ParseCultureInfoXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_pathCultureInfoXml);
            XmlElement root = doc.DocumentElement;
            foreach (XmlElement node in root.ChildNodes)
            {
                if (node.Name != "name" && node.FirstChild == null)
                {
                    continue;
                }

                string lang = node.GetAttribute("xml:lang");
                string cultureName = node.FirstChild.Value;
                if (!string.IsNullOrEmpty(lang) && !string.IsNullOrEmpty(cultureName))
                {
                    try
                    {
                        _cultureNames.Add(lang, cultureName);
                    }
                    catch (ArgumentException e)
                    {
                        Log.Error(LogTag, "ArgumentException: " + e.Message);
                    }
                }
            }
        }

        public static string GetCultureName(string locale)
        {
            lock (_lock)
            {
                if (!_initialized)
                {
                    Initialize();
                }

                if (_cultureNames.TryGetValue(locale.ToLower(_cultureInfo), out string cultureName))
                {
                    return cultureName;
                }
            }

            return string.Empty;
        }
    }
}

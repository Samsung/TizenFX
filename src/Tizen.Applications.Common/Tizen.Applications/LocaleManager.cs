/*
 * Copyright (c) 2025 Samsung Electronics Co., Ltd.
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Tizen.Applications
{
    /// <summary>
    /// The class for managing the app's locale.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class LocaleManager
    {
        private static readonly string LogTag = "Tizen.Applications";
        private static readonly string SupportedLocalesFilePath = "/usr/share/i18n/SUPPORTED";
        private static bool _fileExists = File.Exists(SupportedLocalesFilePath);
        private static HashSet<string> _supportedLocales;

        /// <summary>
        /// Set the application's language independently of the system language.
        /// </summary>
        /// <remarks>
        /// If a device does not support the language , It will be set to the default language(en_US.UTF-8)
        /// </remarks>
        /// <param name="info">The locale to set language</param>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetApplicationLocale(CultureInfo info)
        {
            if (!_fileExists)
            {
                Log.Error(LogTag, $"{SupportedLocalesFilePath} not found");
                return;
            }
            var converter = new SystemLocaleConverter();
            string convertedLocale = converter.Convert(info);

            if (VerifySupportedLocale(convertedLocale))
            {
                Interop.AppCommon.AppCommonErrorCode ret = Interop.AppCommon.AppLocaleManagerSetLanguage(convertedLocale);
                if (ret != Interop.AppCommon.AppCommonErrorCode.None)
                {
                    Interop.AppCommon.AppLocaleManagerSetLanguage("en_US.UTF-8");
                }
            }
            else
            {
                Log.Error(LogTag, $"Unsupported Language : {info.Name}");
            }
        }

        /// <summary>
        /// Get the application's language
        /// </summary>
        /// <returns>CultureInfo corresponding to the application language</returns>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CultureInfo GetApplicationLocale()
        {
            IntPtr langPtr = IntPtr.Zero;

            try
            {
                Interop.AppCommon.AppCommonErrorCode ret = Interop.AppCommon.AppLocaleManagerGetLanguage(out langPtr);

                if (ret != Interop.AppCommon.AppCommonErrorCode.None || langPtr == IntPtr.Zero)
                {
                    Log.Error(LogTag, $"Failed to get application language. Result: {ret}");
                    return null;
                }

                string language = Marshal.PtrToStringAnsi(langPtr);
                if (string.IsNullOrEmpty(language))
                {
                    Log.Warn(LogTag, "Retrieved application language is null or empty.");
                    return null;
                }

                var converter = new SystemLocaleConverter();
                return converter.Convert(language);
            }
            finally
            {
                if (langPtr != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(langPtr);
                }
            }
        }

        /// <summary>
        /// Get the system's language
        /// </summary>
        /// <returns>CultureInfo corresponding to the system language</returns>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CultureInfo GetSystemLocale()
        {
            IntPtr langPtr = IntPtr.Zero;

            try
            {
                Interop.AppCommon.AppCommonErrorCode ret = Interop.AppCommon.AppLocaleManagerGetSystemLanguage(out langPtr);

                if (ret != Interop.AppCommon.AppCommonErrorCode.None || langPtr == IntPtr.Zero)
                {
                    Log.Error(LogTag, $"Failed to get system language. Result: {ret}");
                    return null;
                }

                string language = Marshal.PtrToStringAnsi(langPtr);
                if (string.IsNullOrEmpty(language))
                {
                    Log.Warn(LogTag, "Retrieved System language is null or empty.");
                    return null;
                }

                var converter = new SystemLocaleConverter();
                return converter.Convert(language);
            }
            finally
            {
                if(langPtr != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(langPtr);
                }
            }
        }

        internal static void SetCurrentCultureInfo(string locale)
        {
            var converter = new SystemLocaleConverter();
            CultureInfo cultureInfo = converter.Convert(locale);
            if (cultureInfo != null)
            {
                CultureInfo.CurrentCulture = cultureInfo;
            }
            else
            {
                Log.Error(LogTag, $"CultureInfo is null. locale: {locale}");
            }
        }

        internal static void SetCurrentUICultureInfo(string locale)
        {
            var converter = new SystemLocaleConverter();
            CultureInfo cultureInfo = converter.Convert(locale);
            if (cultureInfo != null)
            {
                CultureInfo.CurrentUICulture = cultureInfo;
            }
            else
            {
                Log.Error(LogTag, $"CultureInfo is null. locale: {locale}");
            }
        }

        private static bool VerifySupportedLocale(string locale)
        {
            if (_supportedLocales == null)
            {
                LoadSupportedLocales();
            }

            return _supportedLocales.Contains(locale);
        }

        /// <summary>
        /// Parses a line from the SUPPORTED file and formats it into "{language}_{country}.{encoding}".
        /// The input lineParts can be:
        /// 1. ["{localeString}", "{encodingString}"] e.g., ["en_US", "UTF-8"]
        /// 2. ["{localeString}"] e.g., ["ko_KR"] (encoding will default to UTF-8)
        /// The localeString itself might contain an encoding, e.g., "ko_KR.UTF-8", which will be stripped.
        /// </summary>
        /// <param name="lineParts">Array of strings from splitting a line by space.</param>
        /// <returns>Formatted locale string or null if parsing fails.</returns>
        private static string ParseAndFormatLocaleLine(string[] lineParts)
        {
            if (lineParts == null || lineParts.Length == 0 || string.IsNullOrWhiteSpace(lineParts[0]))
            {
                return null;
            }

            string localeString = lineParts[0];
            string encodingString;

            if (lineParts.Length == 2)
            {
                encodingString = lineParts[1];
            }
            else
            {
                encodingString = Encoding.UTF8.BodyName;
            }

            int dotIndex = localeString.IndexOf('.');
            if (dotIndex != -1)
            {
                localeString = localeString[..dotIndex];
            }

            if (string.IsNullOrWhiteSpace(localeString) || string.IsNullOrWhiteSpace(encodingString))
            {
                return null;
            }

            return $"{localeString}.{encodingString}";
        }

        private static void LoadSupportedLocales()
        {
            _supportedLocales = File.ReadAllLines(SupportedLocalesFilePath)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                .Select(lineParts => ParseAndFormatLocaleLine(lineParts))
                .Where(formattedLocale => formattedLocale != null)
                .ToHashSet();
        }
    }
}

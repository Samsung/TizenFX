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
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Applications
{
    internal class SystemLocaleConverter
    {
        private static readonly string LogTag = "Tizen.Applications";
        public SystemLocaleConverter()
        {
        }

        public CultureInfo Convert(string locale)
        {
            ULocale pLocale = new ULocale(locale);
            string cultureName = CultureInfoHelper.GetCultureName(pLocale.Locale.Replace("_", "-"));

            if (!string.IsNullOrEmpty(cultureName))
            {
                try
                {
                    return new CultureInfo(cultureName);
                }
                catch (CultureNotFoundException)
                {
                    Log.Error(LogTag, "CultureNotFoundException occurs. CultureName: " + cultureName);
                }
            }

            try
            {
                return new CultureInfo(pLocale.LCID);
            }
            catch (ArgumentOutOfRangeException)
            {
                return GetFallback(pLocale);
            }
            catch (CultureNotFoundException)
            {
                return GetFallback(pLocale);
            }
        }

        public string Convert(CultureInfo cultureInfo)
        {
            if (cultureInfo == null || string.IsNullOrEmpty(cultureInfo.Name))
            {
                return string.Empty;
            }
            return $"{cultureInfo.Name.Replace("-", "_")}.UTF-8";
        }

        private CultureInfo GetFallback(ULocale uLocale)
        {
            CultureInfo fallbackCultureInfo = null;
            string locale = string.Empty;

            if (uLocale.Locale != null)
            {
                locale = uLocale.Locale.Replace("_", "-");
                fallbackCultureInfo = GetCultureInfo(locale);
            }

            if (fallbackCultureInfo == null && uLocale.Language != null && uLocale.Script != null && uLocale.Country != null)
            {
                locale = uLocale.Language + "-" + uLocale.Script + "-" + uLocale.Country;
                fallbackCultureInfo = GetCultureInfo(locale);
            }

            if (fallbackCultureInfo == null && uLocale.Language != null && uLocale.Script != null)
            {
                locale = uLocale.Language + "-" + uLocale.Script;
                fallbackCultureInfo = GetCultureInfo(locale);
            }

            if (fallbackCultureInfo == null && uLocale.Language != null && uLocale.Country != null)
            {
                locale = uLocale.Language + "-" + uLocale.Country;
                fallbackCultureInfo = GetCultureInfo(locale);
            }

            if (fallbackCultureInfo == null && uLocale.Language != null)
            {
                locale = uLocale.Language;
                fallbackCultureInfo = GetCultureInfo(locale);
            }

            if (fallbackCultureInfo == null)
            {
                try
                {
                    fallbackCultureInfo = new CultureInfo("en");
                }
                catch (CultureNotFoundException e)
                {
                    Log.Error(LogTag, "Failed to create CultureInfo. err = " + e.Message);
                }
            }

            return fallbackCultureInfo;
        }

        private CultureInfo GetCultureInfo(string locale)
        {
            if (!Exist(locale))
            {
                return null;
            }

            try
            {
                return new CultureInfo(locale);
            }
            catch (CultureNotFoundException)
            {
                return null;
            }
        }

        private bool Exist(string locale)
        {
            foreach (var cultureInfo in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                if (cultureInfo.Name == locale)
                {
                    return true;
                }
            }
            return false;
        }


        internal class ULocale
        {
            private const int ULOC_FULLNAME_CAPACITY = 157;
            private const int ULOC_LANG_CAPACITY = 12;
            private const int ULOC_SCRIPT_CAPACITY = 6;
            private const int ULOC_COUNTRY_CAPACITY = 4;
            private const int ULOC_VARIANT_CAPACITY = ULOC_FULLNAME_CAPACITY;
            private string locale;
            private string _locale;
            private string _language;
            private string _script;
            private string _country;
            private string _variant;
            private int _lcid;

            internal ULocale(string locale)
            {
                this.locale = locale;
                _locale = _language = _script = _country = _variant = null;
                _lcid = -1;
            }

            internal string Locale
            {
                get
                {
                    if (string.IsNullOrEmpty(_locale))
                    {
                        _locale = Canonicalize(locale);
                    }
                    return _locale;
                }
                private set 
                {
                    _locale = value;
                } 
            }
            internal string Language {
                get
                {
                    if (string.IsNullOrEmpty(_language))
                    {
                        _language = GetLanguage(locale);
                    }
                    return _language;
                }
                private set
                {
                    _language = value;
                } 
            }
            internal string Script
            {
                get
                {
                    if (string.IsNullOrEmpty(_script))
                    {
                        _script = GetScript(locale);
                    }
                    return _script;
                }
                private set
                {
                    _script = value;
                }
            }
            internal string Country {
                get
                {
                    if (string.IsNullOrEmpty(_country))
                    {
                        _country = GetCountry(locale);
                    }
                    return _country;
                }
                private set
                {
                    _country = value;
                }
            }
            internal string Variant
            {
                get
                {
                    if (string.IsNullOrEmpty(_variant))
                    {
                        _variant = GetVariant(locale);
                    }
                    return _variant;
                }
                private set
                {
                    _variant = value;
                }
            }
            internal int LCID { 
                get
                {
                    if (_lcid == -1) {
                        _lcid = GetLCID(locale);
                    }
                    return _lcid;
                }
                private set {
                    _lcid = value;
                }
            }

            private string Canonicalize(string localeName)
            {
                // Get the locale name from ICU
                StringBuilder sb = new StringBuilder(ULOC_FULLNAME_CAPACITY);
                if (Interop.BaseUtilsi18n.Canonicalize(localeName, sb, sb.Capacity) <= 0)
                {
                    return null;
                }

                return sb.ToString();
            }

            private string GetLanguage(string locale)
            {
                // Get the language name from ICU
                StringBuilder sb = new StringBuilder(ULOC_LANG_CAPACITY);
                if (Interop.BaseUtilsi18n.GetLanguage(locale, sb, sb.Capacity, out int bufSizeLanguage) != 0)
                {
                    return null;
                }

                return sb.ToString();
            }

            private string GetScript(string locale)
            {
                // Get the script name from ICU
                StringBuilder sb = new StringBuilder(ULOC_SCRIPT_CAPACITY);
                if (Interop.BaseUtilsi18n.GetScript(locale, sb, sb.Capacity) <= 0)
                {
                    return null;
                }

                return sb.ToString();
            }

            private string GetCountry(string locale)
            {
                int err = 0;

                // Get the country name from ICU
                StringBuilder sb = new StringBuilder(ULOC_COUNTRY_CAPACITY);
                if (Interop.BaseUtilsi18n.GetCountry(locale, sb, sb.Capacity, out err) <= 0)
                {
                    return null;
                }

                return sb.ToString();
            }

            private string GetVariant(string locale)
            {
                // Get the variant name from ICU
                StringBuilder sb = new StringBuilder(ULOC_VARIANT_CAPACITY);
                if (Interop.BaseUtilsi18n.GetVariant(locale, sb, sb.Capacity) <= 0)
                {
                    return null;
                }

                return sb.ToString();
            }

            private int GetLCID(string locale)
            {
                // Get the LCID from ICU
                uint lcid = Interop.BaseUtilsi18n.GetLCID(locale);
                return (int)lcid;
            }

            internal static string GetDefaultLocale()
            {
                IntPtr stringPtr = Interop.Libc.GetEnvironmentVariable("LANG");
                if (stringPtr == IntPtr.Zero)
                {
                    return string.Empty;
                }

                return Marshal.PtrToStringAnsi(stringPtr);
            }
        }
    }
}

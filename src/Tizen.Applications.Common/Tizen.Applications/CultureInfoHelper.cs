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
using System.Runtime.InteropServices;

namespace Tizen.Applications
{
    internal static class CultureInfoHelper
    {
        private const string LogTag = "Tizen.Applications";
        private const string _pathCultureInfoIni = "/usr/share/dotnet.tizen/framework/i18n/CultureInfo.ini";

        public static string GetCultureName(string locale)
        {
            Log.Error(LogTag, "[__DEBUG__] BEGIN");
            IntPtr dictionary = Interop.LibIniParser.Load(_pathCultureInfoIni);
            if (dictionary == IntPtr.Zero)
            {
                Log.Error(LogTag, "[__DEBUG__] END");
                return string.Empty;
            }

            string cultureName = string.Empty;
            string key = "CultureInfo:" + locale.ToLowerInvariant();
            IntPtr value = Interop.LibIniParser.GetString(dictionary, key, IntPtr.Zero);
            if (value != IntPtr.Zero)
            {
                cultureName = Marshal.PtrToStringAnsi(value);
            }

            Interop.LibIniParser.FreeDict(dictionary);
            Log.Warn(LogTag, locale + " : " + cultureName);
            Log.Error(LogTag, "[__DEBUG__] END");
            return cultureName;
        }
    }
}

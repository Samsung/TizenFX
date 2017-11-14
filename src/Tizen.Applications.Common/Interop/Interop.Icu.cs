/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using Tizen.Applications;

internal static partial class Interop
{
    internal static partial class Icu
    {
        [DllImport(Libraries.Icuuc, EntryPoint = "uloc_canonicalize")]
        internal static extern Int32 Canonicalize(string localeID, [Out] StringBuilder name, Int32 nameCapacity, out int err);

        [DllImport(Libraries.Icuuc, EntryPoint = "uloc_getLanguage")]
        internal static extern Int32 GetLanguage(string localeID, [Out] StringBuilder language, Int32 languageCapacity, out int err);

        [DllImport(Libraries.Icuuc, EntryPoint = "uloc_getScript")]
        internal static extern Int32 GetScript(string localeID, [Out] StringBuilder script, Int32 scriptCapacity, out int err);

        [DllImport(Libraries.Icuuc, EntryPoint = "uloc_getCountry")]
        internal static extern Int32 GetCountry(string localeID, [Out] StringBuilder country, Int32 countryCapacity, out int err);

        [DllImport(Libraries.Icuuc, EntryPoint = "uloc_getVariant")]
        internal static extern Int32 GetVariant(string localeID, [Out] StringBuilder variant, Int32 variantCapacity, out int err);
    }
}

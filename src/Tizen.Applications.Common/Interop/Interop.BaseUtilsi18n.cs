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
    internal static partial class BaseUtilsi18n
    {
        [DllImport(Libraries.BaseUtilsi18n, EntryPoint = "i18n_ulocale_canonicalize")]
        internal static extern Int32 Canonicalize(string localeID, [Out] StringBuilder name, Int32 nameCapacity);
        // int32_t i18n_ulocale_canonicalize(const char *locale_id, char *name, int32_t name_capacity);c

        [DllImport(Libraries.BaseUtilsi18n, EntryPoint = "i18n_ulocale_get_language")]
        internal static extern int GetLanguage(string localeID, [Out] StringBuilder language, Int32 languageCapacity, out int bufSizeLanguage);
        // int i18n_ulocale_get_language(const char *locale_id, char *language, int32_t language_capacity, int32_t *buf_size_language);

        [DllImport(Libraries.BaseUtilsi18n, EntryPoint = "i18n_ulocale_get_script")]
        internal static extern Int32 GetScript(string localeID, [Out] StringBuilder script, Int32 scriptCapacity);
        // int32_t i18n_ulocale_get_script(const char *locale_id, char *script, int32_t script_capacity);

        [DllImport(Libraries.BaseUtilsi18n, EntryPoint = "i18n_ulocale_get_country")]
        internal static extern Int32 GetCountry(string localeID, [Out] StringBuilder country, Int32 countryCapacity, out int err);
        // int32_t i18n_ulocale_get_country(const char *locale_id, char *country, int32_t country_capacity, int *error);

        [DllImport(Libraries.BaseUtilsi18n, EntryPoint = "i18n_ulocale_get_variant")]
        internal static extern Int32 GetVariant(string localeID, [Out] StringBuilder variant, Int32 variantCapacity);
        // int32_t i18n_ulocale_get_variant(const char *locale_id, char *variant, int32_t variant_capacity);

        [DllImport(Libraries.BaseUtilsi18n, EntryPoint = "i18n_ulocale_get_lcid")]
        internal static extern UInt32 GetLCID(string localeID);
        // uint32_t i18n_ulocale_get_lcid(const char *locale_id);

        [DllImport(Libraries.BaseUtilsi18n, EntryPoint = "i18n_ulocale_get_default")]
        internal static extern int GetDefault(out IntPtr localeID);
        // int i18n_ulocale_get_default(const char **locale);
    }
}

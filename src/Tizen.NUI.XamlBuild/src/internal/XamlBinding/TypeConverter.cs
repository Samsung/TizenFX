/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Globalization;

namespace Tizen.NUI.Binding
{
    internal abstract class TypeConverter
    {
        public virtual bool CanConvertFrom(Type sourceType)
        {
            if (sourceType == null)
                throw new ArgumentNullException(nameof(sourceType));

            return sourceType == typeof(string);
        }

        [Obsolete("ConvertFrom is obsolete as of version 2.2.0. Please use ConvertFromInvariantString (string) instead.")]
        public virtual object ConvertFrom(object o)
        {
            return null;
        }

        [Obsolete("ConvertFrom is obsolete as of version 2.2.0. Please use ConvertFromInvariantString (string) instead.")]
        public virtual object ConvertFrom(CultureInfo culture, object o)
        {
            return null;
        }

        public virtual object ConvertFromInvariantString(string value)
        {
#pragma warning disable 0618 // retain until ConvertFrom removed
            return ConvertFrom(CultureInfo.InvariantCulture, value);
#pragma warning restore
        }
    }
}
 

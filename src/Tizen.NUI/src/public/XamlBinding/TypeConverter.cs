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
using System.ComponentModel;
using System.Globalization;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class TypeConverter
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool CanConvertFrom(Type sourceType)
        {
            if (sourceType == null)
                throw new ArgumentNullException(nameof(sourceType));

            return sourceType == typeof(string);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("ConvertFrom is obsolete as of version 2.2.0. Please use ConvertFromInvariantString (string) instead.")]
        public virtual object ConvertFrom(object o)
        {
            return null;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("ConvertFrom is obsolete as of version 2.2.0. Please use ConvertFromInvariantString (string) instead.")]
        public virtual object ConvertFrom(CultureInfo culture, object o)
        {
            return null;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual object ConvertFromInvariantString(string value)
        {
#pragma warning disable 0618 // retain until ConvertFrom removed
            return ConvertFrom(CultureInfo.InvariantCulture, value);
#pragma warning restore
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string ConvertToString(object value)
        {
            return null;
        }
    }
}

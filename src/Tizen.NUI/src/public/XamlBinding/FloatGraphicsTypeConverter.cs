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
using System.Linq;
using System.Reflection;
using System.Globalization;

using Tizen.NUI;
using Tizen.NUI.Xaml;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// A TypeConverter of float variable as it's graphics type suffix.
    /// dp, sp suffix is converted to pixel value with Dpi and ScalingFactors by GraphicsTypeManager.
    /// <seealso cref="Tizen.NUI.GraphicsTypeManager" />
    /// </summary>
    /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ProvideCompiledAttribute("Tizen.NUI.Xaml.Core.XamlC.FloatGraphicsTypeConverter")]
    public class FloatGraphicsTypeConverter : TypeConverter
    {
        /// <inheritdoc/>
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override object ConvertFromInvariantString(string value)
        {
            if(!string.IsNullOrEmpty(value))
            {
                return (float)GraphicsTypeManager.Instance.ConvertScriptToPixel(value.Trim());
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(float)}");
        }

        /// <inheritdoc/>
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ConvertToString(object value)
        {
            if (value != null)
            {
                float floatVal = (float)value;
                return floatVal.ToString();
            }
            return "";
        }
    }
}

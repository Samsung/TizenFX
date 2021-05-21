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
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Binding;
using System.ComponentModel;

namespace Tizen.NUI.Xaml
{
    /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ContentProperty("RealString")]
    [AcceptEmptyServiceProvider]
    public sealed class CombinedString : IMarkupExtension<string>
    {
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(object value)
        {
            if (value is string)
            {
                realString += value as string;
            }
            else if (value is EnviromentValue enviromentValue)
            {
                realString += enviromentValue.Value;
            }
            else
            {
                throw new XamlParseException(String.Format("Can't add {0} to string", value?.GetType()?.ToString()));
            }
        }

        private string realString = "";
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string RealString
        {
            get
            {
                return realString;
            }
            set
            {
                realString += value;
            }
        }

        string IMarkupExtension<string>.ProvideValue(IServiceProvider serviceProvider)
        {
            return realString;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<string>).ProvideValue(serviceProvider);
        }
    }
}

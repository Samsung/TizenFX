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
    /// This will be opened in next ACR.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ContentProperty("RealString")]
    [AcceptEmptyServiceProvider]
    public sealed class CombinedString : IMarkupExtension<string>
    {
        /// This will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(object value)
        {
            if (value is string)
            {
                realString += value as string;
            }
            else if (value is EnviromentValue)
            {
                realString += (value as EnviromentValue).Value;
            }
            else
            {
                throw new XamlParseException(String.Format("Can't add {0} to string", value?.GetType()?.ToString()));
            }
        }

        private string realString = "";
        /// This will be opened in next ACR.
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

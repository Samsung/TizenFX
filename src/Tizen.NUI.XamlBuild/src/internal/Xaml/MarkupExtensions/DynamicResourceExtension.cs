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
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.EXaml;

namespace Tizen.NUI.Xaml
{
    [ContentProperty("Key")]
    internal sealed class DynamicResourceExtension : IMarkupExtension<DynamicResource>
    {
        public string Key { get; set; }

        public object ProvideValue()
        {
            if (null == Key)
            {
                return null;
            }
            else
            {
                return new DynamicResource(Key);
            }
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return ((IMarkupExtension<DynamicResource>)this).ProvideValue(serviceProvider);
        }

        DynamicResource IMarkupExtension<DynamicResource>.ProvideValue(IServiceProvider serviceProvider)
        {
            if (Key == null)
            {
                var lineInfoProvider = serviceProvider.GetService(typeof (IXmlLineInfoProvider)) as IXmlLineInfoProvider;
                var lineInfo = (lineInfoProvider != null) ? lineInfoProvider.XmlLineInfo : new XmlLineInfo();
                throw new XamlParseException("DynamicResource markup require a Key", lineInfo);
            }
            return new DynamicResource(Key);
        }
    }
}
 

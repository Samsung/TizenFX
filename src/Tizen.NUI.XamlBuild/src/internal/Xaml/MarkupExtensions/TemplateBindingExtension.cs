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

namespace Tizen.NUI.Xaml
{
    [ContentProperty("Path")]
    [AcceptEmptyServiceProvider]
    internal sealed class TemplateBindingExtension : IMarkupExtension<BindingBase>
    {
        internal TemplateBindingExtension()
        {
            Mode = BindingMode.Default;
            Path = Tizen.NUI.Binding.Binding.SelfPath;
        }

        public string Path { get; set; }

        public BindingMode Mode { get; set; }

        public IValueConverter Converter { get; set; }

        public object ConverterParameter { get; set; }

        public string StringFormat { get; set; }

        BindingBase IMarkupExtension<BindingBase>.ProvideValue(IServiceProvider serviceProvider)
        {
            return new TemplateBinding(Path, Mode, Converter, ConverterParameter, StringFormat);
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<BindingBase>).ProvideValue(serviceProvider);
        }
    }
}
 

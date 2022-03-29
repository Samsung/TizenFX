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
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Binding;
using Tizen.NUI.EXaml;
using Mono.Cecil;
using Tizen.NUI.EXaml.Build.Tasks;

namespace Tizen.NUI.Xaml
{
    [ContentProperty("Path")]
    [AcceptEmptyServiceProvider]
    internal sealed class BindingExtension : IMarkupExtension<BindingBase>
    {
        public string Path { get; set; } = Tizen.NUI.Binding.Binding.SelfPath;
        public BindingMode Mode { get; set; } = BindingMode.Default;

        public EXamlCreateObject ModeInEXaml { get; set; } = null;

        public object Converter { get; set; }

        public object ConverterParameter { get; set; }

        public string StringFormat { get; set; }

        public object Source { get; set; }

        public string UpdateSourceEventName { get; set; }

        public object TargetNullValue { get; set; }

        public object FallbackValue { get; set; }

        public TypedBindingBase TypedBinding { get; set; }

        public EXamlCreateObject ProvideValue(EXamlContext context, ModuleDefinition module)
        {
            if (TypedBinding == null)
            {
                var newTypeRef = module.ImportReference(typeof(Tizen.NUI.Binding.Binding));
                return new EXamlCreateObject(context, null, newTypeRef, new object[] { Path, ModeInEXaml, Converter, ConverterParameter, StringFormat, Source });
            }
            else
            {
                throw new Exception("TypedBinding should not be not null");
                //TypedBinding.Mode = Mode;
                //TypedBinding.Converter = Converter;
                //TypedBinding.ConverterParameter = ConverterParameter;
                //TypedBinding.StringFormat = StringFormat;
                //TypedBinding.Source = Source;
                //TypedBinding.UpdateSourceEventName = UpdateSourceEventName;
                //TypedBinding.FallbackValue = FallbackValue;
                //TypedBinding.TargetNullValue = TargetNullValue;
                //return TypedBinding;
            }
        }

        BindingBase IMarkupExtension<BindingBase>.ProvideValue(IServiceProvider serviceProvider)
        {
            if (TypedBinding == null)
                return new Tizen.NUI.Binding.Binding(Path, Mode, Converter as IValueConverter, ConverterParameter, StringFormat, Source)
                {
                    UpdateSourceEventName = UpdateSourceEventName,
                    FallbackValue = FallbackValue,
                    TargetNullValue = TargetNullValue,
                };

            TypedBinding.Mode = Mode;
            TypedBinding.Converter = Converter as IValueConverter;
            TypedBinding.ConverterParameter = ConverterParameter;
            TypedBinding.StringFormat = StringFormat;
            TypedBinding.Source = Source;
            TypedBinding.UpdateSourceEventName = UpdateSourceEventName;
            TypedBinding.FallbackValue = FallbackValue;
            TypedBinding.TargetNullValue = TargetNullValue;
            return TypedBinding;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<BindingBase>).ProvideValue(serviceProvider);
        }
    }
}
 

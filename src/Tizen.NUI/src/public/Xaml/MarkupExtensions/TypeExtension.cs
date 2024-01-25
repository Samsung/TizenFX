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
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    [ContentProperty(nameof(TypeName))]
    [ProvideCompiled("Tizen.NUI.Xaml.Build.Tasks.TypeExtension")]
    internal class TypeExtension : IMarkupExtension<Type>
    {
        public string TypeName { get; set; }

        public Type ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(TypeName))
                throw new InvalidOperationException("TypeName isn't set.");
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));
            var typeResolver = serviceProvider.GetService(typeof(IXamlTypeResolver)) as IXamlTypeResolver;
            if (typeResolver == null)
                throw new ArgumentException("No IXamlTypeResolver in IServiceProvider");

            return typeResolver.Resolve(TypeName, serviceProvider);
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<Type>).ProvideValue(serviceProvider);
        }
    }
}

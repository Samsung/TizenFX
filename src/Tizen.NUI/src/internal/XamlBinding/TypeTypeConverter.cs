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
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    /// Internal use, will never open
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Xaml.ProvideCompiled("Tizen.NUI.Xaml.Core.XamlC.TypeTypeConverter")]
    [Xaml.TypeConversion(typeof(Type))]
    public sealed class TypeTypeConverter : TypeConverter, IExtendedTypeConverter
    {
        [Obsolete("IExtendedTypeConverter.ConvertFrom is obsolete as of version 2.2.0. Please use ConvertFromInvariantString (string, IServiceProvider) instead.")]
        object IExtendedTypeConverter.ConvertFrom(CultureInfo culture, object value, IServiceProvider serviceProvider)
        {
            return ((IExtendedTypeConverter)this).ConvertFromInvariantString((string)value, serviceProvider);
        }

        object IExtendedTypeConverter.ConvertFromInvariantString(string value, IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));
            var typeResolver = serviceProvider.GetService(typeof(IXamlTypeResolver)) as IXamlTypeResolver;
            if (typeResolver == null)
                throw new ArgumentException("No IXamlTypeResolver in IServiceProvider");

            return typeResolver.Resolve(value, serviceProvider);
        }

        /// Internal use, will never open
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override object ConvertFromInvariantString(string value)
        {
            throw new NotImplementedException();
        }
    }
}

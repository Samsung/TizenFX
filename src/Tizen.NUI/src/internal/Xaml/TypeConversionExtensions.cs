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
//
// TypeConversionExtensions.cs
//
// Author:
//       Stephane Delcroix <stephane@mi8.be>
//
// Copyright (c) 2013 Mobile Inception
// Copyright (c) 2014 Xamarin, Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
// using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Xaml.Internals;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    internal static class TypeConversionExtensions
    {
        internal static object ConvertTo(this object value, Type toType, Func<ParameterInfo> pinfoRetriever,
            IServiceProvider serviceProvider)
        {
            Func<TypeConverter> getConverter = () =>
            {
                ParameterInfo pInfo;
                if (pinfoRetriever == null || (pInfo = pinfoRetriever()) == null)
                    return null;

                var converterTypeName = pInfo.CustomAttributes.GetTypeConverterTypeName();
                if (converterTypeName == null)
                    return null;
                var convertertype = Type.GetType(converterTypeName);
                return (TypeConverter)Activator.CreateInstance(convertertype);
            };

            return ConvertTo(value, toType, getConverter, serviceProvider);
        }

        internal static object ConvertTo(this object value, Type toType, Func<MemberInfo> minfoRetriever,
            IServiceProvider serviceProvider)
        {
            Func<object> getConverter = () =>
            {
                MemberInfo memberInfo;
                string converterTypeName = null;
                Type realType = toType;

                if (true == realType.IsGenericType && typeof(Nullable<>) == realType.GetGenericTypeDefinition())
                {
                    realType = realType.GetGenericArguments()[0];
                }

                converterTypeName = realType.CustomAttributes.GetTypeConverterTypeName();
                if (minfoRetriever != null && (memberInfo = minfoRetriever()) != null)
                    converterTypeName = memberInfo.CustomAttributes.GetTypeConverterTypeName() ?? converterTypeName;

                if (converterTypeName == null)
                {
                    converterTypeName = toType.FullName + "TypeConverter";
                }

                var convertertype = Type.GetType(converterTypeName);

                if (null == convertertype)
                {
                    return null;
                }
                else
                {
                    return Activator.CreateInstance(convertertype);
                }
            };

            return ConvertTo(value, toType, getConverter, serviceProvider);
        }

        static string GetTypeConverterTypeName(this IEnumerable<CustomAttributeData> attributes)
        {
            var converterAttribute =
                attributes.FirstOrDefault(cad => TypeConverterAttribute.TypeConvertersType.Contains(cad.AttributeType.FullName));
            if (converterAttribute == null)
                return null;
            if (converterAttribute.ConstructorArguments[0].ArgumentType == typeof(string))
                return (string)converterAttribute.ConstructorArguments[0].Value;
            if (converterAttribute.ConstructorArguments[0].ArgumentType == typeof(Type))
                return ((Type)converterAttribute.ConstructorArguments[0].Value).AssemblyQualifiedName;
            return null;
        }

        //Don't change the name or the signature of this, it's used by XamlC
        public static object ConvertTo(this object value, Type toType, Type convertertype, IServiceProvider serviceProvider)
        {
            if (convertertype == null)
                return value.ConvertTo(toType, (Func<object>)null, serviceProvider);
            Func<object> getConverter = () => Activator.CreateInstance(convertertype);
            ;
            return value.ConvertTo(toType, getConverter, serviceProvider);
        }

        private delegate void ParseValueFunc(string s, IFormatProvider provider);

        static private Dictionary<Type, ParseValueFunc> typeToParseValueFunc = null;

        static private void BuildParseValueFunc()
        {
            if (null == typeToParseValueFunc)
            {
                typeToParseValueFunc = new Dictionary<Type, ParseValueFunc>();

            }
        }

        internal static object ConvertTo(this object value, Type toType, Func<object> getConverter,
            IServiceProvider serviceProvider)
        {
            if (value == null)
                return null;

            var str = value as string;
            if (str != null)
            {
                //If there's a [TypeConverter], use it
                object converter = getConverter?.Invoke();
                if (null != converter)
                {
                    var xfTypeConverter = converter as TypeConverter;
                    var xfExtendedTypeConverter = xfTypeConverter as IExtendedTypeConverter;
                    if (xfExtendedTypeConverter != null)
                        return value = xfExtendedTypeConverter.ConvertFromInvariantString(str, serviceProvider);
                    if (xfTypeConverter != null)
                        return value = xfTypeConverter.ConvertFromInvariantString(str);
                    var converterType = converter?.GetType();
                    if (converterType != null)
                    {
                        var convertFromStringInvariant = converterType.GetRuntimeMethod("ConvertFromInvariantString",
                            new[] { typeof(string) });
                        if (convertFromStringInvariant != null)
                            return value = convertFromStringInvariant.Invoke(converter, new object[] { str });
                    }
                }

                var ignoreCase = (serviceProvider?.GetService(typeof(IConverterOptions)) as IConverterOptions)?.IgnoreCase ?? false;

                //If the type is nullable, as the value is not null, it's safe to assume we want the built-in conversion
                if (toType.GetTypeInfo().IsGenericType && toType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    toType = Nullable.GetUnderlyingType(toType);

                //Obvious Built-in conversions
                if (toType.GetTypeInfo().IsEnum)
                    return Enum.Parse(toType, str, ignoreCase);

                if (toType == typeof(SByte))
                    return SByte.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Int16))
                    return Int16.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Int32))
                    return Int32.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Int64))
                    return Int64.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Byte))
                    return Byte.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(UInt16))
                    return UInt16.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(UInt32))
                    return UInt32.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(UInt64))
                    return UInt64.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Single))
                    return Single.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Double))
                    return Double.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Boolean))
                    return Boolean.Parse(str);
                if (toType == typeof(TimeSpan))
                    return TimeSpan.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(DateTime))
                    return DateTime.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Char))
                {
                    char c = '\0';
                    _ = Char.TryParse(str, out c);
                    return c;
                }
                if (toType == typeof(String) && str.StartsWith("{}", StringComparison.Ordinal))
                    return str.Substring(2);
                if (toType == typeof(String))
                    return value;
                if (toType == typeof(Decimal))
                    return Decimal.Parse(str, CultureInfo.InvariantCulture);
            }

            //if the value is not assignable and there's an implicit conversion, convert
            if (value != null && !toType.IsAssignableFrom(value.GetType()))
            {
                var opImplicit = value.GetType().GetImplicitConversionOperator(fromType: value.GetType(), toType: toType)
                                ?? toType.GetImplicitConversionOperator(fromType: value.GetType(), toType: toType);

                if (opImplicit != null)
                {
                    value = opImplicit.Invoke(null, new[] { value });
                    return value;
                }
            }

            return value;
        }

        internal static MethodInfo GetImplicitConversionOperator(this Type onType, Type fromType, Type toType)
        {
#if NETSTANDARD1_0
            var mi = onType.GetRuntimeMethod("op_Implicit", new[] { fromType });
#else
            var bindingFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy;
            var mi = onType.GetMethod("op_Implicit", bindingFlags, null, new[] { fromType }, null);
#endif
            if (mi == null) return null;
            if (!mi.IsSpecialName) return null;
            if (!mi.IsPublic) return null;
            if (!mi.IsStatic) return null;
            if (!toType.IsAssignableFrom(mi.ReturnType)) return null;

            return mi;
        }
    }
}

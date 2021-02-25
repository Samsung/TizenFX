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
// System.ComponentModel.TypeConverterAttribute
//
// Authors:
//  Gonzalo Paniagua Javier (gonzalo@ximian.com)
//  Andreas Nahr (ClassDevelopment@A-SoftTech.com)
//
// (C) 2002 Ximian, Inc (http://www.ximian.com)
// (C) 2003 Andreas Nahr
//

//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;

namespace Tizen.NUI.Binding
{
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class TypeConverterAttribute : Attribute
    {
        internal static string[] TypeConvertersType = { "Tizen.NUI.Binding.TypeConverterAttribute", "System.ComponentModel.TypeConverterAttribute" };

        public static readonly TypeConverterAttribute Default = new TypeConverterAttribute();

        public TypeConverterAttribute()
        {
            ConverterTypeName = "";
        }

        public TypeConverterAttribute(string typeName)
        {
            ConverterTypeName = typeName;
        }

        public TypeConverterAttribute(Type type)
        {
            ConverterTypeName = type.AssemblyQualifiedName;
        }

        public string ConverterTypeName { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is TypeConverterAttribute))
                return false;

            return ((TypeConverterAttribute)obj).ConverterTypeName == ConverterTypeName;
        }

        public override int GetHashCode()
        {
            return ConverterTypeName.GetHashCode();
        }
    }
}

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

namespace Tizen.NUI.StyleSheets
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = true)]
    internal sealed class StylePropertyAttribute : Attribute
    {
        public string CssPropertyName { get; }
        public string BindablePropertyName { get; }
        public Type TargetType { get; }
        public Type PropertyOwnerType { get; set; }
        public BindableProperty BindableProperty { get; set; }
        public bool Inherited { get; set; } = false;


        public StylePropertyAttribute(string cssPropertyName, Type targetType, string bindablePropertyName)
        {
            CssPropertyName = cssPropertyName;
            BindablePropertyName = bindablePropertyName;
            TargetType = targetType;
        }
    }
}
 

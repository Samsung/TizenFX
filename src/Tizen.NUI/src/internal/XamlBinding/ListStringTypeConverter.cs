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
using System.Collections.Generic;
using System.Linq;

namespace Tizen.NUI.Binding
{
    [Xaml.ProvideCompiled("Tizen.NUI.Core.XamlC.ListStringTypeConverter")]
    [Xaml.TypeConversion(typeof(List<string>))]
    internal class ListStringTypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value == null)
                return null;

            return value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
        }
    }
}

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
using System.Collections;
using System.Collections.Generic;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    [ContentProperty("Items")]
    [AcceptEmptyServiceProvider]
    internal class ArrayExtension : IMarkupExtension<Array>
    {
        public ArrayExtension()
        {
            Items = new List<object>();
        }

        public IList Items { get; }

        public Type Type { get; set; }

        public Array ProvideValue(IServiceProvider serviceProvider)
        {
            if (Type == null)
                throw new InvalidOperationException("Type argument mandatory for x:Array extension");

            if (Items == null)
                return null;

            var array = Array.CreateInstance(Type, Items.Count);
            for (var i = 0; i < Items.Count; i++)
                ((IList)array)[i] = Items[i];

            return array;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<Array>).ProvideValue(serviceProvider);
        }
    }
}
 

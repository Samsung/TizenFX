/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal class EmptyResourceTable<T> : ITokenTable<T>
    {
#pragma warning disable CS0067 // The event 'EmptyResourceTable<T>.Updated' is never used
        public event EventHandler Updated;
#pragma warning restore CS0067

        public bool TryGetValue(string id, out T result)
        {
            result = default;
            return false;
        }

        public void Update(IDictionary<string, T> table)
        {
        }

        public void Bind(View target, IPropertySetter<T> setter, IToken<T> token)
        {
        }
    }
}

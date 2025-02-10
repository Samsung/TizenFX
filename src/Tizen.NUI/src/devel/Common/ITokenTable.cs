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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// The interface for a token table.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITokenTable<T>
    {
        /// <summary>
        /// The event which is invoked when the resource table is updated.
        /// </summary>
        event EventHandler Updated;

        /// <summary>
        /// The method to get the value from the resource table.
        /// </summary>
        bool TryGetValue(string id, out T result);

        /// <summary>
        /// The method to update the resource table.
        /// </summary>
        void Update(IDictionary<string, T> table);

        /// <summary>
        /// The method to bind target with token.
        /// When table is updated, binded view will be updated.
        /// </summary>
        void Bind(View target, IPropertySetter<T> setter, IToken<T> token);
    }
}

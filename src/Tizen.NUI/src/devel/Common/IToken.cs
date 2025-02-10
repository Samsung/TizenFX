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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// Interface for token. Token is a key-value pair that can be applied to the target. It has an id and value. The value type is generic.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IToken<T>
    {
        /// <summary>
        /// The unique identifier of the token.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// The value of the token.
        /// </summary>
        T Value { get; }

        /// <summary>
        /// Apply the token to target.
        /// </summary>
        void Apply<TView>(TView view, IPropertySetter<T> propertySetter) where TView : View;
    }
}

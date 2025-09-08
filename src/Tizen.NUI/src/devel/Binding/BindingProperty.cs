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
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// The BindingProperty class represents a binding property for a view.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class BindingProperty<TView, TValue>
    {
        /// <summary>
        /// Gets or sets the setter action for the binding property.
        /// </summary>
        public Action<TView, TValue> Setter { get; set; }
    }
}

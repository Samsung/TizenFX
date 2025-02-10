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

namespace Tizen.NUI
{
    /// <summary>
    /// Describes a property setter.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PropertySetter<TView, TValue> : IPropertySetter<TValue>
    {
        private Action<TView, TValue> _setter;

        /// <summary>
        /// Creates an instance of the PropertySetter class.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="setter">The action to set the property.</param>
        public PropertySetter(string name, Action<TView, TValue> setter)
        {
            Name = name;
            _setter = setter;
        }

        /// <inheritdoc/>
        public string Name { get; }

        /// <inheritdoc/>
        public virtual void Invoke(object target, TValue value)
        {
            if (target is TView typedTarget)
                _setter(typedTarget, value);
        }
    }
}

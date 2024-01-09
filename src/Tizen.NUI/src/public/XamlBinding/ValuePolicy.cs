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

using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// The Policy of SetValue / GetValue behaviour
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ValuePolicy
    {
        /// <summary>
        /// Always ask old value to Native when we GetValue, and SetValue.
        /// DefaultValueCreator will called when we SetValue.
        /// </summary>
        Default,

        /// <summary>
        /// Ignore old value when we call SetValue. GetValue will ask old value to Native.
        /// </summary>
        IgnoreOldValueWhenSetValue,

        /// <summary>
        /// Get native value only if we create new BindableContext.
        /// If we call SetValue before, DefaultValueCreator never be called.
        /// Else, DefaultValueCreator called only one time.
        /// </summary>
        GetNativeValueOnlyCreation,
    }
}

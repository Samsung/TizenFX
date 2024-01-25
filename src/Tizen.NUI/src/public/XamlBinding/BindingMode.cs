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
    /// The direction of changes propagation for bindings.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum BindingMode
    {
        /// <summary>
        /// When used in Bindings, indicates that the Binding should use the DefaultBindingMode. When used in BindableProperty declaration, defaults to BindingMode.OneWay.
        /// </summary>
        Default,

        /// <summary>
        /// Indicates that the binding should propagates changes from source (usually the View Model) to target (the BindableObject) in both directions.
        /// </summary>
        TwoWay,

        /// <summary>
        /// Indicates that the binding should only propagate changes from source (usually the View Model) to target (the BindableObject). This is the default mode for most BindableProperty values.
        /// </summary>
        OneWay,

        /// <summary>
        /// Indicates that the binding should only propagate changes from target (the BindableObject) to source (usually the View Model). This is mainly used for read-only BindableProperty values.
        /// </summary>
        OneWayToSource,

        /// <summary>
        /// Indicates that the binding will be applied only when the binding context changes and the value will not be monitored for changes with INotifyPropertyChanged.
        /// </summary>
        OneTime,
    }
}

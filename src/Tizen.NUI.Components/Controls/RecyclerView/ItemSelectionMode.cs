/* Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using System.Diagnostics.CodeAnalysis;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Selection mode of CollecitonView.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SuppressMessage("Microsoft.Naming",
                     "CA1720: Identifiers should not contain type names",
                     Justification = "Single is the member of enum ItemSelectionMode. there are no possible danger to miss using Single Identifiers.")]
    public enum ItemSelectionMode
    {
        /// <summary>
        /// None of item can be selected.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        None,
        /// <summary>
        /// Single selection. select item exclusively so previous selected item will be unselected.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Single,
        /// <summary>
        /// Single selection always. select item exclusively but selection is always exist after being selected.
        /// to deselect item, clear selection forcely.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        SingleAlways,
        /// <summary>
        /// Multiple selections. select multiple items and previous selected item still remains selected.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Multiple
    }
}

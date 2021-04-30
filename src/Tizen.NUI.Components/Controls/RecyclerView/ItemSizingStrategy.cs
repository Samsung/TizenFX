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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Size calculation strategy for CollectionView.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ItemSizingStrategy
    {
        /// <summary>
        /// Measure first item and deligate size for all items.
        /// if template is selector, the size of first item from each template will be deligated.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MeasureFirst,
        /// <summary>
        /// Measure all items in advanced.
        /// Estimate first item size for all, and when scroll reached position,
        /// measure strictly. Note : This will make scroll bar trembling.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MeasureAll,
    }
}

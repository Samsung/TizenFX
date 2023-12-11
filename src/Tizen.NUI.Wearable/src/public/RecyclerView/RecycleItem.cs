/* Copyright (c) 2020 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Components;
using System;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// [Draft] This class provides a basic item for RecyclerView.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    [Obsolete("This has been deprecated in API12")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RecycleItem : Control
    {
        /// <summary>
        /// Data index which is binded to item by RecycleAdapter.
        /// Can access to data of RecycleAdapter using this index.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DataIndex { get; set; } = 0;
    }
}

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

using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Selection changed event in RecyclerView items.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class SelectionChangedEventArgs : EventArgs
    {
        static readonly IReadOnlyList<object> selectEmpty = new List<object>(0);

        /// <summary>
        /// Previous selection list.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public IReadOnlyList<object> PreviousSelection { get; }

        /// <summary>
        /// Current selection list.    
        ///  </summary>
        /// <since_tizen> 9 </since_tizen>
        public IReadOnlyList<object> CurrentSelection { get; }

        internal SelectionChangedEventArgs(object previousSelection, object currentSelection)
        {
            PreviousSelection = previousSelection != null ? new List<object>(1) { previousSelection } : selectEmpty;
            CurrentSelection = currentSelection != null ? new List<object>(1) { currentSelection } : selectEmpty;
        }

        internal SelectionChangedEventArgs(IList<object> previousSelection, IList<object> currentSelection)
        {
            PreviousSelection = new List<object>(previousSelection ?? throw new ArgumentNullException(nameof(previousSelection)));
            CurrentSelection = new List<object>(currentSelection ?? throw new ArgumentNullException(nameof(currentSelection)));
        }
    }
}

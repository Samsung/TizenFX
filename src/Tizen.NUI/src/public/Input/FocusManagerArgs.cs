/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    ///<summary>
    /// Event arguments passed via the FocusChanging signal.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public class FocusChangingEventArgs : EventArgs
    {
        private View current;
        private View proposed;
        private View.FocusDirection direction;

        /// <summary>
        /// Gets or sets the view which is currently focused.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public View Current
        {
            get
            {
                return current;
            }
            set
            {
                current = value;
            }
        }

        /// <summary>
        /// Gets or sets the proposed view for focus change.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public View Proposed
        {
            get
            {
                return proposed;
            }
            set
            {
                proposed = value;
            }
        }

        /// <summary>
        /// Gets or sets the focus move direction.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public View.FocusDirection Direction
        {
            get
            {
                return direction;
            }
            set
            {
                direction = value;
            }
        }
    }
}

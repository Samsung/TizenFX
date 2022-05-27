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
    /// Event arguments that passed via the FocusChanging signal.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public class FocusChangingEventArgs : EventArgs
    {
        private View current;
        private View proposed;
        private View.FocusDirection direction;

        /// <summary>
        /// The current focus view.
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
        /// The  proposed view.
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
        /// The focus move direction.
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

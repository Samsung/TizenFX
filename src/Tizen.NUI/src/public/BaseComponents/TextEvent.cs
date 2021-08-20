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

using System;
using System.ComponentModel;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// AnchorClickedEventArgs is a class to record anchor click event arguments which will be sent to user.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class AnchorClickedEventArgs : EventArgs
    {
        /// <summary>
        /// Anchor href(hypertext reference).
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string Href { get; set; }
    }

    /// <summary>
    /// InputFilteredEventArgs is a class to record input filter event arguments which will be sent to user.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class InputFilteredEventArgs : EventArgs
    {
        /// <summary>
        /// The type of InputFilter that filtered the input is stored. <br />
        /// If the input is filtered by the Accepted Regex of the InputFilter, the Accept type is stored. <br />
        /// If the input is filtered by the Rejected Regex of the InputFilter, the Reject type is stored. <br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InputFilterType Type { get; set; }
    }
}
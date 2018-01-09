/*
* Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
*
* Licensed under the Apache License, Version 2.0 (the License);
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an AS IS BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

namespace Tizen.Uix.InputMethod
{
    /// <summary>
    /// This class contains the data related to the FocusedOut event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class FocusedOutEventArgs
    {
        internal FocusedOutEventArgs(int contextId)
        {
            ContextId = contextId;
        }

        /// <summary>
        /// The input context identification value of an associated text input UI control.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int ContextId
        {
            get;
            internal set;
        }
    }
}
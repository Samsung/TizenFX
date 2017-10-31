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
    /// This Class contains data related to SurroundingTextUpdated Event
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class SurroundingTextUpdatedEventArgs
    {
        internal SurroundingTextUpdatedEventArgs(int contextId, string text, int cursorPos)
        {
            ContextId = contextId;
            Text = text;
            CursorPosition = cursorPos;
        }

        /// <summary>
        /// The input context identification value of an associated text input UI control
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int ContextId
        {
            get;
            internal set;
        }

        /// <summary>
        /// The cursor position
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int CursorPosition
        {
            get;
            internal set;
        }

        /// <summary>
        /// The string requested
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Text
        {
            get;
            internal set;
        }
    }
}
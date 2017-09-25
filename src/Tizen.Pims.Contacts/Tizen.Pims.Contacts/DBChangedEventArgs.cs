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

using System;

namespace Tizen.Pims.Contacts
{
    /// <summary>
    /// Event arguments passed when contacts database is changed
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class DBChangedEventArgs : EventArgs
    {
        internal DBChangedEventArgs(string viewUri)
        {
            ViewUri = viewUri;
        }

        /// <summary>
        /// The contacts view URI changed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string ViewUri
        {
            get;
            internal set;
        }
    }
}

/*
* Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Uix.VoiceControlManager
{
    /// <summary>
    /// This Class contains sets private data to manager client.
    /// </summary>
    public class PrivateDataUpdatedEventArgs : EventArgs
    {
        internal PrivateDataUpdatedEventArgs(string key, string data)
        {
            Key = key;
            Data = data;
        }

        /// <summary>
        /// Private key
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Key
        {
            get;
            private set;
        }

        /// <summary>
        /// Private data
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Data
        {
            get;
            private set;
        }
    }
}
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

namespace Tizen.Network.NetworkMonitor
{
    /// <summary>
    /// An extended EventArgs class which contains the result of sending HTTP GET requests.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class UrlCheckResultEventArgs : EventArgs
    {
        private UrlCheckResult _result;
        private string _url;

        internal UrlCheckResultEventArgs(int result, string url)
        {
            _result = (UrlCheckResult)result;
            _url = url;
        }

        /// <summary>
        /// The result of sending HTTP GET requests.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The result of sending HTTP GET requests </value>
        public UrlCheckResult Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// The requested URL.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The requested URL </value>
        public string Url
        {
            get
            {
                return _url;
            }
        }
    }
}

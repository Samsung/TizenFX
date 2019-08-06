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
using System.Collections.Generic;

namespace Tizen.Network.NetworkMonitor
{
    /// <summary>
    /// A class which checks whether given URLs are reachable or not.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static class UrlChecker
    {
        private static List<string> _urlList;
        private static int _type;

        /// <summary>
        /// Starts to send HTTP GET requests to check reachability of URLs.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="urlList"> A list of URLs to check reachability. If it is empty or null, default URLs are used to check whether the device is connected to the Internet or not. </param>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <exception cref="NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        /// <exception cref="NowInProgressException">Thrown when the UrlChecker is already started.</exception>
        public static void Start(List<string> urlList)
        {
            if (IsRunning)
            {
                throw new NowInProgressException("Now in progress");
            }

            if (urlList == null || urlList.Count == 0)
            {
                _type = 0;   // default type
            }
            else
            {
                _type = 1;
                NetworkMonitorImpl.Instance.AddUrls(urlList);
            }
            _urlList = urlList;
            NetworkMonitorImpl.Instance.UrlCheckerStart(_type);
        }

        /// <summary>
        /// Stops sending HTTP GET requests to check reachability of URLs of the given type.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <exception cref="NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        public static void Stop()
        {
            NetworkMonitorImpl.Instance.UrlCheckerStop(_type);
            ClearUrlList();
        }

        /// <summary>
        /// A property to get whether the URLChecker is running or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> Whether the URLChecker is running or not </value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <exception cref="NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        public static bool IsRunning
        {
            get
            {
                return NetworkMonitorImpl.Instance.UrlCheckerIsRunning(_type);
            }
        }

        /// <summary>
        /// ResultReceived event is raised when a response of A HTTP GET request is received.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static event EventHandler<UrlCheckResultEventArgs> ResultReceived
        {
            add
            {
                NetworkMonitorImpl.Instance.ResultReceived += value;
            }
            remove
            {
                NetworkMonitorImpl.Instance.ResultReceived -= value;
            }
        }

        private static void ClearUrlList()
        {
            if (_urlList != null && _urlList.Count > 0)
            {
                NetworkMonitorImpl.Instance.ClearUrls(_urlList);
            }
        }
    }
}

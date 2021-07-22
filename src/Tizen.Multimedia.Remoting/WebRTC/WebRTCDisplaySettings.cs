/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides a means to configure display settings for video <see cref="WebRTC"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException">The webRtc is null.</exception>
    /// <since_tizen> 9 </since_tizen>
    public class WebRTCDisplaySettings
    {
        private readonly WebRTC _webRtc;

        internal WebRTCDisplaySettings(WebRTC webRtc)
        {
            _webRtc = webRtc ?? throw new ArgumentNullException(nameof(webRtc));
        }
    }
}

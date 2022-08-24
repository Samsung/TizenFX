﻿/*
* Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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


namespace Tizen.Uix.Tts
{
    /// <summary>
    /// This class holds information related to the TTS ServiceStateChanged event.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public class ServiceStateChangedEventArgs
    {
        internal ServiceStateChangedEventArgs(ServiceState previous, ServiceState current)
        {
            Previous = previous;
            Current = current;
        }

        /// <summary>
        /// The previous state of TTS service.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public ServiceState Previous
        {
            get;
            internal set;
        }

        /// <summary>
        /// The current state of TTS service.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public ServiceState Current
        {
            get;
            internal set;
        }
    }
}

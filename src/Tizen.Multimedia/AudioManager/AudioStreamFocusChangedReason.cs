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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Enumerates the reasons for changes in the focus state of an audio stream.
    /// This enumeration provides specific contexts in which the audio stream
    /// focus may be gained or lost, ensuring developers can respond appropriately.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AudioStreamFocusChangedReason
    {
        /// <summary>
        /// Media.
        /// </summary>
        Media,

        /// <summary>
        /// System.
        /// </summary>
        System,

        /// <summary>
        /// Alarm.
        /// </summary>
        Alarm,

        /// <summary>
        /// Notification.
        /// </summary>
        Notification,

        /// <summary>
        /// Emergency.
        /// </summary>
        Emergency,

        /// <summary>
        /// Voice information.
        /// </summary>
        VoiceInformation,

        /// <summary>
        /// Voice recognition.
        /// </summary>
        VoiceRecognition,

        /// <summary>
        /// Ringtone.
        /// </summary>
        RingtoneVoip,

        /// <summary>
        /// VoIP.
        /// </summary>
        Voip,

        /// <summary>
        /// Voice-call or video-call.
        /// </summary>
        Call,

        /// <summary>
        /// Media only for external devices.
        /// </summary>
        MediaExternalOnly
    }
}

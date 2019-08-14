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
    /// Specifies the audio device types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AudioDeviceType
    {
        /// <summary>
        /// Built-in speaker.
        /// </summary>
        BuiltinSpeaker,

        /// <summary>
        /// Built-in receiver.
        /// </summary>
        BuiltinReceiver,

        /// <summary>
        /// Built-in microphone.
        /// </summary>
        BuiltinMic,

        /// <summary>
        /// Audio jack that can be connected to wired accessories such as headphones and headsets.
        /// </summary>
        AudioJack,

        /// <summary>
        /// Bluetooth media (A2DP).
        /// </summary>
        BluetoothMedia,

        /// <summary>
        /// HDMI.
        /// </summary>
        Hdmi,

        /// <summary>
        /// Device for forwarding.
        /// </summary>
        Forwarding,

        /// <summary>
        /// USB audio.
        /// </summary>
        UsbAudio,

        /// <summary>
        /// Bluetooth voice (SCO).
        /// </summary>
        BluetoothVoice,

        /// <summary>
        /// Network.
        /// </summary>
        Network
    }
}

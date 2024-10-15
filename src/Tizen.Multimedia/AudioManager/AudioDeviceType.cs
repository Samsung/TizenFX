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
    /// Represents the various types of audio devices available in the system.
    /// This enumeration categorizes audio devices based on their functionality and
    /// connection type, enabling developers to easily identify and utilize
    /// the appropriate audio device for their applications. The types include
    /// built-in speakers and microphones, external connections like audio jacks,
    /// Bluetooth, HDMI, USB audio, and network audio devices, facilitating
    /// effective audio management in diverse scenarios.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AudioDeviceType
    {
        /// <summary>
        /// Represents the built-in speaker of the device, typically used for
        /// playback of audio through the device's internal audio output.
        /// </summary>
        BuiltinSpeaker,

        /// <summary>
        /// Represents the built-in receiver, usually utilized for phone calls
        /// and communication through the device, providing audio input and output.
        /// </summary>
        BuiltinReceiver,

        /// <summary>
        /// Represents the built-in microphone, used for capturing audio input
        /// from the environment, such as for voice commands, calls, or recordings.
        /// </summary>
        BuiltinMic,

        /// <summary>
        /// Indicates an audio jack that allows the connection of wired accessories
        /// such as headphones and headsets, providing a physical interface for
        /// audio playback and recording.
        /// </summary>
        AudioJack,

        /// <summary>
        /// Represents Bluetooth media devices using the A2DP (Advanced Audio
        /// Distribution Profile) standard for streaming high-quality audio wirelessly.
        /// </summary>
        BluetoothMedia,

        /// <summary>
        /// Represents HDMI audio output, allowing the transmission of high-fidelity
        /// audio and video to external displays or audio receivers through an HDMI cable.
        /// </summary>
        Hdmi,

        /// <summary>
        /// Represents devices used for forwarding audio data, which may involve
        /// relaying audio signals to other devices or systems for processing or playback.
        /// </summary>
        Forwarding,

        /// <summary>
        /// Represents USB audio devices, which connect through USB ports to provide
        /// audio input and output, such as external sound cards or USB microphones.
        /// </summary>
        UsbAudio,

        /// <summary>
        /// Represents Bluetooth voice devices using the SCO (Synchronous Connection
        /// Oriented) profile, primarily used for voice communication over Bluetooth.
        /// </summary>
        BluetoothVoice,

        /// <summary>
        /// Represents devices that transmit audio data over a network, enabling audio
        /// streaming or communication over internet or local networks.
        /// </summary>
        Network
    }
}

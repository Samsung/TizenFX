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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Specifies the flags for the audio device options.
    /// <para>
    /// This enumeration has a <see cref="FlagsAttribute"/> attribute that allows a bitwise combination of its member values.
    /// </para>
    /// </summary>
    [Flags]
    internal enum AudioDeviceOptions
    {
        /// <summary>
        /// Input devices.
        /// </summary>
        Input = 0x0001,
        /// <summary>
        /// Output devices.
        /// </summary>
        Output = 0x0002,
        /// <summary>
        /// Input and output devices (both directions are available).
        /// </summary>
        InputAndOutput = 0x0004,
        /// <summary>
        /// Built-in devices.
        /// </summary>
        Internal = 0x00010,
        /// <summary>
        /// External devices.
        /// </summary>
        External = 0x0020,
        /// <summary>
        /// Deactivated devices.
        /// </summary>
        Deactivated = 0x1000,
        /// <summary>
        /// Activated devices.
        /// </summary>
        Activated = 0x2000,

        /// <summary>
        /// All devices.
        /// </summary>
        All = 0xFFFF
    }

    /// <summary>
    /// Specifies the audio device types.
    /// </summary>
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
        BluetoothVoice
    }

    /// <summary>
    /// Specifies the audio device directions.
    /// </summary>
    public enum AudioDeviceIoDirection
    {
        /// <summary>
        /// Input device.
        /// </summary>
        Input,
        /// <summary>
        /// Output device.
        /// </summary>
        Output,
        /// <summary>
        /// Input/output device (both directions are available).
        /// </summary>
        InputAndOutput
    }

    /// <summary>
    /// Specifies the audio device states.
    /// </summary>
    public enum AudioDeviceState
    {
        /// <summary>
        /// Deactivated state.
        /// </summary>
        Deactivated,
        /// <summary>
        /// Activated state.
        /// </summary>
        Activated
    }

    /// <summary>
    /// Specifies the audio volume types.
    /// </summary>
    public enum AudioVolumeType
    {
        /// <summary>
        /// System.
        /// </summary>
        System,
        /// <summary>
        /// Notification.
        /// </summary>
        Notification,
        /// <summary>
        /// Alarm.
        /// </summary>
        Alarm,
        /// <summary>
        /// Ringtone.
        /// </summary>
        Ringtone,
        /// <summary>
        /// Media.
        /// </summary>
        Media,
        /// <summary>
        /// Call.
        /// </summary>
        Call,
        /// <summary>
        /// VoIP.
        /// </summary>
        Voip,
        /// <summary>
        /// Voice.
        /// </summary>
        Voice,
        /// <summary>
        /// No volume exists.
        /// </summary>
        /// <seealso cref="AudioStreamPolicy.VolumeType"/>
        None
    }

    /// <summary>
    /// Specifies the audio stream types.
    /// </summary>
    public enum AudioStreamType
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
        /// Ringtone for VoIP.
        /// </summary>
        RingtoneVoip,
        /// <summary>
        /// VoIP.
        /// </summary>
        Voip,
        /// <summary>
        /// Media only for external devices.
        /// </summary>
        MediaExternalOnly
    }

    /// <summary>
    /// Specifies the change reasons of the audio stream focus state.
    /// </summary>
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

    /// <summary>
    /// Specifies the flags for the audio stream focus options.
    /// <para>
    /// This enumeration has a <see cref="FlagsAttribute"/> attribute that allows a bitwise combination of its member values.
    /// </para>
    /// </summary>
    [Flags]
    public enum AudioStreamFocusOptions
    {
        /// <summary>
        /// Playback focus.
        /// </summary>
        Playback = 0x0001,
        /// <summary>
        /// Recording focus.
        /// </summary>
        Recording = 0x0002
    }

    /// <summary>
    /// Specifies the audio stream focus states.
    /// </summary>
    public enum AudioStreamFocusState
    {
        /// <summary>
        /// Focus state for release.
        /// </summary>
        Released,
        /// <summary>
        /// Focus state for acquisition.
        /// </summary>
        Acquired
    }

    /// <summary>
    /// Specifies the flags for the audio stream behaviors.
    /// <para>
    /// This enumeration has a <see cref="FlagsAttribute"/> attribute that allows a bitwise combination of its member values.
    /// </para>
    /// </summary>
    [Flags]
    public enum AudioStreamBehaviors
    {
        /// <summary>
        /// No Resume.
        /// </summary>
        NoResume = 0x0001,
        /// <summary>
        /// Fading.
        /// </summary>
        Fading = 0x0002
    }


    internal static class AudioManagerEnumExtensions
    {
        internal static bool IsValid(this AudioStreamFocusOptions value)
        {
            int mask = (int)(AudioStreamFocusOptions.Playback | AudioStreamFocusOptions.Recording);

            return (mask & (int)value) != 0;
        }

        internal static bool IsValid(this AudioStreamBehaviors value)
        {
            int mask = (int)(AudioStreamBehaviors.NoResume | AudioStreamBehaviors.Fading);

            return ((~mask) & (int)value) == 0;
        }
    }

}

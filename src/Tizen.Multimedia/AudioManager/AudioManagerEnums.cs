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
using System.ComponentModel;

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
        /// All devices.
        /// </summary>
        All = 0xFFFF
    }

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
        /// Device for the transmission of audio data over a network
        /// </summary>
        Network
    }

    /// <summary>
    /// Specifies the audio sample formats.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum AudioSampleFormat
    {
        /// <summary>
        /// Unsigned 8 bit samples.
        /// </summary>
        U8,

        /// <summary>
        /// Signed 16 bit samples.
        /// </summary>
        S16LE,

        /// <summary>
        /// Signed 24 bit samples.
        /// </summary>
        S24LE,

        /// <summary>
        /// Signed 24 bit(packed in 32 bit) samples.
        /// </summary>
        S24PackedIn32LE,
    }

    /// <summary>
    /// Specifies the flags for the audio stream behaviors.
    /// <para>
    /// This enumeration has a <see cref="FlagsAttribute"/> attribute that allows a bitwise combination of its member values.
    /// </para>
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
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

    /// <summary>
    /// Specifies the change reasons of the audio stream focus state.
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

    /// <summary>
    /// Specifies the flags for the audio stream focus options.
    /// <para>
    /// This enumeration has a <see cref="FlagsAttribute"/> attribute that allows a bitwise combination of its member values.
    /// </para>
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// <since_tizen> 3 </since_tizen>
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
    /// Specifies the audio stream types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// Specifies the audio volume types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// Specifies the audio effect types.
    /// </summary>
    /// <since_tizen> 11 </since_tizen>
    [Flags]
    public enum AudioEffect
    {
        /// <summary>
        /// Noise suppression for voice call.
        /// </summary>
        NoiseSuppression,

        /// <summary>
        /// Auto Gain Control for normal capturing.
        /// </summary>
        AutoGainControl
    }

    /// <summary>
    /// Specifies the audio effect types with reference device.
    /// </summary>
    /// <since_tizen> 11 </since_tizen>
    public enum AudioEffectWithReference
    {
        /// <summary>
        /// Including reference source.
        /// </summary>
        /// <remarks>
        /// This effect should be used with reference device.
        /// </remarks>
        ReferenceCopy,

        /// <summary>
        /// AEC(Acoustic Echo Cancellation) with speex.
        /// </summary>
        /// <remarks>
        /// This effect should be used with reference device.
        /// </remarks>
        AecSpeex,

        /// <summary>
        /// AEC(Acoustic Echo Cancellation) with webrtc.
        /// </summary>
        /// <remarks>
        /// This effect should be used with reference device.
        /// </remarks>
        AecWebrtc
    }

    internal enum AudioEffectNative
    {
        // These effects can be set together
        NoiseSuppression = 0x0001,
        AutoGainControl = 0x0002,
        // Public enum - AudioEffect - doesn't have All for future expandability.
        All = NoiseSuppression | AutoGainControl
    }

    internal enum AudioEffectNativeWithReference
    {
        ReferenceCopy = 0x0001,
        AecSpeex = 0x0002,
        AecWebrtc = 0x0004
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

        internal static AudioEffect ToPublic(this AudioEffectNative nativeEffect)
        {
            AudioEffect effect = AudioEffect.NoiseSuppression;

            switch (nativeEffect)
            {
                case AudioEffectNative.NoiseSuppression:
                    effect = AudioEffect.NoiseSuppression;
                    break;
                case AudioEffectNative.AutoGainControl:
                    effect = AudioEffect.AutoGainControl;
                    break;
                case AudioEffectNative.All:
                    effect = AudioEffect.NoiseSuppression | AudioEffect.AutoGainControl;
                    break;
                default:
                    break;
            }

            return effect;
        }

        internal static AudioEffectWithReference ToPublic(this AudioEffectNativeWithReference nativeEffect)
        {
            AudioEffectWithReference effect = AudioEffectWithReference.ReferenceCopy;

            switch (nativeEffect)
            {
                case AudioEffectNativeWithReference.ReferenceCopy:
                    effect = AudioEffectWithReference.ReferenceCopy;
                    break;
                case AudioEffectNativeWithReference.AecSpeex:
                    effect = AudioEffectWithReference.AecSpeex;
                    break;
                case AudioEffectNativeWithReference.AecWebrtc:
                    effect = AudioEffectWithReference.AecWebrtc;
                    break;
                default:
                    break;
            }

            return effect;
        }
    }
}

/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// Specifies the sound effect types.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public enum SoundEffectType
    {
        /// <summary>
        /// Noise suppression for voice call.
        /// </summary>
        NoiseSuppression,

        /// <summary>
        /// Auto Gain Control for normal capturing.
        /// </summary>
        AutoGainControl,

        /// <summary>
        /// Noise suppression + Auto Gain Control.
        /// </summary>
        NsWithAgc,

        /// <summary>
        /// Includes the output sound from the reference device in the recorded audio.
        /// </summary>
        /// <remarks>
        /// This effect should be used with <see cref="SoundEffectInfo.ReferenceDevice"/>.
        /// </remarks>
        ReferenceCopy = 0x1001,

        /// <summary>
        /// AEC (Acoustic Echo Cancellation) with Speex.
        /// </summary>
        /// <remarks>
        /// This effect should be used with <see cref="SoundEffectInfo.ReferenceDevice"/>.
        /// </remarks>
        AecSpeex,

        /// <summary>
        /// AEC (Acoustic Echo Cancellation) with WebRTC.
        /// </summary>
        /// <remarks>
        /// This effect should be used with <see cref="SoundEffectInfo.ReferenceDevice"/>.
        /// </remarks>
        AecWebrtc
    }

    /// <summary>
    /// Specifies the sound effect information.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public struct SoundEffectInfo
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SoundEffectInfo"/>.
        /// </summary>
        /// <param name="type">The SoundEffectType.</param>
        /// <exception cref="ArgumentException">Invalid input enum type.</exception>
        /// <since_tizen> 12 </since_tizen>
        public SoundEffectInfo(SoundEffectType type)
        {
            ValidationUtil.ValidateEnum(typeof(SoundEffectType), type, nameof(type));

            Type = type;
            ReferenceDevice = null;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SoundEffectInfo"/> with a reference audio device.
        /// </summary>
        /// <param name="type">The SoundEffectType.</param>
        /// <param name="device">The AudioDevice to be refered.</param>
        /// <since_tizen> 12 </since_tizen>
        public SoundEffectInfo(SoundEffectType type, AudioDevice device)
        {
            ValidationUtil.ValidateEnum(typeof(SoundEffectType), type, nameof(type));

            Type = type;
            ReferenceDevice = device;
        }

        /// <summary>
        /// The SoundEffectType.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public SoundEffectType Type { get; }

        /// <summary>
        /// The AudioDevice used by the SoundEffect as additional source of audio data.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public AudioDevice ReferenceDevice { get; }
    }

    [Flags]
    internal enum SoundEffectNative
    {
        NoiseSuppression = 1,
        AutoGainControl = 2
    }

    internal enum SoundEffectWithReferenceNative
    {
        ReferenceCopy = 1,
        AecSpeex = 2,
        AecWebrtc = 4
    }

    internal static class EnumExtensions
    {
        private const string Tag = "Tizen.Multimedia.AudioManager";

        internal static int ToNative(this SoundEffectType effect)
        {
            int ret = 0;

            /* Native enum values are defined as below:
                typedef enum {
                    SOUND_EFFECT_REFERENCE_COPY              = 0x0001, //< Including reference source
                    SOUND_EFFECT_ACOUSTIC_ECHO_CANCEL_SPEEX  = 0x0002, //< Acoustic echo cancel with speex
                    SOUND_EFFECT_ACOUSTIC_ECHO_CANCEL_WEBRTC = 0x0004, //< Acoustic echo cancel with webrtc
                } sound_effect_method_with_reference_e;

                typedef enum {
                    SOUND_EFFECT_NOISE_SUPPRESSION_VOIP          = 0x0001, //< Noise suppression for voice call
                    SOUND_EFFECT_AUTOMATIC_GAIN_CONTROL_CAPTURE  = 0x0002, //< Auto Gain Control for normal capturing
                } sound_effect_method_e;
            */
            switch (effect)
            {
                case SoundEffectType.NoiseSuppression:
                    ret = 1;
                    break;
                case SoundEffectType.AutoGainControl:
                    ret = 2;
                    break;
                case SoundEffectType.NsWithAgc:
                    ret = 3;
                    break;
                case SoundEffectType.ReferenceCopy:
                    ret = 1;
                    break;
                case SoundEffectType.AecSpeex:
                    ret = 2;
                    break;
                case SoundEffectType.AecWebrtc:
                    ret = 4;
                    break;
                default:
                    Log.Error(Tag, "Invalid sound effect type.");
                    break;
            }

            return ret;
        }

        internal static SoundEffectType ToPublic(this SoundEffectNative effect)
        {
            SoundEffectType ret = SoundEffectType.NoiseSuppression;

            /* Native enum values are defined as below. And these can be set together.
                typedef enum {
                    SOUND_EFFECT_NOISE_SUPPRESSION_VOIP          = 0x0001, //< Noise suppression for voice call
                    SOUND_EFFECT_AUTOMATIC_GAIN_CONTROL_CAPTURE  = 0x0002, //< Auto Gain Control for normal capturing
                } sound_effect_method_e;
            */
            switch (effect)
            {
                case SoundEffectNative.NoiseSuppression:
                    ret = SoundEffectType.NoiseSuppression;
                    break;
                case SoundEffectNative.AutoGainControl:
                    ret = SoundEffectType.AutoGainControl;
                    break;
                case SoundEffectNative.NoiseSuppression | SoundEffectNative.AutoGainControl:
                    ret = SoundEffectType.NsWithAgc;
                    break;
                default:
                    Log.Error(Tag, "Invalid sound effect type.");
                    break;
            }

            return ret;
        }

        internal static SoundEffectType ToPublic(this SoundEffectWithReferenceNative effect)
        {
            SoundEffectType ret = SoundEffectType.ReferenceCopy;

            /* Native enum values are defined as below. And these cannot be set together.
                typedef enum {
                    SOUND_EFFECT_REFERENCE_COPY              = 0x0001, //< Including reference source
                    SOUND_EFFECT_ACOUSTIC_ECHO_CANCEL_SPEEX  = 0x0002, //< Acoustic echo cancel with speex
                    SOUND_EFFECT_ACOUSTIC_ECHO_CANCEL_WEBRTC = 0x0004, //< Acoustic echo cancel with webrtc
                } sound_effect_method_with_reference_e;
            */
            switch (effect)
            {
                case SoundEffectWithReferenceNative.ReferenceCopy:
                    ret = SoundEffectType.ReferenceCopy;
                    break;
                case SoundEffectWithReferenceNative.AecSpeex:
                    ret = SoundEffectType.AecSpeex;
                    break;
                case SoundEffectWithReferenceNative.AecWebrtc:
                    ret = SoundEffectType.AecWebrtc;
                    break;
                default:
                    Log.Error(Tag, "Invalid sound effect type.");
                    break;
            }

            return ret;
        }
    }

}

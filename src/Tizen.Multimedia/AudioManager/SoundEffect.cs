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
    /// Defines the various types of sound effects that can be applied to audio processing.
    /// Each sound effect type serves a specific purpose in enhancing audio quality for different scenarios.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public enum SoundEffectType
    {
        /// <summary>
        /// Applies noise suppression specifically designed for voice calls,
        /// reducing background noise to enhance the clarity of the speaker's voice.
        /// </summary>
        NoiseSuppression,

        /// <summary>
        /// Implements Auto Gain Control (AGC) to automatically adjust the audio levels
        /// during normal audio capturing, ensuring consistent volume regardless of input variations.
        /// </summary>
        AutoGainControl,

        /// <summary>
        /// Combines both Noise Suppression and Auto Gain Control,
        /// providing a comprehensive solution for clear and balanced audio during calls or recordings.
        /// </summary>
        NsWithAgc,

        /// <summary>
        /// Captures and includes the output sound from a reference audio device
        /// in the recorded audio, allowing for enhanced audio mixing and playback. j
        /// This effect is particularly useful when used with <see cref="SoundEffectInfo.ReferenceDevice"/>.
        /// </summary>
        /// <remarks>
        /// This effect should be used in conjunction with <see cref="SoundEffectInfo.ReferenceDevice"/>
        /// to specify the audio source from which the reference sound is taken.
        /// </remarks>
        ReferenceCopy = 0x1001,

        /// <summary>
        /// Implements Acoustic Echo Cancellation (AEC) using the Speex algorithm,
        /// which helps to eliminate echo and improve voice clarity during calls or recordings.
        /// </summary>
        /// <remarks>
        /// This effect should be used with <see cref="SoundEffectInfo.ReferenceDevice"/>
        /// to optimize echo cancellation based on the reference audio input.
        /// </remarks>
        AecSpeex,

        /// <summary>
        /// Utilizes the WebRTC algorithm for Acoustic Echo Cancellation (AEC),
        /// effectively reducing echo and enhancing the quality of audio communications.
        /// </summary>
        /// <remarks>
        /// This effect should be used together with <see cref="SoundEffectInfo.ReferenceDevice"/>
        /// to ensure optimal performance in echo cancellation.
        /// </remarks>
        AecWebrtc
    }

    /// <summary>
    /// Represents the configuration and parameters for applying sound effects to audio processing.
    /// This structure allows you to specify the type of sound effect and, if necessary,
    /// a reference audio device to enhance the audio processing capabilities.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public struct SoundEffectInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SoundEffectInfo"/> structure
        /// with the specified sound effect type. The reference device is set to null.
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
        /// Initializes a new instance of the <see cref="SoundEffectInfo"/> structure
        /// with the specified sound effect type and a reference audio device.
        /// This allows for enhanced audio processing by using additional audio data from the specified device.
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
        /// Gets the type of sound effect that will be applied, as specified in the <see cref="SoundEffectType"/> enum.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public SoundEffectType Type { get; }

        /// <summary>
        /// Gets the reference audio device used by the sound effect as an additional source of audio data.
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

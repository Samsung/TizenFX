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
using System.Diagnostics;
using Native = Interop.AudioEffect;

namespace Tizen.Multimedia
{

    /// <summary>
    /// Represents an equalizer band of <see cref="AudioEffect"/>.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class EqualizerBand
    {
        private readonly AudioEffect _owner;
        private readonly int _index;
        private readonly int _frequency;
        private readonly int _frequencyRange;

        internal EqualizerBand(AudioEffect owner, int index)
        {
            Debug.Assert(owner != null);

            _owner = owner;
            _index = index;
            _frequency = Frequency;
            _frequencyRange = FrequencyRange;

            Log.Debug(PlayerLog.Tag, "frequency : " + _frequency + ", range : " + _frequencyRange);
        }

        /// <summary>
        /// Sets or gets the gain for the equalizer band.
        /// </summary>
        /// <param name="value">The value indicating new gain in decibel(dB).</param>
        /// <exception cref="ObjectDisposedException">The player that this EqualizerBand belongs to has already been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="value"/> is not inside of <see cref="AudioEffect.BandLevelRange"/>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     If audio offload is enabled by calling <see cref="AudioOffload.IsEnabled"/>. (Since tizen 6.0)
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public int Level
        {
            get
            {
                _owner.Player.ValidateNotDisposed();
                _owner.Player.AudioOffload.CheckEnabled();

                Native.GetEqualizerBandLevel(_owner.Player.Handle, _index, out var value).
                    ThrowIfFailed(_owner.Player, "Failed to get the level of the equalizer band");

                Log.Info(PlayerLog.Tag, "get level : " + value);
                return value;
            }
            set
            {
                _owner.Player.ValidateNotDisposed();
                _owner.Player.AudioOffload.CheckEnabled();

                if (value < _owner.BandLevelRange.Min || _owner.BandLevelRange.Max < value)
                {
                    Log.Error(PlayerLog.Tag, "invalid level : " + value);
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        $"valid value range is { nameof(AudioEffect.BandLevelRange) }." +
                        $"but got {value}.");
                }

                Native.SetEqualizerBandLevel(_owner.Player.Handle, _index, value).
                    ThrowIfFailed(_owner.Player, "Failed to set the level of the equalizer band");
            }
        }


        /// <summary>
        /// Gets the frequency in the dB.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     If audio offload is enabled by calling <see cref="AudioOffload.IsEnabled"/>. (Since tizen 6.0)
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public int Frequency
        {
            get
            {
                _owner.Player.AudioOffload.CheckEnabled();

                Native.GetEqualizerBandFrequency(_owner.Player.Handle, _index, out var frequency).
                ThrowIfFailed(_owner.Player, "Failed to initialize equalizer band");

                return frequency;
            }
        }

        /// <summary>
        /// Gets the frequency range in the dB.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     If audio offload is enabled by calling <see cref="AudioOffload.IsEnabled"/>. (Since tizen 6.0)
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public int FrequencyRange
        {
            get
            {
                _owner.Player.AudioOffload.CheckEnabled();

                Native.GetEqualizerBandFrequencyRange(_owner.Player.Handle, _index, out var frequencyRange).
                ThrowIfFailed(_owner.Player, "Failed to initialize equalizer band");

                return frequencyRange;
            }
        }

    }
}

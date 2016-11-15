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

namespace Tizen.Multimedia
{

    /// <summary>
    /// Represents a equalizer band of <see cref="AudioEffect"/>.
    /// </summary>
    public class EqualizerBand
    {
        private readonly AudioEffect _owner;
        private readonly int _index;

        internal EqualizerBand(AudioEffect owner, int index)
        {
            Debug.Assert(owner != null);

            _owner = owner;
            _index = index;

            int frequency = 0;
            int range = 0;

            int ret = Interop.Player.AudioEffectGetEqualizerBandFrequency(_owner.Player.GetHandle(), _index, out frequency);
            PlayerErrorConverter.ThrowIfError(ret, "Failed to initialize equalizer band");

            ret = Interop.Player.AudioEffectGetEqualizerBandFrequencyRange(_owner.Player.GetHandle(), _index, out range);
            PlayerErrorConverter.ThrowIfError(ret, "Failed to initialize equalizer band");

            Frequency = frequency;
            FrequencyRange = range;
        }

        /// <summary>
        /// Sets the gain for the equalizer band.
        /// </summary>
        /// <param name="value">The value indicating new gain in decibel(dB).</param>
        /// <exception cref="ObjectDisposedException">The player that this EqualuzerBand belongs to has already been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     value is less than <see cref="AudioEffect.MinBandLevel"/>.
        ///     <para>-or-</para>
        ///     value is greater than <see cref="AudioEffect.MaxBandLevel"/>.
        /// </exception>
        public void SetLevel(int value)
        {
            _owner.Player.ValidateNotDisposed();

            if (value < _owner.MinBandLevel || _owner.MaxBandLevel < value)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value,
                    $"valid value range is { nameof(AudioEffect.MinBandLevel) } <= level <= { nameof(AudioEffect.MaxBandLevel) }. " +
                    $"but got {value}.");
            }

            int ret = Interop.Player.AudioEffectSetEqualizerBandLevel(_owner.Player.GetHandle(), _index, value);
            PlayerErrorConverter.ThrowIfError(ret, "Failed to set the level of the equalizer band");
        }

        /// <summary>
        /// Gets the gain for the equalizer band.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The player that this EqualuzerBand belongs to has already been disposed of.</exception>
        public int GetLevel()
        {
            _owner.Player.ValidateNotDisposed();

            int value = 0;
            int ret = Interop.Player.AudioEffectGetEqualizerBandLevel(_owner.Player.GetHandle(),
                _index, out value);
            PlayerErrorConverter.ThrowIfError(ret, "Failed to initialize equalizer band");

            return value;
        }

        /// <summary>
        /// Gets the frequency in dB.
        /// </summary>
        public int Frequency { get; }

        /// <summary>
        /// Gets the frequency range oin dB.
        /// </summary>
        public int FrequencyRange { get; }

    }
}

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
using Native = Interop.AudioEffect;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides the ability to control the audio effects for <see cref="Multimedia.Player"/>.
    /// </summary>
    public class AudioEffect
    {
        private readonly EqualizerBand[] _bands;

        internal AudioEffect(Player owner)
        {
            Player = owner;

            bool available = false;

            Native.EqualizerIsAvailable(Player.Handle, out available).
                ThrowIfFailed("Failed to initialize the AudioEffect");

            IsAvailable = available;

            if (IsAvailable == false)
            {
                return;
            }

            int count = 0;
            Native.GetEqualizerBandsCount(Player.Handle, out count).
                ThrowIfFailed("Failed to initialize the AudioEffect");

            int min = 0;
            int max = 0;
            Native.GetEqualizerLevelRange(Player.Handle, out min, out max).
                ThrowIfFailed("Failed to initialize the AudioEffect");

            Count = count;
            BandLevelRange = new Range(min, max);

            _bands = new EqualizerBand[count];
        }

        /// <summary>
        /// Gets a <see cref="EqualizerBand"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the band to get.</param>
        /// <exception cref="ObjectDisposedException">The <see cref="Player"/> has already been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     index is less than zero.\n
        ///     -or-\n
        ///     index is equal to or greater than <see cref="Count"/>.
        /// </exception>
        public EqualizerBand this[int index]
        {
            get
            {
                Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
                Player.ValidateNotDisposed();

                if (index < 0 || Count <= index)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), index,
                        $"Valid index is 0 <= x < { nameof(Count) } ");
                }

                if (_bands[index] == null)
                {
                    _bands[index] = new EqualizerBand(this, index);
                }
                Log.Info(PlayerLog.Tag, "get equalizer band : " + _bands[index]);
                return _bands[index];
            }
        }

        /// <summary>
        /// Clears the equalizer effect.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The <see cref="Player"/> has already been disposed of.</exception>
        public void Clear()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            Player.ValidateNotDisposed();

            Native.EqualizerClear(Player.Handle).
                ThrowIfFailed("Failed to clear equalizer effect");
            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
        }

        /// <summary>
        /// Get the number of items.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Get the band level range of the bands in dB.
        /// </summary>
        public Range BandLevelRange { get; }

        /// <summary>
        /// Gets the value whether the AudioEffect is available or not.
        /// </summary>
        public bool IsAvailable { get; }

        /// <summary>
        /// Gets the player that this AudioEffect belongs to.
        /// </summary>
        public Player Player { get; }
    }
}

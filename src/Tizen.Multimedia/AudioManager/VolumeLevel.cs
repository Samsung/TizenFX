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
    /// Provides a means to control volume levels.
    /// </summary>
    public class VolumeLevel
    {
        internal VolumeLevel()
        {
        }

        /// <summary>
        /// Gets or sets the volume level of the specified <see cref="AudioVolumeType"/>
        /// </summary>
        /// <param name="type">The <see cref="AudioVolumeType"/> to control.</param>
        /// <value>The current volume level.</value>
        /// <remarks>To set volumes, the specified privilege is required.</remarks>
        /// <privilege>http://tizen.org/privilege/volume.set</privilege>
        /// <exception cref="ArgumentException"><paramref name="type"/> is invalid.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="type"/> is <see cref="AudioVolumeType.None"/>.
        ///     -or-
        ///     <paramref name="value"/> is less than zero.
        ///     -or-
        ///     <paramref name="value"/> is greater than <see cref="MaxVolumeLevel.this[AudioVolumeType]"/>.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">Caller does not have required privilege to set volume.</exception>
        public int this[AudioVolumeType type]
        {
            get
            {
                ValidationUtil.ValidateEnum(typeof(AudioVolumeType), type, nameof(type));

                if (type == AudioVolumeType.None)
                {
                    throw new ArgumentOutOfRangeException(nameof(type),
                        "Cannot get volume level for AudioVolumeType.None");
                }

                Interop.AudioVolume.GetVolume(type, out var volume).Validate("Failed to get the volume level");

                return volume;
            }
            set
            {
                ValidationUtil.ValidateEnum(typeof(AudioVolumeType), type, nameof(value));

                if (type == AudioVolumeType.None)
                {
                    throw new ArgumentOutOfRangeException(nameof(type),
                        "Cannot set volume level for AudioVolumeType.None");
                }

                var ret = Interop.AudioVolume.SetVolume(type, value);

                if (ret == AudioManagerError.InvalidParameter)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        $"valid volume level range is 0 <= x <= {nameof(MaxVolumeLevel)}[{nameof(AudioVolumeType)}]");
                }

                ret.Validate("Failed to set the volume level");
            }
        }
    }
}

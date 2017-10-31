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
    /// Provides a means to get max volume levels.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class MaxVolumeLevel
    {
        internal MaxVolumeLevel()
        {
        }

        /// <summary>
        /// Gets the max volume level of the specified <see cref="AudioVolumeType"/>.
        /// </summary>
        /// <param name="type">The <see cref="AudioVolumeType"/> to query.</param>
        /// <value>The maximum volume level.</value>
        /// <exception cref="ArgumentException"><paramref name="type"/> is invalid.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="type"/> is <see cref="AudioVolumeType.None"/>.</exception>
        /// <since_tizen> 3 </since_tizen>
        public int this[AudioVolumeType type]
        {
            get
            {
                ValidationUtil.ValidateEnum(typeof(AudioVolumeType), type, nameof(type));

                if (type == AudioVolumeType.None)
                {
                    throw new ArgumentOutOfRangeException(nameof(type),
                        "Cannot get max volume level for AudioVolumeType.None");
                }

                Interop.AudioVolume.GetMaxVolume(type, out var maxVolume).
                    Validate("Failed to get the max volume level");

                return maxVolume;
            }
        }
    }
}

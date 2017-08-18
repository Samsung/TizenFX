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
    /// Provides data for the <see cref="AudioVolume.Changed"/> event.
    /// </summary>
    public class VolumeChangedEventArgs : EventArgs
    {
        internal VolumeChangedEventArgs(AudioVolumeType type, uint level)
        {
            Type = type;
            Level = (int)level;
        }

        /// <summary>
        /// Gets the sound type that volume is changed.
        /// </summary>
        /// <value>The sound type that volume is changed.</value>
        public AudioVolumeType Type { get; }

        /// <summary>
        /// Gets the new volume.
        /// </summary>
        /// <value>The new volume level.</value>
        public int Level { get; }
    }
}

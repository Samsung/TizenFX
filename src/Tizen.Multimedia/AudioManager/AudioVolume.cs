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
    /// Provides the ability to control the volume levels.
    /// </summary>
    /// <seealso cref="AudioManager"/>
    public class AudioVolume
    {
        private const string Tag = "Tizen.Multimedia.AudioVolume";

        private int _volumeChangedCallbackId = -1;
        private EventHandler<VolumeChangedEventArgs> _volumeChanged;
        private Interop.AudioVolume.VolumeChangedCallback _volumeChangedCallback;

        private object _eventLock = new object();

        internal AudioVolume()
        {
            Level = new VolumeLevel();
            MaxLevel = new MaxVolumeLevel();
        }

        /// <summary>
        /// Occurs when the volume level is changed.
        /// </summary>
        public event EventHandler<VolumeChangedEventArgs> Changed
        {
            add
            {
                lock (_eventLock)
                {
                    if (_volumeChanged == null)
                    {
                        RegisterVolumeChangedEvent();
                    }
                    _volumeChanged += value;
                }
            }
            remove
            {
                if (value == null)
                {
                    return;
                }

                lock (_eventLock)
                {
                    if (_volumeChanged == value)
                    {
                        UnregisterVolumeChangedEvent();
                    }
                    _volumeChanged -= value;
                }
            }
        }

        /// <summary>
        /// Gets the volume type of the sound being currently played.
        /// </summary>
        /// <value>The volume type of the sound being currently played.</value>
        public AudioVolumeType CurrentPlaybackType
        {
            get
            {
                var ret = Interop.AudioVolume.GetCurrentSoundType(out var currentType);
                if (ret == AudioManagerError.NoPlayingSound)
                {
                    return AudioVolumeType.None;
                }
                ret.Validate("Failed to get current volume type");

                return currentType;
            }
        }

        /// <summary>
        /// Gets the <see cref="VolumeLevel"/>.
        /// </summary>
        /// <value>The <see cref="VolumeLevel"/>.</value>
        public VolumeLevel Level { get; }

        /// <summary>
        /// Gets the <see cref="MaxVolumeLevel"/>.
        /// </summary>
        /// <value>The <see cref="MaxVolumeLevel"/>.</value>
        public MaxVolumeLevel MaxLevel { get; }

        private void RegisterVolumeChangedEvent()
        {
            _volumeChangedCallback = (AudioVolumeType type, uint volume, IntPtr userData) =>
            {
                _volumeChanged?.Invoke(this, new VolumeChangedEventArgs(type, volume));
            };
            var error = Interop.AudioVolume.AddVolumeChangedCallback(_volumeChangedCallback, IntPtr.Zero,
                out _volumeChangedCallbackId);
            Log.Info(Tag, $"VolumeController callback id:{_volumeChangedCallbackId}");

            error.Validate("Failed to add volume changed event");
        }

        private void UnregisterVolumeChangedEvent()
        {
            Interop.AudioVolume.RemoveVolumeChangedCallback(_volumeChangedCallbackId).
                Validate("Failed to remove volume changed event");
        }
    }
}

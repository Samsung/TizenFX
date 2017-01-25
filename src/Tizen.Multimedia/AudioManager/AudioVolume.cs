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
    internal static class AudioVolumeLog
    {
        internal const string Tag = "Tizen.Multimedia.AudioVolume";
    }

    /// <summary>
    /// The AudioVolume API provides functions to check and control volumes.
    /// </summary>
    public class AudioVolume
    {
        private static int _volumeChangedCallbackId = -1;
        private EventHandler<VolumeChangedEventArgs> _volumeChanged;
        private Interop.SoundManagerVolumeChangedCallback _volumeChangedCallback;

        public AudioVolume()
        {
            Level = new VolumeLevel();
            MaxLevel = new MaxVolumeLevel();
        }

        /// <summary>
        /// Registers a function to be invoked when the volume level is changed.
        /// </summary>
        public event EventHandler<VolumeChangedEventArgs> Changed {
            add {
                Tizen.Log.Info(AudioVolumeLog.Tag, "VolumeController Changed Event added....");
                if(_volumeChanged == null) {
                    RegisterVolumeChangedEvent();
                }
                _volumeChanged += value;
            }
            remove {
                Tizen.Log.Info(AudioVolumeLog.Tag, "VolumeController Changed Event removed....");
                if(_volumeChanged?.GetInvocationList()?.GetLength(0) == 1) {
                    UnregisterVolumeChangedEvent();
                }
                _volumeChanged -= value;
            }
        }

        /// <summary>
        /// The Audio Manager has predefined volume types.(system, notification, alarm, ringtone, media, call, voip, voice).
        /// The volume type of the sound being currently played.
        /// </summary>
        public AudioVolumeType CurrentPlaybackType {
            get {
                AudioVolumeType currentType;
                int ret = Interop.AudioVolume.GetCurrentSoundType(out currentType);
                if(ret != 0) {
                    Tizen.Log.Info(AudioVolumeLog.Tag, "Unable to get current playback sound type" + (AudioManagerError)ret);
                    return AudioVolumeType.None;
                }
                return currentType;
            }
        }

        /// <summary>
        /// The indexer class which is used to get/set volume level specified for a particular sound type.
        /// </summary>
        public VolumeLevel Level;

        /// <summary>
        /// The indexer class which is used to get maximum volume level supported for a particular sound type.
        /// </summary>
        public MaxVolumeLevel MaxLevel;

        private void RegisterVolumeChangedEvent()
        {
            _volumeChangedCallback = (AudioVolumeType type, uint volume, IntPtr userData) => {
                VolumeChangedEventArgs eventArgs = new VolumeChangedEventArgs(type, volume);
                _volumeChanged.Invoke(this, eventArgs);
            };
            int error = Interop.AudioVolume.AddVolumeChangedCallback(_volumeChangedCallback, IntPtr.Zero, out _volumeChangedCallbackId);
            Tizen.Log.Info(AudioVolumeLog.Tag, "VolumeController Add Changed Event return id:" + _volumeChangedCallbackId + "error:" + error);
            AudioManagerErrorFactory.CheckAndThrowException(error, "unable to add level changed callback");
        }

        private void UnregisterVolumeChangedEvent()
        {
            if (_volumeChangedCallbackId > 0) {
                int error = Interop.AudioVolume.RemoveVolumeChangedCallback(_volumeChangedCallbackId);
                Tizen.Log.Info(AudioVolumeLog.Tag, "VolumeController Remove Changed Event(id:" + _volumeChangedCallbackId + ") return error: " + error);
                AudioManagerErrorFactory.CheckAndThrowException(error, "unable to remove level changed callback");
            }
        }
    }
}

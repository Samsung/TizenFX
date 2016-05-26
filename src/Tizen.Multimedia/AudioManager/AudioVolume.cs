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
        public event EventHandler<VolumeChangedEventArgs> Changed
        {
            add
            {
                Tizen.Log.Info(AudioVolumeLog.Tag, "VolumeController Changed Event added....");
                if (_volumeChanged == null)
                {
                    RegisterVolumeChangedEvent();
                }
                _volumeChanged += value;
            }
            remove
            {
                Tizen.Log.Info(AudioVolumeLog.Tag, "VolumeController Changed Event removed....");
                _volumeChanged -= value;
                if (_volumeChanged == null)
                {
                    UnregisterVolumeChangedEvent();
                }
            }
        }

        /// <summary>
        /// The Sound Manager has predefined types of sounds.(system, notification, alarm, ringtone, media, call, voip, voice).
        /// The type of the sound being currently played.
        /// </summary>
        public AudioVolumeType CurrentType
        {
            get
            {
                AudioVolumeType currentType;
                int ret = Interop.AudioVolume.GetCurrentSoundType(out currentType);
                if ( ret != 0)
                {
                    Tizen.Log.Info(AudioVolumeLog.Tag, "Unable to get current sound type" + (AudioManagerError)ret);
                    return AudioVolumeType.None;
                }
                return currentType;
            }
            set
            {
                int ret = Interop.AudioVolume.SetCurrentSoundType(value);
                if (ret != 0)
                {
                    if (value == AudioVolumeType.None)
                    {
                        ret = Interop.AudioVolume.UnsetCurrentType();
                    }
                }
                AudioManagerErrorFactory.CheckAndThrowException(ret, "unable to set current sound type");
            }
        }

        public VolumeLevel Level;

        public MaxVolumeLevel MaxLevel;

        private void RegisterVolumeChangedEvent()
        {
            _volumeChangedCallback = (AudioVolumeType type, uint volume, IntPtr userData) =>
            {
                VolumeChangedEventArgs eventArgs = new VolumeChangedEventArgs(type, volume);
                _volumeChanged.Invoke(this, eventArgs);
            };
            int error = Interop.AudioVolume.SetVolumeChangedCallback(_volumeChangedCallback, IntPtr.Zero);
            Tizen.Log.Info(AudioVolumeLog.Tag, "VolumeController Changed Event return:" + error);
            AudioManagerErrorFactory.CheckAndThrowException(error, "unable to set level changed callback");
        }

        private void UnregisterVolumeChangedEvent()
        {
            int error = Interop.AudioVolume.UnsetVolumeChangedCallback();
            Tizen.Log.Info(AudioVolumeLog.Tag, "VolumeController Changed Unset Event return: " + error);
            AudioManagerErrorFactory.CheckAndThrowException(error, "unable to unset level changed callback");
        }
    }
}
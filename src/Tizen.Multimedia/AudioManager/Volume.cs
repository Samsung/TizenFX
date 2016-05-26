using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The Volume API provides functions to check and control volumes. 
    /// </summary>
    public class Volume
    {
        private EventHandler<VolumeChangedEventArgs> _volumeChanged;
        private Interop.SoundManagerVolumeChangedCallback _volumeChangedCallback;


        /// <summary>
        /// The Sound Manager has predefined types of sounds.(system, notification, alarm, ringtone, media, call, voip, voice).
        /// The type of the sound being currently played.
        /// </summary>
        public AudioType CurrentType 
        {
            get
            {
                AudioType currentType;
                int ret = Interop.Volume.GetCurrentSoundType(out currentType);
                if ( ret != 0)
                {
                    if(ret == (int)AudioManagerError.NoPlayingSound){
                        return AudioType.None;
                    }
                    AudioManagerErrorFactory.CheckAndThrowException(ret, "unable to get current sound type");
                    Console.WriteLine("Not set");
                }
                return currentType;
            }

            set
            {
                int ret = Interop.Volume.SetCurrentSoundType(value);
                if (ret != 0)
                {
                    if (value == AudioType.None)
                    {
                        ret = Interop.Volume.UnsetCurrentType();
                    }
                }
                AudioManagerErrorFactory.CheckAndThrowException(ret, "unable to set current sound type");
            } 
        }

        public VolumeLevel Level;
        public MaxVolumeLevel MaxLevel;


        public Volume()
        {
            Level = new VolumeLevel();
            MaxLevel = new MaxVolumeLevel();
        }

        /// <summary>
        /// Gets the maximum volume level supported for a particular sound type.
        /// </summary>
        /// <param name="type">The sound type</param>
        /// <returns>The maximum volume level</returns>
        public int GetMaxVolume(AudioType type)
        {
            int maxVolume;
            int ret = Interop.Volume.GetMaxVolume(type, out maxVolume);
            AudioManagerErrorFactory.CheckAndThrowException(ret, "unable to get max volume");
            return maxVolume;
        }

        /// <summary>
        /// Sets the volume level specified for a particular sound type.
        /// </summary>
        /// <param name="type">The sound type</param>
        /// <param name="volumeValue">The volume level to be set</param>
        public void SetVolume(AudioType type, int volumeValue)
        {           
            int ret = Interop.Volume.SetVolume(type, volumeValue);
            AudioManagerErrorFactory.CheckAndThrowException(ret, "unable to set volume");
            return;
        }

        /// <summary>
        /// Gets the volume level specified for a particular sound type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetVolume(AudioType type)
        {
            int volume;
            int ret = Interop.Volume.GetVolume(type, out volume);
            AudioManagerErrorFactory.CheckAndThrowException(ret, "unable to get volume");
            return volume;
        }

        /// <summary>
        /// Unsets the type of the sound being currently played.
        /// </summary>
        public void UnsetCurrentType()
        {
            int ret = Interop.Volume.UnsetCurrentType();
            AudioManagerErrorFactory.CheckAndThrowException(ret, "unable to unset current type");

            return;
        }

        /// <summary>
        /// Registers a function to be invoked when the volume level is changed.
        /// </summary>
        public event EventHandler<VolumeChangedEventArgs> Changed
        {
            add
            {
               Console.WriteLine("VolumeController Changed Event added....");
                if (_volumeChanged == null)
                {
                    RegisterVolumeChangedEvent();
                }
                _volumeChanged += value;
            }
            remove
            {
                Console.WriteLine("VolumeController Changed Event removed");
                _volumeChanged -= value;
                if (_volumeChanged == null)
                {
                    UnregisterVolumeChangedEvent();
                }
               
            }
        }

        private void RegisterVolumeChangedEvent()
        {
            _volumeChangedCallback = (AudioType type, uint volume, IntPtr userData) =>
            {
                VolumeChangedEventArgs eventArgs = new VolumeChangedEventArgs(type, volume);
                _volumeChanged.Invoke(this, eventArgs);
            };
            int error = Interop.Volume.SetVolumeChangedCallback(_volumeChangedCallback, IntPtr.Zero);
			AudioManagerErrorFactory.CheckAndThrowException(error, "unable to set volume changed callback");
            Console.WriteLine("VolumeController Changed Event return:" + error);
        }

        private void UnregisterVolumeChangedEvent()
        {
            int error = Interop.Volume.UnsetVolumeChangedCallback();
			AudioManagerErrorFactory.CheckAndThrowException(error, "unable to unset volume changed callback");
            Console.WriteLine("VolumeController Changed Unset Event return:" + error);
        }



    }

}

    
   

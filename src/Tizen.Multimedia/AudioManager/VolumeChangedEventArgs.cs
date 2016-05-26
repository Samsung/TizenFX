using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Extnded EventArgs which contains the parameteres to be passed to the AudioVolume Changed event
    /// </summary>
    public class VolumeChangedEventArgs : EventArgs{

        private AudioVolumeType _type;
        private uint _level;

        internal VolumeChangedEventArgs(AudioVolumeType type, uint level)
        {
            _type = type;
            _level = level;
        }

        /// <summary>
        ///  The sound type of the changed volume
        /// </summary>
        public AudioVolumeType Type 
        {
            get
            {
                return _type;
            }
        }

        /// <summary>
        /// The new volume value
        /// </summary>
        public uint Level
        {
            get
            {
                return _level;
            }
        }
    }
}
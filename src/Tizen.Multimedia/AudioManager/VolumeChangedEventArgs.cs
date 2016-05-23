using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Extnded EventArgs which contains the parameteres to be passed to the Volume Changed event
    /// </summary>
    public class VolumeChangedEventArgs : EventArgs{

        private AudioType _type;
        private uint _volume;

        internal VolumeChangedEventArgs(AudioType type, uint volume)
        {
            _type = type;
            _volume = volume;
        }


        /// <summary>
        ///  The sound type of the changed volume
        /// </summary>
        public AudioType Type 
        {
            get
            {
                return _type;
            }
        }
        /// <summary>
        /// The new volume value
        /// </summary>
        public uint Volume
        {
            get
            {
                return _volume;
            }  
        }
    }
}


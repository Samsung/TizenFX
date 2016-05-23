using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Class extending EventArgs which contains parameters to be passed to event handler of DeviceInformationChanged event
    /// </summary>
    public class AudioDevicePropertyChangedEventArgs : EventArgs
    {
        private AudioDevice _device;
        private AudioDeviceProperty _changedProperty;

        internal AudioDevicePropertyChangedEventArgs(AudioDevice device, AudioDeviceProperty changedInfo)
        {
            _device = device;
            _changedProperty = changedInfo;
        }

        /// <summary>
        /// The object of sound device
        /// </summary>
        public AudioDevice Device
        {
            get
            {
                return _device;
            }
        }

        /// <summary>
        /// The entry of sound device information
        /// </summary>
        public AudioDeviceProperty ChangedInfo
        {
            get
            {
                return _changedProperty;
            }
        }
    }
}

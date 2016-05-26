using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Class extending EventArgs which contains parameters to be passed to event handler of DeviceConnected event
    /// </summary>
    public class AudioDeviceConnectionStateChangedEventArgs : EventArgs
    {
        private AudioDevice _device;
        private bool _isConnected;

        internal AudioDeviceConnectionStateChangedEventArgs(AudioDevice device, bool isConnected)
        {
            _device = device;
            _isConnected = isConnected;
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
        /// The state of device connection: (true = connected, false = disconnected)
        /// </summary>
        public bool IsConnected
        { 
            get
            {
                return _isConnected;
            }
        }
    } 

}

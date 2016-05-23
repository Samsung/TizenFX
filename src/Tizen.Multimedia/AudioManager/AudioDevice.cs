using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace Tizen.Multimedia
{
    /// <summary>
    /// The Device API provides functions to query the information of sound devices.
    /// </summary>
    public class AudioDevice
    {
        internal IntPtr _handle;
        private int _id;
        private string _name;
        private AudioDeviceType _type;
        private AudioDeviceIoDirection _ioDirection;
        private AudioDeviceState _state;
       
        /// <summary>
        /// The id of the device. 
        /// </summary>
        public int Id {
            get
            {
                return _id;
            } 
        }

        /// <summary>
        /// The name of the device. 
        /// </summary>
        public string Name { 
            get 
            {
                return _name;
          
            } 
        }

        /// <summary>
        /// The type of the device.
        /// </summary>
        public AudioDeviceType Type { 
            get
            {
                return _type;
            } 
        }

        /// <summary>
        /// The io direction of the device.
        /// </summary>
        public AudioDeviceIoDirection IoDirection { 
            get 
            {
                return _ioDirection;
            }
        }

        /// <summary>
        /// The state of the device. 
        /// </summary>
        public AudioDeviceState State { 
            get
            {         
                return _state;
            } 
        }

         
        /// <summary>
        /// Constructor : creates a Device object using the handle obtained from CAPI.
        /// </summary>
        /// <param name="?">Sound device handle from CAPI.</param>
        internal AudioDevice(IntPtr deviceHandle)
        {
            _handle = deviceHandle;
            int ret;
            IntPtr name;

            ret = Interop.Device.GetDeviceId(_handle, out _id);
			AudioManagerErrorFactory.CheckAndThrowException(ret, _handle, "Unable to get device Id");

            ret = Interop.Device.GetDeviceName(_handle, out name);
			AudioManagerErrorFactory.CheckAndThrowException(ret, _handle, "Unable to get device name");
            _name = Marshal.PtrToStringAuto(name);

            ret = Interop.Device.GetDeviceType(_handle, out _type);
            AudioManagerErrorFactory.CheckAndThrowException(ret, _handle, "Unable to get device type");

            ret = Interop.Device.GetDeviceIoDirection(_handle, out _ioDirection);
            AudioManagerErrorFactory.CheckAndThrowException(ret, _handle, "Unable to get device IO direction");

            ret = Interop.Device.GetDeviceState(_handle, out _state);
            AudioManagerErrorFactory.CheckAndThrowException(ret, _handle, "Unable to get device state");
        }      

    }
}

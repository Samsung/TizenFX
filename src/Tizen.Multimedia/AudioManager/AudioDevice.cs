using System;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    internal static class AudioDeviceLog
    {
        internal const string Tag = "Tizen.Multimedia.AudioDevice";
    }

    /// <summary>
    /// The Device API provides functions to query the information of sound devices.
    /// </summary>
    public class AudioDevice
    {
        private int _id;
        private string _name;
        private AudioDeviceType _type;
        private AudioDeviceIoDirection _ioDirection;
        private AudioDeviceState _state;
        private IntPtr _handle;

        internal AudioDevice(IntPtr deviceHandle)
        {
            _handle = deviceHandle;
            int ret;

            ret = Interop.AudioDevice.GetDeviceId(_handle, out _id);
            if (ret != 0)
            {
                Tizen.Log.Error(AudioDeviceLog.Tag, "Unable to get device Id: " + (AudioManagerError)ret);
            }
            AudioManagerErrorFactory.CheckAndThrowException(ret, _handle, "Unable to get device Id");

            IntPtr name;
            ret = Interop.AudioDevice.GetDeviceName(_handle, out name);
            if (ret != 0)
            {
                Tizen.Log.Error(AudioDeviceLog.Tag, "Unable to get device name" + (AudioManagerError)ret);
            }
            AudioManagerErrorFactory.CheckAndThrowException(ret, _handle, "Unable to get device name");

            _name = Marshal.PtrToStringAnsi(name);

            ret = Interop.AudioDevice.GetDeviceType(_handle, out _type);
            if (ret != 0)
            {
                Tizen.Log.Error(AudioDeviceLog.Tag, "Unable to get device type" + (AudioManagerError)ret);
            }
            AudioManagerErrorFactory.CheckAndThrowException(ret, _handle, "Unable to get device type");

            ret = Interop.AudioDevice.GetDeviceIoDirection(_handle, out _ioDirection);
            if (ret != 0)
            {
                Tizen.Log.Error(AudioDeviceLog.Tag, "Unable to get device IoDirection" + (AudioManagerError)ret);
            }
            AudioManagerErrorFactory.CheckAndThrowException(ret, _handle, "Unable to get device IO Direction");

            ret = Interop.AudioDevice.GetDeviceState(_handle, out _state);
            if (ret != 0)
            {
                Tizen.Log.Error(AudioDeviceLog.Tag, "Unable to get device state" + (AudioManagerError)ret);
            }
            AudioManagerErrorFactory.CheckAndThrowException(ret, _handle, "Unable to get device state");
        }

        /// <summary>
        /// The id of the device.
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// The name of the device.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// The type of the device.
        /// </summary>
        public AudioDeviceType Type
        {
            get
            {
                return _type;
            }
        }

        /// <summary>
        /// The io direction of the device.
        /// </summary>
        public AudioDeviceIoDirection IoDirection
        {
            get
            {
                return _ioDirection;
            }
        }

        /// <summary>
        /// The state of the device.
        /// </summary>
        public AudioDeviceState State
        {
            get
            {
                return _state;
            }
        }

        internal IntPtr Handle
        {
            get
            {
                return _handle;
            }
        }
    }
}

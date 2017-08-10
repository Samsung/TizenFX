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
        private readonly int _id;
        private readonly string _name;
        private readonly AudioDeviceType _type;
        private readonly AudioDeviceIoDirection _ioDirection;
        private readonly AudioDeviceState _state;
        private readonly IntPtr _handle;

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
        public int Id => _id;

        /// <summary>
        /// The name of the device.
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// The type of the device.
        /// </summary>
        public AudioDeviceType Type => _type;

        /// <summary>
        /// The io direction of the device.
        /// </summary>
        public AudioDeviceIoDirection IoDirection => _ioDirection;

        /// <summary>
        /// The state of the device.
        /// </summary>
        public AudioDeviceState State => _state;

        internal IntPtr Handle => _handle;
    }
}

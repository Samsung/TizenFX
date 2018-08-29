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
    /// <summary>
    /// Provides the ability to query the information of sound devices.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AudioDevice
    {
        private readonly int _id;
        private readonly AudioDeviceType _type;
        private readonly AudioDeviceIoDirection _ioDirection;
        private readonly IntPtr _deviceHandle;

        internal AudioDevice(IntPtr deviceHandle)
        {
            int ret = Interop.AudioDevice.GetDeviceId(deviceHandle, out _id);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.AudioDevice.GetDeviceName(deviceHandle, out var name);
            MultimediaDebug.AssertNoError(ret);

            Name = Marshal.PtrToStringAnsi(name);

            ret = Interop.AudioDevice.GetDeviceType(deviceHandle, out _type);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.AudioDevice.GetDeviceIoDirection(deviceHandle, out _ioDirection);
            MultimediaDebug.AssertNoError(ret);

            _deviceHandle = deviceHandle;
        }

        /// <summary>
        /// Gets the ID of the device.
        /// </summary>
        /// <value>The id of the device.</value>
        /// <since_tizen> 3 </since_tizen>
        public int Id => _id;

        /// <summary>
        /// Gets the name of the device.
        /// </summary>
        /// <value>The name of the device.</value>
        /// <since_tizen> 3 </since_tizen>
        public string Name { get; }

        /// <summary>
        /// Gets the type of the device.
        /// </summary>
        /// <value>The <see cref="AudioDeviceType"/> of the device.</value>
        /// <since_tizen> 3 </since_tizen>
        public AudioDeviceType Type => _type;

        /// <summary>
        /// Gets the IO direction of the device.
        /// </summary>
        /// <value>The IO direction of the device.</value>
        /// <since_tizen> 3 </since_tizen>
        public AudioDeviceIoDirection IoDirection => _ioDirection;

        /// <summary>
        /// Gets the state of the device.
        /// </summary>
        /// <value>The <see cref="AudioDeviceState"/> of the device.</value>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 5. Please use the IsRunning property instead.")]
        public AudioDeviceState State
        {
            get
            {
                Interop.AudioDevice.GetDeviceState(Id, out var state).
                    ThrowIfError("Failed to get the state of the device");

                return state;
            }
        }

        /// <summary>
        /// Gets the running state of the device.
        /// </summary>
        /// <value>true if the audio stream of device is running actually; otherwise, false.</value>
        /// <since_tizen> 5 </since_tizen>
        public bool IsRunning
        {
            get
            {
                Interop.AudioDevice.IsDeviceRunning(_id, out bool isRunning).
                    ThrowIfError("Failed to get the running state of the device");

                return isRunning;
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override string ToString() =>
            $"Id={Id}, Name={Name}, Type={Type}, IoDirection={IoDirection}, IsRunning={IsRunning}";

        /// <summary>
        /// Compares an object to an instance of <see cref="AudioDevice"/> for equality.
        /// </summary>
        /// <param name="obj">A <see cref="Object"/> to compare.</param>
        /// <returns>true if the two devices are equal; otherwise, false.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override bool Equals(object obj)
        {
            var rhs = obj as AudioDevice;
            if (rhs == null)
            {
                return false;
            }

            return Id == rhs.Id;
        }


        /// <summary>
        /// Gets the hash code for this instance of <see cref="AudioDevice"/>.
        /// </summary>
        /// <returns>The hash code for this instance of <see cref="AudioDevice"/>.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

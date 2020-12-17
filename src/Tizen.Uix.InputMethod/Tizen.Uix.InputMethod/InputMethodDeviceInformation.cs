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
using System.Collections.Generic;
using System.Text;
using static Interop.InputMethod;

namespace Tizen.Uix.InputMethod
{
    /// <summary>
    /// Enumeration for the device class.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum DeviceClass
    {
        /// <summary>
        /// None.
        /// </summary>
        None,
        /// <summary>
        /// Seat.
        /// </summary>
        Seat,
        /// <summary>
        /// Keyboard.
        /// </summary>
        Keyboard,
        /// <summary>
        /// Mouse.
        /// </summary>
        Mouse,
        /// <summary>
        /// Touch.
        /// </summary>
        Touch,
        /// <summary>
        /// Pen.
        /// </summary>
        Pen,
        /// <summary>
        /// Pointer.
        /// </summary>
        Pointer,
        /// <summary>
        /// Gamepad.
        /// </summary>
        Gamepad,
        /// <summary>
        /// Undefined.
        /// </summary>
        Undefined
    };

    /// <summary>
    /// Enumeration for the device subclass.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum DeviceSubclass
    {
        /// <summary>
        /// None.
        /// </summary>
        None,
        /// <summary>
        /// Finger.
        /// </summary>
        Finger,
        /// <summary>
        /// FingerNail.
        /// </summary>
        FingerNail,
        /// <summary>
        /// Knuckle.
        /// </summary>
        Knuckle,
        /// <summary>
        /// Palm.
        /// </summary>
        Palm,
        /// <summary>
        /// HandSize.
        /// </summary>
        HandSize,
        /// <summary>
        /// HandFlat.
        /// </summary>
        HandFlat,
        /// <summary>
        /// PenTip.
        /// </summary>
        PenTip,
        /// <summary>
        /// Trackpad.
        /// </summary>
        Trackpad,
        /// <summary>
        /// Trackpoint.
        /// </summary>
        Trackpoint,
        /// <summary>
        /// Trackball.
        /// </summary>
        Trackball,
        /// <summary>
        /// Undefined.
        /// </summary>
        Undefined
    };

    /// <summary>
    /// This class gives the device information, like the name, class, and subclass.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class InputMethodDeviceInformation
    {
        private IntPtr _handle;
        internal InputMethodDeviceInformation(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Gets the device name of the key event.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Name
        {
            get
            {
                string name;
                ErrorCode error = ImeDeviceInfoGetName(_handle, out name);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetName Failed with error " + error);
                    return "";
                }
                return name;
            }
        }

        /// <summary>
        /// Gets the device class of the key event.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public DeviceClass DeviceClass
        {
            get
            {
                DeviceClass devClass;
                ErrorCode error = ImeDeviceInfoGetClass(_handle, out devClass);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetClass Failed with error " + error);
                    return DeviceClass.Undefined;
                }
                return devClass;
            }
        }

        /// <summary>
        /// Gets the device subclass of the key event.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public DeviceSubclass DeviceSubclass
        {
            get
            {
                DeviceSubclass subclass;
                ErrorCode error = ImeDeviceInfoGetSubclass(_handle, out subclass);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetSubclass Failed with error " + error);
                    return DeviceSubclass.Undefined;
                }
                return subclass;
            }
        }
    }
}

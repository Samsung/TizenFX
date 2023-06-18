/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// DeviceInfo is used when a device such as a mouse or keyboard is connected or disconnected.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DeviceInfo : Disposable
    {

        /// <summary>
        /// The default constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DeviceInfo() : this(Interop.DeviceInfo.NewDeviceInfo((int)DeviceInfo.StateType.None, "", "", ""), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="state">The state of the event.</param>
        /// <param name="name">The device name</param>
        /// <param name="identifier">The identifier.</param>
        /// <param name="seatname">The seat name.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DeviceInfo(DeviceInfo.StateType state, string name, string identifier, string seatname) : this(Interop.DeviceInfo.NewDeviceInfo((int)state, name, identifier, seatname), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal DeviceInfo(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The state of the device info event.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum StateType
        {
            /// <summary>
            /// Default value
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            None,

            /// <summary>
            /// device added
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Added,

            /// <summary>
            /// device removed
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Removed
        }

        /// <summary>
        /// The state of the device info event.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DeviceInfo.StateType State
        {
            get
            {
                return state;
            }
        }

        /// <summary>
        /// The device name
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// The identifier
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Identifier
        {
            get
            {
                return identifier;
            }
        }

        /// <summary>
        /// The seat name
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SeatName
        {
            get
            {
                return seatName;
            }
        }

        /// <summary>
        /// Get the device class the device info event originated from.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DeviceClassType DeviceClass
        {
            get
            {
                return deviceClass;
            }
        }

        /// <summary>
        /// Get the device subclass the device info event originated from.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DeviceSubClassType DeviceSubClass
        {
            get
            {
                return deviceSubClass;
            }
        }

        private DeviceInfo.StateType state
        {
            get
            {
                DeviceInfo.StateType ret = (DeviceInfo.StateType)Interop.DeviceInfo.TypeGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private string name
        {
            get
            {
                string ret = Interop.DeviceInfo.NameGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private string identifier
        {
            get
            {
                string ret = Interop.DeviceInfo.IdentifierGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private string seatName
        {
            get
            {
                string ret = Interop.DeviceInfo.SeatNameGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private DeviceClassType deviceClass
        {
            get
            {
                int ret = Interop.DeviceInfo.DeviceClassGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return (DeviceClassType)ret;
            }
        }

        private DeviceSubClassType deviceSubClass
        {
            get
            {
                int ret = Interop.DeviceInfo.DeviceSubClassGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return (DeviceSubClassType)ret;
            }
        }

        internal static DeviceInfo GetDeviceInfoFromPtr(global::System.IntPtr cPtr)
        {
            DeviceInfo ret = new DeviceInfo(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.DeviceInfo.DeleteDeviceInfo(swigCPtr);
        }
    }
}

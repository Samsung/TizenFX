/*
 * Copyright(c) 2026 Samsung Electronics Co., Ltd.
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

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// Selects the input devices that a set of gesture options or recognition thresholds applies to.<br />
    /// A selector matches a gesture by the exact name of the device that started it, by the device class and subclass,
    /// or by the device class alone. When several selectors registered on the same object match one gesture,
    /// the most specific one wins: device name first, then class and subclass, then class.<br />
    /// Device names are compared exactly (case-sensitive, no normalization). Read the name to use from
    /// <see cref="Touch.GetDeviceName(uint)"/> or <see cref="Gesture.DeviceName"/>.
    /// </summary>
    /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class GestureDeviceSelector : Disposable
    {
        /// <summary>
        /// How a selector matches an input device.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum MatchType
        {
            /// <summary>
            /// Matches the exact device name.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            DeviceName = 0,

            /// <summary>
            /// Matches the device class only.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            DeviceClass = 1,

            /// <summary>
            /// Matches the device class and subclass.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            DeviceClassAndSubclass = 2,
        }

        /// <summary>
        /// Creates a selector that matches <see cref="DeviceClassType.None"/> by device class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GestureDeviceSelector() : this(Interop.GestureDeviceSelector.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal GestureDeviceSelector(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn, false)
        {
        }

        /// <summary>
        /// Creates a selector that matches every device of the given class.
        /// </summary>
        /// <param name="deviceClass">The device class to match.</param>
        /// <returns>The selector.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GestureDeviceSelector ByDeviceClass(DeviceClassType deviceClass)
        {
            GestureDeviceSelector ret = new GestureDeviceSelector(Interop.GestureDeviceSelector.ByDeviceClass((int)deviceClass), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Creates a selector that matches every device of the given class and subclass.
        /// </summary>
        /// <param name="deviceClass">The device class to match.</param>
        /// <param name="deviceSubClass">The device subclass to match.</param>
        /// <returns>The selector.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GestureDeviceSelector ByDeviceClassAndSubclass(DeviceClassType deviceClass, DeviceSubClassType deviceSubClass)
        {
            GestureDeviceSelector ret = new GestureDeviceSelector(Interop.GestureDeviceSelector.ByDeviceClassAndSubclass((int)deviceClass, (int)deviceSubClass), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Creates a selector that matches one device by its exact name.
        /// </summary>
        /// <param name="deviceName">The device name as reported by the input system. Must not be null or empty.</param>
        /// <returns>The selector.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="deviceName"/> is null or empty.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GestureDeviceSelector ByDeviceName(string deviceName)
        {
            if (string.IsNullOrEmpty(deviceName))
            {
                throw new ArgumentException("Device name must not be null or empty.", nameof(deviceName));
            }

            GestureDeviceSelector ret = new GestureDeviceSelector(Interop.GestureDeviceSelector.ByDeviceName(deviceName), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets how this selector matches a device (read-only).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GestureDeviceSelector.MatchType Match
        {
            get
            {
                GestureDeviceSelector.MatchType ret = (GestureDeviceSelector.MatchType)Interop.GestureDeviceSelector.GetMatchType(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Gets the device class this selector matches (read-only).<br />
        /// <see cref="DeviceClassType.None"/> when <see cref="Match"/> is <see cref="MatchType.DeviceName"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DeviceClassType DeviceClass
        {
            get
            {
                DeviceClassType ret = (DeviceClassType)Interop.GestureDeviceSelector.GetDeviceClass(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Gets the device subclass this selector matches (read-only).<br />
        /// <see cref="DeviceSubClassType.None"/> unless <see cref="Match"/> is <see cref="MatchType.DeviceClassAndSubclass"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DeviceSubClassType DeviceSubClass
        {
            get
            {
                DeviceSubClassType ret = (DeviceSubClassType)Interop.GestureDeviceSelector.GetDeviceSubclass(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Gets the device name this selector matches (read-only).<br />
        /// Empty unless <see cref="Match"/> is <see cref="MatchType.DeviceName"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DeviceName
        {
            get
            {
                string ret = Interop.GestureDeviceSelector.GetDeviceName(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Determines whether the specified object is a selector with the same match type and keys.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>True if both selectors match the same devices. False when either selector has been disposed.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            GestureDeviceSelector other = obj as GestureDeviceSelector;
            if (other == null)
            {
                return false;
            }

            bool ret = Interop.GestureDeviceSelector.IsEqual(SwigCPtr, GestureDeviceSelector.getCPtr(other));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                // Only a disposed selector reaches here; Equals must not throw, so treat it as not equal.
                NDalicPINVOKE.SWIGPendingException.Retrieve();
                return false;
            }

            return ret;
        }

        /// <summary>
        /// Returns a hash code consistent with <see cref="Equals(object)"/>.
        /// </summary>
        /// <returns>The hash code.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return HashCode.Combine(Match, DeviceClass, DeviceSubClass, DeviceName);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(HandleRef swigCPtr)
        {
            Interop.GestureDeviceSelector.Delete(swigCPtr);
        }
    }
}

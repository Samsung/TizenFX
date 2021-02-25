/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// The key structure is used to store a key press.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Key : BaseHandle
    {
        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Key() : this(Interop.Key.New("", "", 0, 0, 0u, 0), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="keyName">The name of the key pressed or command from the IMF, if later, then the following parameters will be needed.</param>
        /// <param name="keyString">A string of input characters or key pressed.</param>
        /// <param name="keyCode">The unique key code for the key pressed.</param>
        /// <param name="keyModifier">The key modifier for special keys like Shift and Alt.</param>
        /// <param name="timeStamp">The time (in ms) that the key event occurred.</param>
        /// <param name="keyState">The state of the key event.</param>
        internal Key(string keyName, string keyString, int keyCode, int keyModifier, uint timeStamp, Key.StateType keyState) : this(Interop.Key.New(keyName, keyString, keyCode, keyModifier, timeStamp, (int)keyState), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Key(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Enumeration for specifying the state of the key event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum StateType
        {
            /// <summary>
            /// Key Down.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Down,
            /// <summary>
            /// Key Up.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Up,
            /// <summary>
            /// Key Last.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Last
        }

        /// <summary>
        /// Device name
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string DeviceName
        {
            get
            {
                string ret = Interop.NDalic.GetDeviceName(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Name given to the key pressed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string KeyPressedName
        {
            get
            {
                string ret = Interop.Key.KeyPressedNameGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
            set
            {
                Interop.Key.KeyPressedNameSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

        }

        /// <summary>
        /// Get the logical key string. (eg. shift + 1 == "exclamation")
        /// </summary>
        /// <returns>The logical key symbol</returns>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LogicalKey
        {
            get
            {
                string ret = Interop.Key.LogicalKeyGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Get the actual string returned that should be used for input editors.
        /// </summary>
        /// <returns>The key string</returns>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string KeyPressed
        {
            get
            {
                return keyPressed;
            }
        }

        /// <summary>
        /// Get the actual string returned that should be used for input editors.
        /// </summary>
        /// <returns>The key string</returns>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string KeyString
        {
            get
            {
                string ret = Interop.Key.KeyStringGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
            set
            {
                Interop.Key.KeyStringSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Keycode for the key pressed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int KeyCode
        {
            get
            {
                int ret = Interop.Key.KeyCodeGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
            set
            {
                Interop.Key.KeyCodeSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Special keys like Shift, Alt, and Ctrl which modify the next key pressed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int KeyModifier
        {
            get
            {
                int ret = Interop.Key.KeyModifierGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
            set
            {
                Interop.Key.KeyModifierSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// The time (in ms) that the key event occurred.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint Time
        {
            get
            {
                uint ret = Interop.Key.TimeGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
            set
            {
                Interop.Key.TimeSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// State of the key event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Key.StateType State
        {
            get
            {
                Key.StateType ret = (Key.StateType)Interop.Key.StateGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
            set
            {
                Interop.Key.StateSet(SwigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Get the device class the key event originated from.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public DeviceClassType DeviceClass
        {
            get
            {
                int ret = Interop.NDalic.GetDeviceClass(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return (DeviceClassType)ret;
            }
        }

        /// <summary>
        /// Get the device subclass the key event originated from.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public DeviceSubClassType DeviceSubClass
        {
            get
            {
                int ret = Interop.NDalic.GetDeviceSubClass(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return (DeviceSubClassType)ret;
            }
        }

        private string keyPressed
        {
            set
            {
                Interop.Key.KeyPressedSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.Key.KeyPressedGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Checks to see if the Shift key modifier has been supplied.
        /// </summary>
        /// <returns>True if Shift modifier.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsShiftModifier()
        {
            bool ret = Interop.Key.IsShiftModifier(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Checks to see if Ctrl (control) key modifier has been supplied.
        /// </summary>
        /// <returns>True if Ctrl modifier.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsCtrlModifier()
        {
            bool ret = Interop.Key.IsCtrlModifier(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Checks to see if Alt key modifier has been supplied.
        /// </summary>
        /// <returns>True if Alt modifier.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsAltModifier()
        {
            bool ret = Interop.Key.IsAltModifier(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Key obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal static Key GetKeyFromPtr(global::System.IntPtr cPtr)
        {
            Key ret = new Key(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Key.DeleteKey(swigCPtr);
        }
    }
}

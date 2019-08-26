/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{

    /// <summary>
    /// The key structure is used to store a key press.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Key : Disposable
    {
        /// <summary>
        /// swigCMemOwn
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected bool swigCMemOwn;

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Key() : this(Interop.Key.new_Key__SWIG_0(), true)
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
        internal Key(string keyName, string keyString, int keyCode, int keyModifier, uint timeStamp, Key.StateType keyState) : this(Interop.Key.new_Key__SWIG_1(keyName, keyString, keyCode, keyModifier, timeStamp, (int)keyState), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Key(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
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
                string ret = Interop.NDalic.GetDeviceName(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
                return keyPressedName;
            }
            set
            {
                keyPressedName = value;
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
                return logicalKey;
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
                return keyString;
            }
            set
            {
                keyString = value;
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
                return keyCode;
            }
            set
            {
                keyCode = value;
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
                return keyModifier;
            }
            set
            {
                keyModifier = value;
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
                return time;
            }
            set
            {
                time = value;
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
                return state;
            }
            set
            {
                state = value;
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
                int ret = Interop.NDalic.GetDeviceClass(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
                int ret = Interop.NDalic.GetDeviceSubClass(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return (DeviceSubClassType)ret;
            }
        }

        private string keyPressedName
        {
            set
            {
                Interop.Key.Key_keyPressedName_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.Key.Key_keyPressedName_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private string keyPressed
        {
            set
            {
                Interop.Key.Key_keyPressed_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.Key.Key_keyPressed_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private string keyString
        {
            set
            {
                Interop.Key.Key_keyString_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.Key.Key_keyString_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int keyCode
        {
            set
            {
                Interop.Key.Key_keyCode_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.Key.Key_keyCode_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int keyModifier
        {
            set
            {
                Interop.Key.Key_keyModifier_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.Key.Key_keyModifier_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private uint time
        {
            set
            {
                Interop.Key.Key_time_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.Key.Key_time_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Key.StateType state
        {
            set
            {
                Interop.Key.Key_state_set(swigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Key.StateType ret = (Key.StateType)Interop.Key.Key_state_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private string logicalKey
        {
            get
            {
                string ret = Interop.Key.Key_logicalKey_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return "";
            }
        }

        /// <summary>
        /// Checks to see if the Shift key modifier has been supplied.
        /// </summary>
        /// <returns>True if Shift modifier.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsShiftModifier()
        {
            bool ret = Interop.Key.Key_IsShiftModifier(swigCPtr);
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
            bool ret = Interop.Key.Key_IsCtrlModifier(swigCPtr);
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
            bool ret = Interop.Key.Key_IsAltModifier(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Key obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal static Key GetKeyFromPtr(global::System.IntPtr cPtr)
        {
            Key ret = new Key(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="type">The dispose type.</param>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.Key.delete_Key(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            base.Dispose(type);
        }
    }
}

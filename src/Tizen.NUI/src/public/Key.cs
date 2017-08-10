/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{

    /// <summary>
    /// The key structure is used to store a key press.
    /// </summary>
    public class Key : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal Key(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Key obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;

        ~Key()
        {
            if(!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        public void Dispose()
        {
            //Throw excpetion if Dispose() is called in separate thread.
            if (!Window.IsInstalled())
            {
                throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
            }

            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                System.GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_Key(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            disposed = true;
        }


        internal static Key GetKeyFromPtr(global::System.IntPtr cPtr)
        {
            Key ret = new Key(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public string DeviceName
        {
            get
            {
                string ret = NDalicPINVOKE.GetDeviceName(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Name given to the key pressed
        /// </summary>
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

        /* duplicated with KeyPressedName : removed
        public string KeyPressed
        {
            get
            {
                return keyPressed;
            }
        }
        */

        /// <summary>
        /// Keycode for the key pressed.
        /// </summary>
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
        /// Special keys like shift, alt and control which modify the next key pressed.
        /// </summary>
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

        public DeviceClassType DeviceClass
        {
            get
            {
                int ret = NDalicPINVOKE.GetDeviceClass(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return (DeviceClassType)ret;
            }
        }


        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Key() : this(NDalicPINVOKE.new_Key__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="keyName">The name of the key pressed or command from the IMF, if later then the some following parameters will be needed</param>
        /// <param name="keyString">A string of input characters or key pressed</param>
        /// <param name="keyCode">The unique key code for the key pressed</param>
        /// <param name="keyModifier">The key modifier for special keys like shift and alt</param>
        /// <param name="timeStamp">The time (in ms) that the key event occurred</param>
        /// <param name="keyState">The state of the key event</param>
        internal Key(string keyName, string keyString, int keyCode, int keyModifier, uint timeStamp, Key.StateType keyState) : this(NDalicPINVOKE.new_Key__SWIG_1(keyName, keyString, keyCode, keyModifier, timeStamp, (int)keyState), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Checks to see if Shift key modifier has been supplied.
        /// </summary>
        /// <returns>True if shift modifier</returns>
        public bool IsShiftModifier()
        {
            bool ret = NDalicPINVOKE.Key_IsShiftModifier(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Checks to see if Ctrl (control) key modifier has been supplied.
        /// </summary>
        /// <returns>True if ctrl modifier</returns>
        public bool IsCtrlModifier()
        {
            bool ret = NDalicPINVOKE.Key_IsCtrlModifier(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Checks to see if Alt key modifier has been supplied.
        /// </summary>
        /// <returns>True if alt modifier</returns>
        public bool IsAltModifier()
        {
            bool ret = NDalicPINVOKE.Key_IsAltModifier(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private string keyPressedName
        {
            set
            {
                NDalicPINVOKE.Key_keyPressedName_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = NDalicPINVOKE.Key_keyPressedName_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private string keyPressed
        {
            set
            {
                NDalicPINVOKE.Key_keyPressed_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = NDalicPINVOKE.Key_keyPressed_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int keyCode
        {
            set
            {
                NDalicPINVOKE.Key_keyCode_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = NDalicPINVOKE.Key_keyCode_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int keyModifier
        {
            set
            {
                NDalicPINVOKE.Key_keyModifier_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = NDalicPINVOKE.Key_keyModifier_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private uint time
        {
            set
            {
                NDalicPINVOKE.Key_time_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = NDalicPINVOKE.Key_time_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Key.StateType state
        {
            set
            {
                NDalicPINVOKE.Key_state_set(swigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Key.StateType ret = (Key.StateType)NDalicPINVOKE.Key_state_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Enumeration for specifying the state of the key event.
        /// </summary>
        public enum StateType
        {
            Down,
            Up,
            Last
        }

    }
}

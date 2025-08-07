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
    /// MouseInOut is used when the mouse enters or exits a window.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MouseInOut : Disposable
    {
        /// <summary>
        /// The default constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MouseInOut() : this(Interop.MouseInOut.NewMouseInOut((int)MouseInOut.StateType.None, 0, Vector2.getCPtr(Vector2.Zero), 0), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="state">The state of the event.</param>
        /// <param name="modifiers">Modifier keys pressed during the event (such as Shift, Alt, and Ctrl).</param>
        /// <param name="point">The coordinates of the cursor relative to the top-left of the screen.</param>
        /// <param name="timeStamp">The time the event is being started.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MouseInOut(MouseInOut.StateType state, uint modifiers, Vector2 point, uint timeStamp) : this(Interop.MouseInOut.NewMouseInOut((int)state, modifiers, Vector2.getCPtr(point), timeStamp), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal MouseInOut(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal MouseInOut(global::System.IntPtr cPtr, bool cMemoryOwn, bool disposableOnlyMainThread) : base(cPtr, cMemoryOwn, disposableOnlyMainThread)
        {
        }

        /// <summary>
        /// The state of the mouse event.
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
            /// Mouse entered
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            In,

            /// <summary>
            /// Mouse exited
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Out
        }

        /// <summary>
        /// The state of the mouse event.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MouseInOut.StateType State
        {
            get
            {
                return state;
            }
        }

        /// <summary>
        /// Modifier keys pressed during the event (such as Shift, Alt, and Ctrl).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Modifiers
        {
            get
            {
                return modifiers;
            }
        }

        /// <summary>
        /// The coordinates of the cursor relative to the top-left of the screen.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 Point
        {
            get
            {
                return point;
            }
        }

        /// <summary>
        /// The time the mouse evnet is being started
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint TimeStamp
        {
            get
            {
                return timeStamp;
            }
        }

        /// <summary>
        /// Get the device class the mouse event originated from.
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
        /// Get the device subclass the mouse event originated from.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DeviceSubClassType DeviceSubClass
        {
            get
            {
                return deviceSubClass;
            }
        }

        private MouseInOut.StateType state
        {
            get
            {
                MouseInOut.StateType ret = (MouseInOut.StateType)Interop.MouseInOut.TypeGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private uint modifiers
        {
            get
            {
                uint ret = Interop.MouseInOut.ModifiersGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 point
        {
            get
            {
                global::System.IntPtr cPtr = Interop.MouseInOut.PointGet(SwigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private uint timeStamp
        {
            get
            {
                uint ret = Interop.MouseInOut.TimeStampGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private DeviceClassType deviceClass
        {
            get
            {
                int ret = Interop.MouseInOut.DeviceClassGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return (DeviceClassType)ret;
            }
        }

        private DeviceSubClassType deviceSubClass
        {
            get
            {
                int ret = Interop.MouseInOut.DeviceSubClassGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return (DeviceSubClassType)ret;
            }
        }

        internal static MouseInOut GetMouseInOutFromPtr(global::System.IntPtr cPtr)
        {
            MouseInOut ret = new MouseInOut(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.MouseInOut.DeleteMouseInOut(swigCPtr);
        }
    }
}

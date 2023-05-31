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
    /// MousePointerGrab is used when the mouse enters or exits a window.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MousePointerGrab : Disposable
    {

        /// <summary>
        /// The default constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MousePointerGrab() : this(Interop.MousePointerGrab.NewMousePointerGrab((int)MousePointerGrab.StateType.None, 0, 0, Vector2.getCPtr(new Vector2(0, 0)), Vector2.getCPtr(new Vector2(0, 0)), Vector2.getCPtr(new Vector2(0, 0))), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="state">The state of the event.</param>
        /// <param name="modifiers">Modifier keys pressed during the event (such as Shift, Alt, and Ctrl).</param>
        /// <param name="timeStamp">The time the event is being started.</param>
        /// <param name="screenPosition">The coordinates of the cursor relative to the top-left of the screen.</param>
        /// <param name="diffPosition">The coordinates of the cursor relative to the top-left of the screen.</param>
        /// <param name="unaccelatedPosition">The coordinates of the cursor relative to the top-left of the screen.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MousePointerGrab(MousePointerGrab.StateType state, uint modifiers, uint timeStamp, Vector2 screenPosition, Vector2 diffPosition, Vector2 unaccelatedPosition) : this(Interop.MousePointerGrab.NewMousePointerGrab((int)state, modifiers, timeStamp, Vector2.getCPtr(screenPosition), Vector2.getCPtr(diffPosition), Vector2.getCPtr(unaccelatedPosition)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal MousePointerGrab(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
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
            Move,

            /// <summary>
            /// Mouse exited
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            RelativeMove
        }

        /// <summary>
        /// The state of the mouse event.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MousePointerGrab.StateType State
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
        public Vector2 ScreenPosition
        {
            get
            {
                return screenPosition;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 DiffPosition
        {
            get
            {
                return diffPosition;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 UnaccelatedPosition
        {
            get
            {
                return unaccelatedPosition;
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

        private MousePointerGrab.StateType state
        {
            get
            {
                MousePointerGrab.StateType ret = (MousePointerGrab.StateType)Interop.MousePointerGrab.TypeGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private uint modifiers
        {
            get
            {
                uint ret = Interop.MousePointerGrab.ModifiersGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 screenPosition
        {
            get
            {
                global::System.IntPtr cPtr = Interop.MousePointerGrab.ScreenPositionGet(SwigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 diffPosition
        {
            get
            {
                global::System.IntPtr cPtr = Interop.MousePointerGrab.DiffPositionGet(SwigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 unaccelatedPosition
        {
            get
            {
                global::System.IntPtr cPtr = Interop.MousePointerGrab.UnaccelatedPositionGet(SwigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private uint timeStamp
        {
            get
            {
                uint ret = Interop.MousePointerGrab.TimeStampGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private DeviceClassType deviceClass
        {
            get
            {
                int ret = Interop.MousePointerGrab.DeviceClassGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return (DeviceClassType)ret;
            }
        }

        private DeviceSubClassType deviceSubClass
        {
            get
            {
                int ret = Interop.MousePointerGrab.DeviceSubClassGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return (DeviceSubClassType)ret;
            }
        }

        internal static MousePointerGrab GetMousePointerGrabFromPtr(global::System.IntPtr cPtr)
        {
            MousePointerGrab ret = new MousePointerGrab(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.MousePointerGrab.DeleteMousePointerGrab(swigCPtr);
        }
    }
}

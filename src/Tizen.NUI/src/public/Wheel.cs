/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
    /// The wheel event structure is used to store a wheel rolling, it facilitates processing of the wheel rolling and passing to other libraries like Toolkit.<br />
    /// There is a key modifier which relates to keys like Alt, Shift, and Ctrl functions are supplied to check if they have been pressed when the wheel is being rolled.<br />
    /// We support a mouse device and there may be another custom device that support the wheel event. The device type is specified as \e type.<br />
    /// The mouse wheel event can be sent to the specific actor but the custom wheel event will be sent to the window.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Wheel : Disposable
    {

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Wheel() : this(Interop.Wheel.new_Wheel__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="type">The type of the wheel event.</param>
        /// <param name="direction">The direction of wheel rolling (0 = default vertical wheel, 1 = horizontal wheel).</param>
        /// <param name="modifiers">Modifier keys pressed during the event (such as Shift, Alt, and Ctrl).</param>
        /// <param name="point">The coordinates of the cursor relative to the top-left of the screen.</param>
        /// <param name="z">The offset of rolling (positive value means roll down or clockwise, and negative value means roll up or counter-clockwise).</param>
        /// <param name="timeStamp">The time the wheel is being rolled.</param>
        /// <since_tizen> 3 </since_tizen>
        public Wheel(Wheel.WheelType type, int direction, uint modifiers, Vector2 point, int z, uint timeStamp) : this(Interop.Wheel.new_Wheel__SWIG_1((int)type, direction, modifiers, Vector2.getCPtr(point), z, timeStamp), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Wheel(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The type of the wheel event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum WheelType
        {
            /// <summary>
            /// Mouse wheel event.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            MouseWheel,

            /// <summary>
            /// Custom wheel event.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            CustomWheel
        }

        /// <summary>
        /// The type of the wheel event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Wheel.WheelType Type
        {
            get
            {
                return type;
            }
        }

        /// <summary>
        /// The direction of wheel rolling (0 = default vertical wheel, 1 = horizontal wheel).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Direction
        {
            get
            {
                return direction;
            }
        }

        /// <summary>
        /// Modifier keys pressed during the event (such as Shift, Alt, and Ctrl).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
        public Vector2 Point
        {
            get
            {
                return point;
            }
        }

        /// <summary>
        /// The offset of rolling (positive value means roll down or clockwise, and negative value means roll up or counter-clockwise).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Z
        {
            get
            {
                return z;
            }
        }

        /// <summary>
        /// The time the wheel is being rolled.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint TimeStamp
        {
            get
            {
                return timeStamp;
            }
        }

        private Wheel.WheelType type
        {
            set
            {
                Interop.Wheel.Wheel_type_set(swigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Wheel.WheelType ret = (Wheel.WheelType)Interop.Wheel.Wheel_type_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int direction
        {
            set
            {
                Interop.Wheel.Wheel_direction_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.Wheel.Wheel_direction_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private uint modifiers
        {
            set
            {
                Interop.Wheel.Wheel_modifiers_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.Wheel.Wheel_modifiers_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 point
        {
            set
            {
                Interop.Wheel.Wheel_point_set(swigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.Wheel.Wheel_point_get(swigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int z
        {
            set
            {
                Interop.Wheel.Wheel_z_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.Wheel.Wheel_z_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private uint timeStamp
        {
            set
            {
                Interop.Wheel.Wheel_timeStamp_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.Wheel.Wheel_timeStamp_get(swigCPtr);
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
            bool ret = Interop.Wheel.Wheel_IsShiftModifier(swigCPtr);
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
            bool ret = Interop.Wheel.Wheel_IsCtrlModifier(swigCPtr);
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
            bool ret = Interop.Wheel.Wheel_IsAltModifier(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Wheel obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal static Wheel GetWheelFromPtr(global::System.IntPtr cPtr)
        {
            Wheel ret = new Wheel(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Wheel.delete_Wheel(swigCPtr);
        }
    }
}
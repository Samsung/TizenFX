/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
    /// Base structure for different gestures that an application can receive.<br />
    /// A Gesture is an event that is produced from a combination of several touch events
    /// in a particular order or within a certain time frame (for example, pinch).<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Gesture : BaseHandle
    {

        /// <summary>
        /// The Copy constructor.
        /// </summary>
        /// <param name="rhs">A reference to the copied handle</param>
        /// <since_tizen> 3 </since_tizen>
        public Gesture(Gesture rhs) : this(Interop.Gesture.NewGesture(Gesture.getCPtr(rhs)), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Gesture(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal Gesture(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister, cRegister)
        {
        }

        internal Gesture(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister, bool disposableOnlyMainThread) : base(cPtr, cMemoryOwn, cRegister, disposableOnlyMainThread)
        {
        }

        /// <summary>
        /// Enumeration for type of gesture.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum GestureType
        {
            /// <summary>
            /// When two touch points move away or towards each other.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Pinch = 1 << 0,
            /// <summary>
            /// When the user drags their finger(s) in a particular direction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Pan = 1 << 1,
            /// <summary>
            /// When the user taps the screen.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Tap = 1 << 2,
            /// <summary>
            ///  When the user continues to touch the same area on the screen for the device configured time.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            LongPress = 1 << 3
        }

        /// <summary>
        /// Enumeration for state of the gesture.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum StateType
        {
            /// <summary>
            /// There is no state associated with this gesture.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Clear,
            /// <summary>
            /// The touched points on the screen have moved enough to be considered a gesture.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Started,
            /// <summary>
            /// The gesture is continuing.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Continuing,
            /// <summary>
            /// The user has lifted a finger or touched an additional point on the screen.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Finished,
            /// <summary>
            /// The gesture has been cancelled.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Cancelled,
            /// <summary>
            ///  A gesture is possible.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Possible
        }

        /// <summary>
        /// This is the value of which source the gesture was started with. (ex : mouse)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum SourceType
        {
            /// <summary>
            /// invalid data.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Invalid,
            /// <summary>
            /// Mouse.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Mouse,
            /// <summary>
            /// Touch.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Touch,
        }

        /// <summary>
        /// This is the data of source type
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum SourceDataType
        {
            /// <summary>
            /// invalid data.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Invalid = -1,
            /// <summary>
            /// Primary(Left) mouse button.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            MousePrimary = 1,
            /// <summary>
            /// Secondary(Right) mouse button.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            MouseSecondary = 3,
            /// <summary>
            /// Tertiary(Third) mouse button.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            MouseTertiary = 2,
        }

        /// <summary>
        /// Gets the type of gesture.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Gesture.GestureType Type
        {
            get
            {
                return type;
            }
        }

        /// <summary>
        /// Gets the state of gesture.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Gesture.StateType State
        {
            get
            {
                return state;
            }
        }

        /// <summary>
        /// Get the time when the gesture took place.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint Time
        {
            get
            {
                return time;
            }
        }

        /// <summary>
        /// This is the property of which source type the gesture (read-only).
        /// If you started the gesture with the mouse, it will tell you what type of mouse it is.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Gesture.SourceType Source
        {
            get
            {
                return sourceType;
            }
        }

        /// <summary>
        /// This is a property of the source type data (read-only).
        /// If you started the gesture with the mouse, it will tell you which mouse button you started the gesture with.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Gesture.SourceDataType SourceData
        {
            get
            {
                return sourceDataType;
            }
        }

        private Gesture.GestureType type
        {
            get
            {
                Gesture.GestureType ret = (Gesture.GestureType)Interop.Gesture.TypeGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Gesture.StateType state
        {
            get
            {
                Gesture.StateType ret = (Gesture.StateType)Interop.Gesture.StateGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private uint time
        {
            get
            {
                uint ret = Interop.Gesture.TimeGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Gesture.SourceType sourceType
        {
            get
            {
                Gesture.SourceType ret = (Gesture.SourceType)Interop.Gesture.SourceTypeGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Gesture.SourceDataType sourceDataType
        {
            get
            {
                Gesture.SourceDataType ret = (Gesture.SourceDataType)Interop.Gesture.SourceDataGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static Gesture GetGestureFromPtr(global::System.IntPtr cPtr)
        {
            Gesture ret = new Gesture(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Gesture.DeleteGesture(swigCPtr);
        }
    }

}

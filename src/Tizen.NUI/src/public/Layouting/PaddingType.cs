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

namespace Tizen.NUI
{
    using System.ComponentModel;

    /// <summary>
    /// The gesture state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PaddingType : Disposable
    {

        /// <summary>
        /// Creates an uninitialized PaddingType.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PaddingType() : this(Interop.PaddingType.NewPaddingType(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// PaddingType Constructor.
        /// </summary>
        /// <param name="start">Start padding or X coordinate</param>
        /// <param name="end">End padding or Y coordinate</param>
        /// <param name="top">Top padding or Height</param>
        /// <param name="bottom">Bottom padding or Width</param>
        /// <since_tizen> 3 </since_tizen>
        public PaddingType(float start, float end, float top, float bottom) : this(Interop.PaddingType.NewPaddingType(start, end, top, bottom), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PaddingType(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The Start value.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public float Start
        {
            set
            {
                start = value;
            }
            get
            {
                return start;
            }
        }

        /// <summary>
        /// The End value.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public float End
        {
            set
            {
                end = value;
            }
            get
            {
                return end;
            }
        }

        /// <summary>
        /// The Top value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Top
        {
            set
            {
                top = value;
            }
            get
            {
                return top;
            }
        }

        /// <summary>
        /// The Bottom value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Bottom
        {
            set
            {
                bottom = value;
            }
            get
            {
                return bottom;
            }
        }

        private float left
        {
            set
            {
                Interop.PaddingType.LeftSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.PaddingType.LeftGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private float start
        {
            set
            {
                Interop.PaddingType.StartSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.PaddingType.StartGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private float right
        {
            set
            {
                Interop.PaddingType.RightSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.PaddingType.RightGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private float end
        {
            set
            {
                Interop.PaddingType.EndSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.PaddingType.EndGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private float top
        {
            set
            {
                Interop.PaddingType.TopSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.PaddingType.TopGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private float bottom
        {
            set
            {
                Interop.PaddingType.BottomSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.PaddingType.BottomGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>True if the values are identical</returns>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator ==(PaddingType a, PaddingType b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return (System.Math.Abs(a.Start - b.Start) < NDalic.GetRangedEpsilon(a.Start, b.Start)) &&
                   (System.Math.Abs(a.End - b.End) < NDalic.GetRangedEpsilon(a.End, b.End)) &&
                   (System.Math.Abs(a.Bottom - b.Bottom) < NDalic.GetRangedEpsilon(a.Bottom, b.Bottom)) &&
                   (System.Math.Abs(a.Top - b.Top) < NDalic.GetRangedEpsilon(a.Top, b.Top));
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>True if the values are not identical</returns>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator !=(PaddingType a, PaddingType b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="o">The object should be compared.</param>
        /// <returns>True if equal.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override bool Equals(object o)
        {
            if (o == null)
            {
                return false;
            }
            if (!(o is PaddingType))
            {
                return false;
            }
            PaddingType p = (PaddingType)o;

            // Return true if the fields match:
            return (System.Math.Abs(Start - p.Start) < NDalic.GetRangedEpsilon(Start, p.Start)) &&
                   (System.Math.Abs(End - p.End) < NDalic.GetRangedEpsilon(End, p.End)) &&
                   (System.Math.Abs(Bottom - p.Bottom) < NDalic.GetRangedEpsilon(Bottom, p.Bottom)) &&
                   (System.Math.Abs(Top - p.Top) < NDalic.GetRangedEpsilon(Top, p.Top));
        }

        /// <summary>
        /// Gets the hash code of this baseHandle.
        /// </summary>
        /// <returns>The Hash Code.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Assignment from individual values.
        /// </summary>
        /// <param name="newStart">Start padding or X coordinate</param>
        /// <param name="newEnd">End padding or Y coordinate</param>
        /// <param name="newTop">Top padding or Height</param>
        /// <param name="newBottom">Bottom padding or Width</param>
        /// <since_tizen> 3 </since_tizen>
        public void Set(float newStart, float newEnd, float newTop, float newBottom)
        {
            Interop.PaddingType.Set(SwigCPtr, newStart, newEnd, newTop, newBottom);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PaddingType obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PaddingType.DeletePaddingType(swigCPtr);
        }
    }
}

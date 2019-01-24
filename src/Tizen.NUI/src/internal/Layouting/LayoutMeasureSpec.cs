/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
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
    /// [Draft] A MeasureSpec is used during the Measure pass by a LayoutGroup to inform it's children how to be measured.
    /// For instance, it may measure a child with an exact width and an unspecified height in order to determine height for width.
    /// </summary>
    internal class LayoutMeasureSpec : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal LayoutMeasureSpec(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LayoutMeasureSpec obj)
        {
            return (obj.Equals(null)) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        ~LayoutMeasureSpec()
        {
            Dispose();
        }

        public virtual void Dispose()
        {
            lock (this)
            {
                if (swigCPtr.Handle != global::System.IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        LayoutPINVOKE.delete_MeasureSpec(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
            }
        }

        public LayoutMeasureSpec(LayoutLength measureSpec, LayoutMeasureSpec.ModeType mode) : this(LayoutPINVOKE.new_MeasureSpec__SWIG_0(LayoutLength.getCPtr(measureSpec), (int)mode), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public LayoutMeasureSpec(int measureSpec) : this(LayoutPINVOKE.new_MeasureSpec__SWIG_1(measureSpec), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static bool operator ==(LayoutMeasureSpec r1, LayoutMeasureSpec r2)
        {
            return r1.EqualTo(r2);
        }

        public static bool operator !=(LayoutMeasureSpec r1, LayoutMeasureSpec r2)
        {
            return !r1.EqualTo(r2);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            LayoutMeasureSpec layoutMeasureSpec = obj as LayoutMeasureSpec;
            bool equal = false;
            if (Size == layoutMeasureSpec?.Size && Mode == layoutMeasureSpec?.Mode)
            {
                equal = true;
            }
            return equal;
        }

        /// <summary>
        /// Gets the the hash code of this LayoutMeasureSpec.
        /// </summary>
        /// <returns>The Hash Code.</returns>
        /// <since_tizen> 5 </since_tizen>
        public override int GetHashCode()
        {
            return swigCPtr.GetHashCode();
        }

        private bool EqualTo(LayoutMeasureSpec value)
        {
            bool ret = LayoutPINVOKE.MeasureSpec_EqualTo(swigCPtr, LayoutMeasureSpec.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool NotEqualTo(LayoutMeasureSpec value)
        {
            bool ret = LayoutPINVOKE.MeasureSpec_NotEqualTo(swigCPtr, LayoutMeasureSpec.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutMeasureSpec.ModeType GetMode()
        {
            LayoutMeasureSpec.ModeType ret = (LayoutMeasureSpec.ModeType)LayoutPINVOKE.MeasureSpec_GetMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private int GetSize()
        {
            int ret = LayoutPINVOKE.MeasureSpec_GetSize(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// [Draft] Adjust the measure size by the given delta. Used only for EXACT and AT_MOST modes.
        /// if the adjusted size is negative, it is zeroed.
        /// </summary>
        /// <param name="measureSpec">the measure spec to adjust</param>
        /// <param name="delta">A positive or negative value to adjust the measure spec by.</param>
        /// <returns>A new measure spec with the adjusted values.</returns>
        public static LayoutMeasureSpec Adjust(LayoutMeasureSpec measureSpec, int delta)
        {
            LayoutMeasureSpec ret = new LayoutMeasureSpec(LayoutPINVOKE.MeasureSpec_Adjust(LayoutMeasureSpec.getCPtr(measureSpec), delta), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public int Size
        {
            set
            {
                LayoutPINVOKE.MeasureSpec_mSize_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = LayoutPINVOKE.MeasureSpec_mSize_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public LayoutMeasureSpec.ModeType Mode
        {
            set
            {
                LayoutPINVOKE.MeasureSpec_mMode_set(swigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                LayoutMeasureSpec.ModeType ret = (LayoutMeasureSpec.ModeType)LayoutPINVOKE.MeasureSpec_mMode_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public enum ModeType
        {
            /// <summary>
            /// This is used by a parent to determine the desired dimension of a child layout.
            /// </summary>
            Unspecified,
            /// <summary>
            /// This is used by a parent to impose an exact size on the child.
            /// The child must use this size, and guarantee that all of its descendants will fit within this size.
            /// </summary>
            Exactly,
            /// <summary>
            /// This is used by the parent to impose a maximum size on the child.
            /// The child must guarantee that it and all of it's descendants will fit within this size.
            /// </summary>
            AtMost
        }
    }
}

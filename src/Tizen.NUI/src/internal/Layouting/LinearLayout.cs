/* Copyright (c) 2018 Samsung Electronics Co., Ltd.
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
    /// [Draft] This class implements a linear box layout, automatically handling right to left or left to right direction change.
    /// </summary>
    internal class LinearLayout : LayoutGroupWrapper
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal LinearLayout(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.LinearLayout.LinearLayout_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LinearLayout obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
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
                    Interop.LinearLayout.delete_LinearLayout(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            base.Dispose(type);
        }

        internal static new class ChildProperty
        {
            internal static readonly int WEIGHT = Interop.LinearLayout.LinearLayout_ChildProperty_WEIGHT_get();
        }
        public LinearLayout() : this(Interop.LinearLayout.LinearLayout_New(), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public static LinearLayout DownCast(BaseHandle handle)
        {
            LinearLayout ret = new LinearLayout(Interop.LinearLayout.LinearLayout_DownCast(BaseHandle.getCPtr(handle)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LinearLayout(LinearLayout other) : this(Interop.LinearLayout.new_LinearLayout__SWIG_1(LinearLayout.getCPtr(other)), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal LinearLayout Assign(LinearLayout other)
        {
            LinearLayout ret = new LinearLayout(Interop.LinearLayout.LinearLayout_Assign(swigCPtr, LinearLayout.getCPtr(other)), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetCellPadding(LayoutSize size)
        {
            Interop.LinearLayout.LinearLayout_SetCellPadding(swigCPtr, LayoutSize.getCPtr(size));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal LayoutSize GetCellPadding()
        {
            LayoutSize ret = new LayoutSize(Interop.LinearLayout.LinearLayout_GetCellPadding(swigCPtr), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }


        internal void SetOrientation(LinearLayout.Orientation orientation)
        {
            Interop.LinearLayout.LinearLayout_SetOrientation(swigCPtr, (int)orientation);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal LinearLayout.Orientation GetOrientation()
        {
            LinearLayout.Orientation ret = (LinearLayout.Orientation)Interop.LinearLayout.LinearLayout_GetOrientation(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetAlignment(LinearLayout.Alignment alignment)
        {
            Interop.LinearLayout.LinearLayout_SetAlignment(swigCPtr, (uint)alignment);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal LinearLayout.Alignment GetAlignment()
        {
            LinearLayout.Alignment ret = (LinearLayout.Alignment)Interop.LinearLayout.LinearLayout_GetAlignment(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal enum PropertyRange
        {
            CHILD_PROPERTY_START_INDEX = PropertyRanges.CHILD_PROPERTY_REGISTRATION_START_INDEX,
            CHILD_PROPERTY_END_INDEX = PropertyRanges.CHILD_PROPERTY_REGISTRATION_START_INDEX + 1000
        }

        /// <summary>
        /// [Draft] Get/Set the orientation in the layout
        /// </summary>
        public LinearLayout.Orientation LinearOrientation
        {
            get
            {
                return GetOrientation();
            }
            set
            {
                SetOrientation(value);
            }
        }

        /// <summary>
        /// [Draft] Get/Set the padding between cells in the layout
        /// </summary>
        public LayoutSize CellPadding
        {
            get
            {
                return GetCellPadding();
            }
            set
            {
                SetCellPadding(value);
            }
        }

        /// <summary>
        /// [Draft] Get/Set the alignment in the layout
        /// </summary>
        public LinearLayout.Alignment LinearAlignment
        {
            get
            {
                return GetAlignment();
            }
            set
            {
                SetAlignment(value);
            }
        }

        /// <summary>
        /// [Draft] Enumeration for the direction in which the content is laid out
        /// </summary>
        public enum Orientation
        {
            /// <summary>
            /// Horizontal (row)
            /// </summary>
            Horizontal,
            /// <summary>
            /// Vertical (column)
            /// </summary>
            Vertical
        }

        /// <summary>
        /// [Draft] Enumeration for the alignment of the linear layout items
        /// </summary>
        public enum Alignment
        {
            /// <summary>
            /// At the left/right edge of the container (maps to LTR/RTL direction for horizontal orientation)
            /// </summary>
            Begin              = 0x1,
            /// <summary>
            /// At the right/left edge of the container (maps to LTR/RTL direction for horizontal orientation)
            /// </summary>
            End                = 0x2,
            /// <summary>
            /// At the horizontal center of the container
            /// </summary>
            CenterHorizontal   = 0x4,
            /// <summary>
            /// At the top edge of the container
            /// </summary>
            Top                = 0x8,
            /// <summary>
            /// At the bottom edge of the container
            /// </summary>
            Bottom             = 0x10,
            /// <summary>
            /// At the vertical center of the container
            /// </summary>
            CenterVertical     = 0x20
        }

    }

}

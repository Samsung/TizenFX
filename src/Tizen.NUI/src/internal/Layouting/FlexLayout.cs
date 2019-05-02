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
    /// [Draft] This class implements a flex layout.
    /// The flex layout implementation is based on open source Facebook Yoga layout engine.
    /// For more information about the flex layout API and how to use it please refer to https://yogalayout.com/docs/
    /// We implement the subset of the API in the class below.
    /// </summary>
    internal class FlexLayout : LayoutGroupWrapper
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal FlexLayout(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.FlexLayout.FlexLayout_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FlexLayout obj)
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
                    Interop.FlexLayout.delete_FlexLayout(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            base.Dispose(type);
        }

        /// <summary>
        /// [Draft] Creates a FlexLayout object.
        /// </summary>
        public FlexLayout() : this(Interop.FlexLayout.FlexLayout_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static FlexLayout DownCast(BaseHandle handle)
        {
            FlexLayout ret = new FlexLayout(Interop.FlexLayout.FlexLayout_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal FlexLayout(FlexLayout other) : this(Interop.FlexLayout.new_FlexLayout__SWIG_1(FlexLayout.getCPtr(other)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FlexLayout Assign(FlexLayout other)
        {
            FlexLayout ret = new FlexLayout(Interop.FlexLayout.FlexLayout_Assign(swigCPtr, FlexLayout.getCPtr(other)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFlexDirection(FlexLayout.FlexDirection flexDirection)
        {
            Interop.FlexLayout.FlexLayout_SetFlexDirection(swigCPtr, (int)flexDirection);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FlexLayout.FlexDirection GetFlexDirection()
        {
            FlexLayout.FlexDirection ret = (FlexLayout.FlexDirection)Interop.FlexLayout.FlexLayout_GetFlexDirection(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFlexJustification(FlexLayout.FlexJustification flexJustification)
        {
            Interop.FlexLayout.FlexLayout_SetFlexJustification(swigCPtr, (int)flexJustification);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FlexLayout.FlexJustification GetFlexJustification()
        {
            FlexLayout.FlexJustification ret = (FlexLayout.FlexJustification)Interop.FlexLayout.FlexLayout_GetFlexJustification(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFlexWrap(FlexLayout.FlexWrapType flexWrap)
        {
            Interop.FlexLayout.FlexLayout_SetFlexWrap(swigCPtr, (int)flexWrap);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FlexLayout.FlexWrapType GetFlexWrap()
        {
            FlexLayout.FlexWrapType ret = (FlexLayout.FlexWrapType)Interop.FlexLayout.FlexLayout_GetFlexWrap(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFlexAlignment(FlexLayout.AlignmentType flexAlignment)
        {
            Interop.FlexLayout.FlexLayout_SetFlexAlignment(swigCPtr, (int)flexAlignment);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FlexLayout.AlignmentType GetFlexAlignment()
        {
            FlexLayout.AlignmentType ret = (FlexLayout.AlignmentType)Interop.FlexLayout.FlexLayout_GetFlexAlignment(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFlexItemsAlignment(FlexLayout.AlignmentType flexAlignment)
        {
            Interop.FlexLayout.FlexLayout_SetFlexItemsAlignment(swigCPtr, (int)flexAlignment);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FlexLayout.AlignmentType GetFlexItemsAlignment()
        {
            FlexLayout.AlignmentType ret = (FlexLayout.AlignmentType)Interop.FlexLayout.FlexLayout_GetFlexItemsAlignment(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal enum PropertyRange
        {
            CHILD_PROPERTY_START_INDEX = PropertyRanges.CHILD_PROPERTY_REGISTRATION_START_INDEX,
            CHILD_PROPERTY_END_INDEX = PropertyRanges.CHILD_PROPERTY_REGISTRATION_START_INDEX + 1000
        }

        internal new class ChildProperty
        {
            internal static readonly int FLEX = Interop.FlexLayout.FlexLayout_ChildProperty_FLEX_get();
            internal static readonly int ALIGN_SELF = Interop.FlexLayout.FlexLayout_ChildProperty_ALIGN_SELF_get();
        }

        /// <summary>
        /// [Draft] Get/Set the flex direction in the layout.
        /// The direction of the main-axis which determines the direction that flex items are laid out.
        /// </summary>
        public FlexDirection Direction
        {
            get
            {
                return GetFlexDirection();
            }
            set
            {
                SetFlexDirection(value);
            }
        }

        /// <summary>
        /// [Draft] Get/Set the justification in the layout.
        /// </summary>
        public FlexJustification Justification
        {
            get
            {
                return GetFlexJustification();
            }
            set
            {
                SetFlexJustification(value);
            }
        }

        /// <summary>
        /// [Draft] Get/Set the wrap in the layout.
        /// </summary>
        public FlexWrapType WrapType
        {
            get
            {
                return GetFlexWrap();
            }
            set
            {
                SetFlexWrap(value);
            }
        }

        /// <summary>
        /// [Draft] Get/Set the alignment of the layout content.
        /// </summary>
        public AlignmentType Alignment
        {
            get
            {
                return GetFlexAlignment();
            }
            set
            {
                SetFlexAlignment(value);
            }
        }

        /// <summary>
        /// [Draft] Get/Set the alignment of the layout items.
        /// </summary>
        public AlignmentType ItemsAlignment
        {
            get
            {
                return GetFlexItemsAlignment();
            }
            set
            {
                SetFlexItemsAlignment(value);
            }
        }

        /// <summary>
        /// [Draft] Enumeration for the direction of the main axis in the flex container.
        /// This determines the direction that flex items are laid out in the flex container.
        /// </summary>
        public enum FlexDirection
        {
            /// <summary>
            /// The flexible items are displayed vertically as a column
            /// </summary>
            Column,
            /// <summary>
            /// The flexible items are displayed vertically as a column, but in reverse order
            /// </summary>
            ColumnReverse,
            /// <summary>
            /// The flexible items are displayed horizontally as a row
            /// </summary>
            Row,
            /// <summary>
            /// The flexible items are displayed horizontally as a row, but in reverse order
            /// </summary>
            RowReverse
        }

        /// <summary>
        /// [Draft] Enumeration for the alignment of the flex items when the items do not use all available space on the main-axis.
        /// </summary>
        public enum FlexJustification
        {
            /// <summary>
            /// Items are positioned at the beginning of the container
            /// </summary>
            FlexStart,
            /// <summary>
            /// Items are positioned at the center of the container
            /// </summary>
            Center,
            /// <summary>
            /// Items are positioned at the end of the container
            /// </summary>
            FlexEnd,
            /// <summary>
            /// Items are positioned with equal space between the lines
            /// </summary>
            SpaceBetween,
            /// <summary>
            /// Items are positioned with equal space before, between, and after the lines
            /// </summary>
            SpaceAround
        }

        /// <summary>
        /// [Draft] Enumeration for the wrap type of the flex container when there is no enough room for all the items on one flex line.
        /// </summary>
        public enum FlexWrapType
        {
            /// <summary>
            /// Flex items laid out in single line (shrunk to fit the flex container along the main axis)
            /// </summary>
            NoWrap,
            /// <summary>
            /// Flex items laid out in multiple lines if needed
            /// </summary>
            Wrap
        }

        /// <summary>
        /// [Draft] Enumeration for the alignment of the flex items or lines when the items or lines do not use all the available space on the cross-axis.
        /// </summary>
        public enum AlignmentType
        {
            /// <summary>
            /// Inherits the same alignment from the parent (only valid for "alignSelf" property)
            /// </summary>
            Auto,
            /// <summary>
            /// At the beginning of the container
            /// </summary>
            FlexStart,
            /// <summary>
            /// At the center of the container
            /// </summary>
            Center,
            /// <summary>
            /// At the end of the container
            /// </summary>
            FlexEnd,
            /// <summary>
            /// Stretch to fit the container
            /// </summary>
            Stretch
        }
    }
}

/* Copyright (c) 2019 Samsung Electronics Co., Ltd.
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

using System;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] This class implements a flex layout.
    /// The flex layout implementation is based on open source Facebook Yoga layout engine.
    /// For more information about the flex layout API and how to use it please refer to https://yogalayout.com/docs/
    /// We implement the subset of the API in the class below.
    /// </summary>
    internal class FlexLayout : LayoutGroup,  global::System.IDisposable
    {
        float Flex{ get; set;}
        int AlignSelf{get; set;}

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private bool swigCMemOwn;
        private bool disposed;
        private bool isDisposeQueued = false;

        private IntPtr _rootFlex;  // Pointer to the unmanged flex layout class.

        public struct MeasuredSize
        {
          public MeasuredSize(float x, float y)
          {
            width = x;
            height = y;
          }
          float width;
          float height;
        };

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal delegate MeasuredSize ChildMeasureCallback( global::System.IntPtr child, float width, int measureModeWidth, float height, int measureModeHeight );

        event ChildMeasureCallback measureChildDelegate; // Stores a delegate to the child measure callback. Used for all children of this FlexLayout.

        internal FlexLayout(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            _rootFlex = Interop.FlexLayout.FlexLayout_New();
            measureChildDelegate = new ChildMeasureCallback(measureChild);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FlexLayout obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        public void Dispose()
        {
            // Throw exception if Dispose() is called in separate thread.
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

            if (type == DisposeTypes.Explicit)
            {
                // Called by User
                // Release your own managed resources here.
                // You should release all of your own disposable objects here.

            }

            // Release your own unmanaged resources here.
            // You should not access any managed member here except static instance.
            // because the execution order of Finalizes is non-deterministic.
            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.FlexLayout.delete_FlexLayout(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            disposed = true;
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
            RequestLayout();
        }

        internal FlexLayout.FlexDirection GetFlexDirection()
        {
            FlexLayout.FlexDirection ret = (FlexLayout.FlexDirection)Interop.FlexLayout.FlexLayout_GetFlexDirection(swigCPtr);
            return ret;

        }

        internal void SetFlexJustification(FlexLayout.FlexJustification flexJustification)
        {
            Interop.FlexLayout.FlexLayout_SetFlexJustification(swigCPtr, (int)flexJustification);
            RequestLayout();
        }

        internal FlexLayout.FlexJustification GetFlexJustification()
        {
            FlexLayout.FlexJustification ret = (FlexLayout.FlexJustification)Interop.FlexLayout.FlexLayout_GetFlexJustification(swigCPtr);
            return ret;
        }

        internal void SetFlexWrap(FlexLayout.FlexWrapType flexWrap)
        {
            Interop.FlexLayout.FlexLayout_SetFlexWrap(swigCPtr, (int)flexWrap);
            RequestLayout();
        }

        internal FlexLayout.FlexWrapType GetFlexWrap()
        {
            FlexLayout.FlexWrapType ret = (FlexLayout.FlexWrapType)Interop.FlexLayout.FlexLayout_GetFlexWrap(swigCPtr);
            return ret;
        }

        internal void SetFlexAlignment(FlexLayout.AlignmentType flexAlignment)
        {
            Interop.FlexLayout.FlexLayout_SetFlexAlignment(swigCPtr, (int)flexAlignment);
            RequestLayout();
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
            RequestLayout();
        }

        internal FlexLayout.AlignmentType GetFlexItemsAlignment()
        {
            FlexLayout.AlignmentType ret = (FlexLayout.AlignmentType)Interop.FlexLayout.FlexLayout_GetFlexItemsAlignment(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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
            /// Inherits the same alignment from the parent
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

        private MeasuredSize measureChild(global::System.IntPtr child, float width, int measureModeWidth, float height, int measureModeHeight)
        {
            View view = Registry.GetManagedBaseHandleFromNativePtr(child) as View;
            Size2D viewSize = new Size2D(8,8);
            if(view)
            {
              viewSize = view.NaturalSize2D;
            }
            return new MeasuredSize(viewSize.Width,viewSize.Height);
        }

        void InsertChild( LayoutItem child )
        {
            // Store created node for child
            Interop.FlexLayout.FlexLayout_AddChild(swigCPtr, View.getCPtr(child.Owner), measureChildDelegate, _children.Count-1);
        }

        protected override void OnChildAdd(LayoutItem child)
        {
            InsertChild(child);
        }

        protected override void OnChildRemove(LayoutItem child)
        {
            // When child View is removed from it's parent View (that is a Layout) then remove it from the layout too.
            // FlexLayout refers to the child as a View not LayoutItem.
            Interop.FlexLayout.FlexLayout_RemoveChild(swigCPtr, child);
        }

        protected override void OnMeasure( MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec )
        {
            bool isLayoutRtl = Owner.LayoutDirection == ViewLayoutDirectionType.RTL;
            Extents padding = Owner.Padding;
            Extents margin = Owner.Margin;

            Interop.FlexLayout.FlexLayout_SetMargin(swigCPtr, Extents.getCPtr(margin));
            Interop.FlexLayout.FlexLayout_SetPadding(swigCPtr, Extents.getCPtr(padding));

            float width = 0.0f;
            float height = 0.0f;

            if( widthMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly ||  widthMeasureSpec.Mode == MeasureSpecification.ModeType.AtMost )
            {
                width = widthMeasureSpec.Size.AsDecimal();
            }

            if ( heightMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly || heightMeasureSpec.Mode == MeasureSpecification.ModeType.AtMost )
            {
                height = heightMeasureSpec.Size.AsDecimal();
            }

            Interop.FlexLayout.FlexLayout_CalculateLayout( swigCPtr, width, height, isLayoutRtl );

            SetMeasuredDimensions( GetDefaultSize( new LayoutLength( (float)Interop.FlexLayout.FlexLayout_GetWidth(swigCPtr) ), widthMeasureSpec ),
                                   GetDefaultSize( new LayoutLength( (float)Interop.FlexLayout.FlexLayout_GetHeight(swigCPtr) ), heightMeasureSpec ) );
        }

        protected override void OnLayout( bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom )
        {

            bool isLayoutRtl = Owner.LayoutDirection == ViewLayoutDirectionType.RTL;
            LayoutLength width = right - left;
            LayoutLength height = bottom - top;

            // Call to FlexLayout implementation to calculate layout values for later retrieval.
            Interop.FlexLayout.FlexLayout_CalculateLayout( swigCPtr, width.AsDecimal(), height.AsDecimal(), isLayoutRtl );

            int count = _children.Count;
            for( int childIndex = 0; childIndex < count; childIndex++)
            {
                LayoutItem childLayout = _children[childIndex];
                if( childLayout != null )
                {
                    // Get the frame for the child, start, top, end, bottom.
                    Vector4 frame = new Vector4(Interop.FlexLayout.FlexLayout_GetNodeFrame(swigCPtr, childIndex ), true);
                    childLayout.Layout( new LayoutLength(frame.X), new LayoutLength(frame.Y), new LayoutLength(frame.Z), new LayoutLength(frame.W) );
                }
            }
        }

    } // FLexlayout
} // namesspace Tizen.NUI
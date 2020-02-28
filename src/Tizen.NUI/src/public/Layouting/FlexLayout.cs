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
using System.Diagnostics;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] This class implements a flex layout.
    /// The flex layout implementation is based on open source Facebook Yoga layout engine.
    /// For more information about the flex layout API and how to use it please refer to https://yogalayout.com/docs/
    /// We implement the subset of the API in the class below.
    /// </summary>
    public class FlexLayout : LayoutGroup,  global::System.IDisposable
    {
        private static bool LayoutDebugFlex = false; // Debug flag
        float Flex{ get; set;}
        int AlignSelf{get; set;}

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private bool swigCMemOwn;
        private bool disposed;
        private bool isDisposeQueued = false;

        private MeasureSpecification parentMeasureSpecificationWidth;
        private MeasureSpecification parentMeasureSpecificationHeight;

        private IntPtr _rootFlex;  // Pointer to the unmanged flex layout class.

        internal const float FlexUndefined = 10E20F; // Auto setting which is equivalent to WrapContent.

        internal struct MeasuredSize
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

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
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

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
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

        private MeasuredSize measureChild(global::System.IntPtr childPtr, float width, int measureModeWidth, float height, int measureModeHeight)
        {
            // We need to measure child layout
            View child = Registry.GetManagedBaseHandleFromNativePtr(childPtr) as View;

            LayoutItem childLayout = child.Layout;

            MeasureSpecification childWidthMeasureSpec = GetChildMeasureSpecification(
                                    new MeasureSpecification(
                                        new LayoutLength(parentMeasureSpecificationWidth.Size - (Padding.Start + Padding.End + child.Margin.Start + child.Margin.End)),
                                        parentMeasureSpecificationWidth.Mode),
                                    new LayoutLength(child.Padding.Start + child.Padding.End),
                                    new LayoutLength(child.WidthSpecification));

            MeasureSpecification childHeightMeasureSpec = GetChildMeasureSpecification(
                                    new MeasureSpecification(
                                        new LayoutLength(parentMeasureSpecificationHeight.Size - (Padding.Top + Padding.Bottom + child.Margin.Top + child.Margin.Bottom)),
                                        parentMeasureSpecificationHeight.Mode),
                                    new LayoutLength(Padding.Top + Padding.Bottom),
                                    new LayoutLength(child.HeightSpecification));

            childLayout.Measure( childWidthMeasureSpec, childHeightMeasureSpec);

            return new MeasuredSize(childLayout.MeasuredWidth.Size.AsRoundedValue(),childLayout.MeasuredHeight.Size.AsRoundedValue());
        }

        void InsertChild( LayoutItem child )
        {
            // Store created node for child
            Interop.FlexLayout.FlexLayout_AddChildWithMargin(swigCPtr, View.getCPtr(child.Owner), Extents.getCPtr(child.Owner.Margin), measureChildDelegate, LayoutChildren.Count-1);
        }

        /// <summary>
        /// Callback when child is added to container.<br />
        /// Derived classes can use this to set their own child properties on the child layout's owner.<br />
        /// </summary>
        /// <param name="child">The Layout child.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnChildAdd(LayoutItem child)
        {
            InsertChild(child);
        }

        /// <summary>
        /// Callback when child is removed from container.<br />
        /// </summary>
        /// <param name="child">The Layout child.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnChildRemove(LayoutItem child)
        {
            // When child View is removed from it's parent View (that is a Layout) then remove it from the layout too.
            // FlexLayout refers to the child as a View not LayoutItem.
            Interop.FlexLayout.FlexLayout_RemoveChild(swigCPtr, child);
        }

        /// <summary>
        /// Measure the layout and its content to determine the measured width and the measured height.<br />
        /// </summary>
        /// <param name="widthMeasureSpec">horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">vertical space requirements as imposed by the parent.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnMeasure( MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec )
        {
            bool isLayoutRtl = Owner.LayoutDirection == ViewLayoutDirectionType.RTL;
            Extents padding = Owner.Padding;
            Extents margin = Owner.Margin;

            Interop.FlexLayout.FlexLayout_SetMargin(swigCPtr, Extents.getCPtr(margin));
            Interop.FlexLayout.FlexLayout_SetPadding(swigCPtr, Extents.getCPtr(padding));

            float width = FlexUndefined; // Behaves as WrapContent (Flex Auto)
            float height = FlexUndefined; // Behaves as WrapContent (Flex Auto)

            if( widthMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly ||  widthMeasureSpec.Mode == MeasureSpecification.ModeType.AtMost )
            {
                width = widthMeasureSpec.Size.AsDecimal();
            }

            if ( heightMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly || heightMeasureSpec.Mode == MeasureSpecification.ModeType.AtMost )
            {
                height = heightMeasureSpec.Size.AsDecimal();
            }

            // Save measureSpec to measure children.
            // In other Layout, we can pass it as parameter to measuring child but in FlexLayout we can't
            // because measurChild function is called by native callback.
            parentMeasureSpecificationWidth = widthMeasureSpec;
            parentMeasureSpecificationHeight = heightMeasureSpec;

            Interop.FlexLayout.FlexLayout_CalculateLayout( swigCPtr, width, height, isLayoutRtl );

            LayoutLength flexLayoutWidth =  new LayoutLength( Interop.FlexLayout.FlexLayout_GetWidth(swigCPtr) );
            LayoutLength flexLayoutHeight = new LayoutLength( Interop.FlexLayout.FlexLayout_GetHeight(swigCPtr) );

            Debug.WriteLineIf( LayoutDebugFlex, "FlexLayout OnMeasure width:" + flexLayoutWidth.AsRoundedValue()
                                                + " height:" + flexLayoutHeight.AsRoundedValue() );

            SetMeasuredDimensions( GetDefaultSize(flexLayoutWidth, widthMeasureSpec ),
                                   GetDefaultSize(flexLayoutHeight, heightMeasureSpec ) );
        }

        /// <summary>
        /// Assign a size and position to each of its children.<br />
        /// </summary>
        /// <param name="changed">This is a new size or position for this layout.</param>
        /// <param name="left">Left position, relative to parent.</param>
        /// <param name="top"> Top position, relative to parent.</param>
        /// <param name="right">Right position, relative to parent.</param>
        /// <param name="bottom">Bottom position, relative to parent.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnLayout( bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom )
        {

            bool isLayoutRtl = Owner.LayoutDirection == ViewLayoutDirectionType.RTL;
            LayoutLength width = right - left;
            LayoutLength height = bottom - top;

            // Call to FlexLayout implementation to calculate layout values for later retrieval.
            Interop.FlexLayout.FlexLayout_CalculateLayout( swigCPtr, width.AsDecimal(), height.AsDecimal(), isLayoutRtl );

            int count = LayoutChildren.Count;
            for( int childIndex = 0; childIndex < count; childIndex++)
            {
                LayoutItem childLayout = LayoutChildren[childIndex];
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
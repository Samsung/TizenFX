/* Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// This class implements a flex layout.
    /// The flex layout implementation is based on open source Facebook Yoga layout engine.
    /// For more information about the flex layout API and how to use it please refer to https://yogalayout.com/docs/
    /// We implement the subset of the API in the class below.
    /// </summary>
    public class FlexLayout : LayoutGroup
    {
        /// <summary>
        /// FlexItemProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty FlexItemProperty = BindableProperty.CreateAttached("FlexItem", typeof(HandleRef), typeof(FlexLayout), default(HandleRef));

        /// <summary>
        /// FlexAlignmentSelfProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexAlignmentSelfProperty = BindableProperty.CreateAttached("FlexAlignmentSelf", typeof(AlignmentType), typeof(FlexLayout), AlignmentType.Auto, validateValue: ValidateEnum((int)AlignmentType.Auto, (int)AlignmentType.Stretch), propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// FlexPositionTypeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexPositionTypeProperty = BindableProperty.CreateAttached("FlexPositionType", typeof(PositionType), typeof(FlexLayout), PositionType.Relative, validateValue: ValidateEnum((int)PositionType.Relative, (int)PositionType.Absolute),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            if (bindable is View view)
            {
                view.ExcludeLayouting = (PositionType)newValue == PositionType.Absolute;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            if (view.ExcludeLayouting)
                return PositionType.Absolute;

            return PositionType.Relative;
        });


        /// <summary>
        /// AspectRatioProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexAspectRatioProperty = BindableProperty.CreateAttached("FlexAspectRatio", typeof(float), typeof(FlexLayout), FlexUndefined, validateValue: (bindable, value) => (float)value > 0, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// FlexBasisProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexBasisProperty = BindableProperty.CreateAttached("FlexBasis", typeof(float), typeof(FlexLayout), FlexUndefined, validateValue: (bindable, value) => (float)value >= 0, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// FlexShrinkProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexShrinkProperty = BindableProperty.CreateAttached("FlexShrink", typeof(float), typeof(FlexLayout), 1.0f, validateValue: (bindable, value) => (float)value >= 0, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// FlexGrowProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexGrowProperty = BindableProperty.CreateAttached("FlexGrow", typeof(float), typeof(FlexLayout), FlexUndefined, validateValue: (bindable, value) => (float)value >= 0, propertyChanged: OnChildPropertyChanged);

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private bool swigCMemOwn;
        private bool disposed;
        private bool isDisposeQueued = false;

        private MeasureSpecification parentMeasureSpecificationWidth;
        private MeasureSpecification parentMeasureSpecificationHeight;

        private IntPtr _rootFlex;  // Pointer to the unmanaged flex layout class.

        internal const float FlexUndefined = 10E20F; // Auto setting which is equivalent to WrapContent.

        internal struct MeasuredSize
        {
            public MeasuredSize(float x, float y)
            {
                width = x;
                height = y;
            }
            public float width;
            public float height;
        };

        /// <summary>
        /// Gets the alignment self of the child view.
        /// </summary>
        /// <seealso cref="SetFlexAlignmentSelf(View, AlignmentType)"/>
        /// <param name="view">The child view.</param>
        /// <returns> The value of alignment self.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static AlignmentType GetFlexAlignmentSelf(View view) => GetAttachedValue<AlignmentType>(view, FlexAlignmentSelfProperty);

        /// <summary>
        /// Gets the position type of the child view.
        /// </summary>
        /// <seealso cref="SetFlexPositionType(View, PositionType)"/>
        /// <param name="view">The child view.</param>
        /// <returns> The value of position type</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static PositionType GetFlexPositionType(View view) => GetAttachedValue<PositionType>(view, FlexPositionTypeProperty);

        /// <summary>
        /// Gets the aspect ratio of the child view.
        /// </summary>
        /// <seealso cref="SetFlexAspectRatio(View, float)"/>
        /// <param name="view">The child view.</param>
        /// <returns> The value of aspect ratio</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static float GetFlexAspectRatio(View view) => GetAttachedValue<float>(view, FlexAspectRatioProperty);

        /// <summary>
        /// Gets the basis of the child view.
        /// </summary>
        /// <seealso cref="SetFlexBasis(View, float)"/>
        /// <param name="view">The child view.</param>
        /// <returns> The value of basis</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static float GetFlexBasis(View view) => GetAttachedValue<float>(view, FlexBasisProperty);

        /// <summary>
        /// Gets the shrink of the child view.
        /// </summary>
        /// <seealso cref="SetFlexShrink(View, float)"/>
        /// <param name="view">The child view.</param>
        /// <returns> The value of shrink</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static float GetFlexShrink(View view) => GetAttachedValue<float>(view, FlexShrinkProperty);

        /// <summary>
        /// Gets the grow of the child view.
        /// </summary>
        /// <seealso cref="SetFlexGrow(View, float)"/>
        /// <param name="view">The child view.</param>
        /// <returns> The value of grow</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static float GetFlexGrow(View view) => GetAttachedValue<float>(view, FlexGrowProperty);

        /// <summary>
        /// Sets the alignment self of the child view.<br/>
        /// Alignment self has the same options and effect as <see cref="ItemsAlignment"/> but instead of affecting the children within a container,
        /// you can apply this property to a single child to change its alignment within its parent.<br/>
        /// Alignment self overrides any option set by the parent with <see cref="ItemsAlignment"/>.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The value of alignment self.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="value"/> should be <see cref="AlignmentType"/>.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static void SetFlexAlignmentSelf(View view, AlignmentType value) => SetAttachedValue(view, FlexAlignmentSelfProperty, value);

        /// <summary>
        /// Sets the position type of the child view.<br/>
        /// The position type of an element defines how it is positioned within its parent.
        /// By default a child is positioned relatively. This means a child is positioned according to the normal flow of the layout,
        /// and then offset relative to that position based on the values of <see cref="View.Margin"/>.<br/>
        /// When positioned absolutely an element doesn't take part in the normal layout flow.
        /// It is instead laid out independent of its siblings. The position is determined based on the <see cref="View.Margin"/>.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The value of position type.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="value"/> should be <see cref="PositionType"/>.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static void SetFlexPositionType(View view, PositionType value) => SetAttachedValue(view, FlexPositionTypeProperty, value);

        /// <summary>
        /// Sets the aspect ratio of the child view.
        /// Aspect ratio Defines as the ratio between the width and the height of a node
        /// e.g. if a node has an aspect ratio of 2 then its width is twice the size of its height.<br/>
        /// Aspect ratio accepts any floating point value > 0. this has higher priority than flex grow.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The value of aspect ratio</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="value"/> cannot be less than or equal to 0.0f.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static void SetFlexAspectRatio(View view, float value) => SetAttachedValue(view, FlexAspectRatioProperty, value);

        /// <summary>
        /// Sets the flex basis of the child view.
        /// Flex basis is an axis-independent way of providing the default size of an item along the main axis.<br/>
        /// Setting the flex basis of a child is similar to setting the width of that child if its parent is a container with <see cref="FlexDirection.Row"/>
        /// or setting the height of a child if its parent is a container with <see cref="FlexDirection.Column"/>.<br/>
        /// The flex basis of an item is the default size of that item, the size of the item before any flex grow and flex shrink calculations are performed.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The value of basis</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="value"/> cannot be less than 0.0f.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static void SetFlexBasis(View view, float value) => SetAttachedValue(view, FlexBasisProperty, value);

        /// <summary>
        /// Sets the flex shrink of the child view.
        /// Flex shrink describes how to shrink children along the main axis in the case that the total size of the children overflow the size of the container on the main axis.<br/>
        /// Flex shrink is very similar to flex grow and can be thought of in the same way if any overflowing size is considered to be negative remaining space.
        /// These two properties also work well together by allowing children to grow and shrink as needed.<br/>
        /// Flex shrink accepts any floating point value >= 0, with 1 being the default value. A container will shrink its children weighted by the child's flex shrink value.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The value of shrink</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="value"/> cannot be less than 0.0f.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static void SetFlexShrink(View view, float value) => SetAttachedValue(view, FlexShrinkProperty, value);

        /// <summary>
        /// Sets the grow of the child view.
        /// Flex grow describes how any space within a container should be distributed among its children along the main axis.
        /// After laying out its children, a container will distribute any remaining space according to the flex grow values specified by its children.<br/>
        /// Flex grow accepts any floating point value >= 0, with 0 being the default value.<br/>
        /// A container will distribute any remaining space among its children weighted by the child's flex grow value.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The value of flex</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="value"/> cannot be less than 0.0f.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static void SetFlexGrow(View view, float value) => SetAttachedValue(view, FlexGrowProperty, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ChildMeasureCallback(global::System.IntPtr child, float width, int measureModeWidth, float height, int measureModeHeight, out MeasuredSize measureSize);

        event ChildMeasureCallback measureChildDelegate; // Stores a delegate to the child measure callback. Used for all children of this FlexLayout.

        internal FlexLayout(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            _rootFlex = Interop.FlexLayout.New();
            measureChildDelegate = new ChildMeasureCallback(measureChild);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FlexLayout obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Hidden API (Inhouse API).
        /// Destructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ~FlexLayout() => Dispose(false);

        /// <inheritdoc/>
        /// <since_tizen> 6 </since_tizen>
        public new void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Hidden API (Inhouse API).
        /// Dispose. 
        /// </summary>
        /// <remarks>
        /// Following the guide of https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose.
        /// This will replace "protected virtual void Dispose(DisposeTypes type)" which is exactly same in functionality.
        /// </remarks>
        /// <param name="disposing">true in order to free managed objects</param>
        // Protected implementation of Dispose pattern.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
                // Explicit call. user calls Dispose()

                //Throw exception if Dispose() is called in separate thread.
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
                }
            }
            else
            {
                // Implicit call. user doesn't call Dispose(), so this object is added into DisposeQueue to be disposed automatically.
                if (!isDisposeQueued)
                {
                    isDisposeQueued = true;
                    DisposeQueue.Instance.Add(this);
                }
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.
            base.Dispose(disposing);
        }

        /// <inheritdoc/>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void Dispose(DisposeTypes type)
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
                    ReleaseSwigCPtr(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            disposed = true;
        }

        /// <summary>
        /// Hidden API (Inhouse API).
        /// Release swigCPtr.
        /// </summary>
        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.FlexLayout.DeleteFlexLayout(swigCPtr);
        }

        /// <summary>
        /// Creates a FlexLayout object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public FlexLayout() : this(Interop.FlexLayout.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static FlexLayout DownCast(BaseHandle handle)
        {
            FlexLayout ret = new FlexLayout(Interop.FlexLayout.DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal FlexLayout(FlexLayout other) : this(Interop.FlexLayout.NewFlexLayout(FlexLayout.getCPtr(other)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FlexLayout.AlignmentType GetFlexAlignment()
        {
            FlexLayout.AlignmentType ret = (FlexLayout.AlignmentType)Interop.FlexLayout.GetFlexAlignment(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal FlexLayout.AlignmentType GetFlexItemsAlignment()
        {
            FlexLayout.AlignmentType ret = (FlexLayout.AlignmentType)Interop.FlexLayout.GetFlexItemsAlignment(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets/Sets the flex direction in the layout.
        /// The direction of the main-axis which determines the direction that flex items are laid out.
        /// </summary>
        /// <exception cref="InvalidEnumArgumentException">Thrown when using invalid arguments that are enumerators.</exception>
        /// <since_tizen> 6 </since_tizen>
        public FlexDirection Direction
        {
            get => (FlexDirection)Interop.FlexLayout.GetFlexDirection(swigCPtr);
            set
            {
                if (value < FlexDirection.Column || value > FlexDirection.RowReverse)
                    throw new InvalidEnumArgumentException(nameof(Direction));

                Interop.FlexLayout.SetFlexDirection(swigCPtr, (int)value);
                RequestLayout();
            }
        }

        /// <summary>
        /// Gets/Sets the justification in the layout.
        /// Justify content describes how to align children within the main axis of their container.<br/>
        /// For example, you can use this property to center a child horizontally within a container with <see cref="Direction"/> set to <see cref="FlexDirection.Row"/>
        /// or vertically within a container with <see cref="Direction"/> set to <see cref="FlexDirection.Column"/>.
        /// </summary>
        /// <exception cref="InvalidEnumArgumentException">Thrown when using invalid arguments that are enumerators.</exception>
        /// <since_tizen> 6 </since_tizen>
        public FlexJustification Justification
        {
            get => (FlexJustification)Interop.FlexLayout.GetFlexJustification(swigCPtr);
            set
            {
                if (value < FlexJustification.FlexStart || value > FlexJustification.SpaceAround)
                    throw new InvalidEnumArgumentException(nameof(Justification));

                Interop.FlexLayout.SetFlexJustification(swigCPtr, (int)value);
                RequestLayout();
            }
        }

        /// <summary>
        /// Gets/Sets the wrap in the layout.
        /// The flex wrap property is set on containers and controls what happens when children overflow the size of the container along the main axis.<br/>
        /// By default children are forced into a single line (which can shrink elements).<br/>
        /// If wrapping is allowed items are wrapped into multiple lines along the main axis if needed. wrap reverse behaves the same, but the order of the lines is reversed.<br/>
        /// When wrapping lines <see cref="Alignment"/> can be used to specify how the lines are placed in the container.
        /// </summary>
        /// <exception cref="InvalidEnumArgumentException">Thrown when using invalid arguments that are enumerators.</exception>
        /// <since_tizen> 6 </since_tizen>
        public FlexWrapType WrapType
        {
            get => (FlexWrapType)Interop.FlexLayout.GetFlexWrap(swigCPtr);
            set
            {
                if (value != FlexWrapType.NoWrap && value != FlexWrapType.Wrap)
                    throw new InvalidEnumArgumentException(nameof(WrapType));

                Interop.FlexLayout.SetFlexWrap(swigCPtr, (int)value);
                RequestLayout();

            }
        }

        /// <summary>
        /// Gets/Sets the alignment of the layout content.
        /// Alignment defines the distribution of lines along the cross-axis.<br/>
        /// This only has effect when items are wrapped to multiple lines using flex wrap.
        /// </summary>
        /// <exception cref="InvalidEnumArgumentException">Thrown when using invalid arguments that are enumerators.</exception>
        /// <since_tizen> 6 </since_tizen>
        public AlignmentType Alignment
        {
            get => GetFlexAlignment();
            set
            {
                if (value < AlignmentType.Auto || value > AlignmentType.Stretch)
                    throw new InvalidEnumArgumentException(nameof(Alignment));

                Interop.FlexLayout.SetFlexAlignment(swigCPtr, (int)value);
                RequestLayout();
            }
        }

        /// <summary>
        /// Gets/Sets the alignment of the layout items.
        /// Items alignment describes how to align children along the cross axis of their container.<br/>
        /// Align items is very similar to <see cref="Justification"/> but instead of applying to the main axis, align items applies to the cross axis.
        /// </summary>
        /// <exception cref="InvalidEnumArgumentException">Thrown when using invalid arguments that are enumerators.</exception>
        /// <since_tizen> 6 </since_tizen>
        public AlignmentType ItemsAlignment
        {
            get => GetFlexItemsAlignment();
            set
            {
                if (value < AlignmentType.Auto || value > AlignmentType.Stretch)
                    throw new InvalidEnumArgumentException(nameof(ItemsAlignment));

                Interop.FlexLayout.SetFlexItemsAlignment(swigCPtr, (int)value);
                RequestLayout();
            }
        }

        /// <summary>
        /// Enumeration for the direction of the main axis in the flex container.
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
        /// Enumeration for the alignment of the flex items when the items do not use all available space on the main-axis.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public enum FlexJustification
        {
            /// <summary>
            /// Items are positioned at the beginning of the container.
            /// </summary>
            FlexStart,
            /// <summary>
            /// Items are positioned at the center of the container.
            /// </summary>
            Center,
            /// <summary>
            /// Items are positioned at the end of the container.
            /// </summary>
            FlexEnd,
            /// <summary>
            /// Items are positioned with equal space between the lines.
            /// </summary>
            SpaceBetween,
            /// <summary>
            /// Items are positioned with equal space before, between, and after the lines.<br/>
            /// Compared to <see cref="FlexJustification.SpaceBetween"/> using <see cref="FlexJustification.SpaceAround"/>
            /// will result in space being distributed to the beginning of the first child and end of the last child.
            /// </summary>
            SpaceAround
        }

        /// <summary>
        /// Enumeration for the wrap type of the flex container when there is no enough room for all the items on one flex line.
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
        /// Enumeration for the alignment of the flex items or lines when the items or lines do not use all the available space on the cross-axis.
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

        /// <summary>
        /// Enumeration for the position type of the flex item how it is positioned within its parent.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public enum PositionType
        {
            /// <summary>
            /// Flex items laid out relatively.
            /// </summary>
            Relative,
            /// <summary>
            /// Flex items laid out absolutely.
            /// </summary>
            Absolute
        }

        private void measureChild(global::System.IntPtr childPtr, float width, int measureModeWidth, float height, int measureModeHeight, out MeasuredSize measureSize)
        {
            // We need to measure child layout
            View child = Registry.GetManagedBaseHandleFromNativePtr(childPtr) as View;
            // independent child will be measured in LayoutGroup.OnMeasureIndependentChildren().
            if ((child == null) || (child?.ExcludeLayouting ?? true))
            {
                measureSize.width = 0;
                measureSize.height = 0;
                return;
            }

            LayoutItem childLayout = child.Layout;
            Extents margin = child.Margin;

            MeasureSpecification childWidthMeasureSpec = GetChildMeasureSpecification(
                                    new MeasureSpecification(
                                        new LayoutLength(parentMeasureSpecificationWidth.Size - (margin.Start + margin.End)),
                                        parentMeasureSpecificationWidth.Mode),
                                    new LayoutLength(Padding.Start + Padding.End),
                                    new LayoutLength(child.WidthSpecification));

            MeasureSpecification childHeightMeasureSpec = GetChildMeasureSpecification(
                                    new MeasureSpecification(
                                        new LayoutLength(parentMeasureSpecificationHeight.Size - (margin.Top + margin.Bottom)),
                                        parentMeasureSpecificationHeight.Mode),
                                    new LayoutLength(Padding.Top + Padding.Bottom),
                                    new LayoutLength(child.HeightSpecification));

            childLayout.Measure(childWidthMeasureSpec, childHeightMeasureSpec);

            measureSize.width = childLayout.MeasuredWidth.Size.AsRoundedValue();
            measureSize.height = childLayout.MeasuredHeight.Size.AsRoundedValue();
        }

        void InsertChild(LayoutItem child)
        {
            // Store created node for child
            IntPtr childPtr = Interop.FlexLayout.AddChildWithMargin(swigCPtr, View.getCPtr(child.Owner), Extents.getCPtr(child.Owner.Margin), measureChildDelegate, LayoutChildren.Count - 1);
            HandleRef childHandleRef = new HandleRef(child.Owner, childPtr);
            SetAttachedValue(child.Owner, FlexItemProperty, childHandleRef);
        }

        /// <summary>
        /// Callback when child is added to container.<br />
        /// Derived classes can use this to set their own child properties on the child layout's owner.<br />
        /// </summary>
        /// <param name="child">The Layout child.</param>
        /// <exception cref="ArgumentNullException"> Thrown when child is null. </exception>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnChildAdd(LayoutItem child)
        {
            if (null == child)
            {
                throw new ArgumentNullException(nameof(child));
            }
            InsertChild(child);
        }

        /// <summary>
        /// Callback when child is removed from container.<br />
        /// </summary>
        /// <param name="child">The Layout child.</param>
        /// <exception cref="ArgumentNullException"> Thrown when child is null. </exception>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnChildRemove(LayoutItem child)
        {
            if (null == child)
            {
                throw new ArgumentNullException(nameof(child));
            }
            // When child View is removed from it's parent View (that is a Layout) then remove it from the layout too.
            // FlexLayout refers to the child as a View not LayoutItem.
            Interop.FlexLayout.RemoveChild(swigCPtr, child.Owner.SwigCPtr);
        }

        /// <summary>
        /// Measure the layout and its content to determine the measured width and the measured height.<br />
        /// </summary>
        /// <param name="widthMeasureSpec">horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">vertical space requirements as imposed by the parent.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            bool isLayoutRtl = Owner.LayoutDirection == ViewLayoutDirectionType.RTL;
            Extents padding = Owner.Padding;

            Interop.FlexLayout.SetPadding(swigCPtr, Extents.getCPtr(padding));

            float width = FlexUndefined; // Behaves as WrapContent (Flex Auto)
            float height = FlexUndefined; // Behaves as WrapContent (Flex Auto)

            if (widthMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly || widthMeasureSpec.Mode == MeasureSpecification.ModeType.AtMost)
            {
                width = widthMeasureSpec.Size.AsDecimal();
            }

            if (heightMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly || heightMeasureSpec.Mode == MeasureSpecification.ModeType.AtMost)
            {
                height = heightMeasureSpec.Size.AsDecimal();
            }

            // Save measureSpec to measure children.
            // In other Layout, we can pass it as parameter to measuring child but in FlexLayout we can't
            // because measurChild function is called by native callback.
            parentMeasureSpecificationWidth = widthMeasureSpec;
            parentMeasureSpecificationHeight = heightMeasureSpec;

            Extents zeroMargin = new Extents();

            // Assign child properties
            for (int i = 0; i < LayoutChildren.Count; i++)
            {
                LayoutItem layoutItem = LayoutChildren[i];
                View Child = layoutItem?.Owner;
                HandleRef childHandleRef = (HandleRef)Child.GetValue(FlexItemProperty);
                if (childHandleRef.Handle == IntPtr.Zero || Child == null)
                    continue;

                AlignmentType flexAlignemnt = GetFlexAlignmentSelf(Child);
                PositionType positionType = GetFlexPositionType(Child);
                float flexAspectRatio = GetFlexAspectRatio(Child);
                float flexBasis = GetFlexBasis(Child);
                float flexShrink = GetFlexShrink(Child);
                float flexGrow = GetFlexGrow(Child);
                Extents childMargin = Child.ExcludeLayouting ? zeroMargin : layoutItem.Margin;

                Interop.FlexLayout.SetMargin(childHandleRef, Extents.getCPtr(childMargin));
                Interop.FlexLayout.SetFlexAlignmentSelf(childHandleRef, (int)flexAlignemnt);
                Interop.FlexLayout.SetFlexPositionType(childHandleRef, (int)positionType);
                Interop.FlexLayout.SetFlexAspectRatio(childHandleRef, flexAspectRatio);
                Interop.FlexLayout.SetFlexBasis(childHandleRef, flexBasis);
                Interop.FlexLayout.SetFlexShrink(childHandleRef, flexShrink);
                Interop.FlexLayout.SetFlexGrow(childHandleRef, flexGrow);
            }

            Interop.FlexLayout.CalculateLayout(swigCPtr, width, height, isLayoutRtl);
            zeroMargin.Dispose();

            LayoutLength flexLayoutWidth = new LayoutLength(Interop.FlexLayout.GetWidth(swigCPtr));
            LayoutLength flexLayoutHeight = new LayoutLength(Interop.FlexLayout.GetHeight(swigCPtr));

            NUILog.Debug("FlexLayout OnMeasure width:" + flexLayoutWidth.AsRoundedValue() + " height:" + flexLayoutHeight.AsRoundedValue());

            SetMeasuredDimensions(GetDefaultSize(flexLayoutWidth, widthMeasureSpec),
                                   GetDefaultSize(flexLayoutHeight, heightMeasureSpec));
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
        protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {

            bool isLayoutRtl = Owner.LayoutDirection == ViewLayoutDirectionType.RTL;
            LayoutLength width = right - left;
            LayoutLength height = bottom - top;

            // Call to FlexLayout implementation to calculate layout values for later retrieval.
            Interop.FlexLayout.CalculateLayout(swigCPtr, width.AsDecimal(), height.AsDecimal(), isLayoutRtl);

            for (int childIndex = 0; childIndex < LayoutChildren.Count; childIndex++)
            {
                LayoutItem childLayout = LayoutChildren[childIndex];
                if (!childLayout?.Owner?.ExcludeLayouting ?? false)
                {
                    // Get the frame for the child, start, top, end, bottom.
                    Vector4 frame = new Vector4(Interop.FlexLayout.GetNodeFrame(swigCPtr, childIndex), true);
                    childLayout.Layout(new LayoutLength(frame.X), new LayoutLength(frame.Y), new LayoutLength(frame.Z), new LayoutLength(frame.W));
                    frame.Dispose();
                }
            }
        }
    } // FLexlayout
} // namesspace Tizen.NUI

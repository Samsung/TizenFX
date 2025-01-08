/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// FlexContainer implements a subset of the flexbox spec (defined by W3C):https://www.w3.org/TR/css3-flexbox/<br />
    /// It aims at providing a more efficient way to layout, align, and distribute space among items in the container, even when their size is unknown or dynamic.<br />
    /// FlexContainer has the ability to alter the width and the height of its children (i.e., flex items) to fill the available space in the best possible way on different screen sizes.<br />
    /// FlexContainer can expand items to fill available free space, or shrink them to prevent overflow.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
    public class FlexContainer : View
    {
        /// <summary> Property of ContentDirection </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty ContentDirectionProperty = null;
        internal static void SetInternalContentDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var flexContainer = (FlexContainer)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)flexContainer.SwigCPtr, FlexContainer.Property.ContentDirection, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }
        internal static object GetInternalContentDirectionProperty(BindableObject bindable)
        {
            var flexContainer = (FlexContainer)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)flexContainer.SwigCPtr, FlexContainer.Property.ContentDirection).Get(out temp);
            return (ContentDirectionType)temp;
        }

        /// <summary> Property of FlexDirection </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty FlexDirectionProperty = null;
        internal static void SetInternalFlexDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var flexContainer = (FlexContainer)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)flexContainer.SwigCPtr, FlexContainer.Property.FlexDirection, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }
        internal static object GetInternalFlexDirectionProperty(BindableObject bindable)
        {
            var flexContainer = (FlexContainer)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)flexContainer.SwigCPtr, FlexContainer.Property.FlexDirection).Get(out temp);
            return (FlexDirectionType)temp;
        }

        /// <summary> Property of FlexWrap </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty FlexWrapProperty = null;
        internal static void SetInternalFlexWrapProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var flexContainer = (FlexContainer)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)flexContainer.SwigCPtr, FlexContainer.Property.FlexWrap, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }
        internal static object GetInternalFlexWrapProperty(BindableObject bindable)
        {
            var flexContainer = (FlexContainer)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)flexContainer.SwigCPtr, FlexContainer.Property.FlexWrap).Get(out temp);
            return (WrapType)temp;
        }

        /// <summary> Property of JustifyContent </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty JustifyContentProperty = null;
        internal static void SetInternalJustifyContentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var flexContainer = (FlexContainer)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)flexContainer.SwigCPtr, FlexContainer.Property.JustifyContent, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }
        internal static object GetInternalJustifyContentProperty(BindableObject bindable)
        {
            var flexContainer = (FlexContainer)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)flexContainer.SwigCPtr, FlexContainer.Property.JustifyContent).Get(out temp);
            return (Justification)temp;
        }

        /// <summary> Property of AlignItems </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty AlignItemsProperty = null;
        internal static void SetInternalAlignItemsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var flexContainer = (FlexContainer)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)flexContainer.SwigCPtr, FlexContainer.Property.AlignItems, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }
        internal static object GetInternalAlignItemsProperty(BindableObject bindable)
        {
            var flexContainer = (FlexContainer)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)flexContainer.SwigCPtr, FlexContainer.Property.AlignItems).Get(out temp);
            return (Alignment)temp;
        }

        /// <summary> Property of AlignContent </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty AlignContentProperty = null;
        internal static void SetInternalAlignContentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var flexContainer = (FlexContainer)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)flexContainer.SwigCPtr, FlexContainer.Property.AlignContent, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }
        internal static object GetInternalAlignContentProperty(BindableObject bindable)
        {
            var flexContainer = (FlexContainer)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)flexContainer.SwigCPtr, FlexContainer.Property.AlignContent).Get(out temp);
            return (Alignment)temp;
        }

        static FlexContainer()
        {
            if (NUIApplication.IsUsingXaml)
            {
                ContentDirectionProperty = BindableProperty.Create(nameof(ContentDirection), typeof(ContentDirectionType), typeof(FlexContainer), ContentDirectionType.Inherit,
                    propertyChanged: SetInternalContentDirectionProperty, defaultValueCreator: GetInternalContentDirectionProperty);

                FlexDirectionProperty = BindableProperty.Create(nameof(FlexDirection), typeof(FlexDirectionType), typeof(FlexContainer), FlexDirectionType.Column,
                    propertyChanged: SetInternalFlexDirectionProperty, defaultValueCreator: GetInternalFlexDirectionProperty);

                FlexWrapProperty = BindableProperty.Create(nameof(FlexWrap), typeof(WrapType), typeof(FlexContainer), WrapType.NoWrap,
                    propertyChanged: SetInternalFlexWrapProperty, defaultValueCreator: GetInternalFlexWrapProperty);

                JustifyContentProperty = BindableProperty.Create(nameof(JustifyContent), typeof(Justification), typeof(FlexContainer), Justification.JustifyFlexStart,
                    propertyChanged: SetInternalJustifyContentProperty, defaultValueCreator: GetInternalJustifyContentProperty);

                AlignItemsProperty = BindableProperty.Create(nameof(AlignItems), typeof(Alignment), typeof(FlexContainer), Alignment.AlignAuto,
                    propertyChanged: SetInternalAlignItemsProperty, defaultValueCreator: GetInternalAlignItemsProperty);

                AlignContentProperty = BindableProperty.Create(nameof(AlignContent), typeof(Alignment), typeof(FlexContainer), Alignment.AlignAuto,
                    propertyChanged: SetInternalAlignContentProperty, defaultValueCreator: GetInternalAlignContentProperty);
            }
        }


        /// <summary>
        /// Creates a FlexContainer handle.
        /// Calling member functions with an uninitialized handle is not allowed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
        public FlexContainer() : this(Interop.FlexContainer.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FlexContainer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Enumeration for the direction of the main axis in the flex container. This determines
        /// the direction that flex items are laid out in the flex container.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
        public enum FlexDirectionType
        {
            /// <summary>
            /// The flexible items are displayed vertically as a column.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            Column,
            /// <summary>
            /// The flexible items are displayed vertically as a column, but in reverse order.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            ColumnReverse,
            /// <summary>
            /// The flexible items are displayed horizontally as a row.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            Row,
            /// <summary>
            /// The flexible items are displayed horizontally as a row.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            RowReverse
        }

        /// <summary>
        /// Enumeration for the primary direction in which content is ordered in the flex container
        /// and on which sides the ?�start??and ?�end??are.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
        public enum ContentDirectionType
        {
            /// <summary>
            /// Inherits the same direction from the parent.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            Inherit,
            /// <summary>
            /// From left to right.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            LTR,
            /// <summary>
            /// From right to left.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            RTL
        }

        /// <summary>
        /// Enumeration for the alignment of the flex items when the items do not use all available
        /// space on the main axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
        public enum Justification
        {
            /// <summary>
            /// Items are positioned at the beginning of the container.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            JustifyFlexStart,
            /// <summary>
            /// Items are positioned at the center of the container.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            JustifyCenter,
            /// <summary>
            /// Items are positioned at the end of the container.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            JustifyFlexEnd,
            /// <summary>
            /// Items are positioned with equal space between the lines.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            JustifySpaceBetween,
            /// <summary>
            /// Items are positioned with equal space before, between, and after the lines.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            JustifySpaceAround
        }

        /// <summary>
        /// Enumeration for the alignment of the flex items or lines when the items or lines do not
        /// use all the available space on the cross axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
        public enum Alignment
        {
            /// <summary>
            /// Inherits the same alignment from the parent (only valid for "alignSelf" property).
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            AlignAuto,
            /// <summary>
            /// At the beginning of the container.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            AlignFlexStart,
            /// <summary>
            /// At the center of the container.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            AlignCenter,
            /// <summary>
            /// At the end of the container.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            AlignFlexEnd,
            /// <summary>
            /// Stretch to fit the container.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            AlignStretch
        }

        /// <summary>
        /// Enumeration for the wrap type of the flex container when there is no enough room for
        /// all the items on one flex line.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
        public enum WrapType
        {
            /// <summary>
            /// Flex items laid out in single line (shrunk to fit the flex container along the main axis).
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            NoWrap,
            /// <summary>
            /// Flex items laid out in multiple lines if needed.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
            Wrap
        }

        /// <summary>
        /// The primary direction in which content is ordered.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
        public ContentDirectionType ContentDirection
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (ContentDirectionType)GetValue(ContentDirectionProperty);
                }
                else
                {
                    return (ContentDirectionType)GetInternalContentDirectionProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ContentDirectionProperty, value);
                }
                else
                {
                    SetInternalContentDirectionProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The direction of the main axis which determines the direction that flex items are laid out.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
        public FlexDirectionType FlexDirection
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (FlexDirectionType)GetValue(FlexDirectionProperty);
                }
                else
                {
                    return (FlexDirectionType)GetInternalFlexDirectionProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FlexDirectionProperty, value);
                }
                else
                {
                    SetInternalFlexDirectionProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Whether the flex items should wrap or not if there is no enough room for them on one flex line.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
        public WrapType FlexWrap
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (WrapType)GetValue(FlexWrapProperty);
                }
                else
                {
                    return (WrapType)GetInternalFlexWrapProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FlexWrapProperty, value);
                }
                else
                {
                    SetInternalFlexWrapProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The alignment of flex items when the items do not use all available space on the main axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
        public Justification JustifyContent
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Justification)GetValue(JustifyContentProperty);
                }
                else
                {
                    return (Justification)GetInternalJustifyContentProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(JustifyContentProperty, value);
                }
                else
                {
                    SetInternalJustifyContentProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The alignment of flex items when the items do not use all available space on the cross axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
        public Alignment AlignItems
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Alignment)GetValue(AlignItemsProperty);
                }
                else
                {
                    return (Alignment)GetInternalAlignItemsProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AlignItemsProperty, value);
                }
                else
                {
                    SetInternalAlignItemsProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Similar to "alignItems", but it aligns flex lines; so only works when there are multiple lines.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API8 and will be removed in API10. Use FlexLayout instead.")]
        public Alignment AlignContent
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Alignment)GetValue(AlignContentProperty);
                }
                else
                {
                    return (Alignment)GetInternalAlignContentProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AlignContentProperty, value);
                }
                else
                {
                    SetInternalAlignContentProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.FlexContainer.DeleteFlexContainer(swigCPtr);
        }

        /// <summary>
        /// Enumeration for the instance of child properties belonging to the FlexContainer class.
        /// </summary>
        internal class ChildProperty
        {
            internal static readonly int FLEX = Interop.FlexContainer.ChildPropertyFlexGet();
            internal static readonly int AlignSelf = Interop.FlexContainer.ChildPropertyAlignSelfGet();
            internal static readonly int FlexMargin = Interop.FlexContainer.ChildPropertyFlexMarginGet();
        }

        internal new class Property
        {
            internal static readonly int ContentDirection = Interop.FlexContainer.ContentDirectionGet();
            internal static readonly int FlexDirection = Interop.FlexContainer.FlexDirectionGet();
            internal static readonly int FlexWrap = Interop.FlexContainer.FlexWrapGet();
            internal static readonly int JustifyContent = Interop.FlexContainer.JustifyContentGet();
            internal static readonly int AlignItems = Interop.FlexContainer.AlignItemsGet();
            internal static readonly int AlignContent = Interop.FlexContainer.AlignContentGet();
        }
    }
}

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
    [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
    public class FlexContainer : View
    {
        /// <summary> Property of ContentDirection </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ContentDirectionProperty = BindableProperty.Create("ContentDirection", typeof(ContentDirectionType), typeof(FlexContainer), ContentDirectionType.Inherit, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var flexContainer = (FlexContainer)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(flexContainer.swigCPtr, FlexContainer.Property.CONTENT_DIRECTION, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var flexContainer = (FlexContainer)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(flexContainer.swigCPtr, FlexContainer.Property.CONTENT_DIRECTION).Get(out temp);
            return (ContentDirectionType)temp;
        });
        /// <summary> Property of FlexDirection </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexDirectionProperty = BindableProperty.Create("FlexDirection", typeof(FlexDirectionType), typeof(FlexContainer), FlexDirectionType.Column, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var flexContainer = (FlexContainer)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(flexContainer.swigCPtr, FlexContainer.Property.FLEX_DIRECTION, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var flexContainer = (FlexContainer)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(flexContainer.swigCPtr, FlexContainer.Property.FLEX_DIRECTION).Get(out temp);
            return (FlexDirectionType)temp;
        });
        /// <summary> Property of FlexWrap </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexWrapProperty = BindableProperty.Create("FlexWrap", typeof(WrapType), typeof(FlexContainer), WrapType.NoWrap, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var flexContainer = (FlexContainer)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(flexContainer.swigCPtr, FlexContainer.Property.FLEX_WRAP, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var flexContainer = (FlexContainer)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(flexContainer.swigCPtr, FlexContainer.Property.FLEX_WRAP).Get(out temp);
            return (WrapType)temp;
        });
        /// <summary> Property of JustifyContent </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty JustifyContentProperty = BindableProperty.Create("JustifyContent", typeof(Justification), typeof(FlexContainer), Justification.JustifyFlexStart, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var flexContainer = (FlexContainer)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(flexContainer.swigCPtr, FlexContainer.Property.JUSTIFY_CONTENT, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var flexContainer = (FlexContainer)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(flexContainer.swigCPtr, FlexContainer.Property.JUSTIFY_CONTENT).Get(out temp);
            return (Justification)temp;
        });
        /// <summary> Property of AlignItems </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AlignItemsProperty = BindableProperty.Create("AlignItems", typeof(Alignment), typeof(FlexContainer), Alignment.AlignAuto, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var flexContainer = (FlexContainer)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(flexContainer.swigCPtr, FlexContainer.Property.ALIGN_ITEMS, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var flexContainer = (FlexContainer)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(flexContainer.swigCPtr, FlexContainer.Property.ALIGN_ITEMS).Get(out temp);
            return (Alignment)temp;
        });
        /// <summary> Property of AlignContent </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AlignContentProperty = BindableProperty.Create("AlignContent", typeof(Alignment), typeof(FlexContainer), Alignment.AlignAuto, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var flexContainer = (FlexContainer)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(flexContainer.swigCPtr, FlexContainer.Property.ALIGN_CONTENT, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var flexContainer = (FlexContainer)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(flexContainer.swigCPtr, FlexContainer.Property.ALIGN_CONTENT).Get(out temp);
            return (Alignment)temp;
        });


        /// <summary>
        /// Creates a FlexContainer handle.
        /// Calling member functions with an uninitialized handle is not allowed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
        public FlexContainer() : this(Interop.FlexContainer.FlexContainer_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FlexContainer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.FlexContainer.FlexContainer_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        /// <summary>
        /// Enumeration for the direction of the main axis in the flex container. This determines
        /// the direction that flex items are laid out in the flex container.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
        public enum FlexDirectionType
        {
            /// <summary>
            /// The flexible items are displayed vertically as a column.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            Column,
            /// <summary>
            /// The flexible items are displayed vertically as a column, but in reverse order.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            ColumnReverse,
            /// <summary>
            /// The flexible items are displayed horizontally as a row.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            Row,
            /// <summary>
            /// The flexible items are displayed horizontally as a row.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            RowReverse
        }

        /// <summary>
        /// Enumeration for the primary direction in which content is ordered in the flex container
        /// and on which sides the ?�start??and ?�end??are.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
        public enum ContentDirectionType
        {
            /// <summary>
            /// Inherits the same direction from the parent.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            Inherit,
            /// <summary>
            /// From left to right.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            LTR,
            /// <summary>
            /// From right to left.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            RTL
        }

        /// <summary>
        /// Enumeration for the alignment of the flex items when the items do not use all available
        /// space on the main axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
        public enum Justification
        {
            /// <summary>
            /// Items are positioned at the beginning of the container.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            JustifyFlexStart,
            /// <summary>
            /// Items are positioned at the center of the container.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            JustifyCenter,
            /// <summary>
            /// Items are positioned at the end of the container.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            JustifyFlexEnd,
            /// <summary>
            /// Items are positioned with equal space between the lines.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            JustifySpaceBetween,
            /// <summary>
            /// Items are positioned with equal space before, between, and after the lines.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            JustifySpaceAround
        }

        /// <summary>
        /// Enumeration for the alignment of the flex items or lines when the items or lines do not
        /// use all the available space on the cross axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
        public enum Alignment
        {
            /// <summary>
            /// Inherits the same alignment from the parent (only valid for "alignSelf" property).
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            AlignAuto,
            /// <summary>
            /// At the beginning of the container.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            AlignFlexStart,
            /// <summary>
            /// At the center of the container.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            AlignCenter,
            /// <summary>
            /// At the end of the container.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            AlignFlexEnd,
            /// <summary>
            /// Stretch to fit the container.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            AlignStretch
        }

        /// <summary>
        /// Enumeration for the wrap type of the flex container when there is no enough room for
        /// all the items on one flex line.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
        public enum WrapType
        {
            /// <summary>
            /// Flex items laid out in single line (shrunk to fit the flex container along the main axis).
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            NoWrap,
            /// <summary>
            /// Flex items laid out in multiple lines if needed.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
            Wrap
        }

        /// <summary>
        /// The primary direction in which content is ordered.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
        public ContentDirectionType ContentDirection
        {
            get
            {
                return (ContentDirectionType)GetValue(ContentDirectionProperty);
            }
            set
            {
                SetValue(ContentDirectionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The direction of the main axis which determines the direction that flex items are laid out.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
        public FlexDirectionType FlexDirection
        {
            get
            {
                return (FlexDirectionType)GetValue(FlexDirectionProperty);
            }
            set
            {
                SetValue(FlexDirectionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Whether the flex items should wrap or not if there is no enough room for them on one flex line.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
        public WrapType FlexWrap
        {
            get
            {
                return (WrapType)GetValue(FlexWrapProperty);
            }
            set
            {
                SetValue(FlexWrapProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The alignment of flex items when the items do not use all available space on the main axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
        public Justification JustifyContent
        {
            get
            {
                return (Justification)GetValue(JustifyContentProperty);
            }
            set
            {
                SetValue(JustifyContentProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The alignment of flex items when the items do not use all available space on the cross axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
        public Alignment AlignItems
        {
            get
            {
                return (Alignment)GetValue(AlignItemsProperty);
            }
            set
            {
                SetValue(AlignItemsProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Similar to "alignItems", but it aligns flex lines; so only works when there are multiple lines.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API8, will be removed in API10. Please use FlexLayout instead!")]
        public Alignment AlignContent
        {
            get
            {
                return (Alignment)GetValue(AlignContentProperty);
            }
            set
            {
                SetValue(AlignContentProperty, value);
                NotifyPropertyChanged();
            }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.FlexContainer.delete_FlexContainer(swigCPtr);
        }

        /// <summary>
        /// Enumeration for the instance of child properties belonging to the FlexContainer class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API6, Will be removed in API9, " +
            "Please use View.Flex, View.AlignSelf, View.FlexMargin instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ChildProperty
        {
            internal static readonly int FLEX = Interop.FlexContainer.FlexContainer_ChildProperty_FLEX_get();
            internal static readonly int ALIGN_SELF = Interop.FlexContainer.FlexContainer_ChildProperty_ALIGN_SELF_get();
            internal static readonly int FLEX_MARGIN = Interop.FlexContainer.FlexContainer_ChildProperty_FLEX_MARGIN_get();
        }

        internal new class Property
        {
            internal static readonly int CONTENT_DIRECTION = Interop.FlexContainer.FlexContainer_Property_CONTENT_DIRECTION_get();
            internal static readonly int FLEX_DIRECTION = Interop.FlexContainer.FlexContainer_Property_FLEX_DIRECTION_get();
            internal static readonly int FLEX_WRAP = Interop.FlexContainer.FlexContainer_Property_FLEX_WRAP_get();
            internal static readonly int JUSTIFY_CONTENT = Interop.FlexContainer.FlexContainer_Property_JUSTIFY_CONTENT_get();
            internal static readonly int ALIGN_ITEMS = Interop.FlexContainer.FlexContainer_Property_ALIGN_ITEMS_get();
            internal static readonly int ALIGN_CONTENT = Interop.FlexContainer.FlexContainer_Property_ALIGN_CONTENT_get();
        }
    }
}

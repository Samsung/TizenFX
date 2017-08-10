/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// FlexContainer implements a subset of the flexbox spec (defined by W3C):https://www.w3.org/TR/css3-flexbox/<br>
    /// It aims at providing a more efficient way to lay out, align and distribute space among items in the container, even when their size is unknown or dynamic.<br>
    /// FlexContainer has the ability to alter the width and height of its children (i.e. flex items) to fill the available space in the best possible way on different screen sizes.<br>
    /// FlexContainer can expand items to fill available free space, or shrink them to prevent overflow.<br>
    /// </summary>
    public class FlexContainer : View
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal FlexContainer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.FlexContainer_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FlexContainer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
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
                    NDalicPINVOKE.delete_FlexContainer(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }


        internal class Property
        {
            internal static readonly int CONTENT_DIRECTION = NDalicPINVOKE.FlexContainer_Property_CONTENT_DIRECTION_get();
            internal static readonly int FLEX_DIRECTION = NDalicPINVOKE.FlexContainer_Property_FLEX_DIRECTION_get();
            internal static readonly int FLEX_WRAP = NDalicPINVOKE.FlexContainer_Property_FLEX_WRAP_get();
            internal static readonly int JUSTIFY_CONTENT = NDalicPINVOKE.FlexContainer_Property_JUSTIFY_CONTENT_get();
            internal static readonly int ALIGN_ITEMS = NDalicPINVOKE.FlexContainer_Property_ALIGN_ITEMS_get();
            internal static readonly int ALIGN_CONTENT = NDalicPINVOKE.FlexContainer_Property_ALIGN_CONTENT_get();

        }

        /// <summary>
        /// Enumeration for the instance of child properties belonging to the FlexContainer class.
        /// </summary>
        public class ChildProperty
        {
            internal static readonly int FLEX = NDalicPINVOKE.FlexContainer_ChildProperty_FLEX_get();
            internal static readonly int ALIGN_SELF = NDalicPINVOKE.FlexContainer_ChildProperty_ALIGN_SELF_get();
            internal static readonly int FLEX_MARGIN = NDalicPINVOKE.FlexContainer_ChildProperty_FLEX_MARGIN_get();
        }

        /// <summary>
        /// Creates a FlexContainer handle.
        /// Calling member functions with an uninitialized handle is not allowed.
        /// </summary>
        public FlexContainer() : this(NDalicPINVOKE.FlexContainer_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Enumeration for the direction of the main axis in the flex container. This determines
        /// the direction that flex items are laid out in the flex container.
        /// </summary>
        public enum FlexDirectionType
        {
            Column,
            ColumnReverse,
            Row,
            RowReverse
        }

        /// <summary>
        /// Enumeration for the primary direction in which content is ordered in the flex container
        /// and on which sides the ?�start??and ?�end??are.
        /// </summary>
        public enum ContentDirectionType
        {
            Inherit,
            LTR,
            RTL
        }

        /// <summary>
        /// Enumeration for the alignment of the flex items when the items do not use all available
        /// space on the main-axis.
        /// </summary>
        public enum Justification
        {
            JustifyFlexStart,
            JustifyCenter,
            JustifyFlexEnd,
            JustifySpaceBetween,
            JustifySpaceAround
        }

        /// <summary>
        /// Enumeration for the alignment of the flex items or lines when the items or lines do not
        /// use all the available space on the cross-axis.
        /// </summary>
        public enum Alignment
        {
            AlignAuto,
            AlignFlexStart,
            AlignCenter,
            AlignFlexEnd,
            AlignStretch
        }

        /// <summary>
        /// Enumeration for the wrap type of the flex container when there is no enough room for
        /// all the items on one flex line.
        /// </summary>
        public enum WrapType
        {
            NoWrap,
            Wrap
        }

        /// <summary>
        /// The primary direction in which content is ordered
        /// </summary>
        public ContentDirectionType ContentDirection
        {
            get
            {
                int temp = 0;
                GetProperty(FlexContainer.Property.CONTENT_DIRECTION).Get(out temp);
                return (ContentDirectionType)temp;
            }
            set
            {
                SetProperty(FlexContainer.Property.CONTENT_DIRECTION, new Tizen.NUI.PropertyValue((int)value));
            }
        }

        /// <summary>
        /// The direction of the main-axis which determines the direction that flex items are laid out
        /// </summary>
        public FlexDirectionType FlexDirection
        {
            get
            {
                int temp = 0;
                GetProperty(FlexContainer.Property.FLEX_DIRECTION).Get(out temp);
                return (FlexDirectionType)temp;
            }
            set
            {
                SetProperty(FlexContainer.Property.FLEX_DIRECTION, new Tizen.NUI.PropertyValue((int)value));
            }
        }

        /// <summary>
        /// Whether the flex items should wrap or not if there is no enough room for them on one flex line
        /// </summary>
        public WrapType FlexWrap
        {
            get
            {
                int temp = 0;
                GetProperty(FlexContainer.Property.FLEX_WRAP).Get(out temp);
                return (WrapType)temp;
            }
            set
            {
                SetProperty(FlexContainer.Property.FLEX_WRAP, new Tizen.NUI.PropertyValue((int)value));
            }
        }

        /// <summary>
        /// The alignment of flex items when the items do not use all available space on the main-axis
        /// </summary>
        public Justification JustifyContent
        {
            get
            {
                int temp = 0;
                GetProperty(FlexContainer.Property.JUSTIFY_CONTENT).Get(out temp);
                return (Justification)temp;
            }
            set
            {
                SetProperty(FlexContainer.Property.JUSTIFY_CONTENT, new Tizen.NUI.PropertyValue((int)value));
            }
        }

        /// <summary>
        /// The alignment of flex items when the items do not use all available space on the cross-axis
        /// </summary>
        public Alignment AlignItems
        {
            get
            {
                int temp = 0;
                GetProperty(FlexContainer.Property.ALIGN_ITEMS).Get(out temp);
                return (Alignment)temp;
            }
            set
            {
                SetProperty(FlexContainer.Property.ALIGN_ITEMS, new Tizen.NUI.PropertyValue((int)value));
            }
        }

        /// <summary>
        /// Similar to "alignItems", but it aligns flex lines, so only works when there are multiple lines
        /// </summary>
        public Alignment AlignContent
        {
            get
            {
                int temp = 0;
                GetProperty(FlexContainer.Property.ALIGN_CONTENT).Get(out temp);
                return (Alignment)temp;
            }
            set
            {
                SetProperty(FlexContainer.Property.ALIGN_CONTENT, new Tizen.NUI.PropertyValue((int)value));
            }
        }

    }

}

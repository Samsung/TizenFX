/** Copyright (c) 2018 Samsung Electronics Co., Ltd.
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
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class FlexLayout : LayoutGroupWrapper
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal FlexLayout(global::System.IntPtr cPtr, bool cMemoryOwn) : base(LayoutPINVOKE.FlexLayout_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FlexLayout obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }


        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    LayoutPINVOKE.delete_FlexLayout(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            base.Dispose(type);
        }


        public FlexLayout() : this(LayoutPINVOKE.FlexLayout_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FlexLayout DownCast(BaseHandle handle)
        {
            FlexLayout ret = new FlexLayout(LayoutPINVOKE.FlexLayout_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal FlexLayout(FlexLayout other) : this(LayoutPINVOKE.new_FlexLayout__SWIG_1(FlexLayout.getCPtr(other)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FlexLayout Assign(FlexLayout other)
        {
            FlexLayout ret = new FlexLayout(LayoutPINVOKE.FlexLayout_Assign(swigCPtr, FlexLayout.getCPtr(other)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFlexDirection(FlexLayout.FlexDirection flexDirection)
        {
            LayoutPINVOKE.FlexLayout_SetFlexDirection(swigCPtr, (int)flexDirection);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FlexLayout.FlexDirection GetFlexDirection()
        {
            FlexLayout.FlexDirection ret = (FlexLayout.FlexDirection)LayoutPINVOKE.FlexLayout_GetFlexDirection(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFlexJustification(FlexLayout.FlexJustification flexJustification)
        {
            LayoutPINVOKE.FlexLayout_SetFlexJustification(swigCPtr, (int)flexJustification);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FlexLayout.FlexJustification GetFlexJustification()
        {
            FlexLayout.FlexJustification ret = (FlexLayout.FlexJustification)LayoutPINVOKE.FlexLayout_GetFlexJustification(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFlexWrap(FlexLayout.FlexWrapType flexWrap)
        {
            LayoutPINVOKE.FlexLayout_SetFlexWrap(swigCPtr, (int)flexWrap);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FlexLayout.FlexWrapType GetFlexWrap()
        {
            FlexLayout.FlexWrapType ret = (FlexLayout.FlexWrapType)LayoutPINVOKE.FlexLayout_GetFlexWrap(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFlexAlignment(FlexLayout.AlignmentType flexAlignment)
        {
            LayoutPINVOKE.FlexLayout_SetFlexAlignment(swigCPtr, (int)flexAlignment);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FlexLayout.AlignmentType GetFlexAlignment()
        {
            FlexLayout.AlignmentType ret = (FlexLayout.AlignmentType)LayoutPINVOKE.FlexLayout_GetFlexAlignment(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFlexItemsAlignment(FlexLayout.AlignmentType flexAlignment)
        {
            LayoutPINVOKE.FlexLayout_SetFlexItemsAlignment(swigCPtr, (int)flexAlignment);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FlexLayout.AlignmentType GetFlexItemsAlignment()
        {
            FlexLayout.AlignmentType ret = (FlexLayout.AlignmentType)LayoutPINVOKE.FlexLayout_GetFlexItemsAlignment(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal enum PropertyRange
        {
            CHILD_PROPERTY_START_INDEX = PropertyRanges.CHILD_PROPERTY_REGISTRATION_START_INDEX,
            CHILD_PROPERTY_END_INDEX = PropertyRanges.CHILD_PROPERTY_REGISTRATION_START_INDEX + 1000
        }

        internal class ChildProperty
        {
            internal static readonly int FLEX = LayoutPINVOKE.FlexLayout_ChildProperty_FLEX_get();
            internal static readonly int ALIGN_SELF = LayoutPINVOKE.FlexLayout_ChildProperty_ALIGN_SELF_get();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum FlexDirection
        {
            Column,
            ColumnReverse,
            Row,
            RowReverse
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum FlexJustification
        {
            FlexStart,
            Center,
            FlexEnd,
            SpaceBetween,
            SpaceAround
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum FlexWrapType
        {
            NoWrap,
            Wrap
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum AlignmentType
        {
            Auto,
            FlexStart,
            Center,
            FlexEnd,
            Stretch
        }
    }
}

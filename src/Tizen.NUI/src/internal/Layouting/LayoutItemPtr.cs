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

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal class LayoutItemPtr : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal LayoutItemPtr(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LayoutItemPtr obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        ~LayoutItemPtr()
        {
            Dispose();
        }

        public virtual void Dispose()
        {
            lock(this) {
            if (swigCPtr.Handle != global::System.IntPtr.Zero) {
                if (swigCMemOwn) {
                swigCMemOwn = false;
                LayoutPINVOKE.delete_LayoutItemPtr(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            global::System.GC.SuppressFinalize(this);
            }
        }

        public LayoutItemPtr() : this(LayoutPINVOKE.new_LayoutItemPtr__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal LayoutItemPtr(LayoutItemWrapperImpl p) : this(LayoutPINVOKE.new_LayoutItemPtr__SWIG_1(LayoutItemWrapperImpl.getCPtr(p)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public LayoutItemPtr(LayoutItemPtr rhs) : this(LayoutPINVOKE.new_LayoutItemPtr__SWIG_2(LayoutItemPtr.getCPtr(rhs)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal LayoutItemWrapperImpl Get()
        {
            global::System.IntPtr cPtr = LayoutPINVOKE.LayoutItemPtr_Get(swigCPtr);
            LayoutItemWrapperImpl ret = (cPtr == global::System.IntPtr.Zero) ? null : new LayoutItemWrapperImpl(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LayoutItemWrapperImpl __deref__()
        {
            global::System.IntPtr cPtr = LayoutPINVOKE.LayoutItemPtr___deref__(swigCPtr);
            LayoutItemWrapperImpl ret = (cPtr == global::System.IntPtr.Zero) ? null : new LayoutItemWrapperImpl(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LayoutItemWrapperImpl __ref__()
        {
            LayoutItemWrapperImpl ret = new LayoutItemWrapperImpl(LayoutPINVOKE.LayoutItemPtr___ref__(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Reset()
        {
            LayoutPINVOKE.LayoutItemPtr_Reset__SWIG_0(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void Reset(LayoutItemWrapperImpl rhs)
        {
            LayoutPINVOKE.LayoutItemPtr_Reset__SWIG_1(swigCPtr, LayoutItemWrapperImpl.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal LayoutItemWrapperImpl Detach()
        {
            global::System.IntPtr cPtr = LayoutPINVOKE.LayoutItemPtr_Detach(swigCPtr);
            LayoutItemWrapperImpl ret = (cPtr == global::System.IntPtr.Zero) ? null : new LayoutItemWrapperImpl(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /*public LayoutItemPtr New(Handle owner)
        {
            LayoutItemPtr ret = new LayoutItemPtr(LayoutPINVOKE.LayoutItemPtr_New(swigCPtr, Handle.getCPtr(owner)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Initialize(Handle owner, string containerType)
        {
            LayoutPINVOKE.LayoutItemPtr_Initialize(swigCPtr, Handle.getCPtr(owner), containerType);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }*/

        public void Unparent()
        {
            LayoutPINVOKE.LayoutItemPtr_Unparent(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetAnimateLayout(bool animateLayout)
        {
            LayoutPINVOKE.LayoutItemPtr_SetAnimateLayout(swigCPtr, animateLayout);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsLayoutAnimated()
        {
            bool ret = LayoutPINVOKE.LayoutItemPtr_IsLayoutAnimated(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Measure(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {
            LayoutPINVOKE.LayoutItemPtr_Measure(swigCPtr, LayoutMeasureSpec.getCPtr(widthMeasureSpec), LayoutMeasureSpec.getCPtr(heightMeasureSpec));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Layout(LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            LayoutPINVOKE.LayoutItemPtr_Layout(swigCPtr, LayoutLength.getCPtr(left), LayoutLength.getCPtr(top), LayoutLength.getCPtr(right), LayoutLength.getCPtr(bottom));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public LayoutLength GetDefaultSize(LayoutLength size, LayoutMeasureSpec measureSpec)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutItemPtr_GetDefaultSize(swigCPtr, LayoutLength.getCPtr(size), LayoutMeasureSpec.getCPtr(measureSpec)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /*public LayoutParent GetParent()
        {
            global::System.IntPtr cPtr = (SwigDerivedClassHasMethod("GetParent", swigMethodTypes0) ? LayoutPINVOKE.LayoutItemPtr_GetParentSwigExplicitLayoutItemWrapperImpl(swigCPtr) : LayoutPINVOKE.LayoutItemPtr_GetParent(swigCPtr));
            LayoutParent ret = (cPtr == global::System.IntPtr.Zero) ? null : new LayoutParent(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }*/

        public void RequestLayout()
        {
            LayoutPINVOKE.LayoutItemPtr_RequestLayout(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsLayoutRequested()
        {
            bool ret = LayoutPINVOKE.LayoutItemPtr_IsLayoutRequested(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength GetMeasuredWidth()
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutItemPtr_GetMeasuredWidth(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength GetMeasuredHeight()
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutItemPtr_GetMeasuredHeight(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public MeasuredSize GetMeasuredWidthAndState()
        {
            MeasuredSize ret = new MeasuredSize(LayoutPINVOKE.LayoutItemPtr_GetMeasuredWidthAndState(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public MeasuredSize GetMeasuredHeightAndState()
        {
            MeasuredSize ret = new MeasuredSize(LayoutPINVOKE.LayoutItemPtr_GetMeasuredHeightAndState(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength GetSuggestedMinimumWidth()
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutItemPtr_GetSuggestedMinimumWidth(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength GetSuggestedMinimumHeight()
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutItemPtr_GetSuggestedMinimumHeight(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetMinimumWidth(LayoutLength minWidth)
        {
            LayoutPINVOKE.LayoutItemPtr_SetMinimumWidth(swigCPtr, LayoutLength.getCPtr(minWidth));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetMinimumHeight(LayoutLength minHeight)
        {
            LayoutPINVOKE.LayoutItemPtr_SetMinimumHeight(swigCPtr, LayoutLength.getCPtr(minHeight));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public LayoutLength GetMinimumWidth()
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutItemPtr_GetMinimumWidth(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength GetMinimumHeight()
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutItemPtr_GetMinimumHeight(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Extents GetPadding()
        {
            Extents ret = new Extents(LayoutPINVOKE.LayoutItemPtr_GetPadding(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetMeasuredDimensions(MeasuredSize measuredWidth, MeasuredSize measuredHeight)
        {
            LayoutPINVOKE.LayoutItemPtr_SetMeasuredDimensions(swigCPtr, MeasuredSize.getCPtr(measuredWidth), MeasuredSize.getCPtr(measuredHeight));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool DoAction(string actionName, PropertyMap attributes)
        {
            bool ret = LayoutPINVOKE.LayoutItemPtr_DoAction(swigCPtr, actionName, PropertyMap.getCPtr(attributes));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public string GetTypeName()
        {
            string ret = LayoutPINVOKE.LayoutItemPtr_GetTypeName(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool GetTypeInfo(TypeInfo info)
        {
            bool ret = LayoutPINVOKE.LayoutItemPtr_GetTypeInfo(swigCPtr, TypeInfo.getCPtr(info));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Reference()
        {
            LayoutPINVOKE.LayoutItemPtr_Reference(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Unreference()
        {
            LayoutPINVOKE.LayoutItemPtr_Unreference(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public int ReferenceCount()
        {
            int ret = LayoutPINVOKE.LayoutItemPtr_ReferenceCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }
}

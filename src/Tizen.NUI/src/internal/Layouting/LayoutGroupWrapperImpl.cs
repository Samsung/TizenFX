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
using System;
using Tizen.NUI.BaseComponents;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// Internal Layout class that all layout containers should derive from.
    /// Mirrors the native class LayoutGroup.
    /// </summary>
    internal class LayoutGroupWrapperImpl : LayoutItemWrapperImpl
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        public delegate void OnMeasureDelegate(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec);
        public delegate void OnLayoutDelegate(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom);
        public delegate void OnSizeChangedDelegate(LayoutSize newSize, LayoutSize oldSize);
        public delegate void OnChildAddDelegate(LayoutItemWrapperImpl child);
        public delegate void OnChildRemoveDelegate(LayoutItemWrapperImpl child);
        public delegate void DoInitializeDelegate();
        public delegate void DoRegisterChildPropertiesDelegate(string containerType);
        public delegate void MeasureChildrenDelegate(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec);
        public delegate void MeasureChildDelegate(LayoutItem child, LayoutMeasureSpec parentWidthMeasureSpec, LayoutMeasureSpec parentHeightMeasureSpec);
        public delegate void MeasureChildWithMarginsDelegate(LayoutItem child, LayoutMeasureSpec parentWidthMeasureSpec, LayoutLength widthUsed, LayoutMeasureSpec parentHeightMeasureSpec, LayoutLength heightUsed);

        public OnMeasureDelegate OnMeasure;
        public OnLayoutDelegate OnLayout;
        public OnSizeChangedDelegate OnSizeChanged;
        public OnChildAddDelegate OnChildAdd;
        public OnChildRemoveDelegate OnChildRemove;
        public DoInitializeDelegate DoInitialize;
        public DoRegisterChildPropertiesDelegate DoRegisterChildProperties;
        public MeasureChildrenDelegate MeasureChildren;
        public MeasureChildDelegate MeasureChild;
        public MeasureChildWithMarginsDelegate MeasureChildWithMargins;

        internal LayoutGroupWrapperImpl(global::System.IntPtr cPtr, bool cMemoryOwn) : base(LayoutPINVOKE.LayoutGroupWrapperImpl_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LayoutGroupWrapperImpl obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        public LayoutGroupWrapperImpl() : this(LayoutPINVOKE.new_LayoutGroupWrapperImpl(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            SwigDirectorConnect();
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
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            base.Dispose(type);
        }

        internal uint Add(LayoutItemWrapperImpl layoutChild)
        {
            uint ret = LayoutPINVOKE.LayoutGroupWrapperImpl_Add(swigCPtr, LayoutItemWrapperImpl.getCPtr(layoutChild));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void Remove(uint childId)
        {
            LayoutPINVOKE.LayoutGroupWrapperImpl_Remove__SWIG_0(swigCPtr, childId);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void Remove(LayoutItemWrapperImpl child)
        {
            LayoutPINVOKE.LayoutGroupWrapperImpl_Remove__SWIG_1(swigCPtr, LayoutItemWrapperImpl.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void RemoveAll()
        {
            LayoutPINVOKE.LayoutGroupWrapperImpl_RemoveAll(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal uint GetChildCount()
        {
            uint ret = LayoutPINVOKE.LayoutGroupWrapperImpl_GetChildCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutItem GetChildAt(uint childIndex)
        {
            IntPtr cPtr = LayoutPINVOKE.LayoutGroupWrapperImpl_GetChildAt(swigCPtr, childIndex);
            HandleRef CPtrHandleRef = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);

            global::System.IntPtr refObjectPtr = LayoutPINVOKE.LayoutItemPtr_Get(CPtrHandleRef);
            LayoutItem ret = Registry.GetManagedBaseHandleFromRefObject(refObjectPtr) as LayoutItem;

            LayoutPINVOKE.delete_LayoutItemPtr(CPtrHandleRef);
            CPtrHandleRef = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal uint GetChildId(LayoutItemWrapperImpl child)
        {
            uint ret = LayoutPINVOKE.LayoutGroupWrapperImpl_GetChildId(swigCPtr, LayoutItemWrapperImpl.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutItem GetChild(uint childId)
        {
            IntPtr cPtr = LayoutPINVOKE.LayoutGroupWrapperImpl_GetChild(swigCPtr, childId);
            HandleRef CPtrHandleRef = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);

            global::System.IntPtr refObjectPtr = LayoutPINVOKE.LayoutItemPtr_Get(CPtrHandleRef);
            LayoutItem ret = Registry.GetManagedBaseHandleFromRefObject(refObjectPtr) as LayoutItem;

            LayoutPINVOKE.delete_LayoutItemPtr(CPtrHandleRef);
            CPtrHandleRef = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static LayoutMeasureSpec GetChildMeasureSpec(LayoutMeasureSpec measureSpec, LayoutLength padding, LayoutLength childDimension)
        {
            LayoutMeasureSpec ret = new LayoutMeasureSpec(LayoutPINVOKE.LayoutGroupWrapperImpl_GetChildMeasureSpec(LayoutMeasureSpec.getCPtr(measureSpec), LayoutLength.getCPtr(padding), LayoutLength.getCPtr(childDimension)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal virtual void MeasureChildrenNative(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {
            LayoutPINVOKE.LayoutGroupWrapperImpl_MeasureChildrenSwigExplicitLayoutGroupWrapperImpl(swigCPtr, LayoutMeasureSpec.getCPtr(widthMeasureSpec), LayoutMeasureSpec.getCPtr(heightMeasureSpec));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void MeasureChildNative(LayoutItem child, LayoutMeasureSpec parentWidthMeasureSpec, LayoutMeasureSpec parentHeightMeasureSpec)
        {
            LayoutPINVOKE.LayoutGroupWrapperImpl_MeasureChildSwigExplicitLayoutGroupWrapperImpl(swigCPtr, LayoutItem.getCPtr(child), LayoutMeasureSpec.getCPtr(parentWidthMeasureSpec), LayoutMeasureSpec.getCPtr(parentHeightMeasureSpec));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void MeasureChildWithMarginsNative(LayoutItem child, LayoutMeasureSpec parentWidthMeasureSpec, LayoutLength widthUsed, LayoutMeasureSpec parentHeightMeasureSpec, LayoutLength heightUsed)
        {
            LayoutPINVOKE.LayoutGroupWrapperImpl_MeasureChildWithMarginsSwigExplicitLayoutGroupWrapperImpl(swigCPtr, LayoutItem.getCPtr(child), LayoutMeasureSpec.getCPtr(parentWidthMeasureSpec), LayoutLength.getCPtr(widthUsed), LayoutMeasureSpec.getCPtr(parentHeightMeasureSpec), LayoutLength.getCPtr(heightUsed));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void SwigDirectorConnect()
        {
            base.SwigDirectorConnect();

            //swigDelegate0 = new SwigDelegateLayoutGroupWrapperImpl_0(SwigDirectorGetParent);
            swigDelegate3 = new SwigDelegateLayoutGroupWrapperImpl_3(SwigDirectorOnMeasure);
            swigDelegate4 = new SwigDelegateLayoutGroupWrapperImpl_4(SwigDirectorOnLayout);
            swigDelegate5 = new SwigDelegateLayoutGroupWrapperImpl_5(SwigDirectorOnSizeChanged);
            swigDelegate7 = new SwigDelegateLayoutGroupWrapperImpl_7(SwigDirectorOnChildAdd);
            swigDelegate8 = new SwigDelegateLayoutGroupWrapperImpl_8(SwigDirectorOnChildRemove);
            swigDelegate9 = new SwigDelegateLayoutGroupWrapperImpl_9(SwigDirectorDoInitialize);
            swigDelegate10 = new SwigDelegateLayoutGroupWrapperImpl_10(SwigDirectorDoRegisterChildProperties);
            swigDelegate12 = new SwigDelegateLayoutGroupWrapperImpl_12(SwigDirectorMeasureChildren);
            swigDelegate13 = new SwigDelegateLayoutGroupWrapperImpl_13(SwigDirectorMeasureChild);
            swigDelegate14 = new SwigDelegateLayoutGroupWrapperImpl_14(SwigDirectorMeasureChildWithMargins);

            LayoutPINVOKE.LayoutGroupWrapperImpl_director_connect(swigCPtr, swigDelegate0, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14);
        }

        /*private global::System.IntPtr SwigDirectorGetParent()
        {
            return LayoutParent.getCPtr(GetParent()).Handle;
        }*/

        private void SwigDirectorOnMeasure(global::System.IntPtr widthMeasureSpec, global::System.IntPtr heightMeasureSpec)
        {
            OnMeasure(new LayoutMeasureSpec(widthMeasureSpec, true), new LayoutMeasureSpec(heightMeasureSpec, true));
        }

        private void SwigDirectorOnLayout(bool changed, global::System.IntPtr left, global::System.IntPtr top, global::System.IntPtr right, global::System.IntPtr bottom)
        {
            OnLayout(changed, new LayoutLength(left, true), new LayoutLength(top, true), new LayoutLength(right, true), new LayoutLength(bottom, true));
        }

        private void SwigDirectorOnSizeChanged(global::System.IntPtr newSize, global::System.IntPtr oldSize)
        {
            OnSizeChanged(new LayoutSize(newSize, true), new LayoutSize(oldSize, true));
        }

        private void SwigDirectorOnChildAdd(global::System.IntPtr child)
        {
            OnChildAdd(new LayoutItemWrapperImpl(child, false));
        }

        private void SwigDirectorOnChildRemove(global::System.IntPtr child)
        {
            OnChildRemove(new LayoutItemWrapperImpl(child, false));
        }

        private void SwigDirectorDoInitialize()
        {
            DoInitialize();
        }

        private void SwigDirectorDoRegisterChildProperties(string containerType)
        {
            DoRegisterChildProperties(containerType);
        }

        private void SwigDirectorMeasureChildren(global::System.IntPtr widthMeasureSpec, global::System.IntPtr heightMeasureSpec)
        {
            MeasureChildren(new LayoutMeasureSpec(widthMeasureSpec, true), new LayoutMeasureSpec(heightMeasureSpec, true));
        }

        private void SwigDirectorMeasureChild(global::System.IntPtr child, global::System.IntPtr parentWidthMeasureSpec, global::System.IntPtr parentHeightMeasureSpec)
        {
            HandleRef CPtrHandleRef = new global::System.Runtime.InteropServices.HandleRef(this, child);

            global::System.IntPtr refObjectPtr = LayoutPINVOKE.LayoutItemPtr_Get(CPtrHandleRef);
            LayoutItem layoutItem = Registry.GetManagedBaseHandleFromRefObject(refObjectPtr) as LayoutItem;

            MeasureChild(layoutItem, new LayoutMeasureSpec(parentWidthMeasureSpec, true), new LayoutMeasureSpec(parentHeightMeasureSpec, true));

            LayoutPINVOKE.delete_LayoutItemPtr(CPtrHandleRef);
            CPtrHandleRef = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
        }

        private void SwigDirectorMeasureChildWithMargins(global::System.IntPtr child, global::System.IntPtr parentWidthMeasureSpec, global::System.IntPtr widthUsed, global::System.IntPtr parentHeightMeasureSpec, global::System.IntPtr heightUsed)
        {
            HandleRef CPtrHandleRef = new global::System.Runtime.InteropServices.HandleRef(this, child);

            global::System.IntPtr refObjectPtr = LayoutPINVOKE.LayoutItemPtr_Get(CPtrHandleRef);
            LayoutItem layoutItem = Registry.GetManagedBaseHandleFromRefObject(refObjectPtr) as LayoutItem;

            MeasureChildWithMargins(layoutItem, new LayoutMeasureSpec(parentWidthMeasureSpec, true), new LayoutLength(widthUsed, true), new LayoutMeasureSpec(parentHeightMeasureSpec, true), new LayoutLength(heightUsed, true));

            LayoutPINVOKE.delete_LayoutItemPtr(CPtrHandleRef);
            CPtrHandleRef = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
        }

        public delegate global::System.IntPtr SwigDelegateLayoutGroupWrapperImpl_0();
        public delegate void SwigDelegateLayoutGroupWrapperImpl_3(global::System.IntPtr widthMeasureSpec, global::System.IntPtr heightMeasureSpec);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_4(bool changed, global::System.IntPtr left, global::System.IntPtr top, global::System.IntPtr right, global::System.IntPtr bottom);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_5(global::System.IntPtr newSize, global::System.IntPtr oldSize);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_6();
        public delegate void SwigDelegateLayoutGroupWrapperImpl_7(global::System.IntPtr child);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_8(global::System.IntPtr child);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_9();
        public delegate void SwigDelegateLayoutGroupWrapperImpl_10(string containerType);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_11(global::System.IntPtr child);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_12(global::System.IntPtr widthMeasureSpec, global::System.IntPtr heightMeasureSpec);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_13(global::System.IntPtr child, global::System.IntPtr parentWidthMeasureSpec, global::System.IntPtr parentHeightMeasureSpec);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_14(global::System.IntPtr child, global::System.IntPtr parentWidthMeasureSpec, global::System.IntPtr widthUsed, global::System.IntPtr parentHeightMeasureSpec, global::System.IntPtr heightUsed);

        private SwigDelegateLayoutGroupWrapperImpl_0 swigDelegate0;
        private SwigDelegateLayoutGroupWrapperImpl_3 swigDelegate3;
        private SwigDelegateLayoutGroupWrapperImpl_4 swigDelegate4;
        private SwigDelegateLayoutGroupWrapperImpl_5 swigDelegate5;
        private SwigDelegateLayoutGroupWrapperImpl_6 swigDelegate6;
        private SwigDelegateLayoutGroupWrapperImpl_7 swigDelegate7;
        private SwigDelegateLayoutGroupWrapperImpl_8 swigDelegate8;
        private SwigDelegateLayoutGroupWrapperImpl_9 swigDelegate9;
        private SwigDelegateLayoutGroupWrapperImpl_10 swigDelegate10;
        private SwigDelegateLayoutGroupWrapperImpl_11 swigDelegate11;
        private SwigDelegateLayoutGroupWrapperImpl_12 swigDelegate12;
        private SwigDelegateLayoutGroupWrapperImpl_13 swigDelegate13;
        private SwigDelegateLayoutGroupWrapperImpl_14 swigDelegate14;
    }
} // namespace Tizen.NUI
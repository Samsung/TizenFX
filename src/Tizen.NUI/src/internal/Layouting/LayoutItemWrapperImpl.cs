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
    internal class LayoutItemWrapperImpl : BaseObject, ILayoutParent
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        public delegate void OnMeasureDelegate(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec);
        public delegate void OnLayoutDelegate(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom);
        public delegate void OnSizeChangedDelegate(LayoutSize newSize, LayoutSize oldSize);

        public OnMeasureDelegate OnMeasure;
        public OnLayoutDelegate OnLayout;
        public OnSizeChangedDelegate OnSizeChanged;

        internal LayoutItemWrapperImpl(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LayoutItemWrapperImpl obj)
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
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            base.Dispose(type);
        }

        public LayoutItemWrapperImpl() : this(Interop.LayoutItemWrapperImpl.new_LayoutItemWrapperImpl(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            SwigDirectorConnect();
        }

        /* public LayoutItemWrapperImpl (Handle owner) : this (NDalicPINVOKE.LayoutItemWrapperImpl_New(Handle.getCPtr(owner)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }*/

        public void Initialize(View owner, string containerType)
        {
            Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_Initialize(swigCPtr, View.getCPtr(owner), containerType);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public View GetOwner()
        {
            global::System.IntPtr cPtr = Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_GetOwner(swigCPtr);
            View ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as View;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void Unparent()
        {
            Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_Unparent(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetAnimateLayout(bool animateLayout)
        {
            Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_SetAnimateLayout(swigCPtr, animateLayout);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsLayoutAnimated()
        {
            bool ret = Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_IsLayoutAnimated(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void Measure(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {
            Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_Measure(swigCPtr, LayoutMeasureSpec.getCPtr(widthMeasureSpec), LayoutMeasureSpec.getCPtr(heightMeasureSpec));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void Layout(LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_Layout(swigCPtr, LayoutLength.getCPtr(left), LayoutLength.getCPtr(top), LayoutLength.getCPtr(right), LayoutLength.getCPtr(bottom));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static LayoutLength GetDefaultSize(LayoutLength size, LayoutMeasureSpec measureSpec)
        {
            LayoutLength ret = new LayoutLength(Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_GetDefaultSize(LayoutLength.getCPtr(size), LayoutMeasureSpec.getCPtr(measureSpec)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public ILayoutParent GetParent()
        {
            global::System.IntPtr cPtr = Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_GetParent(swigCPtr);
            //ILayoutParent ret = (cPtr == global::System.IntPtr.Zero) ? null : new ILayoutParent(cPtr, false);
            ILayoutParent ret = (cPtr == global::System.IntPtr.Zero) ? null : new LayoutItemWrapperImpl(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void RequestLayout()
        {
            Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_RequestLayout(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsLayoutRequested()
        {
            bool ret = Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_IsLayoutRequested(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LayoutLength GetMeasuredWidth()
        {
            LayoutLength ret = new LayoutLength(Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_GetMeasuredWidth(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LayoutLength GetMeasuredHeight()
        {
            LayoutLength ret = new LayoutLength(Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_GetMeasuredHeight(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal MeasuredSize GetMeasuredWidthAndState()
        {
            MeasuredSize ret = new MeasuredSize(Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_GetMeasuredWidthAndState(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal MeasuredSize GetMeasuredHeightAndState()
        {
            MeasuredSize ret = new MeasuredSize(Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_GetMeasuredHeightAndState(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LayoutLength GetSuggestedMinimumWidth()
        {
            LayoutLength ret = new LayoutLength(Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_GetSuggestedMinimumWidth(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LayoutLength GetSuggestedMinimumHeight()
        {
            LayoutLength ret = new LayoutLength(Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_GetSuggestedMinimumHeight(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetMinimumWidth(LayoutLength minWidth)
        {
            Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_SetMinimumWidth(swigCPtr, LayoutLength.getCPtr(minWidth));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetMinimumHeight(LayoutLength minHeight)
        {
            Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_SetMinimumHeight(swigCPtr, LayoutLength.getCPtr(minHeight));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal LayoutLength GetMinimumWidth()
        {
            LayoutLength ret = new LayoutLength(Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_GetMinimumWidth(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LayoutLength GetMinimumHeight()
        {
            LayoutLength ret = new LayoutLength(Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_GetMinimumHeight(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Extents GetPadding()
        {
            Extents ret = new Extents(Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_GetPadding(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetMeasuredDimensions(MeasuredSize measuredWidth, MeasuredSize measuredHeight)
        {
            Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_SetMeasuredDimensions(swigCPtr, MeasuredSize.getCPtr(measuredWidth), MeasuredSize.getCPtr(measuredHeight));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void OnMeasureNative(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {
            Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_OnMeasureSwigExplicitLayoutItemWrapperImpl(swigCPtr, LayoutMeasureSpec.getCPtr(widthMeasureSpec), LayoutMeasureSpec.getCPtr(heightMeasureSpec));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void OnLayoutNative(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_OnLayout(swigCPtr, changed, LayoutLength.getCPtr(left), LayoutLength.getCPtr(top), LayoutLength.getCPtr(right), LayoutLength.getCPtr(bottom));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void OnSizeChangedNative(LayoutSize newSize, LayoutSize oldSize)
        {
            Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_OnSizeChanged(swigCPtr, LayoutSize.getCPtr(newSize), LayoutSize.getCPtr(oldSize));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected void SwigDirectorConnect()
        {
            //swigDelegate0 = new SwigDelegateLayoutItemWrapperImpl_0(SwigDirectorGetParent);
            swigDelegate0 = null;
            swigDelegate1 = null;
            swigDelegate2 = null;
            swigDelegate3 = new SwigDelegateLayoutItemWrapperImpl_3(SwigDirectorOnMeasure);
            swigDelegate4 = new SwigDelegateLayoutItemWrapperImpl_4(SwigDirectorOnLayout);
            swigDelegate5 = new SwigDelegateLayoutItemWrapperImpl_5(SwigDirectorOnSizeChanged);
            swigDelegate6 = null;

            Interop.LayoutItemWrapperImpl.LayoutItemWrapperImpl_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
        }

        private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes)
        {
            global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
            bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(LayoutItemWrapperImpl));
            return hasDerivedMethod;
        }

        /*private global::System.IntPtr SwigDirectorGetParent()
        {
            return ILayoutParent.getCPtr(GetParent()).Handle;
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

        public delegate global::System.IntPtr SwigDelegateLayoutItemWrapperImpl_0();
        public delegate void SwigDelegateLayoutItemWrapperImpl_1();
        public delegate void SwigDelegateLayoutItemWrapperImpl_2(string containerType);
        public delegate void SwigDelegateLayoutItemWrapperImpl_3(global::System.IntPtr widthMeasureSpec, global::System.IntPtr heightMeasureSpec);
        public delegate void SwigDelegateLayoutItemWrapperImpl_4(bool changed, global::System.IntPtr left, global::System.IntPtr top, global::System.IntPtr right, global::System.IntPtr bottom);
        public delegate void SwigDelegateLayoutItemWrapperImpl_5(global::System.IntPtr newSize, global::System.IntPtr oldSize);
        public delegate void SwigDelegateLayoutItemWrapperImpl_6();

        private SwigDelegateLayoutItemWrapperImpl_0 swigDelegate0;
        private SwigDelegateLayoutItemWrapperImpl_1 swigDelegate1;
        private SwigDelegateLayoutItemWrapperImpl_2 swigDelegate2;
        private SwigDelegateLayoutItemWrapperImpl_3 swigDelegate3;
        private SwigDelegateLayoutItemWrapperImpl_4 swigDelegate4;
        private SwigDelegateLayoutItemWrapperImpl_5 swigDelegate5;
        private SwigDelegateLayoutItemWrapperImpl_6 swigDelegate6;
    }
} // namespace Tizen.NUI
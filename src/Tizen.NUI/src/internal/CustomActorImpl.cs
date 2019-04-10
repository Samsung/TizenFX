/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    using Tizen.NUI.BaseComponents;

    internal class CustomActorImpl : RefObject
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal CustomActorImpl(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.CustomActorImpl.CustomActorImpl_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CustomActorImpl obj)
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
                    throw new global::System.MethodAccessException("C++ destructor does not have public access");
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        internal CustomActor Self()
        {
            CustomActor ret = new CustomActor(Interop.CustomActorImpl.CustomActorImpl_Self(swigCPtr), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual void OnStageConnection(int depth)
        {
            Interop.CustomActorImpl.CustomActorImpl_OnStageConnection(swigCPtr, depth);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public virtual void OnStageDisconnection()
        {
            Interop.CustomActorImpl.CustomActorImpl_OnStageDisconnection(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public virtual void OnChildAdd(View child)
        {
            Interop.CustomActorImpl.CustomActorImpl_OnChildAdd(swigCPtr, View.getCPtr(child));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public virtual void OnChildRemove(View child)
        {
            Interop.CustomActorImpl.CustomActorImpl_OnChildRemove(swigCPtr, View.getCPtr(child));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public virtual void OnPropertySet(int index, PropertyValue propertyValue)
        {
            Interop.CustomActorImpl.CustomActorImpl_OnPropertySet(swigCPtr, index, PropertyValue.getCPtr(propertyValue));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public virtual void OnSizeSet(Vector3 targetSize)
        {
            Interop.CustomActorImpl.CustomActorImpl_OnSizeSet(swigCPtr, Vector3.getCPtr(targetSize));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public virtual void OnSizeAnimation(Animation animation, Vector3 targetSize)
        {
            Interop.CustomActorImpl.CustomActorImpl_OnSizeAnimation(swigCPtr, Animation.getCPtr(animation), Vector3.getCPtr(targetSize));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal virtual bool OnTouchEvent(SWIGTYPE_p_Dali__TouchEvent arg0)
        {
            bool ret = Interop.CustomActorImpl.CustomActorImpl_OnTouchEvent(swigCPtr, SWIGTYPE_p_Dali__TouchEvent.getCPtr(arg0));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual bool OnHoverEvent(Hover arg0)
        {
            bool ret = Interop.CustomActorImpl.CustomActorImpl_OnHoverEvent(swigCPtr, Hover.getCPtr(arg0));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual bool OnKeyEvent(Key arg0)
        {
            bool ret = Interop.CustomActorImpl.CustomActorImpl_OnKeyEvent(swigCPtr, Key.getCPtr(arg0));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual bool OnWheelEvent(Wheel arg0)
        {
            bool ret = Interop.CustomActorImpl.CustomActorImpl_OnWheelEvent(swigCPtr, Wheel.getCPtr(arg0));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            Interop.CustomActorImpl.CustomActorImpl_OnRelayout(swigCPtr, Vector2.getCPtr(size), RelayoutContainer.getCPtr(container));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public virtual void OnSetResizePolicy(ResizePolicyType policy, DimensionType dimension)
        {
            Interop.CustomActorImpl.CustomActorImpl_OnSetResizePolicy(swigCPtr, (int)policy, (int)dimension);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public virtual Vector3 GetNaturalSize()
        {
            Vector3 ret = new Vector3(Interop.CustomActorImpl.CustomActorImpl_GetNaturalSize(swigCPtr), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual float CalculateChildSize(View child, DimensionType dimension)
        {
            float ret = Interop.CustomActorImpl.CustomActorImpl_CalculateChildSize(swigCPtr, View.getCPtr(child), (int)dimension);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual float GetHeightForWidth(float width)
        {
            float ret = Interop.CustomActorImpl.CustomActorImpl_GetHeightForWidth(swigCPtr, width);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual float GetWidthForHeight(float height)
        {
            float ret = Interop.CustomActorImpl.CustomActorImpl_GetWidthForHeight(swigCPtr, height);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual bool RelayoutDependentOnChildren(DimensionType dimension)
        {
            bool ret = Interop.CustomActorImpl.CustomActorImpl_RelayoutDependentOnChildren__SWIG_0(swigCPtr, (int)dimension);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual bool RelayoutDependentOnChildren()
        {
            bool ret = Interop.CustomActorImpl.CustomActorImpl_RelayoutDependentOnChildren__SWIG_1(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual void OnCalculateRelayoutSize(DimensionType dimension)
        {
            Interop.CustomActorImpl.CustomActorImpl_OnCalculateRelayoutSize(swigCPtr, (int)dimension);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public virtual void OnLayoutNegotiated(float size, DimensionType dimension)
        {
            Interop.CustomActorImpl.CustomActorImpl_OnLayoutNegotiated(swigCPtr, size, (int)dimension);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public bool RequiresTouchEvents()
        {
            bool ret = Interop.CustomActorImpl.CustomActorImpl_RequiresTouchEvents(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool RequiresHoverEvents()
        {
            bool ret = Interop.CustomActorImpl.CustomActorImpl_RequiresHoverEvents(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool RequiresWheelEvents()
        {
            bool ret = Interop.CustomActorImpl.CustomActorImpl_RequiresWheelEvents(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool IsRelayoutEnabled()
        {
            bool ret = Interop.CustomActorImpl.CustomActorImpl_IsRelayoutEnabled(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}

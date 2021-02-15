/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
    internal class CustomActorImpl : RefObject
    {

        internal CustomActorImpl(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CustomActorImpl obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }

        internal CustomActor Self()
        {
            CustomActor ret = new CustomActor(Interop.CustomActorImpl.Self(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual void OnSceneConnection(int depth)
        {
            Interop.CustomActorImpl.OnSceneConnection(SwigCPtr, depth);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnSceneDisconnection()
        {
            Interop.CustomActorImpl.OnSceneDisconnection(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnChildAdd(View child)
        {
            Interop.CustomActorImpl.OnChildAdd(SwigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnChildRemove(View child)
        {
            Interop.CustomActorImpl.OnChildRemove(SwigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnPropertySet(int index, PropertyValue propertyValue)
        {
            Interop.CustomActorImpl.OnPropertySet(SwigCPtr, index, PropertyValue.getCPtr(propertyValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnSizeSet(Vector3 targetSize)
        {
            Interop.CustomActorImpl.OnSizeSet(SwigCPtr, Vector3.getCPtr(targetSize));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnSizeAnimation(Animation animation, Vector3 targetSize)
        {
            Interop.CustomActorImpl.OnSizeAnimation(SwigCPtr, Animation.getCPtr(animation), Vector3.getCPtr(targetSize));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual bool OnKeyEvent(Key arg0)
        {
            bool ret = Interop.CustomActorImpl.OnKeyEvent(SwigCPtr, Key.getCPtr(arg0));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            Interop.CustomActorImpl.OnRelayout(SwigCPtr, Vector2.getCPtr(size), RelayoutContainer.getCPtr(container));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnSetResizePolicy(ResizePolicyType policy, DimensionType dimension)
        {
            Interop.CustomActorImpl.OnSetResizePolicy(SwigCPtr, (int)policy, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual Vector3 GetNaturalSize()
        {
            Vector3 ret = new Vector3(Interop.CustomActorImpl.GetNaturalSize(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual float CalculateChildSize(View child, DimensionType dimension)
        {
            float ret = Interop.CustomActorImpl.CalculateChildSize(SwigCPtr, View.getCPtr(child), (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual float GetHeightForWidth(float width)
        {
            float ret = Interop.CustomActorImpl.GetHeightForWidth(SwigCPtr, width);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual float GetWidthForHeight(float height)
        {
            float ret = Interop.CustomActorImpl.GetWidthForHeight(SwigCPtr, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual bool RelayoutDependentOnChildren(DimensionType dimension)
        {
            bool ret = Interop.CustomActorImpl.RelayoutDependentOnChildren(SwigCPtr, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual bool RelayoutDependentOnChildren()
        {
            bool ret = Interop.CustomActorImpl.RelayoutDependentOnChildren(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual void OnCalculateRelayoutSize(DimensionType dimension)
        {
            Interop.CustomActorImpl.OnCalculateRelayoutSize(SwigCPtr, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnLayoutNegotiated(float size, DimensionType dimension)
        {
            Interop.CustomActorImpl.OnLayoutNegotiated(SwigCPtr, size, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool RequiresTouchEvents()
        {
            bool ret = Interop.CustomActorImpl.RequiresTouchEvents(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool RequiresHoverEvents()
        {
            bool ret = Interop.CustomActorImpl.RequiresHoverEvents(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool RequiresWheelEvents()
        {
            bool ret = Interop.CustomActorImpl.RequiresWheelEvents(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool IsRelayoutEnabled()
        {
            bool ret = Interop.CustomActorImpl.IsRelayoutEnabled(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}

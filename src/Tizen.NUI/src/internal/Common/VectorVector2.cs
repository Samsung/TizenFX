/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
    internal class VectorVector2 : Disposable
    {
        internal VectorVector2(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.VectorVector2.DeleteVectorVector2(swigCPtr);
        }

        public VectorVector2() : this(Interop.VectorVector2.NewVectorVector2(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public VectorVector2(VectorVector2 vector) : this(Interop.VectorVector2.NewVectorVector2(VectorVector2.getCPtr(vector)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public VectorVector2 Assign(VectorVector2 vector)
        {
            VectorVector2 ret = new VectorVector2(Interop.VectorVector2.Assign(SwigCPtr, VectorVector2.getCPtr(vector)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector2 Begin()
        {
            global::System.IntPtr cPtr = Interop.VectorVector2.Begin(SwigCPtr);
            Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector2 End()
        {
            global::System.IntPtr cPtr = Interop.VectorVector2.End(SwigCPtr);
            Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector2 ValueOfIndex(uint index)
        {
            Vector2 ret = new Vector2(Interop.VectorVector2.ValueOfIndex(SwigCPtr, index), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void PushBack(Vector2 element)
        {
            Interop.VectorVector2.PushBack(SwigCPtr, Vector2.getCPtr(element));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Insert(Vector2 at, Vector2 element)
        {
            Interop.VectorVector2.Insert(SwigCPtr, Vector2.getCPtr(at), Vector2.getCPtr(element));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Insert(Vector2 at, Vector2 from, Vector2 to)
        {
            Interop.VectorVector2.Insert(SwigCPtr, Vector2.getCPtr(at), Vector2.getCPtr(from), Vector2.getCPtr(to));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Reserve(uint count)
        {
            Interop.VectorVector2.Reserve(SwigCPtr, count);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Resize(uint count)
        {
            Interop.VectorVector2.Resize(SwigCPtr, count);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Resize(uint count, Vector2 item)
        {
            Interop.VectorVector2.Resize(SwigCPtr, count, Vector2.getCPtr(item));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector2 Erase(Vector2 iterator)
        {
            global::System.IntPtr cPtr = Interop.VectorVector2.Erase(SwigCPtr, Vector2.getCPtr(iterator));
            Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector2 Erase(Vector2 first, Vector2 last)
        {
            global::System.IntPtr cPtr = Interop.VectorVector2.Erase(SwigCPtr, Vector2.getCPtr(first), Vector2.getCPtr(last));
            Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Remove(Vector2 iterator)
        {
            Interop.VectorVector2.Remove(SwigCPtr, Vector2.getCPtr(iterator));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Swap(VectorVector2 vector)
        {
            Interop.VectorVector2.Swap(SwigCPtr, VectorVector2.getCPtr(vector));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Clear()
        {
            Interop.VectorVector2.Clear(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Release()
        {
            Interop.VectorVector2.Release(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public int Size()
        {
            int size = Interop.VectorVector2.Size(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return size;
        }

        public static readonly int BaseType = Interop.VectorVector2.BaseTypeGet();
    }
}

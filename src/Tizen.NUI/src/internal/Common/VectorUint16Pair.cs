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
    internal class VectorUint16Pair : Disposable
    {
        internal VectorUint16Pair(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(VectorUint16Pair obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.VectorUint16Pair.DeleteVectorUint16Pair(swigCPtr);
        }

        public VectorUint16Pair() : this(Interop.VectorUint16Pair.NewVectorUint16Pair(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public VectorUint16Pair(VectorUint16Pair vector) : this(Interop.VectorUint16Pair.NewVectorUint16Pair(VectorUint16Pair.getCPtr(vector)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public VectorUint16Pair Assign(VectorUint16Pair vector)
        {
            VectorUint16Pair ret = new VectorUint16Pair(Interop.VectorUint16Pair.Assign(SwigCPtr, VectorUint16Pair.getCPtr(vector)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Uint16Pair Begin()
        {
            global::System.IntPtr cPtr = Interop.VectorUint16Pair.Begin(SwigCPtr);
            Uint16Pair ret = (cPtr == global::System.IntPtr.Zero) ? null : new Uint16Pair(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Uint16Pair End()
        {
            global::System.IntPtr cPtr = Interop.VectorUint16Pair.End(SwigCPtr);
            Uint16Pair ret = (cPtr == global::System.IntPtr.Zero) ? null : new Uint16Pair(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Uint16Pair ValueOfIndex(uint index)
        {
            Uint16Pair ret = new Uint16Pair(Interop.VectorUint16Pair.ValueOfIndex(SwigCPtr, index), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void PushBack(Uint16Pair element)
        {
            Interop.VectorUint16Pair.PushBack(SwigCPtr, Uint16Pair.getCPtr(element));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Insert(Uint16Pair at, Uint16Pair element)
        {
            Interop.VectorUint16Pair.Insert(SwigCPtr, Uint16Pair.getCPtr(at), Uint16Pair.getCPtr(element));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Insert(Uint16Pair at, Uint16Pair from, Uint16Pair to)
        {
            Interop.VectorUint16Pair.Insert(SwigCPtr, Uint16Pair.getCPtr(at), Uint16Pair.getCPtr(from), Uint16Pair.getCPtr(to));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Reserve(uint count)
        {
            Interop.VectorUint16Pair.Reserve(SwigCPtr, count);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Resize(uint count)
        {
            Interop.VectorUint16Pair.Resize(SwigCPtr, count);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Resize(uint count, Uint16Pair item)
        {
            Interop.VectorUint16Pair.Resize(SwigCPtr, count, Uint16Pair.getCPtr(item));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Uint16Pair Erase(Uint16Pair iterator)
        {
            global::System.IntPtr cPtr = Interop.VectorUint16Pair.Erase(SwigCPtr, Uint16Pair.getCPtr(iterator));
            Uint16Pair ret = (cPtr == global::System.IntPtr.Zero) ? null : new Uint16Pair(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Uint16Pair Erase(Uint16Pair first, Uint16Pair last)
        {
            global::System.IntPtr cPtr = Interop.VectorUint16Pair.Erase(SwigCPtr, Uint16Pair.getCPtr(first), Uint16Pair.getCPtr(last));
            Uint16Pair ret = (cPtr == global::System.IntPtr.Zero) ? null : new Uint16Pair(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Remove(Uint16Pair iterator)
        {
            Interop.VectorUint16Pair.Remove(SwigCPtr, Uint16Pair.getCPtr(iterator));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Swap(VectorUint16Pair vector)
        {
            Interop.VectorUint16Pair.Swap(SwigCPtr, VectorUint16Pair.getCPtr(vector));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Clear()
        {
            Interop.VectorUint16Pair.Clear(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Release()
        {
            Interop.VectorUint16Pair.Release(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static readonly int BaseType = Interop.VectorUint16Pair.BaseTypeGet();
    }
}

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

namespace Tizen.NUI
{
    internal class VectorUint16Pair : Disposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal VectorUint16Pair(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(VectorUint16Pair obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.VectorUint16Pair.delete_VectorUint16Pair(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        public VectorUint16Pair() : this(Interop.VectorUint16Pair.new_VectorUint16Pair__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public VectorUint16Pair(VectorUint16Pair vector) : this(Interop.VectorUint16Pair.new_VectorUint16Pair__SWIG_1(VectorUint16Pair.getCPtr(vector)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public VectorUint16Pair Assign(VectorUint16Pair vector)
        {
            VectorUint16Pair ret = new VectorUint16Pair(Interop.VectorUint16Pair.VectorUint16Pair_Assign(swigCPtr, VectorUint16Pair.getCPtr(vector)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Uint16Pair Begin()
        {
            global::System.IntPtr cPtr = Interop.VectorUint16Pair.VectorUint16Pair_Begin(swigCPtr);
            Uint16Pair ret = (cPtr == global::System.IntPtr.Zero) ? null : new Uint16Pair(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Uint16Pair End()
        {
            global::System.IntPtr cPtr = Interop.VectorUint16Pair.VectorUint16Pair_End(swigCPtr);
            Uint16Pair ret = (cPtr == global::System.IntPtr.Zero) ? null : new Uint16Pair(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Uint16Pair ValueOfIndex(uint index)
        {
            Uint16Pair ret = new Uint16Pair(Interop.VectorUint16Pair.VectorUint16Pair_ValueOfIndex__SWIG_0(swigCPtr, index), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void PushBack(Uint16Pair element)
        {
            Interop.VectorUint16Pair.VectorUint16Pair_PushBack(swigCPtr, Uint16Pair.getCPtr(element));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Insert(Uint16Pair at, Uint16Pair element)
        {
            Interop.VectorUint16Pair.VectorUint16Pair_Insert__SWIG_0(swigCPtr, Uint16Pair.getCPtr(at), Uint16Pair.getCPtr(element));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Insert(Uint16Pair at, Uint16Pair from, Uint16Pair to)
        {
            Interop.VectorUint16Pair.VectorUint16Pair_Insert__SWIG_1(swigCPtr, Uint16Pair.getCPtr(at), Uint16Pair.getCPtr(from), Uint16Pair.getCPtr(to));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Reserve(uint count)
        {
            Interop.VectorUint16Pair.VectorUint16Pair_Reserve(swigCPtr, count);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Resize(uint count)
        {
            Interop.VectorUint16Pair.VectorUint16Pair_Resize__SWIG_0(swigCPtr, count);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Resize(uint count, Uint16Pair item)
        {
            Interop.VectorUint16Pair.VectorUint16Pair_Resize__SWIG_1(swigCPtr, count, Uint16Pair.getCPtr(item));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Uint16Pair Erase(Uint16Pair iterator)
        {
            global::System.IntPtr cPtr = Interop.VectorUint16Pair.VectorUint16Pair_Erase__SWIG_0(swigCPtr, Uint16Pair.getCPtr(iterator));
            Uint16Pair ret = (cPtr == global::System.IntPtr.Zero) ? null : new Uint16Pair(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Uint16Pair Erase(Uint16Pair first, Uint16Pair last)
        {
            global::System.IntPtr cPtr = Interop.VectorUint16Pair.VectorUint16Pair_Erase__SWIG_1(swigCPtr, Uint16Pair.getCPtr(first), Uint16Pair.getCPtr(last));
            Uint16Pair ret = (cPtr == global::System.IntPtr.Zero) ? null : new Uint16Pair(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Remove(Uint16Pair iterator)
        {
            Interop.VectorUint16Pair.VectorUint16Pair_Remove(swigCPtr, Uint16Pair.getCPtr(iterator));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Swap(VectorUint16Pair vector)
        {
            Interop.VectorUint16Pair.VectorUint16Pair_Swap(swigCPtr, VectorUint16Pair.getCPtr(vector));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Clear()
        {
            Interop.VectorUint16Pair.VectorUint16Pair_Clear(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Release()
        {
            Interop.VectorUint16Pair.VectorUint16Pair_Release(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static readonly int BaseType = Interop.VectorUint16Pair.VectorUint16Pair_BaseType_get();
    }
}

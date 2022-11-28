/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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

using System.Collections.Generic;

namespace Tizen.NUI
{
    internal class VectorUnsignedInteger : Disposable
    {
        internal VectorUnsignedInteger(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.VectorUnsignedInteger.DeleteVectorUnsignedInteger(swigCPtr);
        }

        public VectorUnsignedInteger() : this(Interop.VectorUnsignedInteger.NewVectorUnsignedInteger(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public VectorUnsignedInteger(VectorUnsignedInteger vector) : this(Interop.VectorUnsignedInteger.NewVectorUnsignedInteger(VectorUnsignedInteger.getCPtr(vector)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public VectorUnsignedInteger Assign(VectorUnsignedInteger vector)
        {
            VectorUnsignedInteger ret = new VectorUnsignedInteger(Interop.VectorUnsignedInteger.Assign(SwigCPtr, VectorUnsignedInteger.getCPtr(vector)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_unsigned_int Begin()
        {
            global::System.IntPtr cPtr = Interop.VectorUnsignedInteger.Begin(SwigCPtr);
            SWIGTYPE_p_unsigned_int ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_unsigned_int(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_unsigned_int End()
        {
            global::System.IntPtr cPtr = Interop.VectorUnsignedInteger.End(SwigCPtr);
            SWIGTYPE_p_unsigned_int ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_unsigned_int(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_unsigned_int ValueOfIndex(uint index)
        {
            SWIGTYPE_p_unsigned_int ret = new SWIGTYPE_p_unsigned_int(Interop.VectorUnsignedInteger.ValueOfIndex(SwigCPtr, index));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void PushBack(byte element)
        {
            Interop.VectorUnsignedInteger.PushBack(SwigCPtr, element);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Insert(byte[] at, byte element)
        {
            Interop.VectorUnsignedInteger.Insert(SwigCPtr, at, element);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void Insert(byte[] at, SWIGTYPE_p_unsigned_int from, SWIGTYPE_p_unsigned_int to)
        {
            Interop.VectorUnsignedInteger.Insert(SwigCPtr, at, SWIGTYPE_p_unsigned_int.getCPtr(from), SWIGTYPE_p_unsigned_int.getCPtr(to));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Reserve(uint count)
        {
            Interop.VectorUnsignedInteger.Reserve(SwigCPtr, count);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Resize(uint count)
        {
            Interop.VectorUnsignedInteger.Resize(SwigCPtr, count);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Resize(uint count, byte item)
        {
            Interop.VectorUnsignedInteger.Resize(SwigCPtr, count, item);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal SWIGTYPE_p_unsigned_int Erase(byte[] iterator)
        {
            global::System.IntPtr cPtr = Interop.VectorUnsignedInteger.Erase(SwigCPtr, iterator);
            SWIGTYPE_p_unsigned_int ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_unsigned_int(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_unsigned_int Erase(byte[] first, SWIGTYPE_p_unsigned_int last)
        {
            global::System.IntPtr cPtr = Interop.VectorUnsignedInteger.Erase(SwigCPtr, first, SWIGTYPE_p_unsigned_int.getCPtr(last));
            SWIGTYPE_p_unsigned_int ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_unsigned_int(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Remove(byte[] iterator)
        {
            Interop.VectorUnsignedInteger.Remove(SwigCPtr, iterator);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Swap(VectorUnsignedInteger vector)
        {
            Interop.VectorUnsignedInteger.Swap(SwigCPtr, VectorUnsignedInteger.getCPtr(vector));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Clear()
        {
            Interop.VectorUnsignedInteger.Clear(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Release()
        {
            Interop.VectorUnsignedInteger.Release(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public int Size()
        {
            int size = Interop.VectorUnsignedInteger.Size(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return size;
        }

        public List<uint> GetListFromNativeVector( )
        {
            int count = this.Size();
            List<uint> list = new List<uint>();

            for(int i = 0; i < count; i++)
                list.Add( uintp.frompointer(this.ValueOfIndex( (uint)i )).value());

            return list;
        }

        public static readonly int BaseType = Interop.VectorUnsignedInteger.BaseTypeGet();
    }
}

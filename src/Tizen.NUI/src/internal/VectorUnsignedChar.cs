/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
    internal class VectorUnsignedChar : Disposable
    {

        internal VectorUnsignedChar(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(VectorUnsignedChar obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.VectorUnsignedChar.DeleteVectorUnsignedChar(swigCPtr);
        }

        public VectorUnsignedChar() : this(Interop.VectorUnsignedChar.NewVectorUnsignedChar(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public VectorUnsignedChar(VectorUnsignedChar vector) : this(Interop.VectorUnsignedChar.NewVectorUnsignedChar(VectorUnsignedChar.getCPtr(vector)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public VectorUnsignedChar Assign(VectorUnsignedChar vector)
        {
            VectorUnsignedChar ret = new VectorUnsignedChar(Interop.VectorUnsignedChar.Assign(swigCPtr, VectorUnsignedChar.getCPtr(vector)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_unsigned_char Begin()
        {
            global::System.IntPtr cPtr = Interop.VectorUnsignedChar.Begin(swigCPtr);
            SWIGTYPE_p_unsigned_char ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_unsigned_char(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_unsigned_char End()
        {
            global::System.IntPtr cPtr = Interop.VectorUnsignedChar.End(swigCPtr);
            SWIGTYPE_p_unsigned_char ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_unsigned_char(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_unsigned_char ValueOfIndex(uint index)
        {
            SWIGTYPE_p_unsigned_char ret = new SWIGTYPE_p_unsigned_char(Interop.VectorUnsignedChar.ValueOfIndex(swigCPtr, index));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void PushBack(byte element)
        {
            Interop.VectorUnsignedChar.PushBack(swigCPtr, element);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Insert(byte[] at, byte element)
        {
            Interop.VectorUnsignedChar.Insert(swigCPtr, at, element);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void Insert(byte[] at, SWIGTYPE_p_unsigned_char from, SWIGTYPE_p_unsigned_char to)
        {
            Interop.VectorUnsignedChar.Insert(swigCPtr, at, SWIGTYPE_p_unsigned_char.getCPtr(from), SWIGTYPE_p_unsigned_char.getCPtr(to));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Reserve(uint count)
        {
            Interop.VectorUnsignedChar.Reserve(swigCPtr, count);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Resize(uint count)
        {
            Interop.VectorUnsignedChar.Resize(swigCPtr, count);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Resize(uint count, byte item)
        {
            Interop.VectorUnsignedChar.Resize(swigCPtr, count, item);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal SWIGTYPE_p_unsigned_char Erase(byte[] iterator)
        {
            global::System.IntPtr cPtr = Interop.VectorUnsignedChar.Erase(swigCPtr, iterator);
            SWIGTYPE_p_unsigned_char ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_unsigned_char(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_unsigned_char Erase(byte[] first, SWIGTYPE_p_unsigned_char last)
        {
            global::System.IntPtr cPtr = Interop.VectorUnsignedChar.Erase(swigCPtr, first, SWIGTYPE_p_unsigned_char.getCPtr(last));
            SWIGTYPE_p_unsigned_char ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_unsigned_char(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Remove(byte[] iterator)
        {
            Interop.VectorUnsignedChar.Remove(swigCPtr, iterator);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Swap(VectorUnsignedChar vector)
        {
            Interop.VectorUnsignedChar.Swap(swigCPtr, VectorUnsignedChar.getCPtr(vector));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Clear()
        {
            Interop.VectorUnsignedChar.Clear(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Release()
        {
            Interop.VectorUnsignedChar.Release(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static readonly int BaseType = Interop.VectorUnsignedChar.BaseTypeGet();
    }
}

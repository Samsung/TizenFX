/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{

    [Obsolete("Please do not use! this will be deprecated")]
    public class Uint16Pair : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal Uint16Pair(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Uint16Pair obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;


        ~Uint16Pair()
        {
            if (!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        public void Dispose()
        {
            //Throw excpetion if Dispose() is called in separate thread.
            if (!Window.IsInstalled())
            {
                throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
            }

            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                System.GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(DisposeTypes type)
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
                    NDalicPINVOKE.delete_Uint16Pair(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            disposed = true;
        }


        public static bool operator <(Uint16Pair arg1, Uint16Pair arg2)
        {
            return arg1.LessThan(arg2);
        }

        public static bool operator >(Uint16Pair arg1, Uint16Pair arg2)
        {
            return arg1.GreaterThan(arg2);
        }

        public Uint16Pair() : this(NDalicPINVOKE.new_Uint16Pair__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Uint16Pair(uint width, uint height) : this(NDalicPINVOKE.new_Uint16Pair__SWIG_1(width, height), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Uint16Pair(Uint16Pair rhs) : this(NDalicPINVOKE.new_Uint16Pair__SWIG_2(Uint16Pair.getCPtr(rhs)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetWidth(ushort width)
        {
            NDalicPINVOKE.Uint16Pair_SetWidth(swigCPtr, width);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ushort GetWidth()
        {
            ushort ret = NDalicPINVOKE.Uint16Pair_GetWidth(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetHeight(ushort height)
        {
            NDalicPINVOKE.Uint16Pair_SetHeight(swigCPtr, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ushort GetHeight()
        {
            ushort ret = NDalicPINVOKE.Uint16Pair_GetHeight(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetX(ushort x)
        {
            NDalicPINVOKE.Uint16Pair_SetX(swigCPtr, x);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ushort GetX()
        {
            ushort ret = NDalicPINVOKE.Uint16Pair_GetX(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetY(ushort y)
        {
            NDalicPINVOKE.Uint16Pair_SetY(swigCPtr, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ushort GetY()
        {
            ushort ret = NDalicPINVOKE.Uint16Pair_GetY(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Uint16Pair Assign(Uint16Pair rhs)
        {
            Uint16Pair ret = new Uint16Pair(NDalicPINVOKE.Uint16Pair_Assign(swigCPtr, Uint16Pair.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool EqualTo(Uint16Pair rhs)
        {
            bool ret = NDalicPINVOKE.Uint16Pair_EqualTo(swigCPtr, Uint16Pair.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool NotEqualTo(Uint16Pair rhs)
        {
            bool ret = NDalicPINVOKE.Uint16Pair_NotEqualTo(swigCPtr, Uint16Pair.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool LessThan(Uint16Pair rhs)
        {
            bool ret = NDalicPINVOKE.Uint16Pair_LessThan(swigCPtr, Uint16Pair.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool GreaterThan(Uint16Pair rhs)
        {
            bool ret = NDalicPINVOKE.Uint16Pair_GreaterThan(swigCPtr, Uint16Pair.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}

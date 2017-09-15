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

namespace Tizen.NUI
{

    public class BaseHandle : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;
        private bool _registerMe;

        internal BaseHandle(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            //to catch derived classes dali native exceptions
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            _registerMe = swigCMemOwn = cMemoryOwn;

            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);

            // using copy constructor to create another native handle so Registry.Unregister works fine.
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, NDalicPINVOKE.new_BaseHandle__SWIG_2(swigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if (_registerMe)
            {
                // Register this instance of BaseHandle in the registry.
                Registry.Register(this);
            }
        }

        internal BaseHandle(global::System.IntPtr cPtr)
        {
            _registerMe = swigCMemOwn = true;

            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);

            // using copy constructor to create another native handle so Registry.Unregister works fine.
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, NDalicPINVOKE.new_BaseHandle__SWIG_2(swigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if (_registerMe)
            {
                // Register this instance of BaseHandle in the registry.
                Registry.Register(this);
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(BaseHandle obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;

        ~BaseHandle()
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

            //Unreference this instance from Registry.
            if (_registerMe)
            {
                Registry.Unregister(this);
            }

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                swigCMemOwn = false;
                NDalicPINVOKE.delete_BaseHandle(swigCPtr);
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            disposed = true;
        }



        // Returns the bool value true to indicate that an operand is true and returns false otherwise.
        public static bool operator true(BaseHandle handle)
        {
            // if the C# object is null, return false
            if (BaseHandle.ReferenceEquals(handle, null))
            {
                return false;
            }
            // returns true if the handle has a body, false otherwise
            return handle.HasBody();
        }

        // Returns the bool false  to indicate that an operand is false and returns true otherwise.
        public static bool operator false(BaseHandle handle)
        {
            // if the C# object is null, return true
            if (BaseHandle.ReferenceEquals(handle, null))
            {
                return true;
            }
            return !handle.HasBody();
        }

        // Explicit conversion from Handle to bool.
        public static explicit operator bool(BaseHandle handle)
        {
            // if the C# object is null, return false
            if (BaseHandle.ReferenceEquals(handle, null))
            {
                return false;
            }
            // returns true if the handle has a body, false otherwise
            return handle.HasBody();
        }

        // Equality operator
        public static bool operator ==(BaseHandle x, BaseHandle y)
        {
            // if the C# objects are the same return true
            if (BaseHandle.ReferenceEquals(x, y))
            {
                return true;
            }
            if (!BaseHandle.ReferenceEquals(x, null) && !BaseHandle.ReferenceEquals(y, null))
            {
                // drop into native code to see if both handles point to the same body
                return x.IsEqual(y);
            }

            if (BaseHandle.ReferenceEquals(x, null) && !BaseHandle.ReferenceEquals(y, null))
            {
                if (y.HasBody()) return false;
                else return true;
            }
            if (!BaseHandle.ReferenceEquals(x, null) && BaseHandle.ReferenceEquals(y, null))
            {
                if (x.HasBody()) return false;
                else return true;
            }

            return false;
        }

        // Inequality operator. Returns Null if either operand is Null
        public static bool operator !=(BaseHandle x, BaseHandle y)
        {
            return !(x == y);
        }

        // Logical AND operator for &&
        // It's possible when doing a && this function (opBitwiseAnd) is never called due
        // to short circuiting. E.g.
        // If you perform x && y What actually is called is
        // BaseHandle.op_False( x ) ? BaseHandle.op_True( x ) : BaseHandle.opTrue( BaseHandle.opBitwiseAnd(x,y) )
        //
        public static BaseHandle operator &(BaseHandle x, BaseHandle y)
        {
            if (x == y)
            {
                return x;
            }
            return null;
        }

        // Logical OR operator for ||
        // It's possible when doing a || this function (opBitwiseOr) is never called due
        // to short circuiting. E.g.
        // If you perform x || y What actually is called is
        // BaseHandle.op_True( x ) ? BaseHandle.op_True( x ) : BaseHandle.opTrue( BaseHandle.opBitwiseOr(x,y) )
        public static BaseHandle operator |(BaseHandle x, BaseHandle y)
        {
            if (!BaseHandle.ReferenceEquals(x, null) || !BaseHandle.ReferenceEquals(y, null))
            {
                if (x.HasBody())
                {
                    return x;
                }
                if (y.HasBody())
                {
                    return y;
                }
                return null;
            }
            return null;
        }

        // Logical ! operator
        public static bool operator !(BaseHandle x)
        {
            // if the C# object is null, return true
            if (BaseHandle.ReferenceEquals(x, null))
            {
                return true;
            }
            if (x.HasBody())
            {
                return false;
            }
            return true;
        }

        public override bool Equals(object o)
        {
            if(o == null)
            {
                return false;
            }
            if(!(o is BaseHandle))
            {
                return false;
            }
            BaseHandle b = (BaseHandle)o;
            if (!BaseHandle.ReferenceEquals(this, null) && !BaseHandle.ReferenceEquals(b, null))
            {
                // drop into native code to see if both handles point to the same body
                return this.IsEqual(b);
            }

            if (BaseHandle.ReferenceEquals(this, null) && !BaseHandle.ReferenceEquals(b, null))
            {
                if (b.HasBody()) return false;
                else return true;
            }
            if (!BaseHandle.ReferenceEquals(this, null) && BaseHandle.ReferenceEquals(b, null))
            {
                if (this.HasBody()) return false;
                else return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public BaseHandle() : this(NDalicPINVOKE.new_BaseHandle__SWIG_1())
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public BaseHandle(BaseHandle handle) : this(NDalicPINVOKE.new_BaseHandle__SWIG_2(BaseHandle.getCPtr(handle)))
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        public bool DoAction(string actionName, PropertyMap attributes)
        {
            bool ret = NDalicPINVOKE.BaseHandle_DoAction(swigCPtr, actionName, PropertyMap.getCPtr(attributes));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public string GetTypeName()
        {
            string ret = NDalicPINVOKE.BaseHandle_GetTypeName(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool GetTypeInfo(TypeInfo info)
        {
            bool ret = NDalicPINVOKE.BaseHandle_GetTypeInfo(swigCPtr, TypeInfo.getCPtr(info));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        public void Reset()
        {
            NDalicPINVOKE.BaseHandle_Reset(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool EqualTo(BaseHandle rhs)
        {
            bool ret = NDalicPINVOKE.BaseHandle_EqualTo(swigCPtr, BaseHandle.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool NotEqualTo(BaseHandle rhs)
        {
            bool ret = NDalicPINVOKE.BaseHandle_NotEqualTo(swigCPtr, BaseHandle.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal RefObject GetObjectPtr()
        {
            global::System.IntPtr cPtr = NDalicPINVOKE.BaseHandle_GetObjectPtr(swigCPtr);
            RefObject ret = (cPtr == global::System.IntPtr.Zero) ? null : new RefObject(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool HasBody()
        {
            if (disposed == true)
            {
                return false;
            }

            bool ret = NDalicPINVOKE.BaseHandle_HasBody(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool IsEqual(BaseHandle rhs)
        {
            if (disposed == true)
            {
                return false;
            }

            bool ret = NDalicPINVOKE.BaseHandle_IsEqual(swigCPtr, BaseHandle.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal global::System.Runtime.InteropServices.HandleRef GetBaseHandleCPtrHandleRef
        {
            get
            {
                return swigCPtr;
            }
        }

    }

}


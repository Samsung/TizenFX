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
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI
{

    /// <summary>
    /// BaseHandle is a handle to an internal Dali resource.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BaseHandle : Element, global::System.IDisposable
    {
        /// <summary>
        /// swigCMemOwn
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected bool swigCMemOwn;

        /// <summary>
        /// A flag to check if it is already disposed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected bool disposed = false;
        /// <summary>
        /// swigCPtr.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private global::System.Runtime.InteropServices.HandleRef swigCPtrCopy;
        private bool _registerMe;
        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;

        /// <summary>
        /// Create an instance of BaseHandle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BaseHandle() : this(Interop.BaseHandle.new_BaseHandle__SWIG_1())
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an instance of BaseHandle.
        /// </summary>
        /// <param name="handle">The BaseHandle instance.</param>
        /// <since_tizen> 3 </since_tizen>
        public BaseHandle(BaseHandle handle) : this(Interop.BaseHandle.new_BaseHandle__SWIG_2(BaseHandle.getCPtr(handle)))
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal BaseHandle(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            //to catch derived classes dali native exceptions
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            _registerMe = swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            // using copy constructor to create another native handle so Registry.Unregister works fine.
            swigCPtrCopy = new global::System.Runtime.InteropServices.HandleRef(this, Interop.BaseHandle.new_BaseHandle__SWIG_2(swigCPtr));
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
            swigCPtrCopy = new global::System.Runtime.InteropServices.HandleRef(this, Interop.BaseHandle.new_BaseHandle__SWIG_2(swigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if (_registerMe)
            {
                // Register this instance of BaseHandle in the registry.
                Registry.Register(this);
            }
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ~BaseHandle()
        {
            if (!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        /// <summary>
        /// Event when a property is set.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event PropertyChangedEventHandler PropertySet;

        internal global::System.Runtime.InteropServices.HandleRef GetBaseHandleCPtrHandleRef
        {
            get
            {
                return swigCPtrCopy;
            }
        }

        /// <summary>
        /// Returns the bool value true to indicate that an operand is true and returns false otherwise.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Returns the bool false  to indicate that an operand is false and returns true otherwise.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator false(BaseHandle handle)
        {
            // if the C# object is null, return true
            if (BaseHandle.ReferenceEquals(handle, null))
            {
                return true;
            }
            return !handle.HasBody();
        }

        /// <summary>
        /// Explicit conversion from Handle to bool.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Inequality operator. Returns Null if either operand is Null
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator !=(BaseHandle x, BaseHandle y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Logical AND operator.<br />
        /// It's possible when doing a  operator this function (opBitwiseAnd) is never called due to short circuiting.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static BaseHandle operator &(BaseHandle x, BaseHandle y)
        {
            if (x == y)
            {
                return x;
            }
            return null;
        }

        /// <summary>
        /// Logical OR operator for ||.<br />
        /// It's possible when doing a || this function (opBitwiseOr) is never called due to short circuiting.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static BaseHandle operator |(BaseHandle x, BaseHandle y)
        {
            if (!BaseHandle.ReferenceEquals(x, null) || !BaseHandle.ReferenceEquals(y, null))
            {
                if (x != null && x.HasBody())
                {
                    return x;
                }
                if (y != null && y.HasBody())
                {
                    return y;
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// Logical ! operator
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="o">The object should be compared.</param>
        /// <returns>True if equal.</returns>
        /// <since_tizen> 5 </since_tizen>
        public override bool Equals(object o)
        {
            return base.Equals(o);
        }

        /// <summary>
        /// Gets the the hash code of this baseHandle.
        /// </summary>
        /// <returns>The hash code.</returns>
        /// <since_tizen> 5 </since_tizen>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Performs an action on this object with the given action name and attributes.
        /// </summary>
        /// <param name="actionName">The command for the action.</param>
        /// <param name="attributes">The list of attributes for the action.</param>
        /// <returns>The action is performed by the object or not.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool DoAction(string actionName, PropertyMap attributes)
        {
            bool ret = Interop.BaseHandle.BaseHandle_DoAction(swigCPtrCopy, actionName, PropertyMap.getCPtr(attributes));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the type name for the Handle.<br />
        /// Will return an empty string if the typename does not exist. This will happen for types that
        /// have not registered with type-registry.
        /// </summary>
        /// <returns>The type name. Empty string if the typename does not exist.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetTypeName()
        {
            string ret = Interop.BaseHandle.BaseHandle_GetTypeName(swigCPtrCopy);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the type info for the Handle.<br />
        /// </summary>
        /// <param name="info">The type information.</param>
        /// <returns>True If get the type info.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool GetTypeInfo(Tizen.NUI.TypeInfo info)
        {
            bool ret = Interop.BaseHandle.BaseHandle_GetTypeInfo(swigCPtrCopy, Tizen.NUI.TypeInfo.getCPtr(info));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Resets the handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Reset()
        {
            Interop.BaseHandle.BaseHandle_Reset(swigCPtrCopy);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// To check the BaseHandle instance is equal or not.
        /// </summary>
        /// <param name="rhs">The baseHandle instance.</param>
        /// <returns>True If equal.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(BaseHandle rhs)
        {
            bool ret = Interop.BaseHandle.BaseHandle_EqualTo(swigCPtrCopy, BaseHandle.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// To check the BaseHandle instance is equal or not.
        /// </summary>
        /// <param name="rhs">The baseHandle instance.</param>
        /// <returns>True If not equal.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool NotEqualTo(BaseHandle rhs)
        {
            bool ret = Interop.BaseHandle.BaseHandle_NotEqualTo(swigCPtrCopy, BaseHandle.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// To check the BaseHandle instance has body or not.
        /// </summary>
        /// <returns>True If the baseHandle instance has body.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool HasBody()
        {
            if (swigCPtrCopy.Handle == IntPtr.Zero)
            {
                return false;
            }

            if (disposed == true)
            {
                return false;
            }
            bool ret = Interop.BaseHandle.BaseHandle_HasBody(swigCPtrCopy);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// To check the BaseHandle instance is equal or not.
        /// </summary>
        /// <param name="rhs">The baseHandle instance.</param>
        /// <returns>True If equal.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsEqual(BaseHandle rhs)
        {
            if (disposed == true)
            {
                return false;
            }

            bool ret = Interop.BaseHandle.BaseHandle_IsEqual(swigCPtrCopy, BaseHandle.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(BaseHandle obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtrCopy;
        }

        internal void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertySet?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

            if(swigCPtr.Handle != IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    ReleaseSwigCPtr(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            if (swigCPtrCopy.Handle != global::System.IntPtr.Zero)
            {
                swigCMemOwn = false;
                Interop.BaseHandle.delete_BaseHandle(swigCPtrCopy);
                swigCPtrCopy = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            disposed = true;
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
        }

        /// <summary>
        /// Contains event arguments for the FocusChangeRequested event.
        /// </summary>
        public class FocusRequestArgs : EventArgs
        {

            /// <summary>
            /// Gets or sets a value that indicates the starting focus state of the element for which a focus change is requested.
            /// </summary>
            public bool Focus { get; set; }

            /// <summary>
            /// Gets or sets a value that indicates the ending focus state of the element for which a focus change is requested.
            /// </summary>
            public bool Result { get; set; }
        }

        internal global::System.Runtime.InteropServices.HandleRef SwigCPtr
        {
            get => swigCPtr;
        }

        /// <summary>
        /// A flag to check if it is already disposed.
        /// </summary>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal bool Disposed => disposed;
    }

}

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
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tizen.NUI.Binding;
using global::System.Diagnostics;

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
        [Obsolete("Deprecated in API9, will be removed in API11, Use SwigCMemOwn")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "<Pending>")]
        protected bool swigCMemOwn;

        /// <summary>
        /// The flag to check if it is already disposed of.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API9, will be removed in API11, Use Disposed")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "<Pending>")]
        protected bool disposed = false;

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private bool registerMe;

        //The flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;

        /// <summary>
        /// Create an instance of BaseHandle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BaseHandle() : this(Interop.BaseHandle.NewBaseHandle())
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an instance of BaseHandle.
        /// </summary>
        /// <param name="handle">The BaseHandle instance.</param>
        /// <since_tizen> 3 </since_tizen>
        public BaseHandle(BaseHandle handle) : this(Interop.BaseHandle.NewBaseHandle(BaseHandle.getCPtr(handle)))
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal BaseHandle(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            //to catch derived classes dali native exceptions
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            DebugFileLogging.Instance.WriteLog($"BaseHandle.contructor with cMemeryOwn:{cMemoryOwn} START");

            registerMe = swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if (registerMe)
            {
                // Register this instance of BaseHandle in the registry.
                Registry.Register(this);
            }

            disposeDebuggingCtor();
            DebugFileLogging.Instance.WriteLog($" BaseHandle.contructor with cMemeryOwn END");
            DebugFileLogging.Instance.WriteLog($"=============================");
        }

        internal BaseHandle(global::System.IntPtr cPtr)
        {
            DebugFileLogging.Instance.WriteLog($"BaseHandle.contructor START");

            registerMe = swigCMemOwn = true;

            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if (registerMe)
            {
                // Register this instance of BaseHandle in the registry.
                Registry.Register(this);
            }

            disposeDebuggingCtor();
            DebugFileLogging.Instance.WriteLog($"BaseHandle.contructor END");
            DebugFileLogging.Instance.WriteLog($"=============================");
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        // following this guide: https://docs.microsoft.com/ko-kr/dotnet/fundamentals/code-analysis/quality-rules/ca1063?view=vs-2019 (CA1063)
        ~BaseHandle() => Dispose(false);

        /// <summary>
        /// Event when a property is set.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// <seealso cref="BindableObject.PropertyChanged"/>
        [Obsolete("Deprecated in API9, will be removed in API11, Use BindableObject.PropertyChanged instead.")]
        public event PropertyChangedEventHandler PropertySet;

        internal global::System.Runtime.InteropServices.HandleRef GetBaseHandleCPtrHandleRef
        {
            get
            {
                return swigCPtr;
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
        /// Gets the hash code of this baseHandle.
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
            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(true);
            }
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Hidden API (Inhouse API).
        /// Dispose. 
        /// </summary>
        /// <remarks>
        /// Following the guide of https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose.
        /// This will replace "protected virtual void Dispose(DisposeTypes type)" which is exactly same in functionality.
        /// </remarks>
        /// <param name="disposing">true in order to free managed objects</param>
        // Protected implementation of Dispose pattern.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
                // Explicit call. user calls Dispose()

                //Throw exception if Dispose() is called in separate thread.
                if (!Window.IsInstalled())
                {
                    using var process = global::System.Diagnostics.Process.GetCurrentProcess();
                    var processId = process.Id;
                    var thread = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
                    var me = this.GetType().FullName;

                    DebugFileLogging.Instance.WriteLog("[NUI][BaseHandle] This API called from separate thread. This API must be called from MainThread. \n" +
                        $" process:{processId} thread:{thread}, disposing:{disposing}, isDisposed:{this.disposed}, isDisposeQueued:{this.isDisposeQueued}, me:{me}\n");

                    Tizen.Log.Fatal("NUI", $"[NUI][BaseHandle] This API called from separate thread. This API must be called from MainThread. \n" +
                        $" process:{processId} thread:{thread}, disposing:{disposing}, isDisposed:{this.disposed}, isDisposeQueued:{this.isDisposeQueued}, me:{me}\n");

                    //to fix ArtApp black screen issue. this will be enabled after talking with ArtApp team and fixing it.
                    // throw new global::System.InvalidOperationException("[NUI][BaseHandle] This API called from separate thread. This API must be called from MainThread. \n" +
                    //     $" process:{process} thread:{thread}, disposing:{disposing}, isDisposed:{this.disposed}, isDisposeQueued:{this.isDisposeQueued}, me:{me}\n");
                }

                if (isDisposeQueued)
                {
                    DebugFileLogging.Instance.WriteLog($"should not be here! (dead code) this will be removed!");

                    Tizen.Log.Fatal("NUI", $"[NUI] should not be here! (dead code) this will be removed!");

                    //to fix ArtApp black screen issue. this will be enabled after talking with ArtApp team and fixing it.
                    // throw new global::System.Exception($"[NUI] should not be here! (dead code) this will be removed!");
                    Dispose(DisposeTypes.Implicit);
                }
                else
                {
                    Dispose(DisposeTypes.Explicit);
                }
            }
            else
            {
                // Implicit call. user doesn't call Dispose(), so this object is added into DisposeQueue to be disposed automatically.
                if (!isDisposeQueued)
                {
                    isDisposeQueued = true;
                    DisposeQueue.Instance.Add(this);
                }
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.
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
            bool ret = Interop.BaseHandle.DoAction(swigCPtr, actionName, PropertyMap.getCPtr(attributes));
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
            string ret = Interop.BaseHandle.GetTypeName(swigCPtr);
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
            bool ret = Interop.BaseHandle.GetTypeInfo(swigCPtr, Tizen.NUI.TypeInfo.getCPtr(info));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Resets the handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remark>
        /// This will be deprecated, please use Dispose() instead.
        /// </remark>
        public void Reset()
        {
            this.Dispose();
            NUILog.Error("[ERROR] This(BaseHandle.Reset) will be deprecated, please use Dispose() instead!");
        }

        /// <summary>
        /// To check the BaseHandle instance is equal or not.
        /// </summary>
        /// <param name="rhs">The baseHandle instance.</param>
        /// <returns>True If equal.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(BaseHandle rhs)
        {
            bool ret = Interop.BaseHandle.EqualTo(swigCPtr, BaseHandle.getCPtr(rhs));
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
            bool ret = Interop.BaseHandle.NotEqualTo(swigCPtr, BaseHandle.getCPtr(rhs));
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
            if (swigCPtr.Handle == IntPtr.Zero)
            {
                return false;
            }

            if (disposed == true)
            {
                return false;
            }
            bool ret = Interop.BaseHandle.HasBody(swigCPtr);
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
            if (disposed == true || rhs == null || !rhs.HasBody())
            {
                return false;
            }

            bool ret = Interop.BaseHandle.IsEqual(swigCPtr, BaseHandle.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(BaseHandle obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
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

            DebugFileLogging.Instance.WriteLog($"BaseHandle.Dispose({type}) START");

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
            if (registerMe)
            {
                Registry.Unregister(this);
            }

            disposeDebuggingDispose(type);

            if (SwigCPtr.Handle != IntPtr.Zero)
            {
                var nativeSwigCPtr = swigCPtr.Handle;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    ReleaseSwigCPtr(new global::System.Runtime.InteropServices.HandleRef(this, nativeSwigCPtr));
                }
            }
            else
            {
                var me = this.GetType().FullName;
                DebugFileLogging.Instance.WriteLog($"[ERR] SwigCPtr is NULL, need to check! me:{me}");
                Log.Error("NUI", $"[ERR] SwigCPtr is NULL, need to check! me:{me}");
            }

            disposed = true;
            DebugFileLogging.Instance.WriteLog($"BaseHandle.Dispose({type}) END");
            DebugFileLogging.Instance.WriteLog($"=============================");
            NUILog.Debug($"BaseHandle.Dispose({type}) END");
            NUILog.Debug($"=============================");
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.BaseHandle.DeleteBaseHandle(swigCPtr.Handle);
        }

        /// <summary>
        /// Contains event arguments for the FocusChangeRequested event.
        /// </summary>
        [Obsolete("Deprecated in API9; Will be removed in API11.")]
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
            get
            {
                if (swigCPtr.Handle == IntPtr.Zero)
                {
                    using var process = global::System.Diagnostics.Process.GetCurrentProcess();
                    var processId = process.Id;
                    var thread = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
                    var me = this.GetType().FullName;

                    Tizen.Log.Fatal("NUI", $"SwigCPtr Error! NUI's native dali object is already disposed. " +
                        $"OR the native dali object handle of NUI becomes null! \n" +
                        $" process:{processId} thread:{thread}, isDisposed:{this.disposed}, isDisposeQueued:{this.isDisposeQueued}, me:{me}\n");

                    Tizen.Log.Fatal("NUI", $"[ERROR] back trace!");
                    global::System.Diagnostics.StackTrace st = new global::System.Diagnostics.StackTrace(true);
                    for (int i = 0; i < st.FrameCount; i++)
                    {
                        global::System.Diagnostics.StackFrame sf = st.GetFrame(i);
                        Tizen.Log.Fatal("NUI", " Method " + sf.GetMethod());
                    }
                    Tizen.Log.Fatal("NUI", "Error! just return here with null swigCPtr! this can cause unknown error or crash in next step");

                    //to fix ArtApp black screen issue. this will be enabled after talking with ArtApp team and fixing it.
                    // throw new ObjectDisposedException(nameof(SwigCPtr), $"Error! NUI's native dali object is already disposed. " +
                    //     $"OR the native dali object handle of NUI becomes null! \n" +
                    //     $" process:{process} thread:{thread}, isDisposed:{this.disposed}, isDisposeQueued:{this.isDisposeQueued}, me:{me}\n");
                }
                return swigCPtr;
            }
        }

        internal bool IsNativeHandleInvalid()
        {
            return swigCPtr.Handle == IntPtr.Zero;
        }

        /// <summary>
        /// swigCMemOwn
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal bool SwigCMemOwn => swigCMemOwn;

        /// <summary>
        /// The flag to check if it is already disposed of.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal bool Disposed => disposed;

        /// <summary>
        /// The flag to check if it is disposed by DisposeQueue.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal bool IsDisposeQueued => isDisposeQueued;

        [Conditional("NUI_DISPOSE_DEBUG_ON")]
        private void disposeDebuggingCtor()
        {
            DebugFileLogging.Instance.WriteLog($"type:{GetType()} copyNativeHandle:{swigCPtr.Handle.ToString("X8")}");
            if (this is BaseComponents.View view)
            {
                DebugFileLogging.Instance.WriteLog($"ID:{view.ID} Name:{view.Name}");
                //back trace
                global::System.Diagnostics.StackTrace st = new global::System.Diagnostics.StackTrace(true);
                for (int i = 0; i < st.FrameCount; i++)
                {
                    global::System.Diagnostics.StackFrame sf = st.GetFrame(i);
                    DebugFileLogging.Instance.WriteLog($"[{i}] {sf.GetMethod()}");
                }
            }
        }

        [Conditional("NUI_DISPOSE_DEBUG_ON")]
        private void disposeDebuggingDispose(DisposeTypes type)
        {
            DebugFileLogging.Instance.WriteLog($"swigCMemOwn:{swigCMemOwn} type:{GetType()} copyNativeHandle:{swigCPtr.Handle.ToString("X8")} HasBody:{HasBody()}");

            if (HasBody())
            {
                using var currentProcess = global::System.Diagnostics.Process.GetCurrentProcess();
                var process = currentProcess.Id;
                var thread = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
                var me = this.GetType().FullName;
                var daliId = "unknown";
                var hash = this.GetType().GetHashCode();
                var name = "unknown";

                if (this is BaseComponents.View)
                {
                    daliId = Interop.Actor.GetId(swigCPtr).ToString();
                    name = Interop.Actor.GetName(swigCPtr);
                    BaseObject tmp = new BaseObject(Interop.BaseHandle.GetBaseObject(swigCPtr), false);
                    var refCnt = tmp.ReferenceCount();
                    tmp.Dispose();
                    if (refCnt > 2)
                    {
                        DebugFileLogging.Instance.WriteLog($"[ERR] reference count is over than 2. Could be a memory leak. Need to check! \n" +
                            $" process:{process} thread:{thread}, isDisposed:{this.disposed}, isDisposeQueued:{this.isDisposeQueued}, me:{me} \n" +
                            $" disposeType:{type}, name:{name}, daliID:{daliId}, hash:{hash}, refCnt:{refCnt}");

                        Log.Error("NUI", $"[ERR] reference count is over than 2. Could be a memory leak. Need to check! \n" +
                            $" process:{process} thread:{thread}, isDisposed:{this.disposed}, isDisposeQueued:{this.isDisposeQueued}, me:{me} \n" +
                            $" disposeType:{type}, name:{name}, daliID:{daliId}, hash:{hash}, refCnt:{refCnt}");
                    }
                }
            }
        }

    }
}

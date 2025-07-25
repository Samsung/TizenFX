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
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tizen.NUI.Binding;
using global::System.Diagnostics;

namespace Tizen.NUI
{
    /// <summary>
    /// BaseHandle is a handle to an internal Dali resource.
    /// </summary>
    /// <remarks>
    /// Internal Dali resources with BaseHandle has reference count internally.<br/>
    /// And Dali resources will release the object only if reference count become zero.<br/>
    /// It mean, even we call <see cref="Dispose()"/>, the reousrce will not be released if some native has reference count.
    /// </remarks>
    /// <since_tizen> 3 </since_tizen>
    public class BaseHandle : Element, global::System.IDisposable
    {
        private static Dictionary<IntPtr, HashSet<object>> nativeBindedHolder = new Dictionary<IntPtr, HashSet<object>>();

        static internal void Preload()
        {
            // Do nothing. Just call for load static values.
        }

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
        private bool isDisposeQueued;

        private bool _disposeOnlyMainThread;

        /// <summary>
        /// Create an instance of BaseHandle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BaseHandle() : this(Interop.BaseHandle.NewBaseHandle(), true, false)
        {
            // Note : Empty BaseHandle instance don't need to be register in Registry.
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an instance of BaseHandle.
        /// </summary>
        /// <param name="handle">The BaseHandle instance.</param>
        /// <since_tizen> 3 </since_tizen>
        public BaseHandle(BaseHandle handle) : this(Interop.BaseHandle.NewBaseHandle(BaseHandle.getCPtr(handle)), true, false)
        {
            // Note : Copyed BaseHandle instance don't need to be register in Registry.
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal BaseHandle(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister, bool disposableOnlyMainThread)
        {
            //to catch derived classes dali native exceptions
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            registerMe = cRegister;
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if (registerMe)
            {
                // Register this instance of BaseHandle in the registry.
                if (!Registry.Register(this))
                {
                    registerMe = false;
                }
            }

            // We must dispose BaseHandle at main thread if register successed.
            _disposeOnlyMainThread = disposableOnlyMainThread || registerMe;
        }
        internal BaseHandle(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : this(cPtr, cMemoryOwn, cRegister, true)
        {
        }

        internal BaseHandle(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal BaseHandle(global::System.IntPtr cPtr) : this(cPtr, true)
        {
        }

        /// <summary>
        /// Finalizes the instance of the BaseHandle class.
        /// This method implements the finalization pattern for proper disposal of resources.
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
        /// <param name="x">The first BaseHandle instance to compare.</param>
        /// <param name="y">The second BaseHandle instance to compare.</param>
        /// <returns>true if both instances are equal; otherwise false.</returns>
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
        /// Inequality operator. Returns true if the operands are not equal, false otherwise. Returns true if either operand is null.
        /// </summary>
        /// <param name="x">The first BaseHandle instance to compare.</param>
        /// <param name="y">The second BaseHandle instance to compare.</param>
        /// <returns>True if the operands are not equal, false otherwise. Returns true if either operand is null.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator !=(BaseHandle x, BaseHandle y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Logical AND operator.
        /// It's possible when doing a logical AND operation, this function (opBitwiseAnd) might never be called due to short circuiting.
        /// </summary>
        /// <param name="x">The first BaseHandle instance.</param>
        /// <param name="y">The second BaseHandle instance.</param>
        /// <returns>Returns the first BaseHandle instance if both instances are equal; otherwise, returns null.</returns>
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
        /// Logical OR operator for ||.
        /// It's possible when doing a || this function (opBitwiseOr) is never called due to short circuiting.
        /// </summary>
        /// <param name="x">The first BaseHandle to be compared.</param>
        /// <param name="y">The second BaseHandle to be compared.</param>
        /// <returns>A BaseHandle that contains either of the non-null bodies of the two operands.</returns>
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
        /// Logical ! operator for BaseHandle class.
        /// </summary>
        /// <param name="x">The BaseHandle instance to check.</param>
        /// <returns>True if the handle is null or has no body; otherwise, false.</returns>
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
        /// Compares the current instance with another object of the same type and returns true if they represent the same handle.
        /// </summary>
        /// <param name="o">The object to compare with the current instance.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
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
        /// <remarks>
        /// This method release only C# side objects. If someone hold BaseHandle at Native side<br/>
        /// the object will not be removed until native side reset the handle.
        /// </remarks>
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
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <remarks>
        /// Following the guide of https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose.
        /// This will replace "protected virtual void Dispose(DisposeTypes type)" which is exactly same in functionality.
        /// </remarks>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
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
                if (DisposeOnlyMainThread && !Window.IsInstalled())
                {
                    using var process = global::System.Diagnostics.Process.GetCurrentProcess();
                    var processId = process.Id;
                    var thread = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
                    var me = this.GetType().FullName;

                    Tizen.Log.Fatal("NUI", $"[NUI][BaseHandle] This API called from separate thread. This API must be called from MainThread. \n" +
                        $" process:{processId} thread:{thread}, disposing:{disposing}, isDisposed:{this.disposed}, isDisposeQueued:{this.isDisposeQueued}, me:{me}\n");

                    //to fix ArtApp black screen issue. this will be enabled after talking with ArtApp team and fixing it.
                    // throw new global::System.InvalidOperationException("[NUI][BaseHandle] This API called from separate thread. This API must be called from MainThread. \n" +
                    //     $" process:{process} thread:{thread}, disposing:{disposing}, isDisposed:{this.disposed}, isDisposeQueued:{this.isDisposeQueued}, me:{me}\n");
                }

                if (isDisposeQueued)
                {
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
                if (_disposeOnlyMainThread)
                {
                    if (!isDisposeQueued)
                    {
                        isDisposeQueued = true;
                        DisposeQueue.Instance.Add(this);
                    }
                }
                else
                {
                    Dispose(DisposeTypes.Implicit);
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

            if (!ThemeManager.InitialThemeDisabled && ChangedPropertiesSetExcludingStyle != null)
            {
                ChangedPropertiesSetExcludingStyle.Add(propertyName);
            }
        }

        internal void UnregisterFromRegistry()
        {
            if (registerMe)
            {
                Registry.Unregister(this);
                registerMe = false;
            }
        }

        /// <summary>
        /// Dispose.
        /// Releases unmanaged and optionally managed resources.
        /// </summary>
        /// <remarks>
        /// When overriding this method, you need to distinguish between explicit and implicit conditions. For explicit conditions, release both managed and unmanaged resources. For implicit conditions, only release unmanaged resources.
        /// </remarks>
        /// <param name="type">Explicit to release both managed and unmanaged resources. Implicit to release only unmanaged resources.</param>
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
            UnregisterFromRegistry();

            if (SwigCPtr.Handle != IntPtr.Zero)
            {
                var nativeSwigCPtr = swigCPtr.Handle;

                ClearHolder(nativeSwigCPtr);

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
                Log.Error("NUI", $"[ERR] SwigCPtr is NULL, need to check! me:{me}");
            }

            disposed = true;
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
        /// Adds the specified object to the set of objects that have been bound to the native object.
        /// </summary>
        /// <param name="obj">The object to add.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void AddToNativeHolder(object obj)
        {
            if (IsDisposedOrQueued)
            {
                return;
            }

            if (!nativeBindedHolder.TryGetValue(swigCPtr.Handle, out var holders))
            {
                nativeBindedHolder.Add(swigCPtr.Handle, holders = new HashSet<object>());
            }

            holders.Add(obj);
        }

        /// <summary>
        ///  Removes the specified object from the set of objects that have been bound to the native object.
        /// </summary>
        /// <param name="obj">The object to remove.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void RemoveFromNativeHolder(object obj)
        {
            if (IsDisposedOrQueued)
            {
                return;
            }

            if (nativeBindedHolder.TryGetValue(swigCPtr.Handle, out var holders))
            {
                holders.Remove(obj);

                if (holders.Count == 0)
                {
                    nativeBindedHolder.Remove(swigCPtr.Handle);
                }
            }
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
                        Tizen.Log.Fatal("NUI", " Method " + sf.GetMethod() + ":" + sf.GetFileName() + ":" + sf.GetFileLineNumber());
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal bool IsDisposedOrQueued => disposed || isDisposeQueued;

        /// <summary>
        /// The flag to check if it must be disposed at main thread or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal bool DisposeOnlyMainThread => _disposeOnlyMainThread;

        static private void ClearHolder(IntPtr handle)
        {
            nativeBindedHolder.Remove(handle);
        }

        /// <summary>
        /// Get memory ownership and registry information of the native pointer.
        /// Please be aware enough about this action before use this method.
        /// </summary>
        internal void AcquireOwnership(IntPtr pointer)
        {
            if (swigCMemOwn || registerMe || IsDisposedOrQueued)
            {
                throw new InvalidOperationException("This should not have ownership of other native handle.");
            }

            swigCPtr = new System.Runtime.InteropServices.HandleRef(this, pointer);
            swigCMemOwn = true;
            registerMe = true;

            if (!Registry.Register(this))
            {
                throw new InvalidOperationException("This destination base handle should not have ownership of other native handle.");
            }
            _disposeOnlyMainThread = true;
        }

        /// <summary>
        /// Remove memory ownership and registry information of this handle.
        /// Please be aware enough about this action before use this method.
        /// </summary>
        internal void RemoveOwnership()
        {
            if (!swigCMemOwn || !registerMe || !_disposeOnlyMainThread || IsDisposedOrQueued)
            {
                throw new InvalidOperationException("This base handle does not have ownership of the native handle.");
            }

            UnregisterFromRegistry();
            swigCMemOwn = false;
            _disposeOnlyMainThread = false;
        }

        /// <summary>
        /// Get memory ownership and registry information of the native pointer.
        /// Please be aware enough about this action before use this method.
        /// </summary>
        internal void MoveOwnership(BaseHandle handle)
        {
            IntPtr pointer = swigCPtr.Handle;
            RemoveOwnership();
            handle.AcquireOwnership(pointer);
        }
    }
}

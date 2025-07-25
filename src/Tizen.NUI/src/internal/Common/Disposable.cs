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
using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Disposable class.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Disposable : global::System.IDisposable
    {
        static internal void Preload()
        {
            // Do nothing. Just call for load static values.
        }

        /// <summary>
        /// The flag to check if it is already disposed of.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API9, will be removed in API11, Use Disposed")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "<Pending>")]
        protected bool disposed = false;

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private bool swigCMemOwn { get; set; }
        private bool isDisposeQueued;

        private bool _disposeOnlyMainThread;

        /// <summary>
        /// Create an instance of Disposable.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Disposable() : this(global::System.IntPtr.Zero, false)
        {
        }

        /// This will not be public.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Disposable(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal Disposable(global::System.IntPtr cPtr, bool cMemoryOwn, bool disposableOnlyMainThread)
        {
            swigCMemOwn = cMemoryOwn;
            _disposeOnlyMainThread = disposableOnlyMainThread;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(cPtr == global::System.IntPtr.Zero ? null : this, cPtr);
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~Disposable() => Dispose(false);

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
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

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Disposable obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
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
                if (DisposeOnlyMainThread && !Window.IsInstalled())
                {
                    using var process = global::System.Diagnostics.Process.GetCurrentProcess();
                    var processId = process.Id;
                    var thread = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
                    var me = this.GetType().FullName;

                    Tizen.Log.Fatal("NUI", $"[NUI][Disposable] This API called from separate thread. This API must be called from MainThread. \n" +
                        $" process:{processId} thread:{thread}, disposing:{disposing}, isDisposed:{this.disposed}, isDisposeQueued:{this.isDisposeQueued}, me:{me}\n");

                    //to fix ArtApp black screen issue. this will be enabled after talking with ArtApp team and fixing it.
                    // throw new global::System.InvalidOperationException("[NUI][Disposable] This API called from separate thread. This API must be called from MainThread. \n" +
                    //     $" process:{process} thread:{thread}, disposing:{disposing}, isDisposed:{this.disposed}, isDisposeQueued:{this.isDisposeQueued}, me:{me}\n");
                }

                if (isDisposeQueued)
                {
                    Tizen.Log.Fatal("NUI", $"[Disposable]should not be here! (dead code) this will be removed!");

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
        /// Dispose.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
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
                var nativeSwigCPtr = swigCPtr.Handle;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    ReleaseSwigCPtr(new global::System.Runtime.InteropServices.HandleRef(this, nativeSwigCPtr));
                }
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

        internal global::System.Runtime.InteropServices.HandleRef SwigCPtr
        {
            get => swigCPtr;
            set
            {
                swigCPtr = value;
            }
        }

        internal bool SwigCMemOwn => swigCMemOwn;

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

        /// <summary>
        /// The flag to check if it must be disposed at main thread or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal bool DisposeOnlyMainThread => _disposeOnlyMainThread;
    }

    internal static class DisposableExtension
    {
        internal static T Ensure<T>(this T caller) where T : Disposable
        {
            return (caller.SwigCPtr.Handle == System.IntPtr.Zero ? null : caller);
        }
    }
}

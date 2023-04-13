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
        /// <summary>
        /// The flag to check if it is already disposed of.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API9, will be removed in API11, Use Disposed")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "<Pending>")]
        protected bool disposed = false;

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private bool swigCMemOwn { get; set; }
        private bool isDisposeQueued = false;

        /// <summary>
        /// Create an instance of Disposable.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Disposable()
        {
            swigCMemOwn = false;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
        }

        /// This will not be public.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Disposable(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
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
    }

    internal static class DisposableExtension
    {
        internal static T Ensure<T>(this T caller) where T : Disposable
        {
            return (caller.SwigCPtr.Handle == System.IntPtr.Zero ? null : caller);
        }
    }
}

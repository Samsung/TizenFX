/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Diagnostics.Contracts;

using static CoreUI.DataTypes.DataTypesNative.PromiseNativeMethods;

namespace CoreUI.DataTypes
{

namespace DataTypesNative
{

[EditorBrowsable(EditorBrowsableState.Never)]
static internal class PromiseNativeMethods
{
    internal delegate void Promise_Cancel_Cb(IntPtr data, IntPtr dead);

    [DllImport(CoreUI.Libs.Ecore)]
    internal static extern IntPtr efl_loop_promise_new(IntPtr obj, Promise_Cancel_Cb cancel_cb, IntPtr data);

    [DllImport(CoreUI.Libs.Eina)]
    internal static extern IntPtr eina_promise_new(IntPtr scheduler, Promise_Cancel_Cb cancel_cb, IntPtr data);

    [DllImport(CoreUI.Libs.Eina)]
    internal static extern void eina_promise_resolve(IntPtr scheduler, CoreUI.DataTypes.ValueNative value);

    [DllImport(CoreUI.Libs.Eina)]
    internal static extern void eina_promise_reject(IntPtr scheduler, CoreUI.DataTypes.Error reason);

    [DllImport(CoreUI.Libs.CustomExports)]
    internal static extern void efl_mono_thread_safe_promise_reject(IntPtr scheduler, CoreUI.DataTypes.Error reason);

    [DllImport(CoreUI.Libs.Eina)]
    internal static extern IntPtr eina_future_new(IntPtr promise);

    [DllImport(CoreUI.Libs.Eina)]
    internal static extern void eina_future_cancel(IntPtr future);

    [DllImport(CoreUI.Libs.Ecore)]
    internal static extern IntPtr efl_loop_future_scheduler_get(IntPtr obj);

    [DllImport(CoreUI.Libs.Eina)]
    internal static extern IntPtr eina_future_then_from_desc(IntPtr prev, FutureDesc desc);

    [DllImport(CoreUI.Libs.Eina)]
    internal static extern IntPtr eina_future_chain_array(IntPtr prev, FutureDesc[] desc);

    internal delegate CoreUI.DataTypes.ValueNative FutureCb(IntPtr data, CoreUI.DataTypes.ValueNative value, IntPtr dead_future);

    [StructLayout(LayoutKind.Sequential)]
    internal struct FutureDesc
    {
        internal FutureCb cb;
        internal IntPtr data;
        internal IntPtr storage; // Internal use by eina

        public FutureDesc(FutureCb cb, IntPtr data, IntPtr storage)
        {
            this.cb = cb;
            this.data = data;
            this.storage = storage;
        }
    }
}

} // namespace DataTypesNative

/// <summary>
/// Promises act as placeholders for a value that may be available in the future.
///
/// With a Promise you can attach futures to it, which will be used to notify of the value being available.
///
/// <para>Since CoreUI 1.23.</para>
/// </summary>
/// <since_tizen> 6 </since_tizen>
public class Promise : IDisposable
{
    internal IntPtr Handle;
    private GCHandle CleanupHandle;

    /// <summary>Delegate for functions that will be called upon a promise cancellation.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public delegate void CancelCb();

    /// <summary>
    /// Creates a new Promise with the given callback.
    ///
    /// Currently, creating a promise directly uses the Main Loop scheduler the source of notifications (i.e. the
    /// future callbacks will be called mainly from a loop iteration).
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public Promise(CancelCb cancelCb = null)
    {
        CoreUI.Loop loop = CoreUI.App.AppMain;

        // Should we be able to pass different schedulers?
        IntPtr scheduler = efl_loop_future_scheduler_get(loop.NativeHandle);

        IntPtr cb_data = IntPtr.Zero;

        // A safety clean callback to mark this wrapper as invalid
        CancelCb safetyCb = () =>
        {
            Handle = IntPtr.Zero;
            if (cancelCb != null)
            {
                cancelCb();
            }
        };

        CleanupHandle = GCHandle.Alloc(safetyCb);
        cb_data = GCHandle.ToIntPtr(CleanupHandle);

        this.Handle = eina_promise_new(scheduler, NativeCancelCb, cb_data);
    }

    private static void NativeCancelCb(IntPtr data, IntPtr dead)
    {
        if (data == IntPtr.Zero)
        {
            return;
        }

        GCHandle handle = GCHandle.FromIntPtr(data);
        CancelCb cb = handle.Target as CancelCb;
        if (cb != null)
        {
            cb();
        }
        else
        {
            CoreUI.DataTypes.Log.Info("Null promise CancelCb found");
        }

        handle.Free();
    }

    /// <summary>Dispose this promise, causing its cancellation if it isn't already fulfilled.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Finalizer to be called from the Garbage Collector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    ~Promise()
    {
        Dispose(false);
    }

    /// <summary>Disposes of this wrapper, rejecting the native promise with <see cref="CoreUI.DataTypes.Error.ECANCELED"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="disposing">True if this was called from <see cref="Dispose()"/> public method. False if
    /// called from the C# finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (Handle != IntPtr.Zero)
        {
            if (disposing)
            {
                eina_promise_reject(Handle, CoreUI.DataTypes.Error.ECANCELED);
            }
            else
            {
                efl_mono_thread_safe_promise_reject(Handle, CoreUI.DataTypes.Error.ECANCELED);
            }
            Handle = IntPtr.Zero;
        }
    }

    private void SanityChecks()
    {
        if (this.Handle == IntPtr.Zero)
        {
            throw new ObjectDisposedException(GetType().Name);
        }
    }

    /// <summary>
    /// Fulfills a promise with the given value.
    ///
    /// <para>This will make all futures attached to it to be called with the given value as payload.</para>
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Resolve(CoreUI.DataTypes.Value value)
    {
        Contract.Requires(value != null, nameof(value));
        SanityChecks();
        eina_promise_resolve(this.Handle, value);
        // Promise will take care of releasing this value correctly.
        value.ReleaseOwnership();
        this.Handle = IntPtr.Zero;
        // Resolving a cb does *not* call its cancellation callback, so we have to release the
        // lambda created in the constructor for cleanup.
        CleanupHandle.Free();
    }

    /// <summary>
    /// Rejects a promise.
    ///
    /// <para>The future chain attached to this promise will be called with an CoreUI.DataTypes.Value of type
    /// <see cref="CoreUI.DataTypes.ValueType.Error" /> and payload <see cref="CoreUI.DataTypes.Error.ECANCELED" />.</para>
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Reject(CoreUI.DataTypes.Error reason)
    {
        SanityChecks();
        eina_promise_reject(this.Handle, reason);
        this.Handle = IntPtr.Zero;
    }
}

/// <summary>
/// Futures are the structures holding the callbacks to be notified of a promise fullfillment
/// or cancellation.
/// </summary>
/// <since_tizen> 6 </since_tizen>
public class Future
{
    /// <summary>
    /// Callback attached to a future and to be called when resolving/rejecting a promise.
    ///
    /// <para>The CoreUI.DataTypes.Value as argument can come with an <see cref="CoreUI.DataTypes.Error.ECANCELED" /> as payload if the
    /// promise/future was rejected/cancelled.</para>
    ///
    /// <para>The return value usually is same as the argument, forwarded, but can be changed in
    /// case were the chain act as a transforming pipeline.</para>
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public delegate CoreUI.DataTypes.Value ResolvedCb(CoreUI.DataTypes.Value value);

    internal IntPtr Handle;

    /// <summary>
    /// Creates a Future from a native pointer.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Future(IntPtr handle)
    {
        handle = ThenRaw(handle, (CoreUI.DataTypes.Value value) =>
        {
            Handle = IntPtr.Zero;
            return value;
        });
        Handle = handle;
    }

    /// <summary>
    /// Creates a Future attached to the given Promise.
    ///
    /// <para>Optionally a resolved callback may be provided. If so, it will be chained
    /// before the returned future.</para>
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="promise">The <see cref="CoreUI.DataTypes.Promise" /> which rejection or resolution will cause
    /// the future to trigger.</param>
    /// <param name="cb">The callback to be called when the attached promise resolves.</param>
    public Future(Promise promise, ResolvedCb cb = null)
    {
        Contract.Requires(promise != null, nameof(promise));
        IntPtr intermediate = eina_future_new(promise.Handle);
        Handle = ThenRaw(intermediate, (CoreUI.DataTypes.Value value) =>
        {
            if (cb != null)
            {
                value = cb(value);
            }

            Handle = IntPtr.Zero;
            return value;
        });
    }

    private void SanityChecks()
    {
        if (this.Handle == IntPtr.Zero)
        {
            throw new ObjectDisposedException(GetType().Name);
        }
    }

    /// <summary>
    /// Cancels this future and the chain it belongs to, along with the promise linked against it.
    ///
    /// <para>The callbacks will still be called with <see cref="CoreUI.DataTypes.Error.ECANCELED" /> as payload. The promise cancellation
    /// callback will also be called if present.</para>
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Cancel()
    {
        SanityChecks();
        eina_future_cancel(this.Handle);
    }

    /// <summary>
    /// Creates a new future to be called after this one.
    ///
    /// <para>Once the promise this future is attached to resolves, the callbacks on the chain
    /// are called in the order they were chained.</para>
    ///
    /// <para>CAUTION: Calling Then() on a future that had it called before will replace the previous chain
    /// from this point on.</para>
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="cb">The callback to be called when this future is resolved.</param>
    /// <returns>A new future in the chain after registering the callback.</returns>
    public Future Then(ResolvedCb cb)
    {
        SanityChecks();
        return new Future(ThenRaw(Handle, cb));
    }

    // Helper function to attach a cb to a future without creating a new wrapper directly.
    // It'll be used in the construtor, to attach the cleaning cb to an intermediate future.
    private static IntPtr ThenRaw(IntPtr previous, ResolvedCb cb)
    {
        FutureDesc desc = new FutureDesc();
        desc.cb = NativeResolvedCbDelegate;
        GCHandle handle = GCHandle.Alloc(cb);
        desc.data = GCHandle.ToIntPtr(handle);
        return eina_future_then_from_desc(previous, desc);
    }

    private static FutureCb NativeResolvedCbDelegate = new FutureCb(NativeResolvedCb);

    private static CoreUI.DataTypes.ValueNative NativeResolvedCb(IntPtr data, CoreUI.DataTypes.ValueNative value, IntPtr dead_future)
    {
        GCHandle handle = GCHandle.FromIntPtr(data);
        ResolvedCb cb = handle.Target as ResolvedCb;
        if (cb != null)
        {
            CoreUI.DataTypes.Value managedValue = cb(value);
            // Both `value` and `managedValue` will point to the same internal value data.
            // Avoid C# wrapper invalidating the underlying C Eina_Value as the eina_future.c
            // code will release it.
            value = managedValue.GetNative();
            managedValue.ReleaseOwnership();
        }
        else
        {
            CoreUI.DataTypes.Log.Warning("Failed to get future callback.");
        }

        handle.Free();
        return value;
    }

    /// <summary>
    /// Helper method for chaining a group of callbacks in a single go.
    ///
    /// It is just syntatic sugar for sequential Then() calls, without creating intermediate
    /// futures explicitly.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="cbs">An enumerable with the callbacks to be chained together.</param>
    /// <returns>The future representing the chain.</returns>
    public Future Chain(IEnumerable<ResolvedCb> cbs)
    {
        SanityChecks();
        System.Collections.Generic.IList<ResolvedCb> cbsList = cbs.ToList();
        FutureDesc[] descs = new FutureDesc[cbsList.Count + 1]; // +1 due to the null-cb terminating descriptor.
        int i = 0;
        try
        {
            for (; i < cbsList.Count; i++)
            {
                ResolvedCb cb = cbsList[i];
                descs[i].cb = NativeResolvedCbDelegate;
                GCHandle handle = GCHandle.Alloc(cb);
                descs[i].data = GCHandle.ToIntPtr(handle);
            }

            descs[i].cb = null;
            descs[i].data = IntPtr.Zero;
        }
        catch (Exception e)
        {
            for (int j = 0; j <= i; j++)
            {
                if (descs[i].data == IntPtr.Zero)
                {
                    continue;
                }

                GCHandle handle = GCHandle.FromIntPtr(descs[i].data);
                handle.Free();
            }

            CoreUI.DataTypes.Log.Error($"Failed to create native future description for callbacks. Error: {e.ToString()}");
            return null;
        }

        return new Future(eina_future_chain_array(Handle, descs));
    }
}

/// <summary>Custom marshaler to convert between managed and native <see cref="CoreUI.DataTypes.Future"/>.
/// Internal usage in generated code.</summary>
/// <since_tizen> 6 </since_tizen>
[EditorBrowsable(EditorBrowsableState.Never)]
public class FutureMarshaler : ICustomMarshaler
{

    ///<summary>Wrap the native future with a managed wrapper.</summary>
    /// <since_tizen> 6 </since_tizen>
    ///<param name="pNativeData">Handle to the native future.</param>
    ///<returns>An <see cref="CoreUI.DataTypes.Future"/> wrapping the native future.</returns>
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        return new Future(pNativeData);
    }

    ///<summary>Extracts the native future from a managed wrapper.</summary>
    /// <since_tizen> 6 </since_tizen>
    ///<param name="managedObj">The managed wrapper. If it is not an <see cref="CoreUI.DataTypes.Future"/>, the value returned
    ///is <see cref="System.IntPtr.Zero"/>.</param>
    ///<returns>A <see cref="System.IntPtr"/> pointing to the native future.</returns>
    public IntPtr MarshalManagedToNative(object managedObj)
    {
        Future f = managedObj as Future;
        if (f == null)
        {
            return IntPtr.Zero;
        }

        return f.Handle;
    }

    ///<summary>Not implemented. The code receiving the native data is in charge of releasing it.</summary>
    /// <since_tizen> 6 </since_tizen>
    ///<param name="pNativeData">The native pointer to be released.</param>
    public void CleanUpNativeData(IntPtr pNativeData)
    {
    }

    ///<summary>Not implemented. The runtime takes care of releasing it.</summary>
    /// <since_tizen> 6 </since_tizen>
    ///<param name="managedObj">The managed object to be cleaned.</param>
    public void CleanUpManagedData(object managedObj)
    {
    }

    ///<summary>Size of the native data size returned</summary>
    /// <since_tizen> 6 </since_tizen>
    ///<returns>The size of the data.</returns>
    public int GetNativeDataSize()
    {
        return -1;
    }

    ///<summary>Gets an instance of this marshaller.</summary>
    /// <since_tizen> 6 </since_tizen>
    ///<param name="cookie">A name that could be used to customize the returned marshaller. Currently not used.</param>
    ///<returns>The <see cref="CoreUI.DataTypes.FutureMarshaler"/> instance that will marshall the data.</returns>
    public static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new FutureMarshaler();
        }

        return marshaler;
    }

    private static FutureMarshaler marshaler;
}

} // namespace eina

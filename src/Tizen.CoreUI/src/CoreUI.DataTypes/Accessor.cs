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
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

using static CoreUI.DataTypes.TraitFunctions;

using static CoreUI.DataTypes.AccessorNativeFunctions;

namespace CoreUI.DataTypes
{

internal class AccessorNativeFunctions
{
    [DllImport(CoreUI.Libs.Eina)] public static extern IntPtr
        eina_carray_length_accessor_new(IntPtr array, uint step, uint length);
    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_accessor_data_get(IntPtr accessor, uint position, out IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] public static extern void
        eina_accessor_free(IntPtr accessor);
    [DllImport(CoreUI.Libs.CustomExports)] public static extern IntPtr
        eina_mono_owned_carray_length_accessor_new(IntPtr array,
                                                   uint step,
                                                   uint length,
                                                   CoreUI.DataTypes.Callbacks.EinaFreeCb freeCb,
                                                   IntPtr handle);
}

/// <summary>Accessors provide an uniform way of accessing Eina containers,
/// similar to C++ STL's and C# IEnumerable.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
                 Justification="This is a generalized container mapping the native one.")]
public class Accessor<T> : IEnumerable<T>, IDisposable
{
    /// <summary>Pointer to the native accessor.</summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IntPtr Handle { get; private set; } = IntPtr.Zero;

    /// <summary>Who is in charge of releasing the resources wrapped by this instance.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    private Ownership Ownership { get; set; }

    // FIXME Part of the implicit EFL Container interface. Need to make it explicit.
    /// <summary>Whether this wrapper owns the native accessor.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public bool Own
    {
        get
        {
            return Ownership == Ownership.Managed;
        }
        set
        {
            Ownership = value ? Ownership.Managed : Ownership.Unmanaged;
        }
    }

    /// <summary>Create a new accessor wrapping the given pointer.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="handle">The native handle to be wrapped.</param>
    /// <param name="owner">Whether this wrapper owns the native accessor.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Accessor(IntPtr handle, Ownership owner = Ownership.Managed)
    {
        Handle = handle;
        Ownership = owner;
    }

    /// <summary>Create a new accessor wrapping the given pointer.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="handle">The native handle to be wrapped.</param>
    /// <param name="own">Whether this wrapper owns the native accessor.</param>
    /// <param name="ownContent">For compatibility with other EFL# containers. Ignored in acessors.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Accessor(IntPtr handle, bool own, bool ownContent = false)
        : this(handle, own ? Ownership.Managed : Ownership.Unmanaged)
    {
    }

    /// <summary>Release the native resources held by this instance.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Disposes of this wrapper, releasing the native accessor if
    /// owned.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="disposing">True if this was called from <see cref="Dispose()"/> public method. False if
    /// called from the C# finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (Ownership == Ownership.Managed && Handle != IntPtr.Zero)
        {
            if (disposing)
            {
                eina_accessor_free(Handle);
            }
            else
            {
                CoreUI.Wrapper.Globals.ThreadSafeFreeCbExec(eina_accessor_free, Handle);
            }
            Handle = IntPtr.Zero;
        }
    }

    /// <summary>Finalizer to be called from the Garbage Collector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    ~Accessor()
    {
        Dispose(false);
    }

    /// <summary>Convert the native data into managed. This is used when returning the data through a
    /// <see cref="System.Collections.Generic.IEnumerator&lt;T&gt;"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="data">The data to be converted</param>
    /// <returns>The managed data representing <c>data</c>.</returns>
    internal virtual T Convert(IntPtr data)
    {
        return NativeToManaged<T>(data);
    }

    /// <summary>Returns an enumerator that iterates throught this accessor.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>An enumerator to walk through the acessor items.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        if (Handle == IntPtr.Zero)
        {
            throw new ObjectDisposedException(base.GetType().Name);
        }

        IntPtr tmp;
        uint position = 0;
        while (eina_accessor_data_get(Handle, position, out tmp))
        {
            yield return Convert(tmp); // No need to free as it is still owned by the container.
            position += 1;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

/// <summary>Accessor for Inlists.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
                 Justification="This is a generalized container mapping the native one.")]
public class AccessorInList<T> : Accessor<T>
{
    /// <summary>Create a new accessor wrapping the given pointer.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="handle">The native handle to be wrapped.</param>
    /// <param name="own">Whether this wrapper owns the native accessor.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public AccessorInList(IntPtr handle, Ownership own) : base(handle, own)
    {
    }

    /// <summary>Convert the native data into managed. This is used when returning the data through a
    /// <see cref="System.Collections.Generic.IEnumerator&lt;T&gt;"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="data">The data to be converted</param>
    /// <returns>The managed data representing <c>data</c>.</returns>
    internal override T Convert(IntPtr data)
    {
        return NativeToManagedInlistNode<T>(data);
    }
}

/// <summary>Accessor for Inarrays.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
                 Justification="This is a generalized container mapping the native one.")]
public class AccessorInArray<T> : Accessor<T>
{
    /// <summary>Create a new accessor wrapping the given pointer.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="handle">The native handle to be wrapped.</param>
    /// <param name="own">Whether this wrapper owns the native accessor.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public AccessorInArray(IntPtr handle, Ownership own) : base(handle, own)
    {
    }

    /// <summary>Convert the native data into managed. This is used when returning the data through a
    /// <see cref="System.Collections.Generic.IEnumerator&lt;T&gt;"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="data">The data to be converted</param>
    /// <returns>The managed data representing <c>data</c>.</returns>
    internal override T Convert(IntPtr data)
    {
        return NativeToManagedInplace<T>(data);
    }
}

}

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
#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

using static CoreUI.DataTypes.TraitFunctions;
using static CoreUI.DataTypes.IteratorNativeFunctions;

namespace CoreUI.DataTypes
{

[EditorBrowsable(EditorBrowsableState.Never)]
internal static class IteratorNativeFunctions
{
    [DllImport(CoreUI.Libs.Eina)] internal static extern void
        eina_iterator_free(IntPtr iterator);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_iterator_container_get(IntPtr iterator);
    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_iterator_next(IntPtr iterator, out IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] internal static extern void
        eina_iterator_foreach(IntPtr iterator, IntPtr callback, IntPtr fdata);
    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_iterator_lock(IntPtr iterator);
    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_iterator_unlock(IntPtr iterator);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_carray_iterator_new(IntPtr array);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_carray_length_iterator_new(IntPtr array, uint step, uint length);
}

/// <summary>Wrapper around a native Eina iterator.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
                 Justification="This is a generalized container mapping the native one.")]
public class Iterator<T> : IEnumerable<T>, IDisposable
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IntPtr Handle {get;set;} = IntPtr.Zero;
    /// <summary>Whether this wrapper owns the native iterator.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public bool Own {get;set;} = true;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Iterator(IntPtr handle, bool own)
    {
        Handle = handle;
        Own = own;
    }

    /// <summary>
    ///   Finalizer to be called from the Garbage Collector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    ~Iterator()
    {
        Dispose(false);
    }

    /// <summary>Disposes of this wrapper, releasing the native array if owned.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="disposing">True if this was called from <see cref="Dispose()"/> public method. False if
    /// called from the C# finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
        var h = Handle;
        Handle = IntPtr.Zero;
        if (h == IntPtr.Zero)
        {
            return;
        }

        if (Own)
        {
            if (disposing)
            {
                eina_iterator_free(h);
            }
            else
            {
                CoreUI.Wrapper.Globals.ThreadSafeFreeCbExec(eina_iterator_free, h);
            }
        }
    }

    /// <summary>Releases the native resources held by this instance.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Releases the native resources held by this instance.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Free()
    {
        Dispose();
    }

    /// <summary>
    ///   Releases the native iterator.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The native array.</returns>
    public IntPtr Release()
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        return h;
    }

    /// <summary>Sets own.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="own">If own the object.</param>
    public void SetOwnership(bool own)
    {
        Own = own;
    }

    /// <summary>
    ///   Go to the next one.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    ///
    public bool Next(out T res)
    {
        IntPtr data;
        if (!eina_iterator_next(Handle, out data))
        {
            res = default(T);
            return false;
        }

        res = NativeToManaged<T>(data);

        return true;
    }

    /// <summary>
    ///   Locks the container of the iterator.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>true on success, false otherwise.</returns>
    public bool Lock()
    {
        return eina_iterator_lock(Handle);
    }

    /// <summary>
    ///   Unlocks the container of the iterator.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>true on success, false otherwise.</returns>
    public bool Unlock()
    {
        return eina_iterator_unlock(Handle);
    }

    /// <summary> Gets an Enumerator for this iterator.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public IEnumerator<T> GetEnumerator()
    {
        for (T curr; Next(out curr);)
        {
            yield return curr;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

}

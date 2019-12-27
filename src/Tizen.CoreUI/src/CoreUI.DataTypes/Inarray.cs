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
using System.Diagnostics.Contracts;

using static CoreUI.DataTypes.TraitFunctions;
using static CoreUI.DataTypes.InarrayNativeFunctions;

namespace CoreUI.DataTypes
{

[EditorBrowsable(EditorBrowsableState.Never)]
internal static class InarrayNativeFunctions
{
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inarray_new(uint member_size, uint step);
    [DllImport(CoreUI.Libs.Eina)] internal static extern void
        eina_inarray_free(IntPtr array);
    [DllImport(CoreUI.Libs.Eina)] internal static extern void
        eina_inarray_step_set(IntPtr array, uint sizeof_eina_inarray, uint member_size, uint step);
    [DllImport(CoreUI.Libs.Eina)] internal static extern void
        eina_inarray_flush(IntPtr array);
    [DllImport(CoreUI.Libs.Eina)] internal static extern int
        eina_inarray_push(IntPtr array, IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inarray_grow(IntPtr array, uint size);
    [DllImport(CoreUI.Libs.Eina)] internal static extern int
        eina_inarray_insert(IntPtr array, IntPtr data, IntPtr compare);
    [DllImport(CoreUI.Libs.Eina)] internal static extern int
        eina_inarray_insert_sorted(IntPtr array, IntPtr data, IntPtr compare);
    [DllImport(CoreUI.Libs.Eina)] internal static extern int
        eina_inarray_remove(IntPtr array, IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inarray_pop(IntPtr array);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inarray_nth(IntPtr array, uint position);
    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_inarray_insert_at(IntPtr array, uint position, IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inarray_alloc_at(IntPtr array, uint position, uint member_count);
    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_inarray_replace_at(IntPtr array, uint position, IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_inarray_remove_at(IntPtr array, uint position);
    [DllImport(CoreUI.Libs.Eina)] internal static extern void
        eina_inarray_reverse(IntPtr array);
    [DllImport(CoreUI.Libs.Eina)] internal static extern void
        eina_inarray_sort(IntPtr array, IntPtr compare);
    [DllImport(CoreUI.Libs.Eina)] internal static extern int
        eina_inarray_search(IntPtr array, IntPtr data, IntPtr compare);
    [DllImport(CoreUI.Libs.Eina)] internal static extern int
        eina_inarray_search_sorted(IntPtr array, IntPtr data, IntPtr compare);
    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_inarray_foreach(IntPtr array, IntPtr function, IntPtr user_data);
    [DllImport(CoreUI.Libs.Eina)] internal static extern int
        eina_inarray_foreach_remove(IntPtr array, IntPtr match, IntPtr user_data);
    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_inarray_resize(IntPtr array, uint new_size);
    [DllImport(CoreUI.Libs.Eina)] internal static extern uint
        eina_inarray_count(IntPtr array);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inarray_iterator_new(IntPtr array);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inarray_iterator_reversed_new(IntPtr array);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inarray_accessor_new(IntPtr array);
}

/// <summary>Wrapper around an inplace array.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
                 Justification="This is a generalized container mapping the native one.")]
public class Inarray<T> : IEnumerable<T>, IDisposable
{
    public const uint DefaultStep = 0;
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IntPtr Handle {get;set;} = IntPtr.Zero;
    /// <summary>Whether this wrapper owns the native buffer.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public bool Own {get;set;}
    /// <summary>Who is in charge of releasing the resources wrapped by
    /// this instance.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public bool OwnContent {get;set;}
    /// <summary> Length of the array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public int Length
    {
        get { return Count(); }
    }


    private void InitNew(uint step)
    {
        Handle = EinaInarrayNew<T>(step);
        Own = true;
        OwnContent = true;
        if (Handle == IntPtr.Zero)
        {
            throw new SEHException("Could not alloc inarray");
        }
    }

    /// <summary>
    ///   Default constructor
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public Inarray()
    {
        InitNew(DefaultStep);
    }

    /// <summary>
    ///   Constructor with step.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="step">Step size of the array.</param>
    public Inarray(uint step)
    {
        InitNew(step);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Inarray(IntPtr handle, bool own)
    {
        Handle = handle;
        Own = own;
        OwnContent = own;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Inarray(IntPtr handle, bool own, bool ownContent)
    {
        Handle = handle;
        Own = own;
        OwnContent = ownContent;
    }

    /// <summary>
    ///   Finalizer to be called from the Garbage Collector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    ~Inarray()
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
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        if (h == IntPtr.Zero)
        {
            return;
        }

        if (OwnContent)
        {
            uint len = eina_inarray_count(h);
            for (uint i = 0; i < len; ++i)
            {
                NativeFreeInplace<T>(eina_inarray_nth(h, i));
            }
        }

        if (Own)
        {
            if (disposing)
            {
                eina_inarray_free(h);
            }
            else
            {
                CoreUI.Wrapper.Globals.ThreadSafeFreeCbExec(eina_inarray_free, h);
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
    ///   Releases the native array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The native array.</returns>
    public IntPtr Release()
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        return h;
    }

    private void FreeElementsIfOwned()
    {
        if (OwnContent)
        {
            int len = Length;
            for (int i = 0; i < len; ++i)
            {
                NativeFreeInplace<T>(eina_inarray_nth(Handle, (uint)i));
            }
        }
    }

    /// <summary>
    ///   Removes every member from the array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Flush()
    {
        FreeElementsIfOwned();
        eina_inarray_flush(Handle);
    }

    /// <summary>
    ///   Counts the number of members in an array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>THe number of members in the array.</returns>
    public int Count()
    {
        return (int)eina_inarray_count(Handle);
    }

    /// <summary>Sets all ownership.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="ownAll">If the hash own for all ownerships.</param>
    public void SetOwnership(bool ownAll)
    {
        Own = ownAll;
        OwnContent = ownAll;
    }

    /// <summary>Sets own individually.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="own">If own the object.</param>
    /// <param name="ownContent">If own the content's object.</param>
    public void SetOwnership(bool own, bool ownContent)
    {
        Own = own;
        OwnContent = ownContent;
    }


    /// <summary>
    ///   Puts the value as the last member of the array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val">The value to be pushed.</param>
    /// <returns>The index of the new member, otherwise -1 on errors.</returns>
    public int Push(T val)
    {
        IntPtr ele = IntPtr.Zero;
        GCHandle gch = GCHandle.Alloc(ele, GCHandleType.Pinned);
        IntPtr ind = gch.AddrOfPinnedObject();

        ManagedToNativeCopyTo(val, ind);

        var r = eina_inarray_push(Handle, ind);
        if (r == -1)
        {
            NativeFreeInplace<T>(ele);
        }

        ResidueFreeInplace<T>(ele);
        gch.Free();
        return r;
    }

// TODO ???
//     public void Add(T val)
//     {
//         if (!Push(val))
//         {
//             throw;
//         }
//     }

    /// <summary>
    ///   Removes the last member of the array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The data poppep out of the array.</returns>
    public T Pop()
    {
        IntPtr ele = eina_inarray_pop(Handle);
        var r = NativeToManagedInplace<T>(ele);
        if (OwnContent && ele != IntPtr.Zero)
        {
            NativeFreeInplace<T>(ele);
        }

        return r;
    }

    /// <summary>
    ///   Gets the member at the given position.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">The member position.</param>
    /// <returns>The element of the given position.</returns>
    public T Nth(uint idx)
    {
        IntPtr ele = eina_inarray_nth(Handle, idx);
        return NativeToManagedInplace<T>(ele);
    }

    /// <summary>
    ///   Gets the member at the given position.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">The member position.</param>
    /// <returns>The element of the given position.</returns>
    public T At(int idx)
    {
        return Nth((uint)idx);
    }

    /// <summary>
    ///   Inserts the value at the given position in the array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">The position to insert the member at.</param>
    /// <param name="val">The value to be inserted.</param>
    /// <returns> true on success, false on failure.</returns>
    public bool InsertAt(uint idx, T val)
    {
        IntPtr ele = IntPtr.Zero;
        GCHandle gch = GCHandle.Alloc(ele, GCHandleType.Pinned);
        IntPtr ind = gch.AddrOfPinnedObject();

        ManagedToNativeCopyTo(val, ind);

        var r = eina_inarray_insert_at(Handle, idx, ind);
        if (!r)
        {
            NativeFreeInplace<T>(ele);
        }

        ResidueFreeInplace<T>(ele);
        return r;
    }

    /// <summary>
    ///   Replaces the value at the given position.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">The position to replace the member at.</param>
    /// <param name="val">The value to replace.</param>
    public bool ReplaceAt(uint idx, T val)
    {
        var old = eina_inarray_nth(Handle, idx);
        if (old == IntPtr.Zero)
        {
            return false;
        }

        if (OwnContent)
        {
            NativeFreeInplace<T>(old);
        }

        var ele = IntPtr.Zero;
        GCHandle gch = GCHandle.Alloc(ele, GCHandleType.Pinned);
        IntPtr ind = gch.AddrOfPinnedObject();

        ManagedToNativeCopyTo(val, ind);

        var r = eina_inarray_replace_at(Handle, idx, ind);
        ResidueFreeInplace<T>(ele);
        return r;
    }

    ///  <summary> Accessor by index to the elements of this list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public T this[int idx]
    {
        get
        {
            return At(idx);
        }
        set
        {
            ReplaceAt((uint)idx, value);
        }
    }

    /// <summary>
    ///   Removes a member from the given position.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">The position to remove the member at.</param>
    /// <returns>true on success, false on failure.</returns>
    public bool RemoveAt(uint idx)
    {
        IntPtr ele = eina_inarray_nth(Handle, idx);
        if (ele == IntPtr.Zero)
        {
            return false;
        }

        if (OwnContent)
        {
            NativeFreeInplace<T>(ele);
        }

        return eina_inarray_remove_at(Handle, idx);
    }

    /// <summary>
    ///   Reverses members in the array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Reverse()
    {
        eina_inarray_reverse(Handle);
    }

    /// <summary>
    ///   Returns a array containing all of the elements in proper sequence.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A array</returns>
    public T[] ToArray()
    {
        int len = Length;
        var managed = new T[len];
        for (int i = 0; i < len; ++i)
        {
            managed[i] = At(i);
        }

        return managed;
    }

    ///  <summary> Appends all elements at the end of array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>true on success, false otherwise.</returns>
    public bool Append(T[] values)
    {
        Contract.Requires(values != null, nameof(values));
        foreach (T v in values)
        {
            if (Push(v) == -1)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary> Gets an Iterator for this Array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Iterator<T> GetIterator()
    {
        return new CoreUI.DataTypes.Iterator<T>(eina_inarray_iterator_new(Handle), true);
    }

    /// <summary> Gets an Iterator for this Array with reversed order.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Iterator<T> GetReversedIterator()
    {
        return new CoreUI.DataTypes.Iterator<T>(eina_inarray_iterator_reversed_new(Handle), true);
    }

    /// <summary> Gets an Enumerator for this Array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public IEnumerator<T> GetEnumerator()
    {
        int len = Length;
        for (int i = 0; i < len; ++i)
        {
            yield return At(i);
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary> Gets an Accessor for this Array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Accessor<T> GetAccessor()
    {
        return new CoreUI.DataTypes.AccessorInArray<T>(eina_inarray_accessor_new(Handle), Ownership.Managed);
    }
}

}

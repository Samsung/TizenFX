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
using static CoreUI.DataTypes.InlistNativeFunctions;
using CoreUI.DataTypes.Callbacks;

namespace CoreUI.DataTypes
{

[EditorBrowsable(EditorBrowsableState.Never)]
internal static class InlistNativeFunctions
{
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inlist_append(IntPtr in_list, IntPtr in_item);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inlist_prepend(IntPtr in_list, IntPtr in_item);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inlist_append_relative(IntPtr in_list, IntPtr in_item, IntPtr in_relative);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inlist_prepend_relative(IntPtr in_list, IntPtr in_item, IntPtr in_relative);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inlist_remove(IntPtr in_list, IntPtr in_item);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inlist_find(IntPtr in_list, IntPtr in_item);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inlist_promote(IntPtr list, IntPtr item);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inlist_demote(IntPtr list, IntPtr item);

    [DllImport(CoreUI.Libs.Eina)] internal static extern uint
        eina_inlist_count(IntPtr list);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inlist_iterator_new(IntPtr in_list);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inlist_accessor_new(IntPtr in_list);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inlist_sorted_insert(IntPtr list, IntPtr item, IntPtr func);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inlist_sorted_state_new();

    [DllImport(CoreUI.Libs.Eina)] internal static extern int
        eina_inlist_sorted_state_init(IntPtr state, IntPtr list);

    [DllImport(CoreUI.Libs.Eina)] internal static extern void
        eina_inlist_sorted_state_free(IntPtr state);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inlist_sorted_state_insert(IntPtr list, IntPtr item, IntPtr func, IntPtr state);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_inlist_sort(IntPtr head, IntPtr func);


    [DllImport(CoreUI.Libs.CustomExports)] internal static extern IntPtr
        eina_inlist_first_custom_export_mono(IntPtr list);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern IntPtr
        eina_inlist_last_custom_export_mono(IntPtr list);


    [DllImport(CoreUI.Libs.CustomExports)] internal static extern IntPtr
        eina_inlist_next_custom_export_mono(IntPtr list);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern IntPtr
        eina_inlist_prev_custom_export_mono(IntPtr list);

    [DllImport(CoreUI.Libs.CustomExports)] internal static extern IntPtr
        eina_inlist_iterator_wrapper_new_custom_export_mono(IntPtr in_list);
}

/// <summary>Wrapper around an inplace list.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
                 Justification="This is a generalized container mapping the native one.")]
public class Inlist<T> : IEnumerable<T>, IDisposable
{
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

    public int Length
    {
        get { return Count(); }
    }


    private void InitNew()
    {
        Handle = IntPtr.Zero;
        Own = true;
        OwnContent = true;
    }

    private IntPtr InternalFirst()
    {
        return eina_inlist_first_custom_export_mono(Handle);
    }

    private IntPtr InternalLast()
    {
        return eina_inlist_last_custom_export_mono(Handle);
    }

    private IntPtr InternalAt(int idx)
    {
        if (idx < 0)
        {
            return IntPtr.Zero;
        }

        IntPtr curr = Handle;
        for (int n = 0; n != idx && curr != IntPtr.Zero; ++n)
        {
            curr = InternalNext(curr);
        }

        return curr;
    }

    private static IntPtr InternalNext(IntPtr inlist)
    {
        return eina_inlist_next_custom_export_mono(inlist);
    }

    private static IntPtr InternalPrev(IntPtr inlist)
    {
        return eina_inlist_prev_custom_export_mono(inlist);
    }


    /// <summary>
    ///   Default constructor.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public Inlist()
    {
        InitNew();
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Inlist(IntPtr handle, bool own)
    {
        Handle = handle;
        Own = own;
        OwnContent = own;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Inlist(IntPtr handle, bool own, bool ownContent)
    {
        Handle = handle;
        Own = own;
        OwnContent = ownContent;
    }

    /// <summary>
    ///   Finalizer to be called from the Garbage Collector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    ~Inlist()
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
            for (IntPtr curr = h; curr != IntPtr.Zero; curr = InternalNext(curr))
            {
                NativeFreeInlistNodeElement<T>(curr);
            }
        }

        if (Own)
        {
            while (h != IntPtr.Zero)
            {
                var aux = h;
                h = eina_inlist_remove(h, h);
                NativeFreeInlistNode<T>(aux, false);
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
    ///   Releases the native inlist.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The native inlist.</returns>
    public IntPtr Release()
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        return h;
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
    ///   Gets the count of the number of items.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The number of members in the list.</returns>
    public int Count()
    {
        return (int)eina_inlist_count(Handle);
    }

    /// <summary>
    ///   Cleanup the inlist.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Clean()
    {
        while (Handle != IntPtr.Zero)
        {
            var aux = Handle;
            Handle = eina_inlist_remove(Handle, Handle);
            NativeFreeInlistNode<T>(aux, OwnContent);
        }
    }

    /// <summary>
    ///   Adds a new value to the end.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val">The value to be added.</param>
    public void Append(T val)
    {
        IntPtr node = ManagedToNativeAllocInlistNode(val);
        Handle = eina_inlist_append(Handle, node);
    }

    /// <summary>
    ///   Adds a new value to the begin.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val">The value to be added.</param>
    public void Prepend(T val)
    {
        IntPtr node = ManagedToNativeAllocInlistNode(val);
        Handle = eina_inlist_prepend(Handle, node);
    }

    /// <summary>
    ///   Removes value at the specified position from list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">The given position.</param>
    public void Remove(int idx)
    {
        IntPtr node = InternalAt(idx);
        Handle = eina_inlist_remove(Handle, node);
        NativeFreeInlistNode<T>(node, OwnContent);
    }

    /// <summary>
    ///   Returns the element of the list at the specified position.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">The position of the desired element.</param>
    /// <returns>The element at the specified position</returns>
    public T At(int idx)
    {
        IntPtr node = InternalAt(idx);
        if (node == IntPtr.Zero)
        {
            throw new IndexOutOfRangeException();
        }

        return NativeToManagedInlistNode<T>(node);
    }

    /// <summary>
    ///  Replaces the element at the specified position.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">The position of the desired element.</param>
    /// <param name="val">The value of the element to be inserted.</param>
    public void DataSet(int idx, T val)
    {
        IntPtr old = InternalAt(idx);
        if (old == IntPtr.Zero)
        {
            throw new IndexOutOfRangeException();
        }

        IntPtr new_node = ManagedToNativeAllocInlistNode(val);

        Handle = eina_inlist_append_relative(Handle, new_node, old);
        Handle = eina_inlist_remove(Handle, old);

        NativeFreeInlistNode<T>(old, OwnContent);
    }

    /// <summary>
    ///   Accessor by index to the elements of this list.
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
            DataSet(idx, value);
        }
    }

    
    /// <summary>
    ///   Returns a array containing all of the elements in proper sequence.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A array</returns>
    public T[] ToArray()
    {
        var managed = new T[Count()];
        int i = 0;
        for (IntPtr curr = Handle; curr != IntPtr.Zero; ++i, curr = InternalNext(curr))
        {
            managed[i] = NativeToManagedInlistNode<T>(curr);
        }

        return managed;
    }

    /// <summary>
    ///   Adds a array to the end.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="values">The values to be added.</param>
    public void AppendArray(T[] values)
    {
        Contract.Requires(values != null, nameof(values));
        foreach (T v in values)
        {
            Append(v);
        }
    }

    
    /// <summary> Gets an Iterator for this list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Iterator<T> GetIterator()
    {
        return new CoreUI.DataTypes.Iterator<T>(eina_inlist_iterator_wrapper_new_custom_export_mono(Handle), true);
    }

    /// <summary> Gets an Enumerator for this list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public IEnumerator<T> GetEnumerator()
    {
        for (IntPtr curr = Handle; curr != IntPtr.Zero; curr = InternalNext(curr))
        {
            yield return NativeToManagedInlistNode<T>(curr);
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary> Gets an Accessor for this List.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Accessor<T> GetAccessor()
    {
        return new CoreUI.DataTypes.AccessorInList<T>(eina_inlist_accessor_new(Handle), Ownership.Managed);
    }
}

}

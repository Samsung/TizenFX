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
using static CoreUI.DataTypes.ListNativeFunctions;
using CoreUI.DataTypes.Callbacks;

namespace CoreUI.DataTypes
{

[EditorBrowsable(EditorBrowsableState.Never)]
internal static class ListNativeFunctions
{
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_append(IntPtr list, IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_prepend(IntPtr list, IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_append_relative(IntPtr list, IntPtr data, IntPtr relative);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_append_relative_list(IntPtr list, IntPtr data, IntPtr relative);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_prepend_relative(IntPtr list, IntPtr data, IntPtr relative);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_prepend_relative_list(IntPtr list, IntPtr data, IntPtr relative);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_sorted_insert(IntPtr list, IntPtr func, IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_remove(IntPtr list, IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_remove_list(IntPtr list, IntPtr remove_list);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_promote_list(IntPtr list, IntPtr move_list);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_demote_list(IntPtr list, IntPtr move_list);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_data_find(IntPtr list, IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_data_find_list(IntPtr list, IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_list_move(ref IntPtr to, ref IntPtr from, IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_list_move_list(ref IntPtr to, ref IntPtr from, IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_free(IntPtr list);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern void
        efl_mono_thread_safe_eina_list_free(IntPtr list);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_nth(IntPtr list, uint n);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_nth_list(IntPtr list, uint n);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_reverse(IntPtr list);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_reverse_clone(IntPtr list);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_clone(IntPtr list);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_sort(IntPtr list, uint limit, IntPtr func);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_shuffle(IntPtr list, IntPtr func);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_merge(IntPtr left, IntPtr right);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_sorted_merge(IntPtr left, IntPtr right, IntPtr func);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_split_list(IntPtr list, IntPtr relative, ref IntPtr right);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_search_sorted_near_list(IntPtr list, IntPtr func, IntPtr data, IntPtr result_cmp);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_search_sorted_list(IntPtr list, IntPtr func, IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_search_sorted(IntPtr list, IntPtr func, IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_search_unsorted_list(IntPtr list, IntPtr func, IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_search_unsorted(IntPtr list, IntPtr func, IntPtr data);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_iterator_new(IntPtr list);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_iterator_reversed_new(IntPtr list);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_list_accessor_new(IntPtr list);
    [DllImport(CoreUI.Libs.Eina)] internal static extern int
        eina_list_data_idx(IntPtr list, IntPtr data);


    [DllImport(CoreUI.Libs.CustomExports)] internal static extern IntPtr
        eina_list_last_custom_export_mono(IntPtr list);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern IntPtr
        eina_list_next_custom_export_mono(IntPtr list);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern IntPtr
        eina_list_prev_custom_export_mono(IntPtr list);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern IntPtr
        eina_list_data_get_custom_export_mono(IntPtr list);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern IntPtr
        eina_list_data_set_custom_export_mono(IntPtr list, IntPtr data);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern uint
        eina_list_count_custom_export_mono(IntPtr list);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern IntPtr
        eina_list_last_data_get_custom_export_mono(IntPtr list);
}

/// <summary>Native wrapper around a linked list of items.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
                 Justification="This is a generalized container mapping the native one.")]
public class List<T> : IList<T>, IEnumerable<T>, IDisposable
{

    [EditorBrowsable(EditorBrowsableState.Never)]
    public IntPtr Handle {get; set; } = IntPtr.Zero;

    /// <summary>Whether this managed list owns the native one.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    internal bool Own { get; set; }

    /// <summary>Whether the native list wrapped owns the content it points to.
    ///</summary>
    /// <since_tizen> 6 </since_tizen>
    internal bool OwnContent { get; set; }


    /// <summary>Delegate for comparing two elements of this list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="a">First element.</param>
    /// <param name="b">Second element.</param>
    /// <returns>-1, 0 or 1 for respectively smaller, equal or larger.</returns>
    public delegate int Compare(T a, T b);

    public bool IsReadOnly { get => !OwnContent; }

    /// <summary>The number of elements in this list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public int Count
    {
        get => (int)eina_list_count_custom_export_mono(Handle);
    }

    private void InitNew()
    {
        Handle = IntPtr.Zero;
        Own = true;
        OwnContent = true;
    }

    private IntPtr InternalLast()
        => eina_list_last_custom_export_mono(Handle);

    private static IntPtr InternalNext(IntPtr list)
        => eina_list_next_custom_export_mono(list);

    private static IntPtr InternalPrev(IntPtr list)
        => eina_list_prev_custom_export_mono(list);

    private static IntPtr InternalDataGet(IntPtr list)
        => eina_list_data_get_custom_export_mono(list);

    private static IntPtr InternalDataSet(IntPtr list, IntPtr data)
        => eina_list_data_set_custom_export_mono(list, data);

    private IntPtr GetNative(int idx, Func<IntPtr, uint, IntPtr> f)
    {
        if (!(0 <= idx && idx < Count))
        {
            throw new ArgumentOutOfRangeException(nameof(idx), $"{nameof(idx)} cannot be negative, neither smaller than {nameof(Count)}");
        }

        var ele = f(Handle, (uint)idx);
        if (ele == IntPtr.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(idx), $"There is no position {nameof(idx)}");
        }

        return ele;
    }

    private IntPtr GetNativeDataPointer(int idx)
        => GetNative(idx, eina_list_nth);

    private IntPtr GetNativePointer(int idx)
        => GetNative(idx, eina_list_nth_list);

    private void RequireWritable()
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException("Cannot modify read-only container.");
        }
    }

    private void CheckOwnerships()
    {
        if ((Own == false) && (OwnContent == true))
        {
            throw new InvalidOperationException(nameof(Own) + "/" + nameof(OwnContent));
        }
    }

    private void DeleteData(IntPtr ele)
    {
        if (OwnContent)
        {
            NativeFree<T>(InternalDataGet(ele));
        }
    }

    private U LoopingThrough<U>(T val, Func<int, U> f1, Func<U> f2)
    {
        int i = 0;
        IntPtr cur = Handle;
        for (; cur != IntPtr.Zero; ++i, cur = InternalNext(cur))
        {
            if (NativeToManaged<T>(InternalDataGet(cur)).Equals(val))
            {
                return f1(i);
            }
        }

        return f2();
    }

    /// <summary>Creates a new empty list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public List() => InitNew();

    /// <summary>Creates a new list wrapping the given handle.</summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public List(IntPtr handle, bool own)
    {
        Handle = handle;
        Own = own;
        OwnContent = own;
        CheckOwnerships();
    }

    /// <summary>Creates a new list wrapping the given handle.</summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public List(IntPtr handle, bool own, bool ownContent)
    {
        Handle = handle;
        Own = own;
        OwnContent = ownContent;
        CheckOwnerships();
    }

    /// <summary>Finalizes this list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    ~List() => Dispose(false);

    /// <summary>Disposes of this list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="disposing">Whether this was called from the finalizer (<c>false</c>) or from the
    /// <see cref="Dispose()"/> method.</param>
    protected virtual void Dispose(bool disposing)
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        if (h == IntPtr.Zero)
        {
            return;
        }

        for (IntPtr curr = h; curr != IntPtr.Zero; curr = InternalNext(curr))
        {
            if (!OwnContent)
            {
                break;
            }

            DeleteData(curr);
        }

        if (Own)
        {
            if (disposing)
            {
                eina_list_free(h);
            }
            else
            {
                efl_mono_thread_safe_eina_list_free(h);
            }
        }
    }

    /// <summary>Disposes of this list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Disposes of this list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Free() => Dispose();

    /// <summary>Sets whether this wrapper should own the native list or not.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="ownAll">If the hash own for all ownerships.</param>
    internal void SetOwnership(bool ownAll)
    {
        Own = ownAll;
        OwnContent = ownAll;
        CheckOwnerships();
    }

    /// <summary>Sets whether this wrapper should own the native list and
    /// its content or not.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="own">If own the object.</param>
    /// <param name="ownContent">If own the content's object.</param>
    internal void SetOwnership(bool own, bool ownContent)
    {
        Own = own;
        OwnContent = ownContent;
        CheckOwnerships();
    }

    /// <summary>Appends <c>val</c> to the list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val">The item to be appended.</param>
    public void Append(T val)
    {
        RequireWritable();

        Handle = eina_list_append(Handle, ManagedToNativeAlloc(val));
    }

    /// <summary>Prepends <c>val</c> to the list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val">The item to be prepended.</param>
    public void Prepend(T val)
    {
        RequireWritable();

        Handle = eina_list_prepend(Handle, ManagedToNativeAlloc(val));
    }

    /// <summary>Inserts <c>val</c> in the list in a sorted manner.
    /// It presumes the list is already sorted.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val">The item to be inserted.</param>
    public void SortedInsert(T val)
    {
        RequireWritable();

        Handle = eina_list_sorted_insert(Handle,
                                EinaCompareCb<T>(),
                                ManagedToNativeAlloc(val));
    }

    /// <summary>Inserts <c>val</c> in the list in a sorted manner with the
    /// given <c>compareCb</c> for element comparison.
    /// It presumes the list is already sorted.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="compareCb">The function to compare two elements of the list.</param>
    /// <param name="val">The item to be inserted.</param>
    public void SortedInsert(Compare compareCb, T val)
    {
        RequireWritable();

        Handle = eina_list_sorted_insert(Handle,
                                         Marshal.GetFunctionPointerForDelegate(GetNativeCompareCb(compareCb)),
                                         ManagedToNativeAlloc(val));
    }

    /// <summary>Sorts <c>limit</c> elements in this list inplace.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="limit">The max number of elements to be sorted.</param>
    public void Sort(int limit = 0)
    {
        RequireWritable();

        Handle = eina_list_sort(Handle, (uint)limit, EinaCompareCb<T>());
    }

    /// <summary>Sorts all elements in this list inplace.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="compareCb">The function to compare two elements of the list.</param>
    public void Sort(Compare compareCb)
    {
        RequireWritable();

        Handle = eina_list_sort(Handle, (uint)0,
                                Marshal.GetFunctionPointerForDelegate(GetNativeCompareCb(compareCb)));
    }

    /// <summary>Sorts <c>limit</c> elements in this list inplace.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="limit">The max number of elements to be sorted.</param>
    /// <param name="compareCb">The function to compare two elements of the list.</param>
    public void Sort(int limit, Compare compareCb)
    {
        RequireWritable();

        Handle = eina_list_sort(Handle, (uint)limit,
                                Marshal.GetFunctionPointerForDelegate(GetNativeCompareCb(compareCb)));
    }

    private CoreUI.DataTypes.Callbacks.EinaCompareCb GetNativeCompareCb(Compare managedCb)
        => (IntPtr a, IntPtr b)
        => managedCb(NativeToManaged<T>(a), NativeToManaged<T>(b));
    

    /// <summary>Returns the <c>n</c>th element of this list. Due to marshalling details, the returned element
    /// may be a different C# object from the one you used to append.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="n">The 0-based index to be retrieved.</param>
    /// <returns>The value in the specified element.</returns>
    public T Nth(int n) => NativeToManaged<T>(GetNativeDataPointer(n));

    /// <summary>Sets the data at the <c>idx</c> position.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">The 0-based index to be set.</param>
    /// <param name="val">The value to be inserted.</param>
    internal void DataSet(int idx, T val)
    {
        RequireWritable();

        IntPtr pos = GetNativePointer(idx);
        DeleteData(pos);
        InternalDataSet(pos, ManagedToNativeAlloc(val));
    }

    /// <summary>Accessor for the data at the <c>idx</c> position.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">The 0-based index to be get/set.</param>
    public T this[int idx]
    {
        get
        {
            return Nth(idx);
        }
        set
        {
            DataSet(idx, value);
        }
    }

    /// <summary>Returns the data at the last list element.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The value contained in the last list position.</returns>
    public T LastDataGet()
        => NativeToManaged<T>(eina_list_last_data_get_custom_export_mono(Handle));

    /// <summary>Reverses this list in place.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A reference to this object.</returns>
    public List<T> Reverse()
    {
        RequireWritable();

        Handle = eina_list_reverse(Handle);
        return this;
    }

    /// <summary>Randomly shuffles this list in place.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Shuffle()
    {
        RequireWritable();

        Handle = eina_list_shuffle(Handle, IntPtr.Zero);
    }

    /// <summary>Gets a C# array of the elements in this list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A managed array of the elements.</returns>
    public T[] ToArray()
    {
        var managed = new T[Count];
        int i = 0;
        for (IntPtr curr = Handle; curr != IntPtr.Zero;
             curr = InternalNext(curr), ++i)
        {
            managed[i] = NativeToManaged<T>(InternalDataGet(curr));
        }

        return managed;
    }

    /// <summary>Appends the given array of elements to this list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="values">The values to be appended.</param>
    public void Append(T[] values)
    {
        Contract.Requires(values != null, nameof(values));
        RequireWritable();

        foreach (T v in values)
        {
            Append(v);
        }
    }


    /// <summary>Gets an iterator that iterates this list in normal order.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The iterator.</returns>
    public CoreUI.DataTypes.Iterator<T> GetIterator()
        => new CoreUI.DataTypes.Iterator<T>(eina_list_iterator_new(Handle), true);

    /// <summary>Gets an iterator that iterates this list in reverse order.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The iterator.</returns>
    public CoreUI.DataTypes.Iterator<T> GetReversedIterator()
        => new CoreUI.DataTypes.Iterator<T>(eina_list_iterator_reversed_new(Handle), true);

    /// <summary>Gets an enumerator into this list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The enumerator.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        for (IntPtr curr = Handle; curr != IntPtr.Zero; curr = InternalNext(curr))
        {
            yield return NativeToManaged<T>(InternalDataGet(curr));
        }
    }

    /// <summary>Gets an enumerator into this list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The enumerator.</returns>
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        => this.GetEnumerator();

    /// <summary> Gets an Accessor for this List.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The accessor.</returns>
    public CoreUI.DataTypes.Accessor<T> GetAccessor()
        => new CoreUI.DataTypes.Accessor<T>(eina_list_accessor_new(Handle),
                                Ownership.Managed);

    /// <summary>
    ///   Removes the first occurrence of a specific object.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val">The object to remove.</param>
    public bool Remove(T val)
    {
        RequireWritable();

        var prev_count = Count;
        var deleted = LoopingThrough(val,
                                 (i) =>
        {
            RemoveAt(i);
            return true;
        },
                                 () => false);

        return deleted && (prev_count - 1 == Count);
    }

    /// <summary>
    ///   Adds an item.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val">The object to add.</param>
    public void Add(T val) => Append(val);

    /// <summary>
    ///   Removes all items.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Clear()
    {
        RequireWritable();
        
        for (; Handle != IntPtr.Zero;)
        {
            Handle = eina_list_remove_list(Handle, Handle);
        }
    }

    /// <summary>
    ///   Determines whether the <see cref="List{T}" /> contains a specific value.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val">The object to locate.</param>
    public bool Contains(T val)
        => LoopingThrough(val, (i) => true, () => false);

    /// <summary>
    ///   Determines the index of a specific item.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val">The object to locate.</param>
    public int IndexOf(T val)
        => LoopingThrough(val, (i) => i, () => -1);

    /// <summary>
    ///   Inserts an item to the <see cref="List{T}" /> at the specified index.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">The zero-based index at which item should be inserted.</param>
    /// <param name="val">The object to insert.</param>
    public void Insert(int idx, T val)
    {
        RequireWritable();

        if (idx == 0)
        {
            Prepend(val);
            return;
        }

        if (idx == Count)
        {
            Append(val);
            return;
        }

        if (idx < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(idx), $"{nameof(idx)} cannot be negative.");
        }

        if (Count < idx)
        {
            throw new ArgumentOutOfRangeException(nameof(idx), $"{nameof(idx)} cannot be greater than {nameof(Count)} + 1.");
        }

        Handle = eina_list_prepend_relative_list(Handle, ManagedToNativeAlloc(val),
                                        GetNativePointer(idx));
    }

    /// <summary>
    ///   Removes the <see cref="List{T}" /> item at the specified index.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">The zero-based index of the item to remove.</param>
    public void RemoveAt(int idx)
    {
        RequireWritable();

        var ele = GetNativePointer(idx);
        DeleteData(ele);
        Handle = eina_list_remove_list(Handle, ele);
    }

    /// <summary>
    ///   Copies the elements of the <see cref="List{T}" /> to an
    /// <see cref="Array" />, starting at a particular <see cref="Array" /> index.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="array">The one-dimensional <see cref="Array" /> that is the
    /// destination of the elements copied from <see cref="List{T}" />.
    /// The <see cref="Array" /> must have zero-based indexing.</param>
    /// <param name="arrayIndex">The zero-based index in array at which copying
    /// begins.</param>
    public void CopyTo(T[] array, int arrayIndex)
        => ToArray().CopyTo(array, arrayIndex);
}

}

#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;

using static UIKit.DataTypes.TraitFunctions;
using static UIKit.DataTypes.ListNativeFunctions;
using UIKit.DataTypes.Callbacks;

namespace UIKit
{

namespace DataTypes
{

[EditorBrowsable(EditorBrowsableState.Never)]
public static class ListNativeFunctions
{
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_append(IntPtr list, IntPtr data);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_prepend(IntPtr list, IntPtr data);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_append_relative(IntPtr list, IntPtr data, IntPtr relative);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_append_relative_list(IntPtr list, IntPtr data, IntPtr relative);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_prepend_relative(IntPtr list, IntPtr data, IntPtr relative);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_prepend_relative_list(IntPtr list, IntPtr data, IntPtr relative);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_sorted_insert(IntPtr list, IntPtr func, IntPtr data);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_remove(IntPtr list, IntPtr data);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_remove_list(IntPtr list, IntPtr remove_list);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_promote_list(IntPtr list, IntPtr move_list);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_demote_list(IntPtr list, IntPtr move_list);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_data_find(IntPtr list, IntPtr data);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_data_find_list(IntPtr list, IntPtr data);
    [DllImport(UIKit.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_list_move(ref IntPtr to, ref IntPtr from, IntPtr data);
    [DllImport(UIKit.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_list_move_list(ref IntPtr to, ref IntPtr from, IntPtr data);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_free(IntPtr list);
    [DllImport(UIKit.Libs.CustomExports)] public static extern void
        efl_mono_thread_safe_eina_list_free(IntPtr list);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_nth(IntPtr list, uint n);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_nth_list(IntPtr list, uint n);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_reverse(IntPtr list);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_reverse_clone(IntPtr list);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_clone(IntPtr list);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_sort(IntPtr list, uint limit, IntPtr func);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_shuffle(IntPtr list, IntPtr func);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_merge(IntPtr left, IntPtr right);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_sorted_merge(IntPtr left, IntPtr right, IntPtr func);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_split_list(IntPtr list, IntPtr relative, ref IntPtr right);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_search_sorted_near_list(IntPtr list, IntPtr func, IntPtr data, IntPtr result_cmp);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_search_sorted_list(IntPtr list, IntPtr func, IntPtr data);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_search_sorted(IntPtr list, IntPtr func, IntPtr data);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_search_unsorted_list(IntPtr list, IntPtr func, IntPtr data);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_search_unsorted(IntPtr list, IntPtr func, IntPtr data);

    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_iterator_new(IntPtr list);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_iterator_reversed_new(IntPtr list);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_list_accessor_new(IntPtr list);
    [DllImport(UIKit.Libs.Eina)] public static extern int
        eina_list_data_idx(IntPtr list, IntPtr data);


    [DllImport(UIKit.Libs.CustomExports)] public static extern IntPtr
        eina_list_last_custom_export_mono(IntPtr list);
    [DllImport(UIKit.Libs.CustomExports)] public static extern IntPtr
        eina_list_next_custom_export_mono(IntPtr list);
    [DllImport(UIKit.Libs.CustomExports)] public static extern IntPtr
        eina_list_prev_custom_export_mono(IntPtr list);
    [DllImport(UIKit.Libs.CustomExports)] public static extern IntPtr
        eina_list_data_get_custom_export_mono(IntPtr list);
    [DllImport(UIKit.Libs.CustomExports)] public static extern IntPtr
        eina_list_data_set_custom_export_mono(IntPtr list, IntPtr data);
    [DllImport(UIKit.Libs.CustomExports)] public static extern uint
        eina_list_count_custom_export_mono(IntPtr list);
    [DllImport(UIKit.Libs.CustomExports)] public static extern IntPtr
        eina_list_last_data_get_custom_export_mono(IntPtr list);
}

/// <summary>Native wrapper around a linked list of items.
///
/// Since EFL 1.23.
/// </summary>
public class List<T> : IEnumerable<T>, IDisposable
{

    [EditorBrowsable(EditorBrowsableState.Never)]
    public IntPtr Handle {get;set;} = IntPtr.Zero;
    /// <summary>Whether this managed list owns the native one.</summary>
    public bool Own {get;set;}
    /// <summary>Whether the native list wrapped owns the content it points to.</summary>
    public bool OwnContent {get;set;}

    /// <summary>Delegate for comparing two elements of this list.</summary>
    /// <returns>-1, 0 or 1 for respectively smaller, equal or larger.</returns>
    public delegate int Compare(T a, T b);

    /// <summary>The number of elements on this list.</summary>
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

    private IntPtr InternalLast()
    {
        return eina_list_last_custom_export_mono(Handle);
    }

    private static IntPtr InternalNext(IntPtr list)
    {
        return eina_list_next_custom_export_mono(list);
    }

    private static IntPtr InternalPrev(IntPtr list)
    {
        return eina_list_prev_custom_export_mono(list);
    }

    private static IntPtr InternalDataGet(IntPtr list)
    {
        return eina_list_data_get_custom_export_mono(list);
    }

    private static IntPtr InternalDataSet(IntPtr list, IntPtr data)
    {
        return eina_list_data_set_custom_export_mono(list, data);
    }


    /// <summary>Creates a new empty list.</summary>
    public List()
    {
        InitNew();
    }

    /// <summary>Creates a new list wrapping the given handle.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public List(IntPtr handle, bool own)
    {
        Handle = handle;
        Own = own;
        OwnContent = own;
    }

    /// <summary>Creates a new list wrapping the given handle.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public List(IntPtr handle, bool own, bool ownContent)
    {
        Handle = handle;
        Own = own;
        OwnContent = ownContent;
    }

    /// <summary>Finalizes this list.</summary>
    ~List()
    {
        Dispose(false);
    }

    /// <summary>Disposes of this list.</summary>
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

        if (Own && OwnContent)
        {
            for (IntPtr curr = h; curr != IntPtr.Zero; curr = InternalNext(curr))
            {
                NativeFree<T>(InternalDataGet(curr));
            }
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

    /// <summary>Disposes of this list.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Disposes of this list.</summary>
    public void Free()
    {
        Dispose();
    }

    /// <summary>Relinquishes of the native list.</summary>
    /// <returns>The previously wrapped native list handle.</returns>
    public IntPtr Release()
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        return h;
    }

    /// <summary>Sets whether this wrapper should own the native list or not.</summary>
    public void SetOwnership(bool ownAll)
    {
        Own = ownAll;
        OwnContent = ownAll;
    }

    /// <summary>Sets whether this wrapper should own the native list and its content or not.</summary>
    public void SetOwnership(bool own, bool ownContent)
    {
        Own = own;
        OwnContent = ownContent;
    }

    /// <summary>Returns the number of elements in this list.</summary>
    public int Count()
    {
        return (int)eina_list_count_custom_export_mono(Handle);
    }

    /// <summary>Appends <c>val</c> to the list.</summary>
    /// <param name="val">The item to be appended.</param>
    public void Append(T val)
    {
        IntPtr ele = ManagedToNativeAlloc(val);
        Handle = eina_list_append(Handle, ele);
    }

    /// <summary>Prepends <c>val</c> to the list.</summary>
    /// <param name="val">The item to be prepended.</param>
    public void Prepend(T val)
    {
        IntPtr ele = ManagedToNativeAlloc(val);
        Handle = eina_list_prepend(Handle, ele);
    }

    /// <summary>Inserts <c>val</c> in the list in a sorted manner. It presumes the list is already sorted.</summary>
    /// <param name="val">The item to be inserted.</param>
    public void SortedInsert(T val)
    {
        IntPtr ele = ManagedToNativeAlloc(val);
        Handle = eina_list_sorted_insert(Handle, EinaCompareCb<T>(), ele);
    }

    /// <summary>Inserts <c>val</c> in the list in a sorted manner with the given <c>compareCb</c> for element comparison.
    /// It presumes the list is already sorted.</summary>
    /// <param name="compareCb">The function to compare two elements of the list.</param>
    /// <param name="val">The item to be inserted.</param>
    public void SortedInsert(Compare compareCb, T val)
    {
        IntPtr ele = ManagedToNativeAlloc(val);
        Handle = eina_list_sorted_insert(Handle, Marshal.GetFunctionPointerForDelegate(GetNativeCompareCb(compareCb)), ele);
    }

    /// <summary>Sorts <c>limit</c> elements in this list inplace.</summary>
    /// <param name="limit">The max number of elements to be sorted.</param>
    public void Sort(int limit = 0)
    {
        Handle = eina_list_sort(Handle, (uint)limit, EinaCompareCb<T>());
    }

    /// <summary>Sorts all elements in this list inplace.</summary>
    /// <param name="compareCb">The function to compare two elements of the list.</param>
    public void Sort(Compare compareCb)
    {
        Handle = eina_list_sort(Handle, 0, Marshal.GetFunctionPointerForDelegate(GetNativeCompareCb(compareCb)));
    }

    /// <summary>Sorts <c>limit</c> elements in this list inplace.</summary>
    /// <param name="limit">The max number of elements to be sorted.</param>
    /// <param name="compareCb">The function to compare two elements of the list.</param>
    public void Sort(int limit, Compare compareCb)
    {
        Handle = eina_list_sort(Handle, (uint)limit, Marshal.GetFunctionPointerForDelegate(GetNativeCompareCb(compareCb)));
    }

    private UIKit.DataTypes.Callbacks.EinaCompareCb GetNativeCompareCb(Compare managedCb)
    {
        return (IntPtr a, IntPtr b) => {
            return managedCb(NativeToManaged<T>(a), NativeToManaged<T>(b));
        };
    }

    /// <summary>Returns the <c>n</c>th element of this list. Due to marshalling details, the returned element
    /// may be a different C# object from the one you used to append.</summary>
    /// <param name="n">The 0-based index to be retrieved.</param>
    public T Nth(int n)
    {
        // TODO: check bounds ???
        IntPtr ele = eina_list_nth(Handle, (uint)n);
        return NativeToManaged<T>(ele);
    }

    /// <summary>Sets the data at the <c>idx</c> position.</summary>
    /// <param name="idx">The 0-based index to be set.</param>
    /// <param name="val">The value to be inserted.</param>
    public void DataSet(int idx, T val)
    {
        IntPtr pos = eina_list_nth_list(Handle, (uint)idx);
        if (pos == IntPtr.Zero)
        {
            throw new IndexOutOfRangeException();
        }

        if (OwnContent)
        {
            NativeFree<T>(InternalDataGet(pos));
        }

        IntPtr ele = ManagedToNativeAlloc(val);
        InternalDataSet(pos, ele);
    }

    /// <summary>Accessor for the data at the <c>idx</c> position.</summary>
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

    /// <summary>Returns the data at the last list element.</summary>
    /// <returns>The value contained in the last list position.</returns>
    public T LastDataGet()
    {
        IntPtr ele = eina_list_last_data_get_custom_export_mono(Handle);
        return NativeToManaged<T>(ele);
    }

    /// <summary>Reverses this list in place.</summary>
    /// <returns>A reference to this object.</returns>
    public List<T> Reverse()
    {
        Handle = eina_list_reverse(Handle);
        return this;
    }

    /// <summary>Randomly shuffles this list in place.</summary>
    public void Shuffle()
    {
        Handle = eina_list_shuffle(Handle, IntPtr.Zero);
    }

    /// <summary>Gets a C# array of the elements in this list.</summary>
    /// <returns>A managed array of the elements.</returns>
    public T[] ToArray()
    {
        var managed = new T[Count()];
        int i = 0;
        for (IntPtr curr = Handle; curr != IntPtr.Zero; curr = InternalNext(curr), ++i)
        {
            managed[i] = NativeToManaged<T>(InternalDataGet(curr));
        }

        return managed;
    }

    /// <summary>Appends the given array of elements to this list.</summary>
    /// <param name="values">The values to be appended.</param>
    public void AppendArray(T[] values)
    {
        foreach (T v in values)
        {
            Append(v);
        }
    }


    /// <summary>Gets an iterator that iterates this list in normal order.</summary>
    /// <returns>The iterator.</returns>
    public UIKit.DataTypes.Iterator<T> GetIterator()
    {
        return new UIKit.DataTypes.Iterator<T>(eina_list_iterator_new(Handle), true);
    }

    /// <summary>Gets an iterator that iterates this list in reverse order.</summary>
    /// <returns>The iterator.</returns>
    public UIKit.DataTypes.Iterator<T> GetReversedIterator()
    {
        return new UIKit.DataTypes.Iterator<T>(eina_list_iterator_reversed_new(Handle), true);
    }

    /// <summary>Gets an enumerator into this list.</summary>
    /// <returns>The enumerator.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        for (IntPtr curr = Handle; curr != IntPtr.Zero; curr = InternalNext(curr))
        {
            yield return NativeToManaged<T>(InternalDataGet(curr));
        }
    }

    /// <summary>Gets an enumerator into this list.</summary>
    /// <returns>The enumerator.</returns>
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary> Gets an Accessor for this List.</summary>
    /// <returns>The accessor.</returns>
    public UIKit.DataTypes.Accessor<T> GetAccessor()
    {
        return new UIKit.DataTypes.Accessor<T>(eina_list_accessor_new(Handle), Ownership.Managed);
    }
}

}

}

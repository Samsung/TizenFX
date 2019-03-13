#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

using static Eina.TraitFunctions;
using static Eina.ListNativeFunctions;
using Eina.Callbacks;

namespace Eina {

public static class ListNativeFunctions
{
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_append(IntPtr list, IntPtr data);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_prepend(IntPtr list, IntPtr data);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_append_relative(IntPtr list, IntPtr data, IntPtr relative);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_append_relative_list(IntPtr list, IntPtr data, IntPtr relative);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_prepend_relative(IntPtr list, IntPtr data, IntPtr relative);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_prepend_relative_list(IntPtr list, IntPtr data, IntPtr relative);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_sorted_insert(IntPtr list, IntPtr func, IntPtr data);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_remove(IntPtr list, IntPtr data);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_remove_list(IntPtr list, IntPtr remove_list);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_promote_list(IntPtr list, IntPtr move_list);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_demote_list(IntPtr list, IntPtr move_list);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_data_find(IntPtr list, IntPtr data);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_data_find_list(IntPtr list, IntPtr data);
    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_list_move(ref IntPtr to, ref IntPtr from, IntPtr data);
    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_list_move_list(ref IntPtr to, ref IntPtr from, IntPtr data);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_free(IntPtr list);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_nth(IntPtr list, uint n);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_nth_list(IntPtr list, uint n);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_reverse(IntPtr list);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_reverse_clone(IntPtr list);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_clone(IntPtr list);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_sort(IntPtr list, uint limit, IntPtr func);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_shuffle(IntPtr list, IntPtr func);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_merge(IntPtr left, IntPtr right);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_sorted_merge(IntPtr left, IntPtr right, IntPtr func);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_split_list(IntPtr list, IntPtr relative, ref IntPtr right);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_search_sorted_near_list(IntPtr list, IntPtr func, IntPtr data, IntPtr result_cmp);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_search_sorted_list(IntPtr list, IntPtr func, IntPtr data);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_search_sorted(IntPtr list, IntPtr func, IntPtr data);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_search_unsorted_list(IntPtr list, IntPtr func, IntPtr data);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_search_unsorted(IntPtr list, IntPtr func, IntPtr data);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_iterator_new(IntPtr list);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_iterator_reversed_new(IntPtr list);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_list_accessor_new(IntPtr list);
    [DllImport(efl.Libs.Eina)] public static extern int
        eina_list_data_idx(IntPtr list, IntPtr data);


    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        eina_list_last_custom_export_mono(IntPtr list);
    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        eina_list_next_custom_export_mono(IntPtr list);
    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        eina_list_prev_custom_export_mono(IntPtr list);
    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        eina_list_data_get_custom_export_mono(IntPtr list);
    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        eina_list_data_set_custom_export_mono(IntPtr list, IntPtr data);
    [DllImport(efl.Libs.CustomExports)] public static extern uint
        eina_list_count_custom_export_mono(IntPtr list);
    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        eina_list_last_data_get_custom_export_mono(IntPtr list);
}

public class List<T> : IEnumerable<T>, IDisposable
{
    public IntPtr Handle {get;set;} = IntPtr.Zero;
    public bool Own {get;set;}
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


    public List()
    {
        InitNew();
    }

    public List(IntPtr handle, bool own)
    {
        Handle = handle;
        Own = own;
        OwnContent = own;
    }

    public List(IntPtr handle, bool own, bool ownContent)
    {
        Handle = handle;
        Own = own;
        OwnContent = ownContent;
    }

    ~List()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        if (h == IntPtr.Zero)
            return;

        if (OwnContent)
        {
            for(IntPtr curr = h; curr != IntPtr.Zero; curr = InternalNext(curr))
            {
                NativeFree<T>(InternalDataGet(curr));
            }
        }

        if (Own)
            eina_list_free(h);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Free()
    {
        Dispose();
    }

    public IntPtr Release()
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        return h;
    }

    public void SetOwnership(bool ownAll)
    {
        Own = ownAll;
        OwnContent = ownAll;
    }

    public void SetOwnership(bool own, bool ownContent)
    {
        Own = own;
        OwnContent = ownContent;
    }

    public int Count()
    {
        return (int) eina_list_count_custom_export_mono(Handle);
    }

    public void Append(T val)
    {
        IntPtr ele = ManagedToNativeAlloc(val);
        Handle = eina_list_append(Handle, ele);
    }

    public void Prepend(T val)
    {
        IntPtr ele = ManagedToNativeAlloc(val);
        Handle = eina_list_prepend(Handle, ele);
    }

    public void SortedInsert(T val)
    {
        IntPtr ele = ManagedToNativeAlloc(val);
        Handle = eina_list_sorted_insert(Handle, EinaCompareCb<T>(), ele);
    }

    public void SortedInsert(Eina_Compare_Cb compareCb, T val)
    {
        IntPtr ele = ManagedToNativeAlloc(val);
        Handle = eina_list_sorted_insert(Handle, Marshal.GetFunctionPointerForDelegate(compareCb), ele);
    }

    public void Sort(int limit = 0)
    {
        Handle = eina_list_sort(Handle, (uint)limit, EinaCompareCb<T>());
    }

    public void Sort(Eina_Compare_Cb compareCb)
    {
        Handle = eina_list_sort(Handle, 0, Marshal.GetFunctionPointerForDelegate(compareCb));
    }

    public void Sort(int limit, Eina_Compare_Cb compareCb)
    {
        Handle = eina_list_sort(Handle, (uint)limit, Marshal.GetFunctionPointerForDelegate(compareCb));
    }

    public T Nth(int n)
    {
        // TODO: check bounds ???
        IntPtr ele = eina_list_nth(Handle, (uint)n);
        return NativeToManaged<T>(ele);
    }

    public void DataSet(int idx, T val)
    {
        IntPtr pos = eina_list_nth_list(Handle, (uint)idx);
        if (pos == IntPtr.Zero)
            throw new IndexOutOfRangeException();
        if (OwnContent)
            NativeFree<T>(InternalDataGet(pos));
        IntPtr ele = ManagedToNativeAlloc(val);
        InternalDataSet(pos, ele);
    }

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

    public T LastDataGet()
    {
        IntPtr ele = eina_list_last_data_get_custom_export_mono(Handle);
        return NativeToManaged<T>(ele);
    }

    public List<T> Reverse()
    {
        Handle = eina_list_reverse(Handle);
        return this;
    }

    public void Shuffle()
    {
        Handle = eina_list_shuffle(Handle, IntPtr.Zero);
    }

    public T[] ToArray()
    {
        var managed = new T[Count()];
        int i = 0;
        for(IntPtr curr = Handle; curr != IntPtr.Zero; curr = InternalNext(curr), ++i)
        {
            managed[i] = NativeToManaged<T>(InternalDataGet(curr));
        }
        return managed;
    }

    public void AppendArray(T[] values)
    {
        foreach (T v in values)
            Append(v);
    }


    public Eina.Iterator<T> GetIterator()
    {
        return new Eina.Iterator<T>(eina_list_iterator_new(Handle), true, false);
    }

    public Eina.Iterator<T> GetReversedIterator()
    {
        return new Eina.Iterator<T>(eina_list_iterator_reversed_new(Handle), true, false);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for(IntPtr curr = Handle; curr != IntPtr.Zero; curr = InternalNext(curr))
        {
            yield return NativeToManaged<T>(InternalDataGet(curr));
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary> Gets an Accessor for this List.</summary>
    public Eina.Accessor<T> GetAccessor()
    {
        return new Eina.Accessor<T>(eina_list_accessor_new(Handle), Ownership.Managed);
    }
}

}

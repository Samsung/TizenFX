#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

using static Eina.TraitFunctions;
using static Eina.InlistNativeFunctions;
using Eina.Callbacks;

namespace Eina
{

public static class InlistNativeFunctions
{
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inlist_append(IntPtr in_list, IntPtr in_item);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inlist_prepend(IntPtr in_list, IntPtr in_item);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inlist_append_relative(IntPtr in_list, IntPtr in_item, IntPtr in_relative);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inlist_prepend_relative(IntPtr in_list, IntPtr in_item, IntPtr in_relative);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inlist_remove(IntPtr in_list, IntPtr in_item);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inlist_find(IntPtr in_list, IntPtr in_item);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inlist_promote(IntPtr list, IntPtr item);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inlist_demote(IntPtr list, IntPtr item);

    [DllImport(efl.Libs.Eina)] public static extern uint
        eina_inlist_count(IntPtr list);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inlist_iterator_new(IntPtr in_list);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inlist_accessor_new(IntPtr in_list);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inlist_sorted_insert(IntPtr list, IntPtr item, IntPtr func);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inlist_sorted_state_new();

    [DllImport(efl.Libs.Eina)] public static extern int
        eina_inlist_sorted_state_init(IntPtr state, IntPtr list);

    [DllImport(efl.Libs.Eina)] public static extern void
        eina_inlist_sorted_state_free(IntPtr state);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inlist_sorted_state_insert(IntPtr list, IntPtr item, IntPtr func, IntPtr state);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inlist_sort(IntPtr head, IntPtr func);


    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        eina_inlist_first_custom_export_mono(IntPtr list);
    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        eina_inlist_last_custom_export_mono(IntPtr list);


    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        eina_inlist_next_custom_export_mono(IntPtr list);
    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        eina_inlist_prev_custom_export_mono(IntPtr list);

    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        eina_inlist_iterator_wrapper_new_custom_export_mono(IntPtr in_list);
}

public class Inlist<T> : IEnumerable<T>, IDisposable
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


    public Inlist()
    {
        InitNew();
    }

    public Inlist(IntPtr handle, bool own)
    {
        Handle = handle;
        Own = own;
        OwnContent = own;
    }

    public Inlist(IntPtr handle, bool own, bool ownContent)
    {
        Handle = handle;
        Own = own;
        OwnContent = ownContent;
    }

    ~Inlist()
    {
        Dispose(false);
    }

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
        return (int)eina_inlist_count(Handle);
    }

    public void Clean()
    {
        while (Handle != IntPtr.Zero)
        {
            var aux = Handle;
            Handle = eina_inlist_remove(Handle, Handle);
            NativeFreeInlistNode<T>(aux, OwnContent);
        }
    }

    public void Append(T val)
    {
        IntPtr node = ManagedToNativeAllocInlistNode(val);
        Handle = eina_inlist_append(Handle, node);
    }

    public void Prepend(T val)
    {
        IntPtr node = ManagedToNativeAllocInlistNode(val);
        Handle = eina_inlist_prepend(Handle, node);
    }

    public void Remove(int idx)
    {
        IntPtr node = InternalAt(idx);
        Handle = eina_inlist_remove(Handle, node);
        NativeFreeInlistNode<T>(node, OwnContent);
    }

    public T At(int idx)
    {
        IntPtr node = InternalAt(idx);
        if (node == IntPtr.Zero)
        {
            throw new IndexOutOfRangeException();
        }

        return NativeToManagedInlistNode<T>(node);
    }

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

    public void AppendArray(T[] values)
    {
        foreach (T v in values)
        {
            Append(v);
        }
    }


    public Eina.Iterator<T> GetIterator()
    {
        return new Eina.Iterator<T>(eina_inlist_iterator_wrapper_new_custom_export_mono(Handle), true, false);
    }

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

    /// <summary> Gets an Accessor for this List.</summary>
    public Eina.Accessor<T> GetAccessor()
    {
        return new Eina.AccessorInList<T>(eina_inlist_accessor_new(Handle), Ownership.Managed);
    }
}

}

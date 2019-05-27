#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

using static Eina.TraitFunctions;
using static Eina.InarrayNativeFunctions;

namespace Eina
{

public static class InarrayNativeFunctions
{
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inarray_new(uint member_size, uint step);
    [DllImport(efl.Libs.Eina)] public static extern void
        eina_inarray_free(IntPtr array);
    [DllImport(efl.Libs.Eina)] public static extern void
        eina_inarray_step_set(IntPtr array, uint sizeof_eina_inarray, uint member_size, uint step);
    [DllImport(efl.Libs.Eina)] public static extern void
        eina_inarray_flush(IntPtr array);
    [DllImport(efl.Libs.Eina)] public static extern int
        eina_inarray_push(IntPtr array, IntPtr data);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inarray_grow(IntPtr array, uint size);
    [DllImport(efl.Libs.Eina)] public static extern int
        eina_inarray_insert(IntPtr array, IntPtr data, IntPtr compare);
    [DllImport(efl.Libs.Eina)] public static extern int
        eina_inarray_insert_sorted(IntPtr array, IntPtr data, IntPtr compare);
    [DllImport(efl.Libs.Eina)] public static extern int
        eina_inarray_remove(IntPtr array, IntPtr data);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inarray_pop(IntPtr array);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inarray_nth(IntPtr array, uint position);
    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_inarray_insert_at(IntPtr array, uint position, IntPtr data);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inarray_alloc_at(IntPtr array, uint position, uint member_count);
    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_inarray_replace_at(IntPtr array, uint position, IntPtr data);
    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_inarray_remove_at(IntPtr array, uint position);
    [DllImport(efl.Libs.Eina)] public static extern void
        eina_inarray_reverse(IntPtr array);
    [DllImport(efl.Libs.Eina)] public static extern void
        eina_inarray_sort(IntPtr array, IntPtr compare);
    [DllImport(efl.Libs.Eina)] public static extern int
        eina_inarray_search(IntPtr array, IntPtr data, IntPtr compare);
    [DllImport(efl.Libs.Eina)] public static extern int
        eina_inarray_search_sorted(IntPtr array, IntPtr data, IntPtr compare);
    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_inarray_foreach(IntPtr array, IntPtr function, IntPtr user_data);
    [DllImport(efl.Libs.Eina)] public static extern int
        eina_inarray_foreach_remove(IntPtr array, IntPtr match, IntPtr user_data);
    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_inarray_resize(IntPtr array, uint new_size);
    [DllImport(efl.Libs.Eina)] public static extern uint
        eina_inarray_count(IntPtr array);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inarray_iterator_new(IntPtr array);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inarray_iterator_reversed_new(IntPtr array);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_inarray_accessor_new(IntPtr array);
}

public class Inarray<T> : IEnumerable<T>, IDisposable
{
    public static uint DefaultStep = 0;

    public IntPtr Handle {get;set;} = IntPtr.Zero;
    public bool Own {get;set;}
    public bool OwnContent {get;set;}

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

    public Inarray()
    {
        InitNew(DefaultStep);
    }

    public Inarray(uint step)
    {
        InitNew(step);
    }

    public Inarray(IntPtr handle, bool own)
    {
        Handle = handle;
        Own = own;
        OwnContent = own;
    }

    public Inarray(IntPtr handle, bool own, bool ownContent)
    {
        Handle = handle;
        Own = own;
        OwnContent = ownContent;
    }

    ~Inarray()
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
                Efl.Eo.Globals.ThreadSafeFreeCbExec(eina_inarray_free, h);
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

    public void Flush()
    {
        FreeElementsIfOwned();
        eina_inarray_flush(Handle);
    }

    public int Count()
    {
        return (int)eina_inarray_count(Handle);
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

    public T Nth(uint idx)
    {
        IntPtr ele = eina_inarray_nth(Handle, idx);
        return NativeToManagedInplace<T>(ele);
    }

    public T At(int idx)
    {
        return Nth((uint)idx);
    }

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

    public void Reverse()
    {
        eina_inarray_reverse(Handle);
    }

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

    public bool Append(T[] values)
    {
        foreach (T v in values)
        {
            if (Push(v) == -1)
            {
                return false;
            }
        }

        return true;
    }

    public Eina.Iterator<T> GetIterator()
    {
        return new Eina.Iterator<T>(eina_inarray_iterator_new(Handle), true, false);
    }

    public Eina.Iterator<T> GetReversedIterator()
    {
        return new Eina.Iterator<T>(eina_inarray_iterator_reversed_new(Handle), true, false);
    }

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

    /// <summary> Gets an Accessor for this Array.</summary>
    public Eina.Accessor<T> GetAccessor()
    {
        return new Eina.AccessorInArray<T>(eina_inarray_accessor_new(Handle), Ownership.Managed);
    }
}

}

#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

using static Eina.TraitFunctions;
using static Eina.IteratorNativeFunctions;

namespace Eina
{

public static class IteratorNativeFunctions
{
    [DllImport(efl.Libs.Eina)] public static extern void
        eina_iterator_free(IntPtr iterator);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_iterator_container_get(IntPtr iterator);
    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_iterator_next(IntPtr iterator, out IntPtr data);
    [DllImport(efl.Libs.Eina)] public static extern void
        eina_iterator_foreach(IntPtr iterator, IntPtr callback, IntPtr fdata);
    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_iterator_lock(IntPtr iterator);
    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_iterator_unlock(IntPtr iterator);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_carray_iterator_new(IntPtr array);
}

public class Iterator<T> : IEnumerable<T>, IDisposable
{
    public IntPtr Handle {get;set;} = IntPtr.Zero;
    public bool Own {get;set;} = true;
    public bool OwnContent {get;set;} = false;

    public Iterator(IntPtr handle, bool own)
    {
        Handle = handle;
        Own = own;
        OwnContent = own;
    }

    public Iterator(IntPtr handle, bool own, bool ownContent)
    {
        Handle = handle;
        Own = own;
        OwnContent = ownContent;
    }

    ~Iterator()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        var h = Handle;
        Handle = IntPtr.Zero;
        if (h == IntPtr.Zero)
        {
            return;
        }

        if (OwnContent)
        {
            for (IntPtr data; eina_iterator_next(h, out data);)
            {
                NativeFree<T>(data);
            }
        }

        if (Own)
        {
            if (disposing)
            {
                eina_iterator_free(h);
            }
            else
            {
                Efl.Eo.Globals.ThreadSafeFreeCbExec(eina_iterator_free, h);
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

    public bool Next(out T res)
    {
        IntPtr data;
        if (!eina_iterator_next(Handle, out data))
        {
            res = default(T);
            return false;
        }

        res = NativeToManaged<T>(data);

        if (OwnContent)
        {
            NativeFree<T>(data);
        }

        return true;
    }

    public bool Lock()
    {
        return eina_iterator_lock(Handle);
    }

    public bool Unlock()
    {
        return eina_iterator_unlock(Handle);
    }

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

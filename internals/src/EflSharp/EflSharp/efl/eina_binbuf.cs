#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;

namespace Eina
{

public class Binbuf : IDisposable
{
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_binbuf_new();
    [DllImport(efl.Libs.Eina)] public static extern void
        eina_binbuf_free(IntPtr buf);
    [DllImport(efl.Libs.Eina)] public static extern void
        eina_binbuf_reset(IntPtr buf);
    [DllImport(efl.Libs.Eina)] public static extern byte
        eina_binbuf_append_length(IntPtr buf, byte[] str, UIntPtr length);
    [DllImport(efl.Libs.Eina)] public static extern byte
        eina_binbuf_append_slice(IntPtr buf, Eina.Slice slice);
    [DllImport(efl.Libs.Eina)] public static extern byte
        eina_binbuf_append_buffer(IntPtr buf, IntPtr data);
    [DllImport(efl.Libs.Eina)] public static extern byte
        eina_binbuf_append_char(IntPtr buf, byte c);
    [DllImport(efl.Libs.Eina)] public static extern byte
        eina_binbuf_insert_length(IntPtr buf, byte[] str, UIntPtr length, UIntPtr pos);
    [DllImport(efl.Libs.Eina)] public static extern byte
        eina_binbuf_insert_slice(IntPtr buf, Eina.Slice slice, UIntPtr pos);
    [DllImport(efl.Libs.Eina)] public static extern byte
        eina_binbuf_insert_char(IntPtr buf, byte c, UIntPtr pos);
    [DllImport(efl.Libs.Eina)] public static extern byte
        eina_binbuf_remove(IntPtr buf, UIntPtr start, UIntPtr end);
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_binbuf_string_get(IntPtr buf);
    [DllImport(efl.Libs.Eina)] public static extern void
        eina_binbuf_string_free(IntPtr buf);
    [DllImport(efl.Libs.Eina)] public static extern UIntPtr
        eina_binbuf_length_get(IntPtr buf);
    [DllImport(efl.Libs.Eina)] public static extern Eina.Slice
        eina_binbuf_slice_get(IntPtr buf);

    public IntPtr Handle {get;set;} = IntPtr.Zero;
    public bool Own {get;set;}

    public int Length
    {
        get { return (int)GetLength(); }
    }

    private void InitNew()
    {
        Handle = eina_binbuf_new();
        Own = true;
        if (Handle == IntPtr.Zero)
        {
            throw new SEHException("Could not alloc binbuf");
        }
    }

    public Binbuf()
    {
        InitNew();
    }

    public Binbuf(byte[] str, uint? length = null)
    {
        InitNew();

        if (str != null)
        {
            if (!Append(str, (length != null ? length.Value : (uint)(str.Length))))
            {
                Dispose();
                throw new SEHException("Could not append on binbuf");
            }
        }
    }

    public Binbuf(Binbuf bb)
    {
        InitNew();

        if (bb != null)
        {
            Append(bb);
        }
    }

    public Binbuf(IntPtr handle, bool own)
    {
        Handle = handle;
        Own = own;
    }

    ~Binbuf()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        if (Own && h != IntPtr.Zero)
        {
            eina_binbuf_free(Handle);
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

    public void Reset()
    {
        eina_binbuf_reset(Handle);
    }

    public bool Append(byte[] str)
    {
        return 0 != eina_binbuf_append_length(Handle, str, (UIntPtr)(str.Length));
    }

    public bool Append(byte[] str, uint length)
    {
        return 0 != eina_binbuf_append_length(Handle, str, (UIntPtr)length);
    }

    public bool Append(Binbuf bb)
    {
        return 0 != eina_binbuf_append_buffer(Handle, bb.Handle);
    }

    public bool Append(byte c)
    {
        return 0 != eina_binbuf_append_char(Handle, c);
    }

    public bool Append(Eina.Slice slice)
    {
        return 0 != eina_binbuf_append_slice(Handle, slice);
    }

    public bool Insert(byte[] str, uint pos)
    {
        return 0 != eina_binbuf_insert_length(Handle, str, (UIntPtr)(str.Length), (UIntPtr)pos);
    }

    public bool Insert(byte[] str, uint length, uint pos)
    {
        return 0 != eina_binbuf_insert_length(Handle, str, (UIntPtr)length, (UIntPtr)pos);
    }

    public bool Insert(byte c, uint pos)
    {
        return 0 != eina_binbuf_insert_char(Handle, c, (UIntPtr)pos);
    }

    public bool Insert(Eina.Slice slice, uint pos)
    {
        return 0 != eina_binbuf_insert_slice(Handle, slice, (UIntPtr)pos);
    }

    public bool Remove(uint start, uint end)
    {
        return 0 != eina_binbuf_remove(Handle, (UIntPtr)start, (UIntPtr)end);
    }

    public byte[] GetBytes()
    {
        var ptr = eina_binbuf_string_get(Handle);
        if (ptr == IntPtr.Zero)
        {
            return null;
        }

        var size = (int)(this.GetLength());
        byte[] mArray = new byte[size];
        Marshal.Copy(ptr, mArray, 0, size);
        return mArray;
    }

    public IntPtr GetStringNative()
    {
        return eina_binbuf_string_get(Handle);
    }

    public void FreeString()
    {
        eina_binbuf_string_free(Handle);
    }

    public UIntPtr GetLength()
    {
        return eina_binbuf_length_get(Handle);
    }

    Eina.Slice GetSlice()
    {
        return eina_binbuf_slice_get(Handle);
    }
}

}

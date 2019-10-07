#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;

namespace UIKit
{

namespace DataTypes
{

/// <summary>
/// A Generic buffer designed to be a mutable string.
///
/// Since EFL 1.23.
/// </summary>
public class Binbuf : IDisposable
{
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_binbuf_new();
    [DllImport(UIKit.Libs.Eina)] public static extern void
        eina_binbuf_free(IntPtr buf);
    [DllImport(UIKit.Libs.Eina)] public static extern void
        eina_binbuf_reset(IntPtr buf);
    [DllImport(UIKit.Libs.Eina)] public static extern byte
        eina_binbuf_append_length(IntPtr buf, byte[] str, UIntPtr length);
    [DllImport(UIKit.Libs.Eina)] public static extern byte
        eina_binbuf_append_slice(IntPtr buf, UIKit.DataTypes.Slice slice);
    [DllImport(UIKit.Libs.Eina)] public static extern byte
        eina_binbuf_append_buffer(IntPtr buf, IntPtr data);
    [DllImport(UIKit.Libs.Eina)] public static extern byte
        eina_binbuf_append_char(IntPtr buf, byte c);
    [DllImport(UIKit.Libs.Eina)] public static extern byte
        eina_binbuf_insert_length(IntPtr buf, byte[] str, UIntPtr length, UIntPtr pos);
    [DllImport(UIKit.Libs.Eina)] public static extern byte
        eina_binbuf_insert_slice(IntPtr buf, UIKit.DataTypes.Slice slice, UIntPtr pos);
    [DllImport(UIKit.Libs.Eina)] public static extern byte
        eina_binbuf_insert_char(IntPtr buf, byte c, UIntPtr pos);
    [DllImport(UIKit.Libs.Eina)] public static extern byte
        eina_binbuf_remove(IntPtr buf, UIntPtr start, UIntPtr end);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_binbuf_string_get(IntPtr buf);
    [DllImport(UIKit.Libs.Eina)] public static extern void
        eina_binbuf_string_free(IntPtr buf);
    [DllImport(UIKit.Libs.Eina)] public static extern UIntPtr
        eina_binbuf_length_get(IntPtr buf);
    [DllImport(UIKit.Libs.Eina)] public static extern UIKit.DataTypes.Slice
        eina_binbuf_slice_get(IntPtr buf);

    /// <summary>Pointer to the native buffer.</summary>
    public IntPtr Handle {get;set;} = IntPtr.Zero;
    ///<summary>Whether this wrapper owns the native buffer.</summary>
    public bool Own {get;set;}

    /// <summary> Length of the buffer.</summary>
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

    /// <summary>
    ///   Create a new buffer.
    /// </summary>
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

    /// <summary>
    ///   Create a new buffer with elements.
    /// </summary>
    ///// <param name="bb">Elements to initialize the new buffer.</param>
    public Binbuf(Binbuf bb)
    {
        InitNew();

        if (bb != null)
        {
            Append(bb);
        }
    }

    /// <summary>
    ///   Create a new buffer.
    /// </summary>
    ///// <param name="handle">The native handle to be wrapped.</param>
    ///// <param name="own">Whether this wrapper owns the native handle.</param>
    public Binbuf(IntPtr handle, bool own)
    {
        Handle = handle;
        Own = own;
    }

    ~Binbuf()
    {
        Dispose(false);
    }

    /// <summary>Disposes of this wrapper, releasing the native buffer if owned.</summary>
    /// <param name="disposing">True if this was called from <see cref="Dispose()"/> public method. False if
    /// called from the C# finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        if (Own && h != IntPtr.Zero)
        {
            if (disposing)
            {
                eina_binbuf_free(Handle);
            }
            else
            {
                UIKit.Wrapper.Globals.ThreadSafeFreeCbExec(eina_binbuf_free, Handle);
            }
        }
    }

    /// <summary>Releases the native resources held by this instance.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Releases the native resources held by this instance.</summary>
    public void Free()
    {
        Dispose();
    }

    /// <summary>
    ///   Releases the native buffer.
    /// </summary>
    /// <returns>The native buffer.</returns>
    public IntPtr Release()
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        return h;
    }

    /// <summary>
    ///   Resets the buffer.
    /// </summary>
    public void Reset()
    {
        eina_binbuf_reset(Handle);
    }

    /// <summary>
    ///   Appends a string of inputed buffer's length to the buffer, reallocating as necessary.
    /// </summary>
    ///// <param name="str">The string buffer.</param>
    /// <returns>true on success, false if data could not be appended.</returns>
    public bool Append(byte[] str)
    {
        return 0 != eina_binbuf_append_length(Handle, str, (UIntPtr)(str.Length));
    }

    /// <summary>
    ///   Appends a string of exact length to the buffer, reallocating as necessary.
    /// </summary>
    ///// <param name="str">The string buffer.</param>
    ///// <param name="length">The exact length to use.</param>
    /// <returns>true on success, false if data could not be appended.</returns>
    public bool Append(byte[] str, uint length)
    {
        return 0 != eina_binbuf_append_length(Handle, str, (UIntPtr)length);
    }

    /// <summary>
    ///   Appends a Binbuf to the buffer.
    /// </summary>
    ///// <param name="bb">The buffer to be appended.</param>
    /// <returns>true on success, false if data could not be appended.</returns>
    public bool Append(Binbuf bb)
    {
        return 0 != eina_binbuf_append_buffer(Handle, bb.Handle);
    }

    /// <summary>
    ///  Appends a character to the buffer, reallocating as necessary.
    /// </summary>
    ///// <param name="c">The char to appended.</param>
    /// <returns>true on success, false if data could not be appended.</returns>
    public bool Append(byte c)
    {
        return 0 != eina_binbuf_append_char(Handle, c);
    }

    /// <summary>
    ///  Appends a slice to the buffer, reallocating as necessary.
    /// </summary>
    ///// <param name="slice">The slice to appended.</param>
    /// <returns>true on success, false if data could not be appended.</returns>
    public bool Append(UIKit.DataTypes.Slice slice)
    {
        return 0 != eina_binbuf_append_slice(Handle, slice);
    }

    /// <summary>
    ///   Inserts a string of inputed buffer's length into the buffer, reallocating as necessary.
    /// </summary>
    ///// <param name="str">The string buffer.</param>
    ///// <param name="pos">The position to insert the string.</param>
    /// <returns>true on success, false if data could not be appended.</returns>
    public bool Insert(byte[] str, uint pos)
    {
        return 0 != eina_binbuf_insert_length(Handle, str, (UIntPtr)(str.Length), (UIntPtr)pos);
    }

    /// <summary>
    ///   Inserts a string of exact length into the buffer, reallocating as necessary.
    /// </summary>
    ///// <param name="str">The string buffer.</param>
    ///// <param name="length">The exact length to use.</param>
    ///// <param name="pos">The position to insert the string.</param>
    /// <returns>true on success, false if data could not be appended.</returns>
    public bool Insert(byte[] str, uint length, uint pos)
    {
        return 0 != eina_binbuf_insert_length(Handle, str, (UIntPtr)length, (UIntPtr)pos);
    }

    /// <summary>
    ///   Inserts a character into the buffer, reallocating as  necessary.
    /// </summary>
    ///// <param name="c">The char to appended.</param>
    ///// <param name="pos">The position to insert the string.</param>
    /// <returns>true on success, false if data could not be appended.</returns>
    public bool Insert(byte c, uint pos)
    {
        return 0 != eina_binbuf_insert_char(Handle, c, (UIntPtr)pos);
    }

    /// <summary>
    ///    Inserts a slice into the buffer, reallocating as necessary.
    /// </summary>
    ///// <param name="slice">The slice to appended.</param>
    ///// <param name="pos">The position to insert the string.</param>
    /// <returns>true on success, false if data could not be appended.</returns>
    public bool Insert(UIKit.DataTypes.Slice slice, uint pos)
    {
        return 0 != eina_binbuf_insert_slice(Handle, slice, (UIntPtr)pos);
    }

    /// <summary>
    ///    Removes a slice of the buffer.
    /// </summary>
    ///// <param name="start">The initial (inclusive) slice position to start
    ///// removing, in bytes.</param>
    ///// <param name="end">The final (non-inclusive) slice position to finish
    ///// removing, in bytes..</param>
    /// <returns>true on success, false on failure.</returns>
    public bool Remove(uint start, uint end)
    {
        return 0 != eina_binbuf_remove(Handle, (UIntPtr)start, (UIntPtr)end);
    }

    /// <summary>
    ///   Retrieves a string to the contents of the buffer.
    /// </summary>
    /// <returns>The string that is contained in buffer.</returns>
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

    /// <summary>
    ///   Retrieves a string to the contents of the buffer.
    /// </summary>
    /// <returns>The string that is contained in buffer.</returns>
    public IntPtr GetStringNative()
    {
        return eina_binbuf_string_get(Handle);
    }

    /// <summary>
    ///   Frees the buffer.
    /// </summary>
    public void FreeString()
    {
        eina_binbuf_string_free(Handle);
    }

    /// <summary>
    ///   Retrieves the length of the buffer's contents.
    /// </summary>
    public UIntPtr GetLength()
    {
        return eina_binbuf_length_get(Handle);
    }

    /// <summary>
    ///    Gets a slice of the buffer's contents.
    /// </summary>
    UIKit.DataTypes.Slice GetSlice()
    {
        return eina_binbuf_slice_get(Handle);
    }
}

}

}

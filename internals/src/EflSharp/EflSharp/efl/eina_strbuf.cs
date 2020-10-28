using System;
using System.Runtime.InteropServices;

using static Eina.EinaNative.StrbufNativeMethods;

namespace Eina
{

namespace EinaNative
{

static internal class StrbufNativeMethods
{
    [DllImport(efl.Libs.Eina)]
    internal static extern IntPtr eina_strbuf_new();

    [DllImport(efl.Libs.Eina)]
    internal static extern void eina_strbuf_free(IntPtr buf);

    [DllImport(efl.Libs.Eina)]
    internal static extern void eina_strbuf_reset(IntPtr buf);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_strbuf_append(IntPtr buf, string str);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_strbuf_append_escaped(IntPtr buf, string str);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_strbuf_append_char(IntPtr buf, char c);

    [DllImport(efl.Libs.Eina)]
    internal static extern string eina_strbuf_string_steal(IntPtr buf);

    [DllImport(efl.Libs.Eina)]
    internal static extern IntPtr eina_strbuf_length_get(IntPtr buf); // Uses IntPtr as wrapper for size_t
}

} // namespace EinaNative

///<summary>Native string buffer, similar to the C# StringBuilder class.</summary>
public class Strbuf : IDisposable
{
    ///<summary>Pointer to the underlying native handle.</summary>
    public IntPtr Handle { get; protected set; }
    private Ownership Ownership;
    private bool Disposed;

    ///<summary>Creates a new Strbuf. By default its lifetime is managed.</summary>
    public Strbuf(Ownership ownership = Ownership.Managed)
    {
        this.Handle = eina_strbuf_new();
        this.Ownership = ownership;
    }

    ///<summary>Creates a new Strbuf from an existing IntPtr.</summary>
    public Strbuf(IntPtr ptr, Ownership ownership)
    {
        this.Handle = ptr;
        this.Ownership = ownership;
    }

    /// <summary>Releases the ownership of the underlying value to C.</summary>
    public void ReleaseOwnership()
    {
        this.Ownership = Ownership.Unmanaged;
    }

    /// <summary>Takes the ownership of the underlying value to the Managed runtime.</summary>
    public void TakeOwnership()
    {
        this.Ownership = Ownership.Managed;
    }

    ///<summary>Public method to explicitly free the wrapped buffer.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ///<summary>Actually free the wrapped buffer. Can be called from Dispose() or through the GC.</summary>
    protected virtual void Dispose(bool disposing)
    {
        if (this.Ownership == Ownership.Unmanaged)
        {
            Disposed = true;
            return;
        }

        if (!Disposed && (Handle != IntPtr.Zero))
        {
            eina_strbuf_free(Handle);
        }

        Disposed = true;
    }

    ///<summary>Finalizer to be called from the GC.</summary>
    ~Strbuf()
    {
        Dispose(false);
    }

    ///<summary>Retrieves the length of the buffer contents.</summary>
    public int Length
    {
        get
        {
            IntPtr size = eina_strbuf_length_get(Handle);
            return size.ToInt32();
        }
    }

    ///<summary>Resets a string buffer. Its len is set to 0 and the content to '\\0'</summary>
    public void Reset()
    {
        if (Disposed)
        {
            throw new ObjectDisposedException(base.GetType().Name);
        }

        eina_strbuf_reset(Handle);
    }

    ///<summary>Appends a string to a buffer, reallocating as necessary.</summary>
    public bool Append(string text)
    {
        if (Disposed)
        {
            throw new ObjectDisposedException(base.GetType().Name);
        }

        return eina_strbuf_append(Handle, text);
    }

    ///<summary>Appens an escaped string to a buffer, reallocating as necessary.</summary>
    public bool AppendEscaped(string text)
    {
        if (Disposed)
        {
            throw new ObjectDisposedException(base.GetType().Name);
        }

        return eina_strbuf_append_escaped(Handle, text);
    }

    ///<summary>Appends a char to a buffer, reallocating as necessary.</summary>
    public bool Append(char c)
    {
        if (Disposed)
        {
            throw new ObjectDisposedException(base.GetType().Name);
        }

        return eina_strbuf_append_char(Handle, c);
    }

    ///<summary>Steals the content of a buffer.</summary>
    public string Steal()
    {
        if (Disposed)
        {
            throw new ObjectDisposedException(base.GetType().Name);
        }

        return eina_strbuf_string_steal(Handle);
    }
}

} // namespace eina

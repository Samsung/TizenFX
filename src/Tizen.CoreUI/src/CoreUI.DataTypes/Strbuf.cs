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
using System;
using System.Runtime.InteropServices;
using System.ComponentModel;

using static CoreUI.DataTypes.DataTypesNative.StrbufNativeMethods;

namespace CoreUI.DataTypes
{

namespace DataTypesNative
{

static internal class StrbufNativeMethods
{
    [DllImport(CoreUI.Libs.Eina)]
    internal static extern IntPtr eina_strbuf_new();

    [DllImport(CoreUI.Libs.Eina)]
    internal static extern void eina_strbuf_free(IntPtr buf);

    [DllImport(CoreUI.Libs.Eina)]
    internal static extern void eina_strbuf_reset(IntPtr buf);

    [DllImport(CoreUI.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_strbuf_append(IntPtr buf, string str);

    [DllImport(CoreUI.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_strbuf_append_escaped(IntPtr buf, string str);

    [DllImport(CoreUI.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_strbuf_append_char(IntPtr buf, char c);

    [DllImport(CoreUI.Libs.Eina, CharSet=CharSet.Ansi)]
    [return:
     MarshalAs(UnmanagedType.CustomMarshaler,
	       MarshalTypeRef=typeof(CoreUI.Wrapper.StringPassOwnershipMarshaler))]
    internal static extern string eina_strbuf_string_steal(IntPtr buf);

    [DllImport(CoreUI.Libs.Eina, CharSet=CharSet.Ansi)]
    [return:
     MarshalAs(UnmanagedType.CustomMarshaler,
	       MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
    internal static extern string eina_strbuf_string_get(IntPtr buf);

    [DllImport(CoreUI.Libs.Eina)]
    internal static extern IntPtr eina_strbuf_length_get(IntPtr buf); // Uses IntPtr as wrapper for size_t
}

} // namespace DataTypesNative

/// <summary>Native string buffer, similar to the C# StringBuilder class.
///
/// </summary>
/// <since_tizen> 6 </since_tizen>
public class Strbuf : IDisposable
{
    ///<summary>Pointer to the underlying native handle.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IntPtr Handle { get; protected set; }
    private Ownership Ownership;
    private bool Disposed;

    ///<summary>Creates a new Strbuf. By default its lifetime is managed.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public Strbuf(Ownership ownership = Ownership.Managed)
    {
        this.Handle = eina_strbuf_new();
        this.Ownership = ownership;
    }

    ///<summary>Creates a new Strbuf from an existing IntPtr.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Strbuf(IntPtr ptr, Ownership ownership)
    {
        this.Handle = ptr;
        this.Ownership = ownership;
    }

    /// <summary>Releases the ownership of the underlying value to C.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void ReleaseOwnership()
    {
        this.Ownership = Ownership.Unmanaged;
    }

    /// <summary>Takes the ownership of the underlying value to the Managed runtime.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void TakeOwnership()
    {
        this.Ownership = Ownership.Managed;
    }

    ///<summary>Public method to explicitly free the wrapped buffer.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ///<summary>Actually free the wrapped buffer. Can be called from Dispose() or through the Garbage Collector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    protected virtual void Dispose(bool disposing)
    {
        if (this.Ownership == Ownership.Unmanaged)
        {
            Disposed = true;
            return;
        }

        if (!Disposed && (Handle != IntPtr.Zero))
        {
            if (disposing)
            {
                eina_strbuf_free(Handle);
            }
            else
            {
                CoreUI.Wrapper.Globals.ThreadSafeFreeCbExec(eina_strbuf_free, Handle);
            }

            Handle = IntPtr.Zero;
        }

        Disposed = true;
    }

    ///<summary>Finalizer to be called from the Garbage Collector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    ~Strbuf()
    {
        Dispose(false);
    }

    ///<summary>Retrieves the length of the buffer contents.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The number of characters in this buffer.</value>
    public int Length
    {
        get
        {
            IntPtr size = eina_strbuf_length_get(Handle);
            return size.ToInt32();
        }
    }

    ///<summary>Resets a string buffer. Its len is set to 0.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Reset()
    {
        if (Disposed)
        {
            throw new ObjectDisposedException(base.GetType().Name);
        }

        eina_strbuf_reset(Handle);
    }

    ///<summary>Appends a string to a buffer, reallocating as necessary.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="text">The string to be appended.</param>
    /// <returns><c>true</c> if the append was successful.</returns>
    public bool Append(string text)
    {
        if (Disposed)
        {
            throw new ObjectDisposedException(base.GetType().Name);
        }

        return eina_strbuf_append(Handle, text);
    }

    ///<summary>Appends an escaped string to a buffer, reallocating as necessary.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="text">The string to be escaped and appended.</param>
    /// <returns><c>true</c> if the append was successful.</returns>
    public bool AppendEscaped(string text)
    {
        if (Disposed)
        {
            throw new ObjectDisposedException(base.GetType().Name);
        }

        return eina_strbuf_append_escaped(Handle, text);
    }

    ///<summary>Appends a char to a buffer, reallocating as necessary.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="c">The character to be appended.</param>
    /// <returns><c>true</c> if the append was successful.</returns>
    public bool Append(char c)
    {
        if (Disposed)
        {
            throw new ObjectDisposedException(base.GetType().Name);
        }

        return eina_strbuf_append_char(Handle, c);
    }

    ///<summary>Steals the content of a buffer. This causes the buffer to be re-initialized.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A string with the contents of this buffer.</returns>
    public string Steal()
    {
        if (Disposed)
        {
            throw new ObjectDisposedException(base.GetType().Name);
        }

        return eina_strbuf_string_steal(this.Handle);
    }

    /// <summary>Copy the content of a buffer.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A string with the contents of this buffer.</returns>
    public override string ToString()
    {
        return eina_strbuf_string_get(this.Handle);
    }
}
} // namespace eina

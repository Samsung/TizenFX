using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using static Eina.TraitFunctions;

using static Eina.AccessorNativeFunctions;

namespace Eina
{

internal class AccessorNativeFunctions
{
    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_accessor_data_get(IntPtr accessor, uint position, IntPtr data);
    [DllImport(efl.Libs.Eina)] public static extern void
        eina_accessor_free(IntPtr accessor);
}

/// <summary>Accessors provide an uniform way of accessing Eina containers, similar to C++ STL's and C# IEnumerable.</summary>
public class Accessor<T> : IEnumerable<T>, IDisposable
{
    /// <summary>Pointer to the native accessor.</summary>
    public IntPtr Handle { get; private set; } = IntPtr.Zero;

    /// <summary>Who is in charge of releasing the resources wrapped by this instance.</summary>
    private Ownership Ownership { get; set; }

    // FIXME Part of the implicit EFL Container interface. Need to make it explicit.
    ///<summary>Whether this wrapper owns the native accessor.</summary>
    public bool Own
    {
        get
        {
            return Ownership == Ownership.Managed;
        }
        set
        {
            Ownership = value ? Ownership.Managed : Ownership.Unmanaged;
        }
    }

    /// <summary>Create a new accessor wrapping the given pointer.</summary>
    /// <param name="handle">The native handle to be wrapped.</param>
    /// <param name="owner">Whether this wrapper owns the native accessor.</param>
    public Accessor(IntPtr handle, Ownership owner = Ownership.Managed)
    {
        Handle = handle;
        Ownership = owner;
    }

    /// <summary>Create a new accessor wrapping the given pointer.</summary>
    /// <param name="handle">The native handle to be wrapped.</param>
    /// <param name="own">Whether this wrapper owns the native accessor.</param>
    /// <param name="ownContent">For compatibility with other EFL# containers. Ignored in acessors.</param>
    public Accessor(IntPtr handle, bool own, bool ownContent = false)
        : this(handle, own ? Ownership.Managed : Ownership.Unmanaged)
    {
    }

    /// <summary>Release the native resources held by this instance.</summary>
    public void Dispose()
    {
        Dispose(true);
    }

    /// <summary>Disposes of this wrapper, releasing the native accessor if owned.</summary>
    /// <param name="disposing">True if this was called from <see cref="Dispose()"/> public method. False if
    /// called from the C# finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (Ownership == Ownership.Managed && Handle != IntPtr.Zero)
        {
            if (disposing)
            {
                eina_accessor_free(Handle);
            }
            else
            {
                Efl.Eo.Globals.ThreadSafeFreeCbExec(eina_accessor_free, Handle);
            }
            Handle = IntPtr.Zero;
        }
    }

    /// <summary>Finalizer to be called from the Garbage Collector.</summary>
    ~Accessor()
    {
        Dispose(false);
    }

    /// <summary>Convert the native data into managed. This is used when returning the data through a
    /// <see cref="System.Collections.Generic.IEnumerator&lt;T&gt;"/>.</summary>
    /// <param name="data">The data to be converted</param>
    /// <returns>The managed data representing <c>data</c>.</returns>
    protected virtual T Convert(IntPtr data)
    {
        return NativeToManaged<T>(data);
    }

    /// <summary>Returns an enumerator that iterates throught this accessor.</summary>
    /// <returns>An enumerator to walk through the acessor items.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        if (Handle == IntPtr.Zero)
        {
            throw new ObjectDisposedException(base.GetType().Name);
        }

        IntPtr tmp = MemoryNative.Alloc(Marshal.SizeOf(typeof(IntPtr)));
        uint position = 0;

        try
        {
            while (eina_accessor_data_get(Handle, position, tmp))
            {
                IntPtr data = (IntPtr)Marshal.PtrToStructure(tmp, typeof(IntPtr));
                yield return Convert(data);
                position += 1;
            }
        }
        finally
        {
            MemoryNative.Free(tmp);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

///<summary>Accessor for Inlists.</summary>
public class AccessorInList<T> : Accessor<T>
{
    /// <summary>Create a new accessor wrapping the given pointer.</summary>
    /// <param name="handle">The native handle to be wrapped.</param>
    /// <param name="own">Whether this wrapper owns the native accessor.</param>
    public AccessorInList(IntPtr handle, Ownership own) : base(handle, own)
    {
    }

    /// <summary>Convert the native data into managed. This is used when returning the data through a
    /// <see cref="System.Collections.Generic.IEnumerator&lt;T&gt;"/>.</summary>
    /// <param name="data">The data to be converted</param>
    /// <returns>The managed data representing <c>data</c>.</returns>
    protected override T Convert(IntPtr data)
    {
        return NativeToManagedInlistNode<T>(data);
    }
}

///<summary>Accessor for Inarrays.</summary>
public class AccessorInArray<T> : Accessor<T>
{
    /// <summary>Create a new accessor wrapping the given pointer.</summary>
    /// <param name="handle">The native handle to be wrapped.</param>
    /// <param name="own">Whether this wrapper owns the native accessor.</param>
    public AccessorInArray(IntPtr handle, Ownership own) : base(handle, own)
    {
    }

    /// <summary>Convert the native data into managed. This is used when returning the data through a
    /// <see cref="System.Collections.Generic.IEnumerator&lt;T&gt;"/>.</summary>
    /// <param name="data">The data to be converted</param>
    /// <returns>The managed data representing <c>data</c>.</returns>
    protected override T Convert(IntPtr data)
    {
        return NativeToManagedInplace<T>(data);
    }
}

}

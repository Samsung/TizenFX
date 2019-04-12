using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using static Eina.TraitFunctions;

using static Eina.AccessorNativeFunctions;

namespace Eina {

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
    public Accessor(IntPtr handle, Ownership owner=Ownership.Managed)
    {
        Handle = handle;
        Ownership = owner;
    }

    public Accessor(IntPtr handle, bool own, bool ownContent=false)
        : this(handle, own ? Ownership.Managed : Ownership.Unmanaged)
    {
    }

    /// <summary>Release the native resources held by this instance.</summary>
    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (Ownership == Ownership.Managed && Handle != IntPtr.Zero)
        {
            eina_accessor_free(Handle);
            Handle = IntPtr.Zero;
        }
    }

    ~Accessor()
    {
        Dispose(false);
    }

    public virtual T Convert(IntPtr data)
    {
        return NativeToManaged<T>(data);
    }

    /// <summary>Returns an enumerator that iterates throught this accessor.</summary>
    public IEnumerator<T> GetEnumerator()
    {
        if (Handle == IntPtr.Zero)
            throw new ObjectDisposedException(base.GetType().Name);
        IntPtr tmp = MemoryNative.Alloc(Marshal.SizeOf(typeof(IntPtr)));
        uint position = 0;

        try
        {
            while(eina_accessor_data_get(Handle, position, tmp))
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

public class AccessorInList<T> : Accessor<T>
{
    public AccessorInList(IntPtr handle, Ownership own): base(handle, own) {}
    public override T Convert(IntPtr data)
    {
        return NativeToManagedInlistNode<T>(data);
    }
}

public class AccessorInArray<T> : Accessor<T>
{
    public AccessorInArray(IntPtr handle, Ownership own): base(handle, own) {}
    public override T Convert(IntPtr data)
    {
        return NativeToManagedInplace<T>(data);
    }
}

}

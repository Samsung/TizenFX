#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

using static UIKit.DataTypes.TraitFunctions;
using static UIKit.DataTypes.ArrayNativeFunctions;

namespace UIKit
{

namespace DataTypes
{

public static class ArrayNativeFunctions
{
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_array_new(uint step);
    [DllImport(UIKit.Libs.Eina)] public static extern void
        eina_array_free(IntPtr array);
    [DllImport(UIKit.Libs.Eina)] public static extern void
        eina_array_flush(IntPtr array);
    [DllImport(UIKit.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_array_remove(IntPtr array, IntPtr keep, IntPtr gdata);
    [DllImport(UIKit.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_array_push(IntPtr array, IntPtr data);

    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_array_iterator_new(IntPtr array);
    [DllImport(UIKit.Libs.Eina)] public static extern IntPtr
        eina_array_accessor_new(IntPtr array);

    [DllImport(UIKit.Libs.CustomExports)] public static extern void
        eina_array_clean_custom_export_mono(IntPtr array);
    [DllImport(UIKit.Libs.CustomExports)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_array_push_custom_export_mono(IntPtr array, IntPtr data);
    [DllImport(UIKit.Libs.CustomExports)] public static extern IntPtr
        eina_array_pop_custom_export_mono(IntPtr array);
    [DllImport(UIKit.Libs.CustomExports)] public static extern IntPtr
        eina_array_data_get_custom_export_mono(IntPtr array, uint idx);
    [DllImport(UIKit.Libs.CustomExports)] public static extern void
        eina_array_data_set_custom_export_mono(IntPtr array, uint idx, IntPtr data);
    [DllImport(UIKit.Libs.CustomExports)] public static extern uint
        eina_array_count_custom_export_mono(IntPtr array);

    [DllImport(UIKit.Libs.CustomExports)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_array_foreach_custom_export_mono(IntPtr array, IntPtr cb, IntPtr fdata);
}

/// <summary>A container of contiguous allocated elements.
///
/// Since EFL 1.23.
/// </summary>
public class Array<T> : IEnumerable<T>, IDisposable
{
    public static uint DefaultStep = 32;

    /// <summary>Pointer to the native buffer.</summary>
    public IntPtr Handle {get;set;} = IntPtr.Zero;
    ///<summary>Whether this wrapper owns the native buffer.</summary>
    public bool Own {get;set;}
    /// <summary>Who is in charge of releasing the resources wrapped by this instance.</summary>
    public bool OwnContent {get;set;}
    /// <summary> Length of the array.</summary>
    public int Length
    {
        get { return Count(); }
    }

    private void InitNew(uint step)
    {
        Handle = eina_array_new(step);
        Own = true;
        OwnContent = true;
        if (Handle == IntPtr.Zero)
        {
            throw new SEHException("Could not alloc array");
        }
    }

    internal bool InternalPush(IntPtr ele)
    {
        return eina_array_push_custom_export_mono(Handle, ele);
    }

    internal IntPtr InternalPop()
    {
        return eina_array_pop_custom_export_mono(Handle);
    }

    internal IntPtr InternalDataGet(int idx)
    {
        return eina_array_data_get_custom_export_mono(Handle, (uint)idx); // TODO: Check bounds ???
    }

    internal void InternalDataSet(int idx, IntPtr ele)
    {
        eina_array_data_set_custom_export_mono(Handle, (uint)idx, ele); // TODO: Check bounds ???
    }

    /// <summary>
    ///   Create a new array.
    /// </summary>
    public Array()
    {
        InitNew(DefaultStep);
    }

    /// <summary>
    ///   Create a new array.
    /// </summary>
    ///// <param name="step">Step size of the array.</param>
    public Array(uint step)
    {
        InitNew(step);
    }

    /// <summary>
    ///   Create a new array.
    /// </summary>
    ///// <param name="handle">The native handle to be wrapped.</param>
    ///// <param name="own">Whether this wrapper owns the native handle.</param>
    public Array(IntPtr handle, bool own)
    {
        if (handle == IntPtr.Zero)
        {
            throw new ArgumentNullException("Handle can't be null");
        }

        Handle = handle;
        Own = own;
        OwnContent = own;
    }

    /// <summary>
    ///   Create a new array
    /// </summary>
    ///// <param name="handle">The native array to be wrapped.</param>
    ///// <param name="own">Whether this wrapper owns the native array.</param>
    ///// <param name="ownContent">For compatibility with other EFL# containers.</param>
    public Array(IntPtr handle, bool own, bool ownContent)
    {
        if (handle == IntPtr.Zero)
        {
            throw new ArgumentNullException("Handle can't be null");
        }

        Handle = handle;
        Own = own;
        OwnContent = ownContent;
    }

    /// <summary>
    ///   Finalizer to be called from the Garbage Collector.
    /// </summary>
    ~Array()
    {
        Dispose(false);
    }
    /// <summary>Disposes of this wrapper, releasing the native array if owned.</summary>
    /// <param name="disposing">True if this was called from <see cref="Dispose()"/> public method. False if
    /// called from the C# finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        if (h == IntPtr.Zero)
        {
            return;
        }

        if (Own && OwnContent)
        {
            int len = (int)eina_array_count_custom_export_mono(h);
            for (int i = 0; i < len; ++i)
            {
                NativeFree<T>(eina_array_data_get_custom_export_mono(h, (uint)i));
            }
        }

        if (Own)
        {
            if (disposing)
            {
                eina_array_free(h);
            }
            else
            {
                UIKit.Wrapper.Globals.ThreadSafeFreeCbExec(eina_array_free, h);
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
    ///   Releases the native array.
    /// </summary>
    /// <returns>The native array.</returns>
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
                NativeFree<T>(InternalDataGet(i));
            }
        }
    }

    /// <summary>
    ///   Clears an array's elements and deallocates the memory.
    /// </summary>
    public void Clean()
    {
        FreeElementsIfOwned();
        eina_array_clean_custom_export_mono(Handle);
    }

    /// <summary>
    ///   Clears an array's elements and deallocates the memory.
    /// </summary>
    public void Flush()
    {
        FreeElementsIfOwned();
        eina_array_flush(Handle);
    }

    /// <summary>
    ///   Returns the number of elements in an array.
    /// </summary>
    /// <returns>The number of elements.</returns>
    public int Count()
    {
        return (int)eina_array_count_custom_export_mono(Handle);
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

    /// <summary>
    ///   Inserts the element of the array at the end.
    /// </summary>
    ///// <param name="val">The value of the element to be inserted.</param>
    public bool Push(T val)
    {
        IntPtr ele = ManagedToNativeAlloc(val);
        var r = InternalPush(ele);
        if (!r)
        {
            NativeFree<T>(ele);
        }

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

    /// <summary>
    ///   Returns the element of the array at the end.
    /// </summary>
    /// <returns>The element at the end position.</returns>
    public T Pop()
    {
        IntPtr ele = InternalPop();
        var r = NativeToManaged<T>(ele);
        if (OwnContent && ele != IntPtr.Zero)
        {
            NativeFree<T>(ele);
        }

        return r;
    }

    /// <summary>
    ///   Returns the element of the array at the specified position.
    /// </summary>
    ///// <param name="idx">The position of the desired element.</param>
    /// <returns>The element at the specified position</returns>
    public T DataGet(int idx)
    {
        IntPtr ele = InternalDataGet(idx);
        return NativeToManaged<T>(ele);
    }

    /// <summary>
    ///   Returns the element of the array at the specified position.
    /// </summary>
    ///// <param name="idx">The position of the desired element.</param>
    /// <returns>The element at the specified position</returns>
    public T At(int idx)
    {
        return DataGet(idx);
    }

    /// <summary>
    ///  Replaces the element at the specified position.
    /// </summary>
    ///// <param name="idx">The position of the desired element.</param>
    ///// <param name="val">The value of the element to be inserted.</param>
    public void DataSet(int idx, T val)
    {
        IntPtr ele = InternalDataGet(idx); // TODO: check bondaries ??
        if (OwnContent && ele != IntPtr.Zero)
        {
            NativeFree<T>(ele);
        }

        ele = ManagedToNativeAlloc(val);
        InternalDataSet(idx, ele);
    }

    public T this[int idx]
    {
        get
        {
            return DataGet(idx);
        }
        set
        {
            DataSet(idx, value);
        }
    }

    /// <summary>
    ///   Returns a array containing all of the elements in proper sequence.
    /// </summary>
    /// <returns>A array</returns>
    public T[] ToArray()
    {
        int len = Length;
        var managed = new T[len];
        for (int i = 0; i < len; ++i)
        {
            managed[i] = DataGet(i);
        }

        return managed;
    }

    /// <summary>
    ///   Appends all elements at the end of array.
    /// </summary>
    public bool Append(T[] values)
    {
        foreach (T v in values)
        {
            if (!Push(v))
            {
                return false;
            }
        }

        return true;
    }


    /// <summary> Gets an Iterator for this Array.</summary>
    public UIKit.DataTypes.Iterator<T> GetIterator()
    {
        return new UIKit.DataTypes.Iterator<T>(eina_array_iterator_new(Handle), true);
    }

    /// <summary> Gets an Enumerator for this Array.</summary>
    public IEnumerator<T> GetEnumerator()
    {
        int len = Length;
        for (int i = 0; i < len; ++i)
        {
            yield return DataGet(i);
        }
    }

     /// <summary> Gets an Enumerator for this Array.</summary>
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary> Gets an Accessor for this Array.</summary>
    public UIKit.DataTypes.Accessor<T> GetAccessor()
    {
        return new UIKit.DataTypes.Accessor<T>(eina_array_accessor_new(Handle), Ownership.Managed);
    }
}

}

}

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
#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

using static CoreUI.DataTypes.TraitFunctions;
using static CoreUI.DataTypes.ArrayNativeFunctions;

namespace CoreUI.DataTypes
{

[EditorBrowsable(EditorBrowsableState.Never)]
internal static class ArrayNativeFunctions
{
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_array_new(uint step);
    [DllImport(CoreUI.Libs.Eina)] internal static extern void
        eina_array_free(IntPtr array);
    [DllImport(CoreUI.Libs.Eina)] internal static extern void
        eina_array_flush(IntPtr array);
    public delegate bool KeepCb(IntPtr data, IntPtr gdata);
    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_array_remove(IntPtr array, KeepCb keep, IntPtr gdata);
    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_array_push(IntPtr array, IntPtr data);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_array_iterator_new(IntPtr array);
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_array_accessor_new(IntPtr array);
    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool
        eina_array_find(IntPtr array, IntPtr data,
                        uint out_idx);

    [DllImport(CoreUI.Libs.CustomExports)] internal static extern void
        eina_array_clean_custom_export_mono(IntPtr array);
    [DllImport(CoreUI.Libs.CustomExports)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_array_push_custom_export_mono(IntPtr array, IntPtr data);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern IntPtr
        eina_array_pop_custom_export_mono(IntPtr array);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern IntPtr
        eina_array_data_get_custom_export_mono(IntPtr array, uint idx);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern void
        eina_array_data_set_custom_export_mono(IntPtr array, uint idx, IntPtr data);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern uint
        eina_array_count_custom_export_mono(IntPtr array);

    [DllImport(CoreUI.Libs.CustomExports)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_array_foreach_custom_export_mono(IntPtr array, IntPtr cb, IntPtr fdata);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern void
        eina_array_insert_at_custom_export_mono(IntPtr array, uint index, IntPtr data);
}

/// <summary>A container of contiguous allocated elements.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
                 Justification="This is a generalized container mapping the native one.")] 
public class Array<T> : IList<T>, IEnumerable<T>, IDisposable
{
    public const uint DefaultStep = 32;

    /// <summary>Pointer to the native buffer.</summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IntPtr Handle { get; set; } = IntPtr.Zero;

    /// <summary>Whether this wrapper owns the native buffer.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    internal bool Own { get; set; }

    /// <summary>Who is in charge of releasing the resources wrapped by
    /// this instance.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    internal bool OwnContent { get; set; }

    /// <summary> Gets the number of elements contained in the <see cref="Array{T}" />.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public int Count
    {
        get => (int)eina_array_count_custom_export_mono(Handle); 
    }

    /// <summary>
    ///   Gets a value indicating whether the <see cref="Array" /> is read-only.
    ///<para>
    ///  It's the negative of <see cref="OwnContent" />.
    ///</para>
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public bool IsReadOnly { get => !OwnContent; }

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
        => eina_array_push_custom_export_mono(Handle, ele);

    internal IntPtr InternalPop()
        => eina_array_pop_custom_export_mono(Handle);

    internal IntPtr InternalDataGet(int idx)
        => eina_array_data_get_custom_export_mono(Handle, CheckBounds(idx));

    internal void InternalDataSet(int idx, IntPtr ele)
        => eina_array_data_set_custom_export_mono(Handle, CheckBounds(idx), ele);

    private uint CheckBounds(int idx)
    {
        if (!(0 <= idx && idx < Count))
        {
            throw new ArgumentOutOfRangeException(nameof(idx), $"{nameof(idx)} is out of bounds.");
        }

        return (uint)idx;
    }

    private U LoopingThrough<U>(T val, Func<int, U> f1, Func<U> f2)
    {
        for (int i = 0, count = Count; i < count; ++i)
        {
            if (NativeToManaged<T>(InternalDataGet(i)).Equals(val))
            {
                return f1(i);
            }
        }

        return f2();
    }

    private void CheckOwnerships()
    {
        if ((Own == false) && (OwnContent == true))
        {
            throw new InvalidOperationException(nameof(Own) + "/" + nameof(OwnContent));
        }
    }

    private void RequireWritable()
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException("This object's instance is read only.");
        }
    }

    private void DeleteData(IntPtr ele)
    {
        if (OwnContent)
        {
            NativeFree<T>(ele);
        }
    }

    /// <summary>
    ///   Create a new array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public Array()
    {
        InitNew(DefaultStep);
    }

    /// <summary>
    ///   Create a new array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="step">Step size of the array.</param>
    public Array(uint step)
    {
        InitNew(step);
    }

    /// <summary>
    ///   Create a new array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="handle">The native handle to be wrapped.</param>
    /// <param name="own">Whether this wrapper owns the native handle.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Array(IntPtr handle, bool own)
    {
        Handle = (handle != IntPtr.Zero)
            ? handle
            : throw new ArgumentNullException(nameof(handle),
                                              $"{nameof(Handle)} can't be null");
        Own = own;
        OwnContent = own;
        CheckOwnerships();
    }

    /// <summary>
    ///   Create a new array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="handle">The native array to be wrapped.</param>
    /// <param name="own">Whether this wrapper owns the native array.</param>
    /// <param name="ownContent">For compatibility with other EFL# containers.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Array(IntPtr handle, bool own, bool ownContent)
    {
        Handle = (handle != IntPtr.Zero)
            ? handle
            : throw new ArgumentNullException(nameof(handle),
                                              $"{nameof(Handle)} can't be null");
        Own = own;
        OwnContent = ownContent;
        CheckOwnerships();
    }

    /// <summary>
    ///   Finalizer to be called from the Garbage Collector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    ~Array()
    {
        Dispose(false);
    }
    /// <summary>Disposes of this wrapper, releasing the native array if owned.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
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

        for (int len = (int)eina_array_count_custom_export_mono(h),
                 i = 0; i < len; ++i)
        {
            if (!OwnContent)
            {
                break;
            }

            DeleteData(eina_array_data_get_custom_export_mono(h, (uint)i));
        }
        
        if (Own)
        {
            if (disposing)
            {
                eina_array_free(h);
            }
            else
            {
                CoreUI.Wrapper.Globals.ThreadSafeFreeCbExec(eina_array_free, h);
            }
        }
    }

    /// <summary>Releases the native resources held by this instance.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Releases the native resources held by this instance.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Free()
    {
        Dispose();
    }

    private void FreeElementsIfOwned()
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException("This object's instance is read only.");
        }

        for (int i = 0, count = Count; i < count; ++i)
        {
            DeleteData(InternalDataGet(i));
        }
    }

    /// <summary>
    ///   Clears an array's elements and deallocates the memory.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Clean()
    {
        FreeElementsIfOwned();
        eina_array_clean_custom_export_mono(Handle);
    }

    /// <summary>
    ///   Clears an array's elements and deallocates the memory.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Flush()
    {
        FreeElementsIfOwned();
        eina_array_flush(Handle);
    }

    internal void SetOwnership(bool ownAll)
    {
        Own = ownAll;
        OwnContent = ownAll;
        CheckOwnerships();
    }

    internal void SetOwnership(bool own, bool ownContent)
    {
        Own = own;
        OwnContent = ownContent;
        CheckOwnerships();
    }

    /// <summary>
    ///   Inserts the element of the array at the end.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val">The value of the element to be inserted.</param>
    public bool Push(T val)
    {
        RequireWritable();

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
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The element at the end position.</returns>
    public T Pop()
    {
        RequireWritable();

        IntPtr ele = InternalPop();
        var r = NativeToManaged<T>(ele);
        if (ele != IntPtr.Zero)
        {
            DeleteData(ele);
        }

        return r;
    }

    /// <summary>
    ///   Returns the element of the array at the specified position.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">The position of the desired element.</param>
    /// <returns>The element at the specified position</returns>
    public T DataGet(int idx)
        => NativeToManaged<T>(InternalDataGet(idx));

    /// <summary>
    ///   Returns the element of the array at the specified position.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">The position of the desired element.</param>
    /// <returns>The element at the specified position</returns>
    public T At(int idx)
        => DataGet(idx);


    /// <summary>
    ///  Replaces the element at the specified position.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">The position of the desired element.</param>
    /// <param name="val">The value of the element to be inserted.</param>
    internal void DataSet(int idx, T val)
    {
        RequireWritable();

        IntPtr ele = InternalDataGet(idx);
        if (ele != IntPtr.Zero)
        {
            DeleteData(ele);
        }

        InternalDataSet(idx, ManagedToNativeAlloc(val));
    }

    /// <summary>
    ///   Accessor by index to the elements of this list.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
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
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A array</returns>
    public T[] ToArray()
    {
        int len = Count;
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
    /// <since_tizen> 6 </since_tizen>
    public bool Append(T[] values)
    {
        Contract.Requires(values != null, nameof(values));
        foreach (T v in values)
        {
            if (!Push(v))
            {
                return false;
            }
        }

        return true;
    }


    /// <summary> Gets an Iterator for this Array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Iterator<T> GetIterator()
        => new CoreUI.DataTypes.Iterator<T>(eina_array_iterator_new(Handle), true);

    /// <summary> Gets an Enumerator for this Array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0, count = Count; i < count; ++i)
        {
            yield return DataGet(i);
        }
    }

    /// <summary> Gets an Enumerator for this Array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        => this.GetEnumerator();

    /// <summary> Gets an Accessor for this Array.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Accessor<T> GetAccessor()
        => new CoreUI.DataTypes.Accessor<T>(eina_array_accessor_new(Handle), Ownership.Managed);

    /// <summary>
    ///   Removes the first occurrence of a specific object.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val">The object to remove.</param>
    public bool Remove(T val)
        => LoopingThrough(val,
                          (i) =>
        {
            RemoveAt(i);
            return true;
        }, () => false);

    /// <summary>
    ///   Adds an item.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val">The object to add.</param>
    public void Add(T val) => Push(val);

    /// <summary>
    ///   Removes all items.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Clear() => Clean();

    /// <summary>
    ///   Determines whether the <see cref="Array{T}" /> contains a specific value.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val">The object to locate.</param>
    public bool Contains(T val)
        => LoopingThrough(val, (i) => true, () => false);

    /// <summary>
    ///   Copies the elements of the <see cref="Array{T}" /> to an
    /// <see cref="Array" />, starting at a particular <see cref="Array" /> index.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="array">The one-dimensional <see cref="Array" /> that is the
    /// destination of the elements copied from <see cref="Array{T}" />.
    /// The <see cref="Array" /> must have zero-based indexing.</param>
    /// <param name="arrayIndex">The zero-based index in array at which copying
    /// begins.</param>
    public void CopyTo(T[] array, int arrayIndex)
        => ToArray().CopyTo(array, arrayIndex);

    /// <summary>
    ///   Determines the index of a specific item.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val">The object to locate.</param>
    public int IndexOf(T val)
        => LoopingThrough(val, (i) => i, () => -1);

    /// <summary>
    ///   Inserts an item to the <see cref="Array{T}" /> at the specified index.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="index">The zero-based index at which item should be inserted.</param>
    /// <param name="val">The object to insert.</param>
    public void Insert(int index, T val)
    {
        RequireWritable();

        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"{nameof(index)} cannot be negative.");
        }

        if (Count < index)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"{nameof(index)} is greater than {nameof(Count)} + 1.");
        }

        if (index == Count)
        {
            Push(val);
            return;
        }
        
        eina_array_insert_at_custom_export_mono(Handle, (uint)index,
                                                ManagedToNativeAlloc(val));
    }

    /// <summary>
    ///   Removes the <see cref="Array{T}" /> item at the specified index.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="index">The zero-based index of the item to remove.</param>
    public void RemoveAt(int index)
    {
        RequireWritable();

        var ele = InternalDataGet(index);
        DeleteData(ele);
        eina_array_remove(Handle, (data,gdata)
                          => ele != data,
                          IntPtr.Zero);
    }
}

}

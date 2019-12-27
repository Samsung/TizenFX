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

using static CoreUI.DataTypes.TraitFunctions;
using static CoreUI.DataTypes.IteratorNativeFunctions;
using static CoreUI.DataTypes.HashNativeFunctions;
using CoreUI.DataTypes.Callbacks;

namespace CoreUI.DataTypes
{

[StructLayout(LayoutKind.Sequential)]
[EditorBrowsable(EditorBrowsableState.Never)]    
internal struct HashTupleNative : IEquatable<HashTupleNative>
{
    public IntPtr key;
    public IntPtr data;
    public uint   key_length;

    /// <summary>
    ///   Gets a hash for <see cref="HashTupleNative" />.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A hash code.</returns>
    public override int GetHashCode()
        => key.GetHashCode() ^ data.GetHashCode() ^ key_length.GetHashCode();

    /// <summary>Returns whether this <see cref="HashTupleNative" />
    /// is equal to the given <see cref="object" />.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="other">The <see cref="object" /> to be compared to.</param>
    /// <returns><c>true</c> if is equal to <c>other</c>.</returns>
    public override bool Equals(object other)
        => (!(other is HashTupleNative)) ? false : Equals((HashTupleNative)other);

    /// <summary>Returns whether this <see cref="HashTupleNative" /> is equal
    /// to the given <see cref="HashTupleNative" />.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="other">The <see cref="HashTupleNative" /> to be compared to.</param>
    /// <returns><c>true</c> if is equal to <c>other</c>.</returns>
    public bool Equals(HashTupleNative other)
        => (key == other.key) && (data == other.data)
        && (key_length == other.key_length);

    /// <summary>Returns whether <c>lhs</c> is equal to <c>rhs</c>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="lhs">The left hand side of the operator.</param>
    /// <param name="rhs">The right hand side of the operator.</param>
    /// <returns><c>true</c> if <c>lhs</c> is equal
    /// to <c>rhs</c>.</returns>
    public static bool operator==(HashTupleNative lhs, HashTupleNative rhs)
        => lhs.Equals(rhs);

    /// <summary>Returns whether <c>lhs</c> is not equal to <c>rhs</c>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="lhs">The left hand side of the operator.</param>
    /// <param name="rhs">The right hand side of the operator.</param>
    /// <returns><c>true</c> if <c>lhs</c> is not equal
    /// to <c>rhs</c>.</returns>
    public static bool operator!=(HashTupleNative lhs, HashTupleNative rhs) => !(lhs == rhs);
}

[EditorBrowsable(EditorBrowsableState.Never)]
internal static class HashNativeFunctions
{
    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_hash_new(IntPtr key_length_cb, IntPtr key_cmp_cb, IntPtr key_hash_cb, IntPtr data_free_cb, int buckets_power_size);

    [DllImport(CoreUI.Libs.Eina)] internal static extern void
        eina_hash_free_cb_set(IntPtr hash, IntPtr data_free_cb);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_hash_string_djb2_new(IntPtr data_free_cb);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_hash_string_superfast_new(IntPtr data_free_cb);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_hash_string_small_new(IntPtr data_free_cb);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_hash_int32_new(IntPtr data_free_cb);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_hash_int64_new(IntPtr data_free_cb);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_hash_pointer_new(IntPtr data_free_cb);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_hash_stringshared_new(IntPtr data_free_cb);

    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_hash_add(IntPtr hash, IntPtr key, IntPtr data);

    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_hash_direct_add(IntPtr hash, IntPtr key, IntPtr data);

    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_hash_del(IntPtr hash, IntPtr key, IntPtr data);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_hash_find(IntPtr hash, IntPtr key);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_hash_modify(IntPtr hash, IntPtr key, IntPtr data);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_hash_set(IntPtr hash, IntPtr key, IntPtr data);

    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_hash_move(IntPtr hash, IntPtr old_key, IntPtr new_key);

    [DllImport(CoreUI.Libs.Eina)] internal static extern void
        eina_hash_free(IntPtr hash);

    [DllImport(CoreUI.Libs.Eina)] internal static extern void
        eina_hash_free_buckets(IntPtr hash);

    [DllImport(CoreUI.Libs.Eina)] internal static extern int
        eina_hash_population(IntPtr hash);

    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_hash_add_by_hash(IntPtr hash, IntPtr key, int key_length, int key_hash, IntPtr data);

    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_hash_direct_add_by_hash(IntPtr hash, IntPtr key, int key_length, int key_hash, IntPtr data);

    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_hash_del_by_key_hash(IntPtr hash, IntPtr key, int key_length, int key_hash);

    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_hash_del_by_key(IntPtr hash, IntPtr key);

    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_hash_del_by_data(IntPtr hash, IntPtr data);

    [DllImport(CoreUI.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_hash_del_by_hash(IntPtr hash, IntPtr key, int key_length, int key_hash, IntPtr data);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_hash_find_by_hash(IntPtr hash, IntPtr key, int key_length, int key_hash);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_hash_modify_by_hash(IntPtr hash, IntPtr key, int key_length, int key_hash, IntPtr data);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_hash_iterator_key_new(IntPtr hash);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_hash_iterator_data_new(IntPtr hash);

    [DllImport(CoreUI.Libs.Eina)] internal static extern IntPtr
        eina_hash_iterator_tuple_new(IntPtr hash);

    [DllImport(CoreUI.Libs.Eina)] internal static extern void
        eina_hash_foreach(IntPtr hash, IntPtr func, IntPtr fdata);


    [DllImport(CoreUI.Libs.Eina)] internal static extern void
        eina_hash_list_append(IntPtr hash, IntPtr key, IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] internal static extern void
        eina_hash_list_prepend(IntPtr hash, IntPtr key, IntPtr data);
    [DllImport(CoreUI.Libs.Eina)] internal static extern void
        eina_hash_list_remove(IntPtr hash, IntPtr key, IntPtr data);

    [DllImport(CoreUI.Libs.Eina)] internal static extern int
        eina_hash_superfast(string key, int len);

    [DllImport(CoreUI.Libs.CustomExports)] internal static extern IntPtr
        eina_hash_iterator_ptr_key_wrapper_new_custom_export_mono(IntPtr hash);
}

/// <summary>Wrapper around native dictionary mapping keys to values.
///
/// </summary>
/// <since_tizen> 6 </since_tizen>
[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
                 Justification = "This is a generalized container mapping the native one.")]
public class Hash<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IDisposable
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IntPtr Handle {get; set;} = IntPtr.Zero;
    /// <summary>Whether this wrapper owns the native hash.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public bool Own {get; set;}
    /// <summary>Whether this wrapper owns the key.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public bool OwnKey {get; set;}
    /// <summary>Whether this wrapper owns the value.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public bool OwnValue {get; set;}

    /// <summary>Quantity of elements in the hash.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public int Count
    {
        get
        {
            return Population();
        }
    }


    private void InitNew()
    {
        Handle = EinaHashNew<TKey>();
        SetOwn(true);
        SetOwnKey(true);
        SetOwnValue(true);
    }

    /// <summary>Default constructor.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public Hash()
    {
        InitNew();
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Hash(IntPtr handle, bool own)
    {
        Handle = handle;
        SetOwnership(own);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Hash(IntPtr handle, bool own, bool ownKey, bool ownValue)
    {
        Handle = handle;
        SetOwnership(own, ownKey, ownValue);
    }

    /// <summary>Default destructor.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    ~Hash()
    {
        Dispose(false);
    }

    /// <summary>Disposes of this wrapper, releasing the native accessor if
    /// owned.
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

        if (Own)
        {
            if (disposing)
            {
                eina_hash_free(h);
            }
            else
            {
                CoreUI.Wrapper.Globals.ThreadSafeFreeCbExec(eina_hash_free, h);
            }
        }
    }

    /// <summary>Release the native resources held by this instance.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Release the native resources held by this instance.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Free()
    {
        Dispose();
    }

    /// <summary>Release the pointer.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The instance.</returns>
    public IntPtr Release()
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        return h;
    }

    /// <summary>Sets ownership.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="own">If the hash own the object.</param>
    public void SetOwn(bool own)
    {
        Own = own;
    }

    /// <summary>Sets key's ownership.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="ownKey">If the hash own the key's object.</param>
    public void SetOwnKey(bool ownKey)
    {
        OwnKey = ownKey;
    }

    /// <summary>Sets value's ownership.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="ownValue">If the hash own the value's object.</param>
    public void SetOwnValue(bool ownValue)
    {
        OwnValue = ownValue;

        if (ownValue)
        {
            eina_hash_free_cb_set(Handle, EinaFreeCb<TValue>());
        }
    }

    /// <summary>Sets all ownership.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="ownAll">If the hash own for all ownerships.</param>
    public void SetOwnership(bool ownAll)
    {
        SetOwn(ownAll);
        SetOwnKey(ownAll);
        SetOwnValue(ownAll);
    }

    /// <summary>Sets own individually.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="own">If the hash own the object.</param>
    /// <param name="ownKey">If the hash own the key's object.</param>
    /// <param name="ownValue">If the hash own the value's object.</param>
    public void SetOwnership(bool own, bool ownKey, bool ownValue)
    {
        SetOwn(own);
        SetOwnKey(ownKey);
        SetOwnValue(ownValue);
    }

    /// <summary>
    ///   Cleanup for the hash.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void UnSetFreeCb()
    {
        eina_hash_free_cb_set(Handle, IntPtr.Zero);
    }

    /// <summary>
    ///   Adds an entry to the hash.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key">A unique key.</param>
    /// <param name="val">The value to associate with the key.</param>
    /// <returns> false if an error occurred, true otherwise.</returns>
    public bool AddNew(TKey key, TValue val)
    {
        IntPtr gchnk = CopyNativeObject(key, ForceRefKey<TKey>());
        IntPtr nk = GetNativePtr<TKey>(gchnk, ForceRefKey<TKey>());
        IntPtr gchnv = CopyNativeObject(val, false);
        IntPtr nv = GetNativePtr<TValue>(gchnv, false);
        var r = eina_hash_add(Handle, nk, nv);
        FreeNativeIndirection<TKey>(gchnk, ForceRefKey<TKey>());
        FreeNativeIndirection<TValue>(gchnv, false);
        return r;
    }

    /// <summary>
    ///   Modifies the entry at the specified key.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key">The key of the entry to modify.</param>
    /// <param name="val">The value to replace the previous entry.</param>
    public void Add(TKey key, TValue val)
    {
        Set(key, val);
    }

    /// <summary>
    ///   Removes the entry identified by a key from the hash.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key">The key.</param>
    public bool DelByKey(TKey key)
    {
        IntPtr gchnk = CopyNativeObject(key, ForceRefKey<TKey>());
        IntPtr nk = GetNativePtr<TKey>(gchnk, ForceRefKey<TKey>());
        var r = eina_hash_del_by_key(Handle, nk);
        FreeNativeIndirection<TKey>(gchnk, ForceRefKey<TKey>());
        return r;
    }

    /// <summary>Searches this hash for <c>val</c> and deletes it from the hash,
    /// also deleting it.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val">The value to be deleted.</param>
    /// <returns><c>true</c> if the value was found and deleted, false if it was <c>null</c> or not found.</returns>
    public bool DelByValue(TValue val)
    {
        // We don't use the C version of `eina_hash_del_by_data` because it requires the exact pointer
        // we passed to add(). As our hashes store the data by pointer, this makes it harder to pass the
        // same value.
        if (val == null)
        {
            return false;
        }

        foreach (var pair in this)
        {
            if (pair.Value != null && val.Equals(pair.Value))
            {
                return this.DelByKey(pair.Key);
            }
        }

        return false;

    }

    /// <summary>
    ///   Removes the entry identified by a key from the hash.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key">The key.</param>
    public void Remove(TKey key)
    {
        DelByKey(key);
    }

    /// <summary>
    ///   Retrieves a specific entry in the hash.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key">The key of the entry to find.</param>
    /// <returns>The value of the entry.</returns>
    public TValue Find(TKey key)
    {
        var gchnk = CopyNativeObject<TKey>(key, ForceRefKey<TKey>());
        var nk = GetNativePtr<TKey>(gchnk, ForceRefKey<TKey>());
        var found = eina_hash_find(Handle, nk);
        //NativeFreeRef<TKey>(nk);
        FreeNativeIndirection<TKey>(gchnk, ForceRefKey<TKey>());
        if (found == IntPtr.Zero)
        {
            throw new KeyNotFoundException();
        }

        return NativeToManaged<TValue>(IndirectNative<TValue>(found, false));
    }

    /// <summary>
    ///   Check if key is present. if not, a default value is setted.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key">The key to be checked.</param>
    /// <param name="val">[out] The value of the entry.</param>
    /// <returns>true if key exists, false otherwise.</returns>
    public bool TryGetValue(TKey key, out TValue val)
    {
        var gchnk = CopyNativeObject<TKey>(key, ForceRefKey<TKey>());
        var nk = GetNativePtr<TKey>(gchnk, ForceRefKey<TKey>());
        var found = eina_hash_find(Handle, nk);
        FreeNativeIndirection<TKey>(gchnk, ForceRefKey<TKey>());
        if (found == IntPtr.Zero)
        {
            val = default(TValue);
            return false;
        }

        val = NativeToManaged<TValue>(IndirectNative<TValue>(found, false));
        return true;
    }

    /// <summary>
    ///   Check if key is present.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key">The key to be checked.</param>
    /// <returns>true if key exists, false otherwise.</returns>
    public bool ContainsKey(TKey key)
    {
        var gchnk = CopyNativeObject<TKey>(key, ForceRefKey<TKey>());
        var nk = GetNativePtr<TKey>(gchnk, ForceRefKey<TKey>());
        // var nk = ManagedToNativeAllocRef(key);
        var found = eina_hash_find(Handle, nk);
        // NativeFreeRef<TKey>(nk);
        FreeNativeIndirection<TKey>(gchnk, ForceRefKey<TKey>());
        return found != IntPtr.Zero;
    }

    /// <summary>
    ///   Modifies the speficied key if exists.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key">The key to modify.</param>
    /// <param name="val"> The new value.</param>
    /// <returns>False if key do not exists, true otherwise.</returns>
    public bool Modify(TKey key, TValue val)
    {
        var gchnk = CopyNativeObject<TKey>(key, ForceRefKey<TKey>());
        var nk = GetNativePtr<TKey>(gchnk, ForceRefKey<TKey>());
        var gchnv = CopyNativeObject<TValue>(val, false);
        var nv = GetNativePtr<TValue>(gchnv, false);
        var old = eina_hash_modify(Handle, nk, nv);
        FreeNativeIndirection<TKey>(gchnk, ForceRefKey<TKey>());
        // NativeFreeRef<TKey>(nk);
        if (old == IntPtr.Zero)
        {
            NativeFree<TValue>(nv);
            return false;
        }

        if (OwnValue)
        {
            NativeFree<TValue>(old);
        }

        return true;
    }

    private static bool ForceRefKey<T>()
    {
        return (!typeof(T).IsValueType)
               && (typeof(T) != typeof(string))
               && (typeof(T) != typeof(CoreUI.DataTypes.Stringshare));
    }

    private static IntPtr CopyNativeObject<T>(T value, bool forceRef)
    {
        if (!IsCoreUIObject(typeof(T)) && forceRef)
        {
            GCHandle gch = GCHandle.Alloc(new byte[Marshal.SizeOf<T>()], GCHandleType.Pinned);
            IntPtr pin = gch.AddrOfPinnedObject();

            ManagedToNativeCopyTo(value, pin);

            return GCHandle.ToIntPtr(gch);
        }
        else if (IsCoreUIObject(typeof(T)) && forceRef)
        {
            GCHandle gch = GCHandle.Alloc(new byte[Marshal.SizeOf<IntPtr>()], GCHandleType.Pinned);
            IntPtr pin = gch.AddrOfPinnedObject();

            ManagedToNativeCopyTo(value, pin);

            return GCHandle.ToIntPtr(gch);
        }
        else
        {
            return ManagedToNativeAlloc(value);
        }
    }

    private static IntPtr GetNativePtr<T>(IntPtr gchptr, bool forceRef)
    {
        if (forceRef)
        {
            GCHandle gch = GCHandle.FromIntPtr(gchptr);
            IntPtr pin = gch.AddrOfPinnedObject();

            return pin;
        }
        else
        {
            return gchptr;
        }
    }

    private static void FreeNativeIndirection<T>(IntPtr gchptr, bool forceRef)
    {
        if (forceRef)
        {
            GCHandle gch = GCHandle.FromIntPtr(gchptr);
            gch.Free();
        }
    }

    private static IntPtr IndirectNative<T>(IntPtr ptr, bool forceRef)
    {
        if (forceRef)
        {
            IntPtr val = Marshal.ReadIntPtr(ptr);
            return val;
        }
        else
        {
            return ptr;
        }
    }


    /// <summary>
    ///   Modifies the entry at the specified key. Adds if key is not found.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key">The key to modify.</param>
    /// <param name="val">The value to replace the previous entry.</param>
    public void Set(TKey key, TValue val)
    {
        IntPtr gchnk = CopyNativeObject(key, ForceRefKey<TKey>());
        IntPtr nk = GetNativePtr<TKey>(gchnk, ForceRefKey<TKey>());

        IntPtr gchnv = CopyNativeObject(val, false);
        IntPtr nv = GetNativePtr<TValue>(gchnv, false);
        IntPtr old = eina_hash_set(Handle, nk, nv);
        FreeNativeIndirection<TKey>(gchnk, ForceRefKey<TKey>());
        FreeNativeIndirection<TValue>(gchnv, false);
        if (OwnValue && old != IntPtr.Zero)
        {
            NativeFree<TValue>(old);
        }
    }

    /// <summary>
    ///   Accessor by key to the hash.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public TValue this[TKey key]
    {
        get
        {
            return Find(key);
        }
        set
        {
            Set(key, value);
        }
    }

    /// <summary>
    ///   Changes the keys of an entry in the hash.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key_old">The current key with data.</param>
    /// <param name="key_new">The new key with data.</param>
    /// <returns>false in any case but success, true on success.</returns>
    public bool Move(TKey key_old, TKey key_new)
    {
        IntPtr gchnko = CopyNativeObject(key_old, ForceRefKey<TKey>());
        IntPtr nko = GetNativePtr<TKey>(gchnko, ForceRefKey<TKey>());
        IntPtr gchnk = CopyNativeObject(key_new, ForceRefKey<TKey>());
        IntPtr nk = GetNativePtr<TKey>(gchnk, ForceRefKey<TKey>());
        // var nk_old = ManagedToNativeAllocRef(key_old);
        // var nk_new = ManagedToNativeAllocRef(key_new, true);
        var r = eina_hash_move(Handle, nko, nk);
        FreeNativeIndirection<TKey>(gchnko, ForceRefKey<TKey>());
        FreeNativeIndirection<TKey>(gchnk, ForceRefKey<TKey>());
        // NativeFreeRef<TKey>(nk_old, OwnKey && r);
        // NativeFreeRef<TKey>(nk_new, !r);
        return r;
    }

    /// <summary>
    ///   Frees the hash buckets.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void FreeBuckets()
    {
        eina_hash_free_buckets(Handle);
    }

    /// <summary>
    ///   Returns the number of entries in the hash.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The number of entries, 0 on error.</returns>
    public int Population()
    {
        return eina_hash_population(Handle);
    }

    /// <summary>
    ///   Gets an Iterator for keys.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Iterator<TKey> Keys()
    {
        return new CoreUI.DataTypes.Iterator<TKey>(EinaHashIteratorKeyNew<TKey>(Handle), true);
    }

    /// <summary>
    ///   Gets An Iterator for values.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Iterator<TValue> Values()
    {
        return new CoreUI.DataTypes.Iterator<TValue>(eina_hash_iterator_data_new(Handle), true);
    }

    /// <summary>
    ///   Gets an Iterator for hask.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        IntPtr itr = eina_hash_iterator_tuple_new(Handle);
        try
        {
            for (IntPtr tuplePtr; eina_iterator_next(itr, out tuplePtr);)
            {
                var tuple = Marshal.PtrToStructure<CoreUI.DataTypes.HashTupleNative>(tuplePtr);
                IntPtr ikey = IndirectNative<TKey>(tuple.key, ForceRefKey<TKey>());
                var key = NativeToManaged<TKey>(ikey);
                var val = NativeToManaged<TValue>(tuple.data);
                yield return new KeyValuePair<TKey, TValue>(key, val);
            }
        }
        finally
        {
            eina_iterator_free(itr);
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

}

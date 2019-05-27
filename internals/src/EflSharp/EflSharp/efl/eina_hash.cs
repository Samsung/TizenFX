#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

using static Eina.TraitFunctions;
using static Eina.IteratorNativeFunctions;
using static Eina.HashNativeFunctions;
using Eina.Callbacks;

namespace Eina
{

[StructLayout(LayoutKind.Sequential)]
public struct HashTupleNative
{
    public IntPtr key;
    public IntPtr data;
    public uint   key_length;
}

public static class HashNativeFunctions
{
    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_hash_new(IntPtr key_length_cb, IntPtr key_cmp_cb, IntPtr key_hash_cb, IntPtr data_free_cb, int buckets_power_size);

    [DllImport(efl.Libs.Eina)] public static extern void
        eina_hash_free_cb_set(IntPtr hash, IntPtr data_free_cb);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_hash_string_djb2_new(IntPtr data_free_cb);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_hash_string_superfast_new(IntPtr data_free_cb);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_hash_string_small_new(IntPtr data_free_cb);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_hash_int32_new(IntPtr data_free_cb);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_hash_int64_new(IntPtr data_free_cb);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_hash_pointer_new(IntPtr data_free_cb);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_hash_stringshared_new(IntPtr data_free_cb);

    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_hash_add(IntPtr hash, IntPtr key, IntPtr data);

    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_hash_direct_add(IntPtr hash, IntPtr key, IntPtr data);

    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_hash_del(IntPtr hash, IntPtr key, IntPtr data);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_hash_find(IntPtr hash, IntPtr key);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_hash_modify(IntPtr hash, IntPtr key, IntPtr data);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_hash_set(IntPtr hash, IntPtr key, IntPtr data);

    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_hash_move(IntPtr hash, IntPtr old_key, IntPtr new_key);

    [DllImport(efl.Libs.Eina)] public static extern void
        eina_hash_free(IntPtr hash);

    [DllImport(efl.Libs.Eina)] public static extern void
        eina_hash_free_buckets(IntPtr hash);

    [DllImport(efl.Libs.Eina)] public static extern int
        eina_hash_population(IntPtr hash);

    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_hash_add_by_hash(IntPtr hash, IntPtr key, int key_length, int key_hash, IntPtr data);

    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_hash_direct_add_by_hash(IntPtr hash, IntPtr key, int key_length, int key_hash, IntPtr data);

    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_hash_del_by_key_hash(IntPtr hash, IntPtr key, int key_length, int key_hash);

    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_hash_del_by_key(IntPtr hash, IntPtr key);

    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_hash_del_by_data(IntPtr hash, IntPtr data);

    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eina_hash_del_by_hash(IntPtr hash, IntPtr key, int key_length, int key_hash, IntPtr data);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_hash_find_by_hash(IntPtr hash, IntPtr key, int key_length, int key_hash);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_hash_modify_by_hash(IntPtr hash, IntPtr key, int key_length, int key_hash, IntPtr data);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_hash_iterator_key_new(IntPtr hash);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_hash_iterator_data_new(IntPtr hash);

    [DllImport(efl.Libs.Eina)] public static extern IntPtr
        eina_hash_iterator_tuple_new(IntPtr hash);

    [DllImport(efl.Libs.Eina)] public static extern void
        eina_hash_foreach(IntPtr hash, IntPtr func, IntPtr fdata);


    [DllImport(efl.Libs.Eina)] public static extern void
        eina_hash_list_append(IntPtr hash, IntPtr key, IntPtr data);
    [DllImport(efl.Libs.Eina)] public static extern void
        eina_hash_list_prepend(IntPtr hash, IntPtr key, IntPtr data);
    [DllImport(efl.Libs.Eina)] public static extern void
        eina_hash_list_remove(IntPtr hash, IntPtr key, IntPtr data);

    [DllImport(efl.Libs.Eina)] public static extern int
        eina_hash_superfast(string key, int len);

    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        eina_hash_iterator_ptr_key_wrapper_new_custom_export_mono(IntPtr hash);
}

public class Hash<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IDisposable
{
    public IntPtr Handle {get; set;} = IntPtr.Zero;
    public bool Own {get; set;}
    public bool OwnKey {get; set;}
    public bool OwnValue {get; set;}

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

    public Hash()
    {
        InitNew();
    }

    public Hash(IntPtr handle, bool own)
    {
        Handle = handle;
        SetOwnership(own);
    }

    public Hash(IntPtr handle, bool own, bool ownKey, bool ownValue)
    {
        Handle = handle;
        SetOwnership(own, ownKey, ownValue);
    }

    ~Hash()
    {
        Dispose(false);
    }

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
                Efl.Eo.Globals.ThreadSafeFreeCbExec(eina_hash_free, h);
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

    public void SetOwn(bool own)
    {
        Own = own;
    }

    public void SetOwnKey(bool ownKey)
    {
        OwnKey = ownKey;
    }

    public void SetOwnValue(bool ownValue)
    {
        OwnValue = ownValue;

        if (ownValue)
        {
            eina_hash_free_cb_set(Handle, EinaFreeCb<TValue>());
        }
    }

    public void SetOwnership(bool ownAll)
    {
        SetOwn(ownAll);
        SetOwnKey(ownAll);
        SetOwnValue(ownAll);
    }

    public void SetOwnership(bool own, bool ownKey, bool ownValue)
    {
        SetOwn(own);
        SetOwnKey(ownKey);
        SetOwnValue(ownValue);
    }

    public void UnSetFreeCb()
    {
        eina_hash_free_cb_set(Handle, IntPtr.Zero);
    }

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

    public void Add(TKey key, TValue val)
    {
        Set(key, val);
    }

    public bool DelByKey(TKey key)
    {
        IntPtr gchnk = CopyNativeObject(key, ForceRefKey<TKey>());
        IntPtr nk = GetNativePtr<TKey>(gchnk, ForceRefKey<TKey>());
        var r = eina_hash_del_by_key(Handle, nk);
        FreeNativeIndirection<TKey>(gchnk, ForceRefKey<TKey>());
        // NativeFreeRef<TKey>(nk, OwnKey && r);
        return r;
    }

    public bool DelByValue(TValue val)
    {
        IntPtr gchnv = CopyNativeObject(val, false);
        IntPtr nv = GetNativePtr<TValue>(gchnv, false);
        var r = eina_hash_del_by_data(Handle, nv);
        FreeNativeIndirection<TValue>(gchnv, false);
        return r;
    }

    public void Remove(TKey key)
    {
        DelByKey(key);
    }

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
        return (!typeof(T).IsValueType) && (typeof(T) != typeof(string));
    }

    private static IntPtr CopyNativeObject<T>(T value, bool forceRef)
    {
        if (!IsEflObject(typeof(T)) && forceRef)
        {
            GCHandle gch = GCHandle.Alloc(new byte[Marshal.SizeOf<T>()], GCHandleType.Pinned);
            IntPtr pin = gch.AddrOfPinnedObject();

            ManagedToNativeCopyTo(value, pin);

            return GCHandle.ToIntPtr(gch);
        }
        else if (IsEflObject(typeof(T)) && forceRef)
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

    public void Set(TKey key, TValue val)
    {
        IntPtr gchnk = CopyNativeObject(key, ForceRefKey<TKey>());
        IntPtr nk = GetNativePtr<TKey>(gchnk, ForceRefKey<TKey>());

        IntPtr gchnv = CopyNativeObject(val, false);
        IntPtr nv = GetNativePtr<TValue>(gchnv, false);
        IntPtr old = eina_hash_set(Handle, nk, nv);
        FreeNativeIndirection<TKey>(gchnk, ForceRefKey<TKey>());
        FreeNativeIndirection<TValue>(gchnv, false);
        if (OwnValue || old != IntPtr.Zero)
        {
            NativeFree<TValue>(old);
        }
    }

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

    public void FreeBuckets()
    {
        eina_hash_free_buckets(Handle);
    }

    public int Population()
    {
        return eina_hash_population(Handle);
    }

    public Eina.Iterator<TKey> Keys()
    {
        return new Eina.Iterator<TKey>(EinaHashIteratorKeyNew<TKey>(Handle), true, false);
    }

    public Eina.Iterator<TValue> Values()
    {
        return new Eina.Iterator<TValue>(eina_hash_iterator_data_new(Handle), true, false);
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        IntPtr itr = eina_hash_iterator_tuple_new(Handle);
        try
        {
            for (IntPtr tuplePtr; eina_iterator_next(itr, out tuplePtr);)
            {
                var tuple = Marshal.PtrToStructure<Eina.HashTupleNative>(tuplePtr);
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

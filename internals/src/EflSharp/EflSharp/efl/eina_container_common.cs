#pragma warning disable 1591

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Reflection;

using Eina.Callbacks;
using static Eina.HashNativeFunctions;
using static Eina.InarrayNativeFunctions;
using static Eina.InlistNativeFunctions;
using static Eina.NativeCustomExportFunctions;

namespace Eina
{

public enum ElementType
{
    NumericType,
    StringType,
    ObjectType
};

[StructLayout(LayoutKind.Sequential)]
public struct InlistMem
{
    public IntPtr next {get;set;}
    public IntPtr prev {get;set;}
    public IntPtr last {get;set;}
}

[StructLayout(LayoutKind.Sequential)]
public struct InlistNode<T>
{
    public InlistMem __in_list {get;set;}
    public T Val {get;set;}
}

public interface IBaseElementTraits<T>
{
    IntPtr ManagedToNativeAlloc(T man);
    IntPtr ManagedToNativeAllocInlistNode(T man);
    void ManagedToNativeCopyTo(T man, IntPtr mem);
    void NativeFree(IntPtr nat);
    void NativeFreeInlistNodeElement(IntPtr nat);
    void NativeFreeInlistNode(IntPtr nat, bool freeElement);
    void NativeFreeInplace(IntPtr nat);
    void ResidueFreeInplace(IntPtr nat);
    T NativeToManaged(IntPtr nat);
    T NativeToManagedInlistNode(IntPtr nat);
    T NativeToManagedInplace(IntPtr nat);
    IntPtr EinaCompareCb();
    IntPtr EinaFreeCb();
    IntPtr EinaHashNew();
    IntPtr EinaInarrayNew(uint step);
    IntPtr EinaHashIteratorKeyNew(IntPtr hash);
}

public class StringElementTraits : IBaseElementTraits<string>
{
    public StringElementTraits()
    {
    }

    public IntPtr ManagedToNativeAlloc(string man)
    {
        IntPtr newstring = MemoryNative.StrDup(man);
        return newstring;
    }

    public IntPtr ManagedToNativeAllocInlistNode(string man)
    {
        var node = new InlistNode<IntPtr>();
        node.Val = ManagedToNativeAlloc(man);
        GCHandle pinnedData = GCHandle.Alloc(node, GCHandleType.Pinned);
        IntPtr ptr = pinnedData.AddrOfPinnedObject();
        IntPtr nat = MemoryNative.AllocCopy(ptr, Marshal.SizeOf<InlistMem>() + Marshal.SizeOf<IntPtr>());
        pinnedData.Free();
        return nat;
    }

    public void ManagedToNativeCopyTo(string man, IntPtr mem)
    {
        IntPtr stringptr = ManagedToNativeAlloc(man);
        Marshal.WriteIntPtr(mem, stringptr);
    }

    public void NativeFree(IntPtr nat)
    {
        if (nat != IntPtr.Zero)
        {
            MemoryNative.Free(nat);
        }
    }

    public void NativeFreeInlistNodeElement(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            return;
        }

        var val = Marshal.PtrToStructure<IntPtr>
            (nat + Marshal.SizeOf<InlistMem>());
        NativeFree(val);
    }

    public void NativeFreeInlistNode(IntPtr nat, bool freeElement)
    {
        if (nat == IntPtr.Zero)
        {
            return;
        }

        if (freeElement)
        {
            NativeFreeInlistNodeElement(nat);
        }

        MemoryNative.Free(nat);
    }

    public void NativeFreeInplace(IntPtr nat)
    {
        MemoryNative.FreeRef(nat);
    }

    public void ResidueFreeInplace(IntPtr nat)
    {
    }

    public string NativeToManaged(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            return default(string);
        }

        return StringConversion.NativeUtf8ToManagedString(nat);
    }

    public string NativeToManagedInlistNode(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            Eina.Log.Error("Null pointer for Inlist node.");
            return default(string);
        }

        IntPtr ptr_location = nat + Marshal.SizeOf<InlistMem>();
        return NativeToManaged(Marshal.ReadIntPtr(ptr_location));
    }

    // Strings inplaced are always a pointer, because they are variable-sized
    public string NativeToManagedInplace(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            return default(string);
        }

        nat = Marshal.ReadIntPtr(nat);
        if (nat == IntPtr.Zero)
        {
            return default(string);
        }

        return NativeToManaged(nat);
    }

    public IntPtr EinaCompareCb()
    {
        return MemoryNative.StrCompareFuncPtrGet();
    }

    public IntPtr EinaFreeCb()
    {
        return MemoryNative.FreeFuncPtrGet();
    }

    public IntPtr EinaHashNew()
    {
        return eina_hash_string_superfast_new(IntPtr.Zero);
    }

    public IntPtr EinaInarrayNew(uint step)
    {
        return eina_inarray_new((uint)Marshal.SizeOf<IntPtr>(), step);
    }

    public IntPtr EinaHashIteratorKeyNew(IntPtr hash)
    {
        return eina_hash_iterator_key_new(hash);
    }
}

public class EflObjectElementTraits<T> : IBaseElementTraits<T>
{
    public IntPtr ManagedToNativeAlloc(T man)
    {
        IntPtr h = ((Efl.Eo.IWrapper)man).NativeHandle;
        if (h == IntPtr.Zero)
        {
            return h;
        }

        return Efl.Eo.Globals.efl_ref(h);
    }

    public IntPtr ManagedToNativeAllocInlistNode(T man)
    {
        var node = new InlistNode<IntPtr>();
        node.Val = ManagedToNativeAlloc(man);
        GCHandle pinnedData = GCHandle.Alloc(node, GCHandleType.Pinned);
        IntPtr ptr = pinnedData.AddrOfPinnedObject();
        IntPtr nat = MemoryNative.AllocCopy(ptr, Marshal.SizeOf<InlistMem>() + Marshal.SizeOf<IntPtr>());
        pinnedData.Free();
        return nat;
    }

    public void ManagedToNativeCopyTo(T man, IntPtr mem)
    {
        IntPtr v = ManagedToNativeAlloc(man);
        Marshal.WriteIntPtr(mem, v);
    }

    public void NativeFree(IntPtr nat)
    {
        if (nat != IntPtr.Zero)
        {
            Efl.Eo.Globals.efl_unref(nat);
        }
    }

    public void NativeFreeRef(IntPtr nat, bool unrefs)
    {
        if (unrefs)
        {
            NativeFree(nat);
        }
    }

    public void NativeFreeInlistNodeElement(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            return;
        }

        var val = Marshal.PtrToStructure<IntPtr>
            (nat + Marshal.SizeOf<InlistMem>());
        NativeFree(val);
    }

    public void NativeFreeInlistNode(IntPtr nat, bool freeElement)
    {
        if (nat == IntPtr.Zero)
        {
            return;
        }

        if (freeElement)
        {
            NativeFreeInlistNodeElement(nat);
        }

        MemoryNative.Free(nat);
    }

    public void NativeFreeInplace(IntPtr nat)
    {
        NativeFree(nat);
    }

    public void ResidueFreeInplace(IntPtr nat)
    {
    }

    public T NativeToManaged(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            return default(T);
        }

        return (T) Efl.Eo.Globals.CreateWrapperFor(nat, shouldIncRef: true);
    }

    public T NativeToManagedRef(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            return default(T);
        }

        return NativeToManaged(nat);
    }

    public T NativeToManagedInlistNode(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            Eina.Log.Error("Null pointer for Inlist node.");
            return default(T);
        }

        IntPtr ptr_location = nat + Marshal.SizeOf<InlistMem>();
        return NativeToManaged(Marshal.ReadIntPtr(ptr_location));
    }

    // EFL objects inplaced are always a pointer, because they are variable-sized
    public T NativeToManagedInplace(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            return default(T);
        }

        nat = Marshal.ReadIntPtr(nat);
        if (nat == IntPtr.Zero)
        {
            return default(T);
        }

        return NativeToManaged(nat);
    }

    public IntPtr EinaCompareCb()
    {
        return MemoryNative.PtrCompareFuncPtrGet();
    }

    public IntPtr EinaFreeCb()
    {
        return MemoryNative.EflUnrefFuncPtrGet();
    }

    public IntPtr EinaHashNew()
    {
        return eina_hash_pointer_new(IntPtr.Zero);
    }

    public IntPtr EinaInarrayNew(uint step)
    {
        return eina_inarray_new((uint)Marshal.SizeOf<IntPtr>(), step);
    }

    public IntPtr EinaHashIteratorKeyNew(IntPtr hash)
    {
        return eina_hash_iterator_ptr_key_wrapper_new_custom_export_mono(hash);
    }
}

public abstract class PrimitiveElementTraits<T>
{
    private Eina_Compare_Cb dlgt = null;

    public IntPtr ManagedToNativeAlloc(T man)
    {
        return PrimitiveConversion.ManagedToPointerAlloc(man);
    }

    public IntPtr ManagedToNativeAllocInlistNode(T man)
    {
        var node = new InlistNode<T>();
        node.Val = man;
        GCHandle pinnedData = GCHandle.Alloc(node, GCHandleType.Pinned);
        IntPtr ptr = pinnedData.AddrOfPinnedObject();
        int Tsize = Marshal.SizeOf<T>() < Marshal.SizeOf<IntPtr>() ? Marshal.SizeOf<IntPtr>() : Marshal.SizeOf<T>();
        IntPtr nat = MemoryNative.AllocCopy(ptr, Marshal.SizeOf<InlistMem>() + Tsize);
        pinnedData.Free();
        return nat;
    }

    public void NativeFree(IntPtr nat)
    {
        MemoryNative.Free(nat);
    }

    public void NativeFreeInlistNodeElement(IntPtr nat)
    {
        // Do nothing
    }

    public void NativeFreeInlistNode(IntPtr nat, bool freeElement)
    {
        MemoryNative.Free(nat);
    }

    public void NativeFreeInplace(IntPtr nat)
    {
        // Do nothing
    }

    public void ResidueFreeInplace(IntPtr nat)
    {
        NativeFree(nat);
    }

    public T NativeToManaged(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            Eina.Log.Error("Null pointer on primitive/struct container.");
            return default(T);
        }

        return PrimitiveConversion.PointerToManaged<T>(nat);
    }

    public T NativeToManagedRef(IntPtr nat)
    {
        return NativeToManaged(nat);
    }


    public T NativeToManagedInplace(IntPtr nat)
    {
        return NativeToManaged(nat);
    }

    private int PrimitiveCompareCb(IntPtr ptr1, IntPtr ptr2)
    {
        var m1 = (IComparable)NativeToManaged(ptr1);
        var m2 = NativeToManaged(ptr2);
        return m1.CompareTo(m2);
    }

    public IntPtr EinaCompareCb()
    {
        if (dlgt == null)
        {
            dlgt = new Eina_Compare_Cb(PrimitiveCompareCb);
        }

        return Marshal.GetFunctionPointerForDelegate(dlgt);
    }

    public IntPtr EinaFreeCb()
    {
        return MemoryNative.FreeFuncPtrGet();
    }

    public IntPtr EinaInarrayNew(uint step)
    {
        return eina_inarray_new((uint)Marshal.SizeOf<T>(), step);
    }

    public IntPtr EinaHashIteratorKeyNew(IntPtr hash)
    {
        return eina_hash_iterator_key_new(hash);
    }
}

abstract public class Primitive32ElementTraits<T> : PrimitiveElementTraits<T>, IBaseElementTraits<T>
{
    private static IBaseElementTraits<Int32> int32Traits = null;

    public Primitive32ElementTraits()
    {
        if (int32Traits == null)
        {
            if (typeof(T) == typeof(Int32)) // avoid infinite recursion
            {
                int32Traits = (IBaseElementTraits<Int32>)this;
            }
            else
            {
                int32Traits = TraitFunctions.GetTypeTraits<Int32>();
            }
        }
    }

    public abstract void ManagedToNativeCopyTo(T man, IntPtr mem);
    public abstract T NativeToManagedInlistNode(IntPtr nat);

    public IntPtr ManagedToNativeAllocRef(T man, bool refs)
    {
        return int32Traits.ManagedToNativeAlloc(Convert.ToInt32((object)man));
    }

    public void NativeFreeRef(IntPtr nat, bool unrefs)
    {
        int32Traits.NativeFree(nat);
    }

    public IntPtr EinaHashNew()
    {
        return eina_hash_int32_new(IntPtr.Zero);
    }
}

abstract public class Primitive64ElementTraits<T> : PrimitiveElementTraits<T>, IBaseElementTraits<T>
{
    private static IBaseElementTraits<Int64> int64Traits = null;

    public Primitive64ElementTraits()
    {
        if (int64Traits == null)
        {
            if (typeof(T) == typeof(Int64)) // avoid infinite recursion
            {
                int64Traits = (IBaseElementTraits<Int64>)this;
            }
            else
            {
                int64Traits = TraitFunctions.GetTypeTraits<Int64>();
            }
        }
    }

    public abstract void ManagedToNativeCopyTo(T man, IntPtr mem);
    public abstract T NativeToManagedInlistNode(IntPtr nat);

    public IntPtr ManagedToNativeAllocRef(T man, bool refs)
    {
        return int64Traits.ManagedToNativeAlloc(Convert.ToInt64((object)man));
    }

    public void NativeFreeRef(IntPtr nat, bool unrefs)
    {
        int64Traits.NativeFree(nat);
    }

    public IntPtr EinaHashNew()
    {
        return eina_hash_int64_new(IntPtr.Zero);
    }
}

public class IntElementTraits : Primitive32ElementTraits<int>, IBaseElementTraits<int>
{
    override public void ManagedToNativeCopyTo(int man, IntPtr mem)
    {
        var arr = new int[1];
        arr[0] = man;
        Marshal.Copy(arr, 0, mem, 1);
    }

    override public int NativeToManagedInlistNode(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            Eina.Log.Error("Null pointer for Inlist node.");
            return default(int);
        }

        IntPtr loc = nat + Marshal.SizeOf<InlistMem>();
        var v = new int[1];
        Marshal.Copy(loc, v, 0, 1);
        return v[0];
    }
}

public class CharElementTraits : Primitive32ElementTraits<char>, IBaseElementTraits<char>
{
    override public void ManagedToNativeCopyTo(char man, IntPtr mem)
    {
        var arr = new char[1];
        arr[0] = man;
        Marshal.Copy(arr, 0, mem, 1);
    }

    override public char NativeToManagedInlistNode(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            Eina.Log.Error("Null pointer for Inlist node.");
            return default(char);
        }

        IntPtr loc = nat + Marshal.SizeOf<InlistMem>();
        var v = new char[1];
        Marshal.Copy(loc, v, 0, 1);
        return v[0];
    }
}

public class LongElementTraits : Primitive64ElementTraits<long>, IBaseElementTraits<long>
{
    override public void ManagedToNativeCopyTo(long man, IntPtr mem)
    {
        var arr = new long[1];
        arr[0] = man;
        Marshal.Copy(arr, 0, mem, 1);
    }

    override public long NativeToManagedInlistNode(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            Eina.Log.Error("Null pointer for Inlist node.");
            return default(long);
        }

        IntPtr loc = nat + Marshal.SizeOf<InlistMem>();
        var v = new long[1];
        Marshal.Copy(loc, v, 0, 1);
        return v[0];
    }
}

public class ShortElementTraits : Primitive32ElementTraits<short>, IBaseElementTraits<short>
{
    override public void ManagedToNativeCopyTo(short man, IntPtr mem)
    {
        var arr = new short[1];
        arr[0] = man;
        Marshal.Copy(arr, 0, mem, 1);
    }

    override public short NativeToManagedInlistNode(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            Eina.Log.Error("Null pointer for Inlist node.");
            return default(short);
        }

        IntPtr loc = nat + Marshal.SizeOf<InlistMem>();
        var v = new short[1];
        Marshal.Copy(loc, v, 0, 1);
        return v[0];
    }
}

public class FloatElementTraits : Primitive32ElementTraits<float>, IBaseElementTraits<float>
{
    override public void ManagedToNativeCopyTo(float man, IntPtr mem)
    {
        var arr = new float[1];
        arr[0] = man;
        Marshal.Copy(arr, 0, mem, 1);
    }

    override public float NativeToManagedInlistNode(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            Eina.Log.Error("Null pointer for Inlist node.");
            return default(float);
        }

        IntPtr loc = nat + Marshal.SizeOf<InlistMem>();
        var v = new float[1];
        Marshal.Copy(loc, v, 0, 1);
        return v[0];
    }
}

public class DoubleElementTraits : Primitive64ElementTraits<double>, IBaseElementTraits<double>
{
    override public void ManagedToNativeCopyTo(double man, IntPtr mem)
    {
        var arr = new double[1];
        arr[0] = man;
        Marshal.Copy(arr, 0, mem, 1);
    }

    override public double NativeToManagedInlistNode(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            Eina.Log.Error("Null pointer for Inlist node.");
            return default(double);
        }

        IntPtr loc = nat + Marshal.SizeOf<InlistMem>();
        var v = new double[1];
        Marshal.Copy(loc, v, 0, 1);
        return v[0];
    }
}

public class ByteElementTraits : Primitive32ElementTraits<byte>, IBaseElementTraits<byte>
{
    override public void ManagedToNativeCopyTo(byte man, IntPtr mem)
    {
        var arr = new byte[1];
        arr[0] = man;
        Marshal.Copy(arr, 0, mem, 1);
    }

    override public byte NativeToManagedInlistNode(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            Eina.Log.Error("Null pointer for Inlist node.");
            return default(byte);
        }

        IntPtr loc = nat + Marshal.SizeOf<InlistMem>();
        var v = new byte[1];
        Marshal.Copy(loc, v, 0, 1);
        return v[0];
    }
}

public static class TraitFunctions
{
    public static bool IsEflObject(System.Type type)
    {
        return typeof(Efl.Eo.IWrapper).IsAssignableFrom(type);
    }

    public static bool IsString(System.Type type)
    {
        return type == typeof(string);
    }

    public static Eina.ElementType GetElementTypeCode(System.Type type)
    {
        if (IsEflObject(type))
        {
            return ElementType.ObjectType;
        }
        else if (IsString(type))
        {
            return ElementType.StringType;
        }
        else
        {
            return ElementType.NumericType;
        }
    }

    private static IDictionary<System.Type, object> register = new Dictionary<System.Type, object>();

    private static System.Type AsEflInstantiableType(System.Type type)
    {
        if (!IsEflObject(type))
        {
            return null;
        }

        if (type.IsInterface)
        {
            string fullName = type.FullName + "Concrete";
            return type.Assembly.GetType(fullName); // That was our best guess...
        }

        return type; // Not interface, so it should be a concrete.
    }

    public static object RegisterTypeTraits<T>()
    {
        Eina.Log.Debug($"Finding TypeTraits for {typeof(T).Name}");
        object traits;
        var type = typeof(T);
        if (IsEflObject(type))
        {
            System.Type concrete = AsEflInstantiableType(type);
            if (concrete == null || !type.IsAssignableFrom(concrete))
            {
                throw new Exception("Failed to get a suitable concrete class for this type.");
            }

            // No need to pass concrete as the traits class will use reflection to get the actually most
            // derived type returned.
            traits = new EflObjectElementTraits<T>();
        }
        else if (IsString(type))
        {
            traits = new StringElementTraits();
        }
        else if (type.IsValueType)
        {
            if (type == typeof(int))
            {
                traits = new IntElementTraits();
            }
            else if (type == typeof(char))
            {
                traits = new CharElementTraits();
            }
            else if (type == typeof(long))
            {
                traits = new LongElementTraits();
            }
            else if (type == typeof(short))
            {
                traits = new ShortElementTraits();
            }
            else if (type == typeof(float))
            {
                traits = new FloatElementTraits();
            }
            else if (type == typeof(double))
            {
                traits = new DoubleElementTraits();
            }
            else if (type == typeof(byte))
            {
                traits = new ByteElementTraits();
            }
            else
            {
                throw new Exception("No traits registered for this type");
            }
        }
        else
        {
            throw new Exception("No traits registered for this type");
        }

        register[type] = traits;
        return traits;
    }

    public static object RegisterTypeTraits<T>(IBaseElementTraits<T> traits)
    {
        register[typeof(T)] = traits;
        return traits;
    }

    public static IBaseElementTraits<T> GetTypeTraits<T>()
    {
        object traits;
        if (!register.TryGetValue(typeof(T), out traits))
        {
            traits = RegisterTypeTraits<T>();
        }

        return (IBaseElementTraits<T>)traits;
    }

    //                  //
    // Traits functions //
    //                  //

    // Convertion functions //

    public static IntPtr ManagedToNativeAlloc<T>(T man)
    {
        return GetTypeTraits<T>().ManagedToNativeAlloc(man);
    }

    public static void ManagedToNativeCopyTo<T>(T man, IntPtr mem)
    {
        GetTypeTraits<T>().ManagedToNativeCopyTo(man, mem);
    }

    public static IntPtr ManagedToNativeAllocInlistNode<T>(T man)
    {
        return GetTypeTraits<T>().ManagedToNativeAllocInlistNode(man);
    }

    public static void NativeFree<T>(IntPtr nat)
    {
        GetTypeTraits<T>().NativeFree(nat);
    }

    public static void NativeFreeInlistNodeElement<T>(IntPtr nat)
    {
        GetTypeTraits<T>().NativeFreeInlistNodeElement(nat);
    }

    public static void NativeFreeInlistNode<T>(IntPtr nat, bool freeElement = true)
    {
        GetTypeTraits<T>().NativeFreeInlistNode(nat, freeElement);
    }

    public static void NativeFreeInplace<T>(IntPtr nat)
    {
        GetTypeTraits<T>().NativeFreeInplace(nat);
    }

    public static void ResidueFreeInplace<T>(IntPtr nat)
    {
        GetTypeTraits<T>().ResidueFreeInplace(nat);
    }

    public static T NativeToManaged<T>(IntPtr nat)
    {
        return GetTypeTraits<T>().NativeToManaged(nat);
    }

    public static T NativeToManagedInlistNode<T>(IntPtr nat)
    {
        return GetTypeTraits<T>().NativeToManagedInlistNode(nat);
    }

    public static T NativeToManagedInplace<T>(IntPtr nat)
    {
        return GetTypeTraits<T>().NativeToManagedInplace(nat);
    }

    // Misc //

    public static IntPtr EinaCompareCb<T>()
    {
        return GetTypeTraits<T>().EinaCompareCb();
    }

    public static IntPtr EinaFreeCb<T>()
    {
        return GetTypeTraits<T>().EinaFreeCb();
    }

    public static IntPtr EinaHashNew<TKey>()
    {
        return GetTypeTraits<TKey>().EinaHashNew();
    }

    public static IntPtr EinaInarrayNew<T>(uint step)
    {
        return GetTypeTraits<T>().EinaInarrayNew(step);
    }

    public static IntPtr EinaHashIteratorKeyNew<T>(IntPtr hash)
    {
        return GetTypeTraits<T>().EinaHashIteratorKeyNew(hash);
    }
}

}

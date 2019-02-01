#pragma warning disable 1591

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;

using Eina.Callbacks;
using static Eina.HashNativeFunctions;
using static Eina.InarrayNativeFunctions;
using static Eina.InlistNativeFunctions;
using static Eina.NativeCustomExportFunctions;
using static Eina.ContainerCommonData;

namespace Eina {

public enum ElementType { NumericType, StringType, ObjectType };

public static class ContainerCommonData
{
    public static IBaseElementTraits<IntPtr> intPtrTraits = null;
}

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
    IntPtr ManagedToNativeAllocRef(T man, bool refs);
    IntPtr ManagedToNativeAllocInlistNode(T man);
    IntPtr ManagedToNativeAllocInplace(T man);
    void NativeFree(IntPtr nat);
    void NativeFreeRef(IntPtr nat, bool unrefs);
    void NativeFreeInlistNodeElement(IntPtr nat);
    void NativeFreeInlistNode(IntPtr nat, bool freeElement);
    void NativeFreeInplace(IntPtr nat);
    void ResidueFreeInplace(IntPtr nat);
    T NativeToManaged(IntPtr nat);
    T NativeToManagedRef(IntPtr nat);
    T NativeToManagedInlistNode(IntPtr nat);
    T NativeToManagedInplace(IntPtr nat);
    IntPtr EinaCompareCb();
    IntPtr EinaFreeCb();
    IntPtr EinaHashNew();
    IntPtr EinaInarrayNew(uint step);
    IntPtr EinaHashIteratorKeyNew(IntPtr hash);
}

public class StringElementTraits<T> : IBaseElementTraits<T>
{

    public StringElementTraits()
    {
        if (intPtrTraits == null)
            intPtrTraits = TraitFunctions.GetTypeTraits<IntPtr>();
    }

    public IntPtr ManagedToNativeAlloc(T man)
    {
        return MemoryNative.StrDup((string)(object)man);
    }

    public IntPtr ManagedToNativeAllocRef(T man, bool refs)
    {
        // Keep alloc on C# ?
        return ManagedToNativeAlloc(man);
    }

    public IntPtr ManagedToNativeAllocInlistNode(T man)
    {
        var node = new InlistNode<IntPtr>();
        node.Val = ManagedToNativeAlloc(man);
        GCHandle pinnedData = GCHandle.Alloc(node, GCHandleType.Pinned);
        IntPtr ptr = pinnedData.AddrOfPinnedObject();
        IntPtr nat = MemoryNative.AllocCopy(ptr, Marshal.SizeOf<InlistNode<IntPtr> >());
        pinnedData.Free();
        return nat;
    }

    public IntPtr ManagedToNativeAllocInplace(T man)
    {
        return intPtrTraits.ManagedToNativeAlloc(ManagedToNativeAlloc(man));
    }

    public void NativeFree(IntPtr nat)
    {
        if (nat != IntPtr.Zero)
            MemoryNative.Free(nat);
    }

    public void NativeFreeRef(IntPtr nat, bool unrefs)
    {
        NativeFree(nat);
    }

    public void NativeFreeInlistNodeElement(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
            return;
        var node = Marshal.PtrToStructure< InlistNode<IntPtr> >(nat);
        NativeFree(node.Val);
    }

    public void NativeFreeInlistNode(IntPtr nat, bool freeElement)
    {
        if (nat == IntPtr.Zero)
            return;
        if (freeElement)
            NativeFreeInlistNodeElement(nat);
        MemoryNative.Free(nat);
    }

    public void NativeFreeInplace(IntPtr nat)
    {
        MemoryNative.FreeRef(nat);
    }

    public void ResidueFreeInplace(IntPtr nat)
    {
        intPtrTraits.NativeFree(nat);
    }

    public T NativeToManaged(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
            return default(T);
        return (T)(object)StringConversion.NativeUtf8ToManagedString(nat);
    }

    public T NativeToManagedRef(IntPtr nat)
    {
        return NativeToManaged(nat);
    }

    public T NativeToManagedInlistNode(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            Eina.Log.Error("Null pointer for Inlist node.");
            return default(T);
        }
        var w = Marshal.PtrToStructure< InlistNode<IntPtr> >(nat);
        return NativeToManaged(w.Val);
    }

    public T NativeToManagedInplace(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
            return default(T);
        return NativeToManaged(intPtrTraits.NativeToManaged(nat));
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
    private System.Type concreteType = null;

    public EflObjectElementTraits(System.Type concrete)
    {
        if (intPtrTraits == null)
            intPtrTraits = TraitFunctions.GetTypeTraits<IntPtr>();

        concreteType = concrete;
    }

    public IntPtr ManagedToNativeAlloc(T man)
    {
        IntPtr h = ((Efl.Eo.IWrapper)man).NativeHandle;
        if (h == IntPtr.Zero)
            return h;
        return Efl.Eo.Globals.efl_ref(h);
    }

    public IntPtr ManagedToNativeAllocRef(T man, bool refs)
    {
        IntPtr h = refs ? ManagedToNativeAlloc(man) : ((Efl.Eo.IWrapper)man).NativeHandle;
        return intPtrTraits.ManagedToNativeAlloc(h);
    }

    public IntPtr ManagedToNativeAllocInlistNode(T man)
    {
        var node = new InlistNode<IntPtr>();
        node.Val = ManagedToNativeAlloc(man);
        GCHandle pinnedData = GCHandle.Alloc(node, GCHandleType.Pinned);
        IntPtr ptr = pinnedData.AddrOfPinnedObject();
        IntPtr nat = MemoryNative.AllocCopy(ptr, Marshal.SizeOf<InlistNode<IntPtr> >());
        pinnedData.Free();
        return nat;
    }

    public IntPtr ManagedToNativeAllocInplace(T man)
    {
        return intPtrTraits.ManagedToNativeAlloc(ManagedToNativeAlloc(man));
    }

    public void NativeFree(IntPtr nat)
    {
        if (nat != IntPtr.Zero)
            Efl.Eo.Globals.efl_unref(nat);
    }

    public void NativeFreeRef(IntPtr nat, bool unrefs)
    {
        if (unrefs)
            NativeFree(intPtrTraits.NativeToManaged(nat));
        intPtrTraits.NativeFree(nat);
    }

    public void NativeFreeInlistNodeElement(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
            return;
        var node = Marshal.PtrToStructure< InlistNode<IntPtr> >(nat);
        NativeFree(node.Val);
    }

    public void NativeFreeInlistNode(IntPtr nat, bool freeElement)
    {
        if (nat == IntPtr.Zero)
            return;
        if (freeElement)
            NativeFreeInlistNodeElement(nat);
        MemoryNative.Free(nat);
    }

    public void NativeFreeInplace(IntPtr nat)
    {
        NativeFree(intPtrTraits.NativeToManaged(nat));
    }

    public void ResidueFreeInplace(IntPtr nat)
    {
        intPtrTraits.NativeFree(nat);
    }

    public T NativeToManaged(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
            return default(T);
        return (T) Activator.CreateInstance(concreteType, Efl.Eo.Globals.efl_ref(nat));
    }

    public T NativeToManagedRef(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
            return default(T);
        return NativeToManaged(intPtrTraits.NativeToManaged(nat));
    }

    public T NativeToManagedInlistNode(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            Eina.Log.Error("Null pointer for Inlist node.");
            return default(T);
        }
        var w = Marshal.PtrToStructure< InlistNode<IntPtr> >(nat);
        return NativeToManaged(w.Val);
    }

    public T NativeToManagedInplace(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
            return default(T);
        return NativeToManaged(intPtrTraits.NativeToManaged(nat));
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
        IntPtr nat = MemoryNative.AllocCopy(ptr, Marshal.SizeOf< InlistNode<T> >());
        pinnedData.Free();
        return nat;
    }

    public IntPtr ManagedToNativeAllocInplace(T man)
    {
        return ManagedToNativeAlloc(man);
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

    public T NativeToManagedInlistNode(IntPtr nat)
    {
        if (nat == IntPtr.Zero)
        {
            Eina.Log.Error("Null pointer for Inlist node.");
            return default(T);
        }
        var w = Marshal.PtrToStructure< InlistNode<T> >(nat);
        return w.Val;
    }

    public T NativeToManagedInplace(IntPtr nat)
    {
        return NativeToManaged(nat);
    }

    private int PrimitiveCompareCb(IntPtr ptr1, IntPtr ptr2)
    {
        var m1 = (IComparable) NativeToManaged(ptr1);
        var m2 = NativeToManaged(ptr2);
        return m1.CompareTo(m2);
    }

    public IntPtr EinaCompareCb()
    {
        if (dlgt == null)
            dlgt = new Eina_Compare_Cb(PrimitiveCompareCb);
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

public class Primitive32ElementTraits<T> : PrimitiveElementTraits<T>, IBaseElementTraits<T>
{
    private static IBaseElementTraits<Int32> int32Traits = null;

    public Primitive32ElementTraits()
    {
        if (int32Traits == null)
            if (typeof(T) == typeof(Int32)) // avoid infinite recursion
                int32Traits = (IBaseElementTraits<Int32>)this;
            else
                int32Traits = TraitFunctions.GetTypeTraits<Int32>();
    }

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

public class Primitive64ElementTraits<T> : PrimitiveElementTraits<T>, IBaseElementTraits<T>
{
    private static IBaseElementTraits<Int64> int64Traits = null;

    public Primitive64ElementTraits()
    {
        if (int64Traits == null)
            if (typeof(T) == typeof(Int64)) // avoid infinite recursion
                int64Traits = (IBaseElementTraits<Int64>)this;
            else
                int64Traits = TraitFunctions.GetTypeTraits<Int64>();
    }

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
            return ElementType.ObjectType;
        else if (IsString(type))
            return ElementType.StringType;
        else
            return ElementType.NumericType;
    }

    private static IDictionary<System.Type, object> register = new Dictionary<System.Type, object>();

    private static System.Type AsEflInstantiableType(System.Type type)
    {
        if (!IsEflObject(type))
            return null;

        if (type.IsInterface)
        {
            string[] names = type.FullName.Split('.');
            names[names.Count() - 1] = names.Last().Substring(1); // Remove the leading 'I' (What about user-defined interfaces?)

            string fullName = string.Join(".", names);
            return type.Assembly.GetType(fullName); // That was our best guess...
        }


        System.Type current = type;
        while (current != null)
        {
            if (current.Name.EndsWith("Inherit"))
                throw new Exception("Inherit-based classes are not currently supported.");
            current = current.BaseType;
        }

        return type; // Not inherited neither interface, so it should be a concrete.
    }

    public static object RegisterTypeTraits<T>()
    {
        object traits;
        var type = typeof(T);
        if (IsEflObject(type))
        {
            System.Type concrete = AsEflInstantiableType(type);
            if (concrete == null || !type.IsAssignableFrom(concrete))
                throw new Exception("Failed to get a suitable concrete class for this type.");
            traits = new EflObjectElementTraits<T>(concrete);
        }
        else if (IsString(type))
            traits = new StringElementTraits<T>();
        else if (type.IsValueType)
        {
            if (Marshal.SizeOf<T>() <= 4)
                traits = new Primitive32ElementTraits<T>();
            else
                traits = new Primitive64ElementTraits<T>();
        }
        else
            throw new Exception("No traits registered for this type");

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
            traits = RegisterTypeTraits<T>();
        return (IBaseElementTraits<T>) traits;
    }

    //                  //
    // Traits functions //
    //                  //

    // Convertion functions //

    public static IntPtr ManagedToNativeAlloc<T>(T man)
    {
        return GetTypeTraits<T>().ManagedToNativeAlloc(man);
    }

    public static IntPtr ManagedToNativeAllocRef<T>(T man, bool refs = false)
    {
        return GetTypeTraits<T>().ManagedToNativeAllocRef(man, refs);
    }

    public static IntPtr ManagedToNativeAllocInplace<T>(T man)
    {
        return GetTypeTraits<T>().ManagedToNativeAllocInplace(man);
    }

    public static IntPtr ManagedToNativeAllocInlistNode<T>(T man)
    {
        return GetTypeTraits<T>().ManagedToNativeAllocInlistNode(man);
    }

    public static void NativeFree<T>(IntPtr nat)
    {
        GetTypeTraits<T>().NativeFree(nat);
    }

    public static void NativeFreeRef<T>(IntPtr nat, bool unrefs = false)
    {
        GetTypeTraits<T>().NativeFreeRef(nat, unrefs);
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

    public static T NativeToManagedRef<T>(IntPtr nat)
    {
        return GetTypeTraits<T>().NativeToManagedRef(nat);
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

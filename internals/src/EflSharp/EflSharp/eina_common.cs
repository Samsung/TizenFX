#pragma warning disable 1591

using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Eina
{
namespace Callbacks
{

public delegate int EinaCompareCb(IntPtr data1, IntPtr data2);
public delegate void EinaFreeCb(IntPtr data);

}

internal static class NativeCustomExportFunctions
{
    [DllImport(efl.Libs.CustomExports)] public static extern void
        efl_mono_native_free(IntPtr ptr);
    [DllImport(efl.Libs.CustomExports)] public static extern void
        efl_mono_native_free_ref(IntPtr ptr);
    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        efl_mono_native_alloc(uint count);
    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        efl_mono_native_memset(IntPtr ptr, uint fill, uint count);
    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        efl_mono_native_alloc_copy(IntPtr val, uint size);
    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        efl_mono_native_strdup(string str);

    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        efl_mono_native_ptr_compare_addr_get();
    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        efl_mono_native_str_compare_addr_get();

    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        efl_mono_native_free_addr_get();
    [DllImport(efl.Libs.CustomExports)] public static extern IntPtr
        efl_mono_native_efl_unref_addr_get();
}

/// <summary>Wrapper around native memory DllImport'd functions</summary>
public static class MemoryNative {
    public static void Free(IntPtr ptr)
    {
        NativeCustomExportFunctions.efl_mono_native_free(ptr);
    }

    public static void FreeRef(IntPtr ptr)
    {
        NativeCustomExportFunctions.efl_mono_native_free_ref(ptr);
    }

    // This public api uses int as Marshal.SizeOf return an int instead of uint.
    public static IntPtr Alloc(int count)
    {
        return NativeCustomExportFunctions.efl_mono_native_alloc(Convert.ToUInt32(count));
    }

    public static void Memset(IntPtr ptr, int fill, int count)
    {
        NativeCustomExportFunctions.efl_mono_native_memset(ptr, Convert.ToUInt32(fill), Convert.ToUInt32(count));
    }

    public static IntPtr AllocCopy(IntPtr ptr, int count)
    {
        return NativeCustomExportFunctions.efl_mono_native_alloc_copy(ptr, Convert.ToUInt32(count));
    }

    public static IntPtr StrDup(string str)
    {
        return NativeCustomExportFunctions.efl_mono_native_strdup(str);
    }

    // IntPtr's for some native functions
    public static IntPtr PtrCompareFuncPtrGet()
    {
        return NativeCustomExportFunctions.efl_mono_native_ptr_compare_addr_get();
    }

    public static IntPtr StrCompareFuncPtrGet()
    {
        return NativeCustomExportFunctions.efl_mono_native_str_compare_addr_get();
    }

    public static IntPtr FreeFuncPtrGet()
    {
        return NativeCustomExportFunctions.efl_mono_native_free_addr_get();
    }

    public static IntPtr EflUnrefFuncPtrGet()
    {
        return NativeCustomExportFunctions.efl_mono_native_efl_unref_addr_get();
    }
}

public static class PrimitiveConversion
{
   public static T PointerToManaged<T>(IntPtr nat)
   {
       if (nat == IntPtr.Zero)
       {
           Eina.Log.Error("Null pointer for primitive type.");
           return default(T);
       }

       var w = Marshal.PtrToStructure<T>(nat);
       return w;
   }

   public static IntPtr ManagedToPointerAlloc<T>(T man)
   {
       IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<T>());
       Marshal.StructureToPtr(man, ptr, false);
       return ptr;
   }
}

public static class StringConversion
{
    public static IntPtr ManagedStringToNativeUtf8Alloc(string managedString)
    {
        if (managedString == null)
            return IntPtr.Zero;

        byte[] strbuf = Encoding.UTF8.GetBytes(managedString);
        IntPtr native = MemoryNative.Alloc(strbuf.Length + 1);
        Marshal.Copy(strbuf, 0, native, strbuf.Length);
        Marshal.WriteByte(native + strbuf.Length, 0); // write the terminating null
        return native;
    }

    public static string NativeUtf8ToManagedString(IntPtr pNativeData)
    {
        if (pNativeData == IntPtr.Zero)
            return null;

        int len = 0;
        while (Marshal.ReadByte(pNativeData, len) != 0)
            ++len;

        byte[] strbuf = new byte[len];
        Marshal.Copy(pNativeData, strbuf, 0, strbuf.Length);
        return Encoding.UTF8.GetString(strbuf);
    }
}

/// <summary>Enum to handle resource ownership between managed and unmanaged code.</summary>
public enum Ownership {
    /// <summary> The resource is owned by the managed code. It should free the handle on disposal.</summary>
    Managed,
    /// <summary> The resource is owned by the unmanaged code. It won't be freed on disposal.</summary>
    Unmanaged
}

}

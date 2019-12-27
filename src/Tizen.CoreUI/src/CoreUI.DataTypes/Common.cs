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
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace CoreUI.DataTypes
{

namespace Callbacks
{

internal delegate int EinaCompareCb(IntPtr data1, IntPtr data2);
internal delegate void EinaFreeCb(IntPtr data);

}

internal static partial class NativeCustomExportFunctions
{
    [DllImport(CoreUI.Libs.CustomExports)] public static extern void
        efl_mono_native_free(IntPtr ptr);
    [DllImport(CoreUI.Libs.CustomExports)] public static extern void
        efl_mono_native_free_ref(IntPtr ptr);
    [DllImport(CoreUI.Libs.CustomExports)] public static extern IntPtr
        efl_mono_native_alloc(uint count);
    [DllImport(CoreUI.Libs.CustomExports)] public static extern IntPtr
        efl_mono_native_memset(IntPtr ptr, uint fill, uint count);
    [DllImport(CoreUI.Libs.CustomExports)] public static extern IntPtr
        efl_mono_native_alloc_copy(IntPtr val, uint size);
    [DllImport(CoreUI.Libs.CustomExports)] public static extern IntPtr
        efl_mono_native_strdup(string str);

    [DllImport(CoreUI.Libs.CustomExports)] public static extern IntPtr
        efl_mono_native_ptr_compare_addr_get();
    [DllImport(CoreUI.Libs.CustomExports)] public static extern IntPtr
        efl_mono_native_str_compare_addr_get();

    [DllImport(CoreUI.Libs.CustomExports)] public static extern IntPtr
        efl_mono_native_free_addr_get();
    [DllImport(CoreUI.Libs.CustomExports)] public static extern IntPtr
        efl_mono_native_efl_unref_addr_get();
}

/// <summary>Wrapper around native memory DllImport'd functions.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[EditorBrowsable(EditorBrowsableState.Never)]
public static class MemoryNative
{
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

    /// <summary>
    ///   Retrieves an instance of a string for use in program.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="str"> The NULL-terminated string to retrieve an instance of.</param>
    /// <returns> A pointer to an instance of the string on success,
    ///  on failure a exception is raised.</returns>
    public static IntPtr AddStringshare(string str)
    {
        IntPtr nativeStr = StringConversion.ManagedStringToNativeUtf8Alloc(str);
        try
        {
            var strShare = NativeMethods.eina_stringshare_add(nativeStr);
            return strShare;
        }
        finally
        {
            CoreUI.DataTypes.MemoryNative.Free(nativeStr);
        }
    }

    /// <summary>
    ///   Notes that the given string has lost an instance.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="str">the given string</param>
    public static void DelStringshare(IntPtr str)
    {
        NativeMethods.eina_stringshare_del(str);
    }

    public static void DelStringshareRef(IntPtr ptr)
    {
        NativeMethods.efl_mono_native_stringshare_del_ref(ptr);
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

    public static IntPtr StringshareDelFuncPtrGet()
    {
        return NativeMethods.efl_mono_native_stringshare_del_addr_get();
    }

    public static IntPtr CoreUIUnrefFuncPtrGet()
    {
        return NativeCustomExportFunctions.efl_mono_native_efl_unref_addr_get();
    }
}

/// <summary>
/// Conversor of raw pointer to  a type and type to raw pointer
/// </summary>
/// <since_tizen> 6 </since_tizen>
[EditorBrowsable(EditorBrowsableState.Never)]
public static class PrimitiveConversion
{
   public static T PointerToManaged<T>(IntPtr nat)
   {
       if (nat == IntPtr.Zero)
       {
           CoreUI.DataTypes.Log.Error("Null pointer for primitive type.");
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

/// <summary>
/// Conversor of string to native string and native string to string.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[EditorBrowsable(EditorBrowsableState.Never)]
public static class StringConversion
{
    public static IntPtr ManagedStringToNativeUtf8Alloc(string managedString)
    {
        if (managedString == null)
        {
            return IntPtr.Zero;
        }

        byte[] strbuf = Encoding.UTF8.GetBytes(managedString);
        IntPtr native = MemoryNative.Alloc(strbuf.Length + 1);
        try
        {
            Marshal.Copy(strbuf, 0, native, strbuf.Length);
            Marshal.WriteByte(native + strbuf.Length, 0); // write the terminating null
            return native;
        }
        catch (Exception)
        {
            MemoryNative.Free(native);
            throw;
        }
    }

    public static string NativeUtf8ToManagedString(IntPtr pNativeData)
    {
        if (pNativeData == IntPtr.Zero)
        {
            return null;
        }

        int len = 0;
        while (Marshal.ReadByte(pNativeData, len) != 0)
        {
            ++len;
        }

        byte[] strbuf = new byte[len];
        Marshal.Copy(pNativeData, strbuf, 0, strbuf.Length);
        return Encoding.UTF8.GetString(strbuf);
    }
}

/// <summary>Enum to handle resource ownership between managed and unmanaged code.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[EditorBrowsable(EditorBrowsableState.Never)]
public enum Ownership
{
    /// <summary> The resource is owned by the managed code. It should free the handle on disposal.</summary>
    /// <since_tizen> 6 </since_tizen>
    Managed,
    /// <summary> The resource is owned by the unmanaged code. It won't be freed on disposal.</summary>
    /// <since_tizen> 6 </since_tizen>
    Unmanaged
}

}

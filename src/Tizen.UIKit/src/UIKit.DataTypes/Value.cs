#pragma warning disable 1591

#define CODE_ANALYSIS

using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Security;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

using static UIKit.DataTypes.EinaNative.UnsafeNativeMethods;
using static UIKit.DataTypes.TraitFunctions;


namespace UIKit
{

namespace DataTypes
{

namespace EinaNative
{

// Structs to be passed from/to C when dealing with containers and
// optional values.
[StructLayout(LayoutKind.Sequential)]
struct Value_Array
{
    public IntPtr subtype;
    public uint step;
    public IntPtr subarray;
}

[StructLayout(LayoutKind.Sequential)]
struct Value_List
{
    public IntPtr subtype;
    public IntPtr sublist;
}

[SuppressUnmanagedCodeSecurityAttribute]
static internal class UnsafeNativeMethods
{
    [DllImport(UIKit.Libs.Eina)]
    internal static extern IntPtr eina_value_new(IntPtr type);

    [DllImport(UIKit.Libs.Eina)]
    internal static extern void eina_value_free(IntPtr type);

    [DllImport(UIKit.Libs.Eina)]
    internal static extern IntPtr eina_value_type_name_get(IntPtr type);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_convert(IntPtr handle, IntPtr convert);

    // Wrapped and helper methods
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern int eina_value_sizeof();

    [DllImport(UIKit.Libs.CustomExports, CharSet=CharSet.Ansi)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_string(IntPtr handle, string value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_uchar(IntPtr handle, byte value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_char(IntPtr handle, sbyte value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_short(IntPtr handle, short value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_ushort(IntPtr handle, ushort value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_int(IntPtr handle, int value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_uint(IntPtr handle, uint value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_long(IntPtr handle, long value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_ulong(IntPtr handle, ulong value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_float(IntPtr handle, float value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_double(IntPtr handle, double value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_ptr(IntPtr handle, IntPtr value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_setup_wrapper(IntPtr handle, IntPtr type);

    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern void eina_value_flush_wrapper(IntPtr handle);

    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr eina_value_type_get_wrapper(IntPtr handle);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out IntPtr output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out Value_List output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out Value_Array output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out byte output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out sbyte output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out short output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out ushort output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out int output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out uint output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out long output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out ulong output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out float output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out double output);

    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern int eina_value_compare_wrapper(IntPtr handle, IntPtr other);

    [DllImport(UIKit.Libs.Eina, CharSet=CharSet.Ansi)]
    [return:
     MarshalAs(UnmanagedType.CustomMarshaler,
	       MarshalTypeRef=typeof(UIKit.Wrapper.StringPassOwnershipMarshaler))]
    internal static extern string eina_value_to_string(IntPtr handle); // We take ownership of the returned string.

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_array_setup_wrapper(IntPtr handle, IntPtr subtype, uint step);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_list_setup_wrapper(IntPtr handle, IntPtr subtype);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_string(IntPtr handle, string data);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_ptr(IntPtr handle, IntPtr data);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_char(IntPtr handle, sbyte data);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_uchar(IntPtr handle, byte data);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_short(IntPtr handle, short data);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_ushort(IntPtr handle, ushort data);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_int(IntPtr handle, int data);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_uint(IntPtr handle, uint data);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_long(IntPtr handle, long data);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_ulong(IntPtr handle, ulong data);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_float(IntPtr handle, float data);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_double(IntPtr handle, double data);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_list_append_wrapper(IntPtr handle, IntPtr data);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out IntPtr output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out sbyte output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out byte output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out short output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out ushort output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out int output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out uint output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out long output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out ulong output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out float output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out double output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_list_get_wrapper(IntPtr handle, int index, out IntPtr output);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_string(IntPtr handle, int index, string value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_ptr(IntPtr handle, int index, IntPtr value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_uchar(IntPtr handle, int index, byte value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_char(IntPtr handle, int index, sbyte value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_short(IntPtr handle, int index, short value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_ushort(IntPtr handle, int index, ushort value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_int(IntPtr handle, int index, int value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_uint(IntPtr handle, int index, uint value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_long(IntPtr handle, int index, long value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_ulong(IntPtr handle, int index, ulong value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_float(IntPtr handle, int index, float value);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_double(IntPtr handle, int index, double value);

    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr eina_value_array_subtype_get_wrapper(IntPtr handle);

    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr eina_value_list_subtype_get_wrapper(IntPtr handle);

    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern uint eina_value_array_count_wrapper(IntPtr handle);

    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern uint eina_value_list_count_wrapper(IntPtr handle);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_empty_is_wrapper(IntPtr handle, [MarshalAsAttribute(UnmanagedType.U1)] out bool empty);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref byte value);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref sbyte value);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref short value);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref ushort value);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref int value);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref uint value);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref long value);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref ulong value);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref float value);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref double value);

    [DllImport(UIKit.Libs.Eina, CharSet=CharSet.Ansi)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref string value);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref IntPtr value);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, IntPtr value);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_reset(IntPtr handle);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out UIKit.DataTypes.EinaNative.Value_Array output);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out UIKit.DataTypes.EinaNative.Value_List output);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out IntPtr output);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out byte output);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out sbyte output);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out short output);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out ushort output);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out int output);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out uint output);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out long output);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out ulong output);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out float output);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out double output);

    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr eina_value_optional_type_get_wrapper(IntPtr handle);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_pset_wrapper(IntPtr handle, ref UIKit.DataTypes.EinaNative.Value_Array ptr);

    [DllImport(UIKit.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_pset_wrapper(IntPtr handle, ref UIKit.DataTypes.EinaNative.Value_List ptr);

    [DllImport(UIKit.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_copy(IntPtr src, IntPtr dest);

    // Supported types

    // 8 bits byte
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_byte();
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_sbyte();

    // 16 bits short
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_short();
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_ushort();

    // 32 bits ints
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_int32();
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_uint32();

    // 64 bit longs
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_long();
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_ulong();

    // In C# long and int 64 are synonyms, but in Eina Value they are separate types.
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_int64();
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_uint64();

    // Floating point
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_float();
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_double();

    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_string();

    // Collections
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_array();
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_list();
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_hash();

    // Optional
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_optional();

    // Error
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_error();

    // Error
    [DllImport(UIKit.Libs.CustomExports)]
    internal static extern IntPtr type_object();
}
}

/// <summary>Struct for passing Values by value to Unmanaged functions.
///
/// Since EFL 1.23.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct ValueNative
{
    public IntPtr Type;
    public IntPtr Value; // Actually an Eina_Value_Union, but it is padded to 8 bytes.

    public override string ToString()
    {
        return $"ValueNative<Type:0x{Type.ToInt64():x}, Value:0x{Value.ToInt64():x}>";
    }
}

/// <summary>Exception for failures when setting an container item.
///
/// Since EFL 1.23.
/// </summary>
[Serializable]
public class SetItemFailedException : Exception
{
    /// <summary> Default constructor.</summary>
    public SetItemFailedException() : base()
    {
    }

    /// <summary> Most commonly used contructor.</summary>
    public SetItemFailedException(string msg) : base(msg)
    {
    }

    /// <summary> Wraps an inner exception.</summary>
    public SetItemFailedException(string msg, Exception inner) : base(msg, inner)
    {
    }

    /// <summary> Serializable constructor.</summary>
    protected SetItemFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

/// <summary>Exception for methods that must have been called on a container.
///
/// Since EFL 1.23.
/// </summary>
[Serializable]
public class InvalidValueTypeException: Exception
{
    /// <summary> Default constructor.</summary>
    public InvalidValueTypeException() : base()
    {
    }

    /// <summary> Most commonly used contructor.</summary>
    public InvalidValueTypeException(string msg) : base(msg)
    {
    }

    /// <summary> Wraps an inner exception.</summary>
    public InvalidValueTypeException(string msg, Exception inner) : base(msg, inner)
    {
    }

    /// <summary> Serializable constructor.</summary>
    protected InvalidValueTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}


/// <summary>Managed-side Enum to represent Eina_Value_Type constants.
///
/// Since EFL 1.23.
/// </summary>
public enum ValueType
{
    /// <summary>Signed 8 bit integer. Same as 'sbyte'</summary>
    SByte,
    /// <summary>Unsigned 8 bit integer. Same as 'byte'</summary>
    Byte,
    /// <summary>Signed 16 bit integer. Same as 'short'</summary>
    Short,
    /// <summary>Unsigned 16 bit integer. Same as 'ushort'</summary>
    UShort,
    /// <summary>Signed 32 bit integer. Same as 'int'</summary>
    Int32,
    /// <summary>Unsigned 32 bit integer. Same as 'uint'</summary>
    UInt32,
    /// <summary>Signed long integer. Same as 'long'</summary>
    Long,
    /// <summary>Unsigned long integer. Same as 'ulong'</summary>
    ULong,
    /// <summary>Signed 64 bit integer. Same as 'long'</summary>
    Int64,
    /// <summary>Unsigned 64 bit integer. Same as 'ulong'</summary>
    UInt64,
    /// <summary>4-byte float. Same as 'float'</summary>
    Float,
    /// <summary>8-byte double. Same as 'double'</summary>
    Double,
    /// <summary>Strings</summary>
    String,
    /// <summary>Array of Value items.</summary>
    Array,
    /// <summary>Linked list of Value items.</summary>
    List,
    /// <summary>Map of string keys to Value items.</summary>
    Hash,
    /// <summary>Optional (aka empty) values.</summary>
    Optional,
    /// <summary>Error values.</summary>
    Error,
    Object,
    /// <summary>Empty values.</summary>
    Empty,
}

static class ValueTypeMethods
{
    public static bool IsNumeric(this ValueType val)
    {
        switch (val)
        {
            case ValueType.SByte:
            case ValueType.Byte:
            case ValueType.Short:
            case ValueType.UShort:
            case ValueType.Int32:
            case ValueType.UInt32:
            case ValueType.Long:
            case ValueType.ULong:
            case ValueType.Int64:
            case ValueType.UInt64:
            case ValueType.Float:
            case ValueType.Double:
                return true;
            default:
                return false;
        }
    }

    public static bool IsString(this ValueType val)
    {
        switch (val)
        {
            case ValueType.String:
                return true;
            default:
                return false;
        }
    }

    public static bool IsContainer(this ValueType val)
    {
        switch (val)
        {
            case ValueType.Array:
            case ValueType.List:
            case ValueType.Hash:
                return true;
            default:
                return false;
        }
    }

    public static bool IsOptional(this ValueType val)
    {
        return val == ValueType.Optional;
    }

    public static bool IsError(this ValueType val)
    {
        return val == ValueType.Error;
    }

    public static bool IsObject(this ValueType val)
    {
        return val == ValueType.Object;
    }

    /// <summary>Returns the Marshal.SizeOf for the given ValueType native structure.</summary>
    public static int MarshalSizeOf(this ValueType val)
    {
        switch (val)
        {
            case ValueType.Array:
                return Marshal.SizeOf(typeof(EinaNative.Value_Array));
            case ValueType.List:
                return Marshal.SizeOf(typeof(EinaNative.Value_List));
            default:
                return 0;
        }
    }
}

/// <summary>Boxing class for custom marshalling of ValueType enums.
///
/// <para>As custom marshalling of enums (and other value types) is not supported, use
/// use this boxing class as an intermediate at the Marshalling API level (like in
/// marshall_type_impl.hh in the generator). User-facing API still uses UIKit.DataTypes.ValueType
/// normally.</para>
///
/// Since EFL 1.23.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public class ValueTypeBox
{
    public ValueType _payload;

    public ValueTypeBox(ValueType v)
    {
        _payload = v;
    }

    public static implicit operator ValueTypeBox(ValueType v)
    {
        return new ValueTypeBox(v);
    }

    public static implicit operator ValueType(ValueTypeBox box)
    {
        if (box == null)
        {
            return UIKit.DataTypes.ValueType.Empty;
        }

        return box._payload;
    }
}

static class ValueTypeBridge
{
    private static Dictionary<ValueType, IntPtr> ManagedToNative = new Dictionary<ValueType, IntPtr>();
    private static Dictionary<IntPtr, ValueType> NativeToManaged = new Dictionary<IntPtr, ValueType>();
    private static Dictionary<System.Type, ValueType> StandardToManaged = new Dictionary<System.Type, ValueType>();
    private static Dictionary<ValueType, System.Type> ManagedToStandard = new Dictionary<ValueType, System.Type>();
    private static bool TypesLoaded; // CLR defaults to false;

    public static ValueType GetManaged(IntPtr native)
    {
        if (!TypesLoaded)
        {
            LoadTypes();
        }

        try
        {
            return NativeToManaged[native];
        }
        catch (KeyNotFoundException)
        {
            var name_ptr = eina_value_type_name_get(native);
            var name = Marshal.PtrToStringAnsi(name_ptr);
            throw new UIKit.UIKitException($"Unknown native eina value Type: 0x{native.ToInt64():x} with name {name}");
        }
    }

    public static IntPtr GetNative(ValueType valueType)
    {
        if (!TypesLoaded)
        {
            LoadTypes();
        }

        return ManagedToNative[valueType];
    }

    /// <summary>Returns the UIKit.DataTypes.Value type associated with the given C# type.</summary>
    public static ValueType GetManaged(System.Type type)
    {
        ValueType v;
        if (StandardToManaged.TryGetValue(type, out v))
        {
            return v;
        }
        else
        {
            if (typeof(UIKit.Object).IsAssignableFrom(type))
            {
                return ValueType.Object;
            }
            throw new UIKit.UIKitException($"Unknown value type mapping for C# type {type}");
        }
    }

    /// <summary>Returns the System.Type associated with the given UIKit.DataTypes.Value type.</summary>
    /// <param name="valueType">The intermediate type as returned by <see cref="UIKit.DataTypes.Value.GetValueType()" />.</param>
    /// <returns>The associated C# type with this value type.</returns>
    public static System.Type GetStandard(ValueType valueType)
    {
        System.Type ret = null;
        if (ManagedToStandard.TryGetValue(valueType, out ret))
        {
            return ret;
        }
        else
        {
            throw new UIKit.UIKitException($"Unknown C# type mapping for value type {valueType}");
        }
    }

    private static void LoadTypes()
    {
        UIKit.DataTypes.Config.Init(); // Make sure eina is initialized.

        ManagedToNative.Add(ValueType.SByte, type_sbyte());
        NativeToManaged.Add(type_sbyte(), ValueType.SByte);
        StandardToManaged.Add(typeof(sbyte), ValueType.SByte);
        ManagedToStandard.Add(ValueType.SByte, typeof(sbyte));

        ManagedToNative.Add(ValueType.Byte, type_byte());
        NativeToManaged.Add(type_byte(), ValueType.Byte);
        StandardToManaged.Add(typeof(byte), ValueType.Byte);
        ManagedToStandard.Add(ValueType.Byte, typeof(byte));

        ManagedToNative.Add(ValueType.Short, type_short());
        NativeToManaged.Add(type_short(), ValueType.Short);
        StandardToManaged.Add(typeof(short), ValueType.Short);
        ManagedToStandard.Add(ValueType.Short, typeof(short));

        ManagedToNative.Add(ValueType.UShort, type_ushort());
        NativeToManaged.Add(type_ushort(), ValueType.UShort);
        StandardToManaged.Add(typeof(ushort), ValueType.UShort);
        ManagedToStandard.Add(ValueType.UShort, typeof(ushort));

        ManagedToNative.Add(ValueType.Int32, type_int32());
        NativeToManaged.Add(type_int32(), ValueType.Int32);
        StandardToManaged.Add(typeof(int), ValueType.Int32);
        ManagedToStandard.Add(ValueType.Int32, typeof(int));

        ManagedToNative.Add(ValueType.UInt32, type_uint32());
        NativeToManaged.Add(type_uint32(), ValueType.UInt32);
        StandardToManaged.Add(typeof(uint), ValueType.UInt32);
        ManagedToStandard.Add(ValueType.UInt32, typeof(uint));

        ManagedToNative.Add(ValueType.Long, type_long());
        NativeToManaged.Add(type_long(), ValueType.Long);
        ManagedToStandard.Add(ValueType.Long, typeof(long));

        ManagedToNative.Add(ValueType.ULong, type_ulong());
        NativeToManaged.Add(type_ulong(), ValueType.ULong);
        ManagedToStandard.Add(ValueType.ULong, typeof(ulong));

        ManagedToNative.Add(ValueType.Int64, type_int64());
        NativeToManaged.Add(type_int64(), ValueType.Int64);
        StandardToManaged.Add(typeof(long), ValueType.Int64);
        ManagedToStandard.Add(ValueType.Int64, typeof(long));

        ManagedToNative.Add(ValueType.UInt64, type_uint64());
        NativeToManaged.Add(type_uint64(), ValueType.UInt64);
        StandardToManaged.Add(typeof(ulong), ValueType.UInt64);
        ManagedToStandard.Add(ValueType.UInt64, typeof(ulong));

        ManagedToNative.Add(ValueType.Float, type_float());
        NativeToManaged.Add(type_float(), ValueType.Float);
        StandardToManaged.Add(typeof(float), ValueType.Float);
        ManagedToStandard.Add(ValueType.Float, typeof(float));

        ManagedToNative.Add(ValueType.Double, type_double());
        NativeToManaged.Add(type_double(), ValueType.Double);
        StandardToManaged.Add(typeof(double), ValueType.Double);
        ManagedToStandard.Add(ValueType.Double, typeof(double));

        ManagedToNative.Add(ValueType.String, type_string());
        NativeToManaged.Add(type_string(), ValueType.String);
        StandardToManaged.Add(typeof(string), ValueType.String);
        ManagedToStandard.Add(ValueType.String, typeof(string));

        ManagedToNative.Add(ValueType.Array, type_array());
        NativeToManaged.Add(type_array(), ValueType.Array);

        ManagedToNative.Add(ValueType.List, type_list());
        NativeToManaged.Add(type_list(), ValueType.List);

        ManagedToNative.Add(ValueType.Hash, type_hash());
        NativeToManaged.Add(type_hash(), ValueType.Hash);

        ManagedToNative.Add(ValueType.Optional, type_optional());
        NativeToManaged.Add(type_optional(), ValueType.Optional);

        ManagedToNative.Add(ValueType.Error, type_error());
        NativeToManaged.Add(type_error(), ValueType.Error);
        StandardToManaged.Add(typeof(UIKit.DataTypes.Error), ValueType.Error);
        ManagedToStandard.Add(ValueType.Error, typeof(UIKit.DataTypes.Error));

        ManagedToNative.Add(ValueType.Object, type_object());
        NativeToManaged.Add(type_object(), ValueType.Object);
        // We don't use `typeof(UIKit.Object)` directly in the StandartToManaged dictionary as typeof(myobj) may
        // return a different type. For ManagedToStandard, we make use of C# generics covariance to create
        // an collection of UIKit.Objects when unwrapping.
        ManagedToStandard.Add(ValueType.Object, typeof(UIKit.Object));

        ManagedToNative.Add(ValueType.Empty, IntPtr.Zero);
        NativeToManaged.Add(IntPtr.Zero, ValueType.Empty);

        TypesLoaded = true;
    }
}

/// <summary>Wrapper around UIKit.DataTypes.Value generic storage.
///
/// <para>UIKit.DataTypes.Value is EFL's main workhorse to deal with storing generic data in
/// a uniform way.</para>
///
/// <para>It comes with predefined types for numbers, strings, arrays, lists, hashes,
/// blobs and structs. It is able to convert between data types, including
/// to and from strings.</para>
///
/// Since EFL 1.23.
/// </summary>
public class Value : IDisposable, IComparable<Value>, IEquatable<Value>
{

    // Unmanaged type - Managed type mapping
    // Ok EINA_VALUE_TYPE_UCHAR: unsigned char -- byte
    // Ok EINA_VALUE_TYPE_USHORT: unsigned short -- ushort
    // Ok EINA_VALUE_TYPE_UINT: unsigned int -- uint
    // Ok EINA_VALUE_TYPE_ULONG: unsigned long -- ulong
    // Ok EINA_VALUE_TYPE_UINT64: uint64_t -- ulong
    // Ok EINA_VALUE_TYPE_CHAR: char -- sbyte
    // Ok EINA_VALUE_TYPE_SHORT: short -- short
    // Ok EINA_VALUE_TYPE_INT: int -- int
    // Ok EINA_VALUE_TYPE_LONG: long -- long
    // OK EINA_VALUE_TYPE_INT64: int64_t -- long
    // Ok EINA_VALUE_TYPE_FLOAT: float -- float
    // Ok EINA_VALUE_TYPE_DOUBLE: double -- double
    // EINA_VALUE_TYPE_STRINGSHARE: const char * -- string
    // Ok EINA_VALUE_TYPE_STRING: const char * -- string
    // Ok EINA_VALUE_TYPE_ARRAY: Eina_Value_Array -- UIKit.DataTypes.Array?
    // Ok EINA_VALUE_TYPE_LIST: Eina_Value_List -- UIKit.DataTypes.List?
    // EINA_VALUE_TYPE_HASH: Eina_Value_Hash -- UIKit.DataTypes.Hash?
    // EINA_VALUE_TYPE_TIMEVAL: struct timeval -- FIXME
    // EINA_VALUE_TYPE_BLOB: Eina_Value_Blob -- FIXME
    // EINA_VALUE_TYPE_STRUCT: Eina_Value_Struct -- FIXME


    internal IntPtr Handle { get; set;}

    /// <summary> Whether this wrapper owns (can free) the native value. </summary>
    public Ownership Ownership { get; protected set;}

    private bool Disposed;

    /// <summary> Whether this is an Optional value (meaning it can have a value or not). </summary>
    public bool Optional
    {
        get
        {
            return GetValueType() == UIKit.DataTypes.ValueType.Optional;
        }

        /* protected set {
            // Should we expose this?
            // Something like {
            //    flush(handle)/free(handle)
            //    handle = eina_value_optional_empty_new()
            // }
         } */
    }

    /// <summary> Whether this wrapper is actually empty/uninitialized (zeroed). This is different from an empty optional value. </summary>
    public bool Empty
    {
        get
        {
            SanityChecks();
            return GetValueType() == UIKit.DataTypes.ValueType.Empty;
        }
    }

    /// <summary> Whether this optional value is empty. </summary>
    public bool OptionalEmpty
    {
        get
        {
            OptionalSanityChecks();
            bool empty;
            if (!eina_value_optional_empty_is_wrapper(this.Handle, out empty))
            {
                throw new System.InvalidOperationException("Couldn't get the empty information");
            }
            else
            {
                return empty;
            }
        }
    }

    private static IntPtr Alloc()
    {
        return eina_value_new(type_int32());
    }

    private static void Free(IntPtr ptr)
    {
        eina_value_free(ptr);
    }

    // Constructor to be used by the "FromContainerDesc" methods.
    private Value()
    {
        this.Handle = Alloc();

        if (this.Handle == IntPtr.Zero)
        {
            throw new OutOfMemoryException("Failed to allocate memory for UIKit.DataTypes.Value");
        }

        this.Ownership = Ownership.Managed;
        MemoryNative.Memset(this.Handle, 0, eina_value_sizeof());
    }

    /// <summary>Creates a new Value from the given C# value.</summary>
    /// <param name="obj">The object to be wrapped.</param>
    public Value(object obj) : this()
    {
        var objType = obj.GetType();

        if (objType == typeof(sbyte))
        {
            Setup(ValueType.SByte);
            Set((sbyte)obj);
        }
        else if (objType == typeof(byte))
        {
            Setup(ValueType.Byte);
            Set((byte)obj);
        }
        else if (objType == typeof(short))
        {
            Setup(ValueType.Short);
            Set((short)obj);
        }
        else if (objType == typeof(ushort))
        {
            Setup(ValueType.UShort);
            Set((ushort)obj);
        }
        else if (objType == typeof(int))
        {
            Setup(ValueType.Int32);
            Set((int)obj);
        }
        else if (objType == typeof(uint))
        {
            Setup(ValueType.UInt32);
            Set((uint)obj);
        }
        else if (objType == typeof(long))
        {
            Setup(ValueType.Int64);
            Set((long)obj);
        }
        else if (objType == typeof(ulong))
        {
            Setup(ValueType.UInt64);
            Set((ulong)obj);
        }
        else if (objType == typeof(float))
        {
            Setup(ValueType.Float);
            Set((float)obj);
        }
        else if (objType == typeof(double))
        {
            Setup(ValueType.Double);
            Set((double)obj);
        }
        else if (objType == typeof(string))
        {
            Setup(ValueType.String);
            Set(obj as string);
        }
        else if (typeof(UIKit.Object).IsAssignableFrom(objType))
        {
            Setup(ValueType.Object);
            Set(obj as UIKit.Object);
        }
        else
        {
            // Container type conversion is supported only from IEnumerable<T>
            if (!obj.GetType().GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
            {
                throw new ArgumentException($"Unsupported type for direct construction: {objType}");
            }

            Type[] genericArguments = objType.GetGenericArguments();
            if (genericArguments.Count() != 1)
            {
                throw new ArgumentException($"Unsupported type for direct construction: {objType}");
            }

            var genericArg = genericArguments[0];

            var argValueType = ValueTypeBridge.GetManaged(genericArg);

            Setup(ValueType.Array, argValueType);

            foreach (var item in obj as System.Collections.IEnumerable)
            {
                Append(item);
            }

        }
    }

    public Value(IntPtr handle, Ownership ownership = Ownership.Managed)
    {
        this.Handle = handle;
        this.Ownership = ownership;
    }

    /// <summary>Creates a new value storage for values of type 'type'.</summary>
    public Value(ValueType type)
    {
        if (type.IsContainer())
        {
            throw new ArgumentException("To use container types you must provide a subtype");
        }

        this.Handle = Alloc();
        if (this.Handle == IntPtr.Zero)
        {
            throw new OutOfMemoryException("Failed to allocate memory for UIKit.DataTypes.Value");
        }

        // Initialize to EINA_VALUE_EMPTY before performing any other operation on this value.
        MemoryNative.Memset(this.Handle, 0, eina_value_sizeof());

        this.Ownership = Ownership.Managed;
        Setup(type);
    }

    /// <summary>Constructor for container values, like Array, Hash.</summary>
    public Value(ValueType containerType, ValueType subtype, uint step = 0)
    {
        if (!containerType.IsContainer())
        {
            throw new ArgumentException("First type must be a container type.");
        }

        this.Handle = Alloc();
        this.Ownership = Ownership.Managed;

        Setup(containerType, subtype, step);
    }

    /// <summary>Deep copies the given eina Value</summary>
    public Value(Value v)
    {
        Handle = Alloc();
        if (!eina_value_copy(v.Handle, this.Handle))
        {
            throw new System.InvalidOperationException("Failed to copy value to managed memory.");
        }

        Disposed = false;
        Ownership = Ownership.Managed;
    }

    /// <summary>Constructor to build value from Values_Natives passed by value from C.</summary>
    public Value(ValueNative value)
    {
        IntPtr tmp = IntPtr.Zero;
        try
        {
            this.Handle = Alloc();
            if (value.Type == IntPtr.Zero) // Got an EINA_VALUE_EMPTY by value.
            {
                MemoryNative.Memset(this.Handle, 0, Marshal.SizeOf(typeof(ValueNative)));
            }
            else
            {
                // We allocate this intermediate ValueNative using malloc to allow freeing with
                // free(), avoiding a call to eina_value_flush that would wipe the underlying value contents
                // for pointer types like string.
                tmp = MemoryNative.Alloc(Marshal.SizeOf(typeof(ValueNative)));
                Marshal.StructureToPtr<ValueNative>(value, tmp, false); // Can't get the address of a struct directly.

                // Copy is used to deep copy the pointed payload (e.g. strings) inside this struct, so we can own this value.
                if (!eina_value_copy(tmp, this.Handle))
                {
                    throw new System.InvalidOperationException("Failed to copy value to managed memory.");
                }
            }
        }
        catch
        {
            Free(this.Handle);
            throw;
        }
        finally
        {
            if (tmp != IntPtr.Zero)
            {
                MemoryNative.Free(tmp);
            }
        }

        this.Ownership = Ownership.Managed;
    }

    /// <summary>Type-specific constructor, for convenience.</summary>
    public Value(byte x) : this(ValueType.Byte)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.</summary>
    public Value(sbyte x) : this(ValueType.SByte)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.</summary>
    public Value(short x) : this(ValueType.Short)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.</summary>
    public Value(ushort x) : this(ValueType.UShort)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.</summary>
    public Value(int x) : this(ValueType.Int32)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.</summary>
    public Value(uint x) : this(ValueType.UInt32)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.</summary>
    public Value(long x) : this(ValueType.Long)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.</summary>
    public Value(ulong x) : this(ValueType.ULong)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.</summary>
    public Value(float x) : this(ValueType.Float)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.</summary>
    public Value(double x) : this(ValueType.Double)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.</summary>
    public Value(string x) : this(ValueType.String)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Implicit conversion from managed value to native struct representation.</summary>
    public static implicit operator ValueNative(Value v)
    {
        return v.GetNative();
    }

    /// <summary>Implicit conversion from native struct representation to managed wrapper.</summary>
    public static implicit operator Value(ValueNative v)
    {
        return new Value(v);
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator Value(byte x)
    {
        var v = new UIKit.DataTypes.Value(ValueType.Byte);
        if (!v.Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }

        return v;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator byte(Value v)
    {
        byte b;
        if (!v.Get(out b))
        {
            throw new InvalidOperationException("Couldn't get value.");
        }

        return b;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator Value(sbyte x)
    {
        var v = new UIKit.DataTypes.Value(ValueType.SByte);
        if (!v.Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }

        return v;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator sbyte(Value v)
    {
        sbyte b;
        if (!v.Get(out b))
        {
            throw new InvalidOperationException("Couldn't get value.");
        }

        return b;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator Value(short x)
    {
        var v = new UIKit.DataTypes.Value(ValueType.Short);
        if (!v.Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }

        return v;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator short(Value v)
    {
        short b;
        if (!v.Get(out b))
        {
            throw new InvalidOperationException("Couldn't get value.");
        }

        return b;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator Value(ushort x)
    {
        var v = new UIKit.DataTypes.Value(ValueType.UShort);
        if (!v.Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }

        return v;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator ushort(Value v)
    {
        ushort b;
        if (!v.Get(out b))
        {
            throw new InvalidOperationException("Couldn't get value.");
        }

        return b;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator Value(int x)
    {
        var v = new UIKit.DataTypes.Value(ValueType.Int32);
        if (!v.Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }

        return v;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator int(Value v)
    {
        int b;
        if (!v.Get(out b))
        {
            throw new InvalidOperationException("Couldn't get value.");
        }

        return b;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator Value(uint x)
    {
        var v = new UIKit.DataTypes.Value(ValueType.UInt32);
        if (!v.Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }

        return v;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator uint(Value v)
    {
        uint b;
        if (!v.Get(out b))
        {
            throw new InvalidOperationException("Couldn't get value.");
        }

        return b;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator Value(long x)
    {
        var v = new UIKit.DataTypes.Value(ValueType.Long);
        if (!v.Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }

        return v;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator long(Value v)
    {
        long b;
        if (!v.Get(out b))
        {
            throw new InvalidOperationException("Couldn't get value.");
        }

        return b;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator Value(ulong x)
    {
        var v = new UIKit.DataTypes.Value(ValueType.ULong);
        if (!v.Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }

        return v;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator ulong(Value v)
    {
        ulong b;
        if (!v.Get(out b))
        {
            throw new InvalidOperationException("Couldn't get value.");
        }

        return b;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator Value(float x)
    {
        var v = new UIKit.DataTypes.Value(ValueType.Float);
        if (!v.Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }

        return v;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator float(Value v)
    {
        float b;
        if (!v.Get(out b))
        {
            throw new InvalidOperationException("Couldn't get value.");
        }

        return b;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator Value(double x)
    {
        var v = new UIKit.DataTypes.Value(ValueType.Double);
        if (!v.Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }

        return v;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator double(Value v)
    {
        double b;
        if (!v.Get(out b))
        {
            throw new InvalidOperationException("Couldn't get value.");
        }

        return b;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator Value(string x)
    {
        var v = new UIKit.DataTypes.Value(ValueType.String);
        if (!v.Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }

        return v;
    }

    /// <summary>Implicit conversion.</summary>
    public static implicit operator string(Value v)
    {
        string b;
        if (!v.Get(out b))
        {
            throw new InvalidOperationException("Couldn't get value.");
        }

        return b;
    }

    /// <summary>Unwrap the value into its underlying C# value.
    ///
    /// <para>Useful for methods like <see crev="PropertyInfo.SetValue(object, object)" />
    /// as it will unpack the value to it correct C# type.</para>
    /// </summary>
    /// <returns>The C# value wrapped by this value.</returns>
    public object Unwrap()
    {
        switch (GetValueType())
        {
            case ValueType.SByte:
                {
                    sbyte o;
                    Get(out o);
                    return o;
                }
            case ValueType.Byte:
                {
                    byte o;
                    Get(out o);
                    return o;
                }
            case ValueType.Short:
                {
                    short o;
                    Get(out o);
                    return o;
                }
            case ValueType.UShort:
                {
                    ushort o;
                    Get(out o);
                    return o;
                }
            case ValueType.Int32:
                {
                    int o;
                    Get(out o);
                    return o;
                }
            case ValueType.UInt32:
                {
                    uint o;
                    Get(out o);
                    return o;
                }
            case ValueType.Int64:
            case ValueType.Long:
                {
                    long o;
                    Get(out o);
                    return o;
                }
            case ValueType.UInt64:
            case ValueType.ULong:
                {
                    ulong o;
                    Get(out o);
                    return o;
                }
            case ValueType.Float:
                {
                    float o;
                    Get(out o);
                    return o;
                }
            case ValueType.Double:
                {
                    double o;
                    Get(out o);
                    return o;
                }
            case ValueType.String:
                {
                    string o;
                    Get(out o);
                    return o;
                }
            case ValueType.Object:
                {
                    UIKit.Object o;
                    Get(out o);
                    return o;
                }
            case ValueType.Array:
            case ValueType.List:
                {
                    // Eina Array and Lists will be unwrapped into a System.Collections.Generic.List<T>
                    // usually to be handled as IEnumerable<T> through LINQ.
                    var genericType = ValueTypeBridge.GetStandard(GetValueSubType());
                    Type[] typeArgs = { genericType };
                    var containerType = typeof(System.Collections.Generic.List<>);
                    var retType = containerType.MakeGenericType(typeArgs);
                    object ret = Activator.CreateInstance(retType);

                    var addMeth = retType.GetMethod("Add");

                    if (addMeth == null)
                    {
                        throw new InvalidOperationException("Failed to get Add() method of container to wrap value");
                    }

                    for (int i = 0; i < Count(); i++)
                    {
                        object[] args = new object[]{ this[i] };
                        addMeth.Invoke(ret, args);
                    }

                    return ret;
                }
            default:
                throw new InvalidOperationException($"Unsupported value type to unwrap: {GetValueType()}");
        }
    }

    // UIKit.Object conversions are made explicit to avoid ambiguity between
    // Set(UIKit.Object) and Set(Value) when dealing with classes derived from
    // UIKit.Object.
    /// <summary>Explicit conversion from EFL objects.</summary>
    public static explicit operator Value(UIKit.Object obj)
    {
        var v = new UIKit.DataTypes.Value(ValueType.Object);
        if (!v.Set(obj))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
        return v;
    }

    /// <summary>Explicit conversion from Value to UIKit.Objects.</summary>
    public static explicit operator UIKit.Object(Value v)
    {
        UIKit.Object obj;
        if (!v.Get(out obj))
        {
            throw new InvalidOperationException("Couldn't get value.");
        }

        return obj;
    }

    /// <summary>Creates an Value instance from a given array description.</summary>
    private static Value FromArrayDesc(UIKit.DataTypes.EinaNative.Value_Array arrayDesc)
    {
        Value value = new Value();
        value.Setup(ValueType.Array, ValueType.String); // Placeholder values to be overwritten by the following pset call.

        eina_value_pset_wrapper(value.Handle, ref arrayDesc);
        return value;
    }

    /// <summary>Creates an Value instance from a given array description.</summary>
    private static Value FromListDesc(UIKit.DataTypes.EinaNative.Value_List listDesc)
    {
        Value value = new Value();
        value.Setup(ValueType.List, ValueType.String); // Placeholder values to be overwritten by the following pset call.

        eina_value_pset_wrapper(value.Handle, ref listDesc);
        return value;
    }

    /// <summary>Releases the ownership of the underlying value to C.</summary>
    public void ReleaseOwnership()
    {
        this.Ownership = Ownership.Unmanaged;
    }

    /// <summary>Takes the ownership of the underlying value to the Managed runtime.</summary>
    public void TakeOwnership()
    {
        this.Ownership = Ownership.Managed;
    }

    /// <summary>Public method to explicitly free the wrapped eina value.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Actually free the wrapped eina value. Can be called from Dispose() or through the GC.</summary>
    protected virtual void Dispose(bool disposing)
    {
        if (this.Ownership == Ownership.Unmanaged)
        {
            Disposed = true;
            return;
        }

        if (!Disposed && (Handle != IntPtr.Zero))
        {
            // No need to call flush as eina_value_free already calls it for us.
            if (disposing)
            {
                Free(this.Handle);
            }
            else
            {
                UIKit.Wrapper.Globals.ThreadSafeFreeCbExec(eina_value_free, this.Handle);
            }
        }

        Disposed = true;
    }

    /// <summary>Finalizer to be called from the Garbage Collector.</summary>
    ~Value()
    {
        Dispose(false);
    }

    /// <summary>Returns the native handle wrapped by this object.</summary>
    public IntPtr NativeHandle
    {
        get
        {
            if (Disposed)
            {
                throw new ObjectDisposedException($"Value at 0x{this.Handle.ToInt64():x}");
            }

            return this.Handle;
        }
    }

    /// <summary>Converts this storage to type 'type'</summary>
    public bool Setup(ValueType type)
    {
        if (Disposed)
        {
            throw new ObjectDisposedException($"Value at 0x{this.Handle.ToInt64():x}");
        }

        // Can't call setup with Empty value type (would give an eina error)
        if (type == UIKit.DataTypes.ValueType.Empty)
        {
            // Need to cleanup as it may point to payload outside the underlying Eina_Value (like arrays and strings).
            if (!Empty)
            {
                eina_value_flush_wrapper(this.Handle);
            }

            MemoryNative.Memset(this.Handle, 0, eina_value_sizeof());

            return true;
        }

        if (type.IsContainer())
        {
            throw new ArgumentException("To setup a container you must provide a subtype.");
        }

        return eina_value_setup_wrapper(this.Handle, ValueTypeBridge.GetNative(type));
    }

    public bool Setup(ValueType containerType, ValueType subtype, uint step = 0)
    {
        IntPtr native_subtype = ValueTypeBridge.GetNative(subtype);
        bool ret = false;
        switch (containerType)
        {
            case ValueType.Array:
                ret = eina_value_array_setup_wrapper(this.Handle, native_subtype, step);
                break;
            case ValueType.List:
                ret = eina_value_list_setup_wrapper(this.Handle, native_subtype);
                break;
        }

        return ret;
    }

    private void SanityChecks()
    {
        if (Disposed)
        {
            throw new ObjectDisposedException($"Value at 0x{this.Handle.ToInt64():x}");
        }
    }

    private void ContainerSanityChecks(int targetIndex = -1)
    {
        SanityChecks();
        uint size = 0;
        ValueType type = GetValueType();

        if (!type.IsContainer())
        {
                throw new InvalidValueTypeException("Value type must be a container");
        }

        if (targetIndex == -1)  // Some methods (e.g. append) don't care about size
        {
            return;
        }

        switch (type)
        {
            case ValueType.Array:
                size = eina_value_array_count_wrapper(this.Handle);
                break;
            case ValueType.List:
                size = eina_value_list_count_wrapper(this.Handle);
                break;
        }

        if (targetIndex >= size)
        {
                throw new System.ArgumentOutOfRangeException(
                        $"Index {targetIndex} is larger than max array index {size-1}");
        }
    }

    private void OptionalSanityChecks()
    {
        SanityChecks();
        ValueType type = GetValueType();

        if (!type.IsOptional())
        {
            throw new InvalidValueTypeException("Value is not an Optional one");
        }
    }

    /// <summary>Get a ValueNative struct with the *value* pointed by this UIKit.DataTypes.Value.</summary>
    public ValueNative GetNative()
    {
        SanityChecks();
        ValueNative value = (ValueNative)Marshal.PtrToStructure(this.Handle, typeof(ValueNative));
        return value;
    }

    public bool Set(byte value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.Byte),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric UIKit.DataTypes.Value"));
        }

        return eina_value_set_wrapper_uchar(this.Handle, value);
    }

    public bool Set(sbyte value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.SByte),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric UIKit.DataTypes.Value"));
        }

        return eina_value_set_wrapper_char(this.Handle, value);
    }

    public bool Set(short value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.Short),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric UIKit.DataTypes.Value"));
        }

        return eina_value_set_wrapper_short(this.Handle, value);
    }

    public bool Set(ushort value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.UShort),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric UIKit.DataTypes.Value"));
        }

        return eina_value_set_wrapper_ushort(this.Handle, value);
    }

    /// <summary>Stores the given uint value.</summary>
    public bool Set(uint value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.UInt32),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric UIKit.DataTypes.Value"));
        }

        return eina_value_set_wrapper_uint(this.Handle, value);
    }

    /// <summary>Stores the given int value.</summary>
    public bool Set(int value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.Int32),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric UIKit.DataTypes.Value"));
        }

        return eina_value_set_wrapper_int(this.Handle, value);
    }

    /// <summary>Stores the given ulong value.</summary>
    public bool Set(ulong value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.ULong),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric UIKit.DataTypes.Value"));
        }

        return eina_value_set_wrapper_ulong(this.Handle, value);
    }

    /// <summary>Stores the given int value.</summary>
    public bool Set(long value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.Long),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric UIKit.DataTypes.Value"));
        }

        return eina_value_set_wrapper_long(this.Handle, value);
    }

    /// <summary>Stores the given int value.</summary>
    public bool Set(float value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.Float),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric UIKit.DataTypes.Value"));
        }

        return eina_value_set_wrapper_float(this.Handle, value);
    }

    /// <summary>Stores the given int value.</summary>
    public bool Set(double value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.Double),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric UIKit.DataTypes.Value"));
        }

        return eina_value_set_wrapper_double(this.Handle, value);
    }

    /// <summary>Stores the given string value.</summary>
    public bool Set(string value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.String),
                                            ref value);
        }

        if (!GetValueType().IsString())
        {
            throw (new ArgumentException(
                        "Trying to set string value on a non-string UIKit.DataTypes.Value"));
        }

        // No need to worry about ownership as eina_value_set will copy the passed string.
        return eina_value_set_wrapper_string(this.Handle, value);
    }

    /// <summary>Stores the given error value.</summary>
    public bool Set(UIKit.DataTypes.Error value)
    {
        SanityChecks();

        int error_code = value;

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.Error),
                                            ref error_code);
        }

        return eina_value_set_wrapper_int(this.Handle, error_code);
    }

    /// <summary>Stores the given object.</summary>
    public bool Set(UIKit.Object value)
    {
        // FIXME Implement me
        SanityChecks();

        if (this.Optional)
        {
            IntPtr ptr = value.NativeHandle;
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.Object),
                                            ref ptr);
        }
        return eina_value_set_wrapper_ptr(this.Handle, value.NativeHandle);
    }

    /// <summary>Stores the given value into this value. The target value must be an optional.</summary>
    public bool Set(Value value)
    {
        OptionalSanityChecks();
        ValueType subtype = value.GetValueType();

        IntPtr ptr_val = MemoryNative.Alloc(subtype.MarshalSizeOf());
        IntPtr native_type = ValueTypeBridge.GetNative(subtype);

        try
        {
            switch (subtype)
            {
                // PSet on Container types require an Eina_Value_<Container>, which is the structure
                // that contains subtype, etc.
                case ValueType.Array:
                    EinaNative.Value_Array value_array;
                    if (!eina_value_get_wrapper(value.Handle, out value_array))
                    {
                        return false;
                    }

                    Marshal.StructureToPtr(value_array, ptr_val, false);
                    break;
                case ValueType.List:
                    EinaNative.Value_List value_list;
                    if (!eina_value_get_wrapper(value.Handle, out value_list))
                    {
                        return false;
                    }

                    Marshal.StructureToPtr(value_list, ptr_val, false);
                    break;
                default:
                    throw new InvalidValueTypeException("Only containers can be passed as raw UIKit.DataTypes.Values");
            }

            return eina_value_optional_pset(this.Handle, native_type, ptr_val);
        }
        finally
        {
            MemoryNative.Free(ptr_val);
        }
    }

    /// <summary>Gets the currently stored value as a byte.</summary>
    public bool Get(out byte value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as a sbyte.</summary>
    public bool Get(out sbyte value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as a short.</summary>
    public bool Get(out short value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as an ushort.</summary>
    public bool Get(out ushort value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as an int.</summary>
    public bool Get(out int value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as an uint.</summary>
    public bool Get(out uint value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as a long.</summary>
    public bool Get(out long value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as an ulong.</summary>
    public bool Get(out ulong value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as a float.</summary>
    public bool Get(out float value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as a double.</summary>
    public bool Get(out double value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as a string.</summary>
    public bool Get(out string value)
    {
        SanityChecks();
        IntPtr output = IntPtr.Zero;
        if (this.Optional)
        {
            if (!eina_value_optional_pget(this.Handle, out output))
            {
                value = String.Empty;
                return false;
            }
        }
        else if (!eina_value_get_wrapper(this.Handle, out output))
        {
            value = String.Empty;
            return false;
        }

        value = StringConversion.NativeUtf8ToManagedString(output);
        return true;
    }

    /// <summary>Gets the currently stored value as an UIKit.DataTypes.Error.</summary>
    public bool Get(out UIKit.DataTypes.Error value)
    {
        SanityChecks();
        bool ret;
        int intermediate; // It seems out doesn't play well with implicit operators...
        if (this.Optional)
        {
            ret = eina_value_optional_pget(this.Handle, out intermediate);
        }
        else
        {
            ret = eina_value_get_wrapper(this.Handle, out intermediate);
        }

        value = intermediate;

        return ret;
    }

    /// <summary>Gets the currently stored value as an <see cref="UIKit.Object"/>.</summary>
    public bool Get(out UIKit.Object obj)
    {
        // FIXME Implement me
        SanityChecks();
        IntPtr ptr;
        bool ret;

        if (this.Optional)
        {
            ret = eina_value_optional_pget(this.Handle, out ptr);
        }
        else
        {
            ret = eina_value_get_wrapper(this.Handle, out ptr);
        }

        if (ret)
        {
            obj = (UIKit.Object) UIKit.Wrapper.Globals.CreateWrapperFor(ptr);
        }
        else
        {
            obj = null;
        }

        return ret;
    }


    /// <summary>Gets the currently stored value as an complex (e.g. container) UIKit.DataTypes.Value.</summary>
    public bool Get(out Value value)
    {
        SanityChecks();
        value = null;

        if (!this.Optional)
        {
            throw new InvalidValueTypeException("Values can only be retreived");
        }

        IntPtr nativeType = eina_value_optional_type_get_wrapper(this.Handle);
        ValueType managedType = ValueTypeBridge.GetManaged(nativeType);

        switch (managedType)
        {
            case ValueType.Array:
                UIKit.DataTypes.EinaNative.Value_Array array_desc;

                if (!eina_value_optional_pget(this.Handle, out array_desc))
                {
                    return false;
                }

                value = Value.FromArrayDesc(array_desc);
                break;
            case ValueType.List:
                UIKit.DataTypes.EinaNative.Value_List list_desc;

                if (!eina_value_optional_pget(this.Handle, out list_desc))
                {
                    return false;
                }

                value = Value.FromListDesc(list_desc);
                break;
        }

        return true;
    }

    /// <summary>Gets the 'Type' this value is currently configured to store.</summary>
    public ValueType GetValueType()
    {
        if (Disposed)
        {
            throw new ObjectDisposedException(base.GetType().Name);
        }

        IntPtr native_type = eina_value_type_get_wrapper(this.Handle);
        return ValueTypeBridge.GetManaged(native_type);
    }

    /// <summary>Converts the value on this storage to the type of 'target' and stores
    /// the result in 'target'.</summary>
    public bool ConvertTo(Value target)
    {
        if (target == null)
        {
            return false;
        }

        SanityChecks();

        return eina_value_convert(this.Handle, target.Handle);
    }

    /// <summary>Compare two eina values.</summary>
    public int CompareTo(Value other)
    {
        if (other == null)
        {
            return 1;
        }

        SanityChecks();
        other.SanityChecks();
        return eina_value_compare_wrapper(this.Handle, other.Handle);
    }

    public int Compare(Value other)
    {
        return this.CompareTo(other);
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }

        Value v = obj as Value;
        if (v == null)
        {
            return false;
        }

        return this.Equals(v);
    }

    public bool Equals(Value other)
    {
        try
        {
            return this.CompareTo(other) == 0;
        }
        catch (ObjectDisposedException)
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return this.Handle.ToInt32();
    }

    public static bool operator==(Value x, Value y)
    {
        if (object.ReferenceEquals(x, null))
        {
            return object.ReferenceEquals(y, null);
        }

        return x.Equals(y);
    }

    public static bool operator!=(Value x, Value y)
    {
        if (object.ReferenceEquals(x, null))
        {
            return !object.ReferenceEquals(y, null);
        }

        return !x.Equals(y);
    }

    public static bool operator>(Value x, Value y)
    {
        if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
        {
            return false;
        }

        return x.CompareTo(y) > 0;
    }

    public static bool operator<(Value x, Value y)
    {
        if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
        {
            return false;
        }

        return x.CompareTo(y) < 0;
    }


    /// <summary>Converts value to string.</summary>
    public override String ToString()
    {
        SanityChecks();
        return eina_value_to_string(this.Handle);

    }

    /// <summary>Empties an optional UIKit.DataTypes.Value, freeing what was previously contained.</summary>
    public bool Reset()
    {
        OptionalSanityChecks();
        return eina_value_optional_reset(this.Handle);
    }

    // Container methods methods
    public int Count()
    {
        ContainerSanityChecks();
        switch (GetValueType())
        {
            case ValueType.Array:
                return (int)eina_value_array_count_wrapper(this.Handle);
            case ValueType.List:
                return (int)eina_value_list_count_wrapper(this.Handle);
        }

        return -1;
    }

    public bool Append(object o)
    {
        ContainerSanityChecks();

        switch (GetValueSubType())
        {
            case ValueType.SByte:
                {
                    sbyte b = Convert.ToSByte(o);
                    return eina_value_container_append_wrapper_char(this.Handle, b);
                }

            case ValueType.Byte:
                {
                    byte b = Convert.ToByte(o);
                    return eina_value_container_append_wrapper_uchar(this.Handle, b);
                }

            case ValueType.Short:
                {
                    short b = Convert.ToInt16(o);
                    return eina_value_container_append_wrapper_short(this.Handle, b);
                }

            case ValueType.UShort:
                {
                    ushort b = Convert.ToUInt16(o);
                    return eina_value_container_append_wrapper_ushort(this.Handle, b);
                }

            case ValueType.Int32:
                {
                    int x = Convert.ToInt32(o);
                    return eina_value_container_append_wrapper_int(this.Handle, x);
                }

            case ValueType.UInt32:
                {
                    uint x = Convert.ToUInt32(o);
                    return eina_value_container_append_wrapper_uint(this.Handle, x);
                }

            case ValueType.Long:
            case ValueType.Int64:
                {
                    long x = Convert.ToInt64(o);
                    return eina_value_container_append_wrapper_long(this.Handle, x);
                }

            case ValueType.ULong:
            case ValueType.UInt64:
                {
                    ulong x = Convert.ToUInt64(o);
                    return eina_value_container_append_wrapper_ulong(this.Handle, x);
                }

            case ValueType.Float:
                {
                    float x = Convert.ToSingle(o);
                    return eina_value_container_append_wrapper_float(this.Handle, x);
                }

            case ValueType.Double:
                {
                    double x = Convert.ToDouble(o);
                    return eina_value_container_append_wrapper_double(this.Handle, x);
                }

            case ValueType.String:
                {
                    string x = Convert.ToString(o);
                    return eina_value_container_append_wrapper_string(this.Handle, x);
                }
            case ValueType.Object:
                {
                    var x = (UIKit.Object) o;
                    return eina_value_container_append_wrapper_ptr(this.Handle, x.NativeHandle);
                }
        }

        return false;
    }

    public object this[int i]
    {
        get
        {
            ContainerSanityChecks(i);

            switch (GetValueSubType())
            {
                case ValueType.SByte:
                    {
                        sbyte ret = default(sbyte);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.Byte:
                    {
                        byte ret = default(byte);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.Short:
                    {
                        short ret = default(short);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.UShort:
                    {
                        ushort ret = default(ushort);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.Int32:
                    {
                        int ret = default(int);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.UInt32:
                    {
                        uint ret = default(uint);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.Long:
                case ValueType.Int64:
                    {
                        long ret = default(long);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.ULong:
                case ValueType.UInt64:
                    {
                        ulong ret = default(ulong);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.Float:
                    {
                        float ret = default(float);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.Double:
                    {
                        double ret = default(double);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.String:
                    {
                        // Using intptr as using string as the arg type in the DllImport'd function would
                        // make mono take ownership of the string.
                        IntPtr ptr = IntPtr.Zero;
                        eina_value_container_get_wrapper(this.Handle, i, out ptr);
                        return UIKit.DataTypes.StringConversion.NativeUtf8ToManagedString(ptr);
                    }
                case ValueType.Object:
                    {
                        IntPtr ptr = IntPtr.Zero;
                        eina_value_container_get_wrapper(this.Handle, i, out ptr);
                        return UIKit.Wrapper.Globals.CreateWrapperFor(ptr);
                    }

                default:
                    throw new InvalidOperationException("Subtype not supported.");
            }
        }
        set
        {
            ContainerSanityChecks(i);

            switch (GetValueSubType())
            {
                case ValueType.SByte:
                    {
                        sbyte v = Convert.ToSByte(value);
                        eina_value_container_set_wrapper_char(this.Handle, i, v);
                        break;
                    }

                case ValueType.Byte:
                    {
                        byte v = Convert.ToByte(value);
                        eina_value_container_set_wrapper_uchar(this.Handle, i, v);
                        break;
                    }

                case ValueType.Short:
                    {
                        short x = Convert.ToInt16(value);
                        eina_value_container_set_wrapper_short(this.Handle, i, x);
                        break;
                    }

                case ValueType.UShort:
                    {
                        ushort x = Convert.ToUInt16(value);
                        eina_value_container_set_wrapper_ushort(this.Handle, i, x);
                        break;
                    }

                case ValueType.Int32:
                    {
                        int x = Convert.ToInt32(value);
                        eina_value_container_set_wrapper_int(this.Handle, i, x);
                        break;
                    }

                case ValueType.UInt32:
                    {
                        uint x = Convert.ToUInt32(value);
                        eina_value_container_set_wrapper_uint(this.Handle, i, x);
                        break;
                    }

                case ValueType.Long:
                case ValueType.Int64:
                    {
                        long x = Convert.ToInt64(value);
                        eina_value_container_set_wrapper_long(this.Handle, i, x);
                        break;
                    }

                case ValueType.ULong:
                case ValueType.UInt64:
                    {
                        ulong x = Convert.ToUInt64(value);
                        eina_value_container_set_wrapper_ulong(this.Handle, i, x);
                        break;
                    }

                case ValueType.Float:
                    {
                        float x = Convert.ToSingle(value);
                        eina_value_container_set_wrapper_float(this.Handle, i, x);
                        break;
                    }

                case ValueType.Double:
                    {
                        double x = Convert.ToDouble(value);
                        eina_value_container_set_wrapper_double(this.Handle, i, x);
                        break;
                    }

                case ValueType.String:
                    {
                        string x = Convert.ToString(value);
                        eina_value_container_set_wrapper_string(this.Handle, i, x);
                        break;
                    }
                case ValueType.Object:
                    {
                        UIKit.Object x = (UIKit.Object)value;
                        eina_value_container_set_wrapper_ptr(this.Handle, i, x.NativeHandle);
                        break;
                    }
            }
        }
    }

    public ValueType GetValueSubType()
    {
        ContainerSanityChecks();

        IntPtr native_subtype = IntPtr.Zero;

        switch (GetValueType())
        {
            case ValueType.Array:
                native_subtype = eina_value_array_subtype_get_wrapper(this.Handle);
                break;
            case ValueType.List:
                native_subtype = eina_value_list_subtype_get_wrapper(this.Handle);
                break;
        }

        return ValueTypeBridge.GetManaged(native_subtype);
    }
}

/// <summary> Custom marshaler to convert value pointers to managed values and back,
/// without changing ownership.</summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public class ValueMarshaler : ICustomMarshaler
{
    /// <summary>Creates a managed value from a C pointer, whitout taking ownership of it.</summary>
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        return new Value(pNativeData, Ownership.Unmanaged);
    }

    /// <summary>Retrieves the C pointer from a given managed value,
    /// keeping the managed ownership.</summary>
    public IntPtr MarshalManagedToNative(object managedObj)
    {
        try
        {
            Value v = (Value)managedObj;
            return v.Handle;
        }
        catch (InvalidCastException)
        {
            return IntPtr.Zero;
        }
    }

    public void CleanUpNativeData(IntPtr pNativeData)
    {
    }

    public void CleanUpManagedData(object managedObj)
    {
    }

    public int GetNativeDataSize()
    {
        return -1;
    }

    public static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new ValueMarshaler();
        }

        return marshaler;
    }

    static private ValueMarshaler marshaler;
}

/// <summary> Custom marshaler to convert value pointers to managed values and back,
/// also transferring the ownership to the other side.</summary>
public class ValueMarshalerOwn : ICustomMarshaler
{
    /// <summary>Creates a managed value from a C pointer, taking the ownership.</summary>
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        return new Value(pNativeData, Ownership.Managed);
    }

    /// <summary>Retrieves the C pointer from a given managed value,
    /// transferring the ownership to the unmanaged side, which should release it
    /// when not needed. </summary>
    public IntPtr MarshalManagedToNative(object managedObj)
    {
        try
        {
            Value v = (Value)managedObj;
            v.ReleaseOwnership();
            return v.Handle;
        }
        catch (InvalidCastException)
        {
            return IntPtr.Zero;
        }
    }

    public void CleanUpNativeData(IntPtr pNativeData)
    {
    }

    public void CleanUpManagedData(object managedObj)
    {
    }

    public int GetNativeDataSize()
    {
        return -1;
    }

    public static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new ValueMarshalerOwn();
        }

        return marshaler;
    }

    static private ValueMarshalerOwn marshaler;
}

/// <summary> Custom marshaler to convert value type pointers to managed boxed enum values
/// and back.</summary>
public class ValueTypeMarshaler : ICustomMarshaler
{
    /// <summary>Creates a boxed ValueType enum value from a C pointer.</summary>
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        var r = ValueTypeBridge.GetManaged(pNativeData);
        return new ValueTypeBox(r);
    }
    public static UIKit.DataTypes.ValueType vtype;

    /// <summary>Retrieves the C pointer from a given boxed enum value type.</summary>
    public IntPtr MarshalManagedToNative(object managedObj)
    {
        ValueTypeBox v = (ValueTypeBox)managedObj;
        return ValueTypeBridge.GetNative(v);
    }

    public void CleanUpNativeData(IntPtr pNativeData)
    {
    }

    public void CleanUpManagedData(object managedObj)
    {
    }

    public int GetNativeDataSize()
    {
        return -1;
    }

    public static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new ValueTypeMarshaler();
        }

        return marshaler;
    }

    static private ValueTypeMarshaler marshaler;
}

}

}

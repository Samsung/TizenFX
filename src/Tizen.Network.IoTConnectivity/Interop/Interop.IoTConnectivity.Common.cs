 /*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

internal static partial class Interop
{
    // Deprecated since API13
    internal static partial class IoTConnectivity
    {
        internal static partial class Common
        {
            internal enum DataType
            {
                None = 0,
                Int,
                Bool,
                Double,
                String,
                ByteStr,
                Null,
                List,
                Attributes
            }

            internal static partial class ResourceTypes
            {
                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                [return: MarshalAs(UnmanagedType.U1)] internal delegate bool ForeachCallback(string type, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_types_create")]
                internal static partial int Create(out IntPtr types);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_types_destroy")]
                internal static partial void Destroy(IntPtr types);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_types_add", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Add(IntPtr types, string type);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_types_remove", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Remove(IntPtr types, string type);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_types_foreach")]
                internal static partial int Foreach(IntPtr types, ForeachCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_types_clone")]
                internal static partial int Clone(IntPtr src, out IntPtr dest);
            }

            internal static partial class ResourceInterfaces
            {
                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                [return: MarshalAs(UnmanagedType.U1)] internal delegate bool ForeachCallback(string iface, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_interfaces_create")]
                internal static partial int Create(out IntPtr ifaces);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_interfaces_destroy")]
                internal static partial void Destroy(IntPtr ifaces);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_interfaces_add", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Add(IntPtr ifaces, string iface);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_interfaces_remove", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Remove(IntPtr ifaces, string iface);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_interfaces_foreach")]
                internal static partial int Foreach(IntPtr ifaces, ForeachCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_interfaces_clone")]
                internal static partial int Clone(IntPtr src, out IntPtr dest);
            }

            internal static partial class Attributes
            {
                [return: MarshalAs(UnmanagedType.U1)] internal delegate bool AttributesCallback(IntPtr attributes, string key, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_create")]
                internal static partial int Create(out IntPtr attributes);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_destroy")]
                internal static partial void Destroy(IntPtr attributes);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_clone")]
                internal static partial int Clone(IntPtr attributes, out IntPtr attributes_clone);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_add_int", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int AddInt(IntPtr attributes, string key, int val);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_add_bool", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int AddBool(IntPtr attributes, string key, [MarshalAs(UnmanagedType.U1)] bool val);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_add_double", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int AddDouble(IntPtr attributes, string key, double val);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_add_str", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int AddStr(IntPtr attributes, string key, string val);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_add_byte_str", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int AddByteStr(IntPtr attributes, string key, byte[] val, int len);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_add_list", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int AddList(IntPtr attributes, string key, IntPtr list);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_add_attributes", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int AddAttributes(IntPtr dest, string key, IntPtr src);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_add_null", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int AddNull(IntPtr attributes, string key);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_get_int", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetInt(IntPtr attributes, string key, out int val);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_get_bool", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetBool(IntPtr attributes, string key, [MarshalAs(UnmanagedType.U1)] out bool val);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_get_double", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetDouble(IntPtr attributes, string key, out double val);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_get_str", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetStr(IntPtr attributes, string key, out IntPtr val);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_get_byte_str", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetByteStr(IntPtr attributes, string key, out IntPtr value, out int size);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_get_list", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetList(IntPtr attributes, string key, out IntPtr list);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_get_attributes", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetAttributes(IntPtr src, string key, out IntPtr dest);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_is_null", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int IsNull(IntPtr attributes, string key, [MarshalAs(UnmanagedType.U1)] out bool isNull);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_remove", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Remove(IntPtr attributes, string key);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_get_type", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetType(IntPtr attributes, string key, out DataType type);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_foreach")]
                internal static partial int Foreach(IntPtr attributes, AttributesCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_attributes_get_keys_count")]
                internal static partial int GetKeysCount(IntPtr attributes, out int count);
            }

            internal static partial class Query
            {
                [return: MarshalAs(UnmanagedType.U1)] internal delegate bool QueryCallback(string key, string value, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_query_create")]
                internal static partial int Create(out IntPtr query);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_query_destroy")]
                internal static partial void Destroy(IntPtr query);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_query_get_resource_type")]
                internal static partial int GetResourceType(IntPtr query, out IntPtr resourceType);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_query_get_interface")]
                internal static partial int GetInterface(IntPtr query, out IntPtr resourceInterface);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_query_set_resource_type", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int SetResourceType(IntPtr query, string resourceType);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_query_set_interface", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int SetInterface(IntPtr query, string resourceInterface);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_query_add", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Add(IntPtr query, string key, string value);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_query_remove", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Remove(IntPtr query, string key);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_query_lookup", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Lookup(IntPtr query, string key, out IntPtr data);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_query_foreach")]
                internal static partial int Foreach(IntPtr query, QueryCallback cb, IntPtr userData);
            }

            internal static partial class Representation
            {
                [return: MarshalAs(UnmanagedType.U1)] internal delegate bool RepresentationChildrenCallback(IntPtr child, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_representation_create")]
                internal static partial int Create(out IntPtr repr);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_representation_destroy")]
                internal static partial void Destroy(IntPtr repr);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_representation_clone")]
                internal static partial int Clone(IntPtr src, out IntPtr dest);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_representation_set_uri_path", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int SetUriPath(IntPtr repr, string uriPath);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_representation_get_uri_path")]
                internal static partial int GetUriPath(IntPtr repr, out IntPtr uriPath);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_representation_set_resource_types")]
                internal static partial int SetResourceTypes(IntPtr repr, IntPtr types);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_representation_get_resource_types")]
                internal static partial int GetResourceTypes(IntPtr repr, out IntPtr types);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_representation_set_resource_interfaces")]
                internal static partial int SetResourceInterfaces(IntPtr repr, IntPtr ifaces);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_representation_get_resource_interfaces")]
                internal static partial int GetResourceInterfaces(IntPtr repr, out IntPtr ifaces);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_representation_set_attributes")]
                internal static partial int SetAttributes(IntPtr repr, IntPtr attribs);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_representation_get_attributes")]
                internal static partial int GetAttributes(IntPtr repr, out IntPtr attribs);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_representation_add_child")]
                internal static partial int AddChild(IntPtr parent, IntPtr child);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_representation_remove_child")]
                internal static partial int RemoveChild(IntPtr parent, IntPtr child);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_representation_foreach_children")]
                internal static partial int ForeachChildren(IntPtr parent, RepresentationChildrenCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_representation_get_children_count")]
                internal static partial int GetChildrenCount(IntPtr parent, out int count);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_representation_get_nth_child")]
                internal static partial int GetNthChild(IntPtr parent, int pos, out IntPtr child);
            }

            internal static partial class Options
            {
                [return: MarshalAs(UnmanagedType.U1)] internal delegate bool OptionsCallback(ushort id, string data, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_options_create")]
                internal static partial int Create(out IntPtr options);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_options_destroy")]
                internal static partial void Destroy(IntPtr options);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_options_add", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Add(IntPtr options, ushort id, string data);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_options_remove")]
                internal static partial int Remove(IntPtr options, ushort id);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_options_lookup")]
                internal static partial int Lookup(IntPtr options, ushort id, out IntPtr data);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_options_foreach")]
                internal static partial int ForEach(IntPtr options, OptionsCallback cb, IntPtr userData);
            }

            internal static partial class List
            {
                [return: MarshalAs(UnmanagedType.U1)] internal delegate bool IntCallback(int pos, int value, IntPtr userData);

                [return: MarshalAs(UnmanagedType.U1)] internal delegate bool BoolCallback(int pos, [MarshalAs(UnmanagedType.U1)] bool value, IntPtr userData);

                [return: MarshalAs(UnmanagedType.U1)] internal delegate bool DoubleCallback(int pos, double value, IntPtr userData);

                [return: MarshalAs(UnmanagedType.U1)] internal delegate bool ByteStrCallback(int pos, byte[] value, int len, IntPtr userData);

                [return: MarshalAs(UnmanagedType.U1)] internal delegate bool StrCallback(int pos, string value, IntPtr userData);

                [return: MarshalAs(UnmanagedType.U1)] internal delegate bool ListCallback(int pos, IntPtr value, IntPtr userData);

                [return: MarshalAs(UnmanagedType.U1)] internal delegate bool AttribsCallback(int pos, IntPtr value, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_create")]
                internal static partial int Create(DataType type, out IntPtr list);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_destroy")]
                internal static partial void Destroy(IntPtr list);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_add_int")]
                internal static partial int AddInt(IntPtr list, int val, int pos);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_add_bool")]
                internal static partial int AddBool(IntPtr list, [MarshalAs(UnmanagedType.U1)] bool val, int pos);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_add_double")]
                internal static partial int AddDouble(IntPtr list, double val, int pos);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_add_str", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int AddStr(IntPtr list, string val, int pos);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_add_byte_str")]
                internal static partial int AddByteStr(IntPtr list, byte[] val, int len, int pos);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_add_list")]
                internal static partial int AddList(IntPtr list, IntPtr val, int pos);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_add_attributes")]
                internal static partial int AddAttributes(IntPtr list, IntPtr val, int pos);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_get_nth_int")]
                internal static partial int GetNthInt(IntPtr list, int pos, out int val);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_get_nth_bool")]
                internal static partial int GetNthBool(IntPtr list, int pos, [MarshalAs(UnmanagedType.U1)] out bool val);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_get_nth_double")]
                internal static partial int GetNthDouble(IntPtr list, int pos, out double val);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_get_nth_str")]
                internal static partial int GetNthStr(IntPtr list, int pos, out IntPtr val);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_get_nth_byte_str")]
                internal static partial int GetNthByteStr(IntPtr list, int pos, out IntPtr val, out int len);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_get_nth_list")]
                internal static partial int GetNthList(IntPtr src, int pos, out IntPtr dest);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_get_nth_attributes")]
                internal static partial int GetNthAttributes(IntPtr list, int pos, out IntPtr attribs);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_remove_nth")]
                internal static partial int RemoveNth(IntPtr list, int pos);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_get_type")]
                internal static partial int GetType(IntPtr list, out int type);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_get_length")]
                internal static partial int GetLength(IntPtr list, out int length);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_foreach_int")]
                internal static partial int ForeachInt(IntPtr list, IntCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_foreach_bool")]
                internal static partial int ForeachBool(IntPtr list, BoolCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_foreach_double")]
                internal static partial int ForeachDouble(IntPtr list, DoubleCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_foreach_byte_str")]
                internal static partial int ForeachByteStr(IntPtr list, ByteStrCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_foreach_str")]
                internal static partial int ForeachStr(IntPtr list, StrCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_foreach_list")]
                internal static partial int ForeachList(IntPtr list, ListCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_list_foreach_attributes")]
                internal static partial int ForeachAttributes(IntPtr list, AttribsCallback cb, IntPtr userData);
            }
        }
    }
}





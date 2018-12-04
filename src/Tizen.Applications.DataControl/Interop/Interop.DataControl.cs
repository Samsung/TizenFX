/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Text;
using Tizen.Applications;
using Tizen;
using Tizen.Applications.DataControl;

internal static partial class Interop
{
    internal static partial class DataControl
    {

        internal enum NativeResultType : int
        {
            Success = Tizen.Internals.Errors.ErrorCode.None,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            MaxExceed = -0x01190000 | 0x01,
        }

        internal sealed class SafeBulkDataHandle : SafeHandle
        {
            internal SafeBulkDataHandle()
                : base(IntPtr.Zero, true)
            {
            }

            internal SafeBulkDataHandle(IntPtr existingHandle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
            {
                SetHandle(existingHandle);
            }

            public override bool IsInvalid
            {
                get { return this.handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                DataControl.BulkFree(this.handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }

        internal sealed class SafeBulkResultDataHandle : SafeHandle
        {
            internal SafeBulkResultDataHandle()
                : base(IntPtr.Zero, true)
            {
            }

            internal SafeBulkResultDataHandle(IntPtr existingHandle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
            {
                SetHandle(existingHandle);
            }

            public override bool IsInvalid
            {
                get { return this.handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                DataControl.BulkResultFree(this.handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }

        internal sealed class SafeCursorHandle : SafeHandle
        {
            internal SafeCursorHandle()
                : base(IntPtr.Zero, true)
            {
            }

            internal SafeCursorHandle(IntPtr existingHandle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
            {
                SetHandle(existingHandle);
            }

            public override bool IsInvalid
            {
                get { return this.handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }

        internal sealed class SafeDataControlHandle : SafeHandle
        {
            internal SafeDataControlHandle()
                : base(IntPtr.Zero, true)
            {
            }

            internal SafeDataControlHandle(IntPtr existingHandle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
            {
                SetHandle(existingHandle);
            }

            public override bool IsInvalid
            {
                get { return this.handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                DataControl.Destroy(this.handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_create")]
        internal static extern ResultType DataControlCreate(out SafeDataControlHandle handle);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_destroy")]
        internal static extern ResultType Destroy(IntPtr handle);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_get_provider_id")]
        internal static extern ResultType DataControlGetProviderId(SafeDataControlHandle handle, out string providerId);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_set_provider_id")]
        internal static extern ResultType DataControlSetProviderId(SafeDataControlHandle handle, string providerId);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_set_data_id")]
        internal static extern ResultType DataControlSetDataId(SafeDataControlHandle handle, string dataId);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_get_data_id")]
        internal static extern ResultType DataControlGetDataId(SafeDataControlHandle handle, out string dataId);

        internal delegate void MapGetResponseCallback(int requestID,
            IntPtr provider, IntPtr resultValueList, int resultValueCount, bool providerResult, string error, IntPtr userData);
        internal delegate void MapSetResponseCallback(int requestID,
            IntPtr provider, bool providerResult, string error, IntPtr userData);
        internal delegate void MapAddResponseCallback(int requestID,
            IntPtr provider, bool providerResult, string error, IntPtr userData);
        internal delegate void MapRemoveResponseCallback(int requestID,
            IntPtr provider, bool providerResult, string error, IntPtr userData);
        internal delegate void MapBulkAddResponseCallback(int requestID,
            IntPtr provider, IntPtr bulkResults, bool providerResult, string error, IntPtr userData);

        [StructLayoutAttribute(LayoutKind.Sequential)]
        internal struct MapResponseCallbacks
        {
            public MapGetResponseCallback Get;
            public MapSetResponseCallback Set;
            public MapAddResponseCallback Add;
            public MapRemoveResponseCallback Remove;
        }

        internal delegate void SqlSelectResponseCallback(int requestID,
            IntPtr provider, IntPtr cursor, bool providerResult, string error, IntPtr userData);
        internal delegate void SqlInsertResponseCallback(int requestID,
            IntPtr provider, long inserted_row_id, bool providerResult, string error, IntPtr userData);
        internal delegate void SqlUpdateResponseCallback(int requestID,
            IntPtr provider, bool providerResult, string error, IntPtr userData);
        internal delegate void SqlDeleteResponseCallback(int requestID,
            IntPtr provider, bool providerResult, string error, IntPtr userData);
        internal delegate void SqlBulkInsertResponseCallback(int requestID,
            IntPtr provider, IntPtr bulk_results, bool providerResult, string error, IntPtr userData);

        [StructLayoutAttribute(LayoutKind.Sequential)]
        internal struct SqlResponseCallbacks
        {
            public SqlSelectResponseCallback Select;
            public SqlInsertResponseCallback Insert;
            public SqlUpdateResponseCallback Update;
            public SqlDeleteResponseCallback Delete;
        }

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_map_register_response_cb")]
        internal static extern ResultType RegisterMapResponse(SafeDataControlHandle provider, ref MapResponseCallbacks callback, IntPtr userData);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_map_unregister_response_cb")]
        internal static extern ResultType UnregisterMapResponse(SafeDataControlHandle provider);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_map_register_add_bulk_data_response_cb")]
        internal static extern ResultType RegisterMapBulkResponseCallback(SafeDataControlHandle provider, MapBulkAddResponseCallback callback, IntPtr userData);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_map_unregister_add_bulk_data_response_cb")]
        internal static extern ResultType UnregisterMapBulkResponseCallback(SafeDataControlHandle provider);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_register_response_cb")]
        internal static extern ResultType RegisterSqlResponseCallback(SafeDataControlHandle provider, ref SqlResponseCallbacks callback, IntPtr userData);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_unregister_response_cb")]
        internal static extern ResultType UnregisterSqlResponseCallback(SafeDataControlHandle provider);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_register_insert_bulk_data_response_cb")]
        internal static extern ResultType RegisterSqlBulkResponseCallback(SafeDataControlHandle provider, SqlBulkInsertResponseCallback callback, IntPtr userData);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_unregister_insert_bulk_data_response_cb")]
        internal static extern ResultType UnregisterSqlBulkResponseCallback(SafeDataControlHandle provider);

        internal delegate void MapGetRequestCallback(int requestID,
            IntPtr provider, string key, IntPtr userData);
        internal delegate void MapSetRequestCallback(int requestID,
            IntPtr provider, string key, string oldValue, string newValue, IntPtr userData);
        internal delegate void MapAddRequestCallback(int requestID,
            IntPtr provider, string key, string value, IntPtr userData);
        internal delegate void MapRemoveRequestCallback(int requestID,
            IntPtr provider, string key, string value, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MapBulkAddRequestCallback(int requestID,
            IntPtr provider, IntPtr bulkData, IntPtr userData);

        [StructLayoutAttribute(LayoutKind.Sequential)]
        internal struct MapRequestCallbacks
        {
            public MapGetRequestCallback Get;
            public MapSetRequestCallback Set;
            public MapAddRequestCallback Add;
            public MapRemoveRequestCallback Remove;
        }

        internal delegate void SqlInsertRequestCallback(int requestID,
            IntPtr provider, IntPtr insertData, IntPtr userData);
        internal delegate void SqlSelectRequestCallback(int requestID,
            IntPtr provider, IntPtr columnList, int columnCount, string where, string order, IntPtr userData);
        internal delegate void SqlUpdateRequestCallback(int requestID,
            IntPtr provider, IntPtr updateData, string where, IntPtr userData);
        internal delegate void SqlDeleteRequestCallback(int requestID,
            IntPtr provider, string where, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SqlBulkInsertRequestCallback(int requestID,
            IntPtr provider, IntPtr bulk_data, IntPtr userData);

        [StructLayoutAttribute(LayoutKind.Sequential)]
        internal struct SqlRequestCallbacks
        {
            public SqlInsertRequestCallback Insert;
            public SqlSelectRequestCallback Select;
            public SqlUpdateRequestCallback Update;
            public SqlDeleteRequestCallback Delete;
        }

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_map_register_cb")]
        internal static extern ResultType RegisterMapRequest(ref MapRequestCallbacks callback, IntPtr userData);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_sql_register_cb")]
        internal static extern ResultType RegisterSqlRequest(ref SqlRequestCallbacks callback, IntPtr userData);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_sql_register_insert_bulk_data_request_cb")]
        internal static extern ResultType RegisterSqlBulkRequest(SqlBulkInsertRequestCallback callback, IntPtr userData);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_sql_unregister_insert_bulk_data_request_cb")]
        internal static extern ResultType UnregisterSqlBulkRequest();

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_map_register_add_bulk_data_request_cb")]
        internal static extern ResultType RegisterMapBulkRequest(MapBulkAddRequestCallback callback, IntPtr userData);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_map_unregister_add_bulk_data_request_cb")]
        internal static extern ResultType UnregisterMapBulkRequest();

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_send_map_result")]
        internal static extern ResultType SendMapResult(int requestID);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_send_map_get_value_result")]
        internal static extern ResultType SendMapGetResult(int requestID, string[] valueList, int valueCount);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_send_insert_result")]
        internal static extern ResultType SendInsertResult(int requestID, long rowId);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_send_update_result")]
        internal static extern ResultType SendUpdateResult(int requestID);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_send_delete_result")]
        internal static extern ResultType SendDeleteResult(int requestID);

        [DllImport(Libraries.DataControl, EntryPoint = "datacontrol_provider_send_select_result_without_data")]
        internal static extern ResultType SendSelectResult(int requestID, out int fd);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_send_error")]
        internal static extern ResultType SendError(int requestID, string error);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_get_client_appid")]
        internal static extern ResultType GetClientAppId(int requestID, out string clientAppId);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_insert")]
        internal static extern ResultType Insert(SafeDataControlHandle provider, SafeBundleHandle insertData, out int requestId);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_select_with_page")]
        internal static extern ResultType Select(SafeDataControlHandle provider, string[] columnList, int columnCount, string where, string order, int pageNumber,
            int countPerPage, out int requestID);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_delete")]
        internal static extern ResultType Delete(SafeDataControlHandle provider, string where, out int requestID);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_update")]
        internal static extern ResultType Update(SafeDataControlHandle provider, SafeBundleHandle updatetData, string where, out int requestID);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_insert_bulk_data")]
        internal static extern ResultType BulkInsert(SafeDataControlHandle provider, SafeBulkDataHandle insertData, out int requestID);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_map_add")]
        internal static extern ResultType MapAdd(SafeDataControlHandle provider, string key, string value, out int requestId);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_map_set")]
        internal static extern ResultType MapSet(SafeDataControlHandle provider, string key, string oldValue, string newValue, out int requestId);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_map_remove")]
        internal static extern ResultType MapRemove(SafeDataControlHandle provider, string key, string value, out int requestId);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_map_get_with_page")]
        internal static extern ResultType MapGet(SafeDataControlHandle provider, string key, out int requestId, int pageNumber,
            int countPerPage);
        [DllImport(Libraries.DataControl, EntryPoint = "data_control_map_add_bulk_data")]
        internal static extern ResultType BulkAdd(SafeDataControlHandle provider, SafeBulkDataHandle insertData, out int requestID);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_create_insert_statement")]
        internal static extern string CreateInsertStatement(SafeDataControlHandle provider, SafeBundleHandle insertData);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_create_delete_statement")]
        internal static extern string CreateDeleteStatement(SafeDataControlHandle provider, string where);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_create_update_statement")]
        internal static extern string CreateUpdateStatement(SafeDataControlHandle provider, SafeBundleHandle updateData, string where);

        [DllImport(Libraries.DataControl, EntryPoint = "datacontrol_provider_get_select_page_info")]
        internal static extern ResultType GetSelectPageInfo(int requestId, out int pageNum, out int countPerPage);

        [DllImport(Libraries.DataControl, EntryPoint = "datacontrol_provider_write_socket")]
        internal static extern unsafe ResultType WriteSelectResult(int socketFd, byte* buffer, uint nbytes, out uint bytesWrite);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_send_data_change_noti_by_data_id")]
        internal static extern ResultType SendDataChange(string dataId, ChangeType type, SafeBundleHandle data);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_step_next")]
        internal static extern ResultType Next(SafeCursorHandle cursor);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_step_last")]
        internal static extern ResultType Last(SafeCursorHandle cursor);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_step_first")]
        internal static extern ResultType First(SafeCursorHandle cursor);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_step_previous")]
        internal static extern ResultType Prev(SafeCursorHandle cursor);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_get_column_count")]
        internal static extern int GetColumnCount(SafeCursorHandle cursor);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_get_column_name")]
        internal static extern ResultType GetColumnName(SafeCursorHandle cursor, int idx, StringBuilder name);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_get_column_item_size")]
        internal static extern int GetItemSize(SafeCursorHandle cursor, int idx);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_get_column_item_type")]
        internal static extern ResultType GetItemType(SafeCursorHandle cursor, int idx, out int type);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_get_blob_data")]
        internal static extern ResultType GetBlob(SafeCursorHandle cursor, int idx, byte[] buffer, int size);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_get_int_data")]
        internal static extern ResultType GetInt(SafeCursorHandle cursor, int idx, out int data);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_get_int64_data")]
        internal static extern ResultType GetInt64(SafeCursorHandle cursor, int idx, out long data);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_get_double_data")]
        internal static extern ResultType Getdouble(SafeCursorHandle cursor, int idx, out double data);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_sql_get_text_data")]
        internal static extern unsafe ResultType GetText(SafeCursorHandle cursor, int idx, byte[] data);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_bulk_data_create")]
        internal static extern ResultType BulkCreate(out SafeBulkDataHandle handle);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_bulk_data_add")]
        internal static extern ResultType BulkAdd(SafeBulkDataHandle handle, SafeBundleHandle data);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_bulk_data_get_count")]
        internal static extern ResultType BulkGetCount(SafeBulkDataHandle handle, out int count);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_bulk_data_destroy")]
        internal static extern ResultType BulkFree(IntPtr handle);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_bulk_data_get_data")]
        internal static extern ResultType BulkGetData(SafeBulkDataHandle handle, int idx, out IntPtr data);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_bulk_result_data_create")]
        internal static extern ResultType BulkResultCreate(out SafeBulkResultDataHandle handle);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_bulk_result_data_add")]
        internal static extern ResultType BulkResultAdd(SafeBulkResultDataHandle handle, SafeBundleHandle data, int result);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_bulk_result_data_get_count")]
        internal static extern ResultType BulkResultGetCount(SafeBulkResultDataHandle handle, out int count);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_bulk_result_data_get_result_data")]
        internal static extern ResultType BulkResultGetData(SafeBulkResultDataHandle handle, int idx, out IntPtr data, out int result);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_bulk_result_data_get_result_data")]
        internal static extern ResultType BulkResultGetResult(SafeBulkResultDataHandle handle, int idx, out IntPtr data, out int result);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_bulk_result_data_destroy")]
        internal static extern ResultType BulkResultFree(IntPtr handle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void AddCallbackResultCallback(IntPtr handle, ResultType type, int callbackID, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DataChangeCallback(IntPtr handle, ChangeType type, IntPtr data, IntPtr userData);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_add_data_change_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ResultType AddDataChangeCallback(SafeDataControlHandle provider, DataChangeCallback callback,
            IntPtr userData, AddCallbackResultCallback resultCallback, IntPtr resultCbUserData, out int callbackID);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_remove_data_change_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ResultType RemoveDataChangeCallback(SafeDataControlHandle provider, int callbackID);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool DataChangeConsumerFilterCb(IntPtr handle, string consumerAppid, IntPtr userData);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_add_data_change_consumer_filter_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ResultType AddDataChangeConsumerFilterCallback(DataChangeConsumerFilterCb callback,
            IntPtr userData,
            out int callbackID);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_remove_data_change_consumer_filter_cb")]
        internal static extern int RemoveDataChangeConsumerFilterCallback(int callbackID);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_send_bulk_insert_result")]
        internal static extern ResultType SendBulkInsertResult(int requestId, SafeBulkResultDataHandle result);

        [DllImport(Libraries.DataControl, EntryPoint = "data_control_provider_send_map_bulk_add_result")]
        internal static extern ResultType SendMapBulkAddResult(int requestId, SafeBulkResultDataHandle result);

        internal static class UnsafeCode
        {
            internal static unsafe ResultType WriteResult(int socketFd, byte[] value, int nbytes, out uint bytesWrite)
            {
                fixed (byte* pointer = value)
                {
                    return WriteSelectResult(socketFd, pointer, (uint)nbytes, out bytesWrite);
                }
            }
        }

    }
}

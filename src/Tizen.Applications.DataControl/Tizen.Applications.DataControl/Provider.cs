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
using System.IO;
using System.Text;
using System.Collections.Generic;
using Tizen.Applications.DataControl;
using System.Runtime.InteropServices;
using System.Threading;

namespace Tizen.Applications.DataControl
{
    /// <summary>
    /// Represents the Provider class for the DataControl provider application.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract class Provider : IDisposable
    {
        private const string LogTag = "Tizen.Applications.DataControl";
        private static IDictionary<string, Provider> _providerDict = new Dictionary<string, Provider>();
        private static Interop.DataControl.SqlRequestCallbacks _sqlRequestCallbacks;
        private static Interop.DataControl.MapRequestCallbacks _mapRequestCallbacks;
        private IntPtr _nativeHandle;
        private static Interop.DataControl.DataChangeConsumerFilterCb _filterCallback;
        private static int _filterCallbackID;
        private static bool _filterRegistered;
        private static Interop.DataControl.SqlBulkInsertRequestCallback _sqlBulkCallback;
        private static Interop.DataControl.MapBulkAddRequestCallback _mapBulkCallback;
        private static Mutex _lock = new Mutex();
        private bool _disposed = false;
        private bool _isRunning = false;
        private static string _currentClientAppId;

        /// <summary>
        /// Gets the data ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string DataID
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the current client appid.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string CurrentClientAppId
        {
            get
            {
                return _currentClientAppId;
            }
            set
            {
                _currentClientAppId = value;
            }
        }

        private static bool DataChangeListenFilter(IntPtr handlePtr, string consumerAppid, IntPtr userData)
        {
            Provider provider;
            DataChangeListenResult result;

            provider = GetProvider(handlePtr);
            if (provider == null)
            {
                Log.Error(LogTag, "Provider not exist ");
                return false;
            }

            result = provider.OnDataChangeListenRequest(consumerAppid);
            if (result == null || result.Result != ResultType.Success)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private enum OperationType : short
        {
            Select,
            Update,
            Insert,
            Delete
        }

        private static string CreateSelectQuery(IntPtr handlePtr, string[] columnList, int columnCount, string where, string order, int pageNum, int countPerPage)
        {
            Interop.DataControl.SafeDataControlHandle handle = new Interop.DataControl.SafeDataControlHandle(handlePtr, false);
            string query = "SELECT";
            string dataId;
            if (columnList == null)
            {
                query += " * ";
            }
            else
            {
                for (int i = 0; i < columnCount; i++)
                {
                    if (i != 0)
                    {
                        query += ",";
                    }

                    query += " " + columnList[i];
                }
            }

            Interop.DataControl.DataControlGetDataId(handle, out dataId);
            query += " FROM " + dataId;
            if (where != null)
            {
                query += " WHERE " + where;
            }

            if (order != null)
            {
                query += " ORDER BY " + order;
            }

            if (pageNum != 0)
            {
                query += " LIMIT " + countPerPage + " OFFSET " + (countPerPage * (pageNum - 1));
            }
            handle.Dispose();
            return query;
        }

        static internal ResultType UpdateCurrentClient(int requestId)
        {
            string clientAppId;
            ResultType ret = Interop.DataControl.GetClientAppId(requestId, out clientAppId);
            if (ret != ResultType.Success)
            {
                Log.Error(LogTag, "Get client id fail " + ret.ToString());
                return ResultType.IoError;
            }
            _currentClientAppId = clientAppId;
            return ResultType.Success;
        }

        private static void InsertRequest(int requestId, IntPtr handlePtr, IntPtr insertData, IntPtr userData)
        {
            Provider provider;
            InsertResult result;
            SafeBundleHandle sbh = new SafeBundleHandle(insertData, false);
            string query = GetQuery(handlePtr, sbh, null, OperationType.Update);
            ResultType ret;

            provider = GetProvider(handlePtr);
            if (provider == null)
            {
                Log.Error(LogTag, "Provider not exist ");
                return;
            }

            ret = UpdateCurrentClient(requestId);
            if (ret != ResultType.Success)
                return;

            result = provider.OnInsert(query, new Bundle(sbh));
            if (result != null)
            {
                if (result.Result)
                {
                    ret = Interop.DataControl.SendInsertResult(requestId, result.RowID);
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendInsertResult fail " + ret.ToString());
                    }
                }
                else
                {
                    ret = Interop.DataControl.SendError(requestId, result.Result.ToString());
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendError fail " + ret.ToString());
                    }
                }
            }
            else
            {
                Log.Info(LogTag, $"InsertResult is null : {requestId.ToString()}");
            }
        }

        private static void BulkInsertRequest(int requestId, IntPtr handlePtr, IntPtr bulk_data, IntPtr userData)
        {
            Provider provider;
            BulkInsertResult result;
            BulkData bulkData = new BulkData(new Interop.DataControl.SafeBulkDataHandle(bulk_data, false));
            Interop.DataControl.SafeBulkDataHandle sbdh = bulkData.SafeBulkDataHandle;
            IntPtr bundleHandel;
            ResultType ret;

            int count = bulkData.GetCount();
            List<string> queryList = new List<string>();

            for (int i = 0; i < count; i++)
            {
                Interop.DataControl.BulkGetData(sbdh, i, out bundleHandel);
                queryList.Add(GetQuery(handlePtr, new SafeBundleHandle(bundleHandel, false), null, OperationType.Insert));
            }

            provider = GetProvider(handlePtr);
            if (provider == null)
            {
                Log.Error(LogTag, "Provider not exist ");
                return;
            }

            ret = UpdateCurrentClient(requestId);
            if (ret != ResultType.Success)
                return;

            result = provider.OnBulkInsert(queryList, bulkData);
            if (result != null)
            {
                if (result.Result)
                {
                    ret = Interop.DataControl.SendBulkInsertResult(requestId, result.BulkResultData.SafeBulkDataHandle);
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendBulkInsertResult fail " + ret.ToString());
                    }
                }
                else
                {
                    ret = Interop.DataControl.SendError(requestId, result.Result.ToString());
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendError fail " + ret.ToString());
                    }
                }

                if (result.BulkResultData != null)
                {
                    result.BulkResultData.Dispose();
                }
            }
            else
            {
                Log.Info(LogTag, $"BulkInsertResult is null : {requestId.ToString()}");
            }
        }

        private static void SendNativeProtocol(int socketFd, ICursor cursor, int requestId)
        {
            uint write_len;
            int DATACONTROL_RESULT_NO_DATA = -1;
            int COLUMN_TYPE_NULL = 5;
            int column_count, i, rowcount, size = 0, total_len_of_column_names = 0;
            byte[] type_array, length_array, string_array, int_tmp, value_array = null;
            string txt;
            ResultType result;
            MemoryStream ms;

            if (cursor.Reset() == false)
            {
                Log.Error(LogTag, "Reset is failed  :  " + requestId.ToString());
                return;
            }

            if (cursor.GetRowCount() <= 0)
            {
                Log.Error(LogTag, "The DB does not have another row : " + requestId.ToString());
                int_tmp = BitConverter.GetBytes(DATACONTROL_RESULT_NO_DATA);
                result = (ResultType)Interop.DataControl.UnsafeCode.WriteResult(socketFd, int_tmp, int_tmp.Length, out write_len);
                return;
            }

            /* 1. column count */
            column_count = cursor.GetColumnCount();
            int_tmp = BitConverter.GetBytes(column_count);
            result = (ResultType)Interop.DataControl.UnsafeCode.WriteResult(socketFd, int_tmp, int_tmp.Length, out write_len);
            if (result != ResultType.Success)
            {
                Log.Error(LogTag, "Writing a column_count to a file descriptor is failed.");
                return;
            }

            Log.Info(LogTag, "Writing a column_count " + column_count.ToString());

            /* 2.column type x column_count */
            for (i = 0; i < column_count; i++)
            {
                type_array = BitConverter.GetBytes((int)cursor.GetColumnType(i));
                result = (ResultType)Interop.DataControl.UnsafeCode.WriteResult(socketFd, type_array, type_array.Length, out write_len);
                if (result != ResultType.Success)
                {
                    Log.Error(LogTag, "Writing a type to a file descriptor is failed.");
                    return;
                }

                Log.Info(LogTag, "Writing a column_type " + cursor.GetColumnType(i).ToString());
            }

            /* 3. column name x column_count */
            for (i = 0; i < column_count; i++)
            {
                Log.Info(LogTag, "Writing a name " + cursor.GetColumnName(i));

                total_len_of_column_names += cursor.GetColumnName(i).Length;
                string_array = Encoding.UTF8.GetBytes(cursor.GetColumnName(i));
                value_array = new byte[string_array.Length + 1];/*insert null */
                string_array.CopyTo(value_array, 0);
                length_array = BitConverter.GetBytes(value_array.Length);

                result = (ResultType)Interop.DataControl.UnsafeCode.WriteResult(socketFd, length_array, length_array.Length, out write_len);
                if (result != ResultType.Success)
                {
                    Log.Error(LogTag, "Writing a type to a file descriptor is failed.");
                    return;
                }

                result = (ResultType)Interop.DataControl.UnsafeCode.WriteResult(socketFd, value_array, value_array.Length, out write_len);
                if (result != ResultType.Success)
                {
                    Log.Error(LogTag, "Writing a type to a file descriptor is failed.");
                    return;
                }

            }

            /* 4. total length of column names */
            length_array = BitConverter.GetBytes(total_len_of_column_names);
            result = (ResultType)Interop.DataControl.UnsafeCode.WriteResult(socketFd, length_array, length_array.Length, out write_len);
            if (result != ResultType.Success)
            {
                Log.Error(LogTag, "Writing a total_len_of_column_names to a file descriptor is failed");
                return;
            }

            Log.Info(LogTag, "Writing  total length of column namese " + total_len_of_column_names.ToString());

            /* 5. row count */
            length_array = BitConverter.GetBytes(cursor.GetRowCount());
            Log.Error(LogTag, "=========================== select rowcount " + cursor.GetRowCount().ToString());
            result = (ResultType)Interop.DataControl.UnsafeCode.WriteResult(socketFd, length_array, length_array.Length, out write_len);
            if (result != ResultType.Success)
            {
                Log.Error(LogTag, "Writing a row count to a file descriptor is failed");
                return;
            }

            Log.Error(LogTag, "Writing a row count " + cursor.GetRowCount().ToString());

            rowcount = 0;
            do
            {
                ms = new MemoryStream();

                for (i = 0; i < column_count; i++)
                {
                    type_array = BitConverter.GetBytes((int)cursor.GetColumnType(i));
                    switch (cursor.GetColumnType(i))
                    {
                        case ColumnType.ColumnTypeInt:
                            value_array = BitConverter.GetBytes(cursor.GetInt64Value(i));
                            size = value_array.Length;
                            break;

                        case ColumnType.ColumnTypeDouble:
                            value_array = BitConverter.GetBytes(cursor.GetDoubleValue(i));
                            size = value_array.Length;
                            break;

                        case ColumnType.ColumnTypeString:
                            txt = cursor.GetStringValue(i);
                            if (txt == null)
                            {
                                type_array = BitConverter.GetBytes(COLUMN_TYPE_NULL);
                                size = 0;
                                break;
                            }

                            string_array = Encoding.UTF8.GetBytes(txt);
                            value_array = new byte[string_array.Length + 1];/*insert null */
                            string_array.CopyTo(value_array, 0);
                            size = value_array.Length;
                            break;

                        case ColumnType.ColumnTypeBlob:
                            int_tmp = cursor.GetBlobValue(i);
                            if (int_tmp == null)
                            {
                                type_array = BitConverter.GetBytes(COLUMN_TYPE_NULL);
                                size = 0;
                                break;
                            }

                            value_array = int_tmp;
                            size = value_array.Length;
                            break;
                    }

                    ms.Write(type_array, 0, type_array.Length);

                    length_array = BitConverter.GetBytes(size);
                    ms.Write(length_array, 0, length_array.Length);
                    if (size > 0)
                    {
                        ms.Write(value_array, 0, value_array.Length);
                    }
                }

                value_array = ms.ToArray();

                result = (ResultType)Interop.DataControl.UnsafeCode.WriteResult(socketFd, value_array, value_array.Length, out write_len);
                if (result != ResultType.Success)
                {
                    Log.Error(LogTag, "Writing a row to a file descriptor is failed");
                    ms.Dispose();
                    return;
                }

                ms.Dispose();
                Log.Info(LogTag, "row_count ~~~~ ", rowcount.ToString());

            }
            while (cursor.Next());
        }

        private static void SelectRequest(int requestId,
            IntPtr handlePtr, IntPtr columnList, int columnCount, string where, string order, IntPtr userData)
        {
            Provider provider;
            SelectResult result;
            int pageNum = 0;
            int countPerPage = 0;
            int MAX_WRITE_SIZE = 1024;  /* 1kbyte */
            string query = null;
            int socketFd, write_size, i;
            uint write_len;
            ResultType ret;
            string[] _columnList = new string[columnCount];
            byte[] buffer;

            unsafe
            {
                byte** _sbyte_columnList = (byte**)columnList;

                for (i = 0; i < columnCount; i++)
                {
                    _columnList[i] = Marshal.PtrToStringAnsi((IntPtr)_sbyte_columnList[i]);
                }
            }

            Interop.DataControl.GetSelectPageInfo(requestId, out pageNum, out countPerPage);
            query = CreateSelectQuery(handlePtr, _columnList, _columnList.Length, where, order, pageNum, countPerPage);
            provider = GetProvider(handlePtr);
            if (provider == null)
            {
                Log.Error(LogTag, "Provider not exist ");
                return;
            }

            ret = UpdateCurrentClient(requestId);
            if (ret != ResultType.Success)
                return;
            result = provider.OnSelect(query, where, _columnList, _columnList.Length, order, pageNum, countPerPage);
            if (result != null)
            {
                if (result.Result)
                {
                    Interop.DataControl.SendSelectResult(requestId, out socketFd);

                    MatrixCursor mc = result.ResultCursor as MatrixCursor;

                    if (mc == null)
                    {
                        SendNativeProtocol(socketFd, result.ResultCursor, requestId);
                    }
                    else
                    {
                        FileStream fs = mc.GetFileStream();
                        fs.Seek(0, SeekOrigin.Begin);

                        buffer = new byte[MAX_WRITE_SIZE];

                        do
                        {
                            write_size = fs.Read(buffer, 0, MAX_WRITE_SIZE);

                            if (write_size > 0)
                            {
                                ret = (ResultType)Interop.DataControl.UnsafeCode.WriteResult(socketFd, buffer, write_size, out write_len);
                                if (ret != ResultType.Success)
                                {
                                    Log.Error(LogTag, "Writing a row to a file descriptor is failed");
                                    mc.Dispose();
                                    return;
                                }
                            }
                        }
                        while (write_size > 0);
                        mc.Dispose();
                    }

                }
                else
                {
                    ret = Interop.DataControl.SendError(requestId, result.Result.ToString());
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendError fail " + ret.ToString());
                    }
                }
            }
            else
            {
                Log.Info(LogTag, $"SelectResult is null : {requestId.ToString()}");
            }
        }

        private static void UpdateRequest(int requestId,
            IntPtr handlePtr, IntPtr updateData, string where, IntPtr userData)
        {
            Provider provider;
            UpdateResult result;
            SafeBundleHandle sbh = new SafeBundleHandle(updateData, false);
            string query = GetQuery(handlePtr, sbh, where, OperationType.Update);
            ResultType ret;

            provider = GetProvider(handlePtr);
            if (provider == null)
            {
                Log.Error(LogTag, "Provider not exist ");
                return;
            }

            ret = UpdateCurrentClient(requestId);
            if (ret != ResultType.Success)
                return;
            result = provider.OnUpdate(query, where, new Bundle(sbh));
            if (result != null)
            {
                if (result.Result)
                {
                    ret = Interop.DataControl.SendUpdateResult(requestId);
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendUpdateResult fail " + ret.ToString());
                    }
                }
                else
                {
                    ret = Interop.DataControl.SendError(requestId, result.Result.ToString());
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendError fail " + ret.ToString());
                    }
                }
            }
            else
            {
                Log.Info(LogTag, $"UpdateResult is null : {requestId.ToString()}");
            }
        }

        private static void DeleteRequest(int requestId,
            IntPtr handlePtr, string where, IntPtr userData)
        {
            Provider provider;
            DeleteResult result;
            string query = GetQuery(handlePtr, null, where, OperationType.Delete);
            ResultType ret;

            provider = GetProvider(handlePtr);
            if (provider == null)
            {
                Log.Error(LogTag, "Provider not exist ");
                return;
            }

            ret = UpdateCurrentClient(requestId);
            if (ret != ResultType.Success)
                return;
            result = provider.OnDelete(query, where);
            if (result != null)
            {
                if (result.Result)
                {
                   ret = Interop.DataControl.SendDeleteResult(requestId);
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendDeleteResult fail " + ret.ToString());
                    }

                }
                else
                {
                    ret = Interop.DataControl.SendError(requestId, result.Result.ToString());
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendError fail " + ret.ToString());
                    }
                }
            }
            else
            {
                Log.Info(LogTag, $"DeleteResult is null : {requestId.ToString()}");
            }
        }

        private static void MapAddRequest(int requestId, IntPtr handlePtr, string key, string value, IntPtr userData)
        {
            Provider provider;
            MapAddResult result;
            ResultType ret;

            provider = GetProvider(handlePtr);
            if (provider == null)
            {
                Log.Error(LogTag, "Provider not exist");
                return;
            }

            ret = UpdateCurrentClient(requestId);
            if (ret != ResultType.Success)
                return;
            result = provider.OnMapAdd(key, value);
            if (result != null)
            {
                if (result.Result)
                {
                    ret = Interop.DataControl.SendMapResult(requestId);
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendMapResult fail " + ret.ToString());
                    }
                }
                else
                {
                    ret = Interop.DataControl.SendError(requestId, result.Result.ToString());
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendError fail " + ret.ToString());
                    }
                }
            }
            else
            {
                Log.Info(LogTag, $"MapAddResult is null : {requestId.ToString()}");
            }
        }

        private static void MapSetRequest(int requestId, IntPtr handlePtr, string key, string oldValue, string newValue, IntPtr userData)
        {
            Provider provider;
            MapSetResult result;
            ResultType ret;

            provider = GetProvider(handlePtr);
            if (provider == null)
            {
                Log.Error(LogTag, "Provider not exist");
                return;
            }

            ret = UpdateCurrentClient(requestId);
            if (ret != ResultType.Success)
                return;
            result = provider.OnMapSet(key, oldValue, newValue);
            if (result != null)
            {
                if (result.Result)
                {
                    ret = Interop.DataControl.SendMapResult(requestId);
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendMapResult fail " + ret.ToString());
                    }
                }
                else
                {
                    ret = Interop.DataControl.SendError(requestId, result.Result.ToString());
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendError fail " + ret.ToString());
                    }
                }
            }
            else
            {
                Log.Info(LogTag, $"MapSetResult is null : {requestId.ToString()}");
            }
        }

        private static void MapRemoveRequest(int requestId, IntPtr handlePtr, string key, string value, IntPtr userData)
        {
            Provider provider;
            MapRemoveResult result;
            ResultType ret;

            provider = GetProvider(handlePtr);
            if (provider == null)
            {
                Log.Error(LogTag, "Provider not exist");
                return;
            }

            ret = UpdateCurrentClient(requestId);
            if (ret != ResultType.Success)
                return;
            result = provider.OnMapRemove(key, value);
            if (result != null)
            {
                if (result.Result)
                {
                    ret = Interop.DataControl.SendMapResult(requestId);
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendMapResult fail " + ret.ToString());
                    }

                }
                else
                {
                    ret = Interop.DataControl.SendError(requestId, result.Result.ToString());
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendError fail " + ret.ToString());
                    }
                }
            }
            else
            {
                Log.Info(LogTag, $"MapRemoveRequest is null : {requestId.ToString()}");
            }
        }

        private static void MapGetRequest(int requestId, IntPtr handlePtr, string key, IntPtr userData)
        {
            Provider provider;
            MapGetResult result;
            ResultType ret;

            provider = GetProvider(handlePtr);
            if (provider == null)
            {
                Log.Error(LogTag, "Provider not exist");
                return;
            }

            ret = UpdateCurrentClient(requestId);
            if (ret != ResultType.Success)
                return;
            result = provider.OnMapGet(key);
            if (result != null)
            {
                if (result.Result)
                {
                    int valueCount = 0;
                    if (result.ValueList != null)
                        valueCount = result.ValueList.Length;
                    ret = Interop.DataControl.SendMapGetResult(requestId, result.ValueList, valueCount);
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendMapGetResult fail " + ret.ToString());
                    }

                }
                else
                {
                    ret = Interop.DataControl.SendError(requestId, result.Result.ToString());
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendError fail " + ret.ToString());
                    }
                }
            }
            else
            {
                Log.Info(LogTag, $"MapRemoveRequest is null : {requestId.ToString()}");
            }
        }

        private static void MapBulkAddRequest(int requestId, IntPtr handlePtr, IntPtr bulkDataPtr, IntPtr userData)
        {
            Provider provider;
            MapBulkAddResult result;
            BulkData bulkData = new BulkData(new Interop.DataControl.SafeBulkDataHandle(bulkDataPtr, false));
            Interop.DataControl.SafeBulkDataHandle sbdh = bulkData.SafeBulkDataHandle;
            IntPtr bundleHandel;
            int count = bulkData.GetCount();
            List<string> queryList = new List<string>();
            ResultType ret;

            for (int i = 0; i < count; i++)
            {
                Interop.DataControl.BulkGetData(sbdh, i, out bundleHandel);
                queryList.Add(GetQuery(handlePtr, new SafeBundleHandle(bundleHandel, false), null, OperationType.Insert));
            }

            ret = UpdateCurrentClient(requestId);
            if (ret != ResultType.Success)
                return;
            provider = GetProvider(handlePtr);
            if (provider == null)
            {
                Log.Error(LogTag, "Provider not exist");
                return;
            }

            result = provider.OnMapBulkAdd(bulkData);
            if (result != null)
            {
                if (result.Result)
                {
                    ret = Interop.DataControl.SendMapBulkAddResult(requestId, result.BulkResultData.SafeBulkDataHandle);
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendMapBulkAddResult fail " + ret.ToString());
                    }
                }
                else
                {
                    ret = Interop.DataControl.SendError(requestId, result.Result.ToString());
                    if (ret != ResultType.Success)
                    {
                        Log.Error(LogTag, "SendError fail " + ret.ToString());
                    }
                }

                if (result.BulkResultData != null)
                {
                    result.BulkResultData.Dispose();
                }
            }
            else
            {
                Log.Info(LogTag, $"MapBulkAddRequest is null : {requestId.ToString()}");
            }
        }

        private static string GetQuery(IntPtr handlePtr, SafeBundleHandle data, string where, OperationType type)
        {
            Interop.DataControl.SafeDataControlHandle handle = new Interop.DataControl.SafeDataControlHandle(handlePtr, false);
            string query = null;

            switch (type)
            {
                case OperationType.Select:
                    break;
                case OperationType.Update:
                    query = Interop.DataControl.CreateUpdateStatement(handle, data, where);
                    break;
                case OperationType.Delete:
                    query = Interop.DataControl.CreateDeleteStatement(handle, where);
                    break;
                case OperationType.Insert:
                    query = Interop.DataControl.CreateInsertStatement(handle, data);
                    break;
                default:
                    break;
            }
            handle.Dispose();

            return query;
        }

        private static Provider GetProvider(IntPtr handlePtr)
        {
            Interop.DataControl.SafeDataControlHandle handle = new Interop.DataControl.SafeDataControlHandle(handlePtr, false);
            Provider provider = null;
            string dataID;

            Interop.DataControl.DataControlGetDataId(handle, out dataID);
            if (dataID != null && _providerDict.ContainsKey(dataID))
            {
                provider = _providerDict[dataID];
                provider._nativeHandle = handlePtr;
                Log.Info(LogTag, "DataID :" + dataID + ", hash code : " + provider.GetHashCode().ToString());
            }
            handle.Dispose();

            return provider;
        }

        /// <summary>
        /// Sends a data change notification to consumer applications which have successfully added a data change listen.
        /// </summary>
        /// <param name="type">The changed data type.</param>
        /// <param name="changedData">Customized information about the changed data.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <since_tizen> 3 </since_tizen>
        public void SendDataChange(ChangeType type, Bundle changedData)
        {
            ResultType ret;

            if (changedData == null || changedData.SafeBundleHandle.IsInvalid)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "changedData");
            }

            if (this._nativeHandle == IntPtr.Zero)
            {
                return;
            }

            ret = Interop.DataControl.SendDataChange(this._nativeHandle, type, changedData.SafeBundleHandle);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false);
            }
        }

        /// <summary>
        /// Initializes the Provider class with the dataID.
        /// </summary>
        /// <param name="dataID">The DataControl Data ID.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <since_tizen> 3 </since_tizen>
        public Provider(string dataID)
        {
            if (string.IsNullOrEmpty(dataID))
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "dataID");
            }

            DataID = dataID;
        }

        /// <summary>
        /// Starts the Provider service.
        /// </summary>
        /// <remarks>Only one Provider service can be run for each process.</remarks>
        /// <exception cref="UnauthorizedAccessException">Thrown in case a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <since_tizen> 3 </since_tizen>
        public void Run()
        {
            ResultType ret;
            _lock.WaitOne();
            if (_providerDict.ContainsKey(DataID))
            {
                _lock.ReleaseMutex();
                ErrorFactory.ThrowException((ResultType)1, true, "The provider is already running");
                return;
            }

            if (_providerDict.Count == 0)
            {
                Log.Debug(LogTag, "Provider create");

                _sqlRequestCallbacks.Insert = new Interop.DataControl.SqlInsertRequestCallback(InsertRequest);
                _sqlRequestCallbacks.Select = new Interop.DataControl.SqlSelectRequestCallback(SelectRequest);
                _sqlRequestCallbacks.Update = new Interop.DataControl.SqlUpdateRequestCallback(UpdateRequest);
                _sqlRequestCallbacks.Delete = new Interop.DataControl.SqlDeleteRequestCallback(DeleteRequest);

                ret = Interop.DataControl.RegisterSqlRequest(ref _sqlRequestCallbacks, IntPtr.Zero);
                if (ret != ResultType.Success)
                {
                    _lock.ReleaseMutex();
                    ErrorFactory.ThrowException(ret, false);
                }

                _sqlBulkCallback = new Interop.DataControl.SqlBulkInsertRequestCallback(BulkInsertRequest);
                ret = Interop.DataControl.RegisterSqlBulkRequest(_sqlBulkCallback, IntPtr.Zero);
                if (ret != ResultType.Success)
                {
                    _lock.ReleaseMutex();
                    ErrorFactory.ThrowException(ret, false);
                }

                _mapRequestCallbacks.Add = new Interop.DataControl.MapAddRequestCallback(MapAddRequest);
                _mapRequestCallbacks.Remove = new Interop.DataControl.MapRemoveRequestCallback(MapRemoveRequest);
                _mapRequestCallbacks.Set = new Interop.DataControl.MapSetRequestCallback(MapSetRequest);
                _mapRequestCallbacks.Get = new Interop.DataControl.MapGetRequestCallback(MapGetRequest);
                ret = Interop.DataControl.RegisterMapRequest(ref _mapRequestCallbacks, IntPtr.Zero);
                if (ret != ResultType.Success)
                {
                    _lock.ReleaseMutex();
                    ErrorFactory.ThrowException(ret, false);
                }

                _mapBulkCallback = new Interop.DataControl.MapBulkAddRequestCallback(MapBulkAddRequest);
                ret = Interop.DataControl.RegisterMapBulkRequest(_mapBulkCallback, IntPtr.Zero);
                if (ret != ResultType.Success)
                {
                    _lock.ReleaseMutex();
                    ErrorFactory.ThrowException(ret, false);
                }

                if (_filterRegistered == false)
                {
                    if (_filterCallback == null)
                        _filterCallback = new Interop.DataControl.DataChangeConsumerFilterCb(DataChangeListenFilter);

                    ret = Interop.DataControl.AddDataChangeConsumerFilterCallback(
                         _filterCallback,
                         IntPtr.Zero, out _filterCallbackID);

                    if (ret != ResultType.Success)
                    {
                        _lock.ReleaseMutex();
                        ErrorFactory.ThrowException(ret, false);
                    }
                }

                _filterRegistered = true;
            }

            _providerDict.Add(DataID, this);
            Log.Info(LogTag, "DataID :" + DataID + ", hash code : " + this.GetHashCode().ToString());
            _isRunning = true;
            _lock.ReleaseMutex();
        }

        /// <summary>
        /// Stops the Provider service.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Stop()
        {
            if (_isRunning == true)
            {
                Log.Info(LogTag, "DataID :" + DataID);
                _isRunning = false;
                _providerDict.Remove(DataID);
            }
        }

        /// <summary>
        /// Destructor of the Provider class.
        /// </summary>
        ~Provider()
        {
            Dispose(false);
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the select request is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected abstract SelectResult OnSelect(string query, string where, string[] columList, int columnCount, string order, int pageNum, int countPerPage);

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the insert request is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected abstract InsertResult OnInsert(string query, Bundle insertData);

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the update request is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected abstract UpdateResult OnUpdate(string query, string where, Bundle updateData);

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the delete request is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected abstract DeleteResult OnDelete(string query, string where);

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the bulk insert request is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual BulkInsertResult OnBulkInsert(IEnumerable<string> query, BulkData bulkInsertData)
        {
            Log.Info(LogTag, "The OnBulkInsert is not implemented.");
            return null;
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the map get request is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual MapGetResult OnMapGet(string key)
        {
            Log.Info(LogTag, "The OnMapGet is not implemented.");
            return null;
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the map add request is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual MapAddResult OnMapAdd(string key, string value)
        {
            Log.Info(LogTag, "The OnMapAdd is not implemented.");
            return null;
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the update request is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual MapSetResult OnMapSet(string key, string oldValue, string newValue)
        {
            Log.Info(LogTag, "The OnMapSet is not implemented.");
            return null;
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the delete request is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual MapRemoveResult OnMapRemove(string key, string value)
        {
            Log.Info(LogTag, "The OnMapRemove is not implemented.");
            return null;
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the bulk add request is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual MapBulkAddResult OnMapBulkAdd(BulkData bulkAddData)
        {
            Log.Info(LogTag, "The OnMapBulkAdd is not implemented.");
            return null;
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the data change listen request is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual DataChangeListenResult OnDataChangeListenRequest(string requestAppID)
        {
            Log.Info(LogTag, "The OnDataChangeListenRequest is not implemented.");
            return null;
        }

        /// <summary>
        /// Releases unmanaged resources used by the Provider class specifying whether to perform a normal dispose operation.
        /// </summary>
        /// <param name="disposing">true for a normal dispose operation; false to finalize the handle.</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                Stop();
                _disposed = true;
            }
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Releases all the resources used by the Provider class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
        }
    }
}

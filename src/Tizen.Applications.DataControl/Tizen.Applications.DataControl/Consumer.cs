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
using System.Collections.Generic;
using Tizen.Applications.DataControl.Core;
using System.Threading;
using System.Runtime.InteropServices;

namespace Tizen.Applications.DataControl
{
    /// <summary>
    /// Represents the Consumer class for the DataControl consumer application.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract class Consumer : IDisposable
    {

        private Interop.DataControl.SafeDataControlHandle _handle;
        private string _dataID, _providerID;
        private int _changeCallbackID = 0;
        private const string LogTag = "Tizen.Applications.DataControl";
        private bool _disposed = false;
        private static Mutex _lock = new Mutex();
        private Interop.DataControl.DataChangeCallback _dataChangeCallback;
        private Interop.DataControl.AddCallbackResultCallback _addCallbackResultCallback;

        private static class CallbackManager
        {
            private static IDictionary<string, Interop.DataControl.MapResponseCallbacks> _mapResponseCallbacks = new Dictionary<string, Interop.DataControl.MapResponseCallbacks>();
            private static IDictionary<string, Interop.DataControl.MapBulkAddResponseCallback> _mapBulkResponseCallback = new Dictionary<string, Interop.DataControl.MapBulkAddResponseCallback>();
            private static IDictionary<string, Interop.DataControl.SqlResponseCallbacks> _sqlResponseCallbacks = new Dictionary<string, Interop.DataControl.SqlResponseCallbacks>();
            private static IDictionary<string, Interop.DataControl.SqlBulkInsertResponseCallback> _sqlBulkResponseCallback = new Dictionary<string, Interop.DataControl.SqlBulkInsertResponseCallback>();
            private static IDictionary<int, Consumer> _reqConsumerDictionary = new Dictionary<int, Consumer>();
            private static IDictionary<string, int> _reqProviderList = new Dictionary<string, int>();
            private static void InsertResponse(int reqId, IntPtr provider, long insertedRowId, bool providerResult, string error, IntPtr userData)
            {
                Log.Debug(LogTag, $"InsertResponse {reqId.ToString()}");
                if (!_reqConsumerDictionary.ContainsKey(reqId))
                {
                    Log.Error(LogTag, $"Invalid reqId {reqId.ToString()}");
                    return;
                }

                if (!providerResult)
                {
                    Log.Error(LogTag, $"reqId {reqId.ToString()}, error : {error}, rowID : {insertedRowId.ToString()}");
                }

                Consumer consumer = _reqConsumerDictionary[reqId];
                consumer.OnInsertResult(new InsertResult(insertedRowId, providerResult));
                _reqConsumerDictionary.Remove(reqId);
            }

            private static void BulkInsertResponse(int reqId, IntPtr provider, IntPtr bulkResults, bool providerResult, string error, IntPtr userData)
            {
                BulkResultData brd;
                Log.Debug(LogTag, $"BulkInsertResponse {reqId.ToString()}");
                if (!_reqConsumerDictionary.ContainsKey(reqId))
                {
                    Log.Error(LogTag, $"Invalid reqId {reqId.ToString()}");
                    return;
                }

                if (!providerResult)
                {
                    Log.Error(LogTag, $"reqId {reqId.ToString()}, error : {error}");
                }

                if (bulkResults != IntPtr.Zero)
                {
                    brd = new BulkResultData(new Interop.DataControl.SafeBulkResultDataHandle(bulkResults, false));
                }
                else
                {
                    brd = new BulkResultData();
                    Log.Error(LogTag, $"reqId {reqId.ToString()}, bulkResults is null");
                }

                Consumer consumer = _reqConsumerDictionary[reqId];
                consumer.OnBulkInsertResult(new BulkInsertResult(brd, providerResult));
                _reqConsumerDictionary.Remove(reqId);
            }

            private static void SelectResponse(int reqId, IntPtr provider, IntPtr cursor, bool providerResult, string error, IntPtr userData)
            {
                MatrixCursor dmc;
                Log.Debug(LogTag, $"SelectResponse {reqId.ToString()}");
                if (!_reqConsumerDictionary.ContainsKey(reqId))
                {
                    Log.Error(LogTag, $"Invalid reqId {reqId.ToString()}");
                    return;
                }

                if (!providerResult)
                {
                    Log.Error(LogTag, $"reqId {reqId.ToString()}, error : {error}");
                }

                if (cursor != IntPtr.Zero)
                {
                    try
                    {
                        dmc = CloneCursor(new CloneCursorCore(new Interop.DataControl.SafeCursorHandle(cursor, true)));
                    }
                    catch (Exception ex)
                    {
                        dmc = new MatrixCursor();
                        Log.Error(LogTag, $"reqId {reqId.ToString()},  {ex.ToString()}");
                    }
                }
                else
                {
                    dmc = new MatrixCursor();
                    Log.Error(LogTag, $"reqId {reqId.ToString()}, cursor is null");
                }
                Consumer consumer = _reqConsumerDictionary[reqId];
                consumer.OnSelectResult(new SelectResult(dmc, providerResult));
                _reqConsumerDictionary.Remove(reqId);
            }

            private static void UpdateResponse(int reqId, IntPtr provider, bool providerResult, string error, IntPtr userData)
            {
                if (!_reqConsumerDictionary.ContainsKey(reqId))
                {
                    Log.Error(LogTag, $"Invalid reqId {reqId.ToString()}");
                    return;
                }

                if (!providerResult)
                {
                    Log.Error(LogTag, $"reqId {reqId.ToString()}, error : {error}");
                }

                Consumer consumer = _reqConsumerDictionary[reqId];
                consumer.OnUpdateResult(new UpdateResult(providerResult));
                _reqConsumerDictionary.Remove(reqId);
            }

            private static void DeleteResponse(int reqId, IntPtr provider, bool providerResult, string error, IntPtr userData)
            {
                if (!_reqConsumerDictionary.ContainsKey(reqId))
                {
                    Log.Error(LogTag, $"Invalid reqId {reqId.ToString()}");
                    return;
                }

                if (!providerResult)
                {
                    Log.Error(LogTag, $"reqId {reqId.ToString()}, error : {error}");
                }

                Consumer consumer = _reqConsumerDictionary[reqId];
                consumer.OnDeleteResult(new DeleteResult(providerResult));
                _reqConsumerDictionary.Remove(reqId);
            }

            static void IntPtrToStringArray(IntPtr unmanagedArray, int size, out string[] managedArray)
            {
                managedArray = new string[size];
                IntPtr[] IntPtrArray = new IntPtr[size];
                Marshal.Copy(unmanagedArray, IntPtrArray, 0, size);
                for (int iterator = 0; iterator < size; iterator++)
                {
                    managedArray[iterator] = Marshal.PtrToStringAnsi(IntPtrArray[iterator]);
                }
            }

            private static void MapGetResponse(int reqId, IntPtr provider, IntPtr valueList, int valueCount, bool providerResult, string error, IntPtr userData)
            {
                MapGetResult mgr;
                Log.Debug(LogTag, $"MapGetResponse {reqId.ToString()}");
                if (!_reqConsumerDictionary.ContainsKey(reqId))
                {
                    Log.Error(LogTag, $"Invalid reqId {reqId.ToString()}");
                    return;
                }

                if (!providerResult)
                {
                    Log.Error(LogTag, $"reqId {reqId.ToString()}, error : {error}");
                }

                if (valueList !=null)
                {
                    string[] stringArray;
                    IntPtrToStringArray(valueList, valueCount, out stringArray);
                    mgr = new MapGetResult(stringArray, providerResult);
                }
                else
                {
                    mgr = new MapGetResult(new string[0], providerResult);
                    Log.Error(LogTag, $"reqId {reqId.ToString()}, valueList is null");
                }

                Consumer consumer = _reqConsumerDictionary[reqId];
                consumer.OnMapGetResult(mgr);
                _reqConsumerDictionary.Remove(reqId);
            }

            private static void MapBulkAddResponse(int reqId, IntPtr provider, IntPtr bulkResults, bool providerResult, string error, IntPtr userData)
            {
                BulkResultData brd;
                Log.Debug(LogTag, $"MapBulkAddResponse {reqId.ToString()}");
                if (!_reqConsumerDictionary.ContainsKey(reqId))
                {
                    Log.Error(LogTag, $"Invalid reqId {reqId.ToString()}");
                    return;
                }

                if (!providerResult)
                {
                    Log.Error(LogTag, $"reqId {reqId.ToString()}, error : {error}");
                }

                if (bulkResults != IntPtr.Zero)
                {
                    brd = new BulkResultData(new Interop.DataControl.SafeBulkResultDataHandle(bulkResults, false));
                }
                else
                {
                    brd = new BulkResultData();
                    Log.Error(LogTag, $"reqId {reqId.ToString()}, bulkResults is null");
                }

                Consumer consumer = _reqConsumerDictionary[reqId];
                consumer.OnMapBulkAddResult(new MapBulkAddResult(brd, providerResult));
                _reqConsumerDictionary.Remove(reqId);
            }

            private static void MapAddResponse(int reqId, IntPtr provider, bool providerResult, string error, IntPtr userData)
            {
                Log.Debug(LogTag, $"MapAddResponse {reqId.ToString()}");
                if (!_reqConsumerDictionary.ContainsKey(reqId))
                {
                    Log.Error(LogTag, $"Invalid reqId {reqId.ToString()}");
                    return;
                }

                if (!providerResult)
                {
                    Log.Error(LogTag, $"reqId {reqId.ToString()}, error : {error}");
                }

                Consumer consumer = _reqConsumerDictionary[reqId];
                consumer.OnMapAddResult(new MapAddResult(providerResult));
                _reqConsumerDictionary.Remove(reqId);
            }

            private static void MapSetResponse(int reqId, IntPtr provider, bool providerResult, string error, IntPtr userData)
            {
                Log.Debug(LogTag, $"MapSetResponse {reqId.ToString()}");
                if (!_reqConsumerDictionary.ContainsKey(reqId))
                {
                    Log.Error(LogTag, $"Invalid reqId {reqId.ToString()}");
                    return;
                }

                if (!providerResult)
                {
                    Log.Error(LogTag, $"reqId {reqId.ToString()}, error : {error}");
                }

                Consumer consumer = _reqConsumerDictionary[reqId];
                consumer.OnMapSetResult(new MapSetResult(providerResult));
                _reqConsumerDictionary.Remove(reqId);
            }

            private static void MapRemoveResponse(int reqId, IntPtr provider, bool providerResult, string error, IntPtr userData)
            {
                if (!_reqConsumerDictionary.ContainsKey(reqId))
                {
                    Log.Error(LogTag, $"Invalid reqId {reqId.ToString()}");
                    return;
                }

                if (!providerResult)
                {
                    Log.Error(LogTag, $"reqId {reqId.ToString()}, error : {error}");
                }

                Consumer consumer = _reqConsumerDictionary[reqId];
                consumer.OnMapRemoveResult(new MapRemoveResult(providerResult));
                _reqConsumerDictionary.Remove(reqId);
            }

            private static MatrixCursor CloneCursor(CloneCursorCore coreCursor)
            {
                int size = coreCursor.GetColumnCount();
                int i;
                string[] name = new string[size];
                object[] newRow = new object[size];
                ColumnType[] type = new ColumnType[size];

                for (i = 0; i < size; i++)
                {
                    name[i] = coreCursor.GetColumnName(i);
                    type[i] = coreCursor.GetColumnType(i);
                }

                MatrixCursor dmc = new MatrixCursor(name, type);

                if (coreCursor.GetRowCount() <= 0)
                {
                    return dmc;
                }

                coreCursor.Reset();
                do
                {
                    for (i = 0; i < size; i++)
                    {
                        switch (type[i])
                        {
                            case ColumnType.ColumnTypeInt:
                                newRow[i] = coreCursor.GetInt64Value(i);
                                break;
                            case ColumnType.ColumnTypeDouble:
                                newRow[i] = coreCursor.GetDoubleValue(i);
                                break;
                            case ColumnType.ColumnTypeBlob:
                                newRow[i] = coreCursor.GetBlobValue(i);
                                break;
                            case ColumnType.ColumnTypeString:
                                newRow[i] = coreCursor.GetStringValue(i);
                                break;
                        }
                    }

                    dmc.AddRow(newRow);
                }
                while (coreCursor.Next());

                return dmc;
            }

            internal static void RegisterReqId(int reqId, Consumer consumer)
            {
                _lock.WaitOne();
                _reqConsumerDictionary.Add(reqId, consumer);
                _lock.ReleaseMutex();
            }

            internal static void RegisterCallback(Interop.DataControl.SafeDataControlHandle handle, string providerId)
            {
                ResultType ret;
                Interop.DataControl.SqlResponseCallbacks sqlCallbacks;
                Interop.DataControl.SqlBulkInsertResponseCallback sqlBulkCallbacks;
                Interop.DataControl.MapResponseCallbacks mapCallbacks;
                Interop.DataControl.MapBulkAddResponseCallback mapBulkCallbacks;
                bool sqlRegistered = false;
                bool mapRegistered = false;

                if (_reqProviderList.ContainsKey(providerId))
                {
                    _reqProviderList[providerId]++;
                    Log.Error(LogTag, "The data control is already set");
                    return;
                }

                sqlCallbacks.Insert = new Interop.DataControl.SqlInsertResponseCallback(InsertResponse);
                sqlCallbacks.Select = new Interop.DataControl.SqlSelectResponseCallback(SelectResponse);
                sqlCallbacks.Update = new Interop.DataControl.SqlUpdateResponseCallback(UpdateResponse);
                sqlCallbacks.Delete = new Interop.DataControl.SqlDeleteResponseCallback(DeleteResponse);
                ret = Interop.DataControl.RegisterSqlResponseCallback(handle, ref sqlCallbacks, IntPtr.Zero);
                if (ret != ResultType.Success)
                {
                    Log.Error(LogTag, "Registering the sql callback function is failed : " + ret);
                }
                else
                {
                    _sqlResponseCallbacks.Add(providerId, sqlCallbacks);
                    sqlRegistered = true;
                }

                sqlBulkCallbacks = new Interop.DataControl.SqlBulkInsertResponseCallback(BulkInsertResponse);
                ret = Interop.DataControl.RegisterSqlBulkResponseCallback(handle, sqlBulkCallbacks, IntPtr.Zero);
                if (ret != ResultType.Success)
                {
                    Log.Error(LogTag, "Registering the sql bulk callback function is failed : " + ret);
                }
                else
                {
                    _sqlBulkResponseCallback.Add(providerId, sqlBulkCallbacks);
                }

                mapCallbacks.Add = new Interop.DataControl.MapAddResponseCallback(MapAddResponse);
                mapCallbacks.Set = new Interop.DataControl.MapSetResponseCallback(MapSetResponse);
                mapCallbacks.Get = new Interop.DataControl.MapGetResponseCallback(MapGetResponse);
                mapCallbacks.Remove = new Interop.DataControl.MapRemoveResponseCallback(MapRemoveResponse);
                ret = Interop.DataControl.RegisterMapResponse(handle, ref mapCallbacks, IntPtr.Zero);

                if (ret != ResultType.Success)
                {
                    Log.Error(LogTag, "Registering the map callback function is failed : " + ret);
                }
                else
                {
                    _mapResponseCallbacks.Add(providerId, mapCallbacks);
                    mapRegistered = true;
                }

                mapBulkCallbacks = new Interop.DataControl.MapBulkAddResponseCallback(MapBulkAddResponse);
                ret = Interop.DataControl.RegisterMapBulkResponseCallback(handle, mapBulkCallbacks, IntPtr.Zero);
                if (ret != ResultType.Success)
                {
                    Log.Error(LogTag, "Registering the map bulk callback function is failed : " + ret);
                }
                else
                {
                    _mapBulkResponseCallback.Add(providerId, mapBulkCallbacks);
                }

                if (!mapRegistered && !sqlRegistered)
                {
                    ErrorFactory.ThrowException(ret, true, "Registering the response callback function is failed");
                }

                _reqProviderList.Add(providerId, 1);
            }

            internal static void UnregisterCallback(Interop.DataControl.SafeDataControlHandle handle, string providerId)
            {
                int count;

                if (!_reqProviderList.ContainsKey(providerId))
                {
                    Log.Error(LogTag, "The provider id is not contained : " + providerId);
                    return;
                }

                _reqProviderList[providerId]--;
                count = _reqProviderList[providerId];
                if (count <= 0)
                {
                    _reqProviderList.Remove(providerId);

                    _mapResponseCallbacks.Remove(providerId);
                    Interop.DataControl.UnregisterMapResponse(handle);

                    _mapBulkResponseCallback.Remove(providerId);
                    Interop.DataControl.UnregisterMapBulkResponseCallback(handle);

                    _sqlResponseCallbacks.Remove(providerId);
                    Interop.DataControl.UnregisterSqlResponseCallback(handle);

                    _sqlBulkResponseCallback.Remove(providerId);
                    Interop.DataControl.UnregisterSqlBulkResponseCallback(handle);
                }

            }
        }

        /// <summary>
        /// Sends the insert request to the provider application.
        /// </summary>
        /// <remarks>The OnInsertResult will recieve the result of this API.</remarks>
        /// <param name="insertData">The insert data.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parmaeter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case if a permission is denied.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the message has exceeded the maximum limit (1MB).</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 3 </since_tizen>
        public void Insert(Bundle insertData)
        {
            int reqId;
            ResultType ret;

            if (insertData == null || insertData.SafeBundleHandle.IsInvalid)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "insertData");
            }

            _lock.WaitOne();
            ret = Interop.DataControl.Insert(_handle, insertData.SafeBundleHandle, out reqId);
            _lock.ReleaseMutex();
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false, "Insert");
            }

            CallbackManager.RegisterReqId(reqId, this);
        }

        /// <summary>
        /// Sends the select request to the provider application.
        /// </summary>
        /// <remarks>The OnSelectResult will recieve the result of this API.</remarks>
        /// <param name="columnList">Select the target column list.</param>
        /// <param name="where">The Where statement for the select query.</param>
        /// <param name="order">The Order statement for the select query.</param>
        /// <param name="pageNumber">Select the target page number.</param>
        /// <param name="countPerPage">Select the row count per page.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parmaeter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case if a permission is denied..</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 3 </since_tizen>
        public void Select(string[] columnList, string where, string order, int pageNumber = 1, int countPerPage = 20)
        {
            int reqId, i;
            ResultType ret;
            if (columnList == null || columnList.Length == 0)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "column_list");
            }

            for (i = 0; i < columnList.Length; i++)
            {
                if (string.IsNullOrEmpty(columnList[i]))
                {
                    ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "column_list index " + i.ToString());
                }
            }

            _lock.WaitOne();
            ret = Interop.DataControl.Select(_handle, columnList, columnList.Length, where, order, pageNumber, countPerPage, out reqId);
            _lock.ReleaseMutex();
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false, "Select");
            }
            Log.Info(LogTag, "select end. " + reqId.ToString());

            CallbackManager.RegisterReqId(reqId, this);
        }

        /// <summary>
        /// Sends the delete request to the provider application.
        /// </summary>
        /// <remarks>The OnDeleteResult will recieve the result of this API</remarks>
        /// <param name="where">The Where statement for the delete query.</param>
        /// <exception cref="UnauthorizedAccessException">Thrown in case if a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 3 </since_tizen>
        public void Delete(string where)
        {
            int reqId;
            ResultType ret;

            _lock.WaitOne();
            ret = Interop.DataControl.Delete(_handle, where, out reqId);
            _lock.ReleaseMutex();
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false, "Delete");
            }

            CallbackManager.RegisterReqId(reqId, this);
        }

        /// <summary>
        /// Sends the update request to the provider application.
        /// </summary>
        /// <remarks>The OnUpdateResult will recieve result of this API.</remarks>
        /// <param name="updateData">The update data.</param>
        /// <param name="where">The Where statement for the query.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parmaeter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case if a permission is denied.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the message has exceeded the maximum limit (1MB).</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 3 </since_tizen>
        public void Update(Bundle updateData, string where)
        {
            int reqId;
            ResultType ret;

            if (updateData == null || updateData.SafeBundleHandle.IsInvalid)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "insertData");
            }

            if (string.IsNullOrEmpty(where))
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "where");
            }

            _lock.WaitOne();
            ret = Interop.DataControl.Update(_handle, updateData.SafeBundleHandle, where, out reqId);
            _lock.ReleaseMutex();
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false, "Update");
            }

            CallbackManager.RegisterReqId(reqId, this);
        }

        /// <summary>
        /// Sends the bulk insert request to the provider application.
        /// </summary>
        /// <remarks>The OnBulkInsertResult will recieve the result of this API.</remarks>
        /// <param name="insertData">The bulk insert data.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parmaeter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case oif a permission is denied.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the message has exceeded the maximum limit (1MB).</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 3 </since_tizen>
        public void BulkInsert(BulkData insertData)
        {
            int reqId;
            ResultType ret;

            if (insertData == null || insertData.SafeBulkDataHandle.IsInvalid)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "insertData");
            }

            _lock.WaitOne();
            ret = Interop.DataControl.BulkInsert(_handle, insertData.SafeBulkDataHandle, out reqId);
            _lock.ReleaseMutex();
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false, "BulkInsert");
            }

            CallbackManager.RegisterReqId(reqId, this);
        }

        /// <summary>
        /// Sends the map add request to the provider application.
        /// </summary>
        /// <remarks>The OnMapAddResult will recieve the result of this API.</remarks>
        /// <param name="key">The key of the value to add.</param>
        /// <param name="value">The value to add.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parmaeter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of if a permission is denied.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the message has exceeded the maximum limit (1MB).</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 3 </since_tizen>
        public void MapAdd(string key, string value)
        {
            int reqId;
            ResultType ret;

            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            _lock.WaitOne();
            ret = Interop.DataControl.MapAdd(_handle, key, value, out reqId);
            _lock.ReleaseMutex();
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false, "MapAdd");
            }

            CallbackManager.RegisterReqId(reqId, this);
        }

        /// <summary>
        /// Sends the map get request to the provider application.
        /// </summary>
        /// <remarks>The OnMapGetResult will recieve the result of this API.</remarks>
        /// <param name="key">The key of the value list to obtain.</param>
        /// <param name="pageNumber">The page number of the value set.</param>
        /// <param name="countPerPage">The desired maximum count of the data items per page.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parmaeter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case if a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 3 </since_tizen>
        public void MapGet(string key, int pageNumber = 1, int countPerPage = 20)
        {
            int reqId;
            ResultType ret;

            if (string.IsNullOrEmpty(key) || pageNumber <= 0 || countPerPage <= 0)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            _lock.WaitOne();
            ret = Interop.DataControl.MapGet(_handle, key, out reqId, pageNumber, countPerPage);
            _lock.ReleaseMutex();
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false, "MapGet");
            }

            CallbackManager.RegisterReqId(reqId, this);
        }

        /// <summary>
        /// Sends the map remove request to the provider application.
        /// </summary>
        /// <remarks>The OnMapRemoveResult will recieve the result of this API.</remarks>
        /// <param name="key">The key of the value to remove.</param>
        /// <param name="value">The value to remove.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parmaeter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case if a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 3 </since_tizen>
        public void MapRemove(string key, string value)
        {
            int reqId;
            ResultType ret;

            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            _lock.WaitOne();
            ret = Interop.DataControl.MapRemove(_handle, key, value, out reqId);
            _lock.ReleaseMutex();
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false, "MapRemove");
            }

            CallbackManager.RegisterReqId(reqId, this);
        }

        /// <summary>
        /// Sends the map set request to the provider application.
        /// </summary>
        /// <remarks>The OnMapSetResult will recieve the result of this API.</remarks>
        /// <param name="key">The key of the value to replace.</param>
        /// <param name="oldValue">The value to be replaced.</param>
        /// <param name="newValue"> The new value that replaces the existing value.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parmaeter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case if a permission is denied.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when message has exceeded the maximum limit (1MB).</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 3 </since_tizen>
        public void MapSet(string key, string oldValue, string newValue)
        {
            int reqId;
            ResultType ret;

            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(oldValue) || string.IsNullOrEmpty(newValue))
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            _lock.WaitOne();
            ret = Interop.DataControl.MapSet(_handle, key, oldValue, newValue, out reqId);
            _lock.ReleaseMutex();
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false, "MapSet");
            }

            CallbackManager.RegisterReqId(reqId, this);
        }

        /// <summary>
        /// Sends the map bulk add request to the provider application.
        /// </summary>
        /// <remarks>The OnMapBulkAddResult will recieve the result of this API.</remarks>
        /// <param name="addData">The map bulk add data.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parmaeter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case if a permission is denied.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the message has exceeded the maximum limit (1MB).</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 3 </since_tizen>
        public void MapBulkAdd(BulkData addData)
        {
            int reqId;
            ResultType ret;

            if (addData == null || addData.SafeBulkDataHandle.IsInvalid)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "addData");
            }

            _lock.WaitOne();
            ret = Interop.DataControl.BulkAdd(_handle, addData.SafeBulkDataHandle, out reqId);
            _lock.ReleaseMutex();
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false, "BulkAdd");
            }

            CallbackManager.RegisterReqId(reqId, this);
        }

        private void DataChange(IntPtr handle, ChangeType type, IntPtr data, IntPtr userData)
        {
            OnDataChange(type, new Bundle(new SafeBundleHandle(data, false)));
        }

        private void DataChangeListenResult(IntPtr handle, ResultType type, int callbackId, IntPtr userData)
        {
            OnDataChangeListenResult(new DataChangeListenResult(type));
        }

        /// <summary>
        /// Listens the DataChange event.
        /// </summary>
        /// <remarks>The OnDataChangeListenResult will recieve the result of this API.</remarks>
        /// <remarks>If success, the OnDataChange will recieve the DataChange event.</remarks>
        /// <exception cref="UnauthorizedAccessException">Thrown in case if a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 3 </since_tizen>
        public void DataChangeListen()
        {
            ResultType ret;
            _lock.WaitOne();
            /* Only one callback is allowed for every obejct */
            if (_changeCallbackID > 0)
            {
                _lock.ReleaseMutex();
                return;
            }
            _dataChangeCallback = new Interop.DataControl.DataChangeCallback(DataChange);
            _addCallbackResultCallback = new Interop.DataControl.AddCallbackResultCallback(DataChangeListenResult);
            ret = Interop.DataControl.AddDataChangeCallback(_handle, _dataChangeCallback, IntPtr.Zero,
                      _addCallbackResultCallback , IntPtr.Zero, out _changeCallbackID);
            _lock.ReleaseMutex();
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false, "DataChangeListen");
            }
        }

        /// <summary>
        /// Initializes the Consumer class with the providerId and the ataId.
        /// </summary>
        /// <param name="providerId">The DataControl Provider ID.</param>
        /// <param name="dataId">The DataControl Data ID.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parmaeter.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <since_tizen> 3 </since_tizen>
        public Consumer(string providerId, string dataId)
        {
            ResultType ret;

            if (string.IsNullOrEmpty(providerId))
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "providerId");
            }

            if (string.IsNullOrEmpty(dataId))
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "dataId");
            }

            ret = Interop.DataControl.DataControlCreate(out _handle);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false, "Creating data control handle is failed");
            }

            Interop.DataControl.DataControlSetProviderId(_handle, providerId);
            Interop.DataControl.DataControlSetDataId(_handle, dataId);
            _lock.WaitOne();
            CallbackManager.RegisterCallback(_handle, providerId);
            _lock.ReleaseMutex();
            _dataID = dataId;
            _providerID = providerId;
        }

        /// <summary>
        /// Destructor of the Consumer class.
        /// </summary>
        ~Consumer()
        {
            Dispose(false);
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the DataChangeListen result is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnDataChangeListenResult(DataChangeListenResult result)
        {
            Log.Info(LogTag, "The OnDataChangeListenResult is not implemented.");
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the data change event is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnDataChange(ChangeType type, Bundle data)
        {
            Log.Info(LogTag, "The OnDataChange is not implemented.");
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the select response is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected abstract void OnSelectResult(SelectResult result);

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the insert response is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected abstract void OnInsertResult(InsertResult result);

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the update response is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected abstract void OnUpdateResult(UpdateResult result);

        /// <summary>
        /// Overrides this method if want to handle the behavior when the delete response is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected abstract void OnDeleteResult(DeleteResult result);
        /// <summary>
        /// Overrides this method if you want to handle the behavior when the BulkInsert response is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnBulkInsertResult(BulkInsertResult result)
        {
            Log.Info(LogTag, "The OnBulkInsertResult is not implemented.");
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the map get response is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnMapGetResult(MapGetResult result)
        {
            Log.Info(LogTag, "The OnMapGetResult is not implemented.");
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the map add response is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnMapAddResult(MapAddResult result)
        {
            Log.Info(LogTag, "The OnMapAddResult is not implemented.");
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the map set response is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnMapSetResult(MapSetResult result)
        {
            Log.Info(LogTag, "The OnMapSetResult is not implemented.");
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the map remove response is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnMapRemoveResult(MapRemoveResult result)
        {
            Log.Info(LogTag, "The OnMapRemoveResult is not implemented.");
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the BulkAdd response is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnMapBulkAddResult(MapBulkAddResult result)
        {
            Log.Info(LogTag, "The OnMapBulkAddResult is not implemented.");
        }

        /// <summary>
        /// Releases the unmanaged resources used by the Consumer class specifying whether to perform a normal dispose operation.
        /// </summary>
        /// <param name="disposing">true for a normal dispose operation; false to finalize the handle.</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_changeCallbackID > 0)
                {
                    Interop.DataControl.RemoveDataChangeCallback(_handle, _changeCallbackID);
                }

                _lock.WaitOne();
                CallbackManager.UnregisterCallback(_handle, _providerID);
                _lock.ReleaseMutex();
                _handle.Dispose();
                _disposed = true;
            }

            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Releases all resources used by the Consumer class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
        }
    }
}

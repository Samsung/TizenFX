/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Tizen.Tapi
{
    /// <summary>
    /// A class which manages sim phonebook record information.
    /// </summary>
    public class Phonebook
    {
        private IntPtr _handle = IntPtr.Zero;
        private Dictionary<IntPtr, Interop.Tapi.TapiResponseCallback> _callbackMap = new Dictionary<IntPtr, Interop.Tapi.TapiResponseCallback>();
        private int _requestId = 0;

        private Phonebook()
        {
        }

        /// <summary>
        /// Gets the instance of Phonebook class.
        /// </summary>
        /// <param name="handle">An instance of TapiHandle obtained from InitTapi in TapiManager API.</param>
        /// <exception cref="ArgumentNullException">Thrown when handle is passed as null.</exception>
        public Phonebook(TapiHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException("Handle is null");
            }

            _handle = handle._handle;
        }

        /// <summary>
        /// Gets the current inserted SIM phonebook init status, available phonebook list, and first valid index in case of FDN, ADN, and 3G phonebook.
        /// </summary>
        /// <returns>An instance of SimPhonebookStatus containing init status and phonebook list information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public SimPhonebookStatus GetPhonebookInitInfo()
        {
            SimPhonebookStatusStruct pbStatus;
            int ret = Interop.Tapi.Phonebook.GetPhonebookInitInfo(_handle, out int isInitCompleted, out SimPhonebookListStruct pbList);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get phonebook init info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            pbStatus.IsInitCompleted = isInitCompleted;
            pbStatus.PbList = pbList;
            return PhonebookStructConversions.ConvertSimPhonebookStatusStruct(pbStatus);
        }

        /// <summary>
        /// Gets the number of used records and total records of a specific SIM phonebook type.
        /// </summary>
        /// <param name="type">The different storage types to be selected in the SIM.</param>
        /// <returns>A task containing an instance of PhonebookStorageInfo.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<PhonebookStorageInfo> GetPhonebookStorage(PhonebookType type)
        {
            TaskCompletionSource<PhonebookStorageInfo> task = new TaskCompletionSource<PhonebookStorageInfo>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)PhonebookAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting phone book storage: " + (PhonebookAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting phone book storage, " + (PhonebookAccessResult)result));
                        return;
                    }

                    PhonebookStorageInfoStruct info = Marshal.PtrToStructure<PhonebookStorageInfoStruct>(data);
                    task.SetResult(PhonebookStructConversions.ConvertPhonebookStorageStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Phonebook.GetPhonebookStorage(_handle, type, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get phonebook storage info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets the max text length and max number length supported by the SIM phone book elementary file.
        /// </summary>
        /// <param name="type">The different storage types to be selected in the SIM.</param>
        /// <returns>A task containing an instance of PhonebookMetaInfo.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<PhonebookMetaInfo> GetPhonebookMetaInfo(PhonebookType type)
        {
            TaskCompletionSource<PhonebookMetaInfo> task = new TaskCompletionSource<PhonebookMetaInfo>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)PhonebookAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting phone book meta info: " + (PhonebookAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting phone book meta info, " + (PhonebookAccessResult)result));
                        return;
                    }

                    PhonebookMetaInfoStruct info = Marshal.PtrToStructure<PhonebookMetaInfoStruct>(data);
                    task.SetResult(PhonebookStructConversions.ConvertPhonebookMetaInfoStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Phonebook.GetPhonebookMetaInfo(_handle, type, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get phonebook meta info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets SIM 3G phonebook supported EFs like ANR, SNE, GRP, EMAIL and the corresponding EFs max text length, number length, and size.
        /// </summary>
        /// <returns>A task containing an instance of PhonebookMetaInfo3G.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<PhonebookMetaInfo3G> GetPhonebookMetaInfo3G()
        {
            TaskCompletionSource<PhonebookMetaInfo3G> task = new TaskCompletionSource<PhonebookMetaInfo3G>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)PhonebookAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting 3G phone book meta info: " + (PhonebookAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting 3G phone book meta info, " + (PhonebookAccessResult)result));
                        return;
                    }

                    PhonebookMetaInfo3GStruct metaInfo = Marshal.PtrToStructure<PhonebookMetaInfo3GStruct>(data);
                    task.SetResult(PhonebookStructConversions.ConvertPhonebookMetaInfo3GStruct(metaInfo));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Phonebook.GetPhonebookMetaInfo3G(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get 3G phonebook meta info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Reads SIM phone book entry information from the given storage type and index.
        /// </summary>
        /// <param name="type">The different storage types to be selected in the SIM.</param>
        /// <param name="index">The index for accessing the SIM data.</param>
        /// <returns>A task containing an instance of PhonebookRecord.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<PhonebookRecord> ReadPhonebookRecord(PhonebookType type, ushort index)
        {
            TaskCompletionSource<PhonebookRecord> task = new TaskCompletionSource<PhonebookRecord>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)PhonebookAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during reading phone book record: " + (PhonebookAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs during reading phone book record, " + (PhonebookAccessResult)result));
                        return;
                    }

                    PhonebookRecordStruct record = Marshal.PtrToStructure<PhonebookRecordStruct>(data);
                    task.SetResult(PhonebookStructConversions.ConvertPhonebookRecordStruct(record));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (index == 0)
            {
                throw new ArgumentException("Index should not be zero");
            }

            int ret = Interop.Tapi.Phonebook.ReadPhonebookRecord(_handle, type, index, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to read phonebook record, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Adds or edits SIM phone book record entry information.
        /// </summary>
        /// <param name="record">The phonebook data to be updated or added.</param>
        /// <returns>A task indicating whether the updation is done or not.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when record is passed as null.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<bool> UpdatePhonebookRecord(PhonebookRecord record)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)PhonebookAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during updation of phone book record: " + (PhonebookAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs during updation of phone book record, " + (PhonebookAccessResult)result));
                        return;
                    }

                    task.SetResult(true);
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (record == null)
            {
                throw new ArgumentNullException("Phonebook record is null");
            }

            if (record.Index == 0)
            {
                throw new ArgumentException("Index in phonebook record is zero");
            }

            PhonebookRecordStruct recordStruct = PhonebookClassConversions.ConvertPhonebookrecord(record);
            int ret = Interop.Tapi.Phonebook.UpdatePhonebookRecord(_handle, ref recordStruct, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to update phonebook record, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Deletes a SIM phonebook record.
        /// </summary>
        /// <param name="type">The different storage types to be selected in the SIM.</param>
        /// <param name="index">The index of the record to be deleted.</param>
        /// <returns>A task indicating whether deletion is done or not.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<bool> DeletePhonebookRecord(PhonebookType type, ushort index)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)PhonebookAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during deletion of phone book record: " + (PhonebookAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs during deletion of phone book record, " + (PhonebookAccessResult)result));
                        return;
                    }

                    task.SetResult(true);
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (index == 0)
            {
                throw new ArgumentException("Index of the record is zero");
            }

            int ret = Interop.Tapi.Phonebook.DeletePhonebookRecord(_handle, type, index, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to delete phonebook record, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }
    }
}

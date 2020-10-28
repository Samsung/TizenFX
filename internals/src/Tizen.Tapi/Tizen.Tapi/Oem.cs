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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Tizen.Tapi
{
    /// <summary>
    /// This class provides functions for sending oem related data.
    /// </summary>
    public class Oem
    {
        private IntPtr _handle;
        private Dictionary<IntPtr, Interop.Tapi.TapiResponseCallback> _response_map = new Dictionary<IntPtr, Interop.Tapi.TapiResponseCallback>();
        private int _requestId = 0;

        /// <summary>
        /// A public constructor for Oem class to create a Oem instance for the given tapi handle.
        /// </summary>
        /// <param name="handle">The tapi handle.</param>
        public Oem(TapiHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException("TapiHandle parameter is null");
            }

            _handle = handle._handle;
        }

        /// <summary>
        /// Sends oem data directly.
        /// </summary>
        /// <param name="oemId">Oem id for user specification.</param>
        /// <param name="data">Oem data for sending.</param>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when oem instance is invalid or when method failed due to invalid operation.</exception>
        public void SendOemData(int oemId, byte[] data)
        {
            int length = data.Length;
            IntPtr oemData = Marshal.AllocHGlobal(length);
            Marshal.Copy(data, 0, oemData, length);
            int ret = Interop.Tapi.Oem.SendOemData(_handle, oemId, oemData, Convert.ToUInt32(length));
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to send oem data directly, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }
        }

        /// <summary>
        /// Sends oem data directly.
        /// </summary>
        /// <param name="oemId">Oem id for user specification.</param>
        /// <param name="data">Oem data for sending.</param>
        /// <returns>The oem data which is sent.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public OemData SendOemDataSync(int oemId, byte[] data)
        {
            OemDataStruct oemStruct;
            int length = data.Length;
            IntPtr oemData = Marshal.AllocHGlobal(length);
            Marshal.Copy(data, 0, oemData, length);
            int ret = Interop.Tapi.Oem.SendOemDataSync(_handle, oemId, oemData, Convert.ToUInt32(length), out oemStruct);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to send oem data directly, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            OemData oemDataSend = OemStructConversions.ConvertOemStruct(oemStruct);
            return oemDataSend;
        }

        /// <summary>
        /// Sends oem data directly.
        /// </summary>
        /// <param name="oemId">Oem id for user specification.</param>
        /// <param name="data">Oem data for sending.</param>
        /// <returns>The oem data which is sent.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task<OemData> SendOemDataAsync(int oemId, byte[] data)
        {
            TaskCompletionSource<OemData> task = new TaskCompletionSource<OemData>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr dataResponse, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)NetworkOperationCause.NoError)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during sending oem data, " + (NetworkOperationCause)result);
                        task.SetException(new InvalidOperationException("Error occurs during sending oem data, " + (NetworkOperationCause)result));
                        return;
                    }

                    OemDataStruct oemStruct = Marshal.PtrToStructure<OemDataStruct>(dataResponse);
                    OemData oemClass = OemStructConversions.ConvertOemStruct(oemStruct);
                    task.SetResult(oemClass);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int length = data.Length;
            IntPtr oemData = Marshal.AllocHGlobal(length);
            Marshal.Copy(data, 0, oemData, length);
            int ret = Interop.Tapi.Oem.SendOemDataAsync(_handle, oemId, oemData, Convert.ToUInt32(length), _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to send oem data, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }
    }
}
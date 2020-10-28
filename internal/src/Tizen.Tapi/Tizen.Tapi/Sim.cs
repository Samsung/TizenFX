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
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Tapi
{
    /// <summary>
    /// A class which manages SIM card services.
    /// </summary>
    public class Sim
    {
        private IntPtr _handle = IntPtr.Zero;
        private Dictionary<IntPtr, Interop.Tapi.TapiResponseCallback> _callbackMap = new Dictionary<IntPtr, Interop.Tapi.TapiResponseCallback>();
        private int _requestId = 0;
        private Sim()
        {
        }

        /// <summary>
        /// A constructor to instantiate Sim class using the Tapi handle.
        /// </summary>
        /// <param name="handle">An instance of TapiHandle obtained from InitTapi in TapiManager API.</param>
        /// <exception cref="ArgumentNullException">Thrown when handle is passed as null.</exception>
        public Sim(TapiHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException("Handle is null");
            }

            _handle = handle._handle;
        }

        /// <summary>
        /// Gets SIM card initialization status and SIM card identification.
        /// </summary>
        /// <value>An instance of SimInitInfo class in case of success. Null in case of failure.</value>
        public SimInitInfo InitInfo
        {
            get
            {
                SimCardStatus status;
                int isCardChanged;
                int ret = Interop.Tapi.Sim.SimGetInitInfo(_handle, out status, out isCardChanged);
                if (ret != (int)TapiError.Success)
                {
                    Log.Error(TapiUtility.LogTag, "Failed to get SIM init info, Error: " + (TapiError)ret);
                    return null;
                }

                SimInitInfo initInfo = new SimInitInfo();
                initInfo.SimStatus = status;
                if (isCardChanged == 1)
                {
                    initInfo.IsChanged = true;
                }

                else if (isCardChanged == 0)
                {
                    initInfo.IsChanged = false;
                }

                return initInfo;
            }
        }

        /// <summary>
        /// Gets the card type (SIM/USIM).
        /// </summary>
        public SimCardType SimType
        {
            get
            {
                SimCardType type;
                int ret = Interop.Tapi.Sim.SimGetType(_handle, out type);
                if (ret != (int)TapiError.Success)
                {
                    Log.Error(TapiUtility.LogTag, "Failed to get SIM card type, Error: " + (TapiError)ret);
                    return default(SimCardType);
                }

                return type;
            }
        }

        /// <summary>
        /// Gets SIM IMSI information.
        /// </summary>
        public SimImsiInfo Imsi
        {
            get
            {
                SimImsiInfoStruct imsi;
                int ret = Interop.Tapi.Sim.SimGetImsi(_handle, out imsi);
                if (ret != (int)TapiError.Success)
                {
                    Log.Error(TapiUtility.LogTag, "Failed to get SIM IMSI info, Error: " + (TapiError)ret);
                    return null;
                }

                return SimStructConversions.ConvertSimImsiInfoStruct(imsi);
            }
        }

        /// <summary>
        /// Gets ECC(SIM) or UECC(USIM) data.
        /// </summary>
        public SimEccInfoList Ecc
        {
            get
            {
                SimEccInfoListStruct eccInfo;
                int ret = Interop.Tapi.Sim.SimGetEcc(_handle, out eccInfo);
                if (ret != (int)TapiError.Success)
                {
                    Log.Error(TapiUtility.LogTag, "Failed to get SIM ECC info, Error: " + (TapiError)ret);
                    return null;
                }

                return SimStructConversions.ConvertSimEccInfoListStruct(eccInfo);
            }
        }

        /// <summary>
        /// Gets the list of application on UICC.
        /// </summary>
        /// <returns>A byte containing the masking value for SimAppType.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public byte SimGetApplicationList()
        {
            byte appList;
            int ret = Interop.Tapi.Sim.SimGetApplicationList(_handle, out appList);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get list of applications, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return appList;
        }

        /// <summary>
        /// Gets the unique identification number of the (U)ICC.
        /// </summary>
        /// <returns>A task containing ICCID information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimIccIdInfo> SimGetIccId()
        {
            TaskCompletionSource<SimIccIdInfo> task = new TaskCompletionSource<SimIccIdInfo>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting ICCID info: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting ICCID info, " + (SimAccessResult)result));
                        return;
                    }

                    SimIccIdInfoStruct info = Marshal.PtrToStructure<SimIccIdInfoStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimIccIdInfoStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetIccId(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get SIM ICCID info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets language preference(indication) information.
        /// </summary>
        /// <returns>A task containing information about SIM language preference.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimLanguagePreference> SimGetLanguagePreference()
        {
            TaskCompletionSource<SimLanguagePreference> task = new TaskCompletionSource<SimLanguagePreference>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting language preference: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting language preference, " + (SimAccessResult)result));
                        return;
                    }

                    task.SetResult((SimLanguagePreference)Marshal.ReadInt32(data));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetLanguage(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get SIM language preference, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Updates language preference information to the SIM card.
        /// </summary>
        /// <param name="language">The language preference information.</param>
        /// <returns>A task indicating whether setting of language preference is done or not.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<bool> SimSetLanguagePreference(SimLanguagePreference language)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in setting language preference: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in setting language preference, " + (SimAccessResult)result));
                        return;
                    }

                    task.SetResult(true);
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimSetLanguage(_handle, language, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to set SIM language preference, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets SIM call forwarding indication related data(EF-CFIS and CPHS case).
        /// </summary>
        /// <returns>A task containing call forward response information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimCallForwardResponse> SimGetCallForwardInfo()
        {
            TaskCompletionSource<SimCallForwardResponse> task = new TaskCompletionSource<SimCallForwardResponse>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting call forward info: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting call forward info, " + (SimAccessResult)result));
                        return;
                    }

                    SimCallForwardResponseStruct info = Marshal.PtrToStructure<SimCallForwardResponseStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimCallForwardResponseStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetCallForwardingInfo(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get SIM call forward info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Sets SIM call forwarding indication related data(EF-CFIS and CPHS case).
        /// </summary>
        /// <param name="request">The data requesting for call forwarding.</param>
        /// <returns>A task indicating whether setting call forward info is done or not.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when call forward request is passed as null.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<bool> SimSetCallForwardInfo(SimCallForwardRequest request)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in setting call forward info: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in setting call forward info, " + (SimAccessResult)result));
                        return;
                    }

                    task.SetResult(true);
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (request == null)
            {
                throw new ArgumentNullException("SIM call forward request is null");
            }

            SimCallForwardRequestStruct requestStruct = SimClassConversions.ConvertSimCallForwardRequest(request);
            int ret = Interop.Tapi.Sim.SimSetCallForwardingInfo(_handle, ref requestStruct, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to set SIM call forward info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets SIM message waiting indication related data(EF-MWIS and CPHS case).
        /// </summary>
        /// <returns>A task containing message waiting response information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimMessageWaitingResponse> SimGetMessageWaitingInfo()
        {
            TaskCompletionSource<SimMessageWaitingResponse> task = new TaskCompletionSource<SimMessageWaitingResponse>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting message waiting info: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting message waiting info, " + (SimAccessResult)result));
                        return;
                    }

                    SimMessageWaitingResponseStruct info = Marshal.PtrToStructure<SimMessageWaitingResponseStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimMessageWaitingRespStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetMessageWaitingInfo(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get SIM message waiting info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Sets SIM message waiting indication related data(EF-MWIS and CPHS case).
        /// </summary>
        /// <param name="request">The data requesting for message waiting.</param>
        /// <returns>A task indicating whether setting message waiting info is done or not.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when message waiting request is passed as null.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<bool> SimSetMessageWaitingInfo(SimMessageWaitingRequest request)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in setting message waiting info: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in setting message waiting info, " + (SimAccessResult)result));
                        return;
                    }

                    task.SetResult(true);
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (request == null)
            {
                throw new ArgumentNullException("SIM message waiting request is null");
            }

            SimMessageWaitingRequestStruct requestStruct = SimClassConversions.ConvertSimMessageWaitingRequest(request);
            int ret = Interop.Tapi.Sim.SimSetMessageWaitingInfo(_handle, ref requestStruct, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to set SIM message waiting info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets SIM mailbox related data(EF-MBDN, MBDI, and CPHS case).
        /// </summary>
        /// <returns>A task containing SimMailboxList information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimMailboxList> SimGetMailboxInfo()
        {
            TaskCompletionSource<SimMailboxList> task = new TaskCompletionSource<SimMailboxList>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting mailbox info: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting mailbox info, " + (SimAccessResult)result));
                        return;
                    }

                    SimMailboxListStruct info = Marshal.PtrToStructure<SimMailboxListStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimMailboxListStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetMailboxInfo(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get SIM mailbox info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Sets SIM mailbox related data(EF-MBDN, MBDI and CPHS case).
        /// </summary>
        /// <param name="mailboxNumber">The data requesting for mailbox info.</param>
        /// <returns>A task indicating whether setting mailbox info is done or not.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when mailbox number is passed as null.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<bool> SimSetMailboxInfo(SimMailboxNumber mailboxNumber)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in setting mailbox info: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in setting mailbox info, " + (SimAccessResult)result));
                        return;
                    }

                    task.SetResult(true);
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (mailboxNumber == null)
            {
                throw new ArgumentNullException("SIM mailbox number is null");
            }

            SimMailboxNumberStruct mbStruct = SimClassConversions.ConvertSimMailboxNumber(mailboxNumber);
            int ret = Interop.Tapi.Sim.SimSetMailboxInfo(_handle, ref mbStruct, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to set SIM mailbox info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets SIM CPHS specific data.
        /// </summary>
        /// <returns>A task containing SimCphs information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimCphsInfo> SimGetCphsInfo()
        {
            TaskCompletionSource<SimCphsInfo> task = new TaskCompletionSource<SimCphsInfo>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting CPHS info: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting CPHS info, " + (SimAccessResult)result));
                        return;
                    }

                    SimCphsInfoStruct info = Marshal.PtrToStructure<SimCphsInfoStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimCphsInfoStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetCphsInfo(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get SIM CPHS info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets the SIM Service Table.
        /// </summary>
        /// <returns>A task containing SIM service table information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimServiceTable> SimGetServiceTable()
        {
            TaskCompletionSource<SimServiceTable> task = new TaskCompletionSource<SimServiceTable>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting service table: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting service table, " + (SimAccessResult)result));
                        return;
                    }

                    SimServiceTableStruct info = Marshal.PtrToStructure<SimServiceTableStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimServiceTableStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetServiceTable(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get SIM service table, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets SIM MSISDN data.
        /// </summary>
        /// <returns>A task containing SimMsisdnList information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimMsisdnList> SimGetMsisdn()
        {
            TaskCompletionSource<SimMsisdnList> task = new TaskCompletionSource<SimMsisdnList>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting MSISDN info: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting MSISDN info, " + (SimAccessResult)result));
                        return;
                    }

                    SimMsisdnListStruct info = Marshal.PtrToStructure<SimMsisdnListStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimMsisdnListStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetMsisdn(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get SIM MSISDN data, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets SIM OPLMNWACT(Operator controlled PLMN Selector with Access Technology) data.
        /// </summary>
        /// <returns>A task containing SimOplmnwactList information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimOplmnwactList> SimGetOplmnwact()
        {
            TaskCompletionSource<SimOplmnwactList> task = new TaskCompletionSource<SimOplmnwactList>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting OPLMNWACT info: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting OPLMNWACT info, " + (SimAccessResult)result));
                        return;
                    }

                    SimOplmnwactListStruct info = Marshal.PtrToStructure<SimOplmnwactListStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimOplmnwactListStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetOplmnwact(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get SIM OPLMNWACT info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets SIM SPN data.
        /// </summary>
        /// <returns>A task containing SimSpn information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimSpn> SimGetSpn()
        {
            TaskCompletionSource<SimSpn> task = new TaskCompletionSource<SimSpn>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting SPN info: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting SPN info, " + (SimAccessResult)result));
                        return;
                    }

                    SimSpnStruct info = Marshal.PtrToStructure<SimSpnStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimSpnStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetSpn(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get SIM SPN info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets SIM CPHS NETNAME data.
        /// </summary>
        /// <returns>A task containing SimCphsNetName information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimCphsNetName> SimGetCphsNetName()
        {
            TaskCompletionSource<SimCphsNetName> task = new TaskCompletionSource<SimCphsNetName>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting CPHS netname info: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting CPHS netname info, " + (SimAccessResult)result));
                        return;
                    }

                    SimCphsNetNameStruct info = Marshal.PtrToStructure<SimCphsNetNameStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimCphsNetNameStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetCphsNetName(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get SIM CPHS netname info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Executes an authentication procedure by using SIM.
        /// </summary>
        /// <param name="authenticationData">The authentication code to be validated by the ISIM, 3G, and GSM application in the SIM card.</param>
        /// <returns>A task containing SimAuthenticationResponse information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when authentication data is passed as null.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimAuthenticationResponse> SimExecuteAuthentication(SimAuthenticationData authenticationData)
        {
            TaskCompletionSource<SimAuthenticationResponse> task = new TaskCompletionSource<SimAuthenticationResponse>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in executing authentication procedure: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in executing authentication procedure, " + (SimAccessResult)result));
                        return;
                    }

                    SimAuthenticationResponseStruct info = Marshal.PtrToStructure<SimAuthenticationResponseStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimAuthenticationResponseStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (authenticationData == null)
            {
                throw new ArgumentNullException("SIM authentication data is null");
            }

            SimAuthenticationDataStruct authStruct = SimClassConversions.ConvertSimAuthenticationDataStruct(authenticationData);
            int ret = Interop.Tapi.Sim.SimExecuteAuthentication(_handle, ref authStruct, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to execute authentication procedure, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Performs PIN1/PIN2/SIM LOCK verification.
        /// </summary>
        /// <param name="pinData">The PIN code.</param>
        /// <returns>A task containing SimPinResult information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when pin data is passed as null.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimPinResult> SimVerifyPins(SimPinData pinData)
        {
            TaskCompletionSource<SimPinResult> task = new TaskCompletionSource<SimPinResult>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in verifying SIM pins: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in verifying SIM pins, " + (SimAccessResult)result));
                        return;
                    }

                    SimPinResultStruct info = Marshal.PtrToStructure<SimPinResultStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimPinResultStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (pinData == null)
            {
                throw new ArgumentNullException("SIM PIN data is null");
            }

            SimPinDataStruct pinStruct = SimClassConversions.ConvertSimPinData(pinData);
            int ret = Interop.Tapi.Sim.SimVerifyPins(_handle, ref pinStruct, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to verify SIM PIN, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Performs PIN1/PIN2 unblocking operation based on PUK information.
        /// </summary>
        /// <param name="pukData">The unblocking PIN password.</param>
        /// <param name="newPinData">The PIN password to use after the unblocking operation.</param>
        /// <returns>A task containing SimPinResult information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when either of pukData or newPinData is passed as null.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimPinResult> SimVerifyPuks(SimPinData pukData, SimPinData newPinData)
        {
            TaskCompletionSource<SimPinResult> task = new TaskCompletionSource<SimPinResult>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in verifying SIM puks: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in verifying SIM puks, " + (SimAccessResult)result));
                        return;
                    }

                    SimPinResultStruct info = Marshal.PtrToStructure<SimPinResultStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimPinResultStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (pukData == null || newPinData == null)
            {
                throw new ArgumentNullException("SIM PIN/PUK data is null");
            }

            SimPinDataStruct pukStruct = SimClassConversions.ConvertSimPinData(pukData);
            SimPinDataStruct pinStruct = SimClassConversions.ConvertSimPinData(newPinData);
            int ret = Interop.Tapi.Sim.SimVerifyPuks(_handle, ref pukStruct, ref pinStruct, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to verify SIM puks, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Changes the PIN1/PIN2 code based on the PIN type passed along with old PIN data and new PIN data.
        /// </summary>
        /// <param name="oldPin">The old PIN code entered by the user.</param>
        /// <param name="newPin">The new PIN code entered by the user.</param>
        /// <returns>A task containing SimPinResult information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when either of oldPin or newPin is passed as null.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimPinResult> SimChangePins(SimPinData oldPin, SimPinData newPin)
        {
            TaskCompletionSource<SimPinResult> task = new TaskCompletionSource<SimPinResult>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in changing SIM pins: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in changing SIM pins, " + (SimAccessResult)result));
                        return;
                    }

                    SimPinResultStruct info = Marshal.PtrToStructure<SimPinResultStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimPinResultStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (oldPin == null || newPin == null)
            {
                throw new ArgumentNullException("Old/new PIN data is null");
            }

            SimPinDataStruct oldPinStruct = SimClassConversions.ConvertSimPinData(oldPin);
            SimPinDataStruct newPinStruct = SimClassConversions.ConvertSimPinData(newPin);
            int ret = Interop.Tapi.Sim.SimChangePins(_handle, ref oldPinStruct, ref newPinStruct, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to change SIM pins, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Disables the SIM facility.
        /// </summary>
        /// <param name="facility">An object which contains the facility type and password.</param>
        /// <returns>A task containing SIM facility result information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when SIM facility info is passed as null.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimFacilityResult> SimDisableFacility(SimFacility facility)
        {
            TaskCompletionSource<SimFacilityResult> task = new TaskCompletionSource<SimFacilityResult>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in disabling SIM facility: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in disabling SIM facility, " + (SimAccessResult)result));
                        return;
                    }

                    SimFacilityResultStruct info = Marshal.PtrToStructure<SimFacilityResultStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimFacilityResultStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (facility == null)
            {
                throw new ArgumentNullException("SIM facility info is null");
            }

            SimFacilityStruct facilityStruct = SimClassConversions.ConvertSimFacility(facility);
            int ret = Interop.Tapi.Sim.SimDisableFacility(_handle, ref facilityStruct, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to disable SIM facility, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Enables the SIM facility.
        /// </summary>
        /// <param name="facility">An object which contains the facility type and password.</param>
        /// <returns>A task containing SIM facility result information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when SIM facility info is passed as null.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimFacilityResult> SimEnableFacility(SimFacility facility)
        {
            TaskCompletionSource<SimFacilityResult> task = new TaskCompletionSource<SimFacilityResult>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in enabling SIM facility: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in enabling SIM facility, " + (SimAccessResult)result));
                        return;
                    }

                    SimFacilityResultStruct info = Marshal.PtrToStructure<SimFacilityResultStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimFacilityResultStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (facility == null)
            {
                throw new ArgumentNullException("SIM facility info is null");
            }

            SimFacilityStruct facilityStruct = SimClassConversions.ConvertSimFacility(facility);
            int ret = Interop.Tapi.Sim.SimEnableFacility(_handle, ref facilityStruct, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to enable SIM facility, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets the SIM facility.
        /// </summary>
        /// <param name="lockType">The type of security lock.</param>
        /// <returns>A task containing SIM facility information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimFacilityInfo> SimGetFacility(SimLockType lockType)
        {
            TaskCompletionSource<SimFacilityInfo> task = new TaskCompletionSource<SimFacilityInfo>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting SIM facility: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting SIM facility, " + (SimAccessResult)result));
                        return;
                    }

                    SimFacilityInfoStruct info = Marshal.PtrToStructure<SimFacilityInfoStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimFacilityInfoStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetFacility(_handle, lockType, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get SIM facility, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets SIM lock type info.
        /// </summary>
        /// <param name="lockType">The type of security lock.</param>
        /// <returns>A task containing SIM lock information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimLockInfo> SimGetLockInfo(SimLockType lockType)
        {
            TaskCompletionSource<SimLockInfo> task = new TaskCompletionSource<SimLockInfo>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting SIM lock info: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting SIM lock info, " + (SimAccessResult)result));
                        return;
                    }

                    SimLockInfoStruct info = Marshal.PtrToStructure<SimLockInfoStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimLockInfoStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetLockInfo(_handle, lockType, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get SIM lock info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Sets the SIM power state.
        /// </summary>
        /// <param name="state">The state of SIM to be set.</param>
        /// <returns>A task indicating whether setting SIM power state is done or not.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<bool> SimSetPowerState(SimPowerState state)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimPowerSetResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in setting SIM power state: " + (SimPowerSetResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in setting SIM power state, " + (SimPowerSetResult)result));
                        return;
                    }

                    task.SetResult(true);
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimSetPowerState(_handle, state, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to set SIM power state, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Provides a common interface for accessing SIM data.
        /// </summary>
        /// <param name="apdu">The APDU data.</param>
        /// <returns>A task containing SIM APDU response information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when SIM APDU is passed as null.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimApduResponse> SimRequestApdu(SimApdu apdu)
        {
            TaskCompletionSource<SimApduResponse> task = new TaskCompletionSource<SimApduResponse>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in requesting SIM APDU: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in requesting SIM APDU, " + (SimAccessResult)result));
                        return;
                    }

                    SimApduResponseStruct info = Marshal.PtrToStructure<SimApduResponseStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimApduResponseStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (apdu == null)
            {
                throw new ArgumentNullException("SIM APDU is null");
            }

            SimApduStruct apduStruct = SimClassConversions.ConvertSimApdu(apdu);
            int ret = Interop.Tapi.Sim.SimRequestApdu(_handle, ref apduStruct, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to request SIM APDU, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Provides a common interface to get the SIM ATR(Answer To Reset) value.
        /// </summary>
        /// <returns>A task containing SIM ATR response information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimAtrResponse> SimRequestAtr()
        {
            TaskCompletionSource<SimAtrResponse> task = new TaskCompletionSource<SimAtrResponse>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in requesting SIM ATR: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in requesting SIM ATR, " + (SimAccessResult)result));
                        return;
                    }

                    SimAtrResponseStruct info = Marshal.PtrToStructure<SimAtrResponseStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimAtrResponseStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimRequestAtr(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to request SIM ATR, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets the IMPI(IMS private user identity). (ISIM only).
        /// </summary>
        /// <returns>A task containing IMPI string.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<string> SimGetImpi()
        {
            TaskCompletionSource<string> task = new TaskCompletionSource<string>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting SIM IMPI: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting SIM IMPI, " + (SimAccessResult)result));
                        return;
                    }

                    task.SetResult(Marshal.PtrToStringAnsi(data));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetImpi(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get SIM IMPI, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets the IMPU(IMS public user identity). (ISIM only).
        /// </summary>
        /// <returns>A task containing SIM IMPU list information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimImpuList> SimGetImpu()
        {
            TaskCompletionSource<SimImpuList> task = new TaskCompletionSource<SimImpuList>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting SIM IMPU: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting SIM IMPU, " + (SimAccessResult)result));
                        return;
                    }

                    SimImpuListStruct info = Marshal.PtrToStructure<SimImpuListStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimImpuListStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetImpu(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get SIM IMPU, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets the Domain(Home Network Domain Name). (ISIM only)
        /// </summary>
        /// <returns>A task containing domain string.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<string> SimGetDomain()
        {
            TaskCompletionSource<string> task = new TaskCompletionSource<string>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting SIM domain: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting SIM domain, " + (SimAccessResult)result));
                        return;
                    }

                    task.SetResult(Marshal.PtrToStringAnsi(data));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetDomain(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get SIM domain, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets the P-CSCF(Proxy Call Session Control Function). (ISIM only)
        /// </summary>
        /// <returns>A task containing SIM PCSCF list information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SimPcscfList> SimGetPcscf()
        {
            TaskCompletionSource<SimPcscfList> task = new TaskCompletionSource<SimPcscfList>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting SIM PCSCF: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting SIM PCSCF, " + (SimAccessResult)result));
                        return;
                    }

                    SimPcscfListStruct info = Marshal.PtrToStructure<SimPcscfListStruct>(data);
                    task.SetResult(SimStructConversions.ConvertSimPcscfListStruct(info));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetPcscf(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get SIM PCSCF, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets the ISIM service table. (ISIM only).
        /// </summary>
        /// <returns>A task containing a byte array in which mask value of SimIsimService enum will be stored.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<byte[]> SimGetIsimServiceTable()
        {
            TaskCompletionSource<byte[]> task = new TaskCompletionSource<byte[]>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SimAccessResult.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting ISIM service table: " + (SimAccessResult)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting ISIM service table, " + (SimAccessResult)result));
                        return;
                    }

                    task.SetResult(Encoding.ASCII.GetBytes(Marshal.PtrToStringAnsi(data)));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Sim.SimGetIsimServiceTable(_handle, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get ISIM service table, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }
    }
}

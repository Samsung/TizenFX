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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Tizen.Tapi
{
    /// <summary>
    /// This class provides functions to manage call related setup and methods.
    /// </summary>
    public class Call
    {
        private IntPtr _handle;
        private Dictionary<IntPtr, Interop.Tapi.TapiResponseCallback> _response_map = new Dictionary<IntPtr, Interop.Tapi.TapiResponseCallback>();
        private Interop.Tapi.CallStatusCallback _callStatusCb;
        private int _requestId = 0;

        /// <summary>
        /// A public constructor for Call class to create a Call instance for the given tapi handle.
        /// </summary>
        /// <param name="handle">The tapi handle.</param>
        public Call(TapiHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException("TapiHandle parameter is null");
            }

            _handle = handle._handle;
        }

        /// <summary>
        /// Setup the call to be dialled asynchronously.
        /// </summary>
        /// <param name="info">Information of call type and number.</param>
        /// <returns>A task indicating whether the DialCall method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>
        /// Register the telephony event with proper Notification enum value which is to be listened using RegisterNotiEvent.
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when CallInformation argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task DialCall(CallInformation info)
        {
            if (info != null)
            {
                TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
                IntPtr id;
                id = (IntPtr)_requestId++;
                _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
                {
                    Task resultTask = new Task(() =>
                    {
                        if (result != (int)TapiError.Success)
                        {
                            Log.Error(TapiUtility.LogTag, "Error occurs during call dial setup, " + (TapiError)result);
                            task.SetException(new InvalidOperationException("Error occurs during call dial setup, " + (TapiError)result));
                            return;
                        }

                        task.SetResult(true);
                    });

                    resultTask.Start();
                    resultTask.Wait();
                    _response_map.Remove(key);
                };

                CallInformationStruct callInfoStruct = CallClassConversions.ConvertCallInformationToStruct(info);
                int ret = Interop.Tapi.Call.DialCall(_handle, ref callInfoStruct, _response_map[id], id);
                if (ret != (int)TapiError.Success)
                {
                    Log.Error(TapiUtility.LogTag, "Failed to dial call and do the call setup, Error: " + (TapiError)ret);
                    TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
                }

                return task.Task;
            }

            else
            {
                throw new ArgumentNullException("CallInformation argument is null");
            }
        }

        /// <summary>
        /// Supports answering the incoming call by accepting or rejecting the call asynchronously.
        /// </summary>
        /// <param name="callHandle">Unique handle that refer to the call.</param>
        /// <param name="type">The answer type.</param>
        /// <returns>The call id of answer call. This call handle is available to the application through an incoming call(IncomingVoiceCall) event.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>
        /// There can be a maximum of one existing call.
        /// Register the telephony event with proper Notification enum value which is to be listened using RegisterNotiEvent.
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task<uint> AnswerCall(uint callHandle, CallAnswerType type)
        {
            TaskCompletionSource<uint> task = new TaskCompletionSource<uint>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during answering call, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during answering call, " + (TapiError)result));
                        return;
                    }

                    CallOperationsStruct ansStruct = Marshal.PtrToStructure<CallOperationsStruct>(data);
                    task.SetResult(ansStruct.id);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Call.AnswerCall(_handle, callHandle, type, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to answer the incoming call, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Releases the call asynchronously irrespective of whether the call is in the hold or active state.
        /// </summary>
        /// <param name="callHandle">Unique handle that refer to the call.</param>
        /// <param name="type">The end call type.</param>
        /// <returns>Instance of CallEndData.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>
        /// There should be an existing call in the active/hold state.
        /// Register the telephony event with proper Notification enum value which is to be listened using RegisterNotiEvent.
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task<CallEndData> EndCall(uint callHandle, CallEndType type)
        {
            TaskCompletionSource<CallEndData> task = new TaskCompletionSource<CallEndData>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during ending call, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during ending call, " + (TapiError)result));
                        return;
                    }

                    CallEndStruct endStruct = Marshal.PtrToStructure<CallEndStruct>(data);
                    CallEndData endDataClass = new CallEndData(endStruct.type, endStruct.id);
                    task.SetResult(endDataClass);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Call.EndCall(_handle, callHandle, type, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to end the call, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Puts the given call on hold asynchoronously.
        /// </summary>
        /// <param name="callHandle">Unique handle for referring the call.</param>
        /// <returns>The call id of hold call.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>
        /// The call should be in the active state.
        /// Register the telephony event with proper Notification enum value which is to be listened using RegisterNotiEvent.
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task<uint> HoldCall(uint callHandle)
        {
            TaskCompletionSource<uint> task = new TaskCompletionSource<uint>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during putting call on hold, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during putting call on hold, " + (TapiError)result));
                        return;
                    }

                    CallOperationsStruct holdStruct = Marshal.PtrToStructure<CallOperationsStruct>(data);
                    task.SetResult(holdStruct.id);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Call.HoldCall(_handle, callHandle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to put the call on hold, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Retrieves the call being held asynchoronously.
        /// </summary>
        /// <param name="callHandle">Unique handle for referring the call.</param>
        /// <returns>The call id of active call.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>
        /// Call should be in the held state in order to retrieve it into the active state unless no active call is present.
        /// Register the telephony event with proper Notification enum value which is to be listened using RegisterNotiEvent.
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task<uint> ActiveCall(uint callHandle)
        {
            TaskCompletionSource<uint> task = new TaskCompletionSource<uint>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during retrieving the hold call, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during retrieving the hold call, " + (TapiError)result));
                        return;
                    }

                    CallOperationsStruct activeStruct = Marshal.PtrToStructure<CallOperationsStruct>(data);
                    task.SetResult(activeStruct.id);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Call.ActiveCall(_handle, callHandle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to retrieve the call which was on hold, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Swaps calls asynchoronously. This is only for calls dialed or answered with Telephony.
        /// </summary>
        /// <param name="activeCallHandle">Active call.</param>
        /// <param name="heldCallHandle">Held call.</param>
        /// <returns>The call id of swap call.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>
        /// Register the telephony event with proper Notification enum value which is to be listened using RegisterNotiEvent.
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task<uint> SwapCall(uint activeCallHandle, uint heldCallHandle)
        {
            TaskCompletionSource<uint> task = new TaskCompletionSource<uint>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during swapping calls, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during swapping calls, " + (TapiError)result));
                        return;
                    }

                    CallOperationsStruct activeStruct = Marshal.PtrToStructure<CallOperationsStruct>(data);
                    task.SetResult(activeStruct.id);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Call.SwapCall(_handle, activeCallHandle, heldCallHandle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to swap the active and held calls, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Starts continuous dtmf by sending a single digit during the call asynchronously.
        /// </summary>
        /// <param name="digit">The dtmf digit to be sent.</param>
        /// <returns>A task indicating whether the StartContDtmfCall method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks> An active call should be present. This is to be invoked in the following cases:
        /// i. Key Release (post key press) during on-going call.
        /// ii. Dtmf digits passed with PAUSE(,) or WAIT(;).
        /// In case of PAUSE and WAIT, every StartContDtmfCall() call needs to be followed by StopContDtmfCall() sequentially (for every digit) without waiting for response from StartContDtmfCall().
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task StartContDtmfCall(byte digit)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during starting continuous dtmf, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during starting continuous dtmf, " + (TapiError)result));
                        return;
                    }

                    task.SetResult(true);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Call.StartContDtmfCall(_handle, digit, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to start continuous dtmf during the call, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Stops continuous dtmf during the call asynchronously.
        /// </summary>
        /// <returns>A task indicating whether the StopContDtmfCall method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks> An active call should be present. This is to be invoked in the following cases:
        /// i. Key Release (post key press) during on-going call.
        /// ii. Dtmf digits passed with PAUSE(,) or WAIT(;).
        /// Every StartContDtmfCall() call needs to be followed by StopContDtmfCall() sequentially.
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task StopContDtmfCall()
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during stopping continuous dtmf, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during stopping continuous dtmf, " + (TapiError)result));
                        return;
                    }

                    task.SetResult(true);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Call.StopContDtmfCall(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to stop continuous dtmf during the call, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Send one or more dtmf digits during the call asynchronously.
        /// </summary>
        /// <param name="dtmfData">A burst dtmf info containing dtmf string, pulse width, and inter digit interval.</param>
        /// <returns>A task indicating whether the SendBurstDtmfCall method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>
        /// There will be a single asynchronous notification for all the dtmf digits sent. If the users of this API need an asynchronous
        /// response for each dtmf digit then the user has to call this API multiple times passing each single dtmf digit in CallBurstDtmfData.
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when CallBurstDtmfData argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task SendBurstDtmfCall(CallBurstDtmfData dtmfData)
        {
            if (dtmfData != null)
            {
                TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
                IntPtr id;
                id = (IntPtr)_requestId++;
                _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
                {
                    Task resultTask = new Task(() =>
                    {
                        if (result != (int)TapiError.Success)
                        {
                            Log.Error(TapiUtility.LogTag, "Error occurs while sending dtmf digits, " + (TapiError)result);
                            task.SetException(new InvalidOperationException("Error occurs while sending dtmf digits, " + (TapiError)result));
                            return;
                        }

                        task.SetResult(true);
                    });

                    resultTask.Start();
                    resultTask.Wait();
                    _response_map.Remove(key);
                };

                CallBurstDtmfStruct callBurstStruct = CallClassConversions.ConvertCallBurstToStruct(dtmfData);
                int ret = Interop.Tapi.Call.SendBurstDtmfCall(_handle, ref callBurstStruct, _response_map[id], id);
                if (ret != (int)TapiError.Success)
                {
                    Log.Error(TapiUtility.LogTag, "Failed to send dtmf digits during the call, Error: " + (TapiError)ret);
                    TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
                }

                return task.Task;
            }

            else
            {
                throw new ArgumentNullException("CallBurstDtmfData argument is null");
            }
        }

        /// <summary>
        /// Joins the given two calls (one call in the active conversation state and the other call in the held state) into conference asynchronously.
        /// </summary>
        /// <param name="activeCallhandle">Unique handle which is either an active call or a held call.</param>
        /// <param name="callHandle">Unique call handle.</param>
        /// <returns>The call id of join call.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>
        /// For a multiparty call or for joining two calls into conference, there should be one call in the active state and another call in the held state.
        /// Register the telephony event with proper Notification enum value which is to be listened using RegisterNotiEvent.
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task<uint> JoinCall(uint activeCallhandle, uint callHandle)
        {
            TaskCompletionSource<uint> task = new TaskCompletionSource<uint>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during joining the two calls, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during joining the two calls, " + (TapiError)result));
                        return;
                    }

                    CallOperationsStruct joinStruct = Marshal.PtrToStructure<CallOperationsStruct>(data);
                    task.SetResult(joinStruct.id);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Call.JoinCall(_handle, activeCallhandle, callHandle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to join the given two calls into conference, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Triggers splitting a private call from a multiparty call asynchronously.
        /// </summary>
        /// <param name="callHandle">The handle of the call to be made private. The call handle referring to the call that is to be split from the conference.</param>
        /// <returns>The call id of split call.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>
        /// The call should be in a multiparty conference call.The split call will be the active call and the conference call will be the held call.
        /// Register the telephony event with proper Notification enum value which is to be listened using RegisterNotiEvent.
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task<uint> SplitCall(uint callHandle)
        {
            TaskCompletionSource<uint> task = new TaskCompletionSource<uint>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during splitting a private call from a multiparty call, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during splitting a private call from a multiparty call, " + (TapiError)result));
                        return;
                    }

                    CallOperationsStruct splitStruct = Marshal.PtrToStructure<CallOperationsStruct>(data);
                    task.SetResult(splitStruct.id);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Call.SplitCall(_handle, callHandle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to split a private call from a multiparty call, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Triggers making an explicit call transfer by connecting the two parties where one party is being active(active state) and another party is being held(held state) asynchronously.
        /// </summary>
        /// <param name="activeCallHandle">The call handle of an active call.</param>
        /// <returns>The call id of transferred call.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>
        /// In order to transfer call, served mobile subscriber should have 2 calls, one in the active state and another one in the held state.
        /// Register the telephony event with proper Notification enum value which is to be listened using RegisterNotiEvent.
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task<uint> TransferCall(uint activeCallHandle)
        {
            TaskCompletionSource<uint> task = new TaskCompletionSource<uint>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during transferring call, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during transferring call, " + (TapiError)result));
                        return;
                    }

                    CallOperationsStruct splitStruct = Marshal.PtrToStructure<CallOperationsStruct>(data);
                    task.SetResult(splitStruct.id);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Call.TransferCall(_handle, activeCallHandle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to make explicit call transfer by connecting two calls - active call and held call, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Redirects the incoming call to another subscriber asynchronously.
        /// </summary>
        /// <param name="incomingCallHandle">Incoming call handle.</param>
        /// <param name="destinationNumber">The destination number.</param>
        /// <returns>A task indicating whether the DeflectCall method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>Register the telephony event with proper Notification enum value which is to be listened using RegisterNotiEvent.</remarks>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.ArgumentException">Thrown when destinationNumber argument is invalid.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task DeflectCall(uint incomingCallHandle, byte[] destinationNumber)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            CallDeflectDestStruct deflectStruct = CallClassConversions.ConvertByteDestinationToStruct(destinationNumber);
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during deflecting incoming call, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during deflecting incoming call, " + (TapiError)result));
                        return;
                    }

                    task.SetResult(true);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
                Marshal.FreeHGlobal(deflectStruct.DestinationNumber);
            };

            int ret = Interop.Tapi.Call.DeflectCall(_handle, incomingCallHandle, ref deflectStruct, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to redirect the incoming call to another subscriber, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets the status of the current call.
        /// </summary>
        /// <param name="callId">A unique handle for referring the call.</param>
        /// <returns>The call status information like destination number, call direction, call type, whether call is in the conference state or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public CallStatus GetCallStatus(int callId)
        {
            CallStatusStruct statusStruct;
            int ret = Interop.Tapi.Call.GetCallStatus(_handle, callId, out statusStruct);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the status of the current call, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            CallStatus statusData = CallStructConversions.ConvertStatusStruct(statusStruct);
            return statusData;
        }

        /// <summary>
        /// Get the list of status of the current call.
        /// </summary>
        /// <returns>List of CallStatus.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public IEnumerable<CallStatus> GetAllCallStatus()
        {
            List<CallStatus> callStatusList = new List<CallStatus>();
            _callStatusCb = (ref CallStatusStruct info, IntPtr userData) =>
            {
                if (!info.Equals(null))
                {
                    callStatusList.Add(CallStructConversions.ConvertStatusStruct(info));
                }
            };

            int ret = Interop.Tapi.Call.GetAllCallStatus(_handle, _callStatusCb, IntPtr.Zero);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get all status of the current call, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return callStatusList;
        }

        /// <summary>
        /// Get the call volume asynchronously.
        /// </summary>
        /// <param name="device">The sound device.</param>
        /// <param name="type">The sound type.</param>
        /// <returns>Instance of CallVolumeInfo.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task<CallVolumeInfo> GetCallVolumeInfo(SoundDevice device, SoundType type)
        {
            TaskCompletionSource<CallVolumeInfo> task = new TaskCompletionSource<CallVolumeInfo>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting the call volume, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting the call volume, " + (TapiError)result));
                        return;
                    }

                    CallVolumeStruct volumeStruct = Marshal.PtrToStructure<CallVolumeStruct>(data);
                    CallVolumeInfo volumeInfo = CallStructConversions.ConvertVolumeStruct(volumeStruct);
                    task.SetResult(volumeInfo);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Call.GetCallVolumeInfo(_handle, device, type, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the call volume, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Set the call volume asynchronously.
        /// </summary>
        /// <param name="record">The call volume information.</param>
        /// <returns>A task indicating whether the SetCallVolumeInfo method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when CallVolumeRecord argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task SetCallVolumeInfo(CallVolumeRecord record)
        {
            if (record != null)
            {
                TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
                IntPtr id;
                id = (IntPtr)_requestId++;
                _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
                {
                    Task resultTask = new Task(() =>
                    {
                        if (result != (int)TapiError.Success)
                        {
                            Log.Error(TapiUtility.LogTag, "Error occurs during setting the call volume, " + (TapiError)result);
                            task.SetException(new InvalidOperationException("Error occurs during setting the call volume, " + (TapiError)result));
                            return;
                        }

                        task.SetResult(true);
                    });

                    resultTask.Start();
                    resultTask.Wait();
                    _response_map.Remove(key);
                };

                CallVolumeRecordStruct volumeStruct = CallClassConversions.ConvertVolumeRecordToStruct(record);
                int ret = Interop.Tapi.Call.SetCallVolumeInfo(_handle, ref volumeStruct, _response_map[id], id);
                if (ret != (int)TapiError.Success)
                {
                    Log.Error(TapiUtility.LogTag, "Failed to set the call volume, Error: " + (TapiError)ret);
                    TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
                }

                return task.Task;
            }

            else
            {
                throw new ArgumentNullException("CallVolumeRecord argument is null");
            }
        }

        /// <summary>
        /// Set the call sound path asynchronously.
        /// </summary>
        /// <param name="path">The call sound path information.</param>
        /// <returns>A task indicating whether the SetCallSoundPath method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when CallSoundPathInfo argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task SetCallSoundPath(CallSoundPathInfo path)
        {
            if (path != null)
            {
                TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
                IntPtr id;
                id = (IntPtr)_requestId++;
                _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
                {
                    Task resultTask = new Task(() =>
                    {
                        if (result != (int)TapiError.Success)
                        {
                            Log.Error(TapiUtility.LogTag, "Error occurs during setting the call sound path, " + (TapiError)result);
                            task.SetException(new InvalidOperationException("Error occurs during setting the call sound path, " + (TapiError)result));
                            return;
                        }

                        task.SetResult(true);
                    });

                    resultTask.Start();
                    resultTask.Wait();
                    _response_map.Remove(key);
                };

                CallSoundPathStruct pathStruct = CallClassConversions.ConvertSoundPathToStruct(path);
                int ret = Interop.Tapi.Call.SetCallSoundPath(_handle, ref pathStruct, _response_map[id], id);
                if (ret != (int)TapiError.Success)
                {
                    Log.Error(TapiUtility.LogTag, "Failed to set the call sound path, Error: " + (TapiError)ret);
                    TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
                }

                return task.Task;
            }

            else
            {
                throw new ArgumentNullException("CallSoundPathInfo argument is null");
            }
        }

        /// <summary>
        /// Set the call mute state asynchronously.
        /// </summary>
        /// <param name="record">The call mute status information.</param>
        /// <returns>A task indicating whether the SetCallMuteStatus method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when CallMuteStatusRecord argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task SetCallMuteStatus(CallMuteStatusRecord record)
        {
            if (record != null)
            {
                TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
                IntPtr id;
                id = (IntPtr)_requestId++;
                _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
                {
                    Task resultTask = new Task(() =>
                    {
                        if (result != (int)TapiError.Success)
                        {
                            Log.Error(TapiUtility.LogTag, "Error occurs during setting the call mute state, " + (TapiError)result);
                            task.SetException(new InvalidOperationException("Error occurs during setting the call mute state, " + (TapiError)result));
                            return;
                        }

                        task.SetResult(true);
                    });

                    resultTask.Start();
                    resultTask.Wait();
                    _response_map.Remove(key);
                };

                int ret = Interop.Tapi.Call.SetCallMuteStatus(_handle, record.Status, record.Path, _response_map[id], id);
                if (ret != (int)TapiError.Success)
                {
                    Log.Error(TapiUtility.LogTag, "Failed to set the call mute state, Error: " + (TapiError)ret);
                    TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
                }

                return task.Task;
            }

            else
            {
                throw new ArgumentNullException("CallMuteStatusRecord argument is null");
            }
        }

        /// <summary>
        /// Get the call mute state asynchronously.
        /// </summary>
        /// <returns>Instance of CallMuteStatusRecord.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task<CallMuteStatusRecord> GetCallMuteStatus()
        {
            TaskCompletionSource<CallMuteStatusRecord> task = new TaskCompletionSource<CallMuteStatusRecord>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting the call mute state, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting the call mute state, " + (TapiError)result));
                        return;
                    }

                    CallMuteStatusStruct muteStruct = Marshal.PtrToStructure<CallMuteStatusStruct>(data);
                    CallMuteStatusRecord muteStatusRecord = new CallMuteStatusRecord(muteStruct.Path, muteStruct.Status);
                    task.SetResult(muteStatusRecord);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Call.GetCallMuteStatus(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the call mute state, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Get the voice privacy mode in the phone asynchronously.
        /// </summary>
        /// <returns>CallPrivacyMode value.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>Register the telephony event with proper Notification enum value which is to be listened using RegisterNotiEvent.</remarks>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task<CallPrivacyMode> GetCallPrivacyMode()
        {
            TaskCompletionSource<CallPrivacyMode> task = new TaskCompletionSource<CallPrivacyMode>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting the voice privacy mode, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting the voice privacy mode, " + (TapiError)result));
                        return;
                    }

                    CallPrivacyModeStruct privacyStruct = Marshal.PtrToStructure<CallPrivacyModeStruct>(data);
                    CallPrivacyMode mode = privacyStruct.Mode;
                    task.SetResult(mode);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Call.GetCallMuteStatus(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the voice privacy mode in the phone, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Set the voice privacy mode in the phone asynchronously. It is available only where a call exists.
        /// </summary>
        /// <param name="mode">Voice privacy option mode value.</param>
        /// <returns>A task indicating whether the SetCallPrivacyMode method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>Register the telephony event with proper Notification enum value which is to be listened using RegisterNotiEvent.</remarks>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task SetCallPrivacyMode(CallPrivacyMode mode)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during setting the voice privacy mode, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during setting the voice privacy mode, " + (TapiError)result));
                        return;
                    }

                    task.SetResult(true);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Call.SetCallPrivacyMode(_handle, mode, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to set the voice privacy mode, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Set the preferred voice subscription asynchronously.
        /// </summary>
        /// <param name="subscription">Preferred voice subscription value.</param>
        /// <returns>A task indicating whether the SetCallPreferredVoiceSubscription method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public Task SetCallPreferredVoiceSubscription(CallPreferredVoiceSubscription subscription)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during setting preferred voice subscription, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during setting preferred voice subscription, " + (TapiError)result));
                        return;
                    }

                    task.SetResult(true);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Call.SetCallPreferredVoiceSubs(_handle, subscription, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to set preferred voice subscription, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Get the preferred voice subscription.
        /// </summary>
        /// <returns>CallPreferredVoiceSubscription value.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when call instance is invalid or when method failed due to invalid operation.</exception>
        public CallPreferredVoiceSubscription GetCallPreferredVoiceSubscription()
        {
            CallPreferredVoiceSubscription subscription;
            int ret = Interop.Tapi.Call.GetCallPreferredVoiceSubs(_handle, out subscription);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get preferred voice subscription, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return subscription;
        }
    }
}

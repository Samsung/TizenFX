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
    /// A class which manages Supplementary Services of the SIM.
    /// </summary>
    public class Ss
    {
        private IntPtr _handle = IntPtr.Zero;
        private Dictionary<IntPtr, Interop.Tapi.TapiResponseCallback> _callbackMap = new Dictionary<IntPtr, Interop.Tapi.TapiResponseCallback>();
        private int _requestId = 0;
        private Ss()
        {
        }

        /// <summary>
        /// A constructor to instantiate Ss class using the Tapi handle.
        /// </summary>
        /// <param name="handle">An instance of TapiHandle obtained from InitTapi in TapiManager API.</param>
        /// <exception cref="ArgumentNullException">Thrown when handle is passed as null.</exception>
        public Ss(TapiHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException("Handle is null");
            }

            _handle = handle._handle;
        }

        /// <summary>
        /// Sends a request to activate/deactivate call barring.
        /// </summary>
        /// <param name="info">The information about call barring.</param>
        /// <returns>A task containing an instance of SsBarringResponse which contains information about barring response.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when barring info is passed as null.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SsBarringResponse> SsSetBarring(SsBarringInfo info)
        {
            TaskCompletionSource<SsBarringResponse> task = new TaskCompletionSource<SsBarringResponse>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SsCause.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during setting SS barring info: " + (SsCause)result);
                        task.SetException(new InvalidOperationException("Error occurs during setting SS barring info, " + (SsCause)result));
                        return;
                    }

                    SsBarringResponseStruct response = Marshal.PtrToStructure<SsBarringResponseStruct>(data);
                    task.SetResult(SsStructConversions.ConvertBarringRspStruct(response));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (info == null)
            {
                throw new ArgumentNullException("Ss barring info is null");
            }

            SsBarringInfoStruct infoStruct = SsClassConversions.ConvertSsBarringInfo(info);
            int ret = Interop.Tapi.Ss.SsSetBarring(_handle, ref infoStruct, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to set barring info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets call barring status.
        /// </summary>
        /// <param name="ssClass">The type of call.</param>
        /// <param name="type">The barring type.</param>
        /// <returns>A task containing information about barring response.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SsBarringResponse> SsGetBarringStatus(SsClass ssClass, SsBarringType type)
        {
            TaskCompletionSource<SsBarringResponse> task = new TaskCompletionSource<SsBarringResponse>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SsCause.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting barring status: " + (SsCause)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting barring status, " + (SsCause)result));
                        return;
                    }

                    SsBarringResponseStruct response = Marshal.PtrToStructure<SsBarringResponseStruct>(data);
                    task.SetResult(SsStructConversions.ConvertBarringRspStruct(response));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Ss.SsGetBarringStatus(_handle, ssClass, type, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get barring status, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Allows changing of the barring password in the network.
        /// </summary>
        /// <param name="oldPassword">The old password set for Barring in the Network.</param>
        /// <param name="newPassword">The new password set for Barring in the Network.</param>
        /// <param name="newPasswordAgain">The new password again.</param>
        /// <returns>A task indicating whether the change of password is done or not.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when any of the parameter is passed as null.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<bool> SsChangeBarringPassword(string oldPassword, string newPassword, string newPasswordAgain)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SsCause.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in changing barring password: " + (SsCause)result);
                        task.SetException(new InvalidOperationException("Error occurs in changing barring password, " + (SsCause)result));
                        return;
                    }

                    task.SetResult(true);
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (oldPassword == null || newPassword == null || newPasswordAgain == null)
            {
                throw new ArgumentNullException("Old password/new password is null");
            }

            int ret = Interop.Tapi.Ss.SsChangeBarringPassword(_handle, oldPassword, newPassword, newPasswordAgain, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to change barring password, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Allows to set the (register/erase/activate/deactivate) call forwarding option at the network.
        /// </summary>
        /// <param name="info">The Call forward information such as a forward mode, a forward type, and so on.</param>
        /// <returns>A task containing information about SS forward response.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when forward info is passed as null.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SsForwardResponse> SsSetForwardInfo(SsForwardInfo info)
        {
            TaskCompletionSource<SsForwardResponse> task = new TaskCompletionSource<SsForwardResponse>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SsCause.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in setting SS forward info: " + (SsCause)result);
                        task.SetException(new InvalidOperationException("Error occurs in setting SS forward info, " + (SsCause)result));
                        return;
                    }

                    SsForwardResponseStruct response = Marshal.PtrToStructure<SsForwardResponseStruct>(data);
                    task.SetResult(SsStructConversions.ConvertForwardRspStruct(response));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (info == null)
            {
                throw new ArgumentNullException("Ss forward info is null");
            }

            SsForwardInfoStruct infoStruct = SsClassConversions.ConvertSsForwardInfo(info);
            int ret = Interop.Tapi.Ss.SsSetForward(_handle, ref infoStruct, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to set forward info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Provides an option to get the call forwarding status of different calls from the Network.
        /// </summary>
        /// <param name="ssClass">The Forward call type.</param>
        /// <param name="condition">The forward condition.</param>
        /// <returns>A task containing SS forward response information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SsForwardResponse> SsGetForwardStatus(SsClass ssClass, SsForwardCondition condition)
        {
            TaskCompletionSource<SsForwardResponse> task = new TaskCompletionSource<SsForwardResponse>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SsCause.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting SS forward status: " + (SsCause)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting SS forward status, " + (SsCause)result));
                        return;
                    }

                    SsForwardResponseStruct response = Marshal.PtrToStructure<SsForwardResponseStruct>(data);
                    task.SetResult(SsStructConversions.ConvertForwardRspStruct(response));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Ss.SsGetForwardStatus(_handle, ssClass, condition, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get forward status, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Activates/deactivates the call waiting service.
        /// </summary>
        /// <param name="info">The status of call-waiting service.</param>
        /// <returns>A task containing SS waiting response information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when waiting info is passed as null.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SsWaitingResponse> SsSetWaitingInfo(SsWaitingInfo info)
        {
            TaskCompletionSource<SsWaitingResponse> task = new TaskCompletionSource<SsWaitingResponse>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SsCause.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in setting SS waiting info: " + (SsCause)result);
                        task.SetException(new InvalidOperationException("Error occurs in setting SS waiting info, " + (SsCause)result));
                        return;
                    }

                    SsWaitingResponseStruct response = Marshal.PtrToStructure<SsWaitingResponseStruct>(data);
                    task.SetResult(SsStructConversions.ConvertWaitingRspStruct(response));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (info == null)
            {
                throw new ArgumentNullException("Ss waiting info is null");
            }

            SsWaitingInfoStruct infoStruct = SsClassConversions.ConvertSsWaitingInfo(info);
            int ret = Interop.Tapi.Ss.SsSetWaiting(_handle, ref infoStruct, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to set waiting info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets the status of the call waiting service.
        /// </summary>
        /// <param name="ssClass">The call types.</param>
        /// <returns>A task containing information about SS waiting response.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SsWaitingResponse> SsGetWaitingInfo(SsClass ssClass)
        {
            TaskCompletionSource<SsWaitingResponse> task = new TaskCompletionSource<SsWaitingResponse>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SsCause.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting SS waiting info: " + (SsCause)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting SS waiting info, " + (SsCause)result));
                        return;
                    }

                    SsWaitingResponseStruct response = Marshal.PtrToStructure<SsWaitingResponseStruct>(data);
                    task.SetResult(SsStructConversions.ConvertWaitingRspStruct(response));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Ss.SsGetWaitingStatus(_handle, ssClass, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get waiting info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Activates/deactivates the status of the calling line identity service.
        /// </summary>
        /// <param name="type">The Cli service type.</param>
        /// <param name="status">The Cli Status.</param>
        /// <returns>A task indicating whether setting of CLI status is done or not.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<bool> SsSetCliStatus(SsCliType type, SsCliStatus status)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SsCause.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in setting SS CLI status: " + (SsCause)result);
                        task.SetException(new InvalidOperationException("Error occurs in setting SS CLI status, " + (SsCause)result));
                        return;
                    }

                    task.SetResult(true);
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Ss.SsSetCliStatus(_handle, type, status, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to set SS CLI status, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Gets the status of the calling line identity service.
        /// </summary>
        /// <param name="type">The Cli service type.</param>
        /// <returns>A task containing SS CLI response information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SsCliResponse> SsGetCliStatus(SsCliType type)
        {
            TaskCompletionSource<SsCliResponse> task = new TaskCompletionSource<SsCliResponse>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SsCause.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in getting SS CLI status: " + (SsCause)result);
                        task.SetException(new InvalidOperationException("Error occurs in getting SS CLI status, " + (SsCause)result));
                        return;
                    }

                    SsCliResponseStruct response = Marshal.PtrToStructure<SsCliResponseStruct>(data);
                    task.SetResult(SsStructConversions.ConvertSsCliResponseStruct(response));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            int ret = Interop.Tapi.Ss.SsGetCliStatus(_handle, type, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get CLI status, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Sends a USSD string or User response to the Network.
        /// </summary>
        /// <param name="info">The data coding scheme used</param>
        /// <returns>A task containing SS USSD response information.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when Ussd message info is passed as null.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public Task<SsUssdResponse> SsSendUssdRequest(SsUssdMsgInfo info)
        {
            TaskCompletionSource<SsUssdResponse> task = new TaskCompletionSource<SsUssdResponse>();
            IntPtr id = (IntPtr)_requestId++;
            _callbackMap[id] = (handle, result, data, key) =>
            {
                Task taskResult = new Task(() =>
                {
                    if (result != (int)SsCause.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs in sending USSD request: " + (SsCause)result);
                        task.SetException(new InvalidOperationException("Error occurs in sending USSD request, " + (SsCause)result));
                        return;
                    }

                    SsUssdResponseStruct response = Marshal.PtrToStructure<SsUssdResponseStruct>(data);
                    task.SetResult(SsStructConversions.ConvertSsUssdResponseStruct(response));
                });
                taskResult.Start();
                taskResult.Wait();
                _callbackMap.Remove(key);
            };

            if (info == null)
            {
                throw new ArgumentNullException("Ussd message info is null");
            }

            SsUssdMsgInfoStruct msgStruct = SsClassConversions.ConvertSsUssdMsgInfo(info);
            int ret = Interop.Tapi.Ss.SsSendUssdRequest(_handle, ref msgStruct, _callbackMap[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to send USSD request, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }
    }
}

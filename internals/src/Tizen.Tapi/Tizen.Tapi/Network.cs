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
    /// This class provides functions for managing telephony service network.
    /// </summary>
    public class Network
    {
        private IntPtr _handle;
        private Dictionary<IntPtr, Interop.Tapi.TapiResponseCallback> _response_map = new Dictionary<IntPtr, Interop.Tapi.TapiResponseCallback>();
        private int _requestId = 0;

        /// <summary>
        /// A public constructor for Network class to create a Network instance for the given tapi handle.
        /// </summary>
        /// <param name="handle">The tapi handle.</param>
        public Network(TapiHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException("TapiHandle parameter is null");
            }

            _handle = handle._handle;
        }

        /// <summary>
        /// Request the lower layers to select the network automatically asynchronously.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public Task SelectNetworkAutomatic()
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
                        Log.Error(TapiUtility.LogTag, "Error occurs during selecting the network, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during selecting the network, " + (TapiError)result));
                        return;
                    }

                    task.SetResult(true);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Network.SelectAutoNetwork(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to select the network automatically, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Request the lower layers to select the network which is selected by the user from the network list asynchronously.
        /// </summary>
        /// <param name="plmn">The user selected plmn.</param>
        /// <param name="act">The user selected access technology.</param>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public Task SelectNetworkManual(string plmn, int act)
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
                        Log.Error(TapiUtility.LogTag, "Error occurs during selecting the network, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during selecting the network, " + (TapiError)result));
                        return;
                    }

                    task.SetResult(true);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Network.SelectManualNetwork(_handle, plmn, act, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to select the network manually, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Sends a request to do manual search for the available networks and provides the Network List to the user asynchronously.
        /// </summary>
        /// <returns>Instance of NetworkPlmnList.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public Task<NetworkPlmnList> SearchNetwork()
        {
            TaskCompletionSource<NetworkPlmnList> task = new TaskCompletionSource<NetworkPlmnList>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr dataResponse, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during manual search for the available networks, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during manual search for the available networks, " + (TapiError)result));
                        return;
                    }

                    NetworkPlmnListStruct listStruct = Marshal.PtrToStructure<NetworkPlmnListStruct>(dataResponse);
                    NetworkPlmnList plmnClass = NetworkStructConversions.ConvertNetworkPlmnListStruct(listStruct);
                    task.SetResult(plmnClass);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Network.SearchNetwork(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to do manual search for the available networks, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Get the present network selection mode i.e. automatic or manual asynchronously.
        /// </summary>
        /// <returns>Value of NetworkSelectionMode.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public Task<NetworkSelectionMode> GetNetworkSelectionMode()
        {
            TaskCompletionSource<NetworkSelectionMode> task = new TaskCompletionSource<NetworkSelectionMode>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr dataResponse, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting the present network selection mode, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting the present network selection mode, " + (TapiError)result));
                        return;
                    }

                    task.SetResult((NetworkSelectionMode)Marshal.ReadInt32(dataResponse));
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Network.GetNetworkSelectMode(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the present network selection mode, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Set the network preferred plmn asynchronously.
        /// </summary>
        /// <param name="operation">The operation to be done on the preferred plmn.</param>
        /// <param name="info">The preferred plmn info.</param>
        /// <returns>A task indicating whether the SetNetworkPreferredPlmn method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when NetworkPreferredPlmnInfo argument is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public Task SetNetworkPreferredPlmn(NetworkPreferredPlmnOp operation, NetworkPreferredPlmnInfo info)
        {
            if (info != null)
            {
                TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
                IntPtr id;
                id = (IntPtr)_requestId++;
                _response_map[id] = (IntPtr handle, int result, IntPtr dataResponse, IntPtr key) =>
                {
                    Task resultTask = new Task(() =>
                    {
                        if (result != (int)TapiError.Success)
                        {
                            Log.Error(TapiUtility.LogTag, "Error occurs during setting the network preferred plmn, " + (TapiError)result);
                            task.SetException(new InvalidOperationException("Error occurs during setting the network preferred plmn, " + (TapiError)result));
                            return;
                        }

                        task.SetResult(true);
                    });

                    resultTask.Start();
                    resultTask.Wait();
                    _response_map.Remove(key);
                };

                NetworkPreferredPlmnStruct plmnStruct = NetworkClassConversions.ConvertNetworkPreferredPlmn(info);
                int ret = Interop.Tapi.Network.SetNetworkPreferredPlmn(_handle, operation, ref plmnStruct, _response_map[id], id);
                if (ret != (int)TapiError.Success)
                {
                    Log.Error(TapiUtility.LogTag, "Failed to set the network preferred plmn, Error: " + (TapiError)ret);
                    TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
                }

                return task.Task;
            }

            else
            {
                throw new ArgumentNullException("NetworkPreferredPlmnInfo argument is null");
            }
        }

        /// <summary>
        /// Get the preferred plmn list asynchronously.
        /// </summary>
        /// <returns>List of NetworkPreferredPlmnInfo.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public Task<IEnumerable<NetworkPreferredPlmnInfo>> GetNetworkPreferredPlmn()
        {
            TaskCompletionSource<IEnumerable<NetworkPreferredPlmnInfo>> task = new TaskCompletionSource<IEnumerable<NetworkPreferredPlmnInfo>>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr dataResponse, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting the preferred plmn list, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting the preferred plmn list, " + (TapiError)result));
                        return;
                    }

                    NetworkPreferredPlmnListStruct plmnStruct = Marshal.PtrToStructure<NetworkPreferredPlmnListStruct>(dataResponse);
                    IEnumerable<NetworkPreferredPlmnInfo> plmnInfo = NetworkStructConversions.ConvertNetworkPreferredPlmnStruct(plmnStruct);
                    task.SetResult(plmnInfo);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Network.GetNetworkPreferredPlmn(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the preferred plmn list, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Cancel the triggered manual network search asynchronously.
        /// </summary>
        /// <returns>A task indicating whether the CancelNetworkManualSearch method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public Task CancelNetworkManualSearch()
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr dataResponse, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during cancelling the network manual search, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during cancelling the network manual search, " + (TapiError)result));
                        return;
                    }

                    task.SetResult(true);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Network.CancelNetworkManualSearch(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to cancel the network manual search, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Get the network serving information asynchronously.
        /// </summary>
        /// <returns>Instance of NetworkServing.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public Task<NetworkServing> GetNetworkServing()
        {
            TaskCompletionSource<NetworkServing> task = new TaskCompletionSource<NetworkServing>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr dataResponse, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting the network serving information, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting the network serving information, " + (TapiError)result));
                        return;
                    }

                    NetworkServingStruct servStruct = Marshal.PtrToStructure<NetworkServingStruct>(dataResponse);
                    NetworkServing servingInfo = NetworkStructConversions.ConvertNetworkServingStruct(servStruct);
                    task.SetResult(servingInfo);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Network.GetNetworkServing(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the network serving information, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Set the network mode asynchronously.
        /// </summary>
        /// <param name="mode">The network mode.</param>
        /// <returns>A task indicating whether the SetNetworkMode method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public Task SetNetworkMode(NetworkMode mode)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr dataResponse, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting the network mode, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting the network mode, " + (TapiError)result));
                        return;
                    }

                    task.SetResult(true);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Network.SetNetworkMode(_handle, (int)mode, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the network mode, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Get the network mode asynchronously.
        /// </summary>
        /// <returns>Value of NetworkMode.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public Task<NetworkMode> GetNetworkMode()
        {
            TaskCompletionSource<NetworkMode> task = new TaskCompletionSource<NetworkMode>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr dataResponse, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting the network mode, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting the network mode, " + (TapiError)result));
                        return;
                    }

                    task.SetResult((NetworkMode)Marshal.ReadInt32(dataResponse));
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Network.GetNetworkMode(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the network mode, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Get the neighboring cell info asynchronously.
        /// </summary>
        /// <returns>Instance of NetworkNeighboringCell.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public Task<NetworkNeighboringCell> GetNeighborCellNetwork()
        {
            TaskCompletionSource<NetworkNeighboringCell> task = new TaskCompletionSource<NetworkNeighboringCell>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr dataResponse, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting the neigboring cell info, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting the neigboring cell info, " + (TapiError)result));
                        return;
                    }

                    NetworkNeighboringCellStruct cellStruct = Marshal.PtrToStructure<NetworkNeighboringCellStruct>(dataResponse);
                    NetworkNeighboringCell cell = NetworkStructConversions.ConvertNeighborCellStruct(cellStruct);
                    task.SetResult(cell);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Network.GetNetworkNeighborCell(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the neigboring cell info, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Enters or exits the emergency callback mode asynchronously.
        /// </summary>
        /// <param name="mode">The emergency callback mode.</param>
        /// <returns>A task indicating whether the SetEmergencyCallbackMode method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public Task SetEmergencyCallbackMode(NetworkEmergencyCallbackMode mode)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr dataResponse, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during setting the emergency callback mode, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during setting the emergency callback mode, " + (TapiError)result));
                        return;
                    }

                    task.SetResult(true);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Network.SetNetworkEmergencyCallback(_handle, mode, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to set the emergency callback mode, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Set the network roaming preference asynchronously.
        /// </summary>
        /// <param name="roamPref">The network roaming preference.</param>
        /// <returns>A task indicating whether the SetRoamingPreference method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public Task SetRoamingPreference(NetworkPreferred roamPref)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr dataResponse, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during setting the network roaming preference, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during setting the network roaming preference, " + (TapiError)result));
                        return;
                    }

                    task.SetResult(true);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Network.SetNetworkRoamPreference(_handle, roamPref, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to set the network roaming preference, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Get the network roaming preference asynchronously.
        /// </summary>
        /// <returns>Value of NetworkPreferred.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public Task<NetworkPreferred> GetRoamingPreference()
        {
            TaskCompletionSource<NetworkPreferred> task = new TaskCompletionSource<NetworkPreferred>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr dataResponse, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting the network roaming preference, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting the network roaming preference, " + (TapiError)result));
                        return;
                    }

                    task.SetResult((NetworkPreferred)Marshal.ReadInt32(dataResponse));
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Network.GetNetworkRoamPreference(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the network roaming preference, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Set the default data subscription asynchronously.
        /// </summary>
        /// <returns>A task indicating whether the SetDefaultDataSubscription method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public Task SetDefaultDataSubscription()
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr dataResponse, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during setting the default data subscription, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during setting the default data subscription, " + (TapiError)result));
                        return;
                    }

                    task.SetResult(true);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Network.SetNetworkDefaultDataSubs(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to set the default data subscription, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Get the default data subscription.
        /// </summary>
        /// <returns>Value of NetworkDefaultDataSubscription.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public NetworkDefaultDataSubscription GetDefaultDataSubscription()
        {
            NetworkDefaultDataSubscription defaultDataSubs;
            int ret = Interop.Tapi.Network.GetNetworkDefaultDataSubs(_handle, out defaultDataSubs);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the default data subscription, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return defaultDataSubs;
        }

        /// <summary>
        /// Set the default subscription for voice asynchronously.
        /// </summary>
        /// <returns>A task indicating whether the SetNetworkDefaultSubscription method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public Task SetNetworkDefaultSubscription()
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr dataResponse, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during setting the default subscription for voice, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during setting the default subscription for voice, " + (TapiError)result));
                        return;
                    }

                    task.SetResult(true);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Network.SetNetworkDefaultDataSubs(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to set the default subscription for voice, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Get the default subscription for voice.
        /// </summary>
        /// <returns>Value of NetworkDefaultSubscription.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when network instance is invalid or when method failed due to invalid operation.</exception>
        public NetworkDefaultSubscription GetNetworkDefaultSubscription()
        {
            NetworkDefaultSubscription defaultSubs;
            int ret = Interop.Tapi.Network.GetNetworkDefaultSubs(_handle, out defaultSubs);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the default subscription, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return defaultSubs;
        }
    }
}

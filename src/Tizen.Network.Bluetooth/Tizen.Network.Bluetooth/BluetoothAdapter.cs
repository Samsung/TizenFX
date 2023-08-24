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
using System.ComponentModel;

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// This class is used to control the Bluetooth adapter and get the list of bonded devices.<br/>
    /// The BluetoothAdapter class is used to discover neighbouring bluetooth devices.
    /// </summary>
    /// <privilege> http://tizen.org/privilege/bluetooth </privilege>
    /// <since_tizen> 3 </since_tizen>
    static public class BluetoothAdapter
    {
        /// <summary>
        /// A property to check whether the Bluetooth is enabled.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public bool IsBluetoothEnabled
        {
            get
            {
                try
                {
                    return BluetoothAdapterImpl.Instance.IsBluetoothEnabled;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// The local adapter address.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public string Address
        {
            get
            {
                if (IsBluetoothEnabled)
                {
                    return BluetoothAdapterImpl.Instance.Address;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// The name of the local adapter.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public string Name
        {
            get
            {
                if (IsBluetoothEnabled)
                {
                    return BluetoothAdapterImpl.Instance.Name;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                try
                {
                    BluetoothAdapterImpl.Instance.Name = value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// The visibility mode of the Bluetooth adapter.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public VisibilityMode Visibility
        {
            get
            {
                if (IsBluetoothEnabled)
                {
                    return BluetoothAdapterImpl.Instance.Visibility;
                }
                else
                {
                    return VisibilityMode.NonDiscoverable;
                }
            }
        }

        /// <summary>
        /// A property to check whether the device discovery process is in progress.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public bool IsDiscoveryInProgress
        {
            get
            {
                if (IsBluetoothEnabled)
                {
                    return BluetoothAdapterImpl.Instance.IsDiscoveryInProgress;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// The remaining time, in seconds, until the visibility mode is changed from TimeLimitedDiscoverable to NonDiscoverable.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public int RemainingTimeAsVisible
        {
            get
            {
                if (IsBluetoothEnabled)
                {
                    return BluetoothAdapterImpl.Instance.RemainingTimeAsVisible;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// The StateChanged event is raised when the Bluetooth adapter state is changed.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public event EventHandler<StateChangedEventArgs> StateChanged
        {
            add
            {
                try
                {
                    BluetoothAdapterImpl.Instance.StateChanged += value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
            remove
            {
                try
                {
                    BluetoothAdapterImpl.Instance.StateChanged -= value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// The NameChanged event is raised when the Bluetooth adapter name is changed.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public event EventHandler<NameChangedEventArgs> NameChanged
        {
            add
            {
                try
                {
                    BluetoothAdapterImpl.Instance.NameChanged += value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
            remove
            {
                try
                {
                    BluetoothAdapterImpl.Instance.NameChanged -= value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// The VisibilityModeChanged event is raised when the Bluetooth adapter visibility mode is changed.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public event EventHandler<VisibilityModeChangedEventArgs> VisibilityModeChanged
        {
            add
            {
                try
                {
                    BluetoothAdapterImpl.Instance.VisibilityModeChanged += value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
            remove
            {
                try
                {
                    BluetoothAdapterImpl.Instance.VisibilityModeChanged -= value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// The VisibilityDurationChanged event is raised very second until the visibility mode is changed to NonDiscoverable.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public event EventHandler<VisibilityDurationChangedEventArgs> VisibilityDurationChanged
        {
            add
            {
                try
                {
                    BluetoothAdapterImpl.Instance.VisibilityDurationChanged += value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
            remove
            {
                try
                {
                    BluetoothAdapterImpl.Instance.VisibilityDurationChanged -= value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// The DiscoveryStateChanged event is raised when the device discovery state is changed.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public event EventHandler<DiscoveryStateChangedEventArgs> DiscoveryStateChanged
        {
            add
            {
                try
                {
                    BluetoothAdapterImpl.Instance.DiscoveryStateChanged += value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
            remove
            {
                try
                {
                    BluetoothAdapterImpl.Instance.DiscoveryStateChanged -= value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// This event is called when the LE scan result is obtained.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public event EventHandler<AdapterLeScanResultChangedEventArgs> ScanResultChanged
        {
            add
            {
                try
                {
                    BluetoothLeImplAdapter.Instance.AdapterLeScanResultChanged += value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
            remove
            {
                try
                {
                    BluetoothLeImplAdapter.Instance.AdapterLeScanResultChanged -= value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// Enables the local Bluetooth adapter asynchronously.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <feature>http://tizen.org/feature/network.bluetooth</feature>
        /// <privilege>http://tizen.org/privilege/bluetooth.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method is failed with message.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Enable()
        {
            BluetoothAdapterImpl.Instance.Enable();
        }

        /// <summary>
        /// Disables the local Bluetooth adapter asynchronously.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <feature>http://tizen.org/feature/network.bluetooth</feature>
        /// <privilege>http://tizen.org/privilege/bluetooth.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method is failed with message.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Disable()
        {
            BluetoothAdapterImpl.Instance.Disable();
        }

        /// <summary>
        /// Enables the discoverable mode.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <feature>http://tizen.org/feature/network.bluetooth</feature>
        /// <privilege>http://tizen.org/privilege/bluetooth.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method is failed with message.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void EnableDiscoverable()
        {
            BluetoothAdapterImpl.Instance.SetVisibility(VisibilityMode.Discoverable, 0);
        }

        /// <summary>
        /// Enables the discoverable mode for the duration.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="duration">The duration until the discoverable mode is to be disabled(in seconds).</param>
        /// <feature>http://tizen.org/feature/network.bluetooth</feature>
        /// <privilege>http://tizen.org/privilege/bluetooth.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method is failed with message.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void EnableDiscoverable(int duration)
        {
            BluetoothAdapterImpl.Instance.SetVisibility(VisibilityMode.TimeLimitedDiscoverable, duration);
        }

        /// <summary>
        /// Disables the discoverable mode.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <feature>http://tizen.org/feature/network.bluetooth</feature>
        /// <privilege>http://tizen.org/privilege/bluetooth.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method is failed with message.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void DisableDiscoverable()
        {
            BluetoothAdapterImpl.Instance.SetVisibility(VisibilityMode.NonDiscoverable, 0);
        }

        /// <summary>
        /// Starts the device discovery process.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled and the device discovery process can be stopped by StopDiscovery().
        /// If this succeeds, the DiscoveryStateChanged event will be invoked.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or the start discovery fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public void StartDiscovery()
        {
            if (IsBluetoothEnabled)
            {
                BluetoothAdapterImpl.Instance.StartDiscovery();
            }
        }

        /// <summary>
        /// Stops the device discovery process.
        /// </summary>
        /// <remarks>
        /// The device discovery process must be in progress with StartDiscovery().
        /// If this succeeds, the DiscoveryStateChanged event will be invoked.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled or
        /// the discovery process is not is progress. </exception>
        /// <since_tizen> 3 </since_tizen>
        static public void StopDiscovery()
        {
            if (IsDiscoveryInProgress)
            {
                BluetoothAdapterImpl.Instance.StopDiscovery();
            }
        }

        /// <summary>
        /// Retrieves the device information of all bonded devices.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <returns> The list of the bonded BluetoothDeviceInfo objects.</returns>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or reading the Bonded devices list is failed.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public IEnumerable<BluetoothDevice> GetBondedDevices()
        {
            if (IsBluetoothEnabled)
            {
                return BluetoothAdapterImpl.Instance.GetBondedDevices();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the device information of a bonded device.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <returns> Information of the bonded BluetoothDeviceInfo object.</returns>
        /// <param name="address">The remote device address.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or reading the bonded device information fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public BluetoothDevice GetBondedDevice(string address)
        {
            if (IsBluetoothEnabled)
            {
                return BluetoothAdapterImpl.Instance.GetBondedDevice(address);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Checks whether the UUID of service is used or not.
        /// </summary>
        /// <returns><c>true</c> if the specified serviceUuid is used, otherwise <c>false</c>.</returns>
        /// <param name="serviceUuid">The UUID of Service.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public bool IsServiceUsed(string serviceUuid)
        {
            try
            {
                return BluetoothAdapterImpl.Instance.IsServiceUsed(serviceUuid);
            }
            catch (TypeInitializationException e)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Gets the hash and the randomizer value of the local OOB data object.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <returns>The BluetoothOobData object.</returns>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or the read OObData procedure is failed.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public BluetoothOobData GetLocalOobData()
        {
            if (IsBluetoothEnabled && Globals.IsInitialize)
            {
                return BluetoothAdapterImpl.Instance.GetLocalOobData();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Sets the hash and the randmoizer value of the OOB data into the remote device.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <param name="address">The remote device address.</param>
        /// <param name="oobData">The BluetoothOobData object.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or the set OobData procedure is failed.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public void SetRemoteOobData(string address, BluetoothOobData oobData)
        {
            if (IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAdapterImpl.Instance.SetRemoteOobData(address, oobData);
            }
        }

        /// <summary>
        /// Removes the hash and the randomizer value of the OOB data from the remote device.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <param name="address">The remote device address.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.
        /// or if the Remove Oobdata procedure is failed.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public void RemoveRemoteOobData(string address)
        {
            if (IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAdapterImpl.Instance.RemoveRemoteOobData(address);
            }
        }

        /// <summary>
        /// Starts the Bluetooth LE scan operation to discover BLE devices
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>The result of the operation StartLeScan.
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled
        /// or the Start LE scan is failed.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public void StartLeScan()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothLeImplAdapter.Instance.StartScan ();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to in start the le scan operation, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Starts the Bluetooth LE scan operation with scan mode.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>The result of the operation StartLeScan.
        /// <param name="mode">The LE scan mode.</param>
        /// <since_tizen> 7 </since_tizen>
        /// <feature>http://tizen.org/feature/network.bluetooth.le</feature>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled
        /// or the Start LE scan is failed.</exception>
        static public void StartLeScan(BluetoothLeScanMode mode)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothLeImplAdapter.Instance.SetScanMode(mode);
                int ret = BluetoothLeImplAdapter.Instance.StartScan();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to start the le scan operation, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Stops the Bluetooth LE scan operation.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>The result of the operation stopLescan.
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled
        /// or the Stop LE scan is failed.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public void StopLeScan()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothLeImplAdapter.Instance.StopScan ();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to stop the le scan operation, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Returns the BluetoothLeAdvertiser instance.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled before calling this API.
        /// </remarks>
        /// <returns>The BluetoothLeAdvertiser instance.</returns>
        /// <since_tizen> 3 </since_tizen>
        static public BluetoothLeAdvertiser GetBluetoothLeAdvertiser()
        {
            return BluetoothLeAdvertiser.Instance;
        }

        /// <summary>
        /// Registers a rfcomm server socket with a specific UUID.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled before calling this API.
        /// </remarks>
        /// <returns>The BluetoothServerSocket instance.</returns>
        /// <param name="serviceUuid">The UUID of service to provide.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or the socket create error occurs.</exception>
        /// <since_tizen> 3 </since_tizen>
        static public BluetoothServerSocket CreateServerSocket(string serviceUuid)
        {
            if (IsBluetoothEnabled && Globals.IsInitialize)
            {
                return BluetoothAdapterImpl.Instance.CreateServerSocket (serviceUuid);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Removes the rfcomm server socket which was created using CreateServerSocket().
        /// </summary>
        /// <remarks>
        /// The socket must be created with CreateServerSocket(). The ConnectionStateChanged event is raised after this API is called.
        /// </remarks>
        /// <param name="socket">The server socket instance is created using CreateServerSocket().</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or the socket destroy error occurs.</exception>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 6. Please use Dispose() on BluetoothServerSocket.")]
        static public void DestroyServerSocket(BluetoothServerSocket socket)
        {
            if (IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAdapterImpl.Instance.DestroyServerSocket(socket);
            }
        }

        /// <summary>
        /// Select the A2DP source/sink role.
        /// </summary>
        /// <param name="role">The A2DP source/sink role.</param>
        /// <since_tizen> 9 </since_tizen>
        /// <feature>http://tizen.org/feature/network.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.bluetooth.audio.call</feature>
        /// <feature>http://tizen.org/feature/network.bluetooth.audio.media</feature>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method is failed with message.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public void SelectRole(BluetoothAudioRole role)
        {
            BluetoothAudioImpl.Instance.SelectRole(role);
        }

        /// <summary>
        /// Gets the name of the specification UUID.
        /// </summary>
        /// <param name="uuid">The UUID.</param>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public string GetUuidSpecificationName(string uuid)
        {
            return BluetoothAdapterImpl.Instance.GetUuidSpecificationName(uuid);
        }
    }
}

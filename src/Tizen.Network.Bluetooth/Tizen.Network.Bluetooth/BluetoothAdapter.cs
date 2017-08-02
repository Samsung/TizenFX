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

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// A class which is used to control a bluetooth adapter and get the list of bonded devices.<br>
    /// The BluetoothAdapter class is used to discover neighbouring bluetooth devices.
    /// </summary>
    /// <privilege> http://tizen.org/privilege/bluetooth </privilege>
    static public class BluetoothAdapter
    {
        /// <summary>
        /// A property to check whether Bluetooth is enabled.
        /// </summary>
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled.</exception>
        static public bool IsBluetoothEnabled
        {
            get
            {
                return BluetoothAdapterImpl.Instance.IsBluetoothEnabled;
            }
        }

        /// <summary>
        /// The local adapter address.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled.</exception>
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
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled.</exception>
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
                BluetoothAdapterImpl.Instance.Name = value;
            }
        }

        /// <summary>
        /// The visibility mode of the Bluetooth adapter.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled.</exception>
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
        /// A property to check whether device discovery is in progress.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled.</exception>
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
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled.</exception>
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
        /// (event) StateChanged is raised when bluetooth adapter state is changed.
        /// </summary>
        static public event EventHandler<StateChangedEventArgs> StateChanged
        {
            add
            {
                BluetoothAdapterImpl.Instance.StateChanged += value;
            }
            remove
            {
                BluetoothAdapterImpl.Instance.StateChanged -= value;
            }
        }

        /// <summary>
        /// (event) NameChanged is raised when bluetooth adapter name is changed.
        /// </summary>
        static public event EventHandler<NameChangedEventArgs> NameChanged
        {
            add
            {
                BluetoothAdapterImpl.Instance.NameChanged += value;
            }
            remove
            {
                BluetoothAdapterImpl.Instance.NameChanged -= value;
            }
        }

        /// <summary>
        /// (event) VisibilityModeChanged is raised when bluetooth adapter visibility mode is changed.
        /// </summary>
        static public event EventHandler<VisibilityModeChangedEventArgs> VisibilityModeChanged
        {
            add
            {
                BluetoothAdapterImpl.Instance.VisibilityModeChanged += value;
            }
            remove
            {
                BluetoothAdapterImpl.Instance.VisibilityModeChanged -= value;
            }
        }

        /// <summary>
        /// (event) VisibilityDurationChanged is raised very second until the visibility mode is changed to NonDiscoverable.
        /// </summary>
        static public event EventHandler<VisibilityDurationChangedEventArgs> VisibilityDurationChanged
        {
            add
            {
                BluetoothAdapterImpl.Instance.VisibilityDurationChanged += value;
            }
            remove
            {
                BluetoothAdapterImpl.Instance.VisibilityDurationChanged -= value;
            }
        }

        /// <summary>
        /// (event) DiscoveryStateChanged is raised when the device discovery state is changed.
        /// </summary>
        static public event EventHandler<DiscoveryStateChangedEventArgs> DiscoveryStateChanged
        {
            add
            {
                BluetoothAdapterImpl.Instance.DiscoveryStateChanged += value;
            }
            remove
            {
                BluetoothAdapterImpl.Instance.DiscoveryStateChanged -= value;
            }
        }

        /// <summary>
        /// Event that is called when the LE Scan result is obtained.
        /// </summary>
        static public event EventHandler<AdapterLeScanResultChangedEventArgs> ScanResultChanged
        {
            add
            {
                BluetoothLeImplAdapter.Instance.AdapterLeScanResultChanged += value;
            }
            remove {
                BluetoothLeImplAdapter.Instance.AdapterLeScanResultChanged -= value;
            }
        }

        /// <summary>
        /// Starts the device discovery process.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled and device discovery can be stopped by StopDiscovery().
        /// If this succeeds, DiscoveryStateChanged event will be invoked.
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled
        /// or the start discovery fails.</exception>
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
        /// The device discovery must be in progress with StartDiscovery().
        /// If this succeeds, DiscoveryStateChanged event will be invoked.
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled
        /// the Discovery is not is prpgress </exception>
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
        /// <returns> List of Bonded BluetoothDeviceInfo objects.</returns>
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled
        /// or reading the Bonded devices list is failed.</exception>
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
        /// <returns> Information of bonded BluetoothDeviceInfo object.</returns>
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled
        /// or reading the bonded device information fails.</exception>
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
        /// <returns><c>true</c> if the specified serviceUuid is used; otherwise, <c>false</c>.</returns>
        /// <param name="serviceUuid">The UUID of Service.</param>
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled.</exception>
        static public bool IsServiceUsed(string serviceUuid)
        {
            return BluetoothAdapterImpl.Instance.IsServiceUsed(serviceUuid);
        }

        /// <summary>
        /// Gets the hash and randomizer value of local oob data object.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <returns>The BluetoothOobData object.</returns>
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled
        /// or the read OObData procedure is failed</exception>
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
        /// Sets the Hash and Randmoizer value of oob data into the remote device.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <param name="address">Remote Device address.</param>
        /// <param name="oobData">BluetoothOobData object.</param>
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled
        /// or the set Oobdata procedure is failed.</exception>
        static public void SetRemoteOobData(string address, BluetoothOobData oobData)
        {
            if (IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAdapterImpl.Instance.SetRemoteOobData(address, oobData);
            }
        }

        /// <summary>
        /// Removes the Hash and Randomizer value of oob data from the remote device.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <param name="address">Remote Device address.</param>
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled
        /// or if the Remove Oobdata procedure is failed.</exception>
        static public void RemoveRemoteOobData(string address)
        {
            if (IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAdapterImpl.Instance.RemoveRemoteOobData(address);
            }
        }

        /// <summary>
        /// Starts the Bluetooth Le scan operation to discover BLE devices
        /// </summary>
        /// <remarks>
        /// Bluetooth must be enabled.
        /// </remarks>the result of the operation StartLeScan
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth LE is not Enabled
        /// or the Start LE Scan is failed.</exception>
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
        /// Stops the Bluetooth Le scan operation.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>the result of the operation stopLescan
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth LE is not Enabled
        /// or Stop LE Scan is failed.</exception>
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
        /// Returns BluetoothLeAdvertiser instance.
        /// </summary>
        /// <remarks>
        /// The bluetooth must be enabled before calling this API.
        /// </remarks>
        /// <returns>The BluetoothLeAdvertiser instance.</returns>
        static public BluetoothLeAdvertiser GetBluetoothLeAdvertiser()
        {
            return BluetoothLeAdvertiser.Instance;
        }

        /// <summary>
        /// Registers a rfcomm server socket with a specific UUID.
        /// </summary>
        /// <remarks>
        /// The bluetooth must be enabled before calling this API.
        /// </remarks>
        /// <returns>The BluetoothServerSocket instance.</returns>
        /// <param name="serviceUuid">The UUID of service to provide.</param>
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled
        /// or Socket create error happens.</exception>
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
        /// The socket must be created with CreateServerSocket(). ConnectionStateChanged event is raised after this API is called.
        /// </remarks>
        /// <param name="socket">The server socket instance which is created using CreateServerSocket().</param>
        /// <exception cref="System.NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled
        /// or socket destroy error happens.</exception>
        static public void DestroyServerSocket(BluetoothServerSocket socket)
        {
            if (IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAdapterImpl.Instance.DestroyServerSocket(socket);
            }
        }
    }
}

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
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace Tizen.Network.Bluetooth {

    /// <summary>
    /// This is the BluetoothLeAdvertiser class. It handles the LE advertising operation amd callback.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BluetoothLeAdvertiser
    {
        private static readonly BluetoothLeAdvertiser _instance = new BluetoothLeAdvertiser();

        internal static BluetoothLeAdvertiser Instance
        {
            get
            {
                return _instance;
            }
        }

        private BluetoothLeAdvertiser()
        {
        }

        /// <summary>
        /// This event is called when the LE advertising state changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<AdvertisingStateChangedEventArgs> AdvertisingStateChanged
        {
            add
            {
                BluetoothLeImplAdapter.Instance.AdapterLeAdvertisingStateChanged += value;
            }
            remove
            {
                BluetoothLeImplAdapter.Instance.AdapterLeAdvertisingStateChanged -= value;
            }
        }
        /// <summary>
        /// Starts advertising using the advertise data object.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <param name="advertiseData">The advertiser object carrying information of the advertising.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void StartAdvertising(BluetoothLeAdvertiseData advertiseData)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothLeImplAdapter.Instance.StartAdvertising (advertiseData.GetHandle ());
                if (ret != (int)BluetoothError.None) {
                    Log.Error (Globals.LogTag, "Failed to start advertising- " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Stops the advertising.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <param name="advertiseData">The advertiser object carrying information of the advertising.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void StopAdvertising(BluetoothLeAdvertiseData advertiseData)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothLeImplAdapter.Instance.StopAdvertising (advertiseData.GetHandle ());
                if (ret != (int)BluetoothError.None) {
                    Log.Error (Globals.LogTag, "Failed to stop advertising operation- " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }
    }

    /// <summary>
    /// This is the BluetoothLeDevice class.
    /// It handles the LE device operations like getting data from the scan result information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BluetoothLeDevice
    {
        //properties of Bluetoothlesacandata
        private string _remoteAddress;
        private BluetoothLeDeviceAddressType _addressType;
        private int _rssi;
        private byte[] _advDataValue;
        private byte[] _scanDataValue;
        private BluetoothLePacketType _packetType;
        private BluetoothLeScanData _scanData;

        /// <summary>
        /// This event is called when the GATT client connects/disconnects with the server.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 6. Please use ConnectionStateChanged event on BluetoothGattClient.")]
        public event EventHandler<GattConnectionStateChangedEventArgs> GattConnectionStateChanged
        {
            add
            {
                BluetoothLeImplAdapter.Instance.LeGattConnectionStateChanged += value;
            }
            remove
            {
                BluetoothLeImplAdapter.Instance.LeGattConnectionStateChanged -= value;
            }
        }

        internal BluetoothLeDevice(BluetoothLeScanData scanData)
        {
            _scanData = new BluetoothLeScanData ();
            _scanData = scanData;

            Log.Info (Globals.LogTag, "Rssi" + _scanData.Rssi);
            _rssi = scanData.Rssi;
            Log.Info (Globals.LogTag, "RemoteAddress" + _scanData.RemoteAddress);
            if (scanData.RemoteAddress != null)
                _remoteAddress = scanData.RemoteAddress;
            Log.Info (Globals.LogTag, "AddressType" + _scanData.AddressType);
            _addressType = scanData.AddressType;

            Log.Info (Globals.LogTag, "AdvDataLength" + _scanData.AdvDataLength);
            if (_scanData.AdvDataLength > 0)
            {
                _advDataValue = new byte[_scanData.AdvDataLength];
                scanData.AdvData.CopyTo(_advDataValue, 0);
            }

            Log.Info(Globals.LogTag, "ScanDataLength" + _scanData.ScanDataLength);
            //  Check length before copying
            if (_scanData.ScanDataLength > 0)
            {
                _scanDataValue = new byte[_scanData.ScanDataLength];
                scanData.ScanData.CopyTo(_scanDataValue, 0);
            }
        }

        /// <summary>
        /// BluetoothLeDevice destructor.
        /// </summary>
        ~BluetoothLeDevice()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothLeImplAdapter.Instance.FreeServiceDataList();
            }
        }

        /// <summary>
        /// The remote address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string RemoteAddress
        {
            get
            {
                return _remoteAddress;
            }
        }

        /// <summary>
        /// The type of the address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothLeDeviceAddressType AddressType
        {
            get
            {
                return _addressType;
            }
        }

        /// <summary>
        /// The rssi value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Rssi
        {
            get
            {
                return _rssi;
            }
        }

        /// <summary>
        /// The advertsing data information.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] AdvertsingDataInformation
        {
            get
            {
                return _advDataValue;
            }
        }

        /// <summary>
        /// The scan data information.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] ScanDataInformation
        {
            get
            {
                return _scanDataValue;
            }
        }

        /// <summary>
        /// The type of the packet.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 6. Please use new methods with this type on BluetoothLeDevice.")]
        public BluetoothLePacketType PacketType
        {
            get
            {
                return _packetType;
            }
            set
            {
                _packetType = value;
            }
        }

        /// <summary>
        /// Gets the service UUIDs list from the LE scan result information.
        /// </summary>
        /// <value> Gets the list of the string service UUIDs.</value>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 6. Please use GetServiceUuid() method on BluetoothLeDevice.")]
        public IEnumerable<string> ServiceUuid
        {
            get
            {
                return GetServiceUuid(BluetoothLePacketType.BluetoothLeAdvertisingPacket);
            }
        }

        /// <summary>
        /// Gets the service UUIDs list from the LE scan result information.
        /// </summary>
        /// <value> Gets the list of the string service UUIDs.</value>
        /// <remarks>The Bluetooth must be enabled.</remarks>
        /// <param name="packetType"> The enumeration for BLE packet type.</param>
        /// <returns>The service uuid value</returns>
        /// <feature>http://tizen.org/feature/network.bluetooth.le</feature>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled.</exception>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<string> GetServiceUuid(BluetoothLePacketType packetType)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                Log.Info(Globals.LogTag, "Retrieving Service uuid- ");
                return BluetoothLeImplAdapter.Instance.GetLeScanResultServiceUuids(_scanData, packetType);
            }
            return null;
        }

        /// <summary>
        /// Gets the device name from the LE scan result information.
        /// </summary>
        /// <value> Gets the device name.</value>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 6. Please use GetDeviceName() method on BluetoothLeDevice.")]
        public string DeviceName
        {
            get
            {
                return GetDeviceName(BluetoothLePacketType.BluetoothLeAdvertisingPacket);
            }
        }

        /// <summary>
        /// Gets the device name from the LE scan result information.
        /// </summary>
        /// <value> Gets the device name.</value>
        /// <remarks>The Bluetooth must be enabled.</remarks>
        /// <param name="packetType"> The enumeration for BLE packet type.</param>
        /// <returns>The device name value</returns>
        /// <feature>http://tizen.org/feature/network.bluetooth.le</feature>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled.</exception>
        /// <since_tizen> 6 </since_tizen>
        public string GetDeviceName(BluetoothLePacketType packetType)
        {
            Log.Info(Globals.LogTag, "Retrieving device name- ");
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                return BluetoothLeImplAdapter.Instance.GetLeScanResultDeviceName(_scanData, packetType);
            }
            return null;
        }

        /// <summary>
        /// Gets the transmission power level from the LE scan result information.
        /// </summary>
        /// <value> Gets the transmission power level in dB.</value>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 6. Please use GetTxPowerLevel() method on BluetoothLeDevice.")]
        public int TxPowerLevel
        {
            get
            {
                return GetTxPowerLevel(BluetoothLePacketType.BluetoothLeAdvertisingPacket);
            }
        }

        /// <summary>
        /// Gets the transmission power level from the LE scan result information.
        /// </summary>
        /// <value> Gets the transmission power level in dB.</value>
        /// <remarks>The Bluetooth must be enabled.</remarks>
        /// <param name="packetType"> The enumeration for BLE packet type.</param>
        /// <returns>The tx power level value</returns>
        /// <feature>http://tizen.org/feature/network.bluetooth.le</feature>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled.</exception>
        /// <since_tizen> 6 </since_tizen>
        public int GetTxPowerLevel(BluetoothLePacketType packetType)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                return BluetoothLeImplAdapter.Instance.GetScanResultTxPowerLevel(_scanData, packetType);
            }
            return -1;
        }

        /// <summary>
        /// Gets the service solicitation UUID list from the scan result information.
        /// </summary>
        /// <value> Gets the list of the service solicitation UUIDs.</value>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 6. Please use GetServiceSolicitationUuid() method on BluetoothLeDevice.")]
        public IEnumerable<string> ServiceSolictationUuid
        {
            get
            {
                return GetServiceSolicitationUuid(BluetoothLePacketType.BluetoothLeAdvertisingPacket);
            }
        }

        /// <summary>
        /// Gets the service solicitation UUID list from the scan result information.
        /// </summary>
        /// <value> Gets the list of the service solicitation UUIDs.</value>
        /// <remarks>The Bluetooth must be enabled.</remarks>
        /// <param name="packetType"> The enumeration for BLE packet type.</param>
        /// <returns>The service solicitation uuid value</returns>
        /// <feature>http://tizen.org/feature/network.bluetooth.le</feature>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled.</exception>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<string> GetServiceSolicitationUuid(BluetoothLePacketType packetType)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                return BluetoothLeImplAdapter.Instance.GetScanResultSvcSolicitationUuids(_scanData, packetType);
            }
            return null;
        }

        /// <summary>
        /// Gets the manufacturer data from the scan result information.
        /// </summary>
        /// <value> Gets the appearance value.</value>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 6. Please use GetAppearance() method on BluetoothLeDevice.")]
        public int Appearance
        {
            get
            {
                return GetAppearance(BluetoothLePacketType.BluetoothLeAdvertisingPacket);
            }
        }

        /// <summary>
        /// Gets the manufacturer data from the scan result information.
        /// </summary>
        /// <value> Gets the appearance value.</value>
        /// <remarks>The Bluetooth must be enabled.</remarks>
        /// <param name="packetType"> The enumeration for BLE packet type.</param>
        /// <returns>The appearance value</returns>
        /// <feature>http://tizen.org/feature/network.bluetooth.le</feature>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled.</exception>
        /// <since_tizen> 6 </since_tizen>
        public int GetAppearance(BluetoothLePacketType packetType)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                return BluetoothLeImplAdapter.Instance.GetScanResultAppearance(_scanData, packetType);
            }
            return -1;
        }

        /// <summary>
        /// Gets the manufacturer data from the scan result information.
        /// </summary>
        /// <value> Gets the manufacturer data containing the manucturer data and ID information.</value>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled.</exception>/// 
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 6. Please use GetManufacturerData() method on BluetoothLeDevice.")]
        public ManufacturerData ManufacturerData
        {
            get
            {
                return GetManufacturerData(BluetoothLePacketType.BluetoothLeAdvertisingPacket);
            }
        }

        /// <summary>
        /// Gets the manufacturer data from the scan result information.
        /// </summary>
        /// <value> Gets the manufacturer data containing the manucturer data and ID information.</value>
        /// <remarks>The Bluetooth must be enabled.</remarks>
        /// <param name="packetType"> The enumeration for BLE packet type.</param>
        /// <returns>The manufacturer data object</returns>
        /// <feature>http://tizen.org/feature/network.bluetooth.le</feature>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled.</exception>/// 
        /// <since_tizen> 6 </since_tizen>
        public ManufacturerData GetManufacturerData(BluetoothLePacketType packetType)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                return BluetoothLeImplAdapter.Instance.GetScanResultManufacturerData(_scanData, packetType);
            }
            return null;
        }

        /// <summary>
        /// Gets the service data list from the scan result information.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <returns> Returns the service data list.</returns>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 6. Please use GetServiceDataList() method on BluetoothLeDevice.")]
        public IEnumerable<BluetoothLeServiceData> GetServiceDataList()
        {
            return GetServiceDataList(BluetoothLePacketType.BluetoothLeAdvertisingPacket);
        }

        /// <summary>
        /// Gets the service data list from the scan result information.
        /// </summary>
        /// <remarks>The Bluetooth must be enabled.</remarks>
        /// <param name="packetType"> The packet type.</param>
        /// <returns> Returns the service data list.</returns>
        /// <feature>http://tizen.org/feature/network.bluetooth.le</feature>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled.</exception>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<BluetoothLeServiceData> GetServiceDataList(BluetoothLePacketType packetType)
        {
            int serviceCount = 0;
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                return BluetoothLeImplAdapter.Instance.GetScanResultServiceDataList(_scanData, packetType, out serviceCount);
            }
            return null;
        }

        /// <summary>
        /// Creates a GATT connection with the remote device.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <param name="autoConnect"> The auto connect flag.</param>
        /// <returns>client instance</returns>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled
        /// or when the gatt connection attempt to remote device fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 6. Please use CreateClient() and ConnectAsync() method on BluetoothGattClient.")]
        public BluetoothGattClient GattConnect(bool autoConnect)
        {
            BluetoothGattClient client = null;
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothLeImplAdapter.Instance.GattConnect (_remoteAddress, autoConnect);
                if (ret != (int)BluetoothError.None) {
                    Log.Error (Globals.LogTag, "Failed to create GATT Connection with remote device- " + (BluetoothError)ret);
                }
                else
                {
                    client = BluetoothGattClient.CreateClient(_remoteAddress);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
            return client;
        }

        /// <summary>
        /// Disconnects a GATT connection with the remote device.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled
        /// or when the GATT disconnection attempt to remote device fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 6. Please use DisconnectAsync() method on BluetoothGattClient.")]
        public void GattDisconnect()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothLeImplAdapter.Instance.GattDisconnect (_remoteAddress);
                if (ret != (int)BluetoothError.None) {
                    Log.Error (Globals.LogTag, "Failed to disconnect GATT connection with remote device- " + (BluetoothError)ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }
    }

    /// <summary>
    /// Bluetooth LE advertise data. Handles the data advertising.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BluetoothLeAdvertiseData:IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private BluetoothLeAdvertisingMode _mode;
        private bool _advertisingConnectable;
        private BluetoothLePacketType _packetType;
        private int _appearance;
        private bool _includePowerLevel;
        private bool _includeDeviceName;

        /// <summary>
        /// The default constructor initializes an object of the BluetoothLeAdvertiseData.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled
        /// or when create advertiser fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothLeAdvertiseData()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                Log.Debug(Globals.LogTag, " Creating LeAdvertiser()");
                int ret = Interop.Bluetooth.CreateAdvertiser(out _handle);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to create advertiser object- " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// BluetoothLeAdvertiseData destructor.
        /// </summary>
        ~BluetoothLeAdvertiseData()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                //clean-up
                ClearAdvertisingData (BluetoothLePacketType.BluetoothLeAdvertisingPacket);
                ClearAdvertisingData (BluetoothLePacketType.BluetoothLeScanResponsePacket);
                BluetoothLeImplAdapter.Instance.DestroyAdvertiser (_handle);
            }
            Dispose(false);
        }

        internal IntPtr GetHandle()
        {
            return _handle;
        }

        /// <summary>
        /// The advertising mode to control the advertising power and latency.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled
        /// or when the set advertising mode fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothLeAdvertisingMode AdvertisingMode
        {
            get
            {
                return _mode;
            }
            set
            {
                if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
                {
                    _mode = value;
                    int ret = Interop.Bluetooth.SetAdvertisingMode (GetHandle (), _mode);
                    if (ret != (int)BluetoothError.None) {
                        Log.Error (Globals.LogTag, "Failed to set advertising mode- " + (BluetoothError)ret);
                        BluetoothErrorFactory.ThrowBluetoothException (ret);
                    }
                }
            }
        }

        /// <summary>
        /// The advertising connectable type.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled
        /// or when the set advertising connectable mode fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public bool AdvertisingConnectable
        {
            get
            {
                return _advertisingConnectable;
            }
            set
            {
                if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
                {
                    _advertisingConnectable = value;
                    int ret = Interop.Bluetooth.SetAdvertisingConnectable (GetHandle (), _advertisingConnectable);
                    if (ret != (int)BluetoothError.None) {
                        Log.Error (Globals.LogTag, "Failed to set advertising connectable value- " + (BluetoothError)ret);
                        BluetoothErrorFactory.ThrowBluetoothException (ret);
                    }
                }
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            //todo...
        }

        /// <summary>
        /// The type of the packet.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothLePacketType PacketType
        {
            get
            {
                return _packetType;
            }
            set
            {
                _packetType = value;
            }
        }
        /// <summary>
        /// Sets the external appearance of this device to the advertise or the scan response data.
        /// Please refer to the adopted Bluetooth specification for the appearance.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled
        /// or when the set appearance fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public int Appearance
        {
            get
            {
                return _appearance;
            }
            set
            {
                _appearance = value;
                if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize) {
                    int ret = Interop.Bluetooth.SetAdvertisingAppearance (GetHandle (), _packetType, _appearance);
                    if (ret != (int)BluetoothError.None) {
                        Log.Error (Globals.LogTag, "Failed to add appearance value to advertising data- " + (BluetoothError)ret);
                        BluetoothErrorFactory.ThrowBluetoothException(ret);
                    }
                }
            }
        }

        /// <summary>
        /// Sets whether the device name has to be included in the advertise or the scan response data.
        /// The maximum advertised or responded data size is 31 bytes including the data type and the system wide data.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled
        /// or when the set advertising device name fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public bool IncludeDeviceName
        {
            get
            {
                return _includeDeviceName;
            }
            set
            {
                _includeDeviceName = value;
                if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
                {
                    int ret = Interop.Bluetooth.SetAdvertisingDeviceName(GetHandle(), _packetType, _includeDeviceName);
                    if (ret != (int)BluetoothError.None) {
                        Log.Error (Globals.LogTag, "Failed to add device name to advertising data- " + (BluetoothError)ret);
                        BluetoothErrorFactory.ThrowBluetoothException(ret);
                    }
                }
            }
        }


        /// <summary>
        /// Sets whether the transmission power level should be included in the advertise or the scan response data.
        /// The maximum advertised or responded data size is 31 bytes including the data type and the system wide data.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled
        /// or when the set advertising TC power level fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public bool IncludeTxPowerLevel
        {
            get
            {
                return _includePowerLevel;
            }
            set
            {
                _includePowerLevel = value;
                if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
                {
                    int ret = Interop.Bluetooth.SetAdvertisingTxPowerLevel(GetHandle(), _packetType, _includePowerLevel);
                    if (ret != (int)BluetoothError.None)
                    {
                        Log.Error(Globals.LogTag, "Failed to add advertising service solicitation uuid- " + (BluetoothError)ret);
                    }
                }
            }
        }
        /// <summary>
        /// Adds a service UUID to the advertise or the scan response data.
        /// The maximum advertised or responded data size is 31 bytes
        /// including the data type and the system wide data.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <param name="packetType">The packet type.</param>
        /// <param name="serviceUuid"> The service UUID to add to advertise data.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled
        /// or when the add advertising service UUID procedure fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void AddAdvertisingServiceUuid(BluetoothLePacketType packetType, string serviceUuid)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = Interop.Bluetooth.AddAdvertisingServiceUuid (GetHandle (), packetType, serviceUuid);
                if (ret != (int)BluetoothError.None) {
                    Log.Error (Globals.LogTag, "Failed to add service uuid to advertising data- " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException (ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Adds a service solicitation UUID to advertise or scan the response data.
        /// The maximum advertised or responded data size is 31 bytes
        /// including the data type and the system wide data.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <param name="packetType">The packet type.</param>
        /// <param name="serviceSolicitationUuid"> The service solicitation UUID to add to advertise data.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled
        /// or when the add advertising service solicitation UUID procedure fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void AddAdvertisingServiceSolicitationUuid(BluetoothLePacketType packetType,
                                                        string serviceSolicitationUuid)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = Interop.Bluetooth.AddAdvertisingServiceSolicitationUuid(GetHandle(), packetType,
                                                                serviceSolicitationUuid);
                if (ret != (int)BluetoothError.None) {
                    Log.Error (Globals.LogTag, "Failed to add service solicitation uuid to advertising data- " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Adds a service data to the advertise or the scan response data.
        /// The maximum advertised or responded data size is 31 bytes
        /// including data type and system wide data.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <param name="packetType">The packet type.</param>
        /// <param name="data"> The service data to be added to advertising.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled
        /// or when the add advertising data procedure fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void AddAdvertisingServiceData(BluetoothLePacketType packetType, BluetoothServiceData data)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                IntPtr serviceDataPtr;
                serviceDataPtr = Marshal.AllocHGlobal(data.DataLength);
                Marshal.Copy(data.Data, 0, serviceDataPtr, data.DataLength);

                for (int i = 0; i < data.DataLength; i++)
                    Log.Error (Globals.LogTag, " service data is  " + data.Data [i]);
                int ret = Interop.Bluetooth.AddAdvertisingServiceData(GetHandle(), packetType,
                    data.Uuid, serviceDataPtr, data.DataLength);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to add service data to advertising data- " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Adds the manufacturer specific data to the advertise or the scan response data.
        /// Please refer to the adopted Bluetooth specification for the the appearance.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <param name="packetType">The packet type.</param>
        /// <param name="manufacturerData"> The manufacturer specific data.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled
        /// or when the add advertising manufacturer data procedure fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void AddAdvertisingManufacturerData(BluetoothLePacketType packetType,
                                    ManufacturerData manufacturerData)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                IntPtr manufDataPtr;
                manufDataPtr = Marshal.AllocHGlobal(manufacturerData.DataLength);
                Marshal.Copy(manufacturerData.Data, 0, manufDataPtr, manufacturerData.DataLength);

                int ret = Interop.Bluetooth.AddAdvertisingManufData(GetHandle(), packetType,
                    manufacturerData.Id, manufDataPtr, manufacturerData.DataLength);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to add service solicitation uuid to advertising data- " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Clears all data to be advertised or responded to the scan request from the LE scanning device.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <param name="packetType">The packet type to be cleared.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth LE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth LE is not enabled
        /// or when the clear advertising data procedure fails.</exception>
        internal void ClearAdvertisingData(BluetoothLePacketType packetType)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = Interop.Bluetooth.ClearAdvertisingData (GetHandle (), packetType);
                if (ret != (int)BluetoothError.None) {
                    Log.Error (Globals.LogTag, "Failed to Clear Advertising Data- " + (BluetoothError)ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }
    }
}

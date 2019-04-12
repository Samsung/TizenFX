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
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Tizen.Network.Bluetooth
{
    internal class BluetoothLeImplAdapter : IDisposable
    {
        private static readonly BluetoothLeImplAdapter _instance = new BluetoothLeImplAdapter();

        private bool disposed = false;

        private event EventHandler<AdapterLeScanResultChangedEventArgs> _adapterLeScanResultChanged = null;
        private Interop.Bluetooth.AdapterLeScanResultChangedCallBack _adapterLeScanResultChangedCallback;

        private event EventHandler<AdvertisingStateChangedEventArgs> _advertisingStateChanged = null;
        private Interop.Bluetooth.AdvertisingStateChangedCallBack _advertisingStateChangedCallback;

        private event EventHandler<GattConnectionStateChangedEventArgs> _gattConnectionStateChanged = null;
        private Interop.Bluetooth.GattConnectionStateChangedCallBack _gattConnectionStateChangedCallback;

        private int _serviceListCount = 0;
        private IList<BluetoothLeServiceData> _list = new List<BluetoothLeServiceData>();
        private bool _scanStarted;

        internal static BluetoothLeImplAdapter Instance
        {
            get
            {
                return _instance;
            }
        }

        private BluetoothLeImplAdapter()
        {
        }

        ~BluetoothLeImplAdapter()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free managed objects.
            }
            //Free unmanaged objects
            if (_gattConnectionStateChanged != null)
            {
                UnRegisterGattConnectionStateChangedEvent();
            }

            //stop scan operation in progress
            StopScan ();

            disposed = true;
        }

        internal event EventHandler<AdapterLeScanResultChangedEventArgs> AdapterLeScanResultChanged
        {
            add
            {
                _adapterLeScanResultChanged += value;
            }
            remove {
                _adapterLeScanResultChanged -= value;
            }
        }

        internal event EventHandler<AdvertisingStateChangedEventArgs> AdapterLeAdvertisingStateChanged
        {
            add
            {
                _advertisingStateChanged += value;
            }
            remove
            {
                _advertisingStateChanged -= value;
            }
        }

        internal event EventHandler<GattConnectionStateChangedEventArgs> LeGattConnectionStateChanged
        {
            add
            {
                if (_gattConnectionStateChanged == null)
                {
                    RegisterGattConnectionStateChangedEvent();
                }
                _gattConnectionStateChanged += value;
            }
            remove
            {
                _gattConnectionStateChanged -= value;
                if (_gattConnectionStateChanged == null)
                {
                    UnRegisterGattConnectionStateChangedEvent();
                }
            }
        }

        internal void RegisterGattConnectionStateChangedEvent()
        {
            _gattConnectionStateChangedCallback = (int result, bool connected,
                                    string remoteDeviceAddress, IntPtr userData) =>
            {
                if (_gattConnectionStateChanged != null)
                {
                    Log.Info(Globals.LogTag, "Setting gatt connection state changed callback" );
                    GattConnectionStateChangedEventArgs e = new GattConnectionStateChangedEventArgs (result,
                        connected, remoteDeviceAddress);

                    _gattConnectionStateChanged(null, e);
                }
            };

            int ret = Interop.Bluetooth.SetGattConnectionStateChangedCallback(
                                    _gattConnectionStateChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set gatt connection state changed callback, Error - " + (BluetoothError)ret);
            }
        }

        internal void UnRegisterGattConnectionStateChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetGattConnectionStateChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset gatt connection state changed callback, Error - " + (BluetoothError)ret);
            }
        }

        internal int StartScan()
        {
            _adapterLeScanResultChangedCallback = (int result, ref BluetoothLeScanDataStruct scanData, IntPtr userData) =>
            {
                Log.Info(Globals.LogTag, "Inside Le scan callback " );
                BluetoothLeScanData scanDataInfo = BluetoothUtils.ConvertStructToLeScanData(scanData);

                BluetoothLeDevice device = new BluetoothLeDevice(scanDataInfo);
                BluetoothError res = (BluetoothError)result;

                AdapterLeScanResultChangedEventArgs e = new AdapterLeScanResultChangedEventArgs (res,
                                                                    device);
                _adapterLeScanResultChanged (null, e);
            };

            IntPtr data = IntPtr.Zero;
            int ret = Interop.Bluetooth.StartScan(_adapterLeScanResultChangedCallback, data);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to start BLE scan - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            _scanStarted = true;
            return ret;
        }

        internal int StopScan()
        {
            int ret = (int)BluetoothError.None;

            if (_scanStarted)
            {
                ret = Interop.Bluetooth.StopScan ();
                if (ret != (int)BluetoothError.None) {
                    Log.Error (Globals.LogTag, "Failed to stop BLE scan - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException (ret);
                }
            }
            return ret;
        }

        private string GetPacketTypeToString(BluetoothLePacketType packetType)
        {
            return packetType == BluetoothLePacketType.BluetoothLeAdvertisingPacket ? "AdvertisingPacket" : "ScanResponsePacket";
        }

        internal IList<string> GetLeScanResultServiceUuids(BluetoothLeScanData scanData, BluetoothLePacketType packetType)
        {
            if (!BluetoothAdapter.IsBluetoothEnabled || !Globals.IsInitialize)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }

            IntPtr uuidListArray = IntPtr.Zero;
            int count = -1;
            BluetoothLeScanDataStruct scanDataStruct = BluetoothUtils.ConvertLeScanDataToStruct(scanData);

            int ret = Interop.Bluetooth.GetScanResultServiceUuid(ref scanDataStruct, packetType, ref uuidListArray, ref count);
            if (ret == (int)BluetoothError.NoData)
            {
                Log.Info(Globals.LogTag, "No ServiceUuids in " + GetPacketTypeToString(packetType));
                Marshal.FreeHGlobal(scanDataStruct.AdvData);
                Marshal.FreeHGlobal(scanDataStruct.ScanData);
                return null;
            }
            else if (ret != (int)BluetoothError.None)
            {
                Log.Info(Globals.LogTag, "Failed to service uuids list- " + (BluetoothError)ret);
                Marshal.FreeHGlobal(scanDataStruct.AdvData);
                Marshal.FreeHGlobal(scanDataStruct.ScanData);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }

            Log.Info(Globals.LogTag, "Count of ServiceUuids: " + count);

            IList<string> list = new List<string>();
            IntPtr[] uuidList = new IntPtr[count];
            Marshal.Copy(uuidListArray, uuidList, 0, count);
            foreach (IntPtr uuids in uuidList)
            {
                list.Add(Marshal.PtrToStringAnsi(uuids));
                Interop.Libc.Free(uuids);
            }

            Interop.Libc.Free(uuidListArray);
            Marshal.FreeHGlobal(scanDataStruct.AdvData);
            Marshal.FreeHGlobal(scanDataStruct.ScanData);
            return list;
        }

        internal string GetLeScanResultDeviceName(BluetoothLeScanData scanData, BluetoothLePacketType packetType)
        {
            if (!BluetoothAdapter.IsBluetoothEnabled || !Globals.IsInitialize)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }

            string deviceName;
            BluetoothLeScanDataStruct scanDataStruct = BluetoothUtils.ConvertLeScanDataToStruct(scanData);

            int ret = Interop.Bluetooth.GetLeScanResultDeviceName(ref scanDataStruct, packetType, out deviceName);
            if (ret == (int)BluetoothError.NoData)
            {
                Log.Info(Globals.LogTag, "No DeviceName in " + GetPacketTypeToString(packetType));
                Marshal.FreeHGlobal(scanDataStruct.AdvData);
                Marshal.FreeHGlobal(scanDataStruct.ScanData);
                return null;
            }
            else if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get Device name- " + (BluetoothError)ret);
                Marshal.FreeHGlobal(scanDataStruct.AdvData);
                Marshal.FreeHGlobal(scanDataStruct.ScanData);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }

            Log.Info(Globals.LogTag, "DeviceName: " + deviceName);
            Marshal.FreeHGlobal(scanDataStruct.AdvData);
            Marshal.FreeHGlobal(scanDataStruct.ScanData);
            return deviceName;
        }

        internal int GetScanResultTxPowerLevel(BluetoothLeScanData scanData, BluetoothLePacketType packetType)
        {
            if (!BluetoothAdapter.IsBluetoothEnabled || !Globals.IsInitialize)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }

            int powerLevel = -1;
            BluetoothLeScanDataStruct scanDataStruct = BluetoothUtils.ConvertLeScanDataToStruct(scanData);

            int ret = Interop.Bluetooth.GetScanResultTxPowerLevel(ref scanDataStruct, packetType, out powerLevel);
            if (ret == (int)BluetoothError.NoData)
            {
                Log.Info(Globals.LogTag, "No TxPowerLevel data in " + GetPacketTypeToString(packetType));
                Marshal.FreeHGlobal(scanDataStruct.AdvData);
                Marshal.FreeHGlobal(scanDataStruct.ScanData);
                return -1;
            }
            else if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get tx power level- " + (BluetoothError)ret);
                Marshal.FreeHGlobal(scanDataStruct.AdvData);
                Marshal.FreeHGlobal(scanDataStruct.ScanData);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }

            Log.Info (Globals.LogTag, "TxPowerLevel: " + powerLevel);
            Marshal.FreeHGlobal(scanDataStruct.AdvData);
            Marshal.FreeHGlobal(scanDataStruct.ScanData);
            return powerLevel;
        }

        internal IList<string> GetScanResultSvcSolicitationUuids(BluetoothLeScanData scanData, BluetoothLePacketType packetType)
        {
            if (!BluetoothAdapter.IsBluetoothEnabled || !Globals.IsInitialize)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }

            IntPtr uuidListArray;
            int count;
            BluetoothLeScanDataStruct scanDataStruct = BluetoothUtils.ConvertLeScanDataToStruct(scanData);

            int ret = Interop.Bluetooth.GetScanResultSvcSolicitationUuids(ref scanDataStruct, packetType, out uuidListArray, out count);
            if (ret == (int)BluetoothError.NoData)
            {
                Log.Info(Globals.LogTag, "No ServiceSolicitationUuids in " + GetPacketTypeToString(packetType));
                Marshal.FreeHGlobal(scanDataStruct.AdvData);
                Marshal.FreeHGlobal(scanDataStruct.ScanData);
                return null;
            }
            else if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get service solicitation uuids " + (BluetoothError)ret);
                Marshal.FreeHGlobal(scanDataStruct.AdvData);
                Marshal.FreeHGlobal(scanDataStruct.ScanData);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }

            Log.Info(Globals.LogTag, "Count of ServiceSolicitationUuids: " + count);

            IList<string> list = new List<string>();
            IntPtr[] uuidList = new IntPtr[count];
            Marshal.Copy(uuidListArray, uuidList, 0, count);
            foreach (IntPtr uuids in uuidList)
            {
                list.Add(Marshal.PtrToStringAnsi(uuids));
                Interop.Libc.Free(uuids);
            }

            Interop.Libc.Free(uuidListArray);
            Marshal.FreeHGlobal(scanDataStruct.AdvData);
            Marshal.FreeHGlobal(scanDataStruct.ScanData);
            return list;
        }

        internal IList<BluetoothLeServiceData> GetScanResultServiceDataList(BluetoothLeScanData scanData, BluetoothLePacketType packetType)
        {
            if (!BluetoothAdapter.IsBluetoothEnabled || !Globals.IsInitialize)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }

            IntPtr serviceListArray;
            _serviceListCount = 0;
            BluetoothLeScanDataStruct scanDataStruct = BluetoothUtils.ConvertLeScanDataToStruct(scanData);

            int ret = Interop.Bluetooth.GetScanResultServiceDataList(ref scanDataStruct, packetType, out serviceListArray, out _serviceListCount);
            if (ret == (int)BluetoothError.NoData)
            {
                Log.Info(Globals.LogTag, "No ServiceDataList in " + GetPacketTypeToString(packetType));
                Marshal.FreeHGlobal(scanDataStruct.AdvData);
                Marshal.FreeHGlobal(scanDataStruct.ScanData);
                return null;
            }
            if (ret != (int)BluetoothError.None)
            {
                Log.Info(Globals.LogTag, "Failed to get Service Data List, Error - " + (BluetoothError)ret);
                Marshal.FreeHGlobal(scanDataStruct.AdvData);
                Marshal.FreeHGlobal(scanDataStruct.ScanData);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }

            Log.Info(Globals.LogTag, "Count of ServiceDataList: " + _serviceListCount);

            int sizePointerToABC = Marshal.SizeOf(new BluetoothLeServiceDataStruct());
            for (int i = 0; i < _serviceListCount; i++)
            {
                var svc = (BluetoothLeServiceDataStruct)Marshal.PtrToStructure(new IntPtr(serviceListArray.ToInt32() + (i * sizePointerToABC)), typeof(BluetoothLeServiceDataStruct));
                _list.Add(BluetoothUtils.ConvertStructToLeServiceData(svc));
            }

            Interop.Libc.Free(serviceListArray);
            Marshal.FreeHGlobal(scanDataStruct.AdvData);
            Marshal.FreeHGlobal(scanDataStruct.ScanData);
            return _list;
        }

        internal int FreeServiceDataList()
        {
            if (_list.Count > 0)
            {
                int iServiceDataSize = Marshal.SizeOf(typeof(BluetoothLeServiceData));
                IntPtr structServiceData = Marshal.AllocHGlobal(iServiceDataSize);
                Marshal.StructureToPtr(_list, structServiceData, false);

                int ret = Interop.Bluetooth.FreeServiceDataList(structServiceData, _serviceListCount);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to free Service Data List, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }

                Marshal.FreeHGlobal(structServiceData);
            }
            return 0;
        }

        internal int GetScanResultAppearance(BluetoothLeScanData scanData, BluetoothLePacketType packetType)
        {
            if (!BluetoothAdapter.IsBluetoothEnabled || !Globals.IsInitialize)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }

            int appearance = -1;
            BluetoothLeScanDataStruct scanDataStruct = BluetoothUtils.ConvertLeScanDataToStruct(scanData);

            int ret = Interop.Bluetooth.GetScanResultAppearance(ref scanDataStruct, packetType, out appearance);
            if (ret == (int)BluetoothError.NoData)
            {
                Log.Info(Globals.LogTag, "No Appearance in " + GetPacketTypeToString(packetType));
                Marshal.FreeHGlobal(scanDataStruct.AdvData);
                Marshal.FreeHGlobal(scanDataStruct.ScanData);
                return -1;
            }
            else if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get Appearance value- " + (BluetoothError)ret);
                Marshal.FreeHGlobal(scanDataStruct.AdvData);
                Marshal.FreeHGlobal(scanDataStruct.ScanData);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }

            Marshal.FreeHGlobal(scanDataStruct.AdvData);
            Marshal.FreeHGlobal(scanDataStruct.ScanData);
            return appearance;
        }

        internal ManufacturerData GetScanResultManufacturerData(BluetoothLeScanData scanData, BluetoothLePacketType packetType)
        {
            if (!BluetoothAdapter.IsBluetoothEnabled || !Globals.IsInitialize)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }

            int dataId = 0;
            int dataLength = 0;
            IntPtr manufData;
            BluetoothLeScanDataStruct scanDataStruct = BluetoothUtils.ConvertLeScanDataToStruct(scanData);

            int ret = Interop.Bluetooth.GetScanResultManufacturerData(ref scanDataStruct, packetType, out dataId, out manufData, out dataLength);
            if (ret == (int)BluetoothError.NoData)
            {
                Log.Info(Globals.LogTag, "No ManufacturerData in " + GetPacketTypeToString(packetType));
                Marshal.FreeHGlobal(scanDataStruct.AdvData);
                Marshal.FreeHGlobal(scanDataStruct.ScanData);
                return null;
            }
            else if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get Manufacturer data - " + (BluetoothError)ret);
                Marshal.FreeHGlobal(scanDataStruct.AdvData);
                Marshal.FreeHGlobal(scanDataStruct.ScanData);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }

            Log.Info(Globals.LogTag, "Count of ManufacturerData: " + dataLength);

            ManufacturerData data = new ManufacturerData();
            data.Id = dataId;
            data.DataLength = dataLength;
            if (data.DataLength > 0)
            {
                data.Data = new byte[data.DataLength];
                Marshal.Copy(manufData, data.Data, 0, data.DataLength);
            }

            Interop.Libc.Free(manufData);
            Marshal.FreeHGlobal(scanDataStruct.AdvData);
            Marshal.FreeHGlobal(scanDataStruct.ScanData);
            return data;
        }

        internal int GattConnect(string remoteAddress, bool autoConnect)
        {
            int ret = Interop.Bluetooth.GattConnect (remoteAddress, autoConnect);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to establish GATT connection - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            return ret;
        }

        internal int GattDisconnect(string remoteAddress)
        {
            int ret = Interop.Bluetooth.GattDisconnect (remoteAddress);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to disconnect GATT connection - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            return ret;
        }

        internal int CreateAdvertiser(out IntPtr advertiserHandle)
        {
            return Interop.Bluetooth.CreateAdvertiser (out advertiserHandle);
        }

        internal int DestroyAdvertiser(IntPtr advertiserHandle)
        {
            int ret =  Interop.Bluetooth.DestroyAdvertiser (advertiserHandle);
            if (ret != (int)BluetoothError.None) {
                Log.Error(Globals.LogTag, "Failed to destroy the Advertiser- " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            return ret;
        }

        internal int StartAdvertising(IntPtr advertisingHandle)
        {
            _advertisingStateChangedCallback = (int result, IntPtr advertiserHandle,
                            BluetoothLeAdvertisingState state, IntPtr userData) =>
            {
                Log.Info(Globals.LogTag, "Setting advertising state changed callback !! " );
                AdvertisingStateChangedEventArgs e = new AdvertisingStateChangedEventArgs(result, advertiserHandle, state);
                _advertisingStateChanged(null, e);
            };

            IntPtr uData = IntPtr.Zero;
            int ret = Interop.Bluetooth.BluetoothLeStartAdvertising (advertisingHandle,
                                   _advertisingStateChangedCallback, uData );
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to start BLE advertising - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            return ret;
        }


        internal int StopAdvertising(IntPtr advertisingHandle)
        {
            return Interop.Bluetooth.BluetoothLeStopAdvertising (advertisingHandle);
        }
    }
}

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

namespace Tizen.Network.Bluetooth
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.Network.Bluetooth";
        internal static bool IsInitialize = false;
        internal static bool IsAudioInitialize = false;
        internal static bool IsHidInitialize = false;
        internal static bool IsOppServerInitialized = false;
        internal static bool IsOppClientInitialized = false;
    }

    internal partial class BluetoothAdapterImpl : IDisposable
    {
        private event EventHandler<StateChangedEventArgs> _stateChanged;
        private event EventHandler<NameChangedEventArgs> _nameChanged;
        private event EventHandler<VisibilityModeChangedEventArgs> _visibilityModeChanged;
        private event EventHandler<VisibilityDurationChangedEventArgs> _visibilityDurationChanged;
        private event EventHandler<DiscoveryStateChangedEventArgs> _discoveryStateChanged;

        private Interop.Bluetooth.StateChangedCallback _stateChangedCallback;
        private Interop.Bluetooth.NameChangedCallback _nameChangedCallback;
        private Interop.Bluetooth.VisibilityModeChangedCallback _visibilityChangedCallback;
        private Interop.Bluetooth.VisibilityDurationChangedCallback _visibilitydurationChangedCallback;
        private Interop.Bluetooth.DiscoveryStateChangedCallback _discoveryStateChangedCallback;
        private Interop.Bluetooth.BondedDeviceCallback _bondedDeviceCallback;

        private static readonly BluetoothAdapterImpl _instance = new BluetoothAdapterImpl();
        private bool disposed = false;

        internal event EventHandler<StateChangedEventArgs> StateChanged
        {
            add
            {
                if (_stateChanged == null)
                {
                    RegisterStateChangedEvent();
                }
                _stateChanged += value;
            }
            remove
            {
                _stateChanged -= value;
                if (_stateChanged == null)
                {
                    UnregisterStateChangedEvent();
                }
            }
        }

        internal event EventHandler<NameChangedEventArgs> NameChanged
        {
            add
            {
                if (_nameChanged == null)
                {
                    RegisterNameChangedEvent();
                }
                _nameChanged += value;
            }
            remove
            {
                _nameChanged -= value;
                if (_nameChanged == null)
                {
                    UnregisterNameChangedEvent();
                }
            }
        }

        internal event EventHandler<VisibilityModeChangedEventArgs> VisibilityModeChanged
        {
            add
            {
                if (_visibilityModeChanged == null)
                {
                    RegisterVisibilityChangedEvent();
                }
                _visibilityModeChanged += value;
            }
            remove
            {
                _visibilityModeChanged -= value;
                if (_visibilityModeChanged == null)
                {
                    UnregisterVisibilityChangedEvent();
                }
            }
        }

        internal event EventHandler<VisibilityDurationChangedEventArgs> VisibilityDurationChanged
        {
            add
            {
                if (_visibilityDurationChanged == null)
                {
                    RegisterVisibilityDurationChangedEvent();
                }
                _visibilityDurationChanged += value;
            }
            remove
            {
                _visibilityDurationChanged -= value;
                if (_visibilityDurationChanged == null)
                {
                    UnregisterVisibilityDurationChangedEvent();
                }
            }
        }

        internal event EventHandler<DiscoveryStateChangedEventArgs> DiscoveryStateChanged
        {
            add
            {
                if (_discoveryStateChanged == null)
                {
                    RegisterDiscoveryStateChangedEvent();
                }
                _discoveryStateChanged+= value;
            }
            remove
            {
                _discoveryStateChanged -= value;
                if (_discoveryStateChanged == null)
                {
                    UnregisterDiscoveryStateChangedEvent();
                }
            }
        }

        private void RegisterStateChangedEvent()
        {
            _stateChangedCallback = (int result, int state, IntPtr userData) =>
            {
                if (_stateChanged != null)
                {
                    BluetoothState st = (BluetoothState)state;
                    BluetoothError res = (BluetoothError)result;
                    _stateChanged(null, new StateChangedEventArgs(res,st));
                }
            };
            int ret = Interop.Bluetooth.SetStateChangedCallback(_stateChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set state changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterStateChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetStateChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset state changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void RegisterNameChangedEvent()
        {
            _nameChangedCallback = (string deviceName, IntPtr userData) =>
            {
                if (_nameChanged != null)
                {
                    _nameChanged(null, new NameChangedEventArgs(deviceName));
                }
            };
            int ret = Interop.Bluetooth.SetNameChangedCallback(_nameChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set name changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterNameChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetNameChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset name changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void RegisterVisibilityChangedEvent()
        {
            _visibilityChangedCallback = (int result, int mode, IntPtr userData) =>
            {
                if (_visibilityModeChanged != null)
                {
                    VisibilityMode visibility = (VisibilityMode)mode;
                    BluetoothError res = (BluetoothError)result;
                    _visibilityModeChanged(null, new VisibilityModeChangedEventArgs(res,visibility));
                }
            };
            int ret = Interop.Bluetooth.SetVisibilityModeChangedCallback(_visibilityChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set visibility mode changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterVisibilityChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetVisibilityModeChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset visibility mode changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void RegisterVisibilityDurationChangedEvent()
        {
            _visibilitydurationChangedCallback = (int duration, IntPtr userData) =>
            {
                if (_visibilityDurationChanged != null)
                {
                    _visibilityDurationChanged(null, new VisibilityDurationChangedEventArgs(duration));
                }
            };
            int ret = Interop.Bluetooth.SetVisibilityDurationChangedCallback(_visibilitydurationChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set visibility duration changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterVisibilityDurationChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetVisibilityDurationChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset visiiblity duration changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void RegisterDiscoveryStateChangedEvent()
        {
            _discoveryStateChangedCallback = (int result, BluetoothDeviceDiscoveryState state, IntPtr deviceInfo, IntPtr userData) =>
            {
                Log.Info(Globals.LogTag, "Discovery state changed callback is called");
                if (_discoveryStateChanged != null)
                {
                    BluetoothError res = (BluetoothError)result;
                    switch(state)
                    {
                    case BluetoothDeviceDiscoveryState.Started:
                        _discoveryStateChanged(null, new DiscoveryStateChangedEventArgs(res,state));
                        break;
                    case BluetoothDeviceDiscoveryState.Finished:
                        {
                            _discoveryStateChanged(null, new DiscoveryStateChangedEventArgs(res,state));
                            break;
                        }
                    case BluetoothDeviceDiscoveryState.Found:
                        {
                            BluetoothDiscoveredDeviceStruct info = (BluetoothDiscoveredDeviceStruct)Marshal.PtrToStructure(deviceInfo, typeof(BluetoothDiscoveredDeviceStruct));
                            _discoveryStateChanged(null, new DiscoveryStateChangedEventArgs(res,state,BluetoothUtils.ConvertStructToDiscoveredDevice(info)));
                            break;
                        }
                    default:
                        break;
                    }
                }
            };
            int ret = Interop.Bluetooth.SetDiscoveryStateChangedCallback(_discoveryStateChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set discovery state changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterDiscoveryStateChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetDiscoveryStateChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset discovery state changed callback, Error - " + (BluetoothError)ret);
            }
        }

        internal bool IsBluetoothEnabled
        {
            get
            {
                BluetoothState active;
                int ret = Interop.Bluetooth.GetState(out active);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get state, Error - " + (BluetoothError)ret);
                }
                if (active == BluetoothState.Enabled)
                    return true;
                else
                    return false;
            }
        }
        internal string Address
        {
            get
            {
                string address;
                int ret = Interop.Bluetooth.GetAddress(out address);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get address, Error - " + (BluetoothError)ret);
                    return "";
                }
                return address;
            }
        }

        internal VisibilityMode Visibility
        {
            get
            {
                int visibilityMode;
                int time;
                int ret = Interop.Bluetooth.GetVisibility(out visibilityMode, out time);
                if(ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get visibility mode, Error - " + (BluetoothError)ret);
                    return VisibilityMode.NonDiscoverable;
                }
                return (VisibilityMode)visibilityMode;
            }
        }

        internal bool IsDiscoveryInProgress
        {
            get
            {
                bool isDiscovering;
                int ret = Interop.Bluetooth.IsDiscovering(out isDiscovering);
                if(ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get discovery progress state, Error - " + (BluetoothError)ret);
                }
                return isDiscovering;
            }
        }

        internal int RemainingTimeAsVisible
        {
            get
            {
                int duration = 0;
                int visibilityMode;
                int ret = Interop.Bluetooth.GetVisibility(out visibilityMode, out duration);
                if ((ret != (int)BluetoothError.None) || ((VisibilityMode)visibilityMode != VisibilityMode.TimeLimitedDiscoverable))
                {
                    Log.Error(Globals.LogTag, "Failed to get remaining visible time, Error - " + (BluetoothError)ret);
                }
                return duration;
            }
        }

        internal string Name
        {
            get
            {
                string name;
                int ret = Interop.Bluetooth.GetName(out name);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get adapter name, Error - " + (BluetoothError)ret);
                    return "";
                }
                return name;
            }
            set
            {
                int ret = Interop.Bluetooth.SetName(value.ToString());
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set adapter name, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
        }

        internal void Enable()
        {
            if (Globals.IsInitialize)
            {
                int ret = Interop.Bluetooth.EnableAdapter();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to enable adapter, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotInitialized);
            }
        }

        internal void Disable()
        {
            if (IsBluetoothEnabled)
            {
                int ret = Interop.Bluetooth.DisableAdapter();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to disable adapter, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        internal void SetVisibility(VisibilityMode mode, int timeout)
        {
            if (IsBluetoothEnabled)
            {
                int ret = Interop.Bluetooth.SetVisibility(mode, timeout);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set visibility, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        internal void StartDiscovery()
        {
            int ret = Interop.Bluetooth.StartDiscovery();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to start discovery, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void StopDiscovery()
        {
            int ret = Interop.Bluetooth.StopDiscovery();
            if(ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to stop discovery, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal IEnumerable<BluetoothDevice> GetBondedDevices()
        {
            List<BluetoothDevice> deviceList = new List<BluetoothDevice>();
            _bondedDeviceCallback = (ref BluetoothDeviceStruct deviceInfo, IntPtr userData) =>
            {
                Log.Info(Globals.LogTag, "Bonded devices cb is called");
                if(!deviceInfo.Equals(null))
                {
                    deviceList.Add(BluetoothUtils.ConvertStructToDeviceClass(deviceInfo));
                }
                return true;
            };
            int ret = Interop.Bluetooth.GetBondedDevices(_bondedDeviceCallback, IntPtr.Zero);
            if(ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get bonded devices, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            return deviceList;
        }

        internal BluetoothDevice GetBondedDevice(string address)
        {
            IntPtr deviceInfo;
            BluetoothDevice btDevice;
            int ret = Interop.Bluetooth.GetBondedDeviceByAddress(address, out deviceInfo);
            if(ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get bonded device by address, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            BluetoothDeviceStruct device = (BluetoothDeviceStruct)Marshal.PtrToStructure(deviceInfo, typeof(BluetoothDeviceStruct));
            btDevice = BluetoothUtils.ConvertStructToDeviceClass(device);
            Interop.Bluetooth.FreeDeviceInfo(deviceInfo);
            return btDevice;
        }

        internal bool IsServiceUsed(string serviceUuid)
        {
            bool isUsed;
            int ret = Interop.Bluetooth.IsServiceUsed(serviceUuid, out isUsed);
            if(ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to check the usage of service, Error - " + (BluetoothError)ret);
            }
            return isUsed;
        }

        internal BluetoothOobData GetLocalOobData()
        {
            BluetoothOobData oobData = new BluetoothOobData();
            IntPtr hash;
            IntPtr randomizer;
            int hashLength;
            int randomizerLength;
            int ret = Interop.Bluetooth.GetOobData(out hash, out randomizer, out hashLength, out randomizerLength);
            if(ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get the local oob data, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }

            if (hashLength > 0) {
                byte[] hashArr = new byte[hashLength];
                Marshal.Copy(hash, hashArr, 0, hashLength);
                oobData.HashValue = hashArr;
                Interop.Libc.Free(hash);
            }

            if (randomizerLength > 0) {
                byte[] randomizerArr = new byte[randomizerLength];
                Marshal.Copy(randomizer, randomizerArr, 0, randomizerLength);
                oobData.RandomizerValue = randomizerArr;
                Interop.Libc.Free(randomizer);
            }

            return oobData;
        }

        internal void SetRemoteOobData(string deviceAddress, BluetoothOobData oobData)
        {
            byte[] hash = oobData.HashValue;
            byte[] randomizer = oobData.RandomizerValue;
            int hashLength = hash.Length;
            int randomizerLength = randomizer.Length;

            IntPtr hashPtr = Marshal.AllocHGlobal(hashLength);
            Marshal.Copy(hash, 0, hashPtr, hashLength);
            IntPtr randomizerPtr = Marshal.AllocHGlobal(randomizerLength);
            Marshal.Copy(randomizer, 0, randomizerPtr, randomizerLength);

            int ret = Interop.Bluetooth.SetOobData(deviceAddress, hashPtr, randomizerPtr, hashLength, randomizerLength);
            if(ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set the remote oob data, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void RemoveRemoteOobData(string deviceAddress)
        {
            int ret = Interop.Bluetooth.RemoveOobData(deviceAddress);
            if(ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove the remote oob data, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal BluetoothServerSocket CreateServerSocket(string serviceUuid)
        {
            int socketFd;
            int ret = Interop.Bluetooth.CreateServerSocket(serviceUuid, out socketFd);
            if(ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create server socket, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            Log.Info (Globals.LogTag, "Created socketfd: "+ socketFd);
            return new BluetoothServerSocket(socketFd);
        }

        internal void DestroyServerSocket(BluetoothServerSocket socket)
        {
            int ret = Interop.Bluetooth.DestroyServerSocket(socket.socketFd);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to destroy socket, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal static BluetoothAdapterImpl Instance
        {
            get
            {
                return _instance;
            }
        }

        private BluetoothAdapterImpl()
        {
            initialize();
        }

        ~BluetoothAdapterImpl()
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
            RemoveAllRegisteredEvent();
            deinitialize();
            disposed = true;
        }

        private void initialize()
        {
            int ret = Interop.Bluetooth.Initialize();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error (Globals.LogTag, "Failed to initialize bluetooth, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException (ret);
            }
            else
            {
                Globals.IsInitialize = true;
            }
        }

        private void deinitialize()
        {
            int ret = Interop.Bluetooth.Deinitialize();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error (Globals.LogTag, "Failed to deinitialize bluetooth, Error - " + (BluetoothError)ret);
            }
            else
            {
                Globals.IsInitialize = false;
            }
        }

        private void RemoveAllRegisteredEvent()
        {
            //unregister all remaining events when this object is released.
            if (_stateChanged != null)
            {
                UnregisterStateChangedEvent();
            }

            if (_nameChanged != null)
            {
                UnregisterNameChangedEvent();
            }

            if (_visibilityDurationChanged != null)
            {
                UnregisterVisibilityDurationChangedEvent();
            }

            if (_visibilityModeChanged != null)
            {
                UnregisterVisibilityChangedEvent();
            }

            if (_discoveryStateChanged != null)
            {
                UnregisterDiscoveryStateChangedEvent();
            }
        }
    }
}

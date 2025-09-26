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
using System.Threading;

namespace Tizen.Network.WiFiDirect
{
    internal class WiFiDirectThreadLocal
    {
        private int _threadId;
        internal WiFiDirectThreadLocal(int id)
        {
            _threadId = id;
        }

        public int ThreadId
        {
            get
            {
                return _threadId;
            }
        }

        ~WiFiDirectThreadLocal()
        {
            Log.Info(Globals.LogTag, "Deinitializing Wi-Fi direct");
            int ret = Interop.WiFiDirect.Deinitialize();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to deinitialize Wi-Fi direct, Error - " + (WiFiDirectError)ret);
                if (ret != (int)WiFiDirectError.NotInitialized)
                {
                    WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                }
            }

            else
            {
                Globals.s_isInitialize = false;
            }
        }
    }

    internal static class Globals
    {
        internal const string LogTag = "Tizen.Network.WiFiDirect";
        internal static bool s_isInitialize = false;
        internal static bool s_isDisplay = false;
        private static ThreadLocal<WiFiDirectThreadLocal> s_threadName = new ThreadLocal<WiFiDirectThreadLocal>(() =>
        {
            Log.Info(Globals.LogTag, "In threadlocal delegate");
            return new WiFiDirectThreadLocal(Thread.CurrentThread.ManagedThreadId);
        });
        internal static bool IsActivated
        {
            get
            {
                WiFiDirectState _state = WiFiDirectManager.State;
                if (IsInitialize)
                {
                    if (_state == WiFiDirectState.Deactivated || _state == WiFiDirectState.Deactivating)
                    {
                        return false;
                    }

                    else
                    {
                        return true;
                    }
                }

                else
                {
                    return false;
                }
            }
        }

        private static bool IsUniqueThread()
        {
            if (s_threadName.IsValueCreated)
            {
                Log.Info(Globals.LogTag, "This thread is old");
                return false;
            }

            else
            {
                WiFiDirectThreadLocal obj = s_threadName.Value;
                Log.Info(Globals.LogTag, "This thread is new , Id = " + obj.ThreadId);
                return true;
            }
        }

        internal static bool IsInitialize
        {
            get
            {
                if(Globals.IsUniqueThread() || !Globals.s_isInitialize)
                {
                    WiFiDirectManagerImpl.Instance.Initialize();
                }

                return (Globals.s_isInitialize);
            }
        }
    }

    /// <summary>
    /// The implementation of Wi-Fi Direct APIs.
    /// </summary>
    internal partial class WiFiDirectManagerImpl : IDisposable
    {
        private event EventHandler<StateChangedEventArgs> _stateChanged;
        private event EventHandler<DiscoveryStateChangedEventArgs > _discoveryStateChanged;
        private event EventHandler<PeerFoundEventArgs > _peerFound;
        private event EventHandler<DeviceStateChangedEventArgs > _deviceStateChanged;
        private event EventHandler<ConnectionStatusChangedEventArgs > _connectionStatusChanged;

        private Interop.WiFiDirect.StateChangedCallback _stateChangedCallback;
        private Interop.WiFiDirect.DiscoveryStateChangedCallback _discoveryStateChangedCallback;
        private Interop.WiFiDirect.PeerFoundCallback _peerFoundCallback;
        private Interop.WiFiDirect.DeviceStateChangedCallback _deviceStateChangedCallback;
        private Interop.WiFiDirect.ConnectionStateChangedCallback _connectionChangedCallback;

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

        internal event EventHandler<DiscoveryStateChangedEventArgs> DiscoveryStateChanged
        {
            add
            {
                if (_discoveryStateChanged == null)
                {
                    RegisterDiscoveryStateChangedEvent();
                }

                _discoveryStateChanged += value;
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

        internal event EventHandler<PeerFoundEventArgs> PeerFound
        {
            add
            {
                if (_peerFound == null)
                {
                    RegisterPeerFoundEvent();
                }

                _peerFound += value;
            }

            remove
            {
                _peerFound -= value;
                if (_peerFound == null)
                {
                    UnregisterPeerFoundEvent();
                }
            }
        }

        internal event EventHandler<DeviceStateChangedEventArgs> DeviceStateChanged
        {
            add
            {
                if (_deviceStateChanged == null)
                {
                    RegisterDeviceStateChangedEvent();
                }

                _deviceStateChanged += value;
            }

            remove
            {
                _deviceStateChanged -= value;
                if (_deviceStateChanged == null)
                {
                    UnregisterDeviceStateChangedEvent();
                }
            }
        }

        internal event EventHandler<ConnectionStatusChangedEventArgs> ConnectionStatusChanged
        {
            add
            {
                if (_connectionStatusChanged == null)
                {
                    RegisterConnectionStatusChangedEvent();
                }

                _connectionStatusChanged += value;
            }

            remove
            {
                _connectionStatusChanged -= value;
                if (_connectionStatusChanged == null)
                {
                    UnregisterConnectionStatusChangedEvent();
                }
            }
        }

        private bool _disposed = false;
        private static WiFiDirectManagerImpl _instance;

        private void RegisterStateChangedEvent()
        {
            _stateChangedCallback = (WiFiDirectState stateInfo, IntPtr userData) =>
            {
                if (_stateChanged != null)
                {
                    WiFiDirectState state = stateInfo;
                    _stateChanged(null, new StateChangedEventArgs(state));
                }
            };
            int ret = Interop.WiFiDirect.SetStateChangedCallback(_stateChangedCallback, IntPtr.Zero);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set Wi-Fi Direct state changed callback, Error - " + (WiFiDirectError)ret);
            }
        }

        private void UnregisterStateChangedEvent()
        {
            int ret = Interop.WiFiDirect.UnsetStateChangedCallback();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset Wi-Fi Direct state changed callback, Error - " + (WiFiDirectError)ret);
            }
        }

        private void RegisterDiscoveryStateChangedEvent()
        {
            _discoveryStateChangedCallback = (int result, WiFiDirectDiscoveryState stateInfo, IntPtr userData) =>
            {
                if (_discoveryStateChanged != null)
                {
                    WiFiDirectError error = (WiFiDirectError)result;
                    WiFiDirectDiscoveryState state = stateInfo;
                    _discoveryStateChanged(null, new DiscoveryStateChangedEventArgs(error, state));
                }
            };
            int ret = Interop.WiFiDirect.SetDiscoveryStateChangedCallback(_discoveryStateChangedCallback, IntPtr.Zero);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set Wi-Fi Direct discovery state changed callback, Error - " + (WiFiDirectError)ret);
            }
        }

        private void UnregisterDiscoveryStateChangedEvent()
        {
            int ret = Interop.WiFiDirect.UnsetDiscoveryStateChangedCallback();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset Wi-Fi Direct discovery state changed callback, Error - " + (WiFiDirectError)ret);
            }
        }

        private void RegisterPeerFoundEvent()
        {
            _peerFoundCallback = (int result, WiFiDirectDiscoveryState stateInfo, string address, IntPtr userData) =>
            {
                if (_peerFound != null && stateInfo == WiFiDirectDiscoveryState.Found)
                {
                    WiFiDirectError error = (WiFiDirectError)result;
                    WiFiDirectDiscoveryState state = stateInfo;
                    IntPtr peer;
                    Interop.WiFiDirect.GetDiscoveredPeerInfo(address, out peer);
                    DiscoveredPeerStruct peerStruct = (DiscoveredPeerStruct)Marshal.PtrToStructure(peer, typeof(DiscoveredPeerStruct));
                    _peerFound(null, new PeerFoundEventArgs(error, state, WiFiDirectUtils.ConvertStructToDiscoveredPeer(peerStruct)));
                }
            };
            int ret = Interop.WiFiDirect.SetPeerFoundCallback(_peerFoundCallback, IntPtr.Zero);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set Wi-Fi Direct discovery state changed callback, Error - " + (WiFiDirectError)ret);
            }
        }

        private void UnregisterPeerFoundEvent()
        {
            int ret = Interop.WiFiDirect.UnsetPeerFoundCallback();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset Wi-Fi Direct discovery state changed callback, Error - " + (WiFiDirectError)ret);
            }
        }

        private void RegisterDeviceStateChangedEvent()
        {
            _deviceStateChangedCallback = (int result, WiFiDirectDeviceState stateInfo, IntPtr userData) =>
            {
                if (_deviceStateChanged != null)
                {
                    WiFiDirectError error = (WiFiDirectError)result;
                    WiFiDirectDeviceState state = stateInfo;
                    _deviceStateChanged(null, new DeviceStateChangedEventArgs(error, state));
                }
            };
            int ret = Interop.WiFiDirect.SetDeviceStateChangedCallback(_deviceStateChangedCallback, IntPtr.Zero);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set device state changed callback, Error - " + (WiFiDirectError)ret);
            }
        }

        private void UnregisterDeviceStateChangedEvent()
        {
            int ret = Interop.WiFiDirect.UnsetDeviceStateChangedCallback();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset device state changed callback, Error - " + (WiFiDirectError)ret);
            }
        }

        private void RegisterConnectionStatusChangedEvent()
        {
            _connectionChangedCallback = (int result, WiFiDirectConnectionState stateInfo, string address, IntPtr userData) =>
            {
                if (_connectionStatusChanged != null)
                {
                    WiFiDirectError error = (WiFiDirectError)result;
                    WiFiDirectConnectionState state = stateInfo;

                    _connectionStatusChanged(null, new ConnectionStatusChangedEventArgs(error, state));
                }
            };
            int ret = Interop.WiFiDirect.SetConnectionChangedCallback(_connectionChangedCallback, IntPtr.Zero);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set connection status changed callback, Error - " + (WiFiDirectError)ret);
            }
        }

        private void UnregisterConnectionStatusChangedEvent()
        {
            int ret = Interop.WiFiDirect.UnsetConnectionChangedCallback();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset connection status changed callback, Error - " + (WiFiDirectError)ret);
            }
        }

        internal bool IsInitialize
	{
		get
		{
		    return Globals.IsInitialize;
		}
	}
        internal bool IsGroupOwner
        {
            get
            {
                bool isGroupOwner;
                int ret = Interop.WiFiDirect.IsGroupOwner(out isGroupOwner);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get whether this device is the group owner or not, Error - " + (WiFiDirectError)ret);
                }

                return isGroupOwner;
            }
        }

        internal bool IsAutonomousGroup
        {
            get
            {
                bool isAutonomousGroup;
                int ret = Interop.WiFiDirect.IsAutonomousGroup(out isAutonomousGroup);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to check whether the current group is autonomous or not, Error - " + (WiFiDirectError)ret);
                }

                return isAutonomousGroup;
            }
        }

        internal string Ssid
        {
            get
            {
                string ssid;
                int ret = Interop.WiFiDirect.GetSsid(out ssid);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get SSID of local device, Error - " + (WiFiDirectError)ret);
                    return null;
                }

                return ssid;
            }
        }

        internal string NetworkInterface
        {
            get
            {
                string networkInterface;
                int ret = Interop.WiFiDirect.GetInterfaceName(out networkInterface);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get name of network interface, Error - " + (WiFiDirectError)ret);
                    return "";
                }

                return networkInterface;
            }
        }

        internal string IpAddress
        {
            get
            {
                string ipAddress;
                int ret = Interop.WiFiDirect.GetIpAddress(out ipAddress);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get IP address of local device, Error - " + (WiFiDirectError)ret);
                    return "";
                }

                return ipAddress;
            }
        }

        internal string SubnetMask
        {
            get
            {
                string subnetMask;
                int ret = Interop.WiFiDirect.GetSubnetMask(out subnetMask);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get subnet mask, Error - " + (WiFiDirectError)ret);
                    return "";
                }

                return subnetMask;
            }
        }

        internal string GatewayAddress
        {
            get
            {
                string gatewayAddress;
                int ret = Interop.WiFiDirect.GetGatewayAddress(out gatewayAddress);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get gateway address, Error - " + (WiFiDirectError)ret);
                    return "";
                }

                return gatewayAddress;
            }
        }

        internal string MacAddress
        {
            get
            {
                string macAddress;
                int ret = Interop.WiFiDirect.GetMacAddress(out macAddress);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get mac address, Error - " + (WiFiDirectError)ret);
                    return null;
                }

                return macAddress;
            }
        }

        internal WiFiDirectState State
        {
            get
            {
                WiFiDirectState state;
                int ret = Interop.WiFiDirect.GetState(out state);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get state of Wi-Fi direct service, Error - " + (WiFiDirectError)ret);
                }

                return state;
            }
        }

        internal bool IsDiscoverable
        {
            get
            {
                bool isDiscoverable;
                int ret = Interop.WiFiDirect.IsDiscoverable(out isDiscoverable);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to check whether the device is discoverable, Error - " + (WiFiDirectError)ret);
                }

                return isDiscoverable;
            }
        }

        internal bool IsListenOnly
        {
            get
            {
                bool isListenOnly;
                int ret = Interop.WiFiDirect.IsListeningOnly(out isListenOnly);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to check whether the local device is listening only, Error - " + (WiFiDirectError)ret);
                }

                return isListenOnly;
            }
        }

        internal WiFiDirectPrimaryDeviceType PrimaryType
        {
            get
            {
                WiFiDirectPrimaryDeviceType primaryType;
                int ret = Interop.WiFiDirect.GetPrimaryType(out primaryType);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get the primary device type of local device, Error - " + (WiFiDirectError)ret);
                }

                return primaryType;
            }
        }

        internal WiFiDirectSecondaryDeviceType SecondaryType
        {
            get
            {
                WiFiDirectSecondaryDeviceType secondaryType;
                int ret = Interop.WiFiDirect.GetSecondaryType(out secondaryType);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get the secondary device type of local device, Error - " + (WiFiDirectError)ret);
                }

                return secondaryType;
            }
        }

        internal int WpsMode
        {
            get
            {
                int mode;
                int ret = Interop.WiFiDirect.GetWpsMode(out mode);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get supproted wps modes at local device, Error - " + (WiFiDirectError)ret);
                    return -1;
                }

                return mode;
            }
        }

        internal WiFiDirectWpsType WpsType
        {
            get
            {
                WiFiDirectWpsType wpsType;
                int ret = Interop.WiFiDirect.GetLocalWpsType(out wpsType);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get the WPS type, Error - " + (WiFiDirectError)ret);
                }

                return wpsType;
            }
        }

        internal int OperatingChannel
        {
            get
            {
                int channel;
                int ret = Interop.WiFiDirect.GetChannel(out channel);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get operating channel, Error - " + (WiFiDirectError)ret);
                    return -1;
                }

                return channel;
            }
        }

        internal bool PersistentGroupEnabled
        {
            get
            {
                bool isEnabled;
                int ret = Interop.WiFiDirect.GetPersistentGroupState(out isEnabled);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to check persistent group state, Error - " + (WiFiDirectError)ret);
                }

                return isEnabled;
            }

            set
            {
                int ret = Interop.WiFiDirect.SetPersistentGroupState(value);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set the persistent group state, Error - " + (WiFiDirectError)ret);
                    WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                }
            }
        }

        internal bool AutoConnect
        {
            get
            {
                bool isAutoConnect;
                int ret = Interop.WiFiDirect.GetAutoConnectionMode(out isAutoConnect);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get autoconnection mode status, Error - " + (WiFiDirectError)ret);
                }

                return isAutoConnect;
            }

            set
            {
                int ret = Interop.WiFiDirect.SetAutoConnectionMode(value);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set the autoconnection mode, Error - " + (WiFiDirectError)ret);
                    WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                }
            }
        }

        internal string WpsPin
        {
            get
            {
                string pin;
                int ret = Interop.WiFiDirect.GetWpsPin(out pin);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get WPS pin, Error - " + (WiFiDirectError)ret);
                }

                return pin;
            }

            set
            {
                int ret = Interop.WiFiDirect.SetWpsPin(value.ToString());
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set or update WPS pin, Error - " + (WiFiDirectError)ret);
                    WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                }
            }
        }

        internal string Name
        {
            get
            {
                string name;
                int ret = Interop.WiFiDirect.GetName(out name);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get name of local device, Error - " + (WiFiDirectError)ret);
                    return null;
                }

                return name;
            }

            set
            {
                int ret = Interop.WiFiDirect.SetName(value.ToString());
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set name of local device, Error - " + (WiFiDirectError)ret);
                    WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                }
            }
        }

        internal WiFiDirectWpsType RequestedWps
        {
            get
            {
                WiFiDirectWpsType wpsType;
                int ret = Interop.WiFiDirect.GetReqWpsType(out wpsType);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get the requested WPS type, Error - " + (WiFiDirectError)ret);
                }

                return wpsType;
            }

            set
            {
                int ret = Interop.WiFiDirect.SetReqWpsType(value);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set the requested WPS type, Error - " + (WiFiDirectError)ret);
                    WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                }
            }
        }

        internal int GroupOwnerIntent
        {
            get
            {
                int intent;
                int ret = Interop.WiFiDirect.GetIntent(out intent);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get the intent of the group owner, Error - " + (WiFiDirectError)ret);
                }

                return intent;
            }

            set
            {
                int ret = Interop.WiFiDirect.SetIntent(value);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set the intent of the group owner, Error - " + (WiFiDirectError)ret);
                    WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                }
            }
        }

        internal int MaxClients
        {
            get
            {
                int maxClients;
                int ret = Interop.WiFiDirect.GetMaxClients(out maxClients);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get the max number of clients, Error - " + (WiFiDirectError)ret);
                }

                return maxClients;
            }

            set
            {
                int ret = Interop.WiFiDirect.SetMaxClients(value);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set the max number of clients, Error - " + (WiFiDirectError)ret);
                    WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                }
            }
        }

        internal string Passphrase
        {
            get
            {
                string passphrase;
                int ret = Interop.WiFiDirect.GetPassPhrase(out passphrase);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Wi-Fi Protected Access password, Error - " + (WiFiDirectError)ret);
                    return "";
                }

                return passphrase;
            }

            set
            {
                int ret = Interop.WiFiDirect.SetPassPhrase(value.ToString());
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set or update Wi-Fi Protected Access password, Error - " + (WiFiDirectError)ret);
                    WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                }
            }
        }

        internal int SessionTimer
        {
            get
            {
                int sessionTimer;
                int ret = Interop.WiFiDirect.GetSessionTimer(out sessionTimer);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get the timer used to expire the connection session, Error - " + (WiFiDirectError)ret);
                }

                return sessionTimer;
            }

            set
            {
                int ret = Interop.WiFiDirect.SetSessionTimer(value);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set the timer used to expire the connection session, Error - " + (WiFiDirectError)ret);
                    WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                }
            }
        }

        internal void Activate()
        {
            int ret = Interop.WiFiDirect.Activate();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to activate Wi-Fi direct service, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal void Deactivate()
        {
            int ret = Interop.WiFiDirect.Deactivate();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to deactivate Wi-Fi direct service, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal void StartDiscovery(bool listenOnly, int duration, WiFiDirectDiscoveryChannel channel = WiFiDirectDiscoveryChannel.FullScan)
        {
            int ret = Interop.WiFiDirect.StartDiscoveryInChannel(listenOnly, duration, channel);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to start discovery, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal void CancelDiscovery()
        {
            int ret = Interop.WiFiDirect.StopDiscovery();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to cancel discovery, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal IEnumerable<WiFiDirectPeer> GetDiscoveredPeers()
        {
            List<WiFiDirectPeer> discoveredPeerList = new List<WiFiDirectPeer>();
            Interop.WiFiDirect.DiscoveredPeerCallback callback = (ref DiscoveredPeerStruct peer, IntPtr userData) =>
            {
                if (!peer.Equals(null))
                {
                    discoveredPeerList.Add(WiFiDirectUtils.ConvertStructToDiscoveredPeer(peer));
                }

                return true;
            };
            int ret = Interop.WiFiDirect.GetDiscoveredPeers(callback, IntPtr.Zero);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get information of discovered peers, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }

            return discoveredPeerList;
        }

        internal IEnumerable<WiFiDirectPeer> GetConnectedPeers()
        {
            List<WiFiDirectPeer> connectedPeerList = new List<WiFiDirectPeer>();
            Interop.WiFiDirect.ConnectedPeerCallback callback = (ref ConnectedPeerStruct peer, IntPtr userData) =>
            {
                if (!peer.Equals(null))
                {
                    connectedPeerList.Add(WiFiDirectUtils.ConvertStructToConnectedPeer(peer));
                }

                return true;
            };
            int ret = Interop.WiFiDirect.GetConnectedPeers(callback, IntPtr.Zero);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get information of connected peers, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }

            return connectedPeerList;
        }

        internal void DisconnectAll()
        {
            int ret = Interop.WiFiDirect.DisconnectAll();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to disconnect all connected links, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal void CreateGroup()
        {
            int ret = Interop.WiFiDirect.CreateGroup();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create a WiFi-Direct group, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal void CreateGroup(string ssid)
        {
            int ret = Interop.WiFiDirect.CreateGroupWithSsid(ssid);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create a WiFi-Direct group with ssid, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal void DestroyGroup()
        {
            int ret = Interop.WiFiDirect.DestroyGroup();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to destroy the WiFi-Direct group, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal void ActivatePushButton()
        {
            int ret = Interop.WiFiDirect.ActivatePushButton();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set the Wps config PBC, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal IEnumerable<WiFiDirectWpsType> GetSupportedWpsTypes()
        {
            List<WiFiDirectWpsType> wpsList = new List<WiFiDirectWpsType>();
            Interop.WiFiDirect.WpsTypeCallback callback = (WiFiDirectWpsType type, IntPtr userData) =>
            {
                if (!type.Equals(null))
                {
                    wpsList.Add(type);
                }

                return true;
            };
            int ret = Interop.WiFiDirect.GetWpsTypes(callback, IntPtr.Zero);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get the supported WPS types, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }

            return wpsList;
        }

        internal IEnumerable<WiFiDirectPersistentGroup> GetPersistentGroups()
        {
            List<WiFiDirectPersistentGroup> persistentGroupList = new List<WiFiDirectPersistentGroup>();
            Interop.WiFiDirect.PersistentGroupCallback callback = (string address, string ssid, IntPtr userData) =>
            {
                if (address != null && ssid != null)
                {
                    persistentGroupList.Add(new WiFiDirectPersistentGroup(address, ssid));
                }

                return true;
            };
            int ret = Interop.WiFiDirect.GetPersistentGroups(callback, IntPtr.Zero);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get the persistent groups, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }

            return persistentGroupList;
        }

        internal void RemovePersistentGroup(WiFiDirectPersistentGroup group)
        {
            int ret = Interop.WiFiDirect.RemovePersistentGroup(group.MacAddress, group.Ssid);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove a persistent group, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal void InitMiracast(bool enable)
        {
            int ret = Interop.WiFiDirect.InitMiracast(enable);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set the WiFi-Direct Display(MIRACAST) service, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal void InitDisplay()
        {
            int ret = Interop.WiFiDirect.InitDisplay();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to enable Wi-Fi Display functionality, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }

            else
            {
                Globals.s_isDisplay = true;
            }
        }

        internal void DeinitDisplay()
        {
            int ret = Interop.WiFiDirect.DeinitDisplay();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to disable Wi-Fi Display functionality, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }

            else
            {
                Globals.s_isDisplay = false;
            }
        }

        internal void SetDisplay(WiFiDirectDisplayType type, int port, int hdcp)
        {
            int ret = Interop.WiFiDirect.SetDisplay(type, port, hdcp);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set the Wi-Fi Display parameters, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal void SetDisplayAvailability(bool availability)
        {
            int ret = Interop.WiFiDirect.SetDisplayAvailability(availability);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set the Wi-Fi Display session availability, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal void SetAutoGroupRemove(bool enable)
        {
            int ret = Interop.WiFiDirect.SetAutoGroupRemoval(enable);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set automatic group removal feature when all peers are disconnected, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal uint RegisterService(WiFiDirectServiceType type, string info, string serviceInfo)
        {
            uint serviceId;
            int ret = Interop.WiFiDirect.RegisterService(type, info, serviceInfo, out serviceId);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to register for service, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }

            return serviceId;
        }

        internal void DeregisterService(uint serviceId)
        {
            int ret = Interop.WiFiDirect.DeregisterService(serviceId);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to deregister service, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal void AddVsie(WiFiDirectVsieFrameType frameType, string vsie)
        {
            int ret = Interop.WiFiDirect.AddVsie(frameType, vsie);

            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to add vsie, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal string GetVsie(WiFiDirectVsieFrameType frameType)
        {
            string vsie;
            int ret = Interop.WiFiDirect.GetVsie(frameType, out vsie);

            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get vsie, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                vsie = null;
            }

            return vsie;
        }

        internal void RemoveVsie(WiFiDirectVsieFrameType frameType, string vsie)
        {
            int ret = Interop.WiFiDirect.RemoveVsie(frameType, vsie);

            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove vsie, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal WiFiDirectPeer GetConnectingPeer()
        {
            IntPtr peer;
            int ret = Interop.WiFiDirect.GetConnectingPeerInfo(out peer);

            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get connecting peer info, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                return null;
            }

            DiscoveredPeerStruct peerStruct = (DiscoveredPeerStruct)Marshal.PtrToStructure(peer, typeof(DiscoveredPeerStruct));

            return WiFiDirectUtils.ConvertStructToDiscoveredPeer(peerStruct);
        }

        internal void AcceptConnection(string peerMacAddress)
        {
            int ret = Interop.WiFiDirect.AcceptConnection(peerMacAddress);

            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to accept connection, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal void RejectConnection(string peerMacAddress)
        {
            int ret = Interop.WiFiDirect.RejectConnection(peerMacAddress);

            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to reject connection, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }
        }

        internal static WiFiDirectManagerImpl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WiFiDirectManagerImpl();
                }

                return _instance;
            }
        }

        private WiFiDirectManagerImpl()
        {
        }

        internal void Initialize()
        {
            int ret = Interop.WiFiDirect.Initialize();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to initialize Wi-Fi direct, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }

            else
            {
                Globals.s_isInitialize = true;
            }
        }

        ~WiFiDirectManagerImpl()
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
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Free managed objects.
            }

            //Free unmanaged objects
            RemoveAllRegisteredEvent();
            Deinitialize();
            _disposed = true;
        }

        private void Deinitialize()
        {
            int ret = Interop.WiFiDirect.Deinitialize();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to deinitialize Wi-Fi direct, Error - " + (WiFiDirectError)ret);
                WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
            }

            else
            {
                Globals.s_isInitialize = false;
            }
        }

        private void RemoveAllRegisteredEvent()
        {
            //unregister all remaining events when this object is released.
            if (_stateChanged != null)
            {
                UnregisterStateChangedEvent();
            }

            if (_discoveryStateChanged != null)
            {
                UnregisterDiscoveryStateChangedEvent();
            }

            if (_peerFound != null)
            {
                UnregisterPeerFoundEvent();
            }

            if (_deviceStateChanged != null)
            {
                UnregisterDeviceStateChangedEvent();
            }

            if (_connectionStatusChanged != null)
            {
                UnregisterConnectionStatusChangedEvent();
            }
        }
    }
}

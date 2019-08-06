/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Threading.Tasks;
using Tizen.Network;

namespace Tizen.Network.NetworkMonitor
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.Network.NetworkMonitor";
    }

    internal class NetworkMonitorImpl
    {
        private static readonly NetworkMonitorImpl _instance
            = new NetworkMonitorImpl();
        private IntPtr _handle;

        internal event EventHandler<IPFoundEventArgs> IPFound;
        internal event EventHandler<DefaultGatewayFoundEventArgs> GatewayFound;
        internal event EventHandler<UrlCheckResultEventArgs> ResultReceived;
        internal event EventHandler <ConnectionStateEventArgs> ConnectionStateChanged;

        private Interop.Inm.IPFoundCallback _ipFoundCallback;
        private Interop.Inm.GatewayFoundCallback _gatewayFoundCallback;
        private Interop.Inm.DnsLookupCallback _dnsLookupCallback;
        private Interop.Inm.ReachableUrlsCallback _reachableUrlsCallback;
        private Interop.Inm.ConnectionStateChangedCallback _connectionStateChangedCallback;

        private NetworkMonitorImpl()
        {
            Initialize();
        }

        private void Initialize()
        {
            int ret = Interop.Inm.Initialize(out _handle);
            CheckReturnValue(ret);
        }

        internal static NetworkMonitorImpl Instance
        {
            get
            {
                return _instance;
            }
        }

        private void CheckReturnValue(int ret)
        {
            if ((NetworkMonitorError)ret != NetworkMonitorError.None)
            {
                Log.Error(Globals.LogTag, "Failed to initialize NetworkMonitor "
                        + (NetworkMonitorError)ret);
                NetworkMonitorErrorFactory.ThrowException(ret);
            }
        }

        internal IEnumerable<Connection> GetConnections()
        {
            Log.Debug(Globals.LogTag, "GetConnections");

            IntPtr iter;
            int ret = Interop.Inm.GetConnectionIterator(_handle, out iter);
            CheckReturnValue(ret);

            List<Connection> connectionList = new List<Connection>();
            IntPtr connection;
            IntPtr cloned;
            while (true)
            {
                ret = Interop.Inm.ConnectionIteratorNext(iter, out connection);
                if ((NetworkMonitorError)ret == NetworkMonitorError.None)
                {
                    Interop.Inm.ConnectionClone(out cloned, connection);
                    Connection conn = new Connection(cloned);
                    connectionList.Add(conn);
                }
                else
                {
                    break;
                }
            }

            return connectionList;
        }

        internal void ConnectionDestroy(IntPtr connectionHandle)
        {
            int ret = Interop.Inm.ConnectionDestroy(ref connectionHandle);
            CheckReturnValue(ret);
        }

        internal string ConnectionGetId(IntPtr connectionHandle)
		{
			string id;
            int ret = Interop.Inm.ConnectionGetId(connectionHandle, out id);
            CheckReturnValue(ret);

			return id;
        }

		internal string ConnectionGetName(IntPtr connectionHandle)
		{
			string name;
			int ret = Interop.Inm.ConnectionGetName(connectionHandle, out name);
			CheckReturnValue(ret);

			return name;
		}

        internal ConnectionType ConnectionGetType(IntPtr connectionHandle)
		{
			int type;
			int ret = Interop.Inm.ConnectionGetType(connectionHandle, out type);
			CheckReturnValue(ret);

			return (ConnectionType)type;
		}

        internal string ConnectionGetIfaceName(IntPtr connectionHandle)
		{
			string ifaceName;
			int ret = Interop.Inm.ConnectionGetIfaceName(connectionHandle, out ifaceName);
			CheckReturnValue(ret);

			return ifaceName;
		}

        internal ProxyType ConnectionGetProxyType(IntPtr connectionHandle)
		{
			int type;
			int ret = Interop.Inm.ConnectionGetProxyType(connectionHandle, out type);
			CheckReturnValue(ret);

			return (ProxyType)type;
		}

        internal void ConnectionRefresh(IntPtr connectionHandle)
		{
            Log.Debug(Globals.LogTag, "Refresh Connection");

            int ret = Interop.Inm.ConnectionRefresh(connectionHandle);
            CheckReturnValue(ret);
		}

        internal Connection ConnectionClone(IntPtr connectionHandle)
        {
            Log.Debug(Globals.LogTag, "Clone connection");

            IntPtr cloned;
            int ret = Interop.Inm.ConnectionClone(out cloned, connectionHandle);
            CheckReturnValue(ret);

            return new Connection(cloned);
        }

        internal IEnumerable<Link> GetLinks()
        {
            Log.Debug(Globals.LogTag, "GetLinks");

            List<Link> linkList = new List<Link>();
            Interop.Inm.LinkCallback callback = (IntPtr link, IntPtr userData) =>
            {
                IntPtr cloned;
                Interop.Inm.LinkClone(out cloned, link);
                Link newLink = new Link(cloned);
                linkList.Add(newLink);
                return true;
            };

            int ret = Interop.Inm.ForeachLink(_handle, callback, IntPtr.Zero);
            CheckReturnValue(ret);

            return linkList;
        }

        internal void RefreshLinks()
        {
            Log.Debug(Globals.LogTag, "RefreshLinks");

            int ret = Interop.Inm.RefreshLinks(_handle);
            CheckReturnValue(ret);
        }

        internal Connection GetCurrentConnection()
        {
            Log.Debug(Globals.LogTag, "GetCurrentConnection");

            IntPtr connection;
            int ret = Interop.Inm.GetCurrentConnection(_handle, out connection);
            CheckReturnValue(ret);

            return new Connection(connection);
        }

        internal System.Net.IPAddress LinkAddressGetIP(IntPtr addressHandle)
        {
            Log.Debug(Globals.LogTag, "LinkAddressGetIP");

            string ip;
            int ret = Interop.Inm.LinkAddressGetString(addressHandle, out ip);
            CheckReturnValue(ret);
            Log.Debug(Globals.LogTag, "IP: " + ip);

            return System.Net.IPAddress.Parse(ip);
        }

        internal int LinkAddressGetPrefixLength(IntPtr addressHandle)
        {
            Log.Debug(Globals.LogTag, "LinkAddressGetPrefixLength");

            int prefix;
            int ret = Interop.Inm.LinkAddressGetPrefixLength(addressHandle, out prefix);
            CheckReturnValue(ret);
            Log.Debug(Globals.LogTag, "Prefix length: " + prefix);

            return prefix;
        }

        internal LinkScope LinkAddressGetScope(IntPtr addressHandle)
        {
            Log.Debug(Globals.LogTag, "LinkAddressGetScope");

            int scope;
            int ret = Interop.Inm.LinkAddressGetScope(addressHandle, out scope);
            CheckReturnValue(ret);
            Log.Debug(Globals.LogTag, "Link scope: " + scope);

            return (LinkScope) scope;
        }

        internal LinkAddress LinkAddressClone(IntPtr addressHandle)
        {
            Log.Debug(Globals.LogTag, "Clone link address");

            IntPtr cloned;
            int ret = Interop.Inm.LinkAddressClone(out cloned, addressHandle);
            CheckReturnValue(ret);

            return new LinkAddress(cloned);
        }

        internal void LinkAddressDestroy(IntPtr addressHandle)
        {
            int ret = Interop.Inm.LinkAddressDestroy(addressHandle);
            CheckReturnValue(ret);
        }

        internal Link GetLink(IntPtr connectionHandle)
        {
            Log.Debug(Globals.LogTag, "GetLink. Connection handle: " + connectionHandle.GetHashCode());

            IntPtr link;
            int ret = Interop.Inm.ConnectionGetLink(connectionHandle, out link);
            CheckReturnValue(ret);

            return new Link(link);
        }

        internal string LinkGetInterfaceName(IntPtr linkHandle)
        {
            Log.Debug(Globals.LogTag, "LinkGetInterfaceName");

            string name;
            int ret = Interop.Inm.LinkGetInterfaceName(linkHandle, out name);
            CheckReturnValue(ret);
            Log.Debug(Globals.LogTag, "Interface name: " + name);

            return name;
        }

        internal int LinkGetFlags(IntPtr linkHandle)
        {
            Log.Debug(Globals.LogTag, "LinkGetFlags");

            int flags;
            int ret = Interop.Inm.LinkGetFlags(linkHandle, out flags);
            CheckReturnValue(ret);
            Log.Debug(Globals.LogTag, "Flags: " + flags);

            return flags;
        }

        internal LinkOperationState LinkGetOperationState(IntPtr linkHandle)
        {
            Log.Debug(Globals.LogTag, "LinkGetOperationState");

            int state;
            int ret = Interop.Inm.LinkGetOperationState(linkHandle, out state);
            CheckReturnValue(ret);
            Log.Debug(Globals.LogTag, "Operation state: " + state);

            return (LinkOperationState) state;
        }

        internal ulong LinkGetReceivedBytes(IntPtr linkHandle)
        {
            Log.Debug(Globals.LogTag, "LinkGetReceivedBytes");

            ulong bytes;
            int ret = Interop.Inm.LinkGetReceivedBytes(linkHandle, out bytes);
            CheckReturnValue(ret);
            Log.Debug(Globals.LogTag, "Received bytes: " + bytes);

            return bytes;
        }

        internal ulong LinkGetSentBytes(IntPtr linkHandle)
        {
            Log.Debug(Globals.LogTag, "LinkGetSentBytes");

            ulong bytes;
            int ret = Interop.Inm.LinkGetSentBytes(linkHandle, out bytes);
            CheckReturnValue(ret);
            Log.Debug(Globals.LogTag, "Sent bytes: " + bytes);

            return bytes;
        }

        internal IEnumerable<LinkAddress> LinkGetAddresses(IntPtr linkHandle)
        {
            Log.Debug(Globals.LogTag, "LinkGetAddresses");

            List<LinkAddress> addrList = new List<LinkAddress>();
            Interop.Inm.AddressCallback callback = (IntPtr address, IntPtr userData) =>
            {
                if (address != IntPtr.Zero)
                {
                    IntPtr cloned;
                    Interop.Inm.LinkAddressClone(out cloned, address);
                    LinkAddress addressInfo = new LinkAddress(cloned);
                    addrList.Add(addressInfo);
                    return true;
                }
                return false;
            };

            int ret = Interop.Inm.LinkForeachAddress(linkHandle, callback, IntPtr.Zero);
            CheckReturnValue(ret);

            return addrList;
        }

        internal IEnumerable<Route> LinkGetRoutes(IntPtr linkHandle)
        {
            Log.Debug(Globals.LogTag, "LinkGetRoutes");

            List<Route> routeList = new List<Route>();
            Interop.Inm.RouteCallback callback = (IntPtr route, IntPtr userData) =>
            {
                IntPtr cloned;
                Interop.Inm.LinkRouteClone(out cloned, route);
                Route newRoute = new Route(cloned);
                routeList.Add(newRoute);
                return true;
            };

            int ret = Interop.Inm.LinkForeachRoute(linkHandle, callback, IntPtr.Zero);
            CheckReturnValue(ret);

            return routeList;
        }

        internal Link LinkClone(IntPtr linkHandle)
        {
            Log.Debug(Globals.LogTag, "Clone link");

            IntPtr cloned;
            int ret = Interop.Inm.LinkClone(out cloned, linkHandle);
            CheckReturnValue(ret);

            return new Link(cloned);
        }

        internal void LinkDestroy(IntPtr linkHandle)
        {
            int ret = Interop.Inm.LinkDestroy(linkHandle);
            CheckReturnValue(ret);
        }

        internal string RouteGetDestination(IntPtr routeHandle)
        {
            Log.Debug(Globals.LogTag, "RouteGetDestination");

            string destination;
            int ret = Interop.Inm.LinkRouteGetDestination(routeHandle, out destination);
            CheckReturnValue(ret);
            Log.Debug(Globals.LogTag, "Destination: " + destination);

            return destination;
        }

        internal System.Net.IPAddress RouteGetGateway(IntPtr routeHandle)
        {
            Log.Debug(Globals.LogTag, "RouteGetGateway");

            string ip;
            int ret = Interop.Inm.LinkRouteGetGateway(routeHandle, out ip);
            CheckReturnValue(ret);
            System.Net.IPAddress gateway = System.Net.IPAddress.Parse(ip);
            Log.Debug(Globals.LogTag, "Gateway: " + gateway);

            return gateway;
        }

        internal string RouteGetInterfaceName(IntPtr routeHandle)
        {
            Log.Debug(Globals.LogTag, "RouteGetInterfaceName");

            string name;
            int ret = Interop.Inm.LinkRouteGetInterface(routeHandle, out name);
            CheckReturnValue(ret);
            Log.Debug(Globals.LogTag, "Interface name: " + name);

            return name;
        }

        internal bool RouteIsDefault(IntPtr routeHandle)
        {
            Log.Debug(Globals.LogTag, "RouteIsDefault");

            bool isDefault;
            int ret = Interop.Inm.LinkRouteIsDefault(routeHandle, out isDefault);
            CheckReturnValue(ret);
            Log.Debug(Globals.LogTag, "Default route: " + isDefault);

            return isDefault;
        }

        internal RouteType RouteGetType(IntPtr routeHandle)
        {
            Log.Debug(Globals.LogTag, "RouteGetType");

            int type;
            int ret = Interop.Inm.LinkRouteGetType(routeHandle, out type);
            CheckReturnValue(ret);
            Log.Debug(Globals.LogTag, "Route type: " + type);

            return (RouteType) type;
        }

        internal Route RouteClone(IntPtr routeHandle)
        {
            Log.Debug(Globals.LogTag, "Clone route");

            IntPtr cloned;
            int ret = Interop.Inm.LinkRouteClone(out cloned, routeHandle);
            CheckReturnValue(ret);

            return new Route(cloned);
        }

        internal void RouteDestroy(IntPtr routeHandle)
        {
            int ret = Interop.Inm.LinkRouteDestroy(routeHandle);
            CheckReturnValue(ret);
        }

        internal void ArpRequesterSetPacketInterval(int seconds)
        {
            Log.Debug(Globals.LogTag, "ArpRequesterSetPacketInterval " + seconds);

            int ret = Interop.Inm.ArpRequestSetPacketInterval(_handle, seconds);
            CheckReturnValue(ret);
        }

        internal int ArpRequesterGetPacketInterval()
        {
            Log.Debug(Globals.LogTag, "ArpRequesterGetPacketInterval");

            int seconds;
            int ret = Interop.Inm.ArpRequestGetPacketInterval(_handle, out seconds);
            CheckReturnValue(ret);

            return seconds;
        }

        internal void ArpRequesterStart(string target)
        {
            Log.Info(Globals.LogTag, "Start ARP request to " + target);

            _ipFoundCallback = (bool found, string ip, IntPtr userData) =>
            {
                if (IPFound != null)
                {
                    Log.Info(Globals.LogTag, "IPFound callback is invoked from native API");
                    System.Net.IPAddress parsedIP = System.Net.IPAddress.Parse(ip);
                    IPFound(null, new IPFoundEventArgs(found, parsedIP));
                }
            };

            int ret = Interop.Inm.ArpRequestStart(
                    _handle, target, _ipFoundCallback, IntPtr.Zero);
            CheckReturnValue(ret);
        }

        internal void ArpRequesterStop(string target)
        {
            Log.Info(Globals.LogTag, "Stop ARP request to " + target);

            int ret = Interop.Inm.ArpRequestStop(_handle, target);
            CheckReturnValue(ret);
        }

        internal void GatewayCheckerStart(int timeout)
        {
            Log.Info(Globals.LogTag, "Start default gateway check. Timeout: " + timeout);

            _gatewayFoundCallback = (bool found, string ip, IntPtr userData) =>
            {
                if (GatewayFound != null)
                {
                    Log.Info(Globals.LogTag, "GatewayFound callback is invoked from native API");
                    System.Net.IPAddress parsedIP = System.Net.IPAddress.Parse(ip);
                    GatewayFound(null, new DefaultGatewayFoundEventArgs(found, parsedIP));
                }
            };

            int ret = Interop.Inm.DefaultGatewayStartChecking(
                    _handle, timeout, _gatewayFoundCallback, IntPtr.Zero);
            CheckReturnValue(ret);
        }

        internal void GatewayCheckerStop()
        {
            Log.Info(Globals.LogTag, "Stop default gateway check");
            int ret = Interop.Inm.DefaultGatewayStopChecking(_handle);
            CheckReturnValue(ret);
        }

        internal Task<bool> DnsLookupCheckAsync()
        {
            Log.Info(Globals.LogTag, "Check DNS lookup");

            var task = new TaskCompletionSource<bool>();
            _dnsLookupCallback = (bool found, IntPtr userData) =>
            {
                task.SetResult(found);
            };

            int ret = Interop.Inm.DefaultDnsLookupCheck(
                    _handle, _dnsLookupCallback, IntPtr.Zero);
            CheckReturnValue(ret);

            return task.Task;
        }

        internal void AddUrls(List<string> urlList)
        {
            Log.Info(Globals.LogTag, "Add URLs. Size: " + urlList.Count);

            foreach (var url in urlList)
            {
                Log.Info(Globals.LogTag, "URL: " + url);
                int ret = Interop.Inm.ReachableUrlsAddUrlToCheck(_handle, url);
                CheckReturnValue(ret);
            }
        }

        internal void ClearUrls(List<string> urlList)
        {
            Log.Info(Globals.LogTag, "Remove URLs. Size: " + urlList.Count);

            foreach (var url in urlList)
            {
                Log.Info(Globals.LogTag, "URL: " + url);
                int ret = Interop.Inm.ReachableUrlsRemoveUrlToCheck(_handle, url);
                CheckReturnValue(ret);
            }
        }

        internal void UrlCheckerStart(int type)
        {
            Log.Info(Globals.LogTag, "Start URL check. type: " + type);

            _reachableUrlsCallback = (int result, string url, IntPtr userData) =>
            {
                if (ResultReceived != null)
                {
                    ResultReceived(null, new UrlCheckResultEventArgs(result, url));
                }
            };

            int ret = Interop.Inm.ReachableUrlsStartChecking(
                    _handle, type, _reachableUrlsCallback, IntPtr.Zero);
            CheckReturnValue(ret);
        }

        internal void UrlCheckerStop(int type)
        {
            Log.Info(Globals.LogTag, "Stop URL check. type: " + type);

            int ret = Interop.Inm.ReachableUrlsStopChecking(_handle, type);
            CheckReturnValue(ret);
        }

        internal bool UrlCheckerIsRunning(int type)
        {
            Log.Debug(Globals.LogTag, "UrlCheckerIsRunning. type: " + type);

            bool isRunning;
            int ret = Interop.Inm.ReachableUrlsIsCheckRunning(_handle, type, out isRunning);
            CheckReturnValue(ret);

            return isRunning;
        }

        internal void RegisterConnectionStateChanged(IntPtr connectionHandle)
        {
            Log.Info(Globals.LogTag, "Register connection state changed callback");
            _connectionStateChangedCallback = (int state, IntPtr userData) =>
            {
                if (ConnectionStateChanged != null)
                {
                    ConnectionStateChanged(null, new ConnectionStateEventArgs(state));
                }
            };

            int ret = Interop.Inm.ConnectionSetStateChangedCb(connectionHandle,
                    _connectionStateChangedCallback, IntPtr.Zero);
            CheckReturnValue(ret);
        }

        internal void UnregisterConnectionStateChanged(IntPtr connectionHandle)
        {
            Log.Info(Globals.LogTag, "Unregister connection state changed callback");
            int ret = Interop.Inm.ConnectionUnsetStateChangedCb(connectionHandle);
            CheckReturnValue(ret);
        }
    } // class NetworkMonitorImpl
}

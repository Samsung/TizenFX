using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static class Inm
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate bool LinkCallback(IntPtr link, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate bool RouteCallback(IntPtr route, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate bool AddressCallback(IntPtr address, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void IPFoundCallback(bool found, string ip, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void GatewayFoundCallback(bool found, string ip, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void DnsLookupCallback(bool found, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void ReachableUrlsCallback(int result, string url, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void ConnectionStateChangedCallback(int state, IntPtr userData);
        

        [DllImport(Libraries.Inm, EntryPoint = "inm_initialize")]
            internal static extern int Initialize(out IntPtr handle);
        [DllImport(Libraries.Inm, EntryPoint = "inm_deinitialize")]
            internal static extern int Deinitialize(IntPtr handle);
        [DllImport(Libraries.Inm, EntryPoint = "inm_get_current_connection")]
            internal static extern int GetCurrentConnection(IntPtr handle, out IntPtr connection);
        [DllImport(Libraries.Inm, EntryPoint = "inm_connection_destroy")]
            internal static extern int ConnectionDestroy(ref IntPtr connection);
        [DllImport(Libraries.Inm, EntryPoint = "inm_connection_clone")]
            internal static extern int ConnectionClone(out IntPtr cloned, IntPtr origin);
        [DllImport(Libraries.Inm, EntryPoint = "inm_get_connection_iterator")]
            internal static extern int GetConnectionIterator(IntPtr handle, out IntPtr iter);
        [DllImport(Libraries.Inm, EntryPoint = "inm_connection_iterator_next")]
            internal static extern int ConnectionIteratorNext(IntPtr iter, out IntPtr connection);
        [DllImport(Libraries.Inm, EntryPoint = "inm_destroy_connection_iterator")]
            internal static extern int DestroyConnectionIterator(IntPtr iter);
        [DllImport(Libraries.Inm, EntryPoint = "inm_foreach_link")]
            internal static extern int ForeachLink(IntPtr handle, LinkCallback callback, IntPtr userData);
        [DllImport(Libraries.Inm, EntryPoint = "inm_refresh_links")]
            internal static extern int RefreshLinks(IntPtr handle);
        [DllImport(Libraries.Inm, EntryPoint = "inm_arp_request_set_packet_interval")]
            internal static extern int ArpRequestSetPacketInterval(IntPtr handle, int seconds);
        [DllImport(Libraries.Inm, EntryPoint = "inm_arp_request_get_packet_interval")]
            internal static extern int ArpRequestGetPacketInterval(IntPtr handle, out int seconds);
        [DllImport(Libraries.Inm, EntryPoint = "inm_arp_request_start")]
            internal static extern int ArpRequestStart(IntPtr handle, string target, IPFoundCallback callback, IntPtr userData);
        [DllImport(Libraries.Inm, EntryPoint = "inm_arp_request_stop")]
            internal static extern int ArpRequestStop(IntPtr handle, string target);
        [DllImport(Libraries.Inm, EntryPoint = "inm_default_gateway_start_checking")]
            internal static extern int DefaultGatewayStartChecking(IntPtr handle, int timeout, GatewayFoundCallback callback, IntPtr userData);
        [DllImport(Libraries.Inm, EntryPoint = "inm_default_gateway_stop_checking")]
            internal static extern int DefaultGatewayStopChecking(IntPtr handle);
        [DllImport(Libraries.Inm, EntryPoint = "inm_default_dns_lookup_check")]
            internal static extern int DefaultDnsLookupCheck(IntPtr handle, DnsLookupCallback callback, IntPtr userData);
        [DllImport(Libraries.Inm, EntryPoint = "inm_reachable_urls_add_url_to_check")]
            internal static extern int ReachableUrlsAddUrlToCheck(IntPtr handle, string url);
        [DllImport(Libraries.Inm, EntryPoint = "inm_reachable_urls_remove_url_to_check")]
            internal static extern int ReachableUrlsRemoveUrlToCheck(IntPtr handle, string url);
        [DllImport(Libraries.Inm, EntryPoint = "inm_reachable_urls_start_checking")]
            internal static extern int ReachableUrlsStartChecking(IntPtr handle, int type, ReachableUrlsCallback callback, IntPtr userData);
        [DllImport(Libraries.Inm, EntryPoint = "inm_reachable_urls_stop_checking")]
            internal static extern int ReachableUrlsStopChecking(IntPtr handle, int type);
        [DllImport(Libraries.Inm, EntryPoint = "inm_reachable_urls_is_check_running")]
            internal static extern int ReachableUrlsIsCheckRunning(IntPtr handle, int type, out bool isRunning);
        [DllImport(Libraries.Inm, EntryPoint = "inm_connection_get_link")]
            internal static extern int ConnectionGetLink(IntPtr handle, out IntPtr link);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_destroy")]
            internal static extern int LinkDestroy(IntPtr link);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_clone")]
            internal static extern int LinkClone(out IntPtr cloned, IntPtr origin);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_get_interface_name")]
            internal static extern int LinkGetInterfaceName(IntPtr link, out string name);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_get_flags")]
            internal static extern int LinkGetFlags(IntPtr link, out int flags);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_get_operation_state")]
            internal static extern int LinkGetOperationState(IntPtr link, out int operationState);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_get_received_bytes")]
            internal static extern int LinkGetReceivedBytes(IntPtr link, out ulong bytes);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_get_sent_bytes")]
            internal static extern int LinkGetSentBytes(IntPtr link, out ulong bytes);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_foreach_address")]
            internal static extern int LinkForeachAddress(IntPtr handle, AddressCallback callback, IntPtr userData);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_address_destroy")]
            internal static extern int LinkAddressDestroy(IntPtr address);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_address_clone")]
            internal static extern int LinkAddressClone(out IntPtr cloned, IntPtr origin);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_address_get_family")]
            internal static extern int LinkAddressGetFamily(IntPtr address, out int family);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_address_get_prefix_length")]
            internal static extern int LinkAddressGetPrefixLength(IntPtr address, out int length);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_address_get_scope")]
            internal static extern int LinkAddressGetScope(IntPtr address, out int scope);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_address_get_string")]
            internal static extern int LinkAddressGetString(IntPtr address, out string str);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_foreach_route")]
            internal static extern int LinkForeachRoute(IntPtr handle, RouteCallback callback, IntPtr userData);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_route_destroy")]
            internal static extern int LinkRouteDestroy(IntPtr route);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_route_clone")]
            internal static extern int LinkRouteClone(out IntPtr cloned, IntPtr origin);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_route_get_destination")]
            internal static extern int LinkRouteGetDestination(IntPtr route, out string destination);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_route_get_gateway")]
            internal static extern int LinkRouteGetGateway(IntPtr route, out string gateway);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_route_get_interface")]
            internal static extern int LinkRouteGetInterface(IntPtr route, out string name);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_route_is_default")]
            internal static extern int LinkRouteIsDefault(IntPtr route, out bool isDefault);
        [DllImport(Libraries.Inm, EntryPoint = "inm_link_route_get_type")]
            internal static extern int LinkRouteGetType(IntPtr route, out int type);

        // INM Connection
        [DllImport(Libraries.Inm, EntryPoint = "inm_connection_get_id")]
            internal static extern int ConnectionGetId(IntPtr connection, out string id);
        [DllImport(Libraries.Inm, EntryPoint = "inm_connection_get_name")]
            internal static extern int ConnectionGetName(IntPtr connection, out string name);
        [DllImport(Libraries.Inm, EntryPoint = "inm_connection_get_type")]
            internal static extern int ConnectionGetType(IntPtr connection, out int type);
        [DllImport(Libraries.Inm, EntryPoint = "inm_connection_get_network_interface_name")]
            internal static extern int ConnectionGetIfaceName(IntPtr connection, out string ifaceName);
        [DllImport(Libraries.Inm, EntryPoint = "inm_connection_refresh")]
            internal static extern int ConnectionRefresh(IntPtr connection);
        [DllImport(Libraries.Inm, EntryPoint = "inm_connection_get_ip_config_type")]
            internal static extern int ConnectionGetIpConfigType(IntPtr connection, int addressFamily, out int configType);
        [DllImport(Libraries.Inm, EntryPoint = "inm_connection_get_proxy_type")]
            internal static extern int ConnectionGetProxyType(IntPtr connection, out int type);

        [DllImport(Libraries.Inm, EntryPoint = "inm_connection_set_state_changed_cb")]
            internal static extern int ConnectionSetStateChangedCb(IntPtr connection, ConnectionStateChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.Inm, EntryPoint = "inm_connection_unset_state_changed_cb")]
            internal static extern int ConnectionUnsetStateChangedCb(IntPtr connection);

    }
}

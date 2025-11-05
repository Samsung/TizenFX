---
uid: Tizen.Network.WiFiDirect
summary: *content
---

# Tizen.Network.WiFiDirect Namespace

The Tizen.Network.WiFiDirect namespace provides classes to manage the settings of Wi-Fi Direct. In addition, this namespace provides classes to connect and disconnect remote devices using Wi-Fi Direct.

## Main Classes

### [WiFiDirectManager](xref:Tizen.Network.WiFiDirect.WiFiDirectManager)
The main class for managing Wi-Fi Direct functionality. It provides methods for:
- Activating and deactivating Wi-Fi Direct
- Discovering peer devices
- Managing connections
- Creating and destroying groups
- Handling Wi-Fi Display (Miracast) functionality

### [WiFiDirectPeer](xref:Tizen.Network.WiFiDirect.WiFiDirectPeer)
Represents a remote Wi-Fi Direct device. It provides properties and methods for:
- Getting peer device information
- Connecting to and disconnecting from peers
- Service discovery
- Event handling for connection state changes

### [WiFiDirectPersistentGroup](xref:Tizen.Network.WiFiDirect.WiFiDirectPersistentGroup)
Represents a persistent Wi-Fi Direct group that can be reconnected automatically.

## Key Enumerations

- [WiFiDirectState](xref:Tizen.Network.WiFiDirect.WiFiDirectState) - Wi-Fi Direct service states
- [WiFiDirectConnectionState](xref:Tizen.Network.WiFiDirect.WiFiDirectConnectionState) - Connection states
- [WiFiDirectDiscoveryState](xref:Tizen.Network.WiFiDirect.WiFiDirectDiscoveryState) - Discovery states
- [WiFiDirectWpsType](xref:Tizen.Network.WiFiDirect.WiFiDirectWpsType) - WPS configuration types
- [WiFiDirectServiceType](xref:Tizen.Network.WiFiDirect.WiFiDirectServiceType) - Service discovery types

## Event Arguments

- [StateChangedEventArgs](xref:Tizen.Network.WiFiDirect.StateChangedEventArgs) - Wi-Fi Direct state change events
- [ConnectionStateChangedEventArgs](xref:Tizen.Network.WiFiDirect.ConnectionStateChangedEventArgs) - Connection state change events
- [PeerFoundEventArgs](xref:Tizen.Network.WiFiDirect.PeerFoundEventArgs) - Peer discovery events
- [DiscoveryStateChangedEventArgs](xref:Tizen.Network.WiFiDirect.DiscoveryStateChangedEventArgs) - Discovery state change events

## Basic Usage Example

```csharp
using Tizen.Network.WiFiDirect;

// Activate Wi-Fi Direct
WiFiDirectManager.Activate();

// Start peer discovery
WiFiDirectManager.StartDiscovery(false, 30); // 30 seconds discovery

// Handle peer found event
WiFiDirectManager.PeerFound += (sender, e) =>
{
    if (e.Error == WiFiDirectError.None)
    {
        Console.WriteLine($"Found peer: {e.Peer.Name}");
        // Connect to the peer
        e.Peer.Connect();
    }
};

// Handle connection state changes
WiFiDirectManager.ConnectionStatusChanged += (sender, e) =>
{
    Console.WriteLine($"Connection state: {e.ConnectionState}");
};
```

## Requirements

- **Tizen Version**: 3.0 or later
- **Privilege**: http://tizen.org/privilege/wifidirect
- **Feature**: http://tizen.org/feature/network.wifidirect

## Related Features

- **Wi-Fi Display**: http://tizen.org/feature/network.wifi.direct.display
- **Service Discovery**: http://tizen.org/feature/network.wifi.direct.service_discovery

## See Also

- [Wi-Fi Direct Overview](https://docs.tizen.org/application/native/guides/connectivity/wifi-direct)
- [Network Connectivity Guide](https://docs.tizen.org/application/native/guides/connectivity)

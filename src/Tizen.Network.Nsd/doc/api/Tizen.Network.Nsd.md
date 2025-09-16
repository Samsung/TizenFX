---
uid: Tizen.Network.Nsd
summary: The Tizen.Network.Nsd namespace provides classes to manage the network service discovery protocols.
remarks: *content
---
## Overview
The Nsd API handles DNS-SD (DNS Service Discovery) protocol. It allows applications to announce local services and search for remote services on a network.

## Registering a Service on Network
```cs
// Create and register a service
DnssdService service = new DnssdService("_http._tcp");
service.Name = "TestService";
service.Port = "1234";
service.RegisterService();

// Optional: Add TXT records
service.AddTXTRecord("version", "1.0");
```

## Discovering Services on Network
```cs
// Create browser and start discovery
DnssdBrowser browser = new DnssdBrowser("_http._tcp");
browser.ServiceFound += (s, e) =>
{
    if (e.State == DnssdServiceState.Available)
    {
        // Handle the discovered service
    }
};
browser.StartDiscovery();
```

## Cleaning Up on Application Exit
```cs
// Stop service discovery
browser.StopDiscovery();

// Deregister service and dispose resources
service.DeregisterService();
service.Dispose();
```

## Related Features
To use DNS-SD, declare the following feature requirements in the config file:
http://tizen.org/feature/network.service_discovery.dnssd

To use SSDP, declare the following feature requirements in the config file:
http://tizen.org/feature/network.service_discovery.ssdp

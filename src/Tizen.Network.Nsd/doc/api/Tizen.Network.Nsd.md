---
uid: Tizen.Network.Nsd
summary: The Tizen.Network.Nsd namespace provides classes to manage the network service discovery protocols.
remarks: *content
---
## Overview
The Nsd API handles two network service discovery protocols: DNS-SD (DNS Service Discovery) and SSDP (Simple Service Discovery Protocol). They allows application to announce local services and search for remote services on a network.


## Example
The following example demonstrates how to register a DNS-SD local service.
```cs
DnssdService service = new DnssdService("_http._tcp");
service.Name = "TestService";
service.Port = "1234";
service.RegisterService();
```


## Related Features
To use DNS-SD, declare the following feature requirements in the config file: 
http://tizen.org/feature/network.service_discovery.dnssd

To use SSDP, declare the following feature requirements in the config file: 
http://tizen.org/feature/network.service_discovery.ssdp

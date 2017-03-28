/**
<summary>
The Tizen.Network.Nsd namespace provides classes to manage the network service discovery protocols.
</summary>
<remarks>
<h2>Overview</h2>
<para>The Nsd API handles two network service discovery protocols: DNS-SD (DNS Service Discovery) and SSDP (Simple Service Discovery Protocol). They allows application to announce local services and search for remote services on a network.
</para>
<h2>Related Features</h2>
<para>To use DNS-SD, declare the following feature requirements in the config file:<br/>
http://tizen.org/feature/network.dnssd
</para>
<para>To use SSDP, declare the following feature requirements in the config file:<br/>
http://tizen.org/feature/network.ssdp
</para>

</remarks>

<example>
The following example demonstrates how to register a DNS-SD local service.
<code>
DnssdService service = new DnssdService("_http._tcp");
service.Name = "TestService";
service.Port = "1234";
service.RegisterService();
</code>
</example>

*/
namespace Tizen.Network.Nsd {}

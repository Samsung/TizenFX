/**
<summary>
The Tizen.Location.Geofence namespace provides classes for virtual perimeter.
</summary>

<remarks>
<h2>Overview</h2>
<para>
This API provides functions to set geofence with geopoint, MAC address of Wi-Fi, and Bluetooth address.
And notifications on events like changing in service status are provided.<p>
There are two kinds of places and fences:<br/>
- Public places and fences that are created by MyPlace app can be used by all apps.<br/>
- Private places and fences that are created by specified app can be used by the same app.<p>
Notifications can be received about the following events:<br/>
- Zone in when a device enters a specific area<br/>
- Zone out when a device exits a specific area<br/>
- Results and errors for each event requested to geofence module<p>
The Geofence manager has the following properties:<br/>
- geofence type<br/>
- status<br/>
- 'Service state change' callback
</para>

<h2>Related Features</h2>
<para>To guarantee that the Geofence application runs on a device with Geofence profile feature,
declare the following feature requirements in the config file:<br/>
http://tizen.org/feature/location<br/>
http://tizen.org/feature/location.geofence<br/>
http://tizen.org/feature/location.wps
</para>
</remarks>
*/
namespace Tizen.Location.Geofence {}

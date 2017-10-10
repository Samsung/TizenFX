/**
<summary>
The Tizen.Location.Geofence namespace provides classes for virtual perimeter.
</summary>

<remarks>

<h2>Overview</h2>
<para>
This API provides functions to set the gofence with a geopoint, MAC address of Wi-Fi, and Bluetooth address.
Also, notifications on events like changing in service status are provided.<p/>

There are two kinds of places and fences:<br/>
- Public places and fences that are created by the MyPlace application can be used by all applications.<br/>
- Private places and fences that are created by the specified application can be used by the same application.<p/>

Notifications can be received about the following events:<br/>
- Zone in when a device enters a specific area.<br/>
- Zone out when a device exits a specific area.<br/>
- Results and errors for each event requested to geofence module.<p/>

The Geofence manager has the following properties:<br/>
- The geofence type.<br/>
- The status.<br/>
- 'Service state change' callback
</para>

<h2>Related Features</h2>
<para>To guarantee that the geofence application runs on a device with the geofence profile feature,
declare the following feature requirements in the config file:<br/>
http://tizen.org/feature/location<br/>
http://tizen.org/feature/location.Geofence<br/>
http://tizen.org/feature/location.wps
</para>

</remarks>
*/
namespace Tizen.Location.Geofence {}

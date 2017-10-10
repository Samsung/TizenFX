---
uid: Tizen.Location.Geofence
summary: The Tizen.Location.Geofence namespace provides classes for virtual perimeter.
remarks: *content
---
## Overview
This API provides functions to set the gofence with a geopoint, MAC address of Wi-Fi, and Bluetooth address.
Also, notifications on events like changing in service status are provided.

There are two kinds of places and fences:
- Public places and fences that are created by the MyPlace application can be used by all applications.
- Private places and fences that are created by the specified application can be used by the same application.

Notifications can be received about the following events:
- Zone in when a device enters a specific area.
- Zone out when a device exits a specific area.
- Results and errors for each event requested to geofence module.

The Geofence manager has the following properties:
- The geofence type.
- The status.
- 'Service state change' callback

## Related Features
To guarantee that the geofence application runs on a device with the geofence profile feature,
declare the following feature requirements in the config file:
* http://tizen.org/feature/location
* http://tizen.org/feature/location.Geofence
* http://tizen.org/feature/location.wps

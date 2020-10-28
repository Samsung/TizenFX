---
uid: Tizen.Network.Mtp
summary: The Tizen.Network.Mtp namespace provides classes to manage the MTP(Media Transfer Protocol) initiator.
remarks: *content
---
## Overview
MTP API provides functions for support PTP(Picture Transfer Protocol) subset of MTP(Media Transfer Protocol).

### Manager
Provide functions to establish connection to access MTP responder device, and to Get/Delete files.

### Device
Provide functions to gets the device information of MTP responder device.

### Storage
Provide functions to gets the storage information of MTP responder storage.

### Object
Provide functions to gets the object information of certain file in MTP responder.


## Related Features
To guarantee that if input or output path are relevant to internal and external storage,
declare the following feature requirements in the config file:
* http://tizen.org/privilege/mediastorage
* http://tizen.org/privilege/externalstorage

---
uid: Tizen.Security.DevicePolicyManager
summary: The Tizen.Security.DevicePolicyManager namespace provides classes to manage the device policy management framework. The device policy management framework provides APIs to create security-aware applications that are useful in enterprise settings.
remarks: *content
---
## Overview
The primary purpose of the DPM(Device Policy Management) framework is to support enterprise applications.
The device policy API supports the policies listed in the below, and application can subscribe to those policies from events.

### Policy List
|  <center>Policy Name</center> |  <center>Event</center> |  <center>Description</center> |
|:--------|:--------|:--------|
|wifi |WifiPolicyChanged |Specifies wether the use of Wi-Fi is allowed or not |
|wifi-hotspot |WifiHotspotChanged |Specifies whether the use of Wi-Fi hotspot is allowed or not |
|bluetooth |BluetoothPolicyChanged |Specifies whether the use of bluetooth is allowed or not |
|camera |CameraPolicyChanged |Specifies whether the use of camera is allowed or not |
|microphone |MicrophonePolicyChanged |Specifies whether the use of microphone is allowed or not |
|location |LocationPolicyChanged |Specifies whether the use of GPS is allowed or not |
|external-storage |ExternalStoragePolicyChanged |Specifies whether the use of external storage is allowed or not |
|messaging |MessagingPolicyChanged |Specifies whether the use of text messaging is allowed or not |
|popimap-email |PopImapPolicyChanged |Specifies whether the use of POP/IMAP Email is allowed or not |
|browser |BrowserPolicyChanged |Specifies whether the use of browser is allowed or not |
|bluetooth-tethering |BluetoothTetheringPolicyChanged |Specifies whether the use of bluetooth tethering is allowed or not |
|usb-tethering |UsbTetheringPolicyChanged |Specifies whether the use of usb tethering is allowed or not |
/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */


namespace Tizen.Applications.EventManager
{
    /// <summary>
    /// Supported System Events
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static class SystemEvents
    {
        /// <summary>
        /// Class for system-event of battery charger status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class BatteryChargerStatus
        {
            /// <summary>
            /// Eventname for system-event of battery charger status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.battery_charger_status";

            /// <summary>
            /// Key for system-event of battery charger status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusKey = "battery_charger_status";

            /// <summary>
            /// Value of connected battery charger
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueConnected = "connected";

            /// <summary>
            /// Value of disconnected battery charger
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueDisconnected = "disconnected";

            /// <summary>
            /// Value of charing battery charger
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueCharging = "charging";

            /// <summary>
            /// Value of discharging battery charger
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueDischarging = "discharging";
        }

        /// <summary>
        /// Class for system-event of battery level status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class BatteryLevelStatus
        {
            /// <summary>
            /// Eventname for system-event of battery level status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.battery_level_status";

            /// <summary>
            /// Key for system-event of battery level status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusKey = "battery_level_status";

            /// <summary>
            /// Value of empty battery level status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueEmpty = "empty";

            /// <summary>
            /// Value of critical battery level status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueCritical = "critical";

            /// <summary>
            /// Value of low battery level status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueLow = "low";

            /// <summary>
            /// Value of high battery level status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueHigh = "high";

            /// <summary>
            /// Value of full battery level status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueFull = "full";
        }

        /// <summary>
        /// Class for system-event of usb status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class UsbStatus
        {
            /// <summary>
            /// Eventname for system-event of usb status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.usb_status";

            /// <summary>
            /// Key for system-event of usb status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusKey = "usb_status";

            /// <summary>
            /// Value of disconnected usb status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueDisconnected = "disconnected";

            /// <summary>
            /// Value of connected usb status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueConnected = "connected";

            /// <summary>
            /// Value of available usb status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueAvailable = "available";
        }

        /// <summary>
        /// Class for system-event of earjack status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class EarjackStatus
        {
            /// <summary>
            /// Eventname for system-event of earjack status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.earjack_status";

            /// <summary>
            /// Key for system-event of earjack status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusKey = "earjack_status";

            /// <summary>
            /// Value of disconnected earjack status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueDisconnected = "disconnected";

            /// <summary>
            /// Value of connected earjack status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueConnected = "connected";
        }

        /// <summary>
        /// Class for system-event of display state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class DisplayState
        {
            /// <summary>
            /// Eventname for system-event of display state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.display_state";

            /// <summary>
            /// Key for system-event of display state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateKey = "display_state";

            /// <summary>
            /// Value of normal display state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueNormal = "normal";

            /// <summary>
            /// Value of dim display state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueDim = "dim";

            /// <summary>
            /// Value of off display state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueOff = "off";
        }

        /// <summary>
        /// Class for system-event of boot completed
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class BootCompleted
        {
            /// <summary>
            /// Eventname for system-event of boot completed
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.boot_completed";
        }

        /// <summary>
        /// Class for system-event of system shutdown
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class SystemShutdown
        {
            /// <summary>
            /// Eventname for system-event of system shutdown
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.system_shutdown";
        }

        /// <summary>
        /// Class for system-event of low memory
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class LowMemory
        {
            /// <summary>
            /// Eventname for system-event of low memory
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.low_memory";

            /// <summary>
            /// Key for system-event of low memory
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string Key = "low_memory";

            /// <summary>
            /// Value of normal low memory
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string ValueNormal = "normal";

            /// <summary>
            /// Value of soft warning low memory
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string ValueSoftWarning = "soft_warning";

            /// <summary>
            /// Value of hard warning low memory
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string ValueHardWarning = "hard_warning";
        }

        /// <summary>
        /// Class for system-event of wifi state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class WifiState
        {
            /// <summary>
            /// Eventname for system-event of wifi state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.wifi_state";

            /// <summary>
            /// Key for system-event of wifi state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateKey = "wifi_state";

            /// <summary>
            /// Value of off wifi state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueOff = "off";

            /// <summary>
            /// Value of on wifi state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueOn = "on";

            /// <summary>
            /// Value of connected wifi state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueConnected = "connected";
        }

        /// <summary>
        /// Class for system-event of bluetooth state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class Btstate
        {
            /// <summary>
            /// Eventname for system-event of bluetooth state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.bt_state";

            /// <summary>
            /// Key for system-event of bluetooth state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateKey = "bt_state";

            /// <summary>
            /// Value of off bluetooth state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueOff = "off";

            /// <summary>
            /// Value of on bluetooth state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueOn = "on";

            /// <summary>
            /// Key for system-event of low energy bluetooth state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string LeStateKey = "bt_le_state";

            /// <summary>
            /// Value of off low energy bluetooth state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string LeStateValueOff = "off";

            /// <summary>
            /// Value of on low energy bluetooth state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string LeStateValueOn = "on";

            /// <summary>
            /// Key for system-event of transfering bluetooth state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string TransferStateKey = "bt_transfering_state";

            /// <summary>
            /// Value of non transfering bluetooth state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string TransferStateValueNontransfering = "non_transfering";

            /// <summary>
            /// Value of transfering bluetooth state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string TransferStateValueTransfering = "transfering";
        }

        /// <summary>
        /// Class for system-event of location enable state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class LocatingEnableState
        {
            /// <summary>
            /// Eventname for system-event of location enable state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.location_enable_state";

            /// <summary>
            /// Key for system-event of location enable state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateKey = "location_enable_state";

            /// <summary>
            /// Value of disabled location enable state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueDisabled = "disabled";

            /// <summary>
            /// Value of enabled location enable state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueEnabled = "enabled";
        }

        /// <summary>
        /// Class for system-event of gps enable state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class GpsEnableState
        {
            /// <summary>
            /// Eventname for system-event of gps enable state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.gps_enable_state";

            /// <summary>
            /// Key for system-event of gps enable state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateKey = "gps_enable_state";

            /// <summary>
            /// Value of disabled gps enable state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueDisabled = "disabled";

            /// <summary>
            /// Value of enabled gps enable state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueEnabled = "enabled";
        }

        /// <summary>
        /// Class for system-event of nps enable state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class NpsEnableState
        {
            /// <summary>
            /// Eventname for system-event of nps enable state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.nps_enable_state";

            /// <summary>
            /// Key for system-event of nps enable state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateKey = "nps_enable_state";

            /// <summary>
            /// Value of diabled nps enable state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueDisabled = "disabled";

            /// <summary>
            /// Value of enabled nps enable state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueEnabled = "enabled";
        }

        /// <summary>
        /// Class for system-event of incoming message
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class IncomingMsg
        {
            /// <summary>
            /// Event for system-event of incoming message
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.incoming_msg";

            /// <summary>
            /// Key for system-event of incoming message type
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string TypeKey = "msg_type";

            /// <summary>
            /// Value of sms incoming message type
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string TypeValueSms = "sms";

            /// <summary>
            /// Value of mms incoming message type
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string TypeValueMms = "mms";

            /// <summary>
            /// Value of push incoming message type
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string TypeValuePush = "push";

            /// <summary>
            /// Value of cb incoming message type
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string TypeValueCb = "cb";

            /// <summary>
            /// Key for system-event of incoming message id
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string IdKey = "msg_id";
        }

        /// <summary>
        /// Class for system-event of outgoing message
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class OutgoingMsg
        {
            /// <summary>
            /// Eventname for system-event of outgoing message
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.outgoing_msg";

            /// <summary>
            /// Key for system-event of outgoing message type
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string TypeKey = "msg_type";

            /// <summary>
            /// Value of sms outgoing message type
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string TypeValueSms = "sms";

            /// <summary>
            /// Value of mms outgoing message type
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string TypeValueMms = "mms";

            /// <summary>
            /// Key for system-event of outgoing message id
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string IdKey = "msg_id";
        }

        /// <summary>
        /// Class for system-event of time changed
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class TimeChanged
        {
            /// <summary>
            /// Eventname for system-event of time changed
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.time_changed";

            /// <summary>
            /// Key for system-event of time changed
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string Key = null;
        }

        /// <summary>
        /// Class for system-event of time zone
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class TimeZone
        {
            /// <summary>
            /// Eventname for system-event of time zone
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.time_zone";

            /// <summary>
            /// Key for system-event of time zone
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string Key = "time_zone";
        }

        /// <summary>
        /// Class for system-event of hour format
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class HourFormat
        {
            /// <summary>
            /// Eventname for system-event of hour format
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.hour_format";

            /// <summary>
            /// Key for system-event of hour format
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string Key = "hour_format";

            /// <summary>
            /// Value of 12 hour format
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string Value12 = "12";

            /// <summary>
            /// Value of 24 hour format
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string Value24 = "24";
        }

        /// <summary>
        /// Class for system-event of language set
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class LanguageSet
        {
            /// <summary>
            /// Eventname for system-event of language set
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.language_set";

            /// <summary>
            /// Key for system-event of language set
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string Key = "language_set";
        }

        /// <summary>
        /// Class for system-event of region format
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class RegionFormat
        {
            /// <summary>
            /// Eventname for system-event of region format
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.region_format";

            /// <summary>
            /// Key for system-event of region format
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string Key = "region_format";
        }

        /// <summary>
        /// Class for system-event of silent mode
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class SilentMode
        {
            /// <summary>
            /// Event for system-event of silent mode
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.silent_mode";

            /// <summary>
            /// Key for system-event of silent mode
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string Key = "silent_mode";

            /// <summary>
            /// Value of silent mode on
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string ValueOn = "on";

            /// <summary>
            /// Value of silent mode off
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string ValueOff = "off";
        }

        /// <summary>
        /// Class for system-event of vibration state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class VibrationState
        {
            /// <summary>
            /// Eventname for system-event of vibration state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.vibration_state";

            /// <summary>
            /// Key for system-event of vibration state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateKey = "vibration_state";

            /// <summary>
            /// Value vibration state on
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueOn = "on";

            /// <summary>
            /// Value vibration state off
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueOff = "off";
        }

        /// <summary>
        /// Class for system-event of auto rotate state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class AutoRotateState
        {
            /// <summary>
            /// Eventname for system-event of auto rotate state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.autorotate_state";

            /// <summary>
            /// Key for system-event of auto rotate state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateKey = "autorotate_state";

            /// <summary>
            /// Value of auto rotate state on
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateOn = "on";

            /// <summary>
            /// Value of auto rotate state off
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateOff = "off";
        }

        /// <summary>
        /// Class for system-event of mobile data state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class MobileDataState
        {
            /// <summary>
            /// Eventname for system-event of mobile data state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.mobile_data_state";

            /// <summary>
            /// Key for system-event of mobile data state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateKey = "mobile_data_state";

            /// <summary>
            /// Value of mobile data state on
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueOn = "on";

            /// <summary>
            /// Value of mobile data state off
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueOff = "off";
        }

        /// <summary>
        /// Class for system-event of data roaming state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class DataRoamingState
        {
            /// <summary>
            /// Eventname for system-event of data roaming state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.data_roaming_state";

            /// <summary>
            /// Key for system-event of data roaming state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateKey = "data_roaming_state";

            /// <summary>
            /// Value of data roaming state on
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueOn = "on";

            /// <summary>
            /// Value of data roaming state off
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StateValueOff = "off";
        }

        /// <summary>
        /// Class for system-event of data font set
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class FontSet
        {
            /// <summary>
            /// Eventname for system-event of data font set
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.font_set";

            /// <summary>
            /// Key for system-event of data font set
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string Key = "font_set";
        }

        /// <summary>
        /// Class for system-event of network status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class NetworkStatus
        {
            /// <summary>
            /// Eventname for system-event of network status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string EventName = "tizen.system.event.network_status";

            /// <summary>
            /// Key for system-event of network status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusKey = "network_status";

            /// <summary>
            /// Value of disconnected network status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueDisconnected = "disconnected";

            /// <summary>
            /// Value of wifi network status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueWifi = "wifi";

            /// <summary>
            /// Value of cellular network status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueCellular = "cellular";

            /// <summary>
            /// Value of ethernet network status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueEthernet = "ethernet";

            /// <summary>
            /// Value of bt network status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueBt = "bt";

            /// <summary>
            /// Value of net proxy network status
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public const string StatusValueNetProxy = "net_proxy";
        }
    }
}

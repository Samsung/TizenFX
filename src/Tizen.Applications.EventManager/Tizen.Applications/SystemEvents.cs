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


namespace Tizen.Applications.EventManager.SystemEvents
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
        public static string EventName
        {
            get { return "tizen.system.event.battery_charger_status"; }
        }

        /// <summary>
        /// Key for system-event of battery charger status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusKey
        {
            get { return "battery_charger_status"; }
        }

        /// <summary>
        /// Value of connected battery charger
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueConnected
        {
            get { return "connected"; }
        }

        /// <summary>
        /// Value of disconnected battery charger
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueDisconnected
        {
            get { return "disconnected"; }
        }

        /// <summary>
        /// Value of charing battery charger
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueCharging
        {
            get { return "charging"; }
        }

        /// <summary>
        /// Value of discharging battery charger
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueDischarging
        {
            get { return "discharging"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.battery_level_status"; }
        }

        /// <summary>
        /// Key for system-event of battery level status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusKey
        {
            get { return "battery_level_status"; }
        }

        /// <summary>
        /// Value of empty battery level status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueEmpty
        {
            get { return "empty"; }
        }

        /// <summary>
        /// Value of critical battery level status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueCritical
        {
            get { return "critical"; }
        }

        /// <summary>
        /// Value of low battery level status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueLow
        {
            get { return "low"; }
        }

        /// <summary>
        /// Value of high battery level status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueHigh
        {
            get { return "high"; }
        }

        /// <summary>
        /// Value of full battery level status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueFull
        {
            get { return "full"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.usb_status"; }
        }

        /// <summary>
        /// Key for system-event of usb status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusKey
        {
            get { return "usb_status"; }
        }

        /// <summary>
        /// Value of disconnected usb status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueDisconnected
        {
            get { return "disconnected"; }
        }

        /// <summary>
        /// Value of connected usb status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueConnected
        {
            get { return "connected"; }
        }

        /// <summary>
        /// Value of available usb status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueAvailable
        {
            get { return "available"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.earjack_status"; }
        }

        /// <summary>
        /// Key for system-event of earjack status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusKey
        {
            get { return "earjack_status"; }
        }

        /// <summary>
        /// Value of disconnected earjack status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueDisconnected
        {
            get { return "disconnected"; }
        }

        /// <summary>
        /// Value of connected earjack status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueConnected
        {
            get { return "connected"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.display_state"; }
        }

        /// <summary>
        /// Key for system-event of display state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateKey
        {
            get { return "display_state"; }
        }

        /// <summary>
        /// Value of normal display state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueNormal
        {
            get { return "normal"; }
        }

        /// <summary>
        /// Value of dim display state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueDim
        {
            get { return "dim"; }
        }

        /// <summary>
        /// Value of off display state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueOff
        {
            get { return "off"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.boot_completed"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.system_shutdown"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.low_memory"; }
        }

        /// <summary>
        /// Key for system-event of low memory
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string Key
        {
            get { return "low_memory"; }
        }

        /// <summary>
        /// Value of normal low memory
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string ValueNormal
        {
            get { return "normal"; }
        }

        /// <summary>
        /// Value of soft warning low memory
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string ValueSoftWarning
        {
            get { return "soft_warning"; }
        }

        /// <summary>
        /// Value of hard warning low memory
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string ValueHardWarning
        {
            get { return "hard_warning"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.wifi_state"; }
        }

        /// <summary>
        /// Key for system-event of wifi state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateKey
        {
            get { return "wifi_state"; }
        }

        /// <summary>
        /// Value of off wifi state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueOff
        {
            get { return "off"; }
        }

        /// <summary>
        /// Value of on wifi state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueOn
        {
            get { return "on"; }
        }

        /// <summary>
        /// Value of connected wifi state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueConnected
        {
            get { return "connected"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.bt_state"; }
        }

        /// <summary>
        /// Key for system-event of bluetooth state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateKey
        {
            get { return "bt_state"; }
        }

        /// <summary>
        /// Value of off bluetooth state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueOff
        {
            get { return "off"; }
        }

        /// <summary>
        /// Value of on bluetooth state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueOn
        {
            get { return "on"; }
        }

        /// <summary>
        /// Key for system-event of low energy bluetooth state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string LeStateKey
        {
            get { return "bt_le_state"; }
        }

        /// <summary>
        /// Value of off low energy bluetooth state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string LeStateValueOff
        {
            get { return "off"; }
        }

        /// <summary>
        /// Value of on low energy bluetooth state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string LeStateValueOn
        {
            get { return "on"; }
        }

        /// <summary>
        /// Key for system-event of transfering bluetooth state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string TransferStateKey
        {
            get { return "bt_transfering_state"; }
        }

        /// <summary>
        /// Value of non transfering bluetooth state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string TransferStateValueNontransfering
        {
            get { return "non_transfering"; }
        }

        /// <summary>
        /// Value of transfering bluetooth state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string TransferStateValueTransfering
        {
            get { return "transfering"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.location_enable_state"; }
        }

        /// <summary>
        /// Key for system-event of location enable state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateKey
        {
            get { return "location_enable_state"; }
        }

        /// <summary>
        /// Value of disabled location enable state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueDisabled
        {
            get { return "disabled"; }
        }

        /// <summary>
        /// Value of enabled location enable state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueEnabled
        {
            get { return "enabled"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.gps_enable_state"; }
        }

        /// <summary>
        /// Key for system-event of gps enable state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateKey
        {
            get { return "gps_enable_state"; }
        }

        /// <summary>
        /// Value of disabled gps enable state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueDisabled
        {
            get { return "disabled"; }
        }

        /// <summary>
        /// Value of enabled gps enable state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueEnabled
        {
            get { return "enabled"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.nps_enable_state"; }
        }

        /// <summary>
        /// Key for system-event of nps enable state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateKey
        {
            get { return "nps_enable_state"; }
        }

        /// <summary>
        /// Value of diabled nps enable state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueDisabled
        {
            get { return "disabled"; }
        }

        /// <summary>
        /// Value of enabled nps enable state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueEnabled
        {
            get { return "enabled"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.incoming_msg"; }
        }

        /// <summary>
        /// Key for system-event of incoming message type
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string TypeKey
        {
            get { return "msg_type"; }
        }

        /// <summary>
        /// Value of sms incoming message type
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string TypeValueSms
        {
            get { return "sms"; }
        }

        /// <summary>
        /// Value of mms incoming message type
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string TypeValueMms
        {
            get { return "mms"; }
        }

        /// <summary>
        /// Value of push incoming message type
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string TypeValuePush
        {
            get { return "push"; }
        }

        /// <summary>
        /// Value of cb incoming message type
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string TypeValueCb
        {
            get { return "cb"; }
        }

        /// <summary>
        /// Key for system-event of incoming message id
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string IdKey
        {
            get { return "msg_id"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.outgoing_msg"; }
        }

        /// <summary>
        /// Key for system-event of outgoing message type
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string TypeKey
        {
            get { return "msg_type"; }
        }

        /// <summary>
        /// Value of sms outgoing message type
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string TypeValueSms
        {
            get { return "sms"; }
        }

        /// <summary>
        /// Value of mms outgoing message type
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string TypeValueMms
        {
            get { return "mms"; }
        }

        /// <summary>
        /// Key for system-event of outgoing message id
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string IdKey
        {
            get { return "msg_id"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.time_changed"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.time_zone"; }
        }

        /// <summary>
        /// Key for system-event of time zone
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string Key
        {
            get { return "time_zone"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.hour_format"; }
        }

        /// <summary>
        /// Key for system-event of hour format
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string Key
        {
            get { return "hour_format"; }
        }

        /// <summary>
        /// Value of 12 hour format
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string Value12
        {
            get { return "12"; }
        }

        /// <summary>
        /// Value of 24 hour format
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string Value24
        {
            get { return "24"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.language_set"; }
        }

        /// <summary>
        /// Key for system-event of language set
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string Key
        {
            get { return "language_set"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.region_format"; }
        }

        /// <summary>
        /// Key for system-event of region format
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string Key
        {
            get { return "region_format"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.silent_mode"; }
        }

        /// <summary>
        /// Key for system-event of silent mode
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string Key
        {
            get { return "silent_mode"; }
        }

        /// <summary>
        /// Value of silent mode on
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string ValueOn
        {
            get { return "on"; }
        }

        /// <summary>
        /// Value of silent mode off
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string ValueOff
        {
            get { return "off"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.vibration_state"; }
        }

        /// <summary>
        /// Key for system-event of vibration state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateKey
        {
            get { return "vibration_state"; }
        }

        /// <summary>
        /// Value vibration state on
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueOn
        {
            get { return "on"; }
        }

        /// <summary>
        /// Value vibration state off
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueOff
        {
            get { return "off"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.autorotate_state"; }
        }

        /// <summary>
        /// Key for system-event of auto rotate state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateKey
        {
            get { return "autorotate_state"; }
        }

        /// <summary>
        /// Value of auto rotate state on
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateOn
        {
            get { return "on"; }
        }

        /// <summary>
        /// Value of auto rotate state off
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateOff
        {
            get { return "off"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.mobile_data_state"; }
        }

        /// <summary>
        /// Key for system-event of mobile data state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateKey
        {
            get { return "mobile_data_state"; }
        }

        /// <summary>
        /// Value of mobile data state on
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueOn
        {
            get { return "on"; }
        }

        /// <summary>
        /// Value of mobile data state off
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueOff
        {
            get { return "off"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.data_roaming_state"; }
        }

        /// <summary>
        /// Key for system-event of data roaming state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateKey
        {
            get { return "data_roaming_state"; }
        }

        /// <summary>
        /// Value of data roaming state on
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueOn
        {
            get { return "on"; }
        }

        /// <summary>
        /// Value of data roaming state off
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StateValueOff
        {
            get { return "off"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.font_set"; }
        }

        /// <summary>
        /// Key for system-event of data font set
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string Key
        {
            get { return "font_set"; }
        }
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
        public static string EventName
        {
            get { return "tizen.system.event.network_status"; }
        }

        /// <summary>
        /// Key for system-event of network status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusKey
        {
            get { return "network_status"; }
        }

        /// <summary>
        /// Value of disconnected network status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueDisconnected
        {
            get { return "disconnected"; }
        }

        /// <summary>
        /// Value of wifi network status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueWifi
        {
            get { return "wifi"; }
        }

        /// <summary>
        /// Value of cellular network status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueCellular
        {
            get { return "cellular"; }
        }

        /// <summary>
        /// Value of ethernet network status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueEthernet
        {
            get { return "ethernet"; }
        }

        /// <summary>
        /// Value of bt network status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueBt
        {
            get { return "bt"; }
        }

        /// <summary>
        /// Value of net proxy network status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static string StatusValueNetProxy
        {
            get { return "net_proxy"; }
        }
    }
}

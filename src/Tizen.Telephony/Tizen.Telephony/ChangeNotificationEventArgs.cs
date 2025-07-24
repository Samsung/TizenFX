/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

using System;
namespace Tizen.Telephony
{
    /// <summary>
    /// This class contains the data related to the Notification event.
    /// Each Notification type corresponds to a specific change in the telephony or network configuration,
    /// allowing developers to react accordingly. By leveraging these notifications, applications can maintain
    /// real-time awareness of critical telephony and network conditions, enhancing overall user experience.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// [Obsolete("Deprecated since API13, will be removed in API15.")]
    public class ChangeNotificationEventArgs : EventArgs
    {
        internal ChangeNotificationEventArgs(Notification noti, object data)
        {
            NotificationType = noti;
            NotificationData = data;
        }

        /// <summary>
        /// Enumeration for the Telephony Notification.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public enum Notification
        {
            /// <summary>
            /// The notification to be invoked when the SIM card state changes.
            /// SIM.State will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            SimStatus = 0x10,
            /// <summary>
            /// The notification to be invoked when the SIM call forwarding indicator state changes.
            /// 'state(bool)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            SimCallForwardingIndicatorState,
            /// <summary>
            /// The notification to be invoked when the network service state changes.
            /// Network.ServiceState will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            NetworkServiceState = 0x20,
            /// <summary>
            /// The notification to be invoked when the cell ID changes.
            /// 'cell_id(int)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/location.coarse
            /// </privilege>
            NetworkCellid,
            /// <summary>
            /// The notification to be invoked when the roaming status changes.
            /// 'roaming_status(bool)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            NetworkRoamingStatus,
            /// <summary>
            /// The notification to be invoked when the signal strength changes.
            /// Network.Rssi will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            NetworkSignalstrengthLevel,
            /// <summary>
            /// The notification to be invoked when the network name changes.
            /// 'network_name(string)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            NetworkNetworkName,
            /// <summary>
            /// The notification to be invoked when the PS type changes.
            /// Network.PSType will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            NetworkPsType,
            /// <summary>
            /// The notification to be invoked when the default data subscription changes.
            /// Network.DefaultDataSubscription will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            NetworkDefaultDataSubscription,
            /// <summary>
            /// The notification to be invoked when the default subscription changes.
            /// Network.DefaultSubscription will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            NetworkDefaultSubscription,
            /// <summary>
            /// The notification to be invoked when the LAC (Location Area Code) changes.
            /// 'lac(int)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/location.coarse
            /// </privilege>
            NetworkLac,
            /// <summary>
            /// The notification to be invoked when the TAC (Tracking Area Code) changes.
            /// 'tac(int)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/location.coarse
            /// </privilege>
            NetworkTac,
            /// <summary>
            /// The notification to be invoked when the system ID changes.
            /// 'sid(int)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/location.coarse
            /// </privilege>
            NetworkSystemId,
            /// <summary>
            /// The notification to be invoked when the network ID changes.
            /// 'nid(int)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/location.coarse
            /// </privilege>
            NetworkId,
            /// <summary>
            /// The notification to be invoked when the base station ID changes.
            /// 'id(int)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/location.coarse
            /// </privilege>
            NetworkBsId,
            /// <summary>
            /// The notification to be invoked when the base station latitude changes.
            /// 'latitude(int)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/location.coarse
            /// </privilege>
            NetworkBsLatitude,
            /// <summary>
            /// The notification to be invoked when the base station longitude changes.
            /// 'longitue(int)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/location.coarse
            /// </privilege>
            NetworkBsLongitude,
            /// <summary>
            /// The notification to be invoked when a voice call is in the idle status.
            /// 'handle id(uint)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VoiceCallStatusIdle = 0x32,
            /// <summary>
            /// The notification to be invoked when a voice call is in the active status.
            /// 'handle id(uint)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VoiceCallStatusActive,
            /// <summary>
            /// The notification to be invoked when a voice call is in the held status.
            /// 'handle id(uint)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VoiceCallStatusHeld,
            /// <summary>
            /// The notification to be invoked when a voice call is in the dialing status.
            /// 'handle id(uint)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VoiceCallStatusDialing,
            /// <summary>
            /// The notification to be invoked when a voice call is in the alerting status.
            /// 'handle id(uint)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VoiceCallStatusAlerting,
            /// <summary>
            /// The notification to be invoked when a voice call is in the incoming status.
            /// 'handle id(uint)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VoiceCallStatusIncoming,
            /// <summary>
            /// The notification to be invoked when a video call is in the idle status.
            /// 'handle id(uint)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VideoCallStatusIdle,
            /// <summary>
            /// The notification to be invoked when a video call is in the active status.
            /// 'handle id(uint)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VideoCallStatusActive,
            /// <summary>
            /// The notification to be invoked when a video call is in the dialing status.
            /// 'handle id(uint)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VideoCallStatusDialing,
            /// <summary>
            /// The notification to be invoked when a video call is in the alerting status.
            /// 'handle id(uint)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VideoCallStatusAlerting,
            /// <summary>
            /// The notification to be invoked when a video call is in the incoming status.
            /// 'handle id(uint)' will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VideoCallStatusIncoming,
            /// <summary>
            /// The notification to be invoked when the preferred voice subscription changes.
            /// CallPreferredVoiceSubscription will be delivered in the notification data.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            CallPreferredVoiceSubscription
        };

        /// <summary>
        /// The Telephony Notification type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public Notification NotificationType
        {
            get;
            internal set;
        }

        /// <summary>
        /// The data as per the Notification type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public object NotificationData
        {
            get;
            internal set;
        }
    }
}

/// Copyright 2016 by Samsung Electronics, Inc.
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;
namespace Tizen.Telephony
{
    /// <summary>
    /// This Class contains the data related to the Notification event
    /// </summary>
    public class ChangeNotificationEventArgs : EventArgs
    {
        /// <summary>
        /// Enumeration for Telephony notification.
        /// </summary>
        public enum Notification
        {
            /// <summary>
            /// Notification to be invoked when the SIM card state changes.
            /// SIM.State will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            SimStatus = 0x10,
            /// <summary>
            /// Notification to be invoked when the SIM call forwarding indicator state changes.
            /// 'state(bool)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            SimCallForwardingIndicatorState,
            /// <summary>
            /// Notification to be invoked when the network service state changes.
            /// Network.ServiceState will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            NetworkServiceState = 0x20,
            /// <summary>
            /// Notification to be invoked when the cell ID changes.
            /// 'cell_id(int)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/location.coarse
            /// </privilege>
            NetworkCellid,
            /// <summary>
            /// Notification to be invoked when the roaming status changes.
            /// 'roaming_status(bool)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            NetworkRoamingStatus,
            /// <summary>
            /// Notification to be invoked when the signal strength changes.
            /// Network.Rssi will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            NetworkSignalstrengthLevel,
            /// <summary>
            /// Notification to be invoked when the network name changes.
            /// 'network_name(string)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            NetworkNetworkName,
            /// <summary>
            /// Notification to be invoked when the ps type changes.
            /// Network.PSType will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            NetworkPsType,
            /// <summary>
            /// Notification to be invoked when the default data subscription changes.
            /// Network.DefaultDataSubscription will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            NetworkDefaultDataSubscription,
            /// <summary>
            /// Notification to be invoked when the default subscription changes.
            /// Network.DefaultSubscription will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            NetworkDefaultSubscription,
            /// <summary>
            /// Notification to be invoked when the LAC (Location Area Code) changes.
            /// 'lac(int)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/location.coarse
            /// </privilege>
            NetworkLac,
            /// <summary>
            /// Notification to be invoked when the TAC (Tracking Area Code) changes.
            /// 'tac(int)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/location.coarse
            /// </privilege>
            NetworkTac,
            /// <summary>
            /// Notification to be invoked when the system ID changes.
            /// 'sid(int)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/location.coarse
            /// </privilege>
            NetworkSystemId,
            /// <summary>
            /// Notification to be invoked when the network ID changes.
            /// 'nid(int)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/location.coarse
            /// </privilege>
            NetworkId,
            /// <summary>
            /// Notification to be invoked when the base station ID changes.
            /// 'id(int)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/location.coarse
            /// </privilege>
            NetworkBsId,
            /// <summary>
            /// Notification to be invoked when the base station latitude changes.
            /// 'latitude(int)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/location.coarse
            /// </privilege>
            NetworkBsLatitude,
            /// <summary>
            /// Notification to be invoked when the base station longitude changes.
            /// 'longitue(int)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/location.coarse
            /// </privilege>
            NetworkBsLongitude,
            /// <summary>
            /// Notification to be invoked when a voice call is in idle status.
            /// 'handle id(uint)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VoiceCallStatusIdle,
            /// <summary>
            /// Notification to be invoked when a voice call is in active status.
            /// 'handle id(uint)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VoiceCallStatusActive,
            /// <summary>
            /// Notification to be invoked when a voice call is in held status.
            /// 'handle id(uint)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VoiceCallStatusHeld,
            /// <summary>
            /// Notification to be invoked when a voice call is in dialing status.
            /// 'handle id(uint)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VoiceCallStatusDialing,
            /// <summary>
            /// Notification to be invoked when a voice call is in alertingstatus.
            /// 'handle id(uint)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VoiceCallStatusAlerting,
            /// <summary>
            /// Notification to be invoked when a voice call is in incoming status.
            /// 'handle id(uint)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VoiceCallStatusIncoming,
            /// <summary>
            /// Notification to be invoked when a video call is in idle status.
            /// 'handle id(uint)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VideoCallStatusIdle,
            /// <summary>
            /// Notification to be invoked when a video call is in active status.
            /// 'handle id(uint)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VideoCallStatusActive,
            /// <summary>
            /// Notification to be invoked when a video call is in dialing status.
            /// 'handle id(uint)' will be delivered in notification data.
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VideoCallStatusDialing,
            /// <summary>
            /// Notification to be invoked when a video call is in alerting status.
            /// 'handle id(uint)' will be delivered in notification data
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VideoCallStatusAlerting,
            /// <summary>
            /// Notification to be invoked when a video call is in incoming status.
            /// 'handle id(uint)' will be delivered in notification data
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            VideoCallStatusIncoming,
            /// <summary>
            /// Notification to be invoked when the preferred voice subscription changes.
            /// CallPreferredVoiceSubsubscription will be delivered in notification data
            /// </summary>
            /// <privilege>
            /// http://tizen.org/privilege/telephony
            /// </privilege>
            CallPreferredVoiceSubscription
        };

        /// <summary>
        /// Telephony notification type
        /// </summary>
        public Notification notificationType;

        /// <summary>
        /// Data as per the Notification type
        /// </summary>
        public object notificationData;

        internal ChangeNotificationEventArgs(Notification noti, object data)
        {
            notificationType = noti;
            notificationData = data;
        }
    }
}

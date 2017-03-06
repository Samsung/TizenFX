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
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.Telephony
{
    /// <summary>
    /// This Class provides API's that provides functionality related to slot handle.
    /// </summary>
    public class SlotHandle
    {
        internal IntPtr _handle;
        private List<Interop.Telephony.NotificationCallback> _changeNotificationList = new List<Interop.Telephony.NotificationCallback>();

        internal SlotHandle(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Event Handler for Receiving the Telephony State Changes
        /// this event will be triggered for the NotificationId's given in the SetNotificationId API
        /// </summary>
        public event EventHandler<ChangeNotificationEventArgs> ChangeNotification;

        internal IntPtr Handle
        {
            get
            {
                return _handle;
            }
        }

        /// <summary>
        /// The Notification Id's for which the ChangeNotification event will be triggered
        /// </summary>
        /// <param name="list">
        /// The List of Notification Id's for which the ChangeNotification event will be triggered
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// This Exception can occur due to:
        /// 1. Operation Not Supported
        /// 2. Operation Failed
        /// </exception>
        public void SetNotificationId(IEnumerable<ChangeNotificationEventArgs.Notification> list)
        {
            try
            {
                foreach (ChangeNotificationEventArgs.Notification n in list)
                {
                    SetCallback(n);
                }
            }
            catch (Exception e)
            {
                Tizen.Log.Error(Interop.Telephony.LogTag, "SetNotificationId Failed with Error " + e.ToString());
                throw e;
            }
        }

        /// <summary>
        /// The Notification Id's for which the ChangeNotification event will not be triggered
        /// </summary>
        /// <param name="list">
        /// The List of Notification Id's for which the ChangeNotification event will be not be triggered
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// This Exception can occur due to:
        /// 1. Operation Not Supported
        /// 2. Operation Failed
        /// </exception>
        public void RemoveNotificationId(IEnumerable<ChangeNotificationEventArgs.Notification> list)
        {
            foreach (ChangeNotificationEventArgs.Notification n in list)
            {
                Interop.Telephony.TelephonyError error = Interop.Telephony.TelephonyUnsetNotiCb(_handle, n);
                if (error != Interop.Telephony.TelephonyError.None)
                {
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        private void SetCallback(ChangeNotificationEventArgs.Notification n)
        {
            Interop.Telephony.NotificationCallback NotificationDelegate = (IntPtr handle, ChangeNotificationEventArgs.Notification notiId, IntPtr data, IntPtr userData) =>
            {
                SlotHandle simHandle = Manager.FindHandle(handle);
                object notiData = null;
                switch (notiId)
                {
                    case ChangeNotificationEventArgs.Notification.SimStatus:
                        {
                            notiData = (Sim.State)Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.SimCallForwardingIndicatorState:
                        {
                            notiData = ((Marshal.ReadInt32(data) == 0) ? false : true);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.NetworkServiceState:
                        {
                            notiData = (Network.ServiceState)Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.NetworkCellid:
                        {
                            notiData = Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.NetworkRoamingStatus:
                        {
                            notiData = (Marshal.ReadInt32(data) == 0) ? false : true;
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.NetworkSignalstrengthLevel:
                        {
                            notiData = (Network.Rssi)Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.NetworkNetworkName:
                        {
                            notiData = Marshal.PtrToStringAnsi(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.NetworkPsType:
                        {
                            notiData = (Network.PsType)Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.NetworkDefaultDataSubscription:
                        {
                            notiData = (Network.DefaultDataSubscription)Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.NetworkDefaultSubscription:
                        {
                            notiData = (Network.DefaultSubscription)Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.NetworkLac:
                        {
                            notiData = Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.NetworkTac:
                        {
                            notiData = Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.NetworkSystemId:
                        {
                            notiData = Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.NetworkId:
                        {
                            notiData = Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.NetworkBsId:
                        {
                            notiData = Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.NetworkBsLatitude:
                        {
                            notiData = Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.NetworkBsLongitude:
                        {
                            notiData = Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.VoiceCallStatusIdle:
                        {
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.VoiceCallStatusActive:
                        {
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.VoiceCallStatusHeld:
                        {
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.VoiceCallStatusDialing:
                        {
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.VoiceCallStatusAlerting:
                        {
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.VoiceCallStatusIncoming:
                        {
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.VideoCallStatusIdle:
                        {
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.VideoCallStatusActive:
                        {
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.VideoCallStatusDialing:
                        {
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.VideoCallStatusAlerting:
                        {
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.VideoCallStatusIncoming:
                        {
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        }

                    case ChangeNotificationEventArgs.Notification.CallPreferredVoiceSubscription:
                        {
                            notiData = (CallPreferredVoiceSubscription)Marshal.ReadInt32(data);
                            break;
                        }

                }

                ChangeNotificationEventArgs args = new ChangeNotificationEventArgs(notiId, notiData);
                ChangeNotification?.Invoke(simHandle, args);
            };
            _changeNotificationList.Add(NotificationDelegate);

            Interop.Telephony.TelephonyError error = Interop.Telephony.TelephonySetNotiCb(_handle, n, NotificationDelegate, IntPtr.Zero);
            if (error != Interop.Telephony.TelephonyError.None)
            {
                Exception e = ExceptionFactory.CreateException(error);
                // Check if error is Invalid Parameter then hide the error
                if (e is ArgumentException)
                {
                    e = new InvalidOperationException("Internal Error Occured");
                }

                throw e;
            }
        }
    }
}

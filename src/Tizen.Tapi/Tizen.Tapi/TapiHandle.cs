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
using System.Runtime.InteropServices;

namespace Tizen.Tapi
{
    /// <summary>
    /// This class is used for managing event callbacks for notifications and properties.
    /// </summary>
    public class TapiHandle
    {
        internal IntPtr _handle = IntPtr.Zero;
        private event EventHandler<NotificationChangedEventArgs> _notificationChanged;
        private event EventHandler<PropertyChangedEventArgs> _propertyChanged;

        private Interop.Tapi.TapiNotificationCallback _notificationChangedCb;

        /// <summary>
        /// This event is called for the TAPI notification change.
        /// </summary>
        public event EventHandler<NotificationChangedEventArgs> NotificationChanged
        {
            add
            {
                _notificationChanged += value;
            }

            remove
            {
                _notificationChanged -= value;
            }
        }

        /// <summary>
        /// This event is called for the TAPI property change.
        /// </summary>
        public event EventHandler<PropertyChangedEventArgs> PropertyChanged
        {
            add
            {
                _propertyChanged += value;
            }

            remove
            {
                _propertyChanged -= value;
            }
        }

        internal TapiHandle(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Registers a notification callback for notification change events on DBus interface.
        /// </summary>
        /// <param name="id">Notification id for which a callback has to be registered.</param>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public void RegisterNotiEvent(Notification id)
        {
            _notificationChangedCb = (IntPtr handle, string notiId, IntPtr data, IntPtr userData) =>
            {
                if (_notificationChanged != null)
                {
                    object notiData = null;
                    Notification noti = default(Notification);
                    if (notiId != null)
                    {
                        foreach (Notification n in Enum.GetValues(typeof(Notification)))
                        {
                            if (notiId == TapiUtility.ConvertNotiToString(n))
                            {
                                noti = n;
                                break;
                            }
                        }
                    }

                    switch (noti)
                    {
                        case Notification.IdleVoiceCall:
                            CallIdleStatusNotiStruct voiceIdleStatusNoti = Marshal.PtrToStructure<CallIdleStatusNotiStruct>(data);
                            notiData = CallStructConversions.ConvertCallIdleStatusNoti(voiceIdleStatusNoti);
                            break;
                        case Notification.ActiveVoiceCall:
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Notification.HeldVoiceCall:
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Notification.DialingVoiceCall:
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Notification.AlertVoiceCall:
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Notification.IncomingVoiceCall:
                            CallIncomingInfoStruct callIncomingInfo = Marshal.PtrToStructure<CallIncomingInfoStruct>(data);
                            notiData = CallStructConversions.ConvertIncomingCallInfo(callIncomingInfo);
                            break;
                        case Notification.IdleVideoCall:
                            CallIdleStatusNotiStruct videoIdleStatus = Marshal.PtrToStructure<CallIdleStatusNotiStruct>(data);
                            notiData = CallStructConversions.ConvertCallIdleStatusNoti(videoIdleStatus);
                            break;
                        case Notification.ActiveVideoCall:
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Notification.DialingVideoCall:
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Notification.AlertVideoCall:
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Notification.IncomingVideoCall:
                            CallIncomingInfoStruct videoIncomingInfo = Marshal.PtrToStructure<CallIncomingInfoStruct>(data);
                            notiData = CallStructConversions.ConvertIncomingCallInfo(videoIncomingInfo);
                            break;
                        case Notification.WaitingCallInfo:
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Notification.ForwardCallInfo:
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Notification.BarredIncomingCallInfo:
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Notification.BarredOutgoingCallInfo:
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Notification.ForwardUnconditionalCallInfo:
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Notification.ForwardConditionalCallInfo:
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Notification.ForwardedCallInfo:
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Notification.HeldCallInfo:
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Notification.ActiveCallInfo:
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Notification.JoinedCallInfo:
                            notiData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Notification.RecCallInfo:
                            CallRecordStruct recordStruct = Marshal.PtrToStructure<CallRecordStruct>(data);
                            notiData = CallStructConversions.ConvertCallRecordStruct(recordStruct);
                            break;
                        case Notification.PrivacyModeCall:
                            notiData = (CallPrivacyMode)Marshal.ReadInt32(data);
                            break;
                        case Notification.OtaspCall:
                            notiData = (CallOtaspStatus)Marshal.ReadInt32(data);
                            break;
                        case Notification.OtapaCall:
                            notiData = (CallOtapaStatus)Marshal.ReadInt32(data);
                            break;
                        case Notification.CallSignalInfo:
                            CallSignalInfoStruct signalInfoStruct = Marshal.PtrToStructure<CallSignalInfoStruct>(data);
                            notiData = CallStructConversions.ConvertCallSignalInfo(signalInfoStruct);
                            break;
                        case Notification.CallSoundPath:
                            notiData = (SoundPath)Marshal.ReadInt32(data);
                            break;
                        case Notification.CallSoundRingbackTone:
                            notiData = (CallSoundRingbackNoti)Marshal.ReadInt32(data);
                            break;
                        case Notification.CallSoundWbamr:
                            notiData = (CallSoundWbamrNoti)Marshal.ReadInt32(data);
                            break;
                        case Notification.CallSoundNoiceReduction:
                            notiData = (CallSoundNoiseReduction)Marshal.ReadInt32(data);
                            break;
                        case Notification.CallSoundClock:
                            notiData = Marshal.ReadInt32(data);
                            break;
                        case Notification.CallPreferredVoiceSubscription:
                            notiData = (CallPreferredVoiceSubscription)Marshal.ReadInt32(data);
                            break;
                        case Notification.CallupgradeRequested:
                            CallUpgradeDowngradeNotiStruct upgradeNotiStruct = Marshal.PtrToStructure<CallUpgradeDowngradeNotiStruct>(data);
                            notiData = CallStructConversions.ConvertCallUpgradeNoti(upgradeNotiStruct);
                            break;
                        case Notification.CallDowngraded:
                            CallUpgradeDowngradeNotiStruct downgradeNotiStruct = Marshal.PtrToStructure<CallUpgradeDowngradeNotiStruct>(data);
                            notiData = CallStructConversions.ConvertCallUpgradeNoti(downgradeNotiStruct);
                            break;
                        case Notification.ModemPower:
                            notiData = (PhonePowerStatus)Marshal.ReadInt32(data);
                            break;
                        case Notification.SimStatus:
                            notiData = (SimCardStatus)Marshal.ReadInt32(data);
                            break;
                        case Notification.SimRefreshed:
                            notiData = (SatCmdQualiRefresh)Marshal.ReadInt32(data);
                            break;
                        case Notification.SatSetupMenu:
                            SatMainMenuInfoStruct mainMenuStruct = Marshal.PtrToStructure<SatMainMenuInfoStruct>(data);
                            notiData = SatStructConversions.ConvertSatMainMenuInfoStruct(mainMenuStruct);
                            break;
                        case Notification.SatDisplayText:
                            SatDisplayTextStruct textStruct = Marshal.PtrToStructure<SatDisplayTextStruct>(data);
                            notiData = SatStructConversions.ConvertSatDisplayTextStruct(textStruct);
                            break;
                        case Notification.SatSelectItem:
                            SatSelectItemStruct itemStruct = Marshal.PtrToStructure<SatSelectItemStruct>(data);
                            notiData = SatStructConversions.ConvertSatSelectItemStruct(itemStruct);
                            break;
                        case Notification.SatGetInKey:
                            SatGetInKeyStruct inKeyStruct = Marshal.PtrToStructure<SatGetInKeyStruct>(data);
                            notiData = SatStructConversions.ConvertSatGetInKeyStruct(inKeyStruct);
                            break;
                        case Notification.SatGetInput:
                            SatGetInputStruct inputStruct = Marshal.PtrToStructure<SatGetInputStruct>(data);
                            notiData = SatStructConversions.ConvertSatGetInputStruct(inputStruct);
                            break;
                        case Notification.SatRefresh:
                            SatRefreshStruct refreshStruct = Marshal.PtrToStructure<SatRefreshStruct>(data);
                            notiData = SatStructConversions.ConvertSatRefreshStruct(refreshStruct);
                            break;
                        case Notification.SatSendSms:
                            SatSendSmsStruct smsStruct = Marshal.PtrToStructure<SatSendSmsStruct>(data);
                            notiData = SatStructConversions.ConvertSatSendSmsStruct(smsStruct);
                            break;
                    }

                    _notificationChanged(null, new NotificationChangedEventArgs(noti, notiData));
                }
            };
            int ret = Interop.Tapi.RegisterNotiEvent(_handle, TapiUtility.ConvertNotiToString(id), _notificationChangedCb, IntPtr.Zero);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to register notification event, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle);
            }
        }

        /// <summary>
        /// Registers a notification callback for property change events on DBus interface.
        /// </summary>
        /// <param name="property">Property definition for which a callback has to be registered.</param>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public void RegisterPropEvent(Property property)
        {
            _notificationChangedCb = (IntPtr handle, string prop, IntPtr data, IntPtr userData) =>
            {

            };
            int ret = Interop.Tapi.RegisterNotiEvent(_handle, TapiUtility.ConvertPropToString(property), _notificationChangedCb, IntPtr.Zero);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to register notification event for property change, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle);
            }
        }

        /// <summary>
        /// Deregisters notification callback for notification change events on DBus interface.
        /// </summary>
        /// <param name="id">Notification id for which the callback has to be de-registered.</param>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public void DeregisterNotiEvent(Notification id)
        {
            int ret = Interop.Tapi.DeregisterNotiEvent(_handle, TapiUtility.ConvertNotiToString(id));
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to deregister notification event, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle);
            }
        }

        /// <summary>
        /// Deregisters notification callback for property change events on DBus interface.
        /// </summary>
        /// <param name="property">Property definition for which the callback has to be de-registered.</param>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public void DeregisterPropEvent(Property property)
        {
            int ret = Interop.Tapi.DeregisterNotiEvent(_handle, TapiUtility.ConvertPropToString(property));
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to deregister notification event for property change, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle);
            }
        }

        /// <summary>
        /// Gets the property value in an integer format for the given property.
        /// </summary>
        /// <param name="property">The property to be retrieved from Dbus.</param>
        /// <returns>The property value in integer format.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public int GetIntProperty(Property property)
        {
            int result;
            int ret = Interop.Tapi.GetIntProperty(_handle, TapiUtility.ConvertPropToString(property), out result);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get property in integer format, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return result;
        }

        /// <summary>
        /// Gets the property value in a string format for the given property.
        /// </summary>
        /// <param name="property">The property to be retrieved from Dbus.</param>
        /// <returns>The property value in string format.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public string GetStringProperty(Property property)
        {
            string result;
            int ret = Interop.Tapi.GetStringProperty(_handle, TapiUtility.ConvertPropToString(property), out result);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get property in string format, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return result;
        }
    }
}

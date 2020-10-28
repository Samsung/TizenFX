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

        private List<Interop.Tapi.TapiNotificationCallback> _notificationChangedCbList = new List<Interop.Tapi.TapiNotificationCallback>();
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
            _notificationChangedCb = (IntPtr handle, IntPtr notiIdPtr, IntPtr data, IntPtr userData) =>
            {
                if (_notificationChanged != null)
                {
                    string notiId = null;
                    object notiData = null;
                    Notification noti = default(Notification);
                    if (notiIdPtr != IntPtr.Zero)
                    {
                        notiId = Marshal.PtrToStringAnsi(notiIdPtr);
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
                            int status = Marshal.ReadInt32(data);
                            if (status == 1)
                            {
                                notiData = true;
                            }

                            else if (status == 0)
                            {
                                notiData = false;
                            }

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
                        case Notification.SatSetupEventList:
                            SatEventListDataStruct eventStruct = Marshal.PtrToStructure<SatEventListDataStruct>(data);
                            notiData = SatStructConversions.ConvertSatEventListStruct(eventStruct);
                            break;
                        case Notification.SatSendDtmf:
                            SatSendDtmfDataStruct dtmfStruct = Marshal.PtrToStructure<SatSendDtmfDataStruct>(data);
                            notiData = SatStructConversions.ConvertSatSendDtmfStruct(dtmfStruct);
                            break;
                        case Notification.SatEndProactiveSession:
                            notiData = (SatCommandType)Marshal.ReadInt32(data);
                            break;
                        case Notification.SatCallControlResult:
                            SatCallCtrlIndDataStruct dataStruct = Marshal.PtrToStructure<SatCallCtrlIndDataStruct>(data);
                            notiData = SatStructConversions.ConvertSatCallCtrlIndDataStruct(dataStruct);
                            break;
                        case Notification.SatMoSmControlResult:
                            SatMoSmsCtrlDataStruct moStruct = Marshal.PtrToStructure<SatMoSmsCtrlDataStruct>(data);
                            notiData = SatStructConversions.ConvertSatMoSmsCtrlDataStruct(moStruct);
                            break;
                        case Notification.SatSetupCall:
                            SatSetupCallDataStruct callDataStruct = Marshal.PtrToStructure<SatSetupCallDataStruct>(data);
                            notiData = SatStructConversions.ConvertSatSetupCallDataStruct(callDataStruct);
                            break;
                        case Notification.SatSendSs:
                            SatSendSsDataStruct ssStruct = Marshal.PtrToStructure<SatSendSsDataStruct>(data);
                            notiData = SatStructConversions.ConvertSatSendSsDataStruct(ssStruct);
                            break;
                        case Notification.SatSetupUssd:
                            SatSetupUssdDataStruct ussdStruct = Marshal.PtrToStructure<SatSetupUssdDataStruct>(data);
                            notiData = SatStructConversions.ConvertSatSetupUssdDataStruct(ussdStruct);
                            break;
                        case Notification.PhonebookStatus:
                            SimPhonebookStatusStruct statusStruct = Marshal.PtrToStructure<SimPhonebookStatusStruct>(data);
                            notiData = PhonebookStructConversions.ConvertSimPhonebookStatusStruct(statusStruct);
                            break;
                        case Notification.PhonebookContactChange:
                            PhonebookContactChangeInfoStruct contactStruct = Marshal.PtrToStructure<PhonebookContactChangeInfoStruct>(data);
                            notiData = PhonebookStructConversions.ConvertPhonebookContactChangeStruct(contactStruct);
                            break;
                        case Notification.NetworkRegistrationStatus:
                            NetworkRegistrationStatusStruct nwStruct = Marshal.PtrToStructure<NetworkRegistrationStatusStruct>(data);
                            notiData = NetworkStructConversions.ConvertNetworkRegistrationStruct(nwStruct);
                            break;
                        case Notification.NetworkCellInfo:
                            NetworkCellNotiStruct notiStruct = Marshal.PtrToStructure<NetworkCellNotiStruct>(data);
                            notiData = NetworkStructConversions.ConvertNetworkCellNotiStruct(notiStruct);
                            break;
                        case Notification.NetworkChange:
                            NetworkChangeNotiStruct changeStruct = Marshal.PtrToStructure<NetworkChangeNotiStruct>(data);
                            notiData = NetworkStructConversions.ConvertNetworkChangeStruct(changeStruct);
                            break;
                        case Notification.NetworkTimeInfo:
                            NetworkTimeNotiStruct timeStruct = Marshal.PtrToStructure<NetworkTimeNotiStruct>(data);
                            notiData = NetworkStructConversions.ConvertNetworkTimeNotiStruct(timeStruct);
                            break;
                        case Notification.NetworkIdentity:
                            NetworkIdentityNotiStruct idStruct = Marshal.PtrToStructure<NetworkIdentityNotiStruct>(data);
                            notiData = NetworkStructConversions.ConvertNetworkIdentityStruct(idStruct);
                            break;
                        case Notification.NetworkSignalStrength:
                            notiData = Marshal.ReadInt32(data);
                            break;
                        case Notification.NetworkEmergencyCallbackMode:
                            notiData = (NetworkEmergencyCallbackMode)Marshal.ReadInt32(data);
                            break;
                        case Notification.NetworkDefaultDataSubscription:
                            notiData = (NetworkDefaultDataSubscription)Marshal.ReadInt32(data);
                            break;
                        case Notification.NetworkDefaultSubscription:
                            notiData = (NetworkDefaultSubscription)Marshal.ReadInt32(data);
                            break;
                        case Notification.NetworkCellId:
                            notiData = Marshal.ReadInt32(data);
                            break;
                        case Notification.NetworkLac:
                            notiData = Marshal.ReadInt32(data);
                            break;
                        case Notification.NetworkTac:
                            notiData = Marshal.ReadInt32(data);
                            break;
                        case Notification.NetworkSystemId:
                            notiData = Marshal.ReadInt32(data);
                            break;
                        case Notification.NetworkNetworkId:
                            notiData = Marshal.ReadInt32(data);
                            break;
                        case Notification.NetworkBsId:
                            notiData = Marshal.ReadInt32(data);
                            break;
                        case Notification.NetworkBsLatitude:
                            notiData = Marshal.ReadInt32(data);
                            break;
                        case Notification.NetworkBsLongitude:
                            notiData = Marshal.ReadInt32(data);
                            break;
                        case Notification.NetworkVolteStatus:
                            NetworkVolteStatusStruct volteStruct = Marshal.PtrToStructure<NetworkVolteStatusStruct>(data);
                            notiData = NetworkStructConversions.ConvertNetworkVolteStruct(volteStruct);
                            break;
                        case Notification.NetworkEpdgStatus:
                            int epdgStatus = Marshal.ReadInt32(data);
                            if (epdgStatus == 1)
                            {
                                notiData = true;
                            }

                            else if (epdgStatus == 0)
                            {
                                notiData = false;
                            }

                            break;
                        case Notification.SsUssd:
                            SsUssdMsgInfoStruct ussdInfoStruct = Marshal.PtrToStructure<SsUssdMsgInfoStruct>(data);
                            notiData = SsStructConversions.ConvertSsMsgStruct(ussdInfoStruct);
                            break;
                        case Notification.SsReleaseComplete:
                            SsReleaseCompleteMsgStruct msgStruct = Marshal.PtrToStructure<SsReleaseCompleteMsgStruct>(data);
                            notiData = SsStructConversions.ConvertReleaseMsgStruct(msgStruct);
                            break;
                        case Notification.SsNotifyForwarding:
                            SsForwardResponseStruct responseStruct = Marshal.PtrToStructure<SsForwardResponseStruct>(data);
                            notiData = SsStructConversions.ConvertForwardRspStruct(responseStruct);
                            break;
                        case Notification.SsNotifyBarring:
                            SsBarringResponseStruct barringStruct = Marshal.PtrToStructure<SsBarringResponseStruct>(data);
                            notiData = SsStructConversions.ConvertBarringRspStruct(barringStruct);
                            break;
                        case Notification.SsNotifyWaiting:
                            SsWaitingResponseStruct waitingStruct = Marshal.PtrToStructure<SsWaitingResponseStruct>(data);
                            notiData = SsStructConversions.ConvertWaitingRspStruct(waitingStruct);
                            break;
                        case Notification.SsNotifyInfo:
                            SsInfoStruct ssInfoStruct = Marshal.PtrToStructure<SsInfoStruct>(data);
                            notiData = SsStructConversions.ConvertInfoStruct(ssInfoStruct);
                            break;
                        case Notification.SmsIncomingMsg:
                            SmsIncomingMsgNotiStruct smsNotiStruct = Marshal.PtrToStructure<SmsIncomingMsgNotiStruct>(data);
                            notiData = SmsStructConversions.ConvertSmsIncomingStruct(smsNotiStruct);
                            break;
                        case Notification.SmsIncomingCbMsg:
                            SmsIncomingCbMsgNotiStruct smsCbStruct = Marshal.PtrToStructure<SmsIncomingCbMsgNotiStruct>(data);
                            notiData = SmsStructConversions.ConvertSmsIncomingCbStruct(smsCbStruct);
                            break;
                        case Notification.SmsIncomingEtwsMsg:
                            SmsIncomingEtwsMsgNotiStruct etwsStruct = Marshal.PtrToStructure<SmsIncomingEtwsMsgNotiStruct>(data);
                            notiData = SmsStructConversions.ConvertSmsIncomingEtwsStruct(etwsStruct);
                            break;
                        case Notification.SmsMemoryStatus:
                            notiData = (SmsMemoryStatus)Marshal.ReadInt32(data);
                            break;
                        case Notification.SmsReady:
                            notiData = (SmsReadyStatus)Marshal.ReadInt32(data);
                            break;
                        case Notification.OemData:
                            OemDataStruct oemStruct = Marshal.PtrToStructure<OemDataStruct>(data);
                            notiData = OemStructConversions.ConvertOemStruct(oemStruct);
                            break;
                    }

                    _notificationChanged(null, new NotificationChangedEventArgs(noti, notiData));
                }
            };

            _notificationChangedCbList.Add(_notificationChangedCb);

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
            _notificationChangedCb = (IntPtr handle, IntPtr propPtr, IntPtr data, IntPtr userData) =>
            {
                if (_propertyChanged != null)
                {
                    string prop = null;
                    object propData = null;
                    Property propertyId = default(Property);
                    if (propPtr != IntPtr.Zero)
                    {
                        prop = Marshal.PtrToStringAnsi(propPtr);
                        foreach (Property p in Enum.GetValues(typeof(Property)))
                        {
                            if (prop == TapiUtility.ConvertPropToString(p))
                            {
                                propertyId = p;
                                break;
                            }
                        }
                    }

                    switch (propertyId)
                    {
                        case Property.ModemPower:
                            propData = (PhonePowerStatus)Marshal.ReadInt32(data);
                            break;
                        case Property.ModemDongleStatus:
                            int dongleStatus = Marshal.ReadInt32(data);
                            if (dongleStatus == 1)
                            {
                                propData = true;
                            }

                            else if (dongleStatus == 0)
                            {
                                propData = false;
                            }

                            break;
                        case Property.ModemDongleLogin:
                            int loginStatus = Marshal.ReadInt32(data);
                            if (loginStatus == 1)
                            {
                                propData = true;
                            }

                            else if (loginStatus == 0)
                            {
                                propData = false;
                            }

                            break;
                        case Property.SimCallForwardState:
                            int forwardState = Marshal.ReadInt32(data);
                            if (forwardState == 1)
                            {
                                propData = true;
                            }

                            else if (forwardState == 0)
                            {
                                propData = false;
                            }

                            break;
                        case Property.NetworkLac:
                            propData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Property.NetworkTac:
                            propData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Property.NetworkPlmn:
                            propData = Marshal.PtrToStringAnsi(data);
                            break;
                        case Property.NetworkCellId:
                            propData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Property.NetworkPhysicalCellId:
                            propData = (uint)Marshal.ReadInt32(data);
                            break;
                        case Property.NetworkServiceType:
                            propData = (NetworkServiceType)Marshal.ReadInt32(data);
                            break;
                        case Property.NetworkAct:
                            propData = (NetworkSystemType)Marshal.ReadInt32(data);
                            break;
                        case Property.NetworkPsType:
                            propData = (NetworkPsType)Marshal.ReadInt32(data);
                            break;
                        case Property.NetworkCircuitStatus:
                            propData = (NetworkServiceLevel)Marshal.ReadInt32(data);
                            break;
                        case Property.NetworkPacketStatus:
                            propData = (NetworkServiceLevel)Marshal.ReadInt32(data);
                            break;
                        case Property.NetworkRoamingStatus:
                            int roamingStatus = Marshal.ReadInt32(data);
                            if (roamingStatus == 1)
                            {
                                propData = true;
                            }

                            else if (roamingStatus == 0)
                            {
                                propData = false;
                            }

                            break;
                        case Property.NetworkNameOption:
                            propData = (NetworkNameDisplayCondition)Marshal.ReadInt32(data);
                            break;
                        case Property.NetworkName:
                            propData = Marshal.PtrToStringAnsi(data);
                            break;
                        case Property.NetworkSpnName:
                            propData = Marshal.PtrToStringAnsi(data);
                            break;
                        case Property.NetworkSignalDbm:
                            propData = Marshal.ReadInt32(data);
                            break;
                        case Property.NetworkSignalLevel:
                            propData = Marshal.ReadInt32(data);
                            break;
                        case Property.NetworkImsVoiceStatus:
                            int imsStatus = Marshal.ReadInt32(data);
                            if (imsStatus == 1)
                            {
                                propData = true;
                            }

                            else if (imsStatus == 0)
                            {
                                propData = false;
                            }

                            break;
                        case Property.NetworkVolteEnable:
                            propData = (VolteNetworkType)Marshal.ReadInt32(data);
                            break;
                        case Property.NetworkLteBand:
                            propData = (NetworkLteBandType)Marshal.ReadInt32(data);
                            break;
                    }

                    _propertyChanged(null, new PropertyChangedEventArgs(propertyId, propData));
                }
            };

            _notificationChangedCbList.Add(_notificationChangedCb);
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

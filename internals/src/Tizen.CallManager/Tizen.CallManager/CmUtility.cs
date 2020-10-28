/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Internals.Errors;

namespace Tizen.CallManager
{
    internal enum CmError
    {
        None = ErrorCode.None,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidParameter = ErrorCode.InvalidParameter,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
        NotRegistered = -0x00000000 | 0x01,
        AlreadyRegistered = -0x00000000 | 0x02,
        OperationFailed = -0x00000000 | 0x03,
        InvalidState = -0x00000000 | 0x04
    }

    internal static class CmUtility
    {
        internal const string LogTag = "Tizen.CallManager";

        internal static CallData GetCallData(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
            {
                return null;
            }

            CallData data = new CallData();
            int ret = Interop.CallManager.GetCallId(handle, out uint id);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get call ID from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.CallId = id;
            }

            ret = Interop.CallManager.GetCallDirection(handle, out CallDirection direction);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get call direction from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.CallDirection = direction;
            }

            ret = Interop.CallManager.GetCallNumber(handle, out string number);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get call number from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.Number = number;
            }

            ret = Interop.CallManager.GetCallingName(handle, out string name);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get calling name from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.Name = name;
            }

            ret = Interop.CallManager.GetCallType(handle, out CallType type);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get call type from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.CallType = type;
            }

            ret = Interop.CallManager.GetCallState(handle, out CallState state);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get call state from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.CallState = state;
            }

            ret = Interop.CallManager.GetCallMemberCount(handle, out int count);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get call member count from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.Count = count;
            }

            ret = Interop.CallManager.IsEmergencyCall(handle, out bool isEmergency);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to check if the call is emergency from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.IsEcc = isEmergency;
            }

            ret = Interop.CallManager.IsVoiceMailNumber(handle, out bool isVoiceMail);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to check if the number is voicemail number from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.IsVoiceMail = isVoiceMail;
            }

            ret = Interop.CallManager.GetCallDomain(handle, out CallDomain domain);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get call domain from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.CallDomain = domain;
            }

            ret = Interop.CallManager.GetPersonId(handle, out int personId);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get person ID from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.PersonIndex = personId;
            }

            ret = Interop.CallManager.GetStartTime(handle, out long startTime);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get start time from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.CallStartTime = startTime;
            }

            ret = Interop.CallManager.GetNameMode(handle, out CallNameMode nameMode);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get name mode from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.CallNameMode = nameMode;
            }

            ret = Interop.CallManager.GetSessionId(handle, out int sessionId);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get session ID from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.SessionIdIms = sessionId;
            }

            ret = Interop.CallManager.GetHdIconState(handle, out int isHdEnable);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get HD icon state from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.IsHdEnableIms = (isHdEnable == 1) ? true : false;
            }

            ret = Interop.CallManager.IsWiFiCalling(handle, out int isWiFiCalling);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to identify WiFi calling from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.IsWiFiCall = (isWiFiCalling == 1) ? true : false;
            }

            ret = Interop.CallManager.GetUpgradeDowngradeState(handle, out int isEnable);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get updagrade downgrade state from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.IsUpgradeDowngrade = (isEnable == 1) ? true : false;
            }

            ret = Interop.CallManager.IsRemoteOnHold(handle, out int isHold);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get remote on hold state from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.IsRemoteHold = (isHold == 1) ? true : false;
            }

            ret = Interop.CallManager.IsAddedToConference(handle, out int isAdded);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to check if the call is in conf state from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.IsAddedToConf = (isAdded == 1) ? true : false;
            }

            ret = Interop.CallManager.IsForwardedCall(handle, out bool isForwarded);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to check if the call is forwarded call from call data, Error: " + (CmError)ret);
            }

            else
            {
                data.IsForwardedCall = isForwarded;
            }

            return data;
        }

        internal static ConferenceCallData GetConfCallData(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
            {
                return null;
            }

            ConferenceCallData confData = new ConferenceCallData();
            int ret = Interop.CallManager.GetConfCallId(handle, out uint callId);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get conf call ID, Error: " + (CmError)ret);
            }

            else
            {
                confData.CallId = callId;
            }

            ret = Interop.CallManager.GetConfCallNumber(handle, out string number);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get conf call number, Error: " + (CmError)ret);
            }

            else
            {
                confData.Number = number;
            }

            ret = Interop.CallManager.GetConfCallPersonId(handle, out int personId);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get conf call person ID, Error: " + (CmError)ret);
            }

            else
            {
                confData.PersonIndex = personId;
            }

            ret = Interop.CallManager.GetConfCallNameMode(handle, out CallNameMode nameMode);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get conf call name mode, Error: " + (CmError)ret);
            }

            else
            {
                confData.NameMode = nameMode;
            }

            return confData;
        }

        internal static CallEventData GetCallEventData(CallEvent callEvent, IntPtr handle)
        {
            if (handle == IntPtr.Zero)
            {
                return null;
            }

            CallEventData eventData = new CallEventData();

            if (callEvent == CallEvent.Active)
            {
                int ret = Interop.CallManager.GetEventDataCallId(handle, out uint id);
                if (ret != (int)CmError.None)
                {
                    Log.Error(CmUtility.LogTag, "Failed to get event data call ID, Error: " + (CmError)ret);
                }

                else
                {
                    eventData.EventId = id;
                }

                ret = Interop.CallManager.GetSimSlot(handle, out MultiSimSlot simSlot);
                if (ret != (int)CmError.None)
                {
                    Log.Error(CmUtility.LogTag, "Failed to get event data sim slot, Error: " + (CmError)ret);
                }

                else
                {
                    eventData.Slot = simSlot;
                }

                ret = Interop.CallManager.GetIncomingCallData(handle, out IntPtr incoming);
                if (ret != (int)CmError.None)
                {
                    Log.Error(CmUtility.LogTag, "Failed to get incoming call data, Error: " + (CmError)ret);
                }

                else
                {
                    CallData incomingData = GetCallData(incoming);
                    if (incomingData != null)
                    {
                        ret = Interop.CallManager.FreeCallData(incoming);
                        if (ret != (int)CmError.None)
                        {
                            Log.Error(CmUtility.LogTag, "Failed to free incoming call data, Error: " + (CmError)ret);
                        }
                    }

                    eventData.Incoming = incomingData;
                }

                ret = Interop.CallManager.GetActiveCall(handle, out IntPtr active);
                if (ret != (int)CmError.None)
                {
                    Log.Error(CmUtility.LogTag, "Failed to get active call data, Error: " + (CmError)ret);
                }

                else
                {
                    CallData activeData = GetCallData(active);
                    if (activeData != null)
                    {
                        ret = Interop.CallManager.FreeCallData(active);
                        if (ret != (int)CmError.None)
                        {
                            Log.Error(CmUtility.LogTag, "Failed to free active call data, Error: " + (CmError)ret);
                        }
                    }

                    eventData.Active = activeData;
                }

                ret = Interop.CallManager.GetHeldCall(handle, out IntPtr held);
                if (ret != (int)CmError.None)
                {
                    Log.Error(CmUtility.LogTag, "Failed to get held call data, Error: " + (CmError)ret);
                }

                else
                {
                    CallData heldData = GetCallData(held);
                    if (heldData != null)
                    {
                        ret = Interop.CallManager.FreeCallData(held);
                        if (ret != (int)CmError.None)
                        {
                            Log.Error(CmUtility.LogTag, "Failed to free held call data, Error: " + (CmError)ret);
                        }
                    }

                    eventData.Held = heldData;
                }
            }

            else if (callEvent == CallEvent.Idle)
            {
                int ret = Interop.CallManager.GetEndCause(handle, out CallEndCause endCause);
                if (ret != (int)CmError.None)
                {
                    Log.Error(CmUtility.LogTag, "Failed to get end cause, Error: " + (CmError)ret);
                }

                else
                {
                    eventData.Cause = endCause;
                }
            }

            return eventData;
        }

        internal static void ThrowCmException(int exception)
        {
            _throwException(exception, false, "");
        }

        internal static void ThrowCmException(int exception, IntPtr handle)
        {
            _throwException(exception, (handle == IntPtr.Zero), "");
        }

        internal static void ThrowCmException(int exception, IntPtr handle, string message)
        {
            _throwException(exception, (handle == IntPtr.Zero), message);
        }

        private static void _throwException(int exception, bool isHandleNull, string message)
        {
            CmError _error = (CmError)exception;
            switch(_error)
            {
                case CmError.NotSupported:
                    throw new NotSupportedException("Unsupported feature: http://tizen.org/feature/network.telephony");
                case CmError.PermissionDenied:
                    throw new UnauthorizedAccessException("Permission denied: " + message);
                case CmError.OutOfMemory:
                    throw new OutOfMemoryException("System out of memory");
                case CmError.InvalidParameter:
                    if (isHandleNull)
                    {
                        throw new InvalidOperationException("Invalid instance (object may have been disposed or released)");
                    }

                    throw new ArgumentException("Invalid parameter");
                default:
                    throw new InvalidOperationException(_error.ToString());
            }
        }
    }
}

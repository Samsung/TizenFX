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
using System.Linq;

namespace Tizen.CallManager
{
    /// <summary>
    /// A class which manages call manager events, properties and functions.
    /// </summary>
    public class CmClientHandle
    {
        internal IntPtr _handle = IntPtr.Zero;
        private event EventHandler<CallStatusChangedEventArgs> _callStatusChanged;
        private event EventHandler<CallMuteStatusChangedEventArgs> _callMuteStatusChanged;
        private event EventHandler<CallEventEventArgs> _callEvent;
        private event EventHandler<DialStatusEventArgs> _dialStatusChanged;
        private event EventHandler<AudioStatusChangedEventArgs> _audioStateChanged;
        private event EventHandler<DtmfIndicationEventArgs> _dtmfIndication;
        private event EventHandler<EventArgs> _goForeGround;
        private event EventHandler<VoiceRecordStatusEventArgs> _voiceRecordStatusChanged;

        private Interop.CallManager.CallStatusChangedCallback _callStatusChangedCb;
        private Interop.CallManager.CallMuteStatusChangedCallback _callMuteStatusChangedCb;
        private Interop.CallManager.CallEventNotificationCallback _callEventCb;
        private Interop.CallManager.DialStatusChangedCallback _dialStatusChangedCb;
        private Interop.CallManager.AudioStateChangedCallback _audioStateChangedCb;
        private Interop.CallManager.DtmfIndicationChangedCallback _dtmfIndicationChangedCb;
        private Interop.CallManager.GoForegroundCallback _goForeGroundCb;
        private Interop.CallManager.VoiceRecordStatusChangedCallback _voiceRecordStatusChangedCb;

        internal CmClientHandle(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// This event is raised when call status changes.
        /// </summary>
        public event EventHandler<CallStatusChangedEventArgs> CallStatusChanged
        {
            add
            {
                if (_callStatusChanged == null)
                {
                    RegisterCallStatusChangedEvent();
                }

                _callStatusChanged += value;
            }

            remove
            {
                _callStatusChanged -= value;
                if (_callStatusChanged == null)
                {
                    UnregisterCallStatusChangedEvent();
                }
            }
        }

        /// <summary>
        /// This event is raised when the mute status changes.
        /// </summary>
        public event EventHandler<CallMuteStatusChangedEventArgs> CallMuteStatusChanged
        {
            add
            {
                if (_callMuteStatusChanged == null)
                {
                    RegisterCallMuteStatusChangedEvent();
                }

                _callMuteStatusChanged += value;
            }

            remove
            {
                _callMuteStatusChanged -= value;
                if (_callMuteStatusChanged == null)
                {
                    UnregisterCallMuteStatusChangedEvent();
                }
            }
        }

        /// <summary>
        /// This event is raised when call events change.
        /// </summary>
        public event EventHandler<CallEventEventArgs> CallEvent
        {
            add
            {
                if (_callEvent == null)
                {
                    RegisterCallEventNotification();
                }

                _callEvent += value;
            }

            remove
            {
                _callEvent -= value;
                if (_callEvent == null)
                {
                    UnregisterCallEventNotification();
                }
            }
        }

        /// <summary>
        /// This event is raised when dial status changes.
        /// </summary>
        public event EventHandler<DialStatusEventArgs> DialStatusChanged
        {
            add
            {
                if (_dialStatusChanged == null)
                {
                    RegisterDialStatusEvent();
                }

                _dialStatusChanged += value;
            }

            remove
            {
                _dialStatusChanged -= value;
                if (_dialStatusChanged == null)
                {
                    UnregisterDialStatusEvent();
                }
            }
        }

        /// <summary>
        /// This event is raised when audio status changes.
        /// </summary>
        public event EventHandler<AudioStatusChangedEventArgs> AudioStateChanged
        {
            add
            {
                if (_audioStateChanged == null)
                {
                    RegisterAudioStateChangedEvent();
                }

                _audioStateChanged += value;
            }

            remove
            {
                _audioStateChanged -= value;
                if (_audioStateChanged == null)
                {
                    UnregisterAudioStateChangedEvent();
                }
            }
        }

        /// <summary>
        /// This event is raised during DTMF indication.
        /// </summary>
        public event EventHandler<DtmfIndicationEventArgs> DtmfIndication
        {
            add
            {
                if (_dtmfIndication == null)
                {
                    RegisterDtmfIndicationEvent();
                }

                _dtmfIndication += value;
            }

            remove
            {
                _dtmfIndication -= value;
                if (_dtmfIndication == null)
                {
                    UnregisterDtmfIndicationEvent();
                }
            }
        }

        /// <summary>
        /// This event is raised when call comes to foreground.
        /// </summary>
        public event EventHandler<EventArgs> GoForeground
        {
            add
            {
                if (_goForeGround == null)
                {
                    RegisterGoForegroundEvent();
                }

                _goForeGround += value;
            }

            remove
            {
                _goForeGround -= value;
                if (_goForeGround == null)
                {
                    UnregisterGoForegroundEvent();
                }
            }
        }

        /// <summary>
        /// This event is raised when voice record status is changed.
        /// </summary>
        public event EventHandler<VoiceRecordStatusEventArgs> VoiceRecordStatusChanged
        {
            add
            {
                if (_voiceRecordStatusChanged == null)
                {
                    RegisterVoiceRecordStatusEvent();
                }

                _voiceRecordStatusChanged += value;
            }

            remove
            {
                _voiceRecordStatusChanged -= value;
                if (_voiceRecordStatusChanged == null)
                {
                    UnregisterVoiceRecordStatusEvent();
                }
            }
        }

        private void RegisterCallStatusChangedEvent()
        {
            _callStatusChangedCb = (CallStatus status, IntPtr number, IntPtr userData) =>
            {
                _callStatusChanged?.Invoke(null, new CallStatusChangedEventArgs(status, Marshal.PtrToStringAnsi(number)));
            };
            int ret = Interop.CallManager.SetCallStatusCallback(_handle, _callStatusChangedCb, IntPtr.Zero);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to set call status changed callback, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        private void UnregisterCallStatusChangedEvent()
        {
            int ret = Interop.CallManager.UnsetCallstatusCallback(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to unset call status changed callback, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        private void RegisterCallMuteStatusChangedEvent()
        {
            _callMuteStatusChangedCb = (CallMuteStatus muteStatus, IntPtr userData) =>
            {
                _callMuteStatusChanged?.Invoke(null, new CallMuteStatusChangedEventArgs(muteStatus));
            };
            int ret = Interop.CallManager.SetCallMuteStatusCallback(_handle, _callMuteStatusChangedCb, IntPtr.Zero);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to set call mute status changed callback, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        private void UnregisterCallMuteStatusChangedEvent()
        {
            int ret = Interop.CallManager.UnsetCallMuteStatusCallback(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to unset call mute status changed callback, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        private void RegisterCallEventNotification()
        {
            _callEventCb = (CallEvent callEvent, IntPtr eventData, IntPtr userData) =>
            {
                _callEvent?.Invoke(null, new CallEventEventArgs(callEvent, CmUtility.GetCallEventData(callEvent, eventData)));
            };
            int ret = Interop.CallManager.SetCallEventCb(_handle, _callEventCb, IntPtr.Zero);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to set call event notification callback, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        private void UnregisterCallEventNotification()
        {
            int ret = Interop.CallManager.UnsetCallEventCb(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to unset call event notification callback, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        private void RegisterDialStatusEvent()
        {
            _dialStatusChangedCb = (DialStatus status, IntPtr userData) =>
            {
                _dialStatusChanged?.Invoke(null, new DialStatusEventArgs(status));
            };
            int ret = Interop.CallManager.SetDialStatusCb(_handle, _dialStatusChangedCb, IntPtr.Zero);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to set dial status changed callback, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        private void UnregisterDialStatusEvent()
        {
            int ret = Interop.CallManager.UnsetDialStatusCb(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to unset dial status changed callback, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        private void RegisterAudioStateChangedEvent()
        {
            _audioStateChangedCb = (AudioState state, IntPtr userData) =>
            {
                _audioStateChanged?.Invoke(null, new AudioStatusChangedEventArgs(state));
            };
            int ret = Interop.CallManager.SetAudioStateChangedCb(_handle, _audioStateChangedCb, IntPtr.Zero);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to set audio state changed callback, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        private void UnregisterAudioStateChangedEvent()
        {
            int ret = Interop.CallManager.UnsetAudioStateChangedCb(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to unset audio state changed callback, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        private void RegisterDtmfIndicationEvent()
        {
            _dtmfIndicationChangedCb = (DtmfIndication indiType, string number, IntPtr userData) =>
            {
                _dtmfIndication?.Invoke(null, new DtmfIndicationEventArgs(indiType, number));
            };
            int ret = Interop.CallManager.SetDtmfIndicationCb(_handle, _dtmfIndicationChangedCb, IntPtr.Zero);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to set DTMF indication changed callback, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        private void UnregisterDtmfIndicationEvent()
        {
            int ret = Interop.CallManager.UnsetDtmfIndicationCb(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to unset DTMF indication changed callback, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        private void RegisterGoForegroundEvent()
        {
            _goForeGroundCb = (IntPtr userData) =>
            {
                _goForeGround?.Invoke(null, EventArgs.Empty);
            };
            int ret = Interop.CallManager.SetForegroundCb(_handle, _goForeGroundCb, IntPtr.Zero);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to set go foreground callback, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        private void UnregisterGoForegroundEvent()
        {
            int ret = Interop.CallManager.UnsetForegroundCb(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to unset go foreground callback, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        private void RegisterVoiceRecordStatusEvent()
        {
            _voiceRecordStatusChangedCb = (VrStatus vrStatus, VrStatusExtraType extraType, IntPtr userData) =>
            {
                _voiceRecordStatusChanged?.Invoke(null, new VoiceRecordStatusEventArgs(vrStatus, extraType));
            };
            int ret = Interop.CallManager.SetVoiceRecordStatusCb(_handle, _voiceRecordStatusChangedCb, IntPtr.Zero);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to set voice record status changed callback, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        private void UnregisterVoiceRecordStatusEvent()
        {
            int ret = Interop.CallManager.UnsetVoiceRecordStatusCb(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to unset voice record status changed callback, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Gets the status of the current call.
        /// </summary>
        public CallStatus CallStatus
        {
            get
            {
                int ret = Interop.CallManager.GetStatus(_handle, out CallStatus status);
                if (ret != (int)CmError.None)
                {
                    Log.Error(CmUtility.LogTag, "Failed to get call status, Error: " + (CmError)ret);
                    return default(CallStatus);
                }

                return status;
            }
        }

        /// <summary>
        /// Gets the mute status.
        /// </summary>
        public CallMuteStatus CallMuteStatus
        {
            get
            {
                int ret = Interop.CallManager.GetMuteStatus(_handle, out CallMuteStatus status);
                if (ret != (int)CmError.None)
                {
                    Log.Error(CmUtility.LogTag, "Failed to get call mute status, Error: " + (CmError)ret);
                    return default(CallMuteStatus);
                }

                return status;
            }
        }

        /// <summary>
        /// Gets the audio state.
        /// </summary>
        public AudioState AudioState
        {
            get
            {
                int ret = Interop.CallManager.GetAudioState(_handle, out AudioState state);
                if (ret != (int)CmError.None)
                {
                    Log.Error(CmUtility.LogTag, "Failed to get audio state, Error: " + (CmError)ret);
                    return default(AudioState);
                }

                return state;
            }
        }

        /// <summary>
        /// Gets the list of call data.
        /// </summary>
        public IEnumerable<CallData> AllCalls
        {
            get
            {
                int ret = Interop.CallManager.GetAllCallList(_handle, out IntPtr list);
                if (ret != (int)CmError.None)
                {
                    Log.Error(CmUtility.LogTag, "Failed to get all call list, Error: " + (CmError)ret);
                    return null;
                }

                int length = Interop.GsList.GetLength(list);
                if (length == 0)
                {
                    Log.Debug(CmUtility.LogTag, "Call list is empty");
                    return Enumerable.Empty<CallData>();
                }

                List<CallData> callList = new List<CallData>();
                IntPtr callData = IntPtr.Zero;
                for (int index = 0; index < length; index++)
                {
                    callData = Interop.GsList.GetDataByIndex(list, index);
                    if (callData != IntPtr.Zero)
                    {
                        callList.Add(CmUtility.GetCallData(callData));
                    }
                }

                return callList;
            }
        }

        /// <summary>
        /// Gets the list of conference call data.
        /// </summary>
        public IEnumerable<ConferenceCallData> AllConferenceCalls
        {
            get
            {
                int ret = Interop.CallManager.GetConferenceCallList(_handle, out IntPtr list);
                if (ret != (int)CmError.None)
                {
                    Log.Error(CmUtility.LogTag, "Failed to get conference call list, Error: " + (CmError)ret);
                    return null;
                }

                int length = Interop.GsList.GetLength(list);
                if (length == 0)
                {
                    Log.Debug(CmUtility.LogTag, "Conf call list is empty");
                    return Enumerable.Empty<ConferenceCallData>();
                }
                List<ConferenceCallData> confList = new List<ConferenceCallData>();
                IntPtr confData = IntPtr.Zero;
                for (int index = 0; index < length; index++)
                {
                    confData = Interop.GsList.GetDataByIndex(list, index);
                    if (confData != IntPtr.Zero)
                    {
                        confList.Add(CmUtility.GetConfCallData(confData));
                    }
                }

                return confList;
            }
        }

        /// <summary>
        /// Rejects the incoming call.
        /// </summary>
        /// <privlevel>partner</privlevel>
        /// <privilege>http://developer.samsung.com/tizen/privilege/call.reject</privilege>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void RejectCall()
        {
            int ret = Interop.CallManager.RejectCall(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to reject call, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle, "http://developer.samsung.com/tizen/privilege/call.reject");
            }
        }

        /// <summary>
        /// Starts incoming call alert ringtone.
        /// </summary>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void StartAlert()
        {
            int ret = Interop.CallManager.StartAlert(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to start incoming call alert, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Stops incoming call alert ringtone.
        /// </summary>
        /// <privlevel>partner</privlevel>
        /// <privilege>http://developer.samsung.com/tizen/privilege/call.reject</privilege>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void StopAlert()
        {
            int ret = Interop.CallManager.StopAlert(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to stop incoming call alert, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle, "http://developer.samsung.com/tizen/privilege/call.reject");
            }
        }

        /// <summary>
        /// Enables call recovery.
        /// </summary>
        /// <param name="appId">App ID to be recovered.</param>
        /// <exception cref="ArgumentNullException">Thrown appId is passed as null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void EnableRecovery(string appId)
        {
            if (appId == null)
            {
                throw new ArgumentNullException("App ID is null");
            }

            int ret = Interop.CallManager.EnableRecovery(_handle, appId);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to enable recovery, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Dials a call.
        /// </summary>
        /// <param name="number">Calling number to be dialed.</param>
        /// <param name="type">Type of the call to be dialed.</param>
        /// <param name="slot">Multi sim slot type in which the call is dialed.</param>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown number is passed as null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void DialCall(string number, CallType type, MultiSimSlot slot)
        {
            if (number == null)
            {
                throw new ArgumentNullException("Calling number is null");
            }

            int ret = Interop.CallManager.DialCall(_handle, number, type, slot);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to dial call, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Swaps the calls.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void SwapCall()
        {
            int ret = Interop.CallManager.SwapCall(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to swap call, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Joins a call with another.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void JoinCall()
        {
            int ret = Interop.CallManager.JoinCall(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to join call, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Splits a call.
        /// </summary>
        /// <param name="id">Call id to be splitted.</param>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void SplitCall(uint id)
        {
            int ret = Interop.CallManager.SplitCall(_handle, id);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to split call, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Transfers a call.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void TransferCall()
        {
            int ret = Interop.CallManager.TransferCall(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to transfer call, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Accepts MT ViLTE call as VoLTE.
        /// </summary>
        /// <param name="answerType">Call answer type.</param>
        /// <param name="type">Call type.</param>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void AnswerCallEx(CallAnswerType answerType, CallType type)
        {
            int ret = Interop.CallManager.AnswerCallEx(_handle, answerType, type);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to answer call, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Answers an incoming call.
        /// </summary>
        /// <param name="answerType">Call answer type.</param>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void AnswerCall(CallAnswerType answerType)
        {
            int ret = Interop.CallManager.AnswerCall(_handle, answerType);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to answer call, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Upgrades a call.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void UpgradeCall()
        {
            int ret = Interop.CallManager.UpgradeCall(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to upgrade call, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Downgrades a call.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void DowngradeCall()
        {
            int ret = Interop.CallManager.DowngradeCall(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to downgrade call, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Confirms upgrade call request.
        /// </summary>
        /// <param name="response">Upgrade response type.</param>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void ConfirmUpgradeCall(CallUpgradeResponseType response)
        {
            int ret = Interop.CallManager.ConfirmUpgradeCall(_handle, response);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to confirm upgrade call, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Sets the speaker on/off.
        /// </summary>
        /// <param name="status">Status of the speaker to be set.</param>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void ManageSpeaker(FeatureStatus status)
        {
            int ret = -1;
            if (status == FeatureStatus.Off)
            {
                ret = Interop.CallManager.SpeakerOff(_handle);
            }

            else if (status == FeatureStatus.On)
            {
                ret = Interop.CallManager.SpeakerOn(_handle);
            }

            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to manage speaker, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Sets the bluetooth feature on/off.
        /// </summary>
        /// <param name="status">Status of the bluetooth to be set.</param>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void ManageBluetooth(FeatureStatus status)
        {
            int ret = -1;
            if (status == FeatureStatus.Off)
            {
                ret = Interop.CallManager.BluetoothOff(_handle);
            }

            else if (status == FeatureStatus.On)
            {
                ret = Interop.CallManager.BluetoothOn(_handle);
            }

            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to manage bluetooth, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Sets extra volume if needed.
        /// </summary>
        /// <param name="isExtraVolume">Boolean value to indicate if the call is set to have extra volume.</param>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void SetExtraVolume(bool isExtraVolume)
        {
            int ret = Interop.CallManager.SetExtraVolume(_handle, isExtraVolume);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to set extra volume, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Sets the noise reduction feature during call.
        /// </summary>
        /// <param name="isNoiceReduction">Boolean value to indicate whether the call needs noise reduction.</param>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void SetNoiseReduction(bool isNoiceReduction)
        {
            int ret = Interop.CallManager.SetNoiseReduction(_handle, isNoiceReduction);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to set noise reduction, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Sets the mute state of the call.
        /// </summary>
        /// <param name="isMuteState">Mute state to be set.</param>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void SetMuteState(bool isMuteState)
        {
            int ret = Interop.CallManager.SetMuteState(_handle, isMuteState);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to set mute state, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Starts sending signal through DTMF digit.
        /// </summary>
        /// <param name="dtmfDigit">DTMF digit to be pressed on the phone.</param>
        /// <exception cref="ArgumentException">Thrown when method failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void StartDtmf(byte dtmfDigit)
        {
            int ret = Interop.CallManager.StartDtmf(_handle, dtmfDigit);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to start DTMF, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Stops sending DTMF signal.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void StopDtmf()
        {
            int ret = Interop.CallManager.StopDtmf(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to stop DTMF, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Sends signal through DTMF digits.
        /// </summary>
        /// <param name="dtmfDigits">DTMF digits.</param>
        /// <exception cref="ArgumentNullException">Thrown when dtmfDigits is passed as null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void BurstDtmf(string dtmfDigits)
        {
            if (dtmfDigits == null)
            {
                throw new ArgumentNullException("DTMF digits is null");
            }

            int ret = Interop.CallManager.BurstDtmf(_handle, dtmfDigits);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to burst DTMF, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Sends DTMF response.
        /// </summary>
        /// <param name="response">DTMF response type.</param>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void SendDtmfResponse(DtmfResponseType response)
        {
            int ret = Interop.CallManager.SendDtmfResponse(_handle, response);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to send DTMF response, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Activates call manager UI.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void ActivateUi()
        {
            int ret = Interop.CallManager.ActivateUi(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to activate UI, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Sets device LCD time out.
        /// </summary>
        /// <param name="timeout">LCD timeout to be set.</param>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void SetLcdTimeout(LcdTimeOut timeout)
        {
            int ret = Interop.CallManager.SetLcdTimeOut(_handle, timeout);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to set LCD timeout, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Starts voice recording.
        /// </summary>
        /// <param name="number">Call number.</param>
        /// <exception cref="ArgumentNullException">Thrown when number is passed as null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void StartVoiceRecord(string number)
        {
            if (number == null)
            {
                throw new ArgumentNullException("Call number is null");
            }

            int ret = Interop.CallManager.StartVoiceRecord(_handle, number);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to start voice record, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Stops voice record.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void StopVoiceRecord()
        {
            int ret = Interop.CallManager.StopVoiceRecord(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to stop voice record, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }
        }

        /// <summary>
        /// Gets all current call data.
        /// </summary>
        /// <param name="incoming">Incoming calldata instance to be filled.</param>
        /// <param name="active">Active calldata instance to be filled.</param>
        /// <param name="held">Held calldata instance to be filled.</param>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void GetAllCallData(out CallData incoming, out CallData active, out CallData held)
        {
            int ret = Interop.CallManager.GetAllCallData(_handle, out IntPtr incomingCall, out IntPtr activeCall, out IntPtr heldCall);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to get all call data, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle);
            }

            incoming = CmUtility.GetCallData(incomingCall);
            active = CmUtility.GetCallData(activeCall);
            held = CmUtility.GetCallData(heldCall);
        }

        /// <summary>
        /// Holds the active call.
        /// </summary>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://developer.samsung.com/tizen/privilege/call.admin</privilege>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void HoldCall()
        {
            int ret = Interop.CallManager.HoldCall(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to hold call, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle, "http://developer.samsung.com/tizen/privilege/call.admin");
            }
        }

        /// <summary>
        /// Unholds the active call.
        /// </summary>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://developer.samsung.com/tizen/privilege/call.admin</privilege>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void UnholdCall()
        {
            int ret = Interop.CallManager.UnholdCall(_handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to unhold call, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle, "http://developer.samsung.com/tizen/privilege/call.admin");
            }
        }

        /// <summary>
        /// Ends ongoing call.
        /// </summary>
        /// <param name="id">ID of the call which is to be ended.</param>
        /// <param name="type">Call release type.</param>
        /// <privlevel>platform</privlevel>
        /// <privilege>http://developer.samsung.com/tizen/privilege/call.admin</privilege>
        /// <exception cref="UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void EndCall(uint id, CallReleaseType type)
        {
            int ret = Interop.CallManager.EndCall(_handle, id, type);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to end call, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, _handle, "http://developer.samsung.com/tizen/privilege/call.admin");
            }
        }
    }
}

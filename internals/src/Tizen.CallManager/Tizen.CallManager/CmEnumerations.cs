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

namespace Tizen.CallManager
{
    /// <summary>
    /// Enumeration for Call status.
    /// </summary>
    public enum CallStatus
    {
        /// <summary>
        /// Call is in idle state.
        /// </summary>
        Idle,
        /// <summary>
        /// A new call arrived and is ringing or waiting.
        /// </summary>
        Ringing,
        /// <summary>
        /// At least one call exist that is in dialing, alerting, active, on hold state.
        /// </summary>
        OffHook,
        /// <summary>
        /// Max state.
        /// </summary>
        Max
    }

    /// <summary>
    /// Enumeration for Mute status.
    /// </summary>
    public enum CallMuteStatus
    {
        /// <summary>
        /// Mute state is off.
        /// </summary>
        Off,
        /// <summary>
        /// Mute state is on.
        /// </summary>
        On,
        /// <summary>
        /// Max status.
        /// </summary>
        Max
    }

    /// <summary>
    /// Enumeration for call dial status.
    /// </summary>
    public enum DialStatus
    {
        /// <summary>
        /// Dial status is success.
        /// </summary>
        Success = 0,
        /// <summary>
        /// Dial status is cancel.
        /// </summary>
        Cancel,
        /// <summary>
        /// Dial status is fail.
        /// </summary>
        Fail,
        /// <summary>
        /// Dial status is fail SS.
        /// </summary>
        FailSS,
        /// <summary>
        /// Dial status is fail FDN.
        /// </summary>
        FailFdn,
        /// <summary>
        /// Dial status is fail flight mode.
        /// </summary>
        FailFlightMode
    }

    /// <summary>
    /// Enumeration for DTMF indication type.
    /// </summary>
    public enum DtmfIndication
    {
        /// <summary>
        /// DTMF indication type is idle.
        /// </summary>
        Idle = 0,
        /// <summary>
        /// DTMF indication type is progressing.
        /// </summary>
        Progressing,
        /// <summary>
        /// DTMF indication type is wait.
        /// </summary>
        Wait
    }

    /// <summary>
    /// Enumeration for audio state type.
    /// </summary>
    public enum AudioState
    {
        /// <summary>
        /// None.
        /// </summary>
        None,
        /// <summary>
        /// System LoudSpeaker path.
        /// </summary>
        Speaker,
        /// <summary>
        /// System Receiver.
        /// </summary>
        Receiver,
        /// <summary>
        /// Earjack path.
        /// </summary>
        EarJack,
        /// <summary>
        /// System BT Headset path.
        /// </summary>
        BTHeadset
    }

    /// <summary>
    /// Enumeration for video record status.
    /// </summary>
    public enum VrStatus
    {
        /// <summary>
        /// Video recording is started.
        /// </summary>
        Started = 0,
        /// <summary>
        /// Video recording is stopped.
        /// </summary>
        Stopped
    }

    /// <summary>
    /// Enumeration for Video record status extra type.
    /// </summary>
    public enum VrStatusExtraType
    {
        /// <summary>
        /// Start.
        /// </summary>
        Start = 0x00,
        /// <summary>
        /// Normal recording.
        /// </summary>
        StartNormal,
        /// <summary>
        /// Answering message.
        /// </summary>
        StartAnswerMessage,
        /// <summary>
        /// Start max.
        /// </summary>
        StartMax = 0x0f,
        /// <summary>
        /// Stop.
        /// </summary>
        Stop = 0x10,
        /// <summary>
        /// Stop by normal.
        /// </summary>
        StopByNormal,
        /// <summary>
        /// Stop by max size.
        /// </summary>
        StopByMaxSize,
        /// <summary>
        /// Stop by no free space.
        /// </summary>
        StopByNoFreeSpace,
        /// <summary>
        /// Stop by time limit.
        /// </summary>
        StopByTimeLimit,
        /// <summary>
        /// Error.
        /// </summary>
        StopError,
        /// <summary>
        /// Stop by max.
        /// </summary>
        StopMax = 0x1f
    }

    /// <summary>
    /// Enumeration for call type.
    /// </summary>
    public enum CallType
    {
        /// <summary>
        /// Voice call type.
        /// </summary>
        Voice,
        /// <summary>
        /// Video call type.
        /// </summary>
        Video,
        /// <summary>
        /// Invalid call type.
        /// </summary>
        Invalid
    }

    /// <summary>
    /// Enumeration for sim slot type.
    /// </summary>
    public enum MultiSimSlot
    {
        /// <summary>
        /// Sim slot 1.
        /// </summary>
        Slot1,
        /// <summary>
        /// Sim slot 2.
        /// </summary>
        Slot2,
        /// <summary>
        /// Follow system configuration.
        /// </summary>
        Default
    }

    /// <summary>
    /// Enumeration for call answer types for accepting the incoming call.
    /// </summary>
    public enum CallAnswerType
    {
        /// <summary>
        /// Only single call exist, Accept the Incoming call.
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Put the active call on hold and accepts the call.
        /// </summary>
        HoldActiveAndAccept,
        /// <summary>
        /// Releases the active call and accept the call.
        /// </summary>
        ReleaseActiveAndAccept,
        /// <summary>
        /// Releases the held call and accept the call.
        /// </summary>
        ReleaseHoldAndAccept,
        /// <summary>
        /// Releases all calls and accept the call.
        /// </summary>
        ReleaseAllAndAccept
    }

    /// <summary>
    /// Enumeration for call upgrade response type while receiving upgrade request.
    /// </summary>
    public enum CallUpgradeResponseType
    {
        /// <summary>
        /// Accept incoming upgrade request.
        /// </summary>
        Accept,
        /// <summary>
        /// Reject Incoming upgrade request.
        /// </summary>
        Reject
    }

    /// <summary>
    /// Enumeration for feature(speaker/bluetooth) status.
    /// </summary>
    public enum FeatureStatus
    {
        /// <summary>
        /// On.
        /// </summary>
        On,
        /// <summary>
        /// Off.
        /// </summary>
        Off
    }

    /// <summary>
    /// Enumeration for DTMF response type.
    /// </summary>
    public enum DtmfResponseType
    {
        /// <summary>
        /// Cancel.
        /// </summary>
        Cancel = 0,
        /// <summary>
        /// Continue.
        /// </summary>
        Continue
    }

    /// <summary>
    /// Enumeration for LCD time out.
    /// </summary>
    public enum LcdTimeOut
    {
        /// <summary>
        /// Set.
        /// </summary>
        Set = 1,
        /// <summary>
        /// Unset.
        /// </summary>
        Unset,
        /// <summary>
        /// After lock-screen comes in Connected state LCD goes to OFF in 5 secs.
        /// </summary>
        LockscreenSet,
        /// <summary>
        /// When Keypad is ON, LCD goes to DIM in 3 secs then goes to OFF in 5 secs.
        /// </summary>
        KeypadSet,
        /// <summary>
        /// Default.
        /// </summary>
        Default
    }

    /// <summary>
    /// Enumeration for contact name mode.
    /// </summary>
    public enum CallNameMode
    {
        /// <summary>
        /// None.
        /// </summary>
        None,
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown,
        /// <summary>
        /// Private.
        /// </summary>
        Private,
        /// <summary>
        /// Payphone.
        /// </summary>
        PayPhone
    }

    /// <summary>
    /// Enumeration for LCD control state.
    /// </summary>
    public enum LcdControlState
    {
        /// <summary>
        /// Off.
        /// </summary>
        Off = 1,
        /// <summary>
        /// On.
        /// </summary>
        On,
        /// <summary>
        /// On lock.
        /// </summary>
        OnLock,
        /// <summary>
        /// On unlock.
        /// </summary>
        OnUnlock,
        /// <summary>
        /// Off sleep lock.
        /// </summary>
        OffSleepLock,
        /// <summary>
        /// Off sleep unlock.
        /// </summary>
        OffSleepUnlock
    }

    /// <summary>
    /// Enumeration for call event type.
    /// </summary>
    public enum CallEvent
    {
        /// <summary>
        /// Call Idle event.
        /// </summary>
        Idle = 0,
        /// <summary>
        /// Call Dialling event.
        /// </summary>
        Dialing,
        /// <summary>
        /// Call Active event.
        /// </summary>
        Active,
        /// <summary>
        /// Call Held event.
        /// </summary>
        Held,
        /// <summary>
        /// Call Alert event.
        /// </summary>
        Alert,
        /// <summary>
        /// Call Incoming event.
        /// </summary>
        Incoming,
        /// <summary>
        /// Call Waiting event.
        /// </summary>
        Waiting,
        /// <summary>
        /// Call Join event.
        /// </summary>
        Join,
        /// <summary>
        /// Call Split event.
        /// </summary>
        Split,
        /// <summary>
        /// Call Swapped event.
        /// </summary>
        Swapped,
        /// <summary>
        /// Call Retrieved event.
        /// </summary>
        Retrieved,
        /// <summary>
        /// Sat call control event.
        /// </summary>
        SatCallControl,
        /// <summary>
        /// Call upgrade request event.
        /// </summary>
        UpgradeRequest,
        /// <summary>
        /// Call downgraded event.
        /// </summary>
        Downgraded,
        /// <summary>
        /// Call upgrade success event.
        /// </summary>
        UpgradeSuccess,
        /// <summary>
        /// Call upgrade failure event.
        /// </summary>
        UpgradeFailure,
        /// <summary>
        /// Call downgrade success event.
        /// </summary>
        DowngradeSuccess,
        /// <summary>
        /// Call downgrade failure event.
        /// </summary>
        DowngradeFailure,
        /// <summary>
        /// Call confirm upgrade success event.
        /// </summary>
        ConfirmUpgradeSuccess,
        /// <summary>
        /// Call confirm upgrade failure event.
        /// </summary>
        ConfirmUpgradeFailure,
        /// <summary>
        /// VoWiFi ~ LTE hand-over update event.
        /// </summary>
        VoWiFiLteHandoverUpdate
    }

    /// <summary>
    /// Enumeration for call direction
    /// </summary>
    public enum CallDirection
    {
        /// <summary>
        /// MO call.
        /// </summary>
        MO,
        /// <summary>
        /// MT call.
        /// </summary>
        MT
    }

    /// <summary>
    /// Enumeration for the call state.
    /// </summary>
    public enum CallState
    {
        /// <summary>
        /// Call is in idle state.
        /// </summary>
        Idle,
        /// <summary>
        /// Call is in connected and conversation state.
        /// </summary>
        Active,
        /// <summary>
        /// Call is in held state.
        /// </summary>
        Held,
        /// <summary>
        /// Call is in dialing state.
        /// </summary>
        Dialing,
        /// <summary>
        /// Call is in alerting state.
        /// </summary>
        Alert,
        /// <summary>
        /// Call is in incoming state.
        /// </summary>
        Incoming,
        /// <summary>
        /// Call is in answered state, and waiting for connected indication event.
        /// </summary>
        Waiting
    }

    /// <summary>
    /// Enumeration for call domain.
    /// </summary>
    public enum CallDomain
    {
        /// <summary>
        /// CS call domain.
        /// </summary>
        Cs,
        /// <summary>
        /// PS call domain.
        /// </summary>
        Ps,
        /// <summary>
        /// Wearable call through BT handsfree profile.
        /// </summary>
        Hfp
    }

    /// <summary>
    /// Enumeration for call end cause type.
    /// </summary>
    public enum CallEndCause
    {
        /// <summary>
        /// Call ended.
        /// </summary>
        Ended,
        /// <summary>
        /// Call disconnected.
        /// </summary>
        Disconnected,
        /// <summary>
        /// Service not allowed.
        /// </summary>
        ServiceNotAllowed,
        /// <summary>
        /// Call barred.
        /// </summary>
        Barred,
        /// <summary>
        /// No service.
        /// </summary>
        NoService,
        /// <summary>
        /// Network busy.
        /// </summary>
        NwBusy,
        /// <summary>
        /// Network failed.
        /// </summary>
        NwFailed,
        /// <summary>
        /// No answer from other party.
        /// </summary>
        NoAnswer,
        /// <summary>
        /// No credit available.
        /// </summary>
        NoCredit,
        /// <summary>
        /// Call rejected.
        /// </summary>
        Rejected,
        /// <summary>
        /// User busy.
        /// </summary>
        UserBusy,
        /// <summary>
        /// Wrong group.
        /// </summary>
        WrongGroup,
        /// <summary>
        /// Call not allowed.
        /// </summary>
        NotAllowed,
        /// <summary>
        /// Tapi error.
        /// </summary>
        TapiError,
        /// <summary>
        /// Call failed.
        /// </summary>
        Failed,
        /// <summary>
        /// User not responding.
        /// </summary>
        NoUserResponding,
        /// <summary>
        /// User alerting no answer.
        /// </summary>
        UserAlertingNoAnswer,
        /// <summary>
        /// Circuit Channel Unavailable,Network is out of Order,Switching equipment congestion,Temporary Failure.
        /// </summary>
        ServiceTempUnavailable,
        /// <summary>
        /// Called Party Rejects the Call.
        /// </summary>
        UserUnavailable,
        /// <summary>
        /// Entered number is invalid or incomplete.
        /// </summary>
        InvalidNumberFormat,
        /// <summary>
        /// Entered number has been changed.
        /// </summary>
        NumberChanged,
        /// <summary>
        /// Unassigned/Unallocated number.
        /// </summary>
        UnassignedNumber,
        /// <summary>
        /// Called Party does not respond.
        /// </summary>
        UserDoesNotRespond,
        /// <summary>
        /// IMEI rejected.
        /// </summary>
        ImeiRejected,
        /// <summary>
        /// FDN number only.
        /// </summary>
        FixedDialingNumberOnly,
        /// <summary>
        /// SAT call control reject.
        /// </summary>
        SatCallControlReject,
        /// <summary>
        /// This number cannot receive video calls.
        /// </summary>
        CannotReceiveVideoCall
    }

    /// <summary>
    /// Enumeration for call release type.
    /// </summary>
    public enum CallReleaseType
    {
        /// <summary>
        /// Release call using given call handle.
        /// </summary>
        ByCallHandle = 0,
        /// <summary>
        /// Release all Calls.
        /// </summary>
        AllCalls,
        /// <summary>
        /// Releases all hold calls.
        /// </summary>
        AllHoldCalls,
        /// <summary>
        /// Releases all active calls.
        /// </summary>
        AllActiveCalls
    }
}

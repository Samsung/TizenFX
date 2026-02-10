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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Specifies the audio codec.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API14. Will be removed in API16.")]
    public enum ToneType
    {
        /// <summary>
        /// The default tone.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Predefined DTMF 0.
        /// </summary>
        Dtmf0 = 0,
        /// <summary>
        /// Predefined DTMF 1.
        /// </summary>
        Dtmf1,
        /// <summary>
        /// Predefined DTMF 2.
        /// </summary>
        Dtmf2,
        /// <summary>
        /// Predefined DTMF 3.
        /// </summary>
        Dtmf3,
        /// <summary>
        /// Predefined DTMF 4.
        /// </summary>
        Dtmf4,
        /// <summary>
        /// Predefined DTMF 5.
        /// </summary>
        Dtmf5,
        /// <summary>
        /// Predefined DTMF 6.
        /// </summary>
        Dtmf6,
        /// <summary>
        /// Predefined DTMF 7.
        /// </summary>
        Dtmf7,
        /// <summary>
        /// Predefined DTMF 8.
        /// </summary>
        Dtmf8,
        /// <summary>
        /// Predefined DTMF 9.
        /// </summary>
        Dtmf9,
        /// <summary>
        /// Predefined DTMF Star - Asterisk.
        /// </summary>
        DtmfS,
        /// <summary>
        /// Predefined DTMF sharp (#).
        /// </summary>
        DtmfP,
        /// <summary>
        /// Predefined DTMF A (A).
        /// </summary>
        DtmfA,
        /// <summary>
        /// Predefined DTMF B (B).
        /// </summary>
        DtmfB,
        /// <summary>
        /// Predefined DTMF C (C).
        /// </summary>
        DtmfC,
        /// <summary>
        /// Predefined DTMF D (D).
        /// </summary>
        DtmfD,
        /// <summary>
        /// Call supervisory tone, Dial tone: CEPT: 425Hz, continuous.
        /// </summary>
        SupDial,
        /// <summary>
        /// Call supervisory tone, Dial tone: ANSI (IS-95): 350Hz+440Hz, continuous.
        /// </summary>
        AnsiDial,
        /// <summary>
        /// Call supervisory tone, Dial tone: JAPAN: 400Hz, continuous.
        /// </summary>
        JapanDial,
        /// <summary>
        /// Call supervisory tone, Busy: CEPT: 425Hz, 500ms ON, 500ms OFF.
        /// </summary>
        SupBusy,
        /// <summary>
        /// Call supervisory tone, Busy: ANSI (IS-95): 480Hz+620Hz, 500ms ON, 500ms OFF.
        /// </summary>
        AnsiBusy,
        /// <summary>
        /// Call supervisory tone, Busy: JAPAN: 400Hz, 500ms ON, 500ms OFF.
        /// </summary>
        JapanBusy,
        /// <summary>
        /// Call supervisory tone, Congestion: CEPT, JAPAN: 425Hz, 200ms ON, 200ms OFF.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        SupCongestion,
        /// <summary>
        /// Call supervisory tone, Congestion: ANSI (IS-95): 480Hz+620Hz, 250ms ON, 250ms OFF.
        /// </summary>
        AnsiCongestion,
        /// <summary>
        /// Call supervisory tone, Radio path acknowledgment : CEPT, ANSI: 425Hz, 200ms ON.
        /// </summary>
        SupRadioAck,
        /// <summary>
        /// Call supervisory tone, Radio path acknowledgment : JAPAN: 400Hz, 1s ON, 2s OFF.
        /// </summary>
        JapanRadioAck,
        /// <summary>
        /// Call supervisory tone, Radio path not available: 425Hz, 200ms ON, 200 OFF 3 bursts.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        SupRadioNotAvailable,
        /// <summary>
        /// Call supervisory tone, Error/Special info: 950Hz+1400Hz+1800Hz, 330ms ON, 1s OFF.
        /// </summary>
        SupError,
        /// <summary>
        /// Call supervisory tone, Call Waiting: CEPT, JAPAN: 425Hz, 200ms ON, 600ms OFF, 200ms ON, 3s OFF.
        /// </summary>
        SupCallWaiting,
        /// <summary>
        /// Call supervisory tone, Call Waiting: ANSI (IS-95): 440 Hz, 300 ms ON, 9.7 s OFF, (100 ms ON, 100 ms OFF, 100 ms ON, 9.7s OFF.
        /// </summary>
        AnsiCallWaiting,
        /// <summary>
        /// Call supervisory tone, Ring Tone: CEPT, JAPAN: 425Hz, 1s ON, 4s OFF.
        /// </summary>
        SupRingtone,
        /// <summary>
        /// Call supervisory tone, Ring Tone: ANSI (IS-95): 440Hz + 480Hz, 2s ON, 4s OFF.
        /// </summary>
        AnsiRingtone,
        /// <summary>
        /// General beep: 400Hz+1200Hz, 35ms ON.
        /// </summary>
        PropBeep,
        /// <summary>
        /// Proprietary tone, positive acknowledgment: 1200Hz, 100ms ON, 100ms OFF 2 bursts.
        /// </summary>
        PropAck,
        /// <summary>
        /// Proprietary tone, negative acknowledgment: 300Hz+400Hz+500Hz, 400ms ON.
        /// </summary>
        PropNack,
        /// <summary>
        /// Proprietary tone, prompt tone: 400Hz+1200Hz, 200ms ON.
        /// </summary>
        PropPrompt,
        /// <summary>
        /// Proprietary tone, general double beep: twice 400Hz+1200Hz, 35ms ON, 200ms OFF, 35ms ON.
        /// </summary>
        PropBeep2,
        /// <summary>
        /// Call supervisory tone (IS-95), intercept tone: alternating 440 Hz and 620 Hz tones, each on for 250 ms.
        /// </summary>
        SupIntercept,
        /// <summary>
        /// Call supervisory tone (IS-95), abbreviated intercept: intercept tone limited to 4 seconds.
        /// </summary>
        SupInterceptAbbrev,
        /// <summary>
        /// Call supervisory tone (IS-95), abbreviated congestion: congestion tone limited to 4 seconds.
        /// </summary>
        SupCongestionAbbrev,
        /// <summary>
        /// Call supervisory tone (IS-95), confirm tone: a 350 Hz tone added to a 440 Hz tone repeated 3 times in a 100 ms on, 100 ms off cycle.
        /// </summary>
        SupConfirm,
        /// <summary>
        /// Call supervisory tone (IS-95), pip tone: four bursts of 480 Hz tone (0.1 s on, 0.1 s off).
        /// </summary>
        SupPip,
        /// <summary>
        /// 425Hz continuous.
        /// </summary>
        CdmaDialToneLite,
        /// <summary>
        /// CDMA USA Ringback: 440Hz+480Hz 2s ON, 4000 OFF.
        /// </summary>
        CdmaNetworkUsaRingback,
        /// <summary>
        /// CDMA Intercept tone: 440Hz 250ms ON, 620Hz 250ms ON.
        /// </summary>
        CdmaIntercept,
        /// <summary>
        /// CDMA Abbr Intercept tone: 440Hz 250ms ON, 620Hz 250ms ON.
        /// </summary>
        CdmaAbbrIntercept,
        /// <summary>
        /// CDMA Reorder tone: 480Hz+620Hz 250ms ON, 250ms OFF.
        /// </summary>
        CdmaReorder,
        /// <summary>
        /// CDMA Abbr Reorder tone: 480Hz+620Hz 250ms ON, 250ms OFF repeated for 8 times.
        /// </summary>
        CdmaAbbrReorder,
        /// <summary>
        /// CDMA Network Busy tone: 480Hz+620Hz 500ms ON, 500ms OFF continuous.
        /// </summary>
        CdmaNetworkBusy,
        /// <summary>
        /// CDMA Confirm tone: 350Hz+440Hz 100ms ON, 100ms OFF repeated for 3 times.
        /// </summary>
        CdmaConfirm,
        /// <summary>
        /// CDMA answer tone: silent tone - definition Frequency 0, 0ms ON, 0ms OFF.
        /// </summary>
        CdmaAnswer,
        /// <summary>
        /// CDMA Network Callwaiting tone: 440Hz 300ms ON.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        CdmaNetworkCallWaiting,
        /// <summary>
        /// CDMA PIP tone: 480Hz 100ms ON, 100ms OFF repeated for 4 times.
        /// </summary>
        CdmaPip,
        /// <summary>
        /// ISDN Call Signal Normal tone: {2091Hz 32ms ON, 2556 64ms ON} 20 times, 2091 32ms ON, 2556 48ms ON, 4s OFF.
        /// </summary>
        CdmaCallSignalIsdnNormal,
        /// <summary>
        /// ISDN Call Signal Intergroup tone: {2091Hz 32ms ON, 2556 64ms ON} 8 times, 2091Hz 32ms ON, 400ms OFF, {2091Hz 32ms ON, 2556Hz 64ms ON} 8times, 2091Hz 32ms ON, 4s OFF.
        /// </summary>
        CdmaCallSignalIsdnIntergroup,
        /// <summary>
        /// ISDN Call Signal SP PRI tone:{2091Hz 32ms ON, 2556 64ms ON} 4 times 2091Hz 16ms ON, 200ms OFF, {2091Hz 32ms ON, 2556Hz 64ms ON} 4 times, 2091Hz 16ms ON, 200ms OFF.
        /// </summary>
        CdmaCallSignalIsdnSpPri,
        /// <summary>
        /// ISDN Call sign PAT3 tone: silent tone.
        /// </summary>
        CdmaCallSignalIsdnPat3,
        /// <summary>
        /// ISDN Ping Ring tone: {2091Hz 32ms ON, 2556Hz 64ms ON} 5 times 2091Hz 20ms ON.
        /// </summary>
        CdmaCallSignalIsdnPingRing,
        /// <summary>
        /// ISDN Pat5 tone: silent tone.
        /// </summary>
        CdmaCallSignalIsdnPat5,
        /// <summary>
        /// ISDN Pat6 tone: silent tone.
        /// </summary>
        CdmaCallSignalIsdnPat6,
        /// <summary>
        /// ISDN Pat7 tone: silent tone.
        /// </summary>
        CdmaCallSignalIsdnPat7,
        /// <summary>
        /// TONE_CDMA_HIGH_L tone: {3700Hz 25ms, 4000Hz 25ms} 40 times 4000ms OFF, Repeat.
        /// </summary>
        CdmaHighL,
        /// <summary>
        /// TONE_CDMA_MED_L tone: {2600Hz 25ms, 2900Hz 25ms} 40 times 4000ms OFF, Repeat.
        /// </summary>
        CdmaMedL,
        /// <summary>
        /// TONE_CDMA_LOW_L tone: {1300Hz 25ms, 1450Hz 25ms} 40 times, 4000ms OFF, Repeat.
        /// </summary>
        CdmaLowL,
        /// <summary>
        /// CDMA HIGH SS tone: {3700Hz 25ms, 4000Hz 25ms} repeat 16 times, 400ms OFF, repeat.
        /// </summary>
        CdmaHighSs,
        /// <summary>
        /// CDMA MED SS tone: {2600Hz 25ms, 2900Hz 25ms} repeat 16 times, 400ms OFF, repeat.
        /// </summary>
        CdmaMedSs,
        /// <summary>
        /// CDMA LOW SS tone: {1300z 25ms, 1450Hz 25ms} repeat 16 times, 400ms OFF, repeat.
        /// </summary>
        CdmaLowSs,
        /// <summary>
        /// CDMA HIGH SSL tone: {3700Hz 25ms, 4000Hz 25ms} 8 times, 200ms OFF, {3700Hz 25ms, 4000Hz 25ms} repeat 8 times, 200ms OFF, {3700Hz 25ms, 4000Hz 25ms} repeat 16 times, 4000ms OFF, repeat.
        /// </summary>
        CdmaHighSsl,
        /// <summary>
        /// CDMA MED SSL tone: {2600Hz 25ms, 2900Hz 25ms} 8 times, 200ms OFF, {2600Hz 25ms, 2900Hz 25ms} repeat 8 times, 200ms OFF, {2600Hz 25ms, 2900Hz 25ms} repeat 16 times, 4000ms OFF, repeat.
        /// </summary>
        CdmaMedSsl,
        /// <summary>
        /// CDMA LOW SSL tone: {1300Hz 25ms, 1450Hz 25ms} 8 times, 200ms OFF, {1300Hz 25ms, 1450Hz 25ms} repeat 8 times, 200ms OFF, {1300Hz 25ms, 1450Hz 25ms} repeat 16 times, 4000ms OFF, repeat.
        /// </summary>
        CdmaLowSsl,
        /// <summary>
        /// CDMA HIGH SS2 tone: {3700Hz 25ms, 4000Hz 25ms} 20 times, 1000ms OFF, {3700Hz 25ms, 4000Hz 25ms} 20 times, 3000ms OFF, repeat.
        /// </summary>
        CdmaHighSs2,
        /// <summary>
        /// CDMA MED SS2 tone: {2600Hz 25ms, 2900Hz 25ms} 20 times, 1000ms OFF, {2600Hz 25ms, 2900Hz 25ms} 20 times, 3000ms OFF, repeat.
        /// </summary>
        CdmaMedSs2,
        /// <summary>
        /// CDMA LOW SS2 tone: {1300Hz 25ms, 1450Hz 25ms} 20 times, 1000ms OFF, {1300Hz 25ms, 1450Hz 25ms} 20 times, 3000ms OFF, repeat.
        /// </summary>
        CdmaLowSs2,
        /// <summary>
        /// CDMA HIGH SLS tone: {3700Hz 25ms, 4000Hz 25ms} 10 times, 500ms OFF, {3700Hz 25ms, 4000Hz 25ms} 20 times, 500ms OFF, {3700Hz 25ms, 4000Hz 25ms} 10 times, 3000ms OFF, REPEAT.
        /// </summary>
        CdmaHighSls,
        /// <summary>
        /// CDMA MED SLS tone: {2600Hz 25ms, 2900Hz 25ms} 10 times, 500ms OFF, {2600Hz 25ms, 2900Hz 25ms} 20 times, 500ms OFF, {2600Hz 25ms, 2900Hz 25ms} 10 times, 3000ms OFF, REPEAT.
        /// </summary>
        CdmaMedSls,
        /// <summary>
        /// CDMA LOW SLS tone: {1300Hz 25ms, 1450Hz 25ms} 10 times, 500ms OFF, {1300Hz 25ms, 1450Hz 25ms} 20 times, 500ms OFF, {1300Hz 25ms, 1450Hz 25ms} 10 times, 3000ms OFF, REPEAT.
        /// </summary>
        CdmaLowSls,
        /// <summary>
        /// CDMA HIGH S X4 tone: {3700Hz 25ms, 4000Hz 25ms} 10 times, 500ms OFF, {3700Hz 25ms, 4000Hz 25ms} 10 times, 500ms OFF, {3700Hz 25ms, 4000Hz 25ms} 10 times, 500ms OFF, {3700Hz 25ms, 4000Hz 25ms} 10 times, 2500ms OFF, REPEAT.
        /// </summary>
        CdmaHighSx4,
        /// <summary>
        /// CDMA MED S X4 tone: {2600Hz 25ms, 2900Hz 25ms} 10 times, 500ms OFF, {2600Hz 25ms, 2900Hz 25ms} 10 times, 500ms OFF, {2600Hz 25ms, 2900Hz 25ms} 10 times, 500ms OFF, {2600Hz 25ms, 2900Hz 25ms} 10 times, 2500ms OFF, REPEAT.
        /// </summary>
        CdmaMedSX4,
        /// <summary>
        /// CDMA LOW S X4 tone: {2600Hz 25ms, 2900Hz 25ms} 10 times, 500ms OFF, {2600Hz 25ms, 2900Hz 25ms} 10 times, 500ms OFF, {2600Hz 25ms, 2900Hz 25ms} 10 times, 500ms OFF, {2600Hz 25ms, 2900Hz 25ms} 10 times, 2500ms OFF, REPEAT.
        /// </summary>
        CdmaLowSX4,
        /// <summary>
        /// CDMA HIGH PBX L: {3700Hz 25ms, 4000Hz 25ms}20 times, 2000ms OFF, REPEAT.
        /// </summary>
        CdmaHighPbxL,
        /// <summary>
        /// CDMA MED PBX L: {2600Hz 25ms, 2900Hz 25ms}20 times, 2000ms OFF, REPEAT.
        /// </summary>
        CdmaMedPbxL,
        /// <summary>
        /// CDMA LOW PBX L: {1300Hz 25ms,1450Hz 25ms}20 times, 2000ms OFF, REPEAT.
        /// </summary>
        CdmaLowPbxL,
        /// <summary>
        /// CDMA HIGH PBX SS tone: {3700Hz 25ms, 4000Hz 25ms} 8 times 200 ms OFF, {3700Hz 25ms 4000Hz 25ms}8 times, 2000ms OFF, REPEAT.
        /// </summary>
        CdmaHighPbxSs,
        /// <summary>
        /// CDMA MED PBX SS tone: {2600Hz 25ms, 2900Hz 25ms} 8 times 200 ms OFF, {2600Hz 25ms 2900Hz 25ms}8 times, 2000ms OFF, REPEAT.
        /// </summary>
        CdmaMedPbxSs,
        /// <summary>
        /// CDMA LOW PBX SS tone: {1300Hz 25ms, 1450Hz 25ms} 8 times 200 ms OFF, {1300Hz 25ms 1450Hz 25ms}8 times, 2000ms OFF, REPEAT.
        /// </summary>
        CdmaLowPbxSs,
        /// <summary>
        /// CDMA HIGH PBX SSL tone:{3700Hz 25ms, 4000Hz 25ms} 8 times 200ms OFF, {3700Hz 25ms, 4000Hz 25ms} 8 times, 200ms OFF, {3700Hz 25ms, 4000Hz 25ms} 16 times, 1000ms OFF, REPEAT.
        /// </summary>
        CdmaHighPbxSsl,
        /// <summary>
        /// CDMA MED PBX SSL tone:{2600Hz 25ms, 2900Hz 25ms} 8 times 200ms OFF, {2600Hz 25ms, 2900Hz 25ms} 8 times, 200ms OFF, {2600Hz 25ms, 2900Hz 25ms} 16 times, 1000ms OFF, REPEAT.
        /// </summary>
        CdmaMedPbxSsl,
        /// <summary>
        /// CDMA LOW PBX SSL tone:{1300Hz 25ms, 1450Hz 25ms} 8 times 200ms OFF, {1300Hz 25ms, 1450Hz 25ms} 8 times, 200ms OFF, {1300Hz 25ms, 1450Hz 25ms} 16 times, 1000ms OFF, REPEAT.
        /// </summary>
        CdmaLowPbxSsl,
        /// <summary>
        /// CDMA HIGH PBX SLS tone:{3700Hz 25ms, 4000Hz 25ms} 8 times 200ms OFF, {3700Hz 25ms, 4000Hz 25ms} 16 times, 200ms OFF, {3700Hz 25ms, 4000Hz 25ms} 8 times, 1000ms OFF, REPEAT.
        /// </summary>
        CdmaHighPbxSls,
        /// <summary>
        /// CDMA MED PBX SLS tone:{2600Hz 25ms, 2900Hz 25ms} 8 times 200ms OFF, {2600Hz 25ms, 2900Hz 25ms} 16 times, 200ms OFF, {2600Hz 25ms, 2900Hz 25ms} 8 times, 1000ms OFF, REPEAT.
        /// </summary>
        CdmaMedPbxSls,
        /// <summary>
        /// CDMA LOW PBX SLS tone:{1300Hz 25ms, 1450Hz 25ms} 8 times 200ms OFF, {1300Hz 25ms, 1450Hz 25ms} 16 times, 200ms OFF, {1300Hz 25ms, 1450Hz 25ms} 8 times, 1000ms OFF, REPEAT.
        /// </summary>
        CdmaLowPbxSls,
        /// <summary>
        /// CDMA HIGH PBX X S4 tone: {3700Hz 25ms 4000Hz 25ms} 8 times, 200ms OFF, {3700Hz 25ms 4000Hz 25ms} 8 times, 200ms OFF, {3700Hz 25ms 4000Hz 25ms} 8 times, 200ms OFF, {3700Hz 25ms 4000Hz 25ms} 8 times, 800ms OFF, REPEAT.
        /// </summary>
        CdmaHighPbxSX4,
        /// <summary>
        /// CDMA MED PBX X S4 tone: {2600Hz 25ms 2900Hz 25ms} 8 times, 200ms OFF, {2600Hz 25ms 2900Hz 25ms} 8 times, 200ms OFF, {2600Hz 25ms 2900Hz 25ms} 8 times, 200ms OFF, {2600Hz 25ms 2900Hz 25ms} 8 times, 800ms OFF, REPEAT.
        /// </summary>
        CdmaMedPbxSX4,
        /// <summary>
        /// CDMA LOW PBX X S4 tone: {1300Hz 25ms 1450Hz 25ms} 8 times, 200ms OFF, {1300Hz 25ms 1450Hz 25ms} 8 times, 200ms OFF, {1300Hz 25ms 1450Hz 25ms} 8 times, 200ms OFF, {1300Hz 25ms 1450Hz 25ms} 8 times, 800ms OFF, REPEAT.
        /// </summary>
        CdmaLowPbxSX4,
        /// <summary>
        /// CDMA Alert Network Lite tone: 1109Hz 62ms ON, 784Hz 62ms ON, 740Hz 62ms ON 622Hz 62ms ON, 1109Hz 62ms ON.
        /// </summary>
        CdmaAlertNetworkLite,
        /// <summary>
        ///CDMA Alert Auto Redial tone: {1245Hz 62ms ON, 659Hz 62ms ON} 3 times, 1245 62ms ON.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        CdmaAlertAutoRedialLite,
        /// <summary>
        /// CDMA One Min Beep tone: 1150Hz+770Hz 400ms ON.
        /// </summary>
        CdmaOneMinBeep,
        /// <summary>
        /// CDMA KEYPAD Volume key lite tone: 941Hz+1477Hz 120ms ON.
        /// </summary>
        CdmaKeypadVolumeKeyLite,
        /// <summary>
        /// CDMA PRESSHOLDKEY LITE tone: 587Hz 375ms ON, 1175Hz 125ms ON.
        /// </summary>
        CdmaPressHoldKeyLite,
        /// <summary>
        /// CDMA ALERT INCALL LITE tone: 587Hz 62ms, 784 62ms, 831Hz 62ms, 784Hz 62ms, 1109 62ms, 784Hz 62ms, 831Hz 62ms, 784Hz 62ms.
        /// </summary>
        CdmaAlertIncallLite,
        /// <summary>
        /// CDMA EMERGENCY RINGBACK tone: {941Hz 125ms ON, 10ms OFF} 3times 4990ms OFF, REPEAT.
        /// </summary>
        CdmaEmergencyRingback,
        /// <summary>
        /// CDMA ALERT CALL GUARD tone: {1319Hz 125ms ON, 125ms OFF} 3 times.
        /// </summary>
        CdmaAlertCallGuard,
        /// <summary>
        /// CDMA SOFT ERROR LITE tone: 1047Hz 125ms ON, 370Hz 125ms.
        /// </summary>
        CdmaSoftErrorLite,
        /// <summary>
        /// CDMA CALLDROP LITE tone: 1480Hz 125ms, 1397Hz 125ms, 784Hz 125ms.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        CdmaCallDropLite,
        /// <summary>
        /// CDMA_NETWORK_BUSY_ONE_SHOT tone: 425Hz 500ms ON, 500ms OFF.
        /// </summary>
        CdmaNetworkBusyOneShot,
        /// <summary>
        /// CDMA_ABBR_ALERT tone: 1150Hz+770Hz 400ms ON.
        /// </summary>
        CdmaAbbrAlert,
        /// <summary>
        /// CDMA_SIGNAL_OFF - silent tone.
        /// </summary>
        CdmaSignalOff,
        /// <summary>
        /// User Defined Tone: 100Hz continuous.
        /// </summary>
        UserDefinedLowFre,
        /// <summary>
        /// User Defined Tone: 200Hz continuous.
        /// </summary>
        UserDefinedMedFre,
        /// <summary>
        /// User Defined Tone: 300Hz continuous.
        /// </summary>
        UserDefinedHighFre
    }
}


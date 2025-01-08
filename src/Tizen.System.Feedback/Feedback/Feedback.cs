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
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;


namespace Tizen.System
{
    /// <summary>
    /// The Feedback API provides functions to control haptic and sound.
    /// The Feedback API provides the way to play and stop feedback, and get the information whether a specific pattern is supported.
    /// Below is the supported pattern string:
    /// Tap
    /// SoftInputPanel
    /// Key0
    /// Key1
    /// Key2
    /// Key3
    /// Key4
    /// Key5
    /// Key6
    /// Key7
    /// Key8
    /// Key9
    /// KeyStar
    /// KeySharp
    /// KeyBack
    /// Hold
    /// HardwareKeyPressed
    /// HardwareKeyHold
    /// Message
    /// Email
    /// WakeUp
    /// Schedule
    /// Timer
    /// General
    /// PowerOn
    /// PowerOff
    /// ChargerConnected
    /// ChargingError
    /// FullyCharged
    /// LowBattery
    /// Lock
    /// UnLock
    /// VibrationModeAbled
    /// SilentModeDisabled
    /// BluetoothDeviceConnected
    /// BluetoothDeviceDisconnected
    /// ListReorder
    /// ListSlider
    /// VolumeKeyPressed
    /// </summary>
    /// <privilege>
    /// For controlling the haptic device:
    /// http://tizen.org/privilege/haptic
    /// For controlling the sound, privilege is not needed.
    /// </privilege>
    /// <example>
    /// <code>
    /// Feedback feedback = new Feedback();
    /// bool res = feedback.IsSupportedPattern(FeedbackType.Vibration, "Tap");
    /// </code>
    /// </example>
    /// <since_tizen> 3 </since_tizen>
    public class Feedback
    {
        private const string LogTag = "Tizen.System.Feedback";

        private readonly Dictionary<string, int> Pattern = new Dictionary<string, int>
        {
            {"Tap", 0},
            {"SoftInputPanel", 1},
            {"SipBackspace", 2},
            {"SipFunction", 3},
            {"SipFjkey", 4},
            {"MaxCharacter", 5},
            {"Key0", 6},
            {"Key1", 7},
            {"Key2", 8},
            {"Key3", 9},
            {"Key4", 10},
            {"Key5", 11},
            {"Key6", 12},
            {"Key7", 13},
            {"Key8", 14},
            {"Key9", 15},
            {"KeyStar", 16},
            {"KeySharp", 17},
            {"KeyBack", 18},
            {"Hold", 19},
            {"MultiTap", 20},
            {"HardwareKeyPressed", 21},
            {"HardwareKeyHold", 22},
            {"Message", 23},
            {"MessageOnCall", 24},
            {"Email", 25},
            {"EmailOnCall", 26},
            {"WakeUp", 27},
            {"WakeUpOnCall", 28},
            {"Schedule", 29},
            {"ScheduleOnCall", 30},
            {"Timer", 31},
            {"TimerOnCall", 32},
            {"General", 33},
            {"GeneralOnCall", 34},
            {"SmartAlert", 35},
            {"PowerOn", 36},
            {"PowerOff", 37},
            {"ChargerConnected", 38},
            {"ChargerconnOnCall", 39},
            {"ChargingError", 40},
            {"ChargingErrorOnCall", 41},
            {"FullyCharged", 42},
            {"FullchargedOnCall", 43},
            {"LowBattery", 44},
            {"LowBattOnCall", 45},
            {"Lock", 46},
            {"UnLock", 47},
            {"GeometricLock", 50},
            {"Callconnect", 51},
            {"Discallconnect", 52},
            {"OutgoingCall", 53},
            {"Minuteminder", 54},
            {"VibrationModeAbled", 55},
            {"SilentModeDisabled", 56},
            {"BluetoothDeviceConnected", 57},
            {"BluetoothDeviceDisconnected", 58},
            {"BtPairing", 59},
            {"BtWaiting", 60},
            {"ScreenCapture", 61},
            {"ListReorder", 62},
            {"ListSlider", 63},
            {"VolumeKeyPressed", 64},
            {"UvProcessing", 95},
            {"ShealthStart", 96},
            {"ShealthPause", 97},
            {"ShealthStop", 98},
            {"3rdApplication", 99},
            {"Tick", 100},
            {"TransitionCircular", 101},
            {"TransitionPop", 102},
            {"Process", 103},
            {"MoveList", 104},
            {"Dismiss", 105},
            {"ClockSecondHand", 106},
            {"SystemShort", 107},
            {"SystemError", 108},
            {"SpiralDown", 109},
            {"MoveList2", 110},
            {"SpiralUp", 111},
            {"SystemLong", 112},
            {"SystemMid", 113},
            {"Silence", 114},
            {"InactiveTension", 115},
            {"InactiveFine", 116},
            {"EndEffect", 117},
            {"ShealthNotice", 118},
            {"ShealthGentleAlert", 119},
            {"EndEffectFine", 120},
            {"ClickValue", 121},
            {"ClickFineTrain1", 122},
            {"ClickFine", 123},
            {"ClickSlider", 124},
            {"ClickMedium", 125},
            {"ClickStrong", 126},
            {"TurnRight", 127},
            {"TurnLeft", 128},
            {"Function", 129},
            {"VoiceStart", 130},
            {"VoiceStop", 131},
            {"Communication", 132},
            {"MessageStrongBuzz", 133},
            {"EmailStrongBuzz", 134},
            {"GeneralStrongBuzz", 135},
            {"CommunicationStrongBuzz", 136},
            {"ScheduleStrongBuzz", 137},
            {"WakeupStrongBuzz", 138},
            {"TimerStrongBuzz", 139},
            {"RingerStrongBuzz", 140},
            {"Heartbeat", 141},
            {"HeartbeatFast", 142},
            {"SettingOn", 143},
            {"SettingOff", 144},
            {"Connect", 145},
            {"Disconnect", 146},
            {"FindMyGear", 147},
            {"Notification1", 148},
            {"Notification1StrongBuzz", 149},
            {"Notification2", 150},
            {"Notification2StrongBuzz", 151},
            {"Notification3", 152},
            {"Notification3StrongBuzz", 153},
            {"Notification4", 154},
            {"Notification4StrongBuzz", 155},
            {"Notification5", 156},
            {"Notification5StrongBuzz", 157},
            {"Notification6", 158},
            {"Notification6StrongBuzz", 159},
            {"Notification7", 160},
            {"Notification7StrongBuzz", 161},
            {"Notification8", 162},
            {"Notification8StrongBuzz", 163},
            {"Notification9", 164},
            {"Notification9StrongBuzz", 165},
            {"Notification10", 166},
            {"Notification10StrongBuzz", 167},
            {"Ring1", 168},
            {"Ring1StrongBuzz", 169},
            {"Ring2", 170},
            {"Ring2StrongBuzz", 171},
            {"Ring3", 172},
            {"Ring3StrongBuzz", 173},
            {"Ring4", 174},
            {"Ring4StrongBuzz", 175},
            {"Ring5", 176},
            {"Ring5StrongBuzz", 177},
            {"Ring6", 178},
            {"Ring6StrongBuzz", 179},
            {"Ring7", 180},
            {"Ring7StrongBuzz", 181},
            {"Ring8", 182},
            {"Ring8StrongBuzz", 183},
            {"Ring9", 184},
            {"Ring9StrongBuzz", 185},
            {"Ring10", 186},
            {"Ring10StrongBuzz", 187},
            {"Alarm1", 188},
            {"Alarm1StrongBuzz", 189},
            {"Alarm2", 190},
            {"Alarm2StrongBuzz", 191},
            {"Alarm3", 192},
            {"Alarm3StrongBuzz", 193},
            {"Alarm4", 194},
            {"Alarm4StrongBuzz", 195},
            {"Alarm5", 196},
            {"Alarm5StrongBuzz", 197},
            {"Alarm6", 198},
            {"Alarm6StrongBuzz", 199},
            {"Alarm7", 200},
            {"Alarm7StrongBuzz", 201},
            {"Alarm8", 202},
            {"Alarm8StrongBuzz", 203},
            {"Alarm9", 204},
            {"Alarm9StrongBuzz", 205},
            {"Alarm10", 206},
            {"Alarm10StrongBuzz", 207},
            {"Picker", 208},
            {"PickerFinish", 209},
            {"OnOffSwitch", 210},
            {"Reorder", 211},
            {"CursorMove", 212},
            {"Mms", 10000},
            {"HourlyAlert", 10001},
            {"SafetyAlert", 10002},
            {"AccidentDetect", 10003},
            {"SendSosMessage", 10004},
            {"EndSosMessage", 10005},
            {"EmergencyBuzzer", 10006},
            {"SafetyLowPower", 10007},
            {"Cmas", 10008},
            {"Ringer", 10009},
            {"Notification", 10010},
            {"Info", 10011},
            {"Warning", 10012},
            {"Error", 10013},
            {"Emergency", 10014},
            {"InternalWakeup", 10015},
            {"InternalTimer", 10016},
            {"TemperatureWarning", 10017},
            {"CooldownWarning1", 10018},
            {"CooldownWarning2", 10019},
            {"SpeedUp", 10020},
            {"SlowDown", 10021},
            {"KeepThisPace", 10022},
            {"GoalAchieved", 10023},
            {"ExerciseCount", 10024},
            {"StartCue", 10025},
            {"HealthPace", 10026},
            {"InactiveTime", 10027},
            {"CmasCa", 10028},
            {"NfcSuccess", 10029},
            {"MeasuringSuccess", 10030},
            {"MeasuringFailure", 10031},
            {"Meditation", 10032},
            {"MeditationInternal", 10033},
            {"FallDetection1", 10034},
            {"FallDetection2", 10035},
            {"SmartGesture", 10036},
            {"BreathingExhale", 12000},
            {"Bos", 12001},
            {"Eos", 12002},
            {"Uds", 12003},
            {"Basic", 40001},
            {"ToggleOn", 40002},
            {"ToggleOff", 40003},
            {"LongPressOn", 40004},
            {"LongPressOff", 40005},
            {"Invalid", 40006},
            {"Confirm", 40007},
            {"PopUp", 40008},
            {"PreheatEnding", 40009},
            {"TaskEnding", 40010},
            {"Scroll", 40011},
            {"PageTurn", 40012},
            {"OpStart", 40013},
            {"OpPause", 40014},
            {"OpStop", 40015},
            {"Default", 40016},
            {"DefaultLevel1", 40017},
            {"Level1", 40018},
            {"Level2", 40019},
            {"Level3", 40020},
            {"Level4", 40021},
            {"Level5", 40022},
            {"Level6", 40023},
            {"Level7", 40024},
            {"Level8", 40025},
            {"Level9", 40026},
            {"Level10", 40027},
            {"TimerEnding", 40028},
            {"BurnerDetected", 40029},
            {"BurnerMoved", 40030},
            {"Connected", 40031},
            {"Disconnected", 40032},
            {"Welcome", 40033},
            {"AutoDoorOpen", 40034},
        };

        /// <summary>
        /// Constructor of Feedback class
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>
        /// http://tizen.org/feature/feedback.vibration for FeedbackType.Vibration
        /// </feature>
        /// <exception cref="NotSupportedException">Thrown when failed because the devices (vibration and sound) are not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of a system error.</exception>
        /// <privilege>http://tizen.org/privilege/haptic</privilege>
        /// <example>
        /// <code>
        /// Feedback feedback = new Feedback();
        /// </code>
        /// </example>
        public Feedback()
        {
            Interop.Feedback.FeedbackError res = (Interop.Feedback.FeedbackError)Interop.Feedback.Initialize();
            if (res != Interop.Feedback.FeedbackError.None)
            {
                Log.Warn(LogTag, string.Format("Failed to initialize feedback. err = {0}", res));
                switch (res)
                {
                    case Interop.Feedback.FeedbackError.NotSupported:
                        throw new NotSupportedException("Device is not supported");
                    default:
                        throw new InvalidOperationException("Failed to initialize");
                }
            }
        }

        /// <summary>
        /// Finalizes an instance of the Feedback class.
        /// </summary>
        ~Feedback()
        {
            Interop.Feedback.FeedbackError res = (Interop.Feedback.FeedbackError)Interop.Feedback.Deinitialize();
            if (res != Interop.Feedback.FeedbackError.None)
            {
                Log.Warn(LogTag, string.Format("Failed to deinitialize feedback. err = {0}", res));
            }
        }

        /// <summary>
        /// Gets the supported information about a specific type and pattern.
        /// </summary>
        /// <remarks>
        /// Now, IsSupportedPattern is not working for FeedbackType.All.
        /// This API is working for FeedbackType.Sound and FeedbackType.Vibration only.
        /// If you use FeedbackType.All for type parameter, this API will throw ArgumentException.
        /// To get the supported information for Vibration type, the application should have http://tizen.org/privilege/haptic privilege.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="type">The feedback type.</param>
        /// <param name="pattern">The feedback pattern string.</param>
        /// <feature>
        /// http://tizen.org/feature/feedback.vibration for FeedbackType.Vibration
        /// </feature>
        /// <returns>Information whether a pattern is supported.</returns>
        /// <exception cref="Exception">Thrown when failed because the feedback is not initialized.</exception>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid arguament.</exception>
        /// <exception cref="NotSupportedException">Thrown when failed becuase the device (haptic, sound) is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because the access is not granted (No privilege).</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of a system error.</exception>
        /// <privilege>http://tizen.org/privilege/haptic</privilege>
        /// <example>
        /// <code>
	    /// Feedback feedback = new Feedback();
        /// bool res = feedback.IsSupportedPattern(FeedbackType.Vibration, "Tap");
        /// </code>
        /// </example>
        /// <seealso cref="FeedbackType"/>
        public bool IsSupportedPattern(FeedbackType type, String pattern)
        {
            bool supported = false;
            int number;
            Interop.Feedback.FeedbackError res;

            if (!Pattern.TryGetValue(pattern, out number))
                throw new ArgumentException($"Not supported pattern string : {pattern}", nameof(pattern));

            res = (Interop.Feedback.FeedbackError)Interop.Feedback.IsSupportedPattern((Interop.Feedback.FeedbackType)type, number, out supported);

            if (res != Interop.Feedback.FeedbackError.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get supported information. err = {0}", res));
                switch (res)
                {
                    case Interop.Feedback.FeedbackError.NotInitialized:
                        throw new Exception("Not initialized");
                    case Interop.Feedback.FeedbackError.InvalidParameter:
                        throw new ArgumentException("Invalid Arguments");
                    case Interop.Feedback.FeedbackError.NotSupported:
                        throw new NotSupportedException("Device is not supported");
                    case Interop.Feedback.FeedbackError.PermissionDenied:
                        throw new UnauthorizedAccessException("Access is not granted");
                    case Interop.Feedback.FeedbackError.OperationFailed:
                    default:
                        throw new InvalidOperationException("Failed to get supported information");
                }
            }
            return supported;
        }

        /// <summary>
        /// Plays specific type of reactions that are pre-defined feedback pattern.
        /// </summary>
        /// <remarks>
        /// To play Vibration type, app should have http://tizen.org/privilege/haptic privilege.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="type">The feedback type.</param>
        /// <param name="pattern">The feedback pattern string.</param>
        /// <feature>
        /// http://tizen.org/feature/feedback.vibration for FeedbackType.Vibration
        /// </feature>
        /// <exception cref="Exception">Thrown when failed because feedback is not initialized.</exception>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid arguament.</exception>
        /// <exception cref="NotSupportedException">Thrown when failed because the device (haptic, sound) or a specific pattern is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because the access is not granted(No privilege)</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of a system error.</exception>
        /// <privilege>http://tizen.org/privilege/haptic</privilege>
        /// <example>
        /// <code>
        /// Feedback feedback = new Feedback();
        /// feedback.Play(FeedbackType.All, "Tap");
        /// </code>
        /// </example>
        /// <seealso cref="FeedbackType"/>
        /// <seealso cref="Feedback.Stop()"/>
        public void Play(FeedbackType type, String pattern)
        {
            int number;
            Interop.Feedback.FeedbackError res;

            if (!Pattern.TryGetValue(pattern, out number))
                throw new ArgumentException($"Not supported pattern string : {pattern}", nameof(pattern));

            if (type == FeedbackType.All)
                res = (Interop.Feedback.FeedbackError)Interop.Feedback.Play(number);
            else
                res = (Interop.Feedback.FeedbackError)Interop.Feedback.PlayType((Interop.Feedback.FeedbackType)type, number);

            if (res != Interop.Feedback.FeedbackError.None)
            {
                Log.Warn(LogTag, string.Format("Failed to play feedback. err = {0}", res));
                switch (res)
                {
                    case Interop.Feedback.FeedbackError.NotInitialized:
                        throw new Exception("Not initialized");
                    case Interop.Feedback.FeedbackError.InvalidParameter:
                        throw new ArgumentException("Invalid Arguments");
                    case Interop.Feedback.FeedbackError.NotSupported:
                        throw new NotSupportedException("Not supported");
                    case Interop.Feedback.FeedbackError.PermissionDenied:
                        throw new UnauthorizedAccessException("Access is not granted");
                    case Interop.Feedback.FeedbackError.OperationFailed:
                    default:
                        throw new InvalidOperationException("Failed to play pattern");
                }
            }
        }

        /// <summary>
        /// Stops various types of reactions from the feedback module.
        /// </summary>
        /// <remarks>
        /// To stop vibration, the application should have http://tizen.org/privilege/haptic privilege.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>
        /// http://tizen.org/feature/feedback.vibration
        /// </feature>
        /// <exception cref="Exception">Thrown when failed because the feedback is not initialized.</exception>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid arguament</exception>
        /// <exception cref="NotSupportedException">Thrown when failed because the device (haptic, sound) or a specific pattern is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because the access is not granted (No privilege).</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of a system error.</exception>
        /// <privilege>http://tizen.org/privilege/haptic</privilege>
        /// <example>
        /// <code>
        /// Feedback Feedback1 = new Feedback();
        /// Feedback1.Stop();
        /// </code>
        /// </example>
        /// <seealso cref="Feedback.Play(FeedbackType,String)"/>
        public void Stop()
        {
            Interop.Feedback.FeedbackError res = (Interop.Feedback.FeedbackError)Interop.Feedback.Stop();

            if (res != Interop.Feedback.FeedbackError.None)
            {
                Log.Warn(LogTag, string.Format("Failed to stop feedback. err = {0}", res));
                switch (res)
                {
                    case Interop.Feedback.FeedbackError.NotInitialized:
                        throw new Exception("Not initialized");
                    case Interop.Feedback.FeedbackError.InvalidParameter:
                        throw new ArgumentException("Invalid Arguments");
                    case Interop.Feedback.FeedbackError.NotSupported:
                        throw new NotSupportedException("Not supported");
                    case Interop.Feedback.FeedbackError.PermissionDenied:
                        throw new UnauthorizedAccessException("Access is not granted");
                    case Interop.Feedback.FeedbackError.OperationFailed:
                    default:
                        throw new InvalidOperationException("Failed to stop pattern");
                }
            }
        }

        /// <summary>
        /// Gets the number of themes supported as described in the configuration.
        /// </summary>
        /// <remarks>
        /// Now this internal API works for FeedbackType.Sound only, FeedbackType.Vibration is not supported.
        /// Counts of theme range will be 1 ~ N according to conf file.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        /// <param name="type">The feedback type.</param>
        /// <returns>The counf of theme can be used according to feedback type.</returns>
        /// <exception cref="Exception">Thrown when failed because the feedback is not initialized.</exception>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid arguament.</exception>
        /// <exception cref="NotSupportedException">Thrown when failed becuase the device (haptic, sound) is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of a system error.</exception>
        /// <example>
        /// <code>
        /// Feedback feedback = new Feedback();
        /// uint coundOfTheme = feedback.GetCountOfThemeInternal(FeedbackType.Sound);
        /// </code>
        /// </example>
        /// <seealso cref="FeedbackType"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetCountOfThemeInternal(FeedbackType type)
        {
            uint countOfTheme = 0;
            Interop.Feedback.FeedbackError res;

            res = (Interop.Feedback.FeedbackError)Interop.Feedback.GetCountOfThemeInternal((Interop.Feedback.FeedbackType)type, out countOfTheme);

            if (res != Interop.Feedback.FeedbackError.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get count of theme internal. err = {0}", res));
                switch (res)
                {
                    case Interop.Feedback.FeedbackError.NotInitialized:
                        throw new Exception("Not initialized");
                    case Interop.Feedback.FeedbackError.InvalidParameter:
                        throw new ArgumentException("Invalid Arguments");
                    case Interop.Feedback.FeedbackError.NotSupported:
                        throw new NotSupportedException("Device is not supported");
                    case Interop.Feedback.FeedbackError.OperationFailed:
                    default:
                        throw new InvalidOperationException("Failed to get count of theme internal");
                }
            }
            return countOfTheme;
        }

        /// <summary>
        /// Gets the current id of the theme selected from available themes described in the conf file.
        /// </summary>
        /// <remarks>
        /// Now this internal API works for FeedbackType.Sound only, FeedbackType.Vibration is not supported.
        /// The theme id is positive value as defined in the conf file.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        /// <param name="type">The feedback type.</param>
        /// <returns>The id of theme selected as default theme according to feedback type.</returns>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid arguament.</exception>
        /// <exception cref="NotSupportedException">Thrown when failed becuase the device (haptic, sound) is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of a system error.</exception>
        /// <example>
        /// <code>
        /// Feedback feedback = new Feedback();
        /// uint idOfTheme = feedback.GetThemeIdInternal(FeedbackType.Sound);
        /// </code>
        /// </example>
        /// <seealso cref="FeedbackType"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetThemeIdInternal(FeedbackType type)
        {
            uint countOfTheme = 0;
            Interop.Feedback.FeedbackError res;

            res = (Interop.Feedback.FeedbackError)Interop.Feedback.GetThemeIdInternal((Interop.Feedback.FeedbackType)type, out countOfTheme);

            if (res != Interop.Feedback.FeedbackError.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get id of theme internal. err = {0}", res));
                switch (res)
                {
                    case Interop.Feedback.FeedbackError.InvalidParameter:
                        throw new ArgumentException("Invalid Arguments");
                    case Interop.Feedback.FeedbackError.NotSupported:
                        throw new NotSupportedException("Device is not supported");
                    case Interop.Feedback.FeedbackError.OperationFailed:
                    default:
                        throw new InvalidOperationException("Failed to get id of theme internal");
                }
            }
            return countOfTheme;
        }

        /// <summary>
        /// Sets the current id of the theme from available themes described in the conf file.
        /// </summary>
        /// <remarks>
        /// Now this internal API works for FeedbackType.Sound only, FeedbackType.Vibration is not supported.
        /// To set the id of theme for Sound type, the application should have http://tizen.org/privilege/systemsettings.admin privilege.
        /// The theme id is positive value as defined in the conf file.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        /// <param name="type">The feedback type.</param>
        /// <param name="idOfTheme">The id of theme will be set.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid arguament.</exception>
        /// <exception cref="NotSupportedException">Thrown when failed becuase the device (haptic, sound) is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because the access is not granted(No privilege)</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of a system error.</exception>
        /// <example>
        /// <code>
        /// Feedback feedback = new Feedback();
        /// uint idOfTheme = 1;
        /// feedback.SetThemeIdInternal(FeedbackType.Sound, idOfTheme);
        /// </code>
        /// </example>
        /// <seealso cref="FeedbackType"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetThemeIdInternal(FeedbackType type, uint idOfTheme)
        {
            Interop.Feedback.FeedbackError res;

            res = (Interop.Feedback.FeedbackError)Interop.Feedback.SetThemeIdInternal((Interop.Feedback.FeedbackType)type, idOfTheme);

            if (res != Interop.Feedback.FeedbackError.None)
            {
                Log.Warn(LogTag, string.Format("Failed to set id of theme internal. err = {0}", res));
                switch (res)
                {
                    case Interop.Feedback.FeedbackError.InvalidParameter:
                        throw new ArgumentException("Invalid Arguments");
                    case Interop.Feedback.FeedbackError.NotSupported:
                        throw new NotSupportedException("Device is not supported");
                    case Interop.Feedback.FeedbackError.PermissionDenied:
                        throw new UnauthorizedAccessException("Access is not granted");
                    case Interop.Feedback.FeedbackError.OperationFailed:
                    default:
                        throw new InvalidOperationException("Failed to set id of theme internal");
                }
            }
        }

        /// <summary>
        /// Stops reactions of various types according to the feedback type.
        /// </summary>
        /// <remarks>
        /// To stop vibration, the application should have http://tizen.org/privilege/haptic privilege.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        /// <param name="type">The feedback type.</param>
        /// <exception cref="Exception">Thrown when failed because the feedback is not initialized.</exception>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument</exception>
        /// <exception cref="NotSupportedException">Thrown when failed because the device (haptic, sound) or a specific pattern is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because the access is not granted (No privilege).</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of a system error.</exception>
        /// <example>
        /// <code>
        /// Feedback Feedback = new Feedback();
        /// feedback.StopTypeInternal(FeedbackType.Sound);
        /// feedback.StopTypeInternal(FeedbackType.Vibration);
        /// </code>
        /// </example>
        /// <seealso cref="FeedbackType"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StopTypeInternal(FeedbackType type)
        {
            Interop.Feedback.FeedbackError res;

            res = (Interop.Feedback.FeedbackError)Interop.Feedback.StopTypeInternal((Interop.Feedback.FeedbackType)type);

            if (res != Interop.Feedback.FeedbackError.None)
            {
                Log.Warn(LogTag, string.Format("Failed to Stop feedback by feedback type internal. err = {0}", res));
                switch (res)
                {
                    case Interop.Feedback.FeedbackError.NotInitialized:
                        throw new Exception("Not initialized");
                    case Interop.Feedback.FeedbackError.InvalidParameter:
                        throw new ArgumentException("Invalid Arguments");
                    case Interop.Feedback.FeedbackError.NotSupported:
                        throw new NotSupportedException("Not supported");
                    case Interop.Feedback.FeedbackError.PermissionDenied:
                        throw new UnauthorizedAccessException("Access is not granted");
                    case Interop.Feedback.FeedbackError.OperationFailed:
                    default:
                        throw new InvalidOperationException("Failed to stop pattern by feedback type");
                }
            }
        }

        /// <summary>
        /// Gets the array of theme ids supported described in the conf file.
        /// </summary>
        /// <remarks>
        /// Now this internal API works for FeedbackType.Sound only, FeedbackType.Vibration is not supported.
        /// The theme id is positive value as defined in the conf file.
        /// Gets all theme ids as defined in the conf file.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        /// <param name="type">The feedback type.</param>
        /// <returns>The array of theme id supported according to feedback type.</returns>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid arguament.</exception>
        /// <exception cref="NotSupportedException">Thrown when failed becuase the device (haptic, sound) is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of a system error.</exception>
        /// <example>
        /// <code>
        /// Feedback feedback = new Feedback();
        /// uint[] getThemeIds = feedback.GetThemeIdsInternal(FeedbackType.Sound);
        /// </code>
        /// </example>
        /// <seealso cref="FeedbackType"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint[] GetThemeIdsInternal(FeedbackType type)
        {
            uint countOfTheme = 0;
            IntPtr getThemeIds;
            Interop.Feedback.FeedbackError res;

            res = (Interop.Feedback.FeedbackError)Interop.Feedback.GetThemeIdsInternal((Interop.Feedback.FeedbackType)type, out countOfTheme, out getThemeIds);
            if (res != Interop.Feedback.FeedbackError.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get ids of theme internal. err = {0}", res));
                switch (res)
                {
                    case Interop.Feedback.FeedbackError.InvalidParameter:
                        throw new ArgumentException("Invalid Arguments");
                    case Interop.Feedback.FeedbackError.NotSupported:
                        throw new NotSupportedException("Device is not supported");
                    case Interop.Feedback.FeedbackError.OperationFailed:
                    default:
                        throw new InvalidOperationException("Failed to get ids of theme internal");
                }
            }

            uint[] themeIds = new uint[countOfTheme];
            unsafe {
                uint index = 0;
                uint* themeIdsPointer = (uint*)getThemeIds;

                for (index = 0; index < countOfTheme; index++) {
                    themeIds[index] = themeIdsPointer[index];
                }
            }
            Marshal.FreeHGlobal(getThemeIds);

            return themeIds;
        }
    }
}

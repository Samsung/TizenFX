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
            {"HardwareKeyPressed", 21},
            {"HardwareKeyHold", 22},
            {"Message", 23},
            {"Email", 25},
            {"WakeUp", 27},
            {"Schedule", 29},
            {"Timer", 31},
            {"General", 33},
            {"PowerOn", 36},
            {"PowerOff", 37},
            {"ChargerConnected", 38},
            {"ChargingError", 40},
            {"FullyCharged", 42},
            {"LowBattery", 44},
            {"Lock", 46},
            {"UnLock", 47},
            {"VibrationModeAbled", 55},
            {"SilentModeDisabled", 56},
            {"BluetoothDeviceConnected", 57},
            {"BluetoothDeviceDisconnected", 58},
            {"ListReorder", 62},
            {"ListSlider", 63},
            {"VolumeKeyPressed", 64},
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
                switch (res)
                {
                    case Interop.Feedback.FeedbackError.NotInitialized:
                        throw new Exception("Not initialized");
                    default:
                        throw new InvalidOperationException("Failed to initialize");
                }
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
        /// Plays a specific feedback pattern.
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
        /// Stops to play the feedback.
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
    }
}

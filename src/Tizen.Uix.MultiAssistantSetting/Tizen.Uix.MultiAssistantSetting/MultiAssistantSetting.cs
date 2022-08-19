/*
* Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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
using static Interop.MultiAssistantSetting;

namespace Tizen.Uix.MultiAssistantSetting
{
    /// <summary>
    /// Enumeration for the error values that can occur.
    /// </summary>
    /// <since_tizen> 11 </since_tizen>
    public enum Error
    {
        /// <summary>
        /// Successful, no error.
        /// </summary>
        None,
        /// <summary>
        /// Invalid parameter.
        /// </summary>
        InvalidParameter,
        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied,
        /// <summary>
        /// VC NOT supported.
        /// </summary>
        NotSupported,
        /// <summary>
        /// Operation failed.
        /// </summary>
        OperationFailed,
    };

    /// <summary>
    /// This class contains the API's related to the Multi Assistant setting.
    /// </summary>
    /// <since_tizen> 11 </since_tizen>
    public class MultiAssistantManager
    {
        /// <summary>
        /// Check multi-assistant's multiple mode.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        /// <value>
        /// The multi-assistant's multiple mode.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/multiassistant.manager
        /// </privilege>
        /// <returns>
        /// The multiple mode of multi assistant.
        /// </returns>
        public bool MultipleMode
        {
            get
            {
                bool isMultipleMode;

                ErrorCode error = MaSettingIsMultipleMode(out isMultipleMode);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "IsMultipleMode Failed with error " + error);
                    return false;
                }

                return isMultipleMode;
            }
        }

        /// <summary>
        /// Set multi-assistant's multiple mode.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/multiassistant.manager
        /// </privilege>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        public static void SetMultipleMode(bool multiple)
        {
            ErrorCode error = MaSettingSetMultipleMode(multiple);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "MaSettingSetMultipleMode Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Gets the current voice assistant.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        /// <value>
        /// The application ID of current voice assistant.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/multiassistant.manager
        /// </privilege>
        /// <returns>
        /// The application ID of current voice assistant.
        /// </returns>
        public string CurrentVoiceAssistant
        {
            get
            {
                string currentVoiceAssistant;

                ErrorCode error = MaSettingGetCurrentVoiceAssistant(out currentVoiceAssistant);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "CurrentVoiceAssistant Failed with error " + error);
                    return "";
                }

                return currentVoiceAssistant;
            }
        }

        /// <summary>
        /// Change system's voice assistant.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/multiassistant.manager
        /// </privilege>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to Multi Assistant Setting not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="ArgumentException"> This can happen if improper value is provided while setting the value. </exception>
        public static void ChangeVoiceAssistant(string appid)
        {
            ErrorCode error = MaSettingChangeVoiceAssistant(appid);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "MaSettingChangeVoiceAssistant Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// En/Disable a specific voice assistant.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/multiassistant.manager
        /// </privilege>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to Multi Assistant Setting not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="ArgumentException"> This can happen if improper value is provided while setting the value. </exception>
        public static void SetVoiceAssistantEnabled(string appid, bool enabled)
        {
            Log.Info(LogTag, "MaSettingSetVoiceAssistantEnabled calling...");
            ErrorCode error = MaSettingSetVoiceAssistantEnabled(appid, enabled);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "MaSettingSetVoiceAssistantEnabled Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Get voice assistant enabled.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/multiassistant.manager
        /// </privilege>
        /// <returns>
        /// Enabled (true) or Disable (false).
        /// </returns>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to Multi Assistant Setting not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="ArgumentException"> This can happen if improper value is provided while setting the value. </exception>
        public static bool GetVoiceAssistantEnabled(string appid)
        {
            bool enabled = false;

            ErrorCode error = MaSettingGetVoiceAssistantEnabled(appid, out enabled);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "CurrentVoiceAssistant Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return enabled;
        }

        /// <summary>
        /// Retrieve system's default voice assistant.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        /// <value>
        /// The app id of the voice assistant currently set as default one
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/multiassistant.manager
        /// </privilege>
        public string DefaultVoiceAssistant
        {
            get
            {
                string defaultVoiceAssistant;

                ErrorCode error = MaSettingGetDefaultVoiceAssistant(out defaultVoiceAssistant);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "DefaultVoiceAssistant Failed with error " + error);
                    return "";
                }

                return defaultVoiceAssistant;
            }
        }

        /// <summary>
        /// Change system's default voice assistant.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        /// <param name="app_id">
        /// The app id of the voice assistant that need to set as default one
        /// </param>
        /// <privilege>
        /// http://tizen.org/privilege/multiassistant.manager
        /// </privilege>
        /// <exception cref="InvalidOperationException">This exception can be due to invalid state.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to Multi Assistant Setting not supported.</exception>
        /// <exception cref="ArgumentException"> This can happen if improper value is provided while setting the value. </exception>
        public static void SetDefaultVoiceAssistant(string app_id)
        {
            ErrorCode error = MaSettingSetDefaultVoiceAssistant(app_id);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "MaSettingSetDefaultVoiceAssistant Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }
    }
}

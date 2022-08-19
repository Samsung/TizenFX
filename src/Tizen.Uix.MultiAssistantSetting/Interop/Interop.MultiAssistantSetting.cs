// Copyright 2022 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;
using Tizen;

internal static partial class Interop
{
    internal static partial class MultiAssistantSetting
    {
        internal static string LogTag = "Tizen.Uix.MultiAssistantSetting";

        private const int ErrorMultiAssistant = -0x03000000;

        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,            /* Successful */
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,   /* Invalid parameter */
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,   /* Permission denied */
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,       /* Multi-assistant NOT supported */
            OperationFailed = ErrorMultiAssistant | 0x014,    /* Operation failed */
        };

        [DllImport(Libraries.MultiAssistantSetting, EntryPoint = "ma_settings_change_voice_assistant")]
        internal static extern ErrorCode MaSettingChangeVoiceAssistant(string appid);

        [DllImport(Libraries.MultiAssistantSetting, EntryPoint = "ma_settings_get_current_voice_assistant")]
        internal static extern ErrorCode MaSettingGetCurrentVoiceAssistant(out string currentVoiceAssistant);

        [DllImport(Libraries.MultiAssistantSetting, EntryPoint = "ma_settings_set_default_voice_assistant")]
        internal static extern ErrorCode MaSettingSetDefaultVoiceAssistant(string appid);

        [DllImport(Libraries.MultiAssistantSetting, EntryPoint = "ma_settings_get_default_voice_assistant")]
        internal static extern ErrorCode MaSettingGetDefaultVoiceAssistant(out string defaultVoiceAssistant);

        [DllImport(Libraries.MultiAssistantSetting, EntryPoint = "ma_settings_set_multiple_mode")]
        internal static extern ErrorCode MaSettingSetMultipleMode(bool multiple);

        [DllImport(Libraries.MultiAssistantSetting, EntryPoint = "ma_settings_is_multiple_mode")]
        internal static extern ErrorCode MaSettingIsMultipleMode(out bool isMultipleMode);

        [DllImport(Libraries.MultiAssistantSetting, EntryPoint = "ma_settings_set_voice_assistant_enabled")]
        internal static extern ErrorCode MaSettingSetVoiceAssistantEnabled(string appid, bool enabled);

        [DllImport(Libraries.MultiAssistantSetting, EntryPoint = "ma_settings_get_voice_assistant_enabled")]
        internal static extern ErrorCode MaSettingGetVoiceAssistantEnabled(string appid, out bool enabled);
    }
}

// Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;
using Tizen.Uix.VoiceControlManager;
using static Interop.VoiceControlCommand;
using static Interop.VoiceControlManager;

internal static partial class Interop
{
    internal static partial class ControlCommandExpand
    {
        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_cmd_set_domain")]
        internal static extern ErrorCode VcCmdSetDomain(SafeCommandHandle vcCommand, int domain);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_cmd_get_domain")]
        internal static extern ErrorCode VcCmdGetDomain(SafeCommandHandle vcCommand, out int domain);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_cmd_list_remove_all")]
        internal static extern ErrorCode VcCmdListRemoveAll(SafeCommandListHandle vcCmdList, bool freeCommand);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_cmd_list_filter_by_type")]
        internal static extern ErrorCode VcCmdListFilterByType(SafeCommandListHandle original, CommandType type, out IntPtr filtered);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_cmd_set_pid")]
        internal static extern ErrorCode VcCmdSetPid(SafeCommandHandle vcCommand, int pid);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_cmd_get_pid")]
        internal static extern ErrorCode VcCmdGetPid(SafeCommandHandle vcCommand, out int pid);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_cmd_set_unfixed_command")]
        internal static extern ErrorCode VcCmdSetUnfixedCommand(SafeCommandHandle vcCommand, string command);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_cmd_get_nlu_json")]
        internal static extern ErrorCode VcCmdGetNluJson(SafeCommandHandle vcCmd, out string json);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_cmd_get_datetime")]
        internal static extern ErrorCode VcCmdGetDatetime(string text, out int result, out string remain);


    }
}

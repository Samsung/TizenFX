﻿/*
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
using System.Runtime.InteropServices;
using Tizen;
using Tizen.Uix.VoiceControl;

/// <summary>
/// Partial interop class.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// VoiceControlCommand interop class.
    /// </summary>
    internal static class VoiceControlCommand
    {
        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_list_create")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdListCreate(out SafeCommandListHandle cmdList);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_list_destroy")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdListDestroy(IntPtr cmdList, bool freeCommand);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_list_get_count")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdListGetCount(SafeCommandListHandle cmdList, out int count);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_list_add")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdListAdd(SafeCommandListHandle cmdList, SafeCommandHandle vcCommand);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_list_remove")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdListRemove(SafeCommandListHandle cmdList, SafeCommandHandle vcCommand);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_list_foreach_commands")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdListForeachCommands(SafeCommandListHandle cmdList, VcCmdListCb callback, IntPtr userData);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_list_first")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdListFirst(SafeCommandListHandle cmdList);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_list_last")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdListLast(SafeCommandListHandle cmdList);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_list_next")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdListNext(SafeCommandListHandle cmdList);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_list_prev")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdListPrev(SafeCommandListHandle cmdList);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_list_get_current")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdListGetCurrent(SafeCommandListHandle cmdList, out SafeCommandHandle vcCommand);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_create")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdCreate(out SafeCommandHandle vcCommand);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_destroy")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdDestroy(IntPtr vcCommand);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_set_command")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdSetCommand(SafeCommandHandle vcCommand, string command);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_get_command")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdGetCommand(SafeCommandHandle vcCommand, out string command);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_get_unfixed_command")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdGetUnfixedCommand(SafeCommandHandle vcCommand, out string command);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_set_type")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdSetType(SafeCommandHandle vcCommand, CommandType type);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_get_type")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdGetType(SafeCommandHandle vcCommand, out int type);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_set_format")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdSetFormat(SafeCommandHandle vcCommand, CommandFormat format);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_cmd_get_format")]
        internal static extern Interop.VoiceControl.ErrorCode VcCmdGetFormat(SafeCommandHandle vcCommand, out CommandFormat format);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool VcCmdListCb(IntPtr vcCommand, IntPtr userData);

        internal sealed class SafeCommandListHandle : SafeHandle
        {
            internal bool _ownership;

            public SafeCommandListHandle(IntPtr handle)
                : base(handle, true)
            {
                _ownership = true;
            }

            public SafeCommandListHandle()
                : base(IntPtr.Zero, true)
            {
                _ownership = true;
            }

            public override bool IsInvalid
            {
                get { return this.handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                if (_ownership && !IsInvalid)
                {
                    Interop.VoiceControl.ErrorCode error = VcCmdListDestroy(this.handle, false);
                    if (error != Interop.VoiceControl.ErrorCode.None)
                    {
                        Log.Error(VoiceControl.LogTag, "Destroy Failed with error " + error);
                    }
                }
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }

        internal sealed class SafeCommandHandle : SafeHandle
        {
            internal bool _ownership;

            public SafeCommandHandle(IntPtr handle)
                : base(handle, true)
            {
                _ownership = true;
            }

            public SafeCommandHandle()
                : base(IntPtr.Zero, true)
            {
                _ownership = true;
            }

            public override bool IsInvalid
            {
                get { return this.handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                Interop.VoiceControl.ErrorCode error = VoiceControl.ErrorCode.None;
                if (_ownership && !IsInvalid)
                {
                    error = VcCmdDestroy(this.handle);
                    if (error != Interop.VoiceControl.ErrorCode.None)
                    {
                        Log.Error(VoiceControl.LogTag, "Destroy Failed with error " + error);
                    }
                }
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }
    }
}
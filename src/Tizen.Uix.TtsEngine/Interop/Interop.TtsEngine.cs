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
using System.Runtime.InteropServices;
using Tizen.Internals;
using Tizen.Uix.TtsEngine;
using static Tizen.Uix.TtsEngine.Engine;

/// <summary>
/// The Partial Interop class.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// The TtsEngine Interop class.
    /// </summary>
    internal static class TtsEngine
    {
        internal const string LogTag = "Tizen.Uix.TtsEngine";

        private const int ErrorTts = -0x02F10000;

        public enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,                           /* Successful */
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,             /* Out of Memory */
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,                     /* I/O error */
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,   /* Invalid parameter */
            NetworkDown = Tizen.Internals.Errors.ErrorCode.Networkdown,             /* Network down(Out of network) */
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,   /* Permission denied */
            InvalidState = ErrorTts | 0x01,                                         /* Invalid state */
            InvalidVoice = ErrorTts | 0x02,                                         /* Invalid voice */
            OperationFailed = ErrorTts | 0x04,                                      /* Operation failed  */
            NotSupportedFeature = ErrorTts | 0x06,                                  /* Not supported feature of current engine */
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,           /* Device or resource busy */
        };

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error InitializeCb();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error DeinitializeCb();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error ForEachSupportedVoicesCb(SupportedVoice cb, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error IsValidVoiceCb(string language, int type, out byte isValid);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error SetPitchCb(int pitch);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error LoadVoiceCb(string langauge, int type);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error UnloadVoiceCb(string language, int type);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error CheckAppAgreedCb(string appid, out byte isAgreed);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool NeedAppCredentialCb();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error StartSynthesisCb(string language, int type, string text, int speed, string appid, string credential, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error CancelSynthesisCb();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error GetInfoCb(out string engineUuid, out string engineName, out string engineSetting, out byte useNetwork);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error PrivateDataSetCb(string key, string data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error PrivateDataRequestedCb(string key, out string data);

        [NativeStruct("ttse_request_callback_s", Include="ttse.h", PkgConfig="tts-engine")]
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        internal struct RequestCallbackStruct
        {
            internal int version;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal GetInfoCb getInfo;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal InitializeCb initialize;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal DeinitializeCb deinitialize;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal ForEachSupportedVoicesCb supportedVoice;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal IsValidVoiceCb validVoice;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal SetPitchCb pitch;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal LoadVoiceCb loadVoice;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal UnloadVoiceCb unloadVoice;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal StartSynthesisCb startSynthesis;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal CancelSynthesisCb cancelSynthesis;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal CheckAppAgreedCb checkAppAgreed;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal NeedAppCredentialCb needAppCredential;
        };

        internal sealed class CallbackStructGCHandle : IDisposable
        {
            internal RequestCallbackStruct CallbackStruct;
            internal GCHandle CallbackStructHandle;
            public CallbackStructGCHandle()
            {
                CallbackStruct = new RequestCallbackStruct();
                CallbackStructHandle = GCHandle.Alloc(CallbackStruct);
            }

            #region IDisposable Support
            private bool disposedValue = false;

            void Dispose(bool disposing)
            {
                Tizen.Log.Info(LogTag, "In Dispose");
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        Tizen.Log.Info(LogTag, "In Dispose free called");
                        CallbackStructHandle.Free();
                    }

                    disposedValue = true;
                }
            }

            public void Dispose()
            {
                Dispose(true);
            }
            #endregion
        }

        [DllImport(Libraries.TtsEngine, EntryPoint = "ttse_main")]
        internal static extern Error TTSEMain(int argc, string[] argv, IntPtr callback);

        [DllImport(Libraries.TtsEngine, EntryPoint = "ttse_get_speed_range")]
        internal static extern Error TTSEGetSpeedRange(out int min, out int normal, out int max);

        [DllImport(Libraries.TtsEngine, EntryPoint = "ttse_get_pitch_range")]
        internal static extern Error TTSEGetPitchRange(out int min, out int normal, out int max);

        [DllImport(Libraries.TtsEngine, EntryPoint = "ttse_send_result")]
        internal static extern Error TTSESendResult(ResultEvent resultEvent, IntPtr data, int dataSize, AudioType audioType, int rate, IntPtr userData);

        [DllImport(Libraries.TtsEngine, EntryPoint = "ttse_send_error")]
        internal static extern Error TTSESendError(Error error, string msg);

        [DllImport(Libraries.TtsEngine, EntryPoint = "ttse_set_private_data_set_cb")]
        internal static extern Error TTSESetPrivateDataSetCb(PrivateDataSetCb callbackFunc);

        [DllImport(Libraries.TtsEngine, EntryPoint = "ttse_set_private_data_requested_cb")]
        internal static extern Error TTSESetPrivateDataRequestedCb(PrivateDataRequestedCb callbackFunc);
    }
}

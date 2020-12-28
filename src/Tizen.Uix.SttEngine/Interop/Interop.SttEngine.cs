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
using Tizen.Uix.SttEngine;
using static Tizen.Uix.SttEngine.Engine;

/// <summary>
/// The Partial Interop class.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// The SttEngine Interop class.
    /// </summary>
    internal static class SttEngine
    {
        internal const string LogTag = "Tizen.Uix.SttEngine";

        private const int ErrorStt = -0x02F00000;

        public enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,                           /* Successful */
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,             /* Out of Memory */
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,                     /* I/O error */
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,   /* Invalid parameter */
            NetworkDown = Tizen.Internals.Errors.ErrorCode.Networkdown,             /* Network down(Out of network) */
            InvalidState = ErrorStt | 0x01,                                         /* Invalid state */
            InvalidLanguage = ErrorStt | 0x02,                                      /* Invalid language */
            OperationFailed = ErrorStt | 0x04,                                      /* Operation failed  */
            NotSupportedFeature = ErrorStt | 0x05,                                  /* Not supported feature of current engine */
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,           /* Device or resource busy */
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,   /* Permission denied */
            RecordingTimedOut = ErrorStt | 0x06,                                    /* Recording timed out */
        };

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error InitializeCb();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error DeinitializeCb();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error ForEachSupportedLangsCb(SupportedLanguages cb, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error IsValidLanguageCb(string language, out byte isValid);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SupportSilenceDetectionCb();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error SupportRecognitionTypeCb(string type, out byte isSupported);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error GetRecordingFormatCb(out AudioType types, out int rate, out int channels);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error SetSilenceDetectionCb(bool isSet);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error CheckAppAgreedCb(string appid, out byte isAgreed);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool NeedAppCredentialCb();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error ForEachResultTimeCb(IntPtr timeInfo, ResultTime callback, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error StartCb(string language, string type, string appid, string credential, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error SetRecordingDataCb(string data, uint length);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error StopCb();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error CancelCb();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error GetInfoCb(out string engineUuid, out string engineName, out string engineSetting, out byte useNetwork);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error PrivateDataSetCb(string key, string data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate Error PrivateDataRequestedCb(string key, out string data);

        [NativeStruct("stte_request_callback_s", Include="stte.h", PkgConfig="stt-engine")]
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
            internal ForEachSupportedLangsCb supportedLanaguge;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal IsValidLanguageCb validLanaguage;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal SupportSilenceDetectionCb silence;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal SupportRecognitionTypeCb recognitionType;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal GetRecordingFormatCb recordingFormat;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal ForEachResultTimeCb resultTime;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal SetSilenceDetectionCb silenceDetection;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal StartCb start;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal SetRecordingDataCb recordingData;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal StopCb stop;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal CancelCb cancel;
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

        [DllImport(Libraries.SttEngine, EntryPoint = "stte_main")]
        internal static extern Error STTEMain(int argc, string[] argv, IntPtr callback);

        [DllImport(Libraries.SttEngine, EntryPoint = "stte_send_result")]
        internal static extern Error STTESendResult(ResultEvent resultEvent, string type, string[] result, int resultCount, string msg, IntPtr timeInfo, IntPtr userData);

        [DllImport(Libraries.SttEngine, EntryPoint = "stte_send_error")]
        internal static extern Error STTESendError(Error error, string msg);

        [DllImport(Libraries.SttEngine, EntryPoint = "stte_send_speech_status")]
        internal static extern Error STTESendSpeechStatus(SpeechStatus status, IntPtr userData);

        [DllImport(Libraries.SttEngine, EntryPoint = "stte_set_private_data_set_cb")]
        internal static extern Error STTESetPrivateDataSetCb(PrivateDataSetCb callbackFunc);

        [DllImport(Libraries.SttEngine, EntryPoint = "stte_set_private_data_requested_cb")]
        internal static extern Error STTESetPrivateDataRequestedCb(PrivateDataRequestedCb callbackFunc);
    }
}

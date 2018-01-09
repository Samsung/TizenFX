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
using static Interop.TtsEngine;

namespace Tizen.Uix.TtsEngine
{
    /// <summary>
    /// Enumeration for the audio types.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum AudioType
    {
        /// <summary>
        /// Signed 16-bit audio type.
        /// </summary>
        RawS16 = 0,
        /// <summary>
        /// Unsigned 8-bit audio type.
        /// </summary>
        RawU8,
        /// <summary>
        /// Maximum value.
        /// </summary>
        Max
    };

    /// <summary>
    /// Enumeration for the results.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum ResultEvent
    {
        /// <summary>
        /// Event when the voice synthesis fails.
        /// </summary>
        Fail = -1,
        /// <summary>
        /// Event when the sound data is the first data by the callback function.
        /// </summary>
        Start = 1,
        /// <summary>
        /// Event when the next sound data exists, not the first and the last.
        /// </summary>
        Continue = 2,
        /// <summary>
        /// Event when the sound data is the last data or the sound data is the only result.
        /// </summary>
        Finish = 3
    };

    /// <summary>
    /// Enumeration for the voice types.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum VoiceType
    {
        /// <summary>
        /// Male voice type.
        /// </summary>
        Male = 1,
        /// <summary>
        /// Female voice type.
        /// </summary>
        Female = 2,
        /// <summary>
        /// Child's voice type.
        /// </summary>
        Child = 3
    }

    /// <summary>
    /// Enumeration for the error values that can occur.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum Error
    {
        /// <summary>
        /// Successful, no error.
        /// </summary>
        None = ErrorCode.None,
        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory = ErrorCode.OutOfMemory,
        /// <summary>
        /// I/O error.
        /// </summary>
        IoError = ErrorCode.IoError,
        /// <summary>
        /// Invalid parameter.
        /// </summary>
        InvalidParameter = ErrorCode.InvalidParameter,
        /// <summary>
        /// Network down (Out of network).
        /// </summary>
        NetworkDown = ErrorCode.NetworkDown,
        /// <summary>
        /// Invalid state.
        /// </summary>
        InvalidState = ErrorCode.InvalidState,
        /// <summary>
        /// Invalid voice.
        /// </summary>
        InvalidVoice = ErrorCode.InvalidVoice,
        /// <summary>
        /// Operation failed.
        /// </summary>
        OperationFailed = ErrorCode.OperationFailed,
        /// <summary>
        /// Not supported feature of the current engine.
        /// </summary>
        NotSupportedFeature = ErrorCode.NotSupportedFeature,
        /// <summary>
        /// Not supported.
        /// </summary>
        NotSupported = ErrorCode.NotSupported,
        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied = ErrorCode.PermissionDenied
    };

    /// <summary>
    /// This class represents the TTS engine, which has to be inherited to make the engine.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public abstract class Engine
    {
        private CallbackStructGCHandle _callbackStructGCHandle = new CallbackStructGCHandle();
        private PrivateDataSetCb _privateDataSetCb;
        private Action<string> _privateDatacallback;
        private PrivateDataRequestedCb _privateDataRequestedCb;
        private OutAction<string> _privateDataRequestedCallback;
        private static Engine _engine;
        private IntPtr _structIntPtrHandle;

        /// <summary>
        /// An action with 2 input parameters returning an error.
        /// </summary>
        /// <typeparam name="T">Generic type for parameter 1.</typeparam>
        /// <param name="a">The input parameter 1.</param>
        /// <param name="b">The input parameter 2.</param>
        /// <returns>Error value.</returns>
        /// <since_tizen> 4 </since_tizen>
        public delegate Error Action<T>(T a, T b);

        /// <summary>
        /// An action with 2 out parameters returning an error.
        /// </summary>
        /// <typeparam name="T">Generic type for parameter 1.</typeparam>
        /// <param name="a">The input parameter 1.</param>
        /// <param name="b">The input parameter 2.</param>
        /// <returns>Error value.</returns>
        /// <since_tizen> 4 </since_tizen>
        public delegate Error OutAction<T>(T a, out T b);

        /// <summary>
        /// Called when the TTS engine informs the engine service user about whole supported language and voice type list.
        /// This callback function is implemented by the engine service user, therefore, the engine developer does NOT have to implement this callback function. 
        /// </summary>
        /// <remarks>
        /// This callback function is called by ForEachSupportedVoices() to inform the whole supported voice list. userData must be transferred from ForEachSupportedVoices().
        /// </remarks>
        /// <param name="language">The language is specified as an ISO 3166 alpha-2 two-letter country code followed by an ISO 639-1 for the two-letter language code.
        /// For example, "ko_KR" for Korean, "en_US" for American English.</param>
        /// <param name="type">The voice type.</param>
        /// <param name="userData">The user data passed from ForEachSupportedVoices().</param>
        /// <returns>true to continue with the next iteration of the loop, false to break out of the loop.</returns>
        /// <precondition>ForEachSupportedVoices() will invoke this callback function.</precondition>
        /// <since_tizen> 4 </since_tizen>
        public delegate bool SupportedVoice(string language, VoiceType type, IntPtr userData);

        /// <summary>
        /// Called when the engine service user starts to synthesize a voice, asynchronously.
        /// </summary>
        /// <remarks>
        /// In this callback function, the TTS engine must transfer the synthesized result to the engine service user using SendResult().
        /// Also, if the TTS engine needs the application's credential, it can set the credential granted to the application.
        /// </remarks>
        /// <param name="language">The language is specified as an ISO 3166 alpha-2 two-letter country code followed by an ISO 639-1 for the two-letter language code.
        /// For example, "ko_KR" for Korean, "en_US" for American English.</param>
        /// <param name="type">The voice type.</param>
        /// <param name="text">Texts.</param>
        /// <param name="speed">The speed of speaking.</param>
        /// <param name="appid">The application ID.</param>
        /// <param name="credential">The credential granted to the application.</param>
        /// <param name="userData">The user data which must be passed to the SendResult() function.</param>
        /// <returns>
        /// The following error codes can be returned:
        /// 1. None
        /// 2. InvalidState
        /// 3. InvalidParameter
        /// 4. InvalidVoice
        /// 5. OperationFailed
        /// 6. NetworkDown
        /// 7. PermissionDenied
        /// </returns>
        /// <postcondition>This function invokes SendResult().</postcondition>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error StartSynthesis(string language, int type, string text, int speed, string appid, string credential, IntPtr userData);

        /// <summary>
        /// Called when the engine service user requests the basic information of the TTS engine.
        /// </summary>
        /// <remarks>
        /// The allocated engineUuid, engineName, and engineSetting will be released internally.
        /// In order to upload the engine at Tizen Appstore, both a service application and a UI application are necessary.
        /// Therefore, engineSetting must be transferred to the engine service user.
        /// </remarks>
        /// <param name="engineUuid">UUID of the engine.</param>
        /// <param name="engineName">Name of the engine.</param>
        /// <param name="engineSetting">The engine setting application (UI application)'s ID.</param>
        /// <param name="useNetwork">The status for using the network.</param>
        /// <returns>
        /// The following error codes can be returned:
        /// 1. None
        /// 2. InvalidState
        /// </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error GetInformation(out string engineUuid, out string engineName, out string engineSetting, out bool useNetwork);

        /// <summary>
        /// Called when the engine service user initializes the TTS engine.
        /// </summary>
        /// <returns>
        /// The following error codes can be returned:
        /// 1. None
        /// 2. InvalidState
        /// 3. NotSupportedFeature
        /// 4. PermissionDenied
        /// </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error Initialize();

        /// <summary>
        /// Called when the engine service user deinitializes the TTS engine.
        /// </summary>
        /// <remarks>
        /// NOTE that the engine may be terminated automatically. When this callback function is invoked, the release of the resources is necessary.
        /// </remarks>
        /// <returns>
        /// The following error codes can be returned:
        /// 1. None
        /// 2. InvalidState
        /// </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error Deinitialize();

        /// <summary>
        /// Called when the engine service user gets the whole supported voice list.
        /// </summary>
        /// <remarks>
        /// In this function, the engine service user's callback function 'SupportedVoice()' is invoked repeatedly for getting all the supported voices,
        /// and userData must be transferred to 'SupportedVoice()'. If 'SupportedVoice()' returns false, it should be stopped to call 'SupportedVoice()'.</remarks>
        /// <param name="callback">The callback function.</param>
        /// <param name="userData">The user data which must be passed to SupportedVoice().</param>
        /// <returns>
        /// The following error codes can be returned:
        /// 1. None
        /// 2. OperationFailed
        /// </returns>
        /// <postcondition>This callback function invokes SupportedVoice() repeatedly for getting all the supported voices.</postcondition>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error ForEachSupportedVoices(SupportedVoice callback, IntPtr userData);

        /// <summary>
        /// Called when the engine service user checks whether the voice is valid or not in the TTS engine.
        /// </summary>
        /// <param name="language">The language is specified as an ISO 3166 alpha-2 two-letter country code followed by an ISO 639-1 for the two-letter language code.
        /// For example, "ko_KR" for Korean, "en_US" for American English.</param>
        /// <param name="type">The voice type.</param>
        /// <param name="isValid">A variable for checking whether the corresponding voice is valid or not. true to be valid, false to be invalid.</param>
        /// <returns>
        /// The following error codes can be returned:
        /// 1. None
        /// 2. InvalidParameter
        /// </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error IsValidVoice(string language, int type, out bool isValid);

        /// <summary>
        /// Called when the engine service user sets the default pitch of the TTS engine.
        /// </summary>
        /// <param name="pitch">The default pitch.</param>
        /// <returns>
        /// The following error codes can be returned:
        /// 1. None
        /// 2. InvalidState
        /// 3. OperationFailed
        /// 4. InvalidParameter
        /// </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error SetPitch(int pitch);

        /// <summary>
        /// Called when the engine service user requests to load the corresponding voice type for the first time.
        /// </summary>
        /// <param name="language">The language is specified as an ISO 3166 alpha-2 two-letter country code followed by an ISO 639-1 for the two-letter language code.
        /// For example, "ko_KR" for Korean, "en_US" for American English.</param>
        /// <param name="type">The voice type.</param>
        /// <returns>
        /// The following error codes can be returned:
        /// 1. None
        /// 2. InvalidState
        /// 3. OperationFailed
        /// 4. InvalidVoice
        /// 5. InvalidParameter
        /// 6. OutOfMemory
        /// </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error LoadVoice(string language, int type);

        /// <summary>
        /// Called when the engine service user requests to unload the corresponding voice type or to stop using voice.
        /// </summary>
        /// <param name="language">The language is specified as an ISO 3166 alpha-2 two-letter country code followed by an ISO 639-1 for the two-letter language code.
        /// For example, "ko_KR" for Korean, "en_US" for American English.</param>
        /// <param name="type">The voice type.</param>
        /// <returns>
        /// The following error codes can be returned:
        /// 1. None
        /// 2. InvalidState
        /// 3. OperationFailed
        /// 4. InvalidVoice
        /// 5. InvalidParameter
        /// </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error UnloadVoice(string language, int type);

        /// <summary>
        /// Called when the engine service user requests for the TTS engine to check whether the application agreed the usage of the TTS engine.
        /// This callback function is called when the engine service user requests for the TTS engine to check the application's agreement about using the the engine.
        /// According to the need, the engine developer can provide some user interfaces to check the agreement.
        /// </summary>
        /// <remarks>
        /// If the TTS engine developer does not want to check the agreement, the developer needs to return proper values as isAgreed in accordance with the intention.
        /// true if the developer regards that every application agreed the usage of the engine, false if the developer regards that every application disagreed.
        /// NOTE that, however, there may be any legal issue unless the developer checks the agreement.
        /// Therefore, we suggest that the engine developers should provide a function to check the agreement.
        /// </remarks>
        /// <param name="appid">The application ID.</param>
        /// <param name="isAgreed">A variable for checking whether the application agreed to use the TTS engine or not. true to agree, false to disagree.</param>
        /// <returns>
        /// The following error codes can be returned:
        /// 1. None
        /// 2. InvalidState
        /// 3. NotSupportedFeature
        /// 4. InvalidParameter
        /// </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error CheckAppAgreed(string appid, out bool isAgreed);

        /// <summary>
        /// Called when the engine service user checks whether the TTS engine needs the application's credentials.
        /// </summary>
        /// <returns>true if TTS engine needs the application's credentials, otherwise false. </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract bool NeedAppCredential();

        /// <summary>
        /// Called when the engine service user cancels to synthesize a voice.
        /// </summary>
        /// <returns>
        /// The following error codes can be returned:
        /// 1. None
        /// 2. InvalidState
        /// </returns>
        /// <precondition>
        /// StartSynthesis should be performed.
        /// </precondition>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error CancelSynthesis();

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <since_tizen> 4 </since_tizen>
        public Engine()
        {
            _engine = this;
        }

        /// <summary>
        /// Main function for the Text-To-Speech (TTS) engine.
        /// This function is the main function for operating the TTS engine.
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <remarks>
        /// ServiceAppMain should be used for working the engine after this function.
        /// </remarks>
        /// <param name="argc">The argument count (original).</param>
        /// <param name="argv">The argument (original).</param>
        /// <exception cref="NotSupportedException">Thrown in case of not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of operation failure.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void EngineMain(int argc, string[] argv)
        {
            _callbackStructGCHandle.CallbackStruct.version = 1;
            _callbackStructGCHandle.CallbackStruct.getInfo = _getInfoCb;
            _callbackStructGCHandle.CallbackStruct.initialize = Initialize;
            _callbackStructGCHandle.CallbackStruct.deinitialize = _deinitializeCb;
            _callbackStructGCHandle.CallbackStruct.supportedVoice = ForEachSupportedVoices;
            _callbackStructGCHandle.CallbackStruct.validVoice = IsValidVoice;
            _callbackStructGCHandle.CallbackStruct.pitch = SetPitch;
            _callbackStructGCHandle.CallbackStruct.loadVoice = LoadVoice;
            _callbackStructGCHandle.CallbackStruct.unloadVoice = UnloadVoice;
            _callbackStructGCHandle.CallbackStruct.startSynthesis = _startSynthesisCb;
            _callbackStructGCHandle.CallbackStruct.cancelSynthesis = CancelSynthesis;
            _callbackStructGCHandle.CallbackStruct.checkAppAgreed = CheckAppAgreed;
            _callbackStructGCHandle.CallbackStruct.needAppCredential = NeedAppCredential;
            _structIntPtrHandle = Marshal.AllocHGlobal(Marshal.SizeOf(_callbackStructGCHandle.CallbackStruct));
            Marshal.StructureToPtr<RequestCallbackStruct>(_callbackStructGCHandle.CallbackStruct, _structIntPtrHandle, false);
            Error error = TTSEMain(argc, argv, _structIntPtrHandle);
            if (error != Error.None)
            {
                Log.Error(LogTag, "TTSEMain Failed with error " + error);
                throw ExceptionFactory.CreateException((ErrorCode)error);
            }

            Log.Info(LogTag, "After TTSEMain");
        }

        /// <summary>
        /// Gets the speed range from the Tizen platform.
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <remarks>
        /// This API is used when the TTS engine wants to get the speed range from the Tizen platform.
        /// </remarks>
        /// <param name="min">The minimum speed value.</param>
        /// <param name="normal">The normal speed value.</param>
        /// <param name="max">The maximum speed value.</param>
        /// <exception cref="NotSupportedException">Thrown in case of not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of operation failure.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void GetSpeedRange(out int min, out int normal, out int max)
        {
            Error error = TTSEGetSpeedRange(out min, out normal, out max);
            if (error != Error.None)
            {
                Log.Error(LogTag, "TTSEGetSpeedRange Failed with error " + error);
                throw ExceptionFactory.CreateException((ErrorCode)error);
            }

        }

        /// <summary>
        /// Gets the pitch range from the Tizen platform.
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <remarks>
        /// This API is used when the TTS engine wants to get the pitch range from the Tizen platform.
        /// </remarks>
        /// <param name="min">The minimum pitch value.</param>
        /// <param name="normal">The normal pitch value.</param>
        /// <param name="max">The maximum pitch value.</param>
        /// <exception cref="NotSupportedException">Thrown in case of not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of operation failure.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void GetPitchRange(out int min, out int normal, out int max)
        {
            Error error = TTSEGetPitchRange(out min, out normal, out max);
            if (error != Error.None)
            {
                Log.Error(LogTag, "TTSEGetPitchRange Failed with error " + error);
                throw ExceptionFactory.CreateException((ErrorCode)error);
            }

        }

        /// <summary>
        /// Sends the synthesized result to the engine service user.
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <remarks>
        /// This API is used in StartSynthesis(), when the TTS engine sends the synthesized result to the engine service user.
        /// The synthesized result must be transferred to the engine service user through this function.
        /// </remarks>
        /// <param name="resultEvent">The result event.</param>
        /// <param name="data">The result data.</param>
        /// <param name="dataSize">The result data size.</param>
        /// <param name="audioType">The audio type.</param>
        /// <param name="rate">The sample rate.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown in case of not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of operation failure.</exception>
        /// <precondition>
        /// EngineMain function should be invoked before this function is called. StartSynthesis() will invoke this function.
        /// </precondition>
        /// <since_tizen> 4 </since_tizen>
        public void SendResult(ResultEvent resultEvent, IntPtr data, int dataSize, AudioType audioType, int rate)
        {
            Error error = TTSESendResult(resultEvent, data, dataSize, audioType, rate, IntPtr.Zero);
            if (error != Error.None)
            {
                Log.Error(LogTag, "TTSESendResult Failed with error " + error);
                throw ExceptionFactory.CreateException((ErrorCode)error);
            }
        }

        /// <summary>
        /// Sends the error to the engine service user.
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <param name="error">The error reason.</param>
        /// <param name="msg">The error message.</param>
        /// <exception cref="NotSupportedException">Thrown in case of not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of operation failure.</exception>
        /// <precondition>
        /// EngineMain function should be invoked before this function is called.
        /// </precondition>
        /// <since_tizen> 4 </since_tizen>
        public void SendError(Error error, string msg)
        {
            Error err = TTSESendError(error, msg);
            if (err != Error.None)
            {
                Log.Error(LogTag, "SendError Failed with error " + err);
                throw ExceptionFactory.CreateException((ErrorCode)error);
            }

        }

        /// <summary>
        /// Sets a callback function for setting the private data.
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <param name="callback">
        /// Called when the engine service user gets the private data from the TTS engine.
        /// In parameters:
        /// a = Key -- The key field of private data.
        /// b = data -- The data field of private data.
        /// The following error codes can be returned:
        /// 1. None
        /// 2. InvalidParameter
        /// 3. OperationFailed
        /// 4. NotSupported
        /// </param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown in case of not supported.</exception>
        /// <exception cref="InvalidOperationException">thrown in case of operation failure.</exception>
        /// <precondition>
        /// Main function should be invoked before this function is called.
        /// </precondition>
        /// <since_tizen> 4 </since_tizen>
        public void SetPrivateDataSetDelegate(Action<string> callback)
        {
            if (null == callback)
            {
                Log.Error(LogTag, "callback is null");
                throw ExceptionFactory.CreateException(ErrorCode.InvalidParameter);
            }

            _privateDatacallback = callback;
            _privateDataSetCb = (string key, string data) =>
            {
                return _privateDatacallback.Invoke(key, data);
            };
            Error error = TTSESetPrivateDataSetCb(_privateDataSetCb);
            if (error != Error.None)
            {
                Log.Error(LogTag, "SetPrivateDataSetDelegate Failed with error " + error);
                throw ExceptionFactory.CreateException((ErrorCode)error);
            }

        }

        /// <summary>
        /// Sets a callback function for setting the private data.
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <param name="callback">The callback function.
        /// Called when the TTS engine receives the private data from the engine service user.
        /// This callback function is called when the engine service user sends the private data to the TTS engine.
        /// Out parameters:
        /// a = Key -- The key field of private data.
        /// b = data -- The data field of private data.
        /// The following error codes can be returned:
        /// 1. None
        /// 2. InvalidParameter
        /// 3. OperationFailed
        /// 4. NotSupported
        /// </param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown in case of not supported.</exception>
        /// <exception cref="InvalidOperationException">thrown in case of operation failure.</exception>
        /// <precondition>
        /// Main function should be invoked before this function is called.
        /// </precondition>
        /// <since_tizen> 4 </since_tizen>
        public void SetPrivateDataRequestedDelegate(OutAction<string> callback)
        {
            if (null == callback)
            {
                Log.Error(LogTag, "callback is null");
                throw ExceptionFactory.CreateException(ErrorCode.InvalidParameter);
            }

            _privateDataRequestedCallback = callback;
            _privateDataRequestedCb = (string key, out string data) =>
            {
                return _privateDataRequestedCallback.Invoke(key, out data);
            };
            Error error = TTSESetPrivateDataRequestedCb(_privateDataRequestedCb);
            if (error != Error.None)
            {
                Log.Error(LogTag, "SetPrivateDataRequestedDelegate Failed with error " + error);
                throw ExceptionFactory.CreateException((ErrorCode)error);
            }

        }
        private StartSynthesisCb _startSynthesisCb = (IntPtr language, int type, IntPtr text, int speed, IntPtr appid, IntPtr credential, IntPtr userData) =>
        {
            string lan = null;
            string txt = null;
            string apid = null;
            string cre = null;
            if (language != null)
                lan = Marshal.PtrToStringAnsi(language);
            if (text != null)
                txt = Marshal.PtrToStringAnsi(text);
            if (appid != null)
                apid = Marshal.PtrToStringAnsi(appid);
            if (credential != null)
                cre = Marshal.PtrToStringAnsi(credential);
            return _engine.StartSynthesis(lan, type, txt, speed, apid, cre, IntPtr.Zero);
        };

        private GetInfoCb _getInfoCb = (out IntPtr engineUuid, out IntPtr engineName, out IntPtr engineSetting, out int useNetwork) =>
        {
            string uuid;
            string name;
            string setting;
            bool network;
            Error err = _engine.GetInformation(out uuid, out name, out setting, out network);
            if (network == true)
            {
                useNetwork = 1;
            }
            else
            {
                useNetwork = 0;
            }
            engineUuid = Marshal.StringToHGlobalAnsi(uuid);
            engineName = Marshal.StringToHGlobalAnsi(name);
            engineSetting = Marshal.StringToHGlobalAnsi(setting);
            return err;
        };

        private DeinitializeCb _deinitializeCb = () =>
        {
            Marshal.FreeHGlobal(_engine._structIntPtrHandle);
            return _engine.Deinitialize();
        };
    }
}
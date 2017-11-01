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
using static Interop.SttEngine;

namespace Tizen.Uix.SttEngine
{
    /// <summary>
    /// Enumeration for audio type.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum AudioType
    {
        /// <summary>
        /// Signed 16bit audio type, Little endian
        /// </summary>
        PcmS16Le = 0,
        /// <summary>
        /// Unsigned 8bit audio type
        /// </summary>
        PcmU8
    };

    /// <summary>
    /// Enumeration for result.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum ResultEvent
    {
        /// <summary>
        /// Event when either the full matched or the final result is delivered
        /// </summary>
        FinalResult = 0,
        /// <summary>
        /// Event when the partial matched result is delivered
        /// </summary>
        PartialResult,
        /// <summary>
        /// Event when the recognition has failed
        /// </summary>
        Error
    };

    /// <summary>
    /// Enumeration for result time.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum TimeEvent
    {
        /// <summary>
        /// Event when the token is beginning type
        /// </summary>
        Beginning = 0,
        /// <summary>
        /// Event when the token is middle type
        /// </summary>
        Middle = 1,
        /// <summary>
        /// Event when the token is end type
        /// </summary>
        End = 2
    };

    /// <summary>
    /// Enumeration for speech status.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum SpeechStatus
    {
        /// <summary>
        /// Beginning point of speech is detected
        /// </summary>
        BeginningPointDetected = 0,
        /// <summary>
        /// End point of speech is detected
        /// </summary>
        EndPointDetected
    };

    /// <summary>
    /// Enumeration representing the result message
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum ResultMessage
    {
        /// <summary>
        /// No Error
        /// </summary>
        None,
        /// <summary>
        /// Recognition failed  because the speech started too soon.
        /// </summary>
        TooSoon,
        /// <summary>
        /// Recognition failed  because the speech is too short.
        /// </summary>
        TooShort,
        /// <summary>
        /// Recognition failed  because the speech is too long.
        /// </summary>
        TooLong,
        /// <summary>
        /// Recognition failed  because the speech is too quiet to listen.
        /// </summary>
        TooQuiet,
        /// <summary>
        /// Recognition failed  because the speech is too loud to listen.
        /// </summary>
        TooLoud,
        /// <summary>
        /// Recognition failed  because the speech is too fast to listen.
        /// </summary>
        TooFast
    };


    /// <summary>
    /// Enum for Error values that can occur
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum Error
    {
        /// <summary>
        /// Successful, No error
        /// </summary>
        None = ErrorCode.None,
        /// <summary>
        /// Out of Memory
        /// </summary>
        OutOfMemory = ErrorCode.OutOfMemory,
        /// <summary>
        /// I/O error
        /// </summary>
        IoError = ErrorCode.IoError,
        /// <summary>
        /// Invalid parameter
        /// </summary>
        InvalidParameter = ErrorCode.InvalidParameter,
        /// <summary>
        /// Network down(Out of network)
        /// </summary>
        NetworkDown = ErrorCode.NetworkDown,
        /// <summary>
        /// Invalid state
        /// </summary>
        InvalidState = ErrorCode.InvalidState,
        /// <summary>
        /// Invalid language
        /// </summary>
        InvalidLanguage = ErrorCode.InvalidLanguage,
        /// <summary>
        /// Operation failed
        /// </summary>
        OperationFailed = ErrorCode.OperationFailed,
        /// <summary>
        /// Not supported feature of current engine
        /// </summary>
        NotSupportedFeature = ErrorCode.NotSupportedFeature,
        /// <summary>
        /// NOT supported
        /// </summary>
        NotSupported = ErrorCode.NotSupported,
        /// <summary>
        /// Permission denied
        /// </summary>
        PermissionDenied = ErrorCode.PermissionDenied,
        /// <summary>
        /// Recording timed out
        /// </summary>
        RecordingTimedOut = ErrorCode.RecordingTimedOut
    };

    /// <summary>
    /// This Class represents the Stt Engine which has to be inherited to make the engine.
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
        /// An Action with 2 Input Parameter returning a Error
        /// </summary>
        /// <typeparam name="T">Generic Type for Parameter 1</typeparam>
        /// <param name="a">The Input Parameter 1</param>
        /// <param name="b">The Input Parameter 2</param>
        /// <returns>Error Value</returns>
        /// <since_tizen> 4 </since_tizen>
        public delegate Error Action<T>(T a, T b);

        /// <summary>
        /// An Action with 2 Out Parameter returning a Error
        /// </summary>
        /// <typeparam name="T">Generic Type for Parameter 1</typeparam>
        /// <param name="a">The Input Parameter 1</param>
        /// <param name="b">The Input Parameter 2</param>
        /// <returns>Error Value</returns>
        /// <since_tizen> 4 </since_tizen>
        public delegate Error OutAction<T>(T a, out T b);

        /// <summary>
        /// Called when Stt engine provides the time stamp of result to the engine service user.
        /// This callback function is implemented by the engine service user. Therefore, the engine developer does NOT have to implement this callback function.
        /// </summary>
        /// <param name="index">The result index</param>
        /// <param name="resultEvent">The token event</param>
        /// <param name="text">The result text</param>
        /// <param name="startTime">The time started speaking the result text</param>
        /// <param name="endTime">The time finished speaking the result text</param>
        /// <param name="userData">The User data</param>
        /// <returns>true to continue with the next iteration of the loop, false to break out of the loop</returns>
        /// <precondition>SendResult() should be called.</precondition>
        /// <since_tizen> 4 </since_tizen>
        public delegate bool ResultTime(int index, TimeEvent resultEvent, string text, long startTime, long endTime, IntPtr userData);

        /// <summary>
        /// Called when Stt engine informs the engine service user about whole supported language list.
        /// This callback function is implemented by the engine service user. Therefore, the engine developer does NOT have to implement this callback function.
        /// </summary>
        /// <param name="language">The language is specified as an ISO 3166 alpha-2 two letter country-code
        /// followed by ISO 639-1 for the two-letter language code
        /// for example, "ko_KR" for Korean, "en_US" for American English</param>
        /// <param name="userData">The User data</param>
        /// <returns>true to continue with the next iteration of the loop, false to break out of the loop</returns>
        /// <precondition>ForEachSupportedLanguages() should be called</precondition>
        /// <since_tizen> 4 </since_tizen>
        public delegate bool SupportedLanguages(string language, IntPtr userData);

        /// <summary>
        /// Called when the engine service user requests the basic information of Stt engine.
        /// </summary>
        /// <remarks>
        /// In order to upload the engine at Tizen Appstore, both a service app and a ui app are necessary. Therefore, engineSetting must be transferred to the engine service user.
        /// </remarks>
        /// <param name="engineUuid">UUID of engine</param>
        /// <param name="engineName">Name of engine</param>
        /// <param name="engineSetting">The engine setting application(ui app)'s app ID</param>
        /// <param name="useNetwork">A variable for checking whether the network is used or not</param>
        /// <returns>
        /// Following Error Codes can be returned
        /// 1. None
        /// 2. OperationFailed
        /// 3. InvalidParameter
        /// </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error GetInformation(out string engineUuid, out string engineName, out string engineSetting, out bool useNetwork);

        /// <summary>
        /// Called when the engine service user initializes Stt engine.
        /// This callback function is called by the engine service user to request for Stt engine to be started.
        /// </summary>
        /// <returns>
        /// Following Error Codes can be returned
        /// 1. None
        /// 2. InvalidParameter
        /// 3. InvalidState
        /// 4. OperationFailed
        /// </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error Initialize();

        /// <summary>
        /// Called when the engine service user deinitializes Stt engine.
        /// This callback function is called by the engine service user to request for Stt engine to be deinitialized.
        /// </summary>
        /// <returns>
        /// Following Error Codes can be returned
        /// 1. None
        /// 2. InvalidState
        /// </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error Deinitialize();

        /// <summary>
        /// Called when the engine service user gets the whole supported language list.
        /// </summary>
        /// <remarks>
        /// In this function, the engine service user's callback function 'SupportedLanguages' is invoked repeatedly for getting all supported languages
        /// and user_data must be transferred to 'SupportedLanguages'. If 'SupportedLanguages' returns false, it should be stopped to call 'SupportedLanguages'.
        /// </remarks>
        /// <param name="callback">The callback function</param>
        /// <param name="userData">The user data which must be passed to the callback delegate 'SupportedLanguages'</param>
        /// <returns>
        /// Following Error Codes can be returned
        /// 1. None
        /// 2. InvalidState
        /// 3. InvalidParameter
        /// </returns>
        /// <postcondition>
        /// This callback function invokes SupportedLanguages repeatedly for getting supported languages.
        /// </postcondition>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error ForEachSupportedLanguages(SupportedLanguages callback, IntPtr userData);

        /// <summary>
        /// Called when the engine service user checks whether the corresponding language is valid or not in Stt engine.
        /// </summary>
        /// <param name="language">The language is specified as an ISO 3166 alpha-2 two letter country-code followed by ISO 639-1 for the two-letter language code
        /// For example, "ko_KR" for Korean, "en_US" for American English</param>
        /// <param name="isValid">A variable for checking whether the corresponding language is valid or not. true to be valid, false to be invalid</param>
        /// <returns>
        /// Following Error Codes can be returned
        /// 1. None
        /// 2. InvalidParameter
        /// </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error IsValidLanguage(string language, out bool isValid);

        /// <summary>
        /// Called when the engine service user checks whether Stt engine supports silence detection.
        /// </summary>
        /// <returns>true to support silence detection, false not to support silence detection</returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract bool SupportSilenceDetection();

        /// <summary>
        /// Called when the engine service user checks whether Stt engine supports the corresponding recognition type.
        /// </summary>
        /// <param name="type">The type for recognition, "stt.recognition.type.FREE" or "stt.recognition.type.FREE.PARTIAL"</param>
        /// <param name="isSupported">A variable for checking whether Stt engine supports the corresponding recognition type.
        /// true to support recognition type, false not to support recognition type</param>
        /// <returns>
        /// Following Error Codes can be returned
        /// 1. None
        /// 2. InvalidParameter
        /// </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error SupportRecognitionType(string type, out bool isSupported);

        /// <summary>
        /// Called when the engine service user gets the proper recording format of Stt engine.
        /// The recording format is used for creating the recorder.
        /// </summary>
        /// <param name="types">The format used by the recorder</param>
        /// <param name="rate">The sample rate used by the recorder</param>
        /// <param name="channels">The number of channels used by the recorder</param>
        /// <returns>
        /// Following Error Codes can be returned
        /// 1. None
        /// 2. InvalidState
        /// </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error GetRecordingFormat(out AudioType types, out int rate, out int channels);

        /// <summary>
        /// Called when the engine service user sets the silence detection.
        /// If the engine service user sets this option as 'TRUE', Stt engine will detect the silence (EPD) and send the callback event about it.
        /// </summary>
        /// <param name="isSet">A variable for setting the silence detection. true to detect the silence, false not to detect the silence</param>
        /// <returns>
        /// Following Error Codes can be returned
        /// 1. None
        /// 2. InvalidState
        /// 3. NotSupportedFeature
        /// </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error SetSilenceDetection(bool isSet);

        /// <summary>
        /// Called when the engine service user requests for Stt engine to check whether the application agreed the usage of Stt engine.
        /// This callback function is called when the engine service user requests for Stt engine to check the application's agreement about using the engine.
        /// According to the need, the engine developer can provide some user interfaces to check the agreement.
        /// </summary>
        /// <param name="appid">The Application ID</param>
        /// <param name="isAgreed">A variable for checking whether the application agreed to use Stt engine or not. true to agree, false to disagree</param>
        /// <returns>
        /// Following Error Codes can be returned
        /// 1. None
        /// 2. InvalidState
        /// 3. NotSupportedFeature
        /// </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error CheckAppAgreed(string appid, out bool isAgreed);

        /// <summary>
        /// Called when the engine service user checks whether Stt engine needs the application's credential.
        /// </summary>
        /// <returns>true if Stt engine needs the application's credential, otherwise false </returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract bool NeedAppCredential();

        /// <summary>
        /// Called when the engine service user gets the result time information(stamp).
        /// </summary>
        /// <remarks>
        /// In this function, the engine service user's callback delegate 'ResultTime' is invoked repeatedly for sending the time information to the engine service user
        /// and user_data must be transferred to 'ResultTime'. If 'ResultTime' returns false, it should be stopped to call 'ResultTime'.
        /// timeInfo is transferred from SendResult. The type of timeInfo is up to the Stt engine developer.
        /// </remarks>
        /// <param name="timeInfo">The time information</param>
        /// <param name="callback">The callback function</param>
        /// <param name="userData">The user data which must be passed to the callback function ResultTime</param>
        /// <returns>
        /// Following Error Codes can be returned
        /// 1. None
        /// 2. InvalidState
        /// 3. InvalidParameter
        /// </returns>
        /// <precondition>
        /// SendResult will invoke this function
        /// </precondition>
        /// <postcondition>
        /// This function invokes ResultTime repeatedly for getting result time information.
        /// </postcondition>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error ForEachResultTime(IntPtr timeInfo, ResultTime callback, IntPtr userData);

        /// <summary>
        /// Called when the engine service user starts to recognize the recording data.
        /// In this callback function, Stt engine must transfer the recognition result and userData to the engine service user using SendResult().
        /// Also, if Stt engine needs the application's credential, it sets the credential granted to the application.
        /// </summary>
        /// <param name="language">The language is specified as an ISO 3166 alpha-2 two letter country-code followed by ISO 639-1 for the two-letter language code
        /// For example, "ko_KR" for Korean, "en_US" for American English</param>
        /// <param name="type">The recognition type, "stt.recognition.type.FREE" or "stt.recognition.type.FREE.PARTIAL"</param>
        /// <param name="appid">The Application ID</param>
        /// <param name="credential">The credential granted to the application</param>
        /// <param name="userData">The user data to be passed to the callback function</param>
        /// <returns>
        /// Following Error Codes can be returned
        /// 1. None
        /// 2. InvalidState
        /// 3. InvalidParameter
        /// 4. InvalidLanguage
        /// 5. OperationFailed
        /// 6. NetworkDown
        /// </returns>
        /// <precondition>
        /// The engine is not in recognition processing.
        /// </precondition>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error Start(string language, string type, string appid, string credential, IntPtr userData);

        /// <summary>
        /// Called when the engine service user sets and sends the recording data for speech recognition.
        /// This callback function is called by the engine service user to send the recording data to Stt engine.The engine receives the recording data and uses for speech recognition. 
        /// this function should be returned immediately after recording data copy.
        /// </summary>
        /// <param name="data">The recording data</param>
        /// <param name="length">The length of recording data</param>
        /// <returns>
        /// Following Error Codes can be returned
        /// 1. None
        /// 2. InvalidState
        /// 3. InvalidParameter
        /// 4. OperationFailed
        /// </returns>
        /// <precondition>
        /// Start should succeed</precondition>
        /// <postcondition>
        /// If the engine supports partial result, SendResult() should be invoked.</postcondition>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error SetRecordingData(string data, uint length);

        /// <summary>
        /// Called when the engine service user stops to recognize the recording data.
        /// This callback function is called by the engine service user to stop recording and to get the recognition result.
        /// </summary>
        /// <returns>Following Error Codes can be returned
        /// 1. None
        /// 2. InvalidState
        /// 3. OperationFailed
        /// 4. NetworkDown
        /// </returns>
        /// <precondition>
        /// Start should succeed</precondition>
        /// <postcondition>
        /// After processing of the engine, , SendResult() should be invoked.</postcondition>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error Stop();

        /// <summary>
        /// Called when the engine service user cancels to recognize the recording data.
        /// This callback function is called by the engine service user to cancel to recognize the recording data.Also, when starting the recorder is failed, this function is called.
        /// </summary>
        /// <returns>
        /// Following Error Codes can be returned
        /// 1. None
        /// 2. InvalidState
        /// </returns>
        /// <precondition>Stt engine is in recognition processing or recording.</precondition>
        /// <since_tizen> 4 </since_tizen>
        public abstract Error Cancel();

        /// <summary>
        /// Public Constructor
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <since_tizen> 4 </since_tizen>
        public Engine()
        {
            _engine = this;
        }

        /// <summary>
        /// Main function for Speech-To-Text (STT) engine.
        /// This function is the main function for operating Stt engine.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <remarks>
        /// ServiceAppMain should be used for working the engine after this function.
        /// </remarks>
        /// <param name="argc">The Number of Arguments</param>
        /// <param name="argv">The Arguments Array</param>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of Permission denied</exception>
        /// <exception cref="NotSupportedException">Thrown in case of Not supported</exception>
        /// <exception cref="InvalidOperationException">thrown in case of Operation failure</exception>
        /// <since_tizen> 4 </since_tizen>
        public void EngineMain(int argc, string[] argv)
        {
            _callbackStructGCHandle.CallbackStruct.version = 1;
            _callbackStructGCHandle.CallbackStruct.getInfo = _getInfoCb;
            _callbackStructGCHandle.CallbackStruct.initialize = Initialize;
            _callbackStructGCHandle.CallbackStruct.deinitialize = _deinitializeCb;
            _callbackStructGCHandle.CallbackStruct.supportedLanaguge = ForEachSupportedLanguages;
            _callbackStructGCHandle.CallbackStruct.validLanaguage = _isValidLanguageCb;
            _callbackStructGCHandle.CallbackStruct.silence = SupportSilenceDetection;
            _callbackStructGCHandle.CallbackStruct.recognitionType = SupportRecognitionType;
            _callbackStructGCHandle.CallbackStruct.recordingFormat = GetRecordingFormat;
            _callbackStructGCHandle.CallbackStruct.resultTime = ForEachResultTime;
            _callbackStructGCHandle.CallbackStruct.silenceDetection = SetSilenceDetection;
            _callbackStructGCHandle.CallbackStruct.start = _startCb;
            _callbackStructGCHandle.CallbackStruct.recordingData = SetRecordingData;
            _callbackStructGCHandle.CallbackStruct.stop = Stop;
            _callbackStructGCHandle.CallbackStruct.cancel = Cancel;
            _callbackStructGCHandle.CallbackStruct.checkAppAgreed = CheckAppAgreed;
            _callbackStructGCHandle.CallbackStruct.needAppCredential = NeedAppCredential;
            _structIntPtrHandle = Marshal.AllocHGlobal(Marshal.SizeOf(_callbackStructGCHandle.CallbackStruct));
            Marshal.StructureToPtr<RequestCallbackStruct>(_callbackStructGCHandle.CallbackStruct, _structIntPtrHandle, false);
            Error error = STTEMain(argc, argv, _structIntPtrHandle);
            if (error != Error.None)
            {
                Log.Error(LogTag, "STTEMain Failed with error " + error);
                throw ExceptionFactory.CreateException((ErrorCode)error);
            }

            Log.Info(LogTag, "After STTEMain");
        }

        /// <summary>
        /// Sends the recognition result to the engine service user.
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <remarks>
        /// This API is used in SetRecordingData() and Stop(), when Stt engine sends the recognition result to the engine service user.
        /// This function is called in the following situations; 1) after Stop() is called, 2) the end point of speech is detected from recording, or 3) partial result is occurred.
        /// The recognition result must be transferred to the engine service user through this function. Also, timeInfo must be transferred to ForEachResultTime().
        /// The type of timeInfo is up to the Stt engine developer.
        /// </remarks>
        /// <param name="resultEvent">The result event</param>
        /// <param name="type">The recognition type, "stt.recognition.type.FREE" or "stt.recognition.type.FREE.PARTIAL"</param>
        /// <param name="result">Result texts</param>
        /// <param name="resultCount">Result text count</param>
        /// <param name="msg">Engine message</param>
        /// <param name="timeInfo">The time information</param>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of Permission denied</exception>
        /// <exception cref="NotSupportedException">Thrown in case of Not supported</exception>
        /// <exception cref="InvalidOperationException">thrown in case of Operation failure</exception>
        /// <precondition>
        /// EngineMain function should be invoked before this function is called. Stop will invoke this function.
        /// </precondition>
        /// <postcondition>
        /// This function invokes ForEachResultTime
        /// </postcondition>
        /// <since_tizen> 4 </since_tizen>
        public void SendResult(ResultEvent resultEvent, string type, string[] result, int resultCount, ResultMessage msg, IntPtr timeInfo)
        {
            if ((result != null) && (result.Length != 0))
            {

                string message = "stt.result.message.none";
                switch (msg)
                {
                    case ResultMessage.None:
                    message = "stt.result.message.none";
                    break;

                    case ResultMessage.TooFast:
                    message = "stt.result.message.error.too.fast";
                    break;

                    case ResultMessage.TooLong:
                    message = "stt.result.message.error.too.long";
                    break;

                    case ResultMessage.TooLoud:
                    message = "stt.result.message.error.too.loud";
                    break;

                    case ResultMessage.TooQuiet:
                    message = "stt.result.message.error.too.quiet";
                    break;

                    case ResultMessage.TooShort:
                    message = "stt.result.message.error.too.short";
                    break;

                    case ResultMessage.TooSoon:
                    message = "stt.result.message.error.too.soon";
                    break;
                }

                Error error = STTESendResult(resultEvent, type, result, resultCount, message, timeInfo, IntPtr.Zero);
                if (error != Error.None)
                {
                    Log.Error(LogTag, "STTESendResult Failed with error " + error);
                    throw ExceptionFactory.CreateException((ErrorCode)error);
                }

            }
            else
            {
                throw new ArgumentNullException("result", "is null or empty");
            }
        }

        /// <summary>
        /// Sends the error to the engine service user.
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <param name="error">The Error Reason</param>
        /// <param name="msg">The error message</param>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of Permission denied</exception>
        /// <exception cref="NotSupportedException">Thrown in case of Not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of Operation failure</exception>
        /// <precondition>
        /// Main function should be invoked before this function is called.
        /// </precondition>
        /// <since_tizen> 4 </since_tizen>
        public void SendError(Error error, string msg)
        {
            Error err = STTESendError(error, msg);
            if (err != Error.None)
            {
                Log.Error(LogTag, "SendError Failed with error " + err);
                throw ExceptionFactory.CreateException((ErrorCode)error);
            }
        }

        /// <summary>
        /// Sends the speech status to the engine service user when Stt engine notifies the change of the speech status.
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <remarks>
        /// This API is invoked when Stt engine wants to notify the change of the speech status anytime. NOTE that this API can be invoked for recognizing the speech.
        /// </remarks>
        /// <param name="status">SpeechStatus</param>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of Permission denied</exception>
        /// <exception cref="NotSupportedException">Thrown in case of Not supported</exception>
        /// <exception cref="InvalidOperationException">thrown in case of Operation failure</exception>
        /// <precondition>
        /// Main function should be invoked before this function is called. Start() and SetRecordingData() will invoke this function.
        /// </precondition>
        /// <since_tizen> 4 </since_tizen>
        public void SendSpeechStatus(SpeechStatus status)
        {
            Error error = STTESendSpeechStatus(status, IntPtr.Zero);
            if (error != Error.None)
            {
                Log.Error(LogTag, "SendSpeechStatus Failed with error " + error);
                throw ExceptionFactory.CreateException((ErrorCode)error);
            }

        }

        /// <summary>
        /// Sets a callback function for setting the private data.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <param name="callback">
        /// Called when Stt engine receives the private data from the engine service user.
        /// This callback function is called when the engine service user sends the private data to Stt engine.
        /// In Parameters:
        /// a = Key -- The key field of private data
        /// b = data -- The data field of private data
        /// Following Error Codes can be returned
        /// 1. None
        /// 2. InvalidParameter
        /// 3. OperationFailed
        /// </param>
        /// <exception cref="ArgumentException">Thrown in case of Invalid Parameter</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of Permission denied</exception>
        /// <exception cref="NotSupportedException">Thrown in case of Not supported</exception>
        /// <exception cref="InvalidOperationException">thrown in case of Operation failure</exception>
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
            Error error = STTESetPrivateDataSetCb(_privateDataSetCb);
            if (error != Error.None)
            {
                Log.Error(LogTag, "SetPrivateDataSetDelegate Failed with error " + error);
                throw ExceptionFactory.CreateException((ErrorCode)error);
            }

        }

        /// <summary>
        /// Sets a callback delegate for requesting the private data.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <param name="callback">callback function
        /// Called when Stt engine provides the engine service user with the private data.
        /// This callback function is called when the engine service user gets the private data from Stt engine.
        /// Out Parameters:
        /// a = Key -- The key field of private data
        /// b = data -- The data field of private data
        /// Following Error Codes can be returned
        /// 1. None
        /// 2. InvalidParameter
        /// 3. OperationFailed
        /// </param>
        /// <exception cref="ArgumentException">Thrown in case of Invalid Parameter</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of Permission denied</exception>
        /// <exception cref="NotSupportedException">Thrown in case of Not supported</exception>
        /// <exception cref="InvalidOperationException">thrown in case of Operation failure</exception>
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
            Error error = STTESetPrivateDataRequestedCb(_privateDataRequestedCb);
            if (error != Error.None)
            {
                Log.Error(LogTag, "SetPrivateDataRequestedDelegate Failed with error " + error);
                throw ExceptionFactory.CreateException((ErrorCode)error);
            }

        }

        private StartCb _startCb = (IntPtr language, IntPtr type, IntPtr appid, IntPtr credential, IntPtr userData) =>
        {
            string lan = null;
            string typ = null;
            string apid = null;
            string cre = null;
            if (language != null)
                lan = Marshal.PtrToStringAnsi(language);
            if (type != null)
                typ = Marshal.PtrToStringAnsi(type);
            if (appid != null)
                apid = Marshal.PtrToStringAnsi(appid);
            if (credential != null)
                cre = Marshal.PtrToStringAnsi(credential);
            return _engine.Start(lan, typ, apid, cre, IntPtr.Zero);
        };

        private IsValidLanguageCb _isValidLanguageCb = (IntPtr langauge, IntPtr isValid) =>
        {
            string langaugeStr = Marshal.PtrToStringAnsi(langauge);
            bool valid;
            Error err = _engine.IsValidLanguage(langaugeStr, out valid);
            if (valid == true)
            {
                Marshal.WriteByte(isValid, 0, 1);
            }
            else
            {
                Marshal.WriteByte(isValid, 0, 0);
            }
            return err;
        };

        private GetInfoCb _getInfoCb = (out IntPtr engineUuid, out IntPtr engineName, out IntPtr engineSetting, out IntPtr useNetwork) =>
        {
            string uuid;
            string name;
            string setting;
            bool network;
            Error err = _engine.GetInformation(out uuid, out name, out setting, out network);
            int size = Marshal.SizeOf<int>();
            IntPtr pBool = Marshal.AllocHGlobal(size);
            if (network == true)
            {
                Marshal.WriteInt32(pBool, 0, 1);
            }
            else
            {
                Marshal.WriteInt32(pBool, 0, 0);
            }
            engineUuid = Marshal.StringToHGlobalAnsi(uuid);
            engineName = Marshal.StringToHGlobalAnsi(name);
            engineSetting = Marshal.StringToHGlobalAnsi(setting);
            useNetwork = pBool;
            return err;
        };

        private DeinitializeCb _deinitializeCb = () =>
        {
            Marshal.FreeHGlobal(_engine._structIntPtrHandle);
            return _engine.Deinitialize();
        };
    }
}
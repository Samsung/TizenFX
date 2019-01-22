/*
* Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using static Interop.VoiceControlManager;
using static Interop.VoiceControlCommand;

namespace Tizen.Uix.VoiceControlManager
{
        /// <summary>
    /// Enumeration for the error values that can occur.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum Error
    {
        /// <summary>
        /// Successful, no error.
        /// </summary>
        None,
        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory,
        /// <summary>
        /// I/O error.
        /// </summary>
        IoError,
        /// <summary>
        /// Invalid parameter.
        /// </summary>
        InvalidParameter,
        /// <summary>
        /// No answer from the STT service.
        /// </summary>
        TimedOut,
        /// <summary>
        /// Device or resource busy.
        /// </summary>
        RecorderBusy,
        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied,
        /// <summary>
        /// VC NOT supported.
        /// </summary>
        NotSupported,
        /// <summary>
        /// Invalid state.
        /// </summary>
        InvalidState,
        /// <summary>
        /// Invalid language.
        /// </summary>
        InvalidLanguage,
        /// <summary>
        /// No available engine.
        /// </summary>
        EngineNotFound,
        /// <summary>
        /// Operation failed.
        /// </summary>
        OperationFailed,
        /// <summary>
        /// Operation rejected.
        /// </summary>
        OperationRejected,
        /// <summary>
        /// List reached end.
        /// </summary>
        IterationEnd,
        /// <summary>
        /// List empty.
        /// </summary>
        Empty,
        /// <summary>
        /// Service reset.
        /// </summary>
        ServiceReset,
        /// <summary>
        /// Progress to ready is not finished.
        /// </summary>
        InProgressToReady,
        /// <summary>
        /// Progress to recording is not finished.
        /// </summary>
        InProgressToRecording,
        /// <summary>
        /// Progress to processing is not finished.
        /// </summary>
        InProgressToProcessing,
        /// <summary>
        /// Not supported feature of current engine.
        /// </summary>
        NotSupportedFeature
    };

    /// <summary>
    /// Enumeration for the client state.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum State
    {
        /// <summary>
        /// 'None' state.
        /// </summary>
        None = 0,
        /// <summary>
        /// 'Initialized' state.
        /// </summary>
        Initialized = 1,
        /// <summary>
        /// 'Ready' state.
        /// </summary>
        Ready = 2,
        /// <summary>
        /// The state cannot be determined.
        /// </summary>
        Unavailable = -1
    };

    /// <summary>
    /// Enumeration for the service state.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum ServiceState
    {
        /// <summary>
        /// 'None' state.
        /// </summary>
        None = 0,
        /// <summary>
        /// 'Ready' state.
        /// </summary>
        Ready = 1,
        /// <summary>
        /// 'Recording' state.
        /// </summary>
        Recording = 2,
        /// <summary>
        /// 'Processing' state.
        /// </summary>
        Processing = 3,
        /// <summary>
        /// The state cannot be determined.
        /// </summary>
        Unavailable = -1
    };

    /// <summary>
    /// Enumeration for the result event.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum ResultEvent
    {
        /// <summary>
        /// Normal result.
        /// </summary>
        Success = 0,
        /// <summary>
        /// Rejected result.
        /// </summary>
        Rejected = 1
    };

    /// <summary>
    /// Enumeration for the command type.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum CommandType
    {
        /// <summary>
        /// foreground command type
        /// </summary>
        Foreground = 1,
        /// <summary>
        /// background command type
        /// </summary>
        Background = 2,
        /// <summary>
        /// widget command type
        /// </summary>
        Widget = 3,
        /// <summary>
        /// system command type
        /// </summary>
        System = 4,
        /// <summary>
        /// system background command type
        /// </summary>
        SystemBackground = 5,
        /// <summary>
        /// exclusive command type
        /// </summary>
        Exclusive = 6,
        /// <summary>
        /// Undefined command
        /// </summary>
        Undefined = -1
    };

    /// <summary>
    /// Enumerations of recognition mode
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum RecognitionModeType
    {
        /// <summary>
        /// Default mode
        /// </summary>
        StopBySilence,
        /// <summary>
        /// Restart recognition after rejected result
        /// </summary>
        RestartAfterReject,
        /// <summary>
        /// Continuously restart recognition - not support yet
        /// </summary>
        RestartContinuously,
        /// <summary>
        /// Start and stop manually without silence
        /// </summary>
        Manual,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined = -1
    }

    /// <summary>
    /// Enumerations of send event type
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum SendEventType
    {
        /// <summary>
        /// Send text event to vc engine
        /// </summary>
        Text,
        /// <summary>
        /// Send list event to vc engine
        /// </summary>
        ListEvent,
        /// <summary>
        /// Send haptic event to vc engine
        /// </summary>
        HapticEvent,
    }


    /// <summary>
    /// Voice Control Manager Class
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static class VoiceControlManagerClient
    {
        private static event EventHandler<SetAllResultEventArgs> _setAllResult;
        private static event EventHandler<PreResultEventArgs> _preResult;
        private static event EventHandler<SpecificEngineResultEventArgs> _specificEngineResult;
        private static event EventHandler<EventArgs> _speechDetected;
        private static event EventHandler<DialogRequestedEventArgs> _dialogRequested;
        private static event EventHandler<PrivateDataSetEventArgs> _privateDataSet;
        private static event EventHandler<PrivateDataRequestedEventArgs> _privateDataRequested;
        private static event EventHandler<FeedbackAudioFormatEventArgs> _feedbackAudioFormat;
        private static event EventHandler<FeedbackStreamingEventArgs> _feedbackStreaming;
        private static event EventHandler<VcTtsStreamingEventArgs> _vcTtsStreaming;
        private static event EventHandler<RecognitionResult> _recognitionResult;
        private static event EventHandler<CurrentLanguageChangedEventArgs> _currentLanguageChanged;
        private static event EventHandler<StateChangedEventArgs> _stateChanged;
        private static event EventHandler<ServiceStateChangedEventArgs> _serviceStateChanged;
        private static event EventHandler<ErrorOccurredEventArgs> _errorOccurred;
        private static VcMgrAllResultCallback _allResultDelegate;
        private static VcMgrPreResultCallback _preResultDelegate;
        private static VcMgrSpecificEngineResultCallback _specificEngineResultDelegate;
        private static VcMgrBeginSpeechDetectedCallback _beginSpeechDetectedDelegate;
        private static VcMgrDialogRequestCallback _dialogRequestDelegate;
        private static VcMgrPrivateDataSetCallback _privateDataSetDelegate;
        private static VcMgrPrivateDataRequestedCallback _privateDataRequestedDelegate;
        private static VcMgrFeedbackAudioFormatCallback _feedbackAudioFormatDelegate;
        private static VcMgrFeedbackStreamingCallback _feedbackStreamingDelegate;
        private static VcMgrVcTtsStreamingCallback _vcTtsStreamingDelegate;
        private static VcMgrResultCallback s_resultDelegate;
        private static VcMgrCurrentLanguageChangedCallback _languageDelegate;
        private static VcMgrSupportedLanguageCallback _supportedLanguagesDelegate;
        private static List<string> _supportedLanguages;
        private static VcMgrStateChangedCallback _stateDelegate;
        private static VcMgrServiceStateChangedCallback _serviceStateDelegate;
        private static VcMgrErrorCallback _errorDelegate;

        /// <summary>
        /// Initialize voice control manager.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <post>
        /// The State will be Initialized.
        /// </post>
        public static void Initialize()
        {
            ErrorCode error = VcMgrInitialize();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Initialize Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Deinitialize the voice control manager.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <post>
        /// The State will be None.
        /// </post>
        public static void Deinitialize()
        {
            ErrorCode error = VcMgrDeinitialize();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Deinitialize Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Connects the voice control service.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <pre>
        /// The state must be initialized.
        /// </pre>
        /// <post>
        /// The state must be ready.
        /// </post>
        public static void Prepare()
        {
            ErrorCode error = VcMgrPrepare();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Prepare Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Disconnects the voice control service.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <pre>
        /// The state must be ready.
        /// </pre>
        /// <post>
        /// The state must be initialized.
        /// </post>
        public static void Unprepare()
        {
            ErrorCode error = VcMgrUnprepare();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Unprepare Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Retrieves all the supported languages.
        /// A language is specified as an ISO 3166 alpha-2 two letter country-code
        /// followed by ISO 639-1 for the two-letter language code.
        /// For example, "ko_KR" for Korean, "en_US" for American English.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <pre>
        /// The state must be ready or initialized.
        /// </pre>
        public static IEnumerable<string> GetSupportedLanguages()
        {
            _supportedLanguages = new List<string>();
            _supportedLanguagesDelegate = (IntPtr language, IntPtr userData) =>
            {
                string languageStr = Marshal.PtrToStringAnsi(language);
                _supportedLanguages.Add(languageStr);
                return true;
            };
            ErrorCode error = VcMgrForeachSupportedLanguages(_supportedLanguagesDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetSupportedLanguages Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return _supportedLanguages;
        }

        /// <summary>
        /// Gets the current language.
        /// A language is specified as an ISO 3166 alpha-2 two letter country-code
        /// followed by ISO 639-1 for the two-letter language code.
        /// For example, "ko_KR" for Korean, "en_US" for American English.
        /// An empty string is returned in case of some internal error.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <value>
        /// The current language in voice control.
        /// </value>
        /// <pre>
        /// The state must be initialized or ready.
        /// </pre>
        public static string CurrentLanguage
        {
            get
            {
                string currentLanguage;

                ErrorCode error = VcMgrGetCurrentLanguage(out currentLanguage);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "CurrentLanaguge Failed with error " + error);
                    return "";
                }

                return currentLanguage;
            }
        }

        /// <summary>
        /// Gets the current state of the voice control client.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <value>
        /// The current state of the voice control client.
        /// </value>
        /// <pre>
        /// The state must be initialized or ready.
        /// </pre>
        public static State State
        {
            get
            {
                State state;

                ErrorCode error = VcMgrGetState(out state);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "State Failed with error " + error);
                    return State.Unavailable;
                }

                return state;
            }
        }

        /// <summary>
        /// Gets the current state of the voice control service.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <value>
        /// The current state of the voice control service.
        /// </value>
        /// <pre>
        /// The state must be ready.
        /// </pre>
        public static ServiceState ServiceState
        {
            get
            {
                ServiceState state;

                ErrorCode error = VcMgrGetServiceState(out state);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "ServiceState Failed with error " + error);
                    return ServiceState.Unavailable;
                }

                return state;
            }
        }

        /// <summary>
        /// Checks whether the command format is supported.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <param name="format">The command format</param>
        /// <returns>The result status, true if supported</returns>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <pre>
        /// The State must be Ready.
        /// </pre>
        public static bool IsCommandFormatSupported(CommandFormat format)
        {
            bool supported = false;
            ErrorCode error = VcMgrIsCommandFormatSupported(format, out supported);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "IsCommandFormatSupported Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
            return supported;
        }

        /// <summary>
        /// Sets system or exclusive commands.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <param name="list">Command list</param>
        /// <exception cref="InvalidOperationException">This exception can be due to invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <pre>
        /// The State should be Ready
        /// </pre>
        public static void SetCommandList(VoiceCommandList list)
        {
            if (list == null)
                throw new ArgumentException("Parameter is null");

            ErrorCode error = VcMgrSetCommandList(list._handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetCommandList Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Unsets command list.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to invalid state.</exception>
        /// <pre>
        /// The State should be Ready
        /// </pre>
        public static void UnsetCommandList()
        {
            ErrorCode error = VcMgrUnsetCommandList();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "UnsetCommandList Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Sets commands from file.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <param name="path">File Path</param>
        /// <param name="type">Command type</param>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <pre>
        /// The State should be Ready
        /// </pre>
        public static void SetCommandListFromFile(string path, CommandType type)
        {
            ErrorCode error = VcMgrSetCommandListFromFile(path, type);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetCommandListFromFile Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

        }

        /// <summary>
        /// Sets background commands of preloaded app from file.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <param name="filePath">File Path</param>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <pre>
        /// The State should be Ready
        /// </pre>
        public static void SetPreloadedCommandsFromFile(string filePath)
        {
            ErrorCode error = VcMgrSetPreloadedCommandsFromFile(filePath);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetPreloadedCommandsFromFile Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Retrieves all available commands.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <returns>
        /// The Command List else null in case of no System Commands
        /// </returns>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <pre>
        /// The State should be Ready
        /// </pre>
        public static VoiceCommandList GetCurrentCommands()
        {
            IntPtr handle = IntPtr.Zero;
            ErrorCode error = VcMgrGetCurrentCommands(out handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetCurrentCommands Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            if (handle == IntPtr.Zero)
            {
                Log.Error(LogTag, "GetCurrentCommands handle is null");
                return null;
            }

            SafeCommandListHandle list = new SafeCommandListHandle(handle);
            return new VoiceCommandList(list);
        }

        /// <summary>
        /// Sets or Gets the Audio In Type
        /// the Values of the strings can be "VC_AUDIO_ID_BLUETOOTH" or "VC_AUDIO_ID_MSF"
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <pre>
        /// The State must be Ready.
        /// </pre>
        public static string AudioType
        {
            get
            {
                string type;

                ErrorCode error = VcMgrGetAudioType(out type);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetAudioType Failed with error " + error);
                    return "";
                }

                return type;
            }
            set
            {
                ErrorCode error = VcMgrSetAudioType(value);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "SetAudioType Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Sets or Gets the recognition mode.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <pre>
        /// The State must be Ready.
        /// </pre>
        public static RecognitionModeType RecognitionMode
        {
            get
            {
                RecognitionModeType mode;

                ErrorCode error = VcMgrGetRecognitionMode(out mode);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetRecognitionMode Failed with error " + error);
                    return RecognitionModeType.Undefined;
                }

                return mode;
            }
            set
            {
                ErrorCode error = VcMgrSetRecognitionMode(value);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "SetRecognitionMode Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Sets private data between app and engine.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <param name="key">Private key</param>
        /// <param name="data">Private data</param>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="OutOfMemoryException">This exception can be due to out of memory.</exception>
        /// <pre>
        /// The State must be Ready.
        /// </pre>
        public static void SetPrivateData(string key, string data)
        {
            ErrorCode error = VcMgrSetPrivateData(key, data);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetPrivateData Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Gets private data between app and engine.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <param name="key">Private key</param>
        /// <returns>Private data</returns>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="OutOfMemoryException">This exception can be due to out of memory.</exception>
        /// <pre>
        /// The State must be Ready.
        /// </pre>
        public static string GetPrivateData(string key)
        {
            string data;
            ErrorCode error = VcMgrGetPrivateData(key, out data);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetPrivateData Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
            return data;
        }

        /// <summary>
        /// Request to do action as if utterence is spoken.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <param name="type">Event type</param>
        /// <param name="sendEvent">The string for send event</param>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="OutOfMemoryException">This exception can be due to out of memory.</exception>
        /// <pre>
        /// The State must be Ready.
        /// </pre>
        public static void DoAction(SendEventType type, string sendEvent)
        {
            ErrorCode error = VcMgrDoAction(type, sendEvent);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "DoAction Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Sends the specific engine request to the vc-service.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <param name="engineAppId">A specific engine's app id</param>
        /// <param name="evt">A engine service user request event</param>
        /// <param name="request">A engine service user request text</param>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        public static void SendSpecificEngineRequest(string engineAppId, string evt, string request)
        {
            ErrorCode error = VcMgrSendSpecificEngineRequest(engineAppId, evt, request);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SendSpecificEngineRequest Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Starts recognition.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <param name="exclusiveCommandOption">Exclusive command option</param>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="OutOfMemoryException">This exception can be due to out of memory.</exception>
        /// <pre>
        /// The State must be Ready.
        /// </pre>
        /// <post>
        /// The Service State will become Recording.
        /// </post>
        public static void Start(bool exclusiveCommandOption)
        {
            ErrorCode error = VcMgrStart(exclusiveCommandOption);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Start Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Stop recognition.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <pre>
        /// The State must be Recording.
        /// </pre>
        /// <post>
        /// The Service State will become Processing.
        /// </post>
        public static void Stop()
        {
            ErrorCode error = VcMgrStop();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Stop Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Cancels recognition.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="OutOfMemoryException">This exception can be due to out of memory.</exception>
        /// <pre>
        /// The State must be Recording or Processing.
        /// </pre>
        /// <post>
        /// The Service State will become Ready.
        /// </post>
        public static void Cancel()
        {
            ErrorCode error = VcMgrCancel();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Cancel Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Gets the microphone volume during recording.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <pre>
        /// The Service State must be Recording.
        /// </pre>
        public static float RecordingVolume
        {
            get
            {
                float volume;

                ErrorCode error = VcMgrGetRecordingVolume(out volume);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "RecordingVolume Failed with error " + error);
                    return 0;
                }

                return volume;
            }
        }

        /// <summary>
        /// Select valid result from all results.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <param name="list">The valid result list</param>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="OutOfMemoryException">This exception can be due to out of memory.</exception>
        public static void SetSelectedResults(VoiceCommandList list)
        {
            ErrorCode error = VcMgrSetSelectedResults(list._handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetSelectedResults Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Called when client gets the all recognition results from vc-daemon.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<SetAllResultEventArgs> SetAllResult
        {
            add
            {
                _allResultDelegate = (ResultEvent evt, IntPtr vcCmdList, IntPtr result, IntPtr msg, IntPtr userData) =>
                {
                    string resultString = Marshal.PtrToStringAnsi(result);
                    string msgString = Marshal.PtrToStringAnsi(msg);
                    VoiceCommandList cmdList = new VoiceCommandList(new SafeCommandListHandle(vcCmdList));
                    SetAllResultEventArgs args = new SetAllResultEventArgs(evt, cmdList, resultString, msgString);
                    _setAllResult?.Invoke(null, args);
                    return true;
                };
                ErrorCode error = VcMgrSetAllResultCb(_allResultDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add SetAllResult Failed with error " + error);
                }

                else
                {
                    _setAllResult += value;
                }
            }

            remove
            {
                ErrorCode error = VcMgrUnsetAllResultCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove SetAllResult Failed with error " + error);
                }

                _setAllResult -= value;
                _allResultDelegate = null;
            }
        }

        /// <summary>
        /// Called when client gets the pre recognition results(partial ASR) from vc-daemon.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<PreResultEventArgs> PreResult
        {
            add
            {
                _preResultDelegate = (PreResultEventArgs.PreResultEventType evt, IntPtr result, IntPtr userData) =>
                {
                    string resultString = Marshal.PtrToStringAnsi(result);
                    PreResultEventArgs args = new PreResultEventArgs(evt, resultString);
                    _preResult?.Invoke(null, args);
                };
                ErrorCode error = VcMgrSetPreResultCb(_preResultDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add PreResult Failed with error " + error);
                }

                else
                {
                    _preResult += value;
                }
            }

            remove
            {
                ErrorCode error = VcMgrUnsetPreResultCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove PreResult Failed with error " + error);
                }

                _preResult -= value;
            }
        }

        /// <summary>
        /// Called when client gets the specific engine's result from vc-service.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<SpecificEngineResultEventArgs> SpecificEngineResult
        {
            add
            {
                _specificEngineResultDelegate = (IntPtr engineAppId, IntPtr evt, IntPtr result, IntPtr userData) =>
                {
                    string engineAppIdString = Marshal.PtrToStringAnsi(engineAppId);
                    string eventString = Marshal.PtrToStringAnsi(evt);
                    string resultString = Marshal.PtrToStringAnsi(result);
                    SpecificEngineResultEventArgs args = new SpecificEngineResultEventArgs(engineAppIdString, eventString, resultString);
                    _specificEngineResult?.Invoke(null, args);
                };
                ErrorCode error = VcMgrSetSpecificEngineResultCb(_specificEngineResultDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add SpecificEngineResult Failed with error " + error);
                }
                else
                {
                    _specificEngineResult += value;
                }
            }

            remove
            {
                ErrorCode error = VcMgrUnsetSpecificEngineResultCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove SpecificEngineResult Failed with error " + error);
                }

                _specificEngineResult -= value;
                _specificEngineResultDelegate = null;
            }
        }

        /// <summary>
        /// Event to be invoked when the recognition is done.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<RecognitionResult> RecognitionResult
        {
            add
            {
                s_resultDelegate = (ResultEvent evt, IntPtr cmdList, IntPtr result, IntPtr userData) =>
                {
                    Log.Info(LogTag, "Recognition Result Event Triggered");
                    if ((cmdList != null) && (result != null))
                    {
                        RecognitionResult args = new RecognitionResult(evt, cmdList, result);
                        _recognitionResult?.Invoke(null, args);
                    }
                    else
                    {
                        Log.Info(LogTag, "Recognition Result Event null received");
                    }
                };
                ErrorCode error = VcMgrSetResultCb(s_resultDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add RecognitionResult Failed with error " + error);
                }
                else
                {
                    _recognitionResult += value;
                }
            }

            remove
            {
                ErrorCode error = VcMgrUnsetResultCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove RecognitionResult Failed with error " + error);
                }

                _recognitionResult -= value;
                s_resultDelegate = null;
            }
        }

        /// <summary>
        /// Event to be invoked when the VoiceControl client state changes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <pre>
        /// The state must be initialized.
        /// </pre>
        public static event EventHandler<StateChangedEventArgs> StateChanged
        {
            add
            {
                _stateDelegate = (State previous, State current, IntPtr userData) =>
                {
                    StateChangedEventArgs args = new StateChangedEventArgs(previous, current);
                    _stateChanged?.Invoke(null, args);
                };
                ErrorCode error = VcMgrSetStateChangedCb(_stateDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add StateChanged Failed with error " + error);
                }
                else
                {
                    _stateChanged += value;
                }
            }

            remove
            {
                ErrorCode error = VcMgrUnsetStateChangedCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove StateChanged Failed with error " + error);
                }

                _stateChanged -= value;
                _stateDelegate = null;
            }
        }

        /// <summary>
        /// Event to be invoked when the VoiceControl service state changes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <pre>
        /// The state must be initialized.
        /// </pre>
        public static event EventHandler<ServiceStateChangedEventArgs> ServiceStateChanged
        {
            add
            {
                _serviceStateDelegate = (ServiceState previous, ServiceState current, IntPtr userData) =>
                {
                    ServiceStateChangedEventArgs args = new ServiceStateChangedEventArgs(previous, current);
                    _serviceStateChanged?.Invoke(null, args);
                };
                ErrorCode error = VcMgrSetServiceStateChangedCb(_serviceStateDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add ServiceStateChanged Failed with error " + error);
                }
                else
                {
                    _serviceStateChanged += value;
                }
            }

            remove
            {
                ErrorCode error = VcMgrUnsetServiceStateChangedCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove ServiceStateChanged Failed with error " + error);
                }

                _serviceStateChanged -= value;
                _serviceStateDelegate = null;
            }
        }

        /// <summary>
        /// Called when user speaking is detected.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<EventArgs> SpeechDetected
        {
            add
            {
                _beginSpeechDetectedDelegate = (IntPtr userData) =>
                {
                    _speechDetected?.Invoke(null, EventArgs.Empty);
                };
                ErrorCode error = VcMgrSetSpeechDetectedCb(_beginSpeechDetectedDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add SpeechDetected Failed with error " + error);
                }

                else
                {
                    _speechDetected += value;
                }
            }

            remove
            {
                ErrorCode error = VcMgrUnsetSpeechDetectedCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove SpeechDetected Failed with error " + error);
                }

                _speechDetected -= value;
                _beginSpeechDetectedDelegate = null;
            }
        }

        /// <summary>
        /// Event to be invoked when the default language changes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <pre>
        /// The state must be initialized.
        /// </pre>
        public static event EventHandler<CurrentLanguageChangedEventArgs> CurrentLanguageChanged
        {
            add
            {
                _languageDelegate = (IntPtr previousLanguage, IntPtr currentLanguage, IntPtr userData) =>
            {
                string previousLanguageString = Marshal.PtrToStringAnsi(previousLanguage);
                string currentLanguageString = Marshal.PtrToStringAnsi(currentLanguage);
                CurrentLanguageChangedEventArgs args = new CurrentLanguageChangedEventArgs(previousLanguageString, currentLanguageString);
                _currentLanguageChanged?.Invoke(null, args);
            };
                ErrorCode error = VcMgrSetCurrentLanguageChangedCb(_languageDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add CurrentLanguageChanged Failed with error " + error);
                }

                else
                {
                    _currentLanguageChanged += value;
                }
            }

            remove
            {
                ErrorCode error = VcMgrUnsetCurrentLanguageChangedCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove CurrentLanguageChanged Failed with error " + error);
                }

                _currentLanguageChanged -= value;
                _languageDelegate = null;
            }
        }

        /// <summary>
        /// Gets the current error message.
        /// This function should be called during as ErrorOccurred Event.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        public static string ErrorMessage
        {
            get
            {
                string msg;

                ErrorCode error = VcMgrGetErrorMessage(out msg);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "ErrorMessage Failed with error " + error);
                    return "";
                }

                return msg;
            }
        }

        /// <summary>
        /// Event to be invoked when an error occurs.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <pre>
        /// The state must be initialized.
        /// </pre>
        public static event EventHandler<ErrorOccurredEventArgs> ErrorOccurred
        {
            add
            {
                _errorDelegate = (ErrorCode reason, IntPtr userData) =>
            {
                ErrorOccurredEventArgs args = new ErrorOccurredEventArgs(reason);
                _errorOccurred?.Invoke(null, args);
            };
                ErrorCode error = VcMgrSetErrorCb(_errorDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add ErrorOccurred Failed with error " + error);
                }

                else
                {
                    _errorOccurred += value;
                }
            }


            remove
            {
                ErrorCode error = VcMgrUnsetErrorCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove ErrorOccurred Failed with error " + error);
                }

                _errorOccurred -= value;
                _errorDelegate = null;
            }
        }

        /// <summary>
        /// Event to be called when dialog requests.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<DialogRequestedEventArgs> DialogRequested
        {
            add
            {
                _dialogRequestDelegate = (int pid, IntPtr dispText, IntPtr uttText, bool continuous, IntPtr userData) =>
                {
                    string dispTextString = Marshal.PtrToStringAnsi(dispText);
                    string uttTextString = Marshal.PtrToStringAnsi(uttText);
                    DialogRequestedEventArgs args = new DialogRequestedEventArgs(pid, dispTextString, uttTextString, continuous);
                    _dialogRequested?.Invoke(null, args);
                };
                ErrorCode error = VcMgrSetDialogRequestCb(_dialogRequestDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add DialogRequested Failed with error " + error);
                }
                else
                {
                    _dialogRequested += value;
                }
            }

            remove
            {
                ErrorCode error = VcMgrUnsetDialogRequestCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove DialogRequested Failed with error " + error);
                }

                _dialogRequested -= value;
                _dialogRequestDelegate = null;
            }
        }

        /// <summary>
        /// Enable command type as candidate command.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <param name="cmdType">Command Type</param>
        /// <exception cref="InvalidOperationException">This exception can be due to invalid state.</exception>
        /// <pre>
        /// The State should be Ready
        /// </pre>
        public static void EnableCommandType(CommandType cmdType)
        {
            ErrorCode error = VcMgrEnableCommandType(cmdType);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "EnableCommandType Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Disable command type as candidate command.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <param name="cmdType">Command Type</param>
        /// <exception cref="InvalidOperationException">This exception can be due to invalid state.</exception>
        /// <pre>
        /// The State should be Ready
        /// </pre>
        public static void DisableCommandType(CommandType cmdType)
        {
            ErrorCode error = VcMgrDisableCommandType(cmdType);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "DisableCommandType Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Called when engine sets private data to manager client.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<PrivateDataSetEventArgs> PrivateDataSet
        {
            add
            {
                _privateDataSetDelegate = (IntPtr key, IntPtr data, IntPtr userData) =>
                {
                    string keyString = Marshal.PtrToStringAnsi(key);
                    string dataString = Marshal.PtrToStringAnsi(data);
                    PrivateDataSetEventArgs args = new PrivateDataSetEventArgs(keyString, dataString);
                    _privateDataSet?.Invoke(null, args);
                    return 0;
                };
                ErrorCode error = VcMgrSetPrivateDataSetCb(_privateDataSetDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add PrivateDataSet Failed with error " + error);
                }
                else
                {
                    _privateDataSet += value;
                }
            }

            remove
            {
                ErrorCode error = VcMgrUnsetPrivateDataSetCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove PrivateDataSet Failed with error " + error);
                }

                _privateDataSet -= value;
                _privateDataSetDelegate = null;
            }
        }

        /// <summary>
        /// Called when engine requests private data from manager client.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<PrivateDataRequestedEventArgs> PrivateDataRequested
        {
            add
            {
                _privateDataRequestedDelegate = (string key, out string data, IntPtr userData) =>
                {
                    var args = new PrivateDataRequestedEventArgs(key);

                    _privateDataRequested?.Invoke(null, args);
                    data = args.Data;

                    return (int)ErrorCode.None;
                };

                ErrorCode error = VcMgrSetPrivateDataRequestedCb(_privateDataRequestedDelegate);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add PrivateDataRequestedCallback Failed with error " + error);
                }
                else
                {
                    _privateDataRequested += value;
                }
            }

            remove
            {
                ErrorCode error = VcMgrUnsetPrivateDataRequestedCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove PrivateDataRequestedCallback Failed with error " + error);
                }
                _privateDataRequested -= value;
                _privateDataRequestedDelegate = null;
            }
        }

        /// <summary>
        /// Called when engine sends audio formats necessary for playing TTS feedback.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<FeedbackAudioFormatEventArgs> FeedbackAudioFormat
        {
            add
            {
                _feedbackAudioFormatDelegate = (int rate, FeedbackAudioFormatEventArgs.AudioChanelType channel, FeedbackAudioFormatEventArgs.AudioType audiotype, IntPtr userData) =>
                {
                    FeedbackAudioFormatEventArgs args = new FeedbackAudioFormatEventArgs(rate, channel, audiotype);
                    _feedbackAudioFormat?.Invoke(null, args);
                };
                ErrorCode error = VcMgrSetFeedbackAudioFormatCb(_feedbackAudioFormatDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add FeedbackStreaming Failed with error " + error);
                }
                else
                {
                    _feedbackAudioFormat += value;
                }
            }

            remove
            {
                ErrorCode error = VcMgrUnsetFeedbackAudioFormatCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove FeedbackAudioFormat Failed with error " + error);
                }

                _feedbackAudioFormat -= value;
                _feedbackAudioFormatDelegate = null;
            }
        }

        /// <summary>
        /// Called when engine sends audio streaming for TTS feedback.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<FeedbackStreamingEventArgs> FeedbackStreaming
        {
            add
            {
                _feedbackStreamingDelegate = (FeedbackStreamingEventArgs.FeedbackEventType evt, IntPtr buffer, int len, IntPtr userData) =>
                {
                    string bufferString = Marshal.PtrToStringAnsi(buffer);
                    FeedbackStreamingEventArgs args = new FeedbackStreamingEventArgs(evt, bufferString, len);
                    _feedbackStreaming?.Invoke(null, args);
                };
                ErrorCode error = VcMgrSetFeedbackStreamingCb(_feedbackStreamingDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add FeedbackStreaming Failed with error " + error);
                }
                else
                {
                    _feedbackStreaming += value;
                }
            }

            remove
            {
                ErrorCode error = VcMgrUnsetFeedbackStreamingCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove FeedbackStreaming Failed with error " + error);
                }

                _feedbackStreaming -= value;
                _feedbackStreamingDelegate = null;
            }
        }

        /// <summary>
        /// Starts getting TTS feedback streaming data from the buffer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <pre>
        /// The State should be Ready
        /// </pre>
        public static void StartFeedback()
        {
            ErrorCode error = VcMgrStartFeedback();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "StartFeedback Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Stops getting and removes TTS feedback streaming data from the buffer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <pre>
        /// The State should be Ready
        /// </pre>
        public static void StopFeedback()
        {
            ErrorCode error = VcMgrStopFeedback();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "StopFeedback Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Called when the vc client sends audio streaming for TTS feedback.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/voicecontrol.manager
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<VcTtsStreamingEventArgs> VcTtsStreaming
        {
            add
            {
                _vcTtsStreamingDelegate = (int pid, int uttId, VcTtsStreamingEventArgs.FeedbackEventType evt, IntPtr buffer, int len, IntPtr userData) =>
                {
                    string bufferString = Marshal.PtrToStringAnsi(buffer);
                    VcTtsStreamingEventArgs args = new VcTtsStreamingEventArgs(pid, uttId, evt, bufferString, len);
                    _vcTtsStreaming?.Invoke(null, args);
                };
                ErrorCode error = VcMgrSetVcTtsStreamingCb(_vcTtsStreamingDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add VcTtsStreaming Failed with error " + error);
                }
                else
                {
                    _vcTtsStreaming += value;
                }
            }

            remove
            {
                ErrorCode error = VcMgrUnsetVcTtsStreamingCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove VcTtsStreaming Failed with error " + error);
                }

                _vcTtsStreaming -= value;
                _vcTtsStreamingDelegate = null;
            }
        }
    }
}

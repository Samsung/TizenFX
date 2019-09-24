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
using Tizen.Applications;
using static Interop.VoiceControlManager;
using static Interop.VoiceControlCommand;
using System.Text;

namespace Tizen.Uix.VoiceControlManager
{
        /// <summary>
    /// Enumeration for the error values that can occur.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum VoiceError
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
    /// Enumeration for the result of recognizing a VoiceCommand
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum RecognizedResult
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
    /// Enumerations for audio channels
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum AudioChanelType
    {
        /// <summary>
        /// 1 channel, mono
        /// </summary>
        Mono = 0,
        /// <summary>
        /// 2 channels, stereo
        /// </summary>
        Stereo
    }

    /// <summary>
    /// Enumerations of audio types
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
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
    }

    /// <summary>
    /// Enumeration for TTS feedback type
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum FeedbackType
    {
        /// <summary>
        /// Failed
        /// </summary>
        Fail = -1,
        /// <summary>
        /// Start event
        /// </summary>
        Start = 1,
        /// <summary>
        /// Continue event
        /// </summary>
        Continue = 2,
        /// <summary>
        /// Finish event
        /// </summary>
        Finish = 3
    }

    /// <summary>
    /// Enumerations of pre result event
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum PreResultEventType
    {
        /// <summary>
        /// Final result
        /// </summary>
        FinalResult = 0,
        /// <summary>
        /// Partial Result
        /// </summary>
        PartialResult,
        /// <summary>
        /// Error
        /// </summary>
        Error,
    }

    /// <summary>
    /// Voice Control Manager Class
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static class VoiceControlManagerClient
    {
        private static event EventHandler<PreRecognitionResultUpdatedEventArgs> _preResult;
        private static event EventHandler<SpecificEngineResultEventArgs> _specificEngineResult;
        private static event EventHandler<EventArgs> _speechDetected;
        private static event EventHandler<ConversationRequestedEventArgs> _conversationRequested;
        private static event EventHandler<PrivateDataUpdatedEventArgs> _privateDataSet;
        private static event EventHandler<FeedbackAudioFormatEventArgs> _feedbackAudioFormat;
        private static event EventHandler<FeedbackStreamingEventArgs> _feedbackStreaming;
        private static event EventHandler<VcTtsStreamingEventArgs> _vcTtsStreaming;
        private static event EventHandler<RecognitionResultUpdatedEventArgs> _recognitionResult;
        private static event EventHandler<CurrentLanguageChangedEventArgs> _currentLanguageChanged;
        private static event EventHandler<StateChangedEventArgs> _stateChanged;
        private static event EventHandler<ServiceStateChangedEventArgs> _serviceStateChanged;
        private static event EventHandler<ErrorOccurredEventArgs> _errorOccurred;
        private static event EventHandler<AllRecognitionResultEventArgs> _allRecognitionResult;
        private static VcMgrPreResultCallback _preResultDelegate;
        private static VcMgrSpecificEngineResultCallback _specificEngineResultDelegate;
        private static VcMgrBeginSpeechDetectedCallback _beginSpeechDetectedDelegate;
        private static VcMgrDialogRequestCallback _conversationRequestDelegate;
        private static VcMgrPrivateDataSetCallback _privateDataSetDelegate;
        private static VcMgrPrivateDataRequestedCallback _privateDataRequestedDelegate;
        private static VcMgrFeedbackAudioFormatCallback _feedbackAudioFormatDelegate;
        private static VcMgrFeedbackStreamingCallback _feedbackStreamingDelegate;
        private static VcMgrVcTtsStreamingCallback _vcTtsStreamingDelegate;
        private static VcMgrResultCallback s_resultDelegate;
        private static VcMgrCurrentLanguageChangedCallback _languageDelegate;
        private static VcMgrStateChangedCallback _stateDelegate;
        private static VcMgrServiceStateChangedCallback _serviceStateDelegate;
        private static VcMgrErrorCallback _errorDelegate;
        private static SelectRecognizedCommandsDelegate _recognizedCommandsDelegate;

        private static VcMgrAllResultCallback _recognizedCommandsSelectionCallback = (RecognizedResult result, IntPtr vcCmdList, IntPtr recognizedText, IntPtr msg, IntPtr userData) =>
        {
            string recognizedString = Marshal.PtrToStringAnsi(recognizedText);
            string msgString = Marshal.PtrToStringAnsi(msg);

            if (_allRecognitionResult != null)
            {
                AllRecognitionResultEventArgs args = new AllRecognitionResultEventArgs(result, recognizedString, msgString);
                _allRecognitionResult?.Invoke(null, args);
                if (result == RecognizedResult.Rejected)
                    return true;
            }

            if (_recognizedCommandsDelegate != null && result == RecognizedResult.Success)
            {
                VoiceCommandsGroup cmdList = new VoiceCommandsGroup(new SafeCommandListHandle(vcCmdList));
                IEnumerable<VoiceCommand> selectedList = _recognizedCommandsDelegate.Invoke(cmdList.Commands, recognizedString, msgString);
                if (selectedList == null)
                    return true;

                VoiceCommandsGroup resultList = new VoiceCommandsGroup();
                foreach (VoiceCommand command in selectedList)
                {
                    resultList.Commands.Add(command);
                }
                ErrorCode error = VcMgrSetSelectedResults(resultList._handle);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "SetSelectedResults Failed with error " + error);
                }
                return false;
            }
            return true;
        };

        /// <summary>
        /// The delegate is invoked when engine requests private data is needed.
        /// </summary>
        /// <param name="key">Private key</param>
        /// <returns>Private data</returns>
        /// <since_tizen> 6 </since_tizen>
        public delegate string PrivateDataProvider(string key);

        /// <summary>
        /// The delegate is invoked when the sentence match, client selects valid commands from all commands.
        /// </summary>
        /// <param name="commands">Command list</param>
        /// <param name="recognizedText">The Recognized text</param>
        /// <param name="message">Engine message</param>
        /// <returns>Valid commands</returns>
        /// <since_tizen> 6 </since_tizen>
        public delegate IEnumerable<VoiceCommand> SelectRecognizedCommandsDelegate(IEnumerable<VoiceCommand> commands, string recognizedText, string message);

        /// <summary>
        /// Initialize voice control manager.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to out of memory.
        /// 2) This exception can be due to operation failed.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <returns>
        /// List of strings for supported languages.
        /// </returns>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The state must be ready or initialized.
        /// </pre>
        public static IEnumerable<string> GetSupportedLanguages()
        {
            List<string> supportedLanguages = new List<string>();
            VcMgrSupportedLanguageCallback supportedLanguagesDelegate = (IntPtr language, IntPtr userData) =>
            {
                string languageStr = Marshal.PtrToStringAnsi(language);
                supportedLanguages.Add(languageStr);
                return true;
            };
            ErrorCode error = VcMgrForeachSupportedLanguages(supportedLanguagesDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetSupportedLanguages Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return supportedLanguages;
        }

        /// <summary>
        /// Gets the current language.
        /// A language is specified as an ISO 3166 alpha-2 two letter country-code
        /// followed by ISO 639-1 for the two-letter language code.
        /// For example, "ko_KR" for Korean, "en_US" for American English.
        /// An empty string is returned in case of some internal error.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <value>The current language in voice control.</value>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
                    return string.Empty;
                }

                return currentLanguage;
            }
        }

        /// <summary>
        /// Gets the current state of the voice control client.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <value>The current state of the voice control client.</value>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <value>The current state of the voice control service.</value>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to an invalid state.
        /// 2) This exception can be due to operation failed.
        /// </exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <param name="format">The command format</param>
        /// <returns>The result status, true if supported</returns>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The State must be Ready.
        /// </pre>
        public static bool IsSupportedCommandFormat(CommandFormat format)
        {
            bool supported = false;
            ErrorCode error = VcMgrIsCommandFormatSupported(format, out supported);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "IsSupportedCommandFormat Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
            return supported;
        }

        /// <summary>
        /// Sets system or exclusive commands.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <param name="commands">Command list</param>
        /// <exception cref="InvalidOperationException">This exception can be due to invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The State should be Ready
        /// </pre>
        public static void SetCommands(VoiceCommandsGroup commands)
        {
            if (commands == null)
                throw new ArgumentException("Parameter is null");

            ErrorCode error = VcMgrSetCommandList(commands._handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetCommands Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Clears commands.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="InvalidOperationException">This exception can be due to invalid state.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The State should be Ready
        /// </pre>
        public static void ClearCommands()
        {
            ErrorCode error = VcMgrUnsetCommandList();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "ClearCommands Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Sets commands from file.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <param name="path">File Path</param>
        /// <param name="type">Command type</param>
        /// <exception cref="InvalidOperationException">This exception can be due to invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The State should be Ready
        /// </pre>
        public static void SetCommandsFromFile(string path, CommandType type)
        {
            ErrorCode error = VcMgrSetCommandListFromFile(path, type);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetCommandsFromFile Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Retrieves all available commands.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>>
        /// <returns>
        /// The Command List else null in case of no System Commands
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to an invalid state.
        /// 2) This exception can be due to operation failed.
        /// </exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The State should be Ready
        /// </pre>
        public static IEnumerable<VoiceCommand> GetCurrentCommands()
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
            VoiceCommandsGroup cmdList = new VoiceCommandsGroup(list);
            return cmdList.Commands;
        }

        /// <summary>
        /// Sets or Gets the Audio In Type
        /// the Values of the strings can be "VC_AUDIO_ID_BLUETOOTH" or "VC_AUDIO_ID_MSF"
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="InvalidOperationException">This exception can be due to invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
                    return string.Empty;
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <param name="key">Private key</param>
        /// <param name="data">Private data</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to an invalid state.
        /// 2) This exception can be due to operation failed.
        /// </exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException" > The required feature is not supported.</exception>
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <param name="key">Private key</param>
        /// <returns>Private data</returns>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <param name="type">Event type</param>
        /// <param name="sendEvent">The string for send event</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to an invalid state.
        /// 2) This exception can be due to operation failed.
        /// </exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException" > The required feature is not supported.</exception>
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <param name="engineAppId">A specific engine's app id</param>
        /// <param name="evt">A engine service user request event</param>
        /// <param name="request">A engine service user request text</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to an invalid state.
        /// 2) This exception can be due to operation failed.
        /// </exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <param name="exclusiveCommandOption">Exclusive command option</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to an invalid state.
        /// 2) This exception can be due to operation failed.
        /// 3) This exception can be due to progress to recording is not finished.
        /// </exception>
        /// <exception cref="TimeoutException">This exception can be due to no answer from service.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to an invalid state.
        /// 2) This exception can be due to operation failed.
        /// 3) This exception can be due to progress to ready is not finished.
        /// 4) This exception can be due to progress to recording is not finished.
        /// 5) This exception can be due to progress to processing is not finished.
        /// </exception>
        /// <exception cref="TimeoutException">This exception can be due to no answer from service.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to an invalid state.
        /// 2) This exception can be due to operation failed.
        /// 3) This exception can be due to progress to ready is not finished.
        /// 4) This exception can be due to progress to recording is not finished.
        /// 5) This exception can be due to progress to processing is not finished.
        /// </exception>
        /// <exception cref="TimeoutException">This exception can be due to no answer from service.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
        /// Sets the delegate for setting valid commands.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <param name="recognizedCommandsDelegate">The delegate for setting valid commands.</param>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static void SetRecognizedCommandsSelectionDelegate(SelectRecognizedCommandsDelegate recognizedCommandsDelegate)
        {
            ErrorCode error = ErrorCode.None;
            if (recognizedCommandsDelegate == null && _allRecognitionResult == null)
            {
                _recognizedCommandsDelegate = null;
                error = VcMgrUnsetAllResultCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove SetAllResult Failed with error " + error);
                }
                return;
            }

            if (_allRecognitionResult == null && _recognizedCommandsDelegate == null)
            {
                error = VcMgrSetAllResultCb(_recognizedCommandsSelectionCallback, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add SetRecognizedCommandsSelectionDelegate Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
            _recognizedCommandsDelegate = recognizedCommandsDelegate;
        }

        /// <summary>
        /// Called when client gets the all recognition results from vc-daemon.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<AllRecognitionResultEventArgs> AllRecognitionResultReceived
        {
            add
            {
                if (_allRecognitionResult == null && _recognizedCommandsDelegate == null)
                {
                    ErrorCode error = VcMgrSetAllResultCb(_recognizedCommandsSelectionCallback, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add AllRecognitionResult Failed with error " + error);
                    }
                }
                _allRecognitionResult += value;
            }

            remove
            {
                _allRecognitionResult -= value;
                if (_allRecognitionResult == null && _recognizedCommandsDelegate == null)
                {
                    ErrorCode error = VcMgrUnsetAllResultCb();
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Remove SetAllResult Failed with error " + error);
                    }
                }
            }
        }

        /// <summary>
        /// Called when client gets the pre recognition results(partial ASR) from vc-daemon.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<PreRecognitionResultUpdatedEventArgs> PreRecognitionResultUpdated
        {
            add
            {
                if (_preResult == null)
                {
                    _preResultDelegate = (PreResultEventType result, IntPtr recognizedText, IntPtr userData) =>
                    {
                        string recognizedString = Marshal.PtrToStringAnsi(recognizedText);
                        PreRecognitionResultUpdatedEventArgs args = new PreRecognitionResultUpdatedEventArgs(result, recognizedString);
                        _preResult?.Invoke(null, args);
                    };
                    ErrorCode error = VcMgrSetPreResultCb(_preResultDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add PreRecognitionResultUpdated Failed with error " + error);
                    }
                }
                _preResult += value;
            }

            remove
            {
                _preResult -= value;
                if (_preResult == null)
                {
                    ErrorCode error = VcMgrUnsetPreResultCb();
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Remove PreRecognitionResultUpdated Failed with error " + error);
                    }
                }
            }
        }

        /// <summary>
        /// Called when client gets the specific engine's result from vc-service.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<SpecificEngineResultEventArgs> SpecificEngineResult
        {
            add
            {
                if (_specificEngineResult == null)
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
                }
                _specificEngineResult += value;
            }

            remove
            {
                _specificEngineResult -= value;
                if (_specificEngineResult == null)
                {
                    ErrorCode error = VcMgrUnsetSpecificEngineResultCb();
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Remove SpecificEngineResult Failed with error " + error);
                    }
                }
            }
        }

        /// <summary>
        /// Event to be invoked when the recognition is done.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<RecognitionResultUpdatedEventArgs> RecognitionResultUpdated
        {
            add
            {
                if (_recognitionResult == null)
                {
                    s_resultDelegate = (RecognizedResult result, IntPtr cmdList, IntPtr recognizedText, IntPtr userData) =>
                    {
                        Log.Info(LogTag, "Recognition Result Updated Event Triggered");
                        if ((cmdList != null) && (recognizedText != null))
                        {
                            RecognitionResultUpdatedEventArgs args = new RecognitionResultUpdatedEventArgs(result, cmdList, recognizedText);
                            _recognitionResult?.Invoke(null, args);
                        }
                        else
                        {
                            Log.Info(LogTag, "Recognition Result Updated Event null received");
                        }
                    };
                    ErrorCode error = VcMgrSetResultCb(s_resultDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add RecognitionResultUpdated Failed with error " + error);
                    }
                }
                _recognitionResult += value;
            }

            remove
            {
                _recognitionResult -= value;
                if (_recognitionResult == null)
                {
                    ErrorCode error = VcMgrUnsetResultCb();
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Remove RecognitionResultUpdated Failed with error " + error);
                    }
                }
            }
        }

        /// <summary>
        /// Event to be invoked when the VoiceControl client state changes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The state must be initialized.
        /// </pre>
        public static event EventHandler<StateChangedEventArgs> StateChanged
        {
            add
            {
                if (_stateChanged == null)
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
                }
                _stateChanged += value;
            }

            remove
            {
                _stateChanged -= value;
                if (_stateChanged == null)
                {
                    ErrorCode error = VcMgrUnsetStateChangedCb();
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Remove StateChanged Failed with error " + error);
                    }
                }
            }
        }

        /// <summary>
        /// Event to be invoked when the VoiceControl service state changes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The state must be initialized.
        /// </pre>
        public static event EventHandler<ServiceStateChangedEventArgs> ServiceStateChanged
        {
            add
            {
                if (_serviceStateChanged == null)
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
                }
                _serviceStateChanged += value;
            }

            remove
            {
                _serviceStateChanged -= value;
                if (_serviceStateChanged == null)
                {
                    ErrorCode error = VcMgrUnsetServiceStateChangedCb();
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Remove ServiceStateChanged Failed with error " + error);
                    }
                }
            }
        }

        /// <summary>
        /// Called when user speaking is detected.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<EventArgs> SpeechDetected
        {
            add
            {
                if (_speechDetected == null)
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
                }
                _speechDetected += value;
            }

            remove
            {
                _speechDetected -= value;
                if (_speechDetected == null)
                {
                    ErrorCode error = VcMgrUnsetSpeechDetectedCb();
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Remove SpeechDetected Failed with error " + error);
                    }
                }
            }
        }

        /// <summary>
        /// Event to be invoked when the default language changes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The state must be initialized.
        /// </pre>
        public static event EventHandler<CurrentLanguageChangedEventArgs> CurrentLanguageChanged
        {
            add
            {
                if (_currentLanguageChanged == null)
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
                }
                _currentLanguageChanged += value;
            }

            remove
            {
                _currentLanguageChanged -= value;
                if (_currentLanguageChanged == null)
                {
                    ErrorCode error = VcMgrUnsetCurrentLanguageChangedCb();
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Remove CurrentLanguageChanged Failed with error " + error);
                    }
                }
            }
        }

        /// <summary>
        /// Event to be invoked when an error occurs.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The state must be initialized.
        /// </pre>
        public static event EventHandler<ErrorOccurredEventArgs> ErrorOccurred
        {
            add
            {
                if (_errorOccurred == null)
                {
                    _errorDelegate = (ErrorCode reason, IntPtr userData) =>
                    {
                        ErrorOccurredEventArgs args = new ErrorOccurredEventArgs(ExceptionFactory.CreateException(reason));
                        _errorOccurred?.Invoke(null, args);
                    };
                    ErrorCode error = VcMgrSetErrorCb(_errorDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add ErrorOccurred Failed with error " + error);
                    }
                }
                _errorOccurred += value;
            }

            remove
            {
                _errorOccurred -= value;
                if (_errorOccurred == null)
                {
                    ErrorCode error = VcMgrUnsetErrorCb();
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Remove ErrorOccurred Failed with error " + error);
                    }
                }
            }
        }

        /// <summary>
        /// Event to be called when conversation requests.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<ConversationRequestedEventArgs> ConversationRequested
        {
            add
            {
                if (_conversationRequested == null)
                {
                    _conversationRequestDelegate = (int pid, IntPtr dispText, IntPtr uttText, bool continuous, IntPtr userData) =>
                    {
                        string dispTextString = Marshal.PtrToStringAnsi(dispText);
                        string uttTextString = Marshal.PtrToStringAnsi(uttText);
                        ConversationRequestedEventArgs args = new ConversationRequestedEventArgs(ApplicationManager.GetAppId(pid), dispTextString, uttTextString, continuous);
                        _conversationRequested?.Invoke(null, args);
                    };
                    ErrorCode error = VcMgrSetDialogRequestCb(_conversationRequestDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add ConversationRequested Failed with error " + error);
                    }
                }
                _conversationRequested += value;
            }

            remove
            {
                _conversationRequested -= value;
                if (_conversationRequested == null)
                {
                    ErrorCode error = VcMgrUnsetDialogRequestCb();
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Remove ConversationRequested Failed with error " + error);
                    }
                }
            }
        }

        /// <summary>
        /// Enable command type as candidate command.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <param name="cmdType">Command Type</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to an invalid state.
        /// 2) This exception can be due to operation failed.
        /// </exception>
        /// <exception cref="TimeoutException">This exception can be due to no answer from service.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <param name="cmdType">Command Type</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to an invalid state.
        /// 2) This exception can be due to operation failed.
        /// </exception>
        /// <exception cref="TimeoutException">This exception can be due to no answer from service.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<PrivateDataUpdatedEventArgs> PrivateDataUpdated
        {
            add
            {
                if (_privateDataSet == null)
                {
                    _privateDataSetDelegate = (IntPtr key, IntPtr data, IntPtr userData) =>
                    {
                        string keyString = Marshal.PtrToStringAnsi(key);
                        string dataString = Marshal.PtrToStringAnsi(data);
                        PrivateDataUpdatedEventArgs args = new PrivateDataUpdatedEventArgs(keyString, dataString);
                        _privateDataSet?.Invoke(null, args);
                        return 0;
                    };
                    ErrorCode error = VcMgrSetPrivateDataSetCb(_privateDataSetDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add PrivateDataUpdated Failed with error " + error);
                    }
                }
                _privateDataSet += value;
            }

            remove
            {
                _privateDataSet -= value;
                if (_privateDataSet == null)
                {
                    ErrorCode error = VcMgrUnsetPrivateDataSetCb();
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Remove PrivateDataUpdated Failed with error " + error);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the delegate for setting private data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <param name="privateDataDelegate">The delegate for setting private data</param>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static void SetPrivateDataProviderDelegate(PrivateDataProvider privateDataDelegate)
        {
            if (privateDataDelegate == null)
            {
                Log.Error(LogTag, "callback is null");
                throw ExceptionFactory.CreateException(ErrorCode.InvalidParameter);
            }
            _privateDataRequestedDelegate = (string key, out string data, IntPtr userData) =>
            {
                data = privateDataDelegate.Invoke(key);
                if (data == null)
                    return VoiceError.InvalidParameter;
                return VoiceError.None;
            };
            ErrorCode error = VcMgrSetPrivateDataRequestedCb(_privateDataRequestedDelegate);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Add SetPrivateDataProviderDelegate Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Called when engine sends audio formats necessary for playing TTS feedback.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<FeedbackAudioFormatEventArgs> FeedbackAudioFormatChanged
        {
            add
            {
                if (_feedbackAudioFormat == null)
                {
                    _feedbackAudioFormatDelegate = (int rate, AudioChanelType channel, AudioType audiotype, IntPtr userData) =>
                    {
                        FeedbackAudioFormatEventArgs args = new FeedbackAudioFormatEventArgs(rate, channel, audiotype);
                        _feedbackAudioFormat?.Invoke(null, args);
                    };
                    ErrorCode error = VcMgrSetFeedbackAudioFormatCb(_feedbackAudioFormatDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add FeedbackStreaming Failed with error " + error);
                    }
                }
                _feedbackAudioFormat += value;
            }

            remove
            {
                _feedbackAudioFormat -= value;
                if (_feedbackAudioFormat == null)
                {
                    ErrorCode error = VcMgrUnsetFeedbackAudioFormatCb();
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Remove FeedbackAudioFormat Failed with error " + error);
                    }
                }
            }
        }

        /// <summary>
        /// Called when engine sends audio streaming for TTS feedback.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<FeedbackStreamingEventArgs> FeedbackStreaming
        {
            add
            {
                if (_feedbackStreaming == null)
                {
                    _feedbackStreamingDelegate = (FeedbackType type, IntPtr buffer, int len, IntPtr userData) =>
                    {
                        byte[] byteBuffer = new byte[len];
                        Marshal.Copy(buffer, byteBuffer, 0, len);
                        FeedbackStreamingEventArgs args = new FeedbackStreamingEventArgs(type, byteBuffer);
                        _feedbackStreaming?.Invoke(null, args);
                    };
                    ErrorCode error = VcMgrSetFeedbackStreamingCb(_feedbackStreamingDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add FeedbackStreaming Failed with error " + error);
                    }
                }
                _feedbackStreaming += value;
            }

            remove
            {
                _feedbackStreaming -= value;
                if (_feedbackStreaming == null)
                {
                    ErrorCode error = VcMgrUnsetFeedbackStreamingCb();
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Remove FeedbackStreaming Failed with error " + error);
                    }
                }
            }
        }

        /// <summary>
        /// Starts getting TTS feedback streaming data from the buffer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
        /// <privilege>http://tizen.org/privilege/voicecontrol.manager</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/speech.control_manager</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
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
        /// <pre>
        /// The State should be Initialized
        /// </pre>
        public static event EventHandler<VcTtsStreamingEventArgs> VcTtsStreaming
        {
            add
            {
                if (_vcTtsStreaming == null)
                {
                    _vcTtsStreamingDelegate = (int pid, int uttId, FeedbackType type, IntPtr buffer, int len, IntPtr userData) =>
                    {
                        byte[] byteBuffer = new byte[len];
                        Marshal.Copy(buffer, byteBuffer, 0, len);
                        VcTtsStreamingEventArgs args = new VcTtsStreamingEventArgs(ApplicationManager.GetAppId(pid), uttId, type, byteBuffer);
                        _vcTtsStreaming?.Invoke(null, args);
                    };
                    ErrorCode error = VcMgrSetVcTtsStreamingCb(_vcTtsStreamingDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add VcTtsStreaming Failed with error " + error);
                    }
                }
                _vcTtsStreaming += value;
            }

            remove
            {
                _vcTtsStreaming -= value;
                if (_vcTtsStreaming == null)
                {
                    ErrorCode error = VcMgrUnsetVcTtsStreamingCb();
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Remove VcTtsStreaming Failed with error " + error);
                    }
                }
            }
        }
    }
}

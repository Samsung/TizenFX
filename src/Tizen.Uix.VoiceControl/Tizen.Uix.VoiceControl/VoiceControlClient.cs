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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Interop.VoiceControl;
using static Interop.VoiceControlCommand;

namespace Tizen.Uix.VoiceControl
{
    /// <summary>
    /// Enumeration for the error values that can occur.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        InProgressToProcessing
    };

    /// <summary>
    /// Enumeration for the client state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        Unavailable
    };

    /// <summary>
    /// Enumeration for the service state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        Unavailable
    };

    /// <summary>
    /// Enumeration for the result event.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// <since_tizen> 3 </since_tizen>
    public enum CommandType
    {
        /// <summary>
        /// Foreground command by the client.
        /// </summary>
        Foreground = 1,
        /// <summary>
        /// Background command by the client.
        /// </summary>
        Background = 2,
        /// <summary>
        /// The undefined command.
        /// </summary>
        Undefined = -1
    };

    /// <summary>
    /// A main function of the voice control API registers the command and gets a notification for the recognition result.
    /// Applications can add their own commands and provide results when their command is recognized by the user voice input.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public static class VoiceControlClient
    {
        private static event EventHandler<RecognitionResultEventArgs> _recognitionResult;
        private static event EventHandler<StateChangedEventArgs> _stateChanged;
        private static event EventHandler<ServiceStateChangedEventArgs> _serviceStateChanged;
        private static event EventHandler<ErrorOccuredEventArgs> _errorOccured;
        private static event EventHandler<CurrentLanguageChangedEventArgs> _currentLanguageChanged;
        private static readonly Object _recognitionResultLock = new Object();
        private static readonly Object _stateChangedLock = new Object();
        private static readonly Object _serviceStateChangedLock = new Object();
        private static readonly Object _errorOccuredLock = new Object();
        private static readonly Object _currentLanguageChangedLock = new Object();
        private static VcResultCb s_resultDelegate;
        private static VcStateChangedCb s_stateDelegate;
        private static VcServiceStateChangedCb s_serviceStateDelegate;
        private static VcErrorCb s_errorDelegate;
        private static VcCurrentLanguageChangedCb s_languageDelegate;
        private static List<string> s_supportedLanguages;
        private static VcSupportedLanguageCb s_supportedLanguagesCb;
        private static VcResultCb s_resultCb;
        private static RecognitionResult s_recognitionResult;

        /// <summary>
        /// Gets the current language.
        /// A language is specified as an ISO 3166 alpha-2 two letter country-code
        /// followed by ISO 639-1 for the two-letter language code.
        /// For example, "ko_KR" for Korean, "en_US" for American English.
        /// An empty string is returned in case of some internal error.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// The current language in voice control.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <pre>
        /// The state must be initialized or ready.
        /// </pre>
        public static string CurrentLanguage
        {
            get
            {
                string currentLanguage;
                ErrorCode error = VcGetCurrentLanguage(out currentLanguage);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "CurrentLanguage Failed with error " + error);
                    return "";
                }

                return currentLanguage;
            }
        }

        /// <summary>
        /// Gets the current state of the voice control client.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// The current state of the voice control client.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <pre>
        /// The state must be initialized or ready.
        /// </pre>
        public static State State
        {
            get
            {
                State state;
                ErrorCode error = VcGetState(out state);
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
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// The current state of the voice control service.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <pre>
        /// The state must be ready.
        /// </pre>
        public static ServiceState ServiceState
        {
            get
            {
                ServiceState state;

                ErrorCode error = VcGetServiceState(out state);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "ServiceState Failed with error " + error);
                    return ServiceState.Unavailable;
                }

                return state;
            }
        }

        /// <summary>
        /// Sets the invocation name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <remarks>
        /// The invocation name is used to activate background commands. The invocation name can be same as the application name or any other phrase.
        /// For example, an application "Tizen Sample" has a background command, "Play music", and the invocation name of the application is set to "Tizen Sample".
        /// In order to activate the background command, users can say "Tizen Sample, Play music". The invocation name is dependent on the current language.
        /// For example, if the current language is "en_US"(English), the invocation name is also "en_US".
        /// If the current language is "ja_JP"(Japanese) and the invocation name is "en_US", the invocation name will not be recognized.
        /// This function should be called before the SetCommandList().
        /// </remarks>
        /// <param name="name">Invocation name to be invoked by an application.</param>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <pre>
        /// The state must be ready.
        /// </pre>
        public static void SetInvocationName(string name)
        {
            ErrorCode error = VcSetInvocationName(name);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetInvocationName Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Initializes the voice control.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
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
        /// <exception cref="OutOfMemoryException">This exception can be due to out Of memory.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <post>
        /// The state will be initialized.
        /// </post>
        public static void Initialize()
        {
            ErrorCode error = VcInitialize();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Initialize Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Deinitializes the voice control.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
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
        public static void Deinitialize()
        {
            ErrorCode error = VcDeinitialize();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Deinitialize Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Connects the voice control service.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
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
            ErrorCode error = VcPrepare();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Prepare Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Disconnects the voice control service.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
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
            ErrorCode error = VcUnprepare();
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
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
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
            s_supportedLanguages = new List<string>();
            s_supportedLanguagesCb = (IntPtr language, IntPtr userData) =>
            {
                string languageStr = Marshal.PtrToStringAnsi(language);
                s_supportedLanguages.Add(languageStr);
                return true;
            };

            ErrorCode error = VcForeachSupportedLanguages(s_supportedLanguagesCb, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetSupportedLanguages Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return s_supportedLanguages;
        }

        /// <summary>
        /// Gets the system command list.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// The command list, else null in case of no system commands.
        /// </returns>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <privlevel>
        /// public.
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <remarks>
        /// In the system command list, there are system commands predefined by product manufacturers.
        /// Those commands have the highest priority. Therefore, the user cannot set any commands similar to system commands.
        /// </remarks>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <pre>
        /// The state must be ready.
        /// </pre>
        public static VoiceCommandList GetSystemCommandList()
        {
            IntPtr handle = IntPtr.Zero;
            ErrorCode error = VcGetSystemCommandList(out handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetSystemCommandList Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            if (handle == IntPtr.Zero)
            {
                Log.Error(LogTag, "GetSystemCommandList handle is null");
                return null;
            }

            SafeCommandListHandle list = new SafeCommandListHandle(handle);
            return new VoiceCommandList(list);
        }

        /// <summary>
        /// Requests to start the dialogue.
        /// By using this function, the developer can start requesting the dialogue to the framework.
        /// When the developer requests the dialogue, two types of texts, dispText and uttText can be sent by this function. dispText is a text for displaying and uttText is that for uttering.
        /// For example, if dispText is "October 10th" and uttText is "Today is October 10th.", "October 10th" will be displayed on the screen and "Today is October 10th." will be spoken.
        /// Also, the developer can set whether the dialogue starts automatically or not, using autoStart.
        /// If the developer sets autoStart as True, the framework will start to record the next speech and continue the dialogue.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <remarks>
        /// If autoStart is True, the recognition will start again. In this case, it can be restarted up to 4 times.
        /// </remarks>
        /// <param name="dispText">Text to be displayed on the screen.</param>
        /// <param name="uttText">Text to be spoken.</param>
        /// <param name="autoStart">A variable for setting whether the dialog session will be restarted automatically or not.</param>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <pre>
        /// The state must be ready.
        /// </pre>
        public static void RequestDialog(string dispText, string uttText, bool autoStart)
        {
            ErrorCode error = VcRequestDialog(dispText, uttText, autoStart);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "RequestDialog Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Sets the command list.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <remarks>
        /// The command type is valid for CommandType 'Foreground' or 'Background'.
        /// The matched commands of the command list should be set and they should include type and command text at least.
        /// </remarks>
        /// <param name="list">Command list</param>
        /// <param name="type">Command type</param>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <pre>
        /// The state must be ready.
        /// </pre>
        public static void SetCommandList(VoiceCommandList list, CommandType type)
        {
            if ((type == CommandType.Foreground) || (type == CommandType.Background))
            {
                ErrorCode error = VcSetCommandList(list._handle, (VoiceCommandType)type);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "SetCommandList Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }

            else
            {
                throw ExceptionFactory.CreateException(ErrorCode.InvalidParameter);
            }
        }

        /// <summary>
        /// Unsets the command list.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <privlevel>
        /// public
        /// </privlevel>
        /// <feature>
        /// http://tizen.org/feature/speech.control
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <param name="type">Command type</param>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <pre>
        /// The state should be ready.
        /// </pre>
        public static void UnsetCommandList(CommandType type)
        {
            if ((type == CommandType.Foreground) || (type == CommandType.Background))
            {
                VoiceCommandType commandType = VoiceCommandType.Foreground;
                if (type == CommandType.Background)
                    commandType = VoiceCommandType.BackGround;

                ErrorCode error = VcUnsetCommandList(commandType);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "UnsetCommandList Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
            else
            {
                throw ExceptionFactory.CreateException(ErrorCode.InvalidParameter);
            }
        }

        /// <summary>
        /// Gets the recognition result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
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
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        /// <returns>The recognition result if possible, else a null object.</returns>
        /// <pre>
        /// The state must be ready.
        /// </pre>
        public static RecognitionResult GetResult()
        {
            s_recognitionResult = null;
            s_resultCb = (ResultEvent evt, IntPtr cmdList, IntPtr result, IntPtr userData) =>
            {
                s_recognitionResult = new RecognitionResult(evt, cmdList, result);
            };

            ErrorCode error = VcGetResult(s_resultCb, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetResult Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return s_recognitionResult;
        }

        /// <summary>
        /// Event to be invoked when the recognition is done.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <pre>
        /// The state must be initialized.
        /// </pre>
        public static event EventHandler<RecognitionResultEventArgs> RecognitionResult
        {
            add
            {
                lock (_recognitionResultLock)
                {
                    if (_recognitionResult == null)
                    {
                        s_resultDelegate = (ResultEvent evt, IntPtr cmdList, IntPtr result, IntPtr userData) =>
                        {
                            Log.Info(LogTag, "Recognition Result Event Triggered");
                            if ((cmdList != null) && (result != null))
                            {
                                RecognitionResultEventArgs args = new RecognitionResultEventArgs(new RecognitionResult(evt, cmdList, result));
                                _recognitionResult?.Invoke(null, args);
                            }
                            else
                            {
                                Log.Info(LogTag, "Recognition Result Event null received");
                            }
                        };

                        ErrorCode error = VcSetResultCb(s_resultDelegate, IntPtr.Zero);
                        if (error != ErrorCode.None)
                        {
                            Log.Error(LogTag, "Add RecognitionResult Failed with error " + error);
                        }
                    }
                    _recognitionResult += value;
                }
            }

            remove
            {
                lock (_recognitionResultLock)
                {
                    _recognitionResult -= value;
                    if (_recognitionResult == null)
                    {
                        ErrorCode error = VcUnsetResultCb();
                        if (error != ErrorCode.None)
                        {
                            Log.Error(LogTag, "Remove RecognitionResult Failed with error " + error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event to be invoked when the VoiceControl service state changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <pre>
        /// The state must be initialized.
        /// </pre>
        public static event EventHandler<ServiceStateChangedEventArgs> ServiceStateChanged
        {
            add
            {
                lock (_serviceStateChangedLock)
                {
                    if (_serviceStateChanged == null)
                    {
                        s_serviceStateDelegate = (ServiceState previous, ServiceState current, IntPtr userData) =>
                        {
                            ServiceStateChangedEventArgs args = new ServiceStateChangedEventArgs(previous, current);
                            _serviceStateChanged?.Invoke(null, args);
                        };

                        ErrorCode error = VcSetServiceStateChangedCb(s_serviceStateDelegate, IntPtr.Zero);
                        if (error != ErrorCode.None)
                        {
                            Log.Error(LogTag, "Add ServiceStateChanged Failed with error " + error);
                        }
                    }
                    _serviceStateChanged += value;
                }
            }

            remove
            {
                lock (_serviceStateChangedLock)
                {
                    _serviceStateChanged -= value;
                    if (_serviceStateChanged == null)
                    {
                        ErrorCode error = VcUnsetServiceStateChangedCb();
                        if (error != ErrorCode.None)
                        {
                            Log.Error(LogTag, "Remove ServiceStateChanged Failed with error " + error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event to be invoked when the VoiceControl client state changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <pre>
        /// The state must be initialized.
        /// </pre>
        public static event EventHandler<StateChangedEventArgs> StateChanged
        {
            add
            {
                lock (_stateChangedLock)
                {
                    if (_stateChanged == null)
                    {
                        s_stateDelegate = (State previous, State current, IntPtr userData) =>
                        {
                            StateChangedEventArgs args = new StateChangedEventArgs(previous, current);
                            _stateChanged?.Invoke(null, args);
                        };

                        ErrorCode error = VcSetStateChangedCb(s_stateDelegate, IntPtr.Zero);
                        if (error != ErrorCode.None)
                        {
                            Log.Error(LogTag, "Add StateChanged Failed with error " + error);
                        }
                    }
                    _stateChanged += value;
                }
            }

            remove
            {
                lock (_stateChangedLock)
                {
                    _stateChanged -= value;
                    if (_stateChanged == null)
                    {
                        ErrorCode error = VcUnsetStateChangedCb();
                        if (error != ErrorCode.None)
                        {
                            Log.Error(LogTag, "Remove StateChanged Failed with error " + error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event to be invoked when an error occurs.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <pre>
        /// The state must be initialized.
        /// </pre>
        public static event EventHandler<ErrorOccuredEventArgs> ErrorOccured
        {
            add
            {
                lock (_errorOccuredLock)
                {
                    if (_errorOccured == null)
                    {
                        s_errorDelegate = (ErrorCode reason, IntPtr userData) =>
                        {
                            ErrorOccuredEventArgs args = new ErrorOccuredEventArgs(reason);
                            _errorOccured?.Invoke(null, args);
                        };

                        ErrorCode error = VcSetErrorCb(s_errorDelegate, IntPtr.Zero);
                        if (error != ErrorCode.None)
                        {
                            Log.Error(LogTag, "Add ErrorOccured Failed with error " + error);
                        }
                    }
                    _errorOccured += value;
                }
            }

            remove
            {
                lock (_errorOccuredLock)
                {
                    _errorOccured -= value;
                    if (_errorOccured == null)
                    {
                        ErrorCode error = VcUnsetErrorCb();
                        if (error != ErrorCode.None)
                        {
                            Log.Error(LogTag, "Remove ErrorOccured Failed with error " + error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event to be invoked when the default language changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <pre>
        /// The state must be initialized.
        /// </pre>
        public static event EventHandler<CurrentLanguageChangedEventArgs> CurrentLanguageChanged
        {
            add
            {
                lock (_currentLanguageChangedLock)
                {
                    if (_currentLanguageChanged == null)
                    {
                        s_languageDelegate = (IntPtr previousLanguage, IntPtr currentLanguage, IntPtr userData) =>
                        {
                            string previousLanguageString = Marshal.PtrToStringAnsi(previousLanguage);
                            string currentLanguageString = Marshal.PtrToStringAnsi(currentLanguage);
                            CurrentLanguageChangedEventArgs args = new CurrentLanguageChangedEventArgs(previousLanguageString, currentLanguageString);
                            _currentLanguageChanged?.Invoke(null, args);
                        };

                        ErrorCode error = VcSetCurrentLanguageChangedCb(s_languageDelegate, IntPtr.Zero);
                        if (error != ErrorCode.None)
                        {
                            Log.Error(LogTag, "Add CurrentLanguageChanged Failed with error " + error);
                        }
                    }
                    _currentLanguageChanged += value;
                }
            }

            remove
            {
                lock (_currentLanguageChangedLock)
                {
                    _currentLanguageChanged -= value;
                    if (_currentLanguageChanged == null)
                    {
                        ErrorCode error = VcUnsetCurrentLanguageChangedCb();
                        if (error != ErrorCode.None)
                        {
                            Log.Error(LogTag, "Remove CurrentLanguageChanged Failed with error " + error);
                        }
                    }
                }
            }
        }
    }
}

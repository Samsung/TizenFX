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
    /// Enum for Error values that can occur
    /// </summary>
    public enum Error
    {
        /// <summary>
        /// Successful, No error
        /// </summary>
        None,
        /// <summary>
        /// Out of Memory
        /// </summary>
        OutOfMemory,
        /// <summary>
        /// I/O error
        /// </summary>
        IoError,
        /// <summary>
        /// Invalid parameter
        /// </summary>
        InvalidParameter,
        /// <summary>
        /// No answer from the STT service
        /// </summary>
        TimedOut,
        /// <summary>
        /// Device or resource busy
        /// </summary>
        RecorderBusy,
        /// <summary>
        /// Permission denied
        /// </summary>
        PermissionDenied,
        /// <summary>
        /// VC NOT supported
        /// </summary>
        NotSupported,
        /// <summary>
        /// Invalid state
        /// </summary>
        InvalidState,
        /// <summary>
        /// Invalid language
        /// </summary>
        InvalidLanguage,
        /// <summary>
        /// No available engine
        /// </summary>
        EngineNotFound,
        /// <summary>
        /// Operation failed
        /// </summary>
        OperationFailed,
        /// <summary>
        /// Operation Rejected
        /// </summary>
        OperationRejected,
        /// <summary>
        /// List reached end
        /// </summary>
        IterationEnd,
        /// <summary>
        /// List Empty
        /// </summary>
        Empty,
        /// <summary>
        /// Service reset
        /// </summary>
        ServiceReset,
        /// <summary>
        /// Progress to ready is not finished
        /// </summary>
        InProgressToReady,
        /// <summary>
        /// Progress to recording is not finished
        /// </summary>
        InProgressToRecording,
        /// <summary>
        /// Progress to processing is not finished
        /// </summary>
        InProgressToProcessing
    };

    /// <summary>
    /// Enumeration for the client state.
    /// </summary>
    public enum State
    {
        /// <summary>
        /// 'None' state
        /// </summary>
        None = 0,
        /// <summary>
        /// 'Initialized' state
        /// </summary>
        Initialized = 1,
        /// <summary>
        /// 'Ready' state
        /// </summary>
        Ready = 2,
        /// <summary>
        /// state cannot be determined
        /// </summary>
        Unavailable
    };

    /// <summary>
    /// Enumerations of service state.
    /// </summary>
    public enum ServiceState
    {
        /// <summary>
        /// 'None' state
        /// </summary>
        None = 0,
        /// <summary>
        /// 'Ready' state
        /// </summary>
        Ready = 1,
        /// <summary>
        /// 'Recording' state
        /// </summary>
        Recording = 2,
        /// <summary>
        /// 'Processing' state
        /// </summary>
        Processing = 3,
        /// <summary>
        /// state cannot be determined
        /// </summary>
        Unavailable
    };

    /// <summary>
    /// Enumerations of result event.
    /// </summary>
    public enum ResultEvent
    {
        /// <summary>
        /// Normal result
        /// </summary>
        Success = 0,
        /// <summary>
        /// Rejected result
        /// </summary>
        Rejected = 1
    };

    /// <summary>
    /// Enumerations of command type.
    /// </summary>
    public enum CommandType
    {
        /// <summary>
        /// Foreground command by client
        /// </summary>
        Foreground = 1,
        /// <summary>
        /// Background command by client
        /// </summary>
        Background = 2,
        /// <summary>
        /// Undefined command
        /// </summary>
        Undefined = -1
    };

    /// <summary>
    /// A main function of Voice Control API register command and gets notification for recognition result. 
    /// Applications can add their own commands and be provided result when their command is recognized by user voice input.
    /// </summary>
    public static class VoiceControlClient
    {
        /// <summary>
        /// Called when client gets the recognition result.
        /// </summary>
        /// <remarks>
        /// If the duplicated commands are recognized, the event(e.g. Result.Rejected) of command may be rejected
        /// for selecting command as priority.If you set similar or same commands or the recognized results are multi-results, cmdList has the multi commands.
        /// </remarks>
        /// <param name="evt">The ResultEvent</param>
        /// <param name="cmdList">Command List</param>
        /// <param name="result">Result</param>
        public delegate void RecognitionResultDelegate(ResultEvent evt, VoiceCommandList cmdList, string result);

        private static event EventHandler<RecognitionResultEventArgs> _recognitionResult;
        private static event EventHandler<StateChangedEventArgs> _stateChanged;
        private static event EventHandler<ServiceStateChangedEventArgs> _serviceStateChanged;
        private static event EventHandler<ErrorOccuredEventArgs> _errorOccured;
        private static event EventHandler<CurrentLanguageChangedEventArgs> _currentLanguageChanged;
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
        /// Gets current language.
        /// A language is specified as an ISO 3166 alpha-2 two letter country-code
        /// followed by ISO 639-1 for the two-letter language code.
        /// For example, "ko_KR" for Korean, "en_US" for American English.
        /// Empty string is returned incase of some internal error
        /// </summary>
        /// <value>
        /// Current language in voice control.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <precondition>
        /// The State must be Initialized or Ready.
        /// </precondition>
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
        /// Gets current state of voice control client.
        /// </summary>
        /// <value>
        /// Current state of voice control client.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <precondition>
        /// The State must be Initialized or Ready.
        /// </precondition>
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
        /// Gets current state of voice control service.
        /// </summary>
        /// <value>
        /// Current state of voice control service.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <precondition>
        /// The State must be Ready.
        /// </precondition>
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
        /// Invocation name is used to activate background commands. The invocation name can be the same as the application name or any other phrase.
        /// For example, an application "Tizen Sample" has a background command, "Play music", and the invocation name of the application is set to "Tizen Sample".
        /// In order to activate the background command, users can say "Tizen Sample, Play music". The invocation name is dependent on the current language.
        /// For example, if the current language is "en_US"(English), the invocation name is also "en_US".
        /// If the current language is "ja_JP"(Japanese) and the invocation name is "en_US", the invocation name will not be recognized.
        /// This function should be called before SetCommandList().
        /// </remarks>
        /// <param name="name">Invocation name that an application wants to be invoked by</param>
        /// <exception cref="InvalidOperationException"> This Exception can be due to Invalid State. </exception>
        /// <exception cref="ArgumentException"> This Exception can be due to Invalid Parameter. </exception>
        /// <exception cref="NotSupportedException"> This Exception can be due to Not Supported. </exception>
        /// <exception cref="UnauthorizedAccessException"> This Exception can be due to Permission Denied. </exception>
        /// <precondition>
        /// The State must be Ready.
        /// </precondition>
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
        /// Initializes voice control.
        /// </summary>
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
        /// <exception cref="InvalidOperationException"> This Exception can be due to Operation Failed. </exception>
        /// <exception cref="OutOfMemoryException"> This Exception can be due to Out Of Memory. </exception>
        /// <exception cref="NotSupportedException"> This Exception can be due to Not Supported. </exception>
        /// <exception cref="UnauthorizedAccessException"> This Exception can be due to Permission Denied. </exception>
        /// <postcondition>
        /// The State will be Initialized.
        /// </postcondition>
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
        /// Deinitializes voice control.
        /// </summary>
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
        /// <exception cref="InvalidOperationException"> This Exception can be due to Invalid State. </exception>
        /// <exception cref="InvalidOperationException"> This Exception can be due to Operation Failed. </exception>
        /// <exception cref="NotSupportedException"> This Exception can be due to Not Supported. </exception>
        /// <exception cref="UnauthorizedAccessException"> This Exception can be due to Permission Denied. </exception>
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
        /// <exception cref="InvalidOperationException"> This Exception can be due to Invalid State. </exception>
        /// <exception cref="InvalidOperationException"> This Exception can be due to Operation Failed. </exception>
        /// <exception cref="NotSupportedException"> This Exception can be due to Not Supported. </exception>
        /// <exception cref="UnauthorizedAccessException"> This Exception can be due to Permission Denied. </exception>
        /// <precondition>
        /// The State should be Initialized
        /// </precondition>
        /// <postcondition>
        /// The State will be Ready
        /// </postcondition>
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
        /// <exception cref="InvalidOperationException"> This Exception can be due to Invalid State. </exception>
        /// <exception cref="NotSupportedException"> This Exception can be due to Not Supported. </exception>
        /// <exception cref="UnauthorizedAccessException"> This Exception can be due to Permission Denied. </exception>
        /// <precondition>
        /// The State should be Ready
        /// </precondition>
        /// <postcondition>
        /// The State should be Initialized
        /// </postcondition>
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
        /// Retrieves all supported languages.
        /// A language is specified as an ISO 3166 alpha-2 two letter country-code
        /// followed by ISO 639-1 for the two-letter language code.
        /// For example, "ko_KR" for Korean, "en_US" for American English.
        /// </summary>
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
        /// <exception cref="InvalidOperationException"> This Exception can be due to Invalid State. </exception>
        /// <exception cref="InvalidOperationException"> This Exception can be due to Operation Failed. </exception>
        /// <exception cref="NotSupportedException"> This Exception can be due to Not Supported. </exception>
        /// <exception cref="UnauthorizedAccessException"> This Exception can be due to Permission Denied. </exception>
        /// <precondition>
        /// The State should be Ready or Initialized
        /// </precondition>
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
        /// <returns>
        /// The Command List else null in case of no System Commands
        /// </returns>
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
        /// In the system command list, there are system commands predefined by product manufacturers.
        /// Those commands have the highest priority. Therefore, the user can not set any commands same with the system commands.
        /// </remarks>
        /// <exception cref="InvalidOperationException"> This Exception can be due to Invalid State. </exception>
        /// <exception cref="InvalidOperationException"> This Exception can be due to Operation Failed. </exception>
        /// <exception cref="NotSupportedException"> This Exception can be due to Not Supported. </exception>
        /// <exception cref="UnauthorizedAccessException"> This Exception can be due to Permission Denied. </exception>
        /// <precondition>
        /// The State should be Ready
        /// </precondition>
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
        /// Using this function, the developer can request starting the dialogue to the framework.
        /// When the developer requests the dialogue, two types of texts, dispText and uttText, can be sent by this function.dispText is a text for displaying, and uttText is that for uttering.
        /// For example, if dispText is "October 10th" and uttText is "Today is October 10th.", "October 10th" will be displayed on the screen and "Today is October 10th." will be spoken.
        /// Also, the developer can set whether the dialogue starts automatically or not, using autoStart.
        /// If the developer sets autoStart as true, the framework will start to record next speech and continue the dialogue.
        /// </summary>
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
        /// If autoStart is true, the recognition will start again. In this case, it can be restarted up to 4 times.
        /// </remarks>
        /// <param name="dispText"> Text to be displayed on the screen/// </param>
        /// <param name="uttText">Text to be spoken</param>
        /// <param name="autoStart">A variable for setting whether the dialog session will be restarted automatically or not</param>
        /// <exception cref="InvalidOperationException"> This Exception can be due to Invalid State. </exception>
        /// <exception cref="ArgumentException"> This Exception can be due to Invalid Parameter. </exception>
        /// <exception cref="NotSupportedException"> This Exception can be due to Not Supported. </exception>
        /// <exception cref="UnauthorizedAccessException"> This Exception can be due to Permission Denied. </exception>
        /// <precondition>
        /// The State should be Ready
        /// </precondition>
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
        /// Sets command list.
        /// </summary>
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
        /// The matched commands of command list should be set and they should include type and command text at least.
        /// </remarks>
        /// <param name="list">Command list</param>
        /// <param name="type">Command type</param>
        /// <exception cref="InvalidOperationException"> This Exception can be due to Invalid State. </exception>
        /// <exception cref="ArgumentException"> This Exception can be due to Invalid Parameter. </exception>
        /// <exception cref="NotSupportedException"> This Exception can be due to Not Supported. </exception>
        /// <exception cref="UnauthorizedAccessException"> This Exception can be due to Permission Denied. </exception>
        /// <precondition>
        /// The State should be Ready
        /// </precondition>
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
        /// Unsets command list.
        /// </summary>
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
        /// <exception cref="InvalidOperationException"> This Exception can be due to Invalid State. </exception>
        /// <exception cref="ArgumentException"> This Exception can be due to Invalid Parameter. </exception>
        /// <exception cref="NotSupportedException"> This Exception can be due to Not Supported. </exception>
        /// <exception cref="UnauthorizedAccessException"> This Exception can be due to Permission Denied. </exception>
        /// <precondition>
        /// The State should be Ready
        /// </precondition>
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
        /// <exception cref="InvalidOperationException"> This Exception can be due to Invalid State. </exception>
        /// <exception cref="ArgumentException"> This Exception can be due to Invalid Parameter. </exception>
        /// <exception cref="NotSupportedException"> This Exception can be due to Not Supported. </exception>
        /// <returns>The Recognition Result if possible else a null object</returns>
        /// <precondition>
        /// The State should be Ready
        /// </precondition>
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
        /// <precondition>
        /// The State should be Initialized
        /// </precondition>
        public static event EventHandler<RecognitionResultEventArgs> RecognitionResult
        {
            add
            {
                s_resultDelegate = (ResultEvent evt, IntPtr cmdList, IntPtr result, IntPtr userData) =>
                {
                    Log.Info(LogTag, "Recognition Result Event Triggered");
                    if ((cmdList != null) && (result != null))
                    {
                        RecognitionResultEventArgs args = new RecognitionResultEventArgs(new RecognitionResult( evt, cmdList, result));
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
                else
                {
                    _recognitionResult += value;
                }
            }

            remove
            {
                ErrorCode error = VcUnsetResultCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove RecognitionResult Failed with error " + error);
                }

                _recognitionResult -= value;
            }
        }

        /// <summary>
        /// Event to be invoked when VoiceControl service state changes.
        /// </summary>
        /// <precondition>
        /// The State should be Initialized
        /// </precondition>
        public static event EventHandler<ServiceStateChangedEventArgs> ServiceStateChanged
        {
            add
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
                else
                {
                    _serviceStateChanged += value;
                }
            }

            remove
            {
                ErrorCode error = VcUnsetServiceStateChangedCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove ServiceStateChanged Failed with error " + error);
                }

                _serviceStateChanged -= value;
            }
        }

        /// <summary>
        /// Event to be invoked when VoiceControl client state changes.
        /// </summary>
        /// <precondition>
        /// The State should be Initialized
        /// </precondition>
        public static event EventHandler<StateChangedEventArgs> StateChanged
        {
            add
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
                else
                {
                    _stateChanged += value;
                }
            }

            remove
            {
                ErrorCode error = VcUnsetStateChangedCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove StateChanged Failed with error " + error);
                }

                _stateChanged -= value;
            }
        }

        /// <summary>
        /// Event to be invoked when an error occurs.
        /// </summary>
        /// <precondition>
        /// The State should be Initialized
        /// </precondition>
        public static event EventHandler<ErrorOccuredEventArgs> ErrorOccured
        {
            add
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

                else
                {
                    _errorOccured += value;
                }
            }


            remove
            {
                ErrorCode error = VcUnsetErrorCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove ErrorOccured Failed with error " + error);
                }

                _errorOccured -= value;
            }
        }

        /// <summary>
        /// Event to be invoked when default laungage change.
        /// </summary>
        /// <precondition>
        /// The State should be Initialized
        /// </precondition>
        public static event EventHandler<CurrentLanguageChangedEventArgs> CurrentLanguageChanged
        {
            add
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

                else
                {
                    _currentLanguageChanged += value;
                }
            }

            remove
            {
                ErrorCode error = VcUnsetCurrentLanguageChangedCb();
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove CurrentLanguageChanged Failed with error " + error);
                }

                _currentLanguageChanged -= value;
            }
        }
    }
}

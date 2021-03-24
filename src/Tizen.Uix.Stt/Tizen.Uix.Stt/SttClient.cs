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
using static Interop.Stt;

namespace Tizen.Uix.Stt
{
    /// <summary>
    /// The token event.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ResultEvent
    {
        /// <summary>
        /// Event when the recognition for full or last result is ready.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        FinalResult = 0,
        /// <summary>
        /// Event when the recognition for partial result is ready.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        PartialResult,
        /// <summary>
        /// Event when the recognition has failed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Error
    };

    /// <summary>
    /// Enumeration for representing the result message.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ResultMessage
    {
        /// <summary>
        /// No Error.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        None,
        /// <summary>
        /// Recognition failed  because the speech started too soon.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        TooSoon,
        /// <summary>
        /// Recognition failed  because the speech is too short.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        TooShort,
        /// <summary>
        /// Recognition failed  because the speech is too long.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        TooLong,
        /// <summary>
        /// Recognition failed  because the speech is too quiet to listen.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        TooQuiet,
        /// <summary>
        /// Recognition failed  because the speech is too loud to listen.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        TooLoud,
        /// <summary>
        /// Recognition failed  because the speech is too fast to listen.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        TooFast
    };

    /// <summary>
    /// Enumeration for the token types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum TimeEvent
    {
        /// <summary>
        /// Event when the token is beginning type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Beginning = 0,
        /// <summary>
        /// Event when the token is middle type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Middle = 1,
        /// <summary>
        /// Event when the token is end type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        End = 2
    };

    /// <summary>
    /// Enumeration for the error values that can occur.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum Error
    {
        /// <summary>
        /// Successful, No error.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        None,
        /// <summary>
        /// Out of Memory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>.
        OutOfMemory,
        /// <summary>
        /// I/O error.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>.
        IoError,
        /// <summary>
        /// Invalid parameter.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        InvalidParameter,
        /// <summary>
        /// No answer from the STT service.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        TimedOut,
        /// <summary>
        /// Device or resource busy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        RecorderBusy,
        /// <summary>
        /// Network is down.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        OutOfNetwork,
        /// <summary>
        /// Permission denied.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        PermissionDenied,
        /// <summary>
        /// STT NOT supported.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        NotSupported,
        /// <summary>
        /// Invalid state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        InvalidState,
        /// <summary>
        /// Invalid language.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        InvalidLanguage,
        /// <summary>
        /// No available engine.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        EngineNotFound,
        /// <summary>
        /// Operation failed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        OperationFailed,
        /// <summary>
        /// Not supported feature of current engine.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        NotSupportedFeature,
        /// <summary>
        /// Recording timed out.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        RecordingTimedOut,
        /// <summary>
        /// No speech while recording.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        NoSpeech,
        /// <summary>
        /// Progress to ready is not finished.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        InProgressToReady,
        /// <summary>
        /// Progress to recording is not finished.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        InProgressToRecording,
        /// <summary>
        /// Progress to processing is not finished.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        InProgressToProcessing,
        /// <summary>
        /// Service reset.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ServiceReset
    };

    /// <summary>
    /// Enumeration for the recognition types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum RecognitionType
    {
        /// <summary>
        /// Free form dictation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Free,
        /// <summary>
        /// Continuous free dictation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Partial,
        /// <summary>
        /// Search.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Search,
        /// <summary>
        /// Web search.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        WebSearch,
        /// <summary>
        /// Map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Map
    };

    /// <summary>
    /// Enumeration for the state types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum State
    {
        /// <summary>
        /// Created state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Created = 0,
        /// <summary>
        /// Ready state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Ready = 1,
        /// <summary>
        /// Recording state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Recording = 2,
        /// <summary>
        /// Processing state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Processing = 3,
        /// <summary>
        /// Unavailable.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Unavailable
    };

    /// <summary>
    /// Enumeration for the silence detection types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum SilenceDetection
    {
        /// <summary>
        /// Silence detection type - False.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        False = 0,
        /// <summary>
        /// Silence detection type - True.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        True = 1,
        /// <summary>
        /// Silence detection type - Auto.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Auto = 2
    };

    /// <summary>
    /// A main function of Speech-To-Text (below STT) API recognizes sound data recorded by users.
    /// After choosing a language, the applications will start recording and recognizing.
    /// After recording, the applications will receive the recognized result.
    /// The STT has a client-server for the service of multi-applications.
    /// The STT service always works in the background as a server. If the service is not working, client library will invoke it and the client will communicate with it.
    /// The service has engines and a recorder, so that the client does not have the recorder itself. Only the client request commands to the STT service for using STT.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class SttClient : IDisposable
    {
        private IntPtr _handle;
        private event EventHandler<RecognitionResultEventArgs> _recognitionResult;
        private event EventHandler<StateChangedEventArgs> _stateChanged;
        private event EventHandler<ErrorOccurredEventArgs> _errorOccurred;
        private event EventHandler<DefaultLanguageChangedEventArgs> _defaultLanguageChanged;
        private event EventHandler<EngineChangedEventArgs> _engineChanged;
        private bool disposedValue = false;
        private readonly Object _recognitionResultLock = new Object();
        private readonly Object _stateChangedLock = new Object();
        private readonly Object _errorOccurredLock = new Object();
        private readonly Object _defaultLanguageChangedLock = new Object();
        private readonly Object _engineChangedLock = new Object();
        private Interop.Stt.RecognitionResultCallback _resultDelegate;
        private Interop.Stt.StateChangedCallback _stateDelegate;
        private Interop.Stt.ErrorCallback _errorDelegate;
        private Interop.Stt.DefaultLanguageChangedCallback _languageDelegate;
        private Interop.Stt.EngineChangedCallback _engineDelegate;
        private ResultTime _result;
        private ResultTimeCallback _resultTimeDelegate;

        /// <summary>
        /// Constructor to create a STT instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="OutOfMemoryException">This exception can be due to out of memory.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        public SttClient()
        {
            IntPtr handle;
            SttError error = SttCreate(out handle);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "Create Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            _handle = handle;
        }

        /// <summary>
        /// Destructor to destroy a STT instance.
        /// </summary>
        ~SttClient()
        {
            Dispose(false);
        }

        /// <summary>
        /// Event to be invoked when the recognition is done.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<RecognitionResultEventArgs> RecognitionResult
        {
            add
            {
                lock (_recognitionResultLock)
                {
                    if (_recognitionResult == null)
                    {
                        _resultDelegate = (IntPtr handle, ResultEvent e, IntPtr data, int dataCount, IntPtr msg, IntPtr userData) =>
                        {
                            Log.Info(LogTag, "Recognition Result Event Triggered");
                            if (data != null && msg != null)
                            {
                                RecognitionResultEventArgs args = new RecognitionResultEventArgs(e, data, dataCount, Marshal.PtrToStringAnsi(msg));
                                _recognitionResult?.Invoke(this, args);
                            }
                            else
                            {
                                Log.Info(LogTag, "Recognition Result Event null received");
                            }
                        };

                        SttError error = SttSetRecognitionResultCB(_handle, _resultDelegate, IntPtr.Zero);
                        if (error != SttError.None)
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
                        SttError error = SttUnsetRecognitionResultCB(_handle);
                        if (error != SttError.None)
                        {
                            Log.Error(LogTag, "Remove RecognitionResult Failed with error " + error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event to be invoked when the STT state changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<StateChangedEventArgs> StateChanged
        {
            add
            {
                lock (_stateChangedLock)
                {
                    if (_stateChanged == null)
                    {
                        SttClient obj = this;
                        _stateDelegate = (IntPtr handle, State previous, State current, IntPtr userData) =>
                        {
                            StateChangedEventArgs args = new StateChangedEventArgs(previous, current);
                            _stateChanged?.Invoke(obj, args);
                        };

                        SttError error = SttSetStateChangedCB(_handle, _stateDelegate, IntPtr.Zero);
                        if (error != SttError.None)
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
                        SttError error = SttUnsetStateChangedCB(_handle);
                        if (error != SttError.None)
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
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<ErrorOccurredEventArgs> ErrorOccurred
        {
            add
            {
                lock (_errorOccurredLock)
                {
                    if (_errorOccurred == null)
                    {
                        _errorDelegate = (IntPtr handle, SttError reason, IntPtr userData) =>
                        {
                            ErrorOccurredEventArgs args = new ErrorOccurredEventArgs(handle, reason);
                            _errorOccurred?.Invoke(this, args);
                        };

                        SttError error = SttSetErrorCB(_handle, _errorDelegate, IntPtr.Zero);
                        if (error != SttError.None)
                        {
                            Log.Error(LogTag, "Add ErrorOccurred Failed with error " + error);
                        }
                    }
                    _errorOccurred += value;
                }
            }

            remove
            {
                lock (_errorOccurredLock)
                {
                    _errorOccurred -= value;
                    if (_errorOccurred == null)
                    {
                        SttError error = SttUnsetErrorCB(_handle);
                        if (error != SttError.None)
                        {
                            Log.Error(LogTag, "Remove ErrorOccurred Failed with error " + error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event to be invoked when the default language changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<DefaultLanguageChangedEventArgs> DefaultLanguageChanged
        {
            add
            {
                lock (_defaultLanguageChangedLock)
                {
                    if (_defaultLanguageChanged == null)
                    {
                        _languageDelegate = (IntPtr handle, IntPtr previousLanguage, IntPtr currentLanguage, IntPtr userData) =>
                        {
                            string previousLanguageString = Marshal.PtrToStringAnsi(previousLanguage);
                            string currentLanguageString = Marshal.PtrToStringAnsi(currentLanguage);
                            DefaultLanguageChangedEventArgs args = new DefaultLanguageChangedEventArgs(previousLanguageString, currentLanguageString);
                            _defaultLanguageChanged?.Invoke(this, args);
                        };

                        SttError error = SttSetDefaultLanguageChangedCB(_handle, _languageDelegate, IntPtr.Zero);
                        if (error != SttError.None)
                        {
                            Log.Error(LogTag, "Add DefaultLanguageChanged Failed with error " + error);
                        }
                    }
                    _defaultLanguageChanged += value;
                }
            }

            remove
            {
                lock (_defaultLanguageChangedLock)
                {
                    _defaultLanguageChanged -= value;
                    if (_defaultLanguageChanged == null)
                    {
                        SttError error = SttUnsetDefaultLanguageChangedCB(_handle);
                        if (error != SttError.None)
                        {
                            Log.Error(LogTag, "Remove DefaultLanguageChanged Failed with error " + error);
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Event to be invoked to detect the engine change.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<EngineChangedEventArgs> EngineChanged
        {
            add
            {
                lock (_engineChangedLock)
                {
                    if (_engineChanged == null)
                    {
                        _engineDelegate = (IntPtr handle, IntPtr engineId, IntPtr language, bool supportSilence, bool needCredential, IntPtr userData) =>
                        {
                            string engineIdString = Marshal.PtrToStringAnsi(engineId);
                            string languageString = Marshal.PtrToStringAnsi(language);
                            EngineChangedEventArgs args = new EngineChangedEventArgs(engineIdString, languageString, supportSilence, needCredential);
                            _engineChanged?.Invoke(this, args);
                        };

                        SttError error = SttSetEngineChangedCB(_handle, _engineDelegate, IntPtr.Zero);
                        if (error != SttError.None)
                        {
                            Log.Error(LogTag, "Add EngineChanged Failed with error " + error);
                        }
                    }
                    _engineChanged += value;
                }
            }

            remove
            {
                lock (_engineChangedLock)
                {
                    _engineChanged -= value;
                    if (_engineChanged == null)
                    {
                        SttError error = SttUnsetEngineChangedCB(_handle);
                        if (error != SttError.None)
                        {
                            Log.Error(LogTag, "Remove EngineChanged Failed with error " + error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the default language set by the user.
        /// The language is specified as an ISO 3166 alpha-2 two letter country-code followed by ISO 639-1 for the two-letter language code.
        /// For example, "ko_KR" for Korean, "en_US" for American English.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// Default language in STT.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <returns>
        /// Default Language string value.
        /// </returns>
        public string DefaultLanguage
        {
            get
            {
                string language;
                SttError error = SttGetDefaultLanguage(_handle, out language);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "DefaultLanguage Failed with error " + error);
                    return "";
                }

                return language;
            }
        }

        /// <summary>
        /// Gets the microphone volume during recording.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// Recording volume in STT.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <pre>
        /// The state must be recording.
        /// </pre>
        public float RecordingVolume
        {
            get
            {
                float volume;
                SttError error = SttGetRecordingVolume(_handle, out volume);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "GetRecordingVolume Failed with error " + error);
                    return 0.0f;
                }

                return volume;
            }

        }

        /// <summary>
        /// Gets the current STT state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// Current state of STT.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <returns>
        /// Current STT state value.
        /// </returns>
        public State CurrentState
        {
            get
            {
                State state;
                SttError error = SttGetState(_handle, out state);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "GetState Failed with error " + error);
                    return State.Unavailable;
                }

                return state;
            }

        }

        /// <summary>
        /// This property can be used to get and set the current engine id.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// Current STT engine id.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <exception cref="InvalidOperationException">
        /// This exceptioncan occur while setting due to the following reasons:
        /// 1. Operation Failed
        /// 2. Invalid State
        /// </exception>
        /// <exception cref="OutOfMemoryException">This exception can be due to out of memory.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="ArgumentException">This can happen if improper EngineId is provided while setting the value.</exception>
        /// <pre>
        /// The state must be created.
        /// </pre>
        public string Engine
        {
            get
            {
                string engineId;
                SttError error = SttGetEngine(_handle, out engineId);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "Get EngineId Failed with error " + error);
                    return "";
                }

                return engineId;
            }
            set
            {
                SttError error = SttSetEngine(_handle, value);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "Set EngineId Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Retrieves the time stamp of the current recognition result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// List of ResultTime.
        /// </returns>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <remarks>
        /// This function should only be called in the RecognitionResult event.
        /// </remarks>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        public IEnumerable<ResultTime> GetDetailedResult()
        {
            List<ResultTime> list = new List<ResultTime>();
            _resultTimeDelegate = (IntPtr handle, int index, TimeEvent e, IntPtr text, IntPtr startTime, IntPtr endTime, IntPtr userData) =>
            {
                _result = new ResultTime(index, e, Marshal.PtrToStringAnsi(text), (long)startTime, (long)endTime);
                list.Add(_result);
                return true;
            };

            SttError error = SttForeachDetailedResult(_handle, _resultTimeDelegate, IntPtr.Zero);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "GetDetailedResult Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
            return list;
        }


        /// <summary>
        /// Gets the private data from the STT engine.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="key">
        /// The key string.
        /// </param>
        /// <returns>
        /// The data corresponding to the key is provided.
        /// </returns>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to invalid state.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <exception cref="TimeoutException">This exception can be due to No Answer from STT Service.</exception>
        /// <pre>
        /// The state must be ready.
        /// </pre>
        public string GetPrivateData(string key)
        {
            string data;
            SttError error = SttGetPrivateData(_handle, key, out data);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "GetPrivateData Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return data;
        }

        /// <summary>
        /// Sets the private data to the STT engine.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="key">
        /// The key string.
        /// </param>
        /// <param name="data">
        /// The data string.
        /// </param>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to invalid state.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <exception cref="TimeoutException">This exception can be due to No Answer from STT Service.</exception>
        /// <exception cref="ArgumentException"> This can happen if Improper value is provided while setting the value. </exception>
        /// <pre>
        /// The state must be ready.
        /// </pre>
        public void SetPrivateData(string key, string data)
        {
            SttError error = SttSetPrivateData(_handle, key, data);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "SetPrivateData Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Gets the list of supported engines.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// IEnumerable&lt;SupportedEngine&gt; list of supported engines.
        /// </returns>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <exception cref="OutOfMemoryException">This exception can be due to out of memory.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        public IEnumerable<SupportedEngine> GetSupportedEngines()
        {
            List<SupportedEngine> engineList = new List<SupportedEngine>();
            SupportedEngineCallback supportedEngineDelegate = (IntPtr handle, IntPtr engineId, IntPtr engineName, IntPtr userData) =>
            {
                string id = Marshal.PtrToStringAnsi(engineId);
                string name = Marshal.PtrToStringAnsi(engineName);
                SupportedEngine engine = new SupportedEngine(id, name);
                engineList.Add(engine);
                return true;
            };

            SttError error = SttForeEachSupportedEngines(_handle, supportedEngineDelegate, IntPtr.Zero);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "Create Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return engineList;
        }

        /// <summary>
        /// Sets the application credential.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="credential">
        /// The credential string.
        /// </param>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exceptioncan be due to the following reasons:
        /// 1. Operation Failed
        /// 2. Invalid State
        /// </exception>
        /// <exception cref="OutOfMemoryException">This exception can be due to out of memory.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="ArgumentException"> This can happen if Improper value is provided while setting the value. </exception>
        /// <pre>
        /// The state must be created.
        /// </pre>
        public void SetCredential(string credential)
        {
            SttError error = SttSetcredential(_handle, credential);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "SetCredential Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Connects to the STT service asynchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to invalid state.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <pre>
        /// The state must be created.
        /// </pre>
        /// <post>
        /// If this function is successful, the STT state will be ready.
        /// If this function is unsuccessful, ErrorOccurred event will be invoked.
        /// </post>
        public void Prepare()
        {
            SttError error = SttPrepare(_handle);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "SetEngine Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Disconnects from the STT service.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to invalid state.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <pre>
        /// The state must be ready.
        /// </pre>
        /// <post>
        /// If this function is successful, the STT state will be Created.
        /// </post>
        public void Unprepare()
        {
            SttError error = SttUnprepare(_handle);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "Unprepare Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Retrieves all the supported languages of the current engine.
        /// The language is specified as an ISO 3166 alpha-2 two letter country-code followed by ISO 639-1 for the two-letter language code.
        /// For example, "ko_KR" for Korean, "en_US" for American English.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <returns>
        /// List of strings for supported languages.
        /// </returns>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Engine Not Found.
        /// 2. Operation Failed.
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        public IEnumerable<string> GetSupportedLanguages()
        {
            List<string> languageList = new List<string>();
            SupportedLanguageCallback supportedLanguageDelegate = (IntPtr handle, IntPtr language, IntPtr userData) =>
            {
                string lang = Marshal.PtrToStringAnsi(language);
                languageList.Add(lang);
                return true;
            };

            SttError error = SttForeachSupportedLanguages(_handle, supportedLanguageDelegate, IntPtr.Zero);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "GetSupportedLanguages Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return languageList;
        }

        /// <summary>
        /// Checks whether the recognition type is supported.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <param name="type">
        /// RecognitionType value.
        /// </param>
        /// <returns>
        /// Bool value indicating whether the recognition type is supported.
        /// </returns>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Invalid State
        /// 2. Engine Not Found
        /// 3. Operation Failed
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <pre>
        /// The state should be ready.
        /// </pre>
        public bool IsRecognitionTypeSupported(RecognitionType type)
        {
            bool supported;
            string recType = "stt.recognition.type.FREE";
            switch (type)
            {
                case RecognitionType.Free:
                    {
                        recType = "stt.recognition.type.FREE";
                        break;
                    }

                case RecognitionType.Partial:
                    {
                        recType = "stt.recognition.type.FREE.PARTIAL";
                        break;
                    }

                case RecognitionType.Search:
                    {
                        recType = "stt.recognition.type.SEARCH";
                        break;
                    }

                case RecognitionType.WebSearch:
                    {
                        recType = "stt.recognition.type.WEB_SEARCH";
                        break;
                    }

                case RecognitionType.Map:
                    {
                        recType = "stt.recognition.type.MAP";
                        break;
                    }
            }

            SttError error = SttIsRecognitionTypeSupported(_handle, recType, out supported);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "IsRecognitionTypeSupported Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return supported;
        }

        /// <summary>
        /// Sets the silence detection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <param name="type">
        /// SilenceDetection value.
        /// </param>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Invalid State
        /// 2. Not supported feature of current engine
        /// 3. Operation Failed
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <pre>
        /// The state should be ready.
        /// </pre>
        public void SetSilenceDetection(SilenceDetection type)
        {
            SttError error = SttSetSilenceDetection(_handle, type);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "SetSilenceDetection Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Sets the sound to start recording.
        /// Sound file type should be .wav type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <param name="filePath">
        /// File path for the sound.
        /// </param>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Invalid State
        /// 2. Operation Failed
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="ArgumentException"> If an Invalid Parameter is provided. </exception>
        /// <pre>
        /// The state should be ready.
        /// </pre>
        public void SetStartSound(string filePath)
        {
            SttError error = SttSetStartSound(_handle, filePath);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "SetStartSound Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Unsets the sound to start recording.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Invalid State
        /// 2. Operation Failed
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <pre>
        /// The state should be ready.
        /// </pre>
        public void UnsetStartSound()
        {
            SttError error = SttUnsetStartSound(_handle);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "UnsetStartSound Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Sets the sound to stop recording.
        /// Sound file type should be .wav type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <param name="filePath">
        /// File Path for the sound.
        /// </param>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Invalid State
        /// 2. Operation Failed
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="ArgumentException">This exception can be due to Invalid Parameter.</exception>
        /// <pre>
        /// The state should be ready.
        /// </pre>
        public void SetStopSound(string filePath)
        {
            SttError error = SttSetStopSound(_handle, filePath);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "SetStopSound Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Unsets the sound to stop recording.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Invalid State
        /// 2. Operation Failed
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <exception cref="UnauthorizedAccessException"> his exception can be due to permission denied.</exception>
        /// <pre>
        /// The state should be ready.
        /// </pre>
        public void UnsetStopSound()
        {
            SttError error = SttUnsetStopSound(_handle);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "UnsetStopSound Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Starts the recording and recognition asynchronously.
        /// This function starts recording in the STT service and sends the recording data to the engine.
        /// This work continues until stop, cancel, or silence is detected by engine.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <param name="language">
        /// The language selected.
        /// </param>
        /// <param name="type">
        /// The type for recognition.
        /// </param>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Invalid State
        /// 2. Operation Failed
        /// 3. Recorder Busy
        /// 4. Progress to recording is not finished
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid language.</exception>
        /// <pre>
        /// The state should be ready.
        /// </pre>
        /// <post>
        /// It will invoke the StateChanged event, if registered.
        /// If this function succeeds, the STT state will be recording.
        /// If you call this function again before the state changes, you will receive ErrorINProgressToRecording.
        /// </post>
        public void Start(string language, RecognitionType type)
        {
            string recType = "stt.recognition.type.FREE";
            switch (type)
            {
                case RecognitionType.Free:
                    {
                        recType = "stt.recognition.type.FREE";
                        break;
                    }

                case RecognitionType.Partial:
                    {
                        recType = "stt.recognition.type.FREE.PARTIAL";
                        break;
                    }

                case RecognitionType.Search:
                    {
                        recType = "stt.recognition.type.SEARCH";
                        break;
                    }

                case RecognitionType.WebSearch:
                    {
                        recType = "stt.recognition.type.WEB_SEARCH";
                        break;
                    }

                case RecognitionType.Map:
                    {
                        recType = "stt.recognition.type.MAP";
                        break;
                    }
            }

            SttError error = SttStart(_handle, language, recType);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "Start Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Finishes the recording and starts recognition processing in the engine asynchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Invalid State
        /// 2. Operation Failed
        /// 3. Progress to ready is not finished
        /// 4. Progress to recording is not finished
        /// 5. Progress to processing is not finished
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <pre>
        /// The state should be Recording.
        /// </pre>
        /// <post>
        /// It will invoke the StateChanged Event, if registered.
        /// If this function succeeds, the STT state will be processing.
        /// If you call this function again before the state changes, you will receive ErrorINProgressToProcessing.
        /// After processing of engine, the RecognitionResult event is invoked.
        /// </post>
        public void Stop()
        {
            SttError error = SttStop(_handle);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "Stop Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Cancels processing the recognition and recording asynchronously.
        /// This function cancels recording and the engine cancels recognition processing.
        /// After successful cancellation, the StateChanged event is invoked, otherwise if an error is occurs, the ErrorOccurred event is invoked.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/speech.recognition
        /// http://tizen.org/feature/microphone
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Invalid State
        /// 2. Operation Failed
        /// 3. Progress to ready is not finished
        /// 4. Progress to recording is not finished
        /// 5. Progress to processing is not finished
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to STT not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <pre>
        /// The state should be Recording or Processing.
        /// </pre>
        /// <post>
        /// It will invoke the StateChanged event, if registered.
        /// If this function succeeds, the STT state will be ready.
        /// If you call this function again before the state changes, you will receive ErrorINProgressToReady.
        /// </post>
        public void Cancel()
        {
            SttError error = SttCancel(_handle);
            if (error != SttError.None)
            {
                Log.Error(LogTag, "Cancel Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Method to release resources.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Method to release resources.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="disposing">
        /// The boolean value for destoying stt handle.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (_handle != IntPtr.Zero)
                {
                    SttError error = SttDestroy(_handle);
                    if (error != SttError.None)
                    {
                        Log.Error(LogTag, "Destroy Failed with error " + error);
                    }
                    _handle = IntPtr.Zero;
                }

                disposedValue = true;
            }
        }
    }
}

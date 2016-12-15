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
    /// The token event
    /// </summary>
    public enum ResultEvent
    {
        /// <summary>
        /// Event when the recognition full or last result is ready
        /// </summary>
        FinalResult = 0,
        /// <summary>
        /// Event when the recognition partial result is ready
        /// </summary>
        PartialResult,
        /// <summary>
        /// Event when the recognition has failed
        /// </summary>
        Error
    };

    /// <summary>
    /// Enumeration representing the result message
    /// </summary>
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
    /// Enumeration for the Token type
    /// </summary>
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
        /// Network is down
        /// </summary>
        OutOfNetwork,
        /// <summary>
        /// Permission denied
        /// </summary>
        PermissionDenied,
        /// <summary>
        /// STT NOT supported
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
        /// Not supported feature of current engine
        /// </summary>
        NotSupportedFeature,
        /// <summary>
        /// Recording timed out
        /// </summary>
        RecordingTimedOut,
        /// <summary>
        /// No speech while recording
        /// </summary>
        NoSpeech,
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
        InProgressToProcessing,
        /// <summary>
        /// Service reset
        /// </summary>
        ServiceReset
    };

    /// <summary>
    /// Enumeration for Recognition Types
    /// </summary>
    public enum RecognitionType
    {
        /// <summary>
        /// Free form dictation
        /// </summary>
        Free,
        /// <summary>
        /// Continuous free dictation.
        /// </summary>
        Partial,
        /// <summary>
        /// Search
        /// </summary>
        Search,
        /// <summary>
        /// Web Search
        /// </summary>
        WebSearch,
        /// <summary>
        /// Map
        /// </summary>
        Map
    };

    /// <summary>
    /// Enumeration for the State types
    /// </summary>
    public enum State
    {
        /// <summary>
        /// Created state
        /// </summary>
        Created = 0,
        /// <summary>
        /// Ready state
        /// </summary>
        Ready = 1,
        /// <summary>
        /// Recording state
        /// </summary>
        Recording = 2,
        /// <summary>
        /// Processing state
        /// </summary>
        Processing = 3,
        /// <summary>
        /// Unavailable
        /// </summary>
        Unavailable
    };

    /// <summary>
    /// Enumeration for the Silence Detection types
    /// </summary>
    public enum SilenceDetection
    {
        /// <summary>
        /// Silence detection type - False
        /// </summary>
        False = 0,
        /// <summary>
        /// Silence detection type - True
        /// </summary>
        True = 1,
        /// <summary>
        /// Silence detection type - Auto
        /// </summary>
        Auto = 2
    };

    /// <summary>
    /// A main function of Speech-To-Text (below STT) API recognizes sound data recorded by users.
    /// After choosing a language, applications will start recording and recognizing.
    /// After recording, the applications will receive the recognized result.
    /// The STT has a client-server for the service of multi-applications.
    /// The STT service always works in the background as a server. If the service is not working, client library will invoke it and client will communicate with it.
    /// The service has engines and the recorder so client does not have the recorder itself. Only the client request commands to the STT service for using STT.
    /// </summary>
    public class Stt : IDisposable
    {
        private IntPtr _handle;
        private Object thisLock = new Object();
        private event EventHandler<RecognitionResultEventArgs> _recognitionResult;
        private event EventHandler<StateChangedEventArgs> _stateChanged;
        private event EventHandler<ErrorOccuredEventArgs> _errorOccured;
        private event EventHandler<DefaultLanguageChangedEventArgs> _defaultLanguageChanged;
        private event EventHandler<EngineChangedEventArgs> _engineChanged;
        private bool disposedValue = false;
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
        /// <priviledge>
        /// http://tizen.org/privilege/recorder
        /// </priviledge>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. Out Of Memory
        /// 2. Operation Failed
        /// 3. STT Not Supported
        /// 4. Permission Denied
        /// </exception>
        public Stt()
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
        /// Event to be invoked when the recognition is done.
        /// </summary>
        public event EventHandler<RecognitionResultEventArgs> RecognitionResult
        {
            add
            {
                lock (thisLock)
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
                    else
                    {
                        _recognitionResult += value;
                    }
                }
            }

            remove
            {
                lock (thisLock)
                {
                    SttError error = SttUnsetRecognitionResultCB(_handle);
                    if (error != SttError.None)
                    {
                        Log.Error(LogTag, "Remove RecognitionResult Failed with error " + error);
                    }

                    _recognitionResult -= value;
                }
            }
        }

        /// <summary>
        /// Event to be invoked when STT state changes.
        /// </summary>
        public event EventHandler<StateChangedEventArgs> StateChanged
        {
            add
            {
                lock (thisLock)
                {
                    Stt obj = this;
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
                    else
                    {
                        _stateChanged += value;
                    }

                }
            }

            remove
            {
                lock (thisLock)
                {
                    SttError error = SttUnsetStateChangedCB(_handle);
                    if (error != SttError.None)
                    {
                        Log.Error(LogTag, "Remove StateChanged Failed with error " + error);
                    }

                    _stateChanged -= value;
                }
            }

        }

        /// <summary>
        /// Event to be invoked when an error occurs.
        /// </summary>
        public event EventHandler<ErrorOccuredEventArgs> ErrorOccured
        {
            add
            {
                lock (thisLock)
                {
                    _errorDelegate = (IntPtr handle, SttError reason, IntPtr userData) =>
                {
                    ErrorOccuredEventArgs args = new ErrorOccuredEventArgs(handle, reason);
                    _errorOccured?.Invoke(this, args);
                };
                    SttError error = SttSetErrorCB(_handle, _errorDelegate, IntPtr.Zero);
                    if (error != SttError.None)
                    {
                        Log.Error(LogTag, "Add ErrorOccured Failed with error " + error);
                    }

                    else
                    {
                        _errorOccured += value;
                    }
                }

            }

            remove
            {
                lock (thisLock)
                {
                    SttError error = SttUnsetErrorCB(_handle);
                    if (error != SttError.None)
                    {
                        Log.Error(LogTag, "Remove ErrorOccured Failed with error " + error);
                    }

                    _errorOccured -= value;
                }
            }
        }

        /// <summary>
        /// Event to be invoked when default laungage change.
        /// </summary>
        public event EventHandler<DefaultLanguageChangedEventArgs> DefaultLanguageChanged
        {
            add
            {
                lock (thisLock)
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

                    else
                    {
                        _defaultLanguageChanged += value;
                    }
                }

            }

            remove
            {
                lock (thisLock)
                {
                    SttError error = SttUnsetDefaultLanguageChangedCB(_handle);
                    if (error != SttError.None)
                    {
                        Log.Error(LogTag, "Remove DefaultLanguageChanged Failed with error " + error);
                    }

                    _defaultLanguageChanged -= value;
                }
            }

        }

        /// <summary>
        /// Event to be invoked to detect engine change.
        /// </summary>
        public event EventHandler<EngineChangedEventArgs> EngineChanged
        {
            add
            {
                lock (thisLock)
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
                    else
                    {
                        _engineChanged += value;
                    }
                }
            }

            remove
            {
                lock (thisLock)
                {
                    SttError error = SttUnsetEngineChangedCB(_handle);
                    if (error != SttError.None)
                    {
                        Log.Error(LogTag, "Remove EngineChanged Failed with error " + error);
                    }

                    _engineChanged -= value;
                }
            }
        }

        /// <summary>
        /// Gets the default language set by the user.
        /// The language is specified as an ISO 3166 alpha-2 two letter country-code followed by ISO 639-1 for the two-letter language code.
        /// For example, "ko_KR" for Korean, "en_US" for American English.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/recorder
        /// </priviledge>
        /// <returns>
        /// Default Lanaguage string value.
        /// </returns>
        public string GetDefaultLanguage
        {
            get
            {
                string language;
                lock (thisLock)
                {
                    SttError error = SttGetDefaultLanguage(_handle, out language);
                    if (error != SttError.None)
                    {
                        Log.Error(LogTag, "DefaultLanaguage Failed with error " + error);
                        return "";
                    }
                }

                return language;
            }
        }

        /// <summary>
        /// Gets the microphone volume during recording.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/recorder
        /// </priviledge>
        /// <precondition>
        /// The State must be Recording.
        /// </precondition>
        public float GetRecordingVolume
        {
            get
            {
                float volume;
                lock (thisLock)
                {
                    SttError error = SttGetRecordingVolume(_handle, out volume);
                    if (error != SttError.None)
                    {
                        Log.Error(LogTag, "GetRecordingVolume Failed with error " + error);
                        return 0.0f;
                    }

                }

                return volume;
            }

        }

        /// <summary>
        /// Gets the current STT state.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/recorder
        /// </priviledge>
        /// <returns>
        /// Current STT State value.
        /// </returns>
        public State GetState
        {
            get
            {
                State state;
                lock (thisLock)
                {
                    SttError error = SttGetState(_handle, out state);
                    if (error != SttError.None)
                    {
                        Log.Error(LogTag, "GetState Failed with error " + error);
                        return State.Unavailable;
                    }
                }

                return state;
            }

        }

        /// <summary>
        /// This property can be used to get and set the current engine id.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// This Exception can occur while setting due to the following reaons
        /// 1. Out Of Memory
        /// 2. Operation Failed
        /// 3. STT Not Supported
        /// 4. Permission Denied
        /// 5. Invalid State
        /// </exception>
        /// <exception cref="ArgumentException">
        /// This can happen if Improper EngineId is provided while setting the value.
        /// </exception>
        /// <precondition>
        /// The State must be Created.
        /// </precondition>
        public string Engine
        {
            get
            {
                string engineId;
                lock (thisLock)
                {
                    SttError error = SttGetEngine(_handle, out engineId);
                    if (error != SttError.None)
                    {
                        Log.Error(LogTag, "Get EngineId Failed with error " + error);
                        return "";
                    }
                }

                return engineId;
            }
            set
            {
                lock (thisLock)
                {
                    SttError error = SttSetEngine(_handle, value);
                    if (error != SttError.None)
                    {
                        Log.Error(LogTag, "Set EngineId Failed with error " + error);
                        throw ExceptionFactory.CreateException(error);
                    }
                }

            }
        }

        /// <summary>
        /// Retrieves the time stamp of the current recognition result
        /// </summary>
        /// <returns>
        /// list of ResultTime
        /// </returns>
        /// <remarks>
        /// This function should only be called in RecognitionResult Event
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. Opearation Failed.
        /// 2. STT Not Supported
        /// 3. Permission Denied.
        /// </exception>
        public IEnumerable<ResultTime> GetDetailedResult()
        {
            List<ResultTime> list = new List<ResultTime>();
            _resultTimeDelegate = (IntPtr handle, int index, TimeEvent e, IntPtr text, long startTime, long endTime, IntPtr userData) =>
            {
                _result = new ResultTime(index, e, Marshal.PtrToStringAnsi(text), startTime, endTime);
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
        /// Gets the private data from stt engine.
        /// </summary>
        /// <param name="key">
        /// The key string
        /// </param>
        /// <returns>
        /// The Data Corresponding to the Key provided
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. No Answer from STT Service
        /// 2. STT Not Supported
        /// 3. Invalid State
        /// </exception>
        /// <precondition>
        /// The State must be Ready.
        /// </precondition>
        public string GetPrivateData(string key)
        {
            string data;
            lock (thisLock)
            {
                SttError error = SttGetPrivateData(_handle, key, out data);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "GetPrivateData Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }

            return data;
        }

        /// <summary>
        /// Sets the private data to stt engine.
        /// </summary>
        /// <param name="key">
        /// The key string
        /// </param>
        /// <param name="data">
        /// The data string
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. No Answer from STT Service
        /// 2. STT Not Supported
        /// 3. Invalid State
        /// </exception>
        /// <exception cref="ArgumentException">
        /// This can happen if Improper value is provided while setting the value.
        /// </exception>
        /// <precondition>
        /// The State must be Ready.
        /// </precondition>
        public void SetPrivateData(string key, string data)
        {
            lock (thisLock)
            {
                SttError error = SttSetPrivateData(_handle, key, data);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "SetPrivateData Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Gets the list of Supported Engine
        /// </summary>
        /// <returns>
        /// IEnumerable<SupportedEngine> list of supported engines
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. Out Of Memory
        /// 2. Operation Failed
        /// 3. STT Not Supported
        /// 4. Permission Denied
        /// </exception>
        public IEnumerable<SupportedEngine> GetSupportedEngines()
        {
            List<SupportedEngine> engineList = new List<SupportedEngine>();
            lock (thisLock)
            {
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
            }

            return engineList;
        }

        /// <summary>
        /// Sets the app credential
        /// </summary>
        /// <param name="credential">
        /// The credential string
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. Out Of Memory
        /// 2. Operation Failed
        /// 3. STT Not Supported
        /// 4. Permission Denied
        /// 5. Invalid State
        /// </exception>
        /// <exception cref="ArgumentException">
        /// This can happen if Improper value is provided while setting the value.
        /// </exception>
        /// <precondition>
        /// The State must be Created.
        /// </precondition>
        public void SetCredential(string credential)
        {
            lock (thisLock)
            {
                SttError error = SttSetcredential(_handle, credential);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "SetCredential Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Connects to the STT service asynchronously.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/recorder
        /// </priviledge>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reasons
        /// 1. STT Not Supported
        /// 2. Permission Denied
        /// 3. Invalid State
        /// </exception>
        /// <precondition>
        /// The State must be Created.
        /// </precondition>
        /// <postcondition>
        /// If this function is successful, the STT state will be Ready
        /// If this function is unsuccessful, ErrorOccured event will be invoked
        /// </postcondition>
        public void Prepare()
        {
            lock (thisLock)
            {
                SttError error = SttPrepare(_handle);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "SetEngine Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Disconnects from the STT service.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/recorder
        /// </priviledge>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reasons
        /// 1. STT Not Supported
        /// 2. Permission Denied
        /// 3. Invalid State
        /// </exception>
        /// <precondition>
        /// The State must be Ready.
        /// </precondition>
        /// <postcondition>
        /// If this function is successful, the STT state will be Created
        /// </postcondition>
        public void Unprepare()
        {
            lock (thisLock)
            {
                SttError error = SttUnprepare(_handle);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "Unprepare Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Retrieves all supported languages of current engine.
        /// The language is specified as an ISO 3166 alpha-2 two letter country-code followed by ISO 639-1 for the two-letter language code.
        /// For example, "ko_KR" for Korean, "en_US" for American English.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/recorder
        /// </priviledge>
        /// <returns>
        /// list of strings of supported languages.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reasons
        /// 1. STT Not Supported
        /// 2. Permission Denied
        /// 3. Engine Not Found.
        /// 4. Operation Failed.
        /// </exception>
        public IEnumerable<string> GetSupportedLangauages()
        {
            List<string> languageList = new List<string>();
            lock (thisLock)
            {
                SupportedLanguageCallback supportedLanguageDelegate = (IntPtr handle, IntPtr language, IntPtr userData) =>
            {
                string lang = Marshal.PtrToStringAnsi(language);
                languageList.Add(lang);
                return true;
            };

                SttError error = SttForeachSupportedLanguages(_handle, supportedLanguageDelegate, IntPtr.Zero);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "GetSupportedLangauages Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }

            return languageList;
        }

        /// <summary>
        /// Checks whether the recognition type is supported.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/recorder
        /// </priviledge>
        /// <param name="type">
        /// RecognitionType value.
        /// </param>
        /// <returns>
        /// bool value indicating whether the recognition type is supported.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reasons
        /// 1. STT Not Supported
        /// 2. Invalid State
        /// 3. Engine Not Found.
        /// 4. Operation Failed.
        /// </exception>
        /// <precondition>
        /// The state should be Ready.
        /// </precondition>
        public bool IsRecognitionTypeSupported(RecognitionType type)
        {
            bool supported;
            lock (thisLock)
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

                SttError error = SttIsRecognitionTypeSupported(_handle, recType, out supported);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "IsRecognitionTypeSupported Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }

            }

            return supported;
        }

        /// <summary>
        /// Sets the silence detection.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/recorder
        /// </priviledge>
        /// <param name="type">
        /// SilenceDetection value.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reasons
        /// 1. STT Not Supported
        /// 2. Invalid State
        /// 3. Not supported feature of current engine.
        /// 4. Operation Failed.
        /// </exception>
        /// <precondition>
        /// The state should be Ready.
        /// </precondition>
        public void SetSilenceDetection(SilenceDetection type)
        {
            lock (thisLock)
            {
                SttError error = SttSetSilenceDetection(_handle, type);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "SetSilenceDetection Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Sets the sound to start recording.
        /// Sound file type should be wav type.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/recorder
        /// </priviledge>
        /// <param name="filePath">
        /// File Path for the sound.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reasons
        /// 1. STT Not Supported.
        /// 2. Permission Denied.
        /// 3. Invalid State.
        /// 4. Operation Failed.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If an Invalid Parameter is provided.
        /// </exception>
        /// <precondition>
        /// The state should be Ready.
        /// </precondition>
        public void SetStartSound(string filePath)
        {
            lock (thisLock)
            {
                SttError error = SttSetStartSound(_handle, filePath);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "SetStartSound Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Unsets the sound to start recording.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/recorder
        /// </priviledge>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reasons
        /// 1. STT Not Supported.
        /// 2. Permission Denied.
        /// 3. Invalid State.
        /// 4. Operation Failed.
        /// </exception>
        /// <precondition>
        /// The state should be Ready.
        /// </precondition>
        public void UnsetStartSound()
        {
            lock (thisLock)
            {
                SttError error = SttUnsetStartSound(_handle);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "UnsetStartSound Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Sets the sound to stop recording.
        /// Sound file type should be wav type.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/recorder
        /// </priviledge>
        /// <param name="filePath">
        /// File Path for the sound.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reasons
        /// 1. STT Not Supported.
        /// 2. Permission Denied.
        /// 3. Invalid State.
        /// 4. Operation Failed.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If an Invalid Parameter is provided.
        /// </exception>
        /// <precondition>
        /// The state should be Ready.
        /// </precondition>
        public void SetStopSound(string filePath)
        {
            lock (thisLock)
            {
                SttError error = SttSetStopSound(_handle, filePath);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "SetStopSound Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Unsets the sound to stop recording.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/recorder
        /// </priviledge>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reasons
        /// 1. STT Not Supported.
        /// 2. Permission Denied.
        /// 3. Invalid State.
        /// 4. Operation Failed.
        /// </exception>
        /// <precondition>
        /// The state should be Ready.
        /// </precondition>
        public void UnsetStopSound()
        {
            lock (thisLock)
            {
                SttError error = SttUnsetStopSound(_handle);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "UnsetStopSound Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Starts recording and recognition asynchronously.
        /// This function starts recording in the STT service and sending recording data to engine.
        /// This work continues until Stop, Cancel or silence detected by engine
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/recorder
        /// </priviledge>
        /// <param name="language">
        /// The language selected
        /// </param>
        /// <param name="type">
        /// The type for recognition
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reasons
        /// 1. STT Not Supported.
        /// 2. Permission Denied.
        /// 3. Invalid State.
        /// 4. Operation Failed.
        /// 5. Recorder Busy.
        /// 6. Progress to recording is not finished
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If an Invalid Language is provided
        /// </exception>
        /// <precondition>
        /// The state should be Ready.
        /// </precondition>
        /// <postcondition>
        /// It will invoke StateChanged Event if registerd.
        /// If this function succeeds, the STT state will be Recording.
        /// If you call this function again before state changes, you will receive ErrorINProgressToRecording.
        /// </postcondition>
        public void Start(string language, RecognitionType type)
        {
            lock (thisLock)
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
        }

        /// <summary>
        /// Finishes the recording and starts recognition processing in engine asynchronously.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/recorder
        /// </priviledge>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reasons
        /// 1. STT Not Supported.
        /// 2. Permission Denied.
        /// 3. Invalid State.
        /// 4. Operation Failed.
        /// 5. Progress to ready is not finished.
        /// 6. Progress to recording is not finished.
        /// 7. Progress to processing is not finished.
        /// </exception>
        /// <precondition>
        /// The state should be Recording.
        /// </precondition>
        /// <postcondition>
        /// It will invoke StateChanged Event if registerd.
        /// If this function succeeds, the STT state will be Processing.
        /// If you call this function again before state changes, you will receive ErrorINProgressToProcessing.
        /// After processing of engine, RecognitionResult event is invoked
        /// </postcondition>
        public void Stop()
        {
            lock (thisLock)
            {
                SttError error = SttStop(_handle);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "Stop Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Cancels processing recognition and recording asynchronously.
        /// This function cancels recording and engine cancels recognition processing.
        /// After successful cancel, StateChanged event is invoked otherwise if error is occurred, ErrorOccured event is invoked.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/recorder
        /// </priviledge>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reasons
        /// 1. STT Not Supported.
        /// 2. Permission Denied.
        /// 3. Invalid State.
        /// 4. Operation Failed.
        /// 5. Progress to ready is not finished.
        /// 6. Progress to recording is not finished.
        /// 7. Progress to processing is not finished.
        /// </exception>
        /// <precondition>
        /// The state should be Recording or Processing.
        /// </precondition>
        /// <postcondition>
        /// It will invoke StateChanged Event if registerd.
        /// If this function succeeds, the STT state will be Ready.
        /// If you call this function again before state changes, you will receive ErrorINProgressToReady.
        /// </postcondition>
        public void Cancel()
        {
            lock (thisLock)
            {
                SttError error = SttCancel(_handle);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "Cancel Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Method to release resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    SttError error = SttDestroy(_handle);
                    if (error != SttError.None)
                    {
                        Log.Error(LogTag, "Destroy Failed with error " + error);
                    }
                }

                disposedValue = true;
            }
        }
    }
}

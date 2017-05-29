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
using static Interop.Tts;

namespace Tizen.Uix.Tts
{
    /// <summary>
    /// Enumeration for States
    /// </summary>
    public enum State
    {
        /// <summary>
        /// Created atate
        /// </summary>
        Created = 0,

        /// <summary>
        /// Ready state
        /// </summary>
        Ready = 1,

        /// <summary>
        /// Playing state
        /// </summary>
        Playing = 2,

        /// <summary>
        /// Paused state
        /// </summary>
        Paused = 3,

        /// <summary>
        /// state Unavailable
        /// </summary>
        Unavailable
    };

    /// <summary>
    /// Enumeration for TTS mode.
    /// </summary>
    public enum Mode
    {
        /// <summary>
        /// Default mode for normal application
        /// </summary>
        Default = 0,

        /// <summary>
        /// Notification mode
        /// </summary>
        Notification = 1,

        /// <summary>
        /// Accessibiliity mode
        /// </summary>
        ScreenReader = 2
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
        /// Invalid Voice
        /// </summary>
        InvalidVoice,
        /// <summary>
        /// No available engine
        /// </summary>
        EngineNotFound,
        /// <summary>
        /// Operation failed
        /// </summary>
        OperationFailed,
        /// <summary>
        /// Audio policy blocked
        /// </summary>
        AudioPolicyBlocked
    };

    /// <summary>
    /// Enumeration for Voice Types
    /// </summary>
    public enum Voice
    {
        /// <summary>
        /// Automatic Voice Type
        /// </summary>
        Auto,

        /// <summary>
        /// Male Voice
        /// </summary>
        Male,

        /// <summary>
        /// Female Voice
        /// </summary>
        Female,

        /// <summary>
        /// Child Voice Type
        /// </summary>
        Child
    };

    /// <summary>
    /// You can use Text-To-Speech (TTS) API's to read sound data transformed by the engine from input texts.
    /// Applications can add input-text to queue for reading continuously and control the player that can play, pause, and stop sound data synthesized from text.
    /// </summary>
    public class TtsClient : IDisposable
    {
        private IntPtr _handle;
        private event EventHandler<StateChangedEventArgs> _stateChanged;
        private event EventHandler<UtteranceEventArgs> _utteranceStarted;
        private event EventHandler<UtteranceEventArgs> _utteranceCompleted;
        private event EventHandler<ErrorOccuredEventArgs> _errorOccured;
        private event EventHandler<DefaultVoiceChangedEventArgs> _defaultVoiceChanged;
        private event EventHandler<EngineChangedEventArgs> _engineChanged;
        private bool disposedValue = false;
        private Object thisLock = new Object();
        private TtsStateChangedCB _stateDelegate;
        private TtsUtteranceStartedCB _utteranceStartedResultDelegate;
        private TtsUtteranceCompletedCB _utteranceCompletedResultDelegate;
        private TtsErrorCB _errorDelegate;
        private TtsDefaultVoiceChangedCB _voiceChangedDelegate;
        private TtsEngineChangedCB _engineDelegate;
        private TtsSupportedVoiceCB _supportedvoiceDelegate;

        /// <summary>
        /// Constructor to create a TTS instance.
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. Out Of Memory
        /// 2. Operation Failed
        /// 3. TTS Not Supported
        /// 4. Engine Not Found
        /// </exception>
        public TtsClient()
        {
            IntPtr handle;
            TtsError error = TtsCreate(out handle);
            if (error != TtsError.None)
            {
                Log.Error(LogTag, "Create Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            _handle = handle;
        }

        /// <summary>
        /// Event to be invoked when TTS state changes.
        /// </summary>
        public event EventHandler<StateChangedEventArgs> StateChanged
        {
            add
            {
                lock (thisLock)
                {
                    _stateDelegate = (IntPtr handle, State previous, State current, IntPtr userData) =>
                {
                    StateChangedEventArgs args = new StateChangedEventArgs(previous, current);
                    _stateChanged?.Invoke(this, args);
                };
                    TtsError error = TtsSetStateChangedCB(_handle, _stateDelegate, IntPtr.Zero);
                    if (error != TtsError.None)
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
                    TtsError error = TtsUnsetStateChangedCB(_handle);
                    if (error != TtsError.None)
                    {
                        Log.Error(LogTag, "Remove StateChanged Failed with error " + error);
                    }

                    _stateChanged -= value;
                }
            }

        }

        /// <summary>
        /// Event to be invoked when the utterance starts.
        /// </summary>
        public event EventHandler<UtteranceEventArgs> UtteranceStarted
        {
            add
            {
                lock (thisLock)
                {
                    _utteranceStartedResultDelegate = (IntPtr handle, int uttId, IntPtr userData) =>
                {
                    UtteranceEventArgs args = new UtteranceEventArgs(uttId);
                    _utteranceStarted?.Invoke(this, args);
                };
                    TtsError error = TtsSetUtteranceStartedCB(_handle, _utteranceStartedResultDelegate, IntPtr.Zero);
                    if (error != TtsError.None)
                    {
                        Log.Error(LogTag, "Add UtteranceStarted Failed with error " + error);
                    }
                    else
                    {
                        _utteranceStarted += value;
                    }
                }
            }

            remove
            {
                lock (thisLock)
                {
                    TtsError error = TtsUnsetUtteranceStartedCB(_handle);
                    if (error != TtsError.None)
                    {
                        Log.Error(LogTag, "Remove UtteranceStarted Failed with error " + error);
                    }

                    _utteranceStarted -= value;
                }
            }
        }

        /// <summary>
        /// Event to be invoked when the utterance completes.
        /// </summary>
        public event EventHandler<UtteranceEventArgs> UtteranceCompleted
        {
            add
            {
                lock (thisLock)
                {
                    _utteranceCompletedResultDelegate = (IntPtr handle, int uttId, IntPtr userData) =>
                {
                    UtteranceEventArgs args = new UtteranceEventArgs(uttId);
                    _utteranceCompleted?.Invoke(this, args);
                };
                    TtsError error = TtsSetUtteranceCompletedCB(_handle, _utteranceCompletedResultDelegate, IntPtr.Zero);
                    if (error != TtsError.None)
                    {
                        Log.Error(LogTag, "Add UtteranceCompleted Failed with error " + error);
                    }
                    else
                    {
                        _utteranceCompleted += value;
                    }
                }
            }

            remove
            {
                lock (thisLock)
                {
                    TtsError error = TtsUnsetUtteranceCompletedCB(_handle);
                    if (error != TtsError.None)
                    {
                        Log.Error(LogTag, "Remove UtteranceCompleted Failed with error " + error);
                    }

                    _utteranceCompleted -= value;
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
                    _errorDelegate = (IntPtr handle, int uttId, TtsError reason, IntPtr userData) =>
                {
                    ErrorOccuredEventArgs args = new ErrorOccuredEventArgs(handle, uttId, reason);
                    _errorOccured?.Invoke(this, args);
                };
                    TtsError error = TtsSetErrorCB(_handle, _errorDelegate, IntPtr.Zero);
                    if (error != TtsError.None)
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
                    TtsError error = TtsUnsetErrorCB(_handle);
                    if (error != TtsError.None)
                    {
                        Log.Error(LogTag, "Remove ErrorOccured Failed with error " + error);
                    }

                    _errorOccured -= value;
                }
            }
        }

        /// <summary>
        /// Event to be invoked when an error occurs.
        /// </summary>
        public event EventHandler<DefaultVoiceChangedEventArgs> DefaultVoiceChanged
        {
            add
            {
                lock (thisLock)
                {
                    _voiceChangedDelegate = (IntPtr handle, IntPtr previousLanguage, int previousVoiceType, IntPtr currentLanguage, int currentVoiceType, IntPtr userData) =>
                {
                    string previousLanguageString = Marshal.PtrToStringAnsi(previousLanguage);
                    string currentLanguageString = Marshal.PtrToStringAnsi(currentLanguage);
                    DefaultVoiceChangedEventArgs args = new DefaultVoiceChangedEventArgs(previousLanguageString, previousVoiceType, currentLanguageString, currentVoiceType);
                    _defaultVoiceChanged?.Invoke(this, args);
                };
                    TtsError error = TtsSetDefaultVoiceChangedCB(_handle, _voiceChangedDelegate, IntPtr.Zero);
                    if (error != TtsError.None)
                    {
                        Log.Error(LogTag, "Add DefaultVoiceChanged Failed with error " + error);
                    }

                    else
                    {
                        _defaultVoiceChanged += value;
                    }
                }

            }

            remove
            {
                lock (thisLock)
                {
                    TtsError error = TtsUnsetDefaultVoiceChangedCB(_handle);
                    if (error != TtsError.None)
                    {
                        Log.Error(LogTag, "Remove DefaultVoiceChanged Failed with error " + error);
                    }

                    _defaultVoiceChanged -= value;
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
                    _engineDelegate = (IntPtr handle, IntPtr engineId, IntPtr language, int voiceType, bool needCredential, IntPtr userData) =>
                {
                    string engineIdString = Marshal.PtrToStringAnsi(engineId);
                    string languageString = Marshal.PtrToStringAnsi(language);
                    EngineChangedEventArgs args = new EngineChangedEventArgs(engineIdString, languageString, voiceType, needCredential);
                    _engineChanged?.Invoke(this, args);
                };
                    TtsError error = TtsSetEngineChangedCB(_handle, _engineDelegate, IntPtr.Zero);
                    if (error != TtsError.None)
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
                    TtsError error = TtsUnsetEngineChangedCB(_handle);
                    if (error != TtsError.None)
                    {
                        Log.Error(LogTag, "Remove EngineChanged Failed with error " + error);
                    }

                    _engineChanged -= value;
                }
            }
        }

        /// <summary>
        /// Gets the default voice set by the user.
        /// </summary>
        /// <value>
        /// Default voice in TTS
        /// </value>
        /// <returns>
        /// Default Voice SupportedVoice value.
        /// </returns>
        public SupportedVoice DefaultVoice
        {
            get
            {
                lock (thisLock)
                {
                    string language;
                    int voiceType;
                    TtsError error = TtsGetDefaultVoice(_handle, out language, out voiceType);
                    if (error != TtsError.None)
                    {
                        Log.Error(LogTag, "DefaultVoice Failed with error " + error);
                        return new SupportedVoice();
                    }

                    return new SupportedVoice(language, voiceType);
                }
            }
        }

        /// <summary>
        /// Gets the maximum byte size for text.
        /// </summary>
        /// <value>
        /// Maximum byte size for text
        /// </value>
        /// <returns>
        /// Default Voice SupportedVoice value, 0 if unable to get the value
        /// </returns>
        /// <pre>
        /// The State should be Ready
        /// </pre>
        public uint GetMaxTextSize
        {
            get
            {
                uint maxTextSize;
                lock (thisLock)
                {
                    TtsError error = TtsGetMaxTextSize(_handle, out maxTextSize);
                    if (error != TtsError.None)
                    {
                        Log.Error(LogTag, "MaxTextSize Failed with error " + error);
                        return 0;
                    }

                }

                return maxTextSize;
            }

        }

        /// <summary>
        /// Gets the current TTS state.
        /// </summary>
        /// <value>
        /// Current state of TTS
        /// </value>
        /// <returns>
        /// Current TTS State value.
        /// </returns>
        public State GetState
        {
            get
            {
                State state;
                lock (thisLock)
                {
                    TtsError error = TtsGetState(_handle, out state);
                    if (error != TtsError.None)
                    {
                        Log.Error(LogTag, "CurrentState Failed with error " + error);
                        return State.Unavailable;
                    }

                }

                return state;
            }

        }

        /// <summary>
        /// The TTS Mode can be set using this property
        /// </summary>
        /// <value>
        /// Current mode of TTS (default, screen-reader, notification)
        /// </value>
        /// <returns>
        /// The Mode value
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons while setting the value
        /// 1. Out Of Memory
        /// 2. Operation Failed
        /// 3. TTS Not Supported
        /// 4. Engine Not Found
        /// </exception>
        /// <pre>
        /// State should be Created
        /// </pre>
        public Mode CurrentMode
        {
            get
            {
                Mode mode = Mode.Default;
                lock (thisLock)
                {
                    TtsError error = TtsGetMode(_handle, out mode);
                    if (error != TtsError.None)
                    {
                        Log.Error(LogTag, "Get Mode Failed with error " + error);
                        return Mode.Default;
                    }
                }

                return mode;
            }
            set
            {
                TtsError error;
                lock (thisLock)
                {
                    error = TtsSetMode(_handle, value);
                }

                if (error != TtsError.None)
                {
                    Log.Error(LogTag, "Set Mode Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Sets the app credential
        /// </summary>
        /// <param name="credential">
        /// The credential string
        /// </param>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. TTS Not Supported
        /// 2. Invalid State
        /// </exception>
        /// <exception cref="ArgumentException">
        /// This can happen if Improper value is provided while setting the value.
        /// </exception>
        /// <pre>
        /// The State must be Created or Ready.
        /// </pre>
        public void SetCredential(string credential)
        {
            lock (thisLock)
            {
                TtsError error = TtsSetCredential(_handle, credential);
                if (error != TtsError.None)
                {
                    Tizen.Log.Error(LogTag, "SetCredential Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Connects to the TTS service asynchronously.
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reasons
        /// 1. TTS Not Supported
        /// 2. Invalid State
        /// </exception>
        /// <pre>
        /// The State must be Created.
        /// </pre>
        /// <post>
        /// If this function is successful, the TTS state will be Ready
        /// If this function is unsuccessful, ErrorOccured event will be invoked
        /// </post>
        public void Prepare()
        {
            lock (thisLock)
            {
                TtsError error = TtsPrepare(_handle);
                if (error != TtsError.None)
                {
                    Log.Error(LogTag, "Prepare Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Disconnects from the STT service.
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reasons
        /// 1. TTS Not Supported
        /// 2. Invalid State
        /// </exception>
        /// <pre>
        /// The State must be Ready.
        /// </pre>
        /// <post>
        /// If this function is successful, the TTS state will be Created
        /// </post>
        public void Unprepare()
        {
            lock (thisLock)
            {
                TtsError error = TtsUnprepare(_handle);
                if (error != TtsError.None)
                {
                    Log.Error(LogTag, "Unprepare Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Retrieves all supported voices of the current engine.
        /// </summary>
        /// <returns>
        /// list of SupportedVoice.
        /// </returns>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reasons
        /// 1. TTS Not Supported
        /// 2. Engine Not Found.
        /// 3. Operation Failed.
        /// </exception>
        public IEnumerable<SupportedVoice> GetSupportedVoices()
        {
            List<SupportedVoice> voicesList = new List<SupportedVoice>();
            lock (thisLock)
            {
               _supportedvoiceDelegate = (IntPtr handle, IntPtr language, int voiceType, IntPtr userData) =>
            {
                string lang = Marshal.PtrToStringAnsi(language);
                SupportedVoice voice = new SupportedVoice(lang, voiceType);
                voicesList.Add(voice);
                return true;
            };
                TtsError error = TtsForeachSupportedVoices(_handle, _supportedvoiceDelegate, IntPtr.Zero);
                if (error != TtsError.None)
                {
                    Log.Error(LogTag, "GetSupportedVoices Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }

            }

            return voicesList;
        }

        /// <summary>
        /// Gets the private data from tts engine.
        /// </summary>
        /// <param name="key">
        /// The key string
        /// </param>
        /// <returns>
        /// The Data Corresponding to the Key provided
        /// </returns>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. TTS Not Supported
        /// 2. Invalid State
        /// 3. Engine Not found
        /// 4. Operation Failure
        /// </exception>
        /// <pre>
        /// The State must be Ready.
        /// </pre>
        public string GetPrivateData(string key)
        {
            string data;
            lock (thisLock)
            {
                TtsError error = TtsGetPrivateData(_handle, key, out data);
                if (error != TtsError.None)
                {
                    Log.Error(LogTag, "GetPrivateData Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }

            }

            return data;
        }

        /// <summary>
        /// Sets the private data to tts engine.
        /// </summary>
        /// <param name="key">
        /// The key string
        /// </param>
        /// <param name="data">
        /// The data string
        /// </param>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. TTS Not Supported
        /// 2. Invalid State
        /// 3. Engine Not found
        /// 4. Operation Failure
        /// </exception>
        /// <exception cref="ArgumentException">
        /// This can happen if Improper value is provided while setting the value.
        /// </exception>
        /// <pre>
        /// The State must be Ready.
        /// </pre>
        public void SetPrivateData(string key, string data)
        {
            lock (thisLock)
            {
                TtsError error = TtsSetPrivateData(_handle, key, data);
                if (error != TtsError.None)
                {
                    Log.Error(LogTag, "SetPrivateData Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Gets the speed range.
        /// </summary>
        /// <returns>
        /// The SpeedRange value
        /// </returns>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. TTS Not Supported
        /// 2. Invalid State
        /// 3. Operation Failure
        /// </exception>
        /// <pre>
        /// The State must be Created.
        /// </pre>
        public SpeedRange GetSpeedRange()
        {
            int min = 0, max = 0, normal = 0;
            lock (thisLock)
            {
                TtsError error = TtsGetSpeedRange(_handle, out min, out normal, out max);
                if (error != TtsError.None)
                {
                    Log.Error(LogTag, "GetSpeedRange Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }

            }

            return new SpeedRange(min, normal, max);
        }

        /// <summary>
        /// Adds a text to the queue.
        /// </summary>
        /// <remarks>
        /// Locale MUST be set for utf8 text validation check.
        /// </remarks>
        /// <param name="text">
        /// An input text based utf8
        /// </param>
        /// <param name="language">
        /// The language selected from the SupportedVoice.Language Property obtained from GetSupportedVoices() (e.g. 'NULL'(Automatic), 'en_US')
        /// </param>
        /// <param name="voiceType">
        /// The voice type selected from the SupportedVoice.VoiceType Property obtained from GetSupportedVoices()
        /// </param>
        /// <param name="speed">
        /// A speaking speed (e.g.0 for Auto or the value from SpeedRange Property)
        /// </param>
        /// <returns>
        /// The utterance ID.
        /// </returns>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. TTS Not Supported
        /// 2. Invalid State
        /// 3. Operation Failure
        /// 4. Invalid Voice
        /// 5. Permission Denied
        /// </exception>
        /// <exception cref="ArgumentException">
        /// This can happen if Improper value is provided.
        /// </exception>
        /// <pre>
        /// The State must be Ready or Playing or Paused.
        /// </pre>
        public int AddText(string text, string language, int voiceType, int speed)
        {
            int id;
            lock (thisLock)
            {
                TtsError error = TtsAddText(_handle, text, language, voiceType, speed, out id);
                if (error != TtsError.None)
                {
                    Log.Error(LogTag, "AddText Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }

            }

            return id;
        }

        /// <summary>
        /// Starts synthesizing voice from the text and plays the synthesized audio data.
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. TTS Not Supported
        /// 2. Invalid State
        /// 3. Operation Failure
        /// 4. Out of Network
        /// 5. Permission Denied
        /// </exception>
        /// <pre>
        /// The State must be Ready or Paused.
        /// </pre>
        /// <post>
        /// If this function succeeds, the TTS state will be Playing.
        /// </post>
        public void Play()
        {
            lock (thisLock)
            {
                TtsError error = TtsPlay(_handle);
                if (error != TtsError.None)
                {
                    Log.Error(LogTag, "Play Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Stops playing the utterance and clears the queue.
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. TTS Not Supported
        /// 2. Invalid State
        /// 3. Operation Failure
        /// </exception>
        /// <pre>
        /// The State must be Ready or Playing or Paused.
        /// </pre>
        /// <post>
        /// If this function succeeds, the TTS state will be Ready.
        /// This function will remove all text added via AddText() and synthesized sound data.
        /// </post>
        public void Stop()
        {
            lock (thisLock)
            {
                TtsError error = TtsStop(_handle);
                if (error != TtsError.None)
                {
                    Log.Error(LogTag, "Stop Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Pauses the currently playing utterance.
        /// </summary>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. TTS Not Supported
        /// 2. Invalid State
        /// 3. Operation Failure
        /// </exception>
        /// <pre>
        /// The State must be Playing.
        /// </pre>
        /// <post>
        /// If this function succeeds, the TTS state will be Paused.
        /// </post>
        public void Pause()
        {
            lock (thisLock)
            {
                TtsError error = TtsPause(_handle);
                if (error != TtsError.None)
                {
                    Log.Error(LogTag, "Pause Failed with error " + error);
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
                    TtsError error = TtsDestroy(_handle);
                    if (error != TtsError.None)
                    {
                        Log.Error(LogTag, "Destroy Failed with error " + error);
                    }
                }

                disposedValue = true;
            }
        }
    }
}

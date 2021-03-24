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
    /// Enumeration for the states.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum State
    {
        /// <summary>
        ///  Created state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Created = 0,

        /// <summary>
        /// Ready state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Ready = 1,

        /// <summary>
        /// Playing state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Playing = 2,

        /// <summary>
        /// Paused state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Paused = 3,

        /// <summary>
        /// Unavailable state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Unavailable
    };

    /// <summary>
    /// Enumeration for TTS mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum Mode
    {
        /// <summary>
        /// Default mode for normal application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Default = 0,

        /// <summary>
        /// Notification mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Notification = 1,

        /// <summary>
        /// Accessibility mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ScreenReader = 2
    };

    /// <summary>
    /// Enumeration for error values that can occur.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum Error
    {
        /// <summary>
        /// Successful, no error.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        None,
        /// <summary>
        /// Out of memory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        OutOfMemory,
        /// <summary>
        /// I/O error.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// STT not supported.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        NotSupported,
        /// <summary>
        /// Invalid state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        InvalidState,
        /// <summary>
        /// Invalid voice.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        InvalidVoice,
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
        /// Audio policy blocked.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        AudioPolicyBlocked
    };

    /// <summary>
    /// Enumeration for the voice types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum Voice
    {
        /// <summary>
        /// The automatic voice type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Auto,

        /// <summary>
        /// The male voice type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Male,

        /// <summary>
        /// The female voice type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Female,

        /// <summary>
        /// The child voice type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Child
    };

    /// <summary>
    /// You can use Text-To-Speech (TTS) API's to read sound data transformed by the engine from input texts.
    /// Applications can add input-text to queue for reading continuously and control the player that can play, pause, and stop sound data synthesized from text.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class TtsClient : IDisposable
    {
        private IntPtr _handle;
        private event EventHandler<StateChangedEventArgs> _stateChanged;
        private event EventHandler<UtteranceEventArgs> _utteranceStarted;
        private event EventHandler<UtteranceEventArgs> _utteranceCompleted;
        private event EventHandler<ErrorOccurredEventArgs> _errorOccurred;
        private event EventHandler<DefaultVoiceChangedEventArgs> _defaultVoiceChanged;
        private event EventHandler<EngineChangedEventArgs> _engineChanged;
        private bool disposedValue = false;
        private readonly Object _stateChangedLock = new Object();
        private readonly Object _utteranceStartedLock = new Object();
        private readonly Object _utteranceCompletedLock = new Object();
        private readonly Object _errorOccurredLock = new Object();
        private readonly Object _defaultVoiceChangedLock = new Object();
        private readonly Object _engineChangedLock = new Object();
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
        /// <since_tizen> 3 </since_tizen>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Operation Failed
        /// 2. Engine Not Found
        /// </exception>
        /// <exception cref="OutOfMemoryException">This exception can be due to out Of memory.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to TTS not supported.</exception>
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
        /// Destructor to destroy TtsClient handle.
        /// </summary>
        ~TtsClient()
        {
            Dispose(false);
        }

        /// <summary>
        /// Event to be invoked when TTS state changes.
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
                        TtsError error = TtsUnsetStateChangedCB(_handle);
                        if (error != TtsError.None)
                        {
                            Log.Error(LogTag, "Remove StateChanged Failed with error " + error);
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Event to be invoked when the utterance starts.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<UtteranceEventArgs> UtteranceStarted
        {
            add
            {
                lock (_utteranceStartedLock)
                {
                    if (_utteranceStarted == null)
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
                    }
                    _utteranceStarted += value;
                }
            }

            remove
            {
                lock (_utteranceStartedLock)
                {
                    _utteranceStarted -= value;
                    if (_utteranceStarted == null)
                    {
                        TtsError error = TtsUnsetUtteranceStartedCB(_handle);
                        if (error != TtsError.None)
                        {
                            Log.Error(LogTag, "Remove UtteranceStarted Failed with error " + error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event to be invoked when the utterance completes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<UtteranceEventArgs> UtteranceCompleted
        {
            add
            {
                lock (_utteranceCompletedLock)
                {
                    if (_utteranceCompleted == null)
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
                    }
                    _utteranceCompleted += value;
                }
            }

            remove
            {
                lock (_utteranceCompletedLock)
                {
                    _utteranceCompleted -= value;
                    if (_utteranceCompleted == null)
                    {
                        TtsError error = TtsUnsetUtteranceCompletedCB(_handle);
                        if (error != TtsError.None)
                        {
                            Log.Error(LogTag, "Remove UtteranceCompleted Failed with error " + error);
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
                        _errorDelegate = (IntPtr handle, int uttId, TtsError reason, IntPtr userData) =>
                        {
                            ErrorOccurredEventArgs args = new ErrorOccurredEventArgs(handle, uttId, reason);
                            _errorOccurred?.Invoke(this, args);
                        };

                        TtsError error = TtsSetErrorCB(_handle, _errorDelegate, IntPtr.Zero);
                        if (error != TtsError.None)
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
                        TtsError error = TtsUnsetErrorCB(_handle);
                        if (error != TtsError.None)
                        {
                            Log.Error(LogTag, "Remove ErrorOccurred Failed with error " + error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event to be invoked when an error occurs.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<DefaultVoiceChangedEventArgs> DefaultVoiceChanged
        {
            add
            {
                lock (_defaultVoiceChangedLock)
                {
                    if (_defaultVoiceChanged == null)
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
                    }
                    _defaultVoiceChanged += value;
                }
            }

            remove
            {
                lock (_defaultVoiceChangedLock)
                {
                    _defaultVoiceChanged -= value;
                    if (_defaultVoiceChanged == null)
                    {
                        TtsError error = TtsUnsetDefaultVoiceChangedCB(_handle);
                        if (error != TtsError.None)
                        {
                            Log.Error(LogTag, "Remove DefaultVoiceChanged Failed with error " + error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event to be invoked to detect engine change.
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
                        TtsError error = TtsUnsetEngineChangedCB(_handle);
                        if (error != TtsError.None)
                        {
                            Log.Error(LogTag, "Remove EngineChanged Failed with error " + error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the default voice set by the user.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// The default voice in TTS.
        /// </value>
        /// <returns>
        /// The default voice SupportedVoice value.
        /// </returns>
        public SupportedVoice DefaultVoice
        {
            get
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

        /// <summary>
        /// Gets the maximum byte size for text.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// The Maximum byte size for text.
        /// </value>
        /// <returns>
        /// The Default Voice SupportedVoice value, 0 if unable to get the value.
        /// </returns>
        /// <pre>
        /// The State should be ready.
        /// </pre>
        public uint MaxTextSize
        {
            get
            {
                uint maxTextSize;
                TtsError error = TtsGetMaxTextSize(_handle, out maxTextSize);
                if (error != TtsError.None)
                {
                    Log.Error(LogTag, "MaxTextSize Failed with error " + error);
                    return 0;
                }

                return maxTextSize;
            }

        }

        /// <summary>
        /// Gets the current TTS state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// The current state of TTS.
        /// </value>
        /// <returns>
        /// Current TTS State value.
        /// </returns>
        public State CurrentState
        {
            get
            {
                State state;
                TtsError error = TtsGetState(_handle, out state);
                if (error != TtsError.None)
                {
                    Log.Error(LogTag, "CurrentState Failed with error " + error);
                    return State.Unavailable;
                }

                return state;
            }

        }

        /// <summary>
        /// The TTS Mode can be set using this property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// The current TTS mode (default, screen-reader, notification).
        /// </value>
        /// <returns>
        /// The Mode value.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons while setting the value:
        /// 1. Operation Failed
        /// 2. Engine Not Found
        /// </exception>
        /// <exception cref="OutOfMemoryException">This exception can be due to out Of memory.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to TTS not supported.</exception>
        /// <pre>
        /// The State should be created.
        /// </pre>
        public Mode CurrentMode
        {
            get
            {
                Mode mode = Mode.Default;
                TtsError error = TtsGetMode(_handle, out mode);
                if (error != TtsError.None)
                {
                    Log.Error(LogTag, "Get Mode Failed with error " + error);
                    return Mode.Default;
                }

                return mode;
            }
            set
            {
                TtsError error;
                error = TtsSetMode(_handle, value);

                if (error != TtsError.None)
                {
                    Log.Error(LogTag, "Set Mode Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Sets the application credential.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="credential">.
        /// The credential string.
        /// </param>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to TTS not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to improper value provided while setting the value.</exception>
        /// <pre>
        /// The State should be created or ready.
        /// </pre>
        public void SetCredential(string credential)
        {
            TtsError error = TtsSetCredential(_handle, credential);
            if (error != TtsError.None)
            {
                Tizen.Log.Error(LogTag, "SetCredential Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Connects to the TTS service asynchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to TTS not supported.</exception>
        /// <pre>
        /// The State must be Created.
        /// </pre>
        /// <post>
        /// If this function is successful, the TTS state will be ready.
        /// If this function is unsuccessful, ErrorOccurred event will be invoked.
        /// </post>
        public void Prepare()
        {
            TtsError error = TtsPrepare(_handle);
            if (error != TtsError.None)
            {
                Log.Error(LogTag, "Prepare Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Disconnects from the STT service.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to TTS not supported.</exception>
        /// <pre>
        /// The state must be ready.
        /// </pre>
        /// <post>
        /// If this function is successful, the TTS state will be created.
        /// </post>
        public void Unprepare()
        {
            TtsError error = TtsUnprepare(_handle);
            if (error != TtsError.None)
            {
                Log.Error(LogTag, "Unprepare Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Retrieves all supported voices of the current engine.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// The list of SupportedVoice.
        /// </returns>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Engine Not Found
        /// 2. Operation Failed
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to TTS not supported.</exception>
        public IEnumerable<SupportedVoice> GetSupportedVoices()
        {
            List<SupportedVoice> voicesList = new List<SupportedVoice>();

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

            return voicesList;
        }

        /// <summary>
        /// Gets the private data from TTS engine.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="key">
        /// The key string.
        /// </param>
        /// <returns>
        /// The data corresponding to the provided key.
        /// </returns>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Invalid State
        /// 2. Engine Not found
        /// 3. Operation Failure
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to TTS not supported.</exception>
        /// <pre>
        /// The state must be ready.
        /// </pre>
        public string GetPrivateData(string key)
        {
            string data;
            TtsError error = TtsGetPrivateData(_handle, key, out data);
            if (error != TtsError.None)
            {
                Log.Error(LogTag, "GetPrivateData Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return data;
        }

        /// <summary>
        /// Sets the private data to tts engine.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="key">
        /// The key string.
        /// </param>
        /// <param name="data">
        /// The data string.
        /// </param>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Invalid State
        /// 2. Engine Not found
        /// 3. Operation Failure
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to TTS not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to improper value provided while setting the value.</exception>
        /// <pre>
        /// The state must be ready.
        /// </pre>
        public void SetPrivateData(string key, string data)
        {
            TtsError error = TtsSetPrivateData(_handle, key, data);
            if (error != TtsError.None)
            {
                Log.Error(LogTag, "SetPrivateData Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Gets the speed range.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// The SpeedRange value.
        /// </returns>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Invalid State
        /// 2. Operation Failure
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to TTS not supported.</exception>
        /// <pre>
        /// The state must be created.
        /// </pre>
        public SpeedRange GetSpeedRange()
        {
            int min = 0, max = 0, normal = 0;
            TtsError error = TtsGetSpeedRange(_handle, out min, out normal, out max);
            if (error != TtsError.None)
            {
                Log.Error(LogTag, "GetSpeedRange Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return new SpeedRange(min, normal, max);
        }

        /// <summary>
        /// Adds a text to the queue.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Locale MUST be set for UTF-8 text validation check.
        /// </remarks>
        /// <param name="text">
        /// An input text based UTF-8.
        /// </param>
        /// <param name="language">
        /// The language selected from the SupportedVoice.Language Property obtained from GetSupportedVoices()(e.g. 'NULL'(Automatic),'en_US').
        /// </param>
        /// <param name="voiceType">
        /// The voice type selected from the SupportedVoice.VoiceType Property obtained from GetSupportedVoices().
        /// </param>
        /// <param name="speed">
        /// A speaking speed (e.g.0 for Auto or the value from SpeedRange Property).
        /// </param>
        /// <returns>
        /// The utterance ID.
        /// </returns>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Invalid State
        /// 2. Operation Failure
        /// 3. Invalid Voice
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to TTS not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="ArgumentException">This exception can be due to improper value provided while setting the value.</exception>
        /// <pre>
        /// The state must be ready or playing or paused.
        /// </pre>
        public int AddText(string text, string language, int voiceType, int speed)
        {
            int id;
            TtsError error = TtsAddText(_handle, text, language, voiceType, speed, out id);
            if (error != TtsError.None)
            {
                Log.Error(LogTag, "AddText Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return id;
        }

        /// <summary>
        /// Starts synthesizing voice from the text and plays the synthesized audio data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Invalid State
        /// 2. Operation Failure
        /// 3. Out of Network
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to TTS not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <pre>
        /// The state must be ready or paused.
        /// </pre>
        /// <post>
        /// If this function succeeds, the TTS state will be playing.
        /// </post>
        public void Play()
        {
            TtsError error = TtsPlay(_handle);
            if (error != TtsError.None)
            {
                Log.Error(LogTag, "Play Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Stops playing the utterance and clears the queue.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Invalid Stat
        /// 2. Operation Failure
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to TTS not supported.</exception>
        /// <pre>
        /// The state must be ready or playing or paused.
        /// </pre>
        /// <post>
        /// If this function succeeds, the TTS state will be ready.
        /// This function will remove all text added via AddText() and synthesized sound data.
        /// </post>
        public void Stop()
        {
            TtsError error = TtsStop(_handle);
            if (error != TtsError.None)
            {
                Log.Error(LogTag, "Stop Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Pauses the currently playing utterance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>
        /// http://tizen.org/feature/speech.synthesis
        /// </feature>
        /// <exception cref="InvalidOperationException">
        /// This exception can be due to the following reasons:
        /// 1. Invalid State
        /// 2. Operation Failure
        /// </exception>
        /// <exception cref="NotSupportedException">This exception can be due to TTS not supported.</exception>
        /// <pre>
        /// The state must be playing.
        /// </pre>
        /// <post>
        /// If this function succeeds, the TTS state will be Paused.
        /// </post>
        public void Pause()
        {
            TtsError error = TtsPause(_handle);
            if (error != TtsError.None)
            {
                Log.Error(LogTag, "Pause Failed with error " + error);
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
        /// The boolean value for destoying tts handle.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (_handle != IntPtr.Zero)
                {
                    TtsError error = TtsDestroy(_handle);
                    if (error != TtsError.None)
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

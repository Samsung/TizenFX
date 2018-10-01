/*
* Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using static Interop.VoiceControlWidget;
using static Interop.VoiceControlCommand;

namespace Tizen.Uix.VoiceControlWidget
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
        Unavailable = -1
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
        Unavailable = -1
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
    /// Enumerations of send event type
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// Enumerations of recognition mode
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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

    public class VoiceControlWidget
    {
        private event EventHandler<StateChangedEventArgs> _stateChanged;
        private event EventHandler<ServiceStateChangedEventArgs> _serviceStateChanged;
        private event EventHandler<ErrorOccurredEventArgs> _errorOccurred;
        private event EventHandler<CurrentLanguageChangedEventArgs> _currentLanguageChanged;
        private event EventHandler<CurrentCommandListEventArgs> _currentCommandList;
        private event EventHandler<AsrResultEventArgs> _asrResult;
        private event EventHandler<TooltipEventArgs> _tooltip;
        private event EventHandler<RecognitionResult> _recognitionResult;
        private VcWidgetStateChangedCallback _stateDelegate;
        private VcWidgetServiceStateChangedCallback _serviceStateDelegate;
        private VcWidgetErrorCallback _errorDelegate;
        private VcWidgetCurrentLanguageChangedCallback _languageDelegate;
        private VcWidgetSendCurrentCommandListCb _currentCommandListDelegate;
        private VcWidgetAsrResultCallback _asrResultDelegate;
        private VcWidgetShowTooltipCb _showTooltiptDelegate;
        private List<string> _supportedLanguages;
        private IntPtr _handle;
        private VcWidgetResultCallback _resultDelegate;
        private VcWidgetSupportedLanguageCb _supportedLanguagesDelegate;


        public string CurrentLanguage
        {
            get
            {
                string currentLanguage;

                ErrorCode error = VcWidgetGetCurrentLanguage(_handle, out currentLanguage);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "CurrentLanaguge Failed with error " + error);
                    return "";
                }

                return currentLanguage;
            }
        }

        public State State
        {
            get
            {
                State state;

                ErrorCode error = VcWidgetGetState(_handle, out state);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "State Failed with error " + error);
                    return State.Unavailable;
                }

                return state;
            }
        }

        public ServiceState ServiceState
        {
            get
            {
                ServiceState state;

                ErrorCode error = VcWidgetGetServiceState(_handle, out state);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "ServiceState Failed with error " + error);
                    return ServiceState.Unavailable;
                }

                return state;
            }
        }

        public bool IsCommandFormatSupported(CommandFormat format)
        {
            bool supported = false;
            ErrorCode error = VcWidgetIsCommandFormatSupported(_handle, format, out supported);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "IsCommandFormatSupported Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
            return supported;
        }

        public void SetForeground(bool value)
        {
            ErrorCode error = VcWidgetSetForeground(_handle, value);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetForeground Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        public void Cancel()
        {
            ErrorCode error = VcWidgetCancel(_handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Cancel Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        public void Initialize()
        {
            ErrorCode error = VcWidgetInitialize(out _handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Initialize Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        public void Deinitialize()
        {
            ErrorCode error = VcWidgetDeinitialize(_handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Deinitialize Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        public void Prepare()
        {
            ErrorCode error = VcWidgetPrepare(_handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Prepare Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        public void Unprepare()
        {
            ErrorCode error = VcWidgetUnprepare(_handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Unprepare Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        public void EnableAsr(bool enable)
        {
            ErrorCode error = VcWidgetEnableAsrResult(_handle, enable);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "EnableAsr Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        public IEnumerable<string> GetSupportedLanguages()
        {
            _supportedLanguages = new List<string>();
            _supportedLanguagesDelegate = (IntPtr language, IntPtr userData) =>
            {
                string languageStr = Marshal.PtrToStringAnsi(language);
                _supportedLanguages.Add(languageStr);
                return true;
            };
            ErrorCode error = VcWidgetForeachSupportedLanguages(_handle, _supportedLanguagesDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetSupportedLanguages Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return _supportedLanguages;
        }

        public event EventHandler<ServiceStateChangedEventArgs> ServiceStateChanged
        {
            add
            {
                _serviceStateDelegate = (ServiceState previous, ServiceState current, IntPtr userData) =>
                {
                    ServiceStateChangedEventArgs args = new ServiceStateChangedEventArgs(previous, current);
                    _serviceStateChanged?.Invoke(null, args);
                };
                ErrorCode error = VcWidgetSetServiceStateChangedCb(_handle, _serviceStateDelegate, IntPtr.Zero);
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
                ErrorCode error = VcWidgetUnsetServiceStateChangedCb(_handle);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove ServiceStateChanged Failed with error " + error);
                }

                _serviceStateChanged -= value;
            }
        }

        public event EventHandler<StateChangedEventArgs> StateChanged
        {
            add
            {
                _stateDelegate = (State previous, State current, IntPtr userData) =>
                {
                    StateChangedEventArgs args = new StateChangedEventArgs(previous, current);
                    _stateChanged?.Invoke(null, args);
                };
                ErrorCode error = VcWidgetSetStateChangedCb(_handle, _stateDelegate, IntPtr.Zero);
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
                ErrorCode error = VcWidgetUnsetStateChangedCb(_handle);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove StateChanged Failed with error " + error);
                }

                _stateChanged -= value;
            }
        }

        public event EventHandler<ErrorOccurredEventArgs> ErrorOccurred
        {
            add
            {
                _errorDelegate = (ErrorCode reason, IntPtr userData) =>
            {
                ErrorOccurredEventArgs args = new ErrorOccurredEventArgs(reason);
                _errorOccurred?.Invoke(null, args);
            };
                ErrorCode error = VcWidgetSetErrorCb(_handle, _errorDelegate, IntPtr.Zero);
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
                ErrorCode error = VcWidgetUnsetErrorCb(_handle);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove ErrorOccurred Failed with error " + error);
                }

                _errorOccurred -= value;
            }
        }

        public event EventHandler<CurrentLanguageChangedEventArgs> CurrentLanguageChanged
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
                ErrorCode error = VcWidgetSetCurrentLanguageChangedCb(_handle, _languageDelegate, IntPtr.Zero);
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
                ErrorCode error = VcWidgetUnsetCurrentLanguageChangedCb(_handle);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove CurrentLanguageChanged Failed with error " + error);
                }

                _currentLanguageChanged -= value;
            }
        }

        public event EventHandler<CurrentCommandListEventArgs> CurrentCommandList
        {
            add
            {
                _currentCommandListDelegate = (out IntPtr listPtr, IntPtr userData) =>
                {
                    CurrentCommandListEventArgs args = new CurrentCommandListEventArgs();
                    _currentCommandList?.Invoke(null, args);

                    listPtr = args.CommandList._handle.DangerousGetHandle();
                    Log.Debug(LogTag, "Send current Command list");
                };
                ErrorCode error = VcWidgetSetSendCurrentCommandListCb(_handle, _currentCommandListDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add CurrentCommandList Failed with error " + error);
                }

                else
                {
                    _currentCommandList += value;
                }
            }

            remove
            {
                ErrorCode error = VcWidgetUnSetSendCurrentCommandListCb(_handle);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove CurrentCommandList Failed with error " + error);
                }

                _currentCommandList -= value;
            }
        }

        public event EventHandler<AsrResultEventArgs> AsrResult
        {
            add
            {
                _asrResultDelegate = (ResultEvent evt, IntPtr result, IntPtr userData) =>
                {
                    string resultString = Marshal.PtrToStringAnsi(result);
                    AsrResultEventArgs args = new AsrResultEventArgs(evt, resultString);
                    _asrResult?.Invoke(null, args);
                    return true;
                };
                ErrorCode error = VcWidgetSetAsrResultCb(_handle, _asrResultDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add AsrResult Failed with error " + error);
                }

                else
                {
                    _asrResult += value;
                }
            }

            remove
            {
                ErrorCode error = VcWidgetUnSetAsrResultCb(_handle);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove AsrResult Failed with error " + error);
                }

                _asrResult -= value;
            }
        }

        public event EventHandler<TooltipEventArgs> ShowTooltip
        {
            add
            {
                _showTooltiptDelegate = (bool show, IntPtr userData) =>
                {
                    TooltipEventArgs args = new TooltipEventArgs(show);
                    _tooltip?.Invoke(null, args);
                };
                ErrorCode error = VcWidgetSetShowTooltipCb(_handle, _showTooltiptDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add ShowTooltip Failed with error " + error);
                }

                else
                {
                    _tooltip += value;
                }
            }

            remove
            {
                ErrorCode error = VcWidgetUnSetShowTooltipCb(_handle);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove ShowTooltip Failed with error " + error);
                }

                _tooltip -= value;
            }
        }

        public event EventHandler<RecognitionResult> RecognitionResult
        {
            add
            {
                _resultDelegate = (ResultEvent evt, IntPtr cmdList, IntPtr result, IntPtr userData) =>
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
                ErrorCode error = VcWidgetSetResultCb(_handle, _resultDelegate, IntPtr.Zero);
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
                ErrorCode error = VcWidgetUnsetResultCb(_handle);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Remove RecognitionResult Failed with error " + error);
                }

                _recognitionResult -= value;
            }
        }
    }
}

/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Specifically manages the input method framework (IMF) that enables the virtual or hardware keyboards.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class InputMethodContext : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        private ActivatedEventCallbackType _activatedEventCallback;
        private EventReceivedEventCallbackType _eventReceivedEventCallback;
        private StatusChangedEventCallbackType _statusChangedEventCallback;
        private ResizedEventCallbackType _resizedEventCallback;
        private LanguageChangedEventCallbackType _languageChangedEventCallback;
        private KeyboardTypeChangedEventCallbackType _keyboardTypeChangedEventCallback;

        /// <summary>
        /// Constructor.<br/>
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public InputMethodContext() : this(NDalicManualPINVOKE.InputMethodContext_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        internal InputMethodContext(IntPtr cPtr, bool cMemoryOwn) : base(NDalicManualPINVOKE.InputMethodContext_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ActivatedEventCallbackType(IntPtr data);
        private delegate IntPtr EventReceivedEventCallbackType(IntPtr inputMethodContext, IntPtr eventData);
        private delegate void StatusChangedEventCallbackType(bool statusChanged);
        private delegate void ResizedEventCallbackType(int resized);
        private delegate void LanguageChangedEventCallbackType(int languageChanged);
        private delegate void KeyboardTypeChangedEventCallbackType(KeyboardType type);

        private event EventHandler<ActivatedEventArgs> _activatedEventHandler;
        private event EventHandlerWithReturnType<object, EventReceivedEventArgs, CallbackData> _eventReceivedEventHandler;
        private event EventHandler<StatusChangedEventArgs> _statusChangedEventHandler;
        private event EventHandler<ResizedEventArgs> _resizedEventHandler;
        private event EventHandler<LanguageChangedEventArgs> _languageChangedEventHandler;
        private event EventHandler<KeyboardTypeChangedEventArgs> _keyboardTypeChangedEventHandler;

        /// <summary>
        /// InputMethodContext activated.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandler<ActivatedEventArgs> Activated
        {
            add
            {
                if (_activatedEventHandler == null)
                {
                    _activatedEventCallback = OnActivated;
                    ActivatedSignal().Connect(_activatedEventCallback);
                }

                _activatedEventHandler += value;
            }
            remove
            {
                _activatedEventHandler -= value;

                if (_activatedEventHandler == null && _activatedEventCallback != null)
                {
                    ActivatedSignal().Disconnect(_activatedEventCallback);
                }
            }
        }

        /// <summary>
        /// InputMethodContext event received.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandlerWithReturnType<object, EventReceivedEventArgs, CallbackData> EventReceived
        {
            add
            {
                if (_eventReceivedEventHandler == null)
                {
                    _eventReceivedEventCallback = OnEventReceived;
                    EventReceivedSignal().Connect(_eventReceivedEventCallback);
                }

                _eventReceivedEventHandler += value;
            }
            remove
            {
                _eventReceivedEventHandler -= value;

                if (_eventReceivedEventHandler == null && _eventReceivedEventCallback != null)
                {
                    EventReceivedSignal().Disconnect(_eventReceivedEventCallback);
                }
            }
        }

        /// <summary>
        /// InputMethodContext status changed.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandler<StatusChangedEventArgs> StatusChanged
        {
            add
            {
                if (_statusChangedEventHandler == null)
                {
                    _statusChangedEventCallback = OnStatusChanged;
                    StatusChangedSignal().Connect(_statusChangedEventCallback);
                }

                _statusChangedEventHandler += value;
            }
            remove
            {
                _statusChangedEventHandler -= value;

                if (_statusChangedEventHandler == null && _statusChangedEventCallback != null)
                {
                    StatusChangedSignal().Disconnect(_statusChangedEventCallback);
                }
            }
        }

        /// <summary>
        /// InputMethodContext resized.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandler<ResizedEventArgs> Resized
        {
            add
            {
                if (_resizedEventHandler == null)
                {
                    _resizedEventCallback = OnResized;
                    ResizedSignal().Connect(_resizedEventCallback);
                }

                _resizedEventHandler += value;
            }
            remove
            {
                _resizedEventHandler -= value;

                if (_resizedEventHandler == null && _resizedEventCallback != null)
                {
                    ResizedSignal().Disconnect(_resizedEventCallback);
                }
            }
        }

        /// <summary>
        /// InputMethodContext language changed.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandler<LanguageChangedEventArgs> LanguageChanged
        {
            add
            {
                if (_languageChangedEventHandler == null)
                {
                    _languageChangedEventCallback = OnLanguageChanged;
                    LanguageChangedSignal().Connect(_languageChangedEventCallback);
                }

                _languageChangedEventHandler += value;
            }
            remove
            {
                _languageChangedEventHandler -= value;

                if (_languageChangedEventHandler == null && _languageChangedEventCallback != null)
                {
                    LanguageChangedSignal().Disconnect(_languageChangedEventCallback);
                }
            }
        }

        /// <summary>
        /// InputMethodContext keyboard type changed.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandler<KeyboardTypeChangedEventArgs> KeyboardTypeChanged
        {
            add
            {
                if (_keyboardTypeChangedEventHandler == null)
                {
                    _keyboardTypeChangedEventCallback = OnKeyboardTypeChanged;
                    KeyboardTypeChangedSignal().Connect(_keyboardTypeChangedEventCallback);
                }

                _keyboardTypeChangedEventHandler += value;
            }
            remove
            {
                _keyboardTypeChangedEventHandler -= value;

                if (_keyboardTypeChangedEventHandler == null && _keyboardTypeChangedEventCallback != null)
                {
                    KeyboardTypeChangedSignal().Disconnect(_keyboardTypeChangedEventCallback);
                }
            }
        }

        /// <summary>
        /// The direction of the text.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public enum TextDirection
        {
            /// <summary>
            /// Left to right.
            /// </summary>
            LeftToRight,
            /// <summary>
            /// Right to left.
            /// </summary>
            RightToLeft
        }

        /// <summary>
        /// Events that are generated by the IMF.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public enum EventType
        {
            /// <summary>
            /// No event.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            Void,
            /// <summary>
            /// Pre-edit changed.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            Preedit,
            /// <summary>
            /// Commit received.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            Commit,
            /// <summary>
            /// An event to delete a range of characters from the string.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            DeleteSurrounding,
            /// <summary>
            /// An event to query string and the cursor position.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            GetSurrounding,
            /// <summary>
            /// Private command sent from the input panel.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            PrivateCommand
        }

        /// <summary>
        /// Enumeration for the state of the input panel.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public enum State
        {
            /// <summary>
            /// Unknown state.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            Default = 0,
            /// <summary>
            /// Input panel is shown.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            Show,
            /// <summary>
            /// Input panel is hidden.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            Hide,
            /// <summary>
            /// Input panel in process of being shown.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            WillShow
        }

        /// <summary>
        /// Enumeration for the types of keyboard.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public enum KeyboardType
        {
            /// <summary>
            /// Software keyboard (virtual keyboard) is default.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            SoftwareKeyboard,
            /// <summary>
            /// Hardware keyboard.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            HardwareKeyboard
        }

        /// <summary>
        /// Gets or sets whether the IM context allows to use the text prediction.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TextPrediction
        {
            get
            {
                return IsTextPredictionAllowed();
            }
            set
            {
                AllowTextPrediction(value);
            }
        }

        /// <summary>
        /// Destroys the context of the IMF.<br/>
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void DestroyContext()
        {
            NDalicManualPINVOKE.InputMethodContext_Finalize(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Activates the IMF.<br/>
        /// It means that the text editing has started.<br/>
        /// If the hardware keyboard is not connected, then it shows the virtual keyboard.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Activate()
        {
            NDalicManualPINVOKE.InputMethodContext_Activate(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Deactivates the IMF.<br/>
        /// It means that the text editing is complete.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Deactivate()
        {
            NDalicManualPINVOKE.InputMethodContext_Deactivate(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the restoration status, which controls if the keyboard is restored after the focus is lost and then regained.<br/>
        /// If true, then the keyboard will be restored (activated) after the focus is regained.
        /// </summary>
        /// <returns>The restoration status.</returns>
        /// <since_tizen> 5 </since_tizen>
        public bool RestoreAfterFocusLost()
        {
            bool ret = NDalicManualPINVOKE.InputMethodContext_RestoreAfterFocusLost(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the status whether the IMF has to restore the keyboard after losing focus.
        /// </summary>
        /// <param name="toggle">True means that keyboard must be restored after the focus is lost and regained.</param>
        /// <since_tizen> 5 </since_tizen>
        public void SetRestoreAfterFocusLost(bool toggle)
        {
            NDalicManualPINVOKE.InputMethodContext_SetRestoreAfterFocusLost(swigCPtr, toggle);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sends a message reset to the pre-edit state or the IMF module.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public new void Reset()
        {
            NDalicManualPINVOKE.InputMethodContext_Reset(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Notifies the IMF context that the cursor position has changed, required for features such as auto-capitalization.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void NotifyCursorPosition()
        {
            NDalicManualPINVOKE.InputMethodContext_NotifyCursorPosition(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the cursor position stored in VirtualKeyboard, this is required by the IMF context.
        /// </summary>
        /// <param name="cursorPosition">The position of the cursor.</param>
        /// <since_tizen> 5 </since_tizen>
        public void SetCursorPosition(uint cursorPosition)
        {
            NDalicManualPINVOKE.InputMethodContext_SetCursorPosition(swigCPtr, cursorPosition);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the cursor position stored in VirtualKeyboard, this is required by the IMF context.
        /// </summary>
        /// <returns>The current position of the cursor.</returns>
        /// <since_tizen> 5 </since_tizen>
        public uint GetCursorPosition()
        {
            uint ret = NDalicManualPINVOKE.InputMethodContext_GetCursorPosition(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// A method to store the string required by the IMF, this is used to provide predictive word suggestions.
        /// </summary>
        /// <param name="text">The text string surrounding the current cursor point.</param>
        /// <since_tizen> 5 </since_tizen>
        public void SetSurroundingText(string text)
        {
            NDalicManualPINVOKE.InputMethodContext_SetSurroundingText(swigCPtr, text);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the current text string set within the IMF manager, this is used to offer predictive suggestions.
        /// </summary>
        /// <returns>The surrounding text.</returns>
        /// <since_tizen> 5 </since_tizen>
        public string GetSurroundingText()
        {
            string ret = NDalicManualPINVOKE.InputMethodContext_GetSurroundingText(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Notifies the IMF context that text input is set to multiline or not.
        /// </summary>
        /// <param name="multiLine">True if multiline text input is used.</param>
        /// <since_tizen> 5 </since_tizen>
        public void NotifyTextInputMultiLine(bool multiLine)
        {
            NDalicManualPINVOKE.InputMethodContext_NotifyTextInputMultiLine(swigCPtr, multiLine);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the text direction of the current input language of the keyboard.
        /// </summary>
        /// <returns>The direction of the text.</returns>
        /// <since_tizen> 5 </since_tizen>
        public InputMethodContext.TextDirection GetTextDirection()
        {
            InputMethodContext.TextDirection ret = (InputMethodContext.TextDirection)NDalicManualPINVOKE.InputMethodContext_GetTextDirection(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Provides the size and the position of the keyboard.<br/>
        /// The position is relative to whether the keyboard is visible or not.<br/>
        /// If the keyboard is not visible, then the position will be off the screen.<br/>
        /// If the keyboard is not being shown when this method is called, the keyboard is partially setup (IMFContext) to get/>
        /// the values then taken down. So ideally, GetInputMethodArea() must be called after Show().
        /// </summary>
        /// <returns>Rectangle which is keyboard panel x, y, width, and height.</returns>
        /// <since_tizen> 5 </since_tizen>
        public Rectangle GetInputMethodArea()
        {
            Rectangle ret = new Rectangle(NDalicManualPINVOKE.InputMethodContext_GetInputMethodArea(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets up the input panel specific data.
        /// </summary>
        /// <param name="text">The specific data to be set to the input panel.</param>
        /// <since_tizen> 5 </since_tizen>
        public void SetInputPanelUserData(string text)
        {
            NDalicManualPINVOKE.InputMethodContext_SetInputPanelUserData(swigCPtr, text);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the specific data of the current active input panel.
        /// </summary>
        /// <param name="text">The specific data to be received from the input panel.</param>
        /// <since_tizen> 5 </since_tizen>
        public void GetInputPanelUserData(out string text)
        {
            NDalicManualPINVOKE.InputMethodContext_GetInputPanelUserData(swigCPtr, out text);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the state of the current active input panel.
        /// </summary>
        /// <returns>The state of the input panel.</returns>
        /// <since_tizen> 5 </since_tizen>
        public InputMethodContext.State GetInputPanelState()
        {
            InputMethodContext.State ret = (InputMethodContext.State)NDalicManualPINVOKE.InputMethodContext_GetInputPanelState(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the return key on the input panel to be visible or invisible.<br/>
        /// The default value is true.
        /// </summary>
        /// <param name="visible">True if the return key is visible (enabled), false otherwise.</param>
        /// <since_tizen> 5 </since_tizen>
        public void SetReturnKeyState(bool visible)
        {
            NDalicManualPINVOKE.InputMethodContext_SetReturnKeyState(swigCPtr, visible);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Enables to show the input panel automatically when focused.
        /// </summary>
        /// <param name="enabled">If true, the input panel will be shown when focused.</param>
        /// <since_tizen> 5 </since_tizen>
        public void AutoEnableInputPanel(bool enabled)
        {
            NDalicManualPINVOKE.InputMethodContext_AutoEnableInputPanel(swigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Shows the input panel.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void ShowInputPanel()
        {
            NDalicManualPINVOKE.InputMethodContext_ShowInputPanel(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Hides the input panel.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void HideInputPanel()
        {
            NDalicManualPINVOKE.InputMethodContext_HideInputPanel(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the keyboard type.<br/>
        /// The default keyboard type is SoftwareKeyboard.
        /// </summary>
        /// <returns>The keyboard type.</returns>
        /// <since_tizen> 5 </since_tizen>
        public InputMethodContext.KeyboardType GetKeyboardType()
        {
            InputMethodContext.KeyboardType ret = (InputMethodContext.KeyboardType)NDalicManualPINVOKE.InputMethodContext_GetKeyboardType(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the current language locale of the input panel.<br/>
        /// For example, en_US, en_GB, en_PH, fr_FR, and so on.
        /// </summary>
        /// <returns>The current language locale of the input panel.</returns>
        /// <since_tizen> 5 </since_tizen>
        public string GetInputPanelLocale()
        {
            string ret = NDalicManualPINVOKE.InputMethodContext_GetInputPanelLocale(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(InputMethodContext obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
        }

        internal InputMethodContext(InputMethodContext inputMethodContext) : this(NDalicManualPINVOKE.new_InputMethodContext__SWIG_1(InputMethodContext.getCPtr(inputMethodContext)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal InputMethodContext Assign(InputMethodContext inputMethodContext)
        {
            InputMethodContext ret = new InputMethodContext(NDalicManualPINVOKE.InputMethodContext_Assign(swigCPtr, InputMethodContext.getCPtr(inputMethodContext)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static InputMethodContext DownCast(BaseHandle handle)
        {
            InputMethodContext ret = new InputMethodContext(NDalicManualPINVOKE.InputMethodContext_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void ApplyOptions(InputMethodOptions options)
        {
            NDalicManualPINVOKE.InputMethodContext_ApplyOptions(swigCPtr, InputMethodOptions.getCPtr(options));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void AllowTextPrediction(bool prediction)
        {
            NDalicManualPINVOKE.InputMethodContext_AllowTextPrediction(swigCPtr, prediction);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsTextPredictionAllowed()
        {
            bool ret = NDalicManualPINVOKE.InputMethodContext_IsTextPredictionAllowed(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ActivatedSignalType ActivatedSignal()
        {
            ActivatedSignalType ret = new ActivatedSignalType(NDalicManualPINVOKE.InputMethodContext_ActivatedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyboardEventSignalType EventReceivedSignal()
        {
            KeyboardEventSignalType ret = new KeyboardEventSignalType(NDalicManualPINVOKE.InputMethodContext_EventReceivedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal StatusSignalType StatusChangedSignal()
        {
            StatusSignalType ret = new StatusSignalType(NDalicManualPINVOKE.InputMethodContext_StatusChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyboardResizedSignalType ResizedSignal()
        {
            KeyboardResizedSignalType ret = new KeyboardResizedSignalType(NDalicManualPINVOKE.InputMethodContext_ResizedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LanguageChangedSignalType LanguageChangedSignal()
        {
            LanguageChangedSignalType ret = new LanguageChangedSignalType(NDalicManualPINVOKE.InputMethodContext_LanguageChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyboardTypeSignalType KeyboardTypeChangedSignal()
        {
            KeyboardTypeSignalType ret = new KeyboardTypeSignalType(NDalicManualPINVOKE.InputMethodContext_KeyboardTypeChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="type">Dispose Type</param>
        /// <since_tizen> 5 </since_tizen>
        /// Please DO NOT use! This will be deprecated!
        /// Dispose() method in Singletone classes (ex: FocusManager, StyleManager, VisualFactory, InputMethodContext, TtsPlayer, Window) is not required.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User.
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //Because the execution order of Finalizes is non-deterministic.

            if (_keyboardTypeChangedEventCallback != null)
            {
                KeyboardTypeChangedSignal().Disconnect(_keyboardTypeChangedEventCallback);
            }

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicManualPINVOKE.delete_InputMethodContext(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, IntPtr.Zero);
            }

            base.Dispose(type);
        }

        private void OnActivated(IntPtr data)
        {
            ActivatedEventArgs e = new ActivatedEventArgs();

            if (data != null)
            {
                e.InputMethodContext = Registry.GetManagedBaseHandleFromNativePtr(data) as InputMethodContext;
            }

            if (_activatedEventHandler != null)
            {
                _activatedEventHandler(this, e);
            }
        }

        private IntPtr OnEventReceived(IntPtr inputMethodContext, IntPtr eventData)
        {
            CallbackData callbackData = null;

            EventReceivedEventArgs e = new EventReceivedEventArgs();

            if (inputMethodContext != null)
            {
                e.InputMethodContext = Registry.GetManagedBaseHandleFromNativePtr(inputMethodContext) as InputMethodContext;
            }
            if (eventData != null)
            {
                e.EventData = EventData.GetEventDataFromPtr(eventData);
            }

            if (_eventReceivedEventHandler != null)
            {
                callbackData = _eventReceivedEventHandler(this, e);
            }
            if (callbackData != null)
            {
                return callbackData.GetCallbackDataPtr();
            }
            else
            {
                return new CallbackData().GetCallbackDataPtr();
            }
        }

        private void OnStatusChanged(bool statusChanged)
        {
            StatusChangedEventArgs e = new StatusChangedEventArgs();

            e.StatusChanged = statusChanged;

            if (_statusChangedEventHandler != null)
            {
                _statusChangedEventHandler(this, e);
            }
        }

        private void OnResized(int resized)
        {
            ResizedEventArgs e = new ResizedEventArgs();
            e.Resized = resized;

            if (_resizedEventHandler != null)
            {
                _resizedEventHandler(this, e);
            }
        }

        private void OnLanguageChanged(int languageChanged)
        {
            LanguageChangedEventArgs e = new LanguageChangedEventArgs();
            e.LanguageChanged = languageChanged;

            if (_languageChangedEventHandler != null)
            {
                _languageChangedEventHandler(this, e);
            }
        }

        private void OnKeyboardTypeChanged(KeyboardType type)
        {
            KeyboardTypeChangedEventArgs e = new KeyboardTypeChangedEventArgs();

            e.KeyboardType = type;

            if (_keyboardTypeChangedEventHandler != null)
            {
                _keyboardTypeChangedEventHandler(this, e);
            }
        }

        /// <summary>
        /// This structure is used to pass on data from the IMF regarding predictive text.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class EventData : global::System.IDisposable
        {
            /// <summary>
            /// swigCMemOwn
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            protected bool swigCMemOwn;

            /// <summary>
            /// A flag to check if it is already disposed.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            protected bool disposed = false;

            private global::System.Runtime.InteropServices.HandleRef swigCPtr;

            //A flag to check who called Dispose(). (By User or DisposeQueue)
            private bool isDisposeQueued = false;

            /// <summary>
            /// The default constructor.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public EventData() : this(NDalicManualPINVOKE.new_InputMethodContext_EventData__SWIG_0(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <summary>
            /// The constructor.
            /// </summary>
            /// <param name="aEventName">The name of the event from the IMF.</param>
            /// <param name="aPredictiveString">The pre-edit or the commit string.</param>
            /// <param name="aCursorOffset">Start the position from the current cursor position to start deleting characters.</param>
            /// <param name="aNumberOfChars">The number of characters to delete from the cursorOffset.</param>
            /// <since_tizen> 5 </since_tizen>
            public EventData(InputMethodContext.EventType aEventName, string aPredictiveString, int aCursorOffset, int aNumberOfChars) : this(NDalicManualPINVOKE.new_InputMethodContext_EventData__SWIG_1((int)aEventName, aPredictiveString, aCursorOffset, aNumberOfChars), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            internal EventData(IntPtr cPtr, bool cMemoryOwn)
            {
                swigCMemOwn = cMemoryOwn;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            }

            /// <summary>
            /// Dispose.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            ~EventData()
            {
                if (!isDisposeQueued)
                {
                    isDisposeQueued = true;
                    DisposeQueue.Instance.Add(this);
                }
            }

            /// <summary>
            /// The pre-edit or the commit string.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public string PredictiveString
            {
                set
                {
                    NDalicManualPINVOKE.InputMethodContext_EventData_predictiveString_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    string ret = NDalicManualPINVOKE.InputMethodContext_EventData_predictiveString_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// The name of the event from the IMF.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public InputMethodContext.EventType EventName
            {
                set
                {
                    NDalicManualPINVOKE.InputMethodContext_EventData_eventName_set(swigCPtr, (int)value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    InputMethodContext.EventType ret = (InputMethodContext.EventType)NDalicManualPINVOKE.InputMethodContext_EventData_eventName_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// The start position from the current cursor position to start deleting characters.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public int CursorOffset
            {
                set
                {
                    NDalicManualPINVOKE.InputMethodContext_EventData_cursorOffset_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    int ret = NDalicManualPINVOKE.InputMethodContext_EventData_cursorOffset_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// The number of characters to delete from the cursorOffset.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public int NumberOfChars
            {
                set
                {
                    NDalicManualPINVOKE.InputMethodContext_EventData_numberOfChars_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    int ret = NDalicManualPINVOKE.InputMethodContext_EventData_numberOfChars_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// The dispose pattern.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public void Dispose()
            {
                //Throw excpetion if Dispose() is called in separate thread.
                if (!Window.IsInstalled())
                {
                    throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
                }

                if (isDisposeQueued)
                {
                    Dispose(DisposeTypes.Implicit);
                }
                else
                {
                    Dispose(DisposeTypes.Explicit);
                    System.GC.SuppressFinalize(this);
                }
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(EventData obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
            }

            internal static EventData GetEventDataFromPtr(IntPtr cPtr)
            {
                EventData ret = new EventData(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }

            /// <summary>
            /// Dispose.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            protected virtual void Dispose(DisposeTypes type)
            {
                if (disposed)
                {
                    return;
                }

                if (type == DisposeTypes.Explicit)
                {
                    //Called by User.
                    //Release your own managed resources here.
                    //You should release all of your own disposable objects here.

                }

                //Release your own unmanaged resources here.
                //You should not access any managed member here except static instance.
                //because the execution order of Finalizes is non-deterministic.

                if (swigCPtr.Handle != IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        NDalicManualPINVOKE.delete_InputMethodContext_EventData(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, IntPtr.Zero);
                }

                disposed = true;
            }
        }

        /// <summary>
        /// Data required by the IMF from the callback.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class CallbackData : global::System.IDisposable
        {
            /// <summary>
            /// swigCMemOwn
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            protected bool swigCMemOwn;

            /// <summary>
            /// A Flag to check if it is already disposed.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            protected bool disposed = false;

            private global::System.Runtime.InteropServices.HandleRef swigCPtr;

            //A Flag to check who called Dispose(). (By User or DisposeQueue)
            private bool isDisposeQueued = false;

            /// <summary>
            /// The default constructor.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public CallbackData() : this(NDalicManualPINVOKE.new_InputMethodContext_CallbackData__SWIG_0(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <summary>
            /// The constructor.
            /// </summary>
            /// <param name="aUpdate">True if the cursor position needs to be updated.</param>
            /// <param name="aCursorPosition">The new position of the cursor.</param>
            /// <param name="aCurrentText">The current text string.</param>
            /// <param name="aPreeditResetRequired">Flag if preedit reset is required.</param>
            /// <since_tizen> 5 </since_tizen>
            public CallbackData(bool aUpdate, int aCursorPosition, string aCurrentText, bool aPreeditResetRequired) : this(NDalicManualPINVOKE.new_InputMethodContext_CallbackData__SWIG_1(aUpdate, aCursorPosition, aCurrentText, aPreeditResetRequired), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <summary>
            /// Dispose.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            ~CallbackData()
            {
                if (!isDisposeQueued)
                {
                    isDisposeQueued = true;
                    DisposeQueue.Instance.Add(this);
                }
            }

            /// <summary>
            /// The current text string.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public string CurrentText
            {
                set
                {
                    NDalicManualPINVOKE.InputMethodContext_CallbackData_currentText_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    string ret = NDalicManualPINVOKE.InputMethodContext_CallbackData_currentText_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// The current cursor position.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public int CursorPosition
            {
                set
                {
                    NDalicManualPINVOKE.InputMethodContext_CallbackData_cursorPosition_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    int ret = NDalicManualPINVOKE.InputMethodContext_CallbackData_cursorPosition_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// If the cursor position needs to be updated.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public bool Update
            {
                set
                {
                    NDalicManualPINVOKE.InputMethodContext_CallbackData_update_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    bool ret = NDalicManualPINVOKE.InputMethodContext_CallbackData_update_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// Flags if the pre-edit reset is required.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public bool PreeditResetRequired
            {
                set
                {
                    NDalicManualPINVOKE.InputMethodContext_CallbackData_preeditResetRequired_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    bool ret = NDalicManualPINVOKE.InputMethodContext_CallbackData_preeditResetRequired_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// The dispose pattern.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public void Dispose()
            {
                //Throw excpetion if Dispose() is called in separate thread.
                if (!Window.IsInstalled())
                {
                    throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
                }

                if (isDisposeQueued)
                {
                    Dispose(DisposeTypes.Implicit);
                }
                else
                {
                    Dispose(DisposeTypes.Explicit);
                    System.GC.SuppressFinalize(this);
                }
            }

            internal IntPtr GetCallbackDataPtr()
            {
                return (IntPtr)swigCPtr;
            }

            internal CallbackData(IntPtr cPtr, bool cMemoryOwn)
            {
                swigCMemOwn = cMemoryOwn;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CallbackData obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
            }

            internal static CallbackData GetCallbackDataFromPtr(IntPtr cPtr)
            {
                CallbackData ret = new CallbackData(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }

            /// <summary>
            /// Dispose.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            protected virtual void Dispose(DisposeTypes type)
            {
                if (disposed)
                {
                    return;
                }

                if (type == DisposeTypes.Explicit)
                {
                    //Called by User.
                    //Release your own managed resources here.
                    //You should release all of your own disposable objects here.

                }

                //Release your own unmanaged resources here.
                //You should not access any managed member here except static instance.
                //Because the execution order of Finalizes is non-deterministic.

                if (swigCPtr.Handle != IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        NDalicManualPINVOKE.delete_InputMethodContext_CallbackData(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, IntPtr.Zero);
                }

                disposed = true;
            }
        }

        /// <summary>
        /// InputMethodContext activated event arguments.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class ActivatedEventArgs : EventArgs
        {
            /// <summary>
            /// InputMethodContext
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public InputMethodContext InputMethodContext
            {
                get;
                set;
            }
        }

        /// <summary>
        /// InputMethodContext event receives event arguments.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class EventReceivedEventArgs : EventArgs
        {
            /// <summary>
            /// InputMethodContext
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public InputMethodContext InputMethodContext
            {
                get;
                set;
            }

            /// <summary>
            /// EventData.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public EventData EventData
            {
                get;
                set;
            }
        }

        /// <summary>
        /// InputMethodContext status changed event arguments.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class StatusChangedEventArgs : EventArgs
        {
            /// <summary>
            /// InputMethodContext status.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public bool StatusChanged
            {
                get;
                set;
            }
        }

        /// <summary>
        /// InputMethodContext resized event arguments.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class ResizedEventArgs : EventArgs
        {
            /// <summary>
            /// resized.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public int Resized
            {
                get;
                set;
            }
        }

        /// <summary>
        /// InputMethodContext language changed event arguments.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class LanguageChangedEventArgs : EventArgs
        {
            /// <summary>
            /// Language changed.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public int LanguageChanged
            {
                get;
                set;
            }
        }

        /// <summary>
        /// InputMethodContext keyboard type changed event arguments.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class KeyboardTypeChangedEventArgs : EventArgs
        {
            /// <summary>
            /// InputMethodContext keyboard type.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public KeyboardType KeyboardType
            {
                get;
                set;
            }
        }
    }
}

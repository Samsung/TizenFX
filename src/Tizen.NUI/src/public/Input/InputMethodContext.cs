/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
        private ActivatedEventCallbackType activatedEventCallback;
        private EventReceivedEventCallbackType eventReceivedEventCallback;
        private StatusChangedEventCallbackType statusChangedEventCallback;
        private ResizedEventCallbackType resizedEventCallback;
        private LanguageChangedEventCallbackType languageChangedEventCallback;
        private KeyboardTypeChangedEventCallbackType keyboardTypeChangedEventCallback;
        private ContentReceivedCallbackType contentReceivedEventCallback;

        /// <summary>
        /// Constructor.<br/>
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public InputMethodContext() : this(Interop.InputMethodContext.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal InputMethodContext(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void ActivatedEventCallbackType(IntPtr data);
        private delegate IntPtr EventReceivedEventCallbackType(IntPtr inputMethodContext, IntPtr eventData);
        private delegate void StatusChangedEventCallbackType(bool statusChanged);
        private delegate void ResizedEventCallbackType(int resized);
        private delegate void LanguageChangedEventCallbackType(int languageChanged);
        private delegate void KeyboardTypeChangedEventCallbackType(KeyboardType type);
        private delegate void ContentReceivedCallbackType(string content, string description, string mimeType);

        private event EventHandler<ActivatedEventArgs> activatedEventHandler;
        private event EventHandlerWithReturnType<object, EventReceivedEventArgs, CallbackData> eventReceivedEventHandler;
        private event EventHandler<StatusChangedEventArgs> statusChangedEventHandler;
        private event EventHandler<ResizedEventArgs> resizedEventHandler;
        private event EventHandler<LanguageChangedEventArgs> languageChangedEventHandler;
        private event EventHandler<KeyboardTypeChangedEventArgs> keyboardTypeChangedEventHandler;
        private event EventHandler<ContentReceivedEventArgs> contentReceivedEventHandler;

        /// <summary>
        /// Event handler for the activation of the InputMethodContext.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandler<ActivatedEventArgs> Activated
        {
            add
            {
                if (activatedEventHandler == null)
                {
                    CreateSafeCallback(OnActivated, out activatedEventCallback);
                    ActivatedSignal().Connect(activatedEventCallback);
                }

                activatedEventHandler += value;
            }
            remove
            {
                activatedEventHandler -= value;

                if (activatedEventHandler == null && activatedEventCallback != null)
                {
                    ActivatedSignal().Disconnect(activatedEventCallback);
                    ReleaseSafeCallback(ref activatedEventCallback);
                }
            }
        }

        /// <summary>
        /// This event handler is used to receive events related to the InputMethodContext.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandlerWithReturnType<object, EventReceivedEventArgs, CallbackData> EventReceived
        {
            add
            {
                if (eventReceivedEventHandler == null)
                {
                    CreateSafeCallback(OnEventReceived, out eventReceivedEventCallback);
                    EventReceivedSignal().Connect(eventReceivedEventCallback);
                }

                eventReceivedEventHandler += value;
            }
            remove
            {
                eventReceivedEventHandler -= value;

                if (eventReceivedEventHandler == null && eventReceivedEventCallback != null)
                {
                    EventReceivedSignal().Disconnect(eventReceivedEventCallback);
                    ReleaseSafeCallback(ref eventReceivedEventCallback);
                }
            }
        }

        /// <summary>
        /// The StatusChanged event is triggered when the input method context status changes.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandler<StatusChangedEventArgs> StatusChanged
        {
            add
            {
                if (statusChangedEventHandler == null)
                {
                    CreateSafeCallback(OnStatusChanged, out statusChangedEventCallback);
                    StatusChangedSignal().Connect(statusChangedEventCallback);
                }

                statusChangedEventHandler += value;
            }
            remove
            {
                statusChangedEventHandler -= value;

                if (statusChangedEventHandler == null && statusChangedEventCallback != null)
                {
                    StatusChangedSignal().Disconnect(statusChangedEventCallback);
                    ReleaseSafeCallback(ref statusChangedEventCallback);
                }
            }
        }

        /// <summary>
        /// Event handler for the InputMethodContext resized event.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandler<ResizedEventArgs> Resized
        {
            add
            {
                if (resizedEventHandler == null)
                {
                    CreateSafeCallback(OnResized, out resizedEventCallback);
                    ResizedSignal().Connect(resizedEventCallback);
                }

                resizedEventHandler += value;
            }
            remove
            {
                resizedEventHandler -= value;

                if (resizedEventHandler == null && resizedEventCallback != null)
                {
                    ResizedSignal().Disconnect(resizedEventCallback);
                    ReleaseSafeCallback(ref resizedEventCallback);
                }
            }
        }

        /// <summary>
        /// This event is triggered when the language of the InputMethodContext changes.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandler<LanguageChangedEventArgs> LanguageChanged
        {
            add
            {
                if (languageChangedEventHandler == null)
                {
                    CreateSafeCallback(OnLanguageChanged, out languageChangedEventCallback);
                    LanguageChangedSignal().Connect(languageChangedEventCallback);
                }

                languageChangedEventHandler += value;
            }
            remove
            {
                languageChangedEventHandler -= value;

                if (languageChangedEventHandler == null && languageChangedEventCallback != null)
                {
                    LanguageChangedSignal().Disconnect(languageChangedEventCallback);
                    ReleaseSafeCallback(ref languageChangedEventCallback);
                }
            }
        }

        /// <summary>
        /// Event handler for InputMethodContext keyboard type changed.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandler<KeyboardTypeChangedEventArgs> KeyboardTypeChanged
        {
            add
            {
                if (keyboardTypeChangedEventHandler == null)
                {
                    CreateSafeCallback(OnKeyboardTypeChanged, out keyboardTypeChangedEventCallback);
                    KeyboardTypeChangedSignal().Connect(keyboardTypeChangedEventCallback);
                }

                keyboardTypeChangedEventHandler += value;
            }
            remove
            {
                keyboardTypeChangedEventHandler -= value;

                if (keyboardTypeChangedEventHandler == null && keyboardTypeChangedEventCallback != null)
                {
                    KeyboardTypeChangedSignal().Disconnect(keyboardTypeChangedEventCallback);
                    ReleaseSafeCallback(ref keyboardTypeChangedEventCallback);
                }
            }
        }

        /// <summary>
        /// InputMethodContext content received.
        /// </summary>
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ContentReceivedEventArgs> ContentReceived
        {
            add
            {
                if (contentReceivedEventHandler == null)
                {
                    CreateSafeCallback(OnContentReceived, out contentReceivedEventCallback);
                    ContentReceivedSignal().Connect(contentReceivedEventCallback);
                }

                contentReceivedEventHandler += value;
            }
            remove
            {
                contentReceivedEventHandler -= value;

                if (contentReceivedEventHandler == null && contentReceivedEventCallback != null)
                {
                    ContentReceivedSignal().Disconnect(contentReceivedEventCallback);
                    ReleaseSafeCallback(ref contentReceivedEventCallback);
                }
            }
        }

        /// <summary>
        /// Enumeration for the direction of the text.
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
        /// Enumeration for the events that are generated by the IMF.
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
        /// Enumeration for the language mode of the input panel.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public enum InputPanelLanguage
        {
            /// <summary>
            /// IME Language is automatically set depending on the system display.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            Automatic,
            /// <summary>
            /// Latin alphabet. (default)
            /// This value can be changed according to OSD(On Screen Display) language.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            Alphabet
        }

        /// <summary>
        /// Enumeration for align of the input panel.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum InputPanelAlign
        {
            /// <summary>
            /// The top-left corner.
            /// </summary>
            TopLeft,
            /// <summary>
            /// The top-center position.
            /// </summary>
            TopCenter,
            /// <summary>
            /// The top-right corner.
            /// </summary>
            TopRight,
            /// <summary>
            /// The middle-left position.
            /// </summary>
            MiddleLeft,
            /// <summary>
            /// The middle-center position.
            /// </summary>
            MiddleCenter,
            /// <summary>
            /// The middle-right position.
            /// </summary>
            MiddleRight,
            /// <summary>
            /// The bottom-left corner.
            /// </summary>
            BottomLeft,
            /// <summary>
            /// The bottom-center position.
            /// </summary>
            BottomCenter,
            /// <summary>
            /// The bottom-right corner.
            /// </summary>
            BottomRight
        }

        /// <summary>
        /// Gets or sets whether the IM context allows to use the text prediction.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
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
        /// Gets or sets whether the input panel should be shown in fullscreen mode.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FullScreenMode
        {
            get
            {
                return IsFullScreenMode();
            }
            set
            {
                SetFullScreenMode(value);
            }
        }

        /// <summary>
        /// Destroys the context of the IMF.<br/>
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void DestroyContext()
        {
            Interop.InputMethodContext.Finalize(SwigCPtr);
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
            Interop.InputMethodContext.Activate(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Deactivates the IMF.<br/>
        /// It means that the text editing is complete.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Deactivate()
        {
            Interop.InputMethodContext.Deactivate(SwigCPtr);
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
            bool ret = Interop.InputMethodContext.RestoreAfterFocusLost(SwigCPtr);
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
            Interop.InputMethodContext.SetRestoreAfterFocusLost(SwigCPtr, toggle);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sends a message reset to the pre-edit state or the IMF module.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public new void Reset()
        {
            Interop.InputMethodContext.Reset(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Notifies the IMF context that the cursor position has changed, required for features such as auto-capitalization.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void NotifyCursorPosition()
        {
            Interop.InputMethodContext.NotifyCursorPosition(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the cursor position stored in VirtualKeyboard, this is required by the IMF context.
        /// </summary>
        /// <param name="cursorPosition">The position of the cursor.</param>
        /// <since_tizen> 5 </since_tizen>
        public void SetCursorPosition(uint cursorPosition)
        {
            Interop.InputMethodContext.SetCursorPosition(SwigCPtr, cursorPosition);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the cursor position stored in VirtualKeyboard, this is required by the IMF context.
        /// </summary>
        /// <returns>The current position of the cursor.</returns>
        /// <since_tizen> 5 </since_tizen>
        public uint GetCursorPosition()
        {
            uint ret = Interop.InputMethodContext.GetCursorPosition(SwigCPtr);
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
            Interop.InputMethodContext.SetSurroundingText(SwigCPtr, text);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the current text string set within the IMF manager, this is used to offer predictive suggestions.
        /// </summary>
        /// <returns>The surrounding text.</returns>
        /// <since_tizen> 5 </since_tizen>
        public string GetSurroundingText()
        {
            string ret = Interop.InputMethodContext.GetSurroundingText(SwigCPtr);
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
            Interop.InputMethodContext.NotifyTextInputMultiLine(SwigCPtr, multiLine);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the text direction of the current input language of the keyboard.
        /// </summary>
        /// <returns>The direction of the text.</returns>
        /// <since_tizen> 5 </since_tizen>
        public InputMethodContext.TextDirection GetTextDirection()
        {
            InputMethodContext.TextDirection ret = (InputMethodContext.TextDirection)Interop.InputMethodContext.GetTextDirection(SwigCPtr);
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
            Rectangle ret = new Rectangle(Interop.InputMethodContext.GetInputMethodArea(SwigCPtr), true);
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
            Interop.InputMethodContext.SetInputPanelUserData(SwigCPtr, text);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the specific data of the current active input panel.
        /// </summary>
        /// <param name="text">The specific data to be received from the input panel.</param>
        /// <since_tizen> 5 </since_tizen>
        public void GetInputPanelUserData(out string text)
        {
            Interop.InputMethodContext.GetInputPanelUserData(SwigCPtr, out text);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the state of the current active input panel.
        /// </summary>
        /// <returns>The state of the input panel.</returns>
        /// <since_tizen> 5 </since_tizen>
        public InputMethodContext.State GetInputPanelState()
        {
            InputMethodContext.State ret = (InputMethodContext.State)Interop.InputMethodContext.GetInputPanelState(SwigCPtr);
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
            Interop.InputMethodContext.SetReturnKeyState(SwigCPtr, visible);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Enables to show the input panel automatically when focused.
        /// </summary>
        /// <param name="enabled">If true, the input panel will be shown when focused.</param>
        /// <since_tizen> 5 </since_tizen>
        public void AutoEnableInputPanel(bool enabled)
        {
            Interop.InputMethodContext.AutoEnableInputPanel(SwigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Shows the input panel.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void ShowInputPanel()
        {
            Interop.InputMethodContext.ShowInputPanel(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Hides the input panel.
        /// This method hides the on-screen keyboard or input panel associated with the current InputMethodContext instance.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void HideInputPanel()
        {
            Interop.InputMethodContext.HideInputPanel(SwigCPtr);
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
            InputMethodContext.KeyboardType ret = (InputMethodContext.KeyboardType)Interop.InputMethodContext.GetKeyboardType(SwigCPtr);
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
            string ret = Interop.InputMethodContext.GetInputPanelLocale(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the allowed MIME Type to deliver to the input panel. <br/>
        /// For example, string mimeType = "text/plain,image/png,image/gif,application/pdf";
        /// </summary>
        /// <param name="mimeType">The allowed MIME type.</param>
        /// <since_tizen> 8 </since_tizen>
        public void SetMIMEType(string mimeType)
        {
            Interop.InputMethodContext.SetMIMEType(SwigCPtr, mimeType);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the x,y coordinates of the input panel.
        /// </summary>
        /// <param name="x">The top-left x coordinate of the input panel.</param>
        /// <param name="y">The top-left y coordinate of the input panel.</param>
        /// <since_tizen> 8 </since_tizen>
        public void SetInputPanelPosition(uint x, uint y)
        {
            Interop.InputMethodContext.SetInputPanelPosition(SwigCPtr, x, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the alignment and its x,y coordinates of the input panel.<br/>
        /// Regardless of the rotation degree, the x, y values of the top-left corner on the screen are based on 0, 0.<br/>
        /// When the IME size is changed, its size will change according to the set alignment.
        /// </summary>
        /// <remarks>
        /// This API can be used to set the alignment of a floating IME.
        /// </remarks>
        /// <param name="x">The x coordinate of the InputPanelAlign value.</param>
        /// <param name="y">The y coordinate of the InputPanelAlign value.</param>
        /// <param name="align">one of the InputPanelAlign values specifying the desired alignment.</param>
        /// <returns>True on success, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SetInputPanelPositionAlign(int x, int y, InputMethodContext.InputPanelAlign align)
        {
            bool ret = Interop.InputMethodContext.SetInputPanelPositionAlign(SwigCPtr, x, y, (int)align);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the language of the input panel.
        /// </summary>
        /// <param name="language">The language to be set to the input panel</param>
        /// <since_tizen> 8 </since_tizen>
        public void SetInputPanelLanguage(InputMethodContext.InputPanelLanguage language)
        {
            Interop.InputMethodContext.SetInputPanelLanguage(SwigCPtr, (int)language);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the language of the input panel.
        /// </summary>
        /// <returns>The language of the input panel</returns>
        /// <since_tizen> 8 </since_tizen>
        public InputMethodContext.InputPanelLanguage GetInputPanelLanguage()
        {
            InputMethodContext.InputPanelLanguage ret = (InputMethodContext.InputPanelLanguage)Interop.InputMethodContext.GetInputPanelLanguage(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(InputMethodContext obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, IntPtr.Zero) : obj.SwigCPtr;
        }

        internal InputMethodContext(InputMethodContext inputMethodContext) : this(Interop.InputMethodContext.NewInputMethodContext(InputMethodContext.getCPtr(inputMethodContext)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal InputMethodContext Assign(InputMethodContext inputMethodContext)
        {
            InputMethodContext ret = new InputMethodContext(Interop.InputMethodContext.Assign(SwigCPtr, InputMethodContext.getCPtr(inputMethodContext)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static InputMethodContext DownCast(BaseHandle handle)
        {
            InputMethodContext ret = new InputMethodContext(Interop.InputMethodContext.DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void AllowTextPrediction(bool prediction)
        {
            Interop.InputMethodContext.AllowTextPrediction(SwigCPtr, prediction);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsTextPredictionAllowed()
        {
            bool ret = Interop.InputMethodContext.IsTextPredictionAllowed(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFullScreenMode(bool fullScreen)
        {
            Interop.InputMethodContext.SetFullScreenMode(SwigCPtr, fullScreen);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsFullScreenMode()
        {
            bool ret = Interop.InputMethodContext.IsFullScreenMode(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ActivatedSignalType ActivatedSignal()
        {
            ActivatedSignalType ret = new ActivatedSignalType(Interop.InputMethodContext.ActivatedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyboardEventSignalType EventReceivedSignal()
        {
            KeyboardEventSignalType ret = new KeyboardEventSignalType(Interop.InputMethodContext.EventReceivedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal StatusSignalType StatusChangedSignal()
        {
            StatusSignalType ret = new StatusSignalType(Interop.InputMethodContext.StatusChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyboardResizedSignalType ResizedSignal()
        {
            KeyboardResizedSignalType ret = new KeyboardResizedSignalType(Interop.InputMethodContext.ResizedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LanguageChangedSignalType LanguageChangedSignal()
        {
            LanguageChangedSignalType ret = new LanguageChangedSignalType(Interop.InputMethodContext.LanguageChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyboardTypeSignalType KeyboardTypeChangedSignal()
        {
            KeyboardTypeSignalType ret = new KeyboardTypeSignalType(Interop.InputMethodContext.KeyboardTypeChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ContentReceivedSignalType ContentReceivedSignal()
        {
            ContentReceivedSignalType ret = new ContentReceivedSignalType(Interop.InputMethodContext.ContentReceivedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// You can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">Dispose Type</param>
        /// <since_tizen> 5 </since_tizen>
        /// Do not use! This will be deprecated!
        /// Dispose() method in Singletone classes (ex: FocusManager, StyleManager, VisualFactory, InputMethodContext, TtsPlayer, Window) is not required.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance
            //because the execution order of Finalizes is non-deterministic.

            if (type == DisposeTypes.Explicit)
            {
                DisconnectNativeSignals();
            }

            base.Dispose(type);
        }

        private void DisconnectNativeSignals()
        {
            if (HasBody() == false)
            {
                NUILog.Debug($"[Dispose] DisConnectFromSignals() No native body! No need to Disconnect Signals!");
                return;
            }

            if (activatedEventCallback != null)
            {
                ActivatedSignal().Disconnect(activatedEventCallback);
                activatedEventCallback = null;
            }

            if (eventReceivedEventCallback != null)
            {
                EventReceivedSignal().Disconnect(eventReceivedEventCallback);
                eventReceivedEventCallback = null;
            }

            if (statusChangedEventCallback != null)
            {
                StatusChangedSignal().Disconnect(statusChangedEventCallback);
                statusChangedEventCallback = null;
            }

            if (resizedEventCallback != null)
            {
                ResizedSignal().Disconnect(resizedEventCallback);
                resizedEventCallback = null;
            }

            if (languageChangedEventCallback != null)
            {
                LanguageChangedSignal().Disconnect(languageChangedEventCallback);
                languageChangedEventCallback = null;
            }

            if (keyboardTypeChangedEventCallback != null)
            {
                KeyboardTypeChangedSignal().Disconnect(keyboardTypeChangedEventCallback);
                keyboardTypeChangedEventCallback = null;
            }

            if (contentReceivedEventCallback != null)
            {
                ContentReceivedSignal().Disconnect(contentReceivedEventCallback);
                contentReceivedEventCallback = null;
            }
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.InputMethodContext.DeleteInputMethodContext(swigCPtr);
        }

        private void OnActivated(IntPtr data)
        {
            if (Disposed || IsDisposeQueued)
            {
                // Ignore native callback if InputMethodContext is disposed or queued for disposal.
                return;
            }

            ActivatedEventArgs e = new ActivatedEventArgs();

            if (data != IntPtr.Zero)
            {
                e.InputMethodContext = Registry.GetManagedBaseHandleFromNativePtr(data) as InputMethodContext;
            }

            if (activatedEventHandler != null)
            {
                activatedEventHandler(this, e);
            }
        }

        private IntPtr OnEventReceived(IntPtr inputMethodContext, IntPtr eventData)
        {
            if (Disposed || IsDisposeQueued)
            {
                // Ignore native callback if InputMethodContext is disposed or queued for disposal.
                return IntPtr.Zero;
            }

            CallbackData callbackData = null;

            EventReceivedEventArgs e = new EventReceivedEventArgs();

            if (inputMethodContext != IntPtr.Zero)
            {
                e.InputMethodContext = Registry.GetManagedBaseHandleFromNativePtr(inputMethodContext) as InputMethodContext;
            }
            if (eventData != IntPtr.Zero)
            {
                e.EventData = EventData.GetEventDataFromPtr(eventData);
            }

            if (eventReceivedEventHandler != null)
            {
                callbackData = eventReceivedEventHandler(this, e);
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
            if (Disposed || IsDisposeQueued)
            {
                // Ignore native callback if InputMethodContext is disposed or queued for disposal.
                return;
            }

            StatusChangedEventArgs e = new StatusChangedEventArgs();

            e.StatusChanged = statusChanged;

            if (statusChangedEventHandler != null)
            {
                statusChangedEventHandler(this, e);
            }
        }

        private void OnResized(int resized)
        {
            if (Disposed || IsDisposeQueued)
            {
                // Ignore native callback if InputMethodContext is disposed or queued for disposal.
                return;
            }

            ResizedEventArgs e = new ResizedEventArgs();
            e.Resized = resized;

            if (resizedEventHandler != null)
            {
                resizedEventHandler(this, e);
            }
        }

        private void OnLanguageChanged(int languageChanged)
        {
            if (Disposed || IsDisposeQueued)
            {
                // Ignore native callback if InputMethodContext is disposed or queued for disposal.
                return;
            }

            LanguageChangedEventArgs e = new LanguageChangedEventArgs();
            e.LanguageChanged = languageChanged;

            if (languageChangedEventHandler != null)
            {
                languageChangedEventHandler(this, e);
            }
        }

        private void OnKeyboardTypeChanged(KeyboardType type)
        {
            if (Disposed || IsDisposeQueued)
            {
                // Ignore native callback if InputMethodContext is disposed or queued for disposal.
                return;
            }

            KeyboardTypeChangedEventArgs e = new KeyboardTypeChangedEventArgs();

            e.KeyboardType = type;

            if (keyboardTypeChangedEventHandler != null)
            {
                keyboardTypeChangedEventHandler(this, e);
            }
        }

        private void OnContentReceived(string content, string description, string mimeType)
        {
            if (Disposed || IsDisposeQueued)
            {
                // Ignore native callback if InputMethodContext is disposed or queued for disposal.
                return;
            }

            ContentReceivedEventArgs e = new ContentReceivedEventArgs();
            e.Content = content;
            e.Description = description;
            e.MimeType = mimeType;

            if (contentReceivedEventHandler != null)
            {
                contentReceivedEventHandler(this, e);
            }
        }

        void CreateSafeCallback<T>(T method, out T safeCallback) where T : Delegate
        {
            AddToNativeHolder(method);
            safeCallback = method;
        }

        void ReleaseSafeCallback<T>(ref T safeCallback) where T : Delegate
        {
            System.Diagnostics.Debug.Assert(safeCallback != null);
            // FIXME: If eventReceivedEventCallback is removed from nativeholder,
            //        then it is called from unmanaged code although it is disconnected.
            //        So the callbacks are not removed from nativeholder until dispose.
            // RemoveFromNativeHolder(safeCallback);
            safeCallback = null;
        }

        /// <summary>
        /// This structure is used to pass on data from the IMF regarding predictive text.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class EventData : Disposable
        {
            /// <summary>
            /// The state if it owns memory
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            [Obsolete("This has been deprecated in API9 and will be removed in API11. Use swigCMemOwn that is declared in the parent class")]
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "<Pending>")]
            protected bool swigCMemOwn;
            private global::System.Runtime.InteropServices.HandleRef swigCPtr;

            /// <summary>
            /// The default constructor of EventData class.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public EventData() : this(Interop.InputMethodContext.NewInputMethodContextEventData(), true)
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
            public EventData(InputMethodContext.EventType aEventName, string aPredictiveString, int aCursorOffset, int aNumberOfChars) : this(Interop.InputMethodContext.NewInputMethodContextEventData((int)aEventName, aPredictiveString, aCursorOffset, aNumberOfChars), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            internal EventData(IntPtr cPtr, bool cMemoryOwn)
            {
                swigCMemOwn = cMemoryOwn;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            }

            /// <summary>
            /// The pre-edit or the commit string.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public string PredictiveString
            {
                set
                {
                    Interop.InputMethodContext.EventDataPredictiveStringSet(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    string ret = Interop.InputMethodContext.EventDataPredictiveStringGet(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                    Interop.InputMethodContext.EventDataEventNameSet(swigCPtr, (int)value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    InputMethodContext.EventType ret = (InputMethodContext.EventType)Interop.InputMethodContext.EventDataEventNameGet(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                    Interop.InputMethodContext.EventDataCursorOffsetSet(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    int ret = Interop.InputMethodContext.EventDataCursorOffsetGet(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                    Interop.InputMethodContext.EventDataNumberOfCharsSet(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    int ret = Interop.InputMethodContext.EventDataNumberOfCharsGet(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                    return ret;
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
            /// You can override it to clean-up your own resources.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            protected override void Dispose(DisposeTypes type)
            {
                if (disposed)
                {
                    return;
                }

                //Release your own unmanaged resources here.
                //You should not access any managed member here except static instance.
                //because the execution order of Finalizes is non-deterministic.

                if (swigCPtr.Handle != IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        Interop.InputMethodContext.DeleteInputMethodContextEventData(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, IntPtr.Zero);
                }

                base.Dispose(type);
            }
        }

        /// <summary>
        /// Data required by the IMF from the callback.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class CallbackData : Disposable
        {
            /// <summary>
            /// The state if it owns memory
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            [Obsolete("This has been deprecated in API9 and will be removed in API11. Use SwigCMemOwn that is declared in the parent class")]
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "<Pending>")]
            protected bool swigCMemOwn;
            private global::System.Runtime.InteropServices.HandleRef swigCPtr;

            /// <summary>
            /// The default constructor of CallbackData class.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public CallbackData() : this(Interop.InputMethodContext.NewInputMethodContextCallbackData(), true)
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
            public CallbackData(bool aUpdate, int aCursorPosition, string aCurrentText, bool aPreeditResetRequired) : this(Interop.InputMethodContext.NewInputMethodContextCallbackData(aUpdate, aCursorPosition, aCurrentText, aPreeditResetRequired), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <summary>
            /// The current text string.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public string CurrentText
            {
                set
                {
                    Interop.InputMethodContext.CallbackDataCurrentTextSet(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    string ret = Interop.InputMethodContext.CallbackDataCurrentTextGet(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                    Interop.InputMethodContext.CallbackDataCursorPositionSet(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    int ret = Interop.InputMethodContext.CallbackDataCursorPositionGet(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                    return ret;
                }
            }

            /// <summary>
            /// The state if the cursor position needs to be updated.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public bool Update
            {
                set
                {
                    Interop.InputMethodContext.CallbackDataUpdateSet(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    bool ret = Interop.InputMethodContext.CallbackDataUpdateGet(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                    Interop.InputMethodContext.CallbackDataPreeditResetRequiredSet(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    bool ret = Interop.InputMethodContext.CallbackDataPreeditResetRequiredGet(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                    return ret;
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

            internal static CallbackData GetCallbackDataFromPtr(IntPtr cPtr)
            {
                CallbackData ret = new CallbackData(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }

            /// <summary>
            /// You can override it to clean-up your own resources.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            protected override void Dispose(DisposeTypes type)
            {
                if (disposed)
                {
                    return;
                }

                //Release your own unmanaged resources here.
                //You should not access any managed member here except static instance.
                //Because the execution order of Finalizes is non-deterministic.

                if (swigCPtr.Handle != IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        Interop.InputMethodContext.DeleteInputMethodContextCallbackData(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, IntPtr.Zero);
                }

                base.Dispose(type);
            }
        }

        /// <summary>
        /// InputMethodContext activated event arguments.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class ActivatedEventArgs : EventArgs
        {
            /// <summary>
            /// The instance of InputMethodContext
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
            /// The instance of InputMethodContext
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public InputMethodContext InputMethodContext
            {
                get;
                set;
            }

            /// <summary>
            /// The event data of IMF
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
            /// The state if the IMF resized.
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

        /// <summary>
        /// InputMethodContext content received event arguments.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ContentReceivedEventArgs : EventArgs
        {
            /// <summary>
            /// The content, such as images, of input method
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string Content
            {
                get;
                set;
            }
            /// <summary>
            /// The description of content
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string Description
            {
                get;
                set;
            }
            /// <summary>
            /// The mime type of content, such as jpg, png, and so on
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string MimeType
            {
                get;
                set;
            }
        }
    }
}

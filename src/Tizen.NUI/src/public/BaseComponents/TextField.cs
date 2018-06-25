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
extern alias TizenSystemSettings;
using TizenSystemSettings.Tizen.System;

using System;
using System.Runtime.InteropServices;
using System.Globalization;
using System.ComponentModel;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// A control which provides a single line editable text field.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class TextField : View
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private string textFieldTextSid = null;
        private string textFieldPlaceHolderTextSid = null;
        private bool systemlangTextFlag = false;

        internal TextField(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.TextField_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TextField obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                DisposeQueue.Instance.Add(this);
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            if (this != null)
            {
                if (_textFieldMaxLengthReachedCallbackDelegate != null)
                {
                    this.MaxLengthReachedSignal().Disconnect(_textFieldMaxLengthReachedCallbackDelegate);
                }

                if (_textFieldTextChangedCallbackDelegate != null)
                {
                    TextChangedSignal().Disconnect(_textFieldTextChangedCallbackDelegate);
                }
            }

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_TextField(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// The TextChanged event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class TextChangedEventArgs : EventArgs
        {
            private TextField _textField;

            /// <summary>
            /// TextField.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public TextField TextField
            {
                get
                {
                    return _textField;
                }
                set
                {
                    _textField = value;
                }
            }
        }

        /// <summary>
        /// The MaxLengthReached event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class MaxLengthReachedEventArgs : EventArgs
        {
            private TextField _textField;

            /// <summary>
            /// TextField.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public TextField TextField
            {
                get
                {
                    return _textField;
                }
                set
                {
                    _textField = value;
                }
            }
        }


        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void TextChangedCallbackDelegate(IntPtr textField);
        private EventHandler<TextChangedEventArgs> _textFieldTextChangedEventHandler;
        private TextChangedCallbackDelegate _textFieldTextChangedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void MaxLengthReachedCallbackDelegate(IntPtr textField);
        private EventHandler<MaxLengthReachedEventArgs> _textFieldMaxLengthReachedEventHandler;
        private MaxLengthReachedCallbackDelegate _textFieldMaxLengthReachedCallbackDelegate;

        /// <summary>
        /// The TextChanged event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<TextChangedEventArgs> TextChanged
        {
            add
            {
                if (_textFieldTextChangedEventHandler == null)
                {
                    _textFieldTextChangedCallbackDelegate = (OnTextChanged);
                    TextChangedSignal().Connect(_textFieldTextChangedCallbackDelegate);
                }
                _textFieldTextChangedEventHandler += value;
            }
            remove
            {
                _textFieldTextChangedEventHandler -= value;
                if (_textFieldTextChangedEventHandler == null && TextChangedSignal().Empty() == false)
                {
                    TextChangedSignal().Disconnect(_textFieldTextChangedCallbackDelegate);
                }
            }
        }

        private void OnTextChanged(IntPtr textField)
        {
            TextChangedEventArgs e = new TextChangedEventArgs();

            // Populate all members of "e" (TextChangedEventArgs) with real data
            e.TextField = Registry.GetManagedBaseHandleFromNativePtr(textField) as TextField;

            if (_textFieldTextChangedEventHandler != null)
            {
                //here we send all data to user event handlers
                _textFieldTextChangedEventHandler(this, e);
            }

        }

        /// <summary>
        /// The MaxLengthReached event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<MaxLengthReachedEventArgs> MaxLengthReached
        {
            add
            {
                if (_textFieldMaxLengthReachedEventHandler == null)
                {
                    _textFieldMaxLengthReachedCallbackDelegate = (OnMaxLengthReached);
                    MaxLengthReachedSignal().Connect(_textFieldMaxLengthReachedCallbackDelegate);
                }
                _textFieldMaxLengthReachedEventHandler += value;
            }
            remove
            {
                if (_textFieldMaxLengthReachedEventHandler == null && MaxLengthReachedSignal().Empty() == false)
                {
                    this.MaxLengthReachedSignal().Disconnect(_textFieldMaxLengthReachedCallbackDelegate);
                }
                _textFieldMaxLengthReachedEventHandler -= value;
            }
        }

        private void OnMaxLengthReached(IntPtr textField)
        {
            MaxLengthReachedEventArgs e = new MaxLengthReachedEventArgs();

            // Populate all members of "e" (MaxLengthReachedEventArgs) with real data
            e.TextField = Registry.GetManagedBaseHandleFromNativePtr(textField) as TextField;

            if (_textFieldMaxLengthReachedEventHandler != null)
            {
                //here we send all data to user event handlers
                _textFieldMaxLengthReachedEventHandler(this, e);
            }

        }

        internal new class Property
        {
            internal static readonly int RENDERING_BACKEND = NDalicPINVOKE.TextField_Property_RENDERING_BACKEND_get();
            internal static readonly int TEXT = NDalicPINVOKE.TextField_Property_TEXT_get();
            internal static readonly int PLACEHOLDER_TEXT = NDalicPINVOKE.TextField_Property_PLACEHOLDER_TEXT_get();
            internal static readonly int PLACEHOLDER_TEXT_FOCUSED = NDalicPINVOKE.TextField_Property_PLACEHOLDER_TEXT_FOCUSED_get();
            internal static readonly int FONT_FAMILY = NDalicPINVOKE.TextField_Property_FONT_FAMILY_get();
            internal static readonly int FONT_STYLE = NDalicPINVOKE.TextField_Property_FONT_STYLE_get();
            internal static readonly int POINT_SIZE = NDalicPINVOKE.TextField_Property_POINT_SIZE_get();
            internal static readonly int MAX_LENGTH = NDalicPINVOKE.TextField_Property_MAX_LENGTH_get();
            internal static readonly int EXCEED_POLICY = NDalicPINVOKE.TextField_Property_EXCEED_POLICY_get();
            internal static readonly int HORIZONTAL_ALIGNMENT = NDalicPINVOKE.TextField_Property_HORIZONTAL_ALIGNMENT_get();
            internal static readonly int VERTICAL_ALIGNMENT = NDalicPINVOKE.TextField_Property_VERTICAL_ALIGNMENT_get();
            internal static readonly int TEXT_COLOR = NDalicPINVOKE.TextField_Property_TEXT_COLOR_get();
            internal static readonly int PLACEHOLDER_TEXT_COLOR = NDalicPINVOKE.TextField_Property_PLACEHOLDER_TEXT_COLOR_get();
            internal static readonly int SHADOW_OFFSET = NDalicPINVOKE.TextField_Property_SHADOW_OFFSET_get();
            internal static readonly int SHADOW_COLOR = NDalicPINVOKE.TextField_Property_SHADOW_COLOR_get();
            internal static readonly int PRIMARY_CURSOR_COLOR = NDalicPINVOKE.TextField_Property_PRIMARY_CURSOR_COLOR_get();
            internal static readonly int SECONDARY_CURSOR_COLOR = NDalicPINVOKE.TextField_Property_SECONDARY_CURSOR_COLOR_get();
            internal static readonly int ENABLE_CURSOR_BLINK = NDalicPINVOKE.TextField_Property_ENABLE_CURSOR_BLINK_get();
            internal static readonly int CURSOR_BLINK_INTERVAL = NDalicPINVOKE.TextField_Property_CURSOR_BLINK_INTERVAL_get();
            internal static readonly int CURSOR_BLINK_DURATION = NDalicPINVOKE.TextField_Property_CURSOR_BLINK_DURATION_get();
            internal static readonly int CURSOR_WIDTH = NDalicPINVOKE.TextField_Property_CURSOR_WIDTH_get();
            internal static readonly int GRAB_HANDLE_IMAGE = NDalicPINVOKE.TextField_Property_GRAB_HANDLE_IMAGE_get();
            internal static readonly int GRAB_HANDLE_PRESSED_IMAGE = NDalicPINVOKE.TextField_Property_GRAB_HANDLE_PRESSED_IMAGE_get();
            internal static readonly int SCROLL_THRESHOLD = NDalicPINVOKE.TextField_Property_SCROLL_THRESHOLD_get();
            internal static readonly int SCROLL_SPEED = NDalicPINVOKE.TextField_Property_SCROLL_SPEED_get();
            internal static readonly int SELECTION_HANDLE_IMAGE_LEFT = NDalicPINVOKE.TextField_Property_SELECTION_HANDLE_IMAGE_LEFT_get();
            internal static readonly int SELECTION_HANDLE_IMAGE_RIGHT = NDalicPINVOKE.TextField_Property_SELECTION_HANDLE_IMAGE_RIGHT_get();
            internal static readonly int SELECTION_HANDLE_PRESSED_IMAGE_LEFT = NDalicPINVOKE.TextField_Property_SELECTION_HANDLE_PRESSED_IMAGE_LEFT_get();
            internal static readonly int SELECTION_HANDLE_PRESSED_IMAGE_RIGHT = NDalicPINVOKE.TextField_Property_SELECTION_HANDLE_PRESSED_IMAGE_RIGHT_get();
            internal static readonly int SELECTION_HANDLE_MARKER_IMAGE_LEFT = NDalicPINVOKE.TextField_Property_SELECTION_HANDLE_MARKER_IMAGE_LEFT_get();
            internal static readonly int SELECTION_HANDLE_MARKER_IMAGE_RIGHT = NDalicPINVOKE.TextField_Property_SELECTION_HANDLE_MARKER_IMAGE_RIGHT_get();
            internal static readonly int SELECTION_HIGHLIGHT_COLOR = NDalicPINVOKE.TextField_Property_SELECTION_HIGHLIGHT_COLOR_get();
            internal static readonly int DECORATION_BOUNDING_BOX = NDalicPINVOKE.TextField_Property_DECORATION_BOUNDING_BOX_get();
            internal static readonly int INPUT_METHOD_SETTINGS = NDalicPINVOKE.TextField_Property_INPUT_METHOD_SETTINGS_get();
            internal static readonly int INPUT_COLOR = NDalicPINVOKE.TextField_Property_INPUT_COLOR_get();
            internal static readonly int ENABLE_MARKUP = NDalicPINVOKE.TextField_Property_ENABLE_MARKUP_get();
            internal static readonly int INPUT_FONT_FAMILY = NDalicPINVOKE.TextField_Property_INPUT_FONT_FAMILY_get();
            internal static readonly int INPUT_FONT_STYLE = NDalicPINVOKE.TextField_Property_INPUT_FONT_STYLE_get();
            internal static readonly int INPUT_POINT_SIZE = NDalicPINVOKE.TextField_Property_INPUT_POINT_SIZE_get();
            internal static readonly int UNDERLINE = NDalicPINVOKE.TextField_Property_UNDERLINE_get();
            internal static readonly int INPUT_UNDERLINE = NDalicPINVOKE.TextField_Property_INPUT_UNDERLINE_get();
            internal static readonly int SHADOW = NDalicPINVOKE.TextField_Property_SHADOW_get();
            internal static readonly int INPUT_SHADOW = NDalicPINVOKE.TextField_Property_INPUT_SHADOW_get();
            internal static readonly int EMBOSS = NDalicPINVOKE.TextField_Property_EMBOSS_get();
            internal static readonly int INPUT_EMBOSS = NDalicPINVOKE.TextField_Property_INPUT_EMBOSS_get();
            internal static readonly int OUTLINE = NDalicPINVOKE.TextField_Property_OUTLINE_get();
            internal static readonly int INPUT_OUTLINE = NDalicPINVOKE.TextField_Property_INPUT_OUTLINE_get();
            internal static readonly int HIDDEN_INPUT_SETTINGS = NDalicManualPINVOKE.TextField_Property_HIDDEN_INPUT_SETTINGS_get();
            internal static readonly int PIXEL_SIZE = NDalicManualPINVOKE.TextField_Property_PIXEL_SIZE_get();
            internal static readonly int ENABLE_SELECTION = NDalicManualPINVOKE.TextField_Property_ENABLE_SELECTION_get();
            internal static readonly int PLACEHOLDER = NDalicManualPINVOKE.TextField_Property_PLACEHOLDER_get();
            internal static readonly int ELLIPSIS = NDalicManualPINVOKE.TextField_Property_ELLIPSIS_get();
            internal static readonly int ENABLE_SHIFT_SELECTION = NDalicManualPINVOKE.TextField_Property_ENABLE_SHIFT_SELECTION_get();
        }

        internal class InputStyle
        {
            internal enum Mask
            {
                None = 0x0000,
                Color = 0x0001,
                FontFamily = 0x0002,
                PointSize = 0x0004,
                FontStyle = 0x0008,
                Underline = 0x0010,
                Shadow = 0x0020,
                Emboss = 0x0040,
                Outline = 0x0080
            }

        }

        /// <summary>
        /// Creates the TextField control.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TextField() : this(NDalicPINVOKE.TextField_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        internal TextField(TextField handle) : this(NDalicPINVOKE.new_TextField__SWIG_1(TextField.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get the InputMethodContext instance.
        /// </summary>
        /// <returns>The InputMethodContext instance.</returns>
        public InputMethodContext GetInputMethodContext() {
            InputMethodContext ret = new InputMethodContext(NDalicPINVOKE.TextField_GetInputMethodContext(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TextFieldSignal TextChangedSignal()
        {
            TextFieldSignal ret = new TextFieldSignal(NDalicPINVOKE.TextField_TextChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TextFieldSignal MaxLengthReachedSignal()
        {
            TextFieldSignal ret = new TextFieldSignal(NDalicPINVOKE.TextField_MaxLengthReachedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__TextField_Dali__Toolkit__TextField__InputStyle__MaskF_t InputStyleChangedSignal()
        {
            SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__TextField_Dali__Toolkit__TextField__InputStyle__MaskF_t ret = new SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__TextField_Dali__Toolkit__TextField__InputStyle__MaskF_t(NDalicPINVOKE.TextField_InputStyleChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal enum ExceedPolicyType
        {
            ExceedPolicyOriginal,
            ExceedPolicyClip
        }

        /// <summary>
        /// The TranslatableText property.<br />
        /// The text can set the SID value.<br />
        /// </summary>
        /// <exception cref='ArgumentNullException'>
        /// ResourceManager about multilingual is null.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public string TranslatableText
        {
            get
            {
                return textFieldTextSid;
            }
            set
            {
                if (NUIApplication.MultilingualResourceManager == null)
                {
                    throw new ArgumentNullException("ResourceManager about multilingual is null");
                }
                textFieldTextSid = value;
                Text = SetTranslatable(textFieldTextSid);
                NotifyPropertyChanged();
            }
        }
        /// <summary>
        /// The TranslatablePlaceholderText property.<br />
        /// The text can set the SID value.<br />
        /// </summary>
        /// <exception cref='ArgumentNullException'>
        /// ResourceManager about multilingual is null.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public string TranslatablePlaceholderText
        {
            get
            {
                return textFieldPlaceHolderTextSid;
            }
            set
            {
                if (NUIApplication.MultilingualResourceManager == null)
                {
                    throw new ArgumentNullException("ResourceManager about multilingual is null");
                }
                textFieldPlaceHolderTextSid = value;
                PlaceholderText = SetTranslatable(textFieldPlaceHolderTextSid);
                NotifyPropertyChanged();
            }
        }
        private string SetTranslatable(string textFieldSid)
        {
            string translatableText = null;
            translatableText = NUIApplication.MultilingualResourceManager?.GetString(textFieldSid, new CultureInfo(SystemSettings.LocaleLanguage.Replace("_", "-")));
            if (translatableText != null)
            {
                if (systemlangTextFlag == false)
                {
                    SystemSettings.LocaleLanguageChanged += new WeakEventHandler<LocaleLanguageChangedEventArgs>(SystemSettings_LocaleLanguageChanged).Handler;
                    systemlangTextFlag = true;
                }
                return translatableText;
            }
            else
            {
                translatableText = "";
                return translatableText;
            }
        }
        private void SystemSettings_LocaleLanguageChanged(object sender, LocaleLanguageChangedEventArgs e)
        {
            if (textFieldTextSid != null)
            {
                Text = NUIApplication.MultilingualResourceManager?.GetString(textFieldTextSid, new CultureInfo(e.Value.Replace("_", "-")));
            }
            if (textFieldPlaceHolderTextSid != null)
            {
                PlaceholderText = NUIApplication.MultilingualResourceManager?.GetString(textFieldPlaceHolderTextSid, new CultureInfo(e.Value.Replace("_", "-")));
            }
        }
        /// <summary>
        /// The Text property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Text
        {
            get
            {
                string temp;
                GetProperty(TextField.Property.TEXT).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.TEXT, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The PlaceholderText property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string PlaceholderText
        {
            get
            {
                string temp;
                GetProperty(TextField.Property.PLACEHOLDER_TEXT).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.PLACEHOLDER_TEXT, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The PlaceholderTextFocused property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string PlaceholderTextFocused
        {
            get
            {
                string temp;
                GetProperty(TextField.Property.PLACEHOLDER_TEXT_FOCUSED).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.PLACEHOLDER_TEXT_FOCUSED, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The FontFamily property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string FontFamily
        {
            get
            {
                string temp;
                GetProperty(TextField.Property.FONT_FAMILY).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.FONT_FAMILY, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The FontStyle property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap FontStyle
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextField.Property.FONT_STYLE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.FONT_STYLE, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The PointSize property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float PointSize
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextField.Property.POINT_SIZE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.POINT_SIZE, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The MaxLength property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int MaxLength
        {
            get
            {
                int temp = 0;
                GetProperty(TextField.Property.MAX_LENGTH).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.MAX_LENGTH, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The ExceedPolicy property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int ExceedPolicy
        {
            get
            {
                int temp = 0;
                GetProperty(TextField.Property.EXCEED_POLICY).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.EXCEED_POLICY, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The HorizontalAlignment property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public HorizontalAlignment HorizontalAlignment
        {
            get
            {
                string temp;
                if (GetProperty(TextField.Property.HORIZONTAL_ALIGNMENT).Get(out temp) == false)
                {
                    NUILog.Error("HorizontalAlignment get error!");
                }

                switch (temp)
                {
                    case "BEGIN":
                        return HorizontalAlignment.Begin;
                    case "CENTER":
                        return HorizontalAlignment.Center;
                    case "END":
                        return HorizontalAlignment.End;
                    default:
                        return HorizontalAlignment.Begin;
                }
            }
            set
            {
                string valueToString = "";
                switch (value)
                {
                    case HorizontalAlignment.Begin:
                    {
                        valueToString = "BEGIN";
                        break;
                    }
                    case HorizontalAlignment.Center:
                    {
                        valueToString = "CENTER";
                        break;
                    }
                    case HorizontalAlignment.End:
                    {
                        valueToString = "END";
                        break;
                    }
                    default:
                    {
                        valueToString = "BEGIN";
                        break;
                    }
                }
                SetProperty(TextField.Property.HORIZONTAL_ALIGNMENT, new Tizen.NUI.PropertyValue(valueToString));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The VerticalAlignment property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public VerticalAlignment VerticalAlignment
        {
            get
            {
                string temp;
                if (GetProperty(TextField.Property.VERTICAL_ALIGNMENT).Get(out temp) == false)
                {
                    NUILog.Error("VerticalAlignment get error!");
                }

                switch (temp)
                {
                    case "TOP":
                        return VerticalAlignment.Top;
                    case "CENTER":
                        return VerticalAlignment.Center;
                    case "BOTTOM":
                        return VerticalAlignment.Bottom;
                    default:
                        return VerticalAlignment.Bottom;
                }
            }
            set
            {
                string valueToString = "";
                switch (value)
                {
                    case VerticalAlignment.Top:
                    {
                        valueToString = "TOP";
                        break;
                    }
                    case VerticalAlignment.Center:
                    {
                        valueToString = "CENTER";
                        break;
                    }
                    case VerticalAlignment.Bottom:
                    {
                        valueToString = "BOTTOM";
                        break;
                    }
                    default:
                    {
                        valueToString = "BOTTOM";
                        break;
                    }
                }
                SetProperty(TextField.Property.VERTICAL_ALIGNMENT, new Tizen.NUI.PropertyValue(valueToString));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The TextColor property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Color TextColor
        {
            get
            {
                Color temp = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(TextField.Property.TEXT_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.TEXT_COLOR, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The PlaceholderTextColor property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 PlaceholderTextColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(TextField.Property.PLACEHOLDER_TEXT_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.PLACEHOLDER_TEXT_COLOR, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The ShadowOffset property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ShadowOffset
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(TextField.Property.SHADOW_OFFSET).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.SHADOW_OFFSET, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The ShadowColor property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 ShadowColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(TextField.Property.SHADOW_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.SHADOW_COLOR, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The PrimaryCursorColor property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 PrimaryCursorColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(TextField.Property.PRIMARY_CURSOR_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.PRIMARY_CURSOR_COLOR, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SecondaryCursorColor property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 SecondaryCursorColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(TextField.Property.SECONDARY_CURSOR_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.SECONDARY_CURSOR_COLOR, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The EnableCursorBlink property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool EnableCursorBlink
        {
            get
            {
                bool temp = false;
                GetProperty(TextField.Property.ENABLE_CURSOR_BLINK).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.ENABLE_CURSOR_BLINK, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The CursorBlinkInterval property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float CursorBlinkInterval
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextField.Property.CURSOR_BLINK_INTERVAL).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.CURSOR_BLINK_INTERVAL, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The CursorBlinkDuration property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float CursorBlinkDuration
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextField.Property.CURSOR_BLINK_DURATION).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.CURSOR_BLINK_DURATION, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The CursorWidth property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int CursorWidth
        {
            get
            {
                int temp = 0;
                GetProperty(TextField.Property.CURSOR_WIDTH).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.CURSOR_WIDTH, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The GrabHandleImage property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string GrabHandleImage
        {
            get
            {
                string temp;
                GetProperty(TextField.Property.GRAB_HANDLE_IMAGE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.GRAB_HANDLE_IMAGE, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The GrabHandlePressedImage property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string GrabHandlePressedImage
        {
            get
            {
                string temp;
                GetProperty(TextField.Property.GRAB_HANDLE_PRESSED_IMAGE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.GRAB_HANDLE_PRESSED_IMAGE, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The ScrollThreshold property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScrollThreshold
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextField.Property.SCROLL_THRESHOLD).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.SCROLL_THRESHOLD, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The ScrollSpeed property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScrollSpeed
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextField.Property.SCROLL_SPEED).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.SCROLL_SPEED, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SelectionHandleImageLeft property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandleImageLeft
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextField.Property.SELECTION_HANDLE_IMAGE_LEFT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.SELECTION_HANDLE_IMAGE_LEFT, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SelectionHandleImageRight property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandleImageRight
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextField.Property.SELECTION_HANDLE_IMAGE_RIGHT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.SELECTION_HANDLE_IMAGE_RIGHT, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SelectionHandlePressedImageLeft property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandlePressedImageLeft
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextField.Property.SELECTION_HANDLE_PRESSED_IMAGE_LEFT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.SELECTION_HANDLE_PRESSED_IMAGE_LEFT, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SelectionHandlePressedImageRight property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandlePressedImageRight
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextField.Property.SELECTION_HANDLE_PRESSED_IMAGE_RIGHT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.SELECTION_HANDLE_PRESSED_IMAGE_RIGHT, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SelectionHandleMarkerImageLeft property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandleMarkerImageLeft
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextField.Property.SELECTION_HANDLE_MARKER_IMAGE_LEFT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.SELECTION_HANDLE_MARKER_IMAGE_LEFT, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SelectionHandleMarkerImageRight property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandleMarkerImageRight
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextField.Property.SELECTION_HANDLE_MARKER_IMAGE_RIGHT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.SELECTION_HANDLE_MARKER_IMAGE_RIGHT, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SelectionHighlightColor property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 SelectionHighlightColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(TextField.Property.SELECTION_HIGHLIGHT_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.SELECTION_HIGHLIGHT_COLOR, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The DecorationBoundingBox property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Rectangle DecorationBoundingBox
        {
            get
            {
                Rectangle temp = new Rectangle(0, 0, 0, 0);
                GetProperty(TextField.Property.DECORATION_BOUNDING_BOX).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.DECORATION_BOUNDING_BOX, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputMethodSettings property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap InputMethodSettings
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextField.Property.INPUT_METHOD_SETTINGS).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.INPUT_METHOD_SETTINGS, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputColor property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 InputColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(TextField.Property.INPUT_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.INPUT_COLOR, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The EnableMarkup property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool EnableMarkup
        {
            get
            {
                bool temp = false;
                GetProperty(TextField.Property.ENABLE_MARKUP).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.ENABLE_MARKUP, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputFontFamily property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InputFontFamily
        {
            get
            {
                string temp;
                GetProperty(TextField.Property.INPUT_FONT_FAMILY).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.INPUT_FONT_FAMILY, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputFontStyle property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap InputFontStyle
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextField.Property.INPUT_FONT_STYLE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.INPUT_FONT_STYLE, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputPointSize property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float InputPointSize
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextField.Property.INPUT_POINT_SIZE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.INPUT_POINT_SIZE, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Underline property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Underline
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextField.Property.UNDERLINE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.UNDERLINE, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputUnderline property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InputUnderline
        {
            get
            {
                string temp;
                GetProperty(TextField.Property.INPUT_UNDERLINE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.INPUT_UNDERLINE, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Shadow property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Shadow
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextField.Property.SHADOW).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.SHADOW, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputShadow property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InputShadow
        {
            get
            {
                string temp;
                GetProperty(TextField.Property.INPUT_SHADOW).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.INPUT_SHADOW, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Emboss property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Emboss
        {
            get
            {
                string temp;
                GetProperty(TextField.Property.EMBOSS).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.EMBOSS, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputEmboss property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InputEmboss
        {
            get
            {
                string temp;
                GetProperty(TextField.Property.INPUT_EMBOSS).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.INPUT_EMBOSS, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Outline property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Outline
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextField.Property.OUTLINE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.OUTLINE, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputOutline property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InputOutline
        {
            get
            {
                string temp;
                GetProperty(TextField.Property.INPUT_OUTLINE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.INPUT_OUTLINE, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The HiddenInputSettings property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyMap HiddenInputSettings
        {
            get
            {
                Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
                GetProperty(TextField.Property.HIDDEN_INPUT_SETTINGS).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.HIDDEN_INPUT_SETTINGS, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The PixelSize property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float PixelSize
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextField.Property.PIXEL_SIZE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.PIXEL_SIZE, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Enable selection property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool EnableSelection
        {
            get
            {
                bool temp = false;
                GetProperty(TextField.Property.ENABLE_SELECTION).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.ENABLE_SELECTION, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Placeholder property.
        /// Gets or sets the placeholder: text, color, font family, font style, point size, and pixel size.
        /// </summary>
        /// <example>
        /// The following example demonstrates how to set the Placeholder property.
        /// <code>
        /// PropertyMap propertyMap = new PropertyMap();
        /// propertyMap.Add("text", new PropertyValue("Setting Placeholder Text"));
        /// propertyMap.Add("textFocused", new PropertyValue("Setting Placeholder Text Focused"));
        /// propertyMap.Add("color", new PropertyValue(Color.Red));
        /// propertyMap.Add("fontFamily", new PropertyValue("Arial"));
        /// propertyMap.Add("pointSize", new PropertyValue(12.0f));
        ///
        /// PropertyMap fontStyleMap = new PropertyMap();
        /// fontStyleMap.Add("weight", new PropertyValue("bold"));
        /// fontStyleMap.Add("width", new PropertyValue("condensed"));
        /// fontStyleMap.Add("slant", new PropertyValue("italic"));
        /// propertyMap.Add("fontStyle", new PropertyValue(fontStyleMap));
        ///
        /// TextField field = new TextField();
        /// field.Placeholder = propertyMap;
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyMap Placeholder
        {
            get
            {
                Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
                GetProperty(TextField.Property.PLACEHOLDER).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.PLACEHOLDER, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Ellipsis property.<br />
        /// Enable or disable the ellipsis.<br />
        /// Placeholder PropertyMap is used to add ellipsis to placeholder text.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool Ellipsis
        {
            get
            {
                bool temp = false;
                GetProperty(TextField.Property.ELLIPSIS).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.ELLIPSIS, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Enables Text selection using Shift key.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public bool EnableShiftSelection
        {
            get
            {
                // mShiftSelectionFlag( true )
                bool temp = true;
                GetProperty(TextField.Property.ENABLE_SHIFT_SELECTION).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextField.Property.ENABLE_SHIFT_SELECTION, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }



    }
}

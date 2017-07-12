/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.BaseComponents
{

    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A control which provides a multi-line editable text editor.
    /// </summary>
    public class TextEditor : View
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal TextEditor(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.TextEditor_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TextEditor obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;

                    //Unreference this instance from Registry.
                    Registry.Unregister(this);

                    NDalicPINVOKE.delete_TextEditor(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Event arguments that passed via TextChanged signal.
        /// </summary>
        public class TextChangedEventArgs : EventArgs
        {
            private TextEditor _textEditor;

            /// <summary>
            /// TextEditor - is the texteditor control which has the text contents changed.
            /// </summary>
            public TextEditor TextEditor
            {
                get
                {
                    return _textEditor;
                }
                set
                {
                    _textEditor = value;
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void TextChangedCallbackDelegate(IntPtr textEditor);
        private EventHandler<TextChangedEventArgs> _textEditorTextChangedEventHandler;
        private TextChangedCallbackDelegate _textEditorTextChangedCallbackDelegate;

        /// <summary>
        /// Event for TextChanged signal which can be used to subscribe/unsubscribe the event handler
        /// provided by the user. TextChanged signal is emitted when the text changes.<br>
        /// </summary>
        public event EventHandler<TextChangedEventArgs> TextChanged
        {
            add
            {
                if (_textEditorTextChangedEventHandler == null)
                {
                    _textEditorTextChangedCallbackDelegate = (OnTextChanged);
                    TextChangedSignal().Connect(_textEditorTextChangedCallbackDelegate);
                }
                _textEditorTextChangedEventHandler += value;
            }
            remove
            {
                _textEditorTextChangedEventHandler -= value;
                if (_textEditorTextChangedEventHandler == null && TextChangedSignal().Empty() == false)
                {
                    TextChangedSignal().Disconnect(_textEditorTextChangedCallbackDelegate);
                }
            }
        }

        private void OnTextChanged(IntPtr textEditor)
        {
            TextChangedEventArgs e = new TextChangedEventArgs();

            // Populate all members of "e" (TextChangedEventArgs) with real data
            e.TextEditor = Registry.GetManagedBaseHandleFromNativePtr(textEditor) as TextEditor;

            if (_textEditorTextChangedEventHandler != null)
            {
                //here we send all data to user event handlers
                _textEditorTextChangedEventHandler(this, e);
            }

        }

        /// <summary>
        /// Event arguments that passed via ScrollStateChanged signal.
        /// </summary>
        public class ScrollStateChangedEventArgs : EventArgs
        {
            private TextEditor _textEditor;
            private ScrollState _scrollState;

            /// <summary>
            /// TextEditor - is the texteditor control which has the scroll state changed.
            /// </summary>
            public TextEditor TextEditor
            {
                get
                {
                    return _textEditor;
                }
                set
                {
                    _textEditor = value;
                }
            }

            /// <summary>
            /// ScrollState - is the texteditor control scroll state.
            /// </summary>
            public ScrollState ScrollState
            {
                get
                {
                    return _scrollState;
                }
                set
                {
                    _scrollState = value;
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ScrollStateChangedCallbackDelegate(IntPtr textEditor, ScrollState state);
        private EventHandler<ScrollStateChangedEventArgs> _textEditorScrollStateChangedEventHandler;
        private ScrollStateChangedCallbackDelegate _textEditorScrollStateChangedCallbackDelegate;

        /// <summary>
        /// Event for ScrollStateChanged signal which can be used to subscribe/unsubscribe the event handler
        /// provided by the user. ScrollStateChanged signal is emitted when the scroll state changes.<br>
        /// </summary>
        public event EventHandler<ScrollStateChangedEventArgs> ScrollStateChanged
        {
            add
            {
                if (_textEditorScrollStateChangedEventHandler == null)
                {
                    _textEditorScrollStateChangedCallbackDelegate = OnScrollStateChanged;
                    ScrollStateChangedSignal(this).Connect(_textEditorScrollStateChangedCallbackDelegate);
                }
                _textEditorScrollStateChangedEventHandler += value;
            }
            remove
            {
                _textEditorScrollStateChangedEventHandler -= value;
                if (_textEditorScrollStateChangedEventHandler == null && ScrollStateChangedSignal(this).Empty() == false)
                {
                    ScrollStateChangedSignal(this).Disconnect(_textEditorScrollStateChangedCallbackDelegate);
                }
            }
        }

        private void OnScrollStateChanged(IntPtr textEditor, ScrollState state)
        {
            ScrollStateChangedEventArgs e = new ScrollStateChangedEventArgs();

            if (textEditor != null)
            {
                // Populate all members of "e" (ScrollStateChangedEventArgs) with real data
                e.TextEditor = Registry.GetManagedBaseHandleFromNativePtr(textEditor) as TextEditor;
                e.ScrollState = state;
            }

            if (_textEditorScrollStateChangedEventHandler != null)
            {
                //here we send all data to user event handlers
                _textEditorScrollStateChangedEventHandler(this, e);
            }
        }

        internal class Property
        {
            internal static readonly int RENDERING_BACKEND = NDalicPINVOKE.TextEditor_Property_RENDERING_BACKEND_get();
            internal static readonly int TEXT = NDalicPINVOKE.TextEditor_Property_TEXT_get();
            internal static readonly int TEXT_COLOR = NDalicPINVOKE.TextEditor_Property_TEXT_COLOR_get();
            internal static readonly int FONT_FAMILY = NDalicPINVOKE.TextEditor_Property_FONT_FAMILY_get();
            internal static readonly int FONT_STYLE = NDalicPINVOKE.TextEditor_Property_FONT_STYLE_get();
            internal static readonly int POINT_SIZE = NDalicPINVOKE.TextEditor_Property_POINT_SIZE_get();
            internal static readonly int HORIZONTAL_ALIGNMENT = NDalicPINVOKE.TextEditor_Property_HORIZONTAL_ALIGNMENT_get();
            internal static readonly int SCROLL_THRESHOLD = NDalicPINVOKE.TextEditor_Property_SCROLL_THRESHOLD_get();
            internal static readonly int SCROLL_SPEED = NDalicPINVOKE.TextEditor_Property_SCROLL_SPEED_get();
            internal static readonly int PRIMARY_CURSOR_COLOR = NDalicPINVOKE.TextEditor_Property_PRIMARY_CURSOR_COLOR_get();
            internal static readonly int SECONDARY_CURSOR_COLOR = NDalicPINVOKE.TextEditor_Property_SECONDARY_CURSOR_COLOR_get();
            internal static readonly int ENABLE_CURSOR_BLINK = NDalicPINVOKE.TextEditor_Property_ENABLE_CURSOR_BLINK_get();
            internal static readonly int CURSOR_BLINK_INTERVAL = NDalicPINVOKE.TextEditor_Property_CURSOR_BLINK_INTERVAL_get();
            internal static readonly int CURSOR_BLINK_DURATION = NDalicPINVOKE.TextEditor_Property_CURSOR_BLINK_DURATION_get();
            internal static readonly int CURSOR_WIDTH = NDalicPINVOKE.TextEditor_Property_CURSOR_WIDTH_get();
            internal static readonly int GRAB_HANDLE_IMAGE = NDalicPINVOKE.TextEditor_Property_GRAB_HANDLE_IMAGE_get();
            internal static readonly int GRAB_HANDLE_PRESSED_IMAGE = NDalicPINVOKE.TextEditor_Property_GRAB_HANDLE_PRESSED_IMAGE_get();
            internal static readonly int SELECTION_HANDLE_IMAGE_LEFT = NDalicPINVOKE.TextEditor_Property_SELECTION_HANDLE_IMAGE_LEFT_get();
            internal static readonly int SELECTION_HANDLE_IMAGE_RIGHT = NDalicPINVOKE.TextEditor_Property_SELECTION_HANDLE_IMAGE_RIGHT_get();
            internal static readonly int SELECTION_HANDLE_PRESSED_IMAGE_LEFT = NDalicPINVOKE.TextEditor_Property_SELECTION_HANDLE_PRESSED_IMAGE_LEFT_get();
            internal static readonly int SELECTION_HANDLE_PRESSED_IMAGE_RIGHT = NDalicPINVOKE.TextEditor_Property_SELECTION_HANDLE_PRESSED_IMAGE_RIGHT_get();
            internal static readonly int SELECTION_HANDLE_MARKER_IMAGE_LEFT = NDalicPINVOKE.TextEditor_Property_SELECTION_HANDLE_MARKER_IMAGE_LEFT_get();
            internal static readonly int SELECTION_HANDLE_MARKER_IMAGE_RIGHT = NDalicPINVOKE.TextEditor_Property_SELECTION_HANDLE_MARKER_IMAGE_RIGHT_get();
            internal static readonly int SELECTION_HIGHLIGHT_COLOR = NDalicPINVOKE.TextEditor_Property_SELECTION_HIGHLIGHT_COLOR_get();
            internal static readonly int DECORATION_BOUNDING_BOX = NDalicPINVOKE.TextEditor_Property_DECORATION_BOUNDING_BOX_get();
            internal static readonly int ENABLE_MARKUP = NDalicPINVOKE.TextEditor_Property_ENABLE_MARKUP_get();
            internal static readonly int INPUT_COLOR = NDalicPINVOKE.TextEditor_Property_INPUT_COLOR_get();
            internal static readonly int INPUT_FONT_FAMILY = NDalicPINVOKE.TextEditor_Property_INPUT_FONT_FAMILY_get();
            internal static readonly int INPUT_FONT_STYLE = NDalicPINVOKE.TextEditor_Property_INPUT_FONT_STYLE_get();
            internal static readonly int INPUT_POINT_SIZE = NDalicPINVOKE.TextEditor_Property_INPUT_POINT_SIZE_get();
            internal static readonly int LINE_SPACING = NDalicPINVOKE.TextEditor_Property_LINE_SPACING_get();
            internal static readonly int INPUT_LINE_SPACING = NDalicPINVOKE.TextEditor_Property_INPUT_LINE_SPACING_get();
            internal static readonly int UNDERLINE = NDalicPINVOKE.TextEditor_Property_UNDERLINE_get();
            internal static readonly int INPUT_UNDERLINE = NDalicPINVOKE.TextEditor_Property_INPUT_UNDERLINE_get();
            internal static readonly int SHADOW = NDalicPINVOKE.TextEditor_Property_SHADOW_get();
            internal static readonly int INPUT_SHADOW = NDalicPINVOKE.TextEditor_Property_INPUT_SHADOW_get();
            internal static readonly int EMBOSS = NDalicPINVOKE.TextEditor_Property_EMBOSS_get();
            internal static readonly int INPUT_EMBOSS = NDalicPINVOKE.TextEditor_Property_INPUT_EMBOSS_get();
            internal static readonly int OUTLINE = NDalicPINVOKE.TextEditor_Property_OUTLINE_get();
            internal static readonly int INPUT_OUTLINE = NDalicPINVOKE.TextEditor_Property_INPUT_OUTLINE_get();
            internal static readonly int SMOOTH_SCROLL = NDalicManualPINVOKE.TextEditor_Property_SMOOTH_SCROLL_get();
            internal static readonly int SMOOTH_SCROLL_DURATION = NDalicManualPINVOKE.TextEditor_Property_SMOOTH_SCROLL_DURATION_get();
            internal static readonly int ENABLE_SCROLL_BAR = NDalicManualPINVOKE.TextEditor_Property_ENABLE_SCROLL_BAR_get();
            internal static readonly int SCROLL_BAR_SHOW_DURATION = NDalicManualPINVOKE.TextEditor_Property_SCROLL_BAR_SHOW_DURATION_get();
            internal static readonly int SCROLL_BAR_FADE_DURATION = NDalicManualPINVOKE.TextEditor_Property_SCROLL_BAR_FADE_DURATION_get();
            internal static readonly int PIXEL_SIZE = NDalicManualPINVOKE.TextEditor_Property_PIXEL_SIZE_get();
            internal static readonly int LINE_COUNT = NDalicManualPINVOKE.TextEditor_Property_LINE_COUNT_get();
            internal static readonly int PLACEHOLDER_TEXT = NDalicManualPINVOKE.TextEditor_Property_PLACEHOLDER_TEXT_get();
            internal static readonly int PLACEHOLDER_TEXT_COLOR = NDalicManualPINVOKE.TextEditor_Property_PLACEHOLDER_TEXT_COLOR_get();
            internal static readonly int ENABLE_SELECTION = NDalicManualPINVOKE.TextEditor_Property_ENABLE_SELECTION_get();
            internal static readonly int PLACEHOLDER = NDalicManualPINVOKE.TextEditor_Property_PLACEHOLDER_get();

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
                LineSpacing = 0x0010,
                Underline = 0x0020,
                Shadow = 0x0040,
                Emboss = 0x0080,
                Outline = 0x0100
            }
        }

        /// <summary>
        /// Creates the TextEditor control.
        /// </summary>
        public TextEditor() : this(NDalicPINVOKE.TextEditor_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        internal TextEditor(TextEditor handle) : this(NDalicPINVOKE.new_TextEditor__SWIG_1(TextEditor.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [Obsolete("Please do not use! this will be deprecated")]
        public new static TextEditor DownCast(BaseHandle handle)
        {
            TextEditor ret = new TextEditor(NDalicPINVOKE.TextEditor_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TextEditorSignal TextChangedSignal()
        {
            TextEditorSignal ret = new TextEditorSignal(NDalicPINVOKE.TextEditor_TextChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ScrollStateChangedSignal ScrollStateChangedSignal(TextEditor textEditor)
        {
            ScrollStateChangedSignal ret = new ScrollStateChangedSignal(NDalicManualPINVOKE.TextEditor_ScrollStateChangedSignal(TextEditor.getCPtr(textEditor)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__TextEditor_Dali__Toolkit__TextEditor__InputStyle__MaskF_t InputStyleChangedSignal()
        {
            SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__TextEditor_Dali__Toolkit__TextEditor__InputStyle__MaskF_t ret = new SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__TextEditor_Dali__Toolkit__TextEditor__InputStyle__MaskF_t(NDalicPINVOKE.TextEditor_InputStyleChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Text property.
        /// </summary>
        public string Text
        {
            get
            {
                string temp;
                GetProperty(TextEditor.Property.TEXT).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.TEXT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Text color property.
        /// </summary>
        public Vector4 TextColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(TextEditor.Property.TEXT_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.TEXT_COLOR, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Font family property.
        /// </summary>
        public string FontFamily
        {
            get
            {
                string temp;
                GetProperty(TextEditor.Property.FONT_FAMILY).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.FONT_FAMILY, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Font style property.
        /// </summary>
        public PropertyMap FontStyle
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextEditor.Property.FONT_STYLE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.FONT_STYLE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Point size property.
        /// </summary>
        public float PointSize
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextEditor.Property.POINT_SIZE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.POINT_SIZE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Horizontal alignment property.
        /// </summary>
        public HorizontalAlignment HorizontalAlignment
        {
            get
            {
                string temp;
                if (GetProperty(TextEditor.Property.HORIZONTAL_ALIGNMENT).Get(out temp) == false)
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
                SetProperty(TextEditor.Property.HORIZONTAL_ALIGNMENT, new Tizen.NUI.PropertyValue(valueToString));
            }
        }

        /// <summary>
        /// Scroll threshold property.
        /// </summary>
        public float ScrollThreshold
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextEditor.Property.SCROLL_THRESHOLD).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.SCROLL_THRESHOLD, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Scroll speed property.
        /// </summary>
        public float ScrollSpeed
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextEditor.Property.SCROLL_SPEED).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.SCROLL_SPEED, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Primary cursor color property.
        /// </summary>
        public Vector4 PrimaryCursorColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(TextEditor.Property.PRIMARY_CURSOR_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.PRIMARY_CURSOR_COLOR, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// SecondaryCursorColor property.
        /// </summary>
        public Vector4 SecondaryCursorColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(TextEditor.Property.SECONDARY_CURSOR_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.SECONDARY_CURSOR_COLOR, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// EnableCursorBlink property.
        /// </summary>
        public bool EnableCursorBlink
        {
            get
            {
                bool temp = false;
                GetProperty(TextEditor.Property.ENABLE_CURSOR_BLINK).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.ENABLE_CURSOR_BLINK, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// CursorBlinkInterval property.
        /// </summary>
        public float CursorBlinkInterval
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextEditor.Property.CURSOR_BLINK_INTERVAL).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.CURSOR_BLINK_INTERVAL, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// CursorBlinkDuration property.
        /// </summary>
        public float CursorBlinkDuration
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextEditor.Property.CURSOR_BLINK_DURATION).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.CURSOR_BLINK_DURATION, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// CursorWidth property.
        /// </summary>
        public int CursorWidth
        {
            get
            {
                int temp = 0;
                GetProperty(TextEditor.Property.CURSOR_WIDTH).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.CURSOR_WIDTH, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// GrabHandleImage property.
        /// </summary>
        public string GrabHandleImage
        {
            get
            {
                string temp;
                GetProperty(TextEditor.Property.GRAB_HANDLE_IMAGE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.GRAB_HANDLE_IMAGE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// GrabHandlePressedImage property.
        /// </summary>
        public string GrabHandlePressedImage
        {
            get
            {
                string temp;
                GetProperty(TextEditor.Property.GRAB_HANDLE_PRESSED_IMAGE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.GRAB_HANDLE_PRESSED_IMAGE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// SelectionHandleImageLeft property.
        /// </summary>
        public PropertyMap SelectionHandleImageLeft
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextEditor.Property.SELECTION_HANDLE_IMAGE_LEFT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.SELECTION_HANDLE_IMAGE_LEFT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// SelectionHandleImageRight property.
        /// </summary>
        public PropertyMap SelectionHandleImageRight
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextEditor.Property.SELECTION_HANDLE_IMAGE_RIGHT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.SELECTION_HANDLE_IMAGE_RIGHT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// SelectionHandlePressedImageLeft property.
        /// </summary>
        public PropertyMap SelectionHandlePressedImageLeft
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextEditor.Property.SELECTION_HANDLE_PRESSED_IMAGE_LEFT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.SELECTION_HANDLE_PRESSED_IMAGE_LEFT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// SelectionHandlePressedImageRight property.
        /// </summary>
        public PropertyMap SelectionHandlePressedImageRight
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextEditor.Property.SELECTION_HANDLE_PRESSED_IMAGE_RIGHT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.SELECTION_HANDLE_PRESSED_IMAGE_RIGHT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// SelectionHandleMarkerImageLeft property.
        /// </summary>
        public PropertyMap SelectionHandleMarkerImageLeft
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextEditor.Property.SELECTION_HANDLE_MARKER_IMAGE_LEFT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.SELECTION_HANDLE_MARKER_IMAGE_LEFT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// SelectionHandleMarkerImageRight property.
        /// </summary>
        public PropertyMap SelectionHandleMarkerImageRight
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextEditor.Property.SELECTION_HANDLE_MARKER_IMAGE_RIGHT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.SELECTION_HANDLE_MARKER_IMAGE_RIGHT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// SelectionHighlightColor property.
        /// </summary>
        public Vector4 SelectionHighlightColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(TextEditor.Property.SELECTION_HIGHLIGHT_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.SELECTION_HIGHLIGHT_COLOR, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// DecorationBoundingBox property.
        /// </summary>
        public Rectangle DecorationBoundingBox
        {
            get
            {
                Rectangle temp = new Rectangle(0, 0, 0, 0);
                GetProperty(TextEditor.Property.DECORATION_BOUNDING_BOX).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.DECORATION_BOUNDING_BOX, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// EnableMarkup property.
        /// </summary>
        public bool EnableMarkup
        {
            get
            {
                bool temp = false;
                GetProperty(TextEditor.Property.ENABLE_MARKUP).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.ENABLE_MARKUP, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// InputColor property.
        /// </summary>
        public Vector4 InputColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(TextEditor.Property.INPUT_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.INPUT_COLOR, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// InputFontFamily property.
        /// </summary>
        public string InputFontFamily
        {
            get
            {
                string temp;
                GetProperty(TextEditor.Property.INPUT_FONT_FAMILY).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.INPUT_FONT_FAMILY, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// InputFontStyle property.
        /// </summary>
        public PropertyMap InputFontStyle
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextEditor.Property.INPUT_FONT_STYLE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.INPUT_FONT_STYLE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// InputPointSize property.
        /// </summary>
        public float InputPointSize
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextEditor.Property.INPUT_POINT_SIZE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.INPUT_POINT_SIZE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// LineSpacing property.
        /// </summary>
        public float LineSpacing
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextEditor.Property.LINE_SPACING).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.LINE_SPACING, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// InputLineSpacing property.
        /// </summary>
        public float InputLineSpacing
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextEditor.Property.INPUT_LINE_SPACING).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.INPUT_LINE_SPACING, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Underline property.
        /// </summary>
        public PropertyMap Underline
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextEditor.Property.UNDERLINE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.UNDERLINE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// InputUnderline property.
        /// </summary>
        public string InputUnderline
        {
            get
            {
                string temp;
                GetProperty(TextEditor.Property.INPUT_UNDERLINE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.INPUT_UNDERLINE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Shadow property.
        /// </summary>
        public PropertyMap Shadow
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextEditor.Property.SHADOW).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.SHADOW, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// InputShadow property.
        /// </summary>
        public string InputShadow
        {
            get
            {
                string temp;
                GetProperty(TextEditor.Property.INPUT_SHADOW).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.INPUT_SHADOW, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Emboss property.
        /// </summary>
        public string Emboss
        {
            get
            {
                string temp;
                GetProperty(TextEditor.Property.EMBOSS).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.EMBOSS, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// InputEmboss property.
        /// </summary>
        public string InputEmboss
        {
            get
            {
                string temp;
                GetProperty(TextEditor.Property.INPUT_EMBOSS).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.INPUT_EMBOSS, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Outline property.
        /// </summary>
        public string Outline
        {
            get
            {
                string temp;
                GetProperty(TextEditor.Property.OUTLINE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.OUTLINE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// InputOutline property.
        /// </summary>
        public string InputOutline
        {
            get
            {
                string temp;
                GetProperty(TextEditor.Property.INPUT_OUTLINE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.INPUT_OUTLINE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// SmoothScroll property.
        /// </summary>
        public bool SmoothScroll
        {
            get
            {
                bool temp = false;
                GetProperty(TextEditor.Property.SMOOTH_SCROLL).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.SMOOTH_SCROLL, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// SmoothScrollDuration property.
        /// </summary>
        public float SmoothScrollDuration
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextEditor.Property.SMOOTH_SCROLL_DURATION).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.SMOOTH_SCROLL_DURATION, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// EnableScrollBar property.
        /// </summary>
        public bool EnableScrollBar
        {
            get
            {
                bool temp = false;
                GetProperty(TextEditor.Property.ENABLE_SCROLL_BAR).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.ENABLE_SCROLL_BAR, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// ScrollBarShowDuration property.
        /// </summary>
        public float ScrollBarShowDuration
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextEditor.Property.SCROLL_BAR_SHOW_DURATION).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.SCROLL_BAR_SHOW_DURATION, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// ScrollBarFadeDuration property.
        /// </summary>
        public float ScrollBarFadeDuration
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextEditor.Property.SCROLL_BAR_FADE_DURATION).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.SCROLL_BAR_FADE_DURATION, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// PixelSize property.
        /// </summary>
        public float PixelSize
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextEditor.Property.PIXEL_SIZE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.PIXEL_SIZE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The line count of text.
        /// </summary>
        public int LineCount
        {
            get
            {
                int temp = 0;
                GetProperty(TextEditor.Property.LINE_COUNT).Get(out temp);
                return temp;
            }
        }

        /// <summary>
        /// The text to display when the TextEditor is empty and inactive.
        /// </summary>
        public string PlaceholderText
        {
            get
            {
                string temp;
                GetProperty(TextEditor.Property.PLACEHOLDER_TEXT).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.PLACEHOLDER_TEXT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The placeholder-text color.
        /// </summary>
        public Color PlaceholderTextColor
        {
            get
            {
                Color temp = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(TextEditor.Property.PLACEHOLDER_TEXT_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.PLACEHOLDER_TEXT_COLOR, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Enable selection property.
        /// </summary>
        public bool EnableSelection
        {
            get
            {
                bool temp = false;
                GetProperty(TextEditor.Property.ENABLE_SELECTION).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.ENABLE_SELECTION, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Placeholder property.
        /// </summary>
        public Tizen.NUI.PropertyMap Placeholder
        {
            get
            {
                Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
                GetProperty(TextEditor.Property.PLACEHOLDER).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.PLACEHOLDER, new Tizen.NUI.PropertyValue(value));
            }
        }

    }

}

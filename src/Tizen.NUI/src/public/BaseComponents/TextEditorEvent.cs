/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// A control which provides a multi-line editable text editor.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class TextEditor
    {
        private EventHandler<TextChangedEventArgs> _textEditorTextChangedEventHandler;
        private TextChangedCallbackDelegate _textEditorTextChangedCallbackDelegate;

        private EventHandler<ScrollStateChangedEventArgs> _textEditorScrollStateChangedEventHandler;
        private ScrollStateChangedCallbackDelegate _textEditorScrollStateChangedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void TextChangedCallbackDelegate(IntPtr textEditor);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ScrollStateChangedCallbackDelegate(IntPtr textEditor, ScrollState state);

        /// <summary>
        /// An event for the TextChanged signal which can be used to subscribe or unsubscribe the event handler
        /// provided by the user. The TextChanged signal is emitted when the text changes.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Event for the ScrollStateChanged signal which can be used to subscribe or unsubscribe the event handler
        /// provided by the user. The ScrollStateChanged signal is emitted when the scroll state changes.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        internal TextEditorSignal TextChangedSignal()
        {
            TextEditorSignal ret = new TextEditorSignal(Interop.TextEditor.TextEditor_TextChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ScrollStateChangedSignal ScrollStateChangedSignal(TextEditor textEditor)
        {
            ScrollStateChangedSignal ret = new ScrollStateChangedSignal(Interop.TextEditor.TextEditor_ScrollStateChangedSignal(TextEditor.getCPtr(textEditor)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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

        private void OnScrollStateChanged(IntPtr textEditor, ScrollState state)
        {
            ScrollStateChangedEventArgs e = new ScrollStateChangedEventArgs();

            if (textEditor != global::System.IntPtr.Zero)
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

        /// <summary>
        /// Event arguments that passed via the TextChanged signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class TextChangedEventArgs : EventArgs
        {
            private TextEditor _textEditor;

            /// <summary>
            /// TextEditor - is the texteditor control which has the text contents changed.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Event arguments that passed via the ScrollStateChanged signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class ScrollStateChangedEventArgs : EventArgs
        {
            private TextEditor _textEditor;
            private ScrollState _scrollState;

            /// <summary>
            /// TextEditor - is the texteditor control which has the scroll state changed.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
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
            /// <since_tizen> 3 </since_tizen>
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
    }
}

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
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// A control which provides a multi-line editable text editor.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class TextEditor
    {
        private EventHandler<TextChangedEventArgs> textEditorTextChangedEventHandler;
        private TextChangedCallbackDelegate textEditorTextChangedCallbackDelegate;

        private EventHandler<ScrollStateChangedEventArgs> textEditorScrollStateChangedEventHandler;
        private ScrollStateChangedCallbackDelegate textEditorScrollStateChangedCallbackDelegate;

        private EventHandler<MaxLengthReachedEventArgs> textEditorMaxLengthReachedEventHandler;
        private MaxLengthReachedCallbackDelegate textEditorMaxLengthReachedCallbackDelegate;

        private EventHandler<AnchorClickedEventArgs> textEditorAnchorClickedEventHandler;
        private AnchorClickedCallbackDelegate textEditorAnchorClickedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void TextChangedCallbackDelegate(IntPtr textEditor);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ScrollStateChangedCallbackDelegate(IntPtr textEditor, ScrollState state);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void MaxLengthReachedCallbackDelegate(IntPtr textEditor);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void AnchorClickedCallbackDelegate(IntPtr textEditor, IntPtr href, uint hrefLength);

        /// <summary>
        /// An event for the TextChanged signal which can be used to subscribe or unsubscribe the event handler
        /// provided by the user. The TextChanged signal is emitted when the text changes.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<TextChangedEventArgs> TextChanged
        {
            add
            {
                if (textEditorTextChangedEventHandler == null)
                {
                    textEditorTextChangedCallbackDelegate = (OnTextChanged);
                    TextChangedSignal().Connect(textEditorTextChangedCallbackDelegate);
                }
                textEditorTextChangedEventHandler += value;
            }
            remove
            {
                textEditorTextChangedEventHandler -= value;
                if (textEditorTextChangedEventHandler == null && TextChangedSignal().Empty() == false)
                {
                    TextChangedSignal().Disconnect(textEditorTextChangedCallbackDelegate);
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
                if (textEditorScrollStateChangedEventHandler == null)
                {
                    textEditorScrollStateChangedCallbackDelegate = OnScrollStateChanged;
                    ScrollStateChangedSignal(this).Connect(textEditorScrollStateChangedCallbackDelegate);
                }
                textEditorScrollStateChangedEventHandler += value;
            }
            remove
            {
                textEditorScrollStateChangedEventHandler -= value;
                if (textEditorScrollStateChangedEventHandler == null && ScrollStateChangedSignal(this).Empty() == false)
                {
                    ScrollStateChangedSignal(this).Disconnect(textEditorScrollStateChangedCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// The MaxLengthReached event.
        /// </summary>
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<MaxLengthReachedEventArgs> MaxLengthReached
        {
            add
            {
                if (textEditorMaxLengthReachedEventHandler == null)
                {
                    textEditorMaxLengthReachedCallbackDelegate = (OnMaxLengthReached);
                    MaxLengthReachedSignal().Connect(textEditorMaxLengthReachedCallbackDelegate);
                }
                textEditorMaxLengthReachedEventHandler += value;
            }
            remove
            {
                if (textEditorMaxLengthReachedEventHandler == null && MaxLengthReachedSignal().Empty() == false)
                {
                    this.MaxLengthReachedSignal().Disconnect(textEditorMaxLengthReachedCallbackDelegate);
                }
                textEditorMaxLengthReachedEventHandler -= value;
            }
        }

        /// <summary>
        /// The AnchorClicked signal is emitted when the anchor is clicked.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<AnchorClickedEventArgs> AnchorClicked
        {
            add
            {
                if (textEditorAnchorClickedEventHandler == null)
                {
                    textEditorAnchorClickedCallbackDelegate = (OnAnchorClicked);
                    AnchorClickedSignal().Connect(textEditorAnchorClickedCallbackDelegate);
                }
                textEditorAnchorClickedEventHandler += value;
            }
            remove
            {
                textEditorAnchorClickedEventHandler -= value;
                if (textEditorAnchorClickedEventHandler == null && AnchorClickedSignal().Empty() == false)
                {
                    AnchorClickedSignal().Disconnect(textEditorAnchorClickedCallbackDelegate);
                }
            }
        }

        internal TextEditorSignal TextChangedSignal()
        {
            TextEditorSignal ret = new TextEditorSignal(Interop.TextEditor.TextChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ScrollStateChangedSignal ScrollStateChangedSignal(TextEditor textEditor)
        {
            ScrollStateChangedSignal ret = new ScrollStateChangedSignal(Interop.TextEditor.ScrollStateChangedSignal(TextEditor.getCPtr(textEditor)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TextEditorSignal MaxLengthReachedSignal()
        {
            TextEditorSignal ret = new TextEditorSignal(Interop.TextEditor.MaxLengthReachedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TextEditorSignal AnchorClickedSignal()
        {
            TextEditorSignal ret = new TextEditorSignal(Interop.TextEditor.AnchorClickedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void OnTextChanged(IntPtr textEditor)
        {
            if (textEditorTextChangedEventHandler != null)
            {
                TextChangedEventArgs e = new TextChangedEventArgs();

                // Populate all members of "e" (TextChangedEventArgs) with real data
                e.TextEditor = Registry.GetManagedBaseHandleFromNativePtr(textEditor) as TextEditor;
                //here we send all data to user event handlers
                textEditorTextChangedEventHandler(this, e);
            }
        }

        private void OnScrollStateChanged(IntPtr textEditor, ScrollState state)
        {
            if (textEditorScrollStateChangedEventHandler != null)
            {
                ScrollStateChangedEventArgs e = new ScrollStateChangedEventArgs();

                if (textEditor != global::System.IntPtr.Zero)
                {
                    // Populate all members of "e" (ScrollStateChangedEventArgs) with real data
                    e.TextEditor = Registry.GetManagedBaseHandleFromNativePtr(textEditor) as TextEditor;
                    e.ScrollState = state;
                }
                //here we send all data to user event handlers
                textEditorScrollStateChangedEventHandler(this, e);
            }
        }

        private void OnMaxLengthReached(IntPtr textEditor)
        {
            if (textEditorMaxLengthReachedEventHandler != null)
            {
                MaxLengthReachedEventArgs e = new MaxLengthReachedEventArgs();

                // Populate all members of "e" (MaxLengthReachedEventArgs) with real data
                e.TextEditor = Registry.GetManagedBaseHandleFromNativePtr(textEditor) as TextEditor;
                //here we send all data to user event handlers
                textEditorMaxLengthReachedEventHandler(this, e);
            }
        }

        private void OnAnchorClicked(IntPtr textEditor, IntPtr href, uint hrefLength)
        {
            // Note: hrefLength is useful for get the length of a const char* (href) in dali-toolkit.
            // But NUI can get the length of string (href), so hrefLength is not necessary in NUI.
            AnchorClickedEventArgs e = new AnchorClickedEventArgs();

            // Populate all members of "e" (AnchorClickedEventArgs) with real data
            e.Href = Marshal.PtrToStringAnsi(href);
            //here we send all data to user event handlers
            textEditorAnchorClickedEventHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Event arguments that passed via the TextChanged signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class TextChangedEventArgs : EventArgs
        {
            private TextEditor textEditor;

            /// <summary>
            /// TextEditor - is the texteditor control which has the text contents changed.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public TextEditor TextEditor
            {
                get
                {
                    return textEditor;
                }
                set
                {
                    textEditor = value;
                }
            }
        }

        /// <summary>
        /// Event arguments that passed via the ScrollStateChanged signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class ScrollStateChangedEventArgs : EventArgs
        {
            private TextEditor textEditor;
            private ScrollState scrollState;

            /// <summary>
            /// TextEditor - is the texteditor control which has the scroll state changed.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public TextEditor TextEditor
            {
                get
                {
                    return textEditor;
                }
                set
                {
                    textEditor = value;
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
                    return scrollState;
                }
                set
                {
                    scrollState = value;
                }
            }
        }

        /// <summary>
        /// The MaxLengthReached event arguments.
        /// </summary>
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class MaxLengthReachedEventArgs : EventArgs
        {
            private TextEditor textEditor;

            /// <summary>
            /// TextEditor.
            /// </summary>
            /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public TextEditor TextEditor
            {
                get
                {
                    return textEditor;
                }
                set
                {
                    textEditor = value;
                }
            }
        }
    }
}

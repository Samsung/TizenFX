﻿/*
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
    /// A control which provides a single line editable text field.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class TextField
    {
        private EventHandler<TextChangedEventArgs> textFieldTextChangedEventHandler;
        private TextChangedCallbackDelegate textFieldTextChangedCallbackDelegate;
        private EventHandler<MaxLengthReachedEventArgs> textFieldMaxLengthReachedEventHandler;
        private MaxLengthReachedCallbackDelegate textFieldMaxLengthReachedCallbackDelegate;
        private EventHandler<AnchorClickedEventArgs> textFieldAnchorClickedEventHandler;
        private AnchorClickedCallbackDelegate textFieldAnchorClickedCallbackDelegate;

        private EventHandler<SelectionChangedEventArgs> textFieldSelectionChangedEventHandler;
        private SelectionChangedCallbackDelegate textFieldSelectionChangedCallbackDelegate;

        private EventHandler<InputFilteredEventArgs> textFieldInputFilteredEventHandler;
        private InputFilteredCallbackDelegate textFieldInputFilteredCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void TextChangedCallbackDelegate(IntPtr textField);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void MaxLengthReachedCallbackDelegate(IntPtr textField);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void AnchorClickedCallbackDelegate(IntPtr textField, IntPtr href, uint hrefLength);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void SelectionChangedCallbackDelegate(IntPtr textField, uint oldStart, uint oldEnd);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void InputFilteredCallbackDelegate(IntPtr textField, InputFilterType type);

        /// <summary>
        /// The TextChanged event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<TextChangedEventArgs> TextChanged
        {
            add
            {
                if (textFieldTextChangedEventHandler == null)
                {
                    textFieldTextChangedCallbackDelegate = (OnTextChanged);
                    TextChangedSignal().Connect(textFieldTextChangedCallbackDelegate);
                }
                textFieldTextChangedEventHandler += value;
            }
            remove
            {
                textFieldTextChangedEventHandler -= value;
                if (textFieldTextChangedEventHandler == null && TextChangedSignal().Empty() == false)
                {
                    TextChangedSignal().Disconnect(textFieldTextChangedCallbackDelegate);
                }
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
                if (textFieldMaxLengthReachedEventHandler == null)
                {
                    textFieldMaxLengthReachedCallbackDelegate = (OnMaxLengthReached);
                    MaxLengthReachedSignal().Connect(textFieldMaxLengthReachedCallbackDelegate);
                }
                textFieldMaxLengthReachedEventHandler += value;
            }
            remove
            {
                if (textFieldMaxLengthReachedEventHandler == null && MaxLengthReachedSignal().Empty() == false)
                {
                    this.MaxLengthReachedSignal().Disconnect(textFieldMaxLengthReachedCallbackDelegate);
                }
                textFieldMaxLengthReachedEventHandler -= value;
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
                if (textFieldAnchorClickedEventHandler == null)
                {
                    textFieldAnchorClickedCallbackDelegate = (OnAnchorClicked);
                    AnchorClickedSignal().Connect(textFieldAnchorClickedCallbackDelegate);
                }
                textFieldAnchorClickedEventHandler += value;
            }
            remove
            {
                textFieldAnchorClickedEventHandler -= value;
                if (textFieldAnchorClickedEventHandler == null && AnchorClickedSignal().Empty() == false)
                {
                    AnchorClickedSignal().Disconnect(textFieldAnchorClickedCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// The SelectionChanged event.
        /// </summary>
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<SelectionChangedEventArgs> SelectionChanged
        {
            add
            {
                if (textFieldSelectionChangedEventHandler == null)
                {
                    textFieldSelectionChangedCallbackDelegate = (OnSelectionChanged);
                    SelectionChangedSignal().Connect(textFieldSelectionChangedCallbackDelegate);
                }
                textFieldSelectionChangedEventHandler += value;
            }
            remove
            {
                if (textFieldSelectionChangedEventHandler == null && SelectionChangedSignal().Empty() == false)
                {
                    this.SelectionChangedSignal().Disconnect(textFieldSelectionChangedCallbackDelegate);
                }
                textFieldSelectionChangedEventHandler -= value;
            }
        }

        /// <summary>
        /// The InputFiltered signal is emitted when the input is filtered by InputFilter. <br />
        /// </summary>
        /// <remarks>
        /// See <see cref="InputFilterType"/> and <see cref="InputFilteredEventArgs"/> for a detailed description. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the InputFiltered event.
        /// <code>
        /// field.InputFiltered += (s, e) =>
        /// {
        ///     if (e.Type == InputFilterType.Accept)
        ///     {
        ///         // If input is filtered by InputFilter of Accept type.
        ///     }
        ///     else if (e.Type == InputFilterType.Reject)
        ///     {
        ///         // If input is filtered by InputFilter of Reject type.
        ///     }
        /// };
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<InputFilteredEventArgs> InputFiltered
        {
            add
            {
                if (textFieldInputFilteredEventHandler == null)
                {
                    textFieldInputFilteredCallbackDelegate = (OnInputFiltered);
                    InputFilteredSignal().Connect(textFieldInputFilteredCallbackDelegate);
                }
                textFieldInputFilteredEventHandler += value;
            }
            remove
            {
                textFieldInputFilteredEventHandler -= value;
                if (textFieldInputFilteredEventHandler == null && InputFilteredSignal().Empty() == false)
                {
                    InputFilteredSignal().Disconnect(textFieldInputFilteredCallbackDelegate);
                }
            }
        }

        internal TextFieldSignal TextChangedSignal()
        {
            TextFieldSignal ret = new TextFieldSignal(Interop.TextField.TextChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TextFieldSignal MaxLengthReachedSignal()
        {
            TextFieldSignal ret = new TextFieldSignal(Interop.TextField.MaxLengthReachedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TextFieldSignal AnchorClickedSignal()
        {
            TextFieldSignal ret = new TextFieldSignal(Interop.TextField.AnchorClickedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TextFieldSignal SelectionChangedSignal()
        {
            TextFieldSignal ret = new TextFieldSignal(Interop.TextField.SelectionChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TextFieldSignal InputFilteredSignal()
        {
            TextFieldSignal ret = new TextFieldSignal(Interop.TextField.InputFilteredSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void OnTextChanged(IntPtr textField)
        {
            if (textFieldTextChangedEventHandler != null)
            {
                TextChangedEventArgs e = new TextChangedEventArgs();

                // Populate all members of "e" (TextChangedEventArgs) with real data
                e.TextField = Registry.GetManagedBaseHandleFromNativePtr(textField) as TextField;
                //here we send all data to user event handlers
                textFieldTextChangedEventHandler(this, e);
            }
        }

        private void OnMaxLengthReached(IntPtr textField)
        {
            if (textFieldMaxLengthReachedEventHandler != null)
            {
                MaxLengthReachedEventArgs e = new MaxLengthReachedEventArgs();

                // Populate all members of "e" (MaxLengthReachedEventArgs) with real data
                e.TextField = Registry.GetManagedBaseHandleFromNativePtr(textField) as TextField;
                //here we send all data to user event handlers
                textFieldMaxLengthReachedEventHandler(this, e);
            }
        }

        private void OnAnchorClicked(IntPtr textField, IntPtr href, uint hrefLength)
        {
            // Note: hrefLength is useful for get the length of a const char* (href) in dali-toolkit.
            // But NUI can get the length of string (href), so hrefLength is not necessary in NUI.
            AnchorClickedEventArgs e = new AnchorClickedEventArgs();

            // Populate all members of "e" (AnchorClickedEventArgs) with real data
            e.Href = Marshal.PtrToStringAnsi(href);
            //here we send all data to user event handlers
            textFieldAnchorClickedEventHandler?.Invoke(this, e);
        }

        private void OnSelectionChanged(IntPtr textField, uint oldStart, uint oldEnd)
        {
            if (textFieldSelectionChangedEventHandler != null)
            {
                SelectionChangedEventArgs e = new SelectionChangedEventArgs();

                // Populate all members of "e" (SelectionChangedEventArgs) with real data
                e.OldSelectionStart = oldStart;
                e.OldSelectionEnd = oldEnd;

                //here we send all data to user event handlers
                textFieldSelectionChangedEventHandler?.Invoke(this, e);
            }
        }

        private void OnInputFiltered(IntPtr textField, InputFilterType type)
        {
            InputFilteredEventArgs e = new InputFilteredEventArgs();

            // Populate all members of "e" (InputFilteredEventArgs) with real data
            e.Type = type;
            //here we send all data to user event handlers
            textFieldInputFilteredEventHandler?.Invoke(this, e);
        }

        /// <summary>
        /// The TextChanged event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class TextChangedEventArgs : EventArgs
        {
            private TextField textField;

            /// <summary>
            /// TextField.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public TextField TextField
            {
                get
                {
                    return textField;
                }
                set
                {
                    textField = value;
                }
            }
        }

        /// <summary>
        /// The MaxLengthReached event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class MaxLengthReachedEventArgs : EventArgs
        {
            private TextField textField;

            /// <summary>
            /// TextField.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public TextField TextField
            {
                get
                {
                    return textField;
                }
                set
                {
                    textField = value;
                }
            }
        }
    }
}

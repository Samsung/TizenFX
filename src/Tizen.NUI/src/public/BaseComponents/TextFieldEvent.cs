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
    /// A control which provides a single line editable text field.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class TextField
    {
        private EventHandler<TextChangedEventArgs> _textFieldTextChangedEventHandler;
        private TextChangedCallbackDelegate _textFieldTextChangedCallbackDelegate;
        private EventHandler<MaxLengthReachedEventArgs> _textFieldMaxLengthReachedEventHandler;
        private MaxLengthReachedCallbackDelegate _textFieldMaxLengthReachedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void TextChangedCallbackDelegate(IntPtr textField);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void MaxLengthReachedCallbackDelegate(IntPtr textField);

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

        internal TextFieldSignal TextChangedSignal()
        {
            TextFieldSignal ret = new TextFieldSignal(Interop.TextField.TextField_TextChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TextFieldSignal MaxLengthReachedSignal()
        {
            TextFieldSignal ret = new TextFieldSignal(Interop.TextField.TextField_MaxLengthReachedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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
    }
}

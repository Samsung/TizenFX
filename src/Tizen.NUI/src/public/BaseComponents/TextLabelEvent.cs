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
    /// A control which renders a short text string.<br />
    /// Text labels are lightweight, non-editable, and do not respond to the user input.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class TextLabel
    {
        private EventHandler<AnchorClickedEventArgs> textLabelAnchorClickedEventHandler;
        private AnchorClickedCallbackDelegate textLabelAnchorClickedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void AnchorClickedCallbackDelegate(IntPtr textLabel, IntPtr href, uint hrefLength);

        /// <summary>
        /// The AnchorClicked signal is emitted when the anchor is clicked.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<AnchorClickedEventArgs> AnchorClicked
        {
            add
            {
                if (textLabelAnchorClickedEventHandler == null)
                {
                    textLabelAnchorClickedCallbackDelegate = (OnAnchorClicked);
                    AnchorClickedSignal().Connect(textLabelAnchorClickedCallbackDelegate);
                }
                textLabelAnchorClickedEventHandler += value;
            }
            remove
            {
                textLabelAnchorClickedEventHandler -= value;
                if (textLabelAnchorClickedEventHandler == null && AnchorClickedSignal().Empty() == false)
                {
                    AnchorClickedSignal().Disconnect(textLabelAnchorClickedCallbackDelegate);
                }
            }
        }

        internal TextLabelSignal AnchorClickedSignal()
        {
            TextLabelSignal ret = new TextLabelSignal(Interop.TextLabel.AnchorClickedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void OnAnchorClicked(IntPtr textLabel, IntPtr href, uint hrefLength)
        {
            // Note: hrefLength is useful for get the length of a const char* (href) in dali-toolkit.
            // But NUI can get the length of string (href), so hrefLength is not necessary in NUI.
            AnchorClickedEventArgs e = new AnchorClickedEventArgs();

            // Populate all members of "e" (AnchorClickedEventArgs) with real data
            e.Href = Marshal.PtrToStringAnsi(href);
            //here we send all data to user event handlers
            textLabelAnchorClickedEventHandler?.Invoke(this, e);
        }
    }
}

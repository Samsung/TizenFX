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
        private EventHandler<AnchorTouchedEventArgs> textLabelAnchorTouchedEventHandler;
        private AnchorTouchedCallbackDelegate textLabelAnchorTouchedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void AnchorTouchedCallbackDelegate(IntPtr textLabel, IntPtr href, uint hrefLength);

        /// <summary>
        /// The AnchorTouched signal is emitted when the anchor is touched.
        /// </summary>
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<AnchorTouchedEventArgs> AnchorTouched
        {
            add
            {
                if (textLabelAnchorTouchedEventHandler == null)
                {
                    textLabelAnchorTouchedCallbackDelegate = (OnAnchorTouched);
                    AnchorTouchedSignal().Connect(textLabelAnchorTouchedCallbackDelegate);
                }
                textLabelAnchorTouchedEventHandler += value;
            }
            remove
            {
                textLabelAnchorTouchedEventHandler -= value;
                if (textLabelAnchorTouchedEventHandler == null && AnchorTouchedSignal().Empty() == false)
                {
                    AnchorTouchedSignal().Disconnect(textLabelAnchorTouchedCallbackDelegate);
                }
            }
        }

        internal TextLabelSignal AnchorTouchedSignal()
        {
            TextLabelSignal ret = new TextLabelSignal(Interop.TextLabel.AnchorTouchedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void OnAnchorTouched(IntPtr textLabel, IntPtr href, uint hrefLength)
        {
            // Note: hrefLength is useful for get the length of a const char* (href) in dali-toolkit.
            // But NUI can get the length of string (href), so hrefLength is not necessary in NUI.
            AnchorTouchedEventArgs e = new AnchorTouchedEventArgs();

            // Populate all members of "e" (AnchorTouchedEventArgs) with real data
            e.Href = Marshal.PtrToStringAnsi(href);
            //here we send all data to user event handlers
            textLabelAnchorTouchedEventHandler?.Invoke(this, e);
        }
    }
}

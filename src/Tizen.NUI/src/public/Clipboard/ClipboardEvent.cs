/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// This specifies clipboard event data.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1815: Override equals and operator equals on value types")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct ClipEvent
    {
        /// <summary>
        /// The mime type of clipboard event data.
        /// </summary>
        public string MimeType { get; set; }
        /// <summary>
        /// The clipboard event data to receive.
        /// </summary>
        public string Data { get; set; }
    }

    /// <summary>
    /// ClipboardEventArgs is a class to record clipboard event arguments which will be sent to user.<br/>
    /// This is for internal use only.
    /// </summary>
    internal class ClipboardEventArgs : EventArgs
    {
        /// <summary>
        /// True if data receive is successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// The data request id to identify the response by request.
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Clipboard event data.
        /// </summary>
        public ClipEvent ClipEvent { get; set; }
    }

    /// <summary>
    /// Clipboard event.
    /// </summary>
    public partial class Clipboard
    {
        private EventHandler<ClipboardEventArgs> clipboardDataReceivedEventHandler;
        private ClipboardDataReceivedCallback clipboardDataReceivedCallback;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ClipboardDataReceivedCallback(uint id, string mimeType, string data);

        private event EventHandler<ClipboardEventArgs> ClipboardDataReceived
        {
            add
            {
                if (clipboardDataReceivedEventHandler == null)
                {
                    clipboardDataReceivedCallback = (OnClipboardDataReceived);
                    ClipboardDataReceivedSignal().Connect(clipboardDataReceivedCallback);
                }
                clipboardDataReceivedEventHandler += value;
            }
            remove
            {
                clipboardDataReceivedEventHandler -= value;
                if (clipboardDataReceivedEventHandler == null && ClipboardDataReceivedSignal().Empty() == false)
                {
                    ClipboardDataReceivedSignal().Disconnect(clipboardDataReceivedCallback);
                }
            }
        }

        internal ClipboardSignal ClipboardDataReceivedSignal()
        {
            var ret = new ClipboardSignal(Interop.Clipboard.ClipboardDataReceivedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void OnClipboardDataReceived(uint id, string mimeType, string data)
        {
            var e = new ClipboardEventArgs();
            var clipEvent = new ClipEvent()
            {
                MimeType = mimeType,
                Data = data,
            };
            e.ClipEvent = clipEvent;
            e.Id = id;
            e.Success = (String.IsNullOrEmpty(e.ClipEvent.MimeType) && String.IsNullOrEmpty(e.ClipEvent.Data)) ? false : true;

            clipboardDataReceivedEventHandler?.Invoke(this, e);
        }
    }
}

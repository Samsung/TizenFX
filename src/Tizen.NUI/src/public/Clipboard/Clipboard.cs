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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// Clipboard.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class Clipboard : BaseHandle
    {
        /// <summary>
        /// User callback for clipboard event.
        /// </summary>
        /// <remarks>
        /// Receives requested data through <see cref="Tizen.NUI.ClipEvent"/>.
        /// </remarks>
        public delegate void ClipboardCallback(bool success, ClipEvent clipEvent);

        internal bool hasClipboardDataReceived = false;
        internal Dictionary<uint, ClipboardCallback> receivedCallbackDictionary = new Dictionary<uint, ClipboardCallback>();

        private Clipboard() : this(Interop.Clipboard.Get(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private Clipboard(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Gets the singleton instance of Clipboard.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Clipboard Instance { get; } = new Clipboard();

        /// <summary>
        /// Request set the given data to the clipboard.
        /// </summary>
        /// <param name="mimeType">The mime type of the data.</param>
        /// <param name="data">The data to be set on the clipboard.</param>
        /// <returns>True if the internal clipboard sending request is successful.</returns>
        /// <example>
        /// The following example demonstrates how to use the SetData.
        /// <code>
        /// string MIME_TYPE_PLAIN_TEXT = "text/plain;charset=utf-8";
        /// Clipboard.Instance.SetData(MIME_TYPE_PLAIN_TEXT, "Hello Clipboard");
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SetData(string mimeType, string data)
        {
            bool setData = Interop.Clipboard.SetData(SwigCPtr, mimeType, data);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return setData;
        }

        /// <summary>
        /// Request get data of the specified mime type from clipboard<br/>
        /// and invokes the given callback with the received clipboard data.
        /// </summary>
        /// <param name="mimeType">The mime type of data to request.</param>
        /// <param name="dataReceivedCallback">The callback method to handle the received clipboard data.</param>
        /// <remarks>
        /// GetData() method is introduced to fetch data of the specified mime type,<br/>
        /// and it expects a callback function as a parameter.<br/>
        /// The given callback is invoked with received clipboard data.<br/>
        /// The callback is designed to be used only once for handling the data.
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the GetData and ClipboardCallback.
        /// <code>
        /// string MIME_TYPE_PLAIN_TEXT = "text/plain;charset=utf-8";
        /// Clipboard.Instance.GetData(MIME_TYPE_PLAIN_TEXT, OnClipboardDataReceived);
        /// ...
        /// public void OnClipboardDataReceived(bool success, ClipEvent clipEvent)
        /// {
        ///     if (!success) return;
        ///     string mimeType = clipEvent.MimeType;
        ///     string data = clipEvent.Data;
        /// }
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GetData(string mimeType, ClipboardCallback dataReceivedCallback)
        {
            if(!hasClipboardDataReceived)
            {
                ClipboardDataReceived += OnClipboardDataReceived;
                hasClipboardDataReceived = true;
            }

            uint id = Interop.Clipboard.GetData(SwigCPtr, mimeType);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if (id == 0)
            {
                // Calls the failure callback even if the request fails.
                var clipEvent = new ClipEvent()
                {
                    MimeType = string.Empty,
                    Data = string.Empty,
                };
                dataReceivedCallback(false, clipEvent);
            }
            else
            {
                receivedCallbackDictionary[id] = dataReceivedCallback;
            }
        }

        private void OnClipboardDataReceived(object sender, ClipboardEventArgs e)
        {
            if (!receivedCallbackDictionary.Any()) return;

            uint id = e.Id;
            if (receivedCallbackDictionary.ContainsKey(id))
            {
                ClipboardCallback callback = receivedCallbackDictionary[id];
                if (callback != null)
                {
                    callback(e.Success, e.ClipEvent);
                }
                receivedCallbackDictionary.Remove(id);
            }
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

            if (hasClipboardDataReceived)
            {
                ClipboardDataReceived -= OnClipboardDataReceived;
                receivedCallbackDictionary.Clear();
            }

            if (this.HasBody())
            {
                if (clipboardDataReceivedCallback != null)
                {
                    this.ClipboardDataReceivedSignal().Disconnect(clipboardDataReceivedCallback);
                }
            }

            base.Dispose(type);
        }
    }
}

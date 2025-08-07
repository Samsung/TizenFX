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

        private EventHandler textLabelTextFitChangedEventHandler;
        private TextFitChangedCallbackDelegate textLabelTextFitChangedCallbackDelegate;

        private EventHandler<AsyncTextRenderedEventArgs> textLabelAsyncTextRenderedEventHandler;
        private AsyncTextRenderedCallbackDelegate textLabelAsyncTextRenderedCallbackDelegate;

        private EventHandler<AsyncTextSizeComputedEventArgs> textLabelAsyncNaturalSizeComputedEventHandler;
        private AsyncNaturalSizeComputedCallbackDelegate textLabelAsyncNaturalSizeComputedCallbackDelegate;

        private EventHandler<AsyncTextSizeComputedEventArgs> textLabelAsyncHeightForWidthComputedEventHandler;
        private AsyncHeightForWidthComputedCallbackDelegate textLabelAsyncHeightForWidthComputedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void AnchorClickedCallbackDelegate(IntPtr textLabel, IntPtr href, uint hrefLength);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void TextFitChangedCallbackDelegate(IntPtr textLabel);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void AsyncTextRenderedCallbackDelegate(IntPtr textLabel, float width, float height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void AsyncNaturalSizeComputedCallbackDelegate(IntPtr textLabel, float width, float height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void AsyncHeightForWidthComputedCallbackDelegate(IntPtr textLabel, float width, float height);


        /// <summary>
        /// The AsyncHeightForWidthComputed signal is emitted when the async natural size computed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<AsyncTextSizeComputedEventArgs> AsyncHeightForWidthComputed
        {
            add
            {
                if (textLabelAsyncHeightForWidthComputedEventHandler == null)
                {
                    textLabelAsyncHeightForWidthComputedCallbackDelegate = OnAsyncHeightForWidthComputed;
                    Interop.TextLabel.AsyncHeightForWidthComputedConnect(SwigCPtr, textLabelAsyncHeightForWidthComputedCallbackDelegate.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                textLabelAsyncHeightForWidthComputedEventHandler += value;
            }
            remove
            {
                textLabelAsyncHeightForWidthComputedEventHandler -= value;
                if (textLabelAsyncHeightForWidthComputedEventHandler == null && textLabelAsyncHeightForWidthComputedCallbackDelegate != null)
                {
                    Interop.TextLabel.AsyncHeightForWidthComputedDisconnect(SwigCPtr, textLabelAsyncHeightForWidthComputedCallbackDelegate.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    textLabelAsyncHeightForWidthComputedCallbackDelegate = null;
                }
            }
        }

        private void OnAsyncHeightForWidthComputed(IntPtr textLabel, float width, float height)
        {
            if (Disposed || IsDisposeQueued)
            {
                // Ignore native callback if the view is disposed or queued for disposal.
                return;
            }

            AsyncTextSizeComputedEventArgs e = new AsyncTextSizeComputedEventArgs(width, height);

            if (textLabelAsyncHeightForWidthComputedEventHandler != null)
            {
                textLabelAsyncHeightForWidthComputedEventHandler(this, e);
            }
        }

        /// <summary>
        /// The AsyncNaturalSizeComputed signal is emitted when the async natural size computed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<AsyncTextSizeComputedEventArgs> AsyncNaturalSizeComputed
        {
            add
            {
                if (textLabelAsyncNaturalSizeComputedEventHandler == null)
                {
                    textLabelAsyncNaturalSizeComputedCallbackDelegate = OnAsyncNaturalSizeComputed;
                    Interop.TextLabel.AsyncNaturalSizeComputedConnect(SwigCPtr, textLabelAsyncNaturalSizeComputedCallbackDelegate.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                textLabelAsyncNaturalSizeComputedEventHandler += value;
            }
            remove
            {
                textLabelAsyncNaturalSizeComputedEventHandler -= value;
                if (textLabelAsyncNaturalSizeComputedEventHandler == null && textLabelAsyncNaturalSizeComputedCallbackDelegate != null)
                {
                    Interop.TextLabel.AsyncNaturalSizeComputedDisconnect(SwigCPtr, textLabelAsyncNaturalSizeComputedCallbackDelegate.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    textLabelAsyncNaturalSizeComputedCallbackDelegate = null;
                }
            }
        }

        private void OnAsyncNaturalSizeComputed(IntPtr textLabel, float width, float height)
        {
            if (Disposed || IsDisposeQueued)
            {
                // Ignore native callback if the view is disposed or queued for disposal.
                return;
            }

            AsyncTextSizeComputedEventArgs e = new AsyncTextSizeComputedEventArgs(width, height);

            if (textLabelAsyncNaturalSizeComputedEventHandler != null)
            {
                textLabelAsyncNaturalSizeComputedEventHandler(this, e);
            }
        }

        /// <summary>
        /// The AsyncTextRendered signal is emitted when the async text rendered.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<AsyncTextRenderedEventArgs> AsyncTextRendered
        {
            add
            {
                if (textLabelAsyncTextRenderedEventHandler == null)
                {
                    textLabelAsyncTextRenderedCallbackDelegate = OnAsyncTextRendered;
                    Interop.TextLabel.AsyncTextRenderedConnect(SwigCPtr, textLabelAsyncTextRenderedCallbackDelegate.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                textLabelAsyncTextRenderedEventHandler += value;
            }
            remove
            {
                textLabelAsyncTextRenderedEventHandler -= value;
                if (textLabelAsyncTextRenderedEventHandler == null && textLabelAsyncTextRenderedCallbackDelegate != null)
                {
                    Interop.TextLabel.AsyncTextRenderedDisconnect(SwigCPtr, textLabelAsyncTextRenderedCallbackDelegate.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    textLabelAsyncTextRenderedCallbackDelegate = null;
                }
            }
        }

        private void OnAsyncTextRendered(IntPtr textLabel, float width, float height)
        {
            if (Disposed || IsDisposeQueued)
            {
                // Ignore native callback if the view is disposed or queued for disposal.
                return;
            }

            AsyncTextRenderedEventArgs e = new AsyncTextRenderedEventArgs(width, height);

            if (textLabelAsyncTextRenderedEventHandler != null)
            {
                textLabelAsyncTextRenderedEventHandler(this, e);
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
                if (textLabelAnchorClickedEventHandler == null)
                {
                    textLabelAnchorClickedCallbackDelegate = (OnAnchorClicked);
                    using var signal = AnchorClickedSignal();
                    signal.Connect(textLabelAnchorClickedCallbackDelegate);
                }
                textLabelAnchorClickedEventHandler += value;
            }
            remove
            {
                textLabelAnchorClickedEventHandler -= value;
                using var signal = AnchorClickedSignal();
                if (textLabelAnchorClickedEventHandler == null && signal.Empty() == false)
                {
                    signal.Disconnect(textLabelAnchorClickedCallbackDelegate);
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
            if (Disposed || IsDisposeQueued)
            {
                // Ignore native callback if the view is disposed or queued for disposal.
                return;
            }

            // Note: hrefLength is useful for get the length of a const char* (href) in dali-toolkit.
            // But NUI can get the length of string (href), so hrefLength is not necessary in NUI.
            AnchorClickedEventArgs e = new AnchorClickedEventArgs();

            // Populate all members of "e" (AnchorClickedEventArgs) with real data
            e.Href = Marshal.PtrToStringAnsi(href);
            //here we send all data to user event handlers
            textLabelAnchorClickedEventHandler?.Invoke(this, e);
        }

        /// <summary>
        /// An event for the TextFitChanged signal which can be used to subscribe or unsubscribe the event handler
        /// provided by the user. The TextFitChanged signal is emitted when the text fit properties changes.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler TextFitChanged
        {
            add
            {
                if (textLabelTextFitChangedEventHandler == null)
                {
                    textLabelTextFitChangedCallbackDelegate = (OnTextFitChanged);
                    using var signal = TextFitChangedSignal();
                    signal.Connect(textLabelTextFitChangedCallbackDelegate);
                }
                textLabelTextFitChangedEventHandler += value;
            }
            remove
            {
                textLabelTextFitChangedEventHandler -= value;
                using var signal = TextFitChangedSignal();
                if (textLabelTextFitChangedEventHandler == null && signal.Empty() == false)
                {
                    signal.Disconnect(textLabelTextFitChangedCallbackDelegate);
                }
            }
        }

        internal TextLabelSignal TextFitChangedSignal()
        {
            TextLabelSignal ret = new TextLabelSignal(Interop.TextLabel.TextFitChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void OnTextFitChanged(IntPtr textLabel)
        {
            if (Disposed || IsDisposeQueued)
            {
                // Ignore native callback if the view is disposed or queued for disposal.
                return;
            }

            // no data to be sent to the user, as in NUI there is no event provide old values.
            textLabelTextFitChangedEventHandler?.Invoke(this, EventArgs.Empty);
        }
    }
}

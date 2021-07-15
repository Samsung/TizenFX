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

using System.ComponentModel;

namespace Tizen.NUI
{
    using global::System;

    /// <summary>
    /// NativeImageQueue is a class for displaying an image resource using queue.
    /// </summary>
    /// <example>
    /// <code>
    /// NativeImageQueue queue = new NativeImageQueue(width,height,ColorDepth.Default);
    /// if(queue.CanDequeueBuffer())
    /// {
    ///   var buffer = queue.DequeueBuffer(ref bufferWidth,ref bufferHeight,ref bufferStride);
    ///
    ///   /* Use buffer */
    ///
    ///   queue.EnqueueBuffer(buffer);
    /// }
    /// </code>
    /// </example>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NativeImageQueue : NativeImageInterface
    {
        private IntPtr handle;

        /// <summary>
        /// Creates an initialized NativeImageQueue with size and color depth.
        /// </summary>
        /// <param name="width">A Width of queue.</param>
        /// <param name="height">A Height of queue.</param>
        /// <param name="depth">A color depth of queue.</param>
        /// <returns>A NativeImageQueue.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NativeImageQueue(uint width, uint height, NativeImageSource.ColorDepth depth) : this(Interop.NativeImageQueue.NewHandle(width, height, (int)depth), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal NativeImageQueue(IntPtr cPtr, bool cMemoryOwn) : base(Interop.NativeImageQueue.Get(cPtr), cMemoryOwn)
        {
            handle = cPtr;
        }

        /// <summary>
        /// Generate Url from native image queue.
        /// </summary>
        /// <returns>The ImageUrl of NativeImageQueue.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageUrl GenerateUrl()
        {
            ImageUrl ret = new ImageUrl(Interop.NativeImageSource.GenerateUrl(this.SwigCPtr.Handle), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.NativeImageQueue.Delete(handle);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(NativeImageQueue obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// <summary>
        /// Checks if the buffer can be got from the queue.
        /// </summary>
        /// <returns>True if the buffer can be got from the queue.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanDequeueBuffer()
        {
            bool ret = Interop.NativeImageQueue.CanDequeueBuffer(this.SwigCPtr.Handle);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Dequeue buffer from the queue.
        /// </summary>
        /// <param name="width">A reference to the buffer's width.</param>
        /// <param name="height">A reference to the buffer's height.</param>
        /// <param name="stride">A reference to the buffer's stride.</param>
        /// <returns>A handle of buffer.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IntPtr DequeueBuffer(ref int width, ref int height, ref int stride)
        {
            IntPtr ret = Interop.NativeImageQueue.DequeueBuffer(this.SwigCPtr.Handle, ref width, ref height, ref stride);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Enqueue buffer to the queue.
        /// </summary>
        /// <param name="buffer">A Handle of buffer to be enqueued.</param>
        /// <returns>True if success.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnqueueBuffer(IntPtr buffer)
        {
            bool ret = Interop.NativeImageQueue.EnqueueBuffer(this.SwigCPtr.Handle, buffer);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}

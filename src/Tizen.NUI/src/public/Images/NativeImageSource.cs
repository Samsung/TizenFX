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
    /// NativeImageSource is a class for displaying an native image resource.
    /// </summary>
    /// <example>
    /// <code>
    /// NativeImageSource surface = new NativeImageSource(width, height, ColorDepth.Default);
    ///
    /// var buffer = surface.AcquireBuffer(ref bufferWidth, ref bufferHeight, ref bufferStride);
    ///
    /// /* Use buffer */
    ///
    /// surface.ReleaseBuffer();
    ///
    /// ImageUrl imageUrl = surface.GenerateUrl();
    /// ImageView view = new ImageView(imageUrl.ToString());
    /// </code>
    /// </example>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NativeImageSource : NativeImageInterface
    {
        private IntPtr handle;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public NativeImageSource(uint width, uint height, ColorDepth depth) : this(Interop.NativeImageSource.NewHandle(width, height, (int)depth), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal NativeImageSource(IntPtr cPtr, bool cMemoryOwn) : base(Interop.NativeImageSource.New(cPtr), cMemoryOwn)
        {
            handle = cPtr;
        }

        /// <summary>
        /// Generate Url from native image source.
        /// </summary>
        /// <remarks>
        /// This API should not be called at worker thread.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageUrl GenerateUrl()
        {
            return GenerateUrl(false);
        }

        /// <summary>
        /// Generate Url from native image source with pre-multiplied by alpha information.
        /// </summary>
        /// <remarks>
        /// This API should not be called at worker thread.
        /// </remarks>
        /// <param name="preMultiplied">The raw pixel data pre-multiplied by alpha.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageUrl GenerateUrl(bool preMultiplied)
        {
            ImageUrl ret = new ImageUrl(Interop.NativeImageQueue.GenerateUrl(this.SwigCPtr.Handle, preMultiplied), true);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.NativeImageSource.Delete(handle);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ColorDepth
        {
            Default,
            Bits8,
            Bits16,
            Bits24,
            Bits32,
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IntPtr AcquireBuffer(ref int width, ref int height, ref int stride)
        {
            IntPtr ret = Interop.NativeImageSource.AcquireBuffer(this.SwigCPtr.Handle, ref width, ref height, ref stride);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ReleaseBuffer()
        {
            bool ret = Interop.NativeImageSource.ReleaseBuffer(this.SwigCPtr.Handle);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}

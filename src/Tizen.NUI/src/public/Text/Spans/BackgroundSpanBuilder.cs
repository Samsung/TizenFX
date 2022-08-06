/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Text.Spans
{
    /// <summary>
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class BackgroundSpanBuilder : Disposable
    {

        /// <summary>
        /// Creates a new BackgroundSpanBuilder object<br />
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BackgroundSpanBuilder Initialize( )
        {
            BackgroundSpanBuilder ret = new BackgroundSpanBuilder(Interop.BackgroundSpanBuilder.Initialize( ), true);
            return ret;
        }

        internal BackgroundSpanBuilder(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Create an instance for color-span<br />
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BackgroundSpan Build( )
        {
            BackgroundSpan ret = new BackgroundSpan(Interop.BackgroundSpanBuilder.Build(SwigCPtr), true);
            return ret;
        }

        /// <summary>
        /// Set fore color for span<br />
        /// </summary>
        /// <param name="color">The fore color</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BackgroundSpanBuilder WithBackgroundColor(Color color)
        {
            BackgroundSpanBuilder ret = new BackgroundSpanBuilder(Interop.BackgroundSpanBuilder.WithBackgroundColor(SwigCPtr,Vector4.getCPtr(color)), true);
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.BackgroundSpanBuilder.DeleteBackgroundSpanBuilder(swigCPtr);
        }

    }
}

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
    public class UnderlineSpanBuilder : Disposable
    {

        /// <summary>
        /// Creates a new UnderlineSpanBuilder object<br />
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static UnderlineSpanBuilder Initialize( )
        {
            UnderlineSpanBuilder ret = new UnderlineSpanBuilder(Interop.UnderlineSpanBuilder.Initialize( ), true);
            return ret;
        }

        internal UnderlineSpanBuilder(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Create an instance for underline-span<br />
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnderlineSpan Build( )
        {
            UnderlineSpan ret = new UnderlineSpan(Interop.UnderlineSpanBuilder.Build(SwigCPtr), true);
            return ret;
        }

        /// <summary>
        /// Set type of underline for span<br />
        /// </summary>
        /// <param name="type">The type of underline</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnderlineSpanBuilder WithUnderlineType(UnderlineType type)
        {
            UnderlineSpanBuilder ret = new UnderlineSpanBuilder(Interop.UnderlineSpanBuilder.WithUnderlineType(SwigCPtr,(int)type), true);
            return ret;
        }

        /// <summary>
        /// Set color of underline for span<br />
        /// </summary>
        /// <param name="color">The underline color</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnderlineSpanBuilder WithUnderlineColor(Color color)
        {
            UnderlineSpanBuilder ret = new UnderlineSpanBuilder(Interop.UnderlineSpanBuilder.WithUnderlineColor(SwigCPtr,Vector4.getCPtr(color)), true);
            return ret;
        }

        /// <summary>
        /// Set height of underline for span<br />
        /// </summary>
        /// <param name="height">The fore color</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnderlineSpanBuilder WithUnderlineHeight(float height)
        {
            UnderlineSpanBuilder ret = new UnderlineSpanBuilder(Interop.UnderlineSpanBuilder.WithUnderlineHeight(SwigCPtr,height), true);
            return ret;
        }

        /// <summary>
        /// Set dash-gap of the dashed underline for span<br />
        /// </summary>
        /// <param name="dashGap">The dash-gap of the dashed underline</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnderlineSpanBuilder WithUnderlineDashGap(float dashGap)
        {
            UnderlineSpanBuilder ret = new UnderlineSpanBuilder(Interop.UnderlineSpanBuilder.WithUnderlineDashGap(SwigCPtr,dashGap), true);
            return ret;
        }

        /// <summary>
        /// Set dash-width of the dashed underline for span<br />
        /// </summary>
        /// <param name="dashWidth">The dash-width of the dashed underline</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnderlineSpanBuilder WithUnderlineDashWidth(float dashWidth)
        {
            UnderlineSpanBuilder ret = new UnderlineSpanBuilder(Interop.UnderlineSpanBuilder.WithUnderlineDashWidth(SwigCPtr,dashWidth), true);
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.UnderlineSpanBuilder.DeleteUnderlineSpanBuilder(swigCPtr);
        }

    }
}

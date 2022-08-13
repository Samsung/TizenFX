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
    public class FontSpanBuilder : Disposable
    {

        /// <summary>
        /// Creates a new FontSpanBuilder object<br />
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FontSpanBuilder Initialize( )
        {
            FontSpanBuilder ret = new FontSpanBuilder(Interop.FontSpanBuilder.Initialize( ), true);
            return ret;
        }

        internal FontSpanBuilder(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Create an instance for font-span<br />
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FontSpan Build( )
        {
            FontSpan ret = new FontSpan(Interop.FontSpanBuilder.Build(SwigCPtr), true);
            return ret;
        }

        /// <summary>
        /// Set font family name for span<br />
        /// </summary>
        /// <param name="familyName">The family name</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FontSpanBuilder WithFamilyName(string familyName)
        {
            FontSpanBuilder ret = new FontSpanBuilder(Interop.FontSpanBuilder.WithFamilyName(SwigCPtr,familyName), true);
            return ret;
        }

        /// <summary>
        /// Set font weight for span<br />
        /// </summary>
        /// <param name="weight">The font weight</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FontSpanBuilder WithFontWeight(FontWeightType weight)
        {
            FontSpanBuilder ret = new FontSpanBuilder(Interop.FontSpanBuilder.WithFontWeight(SwigCPtr,(int)weight), true);
            return ret;
        }

        /// <summary>
        /// Set font width for span<br />
        /// </summary>
        /// <param name="width">The font width</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FontSpanBuilder WithFontWidth(FontWidthType width)
        {
            FontSpanBuilder ret = new FontSpanBuilder(Interop.FontSpanBuilder.WithFontWidth(SwigCPtr,(int)width), true);
            return ret;
        }

        /// <summary>
        /// Set font slant for span<br />
        /// </summary>
        /// <param name="slant">The font slant</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FontSpanBuilder WithFontSlant(FontSlantType slant)
        {
            FontSpanBuilder ret = new FontSpanBuilder(Interop.FontSpanBuilder.WithFontSlant(SwigCPtr,(int)slant), true);
            return ret;
        }

        /// <summary>
        /// Set font size for span<br />
        /// </summary>
        /// <param name="size">The font size</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FontSpanBuilder WithFontSize(float size)
        {
            FontSpanBuilder ret = new FontSpanBuilder(Interop.FontSpanBuilder.WithFontSize(SwigCPtr,size), true);
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.FontSpanBuilder.DeleteFontSpanBuilder(swigCPtr);
        }

    }
}

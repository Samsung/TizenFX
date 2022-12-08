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
    public class ItalicSpan : BaseSpan
    {
        /// <summary>
        /// Create italic span for a range of text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ItalicSpan Create()
        {
            ItalicSpan span = new ItalicSpan(Interop.ItalicSpan.New(), true);
            return span;
        }

        internal ItalicSpan(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Delete an italic span.
        /// </summary>
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ItalicSpan.Delete(swigCPtr);
        }

    }
 }
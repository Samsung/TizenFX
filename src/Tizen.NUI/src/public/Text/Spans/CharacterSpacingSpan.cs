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
    public class CharacterSpacingSpan : BaseSpan
    {

        /// <summary>
        /// Create character spacing span Set and set character spacing for it.<br />
        /// </summary>
        /// <param name="characterSpacing">The spacing betweeen the charactersin the text.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CharacterSpacingSpan Create(float characterSpacing)
        {
            CharacterSpacingSpan span = new CharacterSpacingSpan(Interop.CharacterSpacingSpan.New(characterSpacing), true);
            return span;
        }

        internal CharacterSpacingSpan(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The characterSpacing in the span.
        /// </summary>
        /// This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float CharacterSpacing
        {
            get
            {
                float characterSpacing = (float)(Interop.CharacterSpacingSpan.GetCharacterSpacing(SwigCPtr));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return characterSpacing;
            }
        }

        /// <summary>
        /// Whether the character spacing is defined.
        /// </summary>
        /// This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool HasCharacterSpacing
        {
            get
            {
                bool isDefined = Interop.CharacterSpacingSpan.IsCharacterSpacingDefined(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return isDefined;
            }
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.CharacterSpacingSpan.DeleteCharacterSpacingSpan(swigCPtr);
        }
    }
 }
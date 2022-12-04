/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Text
{
    /// <summary>
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class TextSpannable
    {

        private static void CheckSWIGPendingException()
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Set the spannedText into textLabel. <br />
        /// the spanned text contains content (text) and format (spans with ranges). <br />
        /// the text is copied into text-controller and the spans are applied on ranges. <br />
        /// </summary>
        /// <note>
        /// The TEXT in textLabel will be replaced with text from spannedText
        /// and all the applied styles textLabel will be replaced the styles from spannedText
        /// in-case there are styles were applied from markup-processor will be removed
        /// </note>
        /// <param name="textLabel"> The instance of TextLabel.</param>
        /// <param name="spannedText">The text with spans.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetSpannedText(TextLabel textLabel, Spanned spannedText)
        {
            if (textLabel == null)
            {
                throw new ArgumentNullException(null, "textLabel object is null");
            }

            Interop.TextSpannable.SetSpannedTextIntoTextLabel(textLabel.SwigCPtr, spannedText.SwigCPtr);
            CheckSWIGPendingException();
        }

        /// <summary>
        /// Set the spannedText into textField. <br />
        /// the spanned text contains content (text) and format (spans with ranges). <br />
        /// the text is copied into text-controller and the spans are applied on ranges. <br />
        /// </summary>
        /// <note>
        /// The TEXT in textField will be replaced with text from spannedText
        /// and all the applied styles textField will be replaced the styles from spannedText
        /// in-case there are styles were applied from markup-processor will be removed
        /// </note>
        /// <param name="textField"> The instance of TextField.</param>
        /// <param name="spannedText">The text with spans.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetSpannedText(TextField textField, Spanned spannedText)
        {
            if (textField == null)
            {
                throw new ArgumentNullException(null, "textField object is null");
            }

            Interop.TextSpannable.SetSpannedTextIntoTextField(textField.SwigCPtr, spannedText.SwigCPtr);
            CheckSWIGPendingException();
        }

        /// <summary>
        /// Set the spannedText into textEditor. <br />
        /// the spanned text contains content (text) and format (spans with ranges). <br />
        /// the text is copied into text-controller and the spans are applied on ranges. <br />
        /// </summary>
        /// <note>
        /// The TEXT in textEditor will be replaced with text from spannedText
        /// and all the applied styles textEditor will be replaced the styles from spannedText
        /// in-case there are styles were applied from markup-processor will be removed
        /// </note>
        /// <param name="textEditor"> The instance of TextEditor.</param>
        /// <param name="spannedText">The text with spans.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetSpannedText(TextEditor textEditor, Spanned spannedText)
        {
            if (textEditor == null)
            {
                throw new ArgumentNullException(null, "textEditor object is null");
            }

            Interop.TextSpannable.SetSpannedTextIntoTextEditor(textEditor.SwigCPtr, spannedText.SwigCPtr);
            CheckSWIGPendingException();
        }

    }
}

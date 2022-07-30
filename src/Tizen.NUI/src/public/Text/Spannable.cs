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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Text.Spans;

namespace Tizen.NUI.Text
{
    /// <summary>
    /// Spans are markup objects that can be attached to and detached from text.
    /// They can be applied to whole paragraphs or to parts of the text.
    /// The style is changed dynamically on parts of the text.
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class Spannable
    {


        private static void ValidateRange(int start, int end)
        {
            if (start < 0)
                throw new global::System.ArgumentOutOfRangeException(nameof(start), "Value is less than zero");
            if (end < 0)
                throw new global::System.ArgumentOutOfRangeException(nameof(end), "Value is less than zero");
        }

        private static void CheckSWIGPendingException()
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Apply the given span on the given range of text.<br />
        /// </summary>
        /// <param name="textLabel">The TextLabel control containing the text.</param>
        /// <param name="span">TThe span of style to apply it on text from startIndex to endIndex</param>
        /// <param name="startIndex">The start index of the text to apply span (included)</param>
        /// <param name="endIndex">The end index of the text  The end index to apply span (included)</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void AttachSpan(TextLabel textLabel, BaseSpan span, int startIndex, int endIndex)
        {
            if (textLabel == null)
            {
                throw new ArgumentNullException(null, "textLabel object is null");
            }

            if (span == null)
            {
                throw new ArgumentNullException(null, "span object is null");
            }

            ValidateRange(startIndex, endIndex);

            Interop.Spannable.TextLabel.AttachSpan(textLabel.SwigCPtr,span.SwigCPtr, (uint)startIndex, (uint)endIndex);
            CheckSWIGPendingException();
        }


        /// <summary>
        /// Un-apply the given SpanStyle on all ranges of text.<br />
        /// </summary>
        /// <param name="textLabel">The TextLabel control containing the text.</param>
        /// <param name="span">TThe span of style to apply it on text from startIndex to endIndex</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void DetachSpan(TextLabel textLabel, BaseSpan span)
        {
            if (textLabel == null)
            {
                throw new ArgumentNullException(null, "textLabel object is null");
            }

            if (span == null)
            {
                throw new ArgumentNullException(null, "span object is null");
            }

            Interop.Spannable.TextLabel.DetachSpan(textLabel.SwigCPtr,span.SwigCPtr);
            CheckSWIGPendingException();
        }

        /// <summary>
        /// Apply the attached style tags on text ranges.<br />
        /// </summary>
        /// <param name="textLabel">The TextLabel control containing the text.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void BuildSpannedText(TextLabel textLabel)
        {
            if (textLabel == null)
            {
                throw new ArgumentNullException(null, "textLabel object is null");
            }

            Interop.Spannable.TextLabel.BuildSpannedText(textLabel.SwigCPtr);
            CheckSWIGPendingException();
        }


        /// <summary>
        /// Apply the given span on the given range of text.<br />
        /// </summary>
        /// <param name="textField">The TextField control containing the text.</param>
        /// <param name="span">TThe span of style to apply it on text from startIndex to endIndex</param>
        /// <param name="startIndex">The start index of the text to apply span (included)</param>
        /// <param name="endIndex">The end index of the text  The end index to apply span (included)</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void AttachSpan(TextField textField, BaseSpan span, int startIndex, int endIndex)
        {
            if (textField == null)
            {
                throw new ArgumentNullException(null, "textField object is null");
            }

            if (span == null)
            {
                throw new ArgumentNullException(null, "span object is null");
            }

            ValidateRange(startIndex, endIndex);

            Interop.Spannable.TextField.AttachSpan(textField.SwigCPtr,span.SwigCPtr, (uint)startIndex, (uint)endIndex);
            CheckSWIGPendingException();
        }


        /// <summary>
        /// Un-apply the given SpanStyle on all ranges of text.<br />
        /// </summary>
        /// <param name="textField">The TextField control containing the text.</param>
        /// <param name="span">TThe span of style to apply it on text from startIndex to endIndex</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void DetachSpan(TextField textField, BaseSpan span)
        {
            if (textField == null)
            {
                throw new ArgumentNullException(null, "textField object is null");
            }

            if (span == null)
            {
                throw new ArgumentNullException(null, "span object is null");
            }

            Interop.Spannable.TextField.DetachSpan(textField.SwigCPtr,span.SwigCPtr);
            CheckSWIGPendingException();
        }

        /// <summary>
        /// Apply the attached style tags on text ranges.<br />
        /// </summary>
        /// <param name="textField">The TextField control containing the text.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void BuildSpannedText(TextField textField)
        {
            if (textField == null)
            {
                throw new ArgumentNullException(null, "textField object is null");
            }

            Interop.Spannable.TextField.BuildSpannedText(textField.SwigCPtr);
            CheckSWIGPendingException();
        }


        /// <summary>
        /// Apply the given span on the given range of text.<br />
        /// </summary>
        /// <param name="textEditor">The TextEditor control containing the text.</param>
        /// <param name="span">TThe span of style to apply it on text from startIndex to endIndex</param>
        /// <param name="startIndex">The start index of the text to apply span (included)</param>
        /// <param name="endIndex">The end index of the text  The end index to apply span (included)</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void AttachSpan(TextEditor textEditor, BaseSpan span, int startIndex, int endIndex)
        {
            if (textEditor == null)
            {
                throw new ArgumentNullException(null, "textEditor object is null");
            }

            if (span == null)
            {
                throw new ArgumentNullException(null, "span object is null");
            }

            ValidateRange(startIndex, endIndex);

            Interop.Spannable.TextEditor.AttachSpan(textEditor.SwigCPtr,span.SwigCPtr, (uint)startIndex, (uint)endIndex);
            CheckSWIGPendingException();
        }


        /// <summary>
        /// Un-apply the given SpanStyle on all ranges of text.<br />
        /// </summary>
        /// <param name="textEditor">The TextEditor control containing the text.</param>
        /// <param name="span">TThe span of style to apply it on text from startIndex to endIndex</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void DetachSpan(TextEditor textEditor, BaseSpan span)
        {
            if (textEditor == null)
            {
                throw new ArgumentNullException(null, "textEditor object is null");
            }

            if (span == null)
            {
                throw new ArgumentNullException(null, "span object is null");
            }

            Interop.Spannable.TextEditor.DetachSpan(textEditor.SwigCPtr,span.SwigCPtr);
            CheckSWIGPendingException();
        }

        /// <summary>
        /// Apply the attached style tags on text ranges.<br />
        /// </summary>
        /// <param name="textEditor">The TextField control containing the text.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void BuildSpannedText(TextEditor textEditor)
        {
            if (textEditor == null)
            {
                throw new ArgumentNullException(null, "textEditor object is null");
            }

            Interop.Spannable.TextEditor.BuildSpannedText(textEditor.SwigCPtr);
            CheckSWIGPendingException();
        }

    }
}

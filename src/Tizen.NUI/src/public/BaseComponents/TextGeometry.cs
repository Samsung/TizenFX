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
using Tizen.NUI.Text;
using System.Collections.Generic;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class TextGeometry
    {
        private static void ValidateRange(int start, int end)
        {
            if (start < 0)
                throw new global::System.ArgumentOutOfRangeException(nameof(start), "Value is less than zero");
            if (end < 0)
                throw new global::System.ArgumentOutOfRangeException(nameof(end), "Value is less than zero");
        }

        private static List<Size2D> GetSizeListFromNativeVector(System.IntPtr ptr)
        {
            using (VectorVector2 sizeVector = new VectorVector2 (ptr, true))
            {
                int count = sizeVector.Size();
                List<Size2D> list = new List<Size2D>();

                for(int i = 0; i < count; i++)
                    list.Add(sizeVector.ValueOfIndex( (uint)i ));

                return list;
            }
        }

        private static List<Position2D> GetPositionListFromNativeVector(System.IntPtr ptr)
        {
            using (VectorVector2 positionVector = new VectorVector2 (ptr, true))
            {
                int count = positionVector.Size();
                List<Position2D> list = new List<Position2D>();

                for(int i = 0; i < count; i++)
                    list.Add(positionVector.ValueOfIndex( (uint)i ));

                return list;
            }
        }

        private static void CheckSWIGPendingException()
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get the rendered size of the text between start and end (included). <br />
        /// if the requested text is at multilines, multiple sizes will be returned for each text located in a separate line. <br />
        /// if a line contains characters with different directions, multiple sizes will be returned for each block of contiguous characters with the same direction. <br />
        /// </summary>
        /// <param name="textEditor">The TextEditor control containing the text.</param>
        /// <param name="start">The start index of the text to get the size for</param>
        /// <param name="end">The end index of the text to get the size for.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static List<Size2D> GetTextSize(TextEditor textEditor, int start, int end)
        {
            if (textEditor == null)
            {
                throw new ArgumentNullException(null, "textEditor object is null");
            }

            ValidateRange(start, end);

            List<Size2D> list = GetSizeListFromNativeVector(Interop.TextEditor.GetTextSize(textEditor.SwigCPtr, (uint)start, (uint)end));
            CheckSWIGPendingException();
            return list;
        }

        /// <summary>
        /// Get the rendered size of the text between start and end (included). <br />
        /// if the requested text is at multilines, multiple sizes will be returned for each text located in a separate line. <br />
        /// if a line contains characters with different directions, multiple sizes will be returned for each block of contiguous characters with the same direction. <br />
        /// </summary>
        /// <param name="textField">The TextField control containing the text.</param>
        /// <param name="start">The start index of the text to get the size for</param>
        /// <param name="end">The end index of the text to get the size for.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static List<Size2D> GetTextSize(TextField textField, int start, int end)
        {
            if (textField == null)
            {
                throw new ArgumentNullException(null, "textField object is null");
            }

            ValidateRange(start, end);

            List<Size2D> list = GetSizeListFromNativeVector(Interop.TextField.GetTextSize(textField.SwigCPtr, (uint)start, (uint)end));
            CheckSWIGPendingException();
            return list;
        }

        /// <summary>
        /// Get the rendered size of the text between start and end (included). <br />
        /// if the requested text is at multilines, multiple sizes will be returned for each text located in a separate line. <br />
        /// if a line contains characters with different directions, multiple sizes will be returned for each block of contiguous characters with the same direction. <br />
        /// </summary>
        /// <param name="textLabel">The TextLabel control containing the text.</param>
        /// <param name="start">The start index of the text to get the size for</param>
        /// <param name="end">The end index of the text to get the size for.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static List<Size2D> GetTextSize(TextLabel textLabel, int start, int end)
        {
            if (textLabel == null)
            {
                throw new ArgumentNullException(null, "textLabel object is null");
            }

            ValidateRange(start, end);

            List<Size2D> list = GetSizeListFromNativeVector(Interop.TextLabel.GetTextSize(textLabel.SwigCPtr, (uint)start, (uint)end));
            CheckSWIGPendingException();
            return list;
        }

        /// <summary>
        /// Get the rendered position (top-left) of the text between start and end (included). <br />
        /// if the requested text is at multilines, multiple positions will be returned for each text located in a separate line. <br />
        /// if a line contains characters with different directions, multiple positions will be returned for each block of contiguous characters with the same direction. <br />
        /// </summary>
        /// <param name="textEditor">The TextEditor control containing the text.</param>
        /// <param name="start">The start index of the text to get the position for</param>
        /// <param name="end">The end index of the text to get the position for.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static List<Position2D> GetTextPosition(TextEditor textEditor, int start, int end)
        {
            if (textEditor == null)
            {
                throw new ArgumentNullException(null, "textEditor object is null");
            }

            ValidateRange(start, end);

            List<Position2D> list = GetPositionListFromNativeVector(Interop.TextEditor.GetTextPosition(textEditor.SwigCPtr, (uint)start, (uint)end));
            CheckSWIGPendingException();
            return list;
        }

        /// <summary>
        /// Get the rendered position (top-left) of the text between start and end (included). <br />
        /// if the requested text is at multilines, multiple positions will be returned for each text located in a separate line. <br />
        /// if a line contains characters with different directions, multiple positions will be returned for each block of contiguous characters with the same direction. <br />
        /// </summary>
        /// <param name="textField">The TextField control containing the text.</param>
        /// <param name="start">The start index of the text to get the position for</param>
        /// <param name="end">The end index of the text to get the position for.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static List<Position2D> GetTextPosition(TextField textField, int start, int end)
        {
            if (textField == null)
            {
                throw new ArgumentNullException(null, "textField object is null");
            }

            ValidateRange(start, end);

            List<Position2D> list = GetPositionListFromNativeVector(Interop.TextField.GetTextPosition(textField.SwigCPtr, (uint)start, (uint)end));
            CheckSWIGPendingException();
            return list;
        }

        /// <summary>
        /// Get the rendered position (top-left) of the text between start and end (included). <br />
        /// if the requested text is at multilines, multiple positions will be returned for each text located in a separate line. <br />
        /// if a line contains characters with different directions, multiple positions will be returned for each block of contiguous characters with the same direction. <br />
        /// </summary>
        /// <param name="textLabel">The TextLabel control containing the text.</param>
        /// <param name="start">The start index of the text to get the position for</param>
        /// <param name="end">The end index of the text to get the position for.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static List<Position2D> GetTextPosition(TextLabel textLabel, int start, int end)
        {
            if (textLabel == null)
            {
                throw new ArgumentNullException(null, "textLabel object is null");
            }

            ValidateRange(start, end);

            List<Position2D> list = GetPositionListFromNativeVector(Interop.TextLabel.GetTextPosition(textLabel.SwigCPtr, (uint)start, (uint)end));
            CheckSWIGPendingException();
            return list;
        }
    }
}

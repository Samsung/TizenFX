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

        private static void ValidateIndex(int index)
        {
            if (index < 0)
                throw new global::System.ArgumentOutOfRangeException(nameof(index), "Value is less than zero");
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

        private static Tizen.NUI.Rectangle ConvertPaddingTypeToRectangle(Tizen.NUI.PaddingType paddingType)
        {
            Tizen.NUI.Rectangle rect = new  Tizen.NUI.Rectangle();
            rect.X = (int) paddingType.Start;
            rect.Y = (int) paddingType.End;
            rect.Width = (int) paddingType.Bottom;
            rect.Height = (int) paddingType.Top;

            return rect;
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

        /// <summary>
        /// Get the bounding rectangle of a line. <br />
        /// </summary>
        /// <param name="textLabel">The TextLabel control containing the text.</param>
        /// <param name="lineIndex">The index of the line to get the bounding rectangle for</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Tizen.NUI.Rectangle GetLineBoundingRectangle(TextLabel textLabel, int lineIndex)
        {
            if (textLabel == null)
            {
                throw new ArgumentNullException(null, "textLabel object is null");
            }

            ValidateIndex(lineIndex);

            Tizen.NUI.PaddingType paddingType = new Tizen.NUI.PaddingType(Interop.TextGeometry.GetLineBoundingRectangleTextLabel(textLabel.SwigCPtr, lineIndex), true);
            Tizen.NUI.Rectangle   rect        = ConvertPaddingTypeToRectangle(paddingType);

            CheckSWIGPendingException();
            return rect;
        }

        /// <summary>
        /// Get the bounding rectangle of a line. <br />
        /// </summary>
        /// <param name="textEditor">The TextEditor control containing the text.</param>
        /// <param name="lineIndex">The index of the line to get the bounding rectangle for</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Tizen.NUI.Rectangle GetLineBoundingRectangle(TextEditor textEditor, int lineIndex)
        {
            if (textEditor == null)
            {
                throw new ArgumentNullException(null, "textEditor object is null");
            }

            ValidateIndex(lineIndex);

            Tizen.NUI.PaddingType paddingType = new Tizen.NUI.PaddingType(Interop.TextGeometry.GetLineBoundingRectangleTextEditor(textEditor.SwigCPtr, lineIndex), true);
            Tizen.NUI.Rectangle   rect        = ConvertPaddingTypeToRectangle(paddingType);

            CheckSWIGPendingException();
            return rect;
        }

        /// <summary>
        /// Get the bounding rectangle of a line. <br />
        /// </summary>
        /// <param name="textField">The TextField control containing the text.</param>
        /// <param name="lineIndex">The index of the line to get the bounding rectangle for</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Tizen.NUI.Rectangle GetLineBoundingRectangle(TextField textField, int lineIndex)
        {
            if (textField == null)
            {
                throw new ArgumentNullException(null, "textField object is null");
            }

            ValidateIndex(lineIndex);

            Tizen.NUI.PaddingType paddingType = new Tizen.NUI.PaddingType(Interop.TextGeometry.GetLineBoundingRectangleTextField(textField.SwigCPtr, lineIndex), true);
            Tizen.NUI.Rectangle   rect        = ConvertPaddingTypeToRectangle(paddingType);

            CheckSWIGPendingException();
            return rect;
        }

        /// <summary>
        /// Get the bounding rectangle of a character. <br />
        /// </summary>
        /// <param name="textLabel">The TextLabel control containing the text.</param>
        /// <param name="characterIndex">The index of the character to get the bounding rectangle for</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Tizen.NUI.Rectangle GetCharacterBoundingRectangle(TextLabel textLabel, int characterIndex)
        {
            if (textLabel == null)
            {
                throw new ArgumentNullException(null, "textLabel object is null");
            }

            ValidateIndex(characterIndex);

            Tizen.NUI.PaddingType paddingType = new Tizen.NUI.PaddingType(Interop.TextGeometry.GetCharacterBoundingRectangleTextLabel(textLabel.SwigCPtr, characterIndex), true);
            Tizen.NUI.Rectangle   rect        = ConvertPaddingTypeToRectangle(paddingType);

            CheckSWIGPendingException();
            return rect;
        }

        /// <summary>
        /// Get the bounding rectangle of a character. <br />
        /// </summary>
        /// <param name="textEditor">The TextEditor control containing the text.</param>
        /// <param name="characterIndex">The index of the character to get the bounding rectangle for</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Tizen.NUI.Rectangle GetCharacterBoundingRectangle(TextEditor textEditor, int characterIndex)
        {
            if (textEditor == null)
            {
                throw new ArgumentNullException(null, "textEditor object is null");
            }

            ValidateIndex(characterIndex);

            Tizen.NUI.PaddingType paddingType = new Tizen.NUI.PaddingType(Interop.TextGeometry.GetCharacterBoundingRectangleTextEditor(textEditor.SwigCPtr, characterIndex), true);
            Tizen.NUI.Rectangle   rect        = ConvertPaddingTypeToRectangle(paddingType);

            CheckSWIGPendingException();
            return rect;
        }

        /// <summary>
        /// Get the bounding rectangle of a character. <br />
        /// </summary>
        /// <param name="textField">The TextField control containing the text.</param>
        /// <param name="characterIndex">The index of the character to get the bounding rectangle for</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Tizen.NUI.Rectangle GetCharacterBoundingRectangle(TextField textField, int characterIndex)
        {
            if (textField == null)
            {
                throw new ArgumentNullException(null, "textField object is null");
            }

            ValidateIndex(characterIndex);

            Tizen.NUI.PaddingType paddingType = new Tizen.NUI.PaddingType(Interop.TextGeometry.GetCharacterBoundingRectangleTextField(textField.SwigCPtr, characterIndex), true);
            Tizen.NUI.Rectangle   rect        = ConvertPaddingTypeToRectangle(paddingType);

            CheckSWIGPendingException();
            return rect;
        }

        /// <summary>
        /// Get the character Index at the given position. <br />
        /// </summary>
        /// <param name="textLabel">The TextLabel control containing the text.</param>
        /// <param name="visualX">The visual x point</param>
        /// <param name="visualY">The visual y point</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int GetCharacterIndexAtPosition(TextLabel textLabel, float visualX, float visualY)
        {
            if (textLabel == null)
            {
                throw new ArgumentNullException(null, "textLabel object is null");
            }

            int characterIndex = (int)(Interop.TextGeometry.GetCharacterIndexAtPositionTextLabel(textLabel.SwigCPtr, visualX, visualY));
            CheckSWIGPendingException();
            return characterIndex;
        }

        /// <summary>
        /// Get the character Index at the given position. <br />
        /// </summary>
        /// <param name="textField">The TextField control containing the text.</param>
        /// <param name="visualX">The visual x point</param>
        /// <param name="visualY">The visual y point</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int GetCharacterIndexAtPosition(TextField textField, float visualX, float visualY)
        {
            if (textField == null)
            {
                throw new ArgumentNullException(null, "textField object is null");
            }

            int characterIndex = (int)(Interop.TextGeometry.GetCharacterIndexAtPositionTextField(textField.SwigCPtr, visualX, visualY));
            CheckSWIGPendingException();
            return characterIndex;
        }

        /// <summary>
        /// Get the character Index at the given position. <br />
        /// </summary>
        /// <param name="textEditor">The TextEditor control containing the text.</param>
        /// <param name="visualX">The visual x point</param>
        /// <param name="visualY">The visual y point</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int GetCharacterIndexAtPosition(TextEditor textEditor, float visualX, float visualY)
        {
            if (textEditor == null)
            {
                throw new ArgumentNullException(null, "textEditor object is null");
            }

            int characterIndex = (int)(Interop.TextGeometry.GetCharacterIndexAtPositionTextEditor(textEditor.SwigCPtr, visualX, visualY));
            CheckSWIGPendingException();
            return characterIndex;
        }

    }
}

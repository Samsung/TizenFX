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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class TextGeometry
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextGeometry_TextLabel_GetLineBoundingRectangle")]
            public static extern global::System.IntPtr GetLineBoundingRectangleTextLabel(global::System.Runtime.InteropServices.HandleRef textLabelRef, int lineIndex);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextGeometry_TextField_GetLineBoundingRectangle")]
            public static extern global::System.IntPtr GetLineBoundingRectangleTextField(global::System.Runtime.InteropServices.HandleRef textFieldRef, int lineIndex);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextGeometry_TextEditor_GetLineBoundingRectangle")]
            public static extern global::System.IntPtr GetLineBoundingRectangleTextEditor(global::System.Runtime.InteropServices.HandleRef textEditorRef, int lineIndex);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextGeometry_TextLabel_GetCharacterBoundingRectangle")]
            public static extern global::System.IntPtr GetCharacterBoundingRectangleTextLabel(global::System.Runtime.InteropServices.HandleRef textLabelRef, int characterIndex);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextGeometry_TextField_GetCharacterBoundingRectangle")]
            public static extern global::System.IntPtr GetCharacterBoundingRectangleTextField(global::System.Runtime.InteropServices.HandleRef textFieldRef, int characterIndex);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextGeometry_TextEditor_GetCharacterBoundingRectangle")]
            public static extern global::System.IntPtr GetCharacterBoundingRectangleTextEditor(global::System.Runtime.InteropServices.HandleRef textEditorRef, int characterIndex);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextGeometry_TextLabel_GetCharacterIndexAtPosition")]
            public static extern int GetCharacterIndexAtPositionTextLabel(global::System.Runtime.InteropServices.HandleRef textLabelRef, float visualX, float visualY);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextGeometry_TextField_GetCharacterIndexAtPosition")]
            public static extern int GetCharacterIndexAtPositionTextField(global::System.Runtime.InteropServices.HandleRef textFieldRef, float visualX, float visualY);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextGeometry_TextEditor_GetCharacterIndexAtPosition")]
            public static extern int GetCharacterIndexAtPositionTextEditor(global::System.Runtime.InteropServices.HandleRef textEditorRef, float visualX, float visualY);
        }
    }
}
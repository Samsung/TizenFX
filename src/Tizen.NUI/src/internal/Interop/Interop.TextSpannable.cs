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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class TextSpannable
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_SetSpannedText")]
            public static extern void SetSpannedTextIntoTextLabel(global::System.Runtime.InteropServices.HandleRef textLabelRef, global::System.Runtime.InteropServices.HandleRef spannedRef);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextField_SetSpannedText")]
            public static extern void SetSpannedTextIntoTextField(global::System.Runtime.InteropServices.HandleRef textFieldRef, global::System.Runtime.InteropServices.HandleRef spannedRef);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_SetSpannedText")]
            public static extern void SetSpannedTextIntoTextEditor(global::System.Runtime.InteropServices.HandleRef textEditorRef, global::System.Runtime.InteropServices.HandleRef spannedRef);

        }
    }
}
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
        internal static partial class CharacterSequence
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_CharacterSequence")]
            public static extern void DeleteCharacterSequence(global::System.Runtime.InteropServices.HandleRef refCharacterSequence);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CharacterSequence_GetCharacters")]
            public static extern global::System.IntPtr GetCharacters(global::System.Runtime.InteropServices.HandleRef refCharacterSequence);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CharacterSequence_GetNumberOfCharacters")]
            public static extern uint GetNumberOfCharacters(global::System.Runtime.InteropServices.HandleRef refCharacterSequence);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CharacterSequence_ToString")]
            public static extern string ToString(global::System.Runtime.InteropServices.HandleRef refCharacterSequence);

        }
    }
}
/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
    class NDalicManualPINVOKE
    {
        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_MODE_get")]
        public static extern int HiddeninputPropertyModeGet();

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_SUBSTITUTE_CHARACTER_get")]
        public static extern int HiddeninputPropertySubstituteCharacterGet();

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_SUBSTITUTE_COUNT_get")]
        public static extern int HiddeninputPropertySubstituteCountGet();

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_SHOW_LAST_CHARACTER_DURATION_get")]
        public static extern int HiddeninputPropertyShowLastCharacterDurationGet();

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LINE_MUST_BREAK_get")]
        public static extern int LineMustBreakGet();

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LINE_ALLOW_BREAK_get")]
        public static extern int LineAllowBreakGet();

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LINE_NO_BREAK_get")]
        public static extern int LineNoBreakGet();

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WORD_BREAK_get")]
        public static extern int WordBreakGet();

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WORD_NO_BREAK_get")]
        public static extern int WordNoBreakGet();
    }
}

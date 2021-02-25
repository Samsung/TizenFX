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
        internal static partial class NDalicText
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_TEXT_get")]
            public static extern int TextVisualTextGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_FONT_FAMILY_get")]
            public static extern int TextVisualFontFamilyGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_FONT_STYLE_get")]
            public static extern int TextVisualFontStyleGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_POINT_SIZE_get")]
            public static extern int TextVisualPointSizeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_MULTI_LINE_get")]
            public static extern int TextVisualMultiLineGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_HORIZONTAL_ALIGNMENT_get")]
            public static extern int TextVisualHorizontalAlignmentGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_VERTICAL_ALIGNMENT_get")]
            public static extern int TextVisualVerticalAlignmentGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_TEXT_COLOR_get")]
            public static extern int TextVisualTextColorGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_ENABLE_MARKUP_get")]
            public static extern int TextVisualEnableMarkupGet();
        }
    }
}

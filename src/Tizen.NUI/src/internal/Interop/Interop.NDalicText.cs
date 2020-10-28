﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class NDalicText
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_TEXT_get")]
            public static extern int TEXT_VISUAL_TEXT_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_FONT_FAMILY_get")]
            public static extern int TEXT_VISUAL_FONT_FAMILY_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_FONT_STYLE_get")]
            public static extern int TEXT_VISUAL_FONT_STYLE_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_POINT_SIZE_get")]
            public static extern int TEXT_VISUAL_POINT_SIZE_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_MULTI_LINE_get")]
            public static extern int TEXT_VISUAL_MULTI_LINE_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_HORIZONTAL_ALIGNMENT_get")]
            public static extern int TEXT_VISUAL_HORIZONTAL_ALIGNMENT_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_VERTICAL_ALIGNMENT_get")]
            public static extern int TEXT_VISUAL_VERTICAL_ALIGNMENT_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_TEXT_COLOR_get")]
            public static extern int TEXT_VISUAL_TEXT_COLOR_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TEXT_VISUAL_ENABLE_MARKUP_get")]
            public static extern int TEXT_VISUAL_ENABLE_MARKUP_get();
        }
    }
}
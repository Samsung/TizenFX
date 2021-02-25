using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class GlytphInfo
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GlyphInfo__SWIG_0")]
            public static extern global::System.IntPtr NewGlyphInfo();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GlyphInfo__SWIG_1")]
            public static extern global::System.IntPtr NewGlyphInfo(uint jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_fontId_set")]
            public static extern void GlyphInfoFontIdSet(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_fontId_get")]
            public static extern uint GlyphInfoFontIdGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_index_set")]
            public static extern void GlyphInfoIndexSet(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_index_get")]
            public static extern uint GlyphInfoIndexGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_width_set")]
            public static extern void GlyphInfoWidthSet(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_width_get")]
            public static extern float GlyphInfoWidthGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_height_set")]
            public static extern void GlyphInfoHeightSet(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_height_get")]
            public static extern float GlyphInfoHeightGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_xBearing_set")]
            public static extern void GlyphInfoXBearingSet(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_xBearing_get")]
            public static extern float GlyphInfoXBearingGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_yBearing_set")]
            public static extern void GlyphInfoYBearingSet(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_yBearing_get")]
            public static extern float GlyphInfoYBearingGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_advance_set")]
            public static extern void GlyphInfoAdvanceSet(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_advance_get")]
            public static extern float GlyphInfoAdvanceGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_scaleFactor_set")]
            public static extern void GlyphInfoScaleFactorSet(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_scaleFactor_get")]
            public static extern float GlyphInfoScaleFactorGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_GlyphInfo")]
            public static extern void DeleteGlyphInfo(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}

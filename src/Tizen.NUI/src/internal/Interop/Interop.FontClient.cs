using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class FontClient
        {
            //for FontClient
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_DEFAULT_POINT_SIZE_get")]
            public static extern uint FontClient_DEFAULT_POINT_SIZE_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FontClient_GlyphBufferData")]
            public static extern global::System.IntPtr new_FontClient_GlyphBufferData();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FontClient_GlyphBufferData")]
            public static extern void delete_FontClient_GlyphBufferData(global::System.Runtime.InteropServices.HandleRef jarg1);

            /*
                [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint="CSharp_Dali_FontClient_GlyphBufferData_buffer_set")]
                public static extern void FontClient_GlyphBufferData_buffer_set(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]byte[] jarg2);

                [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint="CSharp_Dali_FontClient_GlyphBufferData_buffer_get")]
                public static extern byte[] FontClient_GlyphBufferData_buffer_get(global::System.Runtime.InteropServices.HandleRef jarg1);
            */
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_width_set")]
            public static extern void FontClient_GlyphBufferData_width_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_width_get")]
            public static extern uint FontClient_GlyphBufferData_width_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_height_set")]
            public static extern void FontClient_GlyphBufferData_height_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_height_get")]
            public static extern uint FontClient_GlyphBufferData_height_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_format_set")]
            public static extern void FontClient_GlyphBufferData_format_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_format_get")]
            public static extern int FontClient_GlyphBufferData_format_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_Get")]
            public static extern global::System.IntPtr FontClient_Get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FontClient__SWIG_0")]
            public static extern global::System.IntPtr new_FontClient__SWIG_0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FontClient")]
            public static extern void delete_FontClient(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FontClient__SWIG_1")]
            public static extern global::System.IntPtr new_FontClient__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_Assign")]
            public static extern global::System.IntPtr FontClient_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_SetDpi")]
            public static extern void FontClient_SetDpi(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetDpi")]
            public static extern void FontClient_GetDpi(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetDefaultFontSize")]
            public static extern int FontClient_GetDefaultFontSize(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_ResetSystemDefaults")]
            public static extern void FontClient_ResetSystemDefaults(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetDefaultFonts")]
            public static extern void FontClient_GetDefaultFonts(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetDefaultPlatformFontDescription")]
            public static extern void FontClient_GetDefaultPlatformFontDescription(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetSystemFonts")]
            public static extern void FontClient_GetSystemFonts(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetDescription")]
            public static extern void FontClient_GetDescription(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetPointSize")]
            public static extern uint FontClient_GetPointSize(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_IsCharacterSupportedByFont")]
            public static extern bool FontClient_IsCharacterSupportedByFont(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_FindDefaultFont__SWIG_0")]
            public static extern uint FontClient_FindDefaultFont__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, bool jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_FindDefaultFont__SWIG_1")]
            public static extern uint FontClient_FindDefaultFont__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_FindDefaultFont__SWIG_2")]
            public static extern uint FontClient_FindDefaultFont__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_FindFallbackFont__SWIG_0")]
            public static extern uint FontClient_FindFallbackFont__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, uint jarg4, bool jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_FindFallbackFont__SWIG_1")]
            public static extern uint FontClient_FindFallbackFont__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, uint jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_FindFallbackFont__SWIG_2")]
            public static extern uint FontClient_FindFallbackFont__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_0")]
            public static extern uint FontClient_GetFontId__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, uint jarg3, uint jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_1")]
            public static extern uint FontClient_GetFontId__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, uint jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_2")]
            public static extern uint FontClient_GetFontId__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_3")]
            public static extern uint FontClient_GetFontId__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, uint jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_4")]
            public static extern uint FontClient_GetFontId__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_5")]
            public static extern uint FontClient_GetFontId__SWIG_5(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_IsScalable__SWIG_0")]
            public static extern bool FontClient_IsScalable__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_IsScalable__SWIG_1")]
            public static extern bool FontClient_IsScalable__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetFixedSizes__SWIG_0")]
            public static extern void FontClient_GetFixedSizes__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetFixedSizes__SWIG_1")]
            public static extern void FontClient_GetFixedSizes__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetFontMetrics")]
            public static extern void FontClient_GetFontMetrics(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetGlyphIndex")]
            public static extern uint FontClient_GetGlyphIndex(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetGlyphMetrics__SWIG_0")]
            public static extern bool FontClient_GetGlyphMetrics__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, int jarg4, bool jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetGlyphMetrics__SWIG_1")]
            public static extern bool FontClient_GetGlyphMetrics__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, int jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_CreateBitmap__SWIG_0")]
            public static extern void FontClient_CreateBitmap__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, bool jarg4, bool jarg5, global::System.Runtime.InteropServices.HandleRef jarg6, int jarg7);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_CreateBitmap__SWIG_1")]
            public static extern global::System.IntPtr FontClient_CreateBitmap__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, int jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_CreateVectorBlob")]
            public static extern void FontClient_CreateVectorBlob(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6, global::System.Runtime.InteropServices.HandleRef jarg7);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetEllipsisGlyph")]
            public static extern global::System.IntPtr FontClient_GetEllipsisGlyph(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_IsColorGlyph")]
            public static extern bool FontClient_IsColorGlyph(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_AddCustomFontDirectory")]
            public static extern bool FontClient_AddCustomFontDirectory(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_SWIGUpcast")]
            public static extern global::System.IntPtr FontClient_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontWidthName_get")]
            public static extern global::System.IntPtr FontWidthName_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontWeightName_get")]
            public static extern global::System.IntPtr FontWeightName_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSlantName_get")]
            public static extern global::System.IntPtr FontSlantName_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FontDescription")]
            public static extern global::System.IntPtr new_FontDescription();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FontDescription")]
            public static extern void delete_FontDescription(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_path_set")]
            public static extern void FontDescription_path_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_path_get")]
            public static extern string FontDescription_path_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_family_set")]
            public static extern void FontDescription_family_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_family_get")]
            public static extern string FontDescription_family_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_width_set")]
            public static extern void FontDescription_width_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_width_get")]
            public static extern int FontDescription_width_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_weight_set")]
            public static extern void FontDescription_weight_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_weight_get")]
            public static extern int FontDescription_weight_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_slant_set")]
            public static extern void FontDescription_slant_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_slant_get")]
            public static extern int FontDescription_slant_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FontMetrics__SWIG_0")]
            public static extern global::System.IntPtr new_FontMetrics__SWIG_0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FontMetrics__SWIG_1")]
            public static extern global::System.IntPtr new_FontMetrics__SWIG_1(float jarg1, float jarg2, float jarg3, float jarg4, float jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_ascender_set")]
            public static extern void FontMetrics_ascender_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_ascender_get")]
            public static extern float FontMetrics_ascender_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_descender_set")]
            public static extern void FontMetrics_descender_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_descender_get")]
            public static extern float FontMetrics_descender_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_height_set")]
            public static extern void FontMetrics_height_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_height_get")]
            public static extern float FontMetrics_height_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_underlinePosition_set")]
            public static extern void FontMetrics_underlinePosition_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_underlinePosition_get")]
            public static extern float FontMetrics_underlinePosition_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_underlineThickness_set")]
            public static extern void FontMetrics_underlineThickness_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_underlineThickness_get")]
            public static extern float FontMetrics_underlineThickness_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FontMetrics")]
            public static extern void delete_FontMetrics(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
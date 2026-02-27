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

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class FontClient
        {
            //for FontClient
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_PreCache", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void PreCache(string[] fallbackFamilyArray, int fallbackFamilySize, string[] extraFamilyArray, int extraFamilySize, string localeFamily, [MarshalAs(UnmanagedType.U1)] bool useThread, [MarshalAs(UnmanagedType.U1)] bool syncCreation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_FontPreLoad", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FontPreLoad(string[] fontPathArray, int fontPathSize, string[] memoryFontPathArray, int memoryFontPathSize, [MarshalAs(UnmanagedType.U1)] bool useThread, [MarshalAs(UnmanagedType.U1)] bool syncCreation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_EnableDesignCompatibility", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableDesignCompatibility();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FontClient_GlyphBufferData", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewFontClientGlyphBufferData();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FontClient_GlyphBufferData", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteFontClientGlyphBufferData(IntPtr jarg1);

            /*
                [LibraryImport(NDalicPINVOKE.Lib, EntryPoint="CSharp_Dali_FontClient_GlyphBufferData_buffer_set", StringMarshalling = StringMarshalling.Utf8)]
                public static partial void GlyphBufferDataBufferSet(IntPtr jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]byte[] jarg2);

                [LibraryImport(NDalicPINVOKE.Lib, EntryPoint="CSharp_Dali_FontClient_GlyphBufferData_buffer_get", StringMarshalling = StringMarshalling.Utf8)]
                public static partial byte[] GlyphBufferDataBufferGet(IntPtr jarg1);
            */
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_width_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlyphBufferDataWidthSet(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_width_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GlyphBufferDataWidthGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_height_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlyphBufferDataHeightSet(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_height_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GlyphBufferDataHeightGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_format_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlyphBufferDataFormatSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_format_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GlyphBufferDataFormatGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_Get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Get();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FontClient__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewFontClient();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Assign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_SetDpi", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetDpi(IntPtr jarg1, uint jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetDefaultFontSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetDefaultFontSize(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_ResetSystemDefaults", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ResetSystemDefaults(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetDefaultPlatformFontDescription", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GetDefaultPlatformFontDescription(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetSystemFonts", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetSystemFonts(IntPtr fontClient);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetDescription", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GetDescription(IntPtr jarg1, uint jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetPointSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetPointSize(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_IsCharacterSupportedByFont", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsCharacterSupportedByFont(IntPtr jarg1, uint jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_FindDefaultFont__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint FindDefaultFont(IntPtr jarg1, uint jarg2, uint jarg3, [MarshalAs(UnmanagedType.U1)] bool jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_FindDefaultFont__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint FindDefaultFont(IntPtr jarg1, uint jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_FindDefaultFont__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint FindDefaultFont(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_FindFallbackFont__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint FindFallbackFont(IntPtr jarg1, uint jarg2, IntPtr jarg3, uint jarg4, [MarshalAs(UnmanagedType.U1)] bool jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_FindFallbackFont__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint FindFallbackFont(IntPtr jarg1, uint jarg2, IntPtr jarg3, uint jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_FindFallbackFont__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint FindFallbackFont(IntPtr jarg1, uint jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetFontId(IntPtr jarg1, string jarg2, uint jarg3, uint jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetFontId(IntPtr jarg1, string jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetFontId(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetFontId(IntPtr jarg1, IntPtr jarg2, uint jarg3, uint jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetFontId(IntPtr jarg1, IntPtr jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_5", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetFontId(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_IsScalable__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsScalable(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_IsScalable__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsScalable(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetFontMetrics", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GetFontMetrics(IntPtr jarg1, uint jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetGlyphIndex", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetGlyphIndex(IntPtr jarg1, uint jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetGlyphMetrics__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetGlyphMetrics(IntPtr jarg1, IntPtr jarg2, uint jarg3, int jarg4, [MarshalAs(UnmanagedType.U1)] bool jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetGlyphMetrics__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetGlyphMetrics(IntPtr jarg1, IntPtr jarg2, uint jarg3, int jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_CreateBitmap__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void CreateBitmap(IntPtr jarg1, uint jarg2, uint jarg3, [MarshalAs(UnmanagedType.U1)] bool jarg4, [MarshalAs(UnmanagedType.U1)] bool jarg5, IntPtr jarg6, int jarg7);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_CreateBitmap__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr CreateBitmap(IntPtr jarg1, uint jarg2, uint jarg3, int jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_GetEllipsisGlyph", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetEllipsisGlyph(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_IsColorGlyph", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsColorGlyph(IntPtr jarg1, uint jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontClient_AddCustomFontDirectory", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddCustomFontDirectory(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FontDescription", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewFontDescription();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FontDescription", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteFontDescription(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_path_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FontDescriptionPathSet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_path_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string FontDescriptionPathGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_family_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FontDescriptionFamilySet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_family_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string FontDescriptionFamilyGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_width_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FontDescriptionWidthSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_width_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int FontDescriptionWidthGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_weight_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FontDescriptionWeightSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_weight_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int FontDescriptionWeightGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_slant_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FontDescriptionSlantSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontDescription_slant_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int FontDescriptionSlantGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FontMetrics__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewFontMetrics();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FontMetrics__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewFontMetrics(float jarg1, float jarg2, float jarg3, float jarg4, float jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_ascender_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FontMetricsAscenderSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_ascender_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float FontMetricsAscenderGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_descender_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FontMetricsDescenderSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_descender_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float FontMetricsDescenderGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_height_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FontMetricsHeightSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_height_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float FontMetricsHeightGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_underlinePosition_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FontMetricsUnderlinePositionSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_underlinePosition_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float FontMetricsUnderlinePositionGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_underlineThickness_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FontMetricsUnderlineThicknessSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontMetrics_underlineThickness_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float FontMetricsUnderlineThicknessGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FontMetrics", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteFontMetrics(IntPtr jarg1);
        }
    }
}






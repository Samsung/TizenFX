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
        internal static partial class RendererParameters
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RendererParameters_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRendererParameters();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_text_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TextSet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_text_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string TextGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_horizontalAlignment_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void HorizontalAlignmentSet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_horizontalAlignment_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string HorizontalAlignmentGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_verticalAlignment_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void VerticalAlignmentSet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_verticalAlignment_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string VerticalAlignmentGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_fontFamily_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FontFamilySet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_fontFamily_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string FontFamilyGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_fontWeight_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FontWeightSet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_fontWeight_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string FontWeightGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_fontWidth_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FontWidthSet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_fontWidth_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string FontWidthGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_fontSlant_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FontSlantSet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_fontSlant_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string FontSlantGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_layout_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LayoutSet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_layout_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string LayoutGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_circularAlignment_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void CircularAlignmentSet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_circularAlignment_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string CircularAlignmentGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_textColor_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TextColorSet(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_textColor_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr TextColorGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_fontSize_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FontSizeSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_fontSize_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float FontSizeGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_textWidth_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TextWidthSet(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_textWidth_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint TextWidthGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_textHeight_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TextHeightSet(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_textHeight_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint TextHeightGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_radius_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RadiusSet(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_radius_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint RadiusGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_beginAngle_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void BeginAngleSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_beginAngle_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float BeginAngleGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_incrementAngle_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void IncrementAngleSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_incrementAngle_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float IncrementAngleGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_ellipsisEnabled_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EllipsisEnabledSet(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_ellipsisEnabled_get", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool EllipsisEnabledGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_markupEnabled_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void MarkupEnabledSet(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_markupEnabled_get", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool MarkupEnabledGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_isTextColorSet_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void IsTextColorSetSet(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_isTextColorSet_get", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsTextColorSetGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_minLineSize_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void MinLineSizeSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_minLineSize_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float MinLineSizeGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_padding_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void PaddingSet(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RendererParameters_padding_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr PaddingGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RendererParameters", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteRendererParameters(IntPtr jarg1);
        }

        internal static partial class EmbeddedItemInfo
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_EmbeddedItemInfo_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewEmbeddedItemInfo();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_EmbeddedItemInfo", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteEmbeddedItemInfo(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EmbeddedItemInfo_characterIndex_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void CharacterIndexSet(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EmbeddedItemInfo_characterIndex_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint CharacterIndexGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EmbeddedItemInfo_glyphIndex_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlyphIndexSet(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EmbeddedItemInfo_glyphIndex_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GlyphIndexGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EmbeddedItemInfo_position_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void PositionSet(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EmbeddedItemInfo_position_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr PositionGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EmbeddedItemInfo_size_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SizeSet(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EmbeddedItemInfo_size_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr SizeGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EmbeddedItemInfo_rotatedSize_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RotatedSizeSet(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EmbeddedItemInfo_rotatedSize_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RotatedSizeGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EmbeddedItemInfo_angle_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AngleSet(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EmbeddedItemInfo_angle_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr AngleGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EmbeddedItemInfo_colorBlendingMode_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ColorBlendingModeSet(IntPtr jarg1, Tizen.NUI.ColorBlendingMode jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EmbeddedItemInfo_colorBlendingMode_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial Tizen.NUI.ColorBlendingMode ColorBlendingModeGet(IntPtr jarg1);
        }

        internal static partial class ShadowParameters
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ShadowParameters_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewShadowParameters();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ShadowParameters", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteShadowParameters(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ShadowParameters_input_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void InputSet(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ShadowParameters_input_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr InputGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ShadowParameters_textColor_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TextColorSet(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ShadowParameters_textColor_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr TextColorGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ShadowParameters_color_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ColorSet(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ShadowParameters_color_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ColorGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ShadowParameters_offset_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void OffsetSet(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ShadowParameters_offset_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr OffsetGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ShadowParameters_blendShadow_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void BlendShadowSet(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ShadowParameters_blendShadow_get", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool BlendShadowGet(IntPtr jarg1);
        }

        internal static partial class TextUtils
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextUtils_Render", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Render(IntPtr jarg1, ref global::System.IntPtr jarg2, ref int count, ref int length);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextUtils_CreateShadow", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr CreateShadow(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextUtils_ConvertToRgba8888", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ConvertToRgba8888(IntPtr jarg1, IntPtr jarg2, [MarshalAs(UnmanagedType.U1)] bool jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextUtils_UpdateBuffer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void UpdateBuffer(IntPtr jarg1, IntPtr jarg2, uint jarg3, uint jarg4, [MarshalAs(UnmanagedType.U1)] bool jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextUtils_GetLastCharacterIndex", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetLastCharacterIndex(IntPtr jarg1);

        }
    }
}






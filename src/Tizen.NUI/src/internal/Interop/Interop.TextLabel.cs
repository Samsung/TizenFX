/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
        internal static partial class TextLabel
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_TEXT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TextGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_FONT_FAMILY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int FontFamilyGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_FONT_STYLE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int FontStyleGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_POINT_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PointSizeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_MULTI_LINE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int MultiLineGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_HORIZONTAL_ALIGNMENT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int HorizontalAlignmentGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_VERTICAL_ALIGNMENT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int VerticalAlignmentGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_TEXT_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TextColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_ENABLE_MARKUP_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EnableMarkupGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_ENABLE_AUTO_SCROLL_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EnableAutoScrollGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_AUTO_SCROLL_SPEED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AutoScrollSpeedGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_AUTO_SCROLL_LOOP_COUNT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AutoScrollLoopCountGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_AUTO_SCROLL_GAP_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AutoScrollGapGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_LINE_SPACING_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LineSpacingGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_RELATIVE_LINE_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RelativeLineHeightGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_UNDERLINE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int UnderlineGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_SHADOW_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ShadowGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_EMBOSS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EmbossGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_OUTLINE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int OutlineGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_New__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_New_With_Style", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New([MarshalAs(UnmanagedType.U1)] bool hasStyle);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_New_With_String_Style", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(string text, [MarshalAs(UnmanagedType.U1)] bool hasStyle);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TextLabel", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteTextLabel(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_PIXEL_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PixelSizeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_ELLIPSIS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EllipsisGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_ELLIPSIS_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EllipsisPositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_LINE_COUNT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LineCountGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_LINE_WRAP_MODE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LineWrapModeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_TEXT_DIRECTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TextDirectionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_VERTICAL_LINE_ALIGNMENT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int VerticalLineAlignmentGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_AUTO_SCROLL_STOP_MODE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AutoScrollStopModeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_AUTO_SCROLL_LOOP_DELAY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AutoScrollLoopDelayGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_MATCH_SYSTEM_LANGUAGE_DIRECTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int MatchSystemLanguageDirectionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_TEXT_FIT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TextFitGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_TextFitChangedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr TextFitChangedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_MIN_LINE_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int MinLineSizeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_FONT_SIZE_SCALE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int FontSizeScaleGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_ENABLE_FONT_SIZE_SCALE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EnableFontSizeScaleGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_GetTextSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetTextSize(IntPtr textLabelRef, uint start, uint end);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_GetTextPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetTextPosition(IntPtr textLabelRef, uint start, uint end);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_SetTextFitArray", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTextFitArray(IntPtr textLabel, [MarshalAs(UnmanagedType.U1)] bool enable, uint arraySize, float[] pointSizeArray, float[] minLineSizeArray);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_GetTextFitArray", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetTextFitArray(IntPtr textLabel);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_AnchorClickedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr AnchorClickedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabelSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool TextLabelSignalEmpty(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabelSignal_GetConnectionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint TextLabelSignalGetConnectionCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabelSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TextLabelSignalConnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabelSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TextLabelSignalDisconnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabelSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TextLabelSignalEmit(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TextLabelSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewTextLabelSignal();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TextLabelSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteTextLabelSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_STRIKETHROUGH_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int StrikethroughGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_CHARACTER_SPACING_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int CharacterSpacingGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_ANCHOR_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AnchorColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_ANCHOR_CLICKED_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AnchorClickedColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_REMOVE_FRONT_INSET_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RemoveFrontInsetGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_REMOVE_BACK_INSET_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RemoveBackInsetGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_CUTOUT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int CutoutGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_RENDER_MODE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RenderModeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_LAYOUT_DIRECTION_POLICY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LayoutDirectionPolicyGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_AUTO_SCROLL_DIRECTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AutoScrollDirectionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_ELLIPSIS_MODE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EllipsisModeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_IS_SCROLLING_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int IsScrollingGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_MANUAL_RENDERED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ManualRenderedGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_NEED_REQUEST_ASYNC_RENDER_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int NeedRequestAsyncRenderGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_ASYNC_LINE_COUNT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AsyncLineCountGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_RENDER_SCALE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RenderScaleGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_PIXEL_SNAP_FACTOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PixelSnapFactorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_RequestAsyncRenderWithFixedSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RequestAsyncRenderWithFixedSize(IntPtr textLabelRef, float width, float height);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_RequestAsyncRenderWithFixedWidth", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RequestAsyncRenderWithFixedWidth(IntPtr textLabelRef, float width, float heightConstraint);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_RequestAsyncRenderWithFixedHeight", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RequestAsyncRenderWithFixedHeight(IntPtr textLabelRef, float widthConstraint, float height);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_RequestAsyncRenderWithConstraint", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RequestAsyncRenderWithConstraint(IntPtr textLabelRef, float widthConstraint, float heightConstraint);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_RequestAsyncNaturalSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RequestAsyncNaturalSize(IntPtr textLabelRef);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_RequestAsyncHeightForWidth", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RequestAsyncHeightForWidth(IntPtr textLabelRef, float width);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_AsyncTextRenderedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AsyncTextRenderedConnect(IntPtr textLabelRef, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_AsyncTextRenderedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AsyncTextRenderedDisconnect(IntPtr textLabelRef, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_AsyncNaturalSizeComputedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AsyncNaturalSizeComputedConnect(IntPtr textLabelRef, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_AsyncNaturalSizeComputedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AsyncNaturalSizeComputedDisconnect(IntPtr textLabelRef, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_AsyncHeightForWidthComputedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AsyncHeightForWidthComputedConnect(IntPtr textLabelRef, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_AsyncHeightForWidthComputedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AsyncHeightForWidthComputedDisconnect(IntPtr textLabelRef, IntPtr handler);
 
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_RegisterFontVariationProperty", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RegisterFontVariationProperty(IntPtr textLabelRef, string pTag);
 
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_SetMaskEffect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMaskEffect(IntPtr textLabelRef, IntPtr control);
 
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_RemoveMaskEffect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RemoveMaskEffect(IntPtr textLabelRef);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_RequestUpdateManually", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RequestUpdateManually(IntPtr textLabelRef);
        }
    }
}




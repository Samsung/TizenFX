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
        internal static partial class TextLabel
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_TEXT_get")]
            public static extern int TextGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_FONT_FAMILY_get")]
            public static extern int FontFamilyGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_FONT_STYLE_get")]
            public static extern int FontStyleGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_POINT_SIZE_get")]
            public static extern int PointSizeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_MULTI_LINE_get")]
            public static extern int MultiLineGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_HORIZONTAL_ALIGNMENT_get")]
            public static extern int HorizontalAlignmentGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_VERTICAL_ALIGNMENT_get")]
            public static extern int VerticalAlignmentGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_TEXT_COLOR_get")]
            public static extern int TextColorGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_ENABLE_MARKUP_get")]
            public static extern int EnableMarkupGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_ENABLE_AUTO_SCROLL_get")]
            public static extern int EnableAutoScrollGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_AUTO_SCROLL_SPEED_get")]
            public static extern int AutoScrollSpeedGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_AUTO_SCROLL_LOOP_COUNT_get")]
            public static extern int AutoScrollLoopCountGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_AUTO_SCROLL_GAP_get")]
            public static extern int AutoScrollGapGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_LINE_SPACING_get")]
            public static extern int LineSpacingGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_UNDERLINE_get")]
            public static extern int UnderlineGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_SHADOW_get")]
            public static extern int ShadowGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_EMBOSS_get")]
            public static extern int EmbossGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_OUTLINE_get")]
            public static extern int OutlineGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TextLabel_Property")]
            public static extern global::System.IntPtr NewTextLabelProperty();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TextLabel_Property")]
            public static extern void DeleteTextLabelProperty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_New__SWIG_0")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_New__SWIG_1")]
            public static extern global::System.IntPtr New(string jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TextLabel__SWIG_0")]
            public static extern global::System.IntPtr NewTextLabel();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TextLabel__SWIG_1")]
            public static extern global::System.IntPtr NewTextLabel(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TextLabel")]
            public static extern void DeleteTextLabel(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_DownCast")]
            public static extern global::System.IntPtr DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_PIXEL_SIZE_get")]
            public static extern int PixelSizeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_ELLIPSIS_get")]
            public static extern int EllipsisGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_LINE_COUNT_get")]
            public static extern int LineCountGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_LINE_WRAP_MODE_get")]
            public static extern int LineWrapModeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_TEXT_DIRECTION_get")]
            public static extern int TextDirectionGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_VERTICAL_LINE_ALIGNMENT_get")]
            public static extern int VerticalLineAlignmentGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_AUTO_SCROLL_STOP_MODE_get")]
            public static extern int AutoScrollStopModeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_AUTO_SCROLL_LOOP_DELAY_get")]
            public static extern int AutoScrollLoopDelayGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_MATCH_SYSTEM_LANGUAGE_DIRECTION_get")]
            public static extern int MatchSystemLanguageDirectionGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_SWIGUpcast")]
            public static extern global::System.IntPtr Upcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_TEXT_FIT_get")]
            public static extern int TextFitGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextLabel_Property_MIN_LINE_SIZE_get")]
            public static extern int MinLineSizeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_Property_FONT_SIZE_SCALE_get")]
            public static extern int FontSizeScaleGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabel_AnchorClickedSignal")]
            public static extern global::System.IntPtr AnchorClickedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabelSignal_Empty")]
            public static extern bool TextLabelSignalEmpty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabelSignal_GetConnectionCount")]
            public static extern uint TextLabelSignalGetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabelSignal_Connect")]
            public static extern void TextLabelSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabelSignal_Disconnect")]
            public static extern void TextLabelSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextLabelSignal_Emit")]
            public static extern void TextLabelSignalEmit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TextLabelSignal")]
            public static extern global::System.IntPtr NewTextLabelSignal();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TextLabelSignal")]
            public static extern void DeleteTextLabelSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}

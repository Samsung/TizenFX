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
        internal static partial class TextEditor
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_TEXT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TextGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_TEXT_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TextColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_FONT_FAMILY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int FontFamilyGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_FONT_STYLE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int FontStyleGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_POINT_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PointSizeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_HORIZONTAL_ALIGNMENT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int HorizontalAlignmentGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_VERTICAL_ALIGNMENT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int VerticalAlignmentGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_SCROLL_THRESHOLD_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollThresholdGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_SCROLL_SPEED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollSpeedGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_PRIMARY_CURSOR_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PrimaryCursorColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_SECONDARY_CURSOR_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SecondaryCursorColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_ENABLE_CURSOR_BLINK_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EnableCursorBlinkGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_CURSOR_BLINK_INTERVAL_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int CursorBlinkIntervalGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_CURSOR_BLINK_DURATION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int CursorBlinkDurationGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_CURSOR_WIDTH_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int CursorWidthGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_GRAB_HANDLE_IMAGE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GrabHandleImageGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_GRAB_HANDLE_PRESSED_IMAGE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GrabHandlePressedImageGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_SELECTION_POPUP_STYLE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SelectionPopupStyleGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_SELECTION_HANDLE_IMAGE_LEFT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SelectionHandleImageLeftGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_SELECTION_HANDLE_IMAGE_RIGHT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SelectionHandleImageRightGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_SELECTION_HANDLE_PRESSED_IMAGE_LEFT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SelectionHandlePressedImageLeftGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_SELECTION_HANDLE_PRESSED_IMAGE_RIGHT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SelectionHandlePressedImageRightGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_SELECTION_HANDLE_MARKER_IMAGE_LEFT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SelectionHandleMarkerImageLeftGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_SELECTION_HANDLE_MARKER_IMAGE_RIGHT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SelectionHandleMarkerImageRightGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_SELECTION_HIGHLIGHT_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SelectionHighlightColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_DECORATION_BOUNDING_BOX_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int DecorationBoundingBoxGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_ENABLE_MARKUP_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EnableMarkupGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_INPUT_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InputColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_INPUT_FONT_FAMILY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InputFontFamilyGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_INPUT_FONT_STYLE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InputFontStyleGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_INPUT_POINT_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InputPointSizeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_LINE_SPACING_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LineSpacingGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_INPUT_LINE_SPACING_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InputLineSpacingGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_RELATIVE_LINE_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RelativeLineHeightGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_UNDERLINE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int UnderlineGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_INPUT_UNDERLINE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InputUnderlineGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_SHADOW_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ShadowGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_INPUT_SHADOW_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InputShadowGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_EMBOSS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EmbossGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_INPUT_EMBOSS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InputEmbossGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_OUTLINE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int OutlineGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_INPUT_OUTLINE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InputOutlineGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_New_With_Style", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New([MarshalAs(UnmanagedType.U1)] bool hasStyle);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TextEditor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteTextEditor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_GetInputMethodContext", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetInputMethodContext(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_TextChangedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr TextChangedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_CursorPositionChangedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr CursorPositionChangedSignal(IntPtr pTextEditor);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_MaxLengthReachedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr MaxLengthReachedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_SelectionClearedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr SelectionClearedSignal(IntPtr pTextEditor);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_SelectionStartedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr SelectionStartedSignal(IntPtr pTextEditor);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_AnchorClickedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr AnchorClickedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_SelectionChangedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr SelectionChangedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditorSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool TextEditorSignalEmpty(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditorSignal_GetConnectionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint TextEditorSignalGetConnectionCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditorSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TextEditorSignalConnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditorSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TextEditorSignalDisconnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditorSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TextEditorSignalEmit(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TextEditorSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewTextEditorSignal();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TextEditorSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteTextEditorSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextEditor_Property_ENABLE_SHIFT_SELECTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EnableShiftSelectionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextEditor_Property_MATCH_SYSTEM_LANGUAGE_DIRECTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int MatchSystemLanguageDirectionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextEditor_Property_PIXEL_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PixelSizeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextEditor_Property_LINE_COUNT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LineCountGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextEditor_Property_PLACEHOLDER_TEXT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PlaceholderTextGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextEditor_Property_PLACEHOLDER_TEXT_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PlaceholderTextColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextEditor_Property_ENABLE_SELECTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EnableSelectionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextEditor_Property_PLACEHOLDER_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PlaceholderGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_SelectWholeText", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SelectWholeText(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_SelectText", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SelectText(IntPtr textEditorRef, uint start, uint end);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_SELECTED_TEXT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SelectedTextGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_SelectNone", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SelectNone(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextEditor_Property_LINE_WRAP_MODE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LineWrapModeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextEditor_Property_SMOOTH_SCROLL_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SmoothScrollGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextEditor_Property_SMOOTH_SCROLL_DURATION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SmoothScrollDurationGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextEditor_Property_ENABLE_SCROLL_BAR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EnableScrollBarGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextEditor_Property_SCROLL_BAR_SHOW_DURATION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollBarShowDurationGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextEditor_Property_SCROLL_BAR_FADE_DURATION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollBarFadeDurationGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_MAX_LENGTH_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int MaxLengthGet();

            //manual pinvoke for text-editor ScrollStateChangedSignal
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_ScrollStateChangedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ScrollStateChangedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_SELECTED_TEXT_START_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SelectedTextStartGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_SELECTED_TEXT_END_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SelectedTextEndGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_ENABLE_EDITING_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EnableEditingGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_HORIZONTAL_SCROLL_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int HorizontalScrollPositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_VERTICAL_SCROLL_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int VerticalScrollPositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_PRIMARY_CURSOR_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PrimaryCursorPositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_ScrollBy", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScrollBy(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_FONT_SIZE_SCALE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int FontSizeScaleGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_ENABLE_FONT_SIZE_SCALE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EnableFontSizeScaleGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_GRAB_HANDLE_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GrabHandleColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_ENABLE_GRAB_HANDLE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EnableGrabHandleGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_ENABLE_GRAB_HANDLE_POPUP_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EnableGrabHandlePopupGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_INPUT_METHOD_SETTINGS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InputMethodSettingsGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextEditor_Property_MIN_LINE_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int MinLineSizeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextEditor_Property_ELLIPSIS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EllipsisGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_TextEditor_Property_ELLIPSIS_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EllipsisPositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_INPUT_FILTER_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InputFilterGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_InputFilteredSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr InputFilteredSignal(IntPtr textEditorRef);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_GetTextSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetTextSize(IntPtr textEditorRef, uint start, uint end);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_GetTextPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetTextPosition(IntPtr textEditorRef, uint start, uint end);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_CopyText", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string CopyText(IntPtr textEditorRef);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_CutText", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string CutText(IntPtr textEditorRef);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_PasteText", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void PasteText(IntPtr textEditorRef);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_STRIKETHROUGH_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int StrikethroughGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_CHARACTER_SPACING_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int CharacterSpacingGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_REMOVE_FRONT_INSET_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RemoveFrontInsetGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_REMOVE_BACK_INSET_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RemoveBackInsetGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_RegisterFontVariationProperty", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RegisterFontVariationProperty(IntPtr textEditorRef, string pTag);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextEditor_Property_ENABLE_CURSOR_INSET_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EnableCursorInsetGet();
        }
    }
}





